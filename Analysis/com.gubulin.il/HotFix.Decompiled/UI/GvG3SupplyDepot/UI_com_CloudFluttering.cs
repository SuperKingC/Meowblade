using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3SupplyDepot;

public class UI_com_CloudFluttering : GComponent
{
	public GImage n19;

	public GImage n20;

	public Transition t0;

	public const string URL = "ui://pobej4q7mys6y1s";

	public static string Name = "UI_com_CloudFluttering";

	public static string GetURL()
	{
		return "ui://pobej4q7mys6y1s";
	}

	public static UI_com_CloudFluttering CreateInstance()
	{
		return (UI_com_CloudFluttering)(object)UIPackage.CreateObject("GvG3SupplyDepot", "com_CloudFluttering");
	}

	public static UI_com_CloudFluttering CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CloudFluttering).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://pobej4q7mys6y1s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
