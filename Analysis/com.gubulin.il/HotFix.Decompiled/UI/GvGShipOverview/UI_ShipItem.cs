using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;

namespace UI.GvGShipOverview;

public class UI_ShipItem : GButton
{
	public Controller State;

	public Controller IsEditing;

	public Controller DraggablePos;

	public Controller ShipStatus;

	public Controller WarningStatus;

	public Controller CanRebuild;

	public Controller CanRemove;

	public Controller shipBuildType;

	public GImage n106;

	public GImage NoContentBack2;

	public UI_ShipDetailBtn ShipDetailBtn;

	public UI_BuildShipBtn BuildShipBtn;

	public UI_LockBtn LockBtn;

	public GGroup NoEditModeBtn;

	public GImage n161;

	public GImage n160;

	public GImage n183;

	public GGroup n188;

	public GImage n111;

	public GTextField ShipName;

	public UI_ChangeNameBtn ChangeNameBtn;

	public GGroup NameTitleGroup;

	public GImage n168;

	public GImage n171;

	public GImage n172;

	public UI_GearRotation n170;

	public UI_GearRotation n169;

	public GTextField StateTitle1;

	public GTextField StateTitle2;

	public GTextField StateTitle3;

	public GGroup StateTitleGroup;

	public UI_RaceTypeSmall Race;

	public GGraph SpineLoader;

	public GImage n162;

	public GGraph WorkerSpine1;

	public GGraph WorkerSpine2;

	public GGraph WorkerSpine3;

	public GGraph NoEditModeBack;

	public UI_IconInfo WorkersInfo;

	public UI_IconInfo FoodInfo;

	public UI_IconInfo SoldiersInfo;

	public GGroup ShipInfo;

	public UI_IconInfo ShipStatusInfo;

	public UI_IconInfo2 BuildTimeInfo;

	public UI_AcceptBtn AcceptBtn;

	public UI_Warning Warning;

	public UI_LiftoffBtn LiftoffBtn;

	public GGroup n174;

	public GGroup NoEditMode;

	public GImage EditModeBack2;

	public GImage EditModeBack;

	public GGraph EditPanelBack;

	public GImage n189;

	public GImage n167;

	public GImage n121;

	public UI_CantRemoveTip CantRemoveTip;

	public GImage n122;

	public GTextField Index;

	public UI_ToLeftBtn ToLeft;

	public UI_ToRightBtn ToRight;

	public UI_DeleteBrn DeletBtn;

	public UI_btn_Rebuild Rebuild;

	public GGroup EditPanel;

	public GGroup EditMode;

	public GImage n192;

	public GLoader tipBtn1;

	public GLoader tipBtn2;

	public GGroup ContentGroup;

	public UI_IconInfo2 SoulGuideInfo;

	public GImage n184;

	public GTextField n185;

	public GGroup n186;

	public const string URL = "ui://7ymaonxtda2123";

	public static string Name = "UI_ShipItem";

	private int SoulGuideCDTimestamp;

	public static string GetURL()
	{
		return "ui://7ymaonxtda2123";
	}

	public static UI_ShipItem CreateInstance()
	{
		return (UI_ShipItem)(object)UIPackage.CreateObject("GvGShipOverview", "ShipItem");
	}

	public static UI_ShipItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ShipItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtda2123", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Expected O, but got Unknown
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Expected O, but got Unknown
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Expected O, but got Unknown
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Expected O, but got Unknown
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Expected O, but got Unknown
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Expected O, but got Unknown
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Expected O, but got Unknown
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Expected O, but got Unknown
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Expected O, but got Unknown
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Expected O, but got Unknown
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Expected O, but got Unknown
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0537: Expected O, but got Unknown
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Expected O, but got Unknown
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Expected O, but got Unknown
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected O, but got Unknown
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_058f: Expected O, but got Unknown
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Expected O, but got Unknown
		//IL_05c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d1: Expected O, but got Unknown
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Expected O, but got Unknown
		//IL_068a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0694: Expected O, but got Unknown
		//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06aa: Expected O, but got Unknown
		//IL_06b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c0: Expected O, but got Unknown
		//IL_06cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d6: Expected O, but got Unknown
		//IL_06e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ec: Expected O, but got Unknown
		//IL_070e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0718: Expected O, but got Unknown
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_072e: Expected O, but got Unknown
		//IL_0779: Unknown result type (might be due to invalid IL or missing references)
		//IL_0783: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		IsEditing = ((GComponent)this).GetController("IsEditing");
		DraggablePos = ((GComponent)this).GetController("DraggablePos");
		ShipStatus = ((GComponent)this).GetController("ShipStatus");
		WarningStatus = ((GComponent)this).GetController("WarningStatus");
		CanRebuild = ((GComponent)this).GetController("CanRebuild");
		CanRemove = ((GComponent)this).GetController("CanRemove");
		shipBuildType = ((GComponent)this).GetController("shipBuildType");
		n106 = (GImage)((GComponent)this).GetChild("n106");
		NoContentBack2 = (GImage)((GComponent)this).GetChild("NoContentBack2");
		ShipDetailBtn = (UI_ShipDetailBtn)(object)((GComponent)this).GetChild("ShipDetailBtn");
		BuildShipBtn = (UI_BuildShipBtn)(object)((GComponent)this).GetChild("BuildShipBtn");
		LockBtn = (UI_LockBtn)(object)((GComponent)this).GetChild("LockBtn");
		NoEditModeBtn = (GGroup)((GComponent)this).GetChild("NoEditModeBtn");
		n161 = (GImage)((GComponent)this).GetChild("n161");
		n160 = (GImage)((GComponent)this).GetChild("n160");
		n183 = (GImage)((GComponent)this).GetChild("n183");
		n188 = (GGroup)((GComponent)this).GetChild("n188");
		n111 = (GImage)((GComponent)this).GetChild("n111");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		string id = "ui://7ymaonxtda2123".Replace("ui://", "") + "-" + ((GObject)ShipName).id;
		((GObject)ShipName).text = LanguagesManager.GetDesc(id);
		ChangeNameBtn = (UI_ChangeNameBtn)(object)((GComponent)this).GetChild("ChangeNameBtn");
		NameTitleGroup = (GGroup)((GComponent)this).GetChild("NameTitleGroup");
		n168 = (GImage)((GComponent)this).GetChild("n168");
		n171 = (GImage)((GComponent)this).GetChild("n171");
		n172 = (GImage)((GComponent)this).GetChild("n172");
		n170 = (UI_GearRotation)(object)((GComponent)this).GetChild("n170");
		n169 = (UI_GearRotation)(object)((GComponent)this).GetChild("n169");
		StateTitle1 = (GTextField)((GComponent)this).GetChild("StateTitle1");
		string id2 = "ui://7ymaonxtda2123".Replace("ui://", "") + "-" + ((GObject)StateTitle1).id;
		((GObject)StateTitle1).text = LanguagesManager.GetDesc(id2);
		StateTitle2 = (GTextField)((GComponent)this).GetChild("StateTitle2");
		string id3 = "ui://7ymaonxtda2123".Replace("ui://", "") + "-" + ((GObject)StateTitle2).id;
		((GObject)StateTitle2).text = LanguagesManager.GetDesc(id3);
		StateTitle3 = (GTextField)((GComponent)this).GetChild("StateTitle3");
		string id4 = "ui://7ymaonxtda2123".Replace("ui://", "") + "-" + ((GObject)StateTitle3).id;
		((GObject)StateTitle3).text = LanguagesManager.GetDesc(id4);
		StateTitleGroup = (GGroup)((GComponent)this).GetChild("StateTitleGroup");
		Race = (UI_RaceTypeSmall)(object)((GComponent)this).GetChild("Race");
		SpineLoader = (GGraph)((GComponent)this).GetChild("SpineLoader");
		n162 = (GImage)((GComponent)this).GetChild("n162");
		WorkerSpine1 = (GGraph)((GComponent)this).GetChild("WorkerSpine1");
		WorkerSpine2 = (GGraph)((GComponent)this).GetChild("WorkerSpine2");
		WorkerSpine3 = (GGraph)((GComponent)this).GetChild("WorkerSpine3");
		NoEditModeBack = (GGraph)((GComponent)this).GetChild("NoEditModeBack");
		WorkersInfo = (UI_IconInfo)(object)((GComponent)this).GetChild("WorkersInfo");
		FoodInfo = (UI_IconInfo)(object)((GComponent)this).GetChild("FoodInfo");
		SoldiersInfo = (UI_IconInfo)(object)((GComponent)this).GetChild("SoldiersInfo");
		ShipInfo = (GGroup)((GComponent)this).GetChild("ShipInfo");
		ShipStatusInfo = (UI_IconInfo)(object)((GComponent)this).GetChild("ShipStatusInfo");
		BuildTimeInfo = (UI_IconInfo2)(object)((GComponent)this).GetChild("BuildTimeInfo");
		AcceptBtn = (UI_AcceptBtn)(object)((GComponent)this).GetChild("AcceptBtn");
		Warning = (UI_Warning)(object)((GComponent)this).GetChild("Warning");
		LiftoffBtn = (UI_LiftoffBtn)(object)((GComponent)this).GetChild("LiftoffBtn");
		n174 = (GGroup)((GComponent)this).GetChild("n174");
		NoEditMode = (GGroup)((GComponent)this).GetChild("NoEditMode");
		EditModeBack2 = (GImage)((GComponent)this).GetChild("EditModeBack2");
		EditModeBack = (GImage)((GComponent)this).GetChild("EditModeBack");
		EditPanelBack = (GGraph)((GComponent)this).GetChild("EditPanelBack");
		n189 = (GImage)((GComponent)this).GetChild("n189");
		n167 = (GImage)((GComponent)this).GetChild("n167");
		n121 = (GImage)((GComponent)this).GetChild("n121");
		CantRemoveTip = (UI_CantRemoveTip)(object)((GComponent)this).GetChild("CantRemoveTip");
		n122 = (GImage)((GComponent)this).GetChild("n122");
		Index = (GTextField)((GComponent)this).GetChild("Index");
		string id5 = "ui://7ymaonxtda2123".Replace("ui://", "") + "-" + ((GObject)Index).id;
		((GObject)Index).text = LanguagesManager.GetDesc(id5);
		ToLeft = (UI_ToLeftBtn)(object)((GComponent)this).GetChild("ToLeft");
		ToRight = (UI_ToRightBtn)(object)((GComponent)this).GetChild("ToRight");
		DeletBtn = (UI_DeleteBrn)(object)((GComponent)this).GetChild("DeletBtn");
		Rebuild = (UI_btn_Rebuild)(object)((GComponent)this).GetChild("Rebuild");
		EditPanel = (GGroup)((GComponent)this).GetChild("EditPanel");
		EditMode = (GGroup)((GComponent)this).GetChild("EditMode");
		n192 = (GImage)((GComponent)this).GetChild("n192");
		tipBtn1 = (GLoader)((GComponent)this).GetChild("tipBtn1");
		tipBtn2 = (GLoader)((GComponent)this).GetChild("tipBtn2");
		ContentGroup = (GGroup)((GComponent)this).GetChild("ContentGroup");
		SoulGuideInfo = (UI_IconInfo2)(object)((GComponent)this).GetChild("SoulGuideInfo");
		n184 = (GImage)((GComponent)this).GetChild("n184");
		n185 = (GTextField)((GComponent)this).GetChild("n185");
		string id6 = "ui://7ymaonxtda2123".Replace("ui://", "") + "-" + ((GObject)n185).id;
		((GObject)n185).text = LanguagesManager.GetDesc(id6);
		n186 = (GGroup)((GComponent)this).GetChild("n186");
	}

	public void SetShipStatus(GvGShipDetailModel detailModel)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		if (Timers.inst.Exists(new TimerCallback(UpdateSoulGuideCoolingDown)))
		{
			Timers.inst.Remove(new TimerCallback(UpdateSoulGuideCoolingDown));
		}
		if (detailModel.UIShipState == eUIShipState.NotLaunched)
		{
			ShipStatus.selectedIndex = 0;
			return;
		}
		if (detailModel.ShipState != null && detailModel.ShipState.IsSoulGuideCoolingDown)
		{
			ShipStatus.selectedIndex = 6;
			SoulGuideCDTimestamp = detailModel.ShipState.SoulGuideCDTimestamp;
			UpdateSoulGuideCoolingDown(null);
			if (!Timers.inst.Exists(new TimerCallback(UpdateSoulGuideCoolingDown)))
			{
				Timers.inst.Add(1f, 0, new TimerCallback(UpdateSoulGuideCoolingDown));
			}
			return;
		}
		ShipStatus.selectedIndex = (int)detailModel.UIShipState;
		if (detailModel.UIShipState == eUIShipState.Stay)
		{
			int ourFlagShipStayIslandId = Singleton<WorldStateManager>.Instance.Data.OurFlagShipStayIslandId;
			IslandStateModel islandStateModel = Singleton<WorldStateManager>.Instance.TryGetIsland(detailModel.StayIslandId);
			eIslandType type = WorldMapConfigHelper.Configs.TryGetIsland(detailModel.StayIslandId).Props.Type;
			if (islandStateModel.CampId != detailModel.CampId || (type != eIslandType.MainMoon && type != eIslandType.Moon && detailModel.StayIslandId != ourFlagShipStayIslandId))
			{
				ShipStatus.selectedIndex = 5;
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
		((GObject)SoulGuideInfo.Info).text = UiHelper.ParseTime(num2);
	}
}
