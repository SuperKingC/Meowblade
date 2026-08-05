using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_btn_RankingListSwitch : GButton
{
	public Controller button;

	public GImage n4;

	public const string URL = "ui://ebc4ciwro12vq50";

	public static string Name = "UI_btn_RankingListSwitch";

	public static string GetURL()
	{
		return "ui://ebc4ciwro12vq50";
	}

	public static UI_btn_RankingListSwitch CreateInstance()
	{
		return (UI_btn_RankingListSwitch)(object)UIPackage.CreateObject("GvGOnIsland3", "btn_RankingListSwitch");
	}

	public static UI_btn_RankingListSwitch CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RankingListSwitch).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwro12vq50", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
