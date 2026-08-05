using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.GvGExchange3;

public class UI_main_PostNewFormulaTip : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_PostNewFormulaTip Popup;

	public const string URL = "ui://tt2iq07oxxgp58";

	public static string Name = "UI_main_PostNewFormulaTip";

	public static string GetURL()
	{
		return "ui://tt2iq07oxxgp58";
	}

	public static UI_main_PostNewFormulaTip CreateInstance()
	{
		return (UI_main_PostNewFormulaTip)(object)UIPackage.CreateObject("GvGExchange3", "main_PostNewFormulaTip");
	}

	public static UI_main_PostNewFormulaTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_PostNewFormulaTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oxxgp58", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Popup = (UI_com_PostNewFormulaTip)(object)((GComponent)this).GetChild("Popup");
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
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
