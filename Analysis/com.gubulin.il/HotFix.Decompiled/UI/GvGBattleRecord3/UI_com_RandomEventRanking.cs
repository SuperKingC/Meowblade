using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_RandomEventRanking : GComponent
{
	public Controller Type;

	public Controller BattleType;

	public GImage back;

	public GTextField n6;

	public GTextField n7;

	public GTextField n19;

	public GTextField n21;

	public GTextField n9;

	public GList UserRankingData;

	public UI_btn_CampaignCampSelect CampSelect;

	public GTextField n11;

	public GTextField n12;

	public GImage n13;

	public GTextField n14;

	public GTextField n16;

	public GTextField n20;

	public UI_btn_MyEventRank MyRankingData;

	public const string URL = "ui://b3fc6085phuh3r";

	public static string Name = "UI_com_RandomEventRanking";

	public static string GetURL()
	{
		return "ui://b3fc6085phuh3r";
	}

	public static UI_com_RandomEventRanking CreateInstance()
	{
		return (UI_com_RandomEventRanking)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_RandomEventRanking");
	}

	public static UI_com_RandomEventRanking CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RandomEventRanking).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085phuh3r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected O, but got Unknown
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		BattleType = ((GComponent)this).GetController("BattleType");
		back = (GImage)((GComponent)this).GetChild("back");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://b3fc6085phuh3r".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://b3fc6085phuh3r".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id3 = "ui://b3fc6085phuh3r".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id3);
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id4 = "ui://b3fc6085phuh3r".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id4);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id5 = "ui://b3fc6085phuh3r".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id5);
		UserRankingData = (GList)((GComponent)this).GetChild("UserRankingData");
		CampSelect = (UI_btn_CampaignCampSelect)(object)((GComponent)this).GetChild("CampSelect");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id6 = "ui://b3fc6085phuh3r".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id6);
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id7 = "ui://b3fc6085phuh3r".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id7);
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id8 = "ui://b3fc6085phuh3r".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id8);
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id9 = "ui://b3fc6085phuh3r".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id9);
		n20 = (GTextField)((GComponent)this).GetChild("n20");
		string id10 = "ui://b3fc6085phuh3r".Replace("ui://", "") + "-" + ((GObject)n20).id;
		((GObject)n20).text = LanguagesManager.GetDesc(id10);
		MyRankingData = (UI_btn_MyEventRank)(object)((GComponent)this).GetChild("MyRankingData");
	}
}
