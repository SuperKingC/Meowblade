using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.Common.Services;
using UI.LegendItemInfo;

namespace UI.LegendItemCultivation;

public class UI_main_LegendItemSelect : GComponent, IUiController
{
	public Controller State;

	public GLoader background;

	public GGraph endChooseClick;

	public GImage chooseListBack;

	public GList LegendItemList;

	public GTextField n4;

	public const string URL = "ui://b9wlonaqsel001";

	public static string Name = "UI_main_LegendItemSelect";

	private string _filterSameNameItemId;

	private long _currentInstanceId = -1L;

	private int _currentSlotIndex = -1;

	private HashSet<string> _excludeMainAttrKeys;

	public readonly List<LegendItemUi> LegendItems = new List<LegendItemUi>();

	public const string CurrentInstanceIdKey = "CurrentInstanceId";

	public const string CurrentSlotIndexKey = "CurrentSlotIndex";

	public const string FilterSameNameItemIdKey = "FilterSameNameItemId";

	public const string ExcludeAttrTypesKey = "ExcludeAttrTypes";

	public static string GetURL()
	{
		return "ui://b9wlonaqsel001";
	}

	public static UI_main_LegendItemSelect CreateInstance()
	{
		return (UI_main_LegendItemSelect)(object)UIPackage.CreateObject("LegendItemCultivation", "main_LegendItemSelect");
	}

	public static UI_main_LegendItemSelect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_LegendItemSelect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqsel001", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		background = (GLoader)((GComponent)this).GetChild("background");
		endChooseClick = (GGraph)((GComponent)this).GetChild("endChooseClick");
		chooseListBack = (GImage)((GComponent)this).GetChild("chooseListBack");
		LegendItemList = (GList)((GComponent)this).GetChild("LegendItemList");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://b9wlonaqsel001".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		SharedMessenger.RemoveListener("LEGEND_ITEM_LOCK_STATE_CHANGED", OnLegendItemLockStateChanged);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)endChooseClick).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		_filterSameNameItemId = (parameters.TryGetValue("FilterSameNameItemId", out var value) ? ((string)value) : null);
		_currentInstanceId = (parameters.TryGetValue("CurrentInstanceId", out var value2) ? ((long)value2) : (-1));
		_currentSlotIndex = (parameters.TryGetValue("CurrentSlotIndex", out var value3) ? ((int)value3) : (-1));
		_excludeMainAttrKeys = (parameters.TryGetValue("ExcludeAttrTypes", out var value4) ? ((HashSet<string>)value4) : null);
		LegendItemFilter();
		RenderAllItems();
		SharedMessenger.AddListener("LEGEND_ITEM_LOCK_STATE_CHANGED", OnLegendItemLockStateChanged);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)endChooseClick).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)endChooseClick).onClick.Remove(new EventCallback0(End));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void LegendItemFilter()
	{
		LegendItems.Clear();
		if (string.IsNullOrEmpty(_filterSameNameItemId))
		{
			return;
		}
		List<LegendItemUi> legendItems = LegendItemsHelper.LegendItems;
		if (legendItems != null && legendItems.Count != 0)
		{
			List<LegendItemUi> list = legendItems.Where((LegendItemUi item) => item.InstanceId != _currentInstanceId && item.LegendItemData != null && item.LegendItemData.Data.Name == _filterSameNameItemId && item.LegendItemData.Data.Rarity > 4).ToList();
			list.Sort(LegendItemsHelper.SortLegendItemDataMaxToMin);
			LegendItems.AddRange(list);
		}
	}

	private void RenderAllItems()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		LegendItemList.itemRenderer = new ListItemRenderer(RenderLegendItem);
		LegendItemList.numItems = LegendItems.Count;
		State.selectedIndex = ((LegendItems.Count <= 0) ? 1 : 0);
	}

	private void RenderLegendItem(int index, GObject obj)
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		if (obj is UI_com_SelectForgeLegendItem uI_com_SelectForgeLegendItem)
		{
			LegendItemUi legendItemUi = LegendItems[index];
			bool flag = LegendItemsHelper.EquippedLegendItems != null && LegendItemsHelper.EquippedLegendItems.ContainsKey(legendItemUi.InstanceId.ToString());
			bool flag2 = LegendItemsHelper.LegendItemsEquiped(legendItemUi.InstanceId);
			bool locked = legendItemUi.LegendItemData.Locked;
			bool flag3 = IsMainAttrConflict(legendItemUi);
			UiHelper.RenderLegendItem(uI_com_SelectForgeLegendItem.LegendItem, legendItemUi, UiHelper.TextColorType.Dark, null, -1, flag || flag2 || flag3);
			uI_com_SelectForgeLegendItem.SelectState.selectedIndex = 0;
			uI_com_SelectForgeLegendItem.LockState.selectedIndex = (locked ? 1 : 0);
			((GObject)uI_com_SelectForgeLegendItem).data = index;
			((GObject)uI_com_SelectForgeLegendItem).onClick.Set(new EventCallback1(SelectLegendItem));
		}
	}

	private bool IsMainAttrConflict(LegendItemUi candidate)
	{
		if (_excludeMainAttrKeys == null || _excludeMainAttrKeys.Count == 0)
		{
			return false;
		}
		if (candidate?.LegendItemData?.MainEntries == null)
		{
			return false;
		}
		UI_Replace.EnsurePayloadCaches();
		foreach (ItemEntry mainEntry in candidate.LegendItemData.MainEntries)
		{
			if (mainEntry.Attributes == null)
			{
				continue;
			}
			foreach (ItemEntryData attribute in mainEntry.Attributes)
			{
				if (string.IsNullOrEmpty(attribute.Key) || !_excludeMainAttrKeys.Contains(attribute.Key))
				{
					continue;
				}
				return true;
			}
		}
		return false;
	}

	private void SelectLegendItem(EventContext context)
	{
		UI_com_SelectForgeLegendItem uI_com_SelectForgeLegendItem = (UI_com_SelectForgeLegendItem)(object)context.sender;
		int index = (int)((GObject)uI_com_SelectForgeLegendItem).data;
		LegendItemUi legendItemUi = LegendItems[index];
		bool flag = LegendItemsHelper.EquippedLegendItems != null && LegendItemsHelper.EquippedLegendItems.ContainsKey(legendItemUi.InstanceId.ToString());
		bool flag2 = LegendItemsHelper.LegendItemsEquiped(legendItemUi.InstanceId);
		if (flag || flag2)
		{
			"SwapLegendItemTip6".ToLanguage().ToTip();
			return;
		}
		if (IsMainAttrConflict(legendItemUi))
		{
			"SwapLegendItemTip7".ToLanguage().ToTip();
			return;
		}
		long selectedInstanceId = legendItemUi.InstanceId;
		int slotIndex = _currentSlotIndex;
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog2.Name, new Dictionary<string, object>
		{
			{ "LegendItem", legendItemUi },
			{
				"Callback",
				new Action(Action)
			}
		});
		void Action()
		{
			SharedMessenger.Broadcast("LEGEND_ITEM_SWAP_SELECT", new SwapSelectLegendItem
			{
				InstanceId = selectedInstanceId,
				Slot = slotIndex
			});
			End();
		}
	}

	private void OnLegendItemLockStateChanged()
	{
		LegendItemFilter();
		RenderAllItems();
	}
}
