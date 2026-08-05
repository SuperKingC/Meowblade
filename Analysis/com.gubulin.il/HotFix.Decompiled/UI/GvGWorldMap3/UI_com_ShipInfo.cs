using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GvG3;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;

namespace UI.GvGWorldMap3;

public class UI_com_ShipInfo : GComponent
{
	public Controller IsSelected;

	public Controller SoldierNumNotEnough;

	public Controller OperationMode;

	public Controller Exception;

	public Controller State;

	public Controller IsDetectorActive;

	public GImage n17;

	public GImage n19;

	public GImage n44;

	public GImage n45;

	public GImage n46;

	public GGroup n47;

	public UI_btn_FocusShip FocusShip;

	public UI_btn_ReplenishSoldier FillupSoldier;

	public UI_btn_DetectResource DetectResourceBtn;

	public GGroup n34;

	public GImage n39;

	public UI_btn_02 n41;

	public GImage n24;

	public GGroup n37;

	public GImage n14;

	public GImage n18;

	public GGraph SpineLoader;

	public GList Soldiers;

	public GTextField SoldiersNum;

	public GTextField GoblinNum;

	public GImage n20;

	public GImage n22;

	public GGraph n15;

	public GImage n16;

	public GImage n11;

	public UI_com_ShipState ShipState;

	public GTextField PlaceName;

	public GButton n21;

	public GGroup n25;

	public GLoader Icon;

	public UI_btn_04 n48;

	public UI_btn_01 n40;

	public GTextField n26;

	public GTextField n27;

	public GTextField Time;

	public GGroup n38;

	public GTextField ShipName;

	public UI_ShipFoodProgress FoodStock;

	public GImage n32;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2bqhp1v";

	public static string Name = "UI_com_ShipInfo";

	public bool Rendered;

	private int SoulGuideCDTimestamp;

	public bool IsTouchable;

	public int Index;

	public static string GetURL()
	{
		return "ui://4eq8fgd2bqhp1v";
	}

	public static UI_com_ShipInfo CreateInstance()
	{
		return (UI_com_ShipInfo)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ShipInfo");
	}

	public static UI_com_ShipInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShipInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2bqhp1v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected O, but got Unknown
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Expected O, but got Unknown
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Expected O, but got Unknown
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Expected O, but got Unknown
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsSelected = ((GComponent)this).GetController("IsSelected");
		SoldierNumNotEnough = ((GComponent)this).GetController("SoldierNumNotEnough");
		OperationMode = ((GComponent)this).GetController("OperationMode");
		Exception = ((GComponent)this).GetController("Exception");
		State = ((GComponent)this).GetController("State");
		IsDetectorActive = ((GComponent)this).GetController("IsDetectorActive");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n47 = (GGroup)((GComponent)this).GetChild("n47");
		FocusShip = (UI_btn_FocusShip)(object)((GComponent)this).GetChild("FocusShip");
		FillupSoldier = (UI_btn_ReplenishSoldier)(object)((GComponent)this).GetChild("FillupSoldier");
		DetectResourceBtn = (UI_btn_DetectResource)(object)((GComponent)this).GetChild("DetectResourceBtn");
		n34 = (GGroup)((GComponent)this).GetChild("n34");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n41 = (UI_btn_02)(object)((GComponent)this).GetChild("n41");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n37 = (GGroup)((GComponent)this).GetChild("n37");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		Soldiers = (GList)((GComponent)this).GetChild("Soldiers");
		SoldiersNum = (GTextField)((GComponent)this).GetChild("SoldiersNum");
		GoblinNum = (GTextField)((GComponent)this).GetChild("GoblinNum");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n15 = (GGraph)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		ShipState = (UI_com_ShipState)(object)((GComponent)this).GetChild("ShipState");
		PlaceName = (GTextField)((GComponent)this).GetChild("PlaceName");
		n21 = (GButton)((GComponent)this).GetChild("n21");
		n25 = (GGroup)((GComponent)this).GetChild("n25");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n48 = (UI_btn_04)(object)((GComponent)this).GetChild("n48");
		n40 = (UI_btn_01)(object)((GComponent)this).GetChild("n40");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id = "ui://4eq8fgd2bqhp1v".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id);
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id2 = "ui://4eq8fgd2bqhp1v".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id2);
		Time = (GTextField)((GComponent)this).GetChild("Time");
		n38 = (GGroup)((GComponent)this).GetChild("n38");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		FoodStock = (UI_ShipFoodProgress)(object)((GComponent)this).GetChild("FoodStock");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RenderDetailInfo(GvG3ShipBriefInfoModel info, ShipStateModel stateInfo)
	{
		if (IsSelected.selectedIndex != 1 || Rendered)
		{
			return;
		}
		((GObject)GoblinNum).text = info.WorkersOnboardCount.ToString();
		Soldiers.RemoveChildrenToPool();
		if (stateInfo.GroupInfo != null)
		{
			foreach (GvGMode3UnitInfo item in stateInfo.GroupInfo)
			{
				if (!(Soldiers.AddItemFromPool() is UI_com_TroopsItem btn))
				{
					return;
				}
				RenderSoldier(item, btn);
			}
		}
		bool flag = Singleton<GvGTalent勘探强化Manager>.Instance.IsActive() && Singleton<GvGTalent勘探强化Manager>.Instance.IsLoaded();
		DetectResourceBtn.Render(flag, stateInfo.ShipId);
		IsDetectorActive.selectedIndex = (flag ? 1 : 0);
		FillupSoldier.IsAvailable.selectedIndex = (stateInfo.CanFillUpUnits() ? 1 : 0);
		((GObject)SoldiersNum).text = $"{stateInfo.GroupSoldiersCntSum}/{stateInfo.GroupSoldiersTotalSum}";
		SoldierNumNotEnough.selectedIndex = (stateInfo.SoldierNumNotEnough_Square() ? 1 : 0);
		int num = Singleton<WorldStateManager>.Instance.Data.RealTimeFoodOnBoardModel.Base;
		((GProgressBar)FoodStock).value = (double)stateInfo.FoodOnboardCount / (double)num * 100.0;
		((GObject)FoodStock.FoodStockValue).text = $"{stateInfo.FoodOnboardCount}/{num}";
	}

	public void RenderBaseInfo(GvG3ShipBriefInfoModel info, ShipStateModel stateInfo)
	{
		bool isEmpty;
		if (!Rendered)
		{
			isEmpty = info == null;
			SetShipInfo();
			SetShipState();
			SetUiState();
			ShowSoulGuideCoolingDown();
		}
		void SetShipInfo()
		{
			if (!isEmpty)
			{
				Icon.url = info?.ShipIcon;
				((GObject)ShipName).text = info?.ShipName;
				if (stateInfo != null && stateInfo.State != eShipState.NotLaunched && stateInfo.State != eShipState.Rebuilding && stateInfo.StayIslandId != 0)
				{
					((GObject)PlaceName).text = WorldMapConfigHelper.Configs.TryGetIsland(stateInfo.StayIslandId).Name;
					Exception.selectedIndex = ((!stateInfo.ShipIsExceptional()) ? 1 : 0);
				}
				OperationMode.selectedIndex = OperationMode.selectedIndex;
			}
		}
		void SetShipState()
		{
			if (!isEmpty && stateInfo != null)
			{
				switch (stateInfo.State)
				{
				case eShipState.NotLaunched:
				case eShipState.Stay:
				case eShipState.Rebuilding:
					ShipState.State.selectedIndex = 0;
					break;
				case eShipState.DuringFlight:
					ShipState.State.selectedIndex = 1;
					break;
				case eShipState.Fighting:
				case eShipState.SuppressRebellion:
					ShipState.State.selectedIndex = 2;
					break;
				case eShipState.Collecting:
					ShipState.State.selectedIndex = 3;
					break;
				case eShipState.FillUpSoldier:
					ShipState.State.selectedIndex = 4;
					break;
				}
			}
		}
		void SetUiState()
		{
			ShipStateModel shipStateModel = stateInfo;
			bool flag = shipStateModel != null && shipStateModel.State == eShipState.Rebuilding;
			GvG3ShipBriefInfoModel gvG3ShipBriefInfoModel = info;
			bool flag2 = gvG3ShipBriefInfoModel != null && gvG3ShipBriefInfoModel.ShipBuildState == eShipBuildState.Building;
			GvG3ShipBriefInfoModel gvG3ShipBriefInfoModel2 = info;
			bool flag3 = (gvG3ShipBriefInfoModel2 != null && gvG3ShipBriefInfoModel2.ShipBuildState == eShipBuildState.PendingAcceptance) || (info != null && info.IsPendingAcceptance);
			ShipStateModel shipStateModel2 = stateInfo;
			bool flag4 = shipStateModel2 != null && shipStateModel2.State == eShipState.NotLaunched;
			bool flag5 = stateInfo != null && stateInfo.IsSoulGuideCoolingDown;
			if (isEmpty)
			{
				State.SetSelectedIndex(5);
			}
			else if (flag3)
			{
				State.SetSelectedIndex(3);
			}
			else if (flag4)
			{
				State.SetSelectedIndex(4);
			}
			else if (flag5)
			{
				State.SetSelectedIndex(2);
			}
			else if (flag2 || flag)
			{
				State.SetSelectedIndex(1);
			}
			else
			{
				State.SetSelectedIndex(0);
			}
		}
		void ShowSoulGuideCoolingDown()
		{
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Expected O, but got Unknown
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Expected O, but got Unknown
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Expected O, but got Unknown
			if (!isEmpty && stateInfo != null)
			{
				if (stateInfo.IsSoulGuideCoolingDown)
				{
					SoulGuideCDTimestamp = stateInfo.SoulGuideCDTimestamp;
					UpdateSoulGuideCoolingDown(null);
					if (!Timers.inst.Exists(new TimerCallback(UpdateSoulGuideCoolingDown)))
					{
						Timers.inst.Add(1f, 0, new TimerCallback(UpdateSoulGuideCoolingDown));
					}
				}
				else if (Timers.inst.Exists(new TimerCallback(UpdateSoulGuideCoolingDown)))
				{
					Timers.inst.Remove(new TimerCallback(UpdateSoulGuideCoolingDown));
				}
			}
		}
	}

	public void SummaryModeOnClick(Action onBtnClicked = null, Action openOverview = null)
	{
		if (IsSelected.selectedIndex == 0 && State.selectedIndex != 2 && State.selectedIndex != 1)
		{
			if (State.selectedIndex == 0)
			{
				onBtnClicked?.Invoke();
			}
			else if (State.selectedIndex == 3 || State.selectedIndex == 4 || State.selectedIndex == 5)
			{
				openOverview?.Invoke();
			}
		}
	}

	private void UpdateSoulGuideCoolingDown(object param)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		int num = (int)GameController.Instance.GetServerTime();
		int num2 = SoulGuideCDTimestamp - num;
		if (num2 <= 0)
		{
			num2 = 0;
			Timers.inst.Remove(new TimerCallback(UpdateSoulGuideCoolingDown));
		}
		((GObject)Time).text = UiHelper.ParseTime(num2);
	}

	private void RenderSoldier(GvGMode3UnitInfo soldierInfo, UI_com_TroopsItem btn)
	{
		if (string.IsNullOrEmpty(soldierInfo.SoldierId))
		{
			btn.Type.selectedIndex = 0;
			return;
		}
		btn.Type.selectedIndex = 2;
		btn.IconLoader.IconLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldierInfo.SoldierId);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(btn.SoulStoneLevel, soldierInfo.PotentialLevel, new List<int>());
		btn.FrameLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorderSoldier(soldierInfo.PotentialLevel);
		UiHelper.LoadSoldierIconFrameMaterial(btn.FrameLoader, soldierInfo.PotentialLevel);
		((GObject)btn.Amount_t).text = string.Empty;
		((GObject)btn.RedDot).visible = soldierInfo.SoldierNumberNotEnough;
	}
}
