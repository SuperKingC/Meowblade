using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_main_AccelerateStatusPage : GComponent
{
	public GGraph mask;

	public UI_main_AccelerateStatusDialog Dialog;

	public Transition showPopup;

	public const string URL = "ui://th385mttixv5o95";

	public static string Name = "UI_main_AccelerateStatusPage";

	public static string GetURL()
	{
		return "ui://th385mttixv5o95";
	}

	public static UI_main_AccelerateStatusPage CreateInstance()
	{
		return (UI_main_AccelerateStatusPage)(object)UIPackage.CreateObject("GvGOuterTech", "main_AccelerateStatusPage");
	}

	public static UI_main_AccelerateStatusPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_AccelerateStatusPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttixv5o95", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		Dialog = (UI_main_AccelerateStatusDialog)(object)((GComponent)this).GetChild("Dialog");
		showPopup = ((GComponent)this).GetTransition("showPopup");
	}
}
