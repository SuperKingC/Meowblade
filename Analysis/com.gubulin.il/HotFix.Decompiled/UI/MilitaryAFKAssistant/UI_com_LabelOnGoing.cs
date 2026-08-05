using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryAFKAssistant;

public class UI_com_LabelOnGoing : GComponent
{
	public Controller typeController;

	public Controller battleController;

	public Controller expanded;

	public Controller canChallenge;

	public Controller stateController;

	public GImage n0;

	public GImage n14;

	public GImage n9;

	public GLoader n15;

	public GTextField levelName;

	public GList stars;

	public GGroup n28;

	public GTextField n27;

	public GImage n23;

	public GTextField n1;

	public GTextField n4;

	public GTextField n5;

	public GTextField n6;

	public GTextField n7;

	public UI_btn_01 n17;

	public GImage n10;

	public GImage n11;

	public GImage n12;

	public GGroup n13;

	public GTextField n3;

	public GTextField ticketsTip;

	public GGroup n19;

	public GTextField totalChallengeTip;

	public GImage n34;

	public UI_dec_01 n31;

	public GTextField n33;

	public GGroup n32;

	public GImage n30;

	public const string URL = "ui://8x5gc8j2sy9cn";

	public static string Name = "UI_com_LabelOnGoing";

	public static string GetURL()
	{
		return "ui://8x5gc8j2sy9cn";
	}

	public static UI_com_LabelOnGoing CreateInstance()
	{
		return (UI_com_LabelOnGoing)(object)UIPackage.CreateObject("MilitaryAFKAssistant", "com_LabelOnGoing");
	}

	public static UI_com_LabelOnGoing CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LabelOnGoing).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8x5gc8j2sy9cn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected O, but got Unknown
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Expected O, but got Unknown
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Expected O, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected O, but got Unknown
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Expected O, but got Unknown
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected O, but got Unknown
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected O, but got Unknown
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Expected O, but got Unknown
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Expected O, but got Unknown
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Expected O, but got Unknown
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Expected O, but got Unknown
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Expected O, but got Unknown
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		typeController = ((GComponent)this).GetController("typeController");
		battleController = ((GComponent)this).GetController("battleController");
		expanded = ((GComponent)this).GetController("expanded");
		canChallenge = ((GComponent)this).GetController("canChallenge");
		stateController = ((GComponent)this).GetController("stateController");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n15 = (GLoader)((GComponent)this).GetChild("n15");
		levelName = (GTextField)((GComponent)this).GetChild("levelName");
		stars = (GList)((GComponent)this).GetChild("stars");
		n28 = (GGroup)((GComponent)this).GetChild("n28");
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id = "ui://8x5gc8j2sy9cn".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id);
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id2 = "ui://8x5gc8j2sy9cn".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id2);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id3 = "ui://8x5gc8j2sy9cn".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id3);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id4 = "ui://8x5gc8j2sy9cn".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id4);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id5 = "ui://8x5gc8j2sy9cn".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id5);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id6 = "ui://8x5gc8j2sy9cn".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id6);
		n17 = (UI_btn_01)(object)((GComponent)this).GetChild("n17");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GGroup)((GComponent)this).GetChild("n13");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id7 = "ui://8x5gc8j2sy9cn".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id7);
		ticketsTip = (GTextField)((GComponent)this).GetChild("ticketsTip");
		string id8 = "ui://8x5gc8j2sy9cn".Replace("ui://", "") + "-" + ((GObject)ticketsTip).id;
		((GObject)ticketsTip).text = LanguagesManager.GetDesc(id8);
		n19 = (GGroup)((GComponent)this).GetChild("n19");
		totalChallengeTip = (GTextField)((GComponent)this).GetChild("totalChallengeTip");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n31 = (UI_dec_01)(object)((GComponent)this).GetChild("n31");
		n33 = (GTextField)((GComponent)this).GetChild("n33");
		string id9 = "ui://8x5gc8j2sy9cn".Replace("ui://", "") + "-" + ((GObject)n33).id;
		((GObject)n33).text = LanguagesManager.GetDesc(id9);
		n32 = (GGroup)((GComponent)this).GetChild("n32");
		n30 = (GImage)((GComponent)this).GetChild("n30");
	}
}
