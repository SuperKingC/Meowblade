using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_DegreeElevationPage : GComponent
{
	public Controller PositionControll;

	public Controller EquipStyle;

	public GImage n128;

	public GGraph n129;

	public GGraph n169;

	public GImage n170;

	public GGroup decorativePattern;

	public GTextField n54;

	public GTextField NextLevel_t;

	public GImage n65;

	public GLoader DemandFrameLoader;

	public GLoader DemandIconLoader;

	public GTextField n66;

	public GGraph n50;

	public GTextField SkillName;

	public GTextField n67;

	public GLoader FloorLoader;

	public GLoader SkillIconLoader;

	public GLoader FrameLoader;

	public GGroup activateByUpgradeGroup;

	public UI_consumptionBtn consumptionBtn;

	public GGroup n87;

	public GLoader DemandFrameLoader2;

	public GGraph CurrentDemand_tSpine;

	public GComponent CurrentDemand_t;

	public GTextField consumeTitle;

	public GButton DegreeElevationUp_Btn;

	public GTextField CurrentLevel;

	public GTextField NextLevel;

	public GTextField n85;

	public GImage n12;

	public GTextField n13;

	public GTextField n14;

	public GTextField n15;

	public GTextField n16;

	public GTextField n17;

	public GTextField HealthGrow_t;

	public GTextField AttackGrow_t;

	public GTextField DefenceGrow_t;

	public GGroup DegreeElevationTip;

	public GImage n88;

	public GImage n95;

	public GImage n96;

	public GImage n97;

	public GImage n98;

	public GGroup page3back;

	public GImage line1;

	public GImage line3;

	public GImage line2;

	public GImage line4;

	public GGroup n164;

	public GImage n70;

	public GLoader SoldierFrameLoader;

	public GLoader SoldierIconLoader;

	public GGroup n71;

	public GComponent SoliderSoulStoneLevel;

	public UI_ElevationProduct Product1;

	public UI_ElevationProduct Product2;

	public UI_ElevationProduct Product3;

	public GGroup n168;

	public UI_ElevationProduct Product4;

	public GGraph SoldierEquipSfxBack;

	public UI_SoldierPromotionBtn SoldierPromotionBtn;

	public GGroup PropsAndEquip;

	public GImage tip;

	public GGraph unlockContentBack;

	public GTextField levelLimitTip;

	public GGroup n163;

	public GImage n167;

	public GImage n166;

	public const string URL = "ui://7dantnbionm22j";

	public static string Name = "UI_DegreeElevationPage";

	public static string GetURL()
	{
		return "ui://7dantnbionm22j";
	}

	public static UI_DegreeElevationPage CreateInstance()
	{
		return (UI_DegreeElevationPage)(object)UIPackage.CreateObject("SoldierCultivate", "DegreeElevationPage");
	}

	public static UI_DegreeElevationPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DegreeElevationPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbionm22j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected O, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Expected O, but got Unknown
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Expected O, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected O, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected O, but got Unknown
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Expected O, but got Unknown
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Expected O, but got Unknown
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Expected O, but got Unknown
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Expected O, but got Unknown
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Expected O, but got Unknown
		//IL_054f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Expected O, but got Unknown
		//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Expected O, but got Unknown
		//IL_05f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Expected O, but got Unknown
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0658: Expected O, but got Unknown
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ad: Expected O, but got Unknown
		//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0702: Expected O, but got Unknown
		//IL_074d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0757: Expected O, but got Unknown
		//IL_0763: Unknown result type (might be due to invalid IL or missing references)
		//IL_076d: Expected O, but got Unknown
		//IL_0779: Unknown result type (might be due to invalid IL or missing references)
		//IL_0783: Expected O, but got Unknown
		//IL_078f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0799: Expected O, but got Unknown
		//IL_07a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07af: Expected O, but got Unknown
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c5: Expected O, but got Unknown
		//IL_07d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07db: Expected O, but got Unknown
		//IL_07e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f1: Expected O, but got Unknown
		//IL_07fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0807: Expected O, but got Unknown
		//IL_0813: Unknown result type (might be due to invalid IL or missing references)
		//IL_081d: Expected O, but got Unknown
		//IL_0829: Unknown result type (might be due to invalid IL or missing references)
		//IL_0833: Expected O, but got Unknown
		//IL_083f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0849: Expected O, but got Unknown
		//IL_0855: Unknown result type (might be due to invalid IL or missing references)
		//IL_085f: Expected O, but got Unknown
		//IL_086b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0875: Expected O, but got Unknown
		//IL_0881: Unknown result type (might be due to invalid IL or missing references)
		//IL_088b: Expected O, but got Unknown
		//IL_0897: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a1: Expected O, but got Unknown
		//IL_08ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b7: Expected O, but got Unknown
		//IL_0905: Unknown result type (might be due to invalid IL or missing references)
		//IL_090f: Expected O, but got Unknown
		//IL_0931: Unknown result type (might be due to invalid IL or missing references)
		//IL_093b: Expected O, but got Unknown
		//IL_095d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0967: Expected O, but got Unknown
		//IL_0973: Unknown result type (might be due to invalid IL or missing references)
		//IL_097d: Expected O, but got Unknown
		//IL_0989: Unknown result type (might be due to invalid IL or missing references)
		//IL_0993: Expected O, but got Unknown
		//IL_099f: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a9: Expected O, but got Unknown
		//IL_09b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bf: Expected O, but got Unknown
		//IL_09cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d5: Expected O, but got Unknown
		//IL_09e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09eb: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PositionControll = ((GComponent)this).GetController("PositionControll");
		EquipStyle = ((GComponent)this).GetController("EquipStyle");
		n128 = (GImage)((GComponent)this).GetChild("n128");
		n129 = (GGraph)((GComponent)this).GetChild("n129");
		n169 = (GGraph)((GComponent)this).GetChild("n169");
		n170 = (GImage)((GComponent)this).GetChild("n170");
		decorativePattern = (GGroup)((GComponent)this).GetChild("decorativePattern");
		n54 = (GTextField)((GComponent)this).GetChild("n54");
		string id = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)n54).id;
		((GObject)n54).text = LanguagesManager.GetDesc(id);
		NextLevel_t = (GTextField)((GComponent)this).GetChild("NextLevel_t");
		string id2 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)NextLevel_t).id;
		((GObject)NextLevel_t).text = LanguagesManager.GetDesc(id2);
		n65 = (GImage)((GComponent)this).GetChild("n65");
		DemandFrameLoader = (GLoader)((GComponent)this).GetChild("DemandFrameLoader");
		DemandIconLoader = (GLoader)((GComponent)this).GetChild("DemandIconLoader");
		n66 = (GTextField)((GComponent)this).GetChild("n66");
		string id3 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)n66).id;
		((GObject)n66).text = LanguagesManager.GetDesc(id3);
		n50 = (GGraph)((GComponent)this).GetChild("n50");
		SkillName = (GTextField)((GComponent)this).GetChild("SkillName");
		string id4 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)SkillName).id;
		((GObject)SkillName).text = LanguagesManager.GetDesc(id4);
		n67 = (GTextField)((GComponent)this).GetChild("n67");
		string id5 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)n67).id;
		((GObject)n67).text = LanguagesManager.GetDesc(id5);
		FloorLoader = (GLoader)((GComponent)this).GetChild("FloorLoader");
		SkillIconLoader = (GLoader)((GComponent)this).GetChild("SkillIconLoader");
		FrameLoader = (GLoader)((GComponent)this).GetChild("FrameLoader");
		activateByUpgradeGroup = (GGroup)((GComponent)this).GetChild("activateByUpgradeGroup");
		consumptionBtn = (UI_consumptionBtn)(object)((GComponent)this).GetChild("consumptionBtn");
		n87 = (GGroup)((GComponent)this).GetChild("n87");
		DemandFrameLoader2 = (GLoader)((GComponent)this).GetChild("DemandFrameLoader2");
		CurrentDemand_tSpine = (GGraph)((GComponent)this).GetChild("CurrentDemand_tSpine");
		CurrentDemand_t = (GComponent)((GComponent)this).GetChild("CurrentDemand_t");
		consumeTitle = (GTextField)((GComponent)this).GetChild("consumeTitle");
		string id6 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)consumeTitle).id;
		((GObject)consumeTitle).text = LanguagesManager.GetDesc(id6);
		DegreeElevationUp_Btn = (GButton)((GComponent)this).GetChild("DegreeElevationUp_Btn");
		CurrentLevel = (GTextField)((GComponent)this).GetChild("CurrentLevel");
		string id7 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)CurrentLevel).id;
		((GObject)CurrentLevel).text = LanguagesManager.GetDesc(id7);
		NextLevel = (GTextField)((GComponent)this).GetChild("NextLevel");
		string id8 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)NextLevel).id;
		((GObject)NextLevel).text = LanguagesManager.GetDesc(id8);
		n85 = (GTextField)((GComponent)this).GetChild("n85");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id9 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id9);
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id10 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id10);
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id11 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id11);
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id12 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id12);
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id13 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id13);
		HealthGrow_t = (GTextField)((GComponent)this).GetChild("HealthGrow_t");
		string id14 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)HealthGrow_t).id;
		((GObject)HealthGrow_t).text = LanguagesManager.GetDesc(id14);
		AttackGrow_t = (GTextField)((GComponent)this).GetChild("AttackGrow_t");
		string id15 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)AttackGrow_t).id;
		((GObject)AttackGrow_t).text = LanguagesManager.GetDesc(id15);
		DefenceGrow_t = (GTextField)((GComponent)this).GetChild("DefenceGrow_t");
		string id16 = "ui://7dantnbionm22j".Replace("ui://", "") + "-" + ((GObject)DefenceGrow_t).id;
		((GObject)DefenceGrow_t).text = LanguagesManager.GetDesc(id16);
		DegreeElevationTip = (GGroup)((GComponent)this).GetChild("DegreeElevationTip");
		n88 = (GImage)((GComponent)this).GetChild("n88");
		n95 = (GImage)((GComponent)this).GetChild("n95");
		n96 = (GImage)((GComponent)this).GetChild("n96");
		n97 = (GImage)((GComponent)this).GetChild("n97");
		n98 = (GImage)((GComponent)this).GetChild("n98");
		page3back = (GGroup)((GComponent)this).GetChild("page3back");
		line1 = (GImage)((GComponent)this).GetChild("line1");
		line3 = (GImage)((GComponent)this).GetChild("line3");
		line2 = (GImage)((GComponent)this).GetChild("line2");
		line4 = (GImage)((GComponent)this).GetChild("line4");
		n164 = (GGroup)((GComponent)this).GetChild("n164");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		SoldierFrameLoader = (GLoader)((GComponent)this).GetChild("SoldierFrameLoader");
		SoldierIconLoader = (GLoader)((GComponent)this).GetChild("SoldierIconLoader");
		n71 = (GGroup)((GComponent)this).GetChild("n71");
		SoliderSoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoliderSoulStoneLevel");
		Product1 = (UI_ElevationProduct)(object)((GComponent)this).GetChild("Product1");
		Product2 = (UI_ElevationProduct)(object)((GComponent)this).GetChild("Product2");
		Product3 = (UI_ElevationProduct)(object)((GComponent)this).GetChild("Product3");
		n168 = (GGroup)((GComponent)this).GetChild("n168");
		Product4 = (UI_ElevationProduct)(object)((GComponent)this).GetChild("Product4");
		SoldierEquipSfxBack = (GGraph)((GComponent)this).GetChild("SoldierEquipSfxBack");
		SoldierPromotionBtn = (UI_SoldierPromotionBtn)(object)((GComponent)this).GetChild("SoldierPromotionBtn");
		PropsAndEquip = (GGroup)((GComponent)this).GetChild("PropsAndEquip");
		tip = (GImage)((GComponent)this).GetChild("tip");
		unlockContentBack = (GGraph)((GComponent)this).GetChild("unlockContentBack");
		levelLimitTip = (GTextField)((GComponent)this).GetChild("levelLimitTip");
		n163 = (GGroup)((GComponent)this).GetChild("n163");
		n167 = (GImage)((GComponent)this).GetChild("n167");
		n166 = (GImage)((GComponent)this).GetChild("n166");
	}
}
