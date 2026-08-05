using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_CampRankDetail : GButton
{
	public Controller button;

	public GTextField Date;

	public GImage n6;

	public GImage n7;

	public const string URL = "ui://hozu168rhd0n9i";

	public static string Name = "UI_btn_CampRankDetail";

	public static string GetURL()
	{
		return "ui://hozu168rhd0n9i";
	}

	public static UI_btn_CampRankDetail CreateInstance()
	{
		return (UI_btn_CampRankDetail)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_CampRankDetail");
	}

	public static UI_btn_CampRankDetail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CampRankDetail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rhd0n9i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Date = (GTextField)((GComponent)this).GetChild("Date");
		string id = "ui://hozu168rhd0n9i".Replace("ui://", "") + "-" + ((GObject)Date).id;
		((GObject)Date).text = LanguagesManager.GetDesc(id);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
