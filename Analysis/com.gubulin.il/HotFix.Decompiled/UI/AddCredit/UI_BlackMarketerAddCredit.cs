using System;
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
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.BlackMarketer;
using UI.GiftBag;
using UI.MainCity;
using UI.PaymentOptions;
using UI.PublicResources;
using UnityEngine;

namespace UI.AddCredit;

public class UI_BlackMarketerAddCredit : GComponent, IUiController
{
	public GLoader background;

	public GImage n12;

	public GComponent n13;

	public GComponent n14;

	public GComponent n15;

	public GImage n16;

	public GImage n17;

	public GImage n20;

	public GImage n21;

	public GGraph mask;

	public UI_CardLoader CardLoader;

	public GComponent n18;

	public GComponent n19;

	public UI_Title titleCom;

	public GButton backBtn;

	public GComponent addCouponBtn;

	public GComponent addDiamondBtn;

	public GGraph line;

	public GGraph missibleSfxBack;

	public GGraph missbleEndPos;

	public GLoader Tips;

	public const string URL = "ui://4pot8w0vavmf0";

	public static string Name = "UI_BlackMarketerAddCredit";

	private List<string> textureList = new List<string>();

	private IUiController parent;

	private Activity storeActivity;

	private List<Shift.Legion.Common.Models.Store.StoreItem> itemList = new List<Shift.Legion.Common.Models.Store.StoreItem>();

	private UI_ProductionNumFloating NumFloating;

	public static string GetURL()
	{
		return "ui://4pot8w0vavmf0";
	}

	public static UI_BlackMarketerAddCredit CreateInstance()
	{
		return (UI_BlackMarketerAddCredit)(object)UIPackage.CreateObject("AddCredit", "BlackMarketerAddCredit");
	}

	public static UI_BlackMarketerAddCredit CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BlackMarketerAddCredit).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4pot8w0vavmf0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GComponent)((GComponent)this).GetChild("n13");
		n14 = (GComponent)((GComponent)this).GetChild("n14");
		n15 = (GComponent)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		CardLoader = (UI_CardLoader)(object)((GComponent)this).GetChild("CardLoader");
		n18 = (GComponent)((GComponent)this).GetChild("n18");
		n19 = (GComponent)((GComponent)this).GetChild("n19");
		titleCom = (UI_Title)(object)((GComponent)this).GetChild("titleCom");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		addCouponBtn = (GComponent)((GComponent)this).GetChild("addCouponBtn");
		addDiamondBtn = (GComponent)((GComponent)this).GetChild("addDiamondBtn");
		line = (GGraph)((GComponent)this).GetChild("line");
		missibleSfxBack = (GGraph)((GComponent)this).GetChild("missibleSfxBack");
		missbleEndPos = (GGraph)((GComponent)this).GetChild("missbleEndPos");
		Tips = (GLoader)((GComponent)this).GetChild("Tips");
	}

	public void Init(Dictionary<string, object> parameters)
	{
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
			if (parameters.TryGetValue("Order", out var value3))
			{
				((GObject)this).sortingOrder = (int)value3;
			}
			else
			{
				((GObject)this).sortingOrder = 1;
			}
		}
		if (storeActivity == null)
		{
			End();
		}
		List<string> activityIds = new List<string> { storeActivity.ActivityId };
		if (storeActivity.ActivityProgress(GameManagers.Instance).IsNew)
		{
			GameManagers.Instance.ActivityManager.ReviewActivities(activityIds);
		}
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		SetBuildingName();
		UiHelper.LoadSomeUiPublicResources(UpdateCardList);
		((GObject)background).width = ((GObject)GRoot.inst).width;
	}

	public void OnShow()
	{
		if (storeActivity != null)
		{
			foreach (KeyValuePair<string, ActivityContentPayload> item in storeActivity.ContentPayload(GameManagers.Instance))
			{
				GameManagers.Instance.NewMsgIncomingManager.CheckActivityContent(storeActivity.ActivityId, item.Key);
			}
		}
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		addDiamondBtn.GetChild("addButton").onClick.Add(new EventCallback0(DiamondBtnEvent));
		addCouponBtn.GetChild("addButton").onClick.Add(new EventCallback0(MoneyBtnEvent));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
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
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		addDiamondBtn.GetChild("addButton").onClick.Remove(new EventCallback0(DiamondBtnEvent));
		addCouponBtn.GetChild("addButton").onClick.Remove(new EventCallback0(MoneyBtnEvent));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		UiHelper.UnloadPackage();
		if (parent != null && parent is UI_MainCity)
		{
			UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		}
	}

	private void CardRenderer(int index, GObject obj)
	{
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Expected O, but got Unknown
		UI_AddCreditCard uI_AddCreditCard = (UI_AddCreditCard)(object)obj;
		Shift.Legion.Common.Models.Store.StoreItem storeItem = itemList[index];
		((GObject)uI_AddCreditCard).data = storeItem;
		if (storeItem.Icon.Contains("PublicResourceStoreItemIcons"))
		{
			uI_AddCreditCard.icon.url = "ui:" + storeItem.Icon;
		}
		else
		{
			uI_AddCreditCard.icon.url = "ui://PublicResources/" + storeItem.Icon;
		}
		((GObject)uI_AddCreditCard.result).text = storeItem.Name;
		if (storeItem.DoubleAtFirst && GameManagers.Instance.StoreManager.GetPurchaseCnt(storeItem.StoreItemId) < 1)
		{
			((GObject)uI_AddCreditCard.FirstTimeDouble).visible = true;
			uI_AddCreditCard.RewardController.selectedIndex = 1;
			((GObject)uI_AddCreditCard.reward).text = storeItem.SubDesc;
		}
		else
		{
			((GObject)uI_AddCreditCard.FirstTimeDouble).visible = false;
			uI_AddCreditCard.RewardController.selectedIndex = 0;
		}
		KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(storeItem);
		Dictionary<string, float> dictionary = storeItem.OriginPrice.First();
		string key = priceItemId.Key;
		FGUIManager.Instance.GetCurrencySymbol(key, uI_AddCreditCard.currentCurrencyIcon, textureList);
		string text = $"{Convert.ToInt32(dictionary.Values.First())}";
		string text2 = $"{Convert.ToInt32(priceItemId.Value)}";
		bool flag = key == "RMB";
		bool flag2 = true;
		ProductLocalInfo productLocalInfo = null;
		if (HotUpdateProcess.Instance.IsRegionOutCN && flag)
		{
			((GObject)uI_AddCreditCard.priceGroup).visible = false;
			((GObject)uI_AddCreditCard.priceGroupIntl).visible = true;
			if (!string.IsNullOrEmpty(storeItem.ReferenceId) && PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out productLocalInfo))
			{
				if (productLocalInfo.Price > 0f)
				{
					text2 = productLocalInfo.FormattedPrice;
					text = $"{productLocalInfo.CurrencySymbol}{productLocalInfo.Price / storeItem.InternationalDiscount:F2}";
				}
				else
				{
					flag2 = false;
					text2 = LanguagesManager.GetDesc("CsharpCodeTextPriceFree");
				}
			}
			else
			{
				flag2 = false;
				text2 = "--";
				if (string.IsNullOrEmpty(storeItem.ReferenceId) && priceItemId.Value <= 0f)
				{
					text2 = LanguagesManager.GetDesc("CsharpCodeTextPriceFree");
				}
			}
		}
		else
		{
			((GObject)uI_AddCreditCard.priceGroup).visible = true;
			((GObject)uI_AddCreditCard.priceGroupIntl).visible = false;
		}
		((GObject)uI_AddCreditCard.Price1st).text = text2;
		((GObject)uI_AddCreditCard.Discount_2).visible = false;
		if (storeItem.IsFree)
		{
			uI_AddCreditCard.Discount.selectedIndex = (flag2 ? 1 : 0);
			((GObject)uI_AddCreditCard.Price2nd).text = text;
			FGUIManager.Instance.GetCurrencySymbol(key, uI_AddCreditCard.originalCurrencyIcon, textureList);
			((GObject)uI_AddCreditCard.Discount_2).visible = true;
			uI_AddCreditCard.Discount_2.GetController("PageController").selectedIndex = 3;
			((GObject)uI_AddCreditCard.curIntlPriceText).text = LanguagesManager.GetDesc("CsharpCodeTextPriceFree");
		}
		else if (Mathf.Abs(storeItem.Discount - 1f) > float.Epsilon && storeItem.Discount > float.Epsilon)
		{
			uI_AddCreditCard.Discount.selectedIndex = (flag2 ? 1 : 0);
			((GObject)uI_AddCreditCard.Price2nd).text = text;
			FGUIManager.Instance.GetCurrencySymbol(key, uI_AddCreditCard.originalCurrencyIcon, textureList);
			((GObject)uI_AddCreditCard.curIntlPriceText).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText956"), text2);
			((GObject)uI_AddCreditCard.originIntlPriceText).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText955"), text);
		}
		else
		{
			uI_AddCreditCard.Discount.selectedIndex = 0;
			((GObject)uI_AddCreditCard.curIntlPriceText).text = string.Format(LanguagesManager.GetDesc("CsharpCodeZhTcText957"), text2);
		}
		uI_AddCreditCard.SetControllerPageText(uI_AddCreditCard.Discount.selectedIndex);
		((GObject)uI_AddCreditCard).onClick.Set((EventCallback0)delegate
		{
			PurchaseManager.Instance.InvokePurchase(storeItem, productLocalInfo, 1, (Action)null, doubleCheck: true);
		});
	}

	public async void UpdateCardList()
	{
		await GetData();
		CardLoader.cardList.itemRenderer = new ListItemRenderer(CardRenderer);
		CardLoader.cardList.numItems = itemList.Count;
		for (int i = 0; i < itemList.Count; i++)
		{
			ThinkingDataHelper.Instance.PayPreviewTrack(itemList[i].StoreItemId);
		}
		if (itemList.Count > 0)
		{
			ThinkingDataHelper.Instance.TimeEvent("nopay_preview");
		}
	}

	public void DiamondBtnEvent()
	{
		UpdateCardList();
	}

	private void MoneyBtnEvent()
	{
		if (parent != null && parent is UI_GiftBagPanel)
		{
			((UI_GiftBagPanel)parent).MoneyBtnEvent();
			End();
			return;
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_GiftBagPanel.Name, new Dictionary<string, object>
		{
			{ "Parent", this },
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

	private void AddCredit(Shift.Legion.Common.Models.Store.StoreItem storeItem)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PaymentOptionsDialog.Name, new Dictionary<string, object>
		{
			{ "StoreItemId", storeItem.StoreItemId },
			{ "CallBack", null },
			{ "DoubleCheck", true }
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

	private void OrderShipSuccessEvent(List<Bonus> result, List<Bonus> bonuses)
	{
		if (parent != null && parent is UI_BlackMarketerPanel uI_BlackMarketerPanel)
		{
			uI_BlackMarketerPanel.UpdateItemCard(Name);
		}
		PlayMissileSfx();
		UpdateCardList();
	}

	private void PlayMissileSfx()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		((GObject)missibleSfxBack).SetPivot(0.5f, 0.5f, true);
		((GObject)missibleSfxBack).SetXY(960f, 500f);
		FGUIManager.Instance.AddTextSpecialEffects(missibleSfxBack, "exp_missile_green", Vector3.zero);
		((GObject)missibleSfxBack).TweenMove(((GObject)missbleEndPos).xy, 0.5f);
		UiAudioManager.Instance.PlaySoundEffect("Missile");
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		ThinkingDataHelper.Instance.NoPayPreviewTrack();
	}

	private void SetBuildingName()
	{
		((GObject)titleCom.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText97");
		UpdateGemstone();
		UpdateMoney(isInit: true);
		addDiamondBtn.GetChild("diamond").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Gem");
		addCouponBtn.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon("Money");
	}

	public void UpdateGemstone()
	{
		((GObject)addDiamondBtn.GetChild("num").asTextField).text = GameManagers.Instance.StockController.GetStock("Gem").ToString();
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

	private async Task GetData()
	{
		GetStoreActivityItemsResponse storeItemsResponse = await GameController.Contexts.Service<INetworkService>().GetStoreActivityItems(storeActivity.ActivityId, storeActivity.ContentPayload(GameManagers.Instance).Keys.First());
		Shift.Legion.ClientApi.Protocol.Store.StoreItem[] incomingStoreItems = storeItemsResponse.StoreItems;
		if (!storeItemsResponse.Result)
		{
			ILRequestHelper.ShowErrorCode(storeItemsResponse.ErrorCode);
			return;
		}
		itemList.Clear();
		Shift.Legion.ClientApi.Protocol.Store.StoreItem[] array = incomingStoreItems;
		foreach (Shift.Legion.ClientApi.Protocol.Store.StoreItem storeItemData in array)
		{
			itemList.Add(new Shift.Legion.Common.Models.Store.StoreItem(GameManagers.Instance, storeItemData.StoreItemId)
			{
				Icon = storeItemData.Icon,
				Rarity = storeItemData.Rarity,
				Category = (StoreCategory)storeItemData.Category,
				DoubleAtFirst = storeItemData.DoubleAtFirst,
				BonusAtFirst = storeItemData.BonusAtFirst,
				Tags = storeItemData.Tags,
				ValidTime = storeItemData.ValidTime,
				KickOffTimestamp = storeItemData.KickOffTimestamp,
				ExpireTimestamp = storeItemData.ExpireTimestamp,
				Content = storeItemData.Content,
				DisplayContent = storeItemData.DisplayContent,
				OriginPrice = storeItemData.OriginPrice,
				Price = storeItemData.Price,
				Discount = storeItemData.Discount,
				PurchaseLimit = storeItemData.PurchaseLimit,
				PurchaseLimitPeriod = (PurchaseLimitType)storeItemData.PurchaseLimitPeriod,
				IsExpo = storeItemData.IsExpo,
				Substitution = storeItemData.Substitution,
				IsResident = storeItemData.IsResident,
				UserLevelFilter = storeItemData.UserLevelFilter,
				DungeonLevelFilter = storeItemData.DungeonLevelFilter,
				GameLevelFilter = storeItemData.GameLevelFilter,
				OwnedItemFilter = storeItemData.OwnedItemFilter,
				PurchaseFilter = storeItemData.PurchaseFilter
			});
		}
	}
}
