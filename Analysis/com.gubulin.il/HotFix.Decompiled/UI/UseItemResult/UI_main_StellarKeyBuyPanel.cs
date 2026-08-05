using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.LegendItemBlueprintTemplate;
using UnityEngine;

namespace UI.UseItemResult;

public class UI_main_StellarKeyBuyPanel : GComponent, IUiController
{
	public class BuyParam
	{
		public Action<int> OnConfirmBuy;

		public string Title;

		public string ItemId;

		public int ItemCount;

		public bool LoadFrame = true;

		public Vector2 IconSize = new Vector2(170f, 178f);

		public int Cost;

		public string Currency;

		public int BoughtCount;

		public int Limit;

		public bool CanSelectCount = true;

		public int MinCount = 1;

		public int MaxCount = 100;
	}

	public Controller Type;

	public Controller HasLimit;

	public Controller CanSelectCount;

	public Controller MoneyEnough;

	public GGraph back;

	public GMovieClip AdvancedBox;

	public GImage nameBack;

	public GTextField Title0;

	public GTextField Title1;

	public GTextField Title2;

	public GTextField BuyLimitTitle;

	public GTextField BuyLimit;

	public GGroup BuyLimitGroup;

	public GTextField n50;

	public GLoader CurrencyIcon;

	public GRichTextField Price;

	public GGroup n53;

	public GLoader ItemIcon;

	public GTextField num;

	public GTextField ItemName;

	public GGroup NotSelectCount;

	public GLoader ItemIcon1;

	public GTextField num1;

	public GTextField ItemName1;

	public GTextField title2nd;

	public GLoader compoundNumBack;

	public GTextField compoundNum;

	public UI_increaseButton increaseBtn;

	public UI_reduceButton reduceBtn;

	public UI_MaxValueBtn MaxValueBtn;

	public GGroup selectCount;

	public GButton ConfirmBuyBtn;

	public Transition OpenChest;

	public Transition CloseChest;

	public const string URL = "ui://800w3r8ra0mrj";

	public static string Name = "UI_main_StellarKeyBuyPanel";

	public const string Param = "Param";

	private UICallbackParam<Action> OnConfirmBuy;

	private Action<int> _onConfirmBuyWithCount;

	private Product Product;

	private int BoughtCount;

	private BuyParam _buyParam;

	private int _currentCount;

	public static string GetURL()
	{
		return "ui://800w3r8ra0mrj";
	}

	public static UI_main_StellarKeyBuyPanel CreateInstance()
	{
		return (UI_main_StellarKeyBuyPanel)(object)UIPackage.CreateObject("UseItemResult", "main_StellarKeyBuyPanel");
	}

	public static UI_main_StellarKeyBuyPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_StellarKeyBuyPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://800w3r8ra0mrj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected O, but got Unknown
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Expected O, but got Unknown
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected O, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected O, but got Unknown
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Expected O, but got Unknown
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Expected O, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected O, but got Unknown
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Expected O, but got Unknown
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		HasLimit = ((GComponent)this).GetController("HasLimit");
		CanSelectCount = ((GComponent)this).GetController("CanSelectCount");
		MoneyEnough = ((GComponent)this).GetController("MoneyEnough");
		back = (GGraph)((GComponent)this).GetChild("back");
		AdvancedBox = (GMovieClip)((GComponent)this).GetChild("AdvancedBox");
		nameBack = (GImage)((GComponent)this).GetChild("nameBack");
		Title0 = (GTextField)((GComponent)this).GetChild("Title0");
		string id = "ui://800w3r8ra0mrj".Replace("ui://", "") + "-" + ((GObject)Title0).id;
		((GObject)Title0).text = LanguagesManager.GetDesc(id);
		Title1 = (GTextField)((GComponent)this).GetChild("Title1");
		string id2 = "ui://800w3r8ra0mrj".Replace("ui://", "") + "-" + ((GObject)Title1).id;
		((GObject)Title1).text = LanguagesManager.GetDesc(id2);
		Title2 = (GTextField)((GComponent)this).GetChild("Title2");
		string id3 = "ui://800w3r8ra0mrj".Replace("ui://", "") + "-" + ((GObject)Title2).id;
		((GObject)Title2).text = LanguagesManager.GetDesc(id3);
		BuyLimitTitle = (GTextField)((GComponent)this).GetChild("BuyLimitTitle");
		string id4 = "ui://800w3r8ra0mrj".Replace("ui://", "") + "-" + ((GObject)BuyLimitTitle).id;
		((GObject)BuyLimitTitle).text = LanguagesManager.GetDesc(id4);
		BuyLimit = (GTextField)((GComponent)this).GetChild("BuyLimit");
		BuyLimitGroup = (GGroup)((GComponent)this).GetChild("BuyLimitGroup");
		n50 = (GTextField)((GComponent)this).GetChild("n50");
		string id5 = "ui://800w3r8ra0mrj".Replace("ui://", "") + "-" + ((GObject)n50).id;
		((GObject)n50).text = LanguagesManager.GetDesc(id5);
		CurrencyIcon = (GLoader)((GComponent)this).GetChild("CurrencyIcon");
		Price = (GRichTextField)((GComponent)this).GetChild("Price");
		n53 = (GGroup)((GComponent)this).GetChild("n53");
		ItemIcon = (GLoader)((GComponent)this).GetChild("ItemIcon");
		num = (GTextField)((GComponent)this).GetChild("num");
		ItemName = (GTextField)((GComponent)this).GetChild("ItemName");
		NotSelectCount = (GGroup)((GComponent)this).GetChild("NotSelectCount");
		ItemIcon1 = (GLoader)((GComponent)this).GetChild("ItemIcon1");
		num1 = (GTextField)((GComponent)this).GetChild("num1");
		ItemName1 = (GTextField)((GComponent)this).GetChild("ItemName1");
		title2nd = (GTextField)((GComponent)this).GetChild("title2nd");
		string id6 = "ui://800w3r8ra0mrj".Replace("ui://", "") + "-" + ((GObject)title2nd).id;
		((GObject)title2nd).text = LanguagesManager.GetDesc(id6);
		compoundNumBack = (GLoader)((GComponent)this).GetChild("compoundNumBack");
		compoundNum = (GTextField)((GComponent)this).GetChild("compoundNum");
		increaseBtn = (UI_increaseButton)(object)((GComponent)this).GetChild("increaseBtn");
		reduceBtn = (UI_reduceButton)(object)((GComponent)this).GetChild("reduceBtn");
		MaxValueBtn = (UI_MaxValueBtn)(object)((GComponent)this).GetChild("MaxValueBtn");
		selectCount = (GGroup)((GComponent)this).GetChild("selectCount");
		ConfirmBuyBtn = (GButton)((GComponent)this).GetChild("ConfirmBuyBtn");
		OpenChest = ((GComponent)this).GetTransition("OpenChest");
		CloseChest = ((GComponent)this).GetTransition("CloseChest");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 998;
		MoneyEnough.SetSelectedIndex(1);
		if (parameters.TryGetValue("Param", out var value))
		{
			BuyParam buyParam = (BuyParam)value;
			_onConfirmBuyWithCount = buyParam.OnConfirmBuy;
			Product = new Product
			{
				Id = buyParam.ItemId,
				Limit = buyParam.Limit,
				Cost = buyParam.Cost,
				Currency = buyParam.Currency
			};
			Type.selectedIndex = 0;
			BoughtCount = buyParam.BoughtCount;
			((GObject)Title0).text = buyParam.Title;
			CanSelectCount.SetSelectedIndex(buyParam.CanSelectCount ? 1 : 0);
			_buyParam = buyParam;
			_currentCount = 1;
		}
		else
		{
			OnConfirmBuy = (parameters.TryGetValue("OnConfirmBuy", out var value2) ? ((UICallbackParam<Action>)value2) : null);
			Product = (parameters.TryGetValue("Product", out var value3) ? ((Product)value3) : null);
			Type.selectedIndex = (parameters.TryGetValue("Type", out var value4) ? ((int)value4) : 0);
			BoughtCount = (parameters.TryGetValue("BoughtCount", out var value5) ? ((int)value5) : 0);
		}
		FGUIManager.Instance.SetItemIconAndFrame(CurrencyIcon, Product.Currency, null, "", frameVisible: false);
		Update();
		RefreshBoughtCount();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		((GObject)back).onClick.Add(new EventCallback0(End));
		((GObject)ConfirmBuyBtn).onClick.Set((EventCallback0)delegate
		{
			OnConfirmBuy?.Callback?.Invoke();
			_onConfirmBuyWithCount?.Invoke(_currentCount);
			End();
		});
		((GObject)reduceBtn).onClick.Set(new EventCallback0(OnClickMinusCount));
		((GObject)increaseBtn).onClick.Set(new EventCallback0(OnClickAddCount));
		((GObject)MaxValueBtn).onClick.Set(new EventCallback0(OnClickAddMax));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
		((GObject)ConfirmBuyBtn).onClick.Clear();
		((GObject)reduceBtn).onClick.Clear();
		((GObject)increaseBtn).onClick.Clear();
		((GObject)MaxValueBtn).onClick.Clear();
	}

	private void OnClickAddCount()
	{
		if (_buyParam != null && _buyParam.CanSelectCount)
		{
			_currentCount = Mathf.Min(_currentCount + 1, _buyParam.MaxCount);
			RefreshBoughtCount();
		}
	}

	private void OnClickMinusCount()
	{
		if (_buyParam != null && _buyParam.CanSelectCount)
		{
			_currentCount = Mathf.Max(_currentCount - 1, _buyParam.MinCount);
			RefreshBoughtCount();
		}
	}

	private void OnClickAddMax()
	{
		if (_buyParam != null && _buyParam.CanSelectCount)
		{
			_currentCount = _buyParam.MaxCount;
			RefreshBoughtCount();
		}
	}

	private void RefreshBoughtCount()
	{
		if (_buyParam != null)
		{
			((GObject)compoundNum).text = $"{_currentCount}";
			int stock = GameManagers.Instance.StockController.GetStock(_buyParam.Currency);
			int num = _currentCount * _buyParam.Cost;
			bool flag = stock >= num;
			MoneyEnough.SetSelectedIndex(flag ? 1 : 0);
			((GObject)Price).text = $"x{num}";
		}
	}

	private void Update()
	{
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		string itemId = Product.Id;
		GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(itemId);
		((GObject)BuyLimit).text = $"{Product.Limit - BoughtCount}/{Product.Limit}";
		HasLimit.selectedIndex = ((Product.Limit > 0) ? 1 : 0);
		((GObject)ItemName).text = gDEItemData.Name;
		((GObject)ItemName1).text = gDEItemData.Name;
		bool frameVisible = false;
		if (_buyParam != null)
		{
			((GObject)ItemIcon).size = _buyParam.IconSize;
			((GObject)ItemIcon1).size = _buyParam.IconSize;
			((GObject)num).text = _buyParam.ItemCount.ToString();
			((GObject)num1).text = _buyParam.ItemCount.ToString();
			((GObject)num).visible = _buyParam.ItemCount > 0;
			((GObject)num1).visible = _buyParam.ItemCount > 0;
			frameVisible = _buyParam.LoadFrame;
		}
		FGUIManager.Instance.SetItemIconAndFrame(ItemIcon, itemId, null, "", frameVisible);
		FGUIManager.Instance.SetItemIconAndFrame(ItemIcon1, itemId, null, "", frameVisible);
		((GObject)ItemIcon).onClick.Set((EventCallback0)delegate
		{
			OnClickItem(itemId);
		});
		((GObject)ItemIcon1).onClick.Set((EventCallback0)delegate
		{
			OnClickItem(itemId);
		});
		((GObject)Price).text = $"x{Product.Cost}";
	}

	private void OnClickItem(string itemId)
	{
		if (Item.ItemType(itemId) == 27)
		{
			ArchiveExtension_Formulas.GvGStoreItemInfo value = JsonHelper.ToObject<ArchiveExtension_Formulas.GvGStoreItemInfo>(Item.PostScript(itemId));
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemBlueprintTemplatePanel.Name, new Dictionary<string, object> { { "Info", value } });
		}
		else if (!FGUIManager.TryShowOptionalBlueprint(itemId))
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		}
	}

	public void OnShow()
	{
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
