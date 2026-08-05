using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_SpringFestivalPanel : GComponent
{
	public GGraph backC;

	public GGraph n1;

	public GImage n4;

	public GGraph n2;

	public GImage n3;

	public GGraph n33;

	public GTextField title;

	public GTextField n42;

	public GTextField date;

	public GImage n46;

	public GImage n45;

	public GImage n47;

	public GTextField n48;

	public GTextField n49;

	public GLoader item0;

	public GLoader item1;

	public GLoader item2;

	public GLoader item3;

	public GLoader item4;

	public GTextField n55;

	public GTextField n56;

	public GTextField n57;

	public GTextField n58;

	public GTextField n65;

	public GTextField n60;

	public GTextField n61;

	public GTextField n62;

	public GTextField n63;

	public GTextField n64;

	public UI_NianSpineCom NianSpineCom;

	public GButton captureBtn;

	public const string URL = "ui://29q48tv6iqfl2r";

	public static string Name = "UI_SpringFestivalPanel";

	public static string GetURL()
	{
		return "ui://29q48tv6iqfl2r";
	}

	public static UI_SpringFestivalPanel CreateInstance()
	{
		return (UI_SpringFestivalPanel)(object)UIPackage.CreateObject("GameActivity", "SpringFestivalPanel");
	}

	public static UI_SpringFestivalPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SpringFestivalPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6iqfl2r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected O, but got Unknown
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Expected O, but got Unknown
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Expected O, but got Unknown
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Expected O, but got Unknown
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Expected O, but got Unknown
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Expected O, but got Unknown
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Expected O, but got Unknown
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Expected O, but got Unknown
		//IL_05e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f1: Expected O, but got Unknown
		//IL_0652: Unknown result type (might be due to invalid IL or missing references)
		//IL_065c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		backC = (GGraph)((GComponent)this).GetChild("backC");
		n1 = (GGraph)((GComponent)this).GetChild("n1");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n2 = (GGraph)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n33 = (GGraph)((GComponent)this).GetChild("n33");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n42 = (GTextField)((GComponent)this).GetChild("n42");
		string id2 = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)n42).id;
		((GObject)n42).text = LanguagesManager.GetDesc(id2);
		date = (GTextField)((GComponent)this).GetChild("date");
		string id3 = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)date).id;
		((GObject)date).text = LanguagesManager.GetDesc(id3);
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n48 = (GTextField)((GComponent)this).GetChild("n48");
		string id4 = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)n48).id;
		((GObject)n48).text = LanguagesManager.GetDesc(id4);
		n49 = (GTextField)((GComponent)this).GetChild("n49");
		string id5 = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)n49).id;
		((GObject)n49).text = LanguagesManager.GetDesc(id5);
		item0 = (GLoader)((GComponent)this).GetChild("item0");
		item1 = (GLoader)((GComponent)this).GetChild("item1");
		item2 = (GLoader)((GComponent)this).GetChild("item2");
		item3 = (GLoader)((GComponent)this).GetChild("item3");
		item4 = (GLoader)((GComponent)this).GetChild("item4");
		n55 = (GTextField)((GComponent)this).GetChild("n55");
		string id6 = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)n55).id;
		((GObject)n55).text = LanguagesManager.GetDesc(id6);
		n56 = (GTextField)((GComponent)this).GetChild("n56");
		string id7 = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)n56).id;
		((GObject)n56).text = LanguagesManager.GetDesc(id7);
		n57 = (GTextField)((GComponent)this).GetChild("n57");
		string id8 = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)n57).id;
		((GObject)n57).text = LanguagesManager.GetDesc(id8);
		n58 = (GTextField)((GComponent)this).GetChild("n58");
		string id9 = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)n58).id;
		((GObject)n58).text = LanguagesManager.GetDesc(id9);
		n65 = (GTextField)((GComponent)this).GetChild("n65");
		string id10 = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)n65).id;
		((GObject)n65).text = LanguagesManager.GetDesc(id10);
		n60 = (GTextField)((GComponent)this).GetChild("n60");
		string id11 = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)n60).id;
		((GObject)n60).text = LanguagesManager.GetDesc(id11);
		n61 = (GTextField)((GComponent)this).GetChild("n61");
		string id12 = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)n61).id;
		((GObject)n61).text = LanguagesManager.GetDesc(id12);
		n62 = (GTextField)((GComponent)this).GetChild("n62");
		string id13 = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)n62).id;
		((GObject)n62).text = LanguagesManager.GetDesc(id13);
		n63 = (GTextField)((GComponent)this).GetChild("n63");
		string id14 = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)n63).id;
		((GObject)n63).text = LanguagesManager.GetDesc(id14);
		n64 = (GTextField)((GComponent)this).GetChild("n64");
		string id15 = "ui://29q48tv6iqfl2r".Replace("ui://", "") + "-" + ((GObject)n64).id;
		((GObject)n64).text = LanguagesManager.GetDesc(id15);
		NianSpineCom = (UI_NianSpineCom)(object)((GComponent)this).GetChild("NianSpineCom");
		captureBtn = (GButton)((GComponent)this).GetChild("captureBtn");
	}
}
