using System;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.Storehouse;
using Shift.Legion.Helpers;

namespace UI.CraftItemPopup;

public class UI_main_CraftItemPopupPanel_GvG : GComponent, IUiController
{
	public GGraph back;

	public UI_com_CraftItemPopupDialog Dialog;

	public Transition showTip;

	public const string URL = "ui://4pn38ozniuisb";

	public static string Name = "UI_main_CraftItemPopupPanel_GvG";

	private string ItemId;

	private UICallbackParam<Action<int>> OnConfirmCraft;

	private int ItemCount;

	private int TargetCraftCount;

	private int MaxValue;

	private GDEItemData ItemGDEData;

	private GvGServer_CraftItemsModel ItemEffect;

	public static string GetURL()
	{
		return "ui://4pn38ozniuisb";
	}

	public static UI_main_CraftItemPopupPanel_GvG CreateInstance()
	{
		return (UI_main_CraftItemPopupPanel_GvG)(object)UIPackage.CreateObject("CraftItemPopup", "main_CraftItemPopupPanel_GvG");
	}

	public static UI_main_CraftItemPopupPanel_GvG CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_CraftItemPopupPanel_GvG).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4pn38ozniuisb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_CraftItemPopupDialog)(object)((GComponent)this).GetChild("Dialog");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (!parameters.TryGetValue("ItemId", out var value))
		{
			ILRuntimeDebug.LogError("[UI_main_CraftItemPopupPanel]: 缺少 ItemId 参数");
			End();
			return;
		}
		if (!parameters.TryGetValue("OnConfirmCraft", out var value2))
		{
			ILRuntimeDebug.LogError("[UI_main_CraftItemPopupPanel]: 缺少 OnConfirmCraft 参数");
			End();
			return;
		}
		ItemId = (string)value;
		OnConfirmCraft = (UICallbackParam<Action<int>>)value2;
		ItemCount = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(ItemId, includingGSStock: true);
		ItemGDEData = GDMgr.Get<GDEItemData>(ItemId);
		ItemEffect = JsonHelper.ToObject<GvGServer_CraftItemsModel>(ItemGDEData.Effect);
		MaxValue = Math.Min(ItemCount / ItemEffect.ConsumeCnt, 100);
		TargetCraftCount = 1;
		((GObject)Dialog.MaxValueBtn.Title).text = "100";
		RenderDialog();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.MaxValueBtn).onClick.Set(new EventCallback0(OnClickMaxBtn));
		((GObject)Dialog.IncreaseBtn).onClick.Set(new EventCallback0(OnClickAddBtn));
		((GObject)Dialog.ReduceBtn).onClick.Set(new EventCallback0(OnClickReduceBtn));
		((GObject)Dialog.CraftBtn).onClick.Set(new EventCallback0(OnClickConfirmCraftBtn));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)back).onClick.Clear();
		((GObject)Dialog.MaxValueBtn).onClick.Clear();
		((GObject)Dialog.IncreaseBtn).onClick.Clear();
		((GObject)Dialog.ReduceBtn).onClick.Clear();
		((GObject)Dialog.CraftBtn).onClick.Clear();
	}

	private void RenderDialog()
	{
		RenderContent();
		RenderConsumptions();
		RenderCraftCount();
	}

	private void RenderContent()
	{
		((GObject)Dialog.Content.title).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, ItemId);
		((GObject)Dialog.Content.Property).text = Item.PostScript(ItemId);
		((GObject)Dialog.Content.Access).text = ItemGDEData.AccessPath ?? string.Empty;
		((GObject)Dialog.Content.stockNum).text = ItemCount.ShortNumberFormat() ?? "";
		FGUIManager.Instance.SetItemIconAndFrame(Dialog.Content.icon, ItemId);
	}

	private void RenderConsumptions()
	{
		RenderOutputItem();
		RenderInputItem();
		int num = ItemEffect.ConsumeCnt * TargetCraftCount;
		bool flag = ItemCount >= num;
		string format = (flag ? "{0}/{1}" : "[color=#FF1919]{0}/[/color]{1}");
		((GObject)Dialog.Consumption.ConsumeNum).text = string.Format(format, ItemCount.ShortNumberFormat(), num.ShortNumberFormat());
		FGUIManager.Instance.SetItemIconAndFrame(Dialog.Consumption.Icon, ItemId, null, "", frameVisible: false);
		((GObject)Dialog.CraftBtn).enabled = flag;
	}

	private void RenderInputItem()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)Dialog.ConsumptionRate.InputRate).text = $"{ItemEffect.ConsumeCnt}";
		((GObject)Dialog.ConsumptionRate.InputItemIcon).onClick.Set((EventCallback0)delegate
		{
			OnClickItem(ItemId);
		});
		FGUIManager.Instance.SetItemIconAndFrame(Dialog.ConsumptionRate.InputItemIcon, ItemId, null, "", frameVisible: false);
	}

	private void RenderOutputItem()
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		((GObject)Dialog.ConsumptionRate.OutputRate).text = $"{1}";
		((GObject)Dialog.ConsumptionRate.OutputItemIcon).onClick.Set((EventCallback0)delegate
		{
			OnClickItem(ItemEffect.DisplayItem);
		});
		FGUIManager.Instance.SetItemIconAndFrame(Dialog.ConsumptionRate.OutputItemIcon, ItemEffect.DisplayItem, null, "", frameVisible: false);
	}

	private void RenderCraftCount()
	{
		((GObject)Dialog.CompoundNum).text = $"{TargetCraftCount}";
	}

	private void UpdateCraftCountAndConsumption()
	{
		RenderConsumptions();
		RenderCraftCount();
	}

	private void OnClickConfirmCraftBtn()
	{
		OnConfirmCraft?.Callback?.Invoke(TargetCraftCount);
		End();
	}

	private void OnClickMaxBtn()
	{
		TargetCraftCount = MaxValue;
		if (TargetCraftCount == 0)
		{
			TargetCraftCount = 1;
		}
		UpdateCraftCountAndConsumption();
	}

	private void OnClickAddBtn()
	{
		if (++TargetCraftCount >= MaxValue)
		{
			TargetCraftCount = MaxValue;
		}
		if (TargetCraftCount == 0)
		{
			TargetCraftCount = 1;
		}
		UpdateCraftCountAndConsumption();
	}

	private void OnClickReduceBtn()
	{
		if (--TargetCraftCount <= 1)
		{
			TargetCraftCount = 1;
		}
		UpdateCraftCountAndConsumption();
	}

	private void OnClickItem(string itemId)
	{
		FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true, reserveRes: false, this);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void OnShow()
	{
	}
}
