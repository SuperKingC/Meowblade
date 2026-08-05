using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_tab_01 : GButton
{
	public Controller button;

	public Controller c1;

	public GImage n54;

	public GImage n55;

	public GLoader n56;

	public GImage note;

	public const string URL = "ui://29q48tv6cp085f9g";

	public static string Name = "UI_tab_01";

	public static string GetURL()
	{
		return "ui://29q48tv6cp085f9g";
	}

	public static UI_tab_01 CreateInstance()
	{
		return (UI_tab_01)(object)UIPackage.CreateObject("GameActivity", "tab_01");
	}

	public static UI_tab_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_tab_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6cp085f9g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		c1 = ((GComponent)this).GetController("c1");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n56 = (GLoader)((GComponent)this).GetChild("n56");
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
