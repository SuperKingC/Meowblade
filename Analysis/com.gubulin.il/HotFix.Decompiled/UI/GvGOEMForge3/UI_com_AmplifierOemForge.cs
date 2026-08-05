using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMForge3;

public class UI_com_AmplifierOemForge : GComponent
{
	public Controller Quatity;

	public Controller FormulaEnough;

	public Controller ForgeController;

	public Controller Extra;

	public GImage n188;

	public GLoader n162;

	public GImage n166;

	public GImage n165;

	public GImage n163;

	public GImage n164;

	public GImage n156;

	public GImage n157;

	public GImage n155;

	public GImage n192;

	public GTextField n136;

	public GTextField n137;

	public GButton HighQualityRateHelpBtn;

	public UI_com_AmplifierModel AmplifierIcon;

	public GTextField AmpName;

	public GTextField HighQualityRate;

	public UI_QualityIcon CurQuality;

	public UI_QualityIcon NextQuality;

	public UI_btn_ForgeBtn ForgeBtn;

	public GComponent AffectedRange;

	public GLoader Icon;

	public GComponent AffectedRangeSmall;

	public UI_com_AnimationTaser n168;

	public UI_com_AnimationTaser n169;

	public GTextField n177;

	public GTextField FormulaNum;

	public GTextField ReqNum;

	public GComponent ProfileDisplay;

	public GGraph ui_amplifier_forge_gun;

	public GGraph ui_amplifier_forge_gun2;

	public GGraph ui_amplifier_forge_icon;

	public GLoader BonusIcon;

	public GTextField BonusCnt;

	public GTextField ExtraBonusCnt;

	public GTextField n189;

	public GImage n198;

	public GButton ExtraHighQualityRateBtn;

	public GTextField remainTimeDes;

	public GTextField remainTime;

	public GTextField n204;

	public Transition ForgeAmp;

	public const string URL = "ui://hotvoz3ppg603f";

	public static string Name = "UI_com_AmplifierOemForge";

	public static string GetURL()
	{
		return "ui://hotvoz3ppg603f";
	}

	public static UI_com_AmplifierOemForge CreateInstance()
	{
		return (UI_com_AmplifierOemForge)(object)UIPackage.CreateObject("GvGOEMForge3", "com_AmplifierOemForge");
	}

	public static UI_com_AmplifierOemForge CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AmplifierOemForge).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hotvoz3ppg603f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
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
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Expected O, but got Unknown
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Expected O, but got Unknown
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Expected O, but got Unknown
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Expected O, but got Unknown
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Expected O, but got Unknown
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Expected O, but got Unknown
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Expected O, but got Unknown
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Expected O, but got Unknown
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0498: Expected O, but got Unknown
		//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Expected O, but got Unknown
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Expected O, but got Unknown
		//IL_050f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0519: Expected O, but got Unknown
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_056e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Quatity = ((GComponent)this).GetController("Quatity");
		FormulaEnough = ((GComponent)this).GetController("FormulaEnough");
		ForgeController = ((GComponent)this).GetController("ForgeController");
		Extra = ((GComponent)this).GetController("Extra");
		n188 = (GImage)((GComponent)this).GetChild("n188");
		n162 = (GLoader)((GComponent)this).GetChild("n162");
		n166 = (GImage)((GComponent)this).GetChild("n166");
		n165 = (GImage)((GComponent)this).GetChild("n165");
		n163 = (GImage)((GComponent)this).GetChild("n163");
		n164 = (GImage)((GComponent)this).GetChild("n164");
		n156 = (GImage)((GComponent)this).GetChild("n156");
		n157 = (GImage)((GComponent)this).GetChild("n157");
		n155 = (GImage)((GComponent)this).GetChild("n155");
		n192 = (GImage)((GComponent)this).GetChild("n192");
		n136 = (GTextField)((GComponent)this).GetChild("n136");
		string id = "ui://hotvoz3ppg603f".Replace("ui://", "") + "-" + ((GObject)n136).id;
		((GObject)n136).text = LanguagesManager.GetDesc(id);
		n137 = (GTextField)((GComponent)this).GetChild("n137");
		string id2 = "ui://hotvoz3ppg603f".Replace("ui://", "") + "-" + ((GObject)n137).id;
		((GObject)n137).text = LanguagesManager.GetDesc(id2);
		HighQualityRateHelpBtn = (GButton)((GComponent)this).GetChild("HighQualityRateHelpBtn");
		AmplifierIcon = (UI_com_AmplifierModel)(object)((GComponent)this).GetChild("AmplifierIcon");
		AmpName = (GTextField)((GComponent)this).GetChild("AmpName");
		HighQualityRate = (GTextField)((GComponent)this).GetChild("HighQualityRate");
		CurQuality = (UI_QualityIcon)(object)((GComponent)this).GetChild("CurQuality");
		NextQuality = (UI_QualityIcon)(object)((GComponent)this).GetChild("NextQuality");
		ForgeBtn = (UI_btn_ForgeBtn)(object)((GComponent)this).GetChild("ForgeBtn");
		AffectedRange = (GComponent)((GComponent)this).GetChild("AffectedRange");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		AffectedRangeSmall = (GComponent)((GComponent)this).GetChild("AffectedRangeSmall");
		n168 = (UI_com_AnimationTaser)(object)((GComponent)this).GetChild("n168");
		n169 = (UI_com_AnimationTaser)(object)((GComponent)this).GetChild("n169");
		n177 = (GTextField)((GComponent)this).GetChild("n177");
		string id3 = "ui://hotvoz3ppg603f".Replace("ui://", "") + "-" + ((GObject)n177).id;
		((GObject)n177).text = LanguagesManager.GetDesc(id3);
		FormulaNum = (GTextField)((GComponent)this).GetChild("FormulaNum");
		ReqNum = (GTextField)((GComponent)this).GetChild("ReqNum");
		string id4 = "ui://hotvoz3ppg603f".Replace("ui://", "") + "-" + ((GObject)ReqNum).id;
		((GObject)ReqNum).text = LanguagesManager.GetDesc(id4);
		ProfileDisplay = (GComponent)((GComponent)this).GetChild("ProfileDisplay");
		ui_amplifier_forge_gun = (GGraph)((GComponent)this).GetChild("ui_amplifier_forge_gun");
		ui_amplifier_forge_gun2 = (GGraph)((GComponent)this).GetChild("ui_amplifier_forge_gun2");
		ui_amplifier_forge_icon = (GGraph)((GComponent)this).GetChild("ui_amplifier_forge_icon");
		BonusIcon = (GLoader)((GComponent)this).GetChild("BonusIcon");
		BonusCnt = (GTextField)((GComponent)this).GetChild("BonusCnt");
		ExtraBonusCnt = (GTextField)((GComponent)this).GetChild("ExtraBonusCnt");
		n189 = (GTextField)((GComponent)this).GetChild("n189");
		string id5 = "ui://hotvoz3ppg603f".Replace("ui://", "") + "-" + ((GObject)n189).id;
		((GObject)n189).text = LanguagesManager.GetDesc(id5);
		n198 = (GImage)((GComponent)this).GetChild("n198");
		ExtraHighQualityRateBtn = (GButton)((GComponent)this).GetChild("ExtraHighQualityRateBtn");
		remainTimeDes = (GTextField)((GComponent)this).GetChild("remainTimeDes");
		string id6 = "ui://hotvoz3ppg603f".Replace("ui://", "") + "-" + ((GObject)remainTimeDes).id;
		((GObject)remainTimeDes).text = LanguagesManager.GetDesc(id6);
		remainTime = (GTextField)((GComponent)this).GetChild("remainTime");
		string id7 = "ui://hotvoz3ppg603f".Replace("ui://", "") + "-" + ((GObject)remainTime).id;
		((GObject)remainTime).text = LanguagesManager.GetDesc(id7);
		n204 = (GTextField)((GComponent)this).GetChild("n204");
		string id8 = "ui://hotvoz3ppg603f".Replace("ui://", "") + "-" + ((GObject)n204).id;
		((GObject)n204).text = LanguagesManager.GetDesc(id8);
		ForgeAmp = ((GComponent)this).GetTransition("ForgeAmp");
	}
}
