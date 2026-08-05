using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Spine.Unity;
using UI.AddCredit;
using UI.Contract;
using UI.GiftBag;
using UI.LegendItemsDraw;
using UI.MonthCard;
using UI.PublicResources;
using UI.WarOrder;
using UI.WorkShop;
using UnityEngine;

namespace UI.BlackMarketer;

public class UI_BlackMarketerPanel : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventCallback0 _003C_003E9__44_1;

		internal void _003CSetClickEvent_003Eb__44_1()
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText21") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	public Controller ShowWarOrder;

	public GLoader background;

	public GImage n17;

	public GComponent n16;

	public GComponent n19;

	public GComponent n12;

	public GImage n13;

	public GImage n14;

	public GImage n22;

	public UI_CardLoader CardLoader;

	public GComponent n20;

	public GComponent n15;

	public GImage n21;

	public GImage n23;

	public GButton backBtn;

	public UI_Title titleCom;

	public GComponent addDiamondBtn;

	public GGraph workUI;

	public UI_WarOrderBtn WarOrderBtn;

	public GMovieClip n11;

	public const string URL = "ui://036k96hrlkzg0";

	public static string Name = "UI_BlackMarketerPanel";

	public static UI_BlackMarketerPanel BlackMarketerPanel;

	private List<string> textureList = new List<string>();

	private List<Activity> blackMarketActivities = new List<Activity>();

	public UI_ProductionNumFloating NumFloating;

	private bool toUnloadAni;

	private GameObject _canvasObject;

	private readonly BlackMarketerPanelsSort _panelsSort = new BlackMarketerPanelsSort();

	private bool showLegendItemCard;

	public static string GetURL()
	{
		return "ui://036k96hrlkzg0";
	}

	public static UI_BlackMarketerPanel CreateInstance()
	{
		return (UI_BlackMarketerPanel)(object)UIPackage.CreateObject("BlackMarketer", "BlackMarketerPanel");
	}

	public static UI_BlackMarketerPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BlackMarketerPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://036k96hrlkzg0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ShowWarOrder = ((GComponent)this).GetController("ShowWarOrder");
		background = (GLoader)((GComponent)this).GetChild("background");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n16 = (GComponent)((GComponent)this).GetChild("n16");
		n19 = (GComponent)((GComponent)this).GetChild("n19");
		n12 = (GComponent)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		CardLoader = (UI_CardLoader)(object)((GComponent)this).GetChild("CardLoader");
		n20 = (GComponent)((GComponent)this).GetChild("n20");
		n15 = (GComponent)((GComponent)this).GetChild("n15");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		titleCom = (UI_Title)(object)((GComponent)this).GetChild("titleCom");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		workUI = (GGraph)((GComponent)this).GetChild("workUI");
		WarOrderBtn = (UI_WarOrderBtn)(object)((GComponent)this).GetChild("WarOrderBtn");
		n11 = (GMovieClip)((GComponent)this).GetChild("n11");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		showLegendItemCard = IsLegendItemDrawOpen();
		UpdateMainUi();
		UpdateDiamondNum();
		SetBuildingName();
		ShowWarOrder.SetSelectedIndex(0);
		if (CacheManager.Instance.Get<Cache_WarOrderState>().IsAvailable)
		{
			ShowWarOrder.SetSelectedIndex(1);
			((GObject)WarOrderBtn.RedDot).visible = CacheManager.Instance.Get<Cache_WarOrderState>().IsShowRedDot;
		}
		((GObject)background).width = ((GObject)GRoot.inst).width;
	}

	public static bool IsLegendItemDrawOpen()
	{
		return LegendItemsHelper.HasAnyLegendItem || (VersionManager.LegendItemDrawSwitch && GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1005").Contains("P520"));
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)WarOrderBtn).onClick.Add(new EventCallback1(OnClickWarOrderBtn));
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		((GObject)addDiamondBtn.GetChild("addButton").asButton).onClick.Add(new EventCallback0(addDiamond));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<Cache_WarOrderState>(Cache_WarOrderState.ON_REDDOT_CHANGE, OnChangeWarOrderRedDot);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		((GObject)addDiamondBtn.GetChild("addButton").asButton).onClick.Remove(new EventCallback0(addDiamond));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<Cache_WarOrderState>(Cache_WarOrderState.ON_REDDOT_CHANGE, OnChangeWarOrderRedDot);
	}

	public void BeforeDestroy()
	{
		BlackMarketerPanel = null;
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("BlackMarket.LotteryEntrance");
		instance.Unregister("BlackMarket.Entrance");
		instance.Unregister("BlackMarket.ExitBtn", backBtn);
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("BlackMarket.ExitBtn", backBtn);
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		UiAudioManager.Instance.PlayBackgroundSound("Building16_Click");
		BlackMarketerPanel = this;
		InitWorkerSpine();
		SetUpCardLoaderLen();
	}

	private void InitWorkerSpine()
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)_canvasObject != (Object)null)
		{
			return;
		}
		GameObject canvasObject = default(GameObject);
		ref GameObject reference = ref canvasObject;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		_canvasObject = canvasObject;
		if ((Object)(object)canvasObject != (Object)null)
		{
			canvasObject.transform.localScale = new Vector3(80f, 80f, 80f);
			canvasObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
			canvasObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val = new GoWrapper(canvasObject);
			((DisplayObject)val).SetXY(0f, 0f);
			((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
			((DisplayObject)val).scaleX = 1f;
			workUI.SetNativeObject((DisplayObject)(object)val);
		}
		SpawnManager.Instance.LoadAnimation("merchant_UI").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				toUnloadAni = true;
				GameObject obj2 = canvasObject;
				SkeletonAnimation val2 = ((obj2 != null) ? obj2.GetComponent<SkeletonAnimation>() : null);
				if ((Object)(object)val2 != (Object)null && (Object)(object)asset != (Object)null)
				{
					((SkeletonRenderer)val2).skeletonDataAsset = asset;
					((SkeletonRenderer)val2).Initialize(true);
					string text = "skin1";
					SpineHelper.SetSkin((ISkeletonAnimation)(object)val2, text);
					((MonoBehaviour)val2).StartCoroutine(UI_WorkShopPanel.WorkerAnimation(val2, "idle2", new List<string> { "work2", "work3" }));
				}
			}
		});
	}

	private void SetBuildingName()
	{
		((GObject)titleCom.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText147") ?? "";
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		if (!(itemId == "Gem"))
		{
			return;
		}
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		((GObject)addDiamondBtn.GetChild("num").asTextField).text = $"{stock}";
		int num = ((addDiamondBtn.GetChild("num").data != null) ? ((int)addDiamondBtn.GetChild("num").data) : stock);
		if (num != stock && stock > num)
		{
			int num2 = stock - num;
			if (NumFloating == null)
			{
				NumFloating = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			}
			if (!((GObject)NumFloating).onStage)
			{
				FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloating, addDiamondBtn, stock - num);
			}
			else
			{
				((GObject)NumFloating.Title).text = $"+{(int)((GObject)NumFloating.Title).data + num2}";
				((GObject)NumFloating.Title).data = (int)((GObject)NumFloating.Title).data + num2;
			}
		}
		addDiamondBtn.GetChild("num").data = stock;
		addDiamondBtn.GetChild("textSFXBack").displayObject.Dispose();
		FGUIManager.Instance.AddTextSpecialEffects(addDiamondBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero);
		UpdateDrawItemCard();
	}

	private void UpdateDiamondNum()
	{
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
		int stock = GameManagers.Instance.StockController.GetStock("Gem");
		((GObject)addDiamondBtn.GetChild("num").asTextField).text = stock.ToString();
		addDiamondBtn.GetChild("num").data = stock;
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		if (toUnloadAni)
		{
			SpawnManager.Instance.UnloadAnimation("merchant_UI");
		}
		FGUIManager.Instance.activityEntranceController?.ShowSpecialActivityEntrance();
	}

	private void SetClickEvent(GComponent button, string uiName, Activity activity = null)
	{
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected O, but got Unknown
		((GObject)button).data = uiName;
		Dictionary<string, object> dic = new Dictionary<string, object> { { "Activity", activity } };
		if (!string.IsNullOrWhiteSpace(uiName))
		{
			if (uiName == "UI_GiftBagPanel")
			{
				dic.Add("Parent", this);
			}
			else if (uiName == "UI_MonthCardPanel")
			{
				dic.Add("Parent", this);
			}
			else if (uiName == "UI_ContractPanel")
			{
				dic.Add("Parent", this);
			}
			else if (uiName == "UI_BlackMarketerAddCredit")
			{
				dic.Add("Parent", this);
			}
			else if (uiName == "UI_LegendItemsDrawPanel")
			{
				dic.Add("Parent", this);
			}
			else
			{
				dic.Add("Parent", this);
			}
			((GObject)button).onClick.Set((EventCallback0)delegate
			{
				if (UiHelper.blackMarketStoryPlayed)
				{
					if (!dic.ContainsKey("isStory"))
					{
						dic.Add("isStory", true);
					}
					UiHelper.blackMarketStoryPlayed = false;
				}
				GameController.Contexts.Service<IUiService>().OpenPanel(uiName, dic);
			});
			return;
		}
		EventListener onClick = ((GObject)button).onClick;
		object obj = _003C_003Ec._003C_003E9__44_1;
		if (obj == null)
		{
			EventCallback0 val = delegate
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText21") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			};
			_003C_003Ec._003C_003E9__44_1 = val;
			obj = (object)val;
		}
		onClick.Set((EventCallback0)obj);
	}

	public void UpdateMainUi()
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		List<Activity> list = new List<Activity>();
		list.AddRange(GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.BlackMarket, null, isSort: false));
		blackMarketActivities.Clear();
		foreach (Activity item in list)
		{
			ActivityStatus status = item.GetStatus(GameManagers.Instance);
			if (status == ActivityStatus.Enabled)
			{
				blackMarketActivities.Add(item);
			}
		}
		_panelsSort.SortBlackMarketerActivities(blackMarketActivities);
		if (((GObject)this).isDisposed)
		{
			return;
		}
		int count = blackMarketActivities.Count;
		CardLoader.cardList.itemRenderer = new ListItemRenderer(RenderCardListItem);
		CardLoader.cardList.numItems = count;
		int num = 1;
		num += RenderLegendItemCard();
		RenderDrawCard();
		count = CardLoader.cardList.numItems;
		CardLoader.cardList.align = (AlignType)(count <= 3);
		SetUpCardLoaderLen();
		UiTagManager instance = UiTagManager.Instance;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		for (int i = 0; i < blackMarketActivities.Count; i++)
		{
			GButton asButton = ((GComponent)CardLoader.cardList).GetChildAt(i + num).asButton;
			string activityId = blackMarketActivities[i].ActivityId;
			string text = ActivityManager.LocaleActivities.FirstOrDefault((string localActivityId) => activityId.StartsWith(localActivityId));
			if (!string.IsNullOrEmpty(text))
			{
				activityId = text;
			}
			dictionary.Add(activityId, asButton);
		}
		instance.Unregister("BlackMarket.Entrance");
		instance.Register("BlackMarket.Entrance", dictionary);
	}

	private void SetUpCardLoaderLen()
	{
		if (((GComponent)CardLoader.cardList).numChildren > 0)
		{
			float width = ((GComponent)CardLoader.cardList).GetChildAt(0).width;
			int numItems = CardLoader.cardList.numItems;
			((GObject)CardLoader.cardList).width = (width + (float)CardLoader.cardList.columnGap) * (float)numItems - (float)CardLoader.cardList.columnGap + 100f;
		}
	}

	private void RenderCardListItem(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		Activity activity = blackMarketActivities[index];
		int selectedIndex = 3;
		switch (activity.UiName)
		{
		case "UI_GiftBagPanel":
			((GComponent)asButton).GetChild("newIcon").visible = activity.HasAnyNewMsg(GameManagers.Instance);
			if (((GComponent)asButton).GetTransition("breathing").playing)
			{
				((GComponent)asButton).GetTransition("breathing").Stop();
			}
			if (((GComponent)asButton).GetChild("newIcon").visible)
			{
				((GComponent)asButton).GetTransition("breathing").Play(-1, 0f, (PlayCompleteCallback)null);
			}
			selectedIndex = 0;
			break;
		case "UI_MonthCardPanel":
		{
			((GComponent)asButton).GetChild("ExclamationTipBtn").touchable = false;
			LeaseholdManager leaseholdManager = GameManagers.Instance.LeaseholdManager;
			bool visible = leaseholdManager.CanClaimDailyBonus("OverlordContract") || leaseholdManager.CanClaimDailyBonus("PrimeContract");
			((GComponent)asButton).GetChild("ExclamationTipBtn").visible = visible;
			selectedIndex = 1;
			break;
		}
		case "UI_BlackMarketerAddCredit":
			selectedIndex = 2;
			break;
		case "UI_MtgGiftPacksPanel":
			selectedIndex = 5;
			break;
		}
		((GComponent)asButton).GetController("CategoryController").selectedIndex = selectedIndex;
		SetClickEvent((GComponent)(object)asButton, activity.UiName, activity);
	}

	private void RenderDrawCard()
	{
		GButton asButton = CardLoader.cardList.AddItemFromPool().asButton;
		((GComponent)CardLoader.cardList).SetChildIndex((GObject)(object)asButton, 0);
		UiTagManager.Instance.Register("BlackMarket.LotteryEntrance", asButton);
		((GComponent)asButton).GetController("CategoryController").selectedIndex = 3;
		SetClickEvent((GComponent)(object)asButton, "UI_ContractPanel");
		UpdateDrawItemCard();
	}

	private void UpdateDrawItemCard()
	{
		UI_CardBasis uI_CardBasis = (UI_CardBasis)(object)((GComponent)CardLoader.cardList).GetChildAt(0);
		if (uI_CardBasis.ExclamationTipBtn == null)
		{
			return;
		}
		((GObject)uI_CardBasis.ExclamationTipBtn).visible = false;
		foreach (Activity item in GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.Lottery))
		{
			if (item.HasAnyNewMsg(GameManagers.Instance))
			{
				((GObject)uI_CardBasis.ExclamationTipBtn).visible = true;
				break;
			}
		}
	}

	private int RenderLegendItemCard()
	{
		if (showLegendItemCard)
		{
			GButton asButton = CardLoader.cardList.AddItemFromPool().asButton;
			((GComponent)CardLoader.cardList).SetChildIndex((GObject)(object)asButton, 0);
			((GComponent)asButton).GetController("CategoryController").selectedIndex = 4;
			SetClickEvent((GComponent)(object)asButton, "UI_LegendItemsDrawPanel");
			((GComponent)asButton).GetChild("n29").visible = LegendItemsHelper.IsFirstLegendItemsDraw;
			return 1;
		}
		return 0;
	}

	private void UpdateLegendItemCard()
	{
		if (showLegendItemCard)
		{
			UI_CardBasis uI_CardBasis = (UI_CardBasis)(object)((GComponent)CardLoader.cardList).GetChildAt(1);
			((GObject)uI_CardBasis.n29).visible = LegendItemsHelper.IsFirstLegendItemsDraw;
		}
	}

	public void UpdateItemCard(string panelName)
	{
		if (panelName == UI_ContractPanel.Name)
		{
			UpdateDrawItemCard();
			return;
		}
		if (panelName == UI_LegendItemsDrawPanel.Name)
		{
			UpdateLegendItemCard();
			return;
		}
		int num = _panelsSort.GetUiPanelIndex(panelName) - 1;
		Activity activity = blackMarketActivities[num];
		int num2 = 1 + (showLegendItemCard ? 1 : 0) + num;
		UI_CardBasis uI_CardBasis = (UI_CardBasis)(object)((GComponent)CardLoader.cardList).GetChildAt(num2);
		if (activity.UiName == UI_GiftBagPanel.Name)
		{
			((GObject)uI_CardBasis.newIcon).visible = activity.HasAnyNewMsg(GameManagers.Instance);
			if (uI_CardBasis.breathing.playing)
			{
				uI_CardBasis.breathing.Stop();
			}
			if (((GObject)uI_CardBasis.newIcon).visible)
			{
				uI_CardBasis.breathing.Play(-1, 0f, (PlayCompleteCallback)null);
			}
		}
		else if (activity.UiName == UI_MonthCardPanel.Name)
		{
			((GObject)uI_CardBasis.ExclamationTipBtn).touchable = false;
			LeaseholdManager leaseholdManager = GameManagers.Instance.LeaseholdManager;
			bool visible = leaseholdManager.CanClaimDailyBonus("OverlordContract") || leaseholdManager.CanClaimDailyBonus("PrimeContract");
			((GObject)uI_CardBasis.ExclamationTipBtn).visible = visible;
		}
	}

	private void addDiamond()
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

	public void OnClickWarOrderBtn(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_WarOrderPanel.Name, null);
	}

	private void OnChangeWarOrderRedDot(Cache_WarOrderState cache)
	{
		((GObject)WarOrderBtn.RedDot).visible = cache.IsShowRedDot;
	}
}
