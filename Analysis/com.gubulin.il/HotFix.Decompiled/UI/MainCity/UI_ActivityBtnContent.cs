using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_ActivityBtnContent : GComponent
{
	public GImage n11;

	public GGraph SfxBack;

	public GLoader icon;

	public const string URL = "ui://j611zmymimvhv439";

	public static string Name = "UI_ActivityBtnContent";

	public static string GetURL()
	{
		return "ui://j611zmymimvhv439";
	}

	public static UI_ActivityBtnContent CreateInstance()
	{
		return (UI_ActivityBtnContent)(object)UIPackage.CreateObject("MainCity", "ActivityBtnContent");
	}

	public static UI_ActivityBtnContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ActivityBtnContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymimvhv439", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n11 = (GImage)((GComponent)this).GetChild("n11");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
