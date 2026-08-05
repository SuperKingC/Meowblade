using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.Talent;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3.RealTime;
using Shift.Legion.GvG.Helpers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Ship;
using Shift.Legion.Helpers;
using UI.EnemyIntroduction;
using UI.GvGWorldMap3;
using UI.Legion;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGShipDetail;

public class UI_ArmyPage : GComponent, IGvGShipDetailPage
{
	private struct SlotData
	{
		public int SlotIndex;

		public long LegendItemInstanceId;
	}

	private class RaceSoldierCountCheckResult
	{
		public int RaceSoldierCount { get; set; }

		public int RealCheckValue { get; set; }
	}

	public Controller TipState;

	public Controller HasFillupSoldierTips;

	public Controller HasExectuingPlan;

	public GImage n92;

	public GImage n83;

	public GImage n82;

	public UI_MyTroopsSketchMap FormationSketchMap;

	public GImage n61;

	public GTextField OurCombat;

	public GTextField n47;

	public GGroup PowerMine;

	public GList BackupList;

	public UI_btn_ChangeArmyBtn ChangeArmyBtn;

	public UI_SoldierIconOnTouch DraggingIcon;

	public GTextField n73;

	public GTextField TeamCount;

	public GButton TeamCountBuff;

	public GTextField n76;

	public GImage n89;

	public GTextField SoldiersNum;

	public GImage n90;

	public GTextField Tip;

	public GButton Race;

	public GButton n81;

	public GImage n84;

	public GTextField n85;

	public GImage n87;

	public GTextField n88;

	public GTextField n91;

	public GButton RaceBuff;

	public GTextField FillupSoldierTips;

	public GImage n96;

	public UI_MyFormation MyFormation;

	public UI_com_ShipPlanMask ShipPlanMask;

	public const string URL = "ui://u6x0b1gnfdar3";

	public static string Name = "UI_ArmyPage";

	private GvGShipDetailModel _data;

	public ShipStateModel StateData;

	private UI_GvGShipDetailPanel _parentPanel;

	private bool _isInitRendered;

	private const int LegendItemsLimit = 2;

	private string _lastBackupString = string.Empty;

	private int _lastGetIslandStateTime;

	private const int GetIslandStateTimeInterval = 60;

	private const string TipText = "GvGShipDetail-ArmyPage-Tip-1";

	private const string TipText2 = "GvGShipDetail-ArmyPage-Tip-2";

	private const string AutoLoadDefaultFormationTip = "GvgDefaultFormationAutoLoadTip";

	private int _realCheckValue;

	private bool IsInit = false;

	private bool isMouseMoving;

	private GObject selectedIcon;

	private int? _raceSoldierCount;

	private int? _raceSoldierCountCheckTalentValue;

	private const string GvgMode3ShipGroupChanged = "GVG_MODE3_SHIP_GROUP_CHANGED";

	public bool CanFillUpUnits => StateData.CanFillUpUnits();

	private int RequiredMinRaceCount => RaceSoldierCountCheck - RaceSoldierCountCheckTalentValue;

	public bool PageActivated { get; set; }

	private int RaceSoldierCountCheck
	{
		get
		{
			int? raceSoldierCount = _raceSoldierCount;
			if (!raceSoldierCount.HasValue)
			{
				ShipConfigModel shipConfigModel = $"GVGSHIP_RACE{_data.ShipType}".ToConfiguration<ShipConfigModel>();
				_raceSoldierCount = Convert.ToInt32(shipConfigModel.Chk.Chk.Where((ChkCondition c) => c.Key == "ShipRaceSoldierCount").ToList()[0].Val);
			}
			return _raceSoldierCount.Value;
		}
	}

	private int RaceSoldierCountCheckTalentValue
	{
		get
		{
			int? raceSoldierCountCheckTalentValue = _raceSoldierCountCheckTalentValue;
			if (!raceSoldierCountCheckTalentValue.HasValue)
			{
				int num = 0;
				if (Singleton<WorldStateManager>.Instance.Data.Talents.HasTalent<种族兼容>())
				{
					num += TalentEvent.GetConfig<种族兼容>().val;
				}
				_raceSoldierCountCheckTalentValue = num;
			}
			return _raceSoldierCountCheckTalentValue.Value;
		}
	}

	public bool ShipGroupChanged => ConfigModified();

	public int PageIndex { get; set; }

	public static string GetURL()
	{
		return "ui://u6x0b1gnfdar3";
	}

	public static UI_ArmyPage CreateInstance()
	{
		return (UI_ArmyPage)(object)UIPackage.CreateObject("GvGShipDetail", "ArmyPage");
	}

	public static UI_ArmyPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ArmyPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnfdar3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Expected O, but got Unknown
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Expected O, but got Unknown
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Expected O, but got Unknown
		//IL_0461: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		TipState = ((GComponent)this).GetController("TipState");
		HasFillupSoldierTips = ((GComponent)this).GetController("HasFillupSoldierTips");
		HasExectuingPlan = ((GComponent)this).GetController("HasExectuingPlan");
		n92 = (GImage)((GComponent)this).GetChild("n92");
		n83 = (GImage)((GComponent)this).GetChild("n83");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		FormationSketchMap = (UI_MyTroopsSketchMap)(object)((GComponent)this).GetChild("FormationSketchMap");
		n61 = (GImage)((GComponent)this).GetChild("n61");
		OurCombat = (GTextField)((GComponent)this).GetChild("OurCombat");
		n47 = (GTextField)((GComponent)this).GetChild("n47");
		string id = "ui://u6x0b1gnfdar3".Replace("ui://", "") + "-" + ((GObject)n47).id;
		((GObject)n47).text = LanguagesManager.GetDesc(id);
		PowerMine = (GGroup)((GComponent)this).GetChild("PowerMine");
		BackupList = (GList)((GComponent)this).GetChild("BackupList");
		ChangeArmyBtn = (UI_btn_ChangeArmyBtn)(object)((GComponent)this).GetChild("ChangeArmyBtn");
		DraggingIcon = (UI_SoldierIconOnTouch)(object)((GComponent)this).GetChild("DraggingIcon");
		n73 = (GTextField)((GComponent)this).GetChild("n73");
		string id2 = "ui://u6x0b1gnfdar3".Replace("ui://", "") + "-" + ((GObject)n73).id;
		((GObject)n73).text = LanguagesManager.GetDesc(id2);
		TeamCount = (GTextField)((GComponent)this).GetChild("TeamCount");
		TeamCountBuff = (GButton)((GComponent)this).GetChild("TeamCountBuff");
		n76 = (GTextField)((GComponent)this).GetChild("n76");
		string id3 = "ui://u6x0b1gnfdar3".Replace("ui://", "") + "-" + ((GObject)n76).id;
		((GObject)n76).text = LanguagesManager.GetDesc(id3);
		n89 = (GImage)((GComponent)this).GetChild("n89");
		SoldiersNum = (GTextField)((GComponent)this).GetChild("SoldiersNum");
		n90 = (GImage)((GComponent)this).GetChild("n90");
		Tip = (GTextField)((GComponent)this).GetChild("Tip");
		Race = (GButton)((GComponent)this).GetChild("Race");
		n81 = (GButton)((GComponent)this).GetChild("n81");
		n84 = (GImage)((GComponent)this).GetChild("n84");
		n85 = (GTextField)((GComponent)this).GetChild("n85");
		string id4 = "ui://u6x0b1gnfdar3".Replace("ui://", "") + "-" + ((GObject)n85).id;
		((GObject)n85).text = LanguagesManager.GetDesc(id4);
		n87 = (GImage)((GComponent)this).GetChild("n87");
		n88 = (GTextField)((GComponent)this).GetChild("n88");
		string id5 = "ui://u6x0b1gnfdar3".Replace("ui://", "") + "-" + ((GObject)n88).id;
		((GObject)n88).text = LanguagesManager.GetDesc(id5);
		n91 = (GTextField)((GComponent)this).GetChild("n91");
		string id6 = "ui://u6x0b1gnfdar3".Replace("ui://", "") + "-" + ((GObject)n91).id;
		((GObject)n91).text = LanguagesManager.GetDesc(id6);
		RaceBuff = (GButton)((GComponent)this).GetChild("RaceBuff");
		FillupSoldierTips = (GTextField)((GComponent)this).GetChild("FillupSoldierTips");
		string id7 = "ui://u6x0b1gnfdar3".Replace("ui://", "") + "-" + ((GObject)FillupSoldierTips).id;
		((GObject)FillupSoldierTips).text = LanguagesManager.GetDesc(id7);
		n96 = (GImage)((GComponent)this).GetChild("n96");
		MyFormation = (UI_MyFormation)(object)((GComponent)this).GetChild("MyFormation");
		ShipPlanMask = (UI_com_ShipPlanMask)(object)((GComponent)this).GetChild("ShipPlanMask");
	}

	public void Init(GvGShipDetailModel detailData, UI_GvGShipDetailPanel parentPanel)
	{
		_data = detailData;
		_parentPanel = parentPanel;
		StateData = parentPanel.StateData;
		_isInitRendered = false;
		GetNewIslandState(FormationDataInit);
	}

	private void InitTeamCountBuff()
	{
		((GObject)TeamCount).text = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.GroupCountLimit}";
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetRealTimeGroupCountLimitModel
		{
			Req = new C2S_GetRealTimeGroupCountLimitModel.Request()
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			C2S_GetRealTimeGroupCountLimitModel.Response res = (C2S_GetRealTimeGroupCountLimitModel.Response)contextResponse.Resp;
			if (res.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(res.ErrorCode);
			}
			else
			{
				((GObject)TeamCountBuff).visible = res.Model.HasBuff;
				((GObject)TeamCountBuff).onClick.Set((EventCallback0)delegate
				{
					OnClickTeamCountBuff(TeamCountBuff, res.Model);
				});
			}
		});
	}

	public void RegisterUiEventListeners()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		MyFormation.SetOnChange(OnFormationChange);
		((GObject)ChangeArmyBtn).onClick.Set(new EventCallback0(SaveGroupConfig));
		((GObject)RaceBuff).onClick.Set(new EventCallback1(ShowGvGTalent10EfficiencyText));
		SharedMessenger.AddListener("ON_SHIP_LEGEND_ITEM_CHANGE", RefreshOnLegendItemsChanged);
		SharedMessenger.AddListener<int>("ON_GVG3_ISLAND_ACTION_SUCCESS", OnIslandActionSuccess);
		List<UI_SoldierFormation> allSlots = FormationSketchMap.GetAllSlots();
		int num = 0;
		foreach (UI_SoldierFormation item in allSlots)
		{
			SetSoldierIconDragable((GObject)(object)item.Icon);
			((GObject)item.Icon.iconFrame).data = num;
			((GObject)item.Icon.iconFrame).onClick.Set(new EventCallback1(OnClickSoldierItem));
			num++;
		}
	}

	public void UnregisterUiEventListeners()
	{
		MyFormation.ClearOnChange();
		((GObject)ChangeArmyBtn).onClick.Clear();
		((GObject)RaceBuff).onClick.Clear();
		SharedMessenger.RemoveListener("ON_SHIP_LEGEND_ITEM_CHANGE", RefreshOnLegendItemsChanged);
		SharedMessenger.RemoveListener<int>("ON_GVG3_ISLAND_ACTION_SUCCESS", OnIslandActionSuccess);
		List<UI_SoldierFormation> allSlots = FormationSketchMap.GetAllSlots();
		foreach (UI_SoldierFormation item in allSlots)
		{
			SetSoldierIconDragable((GObject)(object)item.Icon);
			((GObject)item.Icon.iconFrame).onClick.Clear();
		}
	}

	public void OnActivate()
	{
		PageActivated = true;
		GetNewIslandState(UpdatePage);
		if (!IsInit)
		{
			IsInit = true;
			InitTeamCountBuff();
		}
		void UpdatePage()
		{
			if (!_isInitRendered)
			{
				_isInitRendered = true;
				Update();
				MyFormation.CurFormationInit(StateData.FormationIdTemp);
				SetMaskVisible();
				TryAutoLoadDefaultFormation();
			}
		}
	}

	public void OnInactivate()
	{
		PageActivated = false;
	}

	public void OnDestroy()
	{
	}

	private void OnFormationChange(string fid)
	{
		if (StateData.FormationIdTemp != fid)
		{
			StateData.FormationIdTemp = fid;
			FormationSketchMap.SetOurPos(StateData.FormationIdTemp, StateData.CurrentUnitInfosTemp, this);
			((GObject)ChangeArmyBtn).enabled = ChangeArmyBtnEnabled();
			ChangeArmyBtn.Type.SetSelectedIndex(ChangeArmyBtnTypeIndex());
		}
	}

	private void OnIslandActionSuccess(int actionType)
	{
		if (actionType == 5)
		{
			StateData.SyncUnitInfoFromArchive();
			Update(forceRefresh: true);
		}
	}

	private void RefreshOnLegendItemsChanged()
	{
		StateData.SyncUnitInfoFromArchive();
		Update(forceRefresh: true);
	}

	private void OnClickSoldierItem(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GLoader val = (GLoader)context.sender;
		if (((GObject)((GObject)val).parent).parent.GetController("Type").selectedIndex != 2)
		{
			int num = (int)((GObject)val).data;
			if (!CanFillUpUnits)
			{
				ShowEnemyIntroduction(num);
			}
			else
			{
				OpenLegionPanel(num);
			}
		}
	}

	private void ShowEnemyIntroduction(int unitIndex)
	{
		GvGMode3UnitInfo soldier = StateData.CurrentUnitInfosTemp[unitIndex];
		if (!string.IsNullOrEmpty(soldier.SoldierId))
		{
			Singleton<WorldStateManager>.Instance.GetUnitDetailInfo(StateData.EntityId, soldier.SoldierId, OpenPanel);
		}
		void OpenPanel()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_EnemyIntroduction.Name, new Dictionary<string, object>
			{
				{ "SoldierId", soldier.SoldierId },
				{
					"EntityData",
					JsonHelper.ToObject<GameEntityData>(soldier.JsonGameEntityData)
				},
				{ "Num", soldier.PerTeamMemberCnt },
				{ "PotentialLevel", soldier.PotentialLevel },
				{ "RealTimeCombatPowerModel", soldier.RealTimeCombatPowerModel },
				{ "CombatPowerIncrement", soldier.RealTimeCombatPower },
				{ "AttackIncrement", soldier.RealTimeAttack },
				{ "DefenseIncrement", soldier.RealTimeDefense },
				{ "HealthIncrement", soldier.RealTimeHealth }
			});
		}
	}

	private void OnSelectedConfirm(GvGMode3SoldierSelectResult selected)
	{
		if (string.IsNullOrEmpty(selected.SoldierId))
		{
			StateData.CurrentUnitInfosTemp[selected.SlotIndex].SoldierId = string.Empty;
			UpdateUi();
			return;
		}
		if (StateData.CurrentUnitInfosTemp.All((GvGMode3UnitInfo u) => u.SoldierId != selected.SoldierId))
		{
			StateData.CurrentUnitInfosTemp[selected.SlotIndex].SoldierId = selected.SoldierId;
			UpdateUi();
			return;
		}
		int num = StateData.CurrentUnitInfosTemp.FindIndex((GvGMode3UnitInfo s) => s.SoldierId == selected.SoldierId);
		if (num != selected.SlotIndex)
		{
			GvGMode3UnitInfo value = StateData.CurrentUnitInfosTemp[num];
			StateData.CurrentUnitInfosTemp[num] = StateData.CurrentUnitInfosTemp[selected.SlotIndex];
			StateData.CurrentUnitInfosTemp[selected.SlotIndex] = value;
			UpdateUi();
		}
		void UpdateUi()
		{
			StateData.SyncUnitInfoFromArchive();
			Update();
		}
	}

	private void OnSelectedConfirm(GvGMode3SoldierSelected selected)
	{
		for (int i = ((!selected.IsGroup) ? 5 : 0); i < StateData.CurrentUnitInfosTemp.Count && (!selected.IsGroup || i < 5); i++)
		{
			if (selected.Selected.Count <= 0)
			{
				StateData.CurrentUnitInfosTemp[i].SoldierId = string.Empty;
				continue;
			}
			string soldierId = selected.Selected[0];
			StateData.CurrentUnitInfosTemp[i].SoldierId = soldierId;
			selected.Selected.RemoveAt(0);
		}
		UpdateUi();
		void UpdateUi()
		{
			StateData.SyncUnitInfoFromArchive();
			Update();
		}
	}

	private void OnClickTeamCountBuff(GButton teamCountBuff, RealTimeGroupCountLimitModel model)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		FairyGUITip.ShowTip((GObject)(object)teamCountBuff, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = model.GetText();
		});
	}

	private void GetNewIslandState(Action onFinished = null)
	{
		if (StateData.State == eShipState.NotLaunched)
		{
			onFinished?.Invoke();
			return;
		}
		if (GameController.Instance.GetServerTime() - _lastGetIslandStateTime < 60)
		{
			onFinished?.Invoke();
			return;
		}
		Singleton<WorldStateManager>.Instance.GetIslandsState(new List<int> { StateData.StayIslandId }, UpdateIslandsState);
		void UpdateIslandsState()
		{
			_lastGetIslandStateTime = (int)GameController.Instance.GetServerTime();
			onFinished?.Invoke();
		}
	}

	private void SetMaskVisible()
	{
		Controller hasExectuingPlan = HasExectuingPlan;
		ShipPlanStatusInfo planStatusInfo = StateData.PlanStatusInfo;
		hasExectuingPlan.SetSelectedIndex((planStatusInfo != null && planStatusInfo.PlanStatus == 3) ? 1 : 0);
	}

	private void Update(bool forceRefresh = false)
	{
		UpdateBackupSoldiersSlots(StateData.CurrentUnitInfosTemp, forceRefresh);
		FormationSketchMap.SetOurPos(StateData.FormationIdTemp, StateData.CurrentUnitInfosTemp, this);
		((GObject)OurCombat).text = $"{StateData.FormationPower}";
		((GObject)ChangeArmyBtn).enabled = ChangeArmyBtnEnabled();
		ChangeArmyBtn.Type.SetSelectedIndex(ChangeArmyBtnTypeIndex());
		((GObject)SoldiersNum).text = $"{StateData.GroupSoldiersCntSum}/{StateData.GroupSoldiersTotalSum}";
		HasFillupSoldierTips.selectedIndex = ((!CanFillUpUnits) ? 1 : 0);
		SetTipState();
		PlayFillUpTip();
	}

	private void PlayFillUpTip()
	{
		if (!_parentPanel.ShowNeedFillUpTip)
		{
			return;
		}
		_parentPanel.ShowNeedFillUpTip = false;
		List<UI_SoldierFormation> allSlots = FormationSketchMap.GetAllSlots();
		foreach (UI_SoldierFormation item in allSlots)
		{
			if (((GComponent)item).GetController("Type").selectedIndex != 2 && ((GObject)item.Icon.iconFrame).data != null)
			{
				int index = (int)((GObject)item.Icon.iconFrame).data;
				GvGMode3UnitInfo gvGMode3UnitInfo = StateData.CurrentUnitInfosTemp[index];
				if (gvGMode3UnitInfo.CurCnt < gvGMode3UnitInfo.Total)
				{
					item.Red.Play();
				}
			}
		}
	}

	private void OnBlockTouchBegin(EventContext context)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		if (_data.IsDraggable)
		{
			isMouseMoving = false;
			selectedIcon = null;
			GObject val = (GObject)context.sender;
			string sid = $"{val.data}";
			if (val.name.Contains("Icon") && UnitInfoHelper.CheckIsValidSoldier(sid))
			{
				selectedIcon = val;
				Vector2 val2 = default(Vector2);
				((Vector2)(ref val2))._002Ector(context.inputEvent.x, context.inputEvent.y);
				val2 = ((GObject)this).GlobalToLocal(val2);
				SoldierIconInit(val2, sid);
			}
		}
	}

	private void OnBlockTouchMove(EventContext context)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		if (_data.IsDraggable)
		{
			isMouseMoving = true;
			if (selectedIcon != null)
			{
				Vector2 val = default(Vector2);
				((Vector2)(ref val))._002Ector(context.inputEvent.x, context.inputEvent.y);
				val = ((GObject)this).GlobalToLocal(val);
				((GObject)DraggingIcon).xy = val;
				((GObject)DraggingIcon).alpha = 1f;
				((GObject)DraggingIcon).InvalidateBatchingState();
			}
		}
	}

	private void OnBlockTouchEnd(EventContext context)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		if (!_data.IsDraggable)
		{
			return;
		}
		SoldierIconFade();
		GObject val = (GObject)context.sender;
		if (!isMouseMoving || selectedIcon == null)
		{
			return;
		}
		string sourceId = $"{selectedIcon.data}";
		string targetId = $"{val.data}";
		if (val.name.Contains("Icon") && UnitInfoHelper.CheckIsValidSoldier(targetId) && !(sourceId == targetId))
		{
			selectedIcon.data = targetId;
			val.data = sourceId;
			int index = StateData.CurrentUnitInfosTemp.FindIndex((GvGMode3UnitInfo s) => s.SoldierId == sourceId);
			int index2 = StateData.CurrentUnitInfosTemp.FindIndex((GvGMode3UnitInfo s) => s.SoldierId == targetId);
			GvGMode3UnitInfo value = StateData.CurrentUnitInfosTemp[index];
			StateData.CurrentUnitInfosTemp[index] = StateData.CurrentUnitInfosTemp[index2];
			StateData.CurrentUnitInfosTemp[index2] = value;
			StateData.UpdateFormationPower();
			Update();
			isMouseMoving = false;
			selectedIcon = null;
		}
	}

	private void SoldierIconInit(Vector2 posVector2, string sid)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		string iconPath = UiHelper.GetIconPath(sid);
		if (!string.IsNullOrWhiteSpace(iconPath))
		{
			((GObject)((GComponent)DraggingIcon).GetChild("SoulStoneLevel").asCom).alpha = 1f;
			((GComponent)DraggingIcon).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(sid);
			((GObject)DraggingIcon).xy = posVector2;
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(sid);
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
			((GComponent)DraggingIcon).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			UiHelper.LoadSoldierIconFrameMaterial(((GComponent)DraggingIcon).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)DraggingIcon).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
			((GObject)DraggingIcon).InvalidateBatchingState();
		}
	}

	private void SoldierIconFade()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		((GObject)DraggingIcon).alpha = 0f;
		((GObject)DraggingIcon).xy = new Vector2(10000f, 10000f);
	}

	private void ShowArmyBuff(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		context.StopPropagation();
		GObject target = (GObject)context.sender;
		FairyGUITip.ShowTip(target, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
		{
			((GObject)popup.title).text = "GvGBackupLegionSlotBuff_MilitaryReclamation".ToLanguage();
		});
	}

	private void UpdateBackupSoldiersSlots(List<GvGMode3UnitInfo> currentUnitInfo, bool forceRefresh = false)
	{
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		List<GvGMode3UnitInfo> list = currentUnitInfo.SkipItems(5);
		string text = ToBackupString(list);
		if (text == _lastBackupString && !string.IsNullOrEmpty(text) && !forceRefresh)
		{
			return;
		}
		_lastBackupString = text;
		bool showNeedFillUpTip = _parentPanel.ShowNeedFillUpTip;
		bool flag = OuterTechHelper.IsO军垦支援扩展Active();
		for (int i = 0; i < BackupList.numItems; i++)
		{
			UI_SoldierBackup uI_SoldierBackup = (UI_SoldierBackup)(object)((GComponent)BackupList).GetChildAt(i);
			((GObject)uI_SoldierBackup.Icon).alpha = 1f;
			if (i <= list.Count - 1)
			{
				GvGMode3UnitInfo gvGMode3UnitInfo = list[i];
				string soldierId = gvGMode3UnitInfo.SoldierId;
				if (UnitInfoHelper.CheckIsValidSoldier(soldierId))
				{
					((GObject)uI_SoldierBackup.n7).visible = true;
					RenderSoldierItem(gvGMode3UnitInfo, uI_SoldierBackup.Icon);
					uI_SoldierBackup.Type.selectedIndex = 0;
					if (showNeedFillUpTip && gvGMode3UnitInfo.CurCnt < gvGMode3UnitInfo.Total)
					{
						uI_SoldierBackup.Red.Play();
					}
					((GObject)uI_SoldierBackup.num).visible = true;
					((GObject)uI_SoldierBackup.num).text = $"[color={UnitInfoHelper.GetSoldierNumTextColor(gvGMode3UnitInfo)}]{gvGMode3UnitInfo.CurCnt}[/color]/{gvGMode3UnitInfo.Total}";
					Soldier soldier = GameManagers.Instance.SoldierManager.Get(gvGMode3UnitInfo.SoldierId);
					((GObject)uI_SoldierBackup.SoldierName).text = soldier.Name;
					uI_SoldierBackup.SoldierName.color = Color32.op_Implicit(UiHelper.GetColorByLevel(gvGMode3UnitInfo.PotentialLevel));
				}
				else
				{
					((GObject)uI_SoldierBackup.n7).visible = false;
					((GObject)uI_SoldierBackup.num).visible = false;
					ClearSoldierItem(uI_SoldierBackup.Icon);
					uI_SoldierBackup.Type.selectedIndex = 1;
				}
				((GObject)uI_SoldierBackup.Icon).data = soldierId;
				if (i == list.Count - 1 && flag)
				{
					uI_SoldierBackup.hasOuterTech.selectedIndex = 1;
					((GObject)uI_SoldierBackup.BuffsTip).onClick.Set(new EventCallback1(ShowArmyBuff));
				}
			}
			else
			{
				((GObject)uI_SoldierBackup.n7).visible = false;
				((GObject)uI_SoldierBackup.num).visible = false;
				((GObject)uI_SoldierBackup).data = "";
				uI_SoldierBackup.Type.selectedIndex = 2;
			}
			((GObject)uI_SoldierBackup.Icon).touchable = true;
			SetSoldierIconDragable((GObject)(object)uI_SoldierBackup.Icon);
			((GObject)uI_SoldierBackup.Icon.iconFrame).data = i + 5;
			((GObject)uI_SoldierBackup.Icon.iconFrame).onClick.Set(new EventCallback1(OnClickSoldierItem));
		}
	}

	private void RenderSoldierItem(GvGMode3UnitInfo unitInfo, UI_soliderItem btn)
	{
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(unitInfo.SoldierId);
		((GObject)btn.SoulStoneLevel).alpha = 1f;
		string iconPath = UiHelper.GetIconPath(unitInfo.SoldierId);
		btn.icon.url = "ui://PublicResources/" + iconPath;
		((GObject)btn.lv).text = unitInfo.SoldierLevel.ToString();
		int num = (unitInfo.PotentialLevel + 2) / 2;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(unitInfo.PotentialLevel);
		btn.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		string text = $"kuang_round 3_lv{num}";
		btn.lvFrame.url = "ui://PublicResources/" + text;
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)btn.iconFrame).asLoader, unitInfo.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(btn.SoulStoneLevel, unitInfo.PotentialLevel, soldier.PotentialProgress);
		btn.Type.selectedIndex = 0;
		RenderLegendItems(unitInfo, (GButton)(object)btn);
	}

	private void RenderLegendItems(GvGMode3UnitInfo unitInfo, GButton button)
	{
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		GObject child = ((GComponent)button).GetChild("LegendItems");
		child.visible = true;
		((GComponent)button).GetController("Type").SetSelectedIndex(2);
		int[] array = unitInfo.EquippedItems ?? new int[2];
		for (int i = 0; i < 2; i++)
		{
			GObject child2 = ((GComponent)button).GetChild($"legendItem{i}");
			child2.visible = false;
			child2.scaleY = 0.35f;
			child2.scaleX = 0.35f;
		}
		UI_LegendItemsBack uI_LegendItemsBack = ((GComponent)button).GetChild("LegendItemsBack") as UI_LegendItemsBack;
		int num = 0;
		bool canFillUpUnits = CanFillUpUnits;
		for (int j = 0; j < array.Length && j < 2; j++)
		{
			GButton asButton = ((GComponent)button).GetChild($"legendItem{j}").asButton;
			GLoader asLoader = ((GComponent)asButton).GetChild("Icon").asLoader;
			bool soldierItemSlotState = LegendItemsHelper.GetSoldierItemSlotState(unitInfo.SoldierId, j);
			long num2 = array[j];
			if (!soldierItemSlotState || (!canFillUpUnits && num2 <= 0))
			{
				asLoader.url = "";
				((GComponent)asButton).GetChild("FrameIcon").asLoader.url = "";
				continue;
			}
			num++;
			((GObject)asButton).visible = true;
			((GObject)asButton).alpha = ((num2 <= 0) ? 0f : 1f);
			((GObject)button).touchable = true;
			((GObject)asButton).scaleY = 0.35f;
			((GObject)asButton).scaleX = 0.35f;
			UiHelper.RenderLegendItem(asButton, LegendItemsHelper.GetLegendItemUi(num2), UiHelper.TextColorType.Light, null, 2);
			((GObject)asButton).data = unitInfo;
			((GObject)asLoader).data = new SlotData
			{
				SlotIndex = j,
				LegendItemInstanceId = num2
			};
			((GObject)asButton).onClick.Set(new EventCallback1(OpenLegendItemDialog));
		}
		if (num == 0)
		{
			((GComponent)button).GetChild("LegendItems").visible = false;
			if (uI_LegendItemsBack != null)
			{
				uI_LegendItemsBack.Type.selectedIndex = 0;
			}
		}
		else if (uI_LegendItemsBack != null)
		{
			uI_LegendItemsBack.Type.selectedIndex = num;
		}
	}

	private void ClearSoldierItem(UI_soliderItem btn)
	{
		btn.icon.url = "";
		((GObject)btn.lv).text = "";
		btn.iconFrame.url = "";
		btn.lvFrame.url = "";
		((GObject)btn.SoulStoneLevel).alpha = 0f;
		((GComponent)btn).GetChild("LegendItems").visible = false;
		((UI_LegendItemsBack)(object)((GComponent)btn).GetChild("LegendItemsBack")).Type.selectedIndex = 0;
	}

	private void FormationDataInit()
	{
		if (CanFillUpUnits)
		{
			StateData.SyncUnitInfoFromArchive();
		}
		else
		{
			StateData.UpdateFormationPower();
		}
		MyFormation.Init();
	}

	private void SetTipState()
	{
		eRace shipType = (eRace)_data.ShipType;
		RenderHelper_RaceTypeIcon.RenderShipRaceType((GComponent)(object)Race, shipType);
		TipState.selectedIndex = ((!CheckRaceSoldierCountIsValid(out var checkResult)) ? 1 : 0);
		if (shipType == eRace.全种族)
		{
			((GObject)Tip).text = "GvGShipDetail-ArmyPage-Tip-2".ToLanguage();
		}
		else
		{
			((GObject)Tip).text = string.Format("GvGShipDetail-ArmyPage-Tip-1".ToLanguage(), new object[2] { checkResult.RaceSoldierCount, checkResult.RealCheckValue });
		}
		((GObject)RaceBuff).visible = Singleton<WorldStateManager>.Instance.Data.Talents.HasTalent<种族兼容>();
		((GObject)RaceBuff).data = TalentEvent.GetTalentDesc<种族兼容>();
	}

	private bool CheckRaceSoldierCountIsValid(out RaceSoldierCountCheckResult checkResult)
	{
		int num = StateData.RaceSoldierNum(_data.ShipType);
		int num2 = RaceSoldierCountCheck - RaceSoldierCountCheckTalentValue;
		checkResult = new RaceSoldierCountCheckResult
		{
			RaceSoldierCount = num,
			RealCheckValue = num2
		};
		return num >= num2;
	}

	private void ShowGvGTalent10EfficiencyText(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		GObject val = (GObject)context.sender;
		string value = val.data.ToString();
		Vector2 val2 = val.LocalToGlobal(Vector2.zero);
		val2 = ((GObject)this).GlobalToLocal(val2);
		((Vector2)(ref val2))._002Ector(val2.x - 80f, val2.y);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_ShowEfficiencyBuff.Name, new Dictionary<string, object>
		{
			{ "Text", value },
			{ "Pos", val2 }
		});
		context.StopPropagation();
	}

	private bool ChangeArmyBtnEnabled()
	{
		if (CanFillUpUnits)
		{
			return StateData.GroupSoldiersCntSum < StateData.GroupSoldiersTotalSum || ShipGroupChanged;
		}
		return ShipGroupChanged;
	}

	private int ChangeArmyBtnTypeIndex()
	{
		return (CanFillUpUnits && StateData.GroupSoldiersCntSum < StateData.GroupSoldiersTotalSum && !ShipGroupChanged) ? 1 : 0;
	}

	private void OpenLegionPanel(int slotIndex)
	{
		bool flag = slotIndex < 5;
		List<string> soldierFilter = GetSoldierFilter(flag);
		List<string> list = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.OtherShipsSoldierIds(StateData.ShipId);
		list.AddRange(flag ? StateData.BackupGroupInfoTemp : StateData.GroupInfoTemp);
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "Spine", null },
			{ "SelectedWithTick", soldierFilter },
			{
				"SelectedWithTickMaxCount",
				flag ? 5 : Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.BackupGroupSlotLimit
			},
			{ "OnlyUnlocked", 1 },
			{
				"SelectedWithTick_OnConfirm",
				new UICallbackParam<Action<GvGMode3SoldierSelected>>(OnSelectedConfirm)
			},
			{ "Style", "9" },
			{ "PvpSoldiersFilter", list },
			{ "RaceTypeGvGMode3", _data.ShipType },
			{ "RaceMinCount", RequiredMinRaceCount },
			{ "isCurGroup", flag },
			{
				"SelectedRaceLegionCnt",
				GetOtherSelectedRaceSoldierCnt(flag)
			}
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegionPanel.Name, parameters);
	}

	private void OpenLegendItemDialog(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GButton val = (GButton)context.sender;
		if (((GObject)val).data is GvGMode3UnitInfo gvGMode3UnitInfo)
		{
			SlotData slotData = (SlotData)((GComponent)val).GetChild("Icon").data;
			gvGMode3UnitInfo.ShowLegendItemInfo(StateData.EntityId, slotData.LegendItemInstanceId, CanFillUpUnits, slotData.SlotIndex);
		}
	}

	private void SaveGroupConfig()
	{
		if (!CheckGroupIsInvalid())
		{
			Singleton<WorldStateManager>.Instance.SaveShipGroupConfig(StateData);
		}
	}

	public void SaveGroupConfig(Action onFinished, Action revert = null)
	{
		if (CheckGroupIsInvalid())
		{
			revert?.Invoke();
		}
		else
		{
			Singleton<WorldStateManager>.Instance.SaveShipGroupConfig(StateData, onFinished);
		}
	}

	private bool CheckGroupIsInvalid()
	{
		return !StateData.CurrentUnitValid() || CheckRaceSoldierCountIsInvalid();
	}

	private bool CheckRaceSoldierCountIsInvalid()
	{
		if (CheckRaceSoldierCountIsValid(out var _))
		{
			return false;
		}
		"ErrorCode_-8205".ToShowLanguageTip();
		return true;
	}

	public void SetSoldierIconDragable(GObject btn)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		btn.onTouchBegin.Set(new EventCallback1(OnBlockTouchBegin));
		btn.onTouchMove.Set(new EventCallback1(OnBlockTouchMove));
		btn.onTouchEnd.Set(new EventCallback1(OnBlockTouchEnd));
	}

	private string ToBackupString(List<GvGMode3UnitInfo> backupUnitInfo)
	{
		string text = "";
		foreach (GvGMode3UnitInfo item in backupUnitInfo)
		{
			text = text + item.SoldierId + ",";
		}
		return text;
	}

	private List<string> GetSoldierFilter(bool isCurGroup)
	{
		List<string> list = new List<string>();
		List<string> list2 = (isCurGroup ? StateData.GroupInfoTemp : StateData.BackupGroupInfoTemp);
		foreach (string item in list2)
		{
			if (UnitInfoHelper.CheckIsValidSoldier(item))
			{
				list.Add(item);
			}
		}
		return list;
	}

	private int GetOtherSelectedRaceSoldierCnt(bool isCurGroup)
	{
		int num = 0;
		List<string> list = (isCurGroup ? StateData.BackupGroupInfoTemp : StateData.GroupInfoTemp);
		foreach (string item in list)
		{
			if (UnitInfoHelper.CheckIsValidSoldier(item))
			{
				num++;
			}
		}
		return num;
	}

	private async void TryAutoLoadDefaultFormation()
	{
		if (StateData.State == eShipState.NotLaunched || !IsArmyEmpty())
		{
			return;
		}
		GvGMode3LoadDefaultFormationResponse response = await GameController.Contexts.Service<INetworkService>().GvGMode3LoadDefaultFormation(_data.ShipType);
		if (response == null || response.ErrorCode != 0 || (!HasAnySoldier(response.Group) && !HasAnySoldier(response.BackupGroup)))
		{
			return;
		}
		if (!string.IsNullOrEmpty(response.FormationId))
		{
			StateData.FormationIdTemp = response.FormationId;
		}
		List<string> otherShipsSoldiers = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.OtherShipsSoldierIds(StateData.ShipId);
		int groupSlotIndex = 0;
		for (int i = 0; i < response.Group.Count; i++)
		{
			if (groupSlotIndex >= 5)
			{
				break;
			}
			string soldierId = response.Group[i];
			if (string.IsNullOrEmpty(soldierId))
			{
				groupSlotIndex++;
				continue;
			}
			if (otherShipsSoldiers.Contains(soldierId))
			{
				groupSlotIndex++;
				continue;
			}
			StateData.CurrentUnitInfosTemp[groupSlotIndex].SoldierId = soldierId;
			groupSlotIndex++;
		}
		int backupSlotLimit = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.BackupGroupSlotLimit;
		int backupSlotStart = 5;
		int backupSlotEnd = backupSlotStart + backupSlotLimit;
		if (backupSlotEnd > StateData.CurrentUnitInfosTemp.Count)
		{
			backupSlotEnd = StateData.CurrentUnitInfosTemp.Count;
		}
		int responseBackupIndex = 0;
		for (int j = backupSlotStart; j < backupSlotEnd; j++)
		{
			if (responseBackupIndex >= response.BackupGroup.Count)
			{
				break;
			}
			string soldierId2 = response.BackupGroup[responseBackupIndex];
			responseBackupIndex++;
			if (!string.IsNullOrEmpty(soldierId2) && !otherShipsSoldiers.Contains(soldierId2))
			{
				StateData.CurrentUnitInfosTemp[j].SoldierId = soldierId2;
			}
		}
		StateData.SyncUnitInfoFromArchive();
		Update();
		MyFormation.CurFormationInit(StateData.FormationIdTemp);
		"GvgDefaultFormationAutoLoadTip".ToShowLanguageTip();
	}

	private bool IsArmyEmpty()
	{
		for (int i = 0; i < StateData.CurrentUnitInfosTemp.Count; i++)
		{
			if (UnitInfoHelper.CheckIsValidSoldier(StateData.CurrentUnitInfosTemp[i].SoldierId))
			{
				return false;
			}
		}
		return true;
	}

	private static bool HasAnySoldier(List<string> soldierIds)
	{
		if (soldierIds == null)
		{
			return false;
		}
		for (int i = 0; i < soldierIds.Count; i++)
		{
			if (!string.IsNullOrEmpty(soldierIds[i]))
			{
				return true;
			}
		}
		return false;
	}

	public void OnShipStateChange()
	{
		if (CanFillUpUnits)
		{
			StateData.SyncUnitInfoFromArchive();
		}
		Update();
		MyFormation.CurFormationInit(StateData.FormationIdTemp);
	}

	public void ConfirmOperationOnChangePage(Action changePage, Action revert)
	{
		"GVG_MODE3_SHIP_GROUP_CHANGED".ToLanguage().ToConfirmPopup(ConfirmAction, CancelAction, (AlignType)0);
		void CancelAction()
		{
			StateData.RestoreGroupChanged(OnShipStateChange);
			changePage?.Invoke();
		}
		void ConfirmAction()
		{
			SaveGroupConfig(changePage, revert);
		}
	}

	public void ConfirmOperationOnClose(Action endAction)
	{
		"GVG_MODE3_SHIP_GROUP_CHANGED".ToLanguage().ToConfirmPopup(ConfirmAction, CancelAction, (AlignType)0);
		void CancelAction()
		{
			StateData.RestoreGroupChanged();
			endAction?.Invoke();
		}
		void ConfirmAction()
		{
			SaveGroupConfig(endAction);
		}
	}

	public bool ConfigModified()
	{
		return !UnitInfoHelper.UnitInfosAreEqual(StateData.CurrentUnitInfos, StateData.CurrentUnitInfosTemp) || StateData.FormationId != StateData.FormationIdTemp;
	}
}
