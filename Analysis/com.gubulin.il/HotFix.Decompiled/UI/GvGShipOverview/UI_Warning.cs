using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipOverview;

public class UI_Warning : GComponent
{
	public GImage Warning;

	public Transition t0;

	public const string URL = "ui://7ymaonxtc69m52";

	public static string Name = "UI_Warning";

	public static string GetURL()
	{
		return "ui://7ymaonxtc69m52";
	}

	public static UI_Warning CreateInstance()
	{
		return (UI_Warning)(object)UIPackage.CreateObject("GvGShipOverview", "Warning");
	}

	public static UI_Warning CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Warning).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ymaonxtc69m52", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Warning = (GImage)((GComponent)this).GetChild("Warning");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
