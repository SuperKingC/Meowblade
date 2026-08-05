using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.LegendItemBlueprintTemplate;

namespace UI.GVGStore;

public class UI_com_ShenJiStore : GComponent
{
	private class StoreItemInput
	{
		public string ItemId;

		public int Type;
	}

	private class SelectedStoreItemRecord
	{
		public string PoolTabKey { get; set; }

		public string FormulaId { get; set; }
	}

	public UI_dec_light01 n16;

	public GImage n11;

	public GImage n12;

	public GImage n13;

	public UI_com_ShenJiItemDetail mergeCell;

	public GList itemList;

	public GList Tabs;

	public GTextField TotalRefreshCount;

	public GTextField n8;

	public GImage n14;

	public GImage n15;

	public GImage n18;

	public GImage n17;

	public Transition t0;

	public Transition t1;

	public Transition t2;

	public const string URL = "ui://fvc33k3gllla34";

	public static string Name = "UI_com_ShenJiStore";

	private readonly ArchiveExtension_Formulas.ConfirmBuyStoreItem _selectedStoreItem = new ArchiveExtension_Formulas.ConfirmBuyStoreItem();

	private Dictionary<string, List<GvGStoreGuaranteedItem>> _storeItemsPool = new Dictionary<string, List<GvGStoreGuaranteedItem>>();

	private const string _SELECTED_STORE_ITEM_RECORD_KEY = "SelectedStoreItemRecord";

	private SelectedStoreItemRecord _selectedStoreItemRecord;

	private EventCallback0 _updateTicketCount;

	private List<string> TabKeys => _storeItemsPool.Keys.ToList();

	private string CurCheckTabKey => (Tabs.selectedIndex < 0) ? TabKeys[0] : TabKeys[Tabs.selectedIndex];

	public static string GetURL()
	{
		return "ui://fvc33k3gllla34";
	}

	public static UI_com_ShenJiStore CreateInstance()
	{
		return (UI_com_ShenJiStore)(object)UIPackage.CreateObject("GVGStore", "com_ShenJiStore");
	}

	public static UI_com_ShenJiStore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShenJiStore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gllla34", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n16 = (UI_dec_light01)(object)((GComponent)this).GetChild("n16");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		mergeCell = (UI_com_ShenJiItemDetail)(object)((GComponent)this).GetChild("mergeCell");
		itemList = (GList)((GComponent)this).GetChild("itemList");
		Tabs = (GList)((GComponent)this).GetChild("Tabs");
		TotalRefreshCount = (GTextField)((GComponent)this).GetChild("TotalRefreshCount");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id = "ui://fvc33k3gllla34".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id);
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
		t2 = ((GComponent)this).GetTransition("t2");
	}

	public void Init(Dictionary<string, List<GvGStoreGuaranteedItem>> itemsPool, EventCallback0 updateTicket)
	{
		_storeItemsPool = itemsPool;
		_updateTicketCount = updateTicket;
	}

	public void Display(int count)
	{
		RenderTabs();
		LoadSelectedStoreItem();
		RefreshTotalCount(count);
		UpdateTicketCount();
	}

	public void BeforeDestroy()
	{
		_storeItemsPool = null;
		_selectedStoreItemRecord = null;
		_updateTicketCount = null;
	}

	public void RegisterUiEventListeners()
	{
		RegisterListItemRender();
		RegisterBtnClickEvent();
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)mergeCell.Buy).onClick.Clear();
		((GObject)mergeCell.StoreItemIcon).onClick.Clear();
		Tabs.onClickItem.Clear();
		itemList.onClickItem.Clear();
	}

	public void UpdateSelectedGuaranteedStoreItem()
	{
		if (mergeCell.State.selectedIndex == 1)
		{
			RenderSelectedFormula();
		}
	}

	private void RegisterBtnClickEvent()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		((GObject)mergeCell.Buy).onClick.Set(new EventCallback0(OnPurchaseClick));
		((GObject)mergeCell.StoreItemIcon).onClick.Set(new EventCallback0(CheckFormulaOutput));
		Tabs.onClickItem.Set(new EventCallback0(OnTabClick));
		itemList.onClickItem.Set(new EventCallback1(OnStoreItemSelect));
	}

	private void RegisterListItemRender()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		itemList.itemRenderer = new ListItemRenderer(RenderStoreItem);
		Tabs.itemRenderer = new ListItemRenderer(RenderTab);
	}

	private void RefreshTotalCount(int count)
	{
		((GObject)TotalRefreshCount).text = $"{count / 3}".ToString();
	}

	private void LoadSelectedStoreItem()
	{
		string text = GameLocalDataManager.GetString("SelectedStoreItemRecord");
		_selectedStoreItemRecord = ((!string.IsNullOrEmpty(text)) ? JsonHelper.ToObject<SelectedStoreItemRecord>(text) : null);
		UpdateSelectedFormula(_selectedStoreItemRecord?.FormulaId);
		RenderDefaultPool(_selectedStoreItemRecord);
		RefreshSelectedUi(_selectedStoreItem?.Formula?.FormulaId);
	}

	private void ClearSelectedFormula()
	{
		_selectedStoreItem.Formula = null;
		_selectedStoreItem.ItemId = string.Empty;
		_selectedStoreItem.ItemNum = 0;
	}

	private void SaveSelectedStoreItem()
	{
		if (_selectedStoreItemRecord == null)
		{
			_selectedStoreItemRecord = new SelectedStoreItemRecord();
		}
		_selectedStoreItemRecord.FormulaId = _selectedStoreItem.Formula?.FormulaId;
		_selectedStoreItemRecord.PoolTabKey = CurCheckTabKey;
		GameLocalDataManager.SetString("SelectedStoreItemRecord", JsonHelper.ToJson(_selectedStoreItemRecord));
	}

	private void RefreshSelectedUi(string formulaId)
	{
		if (string.IsNullOrEmpty(formulaId))
		{
			RenderEmptyStoreItemCard();
		}
		else
		{
			RenderSelectedFormula();
		}
	}

	private void RenderEmptyStoreItemCard()
	{
		mergeCell.CanBuy.SetSelectedIndex(0);
		mergeCell.State.SetSelectedIndex(0);
	}

	private void RenderSelectedFormula()
	{
		mergeCell.State.SetSelectedIndex(1);
		RenderStoreItemTicketCost(_selectedStoreItem.Formula);
		RenderStoreItemStoneCost(_selectedStoreItem.Formula);
		FGUIManager.Instance.SetItemIconAndFrame(mergeCell.StoreItemIcon, _selectedStoreItem.ItemId, null, "", frameVisible: false);
		string input = Item.Name(GameManagers.Instance, _selectedStoreItem.ItemId);
		((GObject)mergeCell.ItemName).text = Regex.Replace(input, "\\r?\\n", string.Empty);
		((GObject)mergeCell.ItemNum).text = _selectedStoreItem.ItemNum.ToString();
		mergeCell.GrandPrizeSfxWrapper.PlayIdleParticleEffects();
		mergeCell.CanBuy.SetSelectedIndex(_selectedStoreItem.Formula.CanUse() ? 1 : 0);
	}

	private void RenderStoreItemTicketCost(Formula formula)
	{
		FormulaExtensions.FormulaItemKv firstInputItem = formula.GetFirstInputItem();
		((GObject)mergeCell.couponRequire).text = firstInputItem.Count.ToString();
		FGUIManager.Instance.SetItemIconAndFrame(mergeCell.TicketIcon, firstInputItem.ItemId, null, "", frameVisible: false);
		int stock = GameManagers.Instance.StockController.GetStock(firstInputItem.ItemId);
		mergeCell.TicketIsEnough.SetSelectedIndex((stock >= firstInputItem.Count) ? 1 : 0);
	}

	private void RenderStoreItemStoneCost(Formula formula)
	{
		List<string> inputList = formula.GetInputList();
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		List<StoreItemInput> list = new List<StoreItemInput>();
		foreach (string item in inputList)
		{
			if (!dictionary.ContainsKey(item))
			{
				dictionary.Add(item, GameManagers.Instance.StockController.GetStock(item));
			}
		}
		foreach (string item2 in inputList)
		{
			if (Item.ItemType(item2) == 28)
			{
				StoreItemInput storeItemInput = new StoreItemInput
				{
					ItemId = item2
				};
				if (dictionary[storeItemInput.ItemId] <= 0)
				{
					storeItemInput.Type = 3;
				}
				else
				{
					storeItemInput.Type = 0;
					dictionary[storeItemInput.ItemId]--;
				}
				list.Add(storeItemInput);
			}
		}
		mergeCell.Materials.RemoveChildrenToPool();
		foreach (StoreItemInput item3 in list)
		{
			if (mergeCell.Materials.AddItemFromPool() is UI_com_StoreroomItem btn)
			{
				RenderStoreItemInputItem(btn, item3);
			}
		}
	}

	private static void RenderStoreItemInputItem(UI_com_StoreroomItem btn, StoreItemInput inputItem)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		FGUIManager.Instance.SetItemIconAndFrame(btn.Icon, inputItem.ItemId, null, "", frameVisible: false);
		btn.Type.selectedIndex = inputItem.Type;
		btn.RenderRarity(inputItem.ItemId);
		((GObject)btn).onClick.Set((EventCallback0)delegate
		{
			inputItem.ItemId.DisplayItemTip();
		});
	}

	private void CheckFormulaOutput()
	{
		string itemId = _selectedStoreItem.ItemId;
		string text = itemId + "_BlueprintPostScript";
		string text2 = text.ToLanguage();
		if (text2 == text)
		{
			if (!FGUIManager.TryShowOptionalBlueprint(itemId))
			{
				itemId.DisplayItemTip();
			}
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_LegendItemBlueprintTemplatePanel.Name, new Dictionary<string, object> { 
			{
				"Info",
				JsonHelper.ToObject<ArchiveExtension_Formulas.GvGStoreItemInfo>(text2)
			} });
		}
	}

	private void UpdateTicketCount()
	{
		EventCallback0 updateTicketCount = _updateTicketCount;
		if (updateTicketCount != null)
		{
			updateTicketCount.Invoke();
		}
	}

	private void RenderDefaultPool(SelectedStoreItemRecord record)
	{
		string recordTabKey = record?.PoolTabKey;
		Tabs.selectedIndex = ((!string.IsNullOrEmpty(recordTabKey)) ? TabKeys.FindIndex((string tab) => tab == recordTabKey) : 0);
		itemList.numItems = _storeItemsPool[CurCheckTabKey].Count;
		itemList.selectedIndex = _storeItemsPool[CurCheckTabKey].FindIndex((GvGStoreGuaranteedItem f) => f.FormulaId == record?.FormulaId);
	}

	private void RenderTabs()
	{
		Tabs.numItems = TabKeys.Count;
	}

	private void RenderTab(int index, GObject obj)
	{
		if (!(obj is UI_btn_ShenJiPoolTab uI_btn_ShenJiPoolTab))
		{
			throw new NullReferenceException("UI_com_ShenJiStore : UI_btn_ShenJiPoolTab is null");
		}
		string langKey = TabKeys[index];
		uI_btn_ShenJiPoolTab.iconUp.url = "ui://GVGStore/Tab_" + langKey.ToLanguage() + "_Up";
		uI_btn_ShenJiPoolTab.iconDown.url = "ui://GVGStore/Tab_" + langKey.ToLanguage() + "_Down";
	}

	private void OnTabClick()
	{
		itemList.numItems = _storeItemsPool[CurCheckTabKey].Count;
	}

	private void RenderStoreItem(int index, GObject obj)
	{
		if (!(obj is UI_btn_ShenJiItemPreview uI_btn_ShenJiItemPreview))
		{
			throw new NullReferenceException("UI_com_ShenJiStore : UI_com_ShenJiItemPreview is null");
		}
		GvGStoreGuaranteedItem gvGStoreGuaranteedItem = _storeItemsPool[CurCheckTabKey][index];
		bool flag = gvGStoreGuaranteedItem.RemainingBuyCount < 0;
		uI_btn_ShenJiItemPreview.HasPurchaseLimit.SetSelectedIndex((!flag) ? 1 : 0);
		bool flag2 = gvGStoreGuaranteedItem.RemainingBuyCount > 0;
		((GObject)uI_btn_ShenJiItemPreview.RemainingPurchaseLimitCount).text = gvGStoreGuaranteedItem.RemainingBuyCount.ToString();
		bool flag3 = flag2 || flag;
		uI_btn_ShenJiItemPreview.State.SetSelectedIndex((!flag3) ? 1 : 0);
		((GObject)uI_btn_ShenJiItemPreview).touchable = flag3;
		Formula formula = gvGStoreGuaranteedItem.FormulaId.ToFormula();
		FormulaExtensions.FormulaItemKv firstOutputItem = formula.GetFirstOutputItem();
		((GObject)uI_btn_ShenJiItemPreview.itemName).text = Item.Name(GameManagers.Instance, firstOutputItem.ItemId);
		FGUIManager.Instance.SetItemIconAndFrame(uI_btn_ShenJiItemPreview.itemIcon, firstOutputItem.ItemId, null, "", frameVisible: false);
	}

	private void OnStoreItemSelect(EventContext context)
	{
		string formulaId = _storeItemsPool[CurCheckTabKey][itemList.selectedIndex].FormulaId;
		UpdateSelectedFormula(formulaId);
		SaveSelectedStoreItem();
		RefreshSelectedUi(formulaId);
	}

	private void UpdateSelectedFormula(string formulaId)
	{
		if (!string.IsNullOrEmpty(formulaId))
		{
			Formula formula = formulaId.ToFormula();
			KeyValuePair<string, int> keyValuePair = JsonHelper.ToObject<Dictionary<string, int>>(formula.Output).ToList()[0];
			_selectedStoreItem.Formula = formula;
			_selectedStoreItem.ItemId = keyValuePair.Key;
			_selectedStoreItem.ItemNum = keyValuePair.Value;
		}
	}

	private void UpdatePurchasedItem()
	{
		if (itemList.selectedIndex >= 0)
		{
			int selectedIndex = itemList.selectedIndex;
			GObject childAt = ((GComponent)itemList).GetChildAt(selectedIndex);
			RenderStoreItem(selectedIndex, childAt);
			itemList.selectedIndex = -1;
		}
	}

	private void OnPurchaseClick()
	{
		if (_selectedStoreItem.Formula != null)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GVGStoreBuyConfirmPanel.Name, new Dictionary<string, object>
			{
				{ "StoreItem", _selectedStoreItem },
				{
					"OnPurchased",
					OnPurchased()
				}
			});
		}
	}

	private Action OnPurchased()
	{
		return delegate
		{
			ClearSelectedFormula();
			SaveSelectedStoreItem();
			RefreshSelectedUi(string.Empty);
			UpdatePurchasedItem();
			UpdateTicketCount();
		};
	}
}
