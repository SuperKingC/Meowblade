using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_DefensiveLeftBack : GComponent
{
	public Controller PageController;

	public GImage n88;

	public GImage n175;

	public GImage n177;

	public GImage n178;

	public GGraph n179;

	public GGraph n180;

	public GGroup n186;

	public GImage n163;

	public GImage n150;

	public GImage n142;

	public GTextField DefensiveActivityTitle;

	public GGroup DefensiveName;

	public GTextField MapName;

	public GTextField difficulty;

	public GTextField enemyNum;

	public GTextField levelIntroduction;

	public UI_OffensiveInstanceZonesLevel InstanceZonesLevel;

	public UI_MakeWar MakeWarBtn;

	public GList classListCopy;

	public GList classList;

	public GGroup n155;

	public GImage iconBack;

	public GLoader mainRewardIcon;

	public GRichTextField mainRewardNum;

	public GImage n181;

	public GImage n183;

	public GImage n184;

	public GImage n185;

	public GList OffensiveRewardList;

	public GGroup details;

	public GGraph n173;

	public GGraph n174;

	public GImage n172;

	public GTextField n168;

	public GTextField n169;

	public GTextField OffensiveTip1st;

	public GTextField DefensiveIntroduction;

	public GTextField DefensiveRemainingTime;

	public GLoader DefensiveMapIcon;

	public GList DefensiveSkillList;

	public UI_SkillBtnOutside DefensiveSpecialSkill;

	public UI_showPicture showPicture;

	public GImage BossTitle;

	public GTextField BossName;

	public UI_ClearStagesProgress ClearStagesProgress;

	public UI_PropetryLock quickBtn;

	public const string URL = "ui://f4wr270ric7j2y";

	public static string Name = "UI_DefensiveLeftBack";

	public static string GetURL()
	{
		return "ui://f4wr270ric7j2y";
	}

	public static UI_DefensiveLeftBack CreateInstance()
	{
		return (UI_DefensiveLeftBack)(object)UIPackage.CreateObject("InstanceZones", "DefensiveLeftBack");
	}

	public static UI_DefensiveLeftBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DefensiveLeftBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270ric7j2y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Expected O, but got Unknown
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected O, but got Unknown
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected O, but got Unknown
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected O, but got Unknown
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Expected O, but got Unknown
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Expected O, but got Unknown
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected O, but got Unknown
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Expected O, but got Unknown
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b5: Expected O, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Expected O, but got Unknown
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f7: Expected O, but got Unknown
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Expected O, but got Unknown
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Expected O, but got Unknown
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Expected O, but got Unknown
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Expected O, but got Unknown
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Expected O, but got Unknown
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f9: Expected O, but got Unknown
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_050f: Expected O, but got Unknown
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Expected O, but got Unknown
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Expected O, but got Unknown
		//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Expected O, but got Unknown
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d2: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		n88 = (GImage)((GComponent)this).GetChild("n88");
		n175 = (GImage)((GComponent)this).GetChild("n175");
		n177 = (GImage)((GComponent)this).GetChild("n177");
		n178 = (GImage)((GComponent)this).GetChild("n178");
		n179 = (GGraph)((GComponent)this).GetChild("n179");
		n180 = (GGraph)((GComponent)this).GetChild("n180");
		n186 = (GGroup)((GComponent)this).GetChild("n186");
		n163 = (GImage)((GComponent)this).GetChild("n163");
		n150 = (GImage)((GComponent)this).GetChild("n150");
		n142 = (GImage)((GComponent)this).GetChild("n142");
		DefensiveActivityTitle = (GTextField)((GComponent)this).GetChild("DefensiveActivityTitle");
		string id = "ui://f4wr270ric7j2y".Replace("ui://", "") + "-" + ((GObject)DefensiveActivityTitle).id;
		((GObject)DefensiveActivityTitle).text = LanguagesManager.GetDesc(id);
		DefensiveName = (GGroup)((GComponent)this).GetChild("DefensiveName");
		MapName = (GTextField)((GComponent)this).GetChild("MapName");
		string id2 = "ui://f4wr270ric7j2y".Replace("ui://", "") + "-" + ((GObject)MapName).id;
		((GObject)MapName).text = LanguagesManager.GetDesc(id2);
		difficulty = (GTextField)((GComponent)this).GetChild("difficulty");
		string id3 = "ui://f4wr270ric7j2y".Replace("ui://", "") + "-" + ((GObject)difficulty).id;
		((GObject)difficulty).text = LanguagesManager.GetDesc(id3);
		enemyNum = (GTextField)((GComponent)this).GetChild("enemyNum");
		string id4 = "ui://f4wr270ric7j2y".Replace("ui://", "") + "-" + ((GObject)enemyNum).id;
		((GObject)enemyNum).text = LanguagesManager.GetDesc(id4);
		levelIntroduction = (GTextField)((GComponent)this).GetChild("levelIntroduction");
		string id5 = "ui://f4wr270ric7j2y".Replace("ui://", "") + "-" + ((GObject)levelIntroduction).id;
		((GObject)levelIntroduction).text = LanguagesManager.GetDesc(id5);
		InstanceZonesLevel = (UI_OffensiveInstanceZonesLevel)(object)((GComponent)this).GetChild("InstanceZonesLevel");
		MakeWarBtn = (UI_MakeWar)(object)((GComponent)this).GetChild("MakeWarBtn");
		classListCopy = (GList)((GComponent)this).GetChild("classListCopy");
		classList = (GList)((GComponent)this).GetChild("classList");
		n155 = (GGroup)((GComponent)this).GetChild("n155");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		mainRewardIcon = (GLoader)((GComponent)this).GetChild("mainRewardIcon");
		mainRewardNum = (GRichTextField)((GComponent)this).GetChild("mainRewardNum");
		n181 = (GImage)((GComponent)this).GetChild("n181");
		n183 = (GImage)((GComponent)this).GetChild("n183");
		n184 = (GImage)((GComponent)this).GetChild("n184");
		n185 = (GImage)((GComponent)this).GetChild("n185");
		OffensiveRewardList = (GList)((GComponent)this).GetChild("OffensiveRewardList");
		details = (GGroup)((GComponent)this).GetChild("details");
		n173 = (GGraph)((GComponent)this).GetChild("n173");
		n174 = (GGraph)((GComponent)this).GetChild("n174");
		n172 = (GImage)((GComponent)this).GetChild("n172");
		n168 = (GTextField)((GComponent)this).GetChild("n168");
		string id6 = "ui://f4wr270ric7j2y".Replace("ui://", "") + "-" + ((GObject)n168).id;
		((GObject)n168).text = LanguagesManager.GetDesc(id6);
		n169 = (GTextField)((GComponent)this).GetChild("n169");
		string id7 = "ui://f4wr270ric7j2y".Replace("ui://", "") + "-" + ((GObject)n169).id;
		((GObject)n169).text = LanguagesManager.GetDesc(id7);
		OffensiveTip1st = (GTextField)((GComponent)this).GetChild("OffensiveTip1st");
		DefensiveIntroduction = (GTextField)((GComponent)this).GetChild("DefensiveIntroduction");
		DefensiveRemainingTime = (GTextField)((GComponent)this).GetChild("DefensiveRemainingTime");
		string id8 = "ui://f4wr270ric7j2y".Replace("ui://", "") + "-" + ((GObject)DefensiveRemainingTime).id;
		((GObject)DefensiveRemainingTime).text = LanguagesManager.GetDesc(id8);
		DefensiveMapIcon = (GLoader)((GComponent)this).GetChild("DefensiveMapIcon");
		DefensiveSkillList = (GList)((GComponent)this).GetChild("DefensiveSkillList");
		DefensiveSpecialSkill = (UI_SkillBtnOutside)(object)((GComponent)this).GetChild("DefensiveSpecialSkill");
		showPicture = (UI_showPicture)(object)((GComponent)this).GetChild("showPicture");
		BossTitle = (GImage)((GComponent)this).GetChild("BossTitle");
		BossName = (GTextField)((GComponent)this).GetChild("BossName");
		ClearStagesProgress = (UI_ClearStagesProgress)(object)((GComponent)this).GetChild("ClearStagesProgress");
		quickBtn = (UI_PropetryLock)(object)((GComponent)this).GetChild("quickBtn");
	}
}
