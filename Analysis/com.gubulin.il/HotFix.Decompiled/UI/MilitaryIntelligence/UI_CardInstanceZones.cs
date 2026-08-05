using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryIntelligence;

public class UI_CardInstanceZones : GButton
{
	public Controller button;

	public GImage back;

	public GImage n15;

	public GImage n5;

	public GTextField time;

	public GGraph n8;

	public GTextField title;

	public GTextField content;

	public GImage n13;

	public GButton treasureBtn;

	public const string URL = "ui://nfd5v46uk67ub";

	public static string Name = "UI_CardInstanceZones";

	public static string GetURL()
	{
		return "ui://nfd5v46uk67ub";
	}

	public static UI_CardInstanceZones CreateInstance()
	{
		return (UI_CardInstanceZones)(object)UIPackage.CreateObject("MilitaryIntelligence", "CardInstanceZones");
	}

	public static UI_CardInstanceZones CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CardInstanceZones).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46uk67ub", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		time = (GTextField)((GComponent)this).GetChild("time");
		string id = "ui://nfd5v46uk67ub".Replace("ui://", "") + "-" + ((GObject)time).id;
		((GObject)time).text = LanguagesManager.GetDesc(id);
		n8 = (GGraph)((GComponent)this).GetChild("n8");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id2 = "ui://nfd5v46uk67ub".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id2);
		content = (GTextField)((GComponent)this).GetChild("content");
		string id3 = "ui://nfd5v46uk67ub".Replace("ui://", "") + "-" + ((GObject)content).id;
		((GObject)content).text = LanguagesManager.GetDesc(id3);
		n13 = (GImage)((GComponent)this).GetChild("n13");
		treasureBtn = (GButton)((GComponent)this).GetChild("treasureBtn");
	}
}
