using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.GvGShipDetail;

public class UI_main_SoulGuidePanel : GComponent, IUiController
{
	public GLoader background;

	public GGraph Mask;

	public UI_com_SoulGuideDialog Dialog;

	public Transition Popup;

	public const string URL = "ui://u6x0b1gnc9xa6a";

	public static string Name = "UI_main_SoulGuidePanel";

	private UICallbackParam<Action> OnConfirmCallback;

	public static string GetURL()
	{
		return "ui://u6x0b1gnc9xa6a";
	}

	public static UI_main_SoulGuidePanel CreateInstance()
	{
		return (UI_main_SoulGuidePanel)(object)UIPackage.CreateObject("GvGShipDetail", "main_SoulGuidePanel");
	}

	public static UI_main_SoulGuidePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_SoulGuidePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnc9xa6a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_SoulGuideDialog)(object)((GComponent)this).GetChild("Dialog");
		Popup = ((GComponent)this).GetTransition("Popup");
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
		OnConfirmCallback = (parameters.TryGetValue("OnConfirm", out var value) ? ((UICallbackParam<Action>)value) : null);
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.Cancel).onClick.Add(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Add(new EventCallback1(OnClickConfirm));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Remove(new EventCallback0(End));
		((GObject)Dialog.Confirm).onClick.Clear();
	}

	private void OnClickConfirm(EventContext context)
	{
		End();
		OnConfirmCallback?.Callback?.Invoke();
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
