using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.GVGStore;

public class UI_main_GVGStoreBuyConfirmPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_BuyStoreItemConfirmDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://fvc33k3gv6i716";

	public static string Name = "UI_main_GVGStoreBuyConfirmPanel";

	private ArchiveExtension_Formulas.ConfirmBuyStoreItem _storeItem;

	private Action _onFormulaUsed;

	public static string GetURL()
	{
		return "ui://fvc33k3gv6i716";
	}

	public static UI_main_GVGStoreBuyConfirmPanel CreateInstance()
	{
		return (UI_main_GVGStoreBuyConfirmPanel)(object)UIPackage.CreateObject("GVGStore", "main_GVGStoreBuyConfirmPanel");
	}

	public static UI_main_GVGStoreBuyConfirmPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GVGStoreBuyConfirmPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gv6i716", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_BuyStoreItemConfirmDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
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
		_storeItem = (parameters.TryGetValue("StoreItem", out var value) ? (value as ArchiveExtension_Formulas.ConfirmBuyStoreItem) : null);
		_onFormulaUsed = (parameters.TryGetValue("OnPurchased", out var value2) ? (value2 as Action) : null);
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Dialog.Cancel).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Add(new EventCallback0(Confirm));
		((GObject)Mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Dialog.Cancel).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Remove(new EventCallback0(Confirm));
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void Confirm()
	{
		GameManagers.Instance.UserArchiveManager.UseFormula(_storeItem.Formula, UpdateUi, 0, 0, _storeItem.ItemId, _storeItem.Index);
		void UpdateUi()
		{
			SharedMessenger.Broadcast("UPDATE_GVG_STORE_ITEMS", arg1: false);
			_onFormulaUsed?.Invoke();
			End();
		}
	}

	private void RenderDialog()
	{
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		string desc = LanguagesManager.GetDesc("GvGStoreItemBuyConfirmTip");
		int num = ((Item.ItemType(_storeItem.ItemId) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(_storeItem.ItemId) : Item.Level(GameManagers.Instance, _storeItem.ItemId));
		num = ((num > 0) ? num : Item.Rarity(_storeItem.ItemId));
		string arg = Regex.Replace(Item.Name(GameManagers.Instance, _storeItem.ItemId), "\\r?\\n", string.Empty);
		string text = $"  [color=#{ColorUtility.ToHtmlStringRGB(Color32.op_Implicit(UiHelper.GetColorByItemLevel(num)))}]{arg}（{_storeItem.ItemNum}）[/color]";
		((GObject)Dialog.Tip).text = string.Format(desc, new object[1] { text });
	}
}
