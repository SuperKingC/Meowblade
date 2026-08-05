using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.ReturningRewards;

public class UI_main_ReturningInstructions : GComponent, IUiController
{
	public GGraph Mask;

	public UI_com_Instructions Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://rx5ntv98yvss2d";

	public static string Name = "UI_main_ReturningInstructions";

	public static string GetURL()
	{
		return "ui://rx5ntv98yvss2d";
	}

	public static UI_main_ReturningInstructions CreateInstance()
	{
		return (UI_main_ReturningInstructions)(object)UIPackage.CreateObject("ReturningRewards", "main_ReturningInstructions");
	}

	public static UI_main_ReturningInstructions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_ReturningInstructions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://rx5ntv98yvss2d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_Instructions)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public static void Open()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(Name, null);
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
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.Close).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Dialog.Close).onClick.Clear();
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}
}
