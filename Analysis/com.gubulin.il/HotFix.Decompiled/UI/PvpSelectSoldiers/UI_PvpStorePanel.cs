using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.Tips;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_PvpStorePanel : GComponent, IUiController
{
	public Controller StoreType;

	public GLoader background;

	public GButton backBtn;

	public UI_Title titleCom;

	public GComponent addCouponBtn;

	public GComponent addDiamondBtn;

	public UI_TopThreeItems TopThreeItems;

	public GImage n5;

	public GGroup ItemsBack;

	public GTextField tip3;

	public GList cardList;

	public GImage n20;

	public UI_btn_PvpStoreTab TokenTab;

	public UI_btn_PvpStoreTab BetTab;

	public GImage MarkNew;

	public GGroup TabButtonGroup;

	public const string URL = "ui://82mo10n5t7wpddy";

	public static string Name = "UI_PvpStorePanel";

	public static UI_PvpStorePanel PvpStorePanel;

	private Coroutine Real_RenderOtherStoreItem;

	private Coroutine showFirstThreeItemsCoroutine;

	private int currentCount;

	private Coroutine loadSomeUiPublicResourcesCoroutine;

	private Coroutine showOtherItemsCoroutine;

	private RankDataHelper.PvpSeasonStoreActivity storeActivity;

	private List<StoreItem> itemList = new List<StoreItem>();

	private List<StoreItem> rewardList = new List<StoreItem>();

	private Coroutine TimeLimitRemainingCoroutine;

	private const string LanguageTemplate_TokenStoreItemCountDown = "CsharpCodeZhTcText501";

	private const string LanguageTemplate_BetStoreItemCountDown = "PvPBetStoreCountDownDesc";

	private string PanelName => LanguagesManager.GetDesc("CsharpCodeZhTcText500");

	public static string GetURL()
	{
		return "ui://82mo10n5t7wpddy";
	}

	public static UI_PvpStorePanel CreateInstance()
	{
		return (UI_PvpStorePanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpStorePanel");
	}

	public static UI_PvpStorePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpStorePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5t7wpddy", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StoreType = ((GComponent)this).GetController("StoreType");
		background = (GLoader)((GComponent)this).GetChild("background");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		titleCom = (UI_Title)(object)((GComponent)this).GetChild("titleCom");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		TopThreeItems = (UI_TopThreeItems)(object)((GComponent)this).GetChild("TopThreeItems");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		ItemsBack = (GGroup)((GComponent)this).GetChild("ItemsBack");
		tip3 = (GTextField)((GComponent)this).GetChild("tip3");
		cardList = (GList)((GComponent)this).GetChild("cardList");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		TokenTab = (UI_btn_PvpStoreTab)(object)((GComponent)this).GetChild("TokenTab");
		BetTab = (UI_btn_PvpStoreTab)(object)((GComponent)this).GetChild("BetTab");
		MarkNew = (GImage)((GComponent)this).GetChild("MarkNew");
		TabButtonGroup = (GGroup)((GComponent)this).GetChild("TabButtonGroup");
	}

	public void BeforeDestroy()
	{
		if (TimeLimitRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(TimeLimitRemainingCoroutine);
		}
		if (Real_RenderOtherStoreItem != null)
		{
			FGUIManager.Instance.CloseIEnumerator(Real_RenderOtherStoreItem);
		}
		PvpStorePanel = null;
	}

	public void Destroy()
	{
		UiHelper.UnloadPackage();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		PvpStorePanel = this;
		storeActivity = RankDataHelper.SeasonStoreActivity;
		titleCom.SetBuildingName(PanelName);
		RenderPvpToken();
		RenderBetToken();
		UpdateMainPanel(isInit: true);
		if (!RankDataHelper.IsServerWideBattle)
		{
			((GObject)BetTab).visible = false;
			((GObject)TokenTab).x = 1252f;
		}
		((GObject)BetTab.Title).text = LanguagesManager.GetDesc("BetTabTitle");
		((GObject)TokenTab.Title).text = LanguagesManager.GetDesc("TokenTabTitle");
		((GObject)MarkNew).visible = RankDataHelper.SeasonBetStoreIsNewRefreshed();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		StoreType.onChanged.Set(new EventCallback0(OnStoreTypeChanged));
		SharedMessenger.AddListener<string>("LIMIT_TIME_MERCHANDISE_EXPIRED", OnLimitTimeMerchandiseExpired);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		StoreType.onChanged.Clear();
		SharedMessenger.RemoveListener<string>("LIMIT_TIME_MERCHANDISE_EXPIRED", OnLimitTimeMerchandiseExpired);
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
	}

	private void OnStoreTypeChanged()
	{
		RenderCardList();
		UpdateStoreItemsRefreshTime();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderPvpToken()
	{
		addDiamondBtn.GetChild("num").text = "0";
		addDiamondBtn.GetChild("addButton").visible = false;
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + RankDataHelper.PvPRankScoreItem;
		UiHelper.NumberTextChangeGTween(0f, RankDataHelper.GetPvPRankScoreItemNum(), addDiamondBtn.GetChild("num").asTextField, 1f, (EaseType)19);
	}

	public void RenderBetToken()
	{
		addCouponBtn.GetChild("num").text = "0";
		addCouponBtn.GetChild("addButton").visible = false;
		addCouponBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + RankDataHelper.AllServerChampionshipExchangeCoin;
		UiHelper.NumberTextChangeGTween(0f, GameManagers.Instance.StockController.GetStock(RankDataHelper.AllServerChampionshipExchangeCoin), addCouponBtn.GetChild("num").asTextField, 1f, (EaseType)19);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (itemId == RankDataHelper.PvPRankScoreItem)
		{
			UiHelper.NumberTextChangeGTween(int.Parse(((GObject)addDiamondBtn.GetChild("num").asTextField).text), RankDataHelper.GetPvPRankScoreItemNum(), addDiamondBtn.GetChild("num").asTextField, 1f, (EaseType)19);
		}
		else if (itemId == RankDataHelper.AllServerChampionshipExchangeCoin)
		{
			UiHelper.NumberTextChangeGTween(int.Parse(((GObject)addCouponBtn.GetChild("num").asTextField).text), GameManagers.Instance.StockController.GetStock(RankDataHelper.AllServerChampionshipExchangeCoin), addCouponBtn.GetChild("num").asTextField, 1f, (EaseType)19);
		}
	}

	private void OnLimitTimeMerchandiseExpired(string storeItemId)
	{
		UpdateMainPanel();
	}

	private IEnumerator IEnumerator_LoadSomeUiPublicResources(Action action)
	{
		yield return null;
		UiHelper.LoadSomeUiPublicResources(action);
	}

	public void UpdateMainPanel(bool isInit = false)
	{
		if (storeActivity == null)
		{
			return;
		}
		((GObject)TopThreeItems.RewardList).visible = false;
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
		showOtherItemsCoroutine = FGUIManager.Instance.OpenIEnumerator(ShowOtherItems(aimNum, changeId, isInit));
		showFirstThreeItemsCoroutine = FGUIManager.Instance.OpenIEnumerator(ShowFirstThreeItems(aimNum, changeId, isInit));
	}

	private IEnumerator ShowOtherItems(int aimNum, int changeId, bool isInit = false)
	{
		if (currentCount >= aimNum)
		{
			RenderOtherStoreItems(isInit);
			IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
			uiService.ShowWaitingAnimation(show: false);
			uiService.SetUiTouchable(changeId);
		}
		else
		{
			yield return (object)new WaitForSeconds(0.1f);
			showOtherItemsCoroutine = FGUIManager.Instance.OpenIEnumerator(ShowOtherItems(aimNum, changeId, isInit));
		}
	}

	private void RenderOtherStoreItems(bool isInit = false)
	{
		if (isInit)
		{
			RenderCardList();
			TimeLimitRemainingCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshTimeLimitRemaining());
		}
		else
		{
			RenderCardList();
		}
	}

	private IEnumerator LoadStoreItemsFromStoreActivity()
	{
		if (storeActivity.OtherStoreItems == null || storeActivity.OtherStoreItems.Count <= 0)
		{
			yield break;
		}
		List<StoreItem> _result = new List<StoreItem>();
		for (int i = 0; i < storeActivity.OtherStoreItems.Count; i++)
		{
			StoreItem storeItem = storeActivity.OtherStoreItems[i];
			if (storeItem == null)
			{
				continue;
			}
			if (storeItem.PurchaseLimitPeriod != PurchaseLimitType.NoLimit)
			{
				int storeItemPurchaseCnt = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
				int remainingCnt = storeItem.PurchaseLimit - storeItemPurchaseCnt;
				if (remainingCnt <= 0)
				{
					continue;
				}
			}
			_result.Add(storeItem);
		}
		if (_result.Count > 0)
		{
			itemList = FGUIManager.Instance.GiftBagSort(_result);
		}
	}

	private IEnumerator LoadStoreItemsFromAllServersChampionship()
	{
		if (RankDataHelper.NeedUpdateAllServersChampionshipInfo())
		{
			yield return RankDataHelper.GetAllServersChampionshipInfoCoroutine();
		}
		List<StoreItem> storeItems = new List<StoreItem>();
		using (List<Shift.Legion.GvG.Common.Models.WarRealmStoreItem>.Enumerator enumerator = RankDataHelper.AllServersChampionshipInfo.StoreContents.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				storeItems.Add(StoreItem.Get(storeItemId: enumerator.Current.StoreItemId, managers: GameManagers.Instance));
			}
		}
		itemList = FGUIManager.Instance.GiftBagSort(storeItems);
		RankDataHelper.SeasonBetStoreMarkReviewed();
		((GObject)MarkNew).visible = false;
	}

	private void RenderCardList()
	{
		itemList.Clear();
		cardList.RemoveChildrenToPool();
		Real_RenderOtherStoreItem = FGUIManager.Instance.OpenIEnumerator(Real_RenderOtherStoreItems());
	}

	private IEnumerator Real_RenderOtherStoreItems()
	{
		if (StoreType.selectedIndex == 0)
		{
			yield return LoadStoreItemsFromStoreActivity();
		}
		else if (StoreType.selectedIndex == 1)
		{
			yield return LoadStoreItemsFromAllServersChampionship();
		}
		for (int i = 0; i < itemList.Count; i++)
		{
			int index = i;
			if (cardList != null && !((GObject)cardList).isDisposed)
			{
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
		}
		if (cardList != null && !((GObject)cardList).isDisposed)
		{
			((GComponent)cardList).EnsureBoundsCorrect();
		}
	}

	private void RenderCardListItem(int index, GObject obj)
	{
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Expected O, but got Unknown
		UI_AddCreditCard uI_AddCreditCard = (UI_AddCreditCard)(object)obj;
		StoreItem storeItem = (StoreItem)(((GObject)uI_AddCreditCard).data = itemList[index]);
		uI_AddCreditCard.StoreType.selectedIndex = StoreType.selectedIndex;
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
		((GObject)uI_AddCreditCard.result).text = storeItem.Name;
		if (storeItem.PurchaseLimitPeriod != PurchaseLimitType.NoLimit)
		{
			string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText27");
			uI_AddCreditCard.RewardController.selectedIndex = 1;
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
			int num = storeItem.PurchaseLimit - purchaseCntAtLimitPeriod;
			string text = ((num > 0) ? "#7C4B2A" : "#c41d19");
			((GObject)uI_AddCreditCard.reward).text = string.Format("{0}[color={1}]{2}/{3}[/color]{4}", desc, text, num, storeItem.PurchaseLimit, LanguagesManager.GetDesc("CsharpCodeZhTcText236"));
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
		((GObject)uI_AddCreditCard.FirstTimeDouble).visible = false;
		((GObject)uI_AddCreditCard).onClick.Set(new EventCallback1(ShowGiftBag));
	}

	private void ShowGiftBag(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		object data = ((GObject)context.sender).data;
		StoreItem storeItem = (StoreItem)data;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems.Name, new Dictionary<string, object>
		{
			{
				"Name",
				storeItem.Name ?? ""
			},
			{ "CanBuy", true },
			{ "GiftBag", storeItem },
			{ "Parent", this },
			{ "IsBatchPurchaseMode", true }
		});
	}

	private IEnumerator ShowFirstThreeItems(int aimNum, int changeId, bool isInit = false)
	{
		if (currentCount >= aimNum)
		{
			RenderRewardList();
			IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
			uiService.ShowWaitingAnimation(show: false);
			uiService.SetUiTouchable(changeId);
		}
		else
		{
			yield return (object)new WaitForSeconds(0.1f);
			showFirstThreeItemsCoroutine = FGUIManager.Instance.OpenIEnumerator(ShowFirstThreeItems(aimNum, changeId, isInit));
		}
	}

	private void RenderRewardList()
	{
		rewardList.Clear();
		Real_RenderRewardItems();
	}

	private void Real_RenderRewardItems()
	{
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		if (storeActivity.FirstThreeStoreItems == null || storeActivity.FirstThreeStoreItems.Count <= 0)
		{
			((GObject)TopThreeItems.RewardList).visible = false;
			return;
		}
		for (int i = 0; i < storeActivity.FirstThreeStoreItems.Count; i++)
		{
			StoreItem storeItem = storeActivity.FirstThreeStoreItems[i];
			if (storeItem != null)
			{
				rewardList.Add(storeItem);
			}
		}
		if (rewardList.Count <= 0)
		{
			((GObject)TopThreeItems.RewardList).visible = false;
			return;
		}
		((GObject)TopThreeItems.RewardList).visible = true;
		for (int j = 0; j < rewardList.Count; j++)
		{
			if (j > 2)
			{
				break;
			}
			int index = j;
			GObject item = ((GComponent)TopThreeItems.RewardList).GetChildAt(j);
			item.alpha = 0f;
			item.touchable = false;
			RenderRewardItem(index, item);
			item.TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
			{
				item.touchable = true;
			});
		}
		((GComponent)TopThreeItems.RewardList).EnsureBoundsCorrect();
	}

	private void RenderRewardItem(int index, GObject obj)
	{
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		if (obj is UI_PvpStoreReward uI_PvpStoreReward)
		{
			StoreItem storeItem = rewardList[index];
			((GObject)uI_PvpStoreReward.RewardName).text = storeItem.Name ?? "";
			if (storeItem.Icon.Contains("PublicResourceStoreItemIcons"))
			{
				uI_PvpStoreReward.Icon.url = "ui:" + storeItem.Icon;
			}
			else
			{
				uI_PvpStoreReward.Icon.url = "ui://PublicResources/" + storeItem.Icon;
			}
			uI_PvpStoreReward.Type.selectedIndex = index;
			if (storeItem.PurchaseLimitPeriod != PurchaseLimitType.NoLimit)
			{
				string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText27");
				int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
				int num = storeItem.PurchaseLimit - purchaseCntAtLimitPeriod;
				string text = ((num > 0) ? "#FFFFFF" : "#e72521");
				((GObject)uI_PvpStoreReward.countLimit).text = string.Format("{0}[color={1}]{2}/{3}[/color]{4}", desc, text, num, storeItem.PurchaseLimit, LanguagesManager.GetDesc("CsharpCodeZhTcText236"));
			}
			else
			{
				((GObject)uI_PvpStoreReward.countLimit).text = "";
			}
			KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(storeItem);
			Dictionary<string, float> dictionary = storeItem.Price.First();
			string key = priceItemId.Key;
			int stock = GameManagers.Instance.StockController.GetStock(key);
			((GObject)uI_PvpStoreReward.Price1st).text = $"{stock.ShortNumberFormat()}/{Convert.ToInt32(priceItemId.Value)}";
			uI_PvpStoreReward.currentCurrencyIcon.url = "ui://PublicResources/" + key;
			((GObject)uI_PvpStoreReward.ExchangeBtn).data = storeItem;
			((GObject)uI_PvpStoreReward.ExchangeBtn).onClick.Set(new EventCallback1(ShowGiftBag));
		}
	}

	private void UpdateStoreItemsRefreshTime()
	{
		int num = 0;
		string id = "CsharpCodeZhTcText501";
		if (StoreType.selectedIndex == 0)
		{
			num = DateTimeHelper.GetTimeStamp(storeActivity.EndAt);
		}
		else if (StoreType.selectedIndex == 1)
		{
			if (RankDataHelper.AllServersChampionshipInfo == null)
			{
				ILRuntimeDebug.LogError("PvPStorePanel Page For AllServersChampionship Find No Activity");
				((GObject)tip3).text = "";
				return;
			}
			id = "PvPBetStoreCountDownDesc";
			num = DateTimeHelper.GetTimeStamp(RankDataHelper.AllServersChampionshipInfo.IsRoundI() ? RankDataHelper.AllServersChampionshipInfo.RoundIDuration[1] : RankDataHelper.AllServersChampionshipInfo.RoundIIDuration[1]);
		}
		if (num <= 0)
		{
			((GObject)tip3).text = "";
			return;
		}
		int time = num - DateTimeHelper.ServerNowTimestamp;
		((GObject)tip3).text = LanguagesManager.GetDesc(id) + " : " + ParseTimeChnForGift(time);
	}

	public static string ParseTimeChnForGift(int time)
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return UiHelper.ParseTimeSpanUniversal(time);
		}
		int num = time % 86400 / 3600;
		int num2 = time / 86400;
		int num3 = time % 3600 / 60;
		string text = "";
		if (num2 > 0)
		{
			text += string.Format("{0}{1}", num2, LanguagesManager.GetDesc("CsharpCodeZhTcText228"));
		}
		if (num > 0 || num2 > 0)
		{
			text += string.Format("{0}{1}", num, LanguagesManager.GetDesc("CsharpCodeZhTcText248"));
		}
		return text + string.Format("{0}{1}", num3, LanguagesManager.GetDesc("CsharpCodeZhTcText502"));
	}

	private IEnumerator RefreshTimeLimitRemaining()
	{
		while (true)
		{
			UpdateStoreItemsRefreshTime();
			for (int i = 0; i < cardList.numItems; i++)
			{
				UI_AddCreditCard button = (UI_AddCreditCard)(object)((GComponent)cardList).GetChildAt(i);
				if (!(((GObject)(button?)).data is StoreItem storeItem))
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
				if (storeItem.PurchaseLimitPeriod != PurchaseLimitType.NoLimit)
				{
					string title = LanguagesManager.GetDesc("CsharpCodeZhTcText27");
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
				((GObject)button.FirstTimeDouble).visible = false;
			}
			yield return (object)new WaitForSeconds(1f);
		}
	}
}
