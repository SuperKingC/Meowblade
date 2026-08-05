using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Utils;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvG3FlagShipMissionsUiModel
{
	private const string WaitEternalNightTag = "WaitEternalNight";

	private const string EternalNight = "EternalNight";

	private const string CollectShadowEngery = "CollectShadowEngery";

	private readonly string _campTag;

	public int CheckCampProgress;

	private readonly C2S_GetFinalProgressInfo.Response _finalProgressInfo;

	public CampEnergyDetails CampEnergyDetails;

	private readonly List<GvG3FlagShipMissionModel> _flagShipMissions = new List<GvG3FlagShipMissionModel>();

	private readonly Dictionary<string, GvG3FlagShipMissionModel> _flagShipMissions_Dict = new Dictionary<string, GvG3FlagShipMissionModel>();

	public int CurProgress => Singleton<WorldStateManager>.Instance.Data.ProgressData.CampProgress;

	public int CampStep => (CheckCampProgress == CurProgress) ? Singleton<WorldStateManager>.Instance.Data.ProgressData.CampStep : 4;

	public bool IsEternalNight => CurProgress == 6;

	public C2S_GetFinalProgressInfo.Response FinalProgressInfo => _finalProgressInfo;

	public BindableProperty<string> FinalBossIcon { get; }

	public GvG3FlagShipMissionsUiModel()
	{
		FinalBossIcon = new BindableProperty<string>();
		_finalProgressInfo = new C2S_GetFinalProgressInfo.Response();
		CampEnergyDetails = new CampEnergyDetails();
		CheckCampProgress = CurProgress;
		_campTag = $"Camp{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId}";
	}

	public bool ProgressIsEternalNight(int progress)
	{
		return progress == 6;
	}

	public void CheckCurrentProgress()
	{
		CheckCampProgress = CurProgress;
	}

	public void ChangeCampProgress(int progress)
	{
		if (progress != 0)
		{
			CheckCampProgress += progress;
			if (IsEternalNight && CheckCampProgress == 5)
			{
				CheckCampProgress += progress;
			}
			CheckCampProgress = Mathf.Max(1, CheckCampProgress);
			CheckCampProgress = Mathf.Min(CurProgress, CheckCampProgress);
		}
	}

	public void UpdateFinalProgressInfo(C2S_GetFinalProgressInfo.Response info)
	{
		_finalProgressInfo.BossInfo = info.BossInfo;
		_finalProgressInfo.PlayerBuff = info.PlayerBuff;
		_finalProgressInfo.CampShadowEnergy = info.CampShadowEnergy;
		_finalProgressInfo.CurMissionConfgiId = info.CurMissionConfgiId;
		_finalProgressInfo.SelfShadowStoneCount = info.SelfShadowStoneCount;
		FinalBossIcon.Value = info.BossInfo.BossIcon;
	}

	public void UpdateSelfShadowStoneCount(int stoneCount)
	{
		_finalProgressInfo.SelfShadowStoneCount = stoneCount;
	}

	public void SyncCampEnergyDetails(C2S_GetCampEnergy.Response response)
	{
		CampEnergyDetails.CampEnergy = response.CampEnergy;
		CampEnergyDetails.BrawlEventCampEnergyLastDay = response.BrawlEventCampEnergyLastDay;
		CampEnergyDetails.BrawlEventRankLastDay = response.BrawlEventRankLastDay;
		CampEnergyDetails.IslandCount = response.IslandCount;
		CampEnergyDetails.CampEnergyDetailInfos.Clear();
		if (response.CampEnergyDetailInfos != null)
		{
			CampEnergyDetails.CampEnergyDetailInfos.AddRange(response.CampEnergyDetailInfos);
		}
	}

	public GvG3FlagShipMissionModel GetEternalNightMission(string configId)
	{
		if (string.IsNullOrEmpty(configId))
		{
			return null;
		}
		return _flagShipMissions.Find((GvG3FlagShipMissionModel m) => m.MissionConfigId == configId) ?? NewMissionModel(configId);
	}

	public bool LastCommonCampMainMissionCompleted()
	{
		GvG3FlagShipMissionModel gvG3FlagShipMissionModel = _flagShipMissions.Find((GvG3FlagShipMissionModel m) => m.Data.Progress == 4 && m.Data.Step == 4);
		if (gvG3FlagShipMissionModel == null)
		{
			return false;
		}
		return gvG3FlagShipMissionModel.MState != eMissionEntityState.Undergoing;
	}

	public void SyncMissionsStatus(List<MissionStateRecordWithProgress> missionState)
	{
		if (missionState == null)
		{
			return;
		}
		foreach (MissionStateRecordWithProgress item in missionState)
		{
			if (!_flagShipMissions_Dict.TryGetValue(item.MissionConfigId, out var value))
			{
				value = NewMissionModel(item.MissionConfigId);
			}
			value.SyncMissionState(item);
		}
	}

	public GvG3FlagShipMissionModel NewMissionModel(string missionConfigId)
	{
		GvG3FlagShipMissionModel gvG3FlagShipMissionModel = new GvG3FlagShipMissionModel(missionConfigId);
		_flagShipMissions.Add(gvG3FlagShipMissionModel);
		_flagShipMissions_Dict.Add(gvG3FlagShipMissionModel.MissionConfigId, gvG3FlagShipMissionModel);
		return gvG3FlagShipMissionModel;
	}

	public CampMainMissionUiModel GetMainMission(bool isCurrent = false)
	{
		int progress = (isCurrent ? CurProgress : CheckCampProgress);
		GvG3FlagShipMissionModel gvG3FlagShipMissionModel = (ProgressIsEternalNight(progress) ? _flagShipMissions.Find(IsCurrentEternalNightMission) : _flagShipMissions.Find(IsCurrentMainMission));
		if (gvG3FlagShipMissionModel == null)
		{
			SentrySdk.AddBreadcrumb($"[GetMainMission] mission is null!! progress={progress} ProgressIsEternalNight={ProgressIsEternalNight(progress)}");
		}
		return new CampMainMissionUiModel
		{
			Progress = progress,
			Step = CampStep,
			MainMission = gvG3FlagShipMissionModel
		};
		bool IsCurrentEternalNightMission(GvG3FlagShipMissionModel model)
		{
			if (model.Data.Type != eGvGMode3CampMissionType.CampMain)
			{
				return false;
			}
			if (!model.Data.Tags.Contains("EternalNight"))
			{
				return false;
			}
			if (!model.Data.Tags.Contains(_campTag))
			{
				return false;
			}
			if (model.Data.Progress != progress)
			{
				return false;
			}
			return model.Data.Step == CampStep;
		}
		bool IsCurrentMainMission(GvG3FlagShipMissionModel model)
		{
			if (model.Data.Type != eGvGMode3CampMissionType.CampMain)
			{
				return false;
			}
			if (model.Data.Tags.Contains("WaitEternalNight") || model.Data.Tags.Contains("EternalNight"))
			{
				return false;
			}
			if (!model.Data.Tags.Contains(_campTag))
			{
				return false;
			}
			if (model.Data.Progress != progress)
			{
				return false;
			}
			return model.Data.Step == CampStep;
		}
	}

	public List<CampSideMissionsUiModel> GetSideMissions()
	{
		List<GvG3FlagShipMissionModel> list = (ProgressIsEternalNight(CheckCampProgress) ? _flagShipMissions.Where(IsCurrentEternalNightSideMission).ToList() : _flagShipMissions.Where(IsCurrentProgressSideMission).ToList());
		Dictionary<string, List<GvG3FlagShipMissionModel>> dictionary = new Dictionary<string, List<GvG3FlagShipMissionModel>>();
		foreach (GvG3FlagShipMissionModel item2 in list)
		{
			string key = item2.Data.GroupId.ToString();
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, new List<GvG3FlagShipMissionModel> { item2 });
			}
			else
			{
				dictionary[key].Add(item2);
			}
		}
		List<CampSideMissionsUiModel> list2 = new List<CampSideMissionsUiModel>();
		foreach (KeyValuePair<string, List<GvG3FlagShipMissionModel>> item3 in dictionary)
		{
			CampSideMissionsUiModel item = new CampSideMissionsUiModel(int.Parse(item3.Key), item3.Value);
			list2.Add(item);
		}
		return list2;
		bool IsCurrentEternalNightSideMission(GvG3FlagShipMissionModel model)
		{
			if (model.Data.Type != eGvGMode3CampMissionType.CampSide)
			{
				return false;
			}
			if (model.Data.Tags.Contains("CollectShadowEngery"))
			{
				return false;
			}
			return model.Data.Progress == CheckCampProgress;
		}
		bool IsCurrentProgressSideMission(GvG3FlagShipMissionModel model)
		{
			if (model.Data.Type != eGvGMode3CampMissionType.CampSide)
			{
				return false;
			}
			return model.Data.Progress == CheckCampProgress;
		}
	}
}
