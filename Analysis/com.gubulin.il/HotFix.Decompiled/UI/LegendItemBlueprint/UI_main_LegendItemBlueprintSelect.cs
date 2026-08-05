using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.Managers.LegendItemsManager;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.LegendItemInfo;

namespace UI.LegendItemBlueprint;

public class UI_main_LegendItemBlueprintSelect : GComponent, IUiController
{
	public Controller State;

	public GLoader background;

	public GGraph endChooseClick;

	public GImage chooseListBack;

	public GList LegendItemList;

	public GTextField n6;

	public const string URL = "ui://h09dvkcgpqzh2y";

	public static string Name = "UI_main_LegendItemBlueprintSelect";

	private int ShowLegendItemType;

	private List<string> FilterItemId = new List<string>();

	private int FilterRarity = 0;

	private int CurrentSlotIndex = -1;

	private long CurrentSlotInstanceId = -1L;

	private string CurrentSlotItemId;

	private Dictionary<string, int> SelectedUniversalLegendItems;

	public List<LegendItemUi> LegendItems = new List<LegendItemUi>();

	private UI_main_LegendItemBlueprintForge forgePanel;

	public static string GetURL()
	{
		return "ui://h09dvkcgpqzh2y";
	}

	public static UI_main_LegendItemBlueprintSelect CreateInstance()
	{
		return (UI_main_LegendItemBlueprintSelect)(object)UIPackage.CreateObject("LegendItemBlueprint", "main_LegendItemBlueprintSelect");
	}

	public static UI_main_LegendItemBlueprintSelect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_LegendItemBlueprintSelect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgpqzh2y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://h09dvkcgpqzh2y".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
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
		((GObject)endChooseClick).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		ShowLegendItemType = (parameters.TryGetValue("ShowLegendItemType", out var value) ? ((int)value) : 0);
		FilterItemId = (parameters.TryGetValue("FilterItemId", out var value2) ? (value2 as List<string>) : new List<string>());
		FilterRarity = (parameters.TryGetValue("FilterRarity", out var value3) ? ((int)value3) : 0);
		CurrentSlotIndex = (parameters.TryGetValue("CurrentSlotIndex", out var value4) ? ((int)value4) : (-1));
		CurrentSlotInstanceId = (parameters.TryGetValue("CurrentSlotInstanceId", out var value5) ? ((long)value5) : (-1));
		CurrentSlotItemId = (parameters.TryGetValue("CurrentSlotItemId", out var value6) ? ((string)value6) : null);
		SelectedUniversalLegendItems = (parameters.TryGetValue("SelectedUniversalLegendItems", out var value7) ? ((Dictionary<string, int>)value7) : new Dictionary<string, int>());
		GObject showingUi = GameController.Contexts.Service<IUiService>().GetShowingUi(UI_main_LegendItemBlueprintForge.Name);
		forgePanel = showingUi as UI_main_LegendItemBlueprintForge;
		LegendItemFilter();
		RenderAllItems();
	}

	private void CheckAddUniversalLegendItems()
	{
		if (ShowLegendItemType != 1)
		{
			return;
		}
		foreach (string item2 in ConfigDataManager.ItemsByType[ItemType.UniversalLegendItem])
		{
			int stock = GameManagers.Instance.StockController.GetStock(item2);
			if (stock != 0)
			{
				SelectedUniversalLegendItems.TryGetValue(item2, out var value);
				int num = stock - value;
				if ((!(item2 != CurrentSlotItemId) || num > 0) && Item.Rarity(item2) == FilterRarity)
				{
					LegendItemUi item = new LegendItemUi(item2, num);
					LegendItems.Insert(0, item);
				}
			}
		}
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)endChooseClick).onClick.Add(new EventCallback0(End));
		SharedMessenger.AddListener<ForgeSelectLegendItem>("UPDATE_FORGE_LEGENDITEM", CloseOnSelect);
		SharedMessenger.AddListener("UPDATE_FORGE_SELECT_LEGENDITEM_LIST", UpdateList);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)endChooseClick).onClick.Remove(new EventCallback0(End));
		SharedMessenger.RemoveListener<ForgeSelectLegendItem>("UPDATE_FORGE_LEGENDITEM", CloseOnSelect);
		SharedMessenger.RemoveListener("UPDATE_FORGE_SELECT_LEGENDITEM_LIST", UpdateList);
	}

	private void UpdateList()
	{
		LegendItemFilter();
		RenderAllItems();
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void CloseOnSelect(ForgeSelectLegendItem selectInfo)
	{
		End();
	}

	private void LegendItemFilter()
	{
		List<LegendItemUi> list = ListExtensions.DeepCopy<LegendItemUi>(LegendItemsHelper.GetLegendItemsByRarity());
		LegendItems.Clear();
		if (CurrentSlotInstanceId > -1)
		{
			LegendItemUi item = list.FirstOrDefault((LegendItemUi t) => t.InstanceId == CurrentSlotInstanceId);
			list.Remove(item);
			LegendItems.Add(item);
		}
		List<LegendItemUi> list2 = new List<LegendItemUi>();
		switch (ShowLegendItemType)
		{
		case 0:
			list2 = list.Where((LegendItemUi legendItemUi) => FilterItemId.Contains(legendItemUi.LegendItemData.Data.Key)).ToList();
			break;
		case 1:
			list2 = ((FilterItemId.Count <= 0) ? list.Where((LegendItemUi legendItemUi) => legendItemUi.LegendItemData.Data.Rarity == FilterRarity).ToList() : list.Where((LegendItemUi legendItemUi) => FilterItemId.Contains(legendItemUi.LegendItemData.Data.Key)).ToList());
			break;
		}
		if (ShowLegendItemType == 0)
		{
			list2.Sort(SortMainLegendItem);
		}
		else
		{
			list2.Sort(SortCostLegendItem);
		}
		LegendItems.AddRange(list2);
		CheckAddUniversalLegendItems();
	}

	private void RenderAllItems()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		LegendItemList.SetVirtual();
		LegendItemList.itemProvider = new ListItemProvider(LegendItemProvider);
		LegendItemList.itemRenderer = new ListItemRenderer(LegendItemRenderer);
		LegendItemList.numItems = LegendItems.Count;
		State.selectedIndex = ((LegendItems.Count <= 0) ? 1 : 0);
	}

	private string LegendItemProvider(int index)
	{
		LegendItemUi legendItemUi = LegendItems[index];
		if (string.IsNullOrEmpty(legendItemUi.UniversalLegendItemId))
		{
			return "ui://LegendItemBlueprint/com_SelectForgeLegendItem";
		}
		return "ui://LegendItemBlueprint/com_SelectForgeUniversalLegendItem";
	}

	private void LegendItemRenderer(int index, GObject item)
	{
		LegendItemUi legendItemUi = LegendItems[index];
		if (string.IsNullOrEmpty(legendItemUi.UniversalLegendItemId))
		{
			RenderLegendItem(index, item);
		}
		else
		{
			RenderUniversalLegendItem(index, item);
		}
	}

	private void RenderLegendItem(int index, GObject obj)
	{
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		if (obj is UI_com_SelectForgeLegendItem uI_com_SelectForgeLegendItem)
		{
			uI_com_SelectForgeLegendItem.LockState.selectedIndex = 0;
			uI_com_SelectForgeLegendItem.SelectState.selectedIndex = 0;
			LegendItemUi legendItemUi = LegendItems[index];
			bool showCancelBtn = legendItemUi.InstanceId == CurrentSlotInstanceId;
			uI_com_SelectForgeLegendItem.LegendItem.Level.selectedIndex = legendItemUi.LegendItemData.Data.Rarity - 1;
			((GObject)uI_com_SelectForgeLegendItem.LegendItem.LevelValue).text = legendItemUi.LegendItemData.EnhanceLevel.ToString();
			uI_com_SelectForgeLegendItem.LegendItem.Icon.LoadArmsIcon(legendItemUi.LegendItemData.Data.Icon);
			((GObject)uI_com_SelectForgeLegendItem.LegendItem.name).text = legendItemUi.LegendItemData.Data.Name;
			uI_com_SelectForgeLegendItem.LegendItem.Type.selectedIndex = 1;
			((GObject)uI_com_SelectForgeLegendItem.LegendItem.SoldierIcon).visible = false;
			bool flag = forgePanel != null && forgePanel.ItemInCostList(legendItemUi.InstanceId);
			bool flag2 = forgePanel != null && forgePanel.MainInstance.LegendItem != null && forgePanel.MainInstance.LegendItem.InstanceId == legendItemUi.InstanceId;
			uI_com_SelectForgeLegendItem.SelectState.selectedIndex = ((flag || flag2) ? 1 : 0);
			if (ShowLegendItemType == 0)
			{
				SetMainLegendItemState(uI_com_SelectForgeLegendItem, new LegendItemsHelper.ConfirmDialogInfo
				{
					ShowCancelBtn = flag2,
					CanNotChangeLock = flag
				}, legendItemUi);
			}
			else if (ShowLegendItemType == 1)
			{
				SetLegendItemState(uI_com_SelectForgeLegendItem, new LegendItemsHelper.ConfirmDialogInfo
				{
					ShowCancelBtn = showCancelBtn,
					CanNotChangeLock = flag,
					TipType = new List<LegendItemsHelper.CanNotSelectTipType>()
				}, legendItemUi, flag, flag2);
			}
			((GObject)uI_com_SelectForgeLegendItem).data = index;
			((GObject)uI_com_SelectForgeLegendItem).onClick.Set(new EventCallback1(SelectLegendItem));
		}
	}

	private void RenderUniversalLegendItem(int index, GObject obj)
	{
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		if (obj is UI_com_SelectForgeUniversalLegendItem uI_com_SelectForgeUniversalLegendItem)
		{
			LegendItemUi legendItemUi = LegendItems[index];
			string universalLegendItemId = legendItemUi.UniversalLegendItemId;
			bool flag = universalLegendItemId == CurrentSlotItemId;
			uI_com_SelectForgeUniversalLegendItem.SelectState.selectedIndex = (flag ? 1 : 0);
			uI_com_SelectForgeUniversalLegendItem.ShowCount.selectedIndex = (flag ? 1 : 0);
			uI_com_SelectForgeUniversalLegendItem.ShowName.selectedIndex = 0;
			uI_com_SelectForgeUniversalLegendItem.Level.selectedIndex = Item.Rarity(universalLegendItemId);
			uI_com_SelectForgeUniversalLegendItem.Icon.url = UiHelper.GetIcon(universalLegendItemId).ToPublicResourceIcon();
			((GObject)uI_com_SelectForgeUniversalLegendItem.ItemName).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, universalLegendItemId);
			((GObject)uI_com_SelectForgeUniversalLegendItem.Count).text = $"{legendItemUi.UniversalLegendItemCount}";
			((GObject)uI_com_SelectForgeUniversalLegendItem).onClick.Set((EventCallback0)delegate
			{
				SelectUniversalLegendItem(index);
			});
		}
	}

	private bool SetLegendItemSoldierIcon(LegendItemUi legendItemData, UI_com_SelectForgeLegendItem btn)
	{
		if (LegendItemsHelper.EquippedLegendItems != null && LegendItemsHelper.EquippedLegendItems.TryGetValue(legendItemData.InstanceId.ToString(), out var value))
		{
			((GObject)btn.LegendItem.SoldierIcon).visible = true;
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(value);
			string itemId = soldier.ItemId;
			GObject child = ((GComponent)btn.LegendItem.SoldierIcon).GetChild("icon");
			string iconPath = UiHelper.GetIconPath(itemId);
			child.asCom.GetChild("icon").asLoader.url = "ui://PublicResources/" + iconPath;
			string text = $"kuang_square_lv{legendItemData.LegendItemData.Data.Rarity}";
			((GComponent)btn.LegendItem.SoldierIcon).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + text;
			((GComponent)btn.LegendItem.SoldierIcon).GetChild("numNote").visible = false;
			((GComponent)btn.LegendItem.SoldierIcon).GetChild("num").text = "";
			((GComponent)btn.LegendItem.SoldierIcon).GetChild("title").text = "";
			((GComponent)btn.LegendItem.SoldierIcon).GetChild("title_Max").text = "";
			return true;
		}
		return false;
	}

	private void SetMainLegendItemState(UI_com_SelectForgeLegendItem btn, LegendItemsHelper.ConfirmDialogInfo info, LegendItemUi legendItemData)
	{
		bool flag = LegendItemsHelper.MainLegendItemIsPending(legendItemData);
		btn.LegendItem.AvailableState.selectedIndex = (flag ? 1 : 0);
		if (flag)
		{
			info.TipType = new List<LegendItemsHelper.CanNotSelectTipType> { LegendItemsHelper.CanNotSelectTipType.Pending };
		}
		SetLegendItemSoldierIcon(legendItemData, btn);
		((GObject)btn.LegendItem).data = info;
	}

	private void SetLegendItemState(UI_com_SelectForgeLegendItem btn, LegendItemsHelper.ConfirmDialogInfo info, LegendItemUi legendItemData, bool legendItemInCostList, bool isMainItem)
	{
		bool flag = SetLegendItemSoldierIcon(legendItemData, btn);
		bool flag2 = LegendItemsHelper.LegendItemsEquiped(legendItemData.InstanceId);
		bool flag3 = !flag && !flag2 && !isMainItem;
		if (isMainItem)
		{
			info.TipType.Add(LegendItemsHelper.CanNotSelectTipType.IsMainLegendItem);
		}
		if (flag)
		{
			info.TipType.Add(LegendItemsHelper.CanNotSelectTipType.Equipped);
		}
		if (flag2)
		{
			info.TipType.Add(LegendItemsHelper.CanNotSelectTipType.Occupied);
		}
		btn.LegendItem.AvailableState.selectedIndex = ((!flag3) ? 1 : 0);
		btn.SelectState.selectedIndex = (legendItemInCostList ? 1 : 0);
		if (!legendItemInCostList)
		{
			btn.LockState.selectedIndex = (legendItemData.LegendItemData.Locked ? 1 : 0);
		}
		((GObject)btn.LegendItem).data = info;
	}

	private int SortMainLegendItem(LegendItemUi a, LegendItemUi b)
	{
		bool flag = LegendItemsHelper.MainLegendItemIsPending(a);
		bool flag2 = LegendItemsHelper.MainLegendItemIsPending(b);
		if (!flag && flag2)
		{
			return -1;
		}
		if (flag && !flag2)
		{
			return 1;
		}
		return LegendItemsHelper.SortLegendItemDataMaxToMin(a, b);
	}

	private int SortCostLegendItem(LegendItemUi a, LegendItemUi b)
	{
		if (LegendItemsHelper.EquippedLegendItems != null)
		{
			bool flag = LegendItemsHelper.EquippedLegendItems.ContainsKey(a.InstanceId.ToString());
			bool flag2 = LegendItemsHelper.EquippedLegendItems.ContainsKey(b.InstanceId.ToString());
			if (!flag && flag2)
			{
				return -1;
			}
			if (flag && !flag2)
			{
				return 1;
			}
		}
		if (forgePanel != null && forgePanel.MainInstance.LegendItem != null)
		{
			if (a.InstanceId != forgePanel.MainInstance.LegendItem.InstanceId && b.InstanceId == forgePanel.MainInstance.LegendItem.InstanceId)
			{
				return -1;
			}
			if (a.InstanceId == forgePanel.MainInstance.LegendItem.InstanceId && b.InstanceId != forgePanel.MainInstance.LegendItem.InstanceId)
			{
				return 1;
			}
		}
		if (!a.LegendItemData.Locked && b.LegendItemData.Locked)
		{
			return -1;
		}
		if (a.LegendItemData.Locked && !b.LegendItemData.Locked)
		{
			return 1;
		}
		return LegendItemsHelper.SortLegendItem(new LegendItemUiSortOptions(a, b, LegendItemSortEnhanceLevelOption.MinToMax));
	}

	private void SelectLegendItem(EventContext context)
	{
		UI_com_SelectForgeLegendItem uI_com_SelectForgeLegendItem = (UI_com_SelectForgeLegendItem)(object)context.sender;
		if (!(((GObject)uI_com_SelectForgeLegendItem?.LegendItem).data is LegendItemsHelper.ConfirmDialogInfo confirmDialogInfo))
		{
			return;
		}
		int index = (int)((GObject)uI_com_SelectForgeLegendItem).data;
		LegendItemUi legendItemUi = LegendItems[index];
		if (uI_com_SelectForgeLegendItem.LegendItem.AvailableState.selectedIndex == 1)
		{
			confirmDialogInfo.ShowTip(legendItemUi.LegendItemData.Data.Name);
			return;
		}
		int typeIndex = (confirmDialogInfo.ShowCancelBtn ? 6 : 5);
		if (ShowLegendItemType == 0)
		{
			UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(legendItemUi, "", CurrentSlotIndex, typeIndex, null, null, ShowLegendItemType, !confirmDialogInfo.CanNotChangeLock);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
		}
		else
		{
			UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(legendItemUi, "", CurrentSlotIndex, typeIndex, null, null, ShowLegendItemType, !confirmDialogInfo.CanNotChangeLock);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
		}
	}

	private void SelectUniversalLegendItem(int index)
	{
		LegendItemUi legendItemUi = LegendItems[index];
		string langKey;
		string selectedItemId;
		if (legendItemUi.UniversalLegendItemId == CurrentSlotItemId)
		{
			langKey = "SelectUniversalLegendItemCancelTip";
			selectedItemId = null;
		}
		else
		{
			langKey = "SelectUniversalLegendItemConfirmTip";
			selectedItemId = legendItemUi.UniversalLegendItemId;
		}
		string nameById = SchemaIndexHelper.GetNameById(GameManagers.Instance, legendItemUi.UniversalLegendItemId);
		string rarityTextColor = GetRarityTextColor(Item.Rarity(legendItemUi.UniversalLegendItemId));
		HotFix.Sources.Base.Scripts.Helper.StringExtensions.Format(langKey.ToLanguage(), "[color=" + rarityTextColor + "]" + nameById + "[/color]").ToConfirmPopup(delegate
		{
			SharedMessenger.Broadcast("UPDATE_FORGE_LEGENDITEM", new ForgeSelectLegendItem
			{
				InstanceId = -1L,
				UniversalLegendItemId = selectedItemId,
				Slot = CurrentSlotIndex,
				ItemType = ShowLegendItemType
			});
		}, null, (AlignType)0);
	}

	private string GetRarityTextColor(int rarity)
	{
		return rarity switch
		{
			1 => "#bfa37c", 
			2 => "#8fcc52", 
			3 => "#30b2f2", 
			4 => "#cc66ff", 
			5 => "#f27f0c", 
			6 => "#ffff00", 
			7 => "#ff1a2d", 
			_ => "bfa37c", 
		};
	}
}
