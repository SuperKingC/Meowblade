using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecruitingCamp;

public class UI_com_NewRecruitInfo : GComponent
{
	public Controller NameType;

	public Controller Type;

	public Controller HasShipPlanOccupied;

	public GImage n77;

	public GImage n80;

	public GImage n81;

	public GImage n82;

	public UI_dec_03 n78;

	public GImage n27;

	public GGraph AnimaPlaceholder;

	public GGroup n72;

	public GComponent SoldierNamePotentialLevelBack;

	public GTextField Soldiername_t;

	public GTextField Soldiername_Max;

	public GTextField n21;

	public GTextField n22;

	public GTextField SoldierLevel_t;

	public GTextField SoldierLevel_Max;

	public GLoader ShoulderStrap;

	public GGroup n26;

	public GImage n29;

	public GImage n79;

	public GGraph CombatPowerSfxBack;

	public GTextField n31;

	public GTextField Combatpower_t;

	public GImage CombatPowerIcon;

	public GGroup n35;

	public GTextField SoldierUpperLimit_t;

	public GTextField n40;

	public GGroup n41;

	public GImage n43;

	public GImage n44;

	public GImage n45;

	public GImage n48;

	public GTextField n50;

	public GList WeaponList;

	public GButton NotEnough;

	public GTextField ReadyTime_t;

	public GButton ExclamationMarkBtn1st;

	public UI_SoldierInfoPanelClickBtn SoldierInfoPanelClickBtn;

	public GButton ExclamationMarkBtn2nd;

	public GTextField n71;

	public GTextField SoldierAmount;

	public GGroup n73;

	public GTextField n54;

	public GTextField n51;

	public GImage n59;

	public GImage n60;

	public GImage n61;

	public GTextField n62;

	public GTextField StockLimit;

	public UI_com_ShipPlanOccupiedLimit ShipPlanOccupiedLimit;

	public GButton Help;

	public GList QueueList;

	public GTextField tip;

	public const string URL = "ui://72fujxhknnhl30";

	public static string Name = "UI_com_NewRecruitInfo";

	public static string GetURL()
	{
		return "ui://72fujxhknnhl30";
	}

	public static UI_com_NewRecruitInfo CreateInstance()
	{
		return (UI_com_NewRecruitInfo)(object)UIPackage.CreateObject("RecruitingCamp", "com_NewRecruitInfo");
	}

	public static UI_com_NewRecruitInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NewRecruitInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhknnhl30", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
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
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Expected O, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Expected O, but got Unknown
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Expected O, but got Unknown
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Expected O, but got Unknown
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Expected O, but got Unknown
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Expected O, but got Unknown
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Expected O, but got Unknown
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Expected O, but got Unknown
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c9: Expected O, but got Unknown
		//IL_0514: Unknown result type (might be due to invalid IL or missing references)
		//IL_051e: Expected O, but got Unknown
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0534: Expected O, but got Unknown
		//IL_0540: Unknown result type (might be due to invalid IL or missing references)
		//IL_054a: Expected O, but got Unknown
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Expected O, but got Unknown
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Expected O, but got Unknown
		//IL_0600: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Expected O, but got Unknown
		//IL_0616: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Expected O, but got Unknown
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0636: Expected O, but got Unknown
		//IL_0681: Unknown result type (might be due to invalid IL or missing references)
		//IL_068b: Expected O, but got Unknown
		//IL_06ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b7: Expected O, but got Unknown
		//IL_06c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cd: Expected O, but got Unknown
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		NameType = ((GComponent)this).GetController("NameType");
		Type = ((GComponent)this).GetController("Type");
		HasShipPlanOccupied = ((GComponent)this).GetController("HasShipPlanOccupied");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n80 = (GImage)((GComponent)this).GetChild("n80");
		n81 = (GImage)((GComponent)this).GetChild("n81");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n78 = (UI_dec_03)(object)((GComponent)this).GetChild("n78");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		AnimaPlaceholder = (GGraph)((GComponent)this).GetChild("AnimaPlaceholder");
		n72 = (GGroup)((GComponent)this).GetChild("n72");
		SoldierNamePotentialLevelBack = (GComponent)((GComponent)this).GetChild("SoldierNamePotentialLevelBack");
		Soldiername_t = (GTextField)((GComponent)this).GetChild("Soldiername_t");
		Soldiername_Max = (GTextField)((GComponent)this).GetChild("Soldiername_Max");
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id = "ui://72fujxhknnhl30".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id);
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id2 = "ui://72fujxhknnhl30".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id2);
		SoldierLevel_t = (GTextField)((GComponent)this).GetChild("SoldierLevel_t");
		SoldierLevel_Max = (GTextField)((GComponent)this).GetChild("SoldierLevel_Max");
		ShoulderStrap = (GLoader)((GComponent)this).GetChild("ShoulderStrap");
		n26 = (GGroup)((GComponent)this).GetChild("n26");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		n79 = (GImage)((GComponent)this).GetChild("n79");
		CombatPowerSfxBack = (GGraph)((GComponent)this).GetChild("CombatPowerSfxBack");
		n31 = (GTextField)((GComponent)this).GetChild("n31");
		string id3 = "ui://72fujxhknnhl30".Replace("ui://", "") + "-" + ((GObject)n31).id;
		((GObject)n31).text = LanguagesManager.GetDesc(id3);
		Combatpower_t = (GTextField)((GComponent)this).GetChild("Combatpower_t");
		CombatPowerIcon = (GImage)((GComponent)this).GetChild("CombatPowerIcon");
		n35 = (GGroup)((GComponent)this).GetChild("n35");
		SoldierUpperLimit_t = (GTextField)((GComponent)this).GetChild("SoldierUpperLimit_t");
		n40 = (GTextField)((GComponent)this).GetChild("n40");
		string id4 = "ui://72fujxhknnhl30".Replace("ui://", "") + "-" + ((GObject)n40).id;
		((GObject)n40).text = LanguagesManager.GetDesc(id4);
		n41 = (GGroup)((GComponent)this).GetChild("n41");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n50 = (GTextField)((GComponent)this).GetChild("n50");
		string id5 = "ui://72fujxhknnhl30".Replace("ui://", "") + "-" + ((GObject)n50).id;
		((GObject)n50).text = LanguagesManager.GetDesc(id5);
		WeaponList = (GList)((GComponent)this).GetChild("WeaponList");
		NotEnough = (GButton)((GComponent)this).GetChild("NotEnough");
		ReadyTime_t = (GTextField)((GComponent)this).GetChild("ReadyTime_t");
		ExclamationMarkBtn1st = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn1st");
		SoldierInfoPanelClickBtn = (UI_SoldierInfoPanelClickBtn)(object)((GComponent)this).GetChild("SoldierInfoPanelClickBtn");
		ExclamationMarkBtn2nd = (GButton)((GComponent)this).GetChild("ExclamationMarkBtn2nd");
		n71 = (GTextField)((GComponent)this).GetChild("n71");
		string id6 = "ui://72fujxhknnhl30".Replace("ui://", "") + "-" + ((GObject)n71).id;
		((GObject)n71).text = LanguagesManager.GetDesc(id6);
		SoldierAmount = (GTextField)((GComponent)this).GetChild("SoldierAmount");
		n73 = (GGroup)((GComponent)this).GetChild("n73");
		n54 = (GTextField)((GComponent)this).GetChild("n54");
		string id7 = "ui://72fujxhknnhl30".Replace("ui://", "") + "-" + ((GObject)n54).id;
		((GObject)n54).text = LanguagesManager.GetDesc(id7);
		n51 = (GTextField)((GComponent)this).GetChild("n51");
		string id8 = "ui://72fujxhknnhl30".Replace("ui://", "") + "-" + ((GObject)n51).id;
		((GObject)n51).text = LanguagesManager.GetDesc(id8);
		n59 = (GImage)((GComponent)this).GetChild("n59");
		n60 = (GImage)((GComponent)this).GetChild("n60");
		n61 = (GImage)((GComponent)this).GetChild("n61");
		n62 = (GTextField)((GComponent)this).GetChild("n62");
		string id9 = "ui://72fujxhknnhl30".Replace("ui://", "") + "-" + ((GObject)n62).id;
		((GObject)n62).text = LanguagesManager.GetDesc(id9);
		StockLimit = (GTextField)((GComponent)this).GetChild("StockLimit");
		ShipPlanOccupiedLimit = (UI_com_ShipPlanOccupiedLimit)(object)((GComponent)this).GetChild("ShipPlanOccupiedLimit");
		Help = (GButton)((GComponent)this).GetChild("Help");
		QueueList = (GList)((GComponent)this).GetChild("QueueList");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id10 = "ui://72fujxhknnhl30".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id10);
	}
}
