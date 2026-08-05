using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_ManorSize : GButton
{
	public GImage n9;

	public GImage redPoint;

	public GGroup sizeGroup;

	public const string URL = "ui://c9n2h0ksee14f";

	public static string Name = "UI_ManorSize";

	public static string GetURL()
	{
		return "ui://c9n2h0ksee14f";
	}

	public static UI_ManorSize CreateInstance()
	{
		return (UI_ManorSize)(object)UIPackage.CreateObject("WorldMap", "ManorSize");
	}

	public static UI_ManorSize CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ManorSize).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksee14f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n9 = (GImage)((GComponent)this).GetChild("n9");
		redPoint = (GImage)((GComponent)this).GetChild("redPoint");
		sizeGroup = (GGroup)((GComponent)this).GetChild("sizeGroup");
	}
}
