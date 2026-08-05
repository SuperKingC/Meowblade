using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_PostMission_Small : GButton
{
	public Controller button;

	public GImage n9;

	public GLoader icon;

	public const string URL = "ui://tt2iq07onhzv18";

	public static string Name = "UI_btn_PostMission_Small";

	public static string GetURL()
	{
		return "ui://tt2iq07onhzv18";
	}

	public static UI_btn_PostMission_Small CreateInstance()
	{
		return (UI_btn_PostMission_Small)(object)UIPackage.CreateObject("GvGExchange3", "btn_PostMission_Small");
	}

	public static UI_btn_PostMission_Small CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PostMission_Small).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07onhzv18", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
