using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UnityEngine;

namespace UI.GvGBrawlFight;

public class UI_com_ShipList : GComponent
{
	public enum ShipState
	{
		Ready,
		Deployed,
		Fighting,
		Disabled,
		NotDeployed
	}

	public class ShipBattleStrategy
	{
		public GvGMode3ShipModel Ship;

		public int BattleStrategy;

		public int ZoneId;

		public bool Enable;

		public ShipState GetState(C2S_BrawlEvent_GetInfo.Response eventInfo)
		{
			if (!Enable)
			{
				return ShipState.Disabled;
			}
			BE_SignUpDataModel_ToProtocol bE_SignUpDataModel_ToProtocol = eventInfo.SelfSignUpDatas?.Find((BE_SignUpDataModel_ToProtocol x) => x.ShipId == Ship.ShipId);
			bool flag = bE_SignUpDataModel_ToProtocol != null;
			return eventInfo.GetStage() switch
			{
				C2S_BrawlEvent_GetInfo.Stage.WaitStart => flag ? ShipState.Deployed : ShipState.NotDeployed, 
				C2S_BrawlEvent_GetInfo.Stage.Fighting => flag ? ShipState.Fighting : ShipState.NotDeployed, 
				_ => flag ? ShipState.Deployed : ShipState.Ready, 
			};
		}

		public int GetEnrollIsland(C2S_BrawlEvent_GetInfo.Response eventInfo)
		{
			if (eventInfo.SelfSignUpDatas == null)
			{
				return -1;
			}
			return eventInfo.SelfSignUpDatas.Find((BE_SignUpDataModel_ToProtocol x) => x.ShipId == Ship.ShipId)?.IslandId ?? (-1);
		}

		public List<int> GetOptionalStrategyList(int currentStrategy, C2S_BrawlEvent_GetInfo.Response eventInfo)
		{
			int enrollIsland = GetEnrollIsland(eventInfo);
			if (enrollIsland > 0)
			{
				IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(enrollIsland);
				IEvent_Brawl brawlEvent = islandStateModel.BrawlEvent;
				bool isFfa = brawlEvent != null && brawlEvent.GetSubType() == eGvGMode3CampMissionSubType.RE_FFA;
				return GetBattleStrategyList(currentStrategy, isFfa);
			}
			return GetBattleStrategyList(currentStrategy, isFfa: true);
		}
	}

	public GImage n13;

	public GImage n14;

	public GList ShipList;

	public GTextField n15;

	public const string URL = "ui://hozu168rnt902a";

	public static string Name = "UI_com_ShipList";

	private C2S_BrawlEvent_GetInfo.Response _eventInfo;

	private List<ShipBattleStrategy> _shipDatas;

	private UI_com_ShipInfo _currentSelectItem;

	private bool _isViewOnly;

	private string _missionConfigId;

	public Action<UI_com_ShipInfo, ShipBattleStrategy, EventContext> onPointerDown;

	public Action<EventContext> onPointerMove;

	public Action<EventContext> onPointerUp;

	public Action<string> onClickCancelEnroll;

	public Action<ShipBattleStrategy> OnClickChangeStrategy;

	public int SingleSelectIndex;

	public bool BlockClick;

	public bool IsSelectStrategyPanelOpen => _currentSelectItem != null;

	public static string GetURL()
	{
		return "ui://hozu168rnt902a";
	}

	public static UI_com_ShipList CreateInstance()
	{
		return (UI_com_ShipList)(object)UIPackage.CreateObject("GvGBrawlFight", "com_ShipList");
	}

	public static UI_com_ShipList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rnt902a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		ShipList = (GList)((GComponent)this).GetChild("ShipList");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id = "ui://hozu168rnt902a".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id);
	}

	public void Init(C2S_BrawlEvent_GetInfo.Response eventInfo, List<ShipBattleStrategy> shipDatas, bool viewOnly, string missionConfigId = null)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		_eventInfo = eventInfo;
		_shipDatas = shipDatas;
		_isViewOnly = viewOnly;
		_missionConfigId = missionConfigId;
		SingleSelectIndex = -1;
		ShipList.itemRenderer = (ListItemRenderer)delegate(int index, GObject item)
		{
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Expected O, but got Unknown
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Expected O, but got Unknown
			//IL_0293: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Expected O, but got Unknown
			//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c6: Expected O, but got Unknown
			//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0304: Expected O, but got Unknown
			//IL_0323: Unknown result type (might be due to invalid IL or missing references)
			//IL_032d: Expected O, but got Unknown
			//IL_034b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0355: Expected O, but got Unknown
			ShipBattleStrategy shipData = _shipDatas[index];
			UI_com_ShipInfo btn = (UI_com_ShipInfo)(object)item;
			((GObject)btn).data = index;
			btn.Icon.url = GetShipIconUrlByRace(shipData.Ship.PermanentData.ShipRace);
			((GObject)btn.ShipName).text = shipData.Ship.PermanentData.ShipName.ToRealShipName();
			int num = shipData.BattleStrategy;
			if (num < 0)
			{
				num = 0;
			}
			btn.CurStrategyBtn.CampId.SetSelectedIndex(num);
			ShipState shipState = GetShipState(index);
			List<int> strategyList = shipData.GetOptionalStrategyList(num, _eventInfo);
			btn.StrategyMenu.List.itemRenderer = (ListItemRenderer)delegate(int i, GObject itemObject)
			{
				//IL_0053: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Expected O, but got Unknown
				if (itemObject is UI_btn_StrategySelection uI_btn_StrategySelection)
				{
					int strategy = strategyList[i];
					uI_btn_StrategySelection.Type.SetSelectedIndex(strategy);
					((GObject)uI_btn_StrategySelection).onClick.Set((EventCallback1)delegate(EventContext x)
					{
						x.StopPropagation();
						SingleSelectIndex = -1;
						shipData.BattleStrategy = strategy;
						OnClickChangeStrategy?.Invoke(shipData);
						OnClickCloseStrategyPanel();
						Refresh();
					});
				}
			};
			btn.StrategyMenu.List.numItems = strategyList.Count;
			btn.StrategyMenu.List.selectedIndex = strategyList.IndexOf(shipData.BattleStrategy);
			btn.State.SetSelectedIndex((int)shipState);
			int enrollIsland = shipData.GetEnrollIsland(_eventInfo);
			if (enrollIsland > 0)
			{
				string name = WorldMapConfigHelper.Configs.TryGetIsland(enrollIsland).Name;
				((GObject)btn.State1).text = name;
			}
			bool flag = SingleSelectIndex == index;
			btn.isSelect.SetSelectedIndex((!_isViewOnly && flag) ? 1 : 0);
			((GObject)btn.CurStrategyBtn).touchable = !_isViewOnly && shipState == ShipState.Deployed;
			if (!_isViewOnly && (shipState == ShipState.Ready || shipState == ShipState.Deployed))
			{
				((GObject)btn.CurStrategyBtn).onClick.Set((EventCallback1)delegate(EventContext x)
				{
					x.StopPropagation();
					ShipState shipState2 = GetShipState(index);
					if (shipState2 == ShipState.Deployed)
					{
						if (_currentSelectItem == btn)
						{
							OnClickCloseStrategyPanel();
						}
						else
						{
							OnOpenStrategyPanel(btn);
						}
					}
				});
				((GObject)btn.cancelEnroll).onClick.Set((EventCallback1)delegate(EventContext x)
				{
					x.StopPropagation();
					onClickCancelEnroll?.Invoke(shipData.Ship.ShipId);
				});
				((GObject)btn).onClick.Set((EventCallback1)delegate(EventContext x)
				{
					x.StopPropagation();
					OnClickSelectBtn(btn);
				});
				Vector2 touchDownPos = default(Vector2);
				bool isDrag = false;
				((GObject)btn.dragArea).onTouchBegin.Set((EventCallback1)delegate(EventContext x)
				{
					//IL_0008: Unknown result type (might be due to invalid IL or missing references)
					//IL_000d: Unknown result type (might be due to invalid IL or missing references)
					touchDownPos = x.inputEvent.position;
					isDrag = false;
					x.CaptureTouch();
				});
				((GObject)btn.dragArea).onTouchMove.Set((EventCallback1)delegate(EventContext x)
				{
					//IL_000a: Unknown result type (might be due to invalid IL or missing references)
					//IL_0015: Unknown result type (might be due to invalid IL or missing references)
					//IL_001a: Unknown result type (might be due to invalid IL or missing references)
					//IL_001f: Unknown result type (might be due to invalid IL or missing references)
					if (!isDrag)
					{
						Vector2 val = touchDownPos - x.inputEvent.position;
						if (((Vector2)(ref val)).magnitude > 10f)
						{
							isDrag = true;
							onPointerDown?.Invoke(btn, shipData, x);
						}
					}
					if (isDrag)
					{
						onPointerMove?.Invoke(x);
					}
				});
				((GObject)btn.dragArea).onTouchEnd.Set((EventCallback1)delegate(EventContext x)
				{
					onPointerUp?.Invoke(x);
				});
			}
		};
		Refresh();
	}

	public void Refresh()
	{
		if (_shipDatas != null)
		{
			ShipList.numItems = _shipDatas.Count;
		}
	}

	public void OnClickCloseStrategyPanel()
	{
		if (_currentSelectItem != null)
		{
			_currentSelectItem.isSelectStrategy.SetSelectedIndex(0);
			_currentSelectItem.CurStrategyBtn.isDown.SetSelectedIndex(0);
			_currentSelectItem = null;
		}
	}

	private ShipState GetShipState(int index)
	{
		ShipBattleStrategy shipBattleStrategy = _shipDatas[index];
		if (!string.IsNullOrEmpty(_missionConfigId) && !StrictCondition_AmplifierCheck(shipBattleStrategy.Ship.ShipId, _missionConfigId))
		{
			return ShipState.Disabled;
		}
		return shipBattleStrategy.GetState(_eventInfo);
	}

	private void OnOpenStrategyPanel(UI_com_ShipInfo btn)
	{
		if (!BlockClick)
		{
			OnClickCloseStrategyPanel();
			_currentSelectItem = btn;
			btn.isSelectStrategy.SetSelectedIndex(1);
			btn.CurStrategyBtn.isDown.SetSelectedIndex(1);
			btn.isSelect.SetSelectedIndex(0);
		}
	}

	private void OnClickSelectBtn(UI_com_ShipInfo btn)
	{
		if (BlockClick)
		{
			return;
		}
		OnClickCloseStrategyPanel();
		int num = (int)((GObject)btn).data;
		if (GetShipState(num) == ShipState.Deployed)
		{
			if (SingleSelectIndex == num)
			{
				SingleSelectIndex = -1;
			}
			else
			{
				SingleSelectIndex = num;
			}
			Refresh();
		}
	}

	private static List<int> GetBattleStrategyList(int currentStrategy, bool isFfa)
	{
		int obCampId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.ObCampId;
		if (!isFfa)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < WorldMapConfigHelper.Configs.CampIds.Count + 1; i++)
			{
				if (i != obCampId && i != currentStrategy)
				{
					list.Add(i);
				}
			}
			return list;
		}
		List<int> list2 = new List<int> { 0, 1, 2, 3, 4 };
		list2.Remove(currentStrategy);
		return list2;
	}

	public static string GetShipIconUrlByRace(int race)
	{
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType(race);
		return ShipConfigHelper.GetSkinById(byShipRaceType.DefaultSkinId).IconUrl;
	}

	public static bool StrictCondition_AmplifierCheck(string shipId, string missionConfigId)
	{
		GvGMode3EventMissionConfigModel gvGMode3EventMissionConfigModel = GvG3FlagShipMissionsConfigHelper.EventMissionConfig(missionConfigId);
		if (gvGMode3EventMissionConfigModel.BrawlSubTypeData.AmpScoreLimit <= 0)
		{
			return true;
		}
		int shipAmpScore = GetShipAmpScore(shipId);
		return shipAmpScore >= gvGMode3EventMissionConfigModel.BrawlSubTypeData.AmpScoreLimit;
	}

	public static int GetShipAmpScore(string shipId)
	{
		int num = 0;
		GvGAmplifierManager.ShipAmplifiersData shipAmplifiersData = Singleton<GvGAmplifierManager>.Instance.TryGetShipAmplifiers(shipId);
		if (shipAmplifiersData == null)
		{
			return num;
		}
		foreach (KeyValuePair<int, int> shipsAmplifier in shipAmplifiersData.ShipsAmplifiers)
		{
			int key = shipsAmplifier.Key;
			int value = shipsAmplifier.Value;
			AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(key);
			num += amplifierModel.Score * value;
		}
		return num;
	}
}
