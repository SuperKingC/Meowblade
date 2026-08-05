using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_SoldierBreakthrougPage : GComponent
{
	public Controller PageSwitch;

	public GGraph n188;

	public GGraph n189;

	public GGroup backgroup;

	public GImage n93;

	public GImage n94;

	public GImage n95;

	public GImage n96;

	public GImage n190;

	public GImage n191;

	public GGroup decorativePattern;

	public GTextField n47;

	public GLoader DemandIconLoader1;

	public GButton ActivityBtn;

	public GList curLevelStarListBack;

	public GList curLevelStarList;

	public GList nextLevelStarListBack;

	public GList nextLevelStarList;

	public GImage n77;

	public GList breakThroughCodeList;

	public GTextField soldierLevelDemandTitle;

	public GLoader DemandBackLoader2;

	public GLoader DemandIconLoader2;

	public GLoader DemandFrameLoader2;

	public GImage chipNote;

	public GGraph CurrentDemand_tSpine;

	public GComponent CurrentDemand_t;

	public GTextField consumeTitle;

	public GTextField soldierLevelDemand;

	public GTextField totalTitle;

	public GTextField TotalDemande_t;

	public GLoader TotalBackLoader2;

	public GLoader TotalFrameLoader2;

	public GLoader TotalIconLoader2;

	public GGroup demandGroup;

	public GTextField n84;

	public GTextField unknownNote;

	public UI_breakthroughCode evoLevel1_0;

	public UI_breakthroughCode evoLevel1_1;

	public UI_breakthroughCode evoLevel1_2;

	public UI_breakthroughCode evoLevel1_3;

	public UI_breakthroughCode evoLevel1_4;

	public UI_breakthroughCode evoLevel1_5;

	public UI_breakthroughCode evoLevel1_6;

	public UI_breakthroughCode evoLevel1_7;

	public UI_breakthroughCodeLast evoLevel1_8;

	public GGroup evoLevel1;

	public UI_breakthroughCode evoLevel2_0;

	public UI_breakthroughCode evoLevel2_1;

	public UI_breakthroughCode evoLevel2_2;

	public UI_breakthroughCode evoLevel2_3;

	public UI_breakthroughCode evoLevel2_4;

	public UI_breakthroughCode evoLevel2_5;

	public UI_breakthroughCode evoLevel2_6;

	public UI_breakthroughCode evoLevel2_7;

	public UI_breakthroughCode evoLevel2_8;

	public UI_breakthroughCode evoLevel2_9;

	public UI_breakthroughCodeLast evoLevel2_10;

	public GGroup evoLevel2;

	public UI_breakthroughCode evoLevel3_0;

	public UI_breakthroughCode evoLevel3_1;

	public UI_breakthroughCode evoLevel3_2;

	public UI_breakthroughCode evoLevel3_3;

	public UI_breakthroughCode evoLevel3_4;

	public UI_breakthroughCode evoLevel3_5;

	public UI_breakthroughCode evoLevel3_6;

	public UI_breakthroughCode evoLevel3_7;

	public UI_breakthroughCode evoLevel3_8;

	public UI_breakthroughCode evoLevel3_9;

	public UI_breakthroughCode evoLevel3_10;

	public UI_breakthroughCode evoLevel3_11;

	public UI_breakthroughCodeLast evoLevel3_12;

	public GGroup evoLevel3;

	public UI_breakthroughCode evoLevel4_0;

	public UI_breakthroughCode evoLevel4_1;

	public UI_breakthroughCode evoLevel4_2;

	public UI_breakthroughCode evoLevel4_3;

	public UI_breakthroughCode evoLevel4_4;

	public UI_breakthroughCode evoLevel4_5;

	public UI_breakthroughCode evoLevel4_6;

	public UI_breakthroughCode evoLevel4_7;

	public UI_breakthroughCode evoLevel4_8;

	public UI_breakthroughCode evoLevel4_9;

	public UI_breakthroughCode evoLevel4_10;

	public UI_breakthroughCode evoLevel4_11;

	public UI_breakthroughCode evoLevel4_12;

	public UI_breakthroughCode evoLevel4_13;

	public UI_breakthroughCodeLast evoLevel4_14;

	public GGroup evoLevel4;

	public UI_breakthroughCode evoLevel5_0;

	public UI_breakthroughCode evoLevel5_1;

	public UI_breakthroughCode evoLevel5_2;

	public UI_breakthroughCode evoLevel5_3;

	public UI_breakthroughCode evoLevel5_4;

	public UI_breakthroughCode evoLevel5_5;

	public UI_breakthroughCode evoLevel5_6;

	public UI_breakthroughCode evoLevel5_7;

	public UI_breakthroughCode evoLevel5_8;

	public UI_breakthroughCode evoLevel5_9;

	public UI_breakthroughCode evoLevel5_10;

	public UI_breakthroughCode evoLevel5_11;

	public UI_breakthroughCode evoLevel5_12;

	public UI_breakthroughCode evoLevel5_13;

	public UI_breakthroughCode evoLevel5_14;

	public UI_breakthroughCode evoLevel5_15;

	public UI_breakthroughCodeLast evoLevel5_16;

	public GGroup evoLevel5;

	public GTextField tip;

	public UI_SoldierPromotionClickBtn SoldierPromotionBtn;

	public GGraph SoldierEquipSfxBack;

	public const string URL = "ui://7dantnbionm22i";

	public static string Name = "UI_SoldierBreakthrougPage";

	public static string GetURL()
	{
		return "ui://7dantnbionm22i";
	}

	public static UI_SoldierBreakthrougPage CreateInstance()
	{
		return (UI_SoldierBreakthrougPage)(object)UIPackage.CreateObject("SoldierCultivate", "SoldierBreakthrougPage");
	}

	public static UI_SoldierBreakthrougPage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierBreakthrougPage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbionm22i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
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
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Expected O, but got Unknown
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Expected O, but got Unknown
		//IL_0576: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Expected O, but got Unknown
		//IL_067e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Expected O, but got Unknown
		//IL_07b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Expected O, but got Unknown
		//IL_0912: Unknown result type (might be due to invalid IL or missing references)
		//IL_091c: Expected O, but got Unknown
		//IL_0a9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa8: Expected O, but got Unknown
		//IL_0ab4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abe: Expected O, but got Unknown
		//IL_0b1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b29: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageSwitch = ((GComponent)this).GetController("PageSwitch");
		n188 = (GGraph)((GComponent)this).GetChild("n188");
		n189 = (GGraph)((GComponent)this).GetChild("n189");
		backgroup = (GGroup)((GComponent)this).GetChild("backgroup");
		n93 = (GImage)((GComponent)this).GetChild("n93");
		n94 = (GImage)((GComponent)this).GetChild("n94");
		n95 = (GImage)((GComponent)this).GetChild("n95");
		n96 = (GImage)((GComponent)this).GetChild("n96");
		n190 = (GImage)((GComponent)this).GetChild("n190");
		n191 = (GImage)((GComponent)this).GetChild("n191");
		decorativePattern = (GGroup)((GComponent)this).GetChild("decorativePattern");
		n47 = (GTextField)((GComponent)this).GetChild("n47");
		string id = "ui://7dantnbionm22i".Replace("ui://", "") + "-" + ((GObject)n47).id;
		((GObject)n47).text = LanguagesManager.GetDesc(id);
		DemandIconLoader1 = (GLoader)((GComponent)this).GetChild("DemandIconLoader1");
		ActivityBtn = (GButton)((GComponent)this).GetChild("ActivityBtn");
		curLevelStarListBack = (GList)((GComponent)this).GetChild("curLevelStarListBack");
		curLevelStarList = (GList)((GComponent)this).GetChild("curLevelStarList");
		nextLevelStarListBack = (GList)((GComponent)this).GetChild("nextLevelStarListBack");
		nextLevelStarList = (GList)((GComponent)this).GetChild("nextLevelStarList");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		breakThroughCodeList = (GList)((GComponent)this).GetChild("breakThroughCodeList");
		soldierLevelDemandTitle = (GTextField)((GComponent)this).GetChild("soldierLevelDemandTitle");
		string id2 = "ui://7dantnbionm22i".Replace("ui://", "") + "-" + ((GObject)soldierLevelDemandTitle).id;
		((GObject)soldierLevelDemandTitle).text = LanguagesManager.GetDesc(id2);
		DemandBackLoader2 = (GLoader)((GComponent)this).GetChild("DemandBackLoader2");
		DemandIconLoader2 = (GLoader)((GComponent)this).GetChild("DemandIconLoader2");
		DemandFrameLoader2 = (GLoader)((GComponent)this).GetChild("DemandFrameLoader2");
		chipNote = (GImage)((GComponent)this).GetChild("chipNote");
		CurrentDemand_tSpine = (GGraph)((GComponent)this).GetChild("CurrentDemand_tSpine");
		CurrentDemand_t = (GComponent)((GComponent)this).GetChild("CurrentDemand_t");
		consumeTitle = (GTextField)((GComponent)this).GetChild("consumeTitle");
		string id3 = "ui://7dantnbionm22i".Replace("ui://", "") + "-" + ((GObject)consumeTitle).id;
		((GObject)consumeTitle).text = LanguagesManager.GetDesc(id3);
		soldierLevelDemand = (GTextField)((GComponent)this).GetChild("soldierLevelDemand");
		string id4 = "ui://7dantnbionm22i".Replace("ui://", "") + "-" + ((GObject)soldierLevelDemand).id;
		((GObject)soldierLevelDemand).text = LanguagesManager.GetDesc(id4);
		totalTitle = (GTextField)((GComponent)this).GetChild("totalTitle");
		string id5 = "ui://7dantnbionm22i".Replace("ui://", "") + "-" + ((GObject)totalTitle).id;
		((GObject)totalTitle).text = LanguagesManager.GetDesc(id5);
		TotalDemande_t = (GTextField)((GComponent)this).GetChild("TotalDemande_t");
		TotalBackLoader2 = (GLoader)((GComponent)this).GetChild("TotalBackLoader2");
		TotalFrameLoader2 = (GLoader)((GComponent)this).GetChild("TotalFrameLoader2");
		TotalIconLoader2 = (GLoader)((GComponent)this).GetChild("TotalIconLoader2");
		demandGroup = (GGroup)((GComponent)this).GetChild("demandGroup");
		n84 = (GTextField)((GComponent)this).GetChild("n84");
		unknownNote = (GTextField)((GComponent)this).GetChild("unknownNote");
		string id6 = "ui://7dantnbionm22i".Replace("ui://", "") + "-" + ((GObject)unknownNote).id;
		((GObject)unknownNote).text = LanguagesManager.GetDesc(id6);
		evoLevel1_0 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel1_0");
		evoLevel1_1 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel1_1");
		evoLevel1_2 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel1_2");
		evoLevel1_3 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel1_3");
		evoLevel1_4 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel1_4");
		evoLevel1_5 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel1_5");
		evoLevel1_6 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel1_6");
		evoLevel1_7 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel1_7");
		evoLevel1_8 = (UI_breakthroughCodeLast)(object)((GComponent)this).GetChild("evoLevel1_8");
		evoLevel1 = (GGroup)((GComponent)this).GetChild("evoLevel1");
		evoLevel2_0 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel2_0");
		evoLevel2_1 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel2_1");
		evoLevel2_2 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel2_2");
		evoLevel2_3 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel2_3");
		evoLevel2_4 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel2_4");
		evoLevel2_5 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel2_5");
		evoLevel2_6 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel2_6");
		evoLevel2_7 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel2_7");
		evoLevel2_8 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel2_8");
		evoLevel2_9 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel2_9");
		evoLevel2_10 = (UI_breakthroughCodeLast)(object)((GComponent)this).GetChild("evoLevel2_10");
		evoLevel2 = (GGroup)((GComponent)this).GetChild("evoLevel2");
		evoLevel3_0 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel3_0");
		evoLevel3_1 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel3_1");
		evoLevel3_2 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel3_2");
		evoLevel3_3 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel3_3");
		evoLevel3_4 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel3_4");
		evoLevel3_5 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel3_5");
		evoLevel3_6 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel3_6");
		evoLevel3_7 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel3_7");
		evoLevel3_8 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel3_8");
		evoLevel3_9 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel3_9");
		evoLevel3_10 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel3_10");
		evoLevel3_11 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel3_11");
		evoLevel3_12 = (UI_breakthroughCodeLast)(object)((GComponent)this).GetChild("evoLevel3_12");
		evoLevel3 = (GGroup)((GComponent)this).GetChild("evoLevel3");
		evoLevel4_0 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel4_0");
		evoLevel4_1 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel4_1");
		evoLevel4_2 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel4_2");
		evoLevel4_3 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel4_3");
		evoLevel4_4 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel4_4");
		evoLevel4_5 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel4_5");
		evoLevel4_6 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel4_6");
		evoLevel4_7 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel4_7");
		evoLevel4_8 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel4_8");
		evoLevel4_9 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel4_9");
		evoLevel4_10 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel4_10");
		evoLevel4_11 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel4_11");
		evoLevel4_12 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel4_12");
		evoLevel4_13 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel4_13");
		evoLevel4_14 = (UI_breakthroughCodeLast)(object)((GComponent)this).GetChild("evoLevel4_14");
		evoLevel4 = (GGroup)((GComponent)this).GetChild("evoLevel4");
		evoLevel5_0 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_0");
		evoLevel5_1 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_1");
		evoLevel5_2 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_2");
		evoLevel5_3 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_3");
		evoLevel5_4 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_4");
		evoLevel5_5 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_5");
		evoLevel5_6 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_6");
		evoLevel5_7 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_7");
		evoLevel5_8 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_8");
		evoLevel5_9 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_9");
		evoLevel5_10 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_10");
		evoLevel5_11 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_11");
		evoLevel5_12 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_12");
		evoLevel5_13 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_13");
		evoLevel5_14 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_14");
		evoLevel5_15 = (UI_breakthroughCode)(object)((GComponent)this).GetChild("evoLevel5_15");
		evoLevel5_16 = (UI_breakthroughCodeLast)(object)((GComponent)this).GetChild("evoLevel5_16");
		evoLevel5 = (GGroup)((GComponent)this).GetChild("evoLevel5");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id7 = "ui://7dantnbionm22i".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id7);
		SoldierPromotionBtn = (UI_SoldierPromotionClickBtn)(object)((GComponent)this).GetChild("SoldierPromotionBtn");
		SoldierEquipSfxBack = (GGraph)((GComponent)this).GetChild("SoldierEquipSfxBack");
	}
}
