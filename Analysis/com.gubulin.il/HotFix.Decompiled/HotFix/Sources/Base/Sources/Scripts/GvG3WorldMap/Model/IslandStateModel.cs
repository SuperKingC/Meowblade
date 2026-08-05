using System;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.ClientApi;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

public class IslandStateModel
{
	public int VersionNumber = -1;

	public int IslandId;

	public int CampId;

	public bool IsOnTop = false;

	public eGvGMode3IslandState State;

	public int ProtectedPeriodTimestamp;

	public int NPCRebornTimestamp;

	public int NPCRecoveryTimestamp;

	public int RandomEventStartTimestamp;

	public int RandomEventEndTimestamp;

	public float ObedienceValue;

	public List<int> Markers;

	public List<EOI_ShipInfoOnIsland> ShipsForDisplay;

	public List<(int, int)> CampShipCount;

	public eIslandShieldState ShieldState = eIslandShieldState.Invalid;

	public int AttackerIslandId;

	public GvGMode3IslandDetailInfo DetailInfo;

	public bool IsShowHiddenResource;

	public FlagShipAttackEvent AttackEventFromFlagShip;

	public int Last火力支援ActivateTimestamp = -1;

	public bool HideNameAndState;

	public List<IIslandEvent> IslandEvents = new List<IIslandEvent>();

	public IEvent_火力支援 Event_火力支援;

	public IEvent_额外发现 Event_额外发现;

	public IEvent_伟大航路 Event_伟大航路;

	public IIslandEvent RandomEvent;

	public eRandomEventUIState RandomEventSubType;

	public IIslandEvent TreasureMapEvent;

	public eTreasureMapUIState TreasureMapEventSubType;

	public IEvent_PlayerCommand PlayerCommand;

	public ePlayerCommandUIState PlayerCommandSubType;

	public IEvent_Brawl BrawlEvent;

	public Action<IslandStateModel> OnChange;

	public Action<IslandStateModel> OnFogAreaChange;

	public Action<IslandStateModel> OnHideNameAndStateChange;

	public Action<IslandStateModel> OnDetailChange;

	public Action<IslandStateModel> OnChangeEvent;

	public Action<IslandStateModel> OnPlayerCommandChange;

	public Action<IslandStateModel> OnFlagShipStayChange;

	public Action<IslandStateModel> OnChangeFlagShipAttackEvent;

	public Action<float> OnCameraLocate;

	public Action<IslandController> OnControllerLoaded;

	public Action<IslandController> OnControllerUnloaded;

	public Action<string> OnFilterChange;

	public Action<bool> OnHideStateChange;

	private IslandShipDockInRecord _dockInRecord;

	private string _curFilterId;

	public bool Is火力支援Active => Event_火力支援 != null && Event_火力支援.StillValid((int)GameController.Instance.GetServerTime());

	public bool Is额外发现Active => Event_额外发现 != null && Event_额外发现.StillValid((int)GameController.Instance.GetServerTime());

	public bool can额外发现Share => Is额外发现Active && Event_额外发现.CanShare;

	public bool Is伟大航路Active => Event_伟大航路 != null && Event_伟大航路.StillValid((int)GameController.Instance.GetServerTime());

	public bool Is伟大航路Shared => Is伟大航路Active && Event_伟大航路.IsShared;

	public bool IsHiddenIsland
	{
		get
		{
			IslandConfigData islandConfigData = WorldMapConfigHelper.Configs.TryGetIsland(IslandId);
			return islandConfigData.IsHiddenIsland;
		}
	}

	public bool IsHiddenIslandActive
	{
		get
		{
			int timestamp = (int)GameController.Instance.GetServerTime();
			bool flag = Event_伟大航路 != null && Event_伟大航路.StillValid(timestamp);
			bool flag2 = RandomEvent != null && RandomEventSubType == eRandomEventUIState.FindIsland && RandomEvent.StillValid(timestamp);
			return flag || flag2;
		}
	}

	public bool IsSpecialSuppressIsland => WorldMapConfigHelper.Configs.SpecialSuppressIslandIds.Contains(IslandId);

	public bool IsVisible
	{
		get
		{
			if (IsSpecialSuppressIsland)
			{
				return Singleton<GvGTalentsManager>.Instance.GeTalentUiModel(841).Effective;
			}
			if (IsHiddenIsland)
			{
				return IsHiddenIslandActive;
			}
			return true;
		}
	}

	public bool EventNeedUpdateExpireTimestamp
	{
		get
		{
			int serverTime = (int)GameController.Instance.GetServerTime();
			return (Event_伟大航路 != null && Event_伟大航路.StillValid(serverTime)) || IslandEvents.Any((IIslandEvent e) => e.StillValid(serverTime)) || (PlayerCommand != null && PlayerCommand.StillValid(serverTime));
		}
	}

	public IslandShipDockInRecord ShipDockInRecord => _dockInRecord ?? (_dockInRecord = new IslandShipDockInRecord(IslandId));

	public string CurFilterId
	{
		get
		{
			return _curFilterId;
		}
		set
		{
			_curFilterId = value;
			OnFilterChange?.Invoke(value);
		}
	}

	public void UnregisterOnChangeEvents()
	{
		OnChange = null;
		OnDetailChange = null;
		OnChangeEvent = null;
		OnPlayerCommandChange = null;
		OnFlagShipStayChange = null;
		OnCameraLocate = null;
		OnFilterChange = null;
	}

	public void ShowOnTop(bool isOnTop)
	{
		IsOnTop = isOnTop;
		OnChange?.Invoke(this);
	}

	public void SyncInfo(GvGMode3IslandEntityInfo info)
	{
		IslandId = info.IslandId;
		CampId = info.CampId;
		State = (eGvGMode3IslandState)info.State;
		ProtectedPeriodTimestamp = info.ProtectedPeriodTimestamp;
		ObedienceValue = info.ObedienceValue;
		NPCRebornTimestamp = info.NPCRebornTimestamp;
		NPCRecoveryTimestamp = info.NPCRecoveryTimestamp;
		RandomEventStartTimestamp = info.RandomEventStartTimestamp;
		RandomEventEndTimestamp = info.RandomEventEndTimestamp;
		CampShipCount = info.CampShipCount;
		ShieldState = (eIslandShieldState)info.ShieldState;
		AttackerIslandId = info.AttackerIslandId;
		VersionNumber = info.VersionNumber;
		ParseAllEvents(info.Events);
		OnChange?.Invoke(this);
		OnChangeEvent?.Invoke(this);
		OnPlayerCommandChange?.Invoke(this);
	}

	public void SyncCampShips(EOI_IslandShipInfoOnIsland info)
	{
		bool flag = false;
		if (!CheckShipsForDisplayEqual(ShipsForDisplay, info.IslandCapmShips))
		{
			ShipsForDisplay = info.IslandCapmShips;
			flag = true;
		}
		if (SyncCampShipCount(info.CampShipCount))
		{
			flag = true;
		}
		if (flag)
		{
			OnChange?.Invoke(this);
		}
	}

	public void SyncDetailInfo(GvGMode3IslandDetailInfo info)
	{
		DetailInfo = info;
		if (DetailInfo.PlayerInfos == null)
		{
			DetailInfo.PlayerInfos = new List<GvGMode3IslandDetailInfo_PlayerInfos>();
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (GvGMode3IslandDetailInfo_PlayerInfos playerInfo in DetailInfo.PlayerInfos)
		{
			if (!dictionary.ContainsKey(playerInfo.CampId))
			{
				dictionary[playerInfo.CampId] = 0;
			}
			dictionary[playerInfo.CampId] += playerInfo.ShipCount;
		}
		List<(int, int)> list = new List<(int, int)>();
		foreach (KeyValuePair<int, int> item in dictionary)
		{
			list.Add((item.Key, item.Value));
		}
		SyncCampShipCount(list);
		OnChange?.Invoke(this);
		ObedienceValue = info.ObedienceValue;
		OnDetailChange?.Invoke(this);
	}

	private bool SyncCampShipCount(List<(int CampId, int UserCount)> newCampShipCount)
	{
		if (CheckIslandCampShipCountEqual(CampShipCount, newCampShipCount))
		{
			return false;
		}
		string islandLocalDataKey = Singleton<WorldStateManager>.Instance.GetIslandLocalDataKey(IslandId);
		GvGMode3LocalIslandData typeFromProtoBase = GameLocalDataManager.GetTypeFromProtoBase64(islandLocalDataKey, () => (GvGMode3LocalIslandData)null);
		if (typeFromProtoBase != null)
		{
			typeFromProtoBase.Info.CampShipCount = newCampShipCount;
			GameLocalDataManager.SetTypeToProtoBase64(islandLocalDataKey, typeFromProtoBase);
		}
		CampShipCount = newCampShipCount;
		return true;
	}

	private bool CheckShipsForDisplayEqual(List<EOI_ShipInfoOnIsland> a, List<EOI_ShipInfoOnIsland> b)
	{
		if (b == null || b != a)
		{
			return false;
		}
		if (a == null || b != a)
		{
			return false;
		}
		if (a.Count != b.Count)
		{
			return false;
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (EOI_ShipInfoOnIsland item in a)
		{
			dictionary.Add(item.EntityId, item.SlotIndex);
		}
		bool result = true;
		foreach (EOI_ShipInfoOnIsland item2 in b)
		{
			if (dictionary.TryGetValue(item2.EntityId, out var value))
			{
				item2.SlotIndex = value;
			}
			else
			{
				result = false;
			}
		}
		return result;
	}

	private bool CheckIslandCampShipCountEqual(List<(int CampId, int UserCount)> a, List<(int CampId, int UserCount)> b)
	{
		if (b == null || b != a)
		{
			return false;
		}
		if (a == null || b != a)
		{
			return false;
		}
		if (a.Count != b.Count)
		{
			return false;
		}
		foreach (var item in a)
		{
			if (!b.Contains(item))
			{
				return false;
			}
		}
		return true;
	}

	public void SyncAttackEventFromFlagShip(FlagShipAttackEvent attackEvent)
	{
		AttackEventFromFlagShip = attackEvent;
		OnChangeFlagShipAttackEvent?.Invoke(this);
	}

	public void SyncHiddenResourceNote(bool isShow)
	{
		IsShowHiddenResource = isShow;
		OnChange?.Invoke(this);
	}

	public void SyncIslandEvents(List<MissionStateRecordWithProgress> eventsProgress)
	{
		if (eventsProgress == null)
		{
			return;
		}
		foreach (MissionStateRecordWithProgress progress in eventsProgress)
		{
			IslandEvents.Find((IIslandEvent e) => e.MUID == progress.MUID)?.UpdateProgress(progress);
		}
	}

	public bool RandomEventFilterIsValid()
	{
		if (RandomEvent == null || !RandomEvent.StillValid((int)GameController.Instance.GetServerTime()))
		{
			return false;
		}
		return RandomEventSubType == eRandomEventUIState.Battle || RandomEventSubType == eRandomEventUIState.Collecting || RandomEventSubType == eRandomEventUIState.NPCShop;
	}

	private void ClearEvents()
	{
		IslandEvents.Clear();
		TreasureMapEvent = null;
		RandomEvent = null;
		Event_伟大航路 = null;
		PlayerCommand = null;
		Event_火力支援 = null;
	}

	private void ParseAllEvents(GvGMode3IslandEvents events)
	{
		ClearEvents();
		if (events.EventList == null)
		{
			return;
		}
		foreach (IslandEventInfo @event in events.EventList)
		{
			switch (@event.eIE)
			{
			case eIslandEvent.火力支援:
				Event_火力支援 = @event.Data.Deserialize<IEvent_火力支援>();
				break;
			case eIslandEvent.额外发现:
				Event_额外发现 = @event.Data.Deserialize<IEvent_额外发现>();
				break;
			case eIslandEvent.伟大航路:
				Event_伟大航路 = @event.Data.Deserialize<IEvent_伟大航路>();
				break;
			case eIslandEvent.PlayerCommand_Attack:
				PlayerCommandSubType = ePlayerCommandUIState.Attack;
				PlayerCommand = @event.Data.Deserialize<IEvent_PlayerCommand>();
				PlayerCommand.MUID = @event.MUID;
				PlayerCommand.EventType = @event.eIE;
				break;
			case eIslandEvent.PlayerCommand_Defense:
				PlayerCommandSubType = ePlayerCommandUIState.Defense;
				PlayerCommand = @event.Data.Deserialize<IEvent_PlayerCommand>();
				PlayerCommand.MUID = @event.MUID;
				PlayerCommand.EventType = @event.eIE;
				break;
			case eIslandEvent.PlayerCommand_Search:
				PlayerCommandSubType = ePlayerCommandUIState.Search;
				PlayerCommand = @event.Data.Deserialize<IEvent_PlayerCommand>();
				PlayerCommand.MUID = @event.MUID;
				PlayerCommand.EventType = @event.eIE;
				break;
			case eIslandEvent.RandomEvent_Battle:
				RandomEventSubType = eRandomEventUIState.Battle;
				RandomEvent = @event.Data.Deserialize<IEvent_RandomEvent_Base>();
				IslandEventInit(RandomEvent, @event, eIslandEventUiType.Random);
				break;
			case eIslandEvent.RandomEvent_Collecting:
				RandomEventSubType = eRandomEventUIState.Collecting;
				RandomEvent = @event.Data.Deserialize<IEvent_RandomEvent_Base>();
				IslandEventInit(RandomEvent, @event, eIslandEventUiType.Random);
				break;
			case eIslandEvent.RandomEvent_NPCDialog:
				RandomEventSubType = eRandomEventUIState.NPCDialog;
				RandomEvent = @event.Data.Deserialize<IEvent_RandomEvent_Base>();
				IslandEventInit(RandomEvent, @event, eIslandEventUiType.Random);
				break;
			case eIslandEvent.RandomEvent_NPCShop:
				RandomEventSubType = eRandomEventUIState.NPCShop;
				RandomEvent = @event.Data.Deserialize<IEvent_RandomEvent_Base>();
				IslandEventInit(RandomEvent, @event, eIslandEventUiType.Random);
				break;
			case eIslandEvent.TreasureMap_FindIsland:
				RandomEventSubType = eRandomEventUIState.FindIsland;
				RandomEvent = @event.Data.Deserialize<IEvent_RandomEvent_Base>();
				IslandEventInit(RandomEvent, @event, eIslandEventUiType.Random);
				break;
			case eIslandEvent.TreasureMap_FindIslandBase:
				TreasureMapEventSubType = eTreasureMapUIState.FindIslandBase;
				TreasureMapEvent = @event.Data.Deserialize<IEvent_TreasureMap_FindIslandBase>();
				IslandEventInit(TreasureMapEvent, @event, eIslandEventUiType.TreasureMap);
				break;
			case eIslandEvent.TreasureMap_Base:
				TreasureMapEventSubType = eTreasureMapUIState.Base;
				TreasureMapEvent = @event.Data.Deserialize<IEvent_TreasureMap>();
				IslandEventInit(TreasureMapEvent, @event, eIslandEventUiType.TreasureMap);
				break;
			case eIslandEvent.TreasureMap_NPCDialog:
				TreasureMapEventSubType = eTreasureMapUIState.NPCDialog;
				TreasureMapEvent = @event.Data.Deserialize<IEvent_TreasureMap>();
				IslandEventInit(TreasureMapEvent, @event, eIslandEventUiType.TreasureMap);
				break;
			case eIslandEvent.TreasureMap_Collecting:
				TreasureMapEventSubType = eTreasureMapUIState.Collecting;
				TreasureMapEvent = @event.Data.Deserialize<IEvent_TreasureMap>();
				IslandEventInit(TreasureMapEvent, @event, eIslandEventUiType.TreasureMap);
				break;
			case eIslandEvent.TreasureMap_NPCShop:
				TreasureMapEventSubType = eTreasureMapUIState.NPCShop;
				TreasureMapEvent = @event.Data.Deserialize<IEvent_TreasureMap>();
				IslandEventInit(TreasureMapEvent, @event, eIslandEventUiType.TreasureMap);
				break;
			case eIslandEvent.BrawEvent:
				BrawlEvent = @event.Data.Deserialize<IEvent_Brawl>();
				break;
			case eIslandEvent.RandomEvent_BossEvent:
			case eIslandEvent.RandomEvent_NPCEvent:
				RandomEventSubType = eRandomEventUIState.Battle;
				RandomEvent = @event.Data.Deserialize<IEvent_RandomEvent_Base>();
				IslandEventInit(RandomEvent, @event, eIslandEventUiType.Random);
				break;
			}
		}
		IslandEvents.Sort(IslandEventsSort);
		void IslandEventInit(IIslandEvent islandEvent, IslandEventInfo info, eIslandEventUiType uiType)
		{
			islandEvent.EventType = info.eIE;
			islandEvent.UiType = uiType;
			islandEvent.MUID = info.MUID;
			islandEvent.IconIdx = info.IconIdx;
			IslandEvents.Add(islandEvent);
		}
		static int IslandEventsSort(IIslandEvent a, IIslandEvent b)
		{
			int uiType = (int)a.UiType;
			int uiType2 = (int)b.UiType;
			return uiType - uiType2;
		}
	}

	public void CameraLocateIsland(float catchupTime)
	{
		OnCameraLocate?.Invoke(catchupTime);
	}
}
