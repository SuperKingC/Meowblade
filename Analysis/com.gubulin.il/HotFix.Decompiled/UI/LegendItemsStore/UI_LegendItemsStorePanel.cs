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
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.GiftBag;
using UI.LegendItemsDraw;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.LegendItemsStore;

public class UI_LegendItemsStorePanel : GComponent, IUiController
{
	public Controller Type;

	public GLoader background;

	public GButton backBtn;

	public UI_Title titleCom;

	public GComponent addCouponBtn;

	public GComponent addDiamondBtn;

	public GImage n6;

	public GImage n46;

	public GImage n47;

	public GGroup back0;

	public GTextField tip;

	public GList cardList;

	public GList OtherCardList;

	public GTextField n48;

	public GImage n44;

	public GList Tabs;

	public GGraph missibleSfxBack;

	public GGraph missbleEndPos;

	public const string URL = "ui://i6o930evfjjsd";

	public static string Name = "UI_LegendItemsStorePanel";

	private List<string> textureList = new List<string>();

	private Activity storeActivity;

	private Activity otherStoreActivity;

	private List<Shift.Legion.Common.Models.Store.StoreItem> itemList = new List<Shift.Legion.Common.Models.Store.StoreItem>();

	private List<Shift.Legion.Common.Models.Store.StoreItem> otherItemList = new List<Shift.Legion.Common.Models.Store.StoreItem>();

	private UI_ProductionNumFloating NumFloating;

	private Coroutine TimeLimitRemainingCoroutine;

	private const string Money = "Money";

	private const string LegendItemCertificate = "I40215";

	private static string LegendItemsStoreActivityId
	{
		get
		{
			if (HotUpdateProcess.RegionKey == "sea")
			{
				return "LegendItemMerchant_sea";
			}
			return "LegendItemMerchant";
		}
	}

	private static string LegendItemsOtherStoreActivityId
	{
		get
		{
			if (HotUpdateProcess.RegionKey == "sea")
			{
				return "LegendItemMerchant1_sea";
			}
			return "LegendItemMerchant1";
		}
	}

	public static string GetURL()
	{
		return "ui://i6o930evfjjsd";
	}

	public static UI_LegendItemsStorePanel CreateInstance()
	{
		return (UI_LegendItemsStorePanel)(object)UIPackage.CreateObject("LegendItemsStore", "LegendItemsStorePanel");
	}

	public static UI_LegendItemsStorePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemsStorePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://i6o930evfjjsd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
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
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		background = (GLoader)((GComponent)this).GetChild("background");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		titleCom = (UI_Title)(object)((GComponent)this).GetChild("titleCom");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		back0 = (GGroup)((GComponent)this).GetChild("back0");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://i6o930evfjjsd".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		cardList = (GList)((GComponent)this).GetChild("cardList");
		OtherCardList = (GList)((GComponent)this).GetChild("OtherCardList");
		n48 = (GTextField)((GComponent)this).GetChild("n48");
		string id2 = "ui://i6o930evfjjsd".Replace("ui://", "") + "-" + ((GObject)n48).id;
		((GObject)n48).text = LanguagesManager.GetDesc(id2);
		n44 = (GImage)((GComponent)this).GetChild("n44");
		Tabs = (GList)((GComponent)this).GetChild("Tabs");
		missibleSfxBack = (GGraph)((GComponent)this).GetChild("missibleSfxBack");
		missbleEndPos = (GGraph)((GComponent)this).GetChild("missbleEndPos");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		SetBuildingName();
		UpdateDiamondNum();
		GetCurStoreActivity();
		if (storeActivity != null)
		{
			List<string> list = new List<string> { storeActivity.ActivityId };
			if (otherStoreActivity != null)
			{
				list.Add(otherStoreActivity.ActivityId);
			}
			if (storeActivity.ActivityProgress(GameManagers.Instance).IsNew)
			{
				GameManagers.Instance.ActivityManager.ReviewActivities(list);
			}
			RenderTabs();
			UpdateMainPanel(isInit: true);
		}
	}

	public void OnShow()
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		if (storeActivity == null)
		{
			End();
			return;
		}
		if (storeActivity != null)
		{
			foreach (KeyValuePair<string, ActivityContentPayload> item in storeActivity.ContentPayload(GameManagers.Instance))
			{
				GameManagers.Instance.NewMsgIncomingManager.CheckActivityContent(storeActivity.ActivityId, item.Key);
			}
		}
		Object obj = Resources.Load("Items/LegionPanelSpritMask");
		GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
		val = Object.Instantiate<GameObject>(val);
		val.transform.parent = ((GObject)this).displayObject.gameObject.transform;
		val.transform.localScale = new Vector3(584.61f, 225f, 108f);
		val.transform.localPosition = new Vector3(774f, -593.3f, 0f);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		addDiamondBtn.GetChild("addButton").onClick.Add(new EventCallback0(DiamondBtnEvent));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<string>("LIMIT_TIME_MERCHANDISE_EXPIRED", OnLimitTimeMerchandiseExpired);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		addDiamondBtn.GetChild("addButton").onClick.Remove(new EventCallback0(DiamondBtnEvent));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<string>("LIMIT_TIME_MERCHANDISE_EXPIRED", OnLimitTimeMerchandiseExpired);
	}

	private void UpdateDiamondNum()
	{
		string icon = UiHelper.GetIcon("I40215");
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + icon;
		int stock = GameManagers.Instance.StockController.GetStock("I40215");
		((GObject)addDiamondBtn.GetChild("num").asTextField).text = stock.ToString();
		addDiamondBtn.GetChild("num").data = stock;
	}

	private void GetCurStoreActivity()
	{
		List<Activity> list = new List<Activity>();
		list.AddRange(GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.LegendItemBlackMarket, null, isSort: false));
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if (list[num].GetStatus(GameManagers.Instance) == ActivityStatus.Enabled)
			{
				if (list[num].ActivityId == LegendItemsStoreActivityId)
				{
					storeActivity = list[num];
				}
				else if (list[num].ActivityId == LegendItemsOtherStoreActivityId)
				{
					otherStoreActivity = list[num];
				}
			}
		}
	}

	private void SetBuildingName()
	{
		TextFormat textFormat = titleCom.buildingName.textFormat;
		textFormat.font = "ui://kt6rg65orytnv47b";
		textFormat.size = 48;
		titleCom.buildingName.textFormat = textFormat;
		((GObject)titleCom.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText829");
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	public async void UpdateMainPanel(bool isInit = false)
	{
		IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
		int changeId = uiService.SetUiNotTouchable(Name);
		uiService.ShowWaitingAnimation(show: true);
		await GetData(storeActivity, itemList);
		await GetData(otherStoreActivity, otherItemList);
		RenderCurCards();
		RenderOtherCards();
		uiService.ShowWaitingAnimation(show: false);
		uiService.SetUiTouchable(changeId);
	}

	private async Task GetData(Activity storeItemsActivity, List<Shift.Legion.Common.Models.Store.StoreItem> storeItems)
	{
		if (storeItemsActivity == null)
		{
			return;
		}
		storeItems.Clear();
		Dictionary<string, ActivityContentPayload> contentPayload = storeItemsActivity.ContentPayload(GameManagers.Instance);
		foreach (string _key in contentPayload.Keys)
		{
			GetStoreActivityItemsResponse storeItemsResponse = await GameController.Contexts.Service<INetworkService>().GetStoreActivityItems(storeItemsActivity.ActivityId, _key);
			if (!storeItemsResponse.Result)
			{
				ILRequestHelper.ShowErrorCode(storeItemsResponse.ErrorCode);
				continue;
			}
			Shift.Legion.ClientApi.Protocol.Store.StoreItem[] incomingStoreItems = storeItemsResponse.StoreItems;
			if (incomingStoreItems == null)
			{
				continue;
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
					storeItems.Add(storeItem);
				}
			}
		}
	}

	private void RenderCurCards()
	{
		GiftBagSort(itemList);
		RenderCardList();
		if (itemList.Count <= 0)
		{
			((GObject)tip).visible = true;
		}
		else
		{
			((GObject)tip).visible = false;
		}
	}

	private void GiftBagSort(List<Shift.Legion.Common.Models.Store.StoreItem> storeItems)
	{
		List<Shift.Legion.Common.Models.Store.StoreItem> list = new List<Shift.Legion.Common.Models.Store.StoreItem>();
		list.AddRange(storeItems);
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
		storeItems.Clear();
		storeItems.AddRange(list);
		storeItems.AddRange(list2);
	}

	private void RenderCardList()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		cardList.itemRenderer = new ListItemRenderer(RenderCardListItem);
		cardList.numItems = itemList.Count;
	}

	private void RenderCardListItem(int index, GObject obj)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Expected O, but got Unknown
		UI_AddCreditCard uI_AddCreditCard = (UI_AddCreditCard)(object)obj;
		Shift.Legion.Common.Models.Store.StoreItem storeItem = (Shift.Legion.Common.Models.Store.StoreItem)(((GObject)uI_AddCreditCard).data = itemList[index]);
		FGUIManager.Instance.AddTextSpecialEffects(uI_AddCreditCard.sfxBack, "ui_active_glow_orange_3", new Vector3(180f, 180f, 180f));
		uI_AddCreditCard.icon.LoadArmsIcon(storeItem.Icon);
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
		((GObject)uI_AddCreditCard.result).text = storeItem.Name;
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
				num2 = Convert.ToInt32((dateTimeOffset - DateTimeHelper.Now).TotalSeconds);
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
		Dictionary<string, float> dictionary = storeItem.Price.First();
		Dictionary<string, float> dictionary2 = storeItem.OriginPrice.First();
		string key = priceItemId.Key;
		if (storeItem.IsFree)
		{
			uI_AddCreditCard.Discount.selectedIndex = 1;
			((GObject)uI_AddCreditCard.Price1st).text = $"{Convert.ToInt32(priceItemId.Value)}";
			((GObject)uI_AddCreditCard.Price2nd).text = $"{Convert.ToInt32(dictionary2.Values.First())}";
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key;
			uI_AddCreditCard.originalCurrencyIcon.url = "ui://PublicResources/" + key;
		}
		else if (Mathf.Abs(storeItem.Discount - 1f) > float.Epsilon && storeItem.Discount > float.Epsilon)
		{
			uI_AddCreditCard.Discount.selectedIndex = 1;
			((GObject)uI_AddCreditCard.Price1st).text = $"{Convert.ToInt32(dictionary.Values.First())}";
			((GObject)uI_AddCreditCard.Price2nd).text = $"{Convert.ToInt32(dictionary2.Values.First())}";
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key;
			uI_AddCreditCard.originalCurrencyIcon.url = "ui://PublicResources/" + key;
		}
		else
		{
			uI_AddCreditCard.Discount.selectedIndex = 0;
			((GObject)uI_AddCreditCard.Price1st).text = $"{Convert.ToInt32(dictionary.Values.First())}";
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key;
		}
		uI_AddCreditCard.SetControllerPageText();
		UiHelper.SetStoreItemDiscount(storeItem, uI_AddCreditCard.Discount_2, ribbonVisible: false);
		((GObject)uI_AddCreditCard).onClick.Set(new EventCallback1(ShowGiftBag));
	}

	private void ShowGiftBag(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		Shift.Legion.Common.Models.Store.StoreItem storeItem = (Shift.Legion.Common.Models.Store.StoreItem)data;
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

	private IEnumerator RefreshTimeLimitRemaining()
	{
		while (true)
		{
			_ = DateTimeHelper.Now;
			for (int i = 0; i < itemList.Count && i <= cardList.numItems - 1; i++)
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
					remainingTime = (int)(storeItem.ExpireTimestamp - GameController.Instance.GetServerTime());
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
					int totalSeconds = Convert.ToInt32((_time - DateTimeHelper.Now).TotalSeconds);
					button.FirstTimeDouble.Stauts.selectedIndex = 1;
					((GObject)button.FirstTimeDouble.time).text = UiHelper.ParseTimeChnForGift(totalSeconds) + LanguagesManager.GetDesc("CsharpCodeZhTcText872");
				}
				else
				{
					button.RewardController.selectedIndex = 1;
				}
			}
			yield return (object)new WaitForSeconds(0.5f);
		}
	}

	private void RenderOtherCards()
	{
		if (otherItemList == null || otherItemList.Count <= 0)
		{
			Type.selectedIndex = 0;
			((GObject)Tabs).visible = false;
		}
		else
		{
			((GObject)Tabs).visible = true;
			GiftBagSort(otherItemList);
			RenderOtherCardList();
		}
	}

	private void RenderOtherCardList()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		OtherCardList.itemRenderer = new ListItemRenderer(RenderOtherCardListItem);
		OtherCardList.numItems = otherItemList.Count;
	}

	private void RenderOtherCardListItem(int index, GObject obj)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Expected O, but got Unknown
		UI_AddCreditCard uI_AddCreditCard = (UI_AddCreditCard)(object)obj;
		Shift.Legion.Common.Models.Store.StoreItem storeItem = (Shift.Legion.Common.Models.Store.StoreItem)(((GObject)uI_AddCreditCard).data = otherItemList[index]);
		FGUIManager.Instance.AddTextSpecialEffects(uI_AddCreditCard.sfxBack, "ui_active_glow_orange_3", new Vector3(180f, 180f, 180f));
		uI_AddCreditCard.icon.LoadArmsIcon(storeItem.Icon);
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
		((GObject)uI_AddCreditCard.result).text = storeItem.Name;
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
				num2 = Convert.ToInt32((dateTimeOffset - DateTimeHelper.Now).TotalSeconds);
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
		Dictionary<string, float> dictionary = storeItem.Price.First();
		Dictionary<string, float> dictionary2 = storeItem.OriginPrice.First();
		string key = priceItemId.Key;
		if (storeItem.IsFree)
		{
			uI_AddCreditCard.Discount.selectedIndex = 1;
			((GObject)uI_AddCreditCard.Price1st).text = $"{Convert.ToInt32(priceItemId.Value)}";
			((GObject)uI_AddCreditCard.Price2nd).text = $"{Convert.ToInt32(dictionary2.Values.First())}";
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key;
			uI_AddCreditCard.originalCurrencyIcon.url = "ui://PublicResources/" + key;
		}
		else if (Mathf.Abs(storeItem.Discount - 1f) > float.Epsilon && storeItem.Discount > float.Epsilon)
		{
			uI_AddCreditCard.Discount.selectedIndex = 1;
			((GObject)uI_AddCreditCard.Price1st).text = $"{Convert.ToInt32(dictionary.Values.First())}";
			((GObject)uI_AddCreditCard.Price2nd).text = $"{Convert.ToInt32(dictionary2.Values.First())}";
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key;
			uI_AddCreditCard.originalCurrencyIcon.url = "ui://PublicResources/" + key;
		}
		else
		{
			uI_AddCreditCard.Discount.selectedIndex = 0;
			((GObject)uI_AddCreditCard.Price1st).text = $"{Convert.ToInt32(dictionary.Values.First())}";
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key;
		}
		uI_AddCreditCard.SetControllerPageText();
		UiHelper.SetStoreItemDiscount(storeItem, uI_AddCreditCard.Discount_2, ribbonVisible: false);
		((GObject)uI_AddCreditCard).onClick.Set(new EventCallback1(ShowGiftBag));
	}

	private void RenderTabs()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		Type.selectedIndex = 0;
		UI_ActivityTab uI_ActivityTab = ((GComponent)Tabs).GetChildAt(0) as UI_ActivityTab;
		((GObject)uI_ActivityTab).data = 0;
		if (uI_ActivityTab != null)
		{
			((GObject)uI_ActivityTab).onClick.Set(new EventCallback1(ShowDrawStoreItems));
		}
		((GButton)uI_ActivityTab).selected = true;
		UI_ActivityTab uI_ActivityTab2 = ((GComponent)Tabs).GetChildAt(1) as UI_ActivityTab;
		((GObject)uI_ActivityTab2).data = 1;
		if (uI_ActivityTab2 != null)
		{
			((GObject)uI_ActivityTab2).onClick.Set(new EventCallback1(ShowDrawStoreItems));
		}
	}

	private void ShowDrawStoreItems(EventContext context)
	{
		if (context.sender is UI_ActivityTab uI_ActivityTab && !((GObject)uI_ActivityTab).isDisposed)
		{
			Type.selectedIndex = (int)((GObject)uI_ActivityTab).data;
			for (int i = 0; i < Tabs.numItems; i++)
			{
				((GComponent)Tabs).GetChildAt(i).asButton.selected = false;
			}
			((GButton)uI_ActivityTab).selected = true;
		}
	}

	private void OnLimitTimeMerchandiseExpired(string storeItemId)
	{
		UpdateMainPanel();
	}

	public void UpdateGemstone()
	{
		int stock = GameManagers.Instance.StockController.GetStock("I40215");
		((GObject)addDiamondBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock("I40215").ToString();
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

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		if (itemId == "I40215")
		{
			UpdateGemstone();
			addDiamondBtn.GetChild("textSFXBack").displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(addDiamondBtn.GetChild("textSFXBack").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
	}

	private void DiamondBtnEvent()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemsDrawPanel.Name, null);
	}

	public void MoneyBtnEvent()
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
}
