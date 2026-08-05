using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOEMForge3;

public class UI_com_FormulaOemForge : GComponent
{
	public Controller Quatity;

	public Controller CanForge;

	public Controller ForgeController;

	public Controller hasTalent;

	public Controller RateLevel;

	public GImage n188;

	public GLoader n162;

	public GImage n166;

	public GImage n165;

	public GImage n163;

	public GImage n164;

	public GImage n156;

	public GGraph n213;

	public GImage n231;

	public GImage n155;

	public UI_com_AmplifierModel AmplifierIcon;

	public GTextField AmpName;

	public UI_com_AnimationTaser n168;

	public UI_com_AnimationTaser n169;

	public GGraph ui_amplifier_forge_gun;

	public GGraph ui_amplifier_forge_gun2;

	public GGraph ui_amplifier_forge_icon;

	public UI_btn_ForgeBtn ForgeBtn;

	public GComponent AffectedRange;

	public GImage n226;

	public GImage n232;

	public GTextField n136;

	public GButton HighQualityRateHelpBtn;

	public GTextField n177;

	public GTextField remainTimeDes;

	public GTextField remainTime;

	public GTextField useCountDes;

	public GImage n225;

	public GTextField useCount;

	public GComponent ProfileDisplay;

	public GList ConsumeList;

	public GTextField n219;

	public GTextField BonusCnt;

	public GImage n228;

	public Transition ForgeAmp;

	public const string URL = "ui://hotvoz3pt0zv62";

	public static string Name = "UI_com_FormulaOemForge";

	public static string GetURL()
	{
		return "ui://hotvoz3pt0zv62";
	}

	public static UI_com_FormulaOemForge CreateInstance()
	{
		return (UI_com_FormulaOemForge)(object)UIPackage.CreateObject("GvGOEMForge3", "com_FormulaOemForge");
	}

	public static UI_com_FormulaOemForge CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaOemForge).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hotvoz3pt0zv62", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected O, but got Unknown
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Expected O, but got Unknown
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Expected O, but got Unknown
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Expected O, but got Unknown
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Expected O, but got Unknown
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Expected O, but got Unknown
		//IL_04db: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Expected O, but got Unknown
		//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fb: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Quatity = ((GComponent)this).GetController("Quatity");
		CanForge = ((GComponent)this).GetController("CanForge");
		ForgeController = ((GComponent)this).GetController("ForgeController");
		hasTalent = ((GComponent)this).GetController("hasTalent");
		RateLevel = ((GComponent)this).GetController("RateLevel");
		n188 = (GImage)((GComponent)this).GetChild("n188");
		n162 = (GLoader)((GComponent)this).GetChild("n162");
		n166 = (GImage)((GComponent)this).GetChild("n166");
		n165 = (GImage)((GComponent)this).GetChild("n165");
		n163 = (GImage)((GComponent)this).GetChild("n163");
		n164 = (GImage)((GComponent)this).GetChild("n164");
		n156 = (GImage)((GComponent)this).GetChild("n156");
		n213 = (GGraph)((GComponent)this).GetChild("n213");
		n231 = (GImage)((GComponent)this).GetChild("n231");
		n155 = (GImage)((GComponent)this).GetChild("n155");
		AmplifierIcon = (UI_com_AmplifierModel)(object)((GComponent)this).GetChild("AmplifierIcon");
		AmpName = (GTextField)((GComponent)this).GetChild("AmpName");
		n168 = (UI_com_AnimationTaser)(object)((GComponent)this).GetChild("n168");
		n169 = (UI_com_AnimationTaser)(object)((GComponent)this).GetChild("n169");
		ui_amplifier_forge_gun = (GGraph)((GComponent)this).GetChild("ui_amplifier_forge_gun");
		ui_amplifier_forge_gun2 = (GGraph)((GComponent)this).GetChild("ui_amplifier_forge_gun2");
		ui_amplifier_forge_icon = (GGraph)((GComponent)this).GetChild("ui_amplifier_forge_icon");
		ForgeBtn = (UI_btn_ForgeBtn)(object)((GComponent)this).GetChild("ForgeBtn");
		AffectedRange = (GComponent)((GComponent)this).GetChild("AffectedRange");
		n226 = (GImage)((GComponent)this).GetChild("n226");
		n232 = (GImage)((GComponent)this).GetChild("n232");
		n136 = (GTextField)((GComponent)this).GetChild("n136");
		string id = "ui://hotvoz3pt0zv62".Replace("ui://", "") + "-" + ((GObject)n136).id;
		((GObject)n136).text = LanguagesManager.GetDesc(id);
		HighQualityRateHelpBtn = (GButton)((GComponent)this).GetChild("HighQualityRateHelpBtn");
		n177 = (GTextField)((GComponent)this).GetChild("n177");
		string id2 = "ui://hotvoz3pt0zv62".Replace("ui://", "") + "-" + ((GObject)n177).id;
		((GObject)n177).text = LanguagesManager.GetDesc(id2);
		remainTimeDes = (GTextField)((GComponent)this).GetChild("remainTimeDes");
		string id3 = "ui://hotvoz3pt0zv62".Replace("ui://", "") + "-" + ((GObject)remainTimeDes).id;
		((GObject)remainTimeDes).text = LanguagesManager.GetDesc(id3);
		remainTime = (GTextField)((GComponent)this).GetChild("remainTime");
		string id4 = "ui://hotvoz3pt0zv62".Replace("ui://", "") + "-" + ((GObject)remainTime).id;
		((GObject)remainTime).text = LanguagesManager.GetDesc(id4);
		useCountDes = (GTextField)((GComponent)this).GetChild("useCountDes");
		string id5 = "ui://hotvoz3pt0zv62".Replace("ui://", "") + "-" + ((GObject)useCountDes).id;
		((GObject)useCountDes).text = LanguagesManager.GetDesc(id5);
		n225 = (GImage)((GComponent)this).GetChild("n225");
		useCount = (GTextField)((GComponent)this).GetChild("useCount");
		string id6 = "ui://hotvoz3pt0zv62".Replace("ui://", "") + "-" + ((GObject)useCount).id;
		((GObject)useCount).text = LanguagesManager.GetDesc(id6);
		ProfileDisplay = (GComponent)((GComponent)this).GetChild("ProfileDisplay");
		ConsumeList = (GList)((GComponent)this).GetChild("ConsumeList");
		n219 = (GTextField)((GComponent)this).GetChild("n219");
		string id7 = "ui://hotvoz3pt0zv62".Replace("ui://", "") + "-" + ((GObject)n219).id;
		((GObject)n219).text = LanguagesManager.GetDesc(id7);
		BonusCnt = (GTextField)((GComponent)this).GetChild("BonusCnt");
		n228 = (GImage)((GComponent)this).GetChild("n228");
		ForgeAmp = ((GComponent)this).GetTransition("ForgeAmp");
	}
}
