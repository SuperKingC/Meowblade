using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_CommonPool : GButton
{
	public GImage n0;

	public GImage n26;

	public GImage n22;

	public GGraph n7;

	public UI_singleBtn singleBtn;

	public UI_runningBtn runningBtn;

	public GImage n12;

	public GLoader singleTicketIcon;

	public GTextField singleCost;

	public GImage n10;

	public GLoader runningTicketIcon;

	public GTextField runningCost;

	public const string URL = "ui://avplaivdo5ta2u";

	public static string Name = "UI_CommonPool";

	public static string GetURL()
	{
		return "ui://avplaivdo5ta2u";
	}

	public static UI_CommonPool CreateInstance()
	{
		return (UI_CommonPool)(object)UIPackage.CreateObject("Contract", "CommonPool");
	}

	public static UI_CommonPool CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CommonPool).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdo5ta2u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		singleBtn = (UI_singleBtn)(object)((GComponent)this).GetChild("singleBtn");
		runningBtn = (UI_runningBtn)(object)((GComponent)this).GetChild("runningBtn");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		singleTicketIcon = (GLoader)((GComponent)this).GetChild("singleTicketIcon");
		singleCost = (GTextField)((GComponent)this).GetChild("singleCost");
		string id = "ui://avplaivdo5ta2u".Replace("ui://", "") + "-" + ((GObject)singleCost).id;
		((GObject)singleCost).text = LanguagesManager.GetDesc(id);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		runningTicketIcon = (GLoader)((GComponent)this).GetChild("runningTicketIcon");
		runningCost = (GTextField)((GComponent)this).GetChild("runningCost");
		string id2 = "ui://avplaivdo5ta2u".Replace("ui://", "") + "-" + ((GObject)runningCost).id;
		((GObject)runningCost).text = LanguagesManager.GetDesc(id2);
	}
}
