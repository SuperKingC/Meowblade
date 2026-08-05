using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.InstanceZones;
using UI.LegendItemDungeon;
using UI.MilitaryIntelligence;

namespace Shift.Legion.Common.Managers;

public class StoryManager : Manager
{
	public static class LineOfStory
	{
		public static string Data(string linekey)
		{
			GDEStoryData gDEStoryData = GDMgr.Get<GDEStoryData>(linekey);
			return gDEStoryData.StoryId;
		}

		public static bool TryGetValue(string linekey, out string storyid)
		{
			if (_lineOfStory == null)
			{
				_lineOfStory = new Dictionary<string, string>();
			}
			GDEStoryData gDEStoryData = GDMgr.Get<GDEStoryData>(linekey);
			storyid = gDEStoryData.StoryId;
			return true;
		}
	}

	public static class StoryLineData
	{
		public static GDEStoryData Data(string key)
		{
			if (!_storyLineData.ContainsKey(key))
			{
				GDEStoryData gDEStoryData = GDMgr.Get<GDEStoryData>(key);
				if (gDEStoryData == null)
				{
					ILRuntimeDebug.LogError("Error! StoryLineData Get key = {0}", key);
					return null;
				}
				_storyLineData.Add(key, gDEStoryData);
			}
			return _storyLineData[key];
		}

		public static bool TryGetValue(string key, out GDEStoryData _data)
		{
			if (_storyLineData == null)
			{
				_storyLineData = new Dictionary<string, GDEStoryData>();
			}
			if (!_storyLineData.ContainsKey(key))
			{
				GDEStoryData gDEStoryData = GDMgr.Get<GDEStoryData>(key);
				if (gDEStoryData == null)
				{
					_data = null;
					return false;
				}
				_storyLineData.Add(key, gDEStoryData);
			}
			_data = _storyLineData[key];
			return true;
		}
	}

	private static readonly string[] GvG3Stories = new string[2] { "Story11313", "Story6206" };

	private static Dictionary<string, List<string>> _storyLines;

	private static Dictionary<string, string> _lineOfStory;

	private static Dictionary<string, GDEStoryData> _storyLineData;

	private readonly Dictionary<string, string> _triggers = new Dictionary<string, string>();

	public static Func<string, Task<PlayStoryResponse>> SendPlayStoryRequest;

	public List<string> ActivatedStories => Managers.UserArchiveManager.GetUndergoingStories() ?? new List<string>();

	public List<string> PlayingStories => Managers.UserArchiveManager.GetPlayingStories() ?? new List<string>();

	public Dictionary<string, string> PlayingStoriesLine => Managers.UserArchiveManager.GetPlayingStoriesLine() ?? new Dictionary<string, string>();

	public static Dictionary<string, List<string>> StoryLines
	{
		get
		{
			if (_storyLines == null)
			{
				string json = GDMgr.LoadGameDataFileAllText(null, "StoryLine");
				_storyLines = JsonHelper.ToObject<Dictionary<string, List<string>>>(json);
				GDMgr.ReleaseGameDataFileAllText("StoryLine");
			}
			return _storyLines;
		}
	}

	public StoryManager(GameManagers managers)
		: base(managers)
	{
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<string, CustomTaskCompletionSource<bool>>("STORY_REQUEST_TO_BEGIN", StoryRequestToBegin);
		Managers.Messenger.AddListener<string>("STORY_END", StoryEnd);
		Managers.Messenger.AddListener("APP_QUIT", OnApplicationQuit);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<string, CustomTaskCompletionSource<bool>>("STORY_REQUEST_TO_BEGIN", StoryRequestToBegin);
		Managers.Messenger.RemoveListener<string>("STORY_END", StoryEnd);
		Managers.Messenger.RemoveListener("APP_QUIT", OnApplicationQuit);
	}

	private void OnApplicationQuit()
	{
	}

	public async Task Skip(string uiName = null)
	{
		Managers.Messenger.Broadcast("STORY_SKIP", uiName);
		await SkipCurrentStory(uiName);
	}

	private async Task SkipCurrentStory(string uiName = null)
	{
		List<string> playingStories = PlayingStories;
		if (playingStories.Count == 0)
		{
			return;
		}
		string storyId = playingStories[0];
		string trigger = GetStoryTrigger(storyId);
		Managers.TriggerManager.RemoveTrigger(trigger);
		List<string> lines = StoryLines[storyId];
		if (!PlayingStoriesLine.TryGetValue(storyId, out var currentLineKey))
		{
			currentLineKey = lines[0];
		}
		bool started = false;
		object unlockConf = default(object);
		foreach (string lineKey in lines)
		{
			if (!started)
			{
				started = currentLineKey == lineKey;
			}
			if (!started)
			{
				continue;
			}
			GDEStoryData line = StoryLineData.Data(lineKey);
			if (line.Action == "ActivateStory" || line.Action == "PickUpMission" || line.Action == "StoryEnd")
			{
				Dictionary<string, object> lineDict = GenerateScriptLineDict(line);
				CustomTaskCompletionSource<bool> taskCompletionSource = new CustomTaskCompletionSource<bool>();
				CustomScript.ScriptRunner(taskCompletionSource, Managers, lineDict, 3000);
				if (!taskCompletionSource.IsAsync)
				{
					taskCompletionSource.TrySetResult(result: true);
				}
				await taskCompletionSource.Task;
			}
			else if (line.Action == "OpenUI")
			{
				Dictionary<string, object> linePayload = JsonHelper.ToObject<Dictionary<string, object>>(line.Payload);
				if (linePayload["UI"].ToString() == "UI_TakeItems" && linePayload.TryGetValue("PackageId", out var packageId))
				{
					foreach (KeyValuePair<Bonus, int> item in Managers.LotteryManager.GetLotteryAsListById(packageId.ToString()))
					{
						Bonus bonus = item.Key;
						bonus.Claim(Managers, null, null, forceClaim: true, broadcastInform: false);
					}
				}
				packageId = null;
			}
			else if (line.Action == "Bonus")
			{
				bool inform = false;
				foreach (KeyValuePair<string, object> bonusKv in JsonHelper.ToObject<Dictionary<string, object>>(line.Payload))
				{
					string key = bonusKv.Key;
					string text = key;
					string text2 = text;
					if (!(text2 == "AutoProduce"))
					{
						if (text2 == "Unlock")
						{
							List<string> list_str = new List<string>();
							if (bonusKv.Value is ArrayList)
							{
								foreach (object val in (ArrayList)bonusKv.Value)
								{
									list_str.Add(val.ToString());
								}
							}
							else
							{
								list_str = JsonHelper.ToObject<List<string>>(bonusKv.Value.ToString());
							}
							Bonus.Get(bonusKv.Key, list_str).Claim(Managers, null, null, forceClaim: true, inform);
						}
						else
						{
							Bonus.Get(bonusKv.Key, bonusKv.Value).Claim(Managers, null, null, forceClaim: true, inform);
						}
					}
					else
					{
						Bonus.Get(bonusKv.Key, JsonHelper.ToObject<Dictionary<string, int>>(bonusKv.Value.ToString())).Claim(Managers, null, null, forceClaim: true, inform);
					}
				}
			}
			else if (line.Action == "InsertToDynamicPrizePool")
			{
				Dictionary<string, object> linePayload2 = JsonHelper.ToObject<Dictionary<string, object>>(line.Payload);
				foreach (KeyValuePair<string, object> insertKv in linePayload2)
				{
					string dynamicPrizePoolId = insertKv.Key;
					if (Managers.LotteryManager.DynamicPrizePoolConfigs.TryGetValue(dynamicPrizePoolId, out var config))
					{
						Dictionary<string, List<int>> insertItems = JsonHelper.ToObject<Dictionary<string, List<int>>>(insertKv.Value.ToString());
						DynamicPrizePoolConfig dynamicPrizePoolConfig = config.GetValue();
						dynamicPrizePoolConfig.AddToContent(insertItems.ToArray());
						config.SetValue(dynamicPrizePoolConfig);
						config = null;
					}
				}
			}
			else
			{
				if (!(line.Action == "UnlockMainCityCom"))
				{
					continue;
				}
				if (JsonHelper.ToObject<Dictionary<string, object>>(line.Payload)?.TryGetValue("Component", out unlockConf) ?? false)
				{
					string[] array = unlockConf.ToString().Split(',');
					for (int i = 0; i < array.Length; i++)
					{
						ArchiveExtension_UI.UnlockMainCityCom(componentName: array[i], manager: Managers.UserArchiveManager);
					}
				}
				unlockConf = null;
			}
		}
		Managers.UserArchiveManager.RemovePlayingStory(storyId);
	}

	public void CleanResidualStories()
	{
		string[] array = PlayingStories.ToArray();
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (StoryLines.TryGetValue(text, out var value) && PlayingStoriesLine.TryGetValue(text, out var value2) && value.Last() == value2)
			{
				Managers.UserArchiveManager.RemovePlayingStory(text);
			}
		}
	}

	public void StoryRequestToBegin(string storyId, TaskCompletionSource<bool> taskCompletionSource = null)
	{
		CleanResidualStories();
		Managers.TriggerManager.RemoveTrigger(GetStoryTrigger(storyId));
		bool flag = ActivatedStories.Contains(storyId);
		bool flag2 = PlayingStories.Contains(storyId);
		if (!flag && !flag2)
		{
			if (taskCompletionSource != null)
			{
				Managers.Messenger.Broadcast("CUSTOM_ACTION_FINISH", taskCompletionSource, arg2: false);
			}
			return;
		}
		if (!flag2)
		{
			Managers.UserArchiveManager.AddPlayingStory(storyId);
		}
		bool flag3 = PlayingStories[0] == storyId;
		if (taskCompletionSource != null)
		{
			Managers.Messenger.Broadcast("CUSTOM_ACTION_FINISH", taskCompletionSource, flag3);
		}
		if (flag3)
		{
			Managers.Messenger.Broadcast("STORY_BEGIN", storyId);
		}
		DeactivateStory(storyId);
	}

	private void StoryEnd(string storyId)
	{
		List<string> playingStories = PlayingStories;
		if (playingStories.Count > 0 && playingStories[0] == storyId)
		{
			Managers.UserArchiveManager.RemovePlayingStory(storyId);
		}
		if (PlayingStories.Count > 0 && !storyId.Contains("FAKESTROYID"))
		{
			string storyId2 = PlayingStories[0];
			if (CheckMilitaryIntelligenceStory(storyId2))
			{
				PlayStory(Managers, storyId2);
			}
		}
	}

	private bool CheckMilitaryIntelligenceStory(string storyId)
	{
		List<string> list = StoryLines[storyId];
		string key = list[0];
		StoryLineData.TryGetValue(key, out var _data);
		if (_data == null)
		{
			return true;
		}
		if (!_data.IsMilitaryIntelligence)
		{
			return true;
		}
		bool flag = GameController.Contexts.Service<IUiService>().HasShowingUi(UI_MilitaryIntelligencePanel.Name);
		bool flag2 = GameController.Contexts.Service<IUiService>().HasShowingUi(UI_InstanceZonesPanel.Name) || GameController.Contexts.Service<IUiService>().HasShowingUi(UI_LegendItemDungeonPanel.Name);
		bool flag3 = flag && !flag2;
		if (!flag3)
		{
			GameManagers.Instance.StoryManager.ActivateStory(storyId);
		}
		return flag3;
	}

	public static Dictionary<string, object> GenerateScriptLineDict(GDEStoryData line)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			{ "Key", line.Key },
			{ "StartTrigger", line.StartTrigger },
			{ "ActionName", line.Action },
			{ "ActionPayload", line.Payload },
			{ "NextTrigger", line.NextTrigger }
		};
		if (line.Action == "StoryBegin")
		{
			dictionary["NextTrigger"] = "Waiting";
			dictionary["ActionPayload"] = line.StoryId;
		}
		if (line.Action == "StoryEnd")
		{
			dictionary["ActionPayload"] = line.StoryId;
		}
		return dictionary;
	}

	public override Task Init()
	{
		return null;
	}

	public void LoadStories()
	{
		foreach (string item in ActivatedStories.ToList())
		{
			string storyTrigger = GetStoryTrigger(item);
			if (storyTrigger != null)
			{
				Managers.TriggerManager.SetupTrigger(storyTrigger);
			}
		}
	}

	public static GDEStoryData GetStoryLineData(string storyId, string lineKey = null)
	{
		if (lineKey == null)
		{
			lineKey = StoryLines[storyId][0];
		}
		return StoryLineData.Data(lineKey);
	}

	public void ActivateStory(string storyId, Dictionary<string, string> replaceActivateTriggerDict = null)
	{
		if (!ActivatedStories.Contains(storyId))
		{
			Managers.UserArchiveManager.AddUndergoingStory(storyId);
		}
		string storyTrigger = GetStoryTrigger(storyId);
		if (storyTrigger != null)
		{
			Managers.TriggerManager.SetupTrigger(storyTrigger);
		}
	}

	public void DeactivateStory(string storyId)
	{
		if (ActivatedStories.Contains(storyId))
		{
			Managers.UserArchiveManager.RemoveFromUndergoingStories(storyId);
			string storyTrigger = GetStoryTrigger(storyId);
			if (storyTrigger != null)
			{
				Managers.TriggerManager.RemoveTrigger(storyTrigger);
			}
		}
	}

	public string GetStoryTrigger(string storyId)
	{
		if (_triggers.TryGetValue(storyId, out var value))
		{
			return value;
		}
		if (!StoryLines.TryGetValue(storyId, out var value2) || value2.Count < 1)
		{
			return null;
		}
		if (!StoryLineData.TryGetValue(value2[0], out var _data))
		{
			return null;
		}
		Dictionary<string, object> dictionary = GenerateScriptLineDict(_data);
		string text = dictionary["StartTrigger"].ToString();
		string actionName = dictionary["ActionName"].ToString();
		string actionPayload = dictionary["ActionPayload"].ToString();
		string nextTrigger = dictionary["NextTrigger"].ToString();
		dictionary.TryGetValue("Owner", out var _);
		dictionary.TryGetValue("Key", out var _);
		value = Managers.TriggerManager.CreateTrigger(text);
		Managers.TriggerManager.AddCustomAction(value, _data.Key, text, actionName, actionPayload, nextTrigger);
		_triggers.Add(storyId, value);
		return value;
	}

	public static void PlayStoryByLineKey(GameManagers managers, string storyLineKey)
	{
		string storyId = LineOfStory.Data(storyLineKey);
		PlayStory(managers, storyId);
	}

	public static void PlayStoryWithOutServer(GameManagers managers, string storyId, int timeout = 3000)
	{
		Action action = async delegate
		{
			List<string> lines = StoryLines[storyId];
			string trigger = managers.StoryManager.GetStoryTrigger(storyId);
			managers.TriggerManager.RemoveTrigger(trigger);
			string startKey = lines[0];
			bool started = false;
			for (int i = 0; i < lines.Count; i++)
			{
				string key = lines[i];
				if (!started)
				{
					started = key == startKey;
				}
				if (started)
				{
					GDEStoryData lineData = StoryLineData.Data(key);
					Dictionary<string, object> lineDict = GenerateScriptLineDict(lineData);
					CustomTaskCompletionSource<bool> taskCompletionSource = new CustomTaskCompletionSource<bool>
					{
						Skip = false
					};
					CustomScript.ScriptRunnerWithOutServer(taskCompletionSource, managers, lineDict, 3000, lineData.CanSkip);
					if (!taskCompletionSource.IsAsync)
					{
						taskCompletionSource.TrySetResult(result: true);
					}
					await taskCompletionSource.Task;
					if (taskCompletionSource.Skip)
					{
						taskCompletionSource.TrySetResult(result: false);
						managers.Messenger.Broadcast("NEW_GUIDE_MISSION_SKIP_STORY", lineData.StoryId);
						break;
					}
				}
			}
		};
		action();
	}

	public static void PlayStory(GameManagers managers, string storyId, int timeout = 3000)
	{
		if (!CheckGvG3Available(storyId))
		{
			return;
		}
		List<string> lines = StoryLines[storyId];
		string text = lines[0];
		StoryLineData.TryGetValue(text, out var _data);
		if (_data == null)
		{
			ILRuntimeDebug.LogError("Can't Find storyLineKey=" + text);
		}
		if (!_data.ServerSave && GameManagers.Instance.UserArchiveManager.IsNewGuideMode() && _data.IsNewGuide)
		{
			PlayStoryWithOutServer(managers, storyId);
			return;
		}
		ILRequestHelper<PlayStoryResponse>.Request(null, () => SendPlayStoryRequest(storyId), async delegate(PlayStoryResponse response)
		{
			if (response != null && !response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				string trigger = managers.StoryManager.GetStoryTrigger(storyId);
				managers.TriggerManager.RemoveTrigger(trigger);
				string startKey = (string.IsNullOrEmpty(response.PlayingStoreLine) ? lines[0] : response.PlayingStoreLine);
				bool started = false;
				foreach (string key in lines)
				{
					if (!started)
					{
						started = key == startKey;
					}
					if (started)
					{
						GDEStoryData lineData = StoryLineData.Data(key);
						Dictionary<string, object> lineDict = GenerateScriptLineDict(lineData);
						CustomTaskCompletionSource<bool> taskCompletionSource = new CustomTaskCompletionSource<bool>();
						CustomScript.ScriptRunner(taskCompletionSource, managers, lineDict, 3000);
						if (!taskCompletionSource.IsAsync)
						{
							taskCompletionSource.TrySetResult(result: true);
						}
						await taskCompletionSource.Task;
						List<string> playingStories = managers.StoryManager.PlayingStories;
						if (playingStories.Count >= 1 && !(playingStories[0] == storyId))
						{
							break;
						}
					}
				}
			}
		}, 1f);
	}

	private static bool CheckGvG3Available(string storyId)
	{
		return !GvG3Stories.Contains(storyId) || Define.GvGMode3UnderDevelopment();
	}

	public void SetPlayingStoryLine(string storyId, string lineKey)
	{
		if (!PlayingStoriesLine.ContainsKey(storyId))
		{
			PlayingStoriesLine.Add(storyId, lineKey);
		}
		else
		{
			PlayingStoriesLine[storyId] = lineKey;
		}
		Managers.UserArchiveManager.SetPlayingStoryLine(storyId, lineKey);
	}

	public string GetPlayingStoryLine(string storyId)
	{
		Dictionary<string, string> playingStoriesLine = Managers.UserArchiveManager.GetPlayingStoriesLine();
		if (playingStoriesLine.TryGetValue(storyId, out var value))
		{
			return value;
		}
		return null;
	}

	public void SetReviewingStory(string attachedStoryId, string reviewingStoryId)
	{
	}

	public void GetReviewingStory(string attachedStoryId)
	{
	}

	public void RemoveReviewingStory(string attachedStoryId)
	{
	}
}
