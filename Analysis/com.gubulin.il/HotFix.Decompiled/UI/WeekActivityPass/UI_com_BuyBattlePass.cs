using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_com_BuyBattlePass : GComponent
{
	public GImage Background;

	public GImage n81;

	public GImage n65;

	public GImage n78;

	public GImage n64;

	public GTextField Title2_1;

	public GLoader LevelIcon;

	public GTextField LevelNum;

	public GTextField Title2_3;

	public GGroup Title2;

	public GList ClaimableList;

	public UI_com_CSlider Slider;

	public UI_btn_Add AddBtn;

	public UI_btn_Minus MinusBtn;

	public GTextField QuickBuyText;

	public GLoader QuickBuyIcon;

	public UI_btn_QuickBuy QuickBuyBtn;

	public GTextField n67;

	public GLoader BuyLevelIcon;

	public GTextField Score;

	public GGroup SliderInfo;

	public UI_btn_Max MaxBtn;

	public const string URL = "ui://11dkggb8nk8f15";

	public static string Name = "UI_com_BuyBattlePass";

	public static string GetURL()
	{
		return "ui://11dkggb8nk8f15";
	}

	public static UI_com_BuyBattlePass CreateInstance()
	{
		return (UI_com_BuyBattlePass)(object)UIPackage.CreateObject("WeekActivityPass", "com_BuyBattlePass");
	}

	public static UI_com_BuyBattlePass CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BuyBattlePass).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8nk8f15", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Background = (GImage)((GComponent)this).GetChild("Background");
		n81 = (GImage)((GComponent)this).GetChild("n81");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		n78 = (GImage)((GComponent)this).GetChild("n78");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		Title2_1 = (GTextField)((GComponent)this).GetChild("Title2_1");
		string id = "ui://11dkggb8nk8f15".Replace("ui://", "") + "-" + ((GObject)Title2_1).id;
		((GObject)Title2_1).text = LanguagesManager.GetDesc(id);
		LevelIcon = (GLoader)((GComponent)this).GetChild("LevelIcon");
		LevelNum = (GTextField)((GComponent)this).GetChild("LevelNum");
		Title2_3 = (GTextField)((GComponent)this).GetChild("Title2_3");
		string id2 = "ui://11dkggb8nk8f15".Replace("ui://", "") + "-" + ((GObject)Title2_3).id;
		((GObject)Title2_3).text = LanguagesManager.GetDesc(id2);
		Title2 = (GGroup)((GComponent)this).GetChild("Title2");
		ClaimableList = (GList)((GComponent)this).GetChild("ClaimableList");
		Slider = (UI_com_CSlider)(object)((GComponent)this).GetChild("Slider");
		AddBtn = (UI_btn_Add)(object)((GComponent)this).GetChild("AddBtn");
		MinusBtn = (UI_btn_Minus)(object)((GComponent)this).GetChild("MinusBtn");
		QuickBuyText = (GTextField)((GComponent)this).GetChild("QuickBuyText");
		QuickBuyIcon = (GLoader)((GComponent)this).GetChild("QuickBuyIcon");
		QuickBuyBtn = (UI_btn_QuickBuy)(object)((GComponent)this).GetChild("QuickBuyBtn");
		n67 = (GTextField)((GComponent)this).GetChild("n67");
		string id3 = "ui://11dkggb8nk8f15".Replace("ui://", "") + "-" + ((GObject)n67).id;
		((GObject)n67).text = LanguagesManager.GetDesc(id3);
		BuyLevelIcon = (GLoader)((GComponent)this).GetChild("BuyLevelIcon");
		Score = (GTextField)((GComponent)this).GetChild("Score");
		SliderInfo = (GGroup)((GComponent)this).GetChild("SliderInfo");
		MaxBtn = (UI_btn_Max)(object)((GComponent)this).GetChild("MaxBtn");
	}
}
