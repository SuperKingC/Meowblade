using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_SimpleSolierIconWithMask : GComponent
{
	public GImage n10;

	public GLoader icon;

	public const string URL = "ui://kt6rg65oxe3qv4bw";

	public static string Name = "UI_com_SimpleSolierIconWithMask";

	public static string GetURL()
	{
		return "ui://kt6rg65oxe3qv4bw";
	}

	public static UI_com_SimpleSolierIconWithMask CreateInstance()
	{
		return (UI_com_SimpleSolierIconWithMask)(object)UIPackage.CreateObject("PublicResources", "com_SimpleSolierIconWithMask");
	}

	public static UI_com_SimpleSolierIconWithMask CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SimpleSolierIconWithMask).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oxe3qv4bw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
