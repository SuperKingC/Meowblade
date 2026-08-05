using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_BrawlBattleResult : GComponent
{
	public Controller IsFinal;

	public Controller Claimed;

	public Controller isEmpty;

	public GImage Background;

	public GImage n6;

	public GList BrawlEventSettleInfos;

	public GButton Claim;

	public UI_btn_Close Close;

	public GTextField n3;

	public UI_btn_Calendar Calendar;

	public GTextField n7;

	public GTextField n9;

	public GTextField n10;

	public GImage n12;

	public GImage n13;

	public GImage n20;

	public GImage n14;

	public GImage n17;

	public GTextField n15;

	public GImage n16;

	public GGroup n21;

	public GGroup n18;

	public UI_btn_CampRankDetail CampRankDetail;

	public const string URL = "ui://hozu168rnq4c3l";

	public static string Name = "UI_com_BrawlBattleResult";

	public static string GetURL()
	{
		return "ui://hozu168rnq4c3l";
	}

	public static UI_com_BrawlBattleResult CreateInstance()
	{
		return (UI_com_BrawlBattleResult)(object)UIPackage.CreateObject("GvGBrawlFight", "com_BrawlBattleResult");
	}

	public static UI_com_BrawlBattleResult CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BrawlBattleResult).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rnq4c3l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected O, but got Unknown
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Expected O, but got Unknown
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsFinal = ((GComponent)this).GetController("IsFinal");
		Claimed = ((GComponent)this).GetController("Claimed");
		isEmpty = ((GComponent)this).GetController("isEmpty");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		BrawlEventSettleInfos = (GList)((GComponent)this).GetChild("BrawlEventSettleInfos");
		Claim = (GButton)((GComponent)this).GetChild("Claim");
		Close = (UI_btn_Close)(object)((GComponent)this).GetChild("Close");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://hozu168rnq4c3l".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		Calendar = (UI_btn_Calendar)(object)((GComponent)this).GetChild("Calendar");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://hozu168rnq4c3l".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id3 = "ui://hozu168rnq4c3l".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id3);
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id4 = "ui://hozu168rnq4c3l".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id4);
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id5 = "ui://hozu168rnq4c3l".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id5);
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n21 = (GGroup)((GComponent)this).GetChild("n21");
		n18 = (GGroup)((GComponent)this).GetChild("n18");
		CampRankDetail = (UI_btn_CampRankDetail)(object)((GComponent)this).GetChild("CampRankDetail");
	}
}
