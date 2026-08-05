using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI.MonthCard;
using UI.Tips;
using UI.UpGrade;
using UI.WorkShop;
using UnityEngine;

namespace UI.Collection;

public class UI_CollectionPanel : GComponent, IUiController
{
	public GLoader background;

	public GImage n76;

	public GImage n118;

	public GImage n119;

	public GGroup backAndTexture;

	public GImage n84;

	public GImage n113;

	public GGroup rightBackAndCrack;

	public GButton backButton;

	public UI_confirm confirmButton;

	public UI_diamondButton addDiamondButton;

	public GComponent addWorkerBtn;

	public UI_Title Title;

	public GButton upButton;

	public GGroup NameAndLevel;

	public GImage station;

	public GTextField remainingStation;

	public GImage n71;

	public GTextField stationState;

	public GGroup n122;

	public GButton ExclamationMark2ndBtn;

	public GGraph stationStateSpine;

	public GGroup RemainingStation;

	public GImage backB;

	public GGraph listBack;

	public GGraph n116;

	public GImage n115;

	public GTextField tip;

	public GButton ExclamationMarkBtn;

	public GList materialShowList;

	public GList workerBackList;

	public GList workerList;

	public UI_increaseButton increaseButton;

	public UI_reduceButton reduceButton;

	public GTextField totalOutPut;

	public GTextField totalOutPutTitle;

	public GTextField totalOutPut2nd;

	public GGroup workerAndColl;

	public UI_Portal Portal;

	public GGraph spine;

	public GImage n83;

	public GLoader portalTitle;

	public GTextField introduction;

	public GGraph lookOver;

	public GImage lookOverText;

	public GGroup Transfer;

	public UI_SelectResourcePanel SelectResourcePanel;

	public GGraph workUI;

	public UI_MaterialInfoDialog MaterialInfoDialog;

	public Transition stationStateHeightLight;

	public const string URL = "ui://ehe4tm5zb8ch1h";

	public static string Name = "UI_CollectionPanel";

	private Coroutine _workerAnim;

	private global::WorkShop WorkShopBuilding;

	private Dictionary<string, ProductionConfig> ProductConfig;

	private Dictionary<string, ProductionConfig> NewProductConfig;

	private Dictionary<string, int> productStates;

	private EventCallback1 callback1;

	private EventCallback1 callback2;

	private readonly List<string> productIdList = new List<string>();

	private readonly List<string> chosenList = new List<string>();

	private List<string> chosenClone = new List<string>();

	private readonly List<string> foundList = new List<string>();

	private GoWrapper gw1;

	private GameObject canvasObject;

	private int workNumChange = 0;

	private readonly List<string> collectIconList = new List<string>
	{
		"I12002", "I12001", "I12002", "I12003", "I12004", "I12005", "I12101", "I12102", "I12103", "I12201",
		"I12202", "I12203", "I11001", "I11002", "I11002", "I11003", "I11004", "I11005", "I11101", "I11004",
		"I11101", "I11001", "I13001", "I13001", "I13002", "I13002", "I13003", "I13004", "I13005", "I13102",
		"I13103", "I13101", "I13103"
	};

	private List<string> textureList = new List<string>();

	private bool toUnloadAni;

	private HashSet<string> demandMaterialList = new HashSet<string>();

	public static string GetURL()
	{
		return "ui://ehe4tm5zb8ch1h";
	}

	public static UI_CollectionPanel CreateInstance()
	{
		return (UI_CollectionPanel)(object)UIPackage.CreateObject("Collection", "CollectionPanel");
	}

	public static UI_CollectionPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CollectionPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ehe4tm5zb8ch1h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected O, but got Unknown
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Expected O, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Expected O, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Expected O, but got Unknown
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Expected O, but got Unknown
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Expected O, but got Unknown
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Expected O, but got Unknown
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Expected O, but got Unknown
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Expected O, but got Unknown
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Expected O, but got Unknown
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Expected O, but got Unknown
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Expected O, but got Unknown
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Expected O, but got Unknown
		//IL_0565: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Expected O, but got Unknown
		//IL_0591: Unknown result type (might be due to invalid IL or missing references)
		//IL_059b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		n76 = (GImage)((GComponent)this).GetChild("n76");
		n118 = (GImage)((GComponent)this).GetChild("n118");
		n119 = (GImage)((GComponent)this).GetChild("n119");
		backAndTexture = (GGroup)((GComponent)this).GetChild("backAndTexture");
		n84 = (GImage)((GComponent)this).GetChild("n84");
		n113 = (GImage)((GComponent)this).GetChild("n113");
		rightBackAndCrack = (GGroup)((GComponent)this).GetChild("rightBackAndCrack");
		backButton = (GButton)((GComponent)this).GetChild("backButton");
		confirmButton = (UI_confirm)(object)((GComponent)this).GetChild("confirmButton");
		addDiamondButton = (UI_diamondButton)(object)((GComponent)this).GetChild("addDiamondButton");
		addWorkerBtn = (GComponent)((GComponent)this).GetChild("addWorkerBtn");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		upButton = (GButton)((GComponent)this).GetChild("upButton");
		NameAndLevel = (GGroup)((GComponent)this).GetChild("NameAndLevel");
		station = (GImage)((GComponent)this).GetChild("station");
		remainingStation = (GTextField)((GComponent)this).GetChild("remainingStation");
		string id = "ui://ehe4tm5zb8ch1h".Replace("ui://", "") + "-" + ((GObject)remainingStation).id;
		((GObject)remainingStation).text = LanguagesManager.GetDesc(id);
		n71 = (GImage)((GComponent)this).GetChild("n71");
		stationState = (GTextField)((GComponent)this).GetChild("stationState");
		string id2 = "ui://ehe4tm5zb8ch1h".Replace("ui://", "") + "-" + ((GObject)stationState).id;
		((GObject)stationState).text = LanguagesManager.GetDesc(id2);
		n122 = (GGroup)((GComponent)this).GetChild("n122");
		ExclamationMark2ndBtn = (GButton)((GComponent)this).GetChild("ExclamationMark2ndBtn");
		stationStateSpine = (GGraph)((GComponent)this).GetChild("stationStateSpine");
		RemainingStation = (GGroup)((GComponent)this).GetChild("RemainingStation");
		backB = (GImage)((GComponent)this).GetChild("backB");
		listBack = (GGraph)((GComponent)this).GetChild("listBack");
		n116 = (GGraph)((GComponent)this).GetChild("n116");
		n115 = (GImage)((GComponent)this).GetChild("n115");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id3 = "ui://ehe4tm5zb8ch1h".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id3);
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		materialShowList = (GList)((GComponent)this).GetChild("materialShowList");
		workerBackList = (GList)((GComponent)this).GetChild("workerBackList");
		workerList = (GList)((GComponent)this).GetChild("workerList");
		increaseButton = (UI_increaseButton)(object)((GComponent)this).GetChild("increaseButton");
		reduceButton = (UI_reduceButton)(object)((GComponent)this).GetChild("reduceButton");
		totalOutPut = (GTextField)((GComponent)this).GetChild("totalOutPut");
		string id4 = "ui://ehe4tm5zb8ch1h".Replace("ui://", "") + "-" + ((GObject)totalOutPut).id;
		((GObject)totalOutPut).text = LanguagesManager.GetDesc(id4);
		totalOutPutTitle = (GTextField)((GComponent)this).GetChild("totalOutPutTitle");
		string id5 = "ui://ehe4tm5zb8ch1h".Replace("ui://", "") + "-" + ((GObject)totalOutPutTitle).id;
		((GObject)totalOutPutTitle).text = LanguagesManager.GetDesc(id5);
		totalOutPut2nd = (GTextField)((GComponent)this).GetChild("totalOutPut2nd");
		string id6 = "ui://ehe4tm5zb8ch1h".Replace("ui://", "") + "-" + ((GObject)totalOutPut2nd).id;
		((GObject)totalOutPut2nd).text = LanguagesManager.GetDesc(id6);
		workerAndColl = (GGroup)((GComponent)this).GetChild("workerAndColl");
		Portal = (UI_Portal)(object)((GComponent)this).GetChild("Portal");
		spine = (GGraph)((GComponent)this).GetChild("spine");
		n83 = (GImage)((GComponent)this).GetChild("n83");
		portalTitle = (GLoader)((GComponent)this).GetChild("portalTitle");
		introduction = (GTextField)((GComponent)this).GetChild("introduction");
		lookOver = (GGraph)((GComponent)this).GetChild("lookOver");
		lookOverText = (GImage)((GComponent)this).GetChild("lookOverText");
		Transfer = (GGroup)((GComponent)this).GetChild("Transfer");
		SelectResourcePanel = (UI_SelectResourcePanel)(object)((GComponent)this).GetChild("SelectResourcePanel");
		workUI = (GGraph)((GComponent)this).GetChild("workUI");
		MaterialInfoDialog = (UI_MaterialInfoDialog)(object)((GComponent)this).GetChild("MaterialInfoDialog");
		stationStateHeightLight = ((GComponent)this).GetTransition("stationStateHeightLight");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("SortingOrder", out var value))
		{
			((GObject)this).sortingOrder = (int)value;
		}
		else
		{
			((GObject)this).sortingOrder = 1;
		}
		callback1 = new EventCallback1(OpenMaterialIntroductionPanel);
		callback2 = new EventCallback1(SelectOrCancel);
		CheckWorkersCanAssign();
		if (!parameters.ContainsKey("BuildingType"))
		{
			End();
		}
		((GObject)Portal.clickBg).visible = false;
		WorkShopBuilding = GameManagers.Instance.BuildingManager.GetBuildingByType(parameters["BuildingType"].ToString()) as global::WorkShop;
		SoldiersAndWeaponsDicInit();
		ProductConfig = WorkShopBuilding.ProductionConfigs;
		NewProductConfig = new Dictionary<string, ProductionConfig>();
		foreach (string key in ProductConfig.Keys)
		{
			NewProductConfig.Add(key, new ProductionConfig());
			NewProductConfig[key] = ProductConfig[key].Clone();
		}
		RenderMainUi();
		FontManager.RegisterFont(FontManager.GetFont("Fonts/汉仪粗黑简"), "HYCuHeiJ");
		portalTitle.url = "ui://Collection/PortalTitle_" + WorkShopBuilding.BuildingType;
		addWorkerBtn.GetChild("CurrentWorkerAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		addWorkerBtn.GetChild("separate").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		addWorkerBtn.GetChild("AllWorkerAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		((GObject)confirmButton).enabled = false;
		((GComponent)SelectResourcePanel.confirmButton).GetChild("title").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)60, (byte)72, (byte)13, (byte)153));
		((GComponent)SelectResourcePanel.concelButton).GetChild("title").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)97, (byte)7, (byte)0, (byte)153));
		SetBuildingName();
		SetBackground();
		SetSpine();
		LoadProduct();
		MaterialShowListRenderer();
		CheckUpBtnTip();
		CalculateTotalOutPut();
		((GObject)introduction).text = LanguagesManager.GetDesc("CsharpCodeZhTcText151");
		((GObject)Portal).visible = false;
		ResourcePortalInfoEvo portalInfo = WorkShopBuilding.GetPortalInfo();
		if (portalInfo != null)
		{
			int index = ((WorkShopBuilding.Level > 0) ? (WorkShopBuilding.Level - 1) : 0);
			((GObject)introduction).text = portalInfo.DescList[index];
			((GObject)Portal).visible = true;
			Portal.Icon.url = "ui://Collection/pic_portal_" + WorkShopBuilding.BuildingType;
			AssetsManager.Instance.LoadAsset<Texture2D>(portalInfo.GuiderImgList[index]).Then((Action<Texture2D>)delegate(Texture2D asset)
			{
				//IL_0017: Unknown result type (might be due to invalid IL or missing references)
				//IL_0021: Expected O, but got Unknown
				SelectResourcePanel.npc.texture = new NTexture((Texture)(object)asset);
				textureList.Add(portalInfo.GuiderImgList[index]);
			});
			((GObject)SelectResourcePanel.npcName).text = portalInfo.GuiderNameList[index];
			((GObject)SelectResourcePanel.npcWords).text = portalInfo.GuiderTipList[index];
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		((GObject)backButton).onClick.Add(new EventCallback0(BackEvent));
		((GObject)upButton).onClick.Add(new EventCallback0(UpGrade));
		((GObject)addDiamondButton.addButton).onClick.Add(new EventCallback0(AddDiamond));
		((GObject)addWorkerBtn).onClick.Add(new EventCallback0(OpenWorkerOverview));
		addWorkerBtn.GetChild("addButton").onClick.Add(new EventCallback1(AddWorker));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)ExclamationMark2ndBtn).onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)ExclamationMarkBtn).onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)Portal).onClick.Add(new EventCallback0(OpenPortal));
		((GObject)Portal.spine).onClick.Add(new EventCallback0(OpenPortal));
		Timers.inst.Add(0.2f, 0, new TimerCallback(SyncStock));
		((GObject)increaseButton).onClick.Add(new EventCallback0(increaseWorker));
		((GObject)reduceButton).onClick.Add(new EventCallback0(reduceWorker));
		((GObject)confirmButton).onClick.Add(new EventCallback1(ConfirmClick));
		((GObject)MaterialInfoDialog.clickBack).onClick.Add(new EventCallback0(CloseMaterialIntroductionPanel));
		((GObject)SelectResourcePanel.exitButton).onClick.Add(new EventCallback0(CloseSelectResourcePanel));
		((GButton)SelectResourcePanel.SelectAllBtn).onChanged.Add(new EventCallback1(SelectAllClick));
		SharedMessenger.AddListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		SharedMessenger.AddListener<string>("PRODUCT_UNLOCKED", OnProductUnlocked);
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", OnBuildingUpgraded);
		SharedMessenger.AddListener("OPEN_WORKER_OVERVIEW_PANEL", OpenWorkerOverview);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Expected O, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Expected O, but got Unknown
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		((GObject)backButton).onClick.Remove(new EventCallback0(BackEvent));
		((GObject)upButton).onClick.Remove(new EventCallback0(UpGrade));
		((GObject)addDiamondButton.addButton).onClick.Remove(new EventCallback0(AddDiamond));
		((GObject)addWorkerBtn).onClick.Remove(new EventCallback0(OpenWorkerOverview));
		addWorkerBtn.GetChild("addButton").onClick.Remove(new EventCallback1(AddWorker));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)ExclamationMark2ndBtn).onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)ExclamationMarkBtn).onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)Portal).onClick.Remove(new EventCallback0(OpenPortal));
		((GObject)Portal.spine).onClick.Remove(new EventCallback0(OpenPortal));
		Timers.inst.Remove(new TimerCallback(SyncStock));
		((GObject)increaseButton).onClick.Remove(new EventCallback0(increaseWorker));
		((GObject)reduceButton).onClick.Remove(new EventCallback0(reduceWorker));
		((GObject)confirmButton).onClick.Remove(new EventCallback1(ConfirmClick));
		((GObject)MaterialInfoDialog.clickBack).onClick.Remove(new EventCallback0(CloseMaterialIntroductionPanel));
		((GObject)SelectResourcePanel.exitButton).onClick.Remove(new EventCallback0(CloseSelectResourcePanel));
		((GButton)SelectResourcePanel.SelectAllBtn).onChanged.Remove(new EventCallback1(SelectAllClick));
		SharedMessenger.RemoveListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		SharedMessenger.RemoveListener<string>("PRODUCT_UNLOCKED", OnProductUnlocked);
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", OnBuildingUpgraded);
		SharedMessenger.RemoveListener("OPEN_WORKER_OVERVIEW_PANEL", OpenWorkerOverview);
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("CollectionPanel.AddWorkerBtn", increaseButton);
		instance.Register("CollectionPanel.ReduceWorkerBtn", reduceButton);
		instance.Register("CollectionPanel.UpgradeBtn", upButton);
		instance.Register("CollectionPanel.ConfirmDistributionBtn", confirmButton);
		instance.Register("CollectionPanel.Portal", Portal);
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		UiAudioManager.Instance.PlayBackgroundSound("Building" + WorkShopBuilding.BuildingType + "_Click");
		InitWorkerSpine();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("CollectionPanel.AddWorkerBtn", increaseButton);
		instance.Unregister("CollectionPanel.ReduceWorkerBtn", reduceButton);
		instance.Unregister("CollectionPanel.UpgradeBtn", upButton);
		instance.Unregister("CollectionPanel.ConfirmDistributionBtn", confirmButton);
		instance.Unregister("CollectionPanel.Portal", Portal);
		instance.Unregister("ResourceSelectPanel.Copper");
		instance.Unregister("ResourceSelectPanel.Marble");
		instance.Unregister("ResourceSelectPanel.Product");
		instance.Unregister("ResourceSelectPanel.ConfirmChosenBtn", SelectResourcePanel.exitButton);
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		if (_workerAnim != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_workerAnim);
		}
	}

	private void SoldiersAndWeaponsDicInit()
	{
		int num = 0;
		demandMaterialList.Clear();
		foreach (KeyValuePair<int, string> item in GameManagers.Instance.RecruitingCampDataManager.ProducingQueue)
		{
			if (num > 3)
			{
				break;
			}
			if (string.IsNullOrWhiteSpace(item.Value) || item.Value == "Unlock" || item.Value == "Lock")
			{
				continue;
			}
			foreach (string weapon in GameManagers.Instance.SoldierManager.Get(item.Value).WeaponList)
			{
				GDEProductData productByItemId = GameManagers.Instance.BuildingManager.GetProductByItemId(weapon);
				if (productByItemId == null)
				{
					continue;
				}
				List<string> list = new List<string>();
				list.Add(productByItemId.Stuff1);
				list.Add(productByItemId.Stuff2);
				list.Add(productByItemId.Stuff3);
				list.Add(productByItemId.Stuff4);
				list.Add(productByItemId.Stuff5);
				for (int i = 0; i < list.Count; i++)
				{
					if (!string.IsNullOrWhiteSpace(list[i]))
					{
						demandMaterialList.Add(list[i]);
					}
				}
			}
		}
	}

	private void SetBuildingName()
	{
		((GObject)Title.buildingName).text = WorkShopBuilding.Name ?? "";
	}

	private void CheckUpBtnTip()
	{
		((GObject)((GComponent)upButton).GetChild("redPoint").asImage).visible = WorkShopBuilding.CanUpgrade() || WorkShopBuilding.HasNewMaxLevel();
	}

	private void CalculateTotalOutPut()
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		int outPutInit;
		float num = UpdateTotalOutPut(0, out outPutInit);
		if (num > 0f)
		{
			((GObject)ExclamationMarkBtn).visible = true;
			((GObject)ExclamationMarkBtn).data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1}/{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText155"), outPutInit, LanguagesManager.GetDesc("CsharpCodeZhTcText156"))
				},
				{
					"Pos",
					(object)new Vector2(1510f, 250f)
				}
			};
		}
		else
		{
			((GObject)ExclamationMarkBtn).visible = false;
		}
	}

	private float UpdateTotalOutPut(int workerNum, out int outPutInit)
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ProductionEfficiency", new string[1] { "BuildingType" + WorkShopBuilding.BuildingType });
		float value = (float)WorkShopBuilding.ManPower * 120f * (1f + percentFloatPayload);
		((GObject)totalOutPut).text = $"{Convert.ToInt32(value)}";
		if (workerNum == 0)
		{
			((GObject)totalOutPut2nd).text = "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText156");
			totalOutPut2nd.color = Color32.op_Implicit(new Color32((byte)124, (byte)75, (byte)42, byte.MaxValue));
		}
		else if (workerNum < 0)
		{
			((GObject)totalOutPut2nd).text = string.Format("{0}/{1}", (float)(120 * workerNum) * (1f + percentFloatPayload), LanguagesManager.GetDesc("CsharpCodeZhTcText156"));
			totalOutPut2nd.color = Color32.op_Implicit(new Color32((byte)220, (byte)20, (byte)60, byte.MaxValue));
		}
		else
		{
			((GObject)totalOutPut2nd).text = string.Format("+{0}/{1}", (float)(120 * workerNum) * (1f + percentFloatPayload), LanguagesManager.GetDesc("CsharpCodeZhTcText156"));
			totalOutPut2nd.color = Color32.op_Implicit(new Color32((byte)0, (byte)167, (byte)0, byte.MaxValue));
		}
		outPutInit = Convert.ToInt32(WorkShopBuilding.ManPower * 120);
		return percentFloatPayload;
	}

	private void RenderMaterialItem(int index, GObject obj)
	{
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		GButton asButton = obj.asButton;
		if (((GObject)obj.parent).name == "materialShowList")
		{
			string key = chosenList[index];
			GDEProductData gDEProductData = GDMgr.Get<GDEProductData>(key);
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(gDEProductData.ItemId);
			int itemLevel = GameManagers.Instance.UserArchiveManager.GetItemLevel(gDEProductData.ItemId);
			((GComponent)asButton).GetChild("frame").asLoader.url = $"ui://PublicResources/kuang_round 2_lv{itemLevel}";
			string iconPath = UiHelper.GetIconPath(gDEItemData.Icon);
			((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + iconPath;
			asButton.title = gDEItemData.Name;
			((GObject)((GComponent)asButton).GetChild("selectedNote").asImage).visible = false;
			((GObject)((GComponent)asButton).GetChild("notFoundNote").asTextField).visible = false;
			((GObject)asButton).onClick.Set(callback1);
		}
		else if (((GObject)obj.parent).name == "materialSelectList")
		{
			string text = productIdList[index];
			GDEProductData gDEProductData2 = GDMgr.Get<GDEProductData>(text);
			GDEItemData gDEItemData2 = GDMgr.Get<GDEItemData>(gDEProductData2.ItemId);
			int itemLevel2 = GameManagers.Instance.UserArchiveManager.GetItemLevel(gDEProductData2.ItemId);
			((GComponent)asButton).GetChild("recruitmentMark").visible = false;
			if (demandMaterialList.Contains(gDEProductData2.ItemId))
			{
				((GComponent)asButton).GetChild("recruitmentMark").visible = true;
			}
			if (!foundList.Contains(text))
			{
				((GObject)((GComponent)asButton).GetChild("notFound").asTextField).visible = true;
				((GComponent)asButton).GetChild("icon").asLoader.url = "";
				((GComponent)asButton).GetChild("frame").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorder(2);
				((GObject)((GComponent)asButton).GetChild("title").asTextField).visible = false;
				((GObject)((GComponent)asButton).GetChild("num").asTextField).visible = false;
				((GObject)((GComponent)asButton).GetChild("selectedNote").asImage).visible = false;
				((GObject)((GComponent)asButton).GetChild("notFoundNote").asTextField).visible = true;
				((GComponent)asButton).GetChild("notFoundNote").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
				((GObject)asButton).grayed = true;
				((GObject)asButton).touchable = false;
			}
			else
			{
				((GObject)asButton).grayed = false;
				((GObject)asButton).touchable = true;
				asButton.title = gDEItemData2.Name;
				((GObject)((GComponent)asButton).GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock(gDEItemData2.Key).ToString();
				string iconPath2 = UiHelper.GetIconPath(gDEItemData2.Icon);
				((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + iconPath2;
				((GComponent)asButton).GetChild("frame").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorder(2, itemLevel2);
				((GComponent)asButton).GetChild("title").asTextField.color = Color32.op_Implicit(UiHelper.GetColorByItemLevel(itemLevel2));
				((GObject)((GComponent)asButton).GetChild("num").asTextField).visible = true;
				((GObject)((GComponent)asButton).GetChild("title").asTextField).visible = true;
				((GObject)((GComponent)asButton).GetChild("notFound").asTextField).visible = false;
				((GObject)((GComponent)asButton).GetChild("notFoundNote").asTextField).visible = false;
				((GObject)((GComponent)asButton).GetChild("selectedNote").asImage).visible = chosenList.Contains(text);
				((GObject)asButton).onClick.Set(callback2);
			}
		}
	}

	private void MaterialShowListRenderer()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		materialShowList.itemRenderer = new ListItemRenderer(RenderMaterialItem);
		materialShowList.numItems = chosenList.Count;
		if (materialShowList.numItems == 0)
		{
			((GObject)tip).visible = true;
		}
		else
		{
			((GObject)tip).visible = false;
		}
		if (materialShowList.numItems != 0)
		{
			materialShowList.ScrollToView(0);
		}
	}

	private void WorkerListRenderer()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		workerList.itemRenderer = new ListItemRenderer(RenderWorkerIncrease);
		workerList.numItems = WorkShopBuilding.ManPower;
	}

	private void WorkerBackListRenderer()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		workerBackList.itemRenderer = new ListItemRenderer(RenderWorkerReduce);
		workerBackList.numItems = WorkShopBuilding.ManPower;
	}

	private void RenderWorkerReduce(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		((GObject)((GComponent)asButton).GetChild("reduce").asImage).visible = true;
	}

	private void RenderWorkerIncrease(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		int manPower = WorkShopBuilding.ManPower;
		if (index < manPower)
		{
			((GObject)((GComponent)asButton).GetChild("normal").asImage).visible = true;
			((GObject)((GComponent)asButton).GetChild("increase").asImage).visible = false;
		}
		else
		{
			((GObject)((GComponent)asButton).GetChild("normal").asImage).visible = true;
			((GObject)((GComponent)asButton).GetChild("increase").asImage).visible = true;
		}
	}

	private void MaterialSelectListRenderer()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		SelectResourcePanel.materialSelectList.numItems = 0;
		SelectResourcePanel.materialSelectList.itemRenderer = new ListItemRenderer(RenderMaterialItem);
		SelectResourcePanel.materialSelectList.numItems = productIdList.Count;
		if (SelectResourcePanel.materialSelectList.numItems != 0)
		{
			SelectResourcePanel.materialSelectList.ScrollToView(0);
		}
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("ResourceSelectPanel.Product");
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		for (int i = 0; i < productIdList.Count; i++)
		{
			string text = productIdList[i];
			GObject childAt = ((GComponent)SelectResourcePanel.materialSelectList).GetChildAt(i);
			if (text == "P11001")
			{
				instance.Register("ResourceSelectPanel.Copper", childAt);
			}
			else if (text == "P11201")
			{
				instance.Register("ResourceSelectPanel.Marble", childAt);
			}
			dictionary.Add(text, childAt);
		}
		instance.Register("ResourceSelectPanel.Product", dictionary);
		instance.Register("ResourceSelectPanel.ConfirmChosenBtn", SelectResourcePanel.exitButton);
	}

	private void OnProductUnlocked(string productId)
	{
		Dictionary<string, int> dictionary = WorkShopBuilding.GetProductStates(true);
		if (dictionary.ContainsKey(productId) && !foundList.Contains(productId))
		{
			foundList.Add(productId);
		}
		if (((GObject)SelectResourcePanel).visible)
		{
			SelectResourcePanelInit();
		}
	}

	private void OnBuildingUpgraded(string buildingType, int level)
	{
		CheckUpBtnTip();
		if (buildingType == WorkShopBuilding.BuildingType)
		{
			RenderMainUi();
		}
	}

	private void ApplyAssignationAsync(CustomTaskCompletionSource<bool> taskCompletionSource = null)
	{
		ILRequestHelper<ChangeWorkshopProduceConfigResponse>.Request(taskCompletionSource, delegate
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			Dictionary<int, List<string>> dictionary2 = new Dictionary<int, List<string>>();
			foreach (KeyValuePair<string, ProductionConfig> item in NewProductConfig)
			{
				int key = int.Parse(item.Key);
				dictionary.Add(key, item.Value.Workers);
				dictionary2.Add(key, item.Value.ProductList);
			}
			return GameController.Contexts.Service<INetworkService>().ChangeWorkshopProduceConfig(1L, WorkShopBuilding.BuildingType, dictionary, dictionary2);
		}, delegate(ChangeWorkshopProduceConfigResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				UiAudioManager.Instance.PlaySoundEffect("Confirm");
				GameManagers.Instance.StockController.NeedSyncProduce = true;
				if (NewProductConfig.Count > 0)
				{
					foreach (ProductionConfig value in NewProductConfig.Values)
					{
						value.ProductList = ListExtensions.DeepCopy<string>(chosenList);
					}
				}
				else
				{
					NewProductConfig.Add("0", new ProductionConfig
					{
						Workers = 0,
						ProductList = ListExtensions.DeepCopy<string>(chosenList)
					});
				}
				Dictionary<string, ProductionConfig> dictionary = new Dictionary<string, ProductionConfig>();
				foreach (string key2 in NewProductConfig.Keys)
				{
					dictionary.Add(key2, new ProductionConfig());
					dictionary[key2] = NewProductConfig[key2].Clone();
				}
				SharedMessenger.Broadcast("PRODUCTION_CONFIG_CHANGED", (Building)WorkShopBuilding, dictionary);
				SharedMessenger.Broadcast("WORKERS_ALLOCATION_DISPLAY_CHANGED", (Building)WorkShopBuilding);
				foreach (ProductionConfig value2 in NewProductConfig.Values)
				{
					if (value2.ProductList.Count > 0)
					{
						ThinkingDataHelper.Instance.BulidingMakeTrack(WorkShopBuilding.BuildingType, WorkShopBuilding.Level, value2.ProductList.ToList(), WorkShopBuilding.ManPower);
						break;
					}
				}
				End();
			}
		});
	}

	private void ConfirmClick(EventContext eventContext)
	{
		CustomTaskCompletionSource<bool> taskCompletionSource = eventContext.data as CustomTaskCompletionSource<bool>;
		bool flag = NewProductConfig == null || NewProductConfig.Count < 1 || GetNewAssignedWorkers() < 1 || !NewProductConfig.Values.Any((ProductionConfig productConfig) => productConfig.ProductList.Count > 0);
		if (taskCompletionSource != null)
		{
			taskCompletionSource.IsAsync = true;
		}
		if (flag)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					LanguagesManager.GetDesc("CsharpCodeZhTcText157") + WorkShopBuilding.Name + LanguagesManager.GetDesc("CsharpCodeZhTcText158") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText144") + "？"
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								ApplyAssignationAsync(taskCompletionSource);
							}
						},
						{
							"Cancel",
							delegate
							{
								taskCompletionSource?.SetResult(result: true);
							}
						}
					}
				},
				{ "PageIndex", 0 },
				{ "ClickSound", "Confirm" },
				{
					"Order",
					((GObject)this).sortingOrder
				},
				{ "FGUI_TouchEnable", true }
			});
		}
		else
		{
			ApplyAssignationAsync(taskCompletionSource);
		}
	}

	private void OpenPortal()
	{
		SelectResourcePanelInit();
		((GObject)SelectResourcePanel).visible = true;
		SelectResourcePanel.showUp.Play();
	}

	private void UpGrade()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Parent", this);
		dictionary.Add("Building", WorkShopBuilding);
		dictionary.Add("SortingOrder", ((GObject)this).sortingOrder);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary);
	}

	private void AddWorker(EventContext context)
	{
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MonthCardPanel.Name, new Dictionary<string, object>
			{
				{
					"Activity",
					FGUIManager.Instance.GetBlackMarketerActivity("UI_MonthCardPanel")
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
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
		}
		context.StopPropagation();
	}

	private void OpenWorkerOverview()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Order", ((GObject)this).sortingOrder);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorkersOverviewPanel.Name, dictionary);
	}

	private void AddDiamond()
	{
	}

	private int GetCurrentAvailableWorkers()
	{
		Dungeon value = GameController.Contexts.game.dungeon.value;
		return Dungeon.GetFreeManPower(GameManagers.Instance) - (GetNewAssignedWorkers() - WorkShopBuilding.ManPower);
	}

	private int GetNewAssignedWorkers()
	{
		return NewProductConfig.Values.Sum((ProductionConfig productConfig) => productConfig.Workers);
	}

	private void PlayOperateFX(Queue<Transition> fxPlayList, Queue<Action> tipPlayList)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		if (fxPlayList.Count > 0)
		{
			Transition val = fxPlayList.Dequeue();
			Action action = null;
			if (tipPlayList.Count > 0)
			{
				action = tipPlayList.Dequeue();
			}
			val.Play((PlayCompleteCallback)delegate
			{
				PlayOperateFX(fxPlayList, tipPlayList);
			});
			action?.Invoke();
		}
	}

	private ProductionConfig GetNewProductionConfigAt(int index)
	{
		if (index < NewProductConfig.Count)
		{
			return NewProductConfig[index.ToString()];
		}
		if (index >= ((WorkshopController)WorkShopBuilding.Controller).WorkbenchNominal.Length)
		{
			return null;
		}
		for (int i = NewProductConfig.Count; i <= index; i++)
		{
			NewProductConfig.Add(i.ToString(), new ProductionConfig
			{
				Workers = 0,
				ProductList = new List<string>()
			});
		}
		return NewProductConfig[index.ToString()];
	}

	private void increaseWorker()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		((GObject)confirmButton).enabled = true;
		workerList.itemRenderer = new ListItemRenderer(RenderWorkerIncrease);
		int num = WorkShopBuilding.Slot + WorkShopBuilding.LeaseholdSlot;
		int newAssignedWorkers = GetNewAssignedWorkers();
		int currentAvailableWorkers = GetCurrentAvailableWorkers();
		if (newAssignedWorkers < num && currentAvailableWorkers > 0)
		{
			bool flag = false;
			for (int i = 0; i < WorkShopBuilding.Slot; i++)
			{
				ProductionConfig newProductionConfigAt = GetNewProductionConfigAt(i);
				if (newProductionConfigAt.Workers < 1)
				{
					newProductionConfigAt.Workers = 1;
					newProductionConfigAt.ProductList.Clear();
					newProductionConfigAt.ProductList.AddRange(ListExtensions.DeepCopy<string>(chosenList));
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				for (int j = 0; j < WorkShopBuilding.LeaseholdSlot; j++)
				{
					int index = ((WorkshopController)WorkShopBuilding.Controller).WorkbenchNominal.Length - 1 - j;
					ProductionConfig newProductionConfigAt2 = GetNewProductionConfigAt(index);
					if (newProductionConfigAt2.Workers < 1)
					{
						newProductionConfigAt2.Workers = 1;
						newProductionConfigAt2.ProductList.Clear();
						newProductionConfigAt2.ProductList.AddRange(chosenList);
						break;
					}
				}
			}
			workerList.numItems += 1;
			((GComponent)((GComponent)workerList).GetChildAt(workerList.numItems - 1).asButton).GetTransition("increase").Play();
			addWorkerBtn.GetChild("CurrentWorkerAmount").text = GetCurrentAvailableWorkers().ToString();
			((GObject)stationStateSpine).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(stationStateSpine, FGUIManager.Instance.uiGreen, Vector3.zero);
			addWorkerBtn.GetChild("workerButtonSpine").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addWorkerBtn.GetChild("workerButtonSpine").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
		}
		else
		{
			Queue<Transition> queue = new Queue<Transition>();
			Queue<Action> queue2 = new Queue<Action>();
			if (currentAvailableWorkers <= 0)
			{
				Transition transition = addWorkerBtn.GetTransition("textHeoghtLight");
				if (transition.playing)
				{
					transition.Stop();
				}
				queue.Enqueue(transition);
				queue2.Enqueue(delegate
				{
					//IL_0040: Unknown result type (might be due to invalid IL or missing references)
					addWorkerBtn.GetChild("workerButtonSpine").displayObject.Dispose();
					FGUIManager.Instance.AddTextSpecialEffects(addWorkerBtn.GetChild("workerButtonSpine").asGraph, FGUIManager.Instance.uiRed, Vector3.zero);
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText159") + "！" };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 5, arg3: false);
				});
			}
			if (newAssignedWorkers >= num)
			{
				if (stationStateHeightLight.playing)
				{
					stationStateHeightLight.Stop();
				}
				queue.Enqueue(stationStateHeightLight);
				queue2.Enqueue(delegate
				{
					//IL_0027: Unknown result type (might be due to invalid IL or missing references)
					((GObject)stationStateSpine).displayObject.Dispose();
					FGUIManager.Instance.AddTextSpecialEffects(stationStateSpine, FGUIManager.Instance.uiRed, Vector3.zero);
					List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText160") + "！" };
					SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 5, arg3: false);
				});
			}
			PlayOperateFX(queue, queue2);
		}
		int newAssignedWorkers2 = GetNewAssignedWorkers();
		GetWorkingStatus(num - newAssignedWorkers2, WorkShopBuilding.Slot, WorkShopBuilding.LeaseholdSlot);
		UpdateTotalOutPut(workerList.numItems - WorkShopBuilding.ManPower, out var _);
	}

	private void reduceWorker()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		((GObject)confirmButton).enabled = true;
		workerList.itemRenderer = new ListItemRenderer(RenderWorkerIncrease);
		int availableWorkbenches = WorkShopBuilding.Slot + WorkShopBuilding.LeaseholdSlot;
		int newAssignedWorkers = GetNewAssignedWorkers();
		if (newAssignedWorkers > 0)
		{
			Transition transition = ((GComponent)((GComponent)workerList).GetChildAt(workerList.numItems - 1).asButton).GetTransition("reduce");
			if (transition.playing)
			{
				return;
			}
			for (int num = ((WorkshopController)WorkShopBuilding.Controller).WorkbenchNominal.Length - 1; num >= 0; num--)
			{
				ProductionConfig newProductionConfigAt = GetNewProductionConfigAt(num);
				if (newProductionConfigAt.Workers > 0)
				{
					newProductionConfigAt.Workers = 0;
					break;
				}
			}
			transition.Play((PlayCompleteCallback)delegate
			{
				workerList.numItems -= 1;
				UpdateTotalOutPut(workerList.numItems - WorkShopBuilding.ManPower, out var _);
				addWorkerBtn.GetChild("CurrentWorkerAmount").text = GetCurrentAvailableWorkers().ToString();
				GetWorkingStatus(availableWorkbenches - GetNewAssignedWorkers(), WorkShopBuilding.Slot, WorkShopBuilding.LeaseholdSlot);
			});
		}
		else
		{
			GetWorkingStatus(availableWorkbenches - GetNewAssignedWorkers(), WorkShopBuilding.Slot, WorkShopBuilding.LeaseholdSlot);
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText161") + "！" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 5, arg3: false);
		}
		((GObject)stationStateSpine).displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(stationStateSpine, FGUIManager.Instance.uiGreen, Vector3.zero);
		addWorkerBtn.GetChild("workerButtonSpine").displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(addWorkerBtn.GetChild("workerButtonSpine").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
	}

	private void CloseSelectResourcePanel()
	{
		ReSetChosenList();
		((GObject)SelectResourcePanel).visible = false;
	}

	private void ConfirmSelection()
	{
		((GObject)confirmButton).enabled = true;
		for (int i = 0; i < SelectResourcePanel.materialSelectList.numItems; i++)
		{
			if (!((GObject)((GComponent)((GComponent)SelectResourcePanel.materialSelectList).GetChildAt(i).asButton).GetChild("notFoundNote").asTextField).visible)
			{
				((GObject)((GComponent)((GComponent)SelectResourcePanel.materialSelectList).GetChildAt(i).asButton).GetChild("selectedNote").asImage).visible = true;
			}
		}
		((GObject)SelectResourcePanel.confirmButton).grayed = true;
		((GObject)SelectResourcePanel.confirmButton).touchable = false;
		((GObject)SelectResourcePanel.concelButton).grayed = false;
		((GObject)SelectResourcePanel.concelButton).touchable = true;
	}

	private void ReSetChosenList()
	{
		for (int i = 0; i < SelectResourcePanel.materialSelectList.numItems; i++)
		{
			if (((GObject)((GComponent)((GComponent)SelectResourcePanel.materialSelectList).GetChildAt(i).asButton).GetChild("selectedNote").asImage).visible)
			{
				if (!chosenList.Contains(productIdList[i]))
				{
					chosenList.Add(productIdList[i]);
				}
			}
			else if (chosenList.Contains(productIdList[i]))
			{
				chosenList.Remove(productIdList[i]);
			}
		}
		foreach (ProductionConfig value in NewProductConfig.Values)
		{
			value.ProductList = ListExtensions.DeepCopy<string>(chosenList);
		}
		MaterialShowListRenderer();
	}

	private void CancelAllOfItems()
	{
		((GObject)confirmButton).enabled = true;
		for (int i = 0; i < SelectResourcePanel.materialSelectList.numItems; i++)
		{
			((GObject)((GComponent)((GComponent)SelectResourcePanel.materialSelectList).GetChildAt(i).asButton).GetChild("selectedNote").asImage).visible = false;
		}
		((GObject)SelectResourcePanel.concelButton).grayed = true;
		((GObject)SelectResourcePanel.concelButton).touchable = false;
		((GObject)SelectResourcePanel.confirmButton).grayed = false;
		((GObject)SelectResourcePanel.confirmButton).touchable = true;
	}

	private void SelectAllClick(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		((GObject)confirmButton).enabled = true;
		GButton val = (GButton)context.sender;
		if (val.selected)
		{
			for (int i = 0; i < SelectResourcePanel.materialSelectList.numItems; i++)
			{
				if (!((GObject)((GComponent)((GComponent)SelectResourcePanel.materialSelectList).GetChildAt(i).asButton).GetChild("notFoundNote").asTextField).visible)
				{
					((GObject)((GComponent)((GComponent)SelectResourcePanel.materialSelectList).GetChildAt(i).asButton).GetChild("selectedNote").asImage).visible = true;
				}
			}
			SelectResourcePanel.SelectAllBtn.SetControllerPageText(1);
		}
		else
		{
			for (int j = 0; j < SelectResourcePanel.materialSelectList.numItems; j++)
			{
				((GObject)((GComponent)((GComponent)SelectResourcePanel.materialSelectList).GetChildAt(j).asButton).GetChild("selectedNote").asImage).visible = false;
			}
			SelectResourcePanel.SelectAllBtn.SetControllerPageText(0);
		}
	}

	private void SelectOrCancel(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GButton val = (GButton)context.sender;
		GImage asImage = ((GComponent)val).GetChild("selectedNote").asImage;
		int childIndex = ((GComponent)SelectResourcePanel.materialSelectList).GetChildIndex((GObject)(object)val);
		string text = productIdList[childIndex];
		((GObject)confirmButton).enabled = true;
		((GObject)asImage).visible = !((GObject)asImage).visible;
		for (int i = 0; i < SelectResourcePanel.materialSelectList.numItems; i++)
		{
			if (!((GObject)((GComponent)((GComponent)SelectResourcePanel.materialSelectList).GetChildAt(i).asButton).GetChild("selectedNote").asImage).visible && !((GComponent)SelectResourcePanel.materialSelectList).GetChildAt(i).grayed)
			{
				((GButton)SelectResourcePanel.SelectAllBtn).selected = false;
				break;
			}
			if (i == SelectResourcePanel.materialSelectList.numItems - 1)
			{
				((GButton)SelectResourcePanel.SelectAllBtn).selected = true;
			}
		}
	}

	private void CloseMaterialIntroductionPanel()
	{
		((GObject)MaterialInfoDialog).visible = false;
	}

	private void OpenMaterialIntroductionPanel(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		GButton val = (GButton)context.sender;
		Vector2 val2 = ((GObject)materialShowList).LocalToGlobal(Vector2.zero);
		val2 = ((GObject)this).GlobalToLocal(val2);
		Vector2 val3 = ((GObject)val).LocalToGlobal(Vector2.zero);
		val3 = ((GObject)this).GlobalToLocal(val3);
		Vector2 val4 = default(Vector2);
		((Vector2)(ref val4))._002Ector(val2.x - 53f, val3.y);
		GDEProductData gDEProductData = GDMgr.Get<GDEProductData>(chosenList[((GComponent)materialShowList).GetChildIndex((GObject)(object)val)]);
		Dictionary<string, object> dictionary = new Dictionary<string, object> { { "ItemId", gDEProductData.ItemId } };
		GDEProductData productByItemId = GameManagers.Instance.BuildingManager.GetProductByItemId(gDEProductData.ItemId);
		if (productByItemId == null)
		{
			dictionary.Add("HideCheckBtn", true);
		}
		else if (!BuildingManager.Products.ContainsKey(productByItemId.Key))
		{
			dictionary.Add("HideCheckBtn", true);
		}
		else
		{
			bool flag = true;
			dictionary.Add("HideCheckBtn", true);
		}
		dictionary.Add("Pos", val4);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_MaterialIntroductionPanel.Name, dictionary);
	}

	private void SetBackground()
	{
		if (WorkShopBuilding.BuildingType == "1")
		{
			((GObject)Portal.imageGroup1).visible = true;
			((GObject)Portal.imageGroup2).visible = false;
			((GObject)Portal.imageGroup3).visible = false;
		}
		else if (WorkShopBuilding.BuildingType == "2")
		{
			((GObject)Portal.imageGroup1).visible = false;
			((GObject)Portal.imageGroup2).visible = true;
			((GObject)Portal.imageGroup3).visible = false;
		}
		else if (WorkShopBuilding.BuildingType == "3")
		{
			((GObject)Portal.imageGroup1).visible = false;
			((GObject)Portal.imageGroup2).visible = false;
			((GObject)Portal.imageGroup3).visible = true;
		}
		else
		{
			((GObject)Portal.imageGroup1).visible = true;
			((GObject)Portal.imageGroup2).visible = false;
			((GObject)Portal.imageGroup3).visible = false;
		}
	}

	private void SetSpine()
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		string prefabName = "ui_portal_earthdoor";
		switch (WorkShopBuilding.BuildingType)
		{
		case "1":
			Portal.UpAndDownEarth.Play();
			prefabName = "ui_portal_earthdoor";
			break;
		case "2":
			Portal.UpAndDownWind.Play();
			prefabName = "ui_portal_winddoor";
			break;
		case "3":
			Portal.UpAndDownWater.Play();
			prefabName = "ui_portal_waterdoor";
			break;
		}
		GameObject val = SpawnManager.Instance.InstantiatePool(prefabName, Vector3.zero, 1);
		if (!((Object)(object)val == (Object)null))
		{
			val.GetComponent<Renderer>().sortingLayerName = "Default";
			for (int i = 0; i < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; i++)
			{
				((Component)val.transform).GetComponentsInChildren<Renderer>()[i].sortingLayerName = "Default";
			}
			val.transform.localPosition = new Vector3(0f, 0f, 100f);
			val.transform.localScale = new Vector3(100f, 100f, 100f);
			GoWrapper val2 = new GoWrapper(val);
			((DisplayObject)val2).SetXY(0f, 0f);
			((DisplayObject)val2).pivot = new Vector2(0.5f, 0.5f);
			((GObject)Portal.spine).visible = true;
			Portal.spine.SetNativeObject((DisplayObject)(object)val2);
		}
	}

	private void InitWorkerSpine()
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)canvasObject != (Object)null)
		{
			return;
		}
		ref GameObject reference = ref canvasObject;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		SpawnManager.Instance.LoadAnimation("Goblinworker_UI_001").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				toUnloadAni = true;
				SkeletonAnimation component = canvasObject.GetComponent<SkeletonAnimation>();
				if ((Object)(object)component != (Object)null && (Object)(object)asset != (Object)null)
				{
					((SkeletonRenderer)component).skeletonDataAsset = asset;
					((SkeletonRenderer)component).Initialize(true);
					string idleAnim = "portal_idle";
					List<string> workAnims = new List<string> { "portal_work1", "portal_work2" };
					SpineHelper.SetSkin((ISkeletonAnimation)(object)component, "skin_portal");
					_workerAnim = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(UI_WorkShopPanel.WorkerAnimation(component, idleAnim, workAnims));
				}
			}
		});
		if ((Object)(object)canvasObject != (Object)null)
		{
			canvasObject.transform.localScale = new Vector3(80f, 80f, 80f);
			canvasObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
			canvasObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			gw1 = new GoWrapper(canvasObject);
			((DisplayObject)gw1).SetXY(0f, 0f);
			((DisplayObject)gw1).pivot = new Vector2(0.5f, 0.5f);
			((DisplayObject)gw1).scaleX = 1f;
			workUI.SetNativeObject((DisplayObject)(object)gw1);
		}
	}

	private void BackEvent()
	{
		if (WorkShopBuilding.CheckNewProductionConfigsChange(NewProductConfig))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					LanguagesManager.GetDesc("CsharpCodeZhTcText162") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText163") + "？"
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								((GObject)confirmButton).onClick.Call();
							}
						},
						{
							"Cancel",
							delegate
							{
								End();
							}
						}
					}
				},
				{ "PageIndex", 0 },
				{ "ClickSound", "Confirm" },
				{
					"Order",
					((GObject)this).sortingOrder
				},
				{ "FGUI_TouchEnable", true }
			});
		}
		else
		{
			End();
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		if (toUnloadAni)
		{
			SpawnManager.Instance.UnloadAnimation("Goblinworker_UI_001");
		}
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void SyncStock(object parameter)
	{
		int limit = GameManagers.Instance.StockController.GetLimit(StockCategory.Material);
		if (((GObject)SelectResourcePanel).visible)
		{
			for (int i = 0; i < productIdList.Count; i++)
			{
				GDEProductData gDEProductData = GDMgr.Get<GDEProductData>(productIdList[i]);
				((GObject)((GComponent)((GComponent)SelectResourcePanel.materialSelectList).GetChildAt(i).asButton).GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock(gDEProductData.ItemId).ToString();
				int stock = GameManagers.Instance.StockController.GetStock(gDEProductData.ItemId);
				int num = ((stock >= limit) ? 1 : 0);
				((GComponent)((GComponent)SelectResourcePanel.materialSelectList).GetChildAt(i).asButton).GetChild("max").alpha = num;
			}
		}
		if (chosenList.Count != 0 && !((GObject)SelectResourcePanel).visible)
		{
			for (int j = 0; j < chosenList.Count; j++)
			{
				GDEProductData gDEProductData2 = GDMgr.Get<GDEProductData>(chosenList[j]);
				((GObject)((GComponent)((GComponent)materialShowList).GetChildAt(j).asButton).GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock(gDEProductData2.ItemId).ToString();
				int stock2 = GameManagers.Instance.StockController.GetStock(gDEProductData2.ItemId);
				int num2 = ((stock2 >= limit) ? 1 : 0);
				((GComponent)((GComponent)materialShowList).GetChildAt(j).asButton).GetChild("max").alpha = num2;
			}
		}
	}

	private void SelectResourcePanelInit()
	{
		((GObject)SelectResourcePanel.npcGroup).alpha = 0f;
		((GObject)SelectResourcePanel.npcWords).SetScale(0f, 0f);
		((GObject)SelectResourcePanel.tipBack).SetScale(0.4f, 0.4f);
		MaterialSelectListRenderer();
		SelectResourcePanel.title.url = "ui://Collection/PortalSelectRecourceTitle_" + WorkShopBuilding.BuildingType;
		for (int i = 0; i < SelectResourcePanel.materialSelectList.numItems; i++)
		{
			if (!((GObject)((GComponent)((GComponent)SelectResourcePanel.materialSelectList).GetChildAt(i).asButton).GetChild("selectedNote").asImage).visible && !((GComponent)SelectResourcePanel.materialSelectList).GetChildAt(i).grayed)
			{
				((GButton)SelectResourcePanel.SelectAllBtn).selected = false;
				break;
			}
			if (i == SelectResourcePanel.materialSelectList.numItems - 1)
			{
				((GButton)SelectResourcePanel.SelectAllBtn).selected = true;
			}
		}
	}

	private void TitleInit()
	{
		Title.icon.url = "ui://PublicResources/Building" + WorkShopBuilding.BuildingType;
		((GObject)((GComponent)upButton).GetChild("level").asTextField).text = WorkShopBuilding.Level.ToString();
	}

	public void CheckWorkersCanAssign()
	{
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		Dungeon value = GameController.Contexts.game.dungeon.value;
		addWorkerBtn.GetChild("CurrentWorkerAmount").text = Dungeon.GetFreeManPower(GameManagers.Instance).ToString();
		addWorkerBtn.GetChild("AllWorkerAmount").text = Dungeon.GetTotalManPower(GameManagers.Instance).ToString();
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower() > 0)
		{
			addWorkerBtn.GetChild("AllWorkerAmount").asTextField.color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
			addWorkerBtn.GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText153") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText164"), Dungeon.GetTotalManPower(GameManagers.Instance) - GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower())
				},
				{
					"Pos",
					(object)new Vector2(1718f, 88f)
				}
			};
			addWorkerBtn.GetChild("ExclamationMarkBtn").visible = true;
		}
		else
		{
			addWorkerBtn.GetChild("AllWorkerAmount").asTextField.color = Color32.op_Implicit(new Color32((byte)243, (byte)221, (byte)170, byte.MaxValue));
			addWorkerBtn.GetChild("ExclamationMarkBtn").visible = false;
		}
	}

	private void UpdateWorkerNum(Building building)
	{
		CheckWorkersCanAssign();
		if (building.BuildingType == WorkShopBuilding.BuildingType)
		{
			UpdateMainUi();
		}
	}

	private void UpdateMainUi()
	{
		SoldiersAndWeaponsDicInit();
		ProductConfig = WorkShopBuilding.ProductionConfigs;
		NewProductConfig = new Dictionary<string, ProductionConfig>();
		foreach (string key in ProductConfig.Keys)
		{
			NewProductConfig.Add(key, new ProductionConfig());
			NewProductConfig[key] = ProductConfig[key].Clone();
		}
		RenderMainUi();
		((GObject)confirmButton).enabled = false;
		LoadProduct();
		MaterialShowListRenderer();
		CalculateTotalOutPut();
	}

	private void GetWorkingStatus(int a, int b, int c)
	{
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		((GObject)stationState).text = $"{a}/{b}";
		if (c > 0)
		{
			((GObject)stationState).text = $"{a}/{b}[color=#AFF627]+{c}[/color]";
			((GObject)ExclamationMark2ndBtn).visible = true;
			((GObject)ExclamationMark2ndBtn).data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText165"), WorkShopBuilding.Slot)
				},
				{
					"Content1",
					string.Format("  {0} +{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText166"), WorkShopBuilding.Slot)
				},
				{
					"Content2",
					string.Format("  {0} [color=#AFF627]+{1}[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText167"), WorkShopBuilding.LeaseholdSlot)
				},
				{
					"Pos",
					(object)new Vector2(368f, 810f)
				}
			};
		}
		else
		{
			((GObject)stationState).text = $"{a}/{b}";
			((GObject)ExclamationMark2ndBtn).visible = false;
		}
	}

	public void RenderMainUi()
	{
		GetWorkingStatus(WorkShopBuilding.Slot + WorkShopBuilding.LeaseholdSlot - WorkShopBuilding.ManPower, WorkShopBuilding.Slot, WorkShopBuilding.LeaseholdSlot);
		WorkerListRenderer();
		WorkerBackListRenderer();
		((GObject)Portal.clickBg).alpha = 0f;
		TitleInit();
	}

	private void LoadProduct()
	{
		productIdList.Clear();
		foundList.Clear();
		productStates = WorkShopBuilding.GetProductStates(true, ProductFilter.ShowUp, ProductFilter.Normal);
		List<string> unlockedProducts = GameManagers.Instance.UserArchiveManager.GetUnlockedProducts();
		foreach (string key in productStates.Keys)
		{
			if (BuildingManager.Products.ContainsKey(key))
			{
				productIdList.Add(key);
				if (unlockedProducts.Contains(key))
				{
					foundList.Add(key);
				}
			}
		}
		chosenList.Clear();
		foreach (ProductionConfig value in ProductConfig.Values)
		{
			foreach (string product in value.ProductList)
			{
				if (!chosenList.Contains(product))
				{
					chosenList.Add(product);
				}
			}
		}
		chosenClone = ListExtensions.DeepCopy<string>(chosenList);
	}
}
