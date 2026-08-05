using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix;

namespace UI.Tips;

public class UI_popup_AppClosedTip : GComponent, IUiController
{
	public GGraph back;

	public UI_com_AppClosedTip ConfirmDialog;

	public Transition showTip;

	public const string URL = "ui://47lbpgx9gybij5ltg8";

	public static string Name = "UI_popup_AppClosedTip";

	public const string CloseReason = "CloseReason";

	public static string GetURL()
	{
		return "ui://47lbpgx9gybij5ltg8";
	}

	public static UI_popup_AppClosedTip CreateInstance()
	{
		return (UI_popup_AppClosedTip)(object)UIPackage.CreateObject("Tips", "popup_AppClosedTip");
	}

	public static UI_popup_AppClosedTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_popup_AppClosedTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9gybij5ltg8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		ConfirmDialog = (UI_com_AppClosedTip)(object)((GComponent)this).GetChild("ConfirmDialog");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	public void RegisterUiEventListeners()
	{
	}

	public void UnregisterUiEventListeners()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		CloseAppReason selectedIndex = (CloseAppReason)parameters["CloseReason"];
		ConfirmDialog.Type.SetSelectedIndex((int)selectedIndex);
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
}
