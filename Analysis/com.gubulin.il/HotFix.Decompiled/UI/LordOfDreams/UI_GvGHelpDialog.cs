using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_GvGHelpDialog : GComponent
{
	public GImage Back;

	public GTextField ScoreMultiplierText;

	public GTextField n72;

	public GGraph n73;

	public GTextField n74;

	public GImage n75;

	public GTextField n76;

	public GImage n77;

	public GTextField n78;

	public GTextField n79;

	public GTextField n80;

	public GImage n81;

	public GImage n82;

	public GImage n83;

	public GImage n84;

	public GImage n85;

	public GImage n86;

	public GTextField n87;

	public GTextField n88;

	public GTextField n89;

	public GTextField n90;

	public GTextField n91;

	public GTextField n92;

	public GTextField n93;

	public GTextField n94;

	public GTextField n95;

	public GTextField n96;

	public GTextField n97;

	public GTextField n98;

	public GTextField n99;

	public GTextField n100;

	public const string URL = "ui://0i520nzmpx1kock";

	public static string Name = "UI_GvGHelpDialog";

	public static string GetURL()
	{
		return "ui://0i520nzmpx1kock";
	}

	public static UI_GvGHelpDialog CreateInstance()
	{
		return (UI_GvGHelpDialog)(object)UIPackage.CreateObject("LordOfDreams", "GvGHelpDialog");
	}

	public static UI_GvGHelpDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGHelpDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmpx1kock", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Expected O, but got Unknown
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected O, but got Unknown
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected O, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected O, but got Unknown
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected O, but got Unknown
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Expected O, but got Unknown
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Expected O, but got Unknown
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Expected O, but got Unknown
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Expected O, but got Unknown
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Expected O, but got Unknown
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05af: Expected O, but got Unknown
		//IL_05fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0604: Expected O, but got Unknown
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0659: Expected O, but got Unknown
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Expected O, but got Unknown
		//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0703: Expected O, but got Unknown
		//IL_074e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0758: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Back = (GImage)((GComponent)this).GetChild("Back");
		ScoreMultiplierText = (GTextField)((GComponent)this).GetChild("ScoreMultiplierText");
		n72 = (GTextField)((GComponent)this).GetChild("n72");
		string id = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n72).id;
		((GObject)n72).text = LanguagesManager.GetDesc(id);
		n73 = (GGraph)((GComponent)this).GetChild("n73");
		n74 = (GTextField)((GComponent)this).GetChild("n74");
		string id2 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n74).id;
		((GObject)n74).text = LanguagesManager.GetDesc(id2);
		n75 = (GImage)((GComponent)this).GetChild("n75");
		n76 = (GTextField)((GComponent)this).GetChild("n76");
		string id3 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n76).id;
		((GObject)n76).text = LanguagesManager.GetDesc(id3);
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n78 = (GTextField)((GComponent)this).GetChild("n78");
		string id4 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n78).id;
		((GObject)n78).text = LanguagesManager.GetDesc(id4);
		n79 = (GTextField)((GComponent)this).GetChild("n79");
		string id5 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n79).id;
		((GObject)n79).text = LanguagesManager.GetDesc(id5);
		n80 = (GTextField)((GComponent)this).GetChild("n80");
		string id6 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n80).id;
		((GObject)n80).text = LanguagesManager.GetDesc(id6);
		n81 = (GImage)((GComponent)this).GetChild("n81");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n83 = (GImage)((GComponent)this).GetChild("n83");
		n84 = (GImage)((GComponent)this).GetChild("n84");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		n86 = (GImage)((GComponent)this).GetChild("n86");
		n87 = (GTextField)((GComponent)this).GetChild("n87");
		string id7 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n87).id;
		((GObject)n87).text = LanguagesManager.GetDesc(id7);
		n88 = (GTextField)((GComponent)this).GetChild("n88");
		string id8 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n88).id;
		((GObject)n88).text = LanguagesManager.GetDesc(id8);
		n89 = (GTextField)((GComponent)this).GetChild("n89");
		string id9 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n89).id;
		((GObject)n89).text = LanguagesManager.GetDesc(id9);
		n90 = (GTextField)((GComponent)this).GetChild("n90");
		string id10 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n90).id;
		((GObject)n90).text = LanguagesManager.GetDesc(id10);
		n91 = (GTextField)((GComponent)this).GetChild("n91");
		string id11 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n91).id;
		((GObject)n91).text = LanguagesManager.GetDesc(id11);
		n92 = (GTextField)((GComponent)this).GetChild("n92");
		string id12 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n92).id;
		((GObject)n92).text = LanguagesManager.GetDesc(id12);
		n93 = (GTextField)((GComponent)this).GetChild("n93");
		string id13 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n93).id;
		((GObject)n93).text = LanguagesManager.GetDesc(id13);
		n94 = (GTextField)((GComponent)this).GetChild("n94");
		string id14 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n94).id;
		((GObject)n94).text = LanguagesManager.GetDesc(id14);
		n95 = (GTextField)((GComponent)this).GetChild("n95");
		string id15 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n95).id;
		((GObject)n95).text = LanguagesManager.GetDesc(id15);
		n96 = (GTextField)((GComponent)this).GetChild("n96");
		string id16 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n96).id;
		((GObject)n96).text = LanguagesManager.GetDesc(id16);
		n97 = (GTextField)((GComponent)this).GetChild("n97");
		string id17 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n97).id;
		((GObject)n97).text = LanguagesManager.GetDesc(id17);
		n98 = (GTextField)((GComponent)this).GetChild("n98");
		string id18 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n98).id;
		((GObject)n98).text = LanguagesManager.GetDesc(id18);
		n99 = (GTextField)((GComponent)this).GetChild("n99");
		string id19 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n99).id;
		((GObject)n99).text = LanguagesManager.GetDesc(id19);
		n100 = (GTextField)((GComponent)this).GetChild("n100");
		string id20 = "ui://0i520nzmpx1kock".Replace("ui://", "") + "-" + ((GObject)n100).id;
		((GObject)n100).text = LanguagesManager.GetDesc(id20);
	}
}
