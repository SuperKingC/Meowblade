using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Utils;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;
using UI.AddCredit;
using UI.GiftBag;
using UI.LegendItemInfo;
using UI.LegendItems;
using UI.PublicResources;
using UI.SoldierCultivate;
using UI.Tips;
using UnityEngine;

namespace UI.LegendItemCultivation;

public class UI_LegendItemCultivationPanel : GComponent, IUiController
{
	private enum EntryTextType
	{
		SubEntry,
		FxEntry,
		Suit
	}

	private class FxDescItem
	{
		public string Desc;

		public bool IsBlueprintFx;

		public EntryTextType Type;
	}

	public Controller PageController;

	public GLoader background;

	public UI_Title Title;

	public GButton BackBtn;

	public GComponent addCouponBtn;

	public GComponent addDiamondBtn;

	public GComponent addTicketBtn;

	public GComponent addReforgeTicketBtn;

	public GComponent addChangeTicketBtn;

	public GComponent addSwapTicketBtn;

	public GImage n3;

	public GGroup backLeft;

	public GImage n68;

	public GImage n98;

	public GImage n99;

	public GGroup backRight;

	public GImage n101;

	public GImage n102;

	public GImage n103;

	public UI_LegendItemTitle LegendItemName;

	public GButton SoldierIcon;

	public GComponent Stars;

	public GLoader LegendItemIcon;

	public GGraph CombatPowerSfxBack;

	public GGraph CombatPowerSpine;

	public GTextField n51;

	public GTextField CombatPower;

	public GImage n85;

	public GGroup Bottomleftcorner;

	public UI_activate preview;

	public UI_SwitchBtn SwitchBtn;

	public GTextField introduction;

	public GGroup Content;

	public GImage InfoBtnDark;

	public GImage PotentialBtnDark;

	public GImage DegreeElevationBtnDark;

	public GImage SoulStoneBtnDark;

	public GImage ReplaceBtnDark;

	public GGraph popupMask;

	public UI_Details Details;

	public UI_Refine Refine;

	public UI_Rehandle Rehandle;

	public UI_Intensify Intensify;

	public UI_Replace Replace;

	public GImage InfoBtnLight;

	public GImage PotentialBtnLight;

	public GImage SoulStoneLight;

	public GImage ReplaceBtnLight;

	public GImage DegreeElevationBtnLight;

	public UI_InfoBtn InfoBtn;

	public UI_InfoBtn PotentialBtn;

	public UI_InfoBtn DegreeElevationBtn;

	public UI_InfoBtn SoulStoneBtn;

	public UI_InfoBtn ReplaceBtn;

	public GButton TurnPageLeftBtn;

	public GButton TurnPageRightBtn;

	public UI_LegendItemReplaceAnim LegendItemReplaceAnim;

	public const string URL = "ui://b9wlonaqtpmt0";

	public static string Name = "UI_LegendItemCultivationPanel";

	private List<string> subEntryTexts = new List<string>();

	private List<FxDescItem> fxSuitEntryTexts = new List<FxDescItem>();

	private bool _hasAlterFx;

	private bool needUpdateRehandleBtn = false;

	private int needUpdateBtnIndex = -1;

	private static List<LegendItemUi> currentSelectItems = new List<LegendItemUi>();

	private List<LegendItemUi> totalSelectItems = new List<LegendItemUi>();

	private int configMaxLevel;

	private LegendItemEnhancementConfig maxLeveLegendItemEnhancementConfig = null;

	private List<string> textureList = new List<string>();

	private List<LegendItemUi> legendItems = new List<LegendItemUi>();

	private int curIndex;

	public static LegendItemUi CurLegendItemData;

	public UI_SoldierPromotionPanel SoldierPromotionPanel;

	private static int MaxEnhanceCostNum = 8;

	private string lockTicketId;

	private string reforgeTicketId = "I40213";

	private string changeTicketId = "I40214";

	private string swapTicketId = "I40095";

	public void SetButtonTitle()
	{
		((GObject)InfoBtn).asButton.title = LanguagesManager.GetDesc("LegendItemCultivation-LegendItemCultivationPanel-InfoBtn-title");
		((GObject)PotentialBtn).asButton.title = LanguagesManager.GetDesc("LegendItemCultivation-LegendItemCultivationPanel-PotentialBtn-title");
		((GObject)DegreeElevationBtn).asButton.title = LanguagesManager.GetDesc("LegendItemCultivation-LegendItemCultivationPanel-DegreeElevationBtn-title");
		((GObject)SoulStoneBtn).asButton.title = LanguagesManager.GetDesc("LegendItemCultivation-LegendItemCultivationPanel-SoulStoneBtn-title");
	}

	public static string GetURL()
	{
		return "ui://b9wlonaqtpmt0";
	}

	public static UI_LegendItemCultivationPanel CreateInstance()
	{
		return (UI_LegendItemCultivationPanel)(object)UIPackage.CreateObject("LegendItemCultivation", "LegendItemCultivationPanel");
	}

	public static UI_LegendItemCultivationPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemCultivationPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqtpmt0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Expected O, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected O, but got Unknown
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected O, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Expected O, but got Unknown
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Expected O, but got Unknown
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Expected O, but got Unknown
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Expected O, but got Unknown
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Expected O, but got Unknown
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Expected O, but got Unknown
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		background = (GLoader)((GComponent)this).GetChild("background");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		addTicketBtn = (GComponent)((GComponent)this).GetChild("addTicketBtn");
		addReforgeTicketBtn = (GComponent)((GComponent)this).GetChild("addReforgeTicketBtn");
		addChangeTicketBtn = (GComponent)((GComponent)this).GetChild("addChangeTicketBtn");
		addSwapTicketBtn = (GComponent)((GComponent)this).GetChild("addSwapTicketBtn");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		backLeft = (GGroup)((GComponent)this).GetChild("backLeft");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		n98 = (GImage)((GComponent)this).GetChild("n98");
		n99 = (GImage)((GComponent)this).GetChild("n99");
		backRight = (GGroup)((GComponent)this).GetChild("backRight");
		n101 = (GImage)((GComponent)this).GetChild("n101");
		n102 = (GImage)((GComponent)this).GetChild("n102");
		n103 = (GImage)((GComponent)this).GetChild("n103");
		LegendItemName = (UI_LegendItemTitle)(object)((GComponent)this).GetChild("LegendItemName");
		SoldierIcon = (GButton)((GComponent)this).GetChild("SoldierIcon");
		Stars = (GComponent)((GComponent)this).GetChild("Stars");
		LegendItemIcon = (GLoader)((GComponent)this).GetChild("LegendItemIcon");
		CombatPowerSfxBack = (GGraph)((GComponent)this).GetChild("CombatPowerSfxBack");
		CombatPowerSpine = (GGraph)((GComponent)this).GetChild("CombatPowerSpine");
		n51 = (GTextField)((GComponent)this).GetChild("n51");
		string id = "ui://b9wlonaqtpmt0".Replace("ui://", "") + "-" + ((GObject)n51).id;
		((GObject)n51).text = LanguagesManager.GetDesc(id);
		CombatPower = (GTextField)((GComponent)this).GetChild("CombatPower");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		Bottomleftcorner = (GGroup)((GComponent)this).GetChild("Bottomleftcorner");
		preview = (UI_activate)(object)((GComponent)this).GetChild("preview");
		SwitchBtn = (UI_SwitchBtn)(object)((GComponent)this).GetChild("SwitchBtn");
		introduction = (GTextField)((GComponent)this).GetChild("introduction");
		string id2 = "ui://b9wlonaqtpmt0".Replace("ui://", "") + "-" + ((GObject)introduction).id;
		((GObject)introduction).text = LanguagesManager.GetDesc(id2);
		Content = (GGroup)((GComponent)this).GetChild("Content");
		InfoBtnDark = (GImage)((GComponent)this).GetChild("InfoBtnDark");
		PotentialBtnDark = (GImage)((GComponent)this).GetChild("PotentialBtnDark");
		DegreeElevationBtnDark = (GImage)((GComponent)this).GetChild("DegreeElevationBtnDark");
		SoulStoneBtnDark = (GImage)((GComponent)this).GetChild("SoulStoneBtnDark");
		ReplaceBtnDark = (GImage)((GComponent)this).GetChild("ReplaceBtnDark");
		popupMask = (GGraph)((GComponent)this).GetChild("popupMask");
		Details = (UI_Details)(object)((GComponent)this).GetChild("Details");
		Refine = (UI_Refine)(object)((GComponent)this).GetChild("Refine");
		Rehandle = (UI_Rehandle)(object)((GComponent)this).GetChild("Rehandle");
		Intensify = (UI_Intensify)(object)((GComponent)this).GetChild("Intensify");
		Replace = (UI_Replace)(object)((GComponent)this).GetChild("Replace");
		InfoBtnLight = (GImage)((GComponent)this).GetChild("InfoBtnLight");
		PotentialBtnLight = (GImage)((GComponent)this).GetChild("PotentialBtnLight");
		SoulStoneLight = (GImage)((GComponent)this).GetChild("SoulStoneLight");
		ReplaceBtnLight = (GImage)((GComponent)this).GetChild("ReplaceBtnLight");
		DegreeElevationBtnLight = (GImage)((GComponent)this).GetChild("DegreeElevationBtnLight");
		InfoBtn = (UI_InfoBtn)(object)((GComponent)this).GetChild("InfoBtn");
		PotentialBtn = (UI_InfoBtn)(object)((GComponent)this).GetChild("PotentialBtn");
		DegreeElevationBtn = (UI_InfoBtn)(object)((GComponent)this).GetChild("DegreeElevationBtn");
		SoulStoneBtn = (UI_InfoBtn)(object)((GComponent)this).GetChild("SoulStoneBtn");
		ReplaceBtn = (UI_InfoBtn)(object)((GComponent)this).GetChild("ReplaceBtn");
		TurnPageLeftBtn = (GButton)((GComponent)this).GetChild("TurnPageLeftBtn");
		TurnPageRightBtn = (GButton)((GComponent)this).GetChild("TurnPageRightBtn");
		LegendItemReplaceAnim = (UI_LegendItemReplaceAnim)(object)((GComponent)this).GetChild("LegendItemReplaceAnim");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		MaxEnhanceCostNum = 8;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 1;
		DataInit();
		if (parameters != null && parameters.TryGetValue("LegendItem", out var value))
		{
			LegendItemUi item = (LegendItemUi)value;
			curIndex = legendItems.IndexOf(item);
			Details.popupMask.Init(Details);
			LegendItemName.LegendItemName.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
			CurLegendItemData = legendItems[curIndex];
			SetPageBtnStatus();
			SetBuildingName();
			UpdateTabDirty();
			SetLockTicketId();
			SetChangeEntryTicketId();
			SetReforgeTicketId();
			RenderLegendItemsFilters();
			Replace.Init();
			((GComponent)(object)ReplaceBtn).BindText("ui://b9wlonaqtpmt0");
			SetSwapTicketId();
			UpdateReplaceBtnVisible();
		}
		else
		{
			End();
		}
	}

	public void OnShow()
	{
		Intensify.SetButtonTitle();
		Rehandle.SetButtonTitle();
		SetButtonTitle();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected O, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected O, but got Unknown
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Expected O, but got Unknown
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Expected O, but got Unknown
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)preview).onClick.Add(new EventCallback1(ShowSoldierSpine));
		((GObject)TurnPageLeftBtn).data = -1;
		((GObject)TurnPageRightBtn).data = 1;
		((GObject)TurnPageLeftBtn).onClick.Add(new EventCallback1(PageTurning));
		((GObject)TurnPageRightBtn).onClick.Add(new EventCallback1(PageTurning));
		((GObject)SwitchBtn).onClick.Add(new EventCallback0(SwitchBtnClick));
		((GObject)Details.Atrributes.primeAttribute.SwitchBtn).onClick.Add(new EventCallback0(OnClickSwitchMainAtt));
		((GObject)Rehandle.Rehandle).onClick.Add(new EventCallback0(RehandleClick));
		((GObject)Rehandle.yesBtn).onClick.Add(new EventCallback0(ConfirmRehandle));
		((GObject)Rehandle.noBtn).onClick.Add(new EventCallback0(CancelRehandle));
		((GObject)Intensify.Details).onClick.Add(new EventCallback1(CheckLegendItemDetails));
		((GObject)Intensify.yesBtn).onClick.Add(new EventCallback0(FillLegendItems));
		((GObject)Intensify.noBtn).onClick.Add(new EventCallback0(ClearSelectedItems));
		((GObject)Intensify.Strengthen).onClick.Add(new EventCallback1(IntensifyClick));
		((GObject)InfoBtn).onClick.Add(new EventCallback0(RenderItemEntries));
		((GObject)PotentialBtn).onClick.Add(new EventCallback0(UpdateIntensify));
		((GObject)DegreeElevationBtn).onClick.Add(new EventCallback0(UpdateRehandleAttributes));
		((GObject)SoulStoneBtn).onClick.Add(new EventCallback0(UpdateRefine));
		addCouponBtn.GetChild("addButton").onClick.Add(new EventCallback0(MoneyBtnEvent));
		addDiamondBtn.GetChild("addButton").onClick.Add(new EventCallback0(DiamondBtnEvent));
		addChangeTicketBtn.GetChild("addButton").onClick.Add(new EventCallback0(GoToLegendGift));
		addReforgeTicketBtn.GetChild("addButton").onClick.Add(new EventCallback0(GoToLegendGift));
		addTicketBtn.GetChild("addButton").onClick.Add(new EventCallback0(GoToLegendGift));
		addSwapTicketBtn.GetChild("addButton").onClick.Add(new EventCallback0(GoToLegendGift));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener("LEGEND_ITEM_FX_SWITCHED", OnLegendItemFxSwitched);
		SharedMessenger.AddListener("LEGEND_ITEM_MAIN_SWITCHED", OnLegendItemMainSwitched);
		SharedMessenger.AddListener("LEGEND_ITEM_MAIN_SWAPPED", OnLegendItemMainSwapped);
		((GObject)Intensify.ArmsList).data = 0;
		((GObject)Rehandle.Help).onClick.Set((EventCallback0)delegate
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			FairyGUITip.ShowTip((GObject)(object)Rehandle.Help, eFairyGUITipDir.Up, delegate(UI_com_UniversalPopupTip popup)
			{
				((GObject)popup.title).text = "LegendItemCultivatRehandleTip".ToLanguage();
			});
		});
		Details.popupMask.RegisterEvents();
		Replace.RegisterEvents();
		((GObject)ReplaceBtn).onClick.Set(new EventCallback0(UpdateReplace));
		((GObject)popupMask).onClick.Add(new EventCallback0(HideSwitchMainAttPopup));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected O, but got Unknown
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Expected O, but got Unknown
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Remove(new EventCallback0(End));
		((GObject)preview).onClick.Remove(new EventCallback1(ShowSoldierSpine));
		((GObject)TurnPageLeftBtn).onClick.Remove(new EventCallback1(PageTurning));
		((GObject)TurnPageRightBtn).onClick.Remove(new EventCallback1(PageTurning));
		((GObject)SwitchBtn).onClick.Remove(new EventCallback0(SwitchBtnClick));
		((GObject)Details.Atrributes.primeAttribute.SwitchBtn).onClick.Remove(new EventCallback0(OnClickSwitchMainAtt));
		((GObject)Rehandle.Rehandle).onClick.Remove(new EventCallback0(RehandleClick));
		((GObject)Rehandle.yesBtn).onClick.Remove(new EventCallback0(ConfirmRehandle));
		((GObject)Rehandle.noBtn).onClick.Remove(new EventCallback0(CancelRehandle));
		((GObject)Intensify.Details).onClick.Remove(new EventCallback1(CheckLegendItemDetails));
		((GObject)Intensify.yesBtn).onClick.Remove(new EventCallback0(FillLegendItems));
		((GObject)Intensify.noBtn).onClick.Remove(new EventCallback0(ClearSelectedItems));
		((GObject)Intensify.Strengthen).onClick.Remove(new EventCallback1(IntensifyClick));
		((GObject)InfoBtn).onClick.Remove(new EventCallback0(RenderItemEntries));
		((GObject)PotentialBtn).onClick.Remove(new EventCallback0(UpdateIntensify));
		((GObject)DegreeElevationBtn).onClick.Remove(new EventCallback0(UpdateRehandleAttributes));
		((GObject)SoulStoneBtn).onClick.Remove(new EventCallback0(UpdateRefine));
		addCouponBtn.GetChild("addButton").onClick.Remove(new EventCallback0(MoneyBtnEvent));
		addDiamondBtn.GetChild("addButton").onClick.Remove(new EventCallback0(DiamondBtnEvent));
		addChangeTicketBtn.GetChild("addButton").onClick.Remove(new EventCallback0(GoToLegendGift));
		addReforgeTicketBtn.GetChild("addButton").onClick.Remove(new EventCallback0(GoToLegendGift));
		addTicketBtn.GetChild("addButton").onClick.Remove(new EventCallback0(GoToLegendGift));
		addSwapTicketBtn.GetChild("addButton").onClick.Remove(new EventCallback0(GoToLegendGift));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener("LEGEND_ITEM_FX_SWITCHED", OnLegendItemFxSwitched);
		SharedMessenger.RemoveListener("LEGEND_ITEM_MAIN_SWITCHED", OnLegendItemMainSwitched);
		SharedMessenger.RemoveListener("LEGEND_ITEM_MAIN_SWAPPED", OnLegendItemMainSwapped);
		((GObject)Rehandle.Help).onClick.Clear();
		Details.popupMask.UnregisterEvents();
		Replace.UnregisterEvents();
		((GObject)ReplaceBtn).onClick.Clear();
		((GObject)popupMask).onClick.Remove(new EventCallback0(HideSwitchMainAttPopup));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		UpdateCurIndex();
		UI_SoldierCultivate.SoldierCultivatePanel?.LegendItemButtonsInit();
		UI_SoldierCultivate.SoldierCultivatePanel?.RefreshSoldierDetailInfo();
		UI_SoldierCultivate.SoldierCultivatePanel?.WaitToRefreshCombatPower(_isUpGrade: false);
		UI_SoldierCultivate.legendItemsChanged = true;
	}

	private void SetBuildingName()
	{
		((GObject)Title.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText830");
		addCouponBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Money");
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
		UpdateGemstone(isInit: true);
		UpdateMoney(isInit: true);
	}

	private void UpdateTabDirty()
	{
		((GObject)InfoBtn).data = true;
		((GObject)PotentialBtn).data = true;
		((GObject)DegreeElevationBtn).data = true;
		((GObject)SoulStoneBtn).data = true;
		Details.popupMask.Hide();
		((GObject)popupMask).visible = false;
		switch (PageController.selectedIndex)
		{
		case 0:
			RenderItemEntries();
			break;
		case 1:
			UpdateIntensify();
			break;
		case 2:
			UpdateRehandleAttributes();
			break;
		case 3:
			UpdateRefine();
			break;
		case 4:
			UpdateReplace();
			break;
		}
	}

	public void UpdateMoney(bool isInit = false)
	{
		int stock = GameManagers.Instance.StockController.GetStock("Money");
		if (!isInit && addCouponBtn.GetChild("num").data != null && (int)addCouponBtn.GetChild("num").data != stock)
		{
			int num = (int)addCouponBtn.GetChild("num").data;
			FGUIManager.Instance.AddNumFloatingForCouponBtn(UI_ProductionNumFloating.CreateInstance_ILRuntime(), addCouponBtn, stock - num, 1, dispose: true);
		}
		((GObject)addCouponBtn.GetChild("num").asTextField).text = stock.ToString();
		addCouponBtn.GetChild("num").data = stock;
	}

	public void UpdateLockTicket(bool isInit = false)
	{
		if (!string.IsNullOrWhiteSpace(lockTicketId))
		{
			int stock = GameManagers.Instance.StockController.GetStock(lockTicketId);
			if (!isInit && addTicketBtn.GetChild("num").data != null && (int)addTicketBtn.GetChild("num").data != stock)
			{
				int num = (int)addTicketBtn.GetChild("num").data;
				FGUIManager.Instance.AddNumFloatingForCouponBtn(UI_ProductionNumFloating.CreateInstance_ILRuntime(), addTicketBtn, stock - num, 1, dispose: true);
			}
			((GObject)addTicketBtn.GetChild("num").asTextField).text = stock.ToString();
			addTicketBtn.GetChild("num").data = stock;
		}
	}

	public void UpdateReforgeTicket(bool isInit = false)
	{
		if (!string.IsNullOrWhiteSpace(reforgeTicketId))
		{
			int stock = GameManagers.Instance.StockController.GetStock(reforgeTicketId);
			if (!isInit && addReforgeTicketBtn.GetChild("num").data != null && (int)addReforgeTicketBtn.GetChild("num").data != stock)
			{
				int num = (int)addReforgeTicketBtn.GetChild("num").data;
				FGUIManager.Instance.AddNumFloatingForCouponBtn(UI_ProductionNumFloating.CreateInstance_ILRuntime(), addReforgeTicketBtn, stock - num, 1, dispose: true);
			}
			((GObject)addReforgeTicketBtn.GetChild("num").asTextField).text = stock.ToString();
			addReforgeTicketBtn.GetChild("num").data = stock;
		}
	}

	public void UpdateChangeTicket(bool isInit = false)
	{
		if (!string.IsNullOrWhiteSpace(changeTicketId))
		{
			int stock = GameManagers.Instance.StockController.GetStock(changeTicketId);
			if (!isInit && addChangeTicketBtn.GetChild("num").data != null && (int)addChangeTicketBtn.GetChild("num").data != stock)
			{
				int num = (int)addChangeTicketBtn.GetChild("num").data;
				FGUIManager.Instance.AddNumFloatingForCouponBtn(UI_ProductionNumFloating.CreateInstance_ILRuntime(), addChangeTicketBtn, stock - num, 1, dispose: true);
			}
			((GObject)addChangeTicketBtn.GetChild("num").asTextField).text = stock.ToString();
			addChangeTicketBtn.GetChild("num").data = stock;
		}
	}

	public void UpdateGemstone(bool isInit = false)
	{
		int stock = GameManagers.Instance.StockController.GetStock("Gem");
		if (!isInit && addDiamondBtn.GetChild("num").data != null && (int)addDiamondBtn.GetChild("num").data != stock)
		{
			int num = (int)addDiamondBtn.GetChild("num").data;
			FGUIManager.Instance.AddNumFloatingForCouponBtn(UI_ProductionNumFloating.CreateInstance_ILRuntime(), addDiamondBtn, stock - num, 1, dispose: true);
		}
		((GObject)addDiamondBtn.GetChild("num").asTextField).text = stock.ToString();
		addDiamondBtn.GetChild("num").data = stock;
	}

	private void OnClickEffectLink(EventContext e)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillEffectPanel.Name, new Dictionary<string, object> { 
		{
			"EffectKey",
			e.data.ToString()
		} });
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		if (itemId == "Gem")
		{
			UpdateGemstone();
			addDiamondBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addDiamondBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
		else if (itemId == "Money")
		{
			UpdateMoney();
			addCouponBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addCouponBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
		else if (itemId == lockTicketId)
		{
			UpdateLockTicket();
			addTicketBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addTicketBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
		else if (itemId == changeTicketId)
		{
			UpdateChangeTicket();
			addChangeTicketBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addChangeTicketBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
		else if (itemId == reforgeTicketId)
		{
			UpdateReforgeTicket();
			addReforgeTicketBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addReforgeTicketBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
		else if (itemId == swapTicketId)
		{
			UpdateSwapTicket();
			addSwapTicketBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addSwapTicketBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
	}

	private void OnLegendItemFxSwitched()
	{
		UpdateTabDirty();
	}

	private void OnLegendItemMainSwitched()
	{
		UpdateTabDirty();
	}

	private void OnLegendItemMainSwapped()
	{
		UpdateTabDirty();
	}

	private void OnClickSwitchMainAtt()
	{
		if (CurLegendItemData != null)
		{
			((GObject)popupMask).visible = true;
			Details.popupMask.Show(CurLegendItemData);
			((GObject)popupMask).visible = Details.mainAttrPopup.selectedIndex == 1;
		}
	}

	private void HideSwitchMainAttPopup()
	{
		((GObject)popupMask).visible = false;
		Details.popupMask.Hide();
	}

	private void DiamondBtnEvent()
	{
		if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object>
			{
				{
					"Activity",
					FGUIManager.Instance.GetBlackMarketerActivity("UI_BlackMarketerAddCredit")
				},
				{
					"Order",
					((GObject)this).sortingOrder
				},
				{ "Parent", this }
			});
		}
	}

	private void MoneyBtnEvent()
	{
		if (FGUIManager.Instance.JudgeFreeWorkerNum(needTip: true))
		{
			if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_GiftBagPanel.Name, new Dictionary<string, object>
				{
					{
						"Activity",
						FGUIManager.Instance.GetBlackMarketerActivity("UI_GiftBagPanel")
					},
					{
						"Order",
						((GObject)this).sortingOrder
					},
					{ "Parent", this }
				});
			}
			else
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
		}
	}

	private void GoToLegendGift()
	{
		List<string> arg = new List<string> { LanguagesManager.GetDesc("TipFarmingInAllServersChampionship") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private void ShowSoldierSpine(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		object data = ((GObject)context.sender).data;
		string text = ((data != null) ? data.ToString() : UiHelper.GetUnlockSoldierList().First().Id);
		SoldierPromotionPanel = UI_SoldierPromotionPanel.CreateInstance();
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)SoldierPromotionPanel);
		((GObject)SoldierPromotionPanel).sortingOrder = 1;
		((GObject)SoldierPromotionPanel.mask).onClick.Set((EventCallback0)delegate
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)SoldierPromotionPanel);
			((GObject)SoldierPromotionPanel).Dispose();
		});
		SoldierPromotionPanel.Dialog.PageController.selectedIndex = 0;
		SoldierPromotionPanel.PageController.selectedIndex = 0;
		int num = 1;
		SoldierPromotionPanel.Dialog.PageController.selectedIndex = 2;
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(text);
		int num2 = GameManagers.Instance.SoldierManager.GetSoldierFxSize(text) + 1;
		if (num2 <= 2)
		{
			SoldierPromotionPanel.Dialog.Status.selectedIndex = 0;
		}
		else
		{
			SoldierPromotionPanel.Dialog.Status.selectedIndex = 1;
		}
		Object obj = Object.Instantiate(Resources.Load("Items/Spine", typeof(GameObject)));
		GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
		val.GetComponent<Canvas>().sortingLayerName = "Default";
		int num3 = (soldier.NextPotentialLevel + 2) / 2;
		UiHelper.SpineLoad(SoldierPromotionPanel.Dialog.Spine, text, 46f, $"skin{num3}", "idle");
		((GObject)SoldierPromotionPanel.Dialog).y = num;
		((GComponent)GRoot.inst).AddChild((GObject)(object)SoldierPromotionPanel);
		SoldierPromotionPanel.ShowDialog.Play();
	}

	private void RenderLegendItemsFilters()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		for (int i = 0; i < Intensify.filters.numItems; i++)
		{
			GButton asButton = ((GComponent)Intensify.filters).GetChildAt(i).asButton;
			((GComponent)asButton).GetChild("Title").text = ((GObject)asButton).name;
			((GObject)asButton).data = i;
			((GObject)asButton).onClick.Set(new EventCallback1(FiltrateLegendItems));
			if (i == 0)
			{
				Intensify.filters.selectedIndex = 0;
			}
		}
	}

	private void UpdateLeftDetails()
	{
		((GObject)preview).visible = false;
		((GObject)LegendItemName.LegendItemName).text = LegendItemsHelper.GetLegendItemNameTitle(CurLegendItemData.LegendItemData.Data.Name, CurLegendItemData.LegendItemData.EnhanceLevel);
		LegendItemName.Type.selectedIndex = CurLegendItemData.LegendItemData.Data.Rarity - 1;
		Stars.GetController("ClassController").selectedIndex = CurLegendItemData.LegendItemData.Data.Rarity - 1;
		if (LegendItemsHelper.EquippedLegendItems.ContainsKey(CurLegendItemData.InstanceId.ToString()))
		{
			((GObject)SoldierIcon).visible = true;
			UiHelper.RenderSoldierItem(SoldierIcon, LegendItemsHelper.EquippedLegendItems[CurLegendItemData.InstanceId.ToString()], textureList);
			((GObject)preview).data = LegendItemsHelper.EquippedLegendItems[CurLegendItemData.InstanceId.ToString()];
		}
		else
		{
			((GObject)SoldierIcon).visible = false;
			((GObject)preview).data = null;
		}
		((GObject)CombatPower).text = CurLegendItemData.LegendItemData.Score.ToString();
		UpdateLockState();
		((GObject)introduction).text = CurLegendItemData.LegendItemData.Data.Desc;
		LegendItemIcon.LoadArmsIcon(CurLegendItemData.LegendItemData.Data.Icon);
	}

	private void RenderItemEntries()
	{
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		if (((GObject)InfoBtn).data == null || !(bool)((GObject)InfoBtn).data)
		{
			return;
		}
		((GObject)InfoBtn).data = false;
		UpdateLeftDetails();
		string legendItemMainPropetryKeyText = LegendItemsHelper.GetLegendItemMainPropetryKeyText(CurLegendItemData);
		((GObject)Details.Atrributes.primeAttribute.primeAttribute).text = "";
		((GObject)Details.Atrributes.primeAttribute.primeAttribute).text = legendItemMainPropetryKeyText + LegendItemsHelper.GetLegendItemNextEnhanceLevelValue(CurLegendItemData);
		subEntryTexts.Clear();
		fxSuitEntryTexts.Clear();
		string subEntries = LegendItemsHelper.GetSubEntries(CurLegendItemData.LegendItemData);
		List<string> fxEntries = LegendItemsHelper.GetFxEntries(CurLegendItemData.LegendItemData);
		string suitDesc = LegendItemsHelper.GetSuitDesc(CurLegendItemData.LegendItemData);
		if (!string.IsNullOrEmpty(subEntries))
		{
			subEntryTexts.Add(subEntries);
		}
		List<ItemEntry> fxEntries2 = CurLegendItemData.LegendItemData.FxEntries;
		for (int i = 0; i < fxEntries.Count; i++)
		{
			fxSuitEntryTexts.Add(new FxDescItem
			{
				Desc = fxEntries[i],
				IsBlueprintFx = fxEntries2[i].IsBlueprintEntry,
				Type = EntryTextType.FxEntry
			});
		}
		if (!string.IsNullOrEmpty(suitDesc))
		{
			bool isBlueprintFx = LegendItemsHelper.IsBlueprintSuit(CurLegendItemData.LegendItemData);
			fxSuitEntryTexts.Add(new FxDescItem
			{
				Desc = suitDesc,
				IsBlueprintFx = isBlueprintFx,
				Type = EntryTextType.Suit
			});
		}
		_hasAlterFx = false;
		List<FxEntryGroup> alterFxEntries = CurLegendItemData.LegendItemData.AlterFxEntries;
		if (alterFxEntries != null && alterFxEntries.Count > 0)
		{
			foreach (FxEntryGroup item in alterFxEntries)
			{
				bool flag = item.Entries == null || item.Entries.Count == 0;
				bool flag2 = string.IsNullOrEmpty(item.SetAlias);
				if (!flag || !flag2)
				{
					_hasAlterFx = true;
					break;
				}
			}
		}
		Details.Atrributes.SubEntries.itemRenderer = new ListItemRenderer(RenderSubEntry);
		Details.Atrributes.SubEntries.numItems = subEntryTexts.Count;
		Details.Atrributes.SubEntries.ResizeToFit(subEntryTexts.Count);
		Details.Atrributes.FxSuitEntries.itemRenderer = new ListItemRenderer(RenderFxSuitEntry);
		Details.Atrributes.FxSuitEntries.numItems = fxSuitEntryTexts.Count;
		Details.Atrributes.FxSuitEntries.ResizeToFit(fxSuitEntryTexts.Count);
		List<ItemEntry> alterMainEntries = CurLegendItemData.LegendItemData.AlterMainEntries;
		bool flag3 = alterMainEntries != null && alterMainEntries.Count > 0;
		Details.Atrributes.primeAttribute.ShowSwitchBtn.SetSelectedIndex(flag3 ? 1 : 0);
	}

	private void RenderSubEntry(int index, GObject obj)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		if (index < subEntryTexts.Count && obj is UI_SubAttributeBack uI_SubAttributeBack)
		{
			uI_SubAttributeBack.Type.selectedIndex = 0;
			uI_SubAttributeBack.SetControllerPageText();
			((GObject)uI_SubAttributeBack.Title).text = uI_SubAttributeBack.GetControllerText(0);
			((GObject)uI_SubAttributeBack.primeAttribute).text = subEntryTexts[index];
			((GObject)uI_SubAttributeBack.primeAttribute).onClickLink.Set(new EventCallback1(OnClickEffectLink));
		}
	}

	private void RenderFxSuitEntry(int index, GObject obj)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		if (index < fxSuitEntryTexts.Count && obj is UI_SubAttributeBack uI_SubAttributeBack)
		{
			FxDescItem fxDescItem = fxSuitEntryTexts[index];
			int type = (int)fxDescItem.Type;
			uI_SubAttributeBack.Type.selectedIndex = type;
			uI_SubAttributeBack.SetControllerPageText();
			((GObject)uI_SubAttributeBack.Title).text = uI_SubAttributeBack.GetControllerText(type);
			((GObject)uI_SubAttributeBack.primeAttribute).text = fxDescItem.Desc;
			((GObject)uI_SubAttributeBack.primeAttribute).onClickLink.Set(new EventCallback1(OnClickEffectLink));
			bool flag = _hasAlterFx && fxDescItem.IsBlueprintFx;
			uI_SubAttributeBack.ShowSwitchBtn.selectedIndex = (flag ? 1 : 0);
			if (flag)
			{
				((GObject)uI_SubAttributeBack.SwitchBtn).onClick.Set(new EventCallback0(OnClickEffectSwitchBtn));
			}
			else
			{
				((GObject)uI_SubAttributeBack.SwitchBtn).onClick.Clear();
			}
		}
	}

	private void OnClickEffectSwitchBtn()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_EffectSwitch.Name, new Dictionary<string, object> { { "LegendItem", CurLegendItemData } });
	}

	private void SetPageBtnStatus()
	{
		if (legendItems.Count <= 1)
		{
			((GObject)TurnPageLeftBtn).enabled = false;
			((GObject)TurnPageRightBtn).enabled = false;
		}
		else if (curIndex == 0)
		{
			((GObject)TurnPageLeftBtn).enabled = false;
			((GObject)TurnPageRightBtn).enabled = true;
		}
		else if (curIndex == legendItems.Count - 1)
		{
			((GObject)TurnPageLeftBtn).enabled = true;
			((GObject)TurnPageRightBtn).enabled = false;
		}
		else
		{
			((GObject)TurnPageLeftBtn).enabled = true;
			((GObject)TurnPageRightBtn).enabled = true;
		}
	}

	private void PageTurning(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int direction = (int)((GObject)(GButton)context.sender).data;
		PageRefresh(direction);
	}

	private void PageRefresh(int direction)
	{
		UpdateCurIndex();
		curIndex += direction;
		if (curIndex < 0)
		{
			curIndex = 0;
		}
		else if (curIndex > legendItems.Count - 1)
		{
			curIndex = legendItems.Count - 1;
		}
		CurLegendItemData = legendItems[curIndex];
		SetPageBtnStatus();
		UpdateReplaceBtnVisible();
		UpdateTabDirty();
		if (PageController.selectedIndex != 0)
		{
			UpdateLeftDetails();
		}
	}

	private void UpdateRehandleAttributes()
	{
		if (((GObject)DegreeElevationBtn).data == null || !(bool)((GObject)DegreeElevationBtn).data)
		{
			return;
		}
		((GObject)DegreeElevationBtn).data = false;
		Rehandle.PageController.selectedIndex = 0;
		if (CurLegendItemData.LegendItemData.SubEntries != null)
		{
			Rehandle.PropertyContent.RemoveChildrenToPool();
			for (int i = 0; i < CurLegendItemData.LegendItemData.SubEntries.Count; i++)
			{
				Rehandle.PropertyContent.AddItemFromPool();
				if (CurLegendItemData.LegendItemData.SubEntries[i].Status == 1)
				{
					Rehandle.PageController.selectedIndex = 1;
				}
				RehandleAttributeRender(i, ((GComponent)Rehandle.PropertyContent).GetChildAt(i), CurLegendItemData.LegendItemData.SubEntries[i]);
			}
			RenderReforgeCostCom();
		}
		needUpdateRehandleBtn = false;
	}

	private void RenderReforgeCostCom()
	{
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		string itemId = CurLegendItemData.LegendItemData.ItemId;
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		List<Dictionary<string, int>> value = new List<Dictionary<string, int>>();
		int num = 1;
		if (LegendItemManager.LegendItemReforgeCosts.TryGetValue(itemId, out value))
		{
			foreach (KeyValuePair<string, int> item in value.Last())
			{
				dictionary.Add(item.Key, item.Value);
			}
		}
		if (LegendItemManager.LegendItemReforgeLockCosts.TryGetValue(itemId, out var value2) && CurLegendItemData.ReforgeIndex != null && CurLegendItemData.ReforgeIndex.Count > 0)
		{
			foreach (KeyValuePair<string, int> item2 in value2.Last())
			{
				dictionary.Add(item2.Key, item2.Value);
			}
			num = 2;
		}
		if (value.Count > 1)
		{
			foreach (KeyValuePair<string, int> item3 in value.First())
			{
				dictionary.Add(item3.Key, item3.Value);
			}
		}
		((GObject)Rehandle.CostInfo).data = dictionary;
		Rehandle.CostInfo.itemRenderer = new ListItemRenderer(RenderReforgeCostItem);
		Rehandle.CostInfo.numItems = num;
		Rehandle.CostInfo.ResizeToFit(num);
	}

	private void SetLockTicketId()
	{
		if (!LegendItemManager.LegendItemReforgeLockCosts.TryGetValue(CurLegendItemData.LegendItemData.ItemId, out var value))
		{
			((GObject)addTicketBtn).visible = false;
			return;
		}
		lockTicketId = Enumerable.First(value.Last()).Key;
		if (string.IsNullOrWhiteSpace(lockTicketId))
		{
			((GObject)addTicketBtn).visible = false;
			return;
		}
		((GObject)addTicketBtn).visible = true;
		FGUIManager.Instance.SetItemIconAndFrame(addTicketBtn.GetChild("icon").asLoader, lockTicketId, textureList, "", frameVisible: false);
		UpdateLockTicket(isInit: true);
	}

	private void SetChangeEntryTicketId()
	{
		FGUIManager.Instance.SetItemIconAndFrame(addChangeTicketBtn.GetChild("icon").asLoader, changeTicketId, textureList, "", frameVisible: false);
		UpdateChangeTicket(isInit: true);
	}

	private void SetReforgeTicketId()
	{
		FGUIManager.Instance.SetItemIconAndFrame(addReforgeTicketBtn.GetChild("icon").asLoader, reforgeTicketId, textureList, "", frameVisible: false);
		UpdateReforgeTicket(isInit: true);
	}

	private void SetSwapTicketId()
	{
		FGUIManager.Instance.SetItemIconAndFrame(addSwapTicketBtn.GetChild("icon").asLoader, swapTicketId, textureList, "", frameVisible: false);
		UpdateSwapTicket(isInit: true);
	}

	public void UpdateSwapTicket(bool isInit = false)
	{
		int stock = GameManagers.Instance.StockController.GetStock(swapTicketId);
		if (!isInit && addSwapTicketBtn.GetChild("num").data != null && (int)addSwapTicketBtn.GetChild("num").data != stock)
		{
			int num = (int)addSwapTicketBtn.GetChild("num").data;
			FGUIManager.Instance.AddNumFloatingForCouponBtn(UI_ProductionNumFloating.CreateInstance_ILRuntime(), addSwapTicketBtn, stock - num, 1, dispose: true);
		}
		((GObject)addSwapTicketBtn.GetChild("num").asTextField).text = stock.ToString();
		addSwapTicketBtn.GetChild("num").data = stock;
	}

	private void RenderReforgeCostItem(int index, GObject obj)
	{
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		GComponent asCom = obj.asCom;
		List<KeyValuePair<string, int>> list = ((Dictionary<string, int>)((GObject)Rehandle.CostInfo).data).ToList();
		KeyValuePair<string, int> keyValuePair = list[index];
		int num = ((index <= 0) ? 1 : LegendItemsHelper.GetReforgeLockCostCount(CurLegendItemData));
		string text = "#50280A";
		string key = keyValuePair.Key;
		int stock = GameManagers.Instance.StockController.GetStock(key);
		int num2 = num * keyValuePair.Value;
		if (index == 0 && stock < num2)
		{
			KeyValuePair<string, int> keyValuePair2 = list[list.Count - 1];
			key = keyValuePair2.Key;
			num2 = num * keyValuePair2.Value;
			stock = GameManagers.Instance.StockController.GetStock(key);
		}
		if (stock < num2)
		{
			text = "#ff1919";
		}
		asCom.GetChild("num").text = $"x{num2}";
		asCom.GetController("hasFrame").selectedIndex = 1;
		FGUIManager.Instance.SetItemIconAndFrame(asCom.GetChild("Icon").asLoader, key, textureList, "", frameVisible: false);
		((GObject)asCom).data = key;
		((GObject)asCom).onClick.Set(new EventCallback1(ItemTip));
	}

	private void ReforgePropetryLock(EventContext context)
	{
	}

	private void RehandleAttributeRender(int index, GObject obj, ItemEntry itemEntry)
	{
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		//IL_069b: Expected O, but got Unknown
		//IL_0631: Unknown result type (might be due to invalid IL or missing references)
		UI_ReforgeProperty button = obj as UI_ReforgeProperty;
		((GObject)button.Index).text = (index + 1).ToString();
		string maxLogoText = "";
		Dictionary<string, string> reforgeEntry = LegendItemsHelper.GetReforgeEntry(itemEntry, out maxLogoText);
		KeyValuePair<string, string> keyValuePair = Enumerable.First(reforgeEntry);
		((GButton)button.lockBtn).selected = false;
		if (Rehandle.PageController.selectedIndex == 1)
		{
			((GObject)button.lockBtn).enabled = false;
		}
		else
		{
			((GObject)button.lockBtn).enabled = true;
		}
		if (!LegendItemsHelper.GetSubPropertyUnlocked(CurLegendItemData, index))
		{
			button.TyepController.selectedIndex = 3;
			((GObject)button.lockedContent).text = LanguagesManager.GetLockedSubEntryText();
			((GObject)button.lockBtn).enabled = false;
		}
		else if (CurLegendItemData.ReforgeIndex != null && CurLegendItemData.ReforgeIndex.Contains(index))
		{
			((GObject)button.curContent).text = maxLogoText + keyValuePair.Value;
			((GObject)button.curValue).text = keyValuePair.Key;
			((GObject)button.nextContent).text = maxLogoText + keyValuePair.Value;
			((GObject)button.nextValue).text = keyValuePair.Key;
			button.TyepController.selectedIndex = 1;
			((GButton)button.lockBtn).selected = true;
		}
		else
		{
			switch (itemEntry.Status)
			{
			case -1:
				button.TyepController.selectedIndex = 3;
				((GObject)button.lockedContent).text = LanguagesManager.GetLockedSubEntryText();
				((GObject)button.lockBtn).enabled = false;
				break;
			case 0:
				if (itemEntry.TmpItemEntry == null)
				{
					button.TyepController.selectedIndex = 0;
					((GObject)button.curContent).text = maxLogoText + keyValuePair.Value;
					((GObject)button.curValue).text = keyValuePair.Key;
					((GObject)button.nextContent).text = ((GObject)button.nextContent).data.ToString();
					((GObject)button.nextValue).text = ((GObject)button.nextValue).data.ToString();
				}
				else
				{
					button.TyepController.selectedIndex = 2;
					string maxLogoText3 = "";
					Dictionary<string, string> reforgeEntry3 = LegendItemsHelper.GetReforgeEntry(itemEntry.TmpItemEntry, out maxLogoText3);
					KeyValuePair<string, string> keyValuePair3 = Enumerable.First(reforgeEntry3);
					((GObject)button.nextContent).text = maxLogoText3 + keyValuePair3.Value;
					((GObject)button.nextValue).text = keyValuePair3.Key;
					((GObject)button.curContent).text = maxLogoText + keyValuePair.Value;
					((GObject)button.curValue).text = keyValuePair.Key;
				}
				break;
			case 1:
				button.TyepController.selectedIndex = 2;
				if (itemEntry.TmpItemEntry != null)
				{
					string maxLogoText2 = "";
					Dictionary<string, string> reforgeEntry2 = LegendItemsHelper.GetReforgeEntry(itemEntry.TmpItemEntry, out maxLogoText2);
					KeyValuePair<string, string> keyValuePair2 = Enumerable.First(reforgeEntry2);
					((GObject)button.nextContent).text = maxLogoText2 + keyValuePair2.Value;
					((GObject)button.nextValue).text = keyValuePair2.Key;
				}
				((GObject)button.curContent).text = maxLogoText + keyValuePair.Value;
				((GObject)button.curValue).text = keyValuePair.Key;
				break;
			case 10:
				((GObject)button.curContent).text = maxLogoText + keyValuePair.Value;
				((GObject)button.curValue).text = keyValuePair.Key;
				((GObject)button.nextContent).text = maxLogoText + keyValuePair.Value;
				((GObject)button.nextValue).text = keyValuePair.Key;
				button.TyepController.selectedIndex = 1;
				((GButton)button.lockBtn).selected = true;
				break;
			default:
				button.TyepController.selectedIndex = 0;
				((GObject)button.curContent).text = maxLogoText + keyValuePair.Value;
				((GObject)button.curValue).text = keyValuePair.Key;
				((GObject)button.nextContent).text = ((GObject)button.nextContent).data.ToString();
				((GObject)button.nextValue).text = ((GObject)button.nextValue).data.ToString();
				break;
			}
		}
		if (needUpdateRehandleBtn && itemEntry.TmpItemEntry != null)
		{
			float width = ((GObject)button.nextContentSfxBack).width;
			FGUIManager.Instance.AddTextSpecialEffects(button.nextContentSfxBack, "ui_numberchange_textbox_green", new Vector3(width, 45f, width), "Default", 0.5f, delegate(GameObject uiGreen1)
			{
				UiHelper.HideUiSfx(button.nextContentSfxBack, uiGreen1, 0.5f);
			});
		}
		else if (needUpdateRehandleBtn && button.TyepController.selectedIndex != 3 && button.TyepController.selectedIndex != 1)
		{
			float width2 = ((GObject)button.curContentSfxBack).width;
			FGUIManager.Instance.AddTextSpecialEffects(button.curContentSfxBack, "ui_numberchange_textbox_green", new Vector3(width2, 45f, width2), "Default", 0.5f, delegate(GameObject uiGreen1)
			{
				UiHelper.HideUiSfx(button.curContentSfxBack, uiGreen1, 0.5f);
			});
		}
		button.lockBtn.SetControllerPageText();
		((GObject)button.lockBtn).data = index;
		((GObject)button.lockBtn).onClick.Set(new EventCallback1(LockAttribute));
	}

	private void LockAttribute(EventContext context)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		int num = (int)((GObject)context.sender).data;
		UI_ReforgeProperty _btn = ((GComponent)Rehandle.PropertyContent).GetChildAt(num).asCom as UI_ReforgeProperty;
		if (CurLegendItemData.ReforgeIndex == null || !CurLegendItemData.ReforgeIndex.Contains(num))
		{
			((GComponent)(object)this).SetTimeout(0.05f).OnComplete((GTweenCallback)delegate
			{
				//IL_002e: Unknown result type (might be due to invalid IL or missing references)
				float width = ((GObject)_btn.nextContentSfxBack).width;
				FGUIManager.Instance.AddTextSpecialEffects(_btn.nextContentSfxBack, "ui_numberchange_textbox_green", new Vector3(width, 45f, width), "Default", 0.5f, delegate(GameObject uiGreen1)
				{
					UiHelper.DestoryUiSfx(_btn.nextContentSfxBack, uiGreen1, 0.5f);
				});
			});
		}
		LegendItemsHelper.SetLegendItemLockSubEntriesIndex(CurLegendItemData, num);
		RehandleAttributeRender(num, (GObject)(object)_btn, CurLegendItemData.LegendItemData.SubEntries[num]);
		RenderReforgeCostCom();
	}

	private void RehandleClick()
	{
		bool flag = false;
		RehandleAttributes();
	}

	private void RehandleAttributes()
	{
		needUpdateRehandleBtn = true;
		LegendItemsHelper.LegendItemReforge(CurLegendItemData, UpdateAttributesAfterLegendItemRehandle);
	}

	private void UpdateAttributesAfterLegendItemRehandle()
	{
		UpdateTabDirty();
	}

	private void CancelRehandle()
	{
		LegendItemsHelper.LegendItemConfirmReforge(CurLegendItemData, confirm: false, UpdateAttributesAfterLegendItemRehandle, ((GObject)this).sortingOrder);
	}

	private void ConfirmRehandle()
	{
		LegendItemsHelper.JudgeShowReforgeTip(CurLegendItemData, confirm: true, UpdateAttributesAfterLegendItemRehandle);
		needUpdateRehandleBtn = true;
	}

	private void UpdateRefine()
	{
		if (((GObject)SoulStoneBtn).data == null || !(bool)((GObject)SoulStoneBtn).data)
		{
			return;
		}
		((GObject)SoulStoneBtn).data = false;
		List<ItemEntry> list = CurLegendItemData.LegendItemData.FxEntries;
		List<ItemEntry> subEntries = CurLegendItemData.LegendItemData.SubEntries;
		if (subEntries == null || subEntries.Count == 0)
		{
			return;
		}
		List<ItemEntry> list2 = new List<ItemEntry>();
		if (list == null)
		{
			list = new List<ItemEntry>();
		}
		list2.AddRange(list);
		list2.AddRange(subEntries);
		Refine.PropetryContent.RemoveChildrenToPool();
		for (int i = 0; i < list2.Count; i++)
		{
			GObject val = Refine.PropetryContent.AddItemFromPool();
			if (list2[i].EntryId == null)
			{
				val.visible = false;
				val.y = 25f - val.height;
				continue;
			}
			val.visible = true;
			bool flag = i < list.Count;
			int item = ((!flag) ? 1 : 2);
			int item2 = (flag ? i : (i - list.Count));
			Tuple<int, int> chandePropertyInfo = new Tuple<int, int>(item, item2);
			RefineAttributeRender(i, val, list2[i], chandePropertyInfo);
		}
		((GComponent)Refine.PropetryContent).EnsureBoundsCorrect();
		if (needUpdateBtnIndex >= 0)
		{
			GObject childAt = ((GComponent)Refine.PropetryContent).GetChildAt(needUpdateBtnIndex);
			if (childAt.y + childAt.height > ((GObject)Refine.PropetryContent).height)
			{
				((GComponent)Refine.PropetryContent).scrollPane.ScrollToView(childAt);
			}
		}
		needUpdateBtnIndex = -1;
	}

	private void CostItemAndNumRender(UI_CostItemAndNum content)
	{
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		if (LegendItemManager.LegendItemChangePropertyCosts.TryGetValue(CurLegendItemData.LegendItemData.ItemId, out var value))
		{
			KeyValuePair<string, int> keyValuePair = Enumerable.First(value.Last());
			string arg = "#F6E2B2";
			string key = keyValuePair.Key;
			int value2 = keyValuePair.Value;
			int stock = GameManagers.Instance.StockController.GetStock(key);
			if (stock < keyValuePair.Value && value.Count > 1)
			{
				KeyValuePair<string, int> keyValuePair2 = Enumerable.First(value.First());
				key = keyValuePair2.Key;
				stock = GameManagers.Instance.StockController.GetStock(key);
				value2 = keyValuePair2.Value;
			}
			if (stock < keyValuePair.Value)
			{
				arg = "#ff1919";
			}
			((GObject)content.Num).text = $"[color={arg}]{value2}[/color]";
			FGUIManager.Instance.SetItemIconAndFrame(content.Icon, key, textureList, "", frameVisible: false);
			((GObject)content).data = key;
			((GObject)content).onClick.Set(new EventCallback1(ItemTip));
		}
	}

	private void ItemTip(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string text = ((GObject)context.sender).data.ToString();
		if (!string.IsNullOrWhiteSpace(text))
		{
			FGUIManager.Instance.ItemTip(text, ((GObject)this).sortingOrder, noCheckBtn: true);
		}
	}

	private void RefineAttributeRender(int index, GObject obj, ItemEntry entry, Tuple<int, int> chandePropertyInfo)
	{
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		UI_ChandeProperty uI_ChandeProperty = obj as UI_ChandeProperty;
		uI_ChandeProperty.TyepController.selectedIndex = 0;
		CostItemAndNumRender(uI_ChandeProperty.CostItemAndNum);
		uI_ChandeProperty.Type.selectedIndex = chandePropertyInfo.Item1 - 1;
		uI_ChandeProperty.SetControllerPageText();
		((GObject)uI_ChandeProperty.Title).text = uI_ChandeProperty.GetControllerText(uI_ChandeProperty.Type.selectedIndex);
		((GObject)uI_ChandeProperty.Index).text = (chandePropertyInfo.Item2 + 1).ToString();
		uI_ChandeProperty.TyepController.selectedIndex = 0;
		bool flag = chandePropertyInfo.Item1 == 2;
		string text = "";
		if (flag)
		{
			if (entry.Status == 2 && entry.TmpItemEntry != null)
			{
				uI_ChandeProperty.TyepController.selectedIndex = 1;
				string entryText = LegendItemsHelper.GetEntryText(entry.TmpItemEntry, "ChangePropetryToBeConfirmed", entry, flag);
				text = entryText ?? "";
			}
			else
			{
				string entryText2 = LegendItemsHelper.GetEntryText(entry, "ChangePropetry", null, flag);
				text = entryText2 ?? "";
			}
		}
		else if (LegendItemsHelper.GetSubPropertyUnlocked(CurLegendItemData, chandePropertyInfo.Item2))
		{
			if (entry.Status == 2 && entry.TmpItemEntry != null)
			{
				uI_ChandeProperty.TyepController.selectedIndex = 1;
				string entryText3 = LegendItemsHelper.GetEntryText(entry.TmpItemEntry, "ChangePropetryToBeConfirmed", entry, flag);
				text = entryText3 ?? "";
			}
			else
			{
				string entryText4 = LegendItemsHelper.GetEntryText(entry, "ChangePropetry", null, flag);
				text = entryText4 ?? "";
			}
		}
		else
		{
			uI_ChandeProperty.TyepController.selectedIndex = 2;
			text = LanguagesManager.GetLockedSubEntryText();
		}
		((GObject)uI_ChandeProperty.attribute).text = text;
		if (uI_ChandeProperty.TyepController.selectedIndex != 1 && ((GObject)uI_ChandeProperty.attribute).height < 90f)
		{
			((GObject)uI_ChandeProperty.attribute_max2Line).text = text;
			((GObject)uI_ChandeProperty.attribute_max2Line).visible = true;
			((GObject)uI_ChandeProperty.attribute).text = "\n\n";
		}
		else
		{
			((GObject)uI_ChandeProperty.attribute).text = text;
			((GObject)uI_ChandeProperty.attribute_max2Line).visible = false;
		}
		if (index == needUpdateBtnIndex)
		{
			GGraph attributeSfxBack = uI_ChandeProperty.attributeSfxBack;
			((GObject)attributeSfxBack).x = -100f;
			FGUIManager.Instance.AddTextSpecialEffects(attributeSfxBack, "ui_numberchange_textbox_green", new Vector3(180f, ((GObject)attributeSfxBack).height, ((GObject)attributeSfxBack).width), "Default", 0.5f, delegate(GameObject uiGreen)
			{
				UiHelper.HideUiSfx(attributeSfxBack, uiGreen, 1f);
			});
		}
		((GObject)uI_ChandeProperty.ChangePropetry).data = chandePropertyInfo;
		((GObject)uI_ChandeProperty.ChangePropetry).onClick.Set(new EventCallback1(RefineItem));
		((GObject)uI_ChandeProperty.Confirm).data = chandePropertyInfo;
		((GObject)uI_ChandeProperty.Confirm).onClick.Set(new EventCallback1(RefineConfirm));
		((GObject)uI_ChandeProperty.Cancel).data = chandePropertyInfo;
		((GObject)uI_ChandeProperty.Cancel).onClick.Set(new EventCallback1(RefineCancel));
	}

	private void RefineCancel(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Tuple<int, int> tuple = (Tuple<int, int>)((GObject)context.sender).data;
		LegendItemsHelper.LegendItemConfirmChangePropetry(CurLegendItemData, tuple.Item1, tuple.Item2, confirm: false, UpdateTabDirty, ((GObject)this).sortingOrder);
	}

	private void RefineConfirm(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		Tuple<int, int> tuple = (Tuple<int, int>)val.data;
		needUpdateBtnIndex = ((GComponent)Refine.PropetryContent).GetChildIndex((GObject)(object)val.parent);
		LegendItemsHelper.JudgeShowChangeTipForConfirmChange(CurLegendItemData, tuple.Item1, tuple.Item2, confirm: true, UpdateTabDirty);
	}

	private void RefineItem(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		needUpdateBtnIndex = ((GComponent)Refine.PropetryContent).GetChildIndex((GObject)(object)val.parent);
		Tuple<int, int> tuple = (Tuple<int, int>)val.data;
		LegendItemsHelper.JudgeShowChangeTip(CurLegendItemData, tuple.Item1, tuple.Item2, UpdateTabDirty);
	}

	private void UpdateIntensify()
	{
		if (((GObject)PotentialBtn).data != null && (bool)((GObject)PotentialBtn).data)
		{
			configMaxLevel = LegendItemsHelper.GetLegendItemMaxLevelEnhancementConfigs(CurLegendItemData, out maxLeveLegendItemEnhancementConfig);
			((GObject)PotentialBtn).data = false;
			((GObject)Intensify.Details).enabled = false;
			((GObject)Intensify.Details).data = null;
			currentSelectItems.Clear();
			Intensify.ArmsList.SetVirtual();
			FiltrateLegendItems((int)((GObject)Intensify.ArmsList).data);
			UpdateArmsList();
			UpdateSelectList();
			UpdateMutableUi();
		}
	}

	private void UpdateAfterIntensify()
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		if (((GObject)PotentialBtn).data != null && (bool)((GObject)PotentialBtn).data)
		{
			((GObject)PotentialBtn).data = false;
			((GObject)Intensify.Details).enabled = false;
			((GObject)Intensify.Details).data = null;
			currentSelectItems.Clear();
			Intensify.ArmsList.SetVirtual();
			Intensify.ArmsList.itemRenderer = new ListItemRenderer(LegendItemRender);
			Intensify.ArmsList.numItems = totalSelectItems.Count;
			UpdateSelectList();
			UpdateMutableUi(showTextSfx: true, showProgressSfx: true);
		}
	}

	private void UpdateMutableUi(bool showTextSfx = false, bool showProgressSfx = false)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		int num = (int)((GObject)Intensify.SelectList).data;
		bool canLevelUp = true;
		int fakeLegendItemLevel = LegendItemsHelper.GetFakeLegendItemLevel(CurLegendItemData, num, out canLevelUp);
		int num2 = ((num > 0) ? fakeLegendItemLevel : CurLegendItemData.LegendItemData.EnhanceLevel);
		string numColor = ((num > 0) ? "#AFF627" : "#FFF2D3");
		Intensify.NameCom.Type.selectedIndex = CurLegendItemData.LegendItemData.Data.Rarity - 1;
		Intensify.NameCom.LegendItemName.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		((GObject)Intensify.NameCom.LegendItemName).text = LegendItemsHelper.GetLegendItemNameTitle(CurLegendItemData.LegendItemData.Data.Name, num2, numColor);
		if (showTextSfx)
		{
			FGUIManager.Instance.AddTextSpecialEffects(Intensify.NameCom.sfxBack, FGUIManager.Instance.uiGreen, new Vector3(((GObject)Intensify.NameCom.sfxBack).width, ((GObject)Intensify.NameCom.sfxBack).width, ((GObject)Intensify.NameCom.sfxBack).width), "Default", 0.5f, delegate(GameObject uiGreen)
			{
				UiHelper.DestoryUiSfx(Intensify.sfxBack, uiGreen, 0.5f);
			});
		}
		Intensify.Stars.GetController("ClassController").selectedIndex = CurLegendItemData.LegendItemData.Data.Rarity - 1;
		((GObject)Intensify.n38).visible = num > 0;
		((GObject)Intensify.nextAttribute).visible = num > 0;
		((GObject)Intensify.n40).visible = num > 0;
		if (CurLegendItemData.LegendItemData.MainEntries != null && CurLegendItemData.LegendItemData.MainEntries.Count > 0)
		{
			string legendItemMainPropetryKeyText = LegendItemsHelper.GetLegendItemMainPropetryKeyText(CurLegendItemData);
			((GObject)Intensify.PrimeAttribute).text = legendItemMainPropetryKeyText + LegendItemsHelper.GetLegendItemNextEnhanceLevelValue(CurLegendItemData);
			if (showProgressSfx)
			{
				FGUIManager.Instance.AddTextSpecialEffects(Intensify.PrimeAttributeSfxBack, FGUIManager.Instance.uiGreen, new Vector3(((GObject)Intensify.PrimeAttributeSfxBack).width, ((GObject)Intensify.PrimeAttributeSfxBack).width, ((GObject)Intensify.PrimeAttributeSfxBack).width), "Default", 0.5f, delegate(GameObject uiGreen)
				{
					UiHelper.DestoryUiSfx(Intensify.PrimeAttributeSfxBack, uiGreen, 0.5f);
				});
			}
			((GObject)Intensify.nextAttribute).text = LegendItemsHelper.GetLegendItemNextEnhanceLevelValue(CurLegendItemData, num2 - CurLegendItemData.LegendItemData.EnhanceLevel);
			if (showTextSfx)
			{
				FGUIManager.Instance.AddTextSpecialEffects(Intensify.sfxBack, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
				{
					UiHelper.DestoryUiSfx(Intensify.sfxBack, uiGreen, 0.5f);
				});
			}
		}
		string numColor2 = ((num > 0) ? "#AFF627" : "#F6E2B2");
		UpdateIntensifyExperienceProcess(num2 - CurLegendItemData.LegendItemData.EnhanceLevel, num, numColor2, showProgressSfx);
	}

	private void UpdateArmsList()
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		List<LegendItemUi> list = new List<LegendItemUi>();
		List<LegendItemUi> list2 = new List<LegendItemUi>();
		for (int num = totalSelectItems.Count - 1; num >= 0; num--)
		{
			LegendItemUi legendItemUi = totalSelectItems[num];
			if (legendItemUi.LegendItemData.Locked)
			{
				list.Insert(0, legendItemUi);
				totalSelectItems.RemoveAt(num);
			}
			else if (LegendItemsHelper.EquippedLegendItems.ContainsKey(legendItemUi.InstanceId.ToString()))
			{
				list2.Insert(0, legendItemUi);
				totalSelectItems.RemoveAt(num);
			}
		}
		totalSelectItems.AddRange(list2);
		totalSelectItems.AddRange(list);
		if (CurLegendItemData != null)
		{
			totalSelectItems.Remove(CurLegendItemData);
		}
		Intensify.ArmsList.itemRenderer = new ListItemRenderer(LegendItemRender);
		Intensify.ArmsList.numItems = totalSelectItems.Count;
	}

	private void LegendItemRender(int index, GObject obj)
	{
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		UI_LegendItemC uI_LegendItemC = obj as UI_LegendItemC;
		LegendItemUi legendItemUi = totalSelectItems[index];
		if (((GObject)Intensify.Details).data == null)
		{
			((GObject)uI_LegendItemC.Highlighting).visible = false;
		}
		else
		{
			((GObject)uI_LegendItemC.Highlighting).visible = legendItemUi == ((GObject)Intensify.Details).data as LegendItemUi;
		}
		bool grayed = false;
		if (LegendItemsHelper.CanUseLegendItem(legendItemUi) || CurLegendItemData.InstanceId == legendItemUi.InstanceId)
		{
			uI_LegendItemC.LoackType.selectedIndex = 1;
			if (legendItemUi.LegendItemData.Locked)
			{
				((GObject)uI_LegendItemC.Lock).visible = true;
			}
			else
			{
				((GObject)uI_LegendItemC.Lock).visible = false;
			}
			grayed = true;
		}
		else
		{
			uI_LegendItemC.LoackType.selectedIndex = 0;
		}
		((GObject)uI_LegendItemC.SelectNote).visible = currentSelectItems.Contains(legendItemUi);
		UiHelper.RenderLegendItem(uI_LegendItemC.Content, legendItemUi, UiHelper.TextColorType.Dark, textureList, -1, grayed);
		((GComponent)uI_LegendItemC.Content).GetChild("name").visible = false;
		((GObject)uI_LegendItemC).data = legendItemUi;
		((GObject)uI_LegendItemC).onClick.Set(new EventCallback1(LegendItemClick));
	}

	private void LegendItemClick(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		LegendItemUi legendItemUi = ((GObject)context.sender).data as LegendItemUi;
		if (LegendItemsHelper.CanUseLegendItem(legendItemUi) || CurLegendItemData.InstanceId == legendItemUi.InstanceId || (currentSelectItems.Count >= MaxEnhanceCostNum && currentSelectItems.IndexOf(legendItemUi) < 0))
		{
			return;
		}
		if (CurLegendItemData.LegendItemData.EnhanceLevel >= configMaxLevel)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText325") + "！" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
			return;
		}
		int totalExpNeed = maxLeveLegendItemEnhancementConfig.TotalExpNeed;
		int num = CurLegendItemData.LegendItemData.TotalGainedExp;
		for (int i = 0; i < currentSelectItems.Count; i++)
		{
			num += currentSelectItems[i].LegendItemData.TotalGainedExp + currentSelectItems[i].LegendItemData.Data.ExpProvide;
		}
		if (num >= totalExpNeed && !currentSelectItems.Contains(legendItemUi))
		{
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText325") + "！" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, ((GObject)this).sortingOrder + 1, arg3: false);
			return;
		}
		if (currentSelectItems.Contains(legendItemUi))
		{
			currentSelectItems.Remove(legendItemUi);
			((GObject)Intensify.Details).enabled = false;
			((GObject)Intensify.Details).data = null;
		}
		else
		{
			currentSelectItems.Add(legendItemUi);
			((GObject)Intensify.Details).enabled = true;
			((GObject)Intensify.Details).data = legendItemUi;
		}
		UpdateSelectList();
		UpdateArmsList();
		UpdateMutableUi(showTextSfx: true);
	}

	private void CheckLegendItemDetails(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		if (data != null)
		{
			LegendItemUi item = data as LegendItemUi;
			UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(item);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
		}
	}

	private void FiltrateLegendItems(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int num = (int)((GObject)context.sender).data;
		((GObject)Intensify.ArmsList).data = num;
		FiltrateLegendItems(num);
		UpdateArmsList();
		Intensify.filters.selectedIndex = num;
	}

	private void FiltrateLegendItems(int starNum)
	{
		totalSelectItems.Clear();
		if (starNum == 0)
		{
			totalSelectItems = ListExtensions.DeepCopy<LegendItemUi>(LegendItemsHelper.FilterLegendItemsForEnhance());
		}
		else
		{
			totalSelectItems = ListExtensions.DeepCopy<LegendItemUi>(LegendItemsHelper.FilterLegendItemsByRarity(starNum));
		}
	}

	private void UpdateIntensifyExperienceProcess(int levelAdd, int expAdd, string numColor = "#F6E2B2", bool showProgressSfx = false)
	{
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		if (((GObject)this).isDisposed)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		bool flag = false;
		if (CurLegendItemData.LegendItemData.EnhanceLevel >= configMaxLevel)
		{
			num = 0;
			num2 = 0;
			flag = true;
		}
		else
		{
			int legendItemTotalExpNeed = LegendItemsHelper.GetLegendItemTotalExpNeed(CurLegendItemData, levelAdd);
			num2 = LegendItemsHelper.GetLegendItemTotalExpNeed(CurLegendItemData, levelAdd + 1) - legendItemTotalExpNeed;
			num = CurLegendItemData.LegendItemData.TotalGainedExp + expAdd - legendItemTotalExpNeed;
		}
		if (CurLegendItemData.LegendItemData.EnhanceLevel < configMaxLevel && num2 == 0 && num == 0)
		{
			string key = ((CurLegendItemData.LegendItemData.EnhancementConfig != null) ? CurLegendItemData.LegendItemData.EnhancementConfig.ConfigId : LegendItemsHelper.GetInitEnhanceLevelConfigId(CurLegendItemData.LegendItemData.Data.Rarity));
			Dictionary<int, LegendItemEnhancementConfig> dictionary = LegendItemManager.LegendItemEnhancementConfigs[key];
			int key2 = ((CurLegendItemData.LegendItemData.EnhanceLevel + levelAdd > configMaxLevel) ? configMaxLevel : (CurLegendItemData.LegendItemData.EnhanceLevel + levelAdd));
			int expNeedFromPrevLevel = dictionary[key2].ExpNeedFromPrevLevel;
			num = (num2 = expNeedFromPrevLevel);
		}
		double num3 = (double)num / (double)num2 * 100.0;
		string text = $"[color={numColor}]{num}[/color]";
		string text2 = $"[color={numColor}]{num2}[/color]";
		((GObject)Intensify.ExperienceProcessBar.experienceIcon).visible = true;
		if (num > num2)
		{
			num3 = 100.0;
			string key3 = ((CurLegendItemData.LegendItemData.EnhancementConfig != null) ? CurLegendItemData.LegendItemData.EnhancementConfig.ConfigId : LegendItemsHelper.GetInitEnhanceLevelConfigId(CurLegendItemData.LegendItemData.Data.Rarity));
			Dictionary<int, LegendItemEnhancementConfig> dictionary2 = LegendItemManager.LegendItemEnhancementConfigs[key3];
			int key4 = ((CurLegendItemData.LegendItemData.EnhanceLevel + levelAdd > configMaxLevel) ? configMaxLevel : (CurLegendItemData.LegendItemData.EnhanceLevel + levelAdd));
			int expNeedFromPrevLevel2 = dictionary2[key4].ExpNeedFromPrevLevel;
			num += expNeedFromPrevLevel2;
			num2 += expNeedFromPrevLevel2;
			text = $"[color={numColor}]{num}[/color]";
			text2 = $"[color={numColor}]{num2}[/color]";
		}
		else if (flag)
		{
			num3 = 100.0;
			text = "";
			text2 = "";
			((GObject)Intensify.ExperienceProcessBar.experienceIcon).visible = false;
		}
		if (!showProgressSfx)
		{
			((GProgressBar)Intensify.ExperienceProcessBar).value = num3;
		}
		else
		{
			((GProgressBar)Intensify.ExperienceProcessBar).value = 0.0;
			FGUIManager.Instance.AddTextSpecialEffects(Intensify.ExperienceProcessBar.SfxBack, "exp_missile_green", new Vector3(50f, 50f, 50f), "Default", 0.5f, delegate(GameObject expMissileGreen)
			{
				UiHelper.DestoryUiSfx(Intensify.ExperienceProcessBar.SfxBack, expMissileGreen, 0.75f);
			});
			((GProgressBar)Intensify.ExperienceProcessBar).TweenValue(num3, 0.5f);
		}
		((GObject)Intensify.ExperienceProcessBar.curExperience).text = text;
		((GObject)Intensify.ExperienceProcessBar.experience).text = text2;
	}

	private void UpdateSelectList()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		((GObject)Intensify.SelectList).data = 0;
		Intensify.SelectList.itemRenderer = new ListItemRenderer(SelectItemRender);
		Intensify.SelectList.numItems = MaxEnhanceCostNum;
		RenderEnhanceCost();
	}

	private void RenderEnhanceCost()
	{
		int num = (int)((GObject)Intensify.SelectList).data;
		Dictionary<string, int> source = JsonHelper.ToObject<Dictionary<string, int>>(CurLegendItemData.LegendItemData.Data.EnhanceCostPerExp);
		KeyValuePair<string, int> keyValuePair = Enumerable.First(source);
		FGUIManager.Instance.SetItemIconAndFrame(Intensify.ConsumptionItem.Icon, keyValuePair.Key, textureList, "", frameVisible: false);
		if (num > 0)
		{
			((GObject)Intensify.ConsumptionItem.num).text = $"{GameManagers.Instance.StockController.GetStock(keyValuePair.Key).ShortNumberFormat()}/{num * keyValuePair.Value}";
		}
		else
		{
			((GObject)Intensify.ConsumptionItem.num).text = "----";
		}
	}

	private void SelectItemRender(int index, GObject obj)
	{
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		UI_LegendItemC uI_LegendItemC = obj as UI_LegendItemC;
		((GObject)uI_LegendItemC.Highlighting).visible = false;
		if (index > currentSelectItems.Count - 1)
		{
			UiHelper.RenderNoLegendItem(uI_LegendItemC.Content, textureList);
			((GObject)uI_LegendItemC).onClick.Clear();
			((GObject)uI_LegendItemC.SelectNote).visible = false;
			((GObject)uI_LegendItemC).data = null;
			return;
		}
		((GComponent)uI_LegendItemC.Content).GetChild("name").visible = false;
		LegendItemUi legendItemUi = currentSelectItems[index];
		((GObject)uI_LegendItemC.SelectNote).visible = true;
		UiHelper.RenderLegendItem(uI_LegendItemC.Content, legendItemUi, UiHelper.TextColorType.Dark, textureList);
		((GObject)uI_LegendItemC).data = legendItemUi;
		int num = (int)((GObject)Intensify.SelectList).data;
		num += legendItemUi.LegendItemData.TotalGainedExp + legendItemUi.LegendItemData.Data.ExpProvide;
		((GObject)Intensify.SelectList).data = num;
		((GObject)uI_LegendItemC).onClick.Set(new EventCallback1(ClearSelectedItem));
	}

	private void ClearSelectedItem(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		if (((GObject)context.sender).data is LegendItemUi item)
		{
			currentSelectItems.Remove(item);
			UpdateSelectList();
			UpdateArmsList();
			UpdateMutableUi();
		}
	}

	private void ClearSelectedItems()
	{
		currentSelectItems.Clear();
		UpdateSelectList();
		UpdateArmsList();
		UpdateMutableUi();
	}

	private void FillLegendItems()
	{
		if (CurLegendItemData.LegendItemData.EnhanceLevel >= configMaxLevel)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText325") + "！" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
			return;
		}
		int totalExpNeed = maxLeveLegendItemEnhancementConfig.TotalExpNeed;
		int num = (int)((GObject)Intensify.SelectList).data + CurLegendItemData.LegendItemData.TotalGainedExp;
		for (int i = 0; i < totalSelectItems.Count; i++)
		{
			if (currentSelectItems.Count >= 8)
			{
				break;
			}
			if (!LegendItemsHelper.CanUseLegendItem(totalSelectItems[i]) && !currentSelectItems.Contains(totalSelectItems[i]))
			{
				if (num >= totalExpNeed)
				{
					List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText325") + "！" };
					SharedMessenger.Broadcast("SHOW_TIPS", arg2, ((GObject)this).sortingOrder + 1, arg3: false);
					break;
				}
				num += totalSelectItems[i].LegendItemData.TotalGainedExp + totalSelectItems[i].LegendItemData.Data.ExpProvide;
				currentSelectItems.Add(totalSelectItems[i]);
			}
		}
		UpdateArmsList();
		UpdateSelectList();
		UpdateMutableUi(showTextSfx: true);
	}

	private void IntensifyClick(EventContext context)
	{
		LegendItemEnhancer legendItemEnhancer = new LegendItemEnhancer(this);
		legendItemEnhancer.EnhanceLegendItem();
	}

	public void UpdateIntensifyAfterLegendItemEnhance(List<LegendItemUi> foods)
	{
		for (int num = foods.Count - 1; num >= 0; num--)
		{
			totalSelectItems.Remove(foods[num]);
		}
		((GObject)InfoBtn).data = true;
		((GObject)PotentialBtn).data = true;
		((GObject)DegreeElevationBtn).data = true;
		((GObject)SoulStoneBtn).data = true;
		UpdateAfterIntensify();
	}

	private void UpdateCurIndex()
	{
		DataInit();
		curIndex = legendItems.IndexOf(CurLegendItemData);
		UI_LegendItemsPanel.LegendItemsPanel?.UpdateUiContent(legendItems);
	}

	private void UpdateReplace()
	{
		Replace.ResetLegendItem(CurLegendItemData);
	}

	private void UpdateReplaceBtnVisible()
	{
		bool visible = CurLegendItemData != null && CurLegendItemData.LegendItemData != null && CurLegendItemData.LegendItemData.Data != null && CurLegendItemData.LegendItemData.Data.Rarity >= 5;
		((GObject)ReplaceBtn).visible = visible;
		((GObject)ReplaceBtnLight).visible = visible;
		((GObject)ReplaceBtnDark).visible = visible;
	}

	private void DataInit()
	{
		legendItems.Clear();
		legendItems = ListExtensions.DeepCopy<LegendItemUi>(LegendItemsHelper.GetLegendItemsByRarity());
	}

	private void SwitchBtnClick()
	{
		((GObject)SwitchBtn.n6).SetPivot(0.5f, 0.5f);
		((GObject)SwitchBtn.n7).SetPivot(0.5f, 0.5f);
		lockSizeChange((GObject)(object)SwitchBtn.n6);
		lockSizeChange((GObject)(object)SwitchBtn.n7);
		LegendItemsHelper.LockLegendItem(CurLegendItemData, UpdateLockState);
	}

	public static void lockSizeChange(GObject clickarea)
	{
		EffectHelper.PlayCoroutineEffect(1f, delegate(float effectTime, float totalEffecTime)
		{
			float num = effectTime / totalEffecTime;
			float num2 = ((float)Math.Sin(num * 5f) * 0.5f + 0.5f) * 0.4f + 1f;
			clickarea.scaleX = num2;
			clickarea.scaleY = num2;
		}, delegate
		{
			clickarea.scaleX = 1f;
			clickarea.scaleY = 1f;
		});
	}

	private void UpdateLockState()
	{
		SwitchBtn.Status.selectedIndex = (CurLegendItemData.LegendItemData.Locked ? 1 : 0);
		UI_LegendItemsPanel.LegendItemsPanel?.RenderUiContent();
	}
}
