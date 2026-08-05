using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Sources.Enums;
using UI.MonthCard;
using UI.SpecialActivity;
using UI.Tips;

namespace UI.WeekActivity;

public class UI_popup_weekGiftPackPanel : GComponent, IUiController
{
	public GGraph mask;

	public UI_com_giftContent Content;

	public Transition t0;

	public const string URL = "ui://jl0c82y5fmskd";

	public static string Name = "UI_popup_weekGiftPackPanel";

	private GetWeeklyActivityResponse _info;

	private List<SpinWeekActivityPayload.SpinWeekStoreItem> _storeItems;

	public static string GetURL()
	{
		return "ui://jl0c82y5fmskd";
	}

	public static UI_popup_weekGiftPackPanel CreateInstance()
	{
		return (UI_popup_weekGiftPackPanel)(object)UIPackage.CreateObject("WeekActivity", "popup_weekGiftPackPanel");
	}

	public static UI_popup_weekGiftPackPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_popup_weekGiftPackPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5fmskd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Content = (UI_com_giftContent)(object)((GComponent)this).GetChild("Content");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)mask).onClick.Set(new EventCallback0(End));
		((GObject)Content.backBtn).onClick.Set(new EventCallback0(End));
		GameManagers.Instance.Messenger.AddListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)mask).onClick.Clear();
		((GObject)Content.backBtn).onClick.Clear();
		GameManagers.Instance.Messenger.RemoveListener<List<Bonus>, List<Bonus>>("ORDER_SHIP_SUCCESS", OrderShipSuccessEvent);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		_info = ActivityManager.SpinWeekActivity;
		_storeItems = _info.GetDisplayStoreItems();
		Content.cardList.itemRenderer = new ListItemRenderer(RenderCardListItem);
		Refresh();
	}

	public void OnShow()
	{
	}

	private void Refresh()
	{
		_storeItems.Sort(delegate(SpinWeekActivityPayload.SpinWeekStoreItem a, SpinWeekActivityPayload.SpinWeekStoreItem b)
		{
			bool flag = IsSoldOut(a);
			bool flag2 = IsSoldOut(b);
			return (flag != flag2) ? (flag ? 1 : (-1)) : (a.Index - b.Index);
		});
		Content.cardList.numItems = _storeItems.Count;
		static bool IsSoldOut(SpinWeekActivityPayload.SpinWeekStoreItem item)
		{
			return item.StoreItem.PurchaseLimit > 0 && item.StoreItem.PurchaseLimit - GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(item.StoreItem.StoreItemId) <= 0;
		}
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private void RenderCardListItem(int index, GObject obj)
	{
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected O, but got Unknown
		UI_com_giftPackItem uI_com_giftPackItem = (UI_com_giftPackItem)(object)obj;
		StoreItem storeItem = (StoreItem)(((GObject)uI_com_giftPackItem).data = _storeItems[index].StoreItem);
		if (storeItem.PurchaseLimitPeriod != PurchaseLimitType.NoLimit)
		{
			string goodsPurchaseLimitTitle = FGUIManager.Instance.GetGoodsPurchaseLimitTitle(storeItem.PurchaseLimitPeriod);
			string desc = LanguagesManager.GetDesc("CsharpCodeZhTcText236");
			uI_com_giftPackItem.RewardController.selectedIndex = 1;
			int purchaseCntAtLimitPeriod = GameManagers.Instance.StoreManager.GetPurchaseCntAtLimitPeriod(storeItem.StoreItemId);
			int num = storeItem.PurchaseLimit - purchaseCntAtLimitPeriod;
			((GObject)uI_com_giftPackItem.reward).text = $"{goodsPurchaseLimitTitle} {num}/{storeItem.PurchaseLimit} {desc}";
			if (num <= 0)
			{
				uI_com_giftPackItem.RewardController.selectedIndex = 2;
			}
			else
			{
				uI_com_giftPackItem.RewardController.selectedIndex = 1;
			}
		}
		else
		{
			uI_com_giftPackItem.RewardController.selectedIndex = 0;
		}
		List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
		list.AddRange(storeItem.Content);
		int limitIndex = uI_com_giftPackItem.RewardController.selectedIndex;
		uI_com_giftPackItem.giftList.itemRenderer = (ListItemRenderer)delegate(int i, GObject item)
		{
			UI_com_spinResultIcon uI_com_spinResultIcon = (UI_com_spinResultIcon)(object)item;
			KeyValuePair<string, int> keyValuePair = list[i];
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(keyValuePair.Key);
			uI_com_spinResultIcon.Type.SetSelectedIndex(0);
			uI_com_spinResultIcon.FrameType.SetSelectedIndex(2);
			FGUIManager.Instance.SetItemIconAndFrame(uI_com_spinResultIcon.rewardIcon, keyValuePair.Key);
			uI_com_spinResultIcon.rewardIcon.InitMaterialIntroductionBtn(keyValuePair.Key);
			((GObject)uI_com_spinResultIcon.Num).text = keyValuePair.Value.ToString();
			((GObject)uI_com_spinResultIcon.itemName).text = gDEItemData.Name;
			uI_com_spinResultIcon.RewardController.SetSelectedIndex(limitIndex);
		};
		uI_com_giftPackItem.giftList.numItems = list.Count;
		KeyValuePair<string, float> availablePriceItemId = UI_SpecialActivityPanel.GetAvailablePriceItemId(storeItem);
		Dictionary<string, float> dictionary = storeItem.OriginPrice.First();
		string key = availablePriceItemId.Key;
		string text = $"{Convert.ToInt32(dictionary.Values.First())}";
		string text2 = $"{Convert.ToInt32(availablePriceItemId.Value)}";
		bool flag = key == "RMB";
		bool flag2 = true;
		ProductLocalInfo value = null;
		bool flag3 = HotUpdateProcess.Instance.IsRegionOutCN && flag;
		if (flag3)
		{
			((GObject)uI_com_giftPackItem.currentCurrencyIcon).visible = false;
			if (!string.IsNullOrEmpty(storeItem.ReferenceId) && PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value))
			{
				if (value.Price > 0f)
				{
					text2 = value.FormattedPrice;
					text = $"{value.CurrencySymbol}{value.Price / storeItem.InternationalDiscount:F2}";
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
				if (string.IsNullOrEmpty(storeItem.ReferenceId) && availablePriceItemId.Value <= 0f)
				{
					text2 = LanguagesManager.GetDesc("CsharpCodeTextPriceFree");
				}
			}
			text2 = UI_MonthCardPanel.StripZeros(text2);
		}
		else
		{
			((GObject)uI_com_giftPackItem.currentCurrencyIcon).visible = true;
		}
		uI_com_giftPackItem.region.SetSelectedIndex(flag3 ? 1 : 0);
		((GObject)uI_com_giftPackItem.Price1st).text = text2;
		if (key == "MTG")
		{
			uI_com_giftPackItem.CurrencyType.SetSelectedIndex(1);
		}
		else
		{
			uI_com_giftPackItem.currentCurrencyIcon.url = "ui://PublicResources/" + key;
		}
		((GObject)uI_com_giftPackItem.Price1stSea).text = text2;
		((GObject)uI_com_giftPackItem).onClick.Set(new EventCallback1(ShowGiftBag));
	}

	private void ShowGiftBag(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		StoreItem storeItem = (StoreItem)((GObject)context.sender).data;
		UI_com_giftPackItem uI_com_giftPackItem = (UI_com_giftPackItem)(object)context.sender;
		if (uI_com_giftPackItem.RewardController.selectedIndex == 2)
		{
			return;
		}
		StoreItem storeItem2 = storeItem;
		Dictionary<string, float> dictionary = null;
		bool flag = false;
		foreach (Dictionary<string, float> item in storeItem2.Price)
		{
			string text = item.Keys.First();
			if (text == "RMB")
			{
				flag = true;
			}
			if (text == "MTG" || text == "Gem")
			{
				dictionary = item;
			}
		}
		if (!flag && dictionary != null)
		{
			KeyValuePair<string, float> keyValuePair = dictionary.First();
			float num = GameManagers.Instance.StockController.GetStock(keyValuePair.Key);
			if (keyValuePair.Value > num)
			{
				string.Format(LanguagesManager.GetDesc("NotEnoughCurrencyTip"), Item.Name(GameManagers.Instance, keyValuePair.Key)).ToTip();
				return;
			}
		}
		ProductLocalInfo value = null;
		if (PurchaseManager.Instance.ProductLocalInfoDictionary != null && !string.IsNullOrEmpty(storeItem.ReferenceId))
		{
			PurchaseManager.Instance.ProductLocalInfoDictionary.TryGetValue(storeItem.ReferenceId, out value);
		}
		PurchaseManager.Instance.InvokePurchase(storeItem, value, 1, (Action)null, doubleCheck: true);
	}

	private void OrderShipSuccessEvent(List<Bonus> result, List<Bonus> bonuses)
	{
		Refresh();
		GameManagers.Instance.Messenger.Broadcast("SPIN_WEEK_ACTIVITY_PROGRESS_CHANGE", _info);
	}

	private static void End()
	{
		UnityUiService.Instance.ClosePanel(Name);
	}
}
