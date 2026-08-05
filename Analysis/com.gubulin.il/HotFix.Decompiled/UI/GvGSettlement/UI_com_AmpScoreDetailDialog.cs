using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_com_AmpScoreDetailDialog : GComponent
{
	public GImage back;

	public UI_btn_Close CloseBtn;

	public GImage n42;

	public GTextField title;

	public GList ScoreList;

	public GTextField n9;

	public GTextField n10;

	public GTextField n11;

	public GImage n44;

	public GTextField n12;

	public GTextField Score;

	public GGroup n15;

	public GImage n17;

	public GTextField n18;

	public GList BonusList;

	public GImage n21;

	public GImage n23;

	public GTextField n22;

	public GImage n30;

	public GImage n41;

	public GTextField n29;

	public GTextField n24;

	public GTextField n26;

	public GImage n50;

	public GImage n47;

	public GImage n48;

	public GTextField n31;

	public GTextField n32;

	public GTextField n33;

	public GTextField n35;

	public GTextField n36;

	public GTextField n37;

	public GTextField n38;

	public GTextField n39;

	public GImage n43;

	public GRichTextField n51;

	public GLoader n52;

	public const string URL = "ui://91jxdrkacgcr30";

	public static string Name = "UI_com_AmpScoreDetailDialog";

	public static string GetURL()
	{
		return "ui://91jxdrkacgcr30";
	}

	public static UI_com_AmpScoreDetailDialog CreateInstance()
	{
		return (UI_com_AmpScoreDetailDialog)(object)UIPackage.CreateObject("GvGSettlement", "com_AmpScoreDetailDialog");
	}

	public static UI_com_AmpScoreDetailDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AmpScoreDetailDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkacgcr30", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
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
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Expected O, but got Unknown
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected O, but got Unknown
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected O, but got Unknown
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Expected O, but got Unknown
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Expected O, but got Unknown
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Expected O, but got Unknown
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Expected O, but got Unknown
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c9: Expected O, but got Unknown
		//IL_0514: Unknown result type (might be due to invalid IL or missing references)
		//IL_051e: Expected O, but got Unknown
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Expected O, but got Unknown
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c8: Expected O, but got Unknown
		//IL_0613: Unknown result type (might be due to invalid IL or missing references)
		//IL_061d: Expected O, but got Unknown
		//IL_0668: Unknown result type (might be due to invalid IL or missing references)
		//IL_0672: Expected O, but got Unknown
		//IL_06bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c7: Expected O, but got Unknown
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_071c: Expected O, but got Unknown
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Expected O, but got Unknown
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0787: Expected O, but got Unknown
		//IL_07d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dc: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		CloseBtn = (UI_btn_Close)(object)((GComponent)this).GetChild("CloseBtn");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		ScoreList = (GList)((GComponent)this).GetChild("ScoreList");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id2 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id2);
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id3 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id3);
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id4 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id4);
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id5 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id5);
		Score = (GTextField)((GComponent)this).GetChild("Score");
		n15 = (GGroup)((GComponent)this).GetChild("n15");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GTextField)((GComponent)this).GetChild("n18");
		string id6 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n18).id;
		((GObject)n18).text = LanguagesManager.GetDesc(id6);
		BonusList = (GList)((GComponent)this).GetChild("BonusList");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id7 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id7);
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id8 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id8);
		n24 = (GTextField)((GComponent)this).GetChild("n24");
		string id9 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n24).id;
		((GObject)n24).text = LanguagesManager.GetDesc(id9);
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id10 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id10);
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n31 = (GTextField)((GComponent)this).GetChild("n31");
		string id11 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n31).id;
		((GObject)n31).text = LanguagesManager.GetDesc(id11);
		n32 = (GTextField)((GComponent)this).GetChild("n32");
		string id12 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n32).id;
		((GObject)n32).text = LanguagesManager.GetDesc(id12);
		n33 = (GTextField)((GComponent)this).GetChild("n33");
		string id13 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n33).id;
		((GObject)n33).text = LanguagesManager.GetDesc(id13);
		n35 = (GTextField)((GComponent)this).GetChild("n35");
		string id14 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n35).id;
		((GObject)n35).text = LanguagesManager.GetDesc(id14);
		n36 = (GTextField)((GComponent)this).GetChild("n36");
		string id15 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n36).id;
		((GObject)n36).text = LanguagesManager.GetDesc(id15);
		n37 = (GTextField)((GComponent)this).GetChild("n37");
		string id16 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n37).id;
		((GObject)n37).text = LanguagesManager.GetDesc(id16);
		n38 = (GTextField)((GComponent)this).GetChild("n38");
		string id17 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n38).id;
		((GObject)n38).text = LanguagesManager.GetDesc(id17);
		n39 = (GTextField)((GComponent)this).GetChild("n39");
		string id18 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n39).id;
		((GObject)n39).text = LanguagesManager.GetDesc(id18);
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n51 = (GRichTextField)((GComponent)this).GetChild("n51");
		string id19 = "ui://91jxdrkacgcr30".Replace("ui://", "") + "-" + ((GObject)n51).id;
		((GObject)n51).text = LanguagesManager.GetDesc(id19);
		n52 = (GLoader)((GComponent)this).GetChild("n52");
	}
}
