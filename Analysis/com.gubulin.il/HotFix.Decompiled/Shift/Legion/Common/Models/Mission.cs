using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyGUI;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class Mission
{
	public ActivityContentPayload ParentActivityPayload;

	public string _firstTag = null;

	public GDEMissionData Data;

	public Dictionary<string, object> CompleteCaseData;

	public string TriggerKey;

	public List<Bonus> BonusList;

	public Dictionary<string, string> DisplayBonus;

	private MissionType _missionType;

	public DateTimeOffset KickOffTime;

	public TimeSpan ValidPeriod;

	public TimeSpan CyclePeriod;

	public DateTimeOffset ExpireAt;

	public Dictionary<string, int> ClaimFilter_Purchase;

	public List<string> ProgressFilter_MissionClaimed;

	public int UserLevelFilter;

	public int DungeonLevelFilter;

	public List<string> GameLevelFilter;

	public List<string> MissionFilter;

	public Dictionary<string, int> OwnedItemFilter;

	public Dictionary<string, int> PurchaseFilter;

	public List<string> StoryLineNodeVersionFilter;

	public Dictionary<string, string> StoryNodeNextMission;

	public string JumpContext;

	public Dictionary<string, object> JumpContextParams;

	private static List<MissionType> storyLineNodeVersionEnabledMissionTypes = new List<MissionType>
	{
		MissionType.Newbie4,
		MissionType.NewbieSummary4
	};

	public string Id => Data.Key;

	public string FirstTag
	{
		get
		{
			if (_firstTag == null)
			{
				if (Data.Tags.Count == 0)
				{
					_firstTag = string.Empty;
				}
				else
				{
					_firstTag = Data.Tags.First();
				}
			}
			return _firstTag;
		}
	}

	public MissionType MissionType
	{
		get
		{
			if (_missionType == MissionType.NewbieForeign || _missionType == MissionType.Newbie3 || _missionType == MissionType.Newbie4)
			{
				return MissionType.Newbie;
			}
			if (_missionType == MissionType.NewbieSummaryForeign || _missionType == MissionType.NewbieSummary3 || _missionType == MissionType.NewbieSummary4)
			{
				return MissionType.NewbieSummary;
			}
			return _missionType;
		}
		set
		{
			_missionType = value;
		}
	}

	public bool IsExpired => ExpireAt != default(DateTimeOffset) && DateTimeHelper.Now.CompareTo(ExpireAt) == 1;

	public bool IsKickedOff => KickOffTime == default(DateTimeOffset) || DateTimeHelper.Now.CompareTo(KickOffTime) >= 0;

	public string CompleteTriggerId(GameManagers managers)
	{
		if (!managers.MissionManager.MissionCompleteTriggerIds.TryGetValue(Id, out var value))
		{
			value = managers.TriggerManager.CreateTrigger(TriggerKey);
			managers.MissionManager.MissionCompleteTriggerIds[Id] = value;
		}
		return value;
	}

	public MissionConfig MissionState(GameManagers managers)
	{
		Dictionary<string, MissionConfig> value = managers.MissionManager.PickedMissionRecords.GetValue();
		if (!value.TryGetValue(Id, out var value2))
		{
			value2 = new MissionConfig
			{
				MissionId = Id,
				Status = ((!managers.MissionManager.MissionStat.GetValue().MissionClaimRecords.ContainsKey(Id)) ? MissionStatus.Pending : MissionStatus.Claimed)
			};
			foreach (KeyValuePair<string, object> completeCaseDatum in CompleteCaseData)
			{
				value2.Progress.Add(completeCaseDatum.Key, completeCaseDatum.Value);
			}
			value.Add(Id, value2);
			managers.MissionManager.PickedMissionRecords.Save();
			if (!managers.MissionManager.PickedMissions.ContainsKey(Id))
			{
				managers.MissionManager.PickedMissions.Add(Id, this);
			}
		}
		return value2;
	}

	public Mission(GDEMissionData data)
	{
		Data = data;
		MissionType = (MissionType)data.Type;
		DisplayBonus = new Dictionary<string, string>();
		if (!string.IsNullOrEmpty(Data.DisplayBonus))
		{
			foreach (KeyValuePair<string, string> item in JsonHelper.ToObject<Dictionary<string, string>>(Data.DisplayBonus))
			{
				DisplayBonus.Add(item.Key, item.Value);
			}
		}
		BonusList = new List<Bonus>();
		if (!string.IsNullOrEmpty(Data.Bonus))
		{
			foreach (KeyValuePair<string, int> item2 in JsonHelper.ToObject<Dictionary<string, int>>(Data.Bonus))
			{
				BonusList.Add(Bonus.Get(item2.Key, item2.Value));
			}
		}
		JumpContext = Data.JumpContext;
		if (!string.IsNullOrEmpty(Data.JumpContextParams))
		{
			JumpContextParams = JsonHelper.ToObject<Dictionary<string, object>>(Data.JumpContextParams);
		}
		if (!string.IsNullOrEmpty(Data.GameLevelFilter))
		{
			GameLevelFilter = JsonHelper.ToObject<List<string>>(Data.GameLevelFilter);
		}
		if (!string.IsNullOrEmpty(Data.MissionFilter))
		{
			MissionFilter = JsonHelper.ToObject<List<string>>(Data.MissionFilter);
		}
		if (!string.IsNullOrEmpty(Data.OwnedItemFilter))
		{
			OwnedItemFilter = JsonHelper.ToObject<Dictionary<string, int>>(Data.OwnedItemFilter);
		}
		if (!string.IsNullOrEmpty(Data.PurchaseFilter))
		{
			PurchaseFilter = JsonHelper.ToObject<Dictionary<string, int>>(Data.PurchaseFilter);
		}
		StoryLineNodeVersionFilter = new List<string>();
		if (!string.IsNullOrEmpty(Data.StoryLineNodeVersionFilter))
		{
			StoryLineNodeVersionFilter = JsonHelper.ToObject<List<string>>(Data.StoryLineNodeVersionFilter);
		}
		if (!string.IsNullOrEmpty(Data.ClaimFilter_Purchase))
		{
			ClaimFilter_Purchase = JsonHelper.ToObject<Dictionary<string, int>>(Data.ClaimFilter_Purchase);
		}
		if (!string.IsNullOrEmpty(Data.ProgressFilter_MissionClaimed))
		{
			ProgressFilter_MissionClaimed = JsonHelper.ToObject<List<string>>(Data.ProgressFilter_MissionClaimed);
		}
		if (MissionType == MissionType.Weekly || MissionType == MissionType.DailyMission)
		{
			string[] array = Data.KickOffAt.Split(new char[1] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			if (array.Length != 3 || !DateTimeHelper.TryParse(array[0], out KickOffTime))
			{
				throw new ArgumentException($"NDaysCycle Mission格式错误:{KickOffTime}");
			}
			ValidPeriod = TimeSpan.FromDays(int.Parse(array[1]));
			CyclePeriod = TimeSpan.FromDays(int.Parse(array[2]));
		}
		else if (!string.IsNullOrEmpty(Data.KickOffAt))
		{
			DateTimeHelper.TryParse(Data.KickOffAt, out KickOffTime);
		}
		if (!string.IsNullOrEmpty(Data.ExpireAt))
		{
			DateTimeHelper.TryParse(Data.ExpireAt, out ExpireAt);
		}
		CompleteCaseData = ((Data.TriggerPayload.IndexOf(':') == -1) ? new Dictionary<string, object> { { "Payload", Data.TriggerPayload } } : JsonHelper.ToObject<Dictionary<string, object>>(Data.TriggerPayload));
		TriggerKey = Data.CompleteTrigger + ":" + Data.TriggerPayload;
		StoryNodeNextMission = new Dictionary<string, string>();
		if (!string.IsNullOrEmpty(Data.StoryNodeNextMission))
		{
			StoryNodeNextMission = JsonHelper.ToObject<Dictionary<string, string>>(Data.StoryNodeNextMission);
		}
	}

	public string NextMission(GameManagers gameManagers)
	{
		string storyNodeConfigVersion = gameManagers.UserArchiveManager.GetStoryNodeConfigVersion();
		if (StoryNodeNextMission.TryGetValue(storyNodeConfigVersion, out var value))
		{
			return value;
		}
		return Data.NextMission;
	}

	public void RegisterTrigger(GameManagers managers)
	{
		MissionConfig state = MissionState(managers);
		string triggerId = CompleteTriggerId(managers);
		Trigger.ProcessFilterPayload(state.Progress);
		managers.TriggerManager.SetFilterPayload(triggerId, state.Progress);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (ProgressFilter_MissionClaimed != null)
		{
			dictionary["ProgressFilter_MissionClaimed"] = ProgressFilter_MissionClaimed;
		}
		if (dictionary.Count > 0)
		{
			managers.TriggerManager.SetProgressFilterCases(triggerId, dictionary);
		}
		if (MissionType == MissionType.Newbie)
		{
		}
		managers.TriggerManager.SetCallback(triggerId, delegate
		{
			if (state.Status == MissionStatus.Undergoing)
			{
				state.Status = MissionStatus.Completed;
				if (MissionType == MissionType.Newbie)
				{
					CheckMissionStatus(this, delegate(CheckMissionStatusResponse res)
					{
						if (res.Result)
						{
							managers.Messenger.Broadcast("MISSION_COMPLETE", this);
						}
					});
				}
				else
				{
					managers.Messenger.Broadcast("MISSION_COMPLETE", this);
				}
			}
		});
		managers.TriggerManager.SetOnFilterPayloadChanged(triggerId, delegate(Dictionary<string, object> filterPayload)
		{
			state.Progress = DictionaryExtensions.DeepCopy<string, object>(filterPayload);
			Dictionary<string, MissionConfig> value = managers.MissionManager.PickedMissionRecords.GetValue();
			value[Id] = state;
			managers.MissionManager.PickedMissionRecords.Save();
			managers.Messenger.Broadcast("MISSION_PROGRESS_CHANGED", this);
		});
		managers.TriggerManager.SetupTrigger(triggerId);
	}

	private void CheckMissionStatus(Mission mission, Action<CheckMissionStatusResponse> callback)
	{
		ILRequestHelper<CheckMissionStatusResponse>.Request((EventContext)null, (Func<Task<CheckMissionStatusResponse>>)(() => GameController.Contexts.Service<INetworkService>().CheckMissionStatus(mission.Id, (int)mission.MissionState(GameManagers.Instance).Status)), (Action<CheckMissionStatusResponse>)delegate(CheckMissionStatusResponse response)
		{
			callback(response);
		});
	}

	private bool CheckStoryLineNodeVersionEnabled()
	{
		if (storyLineNodeVersionEnabledMissionTypes.Contains(_missionType))
		{
			return true;
		}
		return false;
	}

	public bool CanPickup(GameManagers managers)
	{
		if (MissionState(managers).Status != MissionStatus.Pending)
		{
			return false;
		}
		if (IsExpired || !IsKickedOff)
		{
			return false;
		}
		if (UserLevelFilter > 0 && managers.UserArchiveManager.GetUserLevel() < UserLevelFilter)
		{
			return false;
		}
		if (DungeonLevelFilter > 0 && managers.UserArchiveManager.GetDungeonLevel() < DungeonLevelFilter)
		{
			return false;
		}
		if (GameLevelFilter != null && GameLevelFilter.Count > 0)
		{
			Dictionary<string, List<string>> levelProgress = managers.UserArchiveManager.GetLevelProgress();
			if (levelProgress == null)
			{
				return false;
			}
			List<string> completeLevels = new List<string>();
			foreach (List<string> value4 in levelProgress.Values)
			{
				completeLevels.AddRange(value4);
			}
			if (GameLevelFilter.All((string _levelId) => !completeLevels.Contains(_levelId)))
			{
				return false;
			}
		}
		if (MissionFilter != null && MissionFilter.Count > 0)
		{
			MissionStats value = managers.MissionManager.MissionStat.GetValue();
			foreach (string item in MissionFilter)
			{
				if (!value.MissionClaimRecords.TryGetValue(item, out var value2) || value2 < 1)
				{
					return false;
				}
			}
		}
		if (OwnedItemFilter != null && OwnedItemFilter.Count > 0)
		{
			foreach (KeyValuePair<string, int> item2 in OwnedItemFilter)
			{
				if (managers.StockController.GetStock(item2.Key) < item2.Value)
				{
					return false;
				}
			}
		}
		if (PurchaseFilter != null && PurchaseFilter.Count > 0)
		{
			Dictionary<string, int> purchaseStat = managers.StoreManager.PurchaseStat.GetValue().PurchaseStat;
			foreach (KeyValuePair<string, int> item3 in PurchaseFilter)
			{
				if (!purchaseStat.TryGetValue(item3.Key, out var value3) || value3 < item3.Value)
				{
					return false;
				}
			}
		}
		if (MissionType == MissionType.Video && !TryPickUpVideoMission(managers))
		{
			return false;
		}
		if (CheckStoryLineNodeVersionEnabled())
		{
			string storyNodeConfigVersion = managers.UserArchiveManager.GetStoryNodeConfigVersion();
			if (!StoryLineNodeVersionFilter.Contains(storyNodeConfigVersion))
			{
				return false;
			}
		}
		return true;
	}

	public bool Pickup(GameManagers managers)
	{
		if (!CanPickup(managers))
		{
			return false;
		}
		MissionConfig missionConfig = MissionState(managers);
		missionConfig.Status = MissionStatus.Undergoing;
		missionConfig.Progress.Clear();
		foreach (KeyValuePair<string, object> completeCaseDatum in CompleteCaseData)
		{
			missionConfig.Progress.Add(completeCaseDatum.Key, completeCaseDatum.Value);
		}
		if (Data.CompleteTrigger == "OnDailyLoginCalc" || Data.CompleteTrigger == "TypeForFunds1")
		{
			missionConfig.Progress["Offset"] = managers.UserArchiveManager.GetDailyLoginStats();
		}
		RegisterTrigger(managers);
		managers.Messenger.Broadcast("MISSION_PICKED", this);
		CheckProgress(managers);
		return true;
	}

	public void CheckProgress(GameManagers managers)
	{
		if (MissionState(managers).Status != MissionStatus.Undergoing)
		{
			return;
		}
		string text = CompleteTriggerId(managers);
		Trigger triggerById = managers.TriggerManager.GetTriggerById(text);
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(text);
		switch (triggerById.Type)
		{
		case "OnBuildingConstructingComplete":
		{
			filterPayload.TryGetValue("BuildingType", out var value2);
			Building buildingByType = managers.BuildingManager.GetBuildingByType(value2.ToString());
			if (buildingByType.Status == BuildingStatus.Running)
			{
				managers.TriggerManager.RunCallback(text);
				managers.TriggerManager.RemoveTrigger(text);
			}
			break;
		}
		case "OnSoldierPotentialUpgrade":
		{
			filterPayload.TryGetValue("Id", out var value6);
			filterPayload.TryGetValue("PotentialLevel", out var value7);
			filterPayload.TryGetValue("Value", out var _);
			int soldierPotentialLevel = managers.UserArchiveManager.GetSoldierPotentialLevel(value6.ToString());
			if (soldierPotentialLevel >= int.Parse(value7.ToString()))
			{
				managers.TriggerManager.RunCallback(text);
				managers.TriggerManager.RemoveTrigger(text);
			}
			break;
		}
		case "OnSoldierUnlock":
		{
			filterPayload.TryGetValue("Id", out var value11);
			if (managers.UserArchiveManager.GetUnlockedSoldiers().Contains(value11?.ToString()))
			{
				managers.TriggerManager.RunCallback(text);
				managers.TriggerManager.RemoveTrigger(text);
			}
			break;
		}
		case "OnLevelComplete":
		{
			if (!filterPayload.ContainsKey("Payload"))
			{
			}
			string text2 = Data.TriggerPayload;
			if (MissionType == MissionType.Newbie)
			{
				string[] array = JsonHelper.ToObject<Dictionary<string, string[]>>(Data.TriggerPayload)["LevelId"];
				text2 = array[0];
			}
			Level levelInstance = managers.ChapterManager.GetLevelInstance(text2);
			if (levelInstance != null)
			{
				List<string> chapterLevelProgress = managers.UserArchiveManager.GetChapterLevelProgress(levelInstance.ChapterId);
				if (chapterLevelProgress != null && chapterLevelProgress.Contains(text2))
				{
					managers.TriggerManager.RunCallback(text);
					managers.TriggerManager.RemoveTrigger(text);
				}
			}
			break;
		}
		case "OnAchievement":
		{
			if (!filterPayload.ContainsKey("Payload"))
			{
			}
			string triggerPayload = Data.TriggerPayload;
			if (AchievementManager.Achievements.TryGetValue(triggerPayload, out var value10))
			{
				AchievementStatus achievementStatus2 = value10.Status(managers);
				if (achievementStatus2 == AchievementStatus.PendingToClaim || achievementStatus2 == AchievementStatus.Claimed)
				{
					managers.TriggerManager.RunCallback(text);
					managers.TriggerManager.RemoveTrigger(text);
				}
			}
			break;
		}
		case "OnDailyLoginCalc":
			if (triggerById.CallbackFilter(managers, text, null))
			{
				managers.TriggerManager.RunCallback(text);
				managers.TriggerManager.RemoveTrigger(text);
			}
			break;
		case "TypeForFunds1":
			if (triggerById.CallbackFilter(managers, text, null))
			{
				managers.TriggerManager.RunCallback(text);
				managers.TriggerManager.RemoveTrigger(text);
			}
			break;
		case "TypeForFunds2":
		{
			if (!filterPayload.TryGetValue("Achievement", out var value4))
			{
				break;
			}
			string key = value4.ToString();
			if (AchievementManager.Achievements.TryGetValue(key, out var value5))
			{
				AchievementStatus achievementStatus = value5.Status(managers);
				if (achievementStatus == AchievementStatus.PendingToClaim || achievementStatus == AchievementStatus.Claimed)
				{
					managers.TriggerManager.RunCallback(text);
					managers.TriggerManager.RemoveTrigger(text);
				}
			}
			break;
		}
		case "OnPlayVideo":
		{
			MissionStatus status = MissionState(managers).Status;
			if (status == MissionStatus.Claimed || status == MissionStatus.Completed)
			{
				managers.TriggerManager.RemoveTrigger(text);
			}
			break;
		}
		case "OnRankUpdate":
		{
			if (filterPayload.TryGetValue("TopRank", out var value12) && RankDataHelper.PvpRankProgress.TopRank <= int.Parse(value12.ToString()))
			{
				managers.TriggerManager.RunCallback(text);
				managers.TriggerManager.RemoveTrigger(text);
			}
			break;
		}
		case "OnDrawCard":
		{
			if (filterPayload.TryGetValue("Total", out var _) && triggerById.CallbackFilter(managers, text, new Dictionary<string, object> { { "Cnt", 0 } }))
			{
				managers.TriggerManager.RunCallback(text);
				managers.TriggerManager.RemoveTrigger(text);
			}
			break;
		}
		case "OnDrawLegendItem":
		{
			if (filterPayload.TryGetValue("Total", out var _) && triggerById.CallbackFilter(managers, text, new Dictionary<string, object> { { "Cnt", 0 } }))
			{
				managers.TriggerManager.RunCallback(text);
				managers.TriggerManager.RemoveTrigger(text);
			}
			break;
		}
		case "OnLegendItemSet":
		{
			if (filterPayload.TryGetValue("Total", out var _) && triggerById.CallbackFilter(managers, text, new Dictionary<string, object> { 
			{
				"Cnt",
				LegendItemManager.GetLegendItemSetInstanceCount()
			} }))
			{
				managers.TriggerManager.RunCallback(text);
				managers.TriggerManager.RemoveTrigger(text);
			}
			break;
		}
		case "OnSoldierLevelUp":
			break;
		case "OnSoldierEvolute":
			break;
		}
	}

	public float CurrentValue(GameManagers managers)
	{
		Trigger triggerById = managers.TriggerManager.GetTriggerById(CompleteTriggerId(managers));
		switch (triggerById.Type)
		{
		case "OnAchievement":
		{
			if (!CompleteCaseData.TryGetValue("Payload", out var value3))
			{
				return 0f;
			}
			if (!AchievementManager.Achievements.TryGetValue(value3.ToString(), out var value4))
			{
				break;
			}
			return value4.CurrentValue(managers);
		}
		case "OnProd":
		case "OnCost":
		case "OnStock":
		case "OnCompound":
		case "OnCompoundCalc":
		case "ActivityReset":
		case "NewOrderStats":
		case "LegendItemEnhanced":
		case "LegendItemChangedProps":
		case "LegendItemReforged":
		case "OnLevelCompleteCalc":
		{
			if (!CompleteCaseData.TryGetValue("Total", out var _) || !MissionState(managers).Progress.TryGetValue("Total", out var _))
			{
				return 0f;
			}
			return Convert.ToSingle(CompleteCaseData["Total"]) - Convert.ToSingle(MissionState(managers).Progress["Total"]);
		}
		case "OnLevelComplete":
		{
			if (!CompleteCaseData.TryGetValue("Payload", out var value10))
			{
				return 0f;
			}
			string[] second = value10.ToString().Split(',');
			if (MissionType == MissionType.Newbie)
			{
				second = JsonHelper.ToObject<Dictionary<string, string[]>>(Data.TriggerPayload)["LevelId"];
			}
			int num = 0;
			foreach (List<string> value12 in managers.UserArchiveManager.GetLevelProgress().Values)
			{
				IEnumerable<string> source = value12.Intersect(second);
				num += source.Count();
			}
			return num;
		}
		case "OnDailyLoginCalc":
		{
			if (MissionState(managers).Progress.TryGetValue("Offset", out var value5))
			{
				return managers.UserArchiveManager.GetDailyLoginStats() - Convert.ToInt32(value5) + 1;
			}
			return 0f;
		}
		case "TypeForFunds1":
		{
			if (MissionState(managers).Progress.TryGetValue("Offset", out var value11))
			{
				return managers.UserArchiveManager.GetDailyLoginStats() - Convert.ToInt32(value11) + 1;
			}
			return 0f;
		}
		case "TypeForFunds2":
		{
			string key = CompleteCaseData["Achievement"].ToString();
			if (!AchievementManager.Achievements.TryGetValue(key, out var value9))
			{
				break;
			}
			return value9.CurrentValue(managers);
		}
		case "OnSoldierUnlock":
		{
			if (MissionType == MissionType.Newbie && JsonHelper.ToObject<Dictionary<string, string>>(Data.TriggerPayload).TryGetValue("Id", out var value6))
			{
				return managers.UserArchiveManager.GetUnlockedSoldiers().Contains(value6?.ToString()) ? 1f : 0f;
			}
			return 0f;
		}
		case "OnLevelBonusClaimed":
			if (MissionType == MissionType.Newbie)
			{
				string[] array = JsonHelper.ToObject<Dictionary<string, string[]>>(Data.TriggerPayload)["LevelId"];
				string[] array2 = array;
				foreach (string levelId in array2)
				{
					if (!managers.UserArchiveManager.IsLevelClaimed(levelId))
					{
						return 0f;
					}
				}
				return 1f;
			}
			return 0f;
		case "PvPRankScoreClaimed":
		case "WatchingReplay":
		case "WatchingPvPRankReplay":
		case "WatchingStoryMainReplay":
		case "PvPRankBattleStart":
		case "AttackInstanceClaimedFinalPrize":
		{
			if (!CompleteCaseData.TryGetValue("Payload", out var _) || !MissionState(managers).Progress.TryGetValue("Payload", out var _))
			{
				return 0f;
			}
			return Convert.ToSingle(CompleteCaseData["Payload"]) - Convert.ToSingle(MissionState(managers).Progress["Payload"]);
		}
		}
		MissionStatus status = MissionState(managers).Status;
		if (status == MissionStatus.Claimed || status == MissionStatus.Completed)
		{
			return TargetValue(managers);
		}
		return 0f;
	}

	public float TargetValue(GameManagers managers)
	{
		string triggerId = CompleteTriggerId(managers);
		Trigger triggerById = managers.TriggerManager.GetTriggerById(triggerId);
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		switch (triggerById.Type)
		{
		case "OnAchievement":
		{
			string key = filterPayload["Payload"].ToString();
			if (!AchievementManager.Achievements.TryGetValue(key, out var value2))
			{
				break;
			}
			return value2.TargetValue;
		}
		case "OnProd":
		case "OnCost":
		case "OnStock":
		case "OnCompound":
		case "OnCompoundCalc":
		case "ActivityReset":
		case "NewOrderStats":
		case "LegendItemEnhanced":
		case "LegendItemChangedProps":
		case "LegendItemReforged":
		case "OnLevelCompleteCalc":
			return Convert.ToSingle(CompleteCaseData["Total"]);
		case "OnSoldierUnlock":
			return 1f;
		case "OnLevelBonusClaimed":
			return 1f;
		case "OnLevelComplete":
		{
			if (MissionType == MissionType.Newbie)
			{
				return 1f;
			}
			if (CompleteCaseData.TryGetValue("Payload", out var value4))
			{
				return value4.ToString().Split(',').Length;
			}
			return 1f;
		}
		case "OnDailyLoginCalc":
		{
			if (CompleteCaseData.TryGetValue("Payload", out var value6))
			{
				return Convert.ToInt32(value6);
			}
			return 1f;
		}
		case "TypeForFunds1":
		{
			if (CompleteCaseData.TryGetValue("LoginCnt", out var value5))
			{
				return Convert.ToInt32(value5);
			}
			return 1f;
		}
		case "TypeForFunds2":
		{
			string key2 = CompleteCaseData["Achievement"].ToString();
			if (!AchievementManager.Achievements.TryGetValue(key2, out var value3))
			{
				break;
			}
			return value3.TargetValue;
		}
		default:
		{
			if (CompleteCaseData.TryGetValue("Payload", out var value))
			{
				return Convert.ToSingle(value);
			}
			return 1f;
		}
		}
		return 1f;
	}

	public bool CanClaimBonus(GameManagers managers)
	{
		CheckProgress(managers);
		if (MissionState(managers).Status != MissionStatus.Completed)
		{
			return false;
		}
		return true;
	}

	public bool Claim(GameManagers managers, out Dictionary<string, float> finalClaimed)
	{
		finalClaimed = new Dictionary<string, float>();
		if (!CanClaimBonus(managers))
		{
			return false;
		}
		MissionState(managers).Status = MissionStatus.Claimed;
		string triggerId = CompleteTriggerId(managers);
		Trigger triggerById = managers.TriggerManager.GetTriggerById(triggerId);
		Dictionary<string, object> filterPayload = managers.TriggerManager.GetFilterPayload(triggerId);
		if (triggerById.Type == "OnAchievement" && filterPayload.TryGetValue("Payload", out var value))
		{
			string text = value.ToString();
			if (!string.IsNullOrEmpty(text) && AchievementManager.Achievements.TryGetValue(text, out var value2))
			{
				value2.ClaimBonus(managers, finalClaimed, broadcastInform: false);
			}
		}
		foreach (Bonus bonus in BonusList)
		{
			bonus.Claim(managers, finalClaimed, $"{56}:{Id}");
		}
		managers.Messenger.Broadcast("MISSION_CLAIMED", this);
		return true;
	}

	public bool IsTargetBuilding(string buildingType)
	{
		if (Data.Tags == null || !Data.Tags.Any())
		{
			return false;
		}
		return Data.Tags.Contains(buildingType);
	}

	private bool TryPickUpVideoMission(GameManagers managers)
	{
		if (Data.Tags == null || !Data.Tags.Any())
		{
			return true;
		}
		string type = Data.Tags.First();
		return managers.BuildingManager.GetBuildingByType(type).Level > 0;
	}
}
