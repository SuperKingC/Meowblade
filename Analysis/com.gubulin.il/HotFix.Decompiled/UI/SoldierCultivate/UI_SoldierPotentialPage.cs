using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoldierPotentialPage : GComponent
{
	public Controller PageController;

	public Controller SfxController;

	public Controller LevelIconController;

	public GImage n188;

	public GGraph n189;

	public GGroup backgroup;

	public GTextField title;

	public GImage n326;

	public GGroup decorativePattern;

	public GImage n327;

	public GGroup decorativePatternM;

	public GImage SoulStoneLineDark0;

	public GImage SoulStoneLineDark1;

	public GImage SoulStoneLineDark2;

	public GLoader DemandBackLoader2;

	public GLoader DemandIconLoader2;

	public GLoader DemandFrameLoader2;

	public GImage chipNote;

	public GGraph CurrentDemand_tSpine;

	public GComponent CurrentDemand_t;

	public GImage SoulStoneLineLight0;

	public GImage SoulStoneLineLight1;

	public GImage SoulStoneLineLight2;

	public GButton SoulStone0;

	public GButton SoulStone1;

	public GButton SoulStone2;

	public GGroup n329;

	public GTextField consumeTitle;

	public GGraph debrisSfxBack;

	public GGroup demandGroup;

	public GGraph n318;

	public GImage tip1st;

	public GImage n279;

	public GImage n280;

	public GImage n281;

	public GImage n282;

	public GImage n283;

	public GImage n284;

	public GImage n285;

	public GImage n286;

	public GImage n300;

	public GImage n301;

	public GImage n330;

	public UI_PromoteBtn PromoteBtn;

	public GGraph unlockContentBack;

	public GTextField unlockTip2nd;

	public GList UnlockSkillList;

	public UI_UnlockSoldierBtn UnlockSoldierBtn;

	public GComponent unlockTip1st;

	public GImage n312;

	public GImage n307;

	public GImage n308;

	public GImage n309;

	public GGraph specialitySfxBack;

	public GImage n313;

	public GGraph specialityBtn;

	public GGroup n311;

	public GGroup n291;

	public UI_SoldierPromotionClickBtn SoldierPromotionBtn;

	public GGraph SoldierEquipSfxBack;

	public UI_SoldierAttribute SoldierAttribute;

	public GGraph PotentialIconSfxBack;

	public GGraph ui_myth_logo_2;

	public UI_DisplayLegendSlot LegendSlot;

	public GGraph MaxLevelTitleSfxBack;

	public GGraph SoulStoneSfxBack0;

	public GGraph SoulStoneSfxBack1;

	public GGraph SoulStoneSfxBack2;

	public const string URL = "ui://7dantnbi108mt76";

	public static string Name = "UI_SoldierPotentialPage";

	public void SetButtonTitle()
	{
		((GObject)PromoteBtn.title).text = LanguagesManager.GetDesc("SoldierCultivate-SoldierPotentialPage-PromoteBtn-title");
	}

	public static string GetURL()
	{
		return "ui://7dantnbi108mt76";
	}

	public static UI_SoldierPotentialPage CreateInstance()
	{
		return (UI_SoldierPotentialPage)(object)UIPackage.CreateObject("SoldierCultivate", "SoldierPotentialPage");
	}

	public static UI_SoldierPotentialPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierPotentialPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbi108mt76", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Expected O, but got Unknown
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected O, but got Unknown
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Expected O, but got Unknown
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected O, but got Unknown
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Expected O, but got Unknown
		//IL_0406: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Expected O, but got Unknown
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Expected O, but got Unknown
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Expected O, but got Unknown
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected O, but got Unknown
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Expected O, but got Unknown
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e7: Expected O, but got Unknown
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Expected O, but got Unknown
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_0513: Expected O, but got Unknown
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Expected O, but got Unknown
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Expected O, but got Unknown
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Expected O, but got Unknown
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Expected O, but got Unknown
		//IL_0577: Unknown result type (might be due to invalid IL or missing references)
		//IL_0581: Expected O, but got Unknown
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0597: Expected O, but got Unknown
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Expected O, but got Unknown
		//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d9: Expected O, but got Unknown
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0605: Expected O, but got Unknown
		//IL_0611: Unknown result type (might be due to invalid IL or missing references)
		//IL_061b: Expected O, but got Unknown
		//IL_063d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Expected O, but got Unknown
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Expected O, but got Unknown
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_0673: Expected O, but got Unknown
		//IL_067f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0689: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		SfxController = ((GComponent)this).GetController("SfxController");
		LevelIconController = ((GComponent)this).GetController("LevelIconController");
		n188 = (GImage)((GComponent)this).GetChild("n188");
		n189 = (GGraph)((GComponent)this).GetChild("n189");
		backgroup = (GGroup)((GComponent)this).GetChild("backgroup");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://7dantnbi108mt76".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n326 = (GImage)((GComponent)this).GetChild("n326");
		decorativePattern = (GGroup)((GComponent)this).GetChild("decorativePattern");
		n327 = (GImage)((GComponent)this).GetChild("n327");
		decorativePatternM = (GGroup)((GComponent)this).GetChild("decorativePatternM");
		SoulStoneLineDark0 = (GImage)((GComponent)this).GetChild("SoulStoneLineDark0");
		SoulStoneLineDark1 = (GImage)((GComponent)this).GetChild("SoulStoneLineDark1");
		SoulStoneLineDark2 = (GImage)((GComponent)this).GetChild("SoulStoneLineDark2");
		DemandBackLoader2 = (GLoader)((GComponent)this).GetChild("DemandBackLoader2");
		DemandIconLoader2 = (GLoader)((GComponent)this).GetChild("DemandIconLoader2");
		DemandFrameLoader2 = (GLoader)((GComponent)this).GetChild("DemandFrameLoader2");
		chipNote = (GImage)((GComponent)this).GetChild("chipNote");
		CurrentDemand_tSpine = (GGraph)((GComponent)this).GetChild("CurrentDemand_tSpine");
		CurrentDemand_t = (GComponent)((GComponent)this).GetChild("CurrentDemand_t");
		SoulStoneLineLight0 = (GImage)((GComponent)this).GetChild("SoulStoneLineLight0");
		SoulStoneLineLight1 = (GImage)((GComponent)this).GetChild("SoulStoneLineLight1");
		SoulStoneLineLight2 = (GImage)((GComponent)this).GetChild("SoulStoneLineLight2");
		SoulStone0 = (GButton)((GComponent)this).GetChild("SoulStone0");
		SoulStone1 = (GButton)((GComponent)this).GetChild("SoulStone1");
		SoulStone2 = (GButton)((GComponent)this).GetChild("SoulStone2");
		n329 = (GGroup)((GComponent)this).GetChild("n329");
		consumeTitle = (GTextField)((GComponent)this).GetChild("consumeTitle");
		string id2 = "ui://7dantnbi108mt76".Replace("ui://", "") + "-" + ((GObject)consumeTitle).id;
		((GObject)consumeTitle).text = LanguagesManager.GetDesc(id2);
		debrisSfxBack = (GGraph)((GComponent)this).GetChild("debrisSfxBack");
		demandGroup = (GGroup)((GComponent)this).GetChild("demandGroup");
		n318 = (GGraph)((GComponent)this).GetChild("n318");
		tip1st = (GImage)((GComponent)this).GetChild("tip1st");
		n279 = (GImage)((GComponent)this).GetChild("n279");
		n280 = (GImage)((GComponent)this).GetChild("n280");
		n281 = (GImage)((GComponent)this).GetChild("n281");
		n282 = (GImage)((GComponent)this).GetChild("n282");
		n283 = (GImage)((GComponent)this).GetChild("n283");
		n284 = (GImage)((GComponent)this).GetChild("n284");
		n285 = (GImage)((GComponent)this).GetChild("n285");
		n286 = (GImage)((GComponent)this).GetChild("n286");
		n300 = (GImage)((GComponent)this).GetChild("n300");
		n301 = (GImage)((GComponent)this).GetChild("n301");
		n330 = (GImage)((GComponent)this).GetChild("n330");
		PromoteBtn = (UI_PromoteBtn)(object)((GComponent)this).GetChild("PromoteBtn");
		unlockContentBack = (GGraph)((GComponent)this).GetChild("unlockContentBack");
		unlockTip2nd = (GTextField)((GComponent)this).GetChild("unlockTip2nd");
		string id3 = "ui://7dantnbi108mt76".Replace("ui://", "") + "-" + ((GObject)unlockTip2nd).id;
		((GObject)unlockTip2nd).text = LanguagesManager.GetDesc(id3);
		UnlockSkillList = (GList)((GComponent)this).GetChild("UnlockSkillList");
		UnlockSoldierBtn = (UI_UnlockSoldierBtn)(object)((GComponent)this).GetChild("UnlockSoldierBtn");
		unlockTip1st = (GComponent)((GComponent)this).GetChild("unlockTip1st");
		n312 = (GImage)((GComponent)this).GetChild("n312");
		n307 = (GImage)((GComponent)this).GetChild("n307");
		n308 = (GImage)((GComponent)this).GetChild("n308");
		n309 = (GImage)((GComponent)this).GetChild("n309");
		specialitySfxBack = (GGraph)((GComponent)this).GetChild("specialitySfxBack");
		n313 = (GImage)((GComponent)this).GetChild("n313");
		specialityBtn = (GGraph)((GComponent)this).GetChild("specialityBtn");
		n311 = (GGroup)((GComponent)this).GetChild("n311");
		n291 = (GGroup)((GComponent)this).GetChild("n291");
		SoldierPromotionBtn = (UI_SoldierPromotionClickBtn)(object)((GComponent)this).GetChild("SoldierPromotionBtn");
		SoldierEquipSfxBack = (GGraph)((GComponent)this).GetChild("SoldierEquipSfxBack");
		SoldierAttribute = (UI_SoldierAttribute)(object)((GComponent)this).GetChild("SoldierAttribute");
		PotentialIconSfxBack = (GGraph)((GComponent)this).GetChild("PotentialIconSfxBack");
		ui_myth_logo_2 = (GGraph)((GComponent)this).GetChild("ui_myth_logo_2");
		LegendSlot = (UI_DisplayLegendSlot)(object)((GComponent)this).GetChild("LegendSlot");
		MaxLevelTitleSfxBack = (GGraph)((GComponent)this).GetChild("MaxLevelTitleSfxBack");
		SoulStoneSfxBack0 = (GGraph)((GComponent)this).GetChild("SoulStoneSfxBack0");
		SoulStoneSfxBack1 = (GGraph)((GComponent)this).GetChild("SoulStoneSfxBack1");
		SoulStoneSfxBack2 = (GGraph)((GComponent)this).GetChild("SoulStoneSfxBack2");
	}
}
