using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class CustomScript
{
	public const string ActionStoryBegin = "StoryBegin";

	public const string ActionStoryEnd = "StoryEnd";

	public const string ActionOpenUI = "OpenUI";

	public const string ActionCloseUI = "CloseUI";

	public const string ActionMoveCamera = "MoveCamera";

	public const string ActionPlayAnimation = "PlayAnimation";

	public const string ActionPlayBattleReplay = "PlayBattleReplay";

	public const string ActionPickUpMission = "PickUpMission";

	public const string ActionDeactivateStory = "DeactivateStory";

	public const string ActionActivateStory = "ActivateStory";

	public const string ActionActivateStoryOnNodeVersion = "ActivateStoryOnNodeVersion";

	public const string ActionFireClick = "FireClick";

	public const string ActionScrollToView = "ScrollToView";

	public const string ActionTimeout = "Timeout";

	public const string ActionBonus = "Bonus";

	public const string ActionInsertToDynamicPrizePool = "InsertToDynamicPrizePool";

	public const string ActionBroadcastEvent = "BroadcastEvent";

	public const string ActionUnlockMainCityCom = "UnlockMainCityCom";

	public static Action<CustomTaskCompletionSource<bool>, GameManagers, Dictionary<string, object>, int> ScriptRunner = delegate(CustomTaskCompletionSource<bool> taskCompletionSource, GameManagers managers, Dictionary<string, object> line, int timeout)
	{
		if (line != null && line.Count != 0)
		{
			string actionName = line["ActionName"].ToString();
			string actionPayload = line["ActionPayload"].ToString();
			string nextTrigger = line["NextTrigger"].ToString();
			line.TryGetValue("Key", out var value);
			if (value != null)
			{
				string lineKey = value.ToString();
				if (StoryManager.LineOfStory.TryGetValue(lineKey, out var storyId))
				{
					if (taskCompletionSource != null)
					{
						taskCompletionSource.IsAsync = true;
					}
					ILRequestHelper<TriggerStoryResponse>.Request(null, null, async delegate
					{
						CustomTaskCompletionSource<bool> lineCompletionSource = new CustomTaskCompletionSource<bool>
						{
							IsAsync = false
						};
						managers.CustomScriptManager.AddPendingAction(lineCompletionSource);
						if (actionName == "OpenUI" && GameController.Contexts.gameState.hasLoadingPanelStatus && GameController.Contexts.gameState.loadingPanelStatus.value != LoadingPanelStatus.Closed)
						{
							await Task.Delay(35);
						}
						Action callback = DoAction(managers, actionName, actionPayload, lineCompletionSource, nextTrigger);
						if (callback == null)
						{
							managers.StoryManager.SetPlayingStoryLine(storyId, lineKey);
						}
						if (!(nextTrigger == "Waiting") && !lineCompletionSource.IsAsync)
						{
							lineCompletionSource.TrySetResult(result: true);
							taskCompletionSource?.TrySetResult(result: true);
						}
						if (!(await lineCompletionSource.Task))
						{
							taskCompletionSource?.TrySetResult(result: false);
						}
						else
						{
							if (callback != null)
							{
								callback();
								managers.StoryManager.SetPlayingStoryLine(storyId, lineKey);
							}
							taskCompletionSource?.TrySetResult(result: true);
						}
					}, 1f);
				}
			}
		}
	};

	public static Action<CustomTaskCompletionSource<bool>, GameManagers, Dictionary<string, object>, int, bool> ScriptRunnerWithOutServer = delegate(CustomTaskCompletionSource<bool> taskCompletionSource, GameManagers managers, Dictionary<string, object> line, int timeout, bool CanSkip)
	{
		if (line != null && line.Count != 0)
		{
			string actionName = line["ActionName"].ToString();
			string actionPayload = line["ActionPayload"].ToString();
			string nextTrigger = line["NextTrigger"].ToString();
			line.TryGetValue("Key", out var value);
			if (value != null)
			{
				string lineKey = value.ToString();
				if (StoryManager.LineOfStory.TryGetValue(lineKey, out var storyId))
				{
					if (taskCompletionSource != null)
					{
						taskCompletionSource.IsAsync = true;
					}
					Action action = async delegate
					{
						CustomTaskCompletionSource<bool> lineCompletionSource = new CustomTaskCompletionSource<bool>
						{
							IsAsync = false,
							CanSkip = CanSkip,
							Skip = false
						};
						managers.CustomScriptManager.AddPendingAction(lineCompletionSource);
						int changeId = Contexts.sharedInstance.Service<IUiService>().SetUiNotTouchable(null);
						while (actionName == "OpenUI" && GameController.Contexts.gameState.hasLoadingPanelStatus && GameController.Contexts.gameState.loadingPanelStatus.value != LoadingPanelStatus.Closed)
						{
							await Task.Delay(35);
						}
						Action callback = DoAction(managers, actionName, actionPayload, lineCompletionSource, nextTrigger);
						if (callback == null)
						{
							managers.StoryManager.SetPlayingStoryLine(storyId, lineKey);
						}
						if (nextTrigger == "Waiting")
						{
							if (actionName != "Timeout")
							{
								Contexts.sharedInstance.Service<IUiService>().SetUiTouchable(changeId);
							}
						}
						else if (!lineCompletionSource.IsAsync)
						{
							lineCompletionSource.TrySetResult(result: true);
							taskCompletionSource?.TrySetResult(result: true);
						}
						if (!(await lineCompletionSource.Task))
						{
							Contexts.sharedInstance.Service<IUiService>().SetUiTouchable(changeId);
							taskCompletionSource?.TrySetResult(result: false);
						}
						else if (lineCompletionSource.Skip)
						{
							Contexts.sharedInstance.Service<IUiService>().SetUiTouchable(changeId);
							taskCompletionSource.Skip = true;
							taskCompletionSource?.TrySetResult(result: false);
						}
						else
						{
							if (callback != null)
							{
								callback();
								managers.StoryManager.SetPlayingStoryLine(storyId, lineKey);
							}
							Contexts.sharedInstance.Service<IUiService>().SetUiTouchable(changeId);
							taskCompletionSource?.TrySetResult(result: true);
						}
					};
					action();
				}
			}
		}
	};

	private static readonly List<IStoryActionHandler> DefaultHandlers = new List<IStoryActionHandler>
	{
		new ActivateStoryActionHandler(),
		new ActivateStoryOnNodeVersionActionHandler(),
		new BonusActionHandler(),
		new BroadcastEventActionHandler(),
		new DeactivateStoryActionHandler(),
		new InsertToDynamicPrizePoolActionHandler(),
		new PickUpMissionActionHandler(),
		new StoryBeginActionHandler(),
		new StoryEndActionHandler(),
		new UnlockMainCityComActionHandler()
	};

	private static Dictionary<string, IStoryActionHandler> _actionHandlers;

	private static Dictionary<string, IStoryActionHandler> ActionHandlers
	{
		get
		{
			if (_actionHandlers == null)
			{
				_actionHandlers = new Dictionary<string, IStoryActionHandler>();
				foreach (IStoryActionHandler defaultHandler in DefaultHandlers)
				{
					_actionHandlers[defaultHandler.ActionId()] = defaultHandler;
				}
			}
			return _actionHandlers;
		}
	}

	public static void AddActionHandler(IStoryActionHandler handler)
	{
		ActionHandlers[handler.ActionId()] = handler;
	}

	public static Action DoAction(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		if (ActionAutomaticSkip(ref actionPayload))
		{
			taskCompletionSource.TrySetResult(result: true);
			return null;
		}
		if (ActionHandlers.TryGetValue(actionName, out var value))
		{
			return value.Handle(managers, actionName, actionPayload, taskCompletionSource, nextTrigger);
		}
		taskCompletionSource.TrySetResult(result: true);
		return null;
	}

	private static bool ActionAutomaticSkip(ref string actionPayload)
	{
		if (string.IsNullOrEmpty(actionPayload) || !actionPayload.Contains(":"))
		{
			return false;
		}
		Dictionary<string, object> dictionary = JsonHelper.ToObject<Dictionary<string, object>>(actionPayload);
		if (!dictionary.TryGetValue("AutoSkip", out var value))
		{
			return false;
		}
		dictionary.Remove("AutoSkip");
		if (value.ToString() == "OnBuildingReady" && dictionary.TryGetValue("SkipBuildingType", out var value2))
		{
			dictionary.Remove("SkipBuildingType");
			string text = value2.ToString();
			if (string.IsNullOrEmpty(text))
			{
				actionPayload = JsonHelper.ToJson(dictionary);
				return false;
			}
			if (GameManagers.Instance.UserArchiveManager.GetBuildingStatus(text) == BuildingStatus.Ready || GameManagers.Instance.UserArchiveManager.GetBuildingStatus(text) == BuildingStatus.Running || GameManagers.Instance.UserArchiveManager.GetBuildingLevel(text) > 0)
			{
				actionPayload = JsonHelper.ToJson(dictionary);
				return true;
			}
			actionPayload = JsonHelper.ToJson(dictionary);
			return false;
		}
		if (value.ToString() == "OnBuildingRunning" && dictionary.TryGetValue("SkipBuildingType", out var value3))
		{
			dictionary.Remove("SkipBuildingType");
			string text2 = value3.ToString();
			if (string.IsNullOrEmpty(text2))
			{
				actionPayload = JsonHelper.ToJson(dictionary);
				return false;
			}
			if (GameManagers.Instance.UserArchiveManager.GetBuildingStatus(text2) == BuildingStatus.Running || GameManagers.Instance.UserArchiveManager.GetBuildingLevel(text2) > 0)
			{
				actionPayload = JsonHelper.ToJson(dictionary);
				return true;
			}
			actionPayload = JsonHelper.ToJson(dictionary);
			return false;
		}
		if (value.ToString() == "OnRegionUnlock" && dictionary.TryGetValue("SkipRegion", out var value4))
		{
			dictionary.Remove("SkipRegion");
			string text3 = value4.ToString();
			if (string.IsNullOrEmpty(text3))
			{
				actionPayload = JsonHelper.ToJson(dictionary);
				return false;
			}
			if (WorldMapManager.Regions.TryGetValue(text3, out var value5) && value5.Status(GameManagers.Instance) != RegionStatus.Unlocked)
			{
				actionPayload = JsonHelper.ToJson(dictionary);
				return true;
			}
			actionPayload = JsonHelper.ToJson(dictionary);
			return false;
		}
		actionPayload = JsonHelper.ToJson(dictionary);
		return false;
	}

	public static Dictionary<string, object> ParseActionPayloadToDict(string actionPayload)
	{
		if (!string.IsNullOrEmpty(actionPayload) && actionPayload.IndexOf(':') > 0)
		{
			return JsonHelper.ToObject<Dictionary<string, object>>(actionPayload);
		}
		return null;
	}
}
