using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Rank.Helpers;
using Spine;
using Spine.Unity;
using UI.MonthCard;
using UI.RecruitingCamp;
using UI.SoldierCultivate;
using UI.Tips;
using UI.UpGrade;
using UI.UpPropGrade;
using UnityEngine;

namespace UI.WorkShop;

public class UI_WorkShopPanel : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventCallback0 _003C_003E9__68_0;

		internal void _003CListRenderer_003Eb__68_0()
		{
			SharedMessenger.Broadcast("WORKSHOP_LIST_SCROLLEND");
		}
	}

	public Controller BuildingType;

	public GLoader background;

	public GImage listBackground;

	public GImage n67;

	public GImage n68;

	public GComponent addWorkerBtn;

	public UI_diamondButton diamondAddBtn;

	public GList itemList;

	public GButton backBtn;

	public GButton yesBtn;

	public UI_Title Title;

	public GButton upButton;

	public GGroup nameGroup;

	public GImage station;

	public GTextField remainingStation;

	public GImage n45;

	public GTextField numbers;

	public GGroup n71;

	public GButton ExclamationMarkBtn;

	public GGraph numbersSpine;

	public GGroup bottomGruop;

	public UI_btn_ItemSort ItemSort;

	public GGraph workUI;

	public GGraph mask;

	public GTextField UnlockTip;

	public UI_armItem1 clearBtn;

	public Transition changeText;

	public Transition numbersHeightLight;

	public const string URL = "ui://k6y9jq3appg40";

	public static string Name = "UI_WorkShopPanel";

	private ProductSortState _sortState = ProductSortState.Default;

	private const string ITEM_SORT_PREFS = "ITEM_SORT_PREFS";

	private const int ITEM_SORT_UNLOCK_LEVEL = 20;

	private global::WorkShop WorkShopBuilding;

	public Dictionary<string, ProductionConfig> NewProductConfig = new Dictionary<string, ProductionConfig>();

	public List<GDEProductData> productList = new List<GDEProductData>();

	private string singleProductId;

	private readonly HashSet<string> weaponSet = new HashSet<string>();

	private int _evolutionlevel;

	private string[] stuffId = new string[4];

	private float time;

	private Canvas canvas;

	private UI_SoldierCultivate soldierPanel;

	private UI_RecruitingCamp campPanel;

	private List<string> weaponList = new List<string>();

	private GameObject canvasObject;

	private GoWrapper gw;

	private int plannedNumber;

	private List<string> textureList = new List<string>();

	private bool toUnloadAni;

	private int itemSelectIndex;

	private Coroutine StockChangeCoroutine;

	private Dictionary<string, List<string>> SoldiersAndWeaponsDic = new Dictionary<string, List<string>>();

	public static string GetURL()
	{
		return "ui://k6y9jq3appg40";
	}

	public static UI_WorkShopPanel CreateInstance()
	{
		return (UI_WorkShopPanel)(object)UIPackage.CreateObject("WorkShop", "WorkShopPanel");
	}

	public static UI_WorkShopPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WorkShopPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k6y9jq3appg40", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		BuildingType = ((GComponent)this).GetController("BuildingType");
		background = (GLoader)((GComponent)this).GetChild("background");
		listBackground = (GImage)((GComponent)this).GetChild("listBackground");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		addWorkerBtn = (GComponent)((GComponent)this).GetChild("addWorkerBtn");
		diamondAddBtn = (UI_diamondButton)(object)((GComponent)this).GetChild("diamondAddBtn");
		itemList = (GList)((GComponent)this).GetChild("itemList");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		yesBtn = (GButton)((GComponent)this).GetChild("yesBtn");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		upButton = (GButton)((GComponent)this).GetChild("upButton");
		nameGroup = (GGroup)((GComponent)this).GetChild("nameGroup");
		station = (GImage)((GComponent)this).GetChild("station");
		remainingStation = (GTextField)((GComponent)this).GetChild("remainingStation");
		string id = "ui://k6y9jq3appg40".Replace("ui://", "") + "-" + ((GObject)remainingStation).id;
		((GObject)remainingStation).text = LanguagesManager.GetDesc(id);
		n45 = (GImage)((GComponent)this).GetChild("n45");
		numbers = (GTextField)((GComponent)this).GetChild("numbers");
		string id2 = "ui://k6y9jq3appg40".Replace("ui://", "") + "-" + ((GObject)numbers).id;
		((GObject)numbers).text = LanguagesManager.GetDesc(id2);
		n71 = (GGroup)((GComponent)this).GetChild("n71");
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		numbersSpine = (GGraph)((GComponent)this).GetChild("numbersSpine");
		bottomGruop = (GGroup)((GComponent)this).GetChild("bottomGruop");
		ItemSort = (UI_btn_ItemSort)(object)((GComponent)this).GetChild("ItemSort");
		workUI = (GGraph)((GComponent)this).GetChild("workUI");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		UnlockTip = (GTextField)((GComponent)this).GetChild("UnlockTip");
		string id3 = "ui://k6y9jq3appg40".Replace("ui://", "") + "-" + ((GObject)UnlockTip).id;
		((GObject)UnlockTip).text = LanguagesManager.GetDesc(id3);
		clearBtn = (UI_armItem1)(object)((GComponent)this).GetChild("clearBtn");
		changeText = ((GComponent)this).GetTransition("changeText");
		numbersHeightLight = ((GComponent)this).GetTransition("numbersHeightLight");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		((GObject)this).sortingOrder = 1;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (!parameters.ContainsKey("BuildingType"))
		{
			End();
			return;
		}
		WorkShopBuilding = GameManagers.Instance.BuildingManager.GetBuildingByType(parameters["BuildingType"].ToString()) as global::WorkShop;
		CheckWorkersCanAssign();
		if (parameters.ContainsKey("ProductId"))
		{
			singleProductId = (string)parameters["ProductId"];
		}
		if (singleProductId != null)
		{
			if (parameters.ContainsKey("Soldier"))
			{
				soldierPanel = (UI_SoldierCultivate)parameters["Soldier"];
			}
			if (parameters.ContainsKey("Camp"))
			{
				campPanel = (UI_RecruitingCamp)parameters["Camp"];
			}
			if (parameters.ContainsKey("Weapons"))
			{
				weaponList = (List<string>)parameters["Weapons"];
			}
		}
		InitItemSort();
		itemList.scrollItemToViewOnClick = false;
		SoldiersAndWeaponsDicInit();
		RenderMainUi();
		InitBackground();
		((GComponent)diamondAddBtn).GetChild("DiamondAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		addWorkerBtn.GetChild("CurrentWorkerAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		addWorkerBtn.GetChild("separate").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		addWorkerBtn.GetChild("AllWorkerAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		SetBuildingName();
		((GObject)yesBtn).enabled = false;
		Dictionary<string, ProductionConfig> productionConfigs = WorkShopBuilding.ProductionConfigs;
		NewProductConfig = new Dictionary<string, ProductionConfig>();
		foreach (string key in productionConfigs.Keys)
		{
			NewProductConfig.Add(key, productionConfigs[key].Clone());
		}
		plannedNumber = 0;
		ListRenderer();
		if (itemList.numItems == 0)
		{
			ILRuntimeDebug.LogError("[UI_WorkShopPanel] 产品数量为0，请检查配置");
		}
		else
		{
			itemList.ScrollToView(0);
		}
		CheckUpBtnTip();
		((GObject)clearBtn).visible = GameManagers.Instance.UserArchiveManager.GetUserLevel() >= 20;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(BackEvent));
		((GObject)yesBtn).onClick.Add(new EventCallback1(Confirm));
		((GObject)addWorkerBtn).onClick.Add(new EventCallback0(OpenWorkerOverview));
		addWorkerBtn.GetChild("addButton").onClick.Add(new EventCallback1(WorkerAddClick));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)diamondAddBtn.addButton).onClick.Add(new EventCallback0(DiamondAddClick));
		((GObject)upButton).onClick.Add(new EventCallback0(UpGrade));
		((GComponent)itemList).scrollPane.onScroll.Add(new EventCallback0(TerminationScroll));
		((GObject)ExclamationMarkBtn).onClick.Add(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)ItemSort).onClick.Set(new EventCallback0(ItemSortClick));
		SharedMessenger.AddListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		SharedMessenger.AddListener<string>("PRODUCT_UNLOCKED", OnProductUnlocked);
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", OnBuildingUpgraded);
		SharedMessenger.AddListener("OPEN_WORKER_OVERVIEW_PANEL", OpenWorkerOverview);
		SharedMessenger.AddListener("PRODUCT_UPGRADED", UpdateList);
		((GObject)clearBtn).onClick.Set(new EventCallback0(OnClickClearAllWorkers));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(BackEvent));
		((GObject)yesBtn).onClick.Remove(new EventCallback1(Confirm));
		((GObject)addWorkerBtn).onClick.Remove(new EventCallback0(OpenWorkerOverview));
		addWorkerBtn.GetChild("addButton").onClick.Remove(new EventCallback1(WorkerAddClick));
		addWorkerBtn.GetChild("ExclamationMarkBtn").onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)diamondAddBtn.addButton).onClick.Remove(new EventCallback0(DiamondAddClick));
		((GObject)upButton).onClick.Remove(new EventCallback0(UpGrade));
		((GComponent)itemList).scrollPane.onScroll.Remove(new EventCallback0(TerminationScroll));
		((GObject)ExclamationMarkBtn).onClick.Remove(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		((GObject)ItemSort).onClick.Clear();
		SharedMessenger.RemoveListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		SharedMessenger.RemoveListener<string>("PRODUCT_UNLOCKED", OnProductUnlocked);
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", OnBuildingUpgraded);
		SharedMessenger.RemoveListener("OPEN_WORKER_OVERVIEW_PANEL", OpenWorkerOverview);
		SharedMessenger.RemoveListener("PRODUCT_UPGRADED", UpdateList);
		SpawnManager.Instance.UnloadAnimation("Goblinworker_UI_001");
		((GObject)clearBtn).onClick.Clear();
	}

	public static IEnumerator WorkerAnimation(SkeletonAnimation anim, string idleAnim, List<string> workAnims)
	{
		bool isComplete = false;
		anim.AnimationState.Complete += new TrackEntryDelegate(OnComplete);
		while (Object.op_Implicit((Object)(object)((Component)anim).gameObject))
		{
			int idleCount = RandomHelper.Range(5, 10);
			for (int i = 0; i < idleCount; i++)
			{
				anim.AnimationState.AddAnimation(1, idleAnim, false, 0f);
				isComplete = false;
				yield return ILWaitUntil(() => isComplete);
			}
			string workAnim = workAnims.Choose(1)[0];
			anim.AnimationState.AddAnimation(1, workAnim, false, 0f);
			isComplete = false;
			yield return ILWaitUntil(() => isComplete);
		}
		void OnComplete(TrackEntry entry)
		{
			isComplete = true;
		}
	}

	public static IEnumerator ILWaitUntil(Func<bool> predicate)
	{
		WaitForSeconds wait = new WaitForSeconds(0.1f);
		while (!predicate())
		{
			yield return wait;
		}
	}

	private void UpdateMainUi()
	{
		RenderMainUi();
		((GObject)yesBtn).enabled = false;
		Dictionary<string, ProductionConfig> productionConfigs = WorkShopBuilding.ProductionConfigs;
		NewProductConfig = new Dictionary<string, ProductionConfig>();
		foreach (string key in productionConfigs.Keys)
		{
			NewProductConfig.Add(key, productionConfigs[key].Clone());
		}
		plannedNumber = 0;
		ListRenderer();
		itemList.ScrollToView(0);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("Workshop.UpgradeBtn", upButton);
		instance.Unregister("Workshop.ConfirmDistributionBtn", yesBtn);
		instance.Unregister("Workshop.Item");
		instance.Unregister("Workshop.AddWorkerBtn");
		instance.Unregister("Workshop.ReduceWorkerBtn");
		instance.Unregister("Workshop.ItemUpgradeBtn");
		instance.Unregister("Workshop.FirstProductionAddWorkerBtn");
		instance.Unregister("Workshop.FirstProductionReduceWorkerBtn");
		instance.Unregister("Workshop.FirstProductionUpgradeBtn");
		if (StockChangeCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(StockChangeCoroutine);
		}
		UiAudioManager.Instance.StopBackgroundSound("Building" + WorkShopBuilding.BuildingType + "Bgs");
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("Workshop.UpgradeBtn", upButton);
		instance.Register("Workshop.ConfirmDistributionBtn", yesBtn);
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		UiAudioManager.Instance.PlayBackgroundSound("Building" + WorkShopBuilding.BuildingType + "_Click");
		foreach (KeyValuePair<int, string> item in GameManagers.Instance.RecruitingCampDataManager.ProducingQueue)
		{
			if (string.IsNullOrWhiteSpace(item.Value) || !(item.Value != "Unlock") || !(item.Value != "Lock"))
			{
				continue;
			}
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(item.Value);
			foreach (string weapon in soldier.WeaponList)
			{
				GDEProductData productByItemId = GameManagers.Instance.BuildingManager.GetProductByItemId(weapon);
				if (productByItemId != null)
				{
					List<string> list = new List<string>();
					list.Add(productByItemId.Stuff1);
					list.Add(productByItemId.Stuff2);
					list.Add(productByItemId.Stuff3);
					list.Add(productByItemId.Stuff4);
					list.Add(productByItemId.Stuff5);
				}
			}
		}
		InitWorkerSpine();
	}

	private void SoldiersAndWeaponsDicInit()
	{
		foreach (KeyValuePair<int, string> item in GameManagers.Instance.RecruitingCampDataManager.ProducingQueue)
		{
			if (!string.IsNullOrWhiteSpace(item.Value) && !(item.Value == "Unlock") && !(item.Value == "Lock") && !SoldiersAndWeaponsDic.ContainsKey(item.Value))
			{
				SoldiersAndWeaponsDic.Add(item.Value, GameManagers.Instance.SoldierManager.Get(item.Value).WeaponList);
			}
		}
	}

	private void ItemListClick(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GComponent val = (GComponent)context.sender;
		int childIndex = ((GComponent)itemList).GetChildIndex((GObject)(object)val);
		int num = itemList.ChildIndexToItemIndex(childIndex);
		if (num != -1)
		{
			itemSelectIndex = num;
			float num2 = ((GObject)val).y + ((DisplayObject)((GComponent)itemList).container).y;
			if (num2 < 0f)
			{
				itemList.ScrollToView(itemSelectIndex, true);
			}
			else if (num2 > ((GComponent)itemList).viewHeight - ((GObject)val).height)
			{
				itemList.ScrollToView(Mathf.Max(0, itemSelectIndex - 1), true);
			}
		}
	}

	private void TerminationScroll()
	{
		int num = itemList.ItemIndexToChildIndex(itemSelectIndex);
		if (((GComponent)itemList).scrollPane.IsChildInView(((GComponent)itemList).GetChildAt(num)))
		{
			((GComponent)itemList).scrollPane.ScrollTop();
		}
	}

	private void OpenWorkerOverview()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Order", ((GObject)this).sortingOrder);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorkersOverviewPanel.Name, dictionary);
	}

	private void WorkerAddClick(EventContext context)
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
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
		context.StopPropagation();
	}

	private void DiamondAddClick()
	{
	}

	private void Confirm(EventContext eventContext)
	{
		int freeManPower = Dungeon.GetFreeManPower(GameManagers.Instance);
		if (plannedNumber > 0 && plannedNumber > freeManPower)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText639") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 5, arg3: false);
		}
		else if (NewProductConfig == null || NewProductConfig.Count < 1 || CheckAllWorkers() < 1)
		{
			CustomTaskCompletionSource<bool> taskCompletionSource = eventContext.data as CustomTaskCompletionSource<bool>;
			if (taskCompletionSource != null)
			{
				taskCompletionSource.IsAsync = true;
			}
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
								taskCompletionSource?.TrySetResult(result: true);
							}
						}
					}
				},
				{ "PageIndex", 0 },
				{ "ClickSound", "Confirm" },
				{
					"Order",
					((GObject)this).sortingOrder
				}
			});
		}
		else
		{
			ApplyAssignationAsync();
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
				dictionary.Add(int.Parse(item.Key), item.Value.Workers);
				dictionary2.Add(int.Parse(item.Key), item.Value.ProductList);
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
				SharedMessenger.Broadcast("PRODUCTION_CONFIG_CHANGED", (Building)WorkShopBuilding, NewProductConfig);
				SharedMessenger.Broadcast("WORKERS_ALLOCATION_DISPLAY_CHANGED", (Building)WorkShopBuilding);
				List<string> list = new List<string>();
				foreach (ProductionConfig value in NewProductConfig.Values)
				{
					if (value.ProductList != null && value.ProductList.Count >= 1)
					{
						foreach (string product in value.ProductList)
						{
							if (!list.Contains(product))
							{
								list.Add(product);
							}
						}
					}
				}
				ThinkingDataHelper.Instance.BulidingMakeTrack(WorkShopBuilding.BuildingType, WorkShopBuilding.Level, list, WorkShopBuilding.ManPower);
				End();
			}
		});
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

	private int GetNewAssignedWorkers(string productId)
	{
		return NewProductConfig.Values.Sum((ProductionConfig productConfig) => productConfig.ProductList.Contains(productId) ? productConfig.Workers : 0);
	}

	private void AddWorker(GList list, string productId, int index)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Expected O, but got Unknown
		//IL_05ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_06aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_092a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0934: Expected O, but got Unknown
		((GObject)yesBtn).enabled = true;
		list.itemRenderer = new ListItemRenderer(RenderWorkerIncrease);
		int num = CheckAllWorkers();
		if (num < WorkShopBuilding.Slot + WorkShopBuilding.LeaseholdSlot && Convert.ToInt32(addWorkerBtn.GetChild("CurrentWorkerAmount").text) > 0)
		{
			GDEProductData gDEProductData = GDMgr.Get<GDEProductData>(productId);
			float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ProductionEfficiency", new string[1] { "BuildingType" + WorkShopBuilding.BuildingType });
			float num2 = 1f / gDEProductData.Time * 3600f * (1f + percentFloatPayload);
			bool flag = false;
			for (int i = 0; i < WorkShopBuilding.Slot; i++)
			{
				ProductionConfig newProductionConfigAt = GetNewProductionConfigAt(i);
				if (!flag && (newProductionConfigAt.Workers < 1 || newProductionConfigAt.ProductList.Count < 1))
				{
					newProductionConfigAt.Workers = 1;
					newProductionConfigAt.ProductList.Clear();
					newProductionConfigAt.ProductList.Add(productId);
					flag = true;
				}
			}
			if (!flag)
			{
				for (int j = 0; j < WorkShopBuilding.LeaseholdSlot; j++)
				{
					int index2 = ((WorkshopController)WorkShopBuilding.Controller).WorkbenchNominal.Length - 1 - j;
					ProductionConfig newProductionConfigAt2 = GetNewProductionConfigAt(index2);
					if (!flag && (newProductionConfigAt2.Workers < 1 || newProductionConfigAt2.ProductList.Count < 1))
					{
						newProductionConfigAt2.Workers = 1;
						newProductionConfigAt2.ProductList.Clear();
						newProductionConfigAt2.ProductList.Add(productId);
						flag = true;
					}
				}
			}
			int numItems = list.numItems;
			list.numItems = numItems + 1;
			((GComponent)((GComponent)list).GetChildAt(list.numItems - 1).asButton).GetTransition("increase").Play();
			plannedNumber++;
			float num3 = (float)WorkShopBuilding.GetAssignedWorkers(productId) * num2;
			float num4 = (float)list.numItems * num2;
			float value = num4 - num3;
			int num5 = itemList.ItemIndexToChildIndex(index);
			GObject childAt = ((GComponent)itemList).GetChildAt(num5);
			GComponent val = (GComponent)childAt;
			val.GetChild("goodsList").data = true;
			if (num4 > num3)
			{
				((GObject)val.GetChild("output").asRichTextField).text = Convert.ToInt32(num3).ToString();
				((GObject)val.GetChild("outputChange").asRichTextField).text = "+" + Convert.ToInt32(value) + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText156");
				((GTextField)val.GetChild("outputChange").asRichTextField).color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
				((GObject)val.GetChild("outputChangeSpine").asGraph).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(val.GetChild("outputChangeSpine").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
			}
			else if (num4 < num3)
			{
				((GObject)val.GetChild("output").asRichTextField).text = Convert.ToInt32(num3).ToString();
				((GObject)val.GetChild("outputChange").asRichTextField).text = Convert.ToInt32(value) + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText156");
				((GTextField)val.GetChild("outputChange").asRichTextField).color = Color32.op_Implicit(new Color32((byte)220, (byte)20, (byte)60, byte.MaxValue));
				((GObject)val.GetChild("outputChangeSpine").asGraph).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(val.GetChild("outputChangeSpine").asGraph, FGUIManager.Instance.uiRed, Vector3.zero);
			}
			else
			{
				((GObject)val.GetChild("output").asRichTextField).text = string.Format("{0}/{1}", Convert.ToInt32(num3), LanguagesManager.GetDesc("CsharpCodeZhTcText156"));
				((GObject)val.GetChild("outputChange").asRichTextField).text = "";
			}
			RefreshCurrentWorkCount();
			((GObject)numbersSpine).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(numbersSpine, FGUIManager.Instance.uiGreen, Vector3.zero);
			addWorkerBtn.GetChild("workerButtonSpine").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addWorkerBtn.GetChild("workerButtonSpine").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
		}
		else
		{
			list.numItems = list.numItems;
			int num6 = itemList.ItemIndexToChildIndex(index);
			GObject childAt2 = ((GComponent)itemList).GetChildAt(num6);
			GComponent val2 = (GComponent)childAt2;
			((GObject)val2.GetChild("outputChangeSpine").asGraph).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(val2.GetChild("outputChangeSpine").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
			if (num >= WorkShopBuilding.Slot + WorkShopBuilding.LeaseholdSlot && Convert.ToInt32(addWorkerBtn.GetChild("CurrentWorkerAmount").text) > 0)
			{
				if (numbersHeightLight.playing)
				{
					numbersHeightLight.Stop();
				}
				numbersHeightLight.Play();
				((GObject)numbersSpine).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(numbersSpine, FGUIManager.Instance.uiRed, Vector3.zero);
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText160") + "！" };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 5, arg3: false);
			}
			else if (Convert.ToInt32(addWorkerBtn.GetChild("CurrentWorkerAmount").text) <= 0 && num < WorkShopBuilding.Slot + WorkShopBuilding.LeaseholdSlot)
			{
				if (addWorkerBtn.GetTransition("textHeoghtLight").playing)
				{
					addWorkerBtn.GetTransition("textHeoghtLight").Stop();
				}
				addWorkerBtn.GetTransition("textHeoghtLight").Play();
				addWorkerBtn.GetChild("workerButtonSpine").displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(addWorkerBtn.GetChild("workerButtonSpine").asGraph, FGUIManager.Instance.uiRed, Vector3.zero);
				List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText641") + "！" };
				SharedMessenger.Broadcast("SHOW_TIPS", arg2, 5, arg3: false);
			}
			else if (Convert.ToInt32(addWorkerBtn.GetChild("CurrentWorkerAmount").text) <= 0 && num >= WorkShopBuilding.Slot + WorkShopBuilding.LeaseholdSlot)
			{
				if (addWorkerBtn.GetTransition("textHeoghtLight").playing)
				{
					addWorkerBtn.GetTransition("textHeoghtLight").Stop();
				}
				addWorkerBtn.GetChild("workerButtonSpine").displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(addWorkerBtn.GetChild("workerButtonSpine").asGraph, FGUIManager.Instance.uiRed, Vector3.zero);
				List<string> arg3 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText641") + "！" };
				SharedMessenger.Broadcast("SHOW_TIPS", arg3, 5, arg3: false);
				addWorkerBtn.GetTransition("textHeoghtLight").Play((PlayCompleteCallback)delegate
				{
					//IL_0050: Unknown result type (might be due to invalid IL or missing references)
					if (numbersHeightLight.playing)
					{
						numbersHeightLight.Stop();
					}
					numbersHeightLight.Play();
					((GObject)numbersSpine).displayObject.Dispose();
					FGUIManager.Instance.AddTextSpecialEffects(numbersSpine, FGUIManager.Instance.uiRed, Vector3.zero);
					List<string> arg4 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText160") + "！" };
					SharedMessenger.Broadcast("SHOW_TIPS", arg4, 5, arg3: false);
				});
			}
		}
		UpdateWorkerStatus();
	}

	private void ReduceWorker(GList list, string productId, int index)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		if (index < 0)
		{
			ILRuntimeDebug.LogError($"UI_WorkShopPanel.ReduceWorker, BuildingType={WorkShopBuilding.BuildingType}, list.numItems={list.numItems}, productId={productId} index={index}");
		}
		((GObject)yesBtn).enabled = true;
		list.itemRenderer = new ListItemRenderer(RenderWorkerIncrease);
		int newAssignedWorkers = GetNewAssignedWorkers(productId);
		int listNumItems = list.numItems;
		if (newAssignedWorkers > 0)
		{
			if (listNumItems < 1 || ((GComponent)((GComponent)list).GetChildAt(listNumItems - 1).asButton).GetTransition("reduce").playing)
			{
				return;
			}
			float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ProductionEfficiency", new string[1] { "BuildingType" + WorkShopBuilding.BuildingType });
			GDEProductData gDEProductData = GDMgr.Get<GDEProductData>(productId);
			float _output = 1f / gDEProductData.Time * 3600f * (1f + percentFloatPayload);
			bool flag = false;
			for (int num = ((WorkshopController)WorkShopBuilding.Controller).WorkbenchNominal.Length - 1; num >= 0; num--)
			{
				ProductionConfig newProductionConfigAt = GetNewProductionConfigAt(num);
				if (!flag && newProductionConfigAt.Workers > 0 && newProductionConfigAt.ProductList.Contains(productId))
				{
					newProductionConfigAt.Workers = 0;
					newProductionConfigAt.ProductList.Clear();
					flag = true;
				}
			}
			plannedNumber--;
			((GComponent)((GComponent)list).GetChildAt(listNumItems - 1).asButton).GetTransition("reduce").Play((PlayCompleteCallback)delegate
			{
				//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c4: Expected O, but got Unknown
				//IL_0171: Unknown result type (might be due to invalid IL or missing references)
				//IL_0176: Unknown result type (might be due to invalid IL or missing references)
				//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
				//IL_0267: Unknown result type (might be due to invalid IL or missing references)
				//IL_026c: Unknown result type (might be due to invalid IL or missing references)
				//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
				list.numItems = listNumItems - 1;
				RefreshCurrentWorkCount();
				UpdateWorkerStatus();
				float num3 = (float)WorkShopBuilding.GetAssignedWorkers(productId) * _output;
				float num4 = (float)listNumItems * _output;
				float value = num4 - num3;
				int num5 = itemList.ItemIndexToChildIndex(index);
				GObject childAt2 = ((GComponent)itemList).GetChildAt(num5);
				GComponent val2 = (GComponent)childAt2;
				val2.GetChild("goodsList").data = true;
				if (num4 > num3)
				{
					((GObject)val2.GetChild("output").asRichTextField).text = Convert.ToInt32(num3).ToString();
					((GObject)val2.GetChild("outputChange").asRichTextField).text = "+" + Convert.ToInt32(value) + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText156");
					((GTextField)val2.GetChild("outputChange").asRichTextField).color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
					((GObject)val2.GetChild("outputChangeSpine").asGraph).displayObject.Dispose();
					FGUIManager.Instance.AddTextSpecialEffects(val2.GetChild("outputChangeSpine").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
				}
				else if (num4 < num3)
				{
					((GObject)val2.GetChild("output").asRichTextField).text = Convert.ToInt32(num3).ToString();
					((GObject)val2.GetChild("outputChange").asRichTextField).text = Convert.ToInt32(value) + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText156");
					((GTextField)val2.GetChild("outputChange").asRichTextField).color = Color32.op_Implicit(new Color32((byte)220, (byte)20, (byte)60, byte.MaxValue));
					((GObject)val2.GetChild("outputChangeSpine").asGraph).displayObject.Dispose();
					FGUIManager.Instance.AddTextSpecialEffects(val2.GetChild("outputChangeSpine").asGraph, FGUIManager.Instance.uiRed, Vector3.zero);
				}
				else
				{
					((GObject)val2.GetChild("output").asRichTextField).text = Convert.ToInt32(num3) + "/" + LanguagesManager.GetDesc("CsharpCodeZhTcText156");
					((GObject)val2.GetChild("outputChange").asRichTextField).text = "";
				}
			});
		}
		else
		{
			int num2 = itemList.ItemIndexToChildIndex(index);
			GObject childAt = ((GComponent)itemList).GetChildAt(num2);
			GComponent val = (GComponent)childAt;
			((GObject)val.GetChild("outputChangeSpine").asGraph).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(val.GetChild("outputChangeSpine").asGraph, FGUIManager.Instance.uiRed, Vector3.zero);
			UpdateWorkerStatus();
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText161") + "！" };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 5, arg3: false);
		}
		((GObject)numbersSpine).displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(numbersSpine, FGUIManager.Instance.uiGreen, Vector3.zero);
		addWorkerBtn.GetChild("workerButtonSpine").displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(addWorkerBtn.GetChild("workerButtonSpine").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
	}

	private void ReduceWorker2(string productId)
	{
		((GObject)yesBtn).enabled = true;
		int newAssignedWorkers = GetNewAssignedWorkers(productId);
		if (newAssignedWorkers > 0)
		{
			for (int num = ((WorkshopController)WorkShopBuilding.Controller).WorkbenchNominal.Length - 1; num >= 0; num--)
			{
				ProductionConfig newProductionConfigAt = GetNewProductionConfigAt(num);
				if (newProductionConfigAt.Workers > 0 && newProductionConfigAt.ProductList.Contains(productId))
				{
					newProductionConfigAt.Workers = 0;
					newProductionConfigAt.ProductList.Clear();
					break;
				}
			}
		}
		UpdateWorkerStatus();
	}

	private void RefreshCurrentWorkCount()
	{
		int freeManPower = Dungeon.GetFreeManPower(GameManagers.Instance);
		int num = freeManPower - plannedNumber;
		addWorkerBtn.GetChild("CurrentWorkerAmount").text = $"{num}";
	}

	private void SetBuildingName()
	{
		((GObject)Title.buildingName).text = WorkShopBuilding.Name ?? "";
		if (WorkShopBuilding.Name == LanguagesManager.GetDesc("CsharpCodeZhTcText640"))
		{
			((GObject)UnlockTip).visible = true;
		}
	}

	public void RenderMainUi()
	{
		UpdateWorkingStatus();
		TitleInit();
	}

	private void RenderListItem(int index, GObject obj)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Expected O, but got Unknown
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Expected O, but got Unknown
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Expected O, but got Unknown
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e7: Expected O, but got Unknown
		//IL_067b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0685: Expected O, but got Unknown
		GDEProductData productData = productList[index];
		GComponent button = (GComponent)obj;
		GameManagers instance = GameManagers.Instance;
		if (weaponSet.Contains(productData.ItemId))
		{
			float percentFloatPayload = instance.ModifierManager.GetPercentFloatPayload("ProductionEfficiency", new string[1] { "BuildingType" + WorkShopBuilding.BuildingType });
			float num = 1f / productData.Time * 3600f * (1f + percentFloatPayload);
			string itemId = productData.ItemId;
			int num2 = Item.Level(instance, itemId);
			_evolutionlevel = ((Item.ItemType(itemId) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemId) : num2);
			bool flag = CanShowItemLevel();
			((GObject)button.GetChild("order").asTextField).text = (flag ? string.Format("{0}{1}", num2 - 1, LanguagesManager.GetDesc("CsharpCodeZhTcText124")) : string.Empty);
			((GObject)button.GetChild("unLockGroup").asGroup).visible = true;
			((GObject)button.GetChild("lockGroup").asGroup).visible = false;
			button.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemId);
			((GComponent)button.GetChild("frame").asButton).GetChild("frame").asLoader.url = $"ui://PublicResources/kuang_round 2_lv{_evolutionlevel}";
			((GObject)button.GetChild("title").asTextField).text = SchemaIndexHelper.GetNameById(instance, itemId);
			((GObject)button.GetChild("output").asTextField).text = string.Format("{0}/{1}", Convert.ToInt32(num * (float)WorkShopBuilding.GetAssignedWorkers(productData.Key)), LanguagesManager.GetDesc("CsharpCodeZhTcText156"));
			((GObject)button.GetChild("outputChange").asTextField).text = "";
			((GObject)button.GetChild("stock").asTextField).text = instance.StockController.GetStock(productData.ItemId).ShortNumberFormat();
			GoodsListRenderer(button.GetChild("goodsList").asList, productData);
			WorkerListRenderer(button.GetChild("workersList").asList, productData.Key);
			WorkersBackListRenderer(button.GetChild("workersBackList").asList, productData.Key);
			((GObject)button.GetChild("increase").asButton).onClick.Set((EventCallback0)delegate
			{
				AddWorker(button.GetChild("workersList").asList, productData.Key, index);
			});
			((GObject)button.GetChild("reduce").asButton).onClick.Set((EventCallback0)delegate
			{
				ReduceWorker(button.GetChild("workersList").asList, productData.Key, index);
			});
			if (!flag)
			{
				((GObject)button.GetChild("upgrade").asButton).visible = false;
			}
			else
			{
				((GObject)button.GetChild("upgrade").asButton).visible = true;
				((GObject)button.GetChild("upgrade").asButton).onClick.Set(new EventCallback1(ShowUpgradePanel));
			}
			((GObject)button.GetChild("frame").asButton).onClick.Set((EventCallback0)delegate
			{
				button.EnsureBoundsCorrect();
				((GComponent)itemList).EnsureBoundsCorrect();
				ProductDetailPopup(itemId, 0, productData.Key, "equip", (GObject)(object)button.GetChild("frame").asButton);
			});
		}
		else
		{
			((GObject)button.GetChild("unLockGroup").asGroup).visible = false;
			((GObject)button.GetChild("lockGroup").asGroup).visible = true;
		}
		button.GetChild("recruitmentMark").visible = false;
		foreach (KeyValuePair<string, List<string>> item in SoldiersAndWeaponsDic)
		{
			if (item.Value.Contains(productData.ItemId))
			{
				button.GetChild("recruitmentMark").visible = true;
				break;
			}
		}
		int stock = instance.StockController.GetStock(productData.ItemId);
		int limit = instance.StockController.GetLimit(productData.ItemId);
		int num3 = ((stock >= limit) ? 1 : 0);
		button.GetChild("max").alpha = num3;
		CalculateTotalOutPut(button.GetChild("ExclamationMarkBtn").asButton, string.Format("{0}/{1}", Convert.ToInt32(Mathf.Round(1f / productData.Time * 3600f) * (float)WorkShopBuilding.GetAssignedWorkers(productData.Key)), LanguagesManager.GetDesc("CsharpCodeZhTcText156")));
		((GObject)button).onClick.Set(new EventCallback1(ItemListClick));
		bool CanShowItemLevel()
		{
			return !(WorkShopBuilding.BuildingType == "13") && !(WorkShopBuilding.BuildingType == "9");
		}
	}

	private void OnClickClearAllWorkers()
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < productList.Count; i++)
		{
			string key = productList[i].Key;
			int newAssignedWorkers = GetNewAssignedWorkers(key);
			for (int j = 0; j < newAssignedWorkers; j++)
			{
				ReduceWorker2(key);
			}
		}
		plannedNumber = -WorkShopBuilding.ManPower;
		RefreshCurrentWorkCount();
		((GObject)numbersSpine).displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(numbersSpine, FGUIManager.Instance.uiGreen, Vector3.zero);
		addWorkerBtn.GetChild("workerButtonSpine").displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(addWorkerBtn.GetChild("workerButtonSpine").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
		itemList.numItems = productList.Count;
		"WorkShopPanelClearTip".ToLanguage().ToTip();
	}

	private void CalculateTotalOutPut(GButton button, string outPutInit)
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ProductionEfficiency", new string[1] { "BuildingType" + WorkShopBuilding.BuildingType });
		if (percentFloatPayload > 0f)
		{
			((GObject)button).visible = true;
			((GObject)button).data = new Dictionary<string, object> { 
			{
				"Title",
				LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText155") + "：" + outPutInit
			} };
			((GObject)button).onClick.Set(new EventCallback1(ItemOutPutTip));
		}
		else
		{
			((GObject)button).visible = false;
		}
	}

	private void ItemOutPutTip(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		GButton val = (GButton)context.sender;
		Vector2 val2 = ((GObject)val).LocalToGlobal(Vector2.one / 2f);
		val2 = ((GObject)this).GlobalToLocal(val2);
		Dictionary<string, object> dictionary = (Dictionary<string, object>)((GObject)val).data;
		if (dictionary.ContainsKey("Pos"))
		{
			dictionary["Pos"] = val2;
		}
		else
		{
			dictionary.Add("Pos", val2);
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_ExclamationMarkPanel.Name, dictionary);
	}

	private void RenderGood(int materialIndex, GObject obj)
	{
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		GButton button = obj.asButton;
		int childIndex = ((GComponent)itemList).GetChildIndex((GObject)(object)((GObject)((GObject)button).parent).parent);
		int prodIndex = itemList.ChildIndexToItemIndex(childIndex);
		GDEProductData gDEProductData = productList[prodIndex];
		List<string> list = new List<string> { gDEProductData.Stuff1, gDEProductData.Stuff2, gDEProductData.Stuff3, gDEProductData.Stuff4, gDEProductData.Stuff5 };
		List<int> list2 = new List<int> { gDEProductData.Number1, gDEProductData.Number2, gDEProductData.Number3, gDEProductData.Number4, gDEProductData.Number5 };
		string materialItemId = list[materialIndex];
		if (materialItemId != "null")
		{
			int stock = GameManagers.Instance.StockController.GetStock(materialItemId);
			int num = Item.Level(GameManagers.Instance, materialItemId);
			int num2 = ((num > 0) ? num : Item.Rarity(materialItemId));
			((GComponent)button).GetChild("title").asTextField.color = ((stock <= list2[materialIndex]) ? Color.red : Color.white);
			((GComponent)button).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(materialItemId);
			((GComponent)button).GetChild("frame").asLoader.url = $"ui://PublicResources/kuang_round 2_lv{num2}";
			int num3 = list2[materialIndex];
			float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ProduceCost", new string[1] { "BuildingType" + WorkShopBuilding.BuildingType });
			if (WorkShopBuilding.BuildingType == "13" && percentFloatPayload < 0f)
			{
				num3 = Convert.ToInt32((float)num3 * (1f + percentFloatPayload));
			}
			button.title = $"{stock.ShortNumberFormat()} / {num3}";
			((GComponent)button).GetChild("icon").onClick.Set((EventCallback0)delegate
			{
				((GComponent)button).EnsureBoundsCorrect();
				((GComponent)itemList).EnsureBoundsCorrect();
				ProductDetailPopup(materialItemId, prodIndex, null, "resources", (GObject)(object)button);
			});
		}
	}

	private void RenderWorkerReduce(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		((GObject)((GComponent)asButton).GetChild("reduceState").asImage).visible = true;
	}

	private void RenderWorkerIncrease(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		GComponent parent = ((GObject)((GObject)asButton).parent).parent;
		int childIndex = ((GComponent)itemList).GetChildIndex((GObject)(object)parent);
		int index2 = itemList.ChildIndexToItemIndex(childIndex);
		int assignedWorkers = WorkShopBuilding.GetAssignedWorkers(productList[index2].Key);
		if (index < assignedWorkers)
		{
			((GObject)((GComponent)asButton).GetChild("normalState").asImage).visible = true;
			((GObject)((GComponent)asButton).GetChild("increaseState").asImage).visible = false;
		}
		else
		{
			((GObject)((GComponent)asButton).GetChild("normalState").asImage).visible = true;
			((GObject)((GComponent)asButton).GetChild("increaseState").asImage).visible = true;
		}
	}

	private void UpdateList()
	{
		itemList.RefreshVirtualList();
	}

	private void ListRenderer()
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		if (StockChangeCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(StockChangeCoroutine);
		}
		LoadProduct();
		EventListener onScroll = ((GComponent)itemList).scrollPane.onScroll;
		object obj = _003C_003Ec._003C_003E9__68_0;
		if (obj == null)
		{
			EventCallback0 val = delegate
			{
				SharedMessenger.Broadcast("WORKSHOP_LIST_SCROLLEND");
			};
			_003C_003Ec._003C_003E9__68_0 = val;
			obj = (object)val;
		}
		onScroll.Set((EventCallback0)obj);
		itemList.SetVirtual();
		itemList.itemRenderer = new ListItemRenderer(RenderListItem);
		itemList.numItems = productList.Count;
		((GComponent)itemList).EnsureBoundsCorrect();
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("Workshop.Item");
		instance.Unregister("Workshop.AddWorkerBtn");
		instance.Unregister("Workshop.ReduceWorkerBtn");
		instance.Unregister("Workshop.ItemUpgradeBtn");
		instance.Unregister("Workshop.FirstProductionAddWorkerBtn");
		instance.Unregister("Workshop.FirstProductionReduceWorkerBtn");
		instance.Unregister("Workshop.FirstProductionUpgradeBtn");
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
		Dictionary<string, object> dictionary4 = new Dictionary<string, object>();
		for (int num = 0; num < productList.Count; num++)
		{
			GDEProductData gDEProductData = productList[num];
			int num2 = itemList.ItemIndexToChildIndex(num);
			if (num2 >= 0)
			{
				if (num2 >= ((GComponent)itemList).numChildren)
				{
					break;
				}
				GComponent asCom = ((GComponent)itemList).GetChildAt(num2).asCom;
				dictionary.Add(gDEProductData.Key, asCom);
				dictionary2.Add(gDEProductData.Key, asCom.GetChild("increase"));
				dictionary3.Add(gDEProductData.Key, asCom.GetChild("reduce"));
				dictionary4.Add(gDEProductData.Key, asCom.GetChild("upgrade"));
			}
		}
		instance.Register("Workshop.Item", dictionary);
		instance.Register("Workshop.AddWorkerBtn", dictionary2);
		instance.Register("Workshop.ReduceWorkerBtn", dictionary3);
		instance.Register("Workshop.ItemUpgradeBtn", dictionary4);
		if (dictionary.Count > 0)
		{
			instance.Register("Workshop.FirstProductionAddWorkerBtn", dictionary2.Values.First());
			instance.Register("Workshop.FirstProductionReduceWorkerBtn", dictionary3.Values.First());
			instance.Register("Workshop.FirstProductionUpgradeBtn", dictionary4.Values.First());
			if (StockChangeCoroutine == null)
			{
				StockChangeCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshStock());
			}
		}
	}

	private void GoodsListRenderer(GList list, GDEProductData product)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		List<string> list2 = new List<string> { product.Stuff1, product.Stuff2, product.Stuff3, product.Stuff4, product.Stuff5 };
		int i;
		for (i = 0; i < list2.Count; i++)
		{
			string text = list2[i];
			if (text == "null")
			{
				break;
			}
		}
		((GObject)list).data = false;
		list.itemRenderer = new ListItemRenderer(RenderGood);
		list.numItems = i;
	}

	private void WorkerListRenderer(GList list, string Id)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		list.itemRenderer = new ListItemRenderer(RenderWorkerIncrease);
		list.numItems = GetNewAssignedWorkers(Id);
	}

	private void WorkersBackListRenderer(GList list, string Id)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		list.itemRenderer = new ListItemRenderer(RenderWorkerReduce);
		list.numItems = 12;
	}

	private void OnProductUnlocked(string productId)
	{
		Dictionary<string, int> productStates = WorkShopBuilding.GetProductStates(true);
		if (productStates.ContainsKey(productId) && !weaponSet.Contains(productId))
		{
			weaponSet.Add(productId);
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

	private void TitleInit()
	{
		Title.icon.url = "ui://PublicResources/Building" + WorkShopBuilding.BuildingType;
		((GObject)((GComponent)upButton).GetChild("level").asTextField).text = WorkShopBuilding.Level.ToString();
	}

	private void InitBackground()
	{
		List<string> list = new List<string>
		{
			string.Empty,
			"4",
			"5",
			"6",
			"13",
			"8",
			"9"
		};
		int num = list.IndexOf(WorkShopBuilding.BuildingType);
		if (num < 0)
		{
			num = 0;
		}
		BuildingType.SetSelectedIndex(num);
	}

	private void InitWorkerSpine()
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)canvasObject != (Object)null)
		{
			return;
		}
		ref GameObject reference = ref canvasObject;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		if ((Object)(object)canvasObject != (Object)null)
		{
			canvasObject.transform.localScale = new Vector3(80f, 80f, 80f);
			canvasObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
			canvasObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			gw = new GoWrapper(canvasObject);
			((DisplayObject)gw).SetXY(0f, 0f);
			((DisplayObject)gw).pivot = new Vector2(0.5f, 0.5f);
			((DisplayObject)gw).scaleX = 1f;
			workUI.SetNativeObject((DisplayObject)(object)gw);
		}
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
					string text = "default";
					List<string> list = new List<string>
					{
						string.Empty,
						"4",
						"5",
						"6",
						"13",
						"8",
						"9"
					};
					int num = list.IndexOf(WorkShopBuilding.BuildingType);
					text = $"skin_work{num}";
					string idleAnim = $"worker{num}_idle";
					List<string> workAnims = new List<string>
					{
						$"worker{num}_work1",
						$"worker{num}_work2"
					};
					SpineHelper.SetSkin((ISkeletonAnimation)(object)component, text);
					((MonoBehaviour)component).StartCoroutine(WorkerAnimation(component, idleAnim, workAnims));
				}
			}
		});
	}

	private void CheckUpBtnTip()
	{
		((GObject)((GComponent)upButton).GetChild("redPoint").asImage).visible = WorkShopBuilding.CanUpgrade() || WorkShopBuilding.HasNewMaxLevel();
	}

	public void CheckWorkersCanAssign()
	{
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		RefreshCurrentWorkCount();
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
								((GObject)yesBtn).onClick.Call();
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
		if (weaponList.Count != 0)
		{
			weaponList.Clear();
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		if (toUnloadAni && singleProductId == null)
		{
			SpawnManager.Instance.UnloadAnimation("Goblinworker_UI_001");
		}
		soldierPanel = null;
		campPanel = null;
		singleProductId = null;
	}

	private void UpdateWorkingStatus()
	{
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		if (WorkShopBuilding.LeaseholdSlot > 0)
		{
			((GObject)numbers).text = $"{WorkShopBuilding.Slot + WorkShopBuilding.LeaseholdSlot - WorkShopBuilding.ManPower}/{WorkShopBuilding.Slot}[color=#AFF627]+{WorkShopBuilding.LeaseholdSlot}[/color]";
			((GObject)ExclamationMarkBtn).visible = true;
			((GObject)ExclamationMarkBtn).data = new Dictionary<string, object>
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
			((GObject)numbers).text = $"{WorkShopBuilding.Slot - WorkShopBuilding.ManPower}/{WorkShopBuilding.Slot}";
			((GObject)ExclamationMarkBtn).visible = false;
		}
	}

	private void InitItemSort()
	{
		bool flag = GameManagers.Instance.UserArchiveManager.GetUserLevel() >= 20;
		((GObject)ItemSort).visible = flag;
		if (flag)
		{
			int num = GameLocalDataManager.GetInt("ITEM_SORT_PREFS");
			ItemSort.Status.SetSelectedIndex(num);
			_sortState = (ProductSortState)num;
		}
	}

	private void ItemSortClick()
	{
		int num = (ItemSort.Status.selectedIndex + 1) % 3;
		ItemSort.Status.SetSelectedIndex(num);
		_sortState = (ProductSortState)num;
		GameLocalDataManager.SetInt("ITEM_SORT_PREFS", num);
		singleProductId = null;
		if (StockChangeCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(StockChangeCoroutine);
		}
		LoadProduct();
		UpdateList();
		if (StockChangeCoroutine == null)
		{
			StockChangeCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshStock());
		}
	}

	private void LoadProduct()
	{
		productList.Clear();
		weaponSet.Clear();
		Dictionary<string, int> productStates = WorkShopBuilding.GetProductStates(true, ProductFilter.ShowUp, ProductFilter.Normal);
		List<GDEProductData> list = new List<GDEProductData>();
		List<GDEProductData> list2 = new List<GDEProductData>();
		List<string> unlockedProducts = GameManagers.Instance.UserArchiveManager.GetUnlockedProducts();
		foreach (KeyValuePair<string, int> item in productStates)
		{
			if (BuildingManager.Products.ContainsKey(item.Key))
			{
				GDEProductData gDEProductData = BuildingManager.Products[item.Key];
				if (unlockedProducts.Contains(gDEProductData.Key))
				{
					weaponSet.Add(gDEProductData.ItemId);
					list.Add(gDEProductData);
				}
				else
				{
					list2.Add(gDEProductData);
				}
			}
		}
		if (_sortState == ProductSortState.CountAsc)
		{
			list.Sort(delegate(GDEProductData a, GDEProductData b)
			{
				int stock = GameManagers.Instance.StockController.GetStock(a.ItemId);
				int stock2 = GameManagers.Instance.StockController.GetStock(b.ItemId);
				int num = stock.CompareTo(stock2);
				return (num != 0) ? num : SortByLevel(a, b);
			});
		}
		else if (_sortState == ProductSortState.CountDesc)
		{
			list.Sort(delegate(GDEProductData a, GDEProductData b)
			{
				int stock = GameManagers.Instance.StockController.GetStock(a.ItemId);
				int num = GameManagers.Instance.StockController.GetStock(b.ItemId).CompareTo(stock);
				return (num != 0) ? num : SortByLevel(a, b);
			});
		}
		else
		{
			List<GDEProductData> list3 = new List<GDEProductData>();
			List<GDEProductData> list4 = new List<GDEProductData>();
			foreach (GDEProductData item2 in list)
			{
				if (WorkShopBuilding.GetAssignedWorkers(item2.Key) > 0)
				{
					list3.Add(item2);
				}
				else
				{
					list4.Add(item2);
				}
			}
			list3.Sort(SortByLevel);
			list4.Sort(SortByLevel);
			list.Clear();
			list.AddRange(list3);
			list.AddRange(list4);
		}
		productList.AddRange(list);
		if (singleProductId != null)
		{
			List<GDEProductData> list5 = productList;
			SortByWeaponList(ref list5);
		}
		productList.AddRange(list2);
	}

	public void ProductDetailPopup(string itemId, int num, string productId, string type, GObject obj)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (type == "equip")
		{
			Vector2 val = ((GObject)obj.parent).LocalToGlobal(Vector2.zero);
			val = ((GObject)this).GlobalToLocal(val);
			dictionary.Add("ItemId", BuildingManager.Products[productId].ItemId);
			dictionary.Add("Pos", val);
			dictionary.Add("Sender", obj);
			dictionary.Add("HideCheckBtn", true);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MaterialIntroductionPanel.Name, dictionary);
		}
		else if (type == "resources")
		{
			Vector2 val2 = ((GObject)((GObject)obj.parent).parent).LocalToGlobal(Vector2.zero);
			val2 = ((GObject)this).GlobalToLocal(val2);
			dictionary.Add("ItemId", itemId);
			dictionary.Add("Pos", val2);
			dictionary.Add("Sender", obj);
			GDEProductData productByItemId = GameManagers.Instance.BuildingManager.GetProductByItemId(itemId);
			if (productByItemId == null)
			{
				dictionary.Add("HideCheckBtn", true);
			}
			else if (!BuildingManager.Products.ContainsKey(productByItemId.Key))
			{
				dictionary.Add("HideCheckBtn", true);
			}
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MaterialIntroductionPanel.Name, dictionary);
		}
	}

	private void UpdateWorkerStatus()
	{
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		int slot = WorkShopBuilding.Slot;
		int num = CheckAllWorkers();
		if (WorkShopBuilding.LeaseholdSlot > 0)
		{
			((GObject)numbers).text = $"{slot + WorkShopBuilding.LeaseholdSlot - num}/{slot}[color=#AFF627]+{WorkShopBuilding.LeaseholdSlot}[/color]";
			((GObject)ExclamationMarkBtn).visible = true;
			((GObject)ExclamationMarkBtn).data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText165"), slot)
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
			((GObject)numbers).text = $"{slot - num}/{slot}";
			((GObject)ExclamationMarkBtn).visible = false;
		}
	}

	public int CheckAllWorkers()
	{
		int num = 0;
		foreach (ProductionConfig value in NewProductConfig.Values)
		{
			num += value.Workers;
		}
		return num;
	}

	private IEnumerator RefreshStock()
	{
		while (true)
		{
			UpdateStock();
			yield return (object)new WaitForSeconds(1f);
		}
	}

	public void UpdateStock()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Expected O, but got Unknown
		//IL_0322: Expected O, but got Unknown
		for (int i = 0; i < ((GComponent)itemList).numChildren; i++)
		{
			GComponent button = (GComponent)((GComponent)itemList).GetChildAt(i);
			if (((GObject)button.GetChild("lockGroup").asGroup).visible || i >= itemList.numItems)
			{
				continue;
			}
			int index = itemList.ChildIndexToItemIndex(i);
			GDEProductData gDEProductData = productList[index];
			GameManagers instance = GameManagers.Instance;
			((GObject)button.GetChild("stock").asTextField).text = instance.StockController.GetStock(gDEProductData.ItemId).ShortNumberFormat();
			int stock = instance.StockController.GetStock(gDEProductData.ItemId);
			int limit = instance.StockController.GetLimit(gDEProductData.ItemId);
			int num = ((stock >= limit) ? 1 : 0);
			button.GetChild("max").alpha = num;
			List<string> list = new List<string> { gDEProductData.Stuff1, gDEProductData.Stuff2, gDEProductData.Stuff3, gDEProductData.Stuff4, gDEProductData.Stuff5 };
			float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ProduceCost", new string[1] { "BuildingType" + WorkShopBuilding.BuildingType });
			List<int> list2 = new List<int>
			{
				Convert.ToInt32((float)gDEProductData.Number1 * (1f + percentFloatPayload)),
				Convert.ToInt32((float)gDEProductData.Number2 * (1f + percentFloatPayload)),
				Convert.ToInt32((float)gDEProductData.Number3 * (1f + percentFloatPayload)),
				Convert.ToInt32((float)gDEProductData.Number4 * (1f + percentFloatPayload)),
				Convert.ToInt32((float)gDEProductData.Number5 * (1f + percentFloatPayload))
			};
			PlayCompleteCallback val = default(PlayCompleteCallback);
			for (int j = 0; j < list.Count; j++)
			{
				string text = list[j];
				if (!(text != "null"))
				{
					continue;
				}
				int stock2 = instance.StockController.GetStock(text);
				GButton asButton = ((GComponent)button.GetChild("goodsList").asList).GetChildAt(j).asButton;
				if (stock2 < list2[j])
				{
					asButton.title = $"[color=#FF5353]{stock2.ShortNumberFormat()}[/color][color=#FF5353] / [/color][color=#FF5353]{list2[j]}[/color]";
					if (button.GetChild("goodsList").data == null || !(bool)button.GetChild("goodsList").data)
					{
						continue;
					}
					Transition transition = ((GComponent)asButton).GetTransition("breathing");
					PlayCompleteCallback obj = val;
					if (obj == null)
					{
						PlayCompleteCallback val2 = delegate
						{
							button.GetChild("goodsList").data = false;
						};
						PlayCompleteCallback val3 = val2;
						val = val2;
						obj = val3;
					}
					transition.Play(obj);
				}
				else
				{
					if (((GComponent)asButton).GetTransition("breathing").playing)
					{
						((GComponent)asButton).GetTransition("breathing").Stop(true, true);
					}
					asButton.title = $"[color=#FFFFFF]{stock2.ShortNumberFormat()}[/color][color=#FFFFFF] / [/color][color=#FFFFFF]{list2[j]}[/color]";
				}
			}
		}
	}

	private void ShowUpgradePanel(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		GComponent parent = ((GObject)context.sender).parent;
		int childIndex = ((GComponent)itemList).GetChildIndex((GObject)(object)parent);
		int index = itemList.ChildIndexToItemIndex(childIndex);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("ProductId", productList[index].Key);
		dictionary.Add("MainUI", this);
		dictionary.Add("Style", "Work");
		if (soldierPanel != null)
		{
			dictionary.Add("Soldier", soldierPanel);
		}
		if (campPanel != null)
		{
			dictionary.Add("Camp", campPanel);
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_ProductUpGradePanel.Name, dictionary);
	}

	private void UpGrade()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Building", WorkShopBuilding);
		dictionary.Add("Parent", this);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary);
	}

	private void SortByWeaponList(ref List<GDEProductData> list)
	{
		GDEProductData gDEProductData = null;
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (GameManagers.Instance.BuildingManager.GetProductByItemId(list[num].ItemId).Key == singleProductId)
			{
				gDEProductData = list[num];
				list.Remove(list[num]);
				break;
			}
		}
		if (gDEProductData != null)
		{
			list.Insert(0, gDEProductData);
		}
	}

	private int SortByWorkers(GDEProductData a, GDEProductData b)
	{
		return WorkShopBuilding.GetAssignedWorkers(b.Key).CompareTo(WorkShopBuilding.GetAssignedWorkers(a.Key));
	}

	private int SortByLevel(GDEProductData a, GDEProductData b)
	{
		return Item.Level(GameManagers.Instance, b.ItemId).CompareTo(Item.Level(GameManagers.Instance, a.ItemId));
	}
}
