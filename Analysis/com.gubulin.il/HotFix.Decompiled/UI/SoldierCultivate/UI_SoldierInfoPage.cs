using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoldierInfoPage : GComponent
{
	public GImage back1;

	public GImage back2;

	public GTextField title;

	public UI_ExperienceProcessBar ExperienceProcessBar;

	public UI_UpSoldierLevel UpSoldierLevelBtn;

	public GTextField LevelNum_t;

	public GGraph LevelNum_tSpine;

	public GButton attackPropertyBtn;

	public GButton defensePropertyBtn;

	public GButton n146;

	public GGraph HealthNum_tSpine;

	public GTextField HealthNum_t;

	public GGraph AttackNum_tSpine;

	public GTextField AttackNum_t;

	public GGraph DefenceNum_tSpine;

	public GTextField DefenceNum_t;

	public GTextField attackTitle;

	public GTextField defenseTitle;

	public GTextField healthTitle;

	public GLoader attackLoader;

	public GLoader defenseLoader;

	public GLoader healthLoader;

	public UI_DetailedInfoBtn DetailedInfoBtn;

	public GImage n153;

	public GImage n154;

	public GImage n152;

	public GTextField n157;

	public GGroup skillTitleGroup;

	public GTextField specialityName;

	public GRichTextField specialityText;

	public GList SkillList;

	public const string URL = "ui://7dantnbionm22h";

	public static string Name = "UI_SoldierInfoPage";

	public static string GetURL()
	{
		return "ui://7dantnbionm22h";
	}

	public static UI_SoldierInfoPage CreateInstance()
	{
		return (UI_SoldierInfoPage)(object)UIPackage.CreateObject("SoldierCultivate", "SoldierInfoPage");
	}

	public static UI_SoldierInfoPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierInfoPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbionm22h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Expected O, but got Unknown
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Expected O, but got Unknown
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Expected O, but got Unknown
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back1 = (GImage)((GComponent)this).GetChild("back1");
		back2 = (GImage)((GComponent)this).GetChild("back2");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://7dantnbionm22h".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		ExperienceProcessBar = (UI_ExperienceProcessBar)(object)((GComponent)this).GetChild("ExperienceProcessBar");
		UpSoldierLevelBtn = (UI_UpSoldierLevel)(object)((GComponent)this).GetChild("UpSoldierLevelBtn");
		LevelNum_t = (GTextField)((GComponent)this).GetChild("LevelNum_t");
		LevelNum_tSpine = (GGraph)((GComponent)this).GetChild("LevelNum_tSpine");
		attackPropertyBtn = (GButton)((GComponent)this).GetChild("attackPropertyBtn");
		defensePropertyBtn = (GButton)((GComponent)this).GetChild("defensePropertyBtn");
		n146 = (GButton)((GComponent)this).GetChild("n146");
		HealthNum_tSpine = (GGraph)((GComponent)this).GetChild("HealthNum_tSpine");
		HealthNum_t = (GTextField)((GComponent)this).GetChild("HealthNum_t");
		AttackNum_tSpine = (GGraph)((GComponent)this).GetChild("AttackNum_tSpine");
		AttackNum_t = (GTextField)((GComponent)this).GetChild("AttackNum_t");
		DefenceNum_tSpine = (GGraph)((GComponent)this).GetChild("DefenceNum_tSpine");
		DefenceNum_t = (GTextField)((GComponent)this).GetChild("DefenceNum_t");
		attackTitle = (GTextField)((GComponent)this).GetChild("attackTitle");
		string id2 = "ui://7dantnbionm22h".Replace("ui://", "") + "-" + ((GObject)attackTitle).id;
		((GObject)attackTitle).text = LanguagesManager.GetDesc(id2);
		defenseTitle = (GTextField)((GComponent)this).GetChild("defenseTitle");
		string id3 = "ui://7dantnbionm22h".Replace("ui://", "") + "-" + ((GObject)defenseTitle).id;
		((GObject)defenseTitle).text = LanguagesManager.GetDesc(id3);
		healthTitle = (GTextField)((GComponent)this).GetChild("healthTitle");
		string id4 = "ui://7dantnbionm22h".Replace("ui://", "") + "-" + ((GObject)healthTitle).id;
		((GObject)healthTitle).text = LanguagesManager.GetDesc(id4);
		attackLoader = (GLoader)((GComponent)this).GetChild("attackLoader");
		defenseLoader = (GLoader)((GComponent)this).GetChild("defenseLoader");
		healthLoader = (GLoader)((GComponent)this).GetChild("healthLoader");
		DetailedInfoBtn = (UI_DetailedInfoBtn)(object)((GComponent)this).GetChild("DetailedInfoBtn");
		n153 = (GImage)((GComponent)this).GetChild("n153");
		n154 = (GImage)((GComponent)this).GetChild("n154");
		n152 = (GImage)((GComponent)this).GetChild("n152");
		n157 = (GTextField)((GComponent)this).GetChild("n157");
		string id5 = "ui://7dantnbionm22h".Replace("ui://", "") + "-" + ((GObject)n157).id;
		((GObject)n157).text = LanguagesManager.GetDesc(id5);
		skillTitleGroup = (GGroup)((GComponent)this).GetChild("skillTitleGroup");
		specialityName = (GTextField)((GComponent)this).GetChild("specialityName");
		string id6 = "ui://7dantnbionm22h".Replace("ui://", "") + "-" + ((GObject)specialityName).id;
		((GObject)specialityName).text = LanguagesManager.GetDesc(id6);
		specialityText = (GRichTextField)((GComponent)this).GetChild("specialityText");
		SkillList = (GList)((GComponent)this).GetChild("SkillList");
	}
}
