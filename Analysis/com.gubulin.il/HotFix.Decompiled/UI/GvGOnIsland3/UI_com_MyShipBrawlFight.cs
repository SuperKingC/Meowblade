using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_MyShipBrawlFight : GComponent
{
	public GImage n84;

	public GImage n85;

	public GTextField n82;

	public UI_btn_MyShipBrawlFight myShip;

	public const string URL = "ui://ebc4ciwrj962q6h";

	public static string Name = "UI_com_MyShipBrawlFight";

	public static string GetURL()
	{
		return "ui://ebc4ciwrj962q6h";
	}

	public static UI_com_MyShipBrawlFight CreateInstance()
	{
		return (UI_com_MyShipBrawlFight)(object)UIPackage.CreateObject("GvGOnIsland3", "com_MyShipBrawlFight");
	}

	public static UI_com_MyShipBrawlFight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MyShipBrawlFight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrj962q6h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n84 = (GImage)((GComponent)this).GetChild("n84");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		n82 = (GTextField)((GComponent)this).GetChild("n82");
		string id = "ui://ebc4ciwrj962q6h".Replace("ui://", "") + "-" + ((GObject)n82).id;
		((GObject)n82).text = LanguagesManager.GetDesc(id);
		myShip = (UI_btn_MyShipBrawlFight)(object)((GComponent)this).GetChild("myShip");
	}
}
