using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_LotteryBtnContent : GComponent
{
	public GImage n5;

	public GImage n7;

	public GImage n8;

	public const string URL = "ui://j611zmymimvhv438";

	public static string Name = "UI_LotteryBtnContent";

	public static string GetURL()
	{
		return "ui://j611zmymimvhv438";
	}

	public static UI_LotteryBtnContent CreateInstance()
	{
		return (UI_LotteryBtnContent)(object)UIPackage.CreateObject("MainCity", "LotteryBtnContent");
	}

	public static UI_LotteryBtnContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LotteryBtnContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymimvhv438", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
