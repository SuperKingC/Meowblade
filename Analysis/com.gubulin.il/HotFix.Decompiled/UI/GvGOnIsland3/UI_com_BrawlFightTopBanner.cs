using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_BrawlFightTopBanner : GComponent
{
	public Controller isFfa;

	public GImage bg;

	public GTextField des;

	public const string URL = "ui://ebc4ciwrj962q6g";

	public static string Name = "UI_com_BrawlFightTopBanner";

	public static string GetURL()
	{
		return "ui://ebc4ciwrj962q6g";
	}

	public static UI_com_BrawlFightTopBanner CreateInstance()
	{
		return (UI_com_BrawlFightTopBanner)(object)UIPackage.CreateObject("GvGOnIsland3", "com_BrawlFightTopBanner");
	}

	public static UI_com_BrawlFightTopBanner CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BrawlFightTopBanner).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrj962q6g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isFfa = ((GComponent)this).GetController("isFfa");
		bg = (GImage)((GComponent)this).GetChild("bg");
		des = (GTextField)((GComponent)this).GetChild("des");
	}
}
