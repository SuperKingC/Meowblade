using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class MissionManager : Manager
{
	private const string PickedMissionRecordsKey = "PickedMissionRecords";

	private const string MissionStatsKey = "MissionStats";

	private static Dictionary<string, Mission> _missions;

	private static Dictionary<string, GDEMissionFrontEndOnlyData> _Configs_GDEMissionFrontEndOnlyData;

	public string CurPickedNewbieMissionid;

	private static Dictionary<string, Mission> _newbieMissions;

	private static Dictionary<string, Mission> _newbieMissionsForeign;

	private static Dictionary<string, Mission> _newbie3Missions;

	private static Dictionary<string, Mission> _newbie4Missions;

	public string CurPickedNewbieSummaryMissionid = null;

	private static Dictionary<string, Mission> _newbieSummaryMissions;

	private static Dictionary<string, Mission> _newbieSummaryMissionsForeign;

	private static Dictionary<string, Mission> _newbie3SummaryMissions;

	private static Dictionary<string, Mission> _newbie4SummaryMissions;

	private static Dictionary<string, Mission> _weeklyMissions;

	private static Dictionary<string, Mission> _dailyMissions;

	private Dictionary<string, Mission> _pickedMissions;

	private Config<Dictionary<string, MissionConfig>> _pickedMissionRecords;

	private Config<MissionStats> _missionStat;

	public readonly Dictionary<string, string> MissionCompleteTriggerIds = new Dictionary<string, string>();

	private static Dictionary<string, Mission> _videoMissions;

	public static Dictionary<string, Mission> Missions
	{
		get
		{
			if (_missions == null)
			{
				EnsureMissions();
			}
			return _missions;
		}
	}

	public static Dictionary<string, GDEMissionFrontEndOnlyData> Configs_GDEMissionFrontEndOnlyData
	{
		get
		{
			if (_Configs_GDEMissionFrontEndOnlyData == null)
			{
				_Configs_GDEMissionFrontEndOnlyData = new Dictionary<string, GDEMissionFrontEndOnlyData>();
				foreach (GDEMissionFrontEndOnlyData allItem in GDMgr.GetAllItems<GDEMissionFrontEndOnlyData>())
				{
					_Configs_GDEMissionFrontEndOnlyData.Add(allItem.Key.Replace("_FrontEndOnly", ""), allItem);
				}
			}
			return _Configs_GDEMissionFrontEndOnlyData;
		}
	}

	public static Dictionary<string, Mission> NewbieMissions
	{
		get
		{
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode2())
			{
				if (_newbieMissionsForeign == null)
				{
					EnsureMissions();
				}
				return _newbieMissionsForeign;
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode3())
			{
				if (_newbie3Missions == null)
				{
					EnsureMissions();
				}
				return _newbie3Missions;
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode4() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode7() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode4() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6())
			{
				if (_newbie4Missions == null)
				{
					EnsureMissions();
				}
				return _newbie4Missions;
			}
			if (_newbieMissions == null)
			{
				EnsureMissions();
			}
			return _newbieMissions;
		}
	}

	public static Dictionary<string, Mission> NewbieSummaryMissions
	{
		get
		{
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode2())
			{
				if (_newbieSummaryMissionsForeign == null)
				{
					EnsureMissions();
				}
				return _newbieSummaryMissionsForeign;
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode3())
			{
				if (_newbie3SummaryMissions == null)
				{
					EnsureMissions();
				}
				return _newbie3SummaryMissions;
			}
			if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode4() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode7() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode4() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6())
			{
				if (_newbie4SummaryMissions == null)
				{
					EnsureMissions();
				}
				return _newbie4SummaryMissions;
			}
			if (_newbieSummaryMissions == null)
			{
				EnsureMissions();
			}
			return _newbieSummaryMissions;
		}
	}

	public static Dictionary<string, Mission> WeeklyMissions
	{
		get
		{
			if (_weeklyMissions == null)
			{
				EnsureMissions();
			}
			return _weeklyMissions;
		}
	}

	public static Dictionary<string, Mission> DailyMissions
	{
		get
		{
			if (_dailyMissions == null)
			{
				EnsureMissions();
			}
			return _dailyMissions;
		}
	}

	public Dictionary<string, Mission> PickedMissions
	{
		get
		{
			if (_pickedMissions == null)
			{
				_pickedMissions = new Dictionary<string, Mission>();
				Dictionary<string, MissionConfig> value = PickedMissionRecords.GetValue();
				string[] array = value.Keys.ToArray();
				for (int i = 0; i < value.Count; i++)
				{
					string key = array[i];
					if (Missions.TryGetValue(key, out var value2))
					{
						MissionStatus status = value2.MissionState(Managers).Status;
						if (status == MissionStatus.Undergoing)
						{
							value2.RegisterTrigger(Managers);
							value2.CheckProgress(Managers);
						}
						_pickedMissions.Add(key, value2);
					}
				}
				RefreshCurNewbieMission();
			}
			return _pickedMissions;
		}
	}

	public Config<Dictionary<string, MissionConfig>> PickedMissionRecords
	{
		get
		{
			if (_pickedMissionRecords == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (userArchiveManager.Contains("PickedMissionRecords"))
				{
					_pickedMissionRecords = userArchiveManager.GetConfig<Dictionary<string, MissionConfig>>("PickedMissionRecords");
				}
				else
				{
					userArchiveManager.SetConfigValue("PickedMissionRecords", new Dictionary<string, MissionConfig>());
					_pickedMissionRecords = userArchiveManager.GetConfig<Dictionary<string, MissionConfig>>("PickedMissionRecords");
				}
			}
			return _pickedMissionRecords;
		}
	}

	public Config<MissionStats> MissionStat
	{
		get
		{
			if (_missionStat == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (userArchiveManager.Contains("MissionStats"))
				{
					_missionStat = userArchiveManager.GetConfig<MissionStats>("MissionStats");
				}
				else
				{
					userArchiveManager.SetConfigValue("MissionStats", new MissionStats());
					_missionStat = userArchiveManager.GetConfig<MissionStats>("MissionStats");
				}
			}
			return _missionStat;
		}
	}

	public static Dictionary<string, Mission> VideoMissions
	{
		get
		{
			if (_videoMissions == null)
			{
				EnsureMissions();
			}
			return _videoMissions;
		}
	}

	public static string GetNextMissionById(string missionId)
	{
		if (Missions.TryGetValue(missionId, out var value))
		{
			return value.NextMission(GameManagers.Instance);
		}
		return string.Empty;
	}

	public void RefreshCurNewbieMission()
	{
		Dictionary<string, MissionConfig> value = PickedMissionRecords.GetValue();
		string[] array = value.Keys.ToArray();
		bool flag = GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode2();
		bool flag2 = GameManagers.Instance.UserArchiveManager.IsNewGuideMode1() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode2();
		bool flag3 = GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode3();
		bool flag4 = GameManagers.Instance.UserArchiveManager.IsNewGuideMode4() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode7() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode4() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6();
		CurPickedNewbieMissionid = null;
		CurPickedNewbieSummaryMissionid = null;
		for (int i = 0; i < value.Count; i++)
		{
			string key = array[i];
			if (!Missions.TryGetValue(key, out var value2))
			{
				continue;
			}
			int type = value2.Data.Type;
			if ((!flag || !FilteringOutSeaGuideMissions(type)) && (!flag2 || !FilteringNewGuideMissions(type)) && (!flag3 || !FilteringNewbie3Missions(type)) && (!flag4 || !FilteringNewbie4Missions(type)))
			{
				MissionStatus status = value2.MissionState(Managers).Status;
				if (string.IsNullOrEmpty(CurPickedNewbieMissionid) && value2.MissionType == MissionType.Newbie && status == MissionStatus.Undergoing)
				{
					CurPickedNewbieMissionid = value2.Id;
				}
				if (string.IsNullOrEmpty(CurPickedNewbieSummaryMissionid) && value2.MissionType == MissionType.NewbieSummary && status == MissionStatus.Undergoing)
				{
					CurPickedNewbieSummaryMissionid = value2.Id;
				}
			}
		}
		static bool FilteringNewGuideMissions(int num)
		{
			return num != 2 && num != 3;
		}
		static bool FilteringNewbie3Missions(int num)
		{
			return num != 9 && num != 10;
		}
		static bool FilteringNewbie4Missions(int num)
		{
			return num != 11 && num != 12;
		}
		static bool FilteringOutSeaGuideMissions(int num)
		{
			return num != 6 && num != 7;
		}
	}

	public MissionManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		TaskCompletionSource<bool> tsc = new TaskCompletionSource<bool>();
		Task<SoldierItemSlotAllResponse> task = GameController.Contexts.Service<INetworkService>().SoldierItemSlotAll();
		task.GetAwaiter().OnCompleted(delegate
		{
			SoldierItemSlotAllResponse result = task.Result;
			LegendItemsHelper.SetSoldierItemSlotData(result.SoldiersItemSlots);
			_ = PickedMissions;
			TryPickUpVideoMissions();
			tsc.SetResult(result: true);
		});
		return tsc.Task;
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<Mission>("MISSION_PICKED", OnMissionPicked);
		Managers.Messenger.AddListener<Mission>("MISSION_COMPLETE", OnMissionCompleted);
		Managers.Messenger.AddListener<string, Level, Team, bool>("LEVEL_COMPLETED", OnLevelComplete);
		Managers.Messenger.AddListener<int>("USER_LEVEL_UP", OnUserLevelUp);
		Managers.Messenger.AddListener<int>("DUNGEON_LEVEL_UP", OnDungeonLevelUp);
		Managers.Messenger.AddListener<string, int>("BUILDING_UPGRADED", OnBuildingRepaired);
		Managers.Messenger.AddListener<Mission>("MISSION_CLAIMED", OnMissionClaimed);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<Mission>("MISSION_PICKED", OnMissionPicked);
		Managers.Messenger.RemoveListener<Mission>("MISSION_COMPLETE", OnMissionCompleted);
		Managers.Messenger.RemoveListener<string, Level, Team, bool>("LEVEL_COMPLETED", OnLevelComplete);
		Managers.Messenger.RemoveListener<int>("USER_LEVEL_UP", OnUserLevelUp);
		Managers.Messenger.RemoveListener<int>("DUNGEON_LEVEL_UP", OnDungeonLevelUp);
		Managers.Messenger.AddListener<string, int>("BUILDING_UPGRADED", OnBuildingRepaired);
		Managers.Messenger.RemoveListener<Mission>("MISSION_CLAIMED", OnMissionClaimed);
	}

	private void OnMissionCompleted(Mission mission)
	{
		if (PickedMissionRecords.GetValue().TryGetValue(mission.Id, out var _))
		{
			PickedMissionRecords.Save();
		}
		MissionStats value2 = MissionStat.GetValue();
		Dictionary<string, int> dictionary = value2.MissionCompleteRecords;
		if (dictionary == null)
		{
			dictionary = (value2.MissionCompleteRecords = new Dictionary<string, int>());
		}
		if (dictionary.ContainsKey(mission.Id))
		{
			dictionary[mission.Id]++;
		}
		else
		{
			dictionary.Add(mission.Id, 1);
		}
		MissionStat.Save();
		if (Configs_GDEMissionFrontEndOnlyData.TryGetValue(mission.Id, out var value3) && !string.IsNullOrEmpty(value3.OnCompleted))
		{
			Managers.Messenger.Broadcast("NEW_GUIDE_MISSION_PLAY_STORY", mission.Id, 2);
		}
	}

	public void OnMissionClaimed(Mission mission)
	{
		Trigger triggerById = Managers.TriggerManager.GetTriggerById(mission.CompleteTriggerId(Managers));
		Dictionary<string, object> filterPayload = Managers.TriggerManager.GetFilterPayload(mission.CompleteTriggerId(Managers));
		if (triggerById.Type == "OnAchievement")
		{
			string key = filterPayload["Payload"].ToString();
			if (AchievementManager.Achievements.TryGetValue(key, out var value))
			{
				value.ClaimBonus(Managers, null, broadcastInform: false);
			}
		}
		if (mission.ParentActivityPayload != null)
		{
			mission.ParentActivityPayload.OnContentChanged(mission);
		}
		mission.MissionState(Managers).Status = MissionStatus.Claimed;
		PickedMissionRecords.Save();
		MissionStats value2 = MissionStat.GetValue();
		Dictionary<string, int> dictionary = value2.MissionClaimRecords;
		if (dictionary == null)
		{
			dictionary = (value2.MissionClaimRecords = new Dictionary<string, int>());
		}
		if (dictionary.ContainsKey(mission.Id))
		{
			dictionary[mission.Id]++;
		}
		else
		{
			dictionary.Add(mission.Id, 1);
		}
		MissionStat.Save();
		if (Configs_GDEMissionFrontEndOnlyData.TryGetValue(mission.Id, out var value3) && !string.IsNullOrEmpty(value3.OnClaimed))
		{
			Managers.Messenger.Broadcast("NEW_GUIDE_MISSION_PLAY_STORY", mission.Id, 3);
		}
		string text = mission.NextMission(Managers);
		if (!string.IsNullOrEmpty(text) && Missions.TryGetValue(text, out var value4))
		{
			if (mission.MissionType == MissionType.Newbie)
			{
				CurPickedNewbieMissionid = value4.Id;
			}
			else if (mission.MissionType == MissionType.NewbieSummary)
			{
				CurPickedNewbieSummaryMissionid = value4.Id;
			}
		}
	}

	public void OnMissionPicked(Mission mission)
	{
		PickedMissions[mission.Id] = mission;
		Dictionary<string, MissionConfig> value = PickedMissionRecords.GetValue();
		if (value.ContainsKey(mission.Id))
		{
			value[mission.Id] = mission.MissionState(Managers);
		}
		else
		{
			value.Add(mission.Id, mission.MissionState(Managers));
		}
		PickedMissionRecords.Save();
		if (mission.MissionType == MissionType.Newbie && string.IsNullOrEmpty(CurPickedNewbieMissionid))
		{
			CurPickedNewbieMissionid = mission.Id;
		}
		if (mission.MissionType == MissionType.NewbieSummary && string.IsNullOrEmpty(CurPickedNewbieSummaryMissionid))
		{
			CurPickedNewbieSummaryMissionid = mission.Id;
		}
		if (Configs_GDEMissionFrontEndOnlyData.TryGetValue(mission.Id, out var value2) && !string.IsNullOrEmpty(value2.OnUndergoing))
		{
			Managers.Messenger.Broadcast("NEW_GUIDE_MISSION_PLAY_STORY", mission.Id, 1);
		}
	}

	private static void EnsureMissions()
	{
		if (_missions == null)
		{
			_missions = new Dictionary<string, Mission>();
		}
		else
		{
			_missions.Clear();
		}
		if (_weeklyMissions == null)
		{
			_weeklyMissions = new Dictionary<string, Mission>();
		}
		else
		{
			_weeklyMissions.Clear();
		}
		if (_dailyMissions == null)
		{
			_dailyMissions = new Dictionary<string, Mission>();
		}
		else
		{
			_dailyMissions.Clear();
		}
		if (_newbieMissions == null)
		{
			_newbieMissions = new Dictionary<string, Mission>();
		}
		else
		{
			_newbieMissions.Clear();
		}
		if (_newbieSummaryMissions == null)
		{
			_newbieSummaryMissions = new Dictionary<string, Mission>();
		}
		else
		{
			_newbieSummaryMissions.Clear();
		}
		if (_videoMissions == null)
		{
			_videoMissions = new Dictionary<string, Mission>();
		}
		else
		{
			_videoMissions.Clear();
		}
		if (_newbieMissionsForeign == null)
		{
			_newbieMissionsForeign = new Dictionary<string, Mission>();
		}
		else
		{
			_newbieMissionsForeign.Clear();
		}
		if (_newbieSummaryMissionsForeign == null)
		{
			_newbieSummaryMissionsForeign = new Dictionary<string, Mission>();
		}
		else
		{
			_newbieSummaryMissionsForeign.Clear();
		}
		if (_newbie3Missions == null)
		{
			_newbie3Missions = new Dictionary<string, Mission>();
		}
		else
		{
			_newbie3Missions.Clear();
		}
		if (_newbie3SummaryMissions == null)
		{
			_newbie3SummaryMissions = new Dictionary<string, Mission>();
		}
		else
		{
			_newbie3SummaryMissions.Clear();
		}
		if (_newbie4Missions == null)
		{
			_newbie4Missions = new Dictionary<string, Mission>();
		}
		else
		{
			_newbie4Missions.Clear();
		}
		if (_newbie4SummaryMissions == null)
		{
			_newbie4SummaryMissions = new Dictionary<string, Mission>();
		}
		else
		{
			_newbie4SummaryMissions.Clear();
		}
		foreach (GDEMissionData allItem in GDMgr.GetAllItems<GDEMissionData>())
		{
			if (!string.IsNullOrEmpty(allItem.Key) && allItem.Enabled)
			{
				Mission mission = new Mission(allItem);
				_missions.Add(mission.Id, mission);
				switch ((MissionType)mission.Data.Type)
				{
				case MissionType.Weekly:
					_weeklyMissions.Add(mission.Id, mission);
					break;
				case MissionType.DailyMission:
					_dailyMissions.Add(mission.Id, mission);
					break;
				case MissionType.Newbie:
					_newbieMissions.Add(mission.Id, mission);
					break;
				case MissionType.NewbieSummary:
					_newbieSummaryMissions.Add(mission.Id, mission);
					break;
				case MissionType.Video:
					_videoMissions.Add(mission.Id, mission);
					break;
				case MissionType.NewbieForeign:
					_newbieMissionsForeign.Add(mission.Id, mission);
					break;
				case MissionType.NewbieSummaryForeign:
					_newbieSummaryMissionsForeign.Add(mission.Id, mission);
					break;
				case MissionType.Newbie3:
					_newbie3Missions.Add(mission.Id, mission);
					break;
				case MissionType.NewbieSummary3:
					_newbie3SummaryMissions.Add(mission.Id, mission);
					break;
				case MissionType.Newbie4:
					_newbie4Missions.Add(mission.Id, mission);
					break;
				case MissionType.NewbieSummary4:
					_newbie4SummaryMissions.Add(mission.Id, mission);
					break;
				}
			}
		}
	}

	public void OnLevelComplete(string battleId, Level level, Team winner, bool newCompleteFlagr)
	{
		if ((level.LevelId == "P003" || level.LevelId == "P0111") && winner == Team.Red)
		{
			string[] array = WeeklyMissions.Keys.ToArray();
			foreach (string key in array)
			{
				WeeklyMissions[key].Pickup(Managers);
			}
		}
		CheckAndPickPendingMissionInRecord();
	}

	public void OnUserLevelUp(int newLevel)
	{
		CheckAndPickPendingMissionInRecord();
	}

	public void OnDungeonLevelUp(int newLevel)
	{
		CheckAndPickPendingMissionInRecord();
	}

	public void OnStockChange(string itemId, int incrBy, (StockInContext, string) contextTuple)
	{
	}

	public void CheckAndPickPendingMissionInRecord()
	{
		List<MissionConfig> list = (from _r in PickedMissionRecords.GetValue()
			where _r.Value.Status == MissionStatus.Pending
			select _r.Value).ToList();
		for (int num = 0; num < list.Count; num++)
		{
			MissionConfig missionConfig = list[num];
			if (Missions.TryGetValue(missionConfig.MissionId, out var value))
			{
				value.Pickup(Managers);
			}
		}
	}

	public void TryPickUpVideoMissions()
	{
		foreach (KeyValuePair<string, Mission> videoMission in VideoMissions)
		{
			if (!_pickedMissions.ContainsKey(videoMission.Key) || videoMission.Value.MissionState(GameManagers.Instance).Status == MissionStatus.Pending)
			{
				videoMission.Value.Pickup(Managers);
			}
		}
		PickedMissionRecords.Save();
	}

	private void OnBuildingRepaired(string buildingType, int level)
	{
		if (level > 1)
		{
			return;
		}
		Mission value;
		List<Mission> list = (from valuePair in PickedMissionRecords.GetValue()
			where valuePair.Value.Status == MissionStatus.Pending && Missions.TryGetValue(valuePair.Value.MissionId, out value) && value.MissionType == MissionType.Video && value.IsTargetBuilding(buildingType)
			select Missions[valuePair.Value.MissionId]).ToList();
		foreach (Mission item in list)
		{
			item.Pickup(Managers);
		}
	}
}
