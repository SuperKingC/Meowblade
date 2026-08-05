using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;
using UI.GiftBag;
using UI.PublicResources;
using UI.Tips;
using UnityEngine;

namespace UI.SoulKeyStore;

public class UI_SoulKeyStorePanel : GComponent, IUiController
{
	public Controller Type;

	public GLoader background;

	public GButton backBtn;

	public UI_Title titleCom;

	public UI_dec_StoneFloating n71;

	public UI_dec_StoneFloatingsmall n72;

	public UI_dec_StoneFloatingsmall n73;

	public UI_dec_StoneFloatingsmall n74;

	public UI_dec_StoneFloatingsmall n75;

	public UI_dec_StoneFloating n76;

	public UI_dec_StoneFloating n77;

	public UI_dec_StoneFloating n78;

	public UI_dec_StoneFloatingsmall n79;

	public UI_dec_StoneFloatingsmall n80;

	public UI_dec_StoneFloatingsmall n81;

	public GImage n6;

	public GImage n67;

	public GImage n68;

	public GImage n69;

	public GImage n70;

	public GImage n63;

	public GImage n64;

	public GImage n65;

	public GImage n66;

	public GImage n51;

	public GImage n52;

	public GImage n53;

	public GImage n54;

	public GImage n55;

	public GImage n56;

	public GImage n57;

	public GImage n58;

	public GImage n59;

	public GImage n60;

	public GImage n61;

	public GImage n62;

	public GGroup back0;

	public GTextField tip;

	public GList FreeCardList;

	public GList PaidCardList;

	public GList Tabs;

	public GGraph missibleSfxBack;

	public GGraph missbleEndPos;

	public UI_currencyBtn FreeCurrencyBtn;

	public UI_currencyBtn PaidCurrencyBtn;

	public UI_com_Scroll scrollDown;

	public const string URL = "ui://3nd2hqkivzbki";

	public static string Name = "UI_SoulKeyStorePanel";

	private List<string> textureList = new List<string>();

	private List<GvG3StoreManager.StoreItem_Ex> freeitemList = new List<GvG3StoreManager.StoreItem_Ex>();

	private List<GvG3StoreManager.StoreItem_Ex> paidItemList = new List<GvG3StoreManager.StoreItem_Ex>();

	private UI_ProductionNumFloating NumFloating;

	private static string FreeCurrency = "";

	private static string PaidCurrency = "";

	private GvG3StoreManager.SoulKeyStoreConfigData Data;

	private UI_ActivityTab FreeTab;

	private UI_ActivityTab PaidTab;

	public static string GetURL()
	{
		return "ui://3nd2hqkivzbki";
	}

	public static UI_SoulKeyStorePanel CreateInstance()
	{
		return (UI_SoulKeyStorePanel)(object)UIPackage.CreateObject("SoulKeyStore", "SoulKeyStorePanel");
	}

	public static UI_SoulKeyStorePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoulKeyStorePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkivzbki", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
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
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
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
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected O, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Expected O, but got Unknown
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected O, but got Unknown
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Expected O, but got Unknown
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected O, but got Unknown
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		background = (GLoader)((GComponent)this).GetChild("background");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		titleCom = (UI_Title)(object)((GComponent)this).GetChild("titleCom");
		n71 = (UI_dec_StoneFloating)(object)((GComponent)this).GetChild("n71");
		n72 = (UI_dec_StoneFloatingsmall)(object)((GComponent)this).GetChild("n72");
		n73 = (UI_dec_StoneFloatingsmall)(object)((GComponent)this).GetChild("n73");
		n74 = (UI_dec_StoneFloatingsmall)(object)((GComponent)this).GetChild("n74");
		n75 = (UI_dec_StoneFloatingsmall)(object)((GComponent)this).GetChild("n75");
		n76 = (UI_dec_StoneFloating)(object)((GComponent)this).GetChild("n76");
		n77 = (UI_dec_StoneFloating)(object)((GComponent)this).GetChild("n77");
		n78 = (UI_dec_StoneFloating)(object)((GComponent)this).GetChild("n78");
		n79 = (UI_dec_StoneFloatingsmall)(object)((GComponent)this).GetChild("n79");
		n80 = (UI_dec_StoneFloatingsmall)(object)((GComponent)this).GetChild("n80");
		n81 = (UI_dec_StoneFloatingsmall)(object)((GComponent)this).GetChild("n81");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		n69 = (GImage)((GComponent)this).GetChild("n69");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		n66 = (GImage)((GComponent)this).GetChild("n66");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n57 = (GImage)((GComponent)this).GetChild("n57");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n59 = (GImage)((GComponent)this).GetChild("n59");
		n60 = (GImage)((GComponent)this).GetChild("n60");
		n61 = (GImage)((GComponent)this).GetChild("n61");
		n62 = (GImage)((GComponent)this).GetChild("n62");
		back0 = (GGroup)((GComponent)this).GetChild("back0");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://3nd2hqkivzbki".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		FreeCardList = (GList)((GComponent)this).GetChild("FreeCardList");
		PaidCardList = (GList)((GComponent)this).GetChild("PaidCardList");
		Tabs = (GList)((GComponent)this).GetChild("Tabs");
		missibleSfxBack = (GGraph)((GComponent)this).GetChild("missibleSfxBack");
		missbleEndPos = (GGraph)((GComponent)this).GetChild("missbleEndPos");
		FreeCurrencyBtn = (UI_currencyBtn)(object)((GComponent)this).GetChild("FreeCurrencyBtn");
		PaidCurrencyBtn = (UI_currencyBtn)(object)((GComponent)this).GetChild("PaidCurrencyBtn");
		scrollDown = (UI_com_Scroll)(object)((GComponent)this).GetChild("scrollDown");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: true);
		Singleton<GvG3StoreManager>.Instance.GetSoulKeyStoreData(delegate(GvG3StoreManager.SoulKeyStoreConfigData data)
		{
			Contexts.sharedInstance.Service<IUiService>().ShowWaitingAnimation(show: false);
			Data = data;
			freeitemList = Data.FreeItemList;
			paidItemList = Data.PaidItemList;
			if (freeitemList.Count > 0)
			{
				FreeCurrency = "I32100";
			}
			if (paidItemList.Count > 0)
			{
				PaidCurrency = "I32101";
			}
			UpdateMainPanel();
			RenderCurrency();
		});
		RenderTabs();
	}

	public void OnShow()
	{
		InitMask();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		((GObject)backBtn).onClick.Add(new EventCallback0(End));
		Type.onChanged.Add(new EventCallback1(OnSwitchTab));
		GvG3StoreManager instance = Singleton<GvG3StoreManager>.Instance;
		instance.OnChangeSoulKeyStoreNotice = (Action)Delegate.Combine(instance.OnChangeSoulKeyStoreNotice, new Action(OnChangeSoulKeyStoreNotice));
		((GObject)PaidCurrencyBtn.addButton).onClick.Add(new EventCallback0(CurrencyBtnEvent));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OnOrderShipSuccess);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		((GObject)backBtn).onClick.Remove(new EventCallback0(End));
		Type.onChanged.Remove(new EventCallback1(OnSwitchTab));
		GvG3StoreManager instance = Singleton<GvG3StoreManager>.Instance;
		instance.OnChangeSoulKeyStoreNotice = (Action)Delegate.Remove(instance.OnChangeSoulKeyStoreNotice, new Action(OnChangeSoulKeyStoreNotice));
		((GObject)PaidCurrencyBtn.addButton).onClick.Remove(new EventCallback0(CurrencyBtnEvent));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OnOrderShipSuccess);
	}

	public void UpdateMainPanel()
	{
		if (Type.selectedIndex == 0)
		{
			UpdateFreeCards();
		}
		else
		{
			UpdatePaidCards();
		}
	}

	private void RenderTabs()
	{
		Type.selectedIndex = 0;
		FreeTab = ((GComponent)Tabs).GetChildAt(0) as UI_ActivityTab;
		((GObject)FreeTab).data = 0;
		PaidTab = ((GComponent)Tabs).GetChildAt(1) as UI_ActivityTab;
		((GObject)PaidTab).data = 1;
		UpdateNotice();
	}

	private void UpdateFreeCards()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		GiftBagSort(freeitemList);
		FreeCardList.itemRenderer = (ListItemRenderer)delegate(int index, GObject obj)
		{
			RenderCardListItem(index, obj, freeitemList);
		};
		FreeCardList.numItems = freeitemList.Count;
		((GComponent)FreeCardList).scrollPane.onScroll.Set((EventCallback0)delegate
		{
			RefreshScrollDownVisible();
		});
	}

	private void UpdatePaidCards()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		GiftBagSort(paidItemList);
		PaidCardList.itemRenderer = (ListItemRenderer)delegate(int index, GObject obj)
		{
			RenderCardListItem(index, obj, paidItemList);
		};
		PaidCardList.numItems = paidItemList.Count;
		((GComponent)PaidCardList).scrollPane.onScroll.Set((EventCallback0)delegate
		{
			RefreshScrollDownVisible();
		});
	}

	private void RenderCardListItem(int index, GObject obj, List<GvG3StoreManager.StoreItem_Ex> storeItems)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Expected O, but got Unknown
		bool flag = true;
		UI_AddCreditCard uI_AddCreditCard = (UI_AddCreditCard)(object)obj;
		GvG3StoreManager.StoreItem_Ex storeItem_Ex = (GvG3StoreManager.StoreItem_Ex)(((GObject)uI_AddCreditCard).data = storeItems[index]);
		uI_AddCreditCard.Soulkeytype.selectedIndex = Type.selectedIndex;
		FGUIManager.Instance.AddTextSpecialEffects(uI_AddCreditCard.sfxBack, "ui_active_glow_orange_3", new Vector3(180f, 180f, 180f));
		uI_AddCreditCard.icon.url = "ui://PublicResources/" + storeItem_Ex.Icon;
		((GObject)uI_AddCreditCard.FirstTimeDouble).visible = false;
		((GObject)uI_AddCreditCard.originalPriceTitle).visible = false;
		((GObject)uI_AddCreditCard.result).text = storeItem_Ex.Name;
		((GObject)uI_AddCreditCard.result2).text = storeItem_Ex.Name;
		((GObject)uI_AddCreditCard.currentPriceTitle).visible = false;
		if (storeItem_Ex.PurchaseLimitPeriod != PurchaseLimitType.NoLimit)
		{
			string goodsPurchaseLimitTitle = FGUIManager.Instance.GetGoodsPurchaseLimitTitle(storeItem_Ex.PurchaseLimitPeriod);
			uI_AddCreditCard.RewardController.selectedIndex = 1;
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem_Ex.StoreItemId);
			int num = storeItem_Ex.PurchaseLimit - purchaseCntAtLimitPeriod;
			string text = ((num > 0) ? "#7C4B2A" : "#c41d19");
			((GObject)uI_AddCreditCard.reward).text = string.Format("{0}[color={1}]{2}/{3}[/color]{4}", goodsPurchaseLimitTitle, text, num, storeItem_Ex.PurchaseLimit, LanguagesManager.GetDesc("CsharpCodeZhTcText236"));
			((GObject)uI_AddCreditCard.reward2).text = ((GObject)uI_AddCreditCard.reward).text;
			if (num <= 0)
			{
				flag = false;
				uI_AddCreditCard.RewardController.selectedIndex = 2;
				((GObject)uI_AddCreditCard.FirstTimeDouble).visible = true;
				uI_AddCreditCard.FirstTimeDouble.Stauts.selectedIndex = 1;
				((GObject)uI_AddCreditCard.FirstTimeDouble.time).text = LanguagesManager.GetDesc("CsharpCodeZhTcText960");
			}
			else
			{
				string key = storeItem_Ex.Content.First().Key;
				GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(key);
				int stock = GameManagers.Instance.StockController.GetStock(key);
				SoulKeyItemEffect soulKeyItemEffect = JsonHelper.ToObject<SoulKeyItemEffect>(gDEItemData.Effect);
				int soldierPotentialLevel = GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(soulKeyItemEffect.SoldierId);
				if (soldierPotentialLevel >= soulKeyItemEffect.PotentialLevel || stock > 0)
				{
					flag = false;
					uI_AddCreditCard.RewardController.selectedIndex = 2;
					((GObject)uI_AddCreditCard.FirstTimeDouble).visible = true;
					uI_AddCreditCard.FirstTimeDouble.Stauts.selectedIndex = 1;
					((GObject)uI_AddCreditCard.FirstTimeDouble.time).text = LanguagesManager.GetDesc("CsharpCodeZhTcText960");
				}
				else
				{
					uI_AddCreditCard.RewardController.selectedIndex = 1;
				}
			}
		}
		else
		{
			uI_AddCreditCard.RewardController.selectedIndex = 0;
		}
		KeyValuePair<string, float> priceItemId = FGUIManager.Instance.GetPriceItemId(storeItem_Ex);
		Dictionary<string, float> dictionary = storeItem_Ex.Price.First();
		Dictionary<string, float> dictionary2 = storeItem_Ex.OriginPrice.First();
		string key2 = priceItemId.Key;
		if (storeItem_Ex.IsFree)
		{
			uI_AddCreditCard.Discount.selectedIndex = 1;
			((GObject)uI_AddCreditCard.Price1st).text = $"{Convert.ToInt32(priceItemId.Value)}";
			((GObject)uI_AddCreditCard.Price2nd).text = $"{Convert.ToInt32(dictionary2.Values.First())}";
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key2;
			uI_AddCreditCard.originalCurrencyIcon.url = "ui://PublicResources/" + key2;
		}
		else if (Mathf.Abs(storeItem_Ex.Discount - 1f) > float.Epsilon && storeItem_Ex.Discount > float.Epsilon)
		{
			uI_AddCreditCard.Discount.selectedIndex = 1;
			((GObject)uI_AddCreditCard.Price1st).text = $"{Convert.ToInt32(dictionary.Values.First())}";
			((GObject)uI_AddCreditCard.Price2nd).text = $"{Convert.ToInt32(dictionary2.Values.First())}";
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key2;
			uI_AddCreditCard.originalCurrencyIcon.url = "ui://PublicResources/" + key2;
		}
		else
		{
			uI_AddCreditCard.Discount.selectedIndex = 0;
			((GObject)uI_AddCreditCard.Price1st).text = $"{Convert.ToInt32(dictionary.Values.First())}";
			uI_AddCreditCard.currentCurrencyIcon.url = "ui://PublicResources/" + key2;
		}
		uI_AddCreditCard.SetControllerPageText();
		UiHelper.SetStoreItemDiscount(storeItem_Ex, uI_AddCreditCard.Discount_2, ribbonVisible: false);
		if (flag)
		{
			((GObject)uI_AddCreditCard).onClick.Set(new EventCallback1(OnClickShowGiftBag));
		}
	}

	private void RenderCurrency()
	{
		string icon = UiHelper.GetIcon(FreeCurrency);
		string icon2 = UiHelper.GetIcon(PaidCurrency);
		FreeCurrencyBtn.icon.url = "ui://PublicResources/" + icon;
		int stock = GameManagers.Instance.StockController.GetStock(FreeCurrency);
		((GObject)FreeCurrencyBtn.num).text = stock.ToString();
		((GObject)FreeCurrencyBtn.num).data = stock;
		((GObject)FreeCurrencyBtn.addButton).visible = false;
		PaidCurrencyBtn.icon.url = "ui://PublicResources/" + icon2;
		int stock2 = GameManagers.Instance.StockController.GetStock(PaidCurrency);
		((GObject)PaidCurrencyBtn.num).text = stock2.ToString();
		((GObject)PaidCurrencyBtn.num).data = stock2;
	}

	private void RefreshScrollDownVisible()
	{
		GList val = ((Type.selectedIndex == 0) ? FreeCardList : PaidCardList);
		((GObject)scrollDown).visible = ((GComponent)val).scrollPane.percY <= 0.98f;
	}

	public void UpdateCurrency(UI_currencyBtn CurrencyComponent, string Currency_ItemId)
	{
		int stock = GameManagers.Instance.StockController.GetStock(Currency_ItemId);
		((GObject)CurrencyComponent.num).text = GameManagers.Instance.StockController.GetStock(Currency_ItemId).ToString();
		int num = ((((GObject)CurrencyComponent.num).data != null) ? ((int)((GObject)CurrencyComponent.num).data) : stock);
		if (num != stock && stock > num)
		{
			int num2 = stock - num;
			if (NumFloating == null)
			{
				NumFloating = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			}
			if (!((GObject)NumFloating).onStage)
			{
				FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloating, (GComponent)(object)CurrencyComponent, stock - num);
			}
			else
			{
				((GObject)NumFloating.Title).text = $"+{(int)((GObject)NumFloating.Title).data + num2}";
				((GObject)NumFloating.Title).data = (int)((GObject)NumFloating.Title).data + num2;
			}
		}
		((GObject)CurrencyComponent.num).data = stock;
	}

	private void UpdateNotice()
	{
		((GObject)FreeTab.RedDot).visible = Singleton<GvG3StoreManager>.Instance.HasSoulKeyStoreNotice_Free;
		((GObject)PaidTab.RedDot).visible = Singleton<GvG3StoreManager>.Instance.HasSoulKeyStoreNotice_Paid;
	}

	private void OnChangeSoulKeyStoreNotice()
	{
		UpdateNotice();
	}

	private void OnSwitchTab(EventContext context)
	{
		UpdateMainPanel();
		RefreshScrollDownVisible();
	}

	private void CurrencyBtnEvent()
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
				{ "Parent", this },
				{ "TabName", "军团" }
			});
		}
		else
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	private void OnClickShowGiftBag(EventContext context)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		string empty = string.Empty;
		empty = ((Type.selectedIndex != 0) ? PaidCurrency : FreeCurrency);
		object data = ((GObject)context.sender).data;
		GvG3StoreManager.StoreItem_Ex storeItem_Ex = (GvG3StoreManager.StoreItem_Ex)data;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_TakeItems.Name, new Dictionary<string, object>
		{
			{
				"Name",
				storeItem_Ex.Name ?? ""
			},
			{ "CanBuy", true },
			{ "GiftBag", storeItem_Ex },
			{ "Parent", this },
			{ "UseCurrency", empty }
		});
	}

	private void OnOrderShipSuccess(List<Bonus> result, List<Bonus> bonuses)
	{
		UpdateMainPanel();
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		if (itemId == FreeCurrency)
		{
			UpdateCurrency(FreeCurrencyBtn, itemId);
			FGUIManager.Instance.AddTextSpecialEffects(FreeCurrencyBtn.textSFXBack, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject obj)
			{
				obj.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
		else if (itemId == PaidCurrency)
		{
			UpdateCurrency(PaidCurrencyBtn, itemId);
			FGUIManager.Instance.AddTextSpecialEffects(PaidCurrencyBtn.textSFXBack, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject obj)
			{
				obj.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
	}

	private bool CanBuySoulKey(GvG3StoreManager.StoreItem_Ex storeItem)
	{
		string key = storeItem.Content.First().Key;
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(key);
		int stock = GameManagers.Instance.StockController.GetStock(key);
		SoulKeyItemEffect soulKeyItemEffect = JsonHelper.ToObject<SoulKeyItemEffect>(gDEItemData.Effect);
		int soldierPotentialLevel = GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(soulKeyItemEffect.SoldierId);
		bool flag = soldierPotentialLevel >= soulKeyItemEffect.PotentialLevel || stock > 0;
		return !flag;
	}

	private void GiftBagSort(List<GvG3StoreManager.StoreItem_Ex> storeItems)
	{
		List<GvG3StoreManager.StoreItem_Ex> list = new List<GvG3StoreManager.StoreItem_Ex>();
		list.AddRange(storeItems);
		List<GvG3StoreManager.StoreItem_Ex> list2 = new List<GvG3StoreManager.StoreItem_Ex>();
		for (int num = list.Count - 1; num >= 0; num--)
		{
			GvG3StoreManager.StoreItem_Ex storeItem_Ex = list[num];
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem_Ex.StoreItemId);
			if ((storeItem_Ex.PurchaseLimitPeriod != PurchaseLimitType.NoLimit && storeItem_Ex.PurchaseLimit - purchaseCntAtLimitPeriod == 0) || !CanBuySoulKey(storeItem_Ex))
			{
				list2.Add(storeItem_Ex);
				list.RemoveAt(num);
			}
		}
		storeItems.Clear();
		storeItems.AddRange(list);
		storeItems.AddRange(list2);
	}

	public void InitMask()
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		Object obj = Resources.Load("Items/LegionPanelSpritMask");
		GameObject val = (GameObject)(object)((obj is GameObject) ? obj : null);
		val = Object.Instantiate<GameObject>(val);
		val.transform.parent = ((GObject)this).displayObject.gameObject.transform;
		val.transform.localScale = new Vector3(584.61f, 225f, 108f);
		val.transform.localPosition = new Vector3(774f, -593.3f, 0f);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	public void BeforeDestroy()
	{
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	public void Destroy()
	{
	}
}
