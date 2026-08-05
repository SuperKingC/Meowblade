using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.AddCredit;
using UI.BlackMarketer;
using UI.GameActivity;
using UI.MainCity;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.GiftBag;

public class UI_GiftBagPanel : GComponent, IUiController
{
	public Controller IsEmpty;

	public GLoader background;

	public GImage n58;

	public GComponent n59;

	public GComponent n60;

	public GComponent n61;

	public GImage n62;

	public GImage n63;

	public GImage n32;

	public GButton backBtn;

	public UI_Title titleCom;

	public GComponent addCouponBtn;

	public GComponent addDiamondBtn;

	public GImage n6;

	public GImage n48;

	public GImage n49;

	public GGroup back;

	public UI_HotSaleGift HotSaleGift;

	public GGroup empty;

	public GImage n53;

	public GImage n52;

	public GTextField tip2;

	public GTextField tip;

	public GList PagesBack;

	public GList cardList;

	public GList Pages;

	public GButton Help;

	public GTextField tip3;

	public GGroup WeeklyTip;

	public UI_HelpPanel HelpPanel;

	public GGraph missibleSfxBack;

	public GGraph missbleEndPos;

	public UI_PageSwitch pageSwitch;

	public const string URL = "ui://4fqsd8h6avmf3";

	public static string Name = "UI_GiftBagPanel";

	private bool isStory;

	private Coroutine Real_RenderHotSale;

	private float cardListTopOffset = 0f;

	private Coroutine Real_RenderMainItems;

	private int currentCount;

	private Coroutine showMainPanelCoroutine;

	private Coroutine loadSomeUiPublicResourcesCoroutine;

	private List<string> textureList = new List<string>();

	private IUiController parent;

	private Activity storeActivity;

	private List<Shift.Legion.Common.Models.Store.StoreItem> itemList = new List<Shift.Legion.Common.Models.Store.StoreItem>();

	private List<Shift.Legion.Common.Models.Store.StoreItem> hotSaleData = new List<Shift.Legion.Common.Models.Store.StoreItem>();

	private List<KeyValuePair<string, int>> hotSaleContent = new List<KeyValuePair<string, int>>();

	private UI_ProductionNumFloating NumFloating;

	private Coroutine TimeLimitRemainingCoroutine;

	private string curPageKey;

	private Dictionary<string, List<Shift.Legion.Common.Models.Store.StoreItem>> totalGifts = new Dictionary<string, List<Shift.Legion.Common.Models.Store.StoreItem>>();

	private bool showLegendItemCard;

	private string aimTabName;

	private const string HotSalePageName = "热卖";

	private const string LegendItemPackName = "宝物";

	private const string GvGPackName = "远征";

	private readonly Dictionary<string, string> _pageNameKeys = new Dictionary<string, string>();

	public static string GetURL()
	{
		return "ui://4fqsd8h6avmf3";
	}

	public static UI_GiftBagPanel CreateInstance()
	{
		return (UI_GiftBagPanel)(object)UIPackage.CreateObject("GiftBag", "GiftBagPanel");
	}

	public static UI_GiftBagPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GiftBagPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6avmf3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected O, but got Unknown
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsEmpty = ((GComponent)this).GetController("IsEmpty");
		background = (GLoader)((GComponent)this).GetChild("background");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n59 = (GComponent)((GComponent)this).GetChild("n59");
		n60 = (GComponent)((GComponent)this).GetChild("n60");
		n61 = (GComponent)((GComponent)this).GetChild("n61");
		n62 = (GImage)((GComponent)this).GetChild("n62");
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		titleCom = (UI_Title)(object)((GComponent)this).GetChild("titleCom");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n49 = (GImage)((GComponent)this).GetChild("n49");
		back = (GGroup)((GComponent)this).GetChild("back");
		HotSaleGift = (UI_HotSaleGift)(object)((GComponent)this).GetChild("HotSaleGift");
		empty = (GGroup)((GComponent)this).GetChild("empty");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		string id = "ui://4fqsd8h6avmf3".Replace("ui://", "") + "-" + ((GObject)tip2).id;
		((GObject)tip2).text = LanguagesManager.GetDesc(id);
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://4fqsd8h6avmf3".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		PagesBack = (GList)((GComponent)this).GetChild("PagesBack");
		cardList = (GList)((GComponent)this).GetChild("cardList");
		Pages = (GList)((GComponent)this).GetChild("Pages");
		Help = (GButton)((GComponent)this).GetChild("Help");
		tip3 = (GTextField)((GComponent)this).GetChild("tip3");
		string id3 = "ui://4fqsd8h6avmf3".Replace("ui://", "") + "-" + ((GObject)tip3).id;
		((GObject)tip3).text = LanguagesManager.GetDesc(id3);
		WeeklyTip = (GGroup)((GComponent)this).GetChild("WeeklyTip");
		HelpPanel = (UI_HelpPanel)(object)((GComponent)this).GetChild("HelpPanel");
		missibleSfxBack = (GGraph)((GComponent)this).GetChild("missibleSfxBack");
		missbleEndPos = (GGraph)((GComponent)this).GetChild("missbleEndPos");
		pageSwitch = (UI_PageSwitch)(object)((GComponent)this).GetChild("pageSwitch");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		if (parameters != null)
		{
			if (parameters.TryGetValue("Parent", out var value))
			{
				parent = (IUiController)value;
			}
			if (parameters.TryGetValue("Activity", out var value2))
			{
				storeActivity = (Activity)value2;
			}
			if (parameters.TryGetValue("ActivityID", out var value3) && ActivityManager.Activities.TryGetValue(value3.ToString(), out var value4))
			{
				storeActivity = value4;
			}
			if (parameters.TryGetValue("Order", out var value5))
			{
				((GObject)this).sortingOrder = (int)value5;
			}
			else
			{
				((GObject)this).sortingOrder = 1;
			}
			if (parameters.TryGetValue("TabName", out var value6))
			{
				aimTabName = value6.ToString();
			}
			if (parameters.TryGetValue("isStory", out var value7))
			{
				isStory = (bool)value7;
			}
		}
		if (storeActivity == null)
		{
			End();
			return;
		}
		List<string> activityIds = new List<string> { storeActivity.ActivityId };
		if (storeActivity.ActivityProgress(GameManagers.Instance).IsNew)
		{
			GameManagers.Instance.ActivityManager.ReviewActivities(activityIds);
		}
		showLegendItemCard = UI_BlackMarketerPanel.IsLegendItemDrawOpen();
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GComponent)HotSaleGift.ConfirmBuyBtn).GetChild("title").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)138, (byte)69, (byte)28, (byte)229));
		SetBuildingName();
		UpdateMainPanel(isInit: true);
	}

	public void OnShow()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		((GObject)missibleSfxBack).xy = new Vector2(1550f, 854f);
	}

	public void BeforeDestroy()
	{
		if (TimeLimitRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(TimeLimitRemainingCoroutine);
		}
		if (Real_RenderMainItems != null)
		{
			FGUIManager.Instance.CloseIEnumerator(Real_RenderMainItems);
		}
		if (Real_RenderHotSale != null)
		{
			FGUIManager.Instance.CloseIEnumerator(Real_RenderHotSale);
		}
	}

	public void Destroy()
	{
		UiHelper.UnloadPackage();
		if (storeActivity != null)
		{
			foreach (KeyValuePair<string, ActivityContentPayload> item in storeActivity.ContentPayload(GameManagers.Instance))
			{
				GameManagers.Instance.NewMsgIncomingManager.CheckActivityContent(storeActivity.ActivityId, item.Key);
			}
		}
		if (parent != null && parent is UI_MainCity)
		{
			UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		}
		if (parent != null && parent is UI_ActivityPanel)
		{
			((UI_ActivityPanel)parent).RenderFirstTimeRewardPanel();
		}
		if (parent != null && parent is UI_BlackMarketerPanel && !isStory)
		{
			((UI_BlackMarketerPanel)parent)?.UpdateItemCard(Name);
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		addDiamondBtn.GetChild("addButton").onClick.Add(new EventCallback0(DiamondBtnEvent));
		addCouponBtn.GetChild("addButton").onClick.Add(new EventCallback0(MoneyBtnEvent));
		((GObject)Help).onClick.Add(new EventCallback0(ShowHelpPanel));
		((GObject)HelpPanel.Mask).onClick.Add(new EventCallback0(CloseHelpPanel));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<string>("LIMIT_TIME_MERCHANDISE_EXPIRED", OnLimitTimeMerchandiseExpired);
		SharedMessenger.AddListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		addDiamondBtn.GetChild("addButton").onClick.Remove(new EventCallback0(DiamondBtnEvent));
		addCouponBtn.GetChild("addButton").onClick.Remove(new EventCallback0(MoneyBtnEvent));
		((GObject)Help).onClick.Remove(new EventCallback0(ShowHelpPanel));
		((GObject)HelpPanel.Mask).onClick.Remove(new EventCallback0(CloseHelpPanel));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<string>("LIMIT_TIME_MERCHANDISE_EXPIRED", OnLimitTimeMerchandiseExpired);
		SharedMessenger.RemoveListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
	}

	private void ShowHelpPanel()
	{
		((GObject)HelpPanel).visible = true;
		HelpPanel.ShowDialog.Play();
	}

	private void CloseHelpPanel()
	{
		((GObject)HelpPanel).visible = false;
	}

	public async void UpdateMainPanel(bool isInit = false)
	{
		IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
		int changeId = uiService.SetUiNotTouchable(Name);
		uiService.ShowWaitingAnimation(show: true);
		currentCount = 0;
		int aimNum = 0;
		if (isInit)
		{
			aimNum = 1;
			Action action = delegate
			{
				currentCount++;
			};
			loadSomeUiPublicResourcesCoroutine = FGUIManager.Instance.OpenIEnumerator(IEnumerator_LoadSomeUiPublicResources(action));
		}
		showMainPanelCoroutine = FGUIManager.Instance.OpenIEnumerator(ShowMainPanel(aimNum, changeId, isInit));
	}

	private void RenderStoreItems(bool isInit = false)
	{
		if (isInit)
		{
			totalGifts.Clear();
			_pageNameKeys.Clear();
			Dictionary<string, ActivityContentPayload> dictionary = storeActivity.ContentPayload(GameManagers.Instance);
			hotSaleData.Clear();
			UserArchiveManager userArchiveManager = GameManagers.Instance.UserArchiveManager;
			foreach (string key in dictionary.Keys)
			{
				_pageNameKeys[key] = "GiftBag-GiftBagPanel-PageName-" + key;
				List<Shift.Legion.Common.Models.Store.StoreItem> value = new List<Shift.Legion.Common.Models.Store.StoreItem>();
				switch (key)
				{
				case "宝物":
					if (userArchiveManager.GetChapterLevelProgress("C1005").Contains("P520") || LegendItemsHelper.HasAnyLegendItem)
					{
						totalGifts.Add(key, value);
					}
					break;
				case "远征":
					if (userArchiveManager.GetChapterLevelProgress("C1011").Contains("P1130"))
					{
						totalGifts.Add(key, value);
					}
					break;
				default:
					totalGifts.Add(key, value);
					break;
				case "热卖":
					break;
				}
			}
		}
		if (isInit)
		{
			RenderHotSaleGift();
			PagesInit(isInit);
			TimeLimitRemainingCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshTimeLimitRemaining());
		}
		else
		{
			RenderHotSaleGift();
			PagesInit(isInit);
		}
	}

	private IEnumerator Real_RenderHotSaleList()
	{
		string curTabKey = storeActivity.ActivityId + ":热卖";
		if (!FGUIManager.Instance.BlackMarket_StoreItem.ContainsKey(curTabKey) || FGUIManager.Instance.BlackMarket_StoreItem[curTabKey].Length == 0)
		{
			HotSaleGift.IsEmpty.selectedIndex = 1;
			bool isLevelNotClear = !GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1001").Contains("P120");
			HotSaleGift.IsLevelNotClear.selectedIndex = (isLevelNotClear ? 1 : 0);
			yield break;
		}
		for (int i = 0; i < FGUIManager.Instance.BlackMarket_StoreItem[curTabKey].Length; i++)
		{
			Shift.Legion.Common.Models.Store.StoreItem storeItem = GetStoreItem(FGUIManager.Instance.BlackMarket_StoreItem[curTabKey][i]);
			if (storeItem != null)
			{
				hotSaleData.Add(storeItem);
			}
		}
		if (hotSaleData.Count <= 0)
		{
			HotSaleGift.IsEmpty.selectedIndex = 1;
			bool isLevelNotClear2 = !GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1001").Contains("P120");
			HotSaleGift.IsLevelNotClear.selectedIndex = (isLevelNotClear2 ? 1 : 0);
			yield break;
		}
		HotSaleGift.IsEmpty.selectedIndex = 0;
		for (int j = 0; j < hotSaleData.Count; j++)
		{
			int index = j;
			if (HotSaleGift.giftList != null && !((GObject)HotSaleGift.giftList).isDisposed && !((GObject)this).isDisposed)
			{
				GObject item = HotSaleGift.giftList.AddItemFromPool();
				item.alpha = 0f;
				item.touchable = false;
				RenderHotSaleGiftItem(index, item);
				item.TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
				{
					item.touchable = true;
				});
				yield return null;
			}
		}
		if (!((GObject)this).isDisposed && HotSaleGift.giftList != null && !((GObject)HotSaleGift.giftList).isDisposed)
		{
			((GComponent)HotSaleGift.giftList).EnsureBoundsCorrect();
		}
	}

	private IEnumerator Real_RenderMainItemList(string tabKey)
	{
		string curTabKey = storeActivity.ActivityId + ":" + tabKey;
		if (!FGUIManager.Instance.BlackMarket_StoreItem.ContainsKey(curTabKey) || FGUIManager.Instance.BlackMarket_StoreItem[curTabKey].Length == 0)
		{
			IsEmpty.selectedIndex = ((itemList.Count <= 0) ? 1 : 0);
			yield break;
		}
		for (int i = 0; i < FGUIManager.Instance.BlackMarket_StoreItem[curTabKey].Length; i++)
		{
			Shift.Legion.Common.Models.Store.StoreItem storeItem = GetStoreItem(FGUIManager.Instance.BlackMarket_StoreItem[curTabKey][i]);
			if (storeItem != null && (storeItem.PurchaseLimitPeriod != PurchaseLimitType.Permanent || GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId) < storeItem.PurchaseLimit))
			{
				itemList.Add(storeItem);
			}
		}
		for (int j = 0; j < itemList.Count; j++)
		{
			int index = j;
			if (((GObject)this).isDisposed || ((GObject)cardList).isDisposed)
			{
				yield break;
			}
			GObject item = cardList.AddItemFromPool();
			item.alpha = 0f;
			item.touchable = false;
			RenderCardListItem(index, item);
			item.TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
			{
				item.touchable = true;
			});
			yield return null;
		}
		if (((GObject)this).isDisposed || ((GObject)cardList).isDisposed)
		{
			yield break;
		}
		((GComponent)cardList).EnsureBoundsCorrect();
		IsEmpty.selectedIndex = ((itemList.Count <= 0) ? 1 : 0);
		UiTagManager uiTagManager = UiTagManager.Instance;
		uiTagManager.Unregister("GiftBagPanel.ItemList");
		Dictionary<string, object> giftBagsMap = new Dictionary<string, object>();
		for (int i2 = 0; i2 < itemList.Count; i2++)
		{
			if (((GObject)this).isDisposed || ((GObject)cardList).isDisposed)
			{
				yield break;
			}
			giftBagsMap.Add(itemList[i2].StoreItemId, ((GComponent)cardList).GetChildAt(i2));
		}
		uiTagManager.Register("GiftBagPanel.ItemList", giftBagsMap);
		if (!Mathf.Approximately(cardListTopOffset, 0f))
		{
			((GComponent)cardList).scrollPane.SetPosY(cardListTopOffset, false);
			cardListTopOffset = 0f;
		}
	}

	private IEnumerator IEnumerator_LoadSomeUiPublicResources(Action action)
	{
		yield return null;
		UiHelper.LoadSomeUiPublicResources(action);
	}

	private IEnumerator ShowMainPanel(int aimNum, int changeId, bool isInit = false)
	{
		if (currentCount >= aimNum)
		{
			RenderStoreItems(isInit);
			IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
			uiService.ShowWaitingAnimation(show: false);
			uiService.SetUiTouchable(changeId);
		}
		else
		{
			yield return (object)new WaitForSeconds(0.1f);
			showMainPanelCoroutine = FGUIManager.Instance.OpenIEnumerator(ShowMainPanel(aimNum, changeId, isInit));
		}
	}

	private void PageSwitchInit()
	{
		if (totalGifts.Keys.Count > 1)
		{
			((GComboBox)pageSwitch).items = totalGifts.Keys.ToArray();
			((GComboBox)pageSwitch).values = totalGifts.Keys.ToArray();
			((GObject)pageSwitch.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText256");
			((GComboBox)pageSwitch).value = totalGifts.Keys.First();
			SetCurShowGiftPage(((GComboBox)pageSwitch).value);
		}
	}

	private void PagesInit(bool isInit = false)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		if (totalGifts.Keys.Count <= 1 || Pages == null || ((GObject)Pages).isDisposed)
		{
			return;
		}
		Pages.itemRenderer = new ListItemRenderer(PageSelectedItemRender);
		Pages.numItems = totalGifts.Keys.Count;
		Pages.ResizeToFit(Pages.numItems);
		PagesBack.numItems = totalGifts.Keys.Count;
		Pages.ResizeToFit(PagesBack.numItems);
		if (isInit)
		{
			if (!string.IsNullOrWhiteSpace(aimTabName) && totalGifts.ContainsKey(aimTabName))
			{
				int selectedIndex = totalGifts.Keys.ToList().IndexOf(aimTabName);
				Pages.selectedIndex = selectedIndex;
				SetCurShowGiftPage(aimTabName);
			}
			else
			{
				Pages.selectedIndex = 0;
				SetCurShowGiftPage(totalGifts.Keys.First());
			}
		}
		else
		{
			string pageKey = ((GComponent)Pages).GetChildAt(Pages.selectedIndex).data.ToString();
			SetCurShowGiftPage(pageKey, needUpdate: true);
		}
	}

	private void PageSelectedItemRender(int index, GObject obj)
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		if (Pages != null && !((GObject)Pages).isDisposed)
		{
			obj.asButton.title = (_pageNameKeys.TryGetValue(totalGifts.Keys.ToList()[index], out var value) ? LanguagesManager.GetDesc(value) : totalGifts.Keys.ToList()[index]);
			obj.data = totalGifts.Keys.ToList()[index];
			obj.onClick.Set(new EventCallback1(ChangePageSwitchValue));
		}
	}

	private void ChangePageSwitchValue(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		string text = ((GObject)context.sender).data.ToString();
		SetCurShowGiftPage(text);
		Pages.selectedIndex = ((GComponent)Pages).GetChildIndex((GObject)context.sender);
		GObject child = ((GComponent)this).GetChild("WeeklyTip");
		if (child.data != null && child.data.ToString() == text)
		{
			((GComponent)this).GetChild("tip3").text = LanguagesManager.GetDesc("CsharpCodeZhTcText261") + "6:00" + LanguagesManager.GetDesc("CsharpCodeZhTcText262");
			((GComponent)this).GetChild("tip3").asTextField.color = Color32.op_Implicit(new Color32((byte)156, (byte)242, (byte)64, byte.MaxValue));
			((GComponent)this).GetChild("Help").visible = true;
			child.visible = true;
		}
		else if (text == "黑市")
		{
			((GComponent)this).GetChild("tip3").text = LanguagesManager.GetDesc("CsharpCodeZhTcText257");
			((GComponent)this).GetChild("tip3").asTextField.color = Color32.op_Implicit(new Color32((byte)241, (byte)216, (byte)148, byte.MaxValue));
			((GComponent)this).GetChild("Help").visible = false;
			child.visible = true;
		}
		else
		{
			child.visible = false;
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void SetBuildingName()
	{
		((GObject)titleCom.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText258");
		UpdateGemstone();
		UpdateMoney(isInit: true);
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
		addCouponBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Money");
	}

	public void UpdateGemstone()
	{
		int stock = GameManagers.Instance.StockController.GetStock("Money");
		((GObject)addDiamondBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock("Gem").ToString();
		int num = ((addCouponBtn.GetChild("num").data != null) ? ((int)addCouponBtn.GetChild("num").data) : stock);
		if (num != stock && stock > num)
		{
			int num2 = stock - num;
			if (NumFloating == null)
			{
				NumFloating = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			}
			if (!((GObject)NumFloating).onStage)
			{
				FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloating, addCouponBtn, stock - num);
			}
			else
			{
				((GObject)NumFloating.Title).text = $"+{(int)((GObject)NumFloating.Title).data + num2}";
				((GObject)NumFloating.Title).data = (int)((GObject)NumFloating.Title).data + num2;
			}
		}
		addCouponBtn.GetChild("num").data = stock;
	}

	public void UpdateMoney(bool isInit = false)
	{
		int stock = GameManagers.Instance.StockController.GetStock("Money");
		if (!isInit && addCouponBtn.GetChild("num").data != null && (int)addCouponBtn.GetChild("num").data != stock)
		{
			int num = (int)addCouponBtn.GetChild("num").data;
			FGUIManager.Instance.AddNumFloatingForCouponBtn(UI_ProductionNumFloating.CreateInstance_ILRuntime(), addCouponBtn, stock - num, 1, dispose: true);
		}
		((GObject)addCouponBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock("Money").ShortNumberFormat();
		addCouponBtn.GetChild("num").data = stock;
	}

	private void BuyHotGiftBag(EventContext context)
	{
	}

	private void RenderCardList()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		cardList.itemRenderer = new ListItemRenderer(RenderCardListItem);
		cardList.numItems = itemList.Count;
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("GiftBagPanel.ItemList");
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		for (int i = 0; i < itemList.Count; i++)
		{
			dictionary.Add(itemList[i].StoreItemId, ((GComponent)cardList).GetChildAt(i));
		}
		instance.Register("GiftBagPanel.ItemList", dictionary);
	}

	private void RenderCardListItem(int index, GObject obj)
	{
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0697: Unknown result type (might be due to invalid IL or missing references)
		//IL_070a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0714: Expected O, but got Unknown
		//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		UI_AddCreditCard uI_AddCreditCard = (UI_AddCreditCard)(object)obj;
		Shift.Legion.Common.Models.Store.StoreItem storeItem = (Shift.Legion.Common.Models.Store.StoreItem)(((GObject)uI_AddCreditCard).data = itemList[index]);
		if (storeItem.Icon.Contains("PublicResourceStoreItemIcons"))
		{
			uI_AddCreditCard.icon.url = "ui:" + storeItem.Icon;
		}
		else
		{
			uI_AddCreditCard.icon.url = "ui://PublicResources/" + storeItem.Icon;
		}
		if (storeItem.ExpireTimestamp > 0)
		{
			uI_AddCreditCard.FirstTimeDouble.Stauts.selectedIndex = 0;
			((GObject)uI_AddCreditCard.FirstTimeDouble).visible = true;
			int value = storeItem.ExpireTimestamp - (int)GameController.Instance.GetServerTime();
			((GObject)uI_AddCreditCard.FirstTimeDouble.time).text = UiHelper.ParseTime(Convert.ToInt32(value)) ?? "";
		}
		else
		{
			((GObject)uI_AddCreditCard.FirstTimeDouble).visible = false;
		}
		((GObject)uI_AddCreditCard.result).text = storeItem.GetNameWithLineBreak();
		if (storeItem.PurchaseLimitPeriod != PurchaseLimitType.NoLimit)
		{
			string goodsPurchaseLimitTitle = FGUIManager.Instance.GetGoodsPurchaseLimitTitle(storeItem.PurchaseLimitPeriod);
			uI_AddCreditCard.RewardController.selectedIndex = 1;
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
			int num = storeItem.PurchaseLimit - purchaseCntAtLimitPeriod;
			string text = ((num > 0) ? "#7C4B2A" : "#c41d19");
			((GObject)uI_AddCreditCard.reward).text = string.Format("{0}[color={1}]{2}/{3}[/color]{4}", goodsPurchaseLimitTitle, text, num, storeItem.PurchaseLimit, LanguagesManager.GetDesc("CsharpCodeZhTcText236"));
			if (num <= 0)
			{
				uI_AddCreditCard.RewardController.selectedIndex = 2;
				((GObject)uI_AddCreditCard.FirstTimeDouble).visible = true;
				int num2 = 0;
				DateTimeOffset dateTimeOffset = DateTimeOffset.Now;
				if (storeItem.PurchaseLimitPeriod == PurchaseLimitType.Daily)
				{
					dateTimeOffset = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().DailyEndAt;
				}
				else if (storeItem.PurchaseLimitPeriod == PurchaseLimitType.Weekly)
				{
					dateTimeOffset = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().WeeklyEndAt;
				}
				else if (storeItem.PurchaseLimitPeriod == PurchaseLimitType.Monthly)
				{
					dateTimeOffset = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().MonthlyEndAt;
				}
				num2 = Convert.ToInt32(dateTimeOffset.Subtract(DateTimeHelper.Now).TotalSeconds);
				uI_AddCreditCard.FirstTimeDouble.Stauts.selectedIndex = 1;
				((GObject)uI_AddCreditCard.FirstTimeDouble.time).text = UiHelper.ParseTimeChnForGift(num2) + LanguagesManager.GetDesc("CsharpCodeZhTcText872");
			}
			else
			{
				uI_AddCreditCard.RewardController.selectedIndex = 1;
			}
		}
		else
		{
			uI_AddCreditCard.RewardController.selectedIndex = 0;
		}
		KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(storeItem);
		Dictionary<string, float> dictionary = storeItem.OriginPrice.First();
		string key = priceItemId.Key;
		FGUIManager.Instance.GetCurrencySymbol(key, uI_AddCreditCard.currentCurrencyIcon, textureList);
		string text2 = $"{Convert.ToInt32(dictionary.Values.First())}";
		string text3 = $"{Convert.ToInt32(priceItemId.Value)}";
		bool flag = key == "RMB";
		bool flag2 = true;
		ProductLocalInfo value2 = null;
		if (HotUpdateProcess.Instance.IsRegionOutCN && flag)
		{
			((GObject)uI_AddCreditCard.priceGroup).visible = false;
			((GObject)uI_AddCreditCard.priceGroupIntl).visible = true;
			if (!string.IsNullOrEmpty(storeItem.ReferenceId) && PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value2))
			{
				if (value2.Price > 0f)
				{
					text3 = value2.FormattedPrice;
					text2 = $"{value2.CurrencySymbol}{value2.Price / storeItem.InternationalDiscount:F2}";
				}
				else
				{
					flag2 = false;
					text3 = LanguagesManager.GetDesc("CsharpCodeTextPriceFree");
				}
			}
			else
			{
				flag2 = false;
				text3 = "--";
				if (string.IsNullOrEmpty(storeItem.ReferenceId) && priceItemId.Value <= 0f)
				{
					text3 = LanguagesManager.GetDesc("CsharpCodeTextPriceFree");
				}
			}
		}
		else
		{
			((GObject)uI_AddCreditCard.priceGroup).visible = true;
			((GObject)uI_AddCreditCard.priceGroupIntl).visible = false;
		}
		if (storeItem.IsFree)
		{
			uI_AddCreditCard.Discount.selectedIndex = (flag2 ? 1 : 0);
			uI_AddCreditCard.currentPriceTitle.shadowOffset = new Vector2(0f, 2f);
			uI_AddCreditCard.Price1st.shadowOffset = new Vector2(0f, 2f);
			((GObject)uI_AddCreditCard.Price1st).text = text3;
			((GObject)uI_AddCreditCard.Price2nd).text = text2;
			((GObject)uI_AddCreditCard.curIntlPriceText).text = LanguagesManager.GetDesc("CsharpCodeTextPriceFree");
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key;
			uI_AddCreditCard.originalCurrencyIcon.url = "ui://PublicResources/" + key;
		}
		else if (Mathf.Abs(storeItem.Discount - 1f) > float.Epsilon && storeItem.Discount > float.Epsilon)
		{
			uI_AddCreditCard.Discount.selectedIndex = (flag2 ? 1 : 0);
			uI_AddCreditCard.currentPriceTitle.shadowOffset = new Vector2(0f, 2f);
			uI_AddCreditCard.Price1st.shadowOffset = new Vector2(0f, 2f);
			((GObject)uI_AddCreditCard.Price1st).text = text3;
			((GObject)uI_AddCreditCard.Price2nd).text = text2;
			((GObject)uI_AddCreditCard.curIntlPriceText).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText956"), text3);
			((GObject)uI_AddCreditCard.originIntlPriceText).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText955"), text2);
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key;
			uI_AddCreditCard.originalCurrencyIcon.url = "ui://PublicResources/" + key;
		}
		else
		{
			uI_AddCreditCard.Discount.selectedIndex = 0;
			uI_AddCreditCard.currentPriceTitle.shadowOffset = new Vector2(0f, 0f);
			uI_AddCreditCard.Price1st.shadowOffset = new Vector2(0f, 0f);
			((GObject)uI_AddCreditCard.Price1st).text = text3;
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key;
			((GObject)uI_AddCreditCard.curIntlPriceText).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText957"), text3);
		}
		uI_AddCreditCard.SetControllerPageText();
		UiHelper.SetStoreItemDiscount(storeItem, uI_AddCreditCard.Discount_2, ribbonVisible: false);
		((GObject)uI_AddCreditCard).onClick.Set(new EventCallback1(ShowGiftBag));
	}

	private void RenderHotSaleGiftItem(int index, GObject obj)
	{
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Expected O, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		GComponent asCom = obj.asCom;
		Shift.Legion.Common.Models.Store.StoreItem storeItem = hotSaleData[index];
		asCom.GetChild("name").text = storeItem.Name ?? "";
		if (storeItem.Icon.Contains("PublicResourceStoreItemIcons"))
		{
			asCom.GetChild("icon").asLoader.url = "ui:" + storeItem.Icon;
		}
		else
		{
			asCom.GetChild("icon").asLoader.url = "ui://PublicResources/" + storeItem.Icon;
		}
		if (storeItem.PurchaseLimitPeriod != PurchaseLimitType.NoLimit)
		{
			string goodsPurchaseLimitTitle = FGUIManager.Instance.GetGoodsPurchaseLimitTitle(storeItem.PurchaseLimitPeriod);
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
			int num = storeItem.PurchaseLimit - purchaseCntAtLimitPeriod;
			asCom.GetChild("countLimit").text = string.Format("{0}/{1}{2}", num, storeItem.PurchaseLimit, LanguagesManager.GetDesc("CsharpCodeZhTcText236"));
		}
		else
		{
			asCom.GetChild("countLimit").text = "";
		}
		KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(storeItem);
		string key = priceItemId.Key;
		string text = $"{Convert.ToInt32(priceItemId.Value)}";
		bool flag = key == "RMB";
		ProductLocalInfo value = null;
		if (HotUpdateProcess.Instance.IsRegionOutCN && flag)
		{
			asCom.GetChild("currentCurrencyIcon").visible = false;
			asCom.GetChild("priceGroup").visible = false;
			asCom.GetChild("priceGroupIntl").visible = true;
			if (!string.IsNullOrEmpty(storeItem.ReferenceId) && PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value))
			{
				text = value.FormattedPrice;
			}
		}
		else
		{
			asCom.GetChild("currentCurrencyIcon").visible = true;
			asCom.GetChild("priceGroup").visible = true;
			asCom.GetChild("priceGroupIntl").visible = false;
		}
		asCom.GetChild("Price1st").text = text;
		asCom.GetChild("currentPriceTitle").text = LanguagesManager.GetDesc("CsharpCodeZhTcText259");
		asCom.GetChild("currentCurrencyIcon").asLoader.url = "ui://PublicResources/" + key;
		asCom.GetChild("curIntlPriceText").text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText956"), text);
		UiHelper.SetStoreItemDiscount(storeItem, asCom.GetChild("Discount").asCom, ribbonVisible: true);
		if (storeItem.ExpireTimestamp > 0)
		{
			int value2 = storeItem.ExpireTimestamp - (int)GameController.Instance.GetServerTime();
			asCom.GetController("IsShowTime").selectedIndex = 1;
			asCom.GetChild("timeLimit").text = LanguagesManager.GetDesc("CsharpCodeZhTcText873") + " " + LanguagesManager.GetDesc("CsharpCodeZhTcText227") + UiHelper.ParseTimeChinsesDH(Convert.ToInt32(value2));
		}
		else
		{
			asCom.GetChild("timeLimit").text = "";
			asCom.GetController("IsShowTime").selectedIndex = 0;
		}
		hotSaleContent.Clear();
		foreach (KeyValuePair<string, int> item in storeItem.Content)
		{
			hotSaleContent.Add(new KeyValuePair<string, int>(item.Key, item.Value));
		}
		asCom.GetChild("content").text = "";
		foreach (KeyValuePair<string, int> item2 in hotSaleContent)
		{
			if (!string.IsNullOrWhiteSpace(asCom.GetChild("content").text))
			{
				GObject child = asCom.GetChild("content");
				child.text += Environment.NewLine;
			}
			GObject child2 = asCom.GetChild("content");
			child2.text += $"{Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, item2.Key)}x{item2.Value}";
		}
		if (((GObject)asCom).data != null && storeItem.StoreItemId != ((Shift.Legion.Common.Models.Store.StoreItem)((GObject)asCom).data).StoreItemId)
		{
			FGUIManager.Instance.AddTextSpecialEffects(asCom.GetChild("iconSfx").asGraph, "activating_white", new Vector3(180f, 180f, 180f));
		}
		((GObject)asCom).data = storeItem;
		((GObject)asCom).onClick.Set(new EventCallback1(ShowGiftBag));
	}

	private async void RenderHotSaleGift()
	{
		await GetSomeTabStoreItems("热卖", needUpdate: true);
		hotSaleData.Clear();
		HotSaleGift.giftList.RemoveChildrenToPool();
		Real_RenderHotSale = FGUIManager.Instance.OpenIEnumerator(Real_RenderHotSaleList());
	}

	private void RenderHotSaleListItem(int index, GObject obj)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		FGUIManager.Instance.SetItemIconAndFrame(((GComponent)asButton).GetChild("icon").asLoader, hotSaleContent[index].Key, textureList);
		((GComponent)asButton).GetChild("num").text = $"x{hotSaleContent[index].Value}";
		((GObject)asButton).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(hotSaleContent[index].Key, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
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

	private void DiamondBtnEvent()
	{
		if (parent != null && parent is UI_BlackMarketerAddCredit)
		{
			((UI_BlackMarketerAddCredit)parent).DiamondBtnEvent();
			End();
			return;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object>
		{
			{ "Parent", this },
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

	public void MoneyBtnEvent()
	{
	}

	private void BuyGiftBag(EventContext context)
	{
	}

	private void OrderShipSuccessEvent(List<Bonus> result, List<Bonus> bonuses)
	{
	}

	private void PlayMissileSfx()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		((GObject)missibleSfxBack).SetPivot(0.5f, 0.5f, true);
		FGUIManager.Instance.AddTextSpecialEffects(missibleSfxBack, "exp_missile_green", Vector3.zero);
		((GObject)missibleSfxBack).TweenMove(((GObject)missbleEndPos).xy, 0.5f);
		UiAudioManager.Instance.PlaySoundEffect("Missile");
		UpdateMoney();
		UpdateGemstone();
	}

	private void ShowGiftBag(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		Shift.Legion.Common.Models.Store.StoreItem storeItem = (Shift.Legion.Common.Models.Store.StoreItem)data;
		cardListTopOffset = ((GComponent)cardList).scrollPane.posY;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems.Name, new Dictionary<string, object>
		{
			{
				"Name",
				storeItem.Name ?? ""
			},
			{ "CanBuy", true },
			{ "GiftBag", storeItem },
			{ "Parent", this }
		});
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
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
		}
	}

	private void OnLimitTimeMerchandiseExpired(string storeItemId)
	{
		UpdateMainPanel();
	}

	private IEnumerator RefreshTimeLimitRemaining()
	{
		while (true)
		{
			_ = DateTimeHelper.Now;
			for (int i = 0; i < cardList.numItems; i++)
			{
				UI_AddCreditCard button = (UI_AddCreditCard)(object)((GComponent)cardList).GetChildAt(i);
				if (!(((GObject)(button?)).data is Shift.Legion.Common.Models.Store.StoreItem storeItem))
				{
					continue;
				}
				bool limitTime = false;
				int remainingTime = 0;
				if (storeItem.ExpireTimestamp > 0)
				{
					limitTime = true;
					remainingTime = storeItem.ExpireTimestamp - (int)GameController.Instance.GetServerTime();
				}
				else if (storeItem.ValidTime > 0)
				{
					remainingTime = GameManagers.Instance.StoreManager.GetLimitTimeMerchandiseRemainingTime(storeActivity.ActivityId, storeItem.StoreItemId);
				}
				if (limitTime)
				{
					if (remainingTime < 0)
					{
						((GObject)button.FirstTimeDouble).visible = false;
					}
					else
					{
						((GObject)button.FirstTimeDouble).visible = true;
						((GObject)button.FirstTimeDouble.time).text = UiHelper.ParseTime(Convert.ToInt32(remainingTime)) ?? "";
					}
				}
				if (storeItem.PurchaseLimitPeriod == PurchaseLimitType.NoLimit)
				{
					continue;
				}
				string title = FGUIManager.Instance.GetGoodsPurchaseLimitTitle(storeItem.PurchaseLimitPeriod);
				button.RewardController.selectedIndex = 1;
				int storeItemPurchaseCnt = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
				int remainingCnt = storeItem.PurchaseLimit - storeItemPurchaseCnt;
				string limitColor = ((remainingCnt > 0) ? "#7C4B2A" : "#c41d19");
				((GObject)button.reward).text = string.Format("{0}[color={1}]{2}/{3}[/color]{4}", title, limitColor, remainingCnt, storeItem.PurchaseLimit, LanguagesManager.GetDesc("CsharpCodeZhTcText236"));
				if (remainingCnt <= 0)
				{
					button.RewardController.selectedIndex = 2;
					((GObject)button.FirstTimeDouble).visible = true;
					DateTimeOffset _time = DateTimeOffset.Now;
					if (storeItem.PurchaseLimitPeriod == PurchaseLimitType.Daily)
					{
						_time = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().DailyEndAt;
					}
					else if (storeItem.PurchaseLimitPeriod == PurchaseLimitType.Weekly)
					{
						_time = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().WeeklyEndAt;
					}
					else if (storeItem.PurchaseLimitPeriod == PurchaseLimitType.Monthly)
					{
						_time = GameManagers.Instance.StoreManager.PurchaseStat.GetValue().MonthlyEndAt;
					}
					int totalSeconds = Convert.ToInt32(_time.Subtract(DateTimeHelper.Now).TotalSeconds);
					button.FirstTimeDouble.Stauts.selectedIndex = 1;
					((GObject)button.FirstTimeDouble.time).text = UiHelper.ParseTimeChnForGift(totalSeconds) + LanguagesManager.GetDesc("CsharpCodeZhTcText872");
				}
				else
				{
					button.RewardController.selectedIndex = 1;
				}
			}
			for (int j = 0; j < HotSaleGift.giftList.numItems; j++)
			{
				UI_HotSaleGiftItem button2 = (UI_HotSaleGiftItem)(object)((GComponent)HotSaleGift.giftList).GetChildAt(j);
				if (!(((GObject)(button2?)).data is Shift.Legion.Common.Models.Store.StoreItem storeItem2))
				{
					continue;
				}
				bool limitTime2 = false;
				int remainingTime2 = 0;
				if (storeItem2.ExpireTimestamp > 0)
				{
					limitTime2 = true;
					remainingTime2 = storeItem2.ExpireTimestamp - (int)GameController.Instance.GetServerTime();
				}
				else if (storeItem2.ValidTime > 0)
				{
					remainingTime2 = GameManagers.Instance.StoreManager.GetLimitTimeMerchandiseRemainingTime(storeActivity.ActivityId, storeItem2.StoreItemId);
				}
				if (limitTime2)
				{
					if (remainingTime2 >= 0)
					{
						((GObject)button2.timeLimit).text = LanguagesManager.GetDesc("CsharpCodeZhTcText873") + " " + LanguagesManager.GetDesc("CsharpCodeZhTcText227") + UiHelper.ParseTimeChinsesDH(Convert.ToInt32(remainingTime2));
						((GComponent)button2).GetController("IsShowTime").selectedIndex = 1;
					}
					else
					{
						((GObject)button2.timeLimit).text = "";
						((GComponent)button2).GetController("IsShowTime").selectedIndex = 0;
					}
				}
			}
			yield return (object)new WaitForSeconds(0.5f);
		}
	}

	private async Task GetData()
	{
		totalGifts.Clear();
		int _index = -1;
		Dictionary<string, ActivityContentPayload> contentPayload = storeActivity.ContentPayload(GameManagers.Instance);
		foreach (string _key in contentPayload.Keys)
		{
			_index++;
			List<Shift.Legion.Common.Models.Store.StoreItem> _itemList = new List<Shift.Legion.Common.Models.Store.StoreItem>();
			GetStoreActivityItemsResponse storeItemsResponse = await GameController.Contexts.Service<INetworkService>().GetStoreActivityItems(storeActivity.ActivityId, _key);
			if (!storeItemsResponse.Result)
			{
				ILRequestHelper.ShowErrorCode(storeItemsResponse.ErrorCode);
				continue;
			}
			Shift.Legion.ClientApi.Protocol.Store.StoreItem[] incomingStoreItems = storeItemsResponse.StoreItems;
			if (incomingStoreItems == null)
			{
				if (_index < contentPayload.Keys.Count - 1)
				{
					if (_key != "宝物")
					{
						totalGifts.Add(_key, _itemList);
					}
					else if (showLegendItemCard)
					{
						totalGifts.Add(_key, _itemList);
					}
				}
				continue;
			}
			if (_index < contentPayload.Keys.Count - 1)
			{
				_itemList.Clear();
			}
			else
			{
				hotSaleData.Clear();
			}
			Shift.Legion.ClientApi.Protocol.Store.StoreItem[] array = incomingStoreItems;
			foreach (Shift.Legion.ClientApi.Protocol.Store.StoreItem incomingStoreItemData in array)
			{
				Shift.Legion.Common.Models.Store.StoreItem storeItem = new Shift.Legion.Common.Models.Store.StoreItem(GameManagers.Instance, incomingStoreItemData.StoreItemId)
				{
					Icon = incomingStoreItemData.Icon,
					Rarity = incomingStoreItemData.Rarity,
					Category = (StoreCategory)incomingStoreItemData.Category,
					DoubleAtFirst = incomingStoreItemData.DoubleAtFirst,
					BonusAtFirst = incomingStoreItemData.BonusAtFirst,
					Tags = incomingStoreItemData.Tags,
					ValidTime = incomingStoreItemData.ValidTime,
					KickOffTimestamp = incomingStoreItemData.KickOffTimestamp,
					ExpireTimestamp = incomingStoreItemData.ExpireTimestamp,
					Content = incomingStoreItemData.Content,
					DisplayContent = incomingStoreItemData.DisplayContent,
					OriginPrice = incomingStoreItemData.OriginPrice,
					Price = incomingStoreItemData.Price,
					Discount = incomingStoreItemData.Discount,
					PurchaseLimit = incomingStoreItemData.PurchaseLimit,
					PurchaseLimitPeriod = (PurchaseLimitType)incomingStoreItemData.PurchaseLimitPeriod,
					IsExpo = incomingStoreItemData.IsExpo,
					Substitution = incomingStoreItemData.Substitution,
					IsResident = incomingStoreItemData.IsResident,
					UserLevelFilter = incomingStoreItemData.UserLevelFilter,
					DungeonLevelFilter = incomingStoreItemData.DungeonLevelFilter,
					GameLevelFilter = incomingStoreItemData.GameLevelFilter,
					OwnedItemFilter = incomingStoreItemData.OwnedItemFilter,
					PurchaseFilter = incomingStoreItemData.PurchaseFilter
				};
				if (storeItem.IsPassedFilters && ((storeItem.IsKickedOff && !storeItem.IsExpired && !storeItem.IsSoldOut) || storeItem.IsResident))
				{
					if (_index < contentPayload.Keys.Count - 1)
					{
						_itemList.Add(storeItem);
					}
					else
					{
						hotSaleData.Add(storeItem);
					}
				}
			}
			if (_index < contentPayload.Keys.Count - 1)
			{
				if (_key != "宝物")
				{
					totalGifts.Add(_key, _itemList);
				}
				else if (showLegendItemCard)
				{
					totalGifts.Add(_key, _itemList);
				}
			}
		}
		currentCount++;
	}

	private async Task GetSomeTabStoreItems(string tabKey, bool needUpdate = false)
	{
		if (isStory)
		{
			needUpdate = isStory;
		}
		string curTabKey = storeActivity.ActivityId + ":" + tabKey;
		if (FGUIManager.Instance.BlackMarket_StoreItem != null && FGUIManager.Instance.BlackMarket_StoreItem.ContainsKey(curTabKey) && !needUpdate)
		{
			return;
		}
		GetStoreActivityItemsResponse storeItemsResponse = await GameController.Contexts.Service<INetworkService>().GetStoreActivityItems(storeActivity.ActivityId, tabKey);
		if (!storeItemsResponse.Result)
		{
			ILRequestHelper.ShowErrorCode(storeItemsResponse.ErrorCode);
			return;
		}
		Shift.Legion.ClientApi.Protocol.Store.StoreItem[] incomingStoreItems = storeItemsResponse.StoreItems;
		if (incomingStoreItems != null)
		{
			Shift.Legion.ClientApi.Protocol.Store.StoreItem[] newStoreItems = FGUIManager.Instance.GiftBagSort(incomingStoreItems);
			if (FGUIManager.Instance.BlackMarket_StoreItem == null)
			{
				FGUIManager.Instance.BlackMarket_StoreItem = new Dictionary<string, Shift.Legion.ClientApi.Protocol.Store.StoreItem[]>();
			}
			if (FGUIManager.Instance.BlackMarket_StoreItem.ContainsKey(curTabKey))
			{
				FGUIManager.Instance.BlackMarket_StoreItem[curTabKey] = newStoreItems;
			}
			else
			{
				FGUIManager.Instance.BlackMarket_StoreItem.Add(curTabKey, newStoreItems);
			}
		}
	}

	private Shift.Legion.Common.Models.Store.StoreItem GetStoreItem(Shift.Legion.ClientApi.Protocol.Store.StoreItem incomingStoreItemData)
	{
		Shift.Legion.Common.Models.Store.StoreItem storeItem = new Shift.Legion.Common.Models.Store.StoreItem(GameManagers.Instance, incomingStoreItemData.StoreItemId)
		{
			Icon = incomingStoreItemData.Icon,
			Rarity = incomingStoreItemData.Rarity,
			Category = (StoreCategory)incomingStoreItemData.Category,
			DoubleAtFirst = incomingStoreItemData.DoubleAtFirst,
			BonusAtFirst = incomingStoreItemData.BonusAtFirst,
			Tags = incomingStoreItemData.Tags,
			ValidTime = incomingStoreItemData.ValidTime,
			KickOffTimestamp = incomingStoreItemData.KickOffTimestamp,
			ExpireTimestamp = incomingStoreItemData.ExpireTimestamp,
			Content = incomingStoreItemData.Content,
			DisplayContent = incomingStoreItemData.DisplayContent,
			OriginPrice = incomingStoreItemData.OriginPrice,
			Price = incomingStoreItemData.Price,
			Discount = incomingStoreItemData.Discount,
			PurchaseLimit = incomingStoreItemData.PurchaseLimit,
			PurchaseLimitPeriod = (PurchaseLimitType)incomingStoreItemData.PurchaseLimitPeriod,
			IsExpo = incomingStoreItemData.IsExpo,
			Substitution = incomingStoreItemData.Substitution,
			IsResident = incomingStoreItemData.IsResident,
			UserLevelFilter = incomingStoreItemData.UserLevelFilter,
			DungeonLevelFilter = incomingStoreItemData.DungeonLevelFilter,
			GameLevelFilter = incomingStoreItemData.GameLevelFilter,
			OwnedItemFilter = incomingStoreItemData.OwnedItemFilter,
			PurchaseFilter = incomingStoreItemData.PurchaseFilter
		};
		if (!storeItem.IsPassedFilters)
		{
			return null;
		}
		if ((!storeItem.IsKickedOff || storeItem.IsExpired || storeItem.IsSoldOut) && !storeItem.IsResident)
		{
			return null;
		}
		return storeItem;
	}

	private async void SetCurShowGiftPage(string pageKey, bool needUpdate = false)
	{
		await GetSomeTabStoreItems(pageKey, needUpdate);
		itemList.Clear();
		cardList.RemoveChildrenToPool();
		if (Real_RenderMainItems != null)
		{
			FGUIManager.Instance.CloseIEnumerator(Real_RenderMainItems);
		}
		Real_RenderMainItems = FGUIManager.Instance.OpenIEnumerator(Real_RenderMainItemList(pageKey));
	}

	private void FilterData()
	{
		hotSaleData.Clear();
		for (int num = itemList.Count - 1; num >= 0; num--)
		{
			if (itemList[num].IsExpo)
			{
				hotSaleData.Add(itemList[num]);
				itemList.RemoveAt(num);
			}
		}
		GiftBagSort();
	}

	private void GiftBagSort()
	{
		List<Shift.Legion.Common.Models.Store.StoreItem> list = new List<Shift.Legion.Common.Models.Store.StoreItem>();
		list.AddRange(itemList);
		List<Shift.Legion.Common.Models.Store.StoreItem> list2 = new List<Shift.Legion.Common.Models.Store.StoreItem>();
		for (int num = list.Count - 1; num >= 0; num--)
		{
			Shift.Legion.Common.Models.Store.StoreItem storeItem = list[num];
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
			if (storeItem.PurchaseLimitPeriod != PurchaseLimitType.NoLimit && storeItem.PurchaseLimit - purchaseCntAtLimitPeriod == 0)
			{
				list2.Add(storeItem);
				list.RemoveAt(num);
			}
		}
		itemList.Clear();
		itemList.AddRange(list);
		itemList.AddRange(list2);
	}
}
