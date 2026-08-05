using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_LegionBtnContent : GComponent
{
	public GImage n6;

	public GImage n8;

	public GImage n9;

	public const string URL = "ui://j611zmymimvhv435";

	public static string Name = "UI_LegionBtnContent";

	public static string GetURL()
	{
		return "ui://j611zmymimvhv435";
	}

	public static UI_LegionBtnContent CreateInstance()
	{
		return (UI_LegionBtnContent)(object)UIPackage.CreateObject("MainCity", "LegionBtnContent");
	}

	public static UI_LegionBtnContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegionBtnContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymimvhv435", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}
