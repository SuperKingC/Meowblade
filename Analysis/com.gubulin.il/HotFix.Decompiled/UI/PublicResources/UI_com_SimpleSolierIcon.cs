using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_com_SimpleSolierIcon : GComponent
{
	public GLoader icon;

	public const string URL = "ui://kt6rg65otxoiv4c9";

	public static string Name = "UI_com_SimpleSolierIcon";

	public static string GetURL()
	{
		return "ui://kt6rg65otxoiv4c9";
	}

	public static UI_com_SimpleSolierIcon CreateInstance()
	{
		return (UI_com_SimpleSolierIcon)(object)UIPackage.CreateObject("PublicResources", "com_SimpleSolierIcon");
	}

	public static UI_com_SimpleSolierIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SimpleSolierIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65otxoiv4c9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
