using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_CampaignInfoDialog : GComponent
{
	public Controller Type;

	public Controller HasEventRanking;

	public Controller BattleState;

	public GImage back;

	public GTextField n5;

	public GTextField n6;

	public GTextField n7;

	public GTextField n8;

	public GTextField n9;

	public UI_btn_CheckDetail CheckDetail;

	public UI_btn_CheckEventRanking CheckEventRanking;

	public GList UserRankingData;

	public UI_btn_CampaignMyData MyRankingData;

	public UI_btn_CampaignCampSelect CampSelect;

	public GTextField n11;

	public GGroup completeGroup;

	public GTextField n12;

	public GImage n13;

	public GTextField n14;

	public GTextField n16;

	public UI_btn_Help Help;

	public GTextField n18;

	public const string URL = "ui://b3fc6085owu55";

	public static string Name = "UI_com_CampaignInfoDialog";

	public static string GetURL()
	{
		return "ui://b3fc6085owu55";
	}

	public static UI_com_CampaignInfoDialog CreateInstance()
	{
		return (UI_com_CampaignInfoDialog)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_CampaignInfoDialog");
	}

	public static UI_com_CampaignInfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_CampaignInfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085owu55", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Expected O, but got Unknown
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected O, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected O, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Expected O, but got Unknown
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected O, but got Unknown
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		HasEventRanking = ((GComponent)this).GetController("HasEventRanking");
		BattleState = ((GComponent)this).GetController("BattleState");
		back = (GImage)((GComponent)this).GetChild("back");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://b3fc6085owu55".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id2 = "ui://b3fc6085owu55".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id2);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id3 = "ui://b3fc6085owu55".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id3);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id4 = "ui://b3fc6085owu55".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id4);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id5 = "ui://b3fc6085owu55".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id5);
		CheckDetail = (UI_btn_CheckDetail)(object)((GComponent)this).GetChild("CheckDetail");
		CheckEventRanking = (UI_btn_CheckEventRanking)(object)((GComponent)this).GetChild("CheckEventRanking");
		UserRankingData = (GList)((GComponent)this).GetChild("UserRankingData");
		MyRankingData = (UI_btn_CampaignMyData)(object)((GComponent)this).GetChild("MyRankingData");
		CampSelect = (UI_btn_CampaignCampSelect)(object)((GComponent)this).GetChild("CampSelect");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id6 = "ui://b3fc6085owu55".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id6);
		completeGroup = (GGroup)((GComponent)this).GetChild("completeGroup");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id7 = "ui://b3fc6085owu55".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id7);
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id8 = "ui://b3fc6085owu55".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id8);
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id9 = "ui://b3fc6085owu55".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id9);
		Help = (UI_btn_Help)(object)((GComponent)this).GetChild("Help");
		n18 = (GTextField)((GComponent)this).GetChild("n18");
		string id10 = "ui://b3fc6085owu55".Replace("ui://", "") + "-" + ((GObject)n18).id;
		((GObject)n18).text = LanguagesManager.GetDesc(id10);
	}
}
