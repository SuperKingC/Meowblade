using System;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.S2C;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

public class ShipStateModel
{
	public class DockInRecord
	{
		public int DockInIslandId { get; private set; } = -1;

		public int SlotIndex { get; private set; } = -1;

		public void UpdateRecord(int stayIslandId)
		{
			if (stayIslandId != DockInIslandId)
			{
				DockInIslandId = stayIslandId;
				SlotIndex = -1;
			}
		}

		public void SetSlotIndex(int slotIndex)
		{
			SlotIndex = slotIndex;
		}
	}

	public const int ReturningCD = 60;

	public bool IsMyShipSelected;

	public bool IsInit;

	public int EntityId;

	public int UserId;

	public int CampId;

	public string ShipId;

	public FlightSchedule FlightSchedule;

	public ShipPlanStatusInfo PlanStatusInfo;

	public eShipState State;

	public eRace ShipRace;

	public int StayIslandId = -1;

	public int FoodOnboardCount;

	public float ShipSightRange = 0f;

	public int SoulGuideCDTimestamp = -1;

	public int ReturningCDTimestamp = -1;

	public float ShipIconScale = 1f;

	private DockInRecord _dockInRecord;

	public const int CurrentGroupNum = 5;

	public const int LegendItemsLimit = 2;

	public string FormationId;

	public string FormationIdTemp;

	public List<GvGMode3UnitInfo> CurrentUnitInfos;

	public List<GvGMode3UnitInfo> CurrentUnitInfosTemp;

	public int FormationPower;

	public List<string> SelectedMinerals;

	public RealTimeCollectingEfficiencyModel CollectingEfficiencyModel;

	private List<CollectingStockModel> _availableMinerals;

	private float _avgCollectingEfficiency;

	private float _shipSummarySpeed;

	private const string TipText0 = "GvGShipDetail-ArmyPage-ChangeArmyBtn-0";

	public Action<ShipStateModel> OnChange;

	public Action<ShipStateModel> OnFogAreaChange;

	public Action<ShipStateModel> OnChangeFlightSchedule;

	public Action<ShipStateModel> OnGroupInfoChange;

	public Action OnCollectingConfigChange;

	public Action OnShipSummaryChange;

	public Action<ShipStateModel> OnChangeSoulGuideCDTimestamp;

	public Action<ShipStateModel> OnChangeMyShipSelected;

	private RealTimeShipSummarySpeedModel _speedModel;

	public bool IsSoulGuideCoolingDown => SoulGuideCDTimestamp > 0;

	public bool CanDoSoulGuide => !IsSoulGuideCoolingDown && State == eShipState.Stay && StayIslandId != Singleton<WorldStateManager>.Instance.GetOurFlagShip().StayIslandId && State != eShipState.NotLaunched && State != eShipState.Rebuilding;

	public eUIShipState UiState => GetUiShipState();

	public DockInRecord ShipDockInRecord => _dockInRecord ?? (_dockInRecord = new DockInRecord());

	private int BackupGroupSlotLimit => Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.BackupGroupSlotLimit;

	public List<GvGMode3UnitInfo> GroupInfo => CurrentUnitInfos.Take(5).ToList();

	public List<GvGMode3UnitInfo> BackupGroupInfo => CurrentUnitInfos.SkipItems(5);

	public int GroupSoldiersCntSum => CurrentUnitInfosTemp.Take(5).Sum((GvGMode3UnitInfo t) => t.CurCnt);

	public int GroupSoldiersTotalSum => CurrentUnitInfosTemp.Take(5).Sum((GvGMode3UnitInfo t) => t.Total);

	public List<string> GroupInfoTemp => GetGroupInfoTemp();

	public List<string> BackupGroupInfoTemp => GetBackupGroupInfoTemp();

	public List<CollectingStockModel> AvailableMinerals => GetAvailableMinerals();

	public int WorkersOnboardCount => Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipData(ShipId).TemporaryData.WorkersOnboardCount;

	public int WorkersOnboardCountLimit => Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.WorkersOnboardCountLimit;

	public int ShipSpeed()
	{
		return GetShipSpeed();
	}

	public int MiningSpeed(int workerNum)
	{
		return GetMiningSpeed(workerNum);
	}

	public MiningState GetMiningStateForModelId(string modelId)
	{
		if (SelectedMinerals == null)
		{
			return MiningState.Empty;
		}
		foreach (string selectedMineral in SelectedMinerals)
		{
			if (selectedMineral.StartsWith(modelId))
			{
				string text = selectedMineral.Split(new string[1] { "##" }, StringSplitOptions.None).Last();
				if (string.IsNullOrEmpty(text))
				{
					return MiningState.Mining;
				}
				return (MiningState)(int.Parse(text) + 1);
			}
		}
		return MiningState.Empty;
	}

	public void UnregisterOnChangeEvents()
	{
		OnChange = null;
		OnGroupInfoChange = null;
		OnCollectingConfigChange = null;
		OnShipSummaryChange = null;
	}

	public void SyncInfo(GvGMode3GetShipSummaryAndFlightScheduleInfo info)
	{
		IsInit = true;
		FlightSchedule = info.FlightSchedule;
		State = (eShipState)info.State;
		StayIslandId = info.StayIslandId;
		ShipIconScale = info.AvatarScale;
		PlanStatusInfo = info.ShipPlanStatus;
		OnChange?.Invoke(this);
		OnGroupInfoChange?.Invoke(this);
	}

	public void SyncStayIsland(S2C_StayIsland.Request req)
	{
		State = (eShipState)req.ShipState;
		StayIslandId = req.ShipTargetIslandId;
		GvGMode3ShipModel gvGMode3ShipModel = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.Ships.Find((GvGMode3ShipModel ship) => ship.TemporaryData != null && ship.TemporaryData.EntityId == req.EntityId);
		if (gvGMode3ShipModel != null)
		{
			gvGMode3ShipModel.TemporaryData.ShipState = State;
			gvGMode3ShipModel.TemporaryData.TargetIslandId = StayIslandId;
		}
		OnChange?.Invoke(this);
		OnGroupInfoChange?.Invoke(this);
		if (State == eShipState.NotLaunched)
		{
			SharedMessenger.Broadcast("ON_GVG3_SHIP_DESTROY");
		}
	}

	public void SyncStayIsland(eShipState shipState, int stayIslandId)
	{
		State = shipState;
		StayIslandId = stayIslandId;
		FlightSchedule = null;
		OnChange?.Invoke(this);
		OnGroupInfoChange?.Invoke(this);
	}

	public void SyncIslandAction(S2C_IslandAction.Request req)
	{
		State = (eShipState)req.ShipState;
		StayIslandId = req.ShipTargetIslandId;
		FlightSchedule = req.FlightSchedule;
		OnChange?.Invoke(this);
		OnChangeFlightSchedule?.Invoke(this);
		OnGroupInfoChange?.Invoke(this);
	}

	public void SyncPlanStatus(S2C_ShipContinueExecutePlan.Request req)
	{
		PlanStatusInfo = req.ShipPlanStatusInfo;
	}

	public void SyncInfoFromRecord(GvGMode3ShipModel shipRecord, GvGMode3ObserverRecord observerRecord)
	{
		IsInit = true;
		ShipId = shipRecord.ShipId;
		State = shipRecord.TemporaryData.ShipState;
		StayIslandId = shipRecord.TemporaryData.TargetIslandId;
		FormationIdTemp = (FormationId = shipRecord.TemporaryData.FormationId);
		FoodOnboardCount = shipRecord.TemporaryData.FoodOnboardCount;
		ShipSightRange = (float)observerRecord.ShipSightRange / 1000f;
		SoulGuideCDTimestamp = shipRecord.TemporaryData.SoulGuideCDTimestamp;
		UpdateCurrentUnitInfos(shipRecord.TemporaryData.Group, shipRecord.TemporaryData.BackupGroup);
		OnChange?.Invoke(this);
		OnGroupInfoChange?.Invoke(this);
	}

	public void SyncShipSightRange(int shipSightRange)
	{
		ShipSightRange = (float)shipSightRange / 1000f;
		OnChange?.Invoke(this);
	}

	public void SyncFood(int foodCount)
	{
		FoodOnboardCount = foodCount;
		OnChange?.Invoke(this);
	}

	public void SyncInfoFromSaveGroupConfig(C2S_SaveShipGroupConfig.Response response)
	{
		if (response.IsSaveConfig)
		{
			FormationId = FormationIdTemp;
			CurrentUnitInfos = CurrentUnitInfosTemp.Clone();
		}
		else
		{
			FormationId = response.FormationId;
			UpdateCurrentUnitInfos(response.On_Group, response.On_BackUpGroup);
		}
		GvGMode3ShipTemporaryData temporaryData = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipData(ShipId).TemporaryData;
		temporaryData.FormationId = FormationId;
		temporaryData.Group = ((response.On_Group != null) ? response.On_Group : new List<GvGMode3UnitInfo>());
		temporaryData.BackupGroup = ((response.On_BackUpGroup != null) ? response.On_BackUpGroup : new List<GvGMode3UnitInfo>());
		OnChange?.Invoke(this);
		OnGroupInfoChange?.Invoke(this);
	}

	public void UpdateUnitTotal(int groupCountLimit)
	{
		if (CurrentUnitInfos != null)
		{
			foreach (GvGMode3UnitInfo currentUnitInfo in CurrentUnitInfos)
			{
				currentUnitInfo.Total = currentUnitInfo.PerTeamMemberCnt * groupCountLimit;
			}
		}
		if (CurrentUnitInfosTemp == null)
		{
			return;
		}
		foreach (GvGMode3UnitInfo item in CurrentUnitInfosTemp)
		{
			item.Total = item.PerTeamMemberCnt * groupCountLimit;
		}
	}

	public void SyncSoldierCount(S2C_SyncSoldierCount.Request request)
	{
		if (request.ShipId != ShipId || request.SoldierCount == null)
		{
			return;
		}
		for (int i = 0; i < CurrentUnitInfos.Count; i++)
		{
			GvGMode3UnitInfo unit = CurrentUnitInfos[i];
			RItem rItem = request.SoldierCount.FirstOrDefault((RItem item) => item.ItemId == unit.SoldierId);
			if (rItem != null)
			{
				unit.CurCnt = rItem.cnt;
			}
		}
		for (int num = 0; num < CurrentUnitInfosTemp.Count; num++)
		{
			GvGMode3UnitInfo unit2 = CurrentUnitInfosTemp[num];
			RItem rItem2 = request.SoldierCount.FirstOrDefault((RItem item) => item.ItemId == unit2.SoldierId);
			if (rItem2 != null)
			{
				unit2.CurCnt = rItem2.cnt;
			}
		}
		OnChange?.Invoke(this);
		OnGroupInfoChange?.Invoke(this);
	}

	public void SyncInfoFromFillUpSoldiers(S2C_FillupSoldiers.Request response)
	{
		GvGMode3ShipTemporaryData temporaryData = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GetMyShipData(ShipId).TemporaryData;
		temporaryData.Group = ((response.On_Group != null) ? response.On_Group : new List<GvGMode3UnitInfo>());
		temporaryData.BackupGroup = ((response.On_BackUpGroup != null) ? response.On_BackUpGroup : new List<GvGMode3UnitInfo>());
		UpdateCurrentUnitInfos(response.On_Group, response.On_BackUpGroup);
		UpdateSoldiersStock(response.ChangedSoldiers);
		OnChange?.Invoke(this);
		OnGroupInfoChange?.Invoke(this);
	}

	public void SyncInfoFromGetUnitDetailInfo(string soldierId, C2S_GetUnitDetailInfo.Response response)
	{
		for (int i = 0; i < CurrentUnitInfos.Count; i++)
		{
			if (!(CurrentUnitInfos[i].SoldierId != soldierId))
			{
				CurrentUnitInfos[i].UpdateUnitInfo(response);
			}
		}
		for (int j = 0; j < CurrentUnitInfosTemp.Count; j++)
		{
			if (!(CurrentUnitInfosTemp[j].SoldierId != soldierId))
			{
				CurrentUnitInfosTemp[j].UpdateUnitInfo(response);
			}
		}
		OnChange?.Invoke(this);
		OnGroupInfoChange?.Invoke(this);
	}

	public void SyncInfoFromShipCollectingDetail(C2S_GetShipCollectingDetailInfo.Response response)
	{
		State = (eShipState)response.ShipState;
		SelectedMinerals = ((response.CurChooseStockModel != null) ? new List<string>(response.CurChooseStockModel) : new List<string>());
		_availableMinerals = ((response.IslandStockModels != null) ? new List<CollectingStockModel>(response.IslandStockModels) : new List<CollectingStockModel>());
		CollectingEfficiencyModel = ((response.CollectingEfficiencyModel != null) ? response.CollectingEfficiencyModel.Clone() : new RealTimeCollectingEfficiencyModel());
		_avgCollectingEfficiency = response.AvgCollectingEfficiency;
		_shipSummarySpeed = response.ShipSummarySpeed;
		OnCollectingConfigChange?.Invoke();
	}

	public void SyncCollectingEfficiencyModel(RealTimeCollectingEfficiencyModel model)
	{
		CollectingEfficiencyModel = model ?? new RealTimeCollectingEfficiencyModel();
		OnCollectingConfigChange?.Invoke();
	}

	public void SyncInfoFromChangeShipCollecting(C2S_ChangeShipCollectingInfo.Response response)
	{
		SelectedMinerals = ((response.SelectedCollectingStockModelIds != null) ? new List<string>(response.SelectedCollectingStockModelIds) : new List<string>());
		CollectingEfficiencyModel = ((response.CollectingEfficiencyModel != null) ? response.CollectingEfficiencyModel.Clone() : new RealTimeCollectingEfficiencyModel());
		OnCollectingConfigChange?.Invoke();
	}

	public void SyncShipSummary(S2C_GvGMode3ShipSummarySpeed.Request request)
	{
		_shipSummarySpeed = request.ShipSummarySpeed;
		OnShipSummaryChange?.Invoke();
	}

	private int GetMiningSpeed(int workerNum)
	{
		return Convert.ToInt32(_avgCollectingEfficiency * (float)workerNum);
	}

	private int GetShipSpeed()
	{
		return Convert.ToInt32(_shipSummarySpeed);
	}

	private List<CollectingStockModel> GetAvailableMinerals()
	{
		if (_availableMinerals != null && _availableMinerals.Count > 0)
		{
			return _availableMinerals;
		}
		return Singleton<WorldStateManager>.Instance.TryGetIsland(StayIslandId).DetailInfo.CollectingGroup;
	}

	private List<string> GetGroupInfoTemp()
	{
		return (from t in CurrentUnitInfosTemp.Take(5)
			select t.SoldierId).ToList();
	}

	private List<string> GetBackupGroupInfoTemp()
	{
		List<string> list = (from t in CurrentUnitInfosTemp.SkipItems(5)
			select t.SoldierId).ToList();
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (!UnitInfoHelper.CheckIsValidSoldier(list[num]))
			{
				list.RemoveAt(num);
			}
		}
		return list;
	}

	public void RestoreGroupChanged(Action onFinished = null)
	{
		FormationIdTemp = FormationId;
		CurrentUnitInfosTemp = CurrentUnitInfos.Clone();
		onFinished?.Invoke();
	}

	private void UpdateSoldiersStock(List<RItem> changeSoldiers)
	{
		if (changeSoldiers != null)
		{
			for (int i = 0; i < changeSoldiers.Count; i++)
			{
				GameManagers.Instance.StockController.SetStock(changeSoldiers[i].ItemId, changeSoldiers[i].cnt, StockInContext.GvGMode3FillUpSoldier_On);
			}
		}
	}

	public void UpdateFormationPower()
	{
		FormationPower = 0;
		int num = 0;
		foreach (GvGMode3UnitInfo item in CurrentUnitInfosTemp)
		{
			if (UnitInfoHelper.CheckIsValidSoldier(item.SoldierId) && num < 5)
			{
				FormationPower += UnitInfoHelper.GetFormationPower(item);
				num++;
			}
		}
	}

	public int RaceSoldierNum(int shipType)
	{
		int num = 0;
		for (int i = 0; i < CurrentUnitInfosTemp.Count; i++)
		{
			if (!string.IsNullOrEmpty(CurrentUnitInfosTemp[i].SoldierId))
			{
				eRace eRace = RaceHelper.FactionToRaceEnum(GameManagers.Instance.SoldierManager.Get(CurrentUnitInfosTemp[i].SoldierId).Faction);
				if (shipType == -1 || shipType == (int)eRace)
				{
					num++;
				}
			}
		}
		return num;
	}

	public bool CurrentUnitValid()
	{
		int num = 0;
		for (int i = 0; i < GroupInfoTemp.Count; i++)
		{
			if (UnitInfoHelper.CheckIsValidSoldier(GroupInfoTemp[i]))
			{
				num++;
			}
		}
		if (num < 5)
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { "GvGShipDetail-ArmyPage-ChangeArmyBtn-0".ToLanguage() }, 1, arg3: false);
			return false;
		}
		return true;
	}

	public void SyncUnitInfoFromArchive()
	{
		foreach (GvGMode3UnitInfo unitInfo in CurrentUnitInfosTemp)
		{
			if (UnitInfoHelper.CheckIsValidSoldier(unitInfo.SoldierId))
			{
				Soldier soldier = GameManagers.Instance.SoldierManager.Get(unitInfo.SoldierId);
				unitInfo.PotentialLevel = soldier.PotentialLevel;
				unitInfo.SoldierLevel = soldier.Level;
				long[] gvGSoldiersEquippedItemIds = GameManagers.Instance.GetGvGSoldiersEquippedItemIds(unitInfo.SoldierId);
				List<int> list = new List<int>(2);
				long[] array = gvGSoldiersEquippedItemIds;
				foreach (long num in array)
				{
					int item = (int)num;
					list.Add(item);
				}
				unitInfo.EquippedItems = list.ToArray();
				int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(unitInfo.SoldierId, unitInfo.SoldierLevel);
				int total = soldierFormationNumber * Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GroupCountLimit;
				GvGMode3UnitInfo gvGMode3UnitInfo = CurrentUnitInfos.FirstOrDefault((GvGMode3UnitInfo unit) => unit.SoldierId == unitInfo.SoldierId);
				unitInfo.CurCnt = gvGMode3UnitInfo?.CurCnt ?? 0;
				unitInfo.Total = total;
				unitInfo.PerTeamMemberCnt = soldierFormationNumber;
			}
		}
		UpdateFormationPower();
	}

	private void UpdateCurrentUnitInfos(List<GvGMode3UnitInfo> group, List<GvGMode3UnitInfo> backupGroup)
	{
		CurrentUnitInfos = new List<GvGMode3UnitInfo>();
		if (group != null)
		{
			CurrentUnitInfos.AddRange(group);
		}
		FillEmptyUnitInfo(5 - CurrentUnitInfos.Count, ref CurrentUnitInfos);
		if (backupGroup != null)
		{
			CurrentUnitInfos.AddRange(backupGroup);
		}
		FillEmptyUnitInfo(BackupGroupSlotLimit - (backupGroup?.Count ?? 0), ref CurrentUnitInfos);
		CurrentUnitInfosTemp = CurrentUnitInfos.Clone();
	}

	public void UpdateBackupGroupSlotLimit(int slotLimit)
	{
		int cnt = slotLimit - BackupGroupInfo.Count;
		FillEmptyUnitInfo(cnt, ref CurrentUnitInfos);
		FillEmptyUnitInfo(cnt, ref CurrentUnitInfosTemp);
	}

	private void FillEmptyUnitInfo(int cnt, ref List<GvGMode3UnitInfo> unitInfos)
	{
		if (cnt == 0)
		{
			return;
		}
		bool flag = cnt < 0;
		cnt = Mathf.Abs(cnt);
		if (flag)
		{
			int num = unitInfos.Count - 1;
			while (num >= 0 && cnt > 0)
			{
				unitInfos.RemoveAt(num);
				cnt--;
				num--;
			}
		}
		else
		{
			for (int i = 0; i < cnt; i++)
			{
				unitInfos.Add(new GvGMode3UnitInfo
				{
					SoldierId = ""
				});
			}
		}
	}

	public void SyncInfoOnRebuildActionFinished()
	{
		OnChange?.Invoke(this);
	}

	public void SyncSoulGuideCDTimestamp(int timestamp)
	{
		if (SoulGuideCDTimestamp != timestamp)
		{
			SoulGuideCDTimestamp = timestamp;
			OnChangeSoulGuideCDTimestamp?.Invoke(this);
		}
	}

	public void SetMyShipSelected(bool selected)
	{
		IsMyShipSelected = selected;
		OnChangeMyShipSelected?.Invoke(this);
	}

	private eUIShipState GetUiShipState()
	{
		eUIShipState result = eUIShipState.NotLaunched;
		switch (State)
		{
		case eShipState.NotLaunched:
		case eShipState.Rebuilding:
			result = eUIShipState.NotLaunched;
			break;
		case eShipState.Stay:
			result = eUIShipState.Stay;
			break;
		case eShipState.DuringFlight:
			result = eUIShipState.Navigating;
			break;
		case eShipState.Collecting:
			result = eUIShipState.Mining;
			break;
		case eShipState.Fighting:
		case eShipState.SuppressRebellion:
			result = eUIShipState.InBattle;
			break;
		}
		return result;
	}

	public void SyncShipSpeedBuff(RealTimeShipSummarySpeedModel model)
	{
		_speedModel = model;
	}

	public bool HasSpeedBuff()
	{
		return _speedModel != null && _speedModel.Total > 1f;
	}

	public string SpeedBuffDesc()
	{
		return (_speedModel == null) ? string.Empty : _speedModel.GetEfficiencyText();
	}
}
