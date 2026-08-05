using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_Tipcontent : GComponent
{
	public GImage back;

	public GImage n10;

	public const string URL = "ui://twlbabics9of3l";

	public static string Name = "UI_Tipcontent";

	public static string GetURL()
	{
		return "ui://twlbabics9of3l";
	}

	public static UI_Tipcontent CreateInstance()
	{
		return (UI_Tipcontent)(object)UIPackage.CreateObject("Battle", "Tipcontent");
	}

	public static UI_Tipcontent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Tipcontent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabics9of3l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}
}
