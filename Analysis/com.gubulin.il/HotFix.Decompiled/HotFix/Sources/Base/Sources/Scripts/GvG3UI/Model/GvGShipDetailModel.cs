using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvGShipDetailModel
{
	private GvGMode3ShipModel _RecordData;

	public bool IsJoinIZ;

	public string ShipId;

	public int EntityId;

	public int Index;

	public int TargetBuildCompleteTime;

	public int TotalSoldiersCount;

	public int CurSoldiersCount;

	private Action OnChange;

	public string ShipName;

	public eUIShipState UIShipState;

	public int CampId;

	public int ShipType;

	public int ShipSkinId;

	public int ShipPower;

	public int FoodOnboardCount;

	public const int LegendItemsLimit = 2;

	public string FormationId;

	public List<GvGMode3UnitInfo> CurrentUnitInfos;

	public bool IsDraggable;

	public int FormationPower;

	public int AmplifierCountLimit;

	public Dictionary<int, int> Amplifiers;

	public int ShipSpeed;

	public int MiningSpeed;

	public int WorkersOnboardCount;

	public int WorkersOnboardCountLimit;

	private List<CollectingStockModel> _availableMinerals;

	public RealTimeCollectingEfficiencyModel CollectingEfficiencyModel;

	public float AvgCollectingEfficiency;

	public bool HasStateModel => Singleton<GvGMode3RoomManager>.Instance.IsConnecting && Singleton<WorldStateManager>.Instance.TryGetShip(EntityId) != null;

	public ShipStateModel ShipState => Singleton<WorldStateManager>.Instance.TryGetShip(EntityId);

	public int StayIslandId => HasStateModel ? ShipState.StayIslandId : (-1);

	public string StayIslandName => WorldMapConfigHelper.Configs.TryGetIsland(StayIslandId).Name;

	public bool ShipNeedLaunch => CanLaunch();

	public eShipBuildState ShipBuildState
	{
		get
		{
			eShipBuildState eShipBuildState2 = (eShipBuildState)_RecordData.PermanentData.ShipBuildState;
			if ((eShipBuildState2 == eShipBuildState.Building || eShipBuildState2 == eShipBuildState.Rebuilding) && TargetBuildCompleteTime <= (int)GameController.Instance.GetServerTime())
			{
				eShipBuildState2 = eShipBuildState.PendingAcceptance;
			}
			return eShipBuildState2;
		}
		set
		{
			_RecordData.PermanentData.ShipBuildState = (int)value;
		}
	}

	public int AvailableWorkersLeft => Dungeon.GetFreeManPower(GameManagers.Instance);

	public List<CollectingStockModel> AvailableMinerals => GetAvailableMinerals();

	public GvGShipDetailModel()
	{
		CurrentUnitInfos = new List<GvGMode3UnitInfo>();
		Amplifiers = new Dictionary<int, int>();
		CollectingEfficiencyModel = new RealTimeCollectingEfficiencyModel();
	}

	public void RegisterEvent()
	{
		if (HasStateModel)
		{
			ShipStateModel shipState = ShipState;
			shipState.OnChange = (Action<ShipStateModel>)Delegate.Combine(shipState.OnChange, new Action<ShipStateModel>(OnShipStateChange));
			shipState.OnChangeSoulGuideCDTimestamp = (Action<ShipStateModel>)Delegate.Combine(shipState.OnChangeSoulGuideCDTimestamp, new Action<ShipStateModel>(OnShipStateChange));
		}
	}

	public void UnregisterEvent()
	{
		if (HasStateModel)
		{
			ShipStateModel shipState = ShipState;
			shipState.OnChange = (Action<ShipStateModel>)Delegate.Remove(shipState.OnChange, new Action<ShipStateModel>(OnShipStateChange));
			shipState.OnChangeSoulGuideCDTimestamp = (Action<ShipStateModel>)Delegate.Remove(shipState.OnChangeSoulGuideCDTimestamp, new Action<ShipStateModel>(OnShipStateChange));
		}
	}

	private void OnShipStateChange(ShipStateModel shipState)
	{
		OnChange?.Invoke();
	}

	public void SetOnChange(Action callback)
	{
		OnChange = callback;
	}

	public void RefreshName()
	{
		ShipName = _RecordData.PermanentData.ShipName.ToRealShipName();
	}

	public void SetRecordData(GvGMode3ShipModel record)
	{
		_RecordData = record;
		ShipId = record.ShipId;
		Index = record.PermanentData.Index;
		TargetBuildCompleteTime = record.PermanentData.TargetBuildCompleteTime;
		ShipType = record.PermanentData.ShipRace;
		ShipName = record.PermanentData.ShipName.ToRealShipName();
		IsJoinIZ = record.PermanentData.IsJoinIZ;
		if (!IsJoinIZ)
		{
			ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(ShipType);
			ShipSkinId = byShipRaceType.DefaultSkinId;
			return;
		}
		if (record.TemporaryData == null)
		{
			throw new Exception("shipId=" + record.ShipId + " 飞空艇已经加入副本但gvg数据不存在");
		}
		GvGMode3ShipTemporaryData temporaryData = _RecordData.TemporaryData;
		UpdateUiState(temporaryData.ShipState);
		EntityId = temporaryData.EntityId;
		CampId = temporaryData.CampId;
		ShipSkinId = temporaryData.ShipSkinId;
		ShipPower = temporaryData.ShipPower;
		ShipSpeed = temporaryData.ShipSpeed;
		FoodOnboardCount = temporaryData.FoodOnboardCount;
		FormationId = temporaryData.FormationId;
		CurrentUnitInfos = new List<GvGMode3UnitInfo>();
		if (temporaryData.Group != null)
		{
			CurrentUnitInfos.AddRange(temporaryData.Group);
		}
		if (temporaryData.BackupGroup != null)
		{
			CurrentUnitInfos.AddRange(temporaryData.BackupGroup);
		}
		UpdateSoldiersCount();
		WorkersOnboardCount = temporaryData.WorkersOnboardCount;
		IsDraggable = true;
	}

	public void GetShipData(Action<string> onFinished = null)
	{
		Singleton<GvGAmplifierManager>.Instance.GetShipAmplifiers(ShipId, delegate(GvGAmplifierManager.ShipAmplifiersData data)
		{
			Amplifiers = data.ShipsAmplifiers;
			onFinished?.Invoke(ShipId);
		});
	}

	private List<CollectingStockModel> GetAvailableMinerals()
	{
		if (_availableMinerals != null && _availableMinerals.Count > 0)
		{
			return _availableMinerals;
		}
		return Singleton<WorldStateManager>.Instance.TryGetIsland(StayIslandId).DetailInfo.CollectingGroup;
	}

	private bool CanLaunch()
	{
		if (!_RecordData.PermanentData.IsJoinIZ)
		{
			return false;
		}
		return _RecordData.TemporaryData.ShipState == eShipState.NotLaunched;
	}

	public bool CanRebuild()
	{
		if (!IsJoinIZ)
		{
			return false;
		}
		if (!HasStateModel)
		{
			return false;
		}
		ShipStateModel shipState = ShipState;
		if (shipState.State == eShipState.NotLaunched)
		{
			return true;
		}
		if (shipState.IsSoulGuideCoolingDown)
		{
			return false;
		}
		if (shipState.State == eShipState.Stay)
		{
			eIslandType type = WorldMapConfigHelper.Configs.TryGetIsland(StayIslandId).Props.Type;
			return type == eIslandType.MainMoon || type == eIslandType.Moon;
		}
		return false;
	}

	public bool CanRemove()
	{
		if (!IsJoinIZ)
		{
			return true;
		}
		if (Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.LastOneShip())
		{
			return false;
		}
		ShipStateModel shipState = ShipState;
		if (shipState.State == eShipState.NotLaunched)
		{
			return true;
		}
		if (shipState.IsSoulGuideCoolingDown)
		{
			return false;
		}
		if (shipState.State == eShipState.Stay)
		{
			eIslandType type = WorldMapConfigHelper.Configs.TryGetIsland(StayIslandId).Props.Type;
			return type == eIslandType.MainMoon || type == eIslandType.Moon;
		}
		return false;
	}

	public eCannotRemoveType CannotRemoveType()
	{
		if (Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.LastOneShip())
		{
			return eCannotRemoveType.LastOneShip;
		}
		ShipStateModel shipState = ShipState;
		eIslandType type = WorldMapConfigHelper.Configs.TryGetIsland(StayIslandId).Props.Type;
		if (shipState.State != eShipState.Stay || (type != eIslandType.MainMoon && type != eIslandType.Moon))
		{
			return eCannotRemoveType.NotInMoonIsland;
		}
		if (shipState.IsSoulGuideCoolingDown)
		{
			return eCannotRemoveType.SoulGuideCoolingDown;
		}
		return eCannotRemoveType.Unknown;
	}

	public void UpdateFormationPower()
	{
		FormationPower = 0;
		int num = 0;
		foreach (GvGMode3UnitInfo currentUnitInfo in CurrentUnitInfos)
		{
			if (UnitInfoHelper.CheckIsValidSoldier(currentUnitInfo.SoldierId) && num < 5)
			{
				FormationPower += UnitInfoHelper.GetFormationPower(currentUnitInfo);
				num++;
			}
		}
	}

	public void UpdateSoldiersCount()
	{
		TotalSoldiersCount = 0;
		CurSoldiersCount = 0;
		foreach (GvGMode3UnitInfo currentUnitInfo in CurrentUnitInfos)
		{
			if (UnitInfoHelper.CheckIsValidSoldier(currentUnitInfo.SoldierId))
			{
				CurSoldiersCount += currentUnitInfo.CurCnt;
				TotalSoldiersCount += currentUnitInfo.Total;
			}
		}
	}

	private void UpdateUiState(eShipState shipState)
	{
		switch (shipState)
		{
		case eShipState.NotLaunched:
		case eShipState.Rebuilding:
			UIShipState = eUIShipState.NotLaunched;
			break;
		case eShipState.Stay:
			UIShipState = eUIShipState.Stay;
			break;
		case eShipState.DuringFlight:
			UIShipState = eUIShipState.Navigating;
			break;
		case eShipState.Collecting:
			UIShipState = eUIShipState.Mining;
			break;
		case eShipState.Fighting:
		case eShipState.SuppressRebellion:
			UIShipState = eUIShipState.InBattle;
			break;
		case eShipState.FillUpSoldier:
			break;
		}
	}

	private void UpdateStateOnLaunched(int islandId)
	{
		Singleton<GvGMode3RoomManager>.Instance.SyncObserverShipLaunchState(_RecordData.TemporaryData.EntityId, islandId);
		UpdateUiState(_RecordData.TemporaryData.ShipState);
	}

	public void SyncShipLaunch(int islandId, Action onFinished = null)
	{
		Singleton<GvGMode3RoomManager>.Instance.LaunchShip(EntityId, islandId, delegate
		{
			UpdateStateOnLaunched(islandId);
			SharedMessenger.Broadcast("ON_GVG3_SHIP_LAUNCH", ShipId);
			onFinished?.Invoke();
		});
	}

	public void GetLaunchableIsland(Action<GvGShipDetailModel> onFinished = null)
	{
		Singleton<GvGShipUiInfoManager>.Instance.GetLaunchableIsland(this, onFinished);
	}

	public void SetRebuildingSkinId(int newShipRace)
	{
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(newShipRace);
		ShipSkinId = byShipRaceType.DefaultSkinId;
	}
}
