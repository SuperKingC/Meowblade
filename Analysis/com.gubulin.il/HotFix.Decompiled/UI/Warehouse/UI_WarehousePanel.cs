using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.AddCredit;
using UI.CraftItemPopup;
using UI.GiftBag;
using UI.PublicResources;
using UI.Tips;
using UI.UpGrade;
using UI.UseItemResult;
using UnityEngine;

namespace UI.Warehouse;

public class UI_WarehousePanel : GComponent, IUiController
{
	public Controller pageSwitch;

	public GLoader background;

	public GImage n56;

	public GImage n89;

	public GImage n90;

	public GGroup backAndCrack;

	public GImage switchDark0;

	public GImage switchDark1;

	public GImage switchDark2;

	public GImage switchDark3;

	public GImage switchDark4;

	public GButton backBtn;

	public GComponent addWorkerBtn;

	public GImage backB;

	public GImage n87;

	public GImage n88;

	public GGroup backGroup;

	public GImage switchLight0;

	public UI_switchProp switch0;

	public GImage switchLight1;

	public UI_switchEquip switch1;

	public GImage switchLight2;

	public UI_switchGood switch2;

	public GImage switchLight3;

	public UI_btn_SwitchCollection switch3;

	public GImage switchLigh4;

	public UI_btn_Switchavailable switch4;

	public GList propsList;

	public GList equipmentsList;

	public GList suppliesList;

	public GList Collections;

	public GList availableList;

	public GImage n42;

	public GImage n83;

	public GTextField stockLimitTitle;

	public GTextField stockLimit;

	public GImage n64;

	public GButton ExclamationMarkBtn;

	public GGroup stockLimitGroup;

	public UI_Title Title;

	public GButton upBtn;

	public GGroup nameGroup;

	public GComponent addCouponBtn;

	public GComponent addDiamondBtn;

	public GGraph workUI;

	public GTextField n86;

	public GImage n98;

	public GImage n103;

	public Transition t0;

	public const string URL = "ui://kh10nzowl3sc0";

	public static string Name = "UI_WarehousePanel";

	public Storehouse StorehouseBuilding;

	private readonly List<string> propsItemList = new List<string>();

	private readonly List<string> equipmentsItemList = new List<string>();

	private readonly List<string> suppliesItemList = new List<string>();

	private readonly List<string> _collections = new List<string>();

	private readonly List<string> _availableItemList = new List<string>();

	private readonly Color32[] SoldierNameColor = (Color32[])(object)new Color32[6]
	{
		new Color32((byte)149, (byte)91, (byte)54, byte.MaxValue),
		new Color32((byte)26, (byte)122, (byte)0, byte.MaxValue),
		new Color32((byte)0, (byte)70, (byte)174, byte.MaxValue),
		new Color32((byte)161, (byte)46, (byte)209, byte.MaxValue),
		new Color32((byte)218, (byte)87, (byte)0, byte.MaxValue),
		new Color32((byte)217, (byte)0, (byte)36, byte.MaxValue)
	};

	private GoWrapper gw1;

	private GameObject canvasObject;

	private List<string> textureList = new List<string>();

	private bool toUnloadAni;

	private UI_ProductionNumFloating NumFloatingMoney;

	private UI_ProductionNumFloating NumFloatingGem;

	private bool _collectionRendered;

	private bool isClosed;

	private bool _has_ItemGem = false;

	private bool _has_Money = false;

	private bool _has_GetData = false;

	private int timerid_OnStockChange = -1;

	private readonly Dictionary<int, int> _refreshTime = new Dictionary<int, int>();

	public static string GetURL()
	{
		return "ui://kh10nzowl3sc0";
	}

	public static UI_WarehousePanel CreateInstance()
	{
		return (UI_WarehousePanel)(object)UIPackage.CreateObject("Warehouse", "WarehousePanel");
	}

	public static UI_WarehousePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WarehousePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kh10nzowl3sc0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
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
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected O, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected O, but got Unknown
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Expected O, but got Unknown
		//IL_0410: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Expected O, but got Unknown
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected O, but got Unknown
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Expected O, but got Unknown
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Expected O, but got Unknown
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		pageSwitch = ((GComponent)this).GetController("pageSwitch");
		background = (GLoader)((GComponent)this).GetChild("background");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n89 = (GImage)((GComponent)this).GetChild("n89");
		n90 = (GImage)((GComponent)this).GetChild("n90");
		backAndCrack = (GGroup)((GComponent)this).GetChild("backAndCrack");
		switchDark0 = (GImage)((GComponent)this).GetChild("switchDark0");
		switchDark1 = (GImage)((GComponent)this).GetChild("switchDark1");
		switchDark2 = (GImage)((GComponent)this).GetChild("switchDark2");
		switchDark3 = (GImage)((GComponent)this).GetChild("switchDark3");
		switchDark4 = (GImage)((GComponent)this).GetChild("switchDark4");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		addWorkerBtn = (GComponent)((GComponent)this).GetChild("addWorkerBtn");
		backB = (GImage)((GComponent)this).GetChild("backB");
		n87 = (GImage)((GComponent)this).GetChild("n87");
		n88 = (GImage)((GComponent)this).GetChild("n88");
		backGroup = (GGroup)((GComponent)this).GetChild("backGroup");
		switchLight0 = (GImage)((GComponent)this).GetChild("switchLight0");
		switch0 = (UI_switchProp)(object)((GComponent)this).GetChild("switch0");
		switchLight1 = (GImage)((GComponent)this).GetChild("switchLight1");
		switch1 = (UI_switchEquip)(object)((GComponent)this).GetChild("switch1");
		switchLight2 = (GImage)((GComponent)this).GetChild("switchLight2");
		switch2 = (UI_switchGood)(object)((GComponent)this).GetChild("switch2");
		switchLight3 = (GImage)((GComponent)this).GetChild("switchLight3");
		switch3 = (UI_btn_SwitchCollection)(object)((GComponent)this).GetChild("switch3");
		switchLigh4 = (GImage)((GComponent)this).GetChild("switchLigh4");
		switch4 = (UI_btn_Switchavailable)(object)((GComponent)this).GetChild("switch4");
		propsList = (GList)((GComponent)this).GetChild("propsList");
		equipmentsList = (GList)((GComponent)this).GetChild("equipmentsList");
		suppliesList = (GList)((GComponent)this).GetChild("suppliesList");
		Collections = (GList)((GComponent)this).GetChild("Collections");
		availableList = (GList)((GComponent)this).GetChild("availableList");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n83 = (GImage)((GComponent)this).GetChild("n83");
		stockLimitTitle = (GTextField)((GComponent)this).GetChild("stockLimitTitle");
		string id = "ui://kh10nzowl3sc0".Replace("ui://", "") + "-" + ((GObject)stockLimitTitle).id;
		((GObject)stockLimitTitle).text = LanguagesManager.GetDesc(id);
		stockLimit = (GTextField)((GComponent)this).GetChild("stockLimit");
		string id2 = "ui://kh10nzowl3sc0".Replace("ui://", "") + "-" + ((GObject)stockLimit).id;
		((GObject)stockLimit).text = LanguagesManager.GetDesc(id2);
		n64 = (GImage)((GComponent)this).GetChild("n64");
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		stockLimitGroup = (GGroup)((GComponent)this).GetChild("stockLimitGroup");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		upBtn = (GButton)((GComponent)this).GetChild("upBtn");
		nameGroup = (GGroup)((GComponent)this).GetChild("nameGroup");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		workUI = (GGraph)((GComponent)this).GetChild("workUI");
		n86 = (GTextField)((GComponent)this).GetChild("n86");
		string id3 = "ui://kh10nzowl3sc0".Replace("ui://", "") + "-" + ((GObject)n86).id;
		((GObject)n86).text = LanguagesManager.GetDesc(id3);
		n98 = (GImage)((GComponent)this).GetChild("n98");
		n103 = (GImage)((GComponent)this).GetChild("n103");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void UpdateStockImmediately(string itemId)
	{
		if (_availableItemList.Contains(itemId))
		{
			FlushLastRefresh();
			GetData();
		}
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		object value = null;
		parameters?.TryGetValue("Tab", out value);
		((GObject)this).sortingOrder = 1;
		if (value == null)
		{
			value = 4;
		}
		FGUIManager.Instance.WarehousePanel = this;
		pageSwitch.selectedIndex = (int)value;
		addWorkerBtn.GetChild("CurrentWorkerAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		addWorkerBtn.GetChild("separate").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		addWorkerBtn.GetChild("AllWorkerAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		InitWorkerSpine();
		GetData();
		SetBuildingName();
		UpdateWorkerNum();
		CheckUpBtnTip();
		if (!Define.IsWarehouseCollectionsOpen())
		{
			((GObject)switchLight3).visible = false;
			((GObject)switchDark3).visible = false;
			((GObject)switch3).visible = false;
		}
	}

	private void OnUpdatePanel()
	{
		FlushLastRefresh();
		GetData();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(BackBtnClick));
		addWorkerBtn.GetChild("addButton").onClick.Add(new EventCallback0(WorkerAddClick));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)ExclamationMarkBtn).onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		addCouponBtn.GetChild("addButton").onClick.Add(new EventCallback0(MoneyBtnEvent));
		addDiamondBtn.GetChild("addButton").onClick.Add(new EventCallback0(DiamondBtnEvent));
		((GObject)upBtn).onClick.Add(new EventCallback0(UpBtnClick));
		((GObject)switch0).onClick.Add(new EventCallback0(UpdatePage0));
		((GObject)switch1).onClick.Add(new EventCallback0(UpdatePage1));
		((GObject)switch2).onClick.Add(new EventCallback0(UpdatePage2));
		((GObject)switch3).onClick.Add(new EventCallback0(RefreshCollections));
		((GObject)switch4).onClick.Add(new EventCallback0(UpdatePage4));
		SharedMessenger.AddListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		SharedMessenger.AddListener<string>("PRODUCT_UNLOCKED", UpdateSuppliesList);
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", OnBuildingUpgraded);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener("FORCE_UPDATE_WAREHOUSE_PANEL", OnUpdatePanel);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(BackBtnClick));
		addWorkerBtn.GetChild("addButton").onClick.Remove(new EventCallback0(WorkerAddClick));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)ExclamationMarkBtn).onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		addCouponBtn.GetChild("addButton").onClick.Remove(new EventCallback0(MoneyBtnEvent));
		addDiamondBtn.GetChild("addButton").onClick.Remove(new EventCallback0(DiamondBtnEvent));
		((GObject)upBtn).onClick.Remove(new EventCallback0(UpBtnClick));
		((GObject)switch0).onClick.Remove(new EventCallback0(UpdatePage0));
		((GObject)switch1).onClick.Remove(new EventCallback0(UpdatePage1));
		((GObject)switch2).onClick.Remove(new EventCallback0(UpdatePage2));
		((GObject)switch3).onClick.Remove(new EventCallback0(RefreshCollections));
		((GObject)switch4).onClick.Remove(new EventCallback0(UpdatePage4));
		SharedMessenger.RemoveListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		SharedMessenger.RemoveListener<string>("PRODUCT_UNLOCKED", UpdateSuppliesList);
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", OnBuildingUpgraded);
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener("FORCE_UPDATE_WAREHOUSE_PANEL", OnUpdatePanel);
		SpawnManager.Instance.UnloadAnimation("Goblinworker_UI_001");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("Storehouse.CloseBtn", backBtn);
		instance.Unregister("Storehouse.UpgradeBtn", upBtn);
		instance.Unregister("Storehouse.TabUsableItem", switch0);
		instance.Unregister("Storehouse.TabWeapon", switch1);
		instance.Unregister("Storehouse.TabResource", switch2);
		instance.Unregister("Storehouse.Item");
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		FGUIManager.Instance.WarehousePanel = null;
	}

	public void OnShow()
	{
		isClosed = false;
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("Storehouse.CloseBtn", backBtn);
		instance.Register("Storehouse.UpgradeBtn", upBtn);
		instance.Register("Storehouse.TabUsableItem", switch0);
		instance.Register("Storehouse.TabWeapon", switch1);
		instance.Register("Storehouse.TabResource", switch2);
		OnPageSwitchChanged();
		UpdateTabNote();
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		UiAudioManager.Instance.PlayBackgroundSound("Building11_Click");
	}

	private void BackBtnClick()
	{
		End();
	}

	private void WorkerAddClick()
	{
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText21") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private void DiamondAddClick()
	{
	}

	private void UpBtnClick()
	{
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "Parent", this },
			{ "Building", StorehouseBuilding }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, parameters);
	}

	private void ItemTip(string itemId)
	{
		switch ((ItemType)Shift.Legion.Common.Models.Item.ItemType(itemId))
		{
		case ItemType.CraftItem:
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_CraftItemPopupPanel_GS.Name, new Dictionary<string, object>
			{
				{ "ItemId", itemId },
				{
					"OnConfirmCraft",
					new UICallbackParam<Action<int>>(delegate(int num)
					{
						OnConfirmCraft(itemId, num);
					})
				}
			});
			break;
		case ItemType.PaidNestingGiftBag:
			ShowItemInnerStoreItem(itemId);
			break;
		default:
			if (!FGUIManager.TryShowOptionalBlueprint(itemId, isPreview: false) && !FGUIManager.TryShowSpecialBlueprint(itemId))
			{
				FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: false, reserveRes: false, this, isPack: true);
			}
			break;
		}
	}

	private void OnConfirmCraft(string itemId, int num)
	{
		ILRequestHelper<UseItemResponse>.Request((EventContext)null, (Func<Task<UseItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().UseItem(-1L, itemId, num, null)), (Action<UseItemResponse>)delegate(UseItemResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else if (response != null)
			{
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				FlushLastRefresh();
				GetData();
				OpenGSUseItemResultPanel(itemId, response);
			}
		});
	}

	private void OpenGSUseItemResultPanel(string useItemId, UseItemResponse response)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GSUseItemResultPanel.Name, new Dictionary<string, object>
		{
			{ "UseItemId", useItemId },
			{ "Result", response }
		});
	}

	private void UpdatePage0()
	{
		SharedMessenger.Broadcast("OPEN_UI", Name, new Dictionary<string, object> { { "Tab", 0 } });
		OnPageSwitchChanged();
	}

	private void UpdatePage1()
	{
		SharedMessenger.Broadcast("OPEN_UI", Name, new Dictionary<string, object> { { "Tab", 1 } });
		OnPageSwitchChanged();
	}

	private void UpdatePage2()
	{
		UpdateSuppliesList("");
		SharedMessenger.Broadcast("OPEN_UI", Name, new Dictionary<string, object> { { "Tab", 2 } });
		OnPageSwitchChanged();
	}

	private void UpdatePage4()
	{
		SharedMessenger.Broadcast("OPEN_UI", Name, new Dictionary<string, object> { { "Tab", 4 } });
		OnPageSwitchChanged();
	}

	private void UpdateMoneyAndGemNum(List<ModelsBonus> bonusList)
	{
		for (int i = 0; i < bonusList.Count; i++)
		{
			if (bonusList[i].ItemId == "Money")
			{
				UpdateMoney();
			}
			else if (bonusList[i].ItemId == "Gem")
			{
				UpdateGemstone();
			}
		}
	}

	public void UpdateMoneyAndGemNum(List<Bonus> bonusList)
	{
		for (int i = 0; i < bonusList.Count; i++)
		{
			if (bonusList[i].ItemId == "Money")
			{
				UpdateMoney();
			}
			else if (bonusList[i].ItemId == "Gem")
			{
				UpdateGemstone();
			}
		}
	}

	private void SetBuildingName()
	{
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		((GObject)Title.buildingName).text = StorehouseBuilding.Name ?? "";
		UpdateGemstone();
		UpdateMoney(isInit: true);
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
		addCouponBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Money");
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("OverlordContract") > 0)
		{
			((GObject)ExclamationMarkBtn).visible = true;
			((GObject)ExclamationMarkBtn).data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText634"), Convert.ToInt32(GameManagers.Instance.StockController.GetLimit("I11001") / 2))
				},
				{
					"Pos",
					(object)new Vector2(960f, 788f)
				}
			};
			float num = 38f + ((GObject)stockLimit).width + 23f;
			((GObject)n64).x = ((GObject)stockLimitTitle).x - num / 2f;
		}
		else
		{
			((GObject)ExclamationMarkBtn).visible = false;
			float num2 = 38f + ((GObject)stockLimit).width;
			((GObject)n64).x = ((GObject)stockLimitTitle).x - num2 / 2f;
		}
	}

	private void PropsListItemRender(int index, GObject obj)
	{
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		string itemId = propsItemList[index];
		int num = ((Shift.Legion.Common.Models.Item.ItemType(itemId) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId) : Shift.Legion.Common.Models.Item.Level(GameManagers.Instance, itemId));
		num = ((num > 0) ? num : Shift.Legion.Common.Models.Item.Rarity(itemId));
		((GComponent)asButton).GetChild("frame").asLoader.url = $"ui://PublicResources/kuang_round 2_lv{num}";
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		int limit = GameManagers.Instance.StockController.GetLimit(itemId);
		FGUIManager.Instance.SetItemIconAndFrame(((GComponent)asButton).GetChild("icon").asLoader, itemId, null, "", frameVisible: false);
		asButton.title = stock.ToString();
		int num2 = ((stock >= limit) ? 1 : 0);
		((GComponent)asButton).GetChild("max").alpha = num2;
		((GObject)((GComponent)asButton).GetChild("name").asTextField).text = SchemaIndexHelper.GetNameByIdWithLineBreak(GameManagers.Instance, itemId);
		((GComponent)asButton).GetChild("name").asTextField.color = Color32.op_Implicit(SoldierNameColor[(num - 1 >= 0) ? (num - 1) : 0]);
		((GObject)asButton).onClick.Set((EventCallback0)delegate
		{
			ItemTip(itemId);
		});
	}

	private void EquipmentsListItemRender(int index, GObject obj)
	{
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		string itemId = equipmentsItemList[index];
		int num = ((Shift.Legion.Common.Models.Item.ItemType(itemId) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId) : Shift.Legion.Common.Models.Item.Level(GameManagers.Instance, itemId));
		num = ((num > 0) ? num : Shift.Legion.Common.Models.Item.Rarity(itemId));
		((GComponent)asButton).GetChild("frame").asLoader.url = $"ui://PublicResources/kuang_round 2_lv{num}";
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		int limit = GameManagers.Instance.StockController.GetLimit(itemId);
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
		asButton.title = stock.ToString();
		int num2 = ((stock >= limit) ? 1 : 0);
		((GComponent)asButton).GetChild("max").alpha = num2;
		((GObject)((GComponent)asButton).GetChild("name").asTextField).text = SchemaIndexHelper.GetNameByIdWithLineBreak(GameManagers.Instance, itemId);
		((GComponent)asButton).GetChild("name").asTextField.color = Color32.op_Implicit(SoldierNameColor[(num - 1 >= 0) ? (num - 1) : 0]);
		((GObject)asButton).onClick.Set((EventCallback0)delegate
		{
			ItemTip(itemId);
		});
	}

	private void SuppliesListItemRender(int index, GObject obj)
	{
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		string itemId = suppliesItemList[index];
		int num = ((Shift.Legion.Common.Models.Item.ItemType(itemId) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId) : Shift.Legion.Common.Models.Item.Level(GameManagers.Instance, itemId));
		num = ((num > 0) ? num : Shift.Legion.Common.Models.Item.Rarity(itemId));
		((GComponent)asButton).GetChild("frame").asLoader.url = $"ui://PublicResources/kuang_round 2_lv{num}";
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		int limit = GameManagers.Instance.StockController.GetLimit(itemId);
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
		asButton.title = stock.ToString();
		int num2 = ((stock >= limit) ? 1 : 0);
		((GComponent)asButton).GetChild("max").alpha = num2;
		((GObject)((GComponent)asButton).GetChild("name").asTextField).text = SchemaIndexHelper.GetNameByIdWithLineBreak(GameManagers.Instance, itemId);
		((GComponent)asButton).GetChild("name").asTextField.color = Color32.op_Implicit(SoldierNameColor[(num - 1 >= 0) ? (num - 1) : 0]);
		((GObject)asButton).onClick.Set((EventCallback0)delegate
		{
			ItemTip(itemId);
		});
	}

	private void CollectionItemRender(int index, GObject obj)
	{
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		string itemId = _collections[index];
		int num = Shift.Legion.Common.Models.Item.Rarity(itemId);
		((GComponent)asButton).GetChild("frame").asLoader.url = $"ui://PublicResources/kuang_round 2_lv{num}";
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		int limit = GameManagers.Instance.StockController.GetLimit(itemId);
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
		asButton.title = stock.ToString();
		int num2 = ((stock >= limit) ? 1 : 0);
		((GComponent)asButton).GetChild("max").alpha = num2;
		((GObject)((GComponent)asButton).GetChild("name").asTextField).text = SchemaIndexHelper.GetNameByIdWithLineBreak(GameManagers.Instance, itemId);
		((GComponent)asButton).GetChild("name").asTextField.color = Color32.op_Implicit(SoldierNameColor[(num - 1 >= 0) ? (num - 1) : 0]);
		((GObject)asButton).onClick.Set((EventCallback0)delegate
		{
			ItemTip(itemId);
		});
	}

	private void AvailableListItemRender(int index, GObject obj)
	{
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		string itemId = _availableItemList[index];
		int num = Shift.Legion.Common.Models.Item.Rarity(itemId);
		((GComponent)asButton).GetChild("frame").asLoader.url = $"ui://PublicResources/kuang_round 2_lv{num}";
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		int limit = GameManagers.Instance.StockController.GetLimit(itemId);
		FGUIManager.Instance.SetItemIconAndFrame(((GComponent)asButton).GetChild("icon").asLoader, itemId, null, "", frameVisible: false);
		asButton.title = stock.ToString();
		int num2 = ((stock >= limit) ? 1 : 0);
		((GComponent)asButton).GetChild("max").alpha = num2;
		((GObject)((GComponent)asButton).GetChild("name").asTextField).text = SchemaIndexHelper.GetNameByIdWithLineBreak(GameManagers.Instance, itemId);
		((GComponent)asButton).GetChild("name").asTextField.color = Color32.op_Implicit(SoldierNameColor[(num - 1 >= 0) ? (num - 1) : 0]);
		((GObject)asButton).onClick.Set((EventCallback0)delegate
		{
			ItemTip(itemId);
		});
	}

	private void RenderPropsList()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		propsList.itemRenderer = new ListItemRenderer(PropsListItemRender);
		propsList.SetVirtual();
		propsList.numItems = propsItemList.Count;
	}

	private void RenderEquipments()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		equipmentsList.itemRenderer = new ListItemRenderer(EquipmentsListItemRender);
		equipmentsList.SetVirtual();
		equipmentsList.numItems = equipmentsItemList.Count;
	}

	private void RenderSuppliesList()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		suppliesList.itemRenderer = new ListItemRenderer(SuppliesListItemRender);
		suppliesList.SetVirtual();
		suppliesList.numItems = suppliesItemList.Count;
	}

	private void RenderCollections()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		Collections.itemRenderer = new ListItemRenderer(CollectionItemRender);
		Collections.SetVirtual();
		Collections.numItems = _collections.Count;
	}

	private void RenderAvailableList()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		availableList.itemRenderer = new ListItemRenderer(AvailableListItemRender);
		availableList.SetVirtual();
		availableList.numItems = _availableItemList.Count;
	}

	private void RefreshPropsList()
	{
		if (!CheckRefreshTime(0))
		{
			return;
		}
		propsItemList.Clear();
		foreach (GDEStorehouseData allStockDatum in GameManagers.Instance.StockController.GetAllStockData(StockCategory.Item))
		{
			propsItemList.Add(allStockDatum.ItemId);
		}
		if (!Define.IsWarehouseCollectionsOpen())
		{
			foreach (GDEStorehouseData allStockDatum2 in GameManagers.Instance.StockController.GetAllStockData(StockCategory.Collection))
			{
				propsItemList.Add(allStockDatum2.ItemId);
			}
		}
		RenderPropsList();
	}

	private void RefreshEquipmentsList()
	{
		if (!CheckRefreshTime(1))
		{
			return;
		}
		equipmentsItemList.Clear();
		foreach (GDEStorehouseData allStockDatum in GameManagers.Instance.StockController.GetAllStockData(StockCategory.Weapon))
		{
			equipmentsItemList.Add(allStockDatum.ItemId);
		}
		RenderEquipments();
	}

	private void RefreshSuppliesList()
	{
		if (!CheckRefreshTime(2))
		{
			return;
		}
		suppliesItemList.Clear();
		foreach (GDEStorehouseData allStockDatum in GameManagers.Instance.StockController.GetAllStockData(StockCategory.Material))
		{
			suppliesItemList.Add(allStockDatum.ItemId);
		}
		RenderSuppliesList();
	}

	private void RefreshCollections()
	{
		if (_collectionRendered)
		{
			return;
		}
		_collections.Clear();
		foreach (GDEStorehouseData allStockDatum in GameManagers.Instance.StockController.GetAllStockData(StockCategory.Collection))
		{
			_collections.Add(allStockDatum.ItemId);
		}
		RenderCollections();
		_collectionRendered = true;
	}

	private void RefreshAvailableList()
	{
		if (!CheckRefreshTime(3))
		{
			return;
		}
		_availableItemList.Clear();
		foreach (GDEStorehouseData allStockDatum in GameManagers.Instance.StockController.GetAllStockData(StockCategory.UsableItem))
		{
			_availableItemList.Add(allStockDatum.ItemId);
		}
		RenderAvailableList();
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		switch (itemId)
		{
		case "Gem":
			_has_ItemGem = true;
			break;
		case "Money":
			_has_Money = true;
			break;
		case "I32100":
			ILRequestHelper.ShowMessage($"{Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, itemId)}+{incr}");
			break;
		default:
			if (incr > 0 && (!propsItemList.Contains(itemId) || !equipmentsItemList.Contains(itemId) || !suppliesItemList.Contains(itemId) || !_availableItemList.Contains(itemId)))
			{
				_has_GetData = true;
			}
			break;
		}
		WaitTo_OnStockChange();
	}

	private void ShowItemInnerStoreItem(string itemId)
	{
		string text = "";
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, itemId) ?? new List<Modifier>();
		foreach (Modifier item in list)
		{
			if (item.ModifierId == "UIParams")
			{
				dictionary = item.PayloadDictionary;
			}
			else if (item.ModifierId == "StoreItem")
			{
				text = item.PayloadDictionary["Payload"].ToString();
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			throw new Exception("[UI_WarehousePanel] 展示Item内部礼包 itemId=" + itemId + " StoreItemId 为空");
		}
		StoreItem storeItem = StoreItem.Get(GameManagers.Instance, text);
		dictionary.Add("Name", storeItem.Name ?? "");
		dictionary.Add("CanBuy", true);
		dictionary.Add("GiftBag", storeItem);
		dictionary.Add("Parent", this);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems.Name, dictionary);
	}

	private void RealOnStockChange()
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		if (isClosed)
		{
			return;
		}
		timerid_OnStockChange = -1;
		if (_has_ItemGem)
		{
			UpdateGemstone();
			addDiamondBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addDiamondBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
		if (_has_Money)
		{
			UpdateMoney();
		}
		if (_has_GetData)
		{
			GetData();
			UpdateTabNote();
		}
		_has_ItemGem = false;
		_has_Money = false;
		_has_GetData = false;
	}

	private void WaitTo_OnStockChange()
	{
		if (timerid_OnStockChange <= 0)
		{
			timerid_OnStockChange = ScriptApi.CreateTimer(0.5f, RealOnStockChange);
			return;
		}
		TimerEntity entityWithId = Contexts.sharedInstance.timer.GetEntityWithId(timerid_OnStockChange);
		if (entityWithId != null)
		{
			entityWithId.ReplaceRepeat(1);
			entityWithId.ReplaceDuration(0.5f);
			entityWithId.ReplaceElapsedTime(0f);
			entityWithId.ReplaceCallbackAction(RealOnStockChange);
		}
		else
		{
			timerid_OnStockChange = ScriptApi.CreateTimer(0.5f, RealOnStockChange);
		}
	}

	public void UpdateGemstone()
	{
		int stock = GameManagers.Instance.StockController.GetStock("Gem");
		((GObject)addDiamondBtn.GetChild("num").asTextField).text = stock.ToString();
		int num = ((addDiamondBtn.GetChild("num").data != null) ? ((int)addDiamondBtn.GetChild("num").data) : stock);
		if (num != stock && stock > num)
		{
			int num2 = stock - num;
			if (NumFloatingGem == null)
			{
				NumFloatingGem = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			}
			if (!((GObject)NumFloatingGem).onStage)
			{
				FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloatingGem, addDiamondBtn, stock - num);
			}
			else
			{
				((GObject)NumFloatingGem.Title).text = $"+{(int)((GObject)NumFloatingGem.Title).data + num2}";
				((GObject)NumFloatingGem.Title).data = (int)((GObject)NumFloatingGem.Title).data + num2;
			}
		}
		addDiamondBtn.GetChild("num").data = stock;
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

	public void End()
	{
		if (timerid_OnStockChange > 0)
		{
			ScriptApi.StopTimer(timerid_OnStockChange);
			timerid_OnStockChange = -1;
		}
		isClosed = true;
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		if (toUnloadAni)
		{
			SpawnManager.Instance.UnloadAnimation("Goblinworker_UI_001");
		}
	}

	public void UpdateWorkerNum(Building building = null)
	{
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		Dungeon value = GameController.Contexts.game.dungeon.value;
		((GObject)addWorkerBtn.GetChild("CurrentWorkerAmount").asTextField).text = Dungeon.GetFreeManPower(GameManagers.Instance).ToString();
		((GObject)addWorkerBtn.GetChild("AllWorkerAmount").asTextField).text = Dungeon.GetTotalManPower(GameManagers.Instance).ToString();
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdManPower() > 0)
		{
			addWorkerBtn.GetChild("AllWorkerAmount").asTextField.color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
			addWorkerBtn.GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText153")
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

	private void InitWorkerSpine()
	{
		((GObject)workUI).visible = false;
	}

	private void DiamondBtnEvent()
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
			}
		});
	}

	private void MoneyBtnEvent()
	{
		if (((GObject)this).parent != null && ((GObject)this).parent is UI_GiftBagPanel)
		{
			((UI_GiftBagPanel)(object)((GObject)this).parent).MoneyBtnEvent();
			End();
		}
		else if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
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
				}
			});
		}
		else
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	private void TitleInit()
	{
		Title.icon.url = "ui://PublicResources/Building" + StorehouseBuilding.BuildingType;
		((GObject)((GComponent)upBtn).GetChild("level").asTextField).text = StorehouseBuilding.Level.ToString();
	}

	private bool CheckRefreshTime(int index)
	{
		int num = (int)GameController.Instance.GetServerTime();
		if (_refreshTime.TryGetValue(index, out var value))
		{
			if (num - value < 5)
			{
				return false;
			}
			_refreshTime[index] = num;
			return true;
		}
		_refreshTime.Add(index, num);
		return true;
	}

	public void FlushLastRefresh()
	{
		_refreshTime.Clear();
	}

	public void GetData()
	{
		StorehouseBuilding = GameManagers.Instance.BuildingManager.GetBuildingByType("11") as Storehouse;
		((GObject)stockLimit).text = string.Format("{0}", GameManagers.Instance.StockController.GetLimit("I11001"));
		TitleInit();
		switch (pageSwitch.selectedIndex)
		{
		case 0:
			RefreshPropsList();
			break;
		case 1:
			RefreshEquipmentsList();
			break;
		case 2:
			RefreshSuppliesList();
			break;
		case 4:
			RefreshAvailableList();
			break;
		case 3:
			break;
		}
	}

	private void UpdateTabNote()
	{
	}

	private void UpdateSuppliesList(string productId)
	{
		if (pageSwitch.selectedIndex == 2)
		{
			RefreshSuppliesList();
		}
	}

	private void OnBuildingUpgraded(string buildingType, int level)
	{
		CheckUpBtnTip();
		if (buildingType == StorehouseBuilding.BuildingType)
		{
			GetData();
		}
	}

	private void CheckUpBtnTip()
	{
		((GObject)((GComponent)upBtn).GetChild("redPoint").asImage).visible = StorehouseBuilding.CanUpgrade() || StorehouseBuilding.HasNewMaxLevel();
	}

	private void OnPageSwitchChanged()
	{
		List<string> list;
		GList collections;
		switch (pageSwitch.selectedIndex)
		{
		default:
			return;
		case 0:
			list = propsItemList;
			collections = propsList;
			break;
		case 1:
			list = equipmentsItemList;
			collections = equipmentsList;
			break;
		case 2:
			list = suppliesItemList;
			collections = suppliesList;
			break;
		case 3:
			list = _collections;
			collections = Collections;
			break;
		case 4:
			list = _availableItemList;
			collections = availableList;
			break;
		}
		UiTagManager instance = UiTagManager.Instance;
		Dictionary<string, object> dictionary = instance.FindObjectsMapByTag("Storehouse.Item");
		if (dictionary == null)
		{
			dictionary = new Dictionary<string, object>();
		}
		else
		{
			dictionary.Clear();
		}
		for (int i = 0; i < list.Count; i++)
		{
			string key = list[i];
			if (i < ((GComponent)collections).numChildren)
			{
				GButton asButton = ((GComponent)collections).GetChildAt(i).asButton;
				dictionary.Add(key, asButton);
			}
		}
		instance.Register("Storehouse.Item", dictionary);
		GetData();
	}
}
