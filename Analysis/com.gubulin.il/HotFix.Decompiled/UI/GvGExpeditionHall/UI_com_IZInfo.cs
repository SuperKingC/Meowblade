using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_IZInfo : GComponent
{
	public GImage n137;

	public GImage n140;

	public GImage n141;

	public GImage n139;

	public GImage n138;

	public GTextField n121;

	public GTextField n122;

	public GTextField Difficulty;

	public GTextField Benefit;

	public UI_DescContainer DescContainer;

	public GTextField TimeCost;

	public GTextField n23;

	public GList NormalBonusList;

	public GImage n133;

	public GGraph NormalBonusBtn;

	public UI_com_SpecialBonusBtn SpecialBonusBtn;

	public GImage n135;

	public GTextField n136;

	public const string URL = "ui://k19peou7u2yw1g";

	public static string Name = "UI_com_IZInfo";

	public static string GetURL()
	{
		return "ui://k19peou7u2yw1g";
	}

	public static UI_com_IZInfo CreateInstance()
	{
		return (UI_com_IZInfo)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_IZInfo");
	}

	public static UI_com_IZInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IZInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7u2yw1g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n137 = (GImage)((GComponent)this).GetChild("n137");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		n141 = (GImage)((GComponent)this).GetChild("n141");
		n139 = (GImage)((GComponent)this).GetChild("n139");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		n121 = (GTextField)((GComponent)this).GetChild("n121");
		string id = "ui://k19peou7u2yw1g".Replace("ui://", "") + "-" + ((GObject)n121).id;
		((GObject)n121).text = LanguagesManager.GetDesc(id);
		n122 = (GTextField)((GComponent)this).GetChild("n122");
		string id2 = "ui://k19peou7u2yw1g".Replace("ui://", "") + "-" + ((GObject)n122).id;
		((GObject)n122).text = LanguagesManager.GetDesc(id2);
		Difficulty = (GTextField)((GComponent)this).GetChild("Difficulty");
		Benefit = (GTextField)((GComponent)this).GetChild("Benefit");
		DescContainer = (UI_DescContainer)(object)((GComponent)this).GetChild("DescContainer");
		TimeCost = (GTextField)((GComponent)this).GetChild("TimeCost");
		n23 = (GTextField)((GComponent)this).GetChild("n23");
		string id3 = "ui://k19peou7u2yw1g".Replace("ui://", "") + "-" + ((GObject)n23).id;
		((GObject)n23).text = LanguagesManager.GetDesc(id3);
		NormalBonusList = (GList)((GComponent)this).GetChild("NormalBonusList");
		n133 = (GImage)((GComponent)this).GetChild("n133");
		NormalBonusBtn = (GGraph)((GComponent)this).GetChild("NormalBonusBtn");
		SpecialBonusBtn = (UI_com_SpecialBonusBtn)(object)((GComponent)this).GetChild("SpecialBonusBtn");
		n135 = (GImage)((GComponent)this).GetChild("n135");
		n136 = (GTextField)((GComponent)this).GetChild("n136");
		string id4 = "ui://k19peou7u2yw1g".Replace("ui://", "") + "-" + ((GObject)n136).id;
		((GObject)n136).text = LanguagesManager.GetDesc(id4);
	}
}
