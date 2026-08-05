using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MilitaryAFKAssistant;

public class UI_com_LabelPreparing : GComponent
{
	public Controller typeController;

	public Controller battleController;

	public Controller expanded;

	public Controller canChallenge;

	public GImage n0;

	public GImage n9;

	public GTextField n2;

	public GTextField n3;

	public GTextField ticketsTip;

	public GTextField n1;

	public GTextField n4;

	public GTextField n5;

	public GTextField n6;

	public GTextField n7;

	public GImage n10;

	public GImage n11;

	public GImage n12;

	public GGroup n13;

	public const string URL = "ui://8x5gc8j2sy9cm";

	public static string Name = "UI_com_LabelPreparing";

	public static string GetURL()
	{
		return "ui://8x5gc8j2sy9cm";
	}

	public static UI_com_LabelPreparing CreateInstance()
	{
		return (UI_com_LabelPreparing)(object)UIPackage.CreateObject("MilitaryAFKAssistant", "com_LabelPreparing");
	}

	public static UI_com_LabelPreparing CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LabelPreparing).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://8x5gc8j2sy9cm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected O, but got Unknown
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Expected O, but got Unknown
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		typeController = ((GComponent)this).GetController("typeController");
		battleController = ((GComponent)this).GetController("battleController");
		expanded = ((GComponent)this).GetController("expanded");
		canChallenge = ((GComponent)this).GetController("canChallenge");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id = "ui://8x5gc8j2sy9cm".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id);
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id2 = "ui://8x5gc8j2sy9cm".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id2);
		ticketsTip = (GTextField)((GComponent)this).GetChild("ticketsTip");
		string id3 = "ui://8x5gc8j2sy9cm".Replace("ui://", "") + "-" + ((GObject)ticketsTip).id;
		((GObject)ticketsTip).text = LanguagesManager.GetDesc(id3);
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id4 = "ui://8x5gc8j2sy9cm".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id4);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id5 = "ui://8x5gc8j2sy9cm".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id5);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id6 = "ui://8x5gc8j2sy9cm".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id6);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id7 = "ui://8x5gc8j2sy9cm".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id7);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id8 = "ui://8x5gc8j2sy9cm".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id8);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GGroup)((GComponent)this).GetChild("n13");
	}
}
