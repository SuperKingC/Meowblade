using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoldierPotentialTip : GComponent
{
	public Controller PageController;

	public GImage back;

	public GTextField title;

	public GComponent curPotential;

	public GComponent nextPotential;

	public GImage n7;

	public GImage n11;

	public GImage n12;

	public GImage n13;

	public GTextField healthTitle;

	public GTextField defenseTitle;

	public GTextField attackTitle;

	public GGraph line1;

	public GTextField curAttack;

	public GTextField curHealth;

	public GTextField curDefense;

	public GTextField nextAttack;

	public GTextField nextHealth;

	public GTextField nextDefense;

	public GImage n24;

	public GImage n25;

	public GImage n26;

	public GGraph line2;

	public GTextField skillName;

	public GLoader SkillIconLoader;

	public GImage frameImage;

	public GGroup skillGroup;

	public GTextField ellipsis;

	public const string URL = "ui://7dantnbi108mt7f";

	public static string Name = "UI_SoldierPotentialTip";

	public static string GetURL()
	{
		return "ui://7dantnbi108mt7f";
	}

	public static UI_SoldierPotentialTip CreateInstance()
	{
		return (UI_SoldierPotentialTip)(object)UIPackage.CreateObject("SoldierCultivate", "SoldierPotentialTip");
	}

	public static UI_SoldierPotentialTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierPotentialTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbi108mt7f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
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
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Expected O, but got Unknown
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected O, but got Unknown
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Expected O, but got Unknown
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://7dantnbi108mt7f".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		curPotential = (GComponent)((GComponent)this).GetChild("curPotential");
		nextPotential = (GComponent)((GComponent)this).GetChild("nextPotential");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		healthTitle = (GTextField)((GComponent)this).GetChild("healthTitle");
		string id2 = "ui://7dantnbi108mt7f".Replace("ui://", "") + "-" + ((GObject)healthTitle).id;
		((GObject)healthTitle).text = LanguagesManager.GetDesc(id2);
		defenseTitle = (GTextField)((GComponent)this).GetChild("defenseTitle");
		string id3 = "ui://7dantnbi108mt7f".Replace("ui://", "") + "-" + ((GObject)defenseTitle).id;
		((GObject)defenseTitle).text = LanguagesManager.GetDesc(id3);
		attackTitle = (GTextField)((GComponent)this).GetChild("attackTitle");
		string id4 = "ui://7dantnbi108mt7f".Replace("ui://", "") + "-" + ((GObject)attackTitle).id;
		((GObject)attackTitle).text = LanguagesManager.GetDesc(id4);
		line1 = (GGraph)((GComponent)this).GetChild("line1");
		curAttack = (GTextField)((GComponent)this).GetChild("curAttack");
		curHealth = (GTextField)((GComponent)this).GetChild("curHealth");
		curDefense = (GTextField)((GComponent)this).GetChild("curDefense");
		nextAttack = (GTextField)((GComponent)this).GetChild("nextAttack");
		nextHealth = (GTextField)((GComponent)this).GetChild("nextHealth");
		nextDefense = (GTextField)((GComponent)this).GetChild("nextDefense");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		line2 = (GGraph)((GComponent)this).GetChild("line2");
		skillName = (GTextField)((GComponent)this).GetChild("skillName");
		string id5 = "ui://7dantnbi108mt7f".Replace("ui://", "") + "-" + ((GObject)skillName).id;
		((GObject)skillName).text = LanguagesManager.GetDesc(id5);
		SkillIconLoader = (GLoader)((GComponent)this).GetChild("SkillIconLoader");
		frameImage = (GImage)((GComponent)this).GetChild("frameImage");
		skillGroup = (GGroup)((GComponent)this).GetChild("skillGroup");
		ellipsis = (GTextField)((GComponent)this).GetChild("ellipsis");
		string id6 = "ui://7dantnbi108mt7f".Replace("ui://", "") + "-" + ((GObject)ellipsis).id;
		((GObject)ellipsis).text = LanguagesManager.GetDesc(id6);
	}
}
