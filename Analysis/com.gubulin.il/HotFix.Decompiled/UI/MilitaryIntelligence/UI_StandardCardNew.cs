using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryIntelligence;

public class UI_StandardCardNew : GButton
{
	public Controller button;

	public Controller TypeController;

	public Controller StatusController;

	public UI_light1 n46;

	public UI_light2 n44;

	public GGroup bgFX;

	public GImage icon0;

	public GImage n30;

	public GImage n31;

	public GImage n36;

	public GImage n38;

	public GImage LimitTimeOpenTip;

	public GImage title3;

	public GTextField time;

	public GGraph n33;

	public GTextField tip2nd;

	public GGroup timeAndCase;

	public GGraph n39;

	public GTextField tip3rd;

	public GGroup extraCase;

	public GTextField title;

	public GTextField content;

	public GButton treasureBtn;

	public GImage newIcon;

	public GButton ExclamationTipBtn;

	public GGraph Cover;

	public const string URL = "ui://nfd5v46uhbasr";

	public static string Name = "UI_StandardCardNew";

	public static string GetURL()
	{
		return "ui://nfd5v46uhbasr";
	}

	public static UI_StandardCardNew CreateInstance()
	{
		return (UI_StandardCardNew)(object)UIPackage.CreateObject("MilitaryIntelligence", "StandardCardNew");
	}

	public static UI_StandardCardNew CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StandardCardNew).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://nfd5v46uhbasr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		TypeController = ((GComponent)this).GetController("TypeController");
		StatusController = ((GComponent)this).GetController("StatusController");
		n46 = (UI_light1)(object)((GComponent)this).GetChild("n46");
		n44 = (UI_light2)(object)((GComponent)this).GetChild("n44");
		bgFX = (GGroup)((GComponent)this).GetChild("bgFX");
		icon0 = (GImage)((GComponent)this).GetChild("icon0");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		LimitTimeOpenTip = (GImage)((GComponent)this).GetChild("LimitTimeOpenTip");
		title3 = (GImage)((GComponent)this).GetChild("title3");
		time = (GTextField)((GComponent)this).GetChild("time");
		n33 = (GGraph)((GComponent)this).GetChild("n33");
		tip2nd = (GTextField)((GComponent)this).GetChild("tip2nd");
		timeAndCase = (GGroup)((GComponent)this).GetChild("timeAndCase");
		n39 = (GGraph)((GComponent)this).GetChild("n39");
		tip3rd = (GTextField)((GComponent)this).GetChild("tip3rd");
		extraCase = (GGroup)((GComponent)this).GetChild("extraCase");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://nfd5v46uhbasr".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		content = (GTextField)((GComponent)this).GetChild("content");
		string id2 = "ui://nfd5v46uhbasr".Replace("ui://", "") + "-" + ((GObject)content).id;
		((GObject)content).text = LanguagesManager.GetDesc(id2);
		treasureBtn = (GButton)((GComponent)this).GetChild("treasureBtn");
		newIcon = (GImage)((GComponent)this).GetChild("newIcon");
		ExclamationTipBtn = (GButton)((GComponent)this).GetChild("ExclamationTipBtn");
		Cover = (GGraph)((GComponent)this).GetChild("Cover");
	}
}
