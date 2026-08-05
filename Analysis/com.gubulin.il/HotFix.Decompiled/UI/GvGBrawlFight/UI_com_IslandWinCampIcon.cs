using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_IslandWinCampIcon : GComponent
{
	public Controller campType;

	public GImage n10;

	public GImage n7;

	public GLoader campIcon;

	public GImage n9;

	public Transition t0;

	public const string URL = "ui://hozu168r9ykh6e";

	public static string Name = "UI_com_IslandWinCampIcon";

	public static string GetURL()
	{
		return "ui://hozu168r9ykh6e";
	}

	public static UI_com_IslandWinCampIcon CreateInstance()
	{
		return (UI_com_IslandWinCampIcon)(object)UIPackage.CreateObject("GvGBrawlFight", "com_IslandWinCampIcon");
	}

	public static UI_com_IslandWinCampIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandWinCampIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168r9ykh6e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		campType = ((GComponent)this).GetController("campType");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		campIcon = (GLoader)((GComponent)this).GetChild("campIcon");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
