using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.GVGStore;

public class UI_main_GVGStoreRareStoreItemRefreshConfirmPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_RareStoreItemRefreshConfirmDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://fvc33k3gn4d02b";

	public static string Name = "UI_main_GVGStoreRareStoreItemRefreshConfirmPanel";

	private Action _onClickConfirm;

	public static string GetURL()
	{
		return "ui://fvc33k3gn4d02b";
	}

	public static UI_main_GVGStoreRareStoreItemRefreshConfirmPanel CreateInstance()
	{
		return (UI_main_GVGStoreRareStoreItemRefreshConfirmPanel)(object)UIPackage.CreateObject("GVGStore", "main_GVGStoreRareStoreItemRefreshConfirmPanel");
	}

	public static UI_main_GVGStoreRareStoreItemRefreshConfirmPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GVGStoreRareStoreItemRefreshConfirmPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gn4d02b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_RareStoreItemRefreshConfirmDialog)(object)((GComponent)this).GetChild("Dialog");
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
		if (parameters != null && parameters.TryGetValue("OnClickConfirm", out var value))
		{
			_onClickConfirm = (Action)value;
		}
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
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)Dialog.Exit).onClick.Add(new EventCallback0(ExitClickEvent));
		((GObject)Dialog.Confirm).onClick.Add(new EventCallback0(ConfirmClickEvent));
		((GObject)Dialog.Cancel).onClick.Add(new EventCallback0(CancelClickEvent));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)Dialog.Exit).onClick.Remove(new EventCallback0(ExitClickEvent));
		((GObject)Dialog.Confirm).onClick.Remove(new EventCallback0(ConfirmClickEvent));
		((GObject)Dialog.Cancel).onClick.Remove(new EventCallback0(CancelClickEvent));
	}

	private void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void ExitClickEvent()
	{
		End();
	}

	private void CancelClickEvent()
	{
		SharedMessenger.Broadcast("CLOSE_GVG_STORE_REFRESH_DIALOG");
		End();
	}

	private void ConfirmClickEvent()
	{
		SharedMessenger.Broadcast("UPDATE_GVG_STORE_ITEMS", arg1: true);
		SharedMessenger.Broadcast("CLOSE_GVG_STORE_REFRESH_DIALOG");
		End();
		_onClickConfirm?.Invoke();
	}
}
