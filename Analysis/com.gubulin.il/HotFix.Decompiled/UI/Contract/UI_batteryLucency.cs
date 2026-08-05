using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_batteryLucency : GComponent
{
	public GImage n24;

	public UI_point point0;

	public UI_point point1;

	public UI_point point2;

	public UI_point startPoint;

	public UI_point middle;

	public UI_point explodePoint;

	public UI_point endPoint;

	public const string URL = "ui://avplaivdkpq617";

	public static string Name = "UI_batteryLucency";

	public static string GetURL()
	{
		return "ui://avplaivdkpq617";
	}

	public static UI_batteryLucency CreateInstance()
	{
		return (UI_batteryLucency)(object)UIPackage.CreateObject("Contract", "batteryLucency");
	}

	public static UI_batteryLucency CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_batteryLucency).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdkpq617", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n24 = (GImage)((GComponent)this).GetChild("n24");
		point0 = (UI_point)(object)((GComponent)this).GetChild("point0");
		point1 = (UI_point)(object)((GComponent)this).GetChild("point1");
		point2 = (UI_point)(object)((GComponent)this).GetChild("point2");
		startPoint = (UI_point)(object)((GComponent)this).GetChild("startPoint");
		middle = (UI_point)(object)((GComponent)this).GetChild("middle");
		explodePoint = (UI_point)(object)((GComponent)this).GetChild("explodePoint");
		endPoint = (UI_point)(object)((GComponent)this).GetChild("endPoint");
	}
}
