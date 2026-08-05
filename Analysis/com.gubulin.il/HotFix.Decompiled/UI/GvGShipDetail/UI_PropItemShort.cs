using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGShipDetail;

public class UI_PropItemShort : GComponent
{
	public GTextField PropName;

	public GTextField PropEffect;

	public const string URL = "ui://u6x0b1gnatee1t";

	public static string Name = "UI_PropItemShort";

	public static string GetURL()
	{
		return "ui://u6x0b1gnatee1t";
	}

	public static UI_PropItemShort CreateInstance()
	{
		return (UI_PropItemShort)(object)UIPackage.CreateObject("GvGShipDetail", "PropItemShort");
	}

	public static UI_PropItemShort CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PropItemShort).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://u6x0b1gnatee1t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PropName = (GTextField)((GComponent)this).GetChild("PropName");
		PropEffect = (GTextField)((GComponent)this).GetChild("PropEffect");
	}
}
