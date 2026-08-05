using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_HelpBtnContent : GComponent
{
	public GImage n6;

	public GImage n10;

	public GImage n11;

	public const string URL = "ui://j611zmymimvhv436";

	public static string Name = "UI_HelpBtnContent";

	public static string GetURL()
	{
		return "ui://j611zmymimvhv436";
	}

	public static UI_HelpBtnContent CreateInstance()
	{
		return (UI_HelpBtnContent)(object)UIPackage.CreateObject("MainCity", "HelpBtnContent");
	}

	public static UI_HelpBtnContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HelpBtnContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymimvhv436", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
	}
}
