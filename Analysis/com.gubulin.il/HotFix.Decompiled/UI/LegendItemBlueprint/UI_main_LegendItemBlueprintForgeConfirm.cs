using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

namespace UI.LegendItemBlueprint;

public class UI_main_LegendItemBlueprintForgeConfirm : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_LegendItemForgeConfirm Dialog;

	public const string URL = "ui://h09dvkcgpqzh32";

	public static string Name = "UI_main_LegendItemBlueprintForgeConfirm";

	private Action ConfirmAction;

	private long MainItemInstanceId;

	private List<string> CostItemsInstanceId;

	private Dictionary<string, int> UniversalLegendItemDict;

	public static string GetURL()
	{
		return "ui://h09dvkcgpqzh32";
	}

	public static UI_main_LegendItemBlueprintForgeConfirm CreateInstance()
	{
		return (UI_main_LegendItemBlueprintForgeConfirm)(object)UIPackage.CreateObject("LegendItemBlueprint", "main_LegendItemBlueprintForgeConfirm");
	}

	public static UI_main_LegendItemBlueprintForgeConfirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_LegendItemBlueprintForgeConfirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgpqzh32", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_LegendItemForgeConfirm)(object)((GComponent)this).GetChild("Dialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		ConfirmAction = (parameters.TryGetValue("ConfirmAction", out var value) ? (value as Action) : null);
		MainItemInstanceId = (parameters.TryGetValue("MainItemInstanceId", out var value2) ? ((long)value2) : (-1));
		CostItemsInstanceId = new List<string>();
		object value3;
		List<string> list = (parameters.TryGetValue("CostItemsInstanceId", out value3) ? (value3 as List<string>) : new List<string>());
		UniversalLegendItemDict = (parameters.TryGetValue("UniversalLegendItemDict", out var value4) ? ((Dictionary<string, int>)value4) : new Dictionary<string, int>());
		object value5;
		string item = (parameters.TryGetValue("BlueprintIconUrl", out value5) ? value5.ToString() : string.Empty);
		CostItemsInstanceId.Add(item);
		if (list != null)
		{
			CostItemsInstanceId.AddRange(list);
		}
		RenderDialog();
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.Confirm).onClick.Add(new EventCallback0(ConfirmEvent));
		((GObject)Dialog.Cancel).onClick.Add(new EventCallback0(CancelEvent));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		((GObject)Dialog.Confirm).onClick.Remove(new EventCallback0(ConfirmEvent));
		((GObject)Dialog.Cancel).onClick.Remove(new EventCallback0(CancelEvent));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void RenderDialog()
	{
		RenderMainItem();
		RenderCostItems();
	}

	private void RenderMainItem()
	{
		LegendItemUi legendItemUi = LegendItemsHelper.GetLegendItemUi(MainItemInstanceId);
		if (legendItemUi != null)
		{
			Dialog.MainLegendItem.Level.selectedIndex = legendItemUi.LegendItemData.Data.Rarity - 1;
			((GObject)Dialog.MainLegendItem.LevelValue).text = legendItemUi.LegendItemData.EnhanceLevel.ToString();
			Dialog.MainLegendItem.Type.selectedIndex = 1;
			Dialog.MainLegendItem.AvailableState.selectedIndex = 0;
			Dialog.MainLegendItem.Icon.LoadArmsIcon(legendItemUi.LegendItemData.Data.Icon);
			((GObject)Dialog.MainLegendItem.SoldierIcon).visible = false;
			if (LegendItemsHelper.EquippedLegendItems != null && LegendItemsHelper.EquippedLegendItems.TryGetValue(legendItemUi.InstanceId.ToString(), out var value))
			{
				((GObject)Dialog.MainLegendItem.SoldierIcon).visible = true;
				Soldier soldier = GameManagers.Instance.SoldierManager.Get(value);
				string itemId = soldier.ItemId;
				GObject child = ((GComponent)Dialog.MainLegendItem.SoldierIcon).GetChild("icon");
				string iconPath = UiHelper.GetIconPath(itemId);
				child.asCom.GetChild("icon").asLoader.url = "ui://PublicResources/" + iconPath;
				string text = $"kuang_square_lv{legendItemUi.LegendItemData.Data.Rarity}";
				((GComponent)Dialog.MainLegendItem.SoldierIcon).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + text;
				((GComponent)Dialog.MainLegendItem.SoldierIcon).GetChild("numNote").visible = false;
				((GComponent)Dialog.MainLegendItem.SoldierIcon).GetChild("num").text = "";
				((GComponent)Dialog.MainLegendItem.SoldierIcon).GetChild("title").text = "";
				((GComponent)Dialog.MainLegendItem.SoldierIcon).GetChild("title_Max").text = "";
			}
		}
	}

	private void RenderCostItems()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Dialog.CostLegendItems.itemRenderer = new ListItemRenderer(RenderCostItem);
		Dialog.CostLegendItems.numItems = CostItemsInstanceId.Count;
	}

	private void RenderCostItem(int index, GObject obj)
	{
		if (!(obj is UI_com_ForgeConfirmCostItem uI_com_ForgeConfirmCostItem))
		{
			return;
		}
		string text = CostItemsInstanceId[index];
		if (index == 0)
		{
			uI_com_ForgeConfirmCostItem.Type.selectedIndex = 0;
			uI_com_ForgeConfirmCostItem.BlueprintIcon.LoadBlueprintIcon(text);
			return;
		}
		if (UniversalLegendItemDict.ContainsKey(text))
		{
			uI_com_ForgeConfirmCostItem.Type.selectedIndex = 2;
			uI_com_ForgeConfirmCostItem.UniversalLegendItem.Level.selectedIndex = Item.Rarity(text);
			uI_com_ForgeConfirmCostItem.UniversalLegendItem.Icon.url = UiHelper.GetIcon(text).ToPublicResourceIcon();
			return;
		}
		LegendItemUi legendItemUi = LegendItemsHelper.GetLegendItemUi(long.Parse(text));
		if (legendItemUi != null)
		{
			uI_com_ForgeConfirmCostItem.Type.selectedIndex = 1;
			uI_com_ForgeConfirmCostItem.Item.Level.selectedIndex = legendItemUi.LegendItemData.Data.Rarity - 1;
			((GObject)uI_com_ForgeConfirmCostItem.Item.LevelValue).text = legendItemUi.LegendItemData.EnhanceLevel.ToString();
			uI_com_ForgeConfirmCostItem.Item.Type.selectedIndex = 0;
			uI_com_ForgeConfirmCostItem.Item.AvailableState.selectedIndex = 0;
			uI_com_ForgeConfirmCostItem.Item.Icon.LoadArmsIcon(legendItemUi.LegendItemData.Data.Icon);
		}
	}

	private void CancelEvent()
	{
		End();
	}

	private void ConfirmEvent()
	{
		ConfirmAction?.Invoke();
		End();
	}
}
