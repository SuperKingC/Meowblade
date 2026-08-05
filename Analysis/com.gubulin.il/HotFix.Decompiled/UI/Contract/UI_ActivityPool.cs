using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_ActivityPool : GButton
{
	public Controller Type;

	public GImage n0;

	public GImage n20;

	public GImage n18;

	public GImage n3;

	public GTextField time;

	public GGraph n5;

	public UI_singleBtn singleBtn;

	public UI_runningBtn runningBtn;

	public GImage n7;

	public GLoader singleTicketIcon;

	public GTextField singleCost;

	public GImage n10;

	public GLoader runningTicketIcon;

	public GTextField runningCost;

	public const string URL = "ui://avplaivdo5ta2v";

	public static string Name = "UI_ActivityPool";

	public static string GetURL()
	{
		return "ui://avplaivdo5ta2v";
	}

	public static UI_ActivityPool CreateInstance()
	{
		return (UI_ActivityPool)(object)UIPackage.CreateObject("Contract", "ActivityPool");
	}

	public static UI_ActivityPool CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ActivityPool).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdo5ta2v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		time = (GTextField)((GComponent)this).GetChild("time");
		string id = "ui://avplaivdo5ta2v".Replace("ui://", "") + "-" + ((GObject)time).id;
		((GObject)time).text = LanguagesManager.GetDesc(id);
		n5 = (GGraph)((GComponent)this).GetChild("n5");
		singleBtn = (UI_singleBtn)(object)((GComponent)this).GetChild("singleBtn");
		runningBtn = (UI_runningBtn)(object)((GComponent)this).GetChild("runningBtn");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		singleTicketIcon = (GLoader)((GComponent)this).GetChild("singleTicketIcon");
		singleCost = (GTextField)((GComponent)this).GetChild("singleCost");
		string id2 = "ui://avplaivdo5ta2v".Replace("ui://", "") + "-" + ((GObject)singleCost).id;
		((GObject)singleCost).text = LanguagesManager.GetDesc(id2);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		runningTicketIcon = (GLoader)((GComponent)this).GetChild("runningTicketIcon");
		runningCost = (GTextField)((GComponent)this).GetChild("runningCost");
		string id3 = "ui://avplaivdo5ta2v".Replace("ui://", "") + "-" + ((GObject)runningCost).id;
		((GObject)runningCost).text = LanguagesManager.GetDesc(id3);
	}
}
