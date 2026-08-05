using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_ExperienceDialog : GComponent
{
	public Controller Status;

	public Controller LevelController;

	public GGraph jieduan;

	public GImage potionListBack;

	public GGraph n55;

	public GImage n12;

	public GImage n13;

	public GImage n14;

	public GTextField healthTitle;

	public GTextField defenseTitle;

	public GTextField attackTitle;

	public GTextField curAttack;

	public GTextField curHealth;

	public GTextField curDefense;

	public GTextField nextAttack;

	public GTextField nextHealth;

	public GTextField nextDefense;

	public GImage n24;

	public GImage n25;

	public GImage n26;

	public GGraph line1;

	public GTextField n32;

	public GImage n34;

	public GImage n54;

	public GGraph line2;

	public GList potionList;

	public GButton ExclamationMarkBtn;

	public GButton UpgradeBtn;

	public GButton QuickUpgradeBtn;

	public GGraph line3;

	public GGraph curAttackSfxBack;

	public GGraph nextAttackSfxBack;

	public GGraph curDefenseSfxBack;

	public GGraph nextDefenseSfxBack;

	public GGraph curHealthSfxBack;

	public GGraph nextHealthSfxBack;

	public GTextField cur;

	public GTextField next;

	public UI_CurNum CurNum;

	public UI_NextNum NextNum;

	public Transition Breath;

	public Transition UpdateNumContent;

	public const string URL = "ui://7dantnbio4ktt7j";

	public static string Name = "UI_ExperienceDialog";

	public static string GetURL()
	{
		return "ui://7dantnbio4ktt7j";
	}

	public static UI_ExperienceDialog CreateInstance()
	{
		return (UI_ExperienceDialog)(object)UIPackage.CreateObject("SoldierCultivate", "ExperienceDialog");
	}

	public static UI_ExperienceDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExperienceDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbio4ktt7j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected O, but got Unknown
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Expected O, but got Unknown
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Expected O, but got Unknown
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Expected O, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected O, but got Unknown
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected O, but got Unknown
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected O, but got Unknown
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Expected O, but got Unknown
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Expected O, but got Unknown
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Expected O, but got Unknown
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Expected O, but got Unknown
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		LevelController = ((GComponent)this).GetController("LevelController");
		jieduan = (GGraph)((GComponent)this).GetChild("jieduan");
		potionListBack = (GImage)((GComponent)this).GetChild("potionListBack");
		n55 = (GGraph)((GComponent)this).GetChild("n55");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		healthTitle = (GTextField)((GComponent)this).GetChild("healthTitle");
		string id = "ui://7dantnbio4ktt7j".Replace("ui://", "") + "-" + ((GObject)healthTitle).id;
		((GObject)healthTitle).text = LanguagesManager.GetDesc(id);
		defenseTitle = (GTextField)((GComponent)this).GetChild("defenseTitle");
		string id2 = "ui://7dantnbio4ktt7j".Replace("ui://", "") + "-" + ((GObject)defenseTitle).id;
		((GObject)defenseTitle).text = LanguagesManager.GetDesc(id2);
		attackTitle = (GTextField)((GComponent)this).GetChild("attackTitle");
		string id3 = "ui://7dantnbio4ktt7j".Replace("ui://", "") + "-" + ((GObject)attackTitle).id;
		((GObject)attackTitle).text = LanguagesManager.GetDesc(id3);
		curAttack = (GTextField)((GComponent)this).GetChild("curAttack");
		curHealth = (GTextField)((GComponent)this).GetChild("curHealth");
		curDefense = (GTextField)((GComponent)this).GetChild("curDefense");
		nextAttack = (GTextField)((GComponent)this).GetChild("nextAttack");
		nextHealth = (GTextField)((GComponent)this).GetChild("nextHealth");
		nextDefense = (GTextField)((GComponent)this).GetChild("nextDefense");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		line1 = (GGraph)((GComponent)this).GetChild("line1");
		n32 = (GTextField)((GComponent)this).GetChild("n32");
		string id4 = "ui://7dantnbio4ktt7j".Replace("ui://", "") + "-" + ((GObject)n32).id;
		((GObject)n32).text = LanguagesManager.GetDesc(id4);
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		line2 = (GGraph)((GComponent)this).GetChild("line2");
		potionList = (GList)((GComponent)this).GetChild("potionList");
		ExclamationMarkBtn = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn");
		UpgradeBtn = (GButton)((GComponent)this).GetChild("UpgradeBtn");
		QuickUpgradeBtn = (GButton)((GComponent)this).GetChild("QuickUpgradeBtn");
		line3 = (GGraph)((GComponent)this).GetChild("line3");
		curAttackSfxBack = (GGraph)((GComponent)this).GetChild("curAttackSfxBack");
		nextAttackSfxBack = (GGraph)((GComponent)this).GetChild("nextAttackSfxBack");
		curDefenseSfxBack = (GGraph)((GComponent)this).GetChild("curDefenseSfxBack");
		nextDefenseSfxBack = (GGraph)((GComponent)this).GetChild("nextDefenseSfxBack");
		curHealthSfxBack = (GGraph)((GComponent)this).GetChild("curHealthSfxBack");
		nextHealthSfxBack = (GGraph)((GComponent)this).GetChild("nextHealthSfxBack");
		cur = (GTextField)((GComponent)this).GetChild("cur");
		string id5 = "ui://7dantnbio4ktt7j".Replace("ui://", "") + "-" + ((GObject)cur).id;
		((GObject)cur).text = LanguagesManager.GetDesc(id5);
		next = (GTextField)((GComponent)this).GetChild("next");
		string id6 = "ui://7dantnbio4ktt7j".Replace("ui://", "") + "-" + ((GObject)next).id;
		((GObject)next).text = LanguagesManager.GetDesc(id6);
		CurNum = (UI_CurNum)(object)((GComponent)this).GetChild("CurNum");
		NextNum = (UI_NextNum)(object)((GComponent)this).GetChild("NextNum");
		Breath = ((GComponent)this).GetTransition("Breath");
		UpdateNumContent = ((GComponent)this).GetTransition("UpdateNumContent");
	}
}
