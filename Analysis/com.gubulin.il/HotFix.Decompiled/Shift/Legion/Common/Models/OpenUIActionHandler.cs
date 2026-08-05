using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyGUI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UI.Battle;
using UI.GameActivity;
using UI.MainCity;

namespace Shift.Legion.Common.Models;

public class OpenUIActionHandler : IStoryActionHandler
{
	public string ActionId()
	{
		return "OpenUI";
	}

	public Action Handle(GameManagers managers, string actionName, string actionPayload, CustomTaskCompletionSource<bool> taskCompletionSource, string nextTrigger)
	{
		Dictionary<string, object> dictionary = CustomScript.ParseActionPayloadToDict(actionPayload);
		string text;
		if (!dictionary.TryGetValue("UI", out var value) || (text = value.ToString()).Length <= 0)
		{
			taskCompletionSource?.TrySetResult(result: true);
			return null;
		}
		if (text == "UI_MainCity")
		{
			string text2 = "MainCity.Right";
			if (dictionary.TryGetValue("Scene", out var value2) && value2.ToString() == "MainCity.Left")
			{
				text2 = "MainCity.Left";
			}
			if (dictionary.TryGetValue("JumpType", out var value3) && value3.ToString() == "NewGuideMission" && GameController.Contexts.Service<BaseSceneService>().CurrentScene == text2)
			{
				taskCompletionSource?.TrySetResult(result: true);
				return null;
			}
			SceneArguments sceneArguments = new SceneArguments(new Dictionary<string, object>
			{
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", taskCompletionSource },
				{
					"LoadingAnimationDirection",
					LoadingAnimationDirection.Left
				}
			});
			if (dictionary.TryGetValue("TimeLine", out var value4) && value4.ToString() == "MainCity.LordAppear")
			{
				sceneArguments.Data.Add("TimeLineMainCity", value4.ToString());
			}
			CommandFactory.CreateOpenSceneCommand(text2, sceneArguments);
			return null;
		}
		if (text == UI_Battle.Name)
		{
			if (dictionary.TryGetValue("JumpType", out var value5) && value5.ToString() == "NewGuideMission" && GameController.Contexts.Service<BaseSceneService>().CurrentScene == "BattleField")
			{
				taskCompletionSource?.TrySetResult(result: true);
				return null;
			}
			string value7;
			if (dictionary.TryGetValue("LevelId", out var value6))
			{
				value7 = value6.ToString();
			}
			else
			{
				value7 = managers.UserArchiveManager.GetCurrentLevelId();
				if (string.IsNullOrEmpty(value7))
				{
					List<Region> list = WorldMapManager.Regions.Values.ToList();
					foreach (Region region in list)
					{
						RegionStatus regionStatus = region.Status(GameManagers.Instance);
						if (regionStatus == RegionStatus.Locked || regionStatus == RegionStatus.Occupied)
						{
							continue;
						}
						if (regionStatus == RegionStatus.Unlocked)
						{
							ILRequestHelper<UnlockRegionResponse>.Request((EventContext)null, (Func<Task<UnlockRegionResponse>>)(() => GameController.Contexts.Service<INetworkService>().UnlockRegion(-1L, region.RegionId)), (Action<UnlockRegionResponse>)delegate(UnlockRegionResponse response)
							{
								if (!response.Result)
								{
									ILRequestHelper.ShowErrorCode(response.ErrorCode);
								}
								else
								{
									region.ClaimUnlockBonuses(GameManagers.Instance);
								}
							});
						}
						value7 = region.CurrentLevelId(GameManagers.Instance);
					}
				}
			}
			SceneBattleFieldArguments sceneBattleFieldArguments = new SceneBattleFieldArguments(new Dictionary<string, object>
			{
				{ "LevelId", value7 },
				{ "Asset", "Prefabs/BattleField" },
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", taskCompletionSource }
			});
			if (dictionary.TryGetValue("OpenUIOnReturn", out var value8))
			{
				sceneBattleFieldArguments.OpenUiOnReturn = value8.ToString();
			}
			CommandFactory.CreateOpenSceneCommand("BattleField", sceneBattleFieldArguments);
			return null;
		}
		Dictionary<string, object> dictionary2;
		switch (text)
		{
		case "UI_PlotDialog":
		{
			if (!dictionary.ContainsKey("StoryScript"))
			{
				taskCompletionSource?.TrySetResult(result: true);
				return null;
			}
			StoryScript storyScript = StoryScript.Get(dictionary["StoryScript"].ToString());
			if (storyScript.formattedScriptList.Count <= 0)
			{
				taskCompletionSource?.TrySetResult(result: true);
				return null;
			}
			dictionary2 = new Dictionary<string, object>
			{
				{ "StoryScripts", storyScript.formattedScriptList },
				{ "taskCompletionSource", taskCompletionSource }
			};
			break;
		}
		case "UI_Guide":
		{
			if (!dictionary.ContainsKey("Guide"))
			{
				taskCompletionSource?.TrySetResult(result: true);
				return null;
			}
			GuideScript guideScript = new GuideScript(dictionary["Guide"].ToString());
			if (guideScript.configParams.Count <= 0)
			{
				taskCompletionSource?.TrySetResult(result: true);
				return null;
			}
			dictionary2 = guideScript.configParams;
			dictionary2.Add("taskCompletionSource", taskCompletionSource);
			break;
		}
		case "UI_TakeItems":
			dictionary2 = dictionary;
			dictionary2.Add("taskCompletionSource", taskCompletionSource);
			break;
		case "UI_FullScreenAnimationPanel":
			if (!dictionary.ContainsKey("GifUrl"))
			{
				taskCompletionSource?.TrySetResult(result: true);
				return null;
			}
			dictionary2 = dictionary;
			dictionary2.Add("taskCompletionSource", taskCompletionSource);
			break;
		default:
			if (text == UI_main_DeparturePresent.Name)
			{
				dictionary2 = dictionary;
				dictionary2.Add("Tab", 15);
				UI_MainCity.OnClickRechargeActivityExt(dictionary2);
				taskCompletionSource?.TrySetResult(result: true);
				return null;
			}
			dictionary2 = dictionary;
			break;
		}
		SharedMessenger.Broadcast("ACTION_OPEN_UI", text, dictionary2, (TaskCompletionSource<bool>)taskCompletionSource);
		return null;
	}
}
