using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_com_BuyBattlePass : GComponent
{
	public Controller Mode;

	public GImage Background;

	public GImage n65;

	public GImage n78;

	public GImage n64;

	public GTextField Title;

	public GTextField n79;

	public GTextField Title2_1;

	public GLoader LevelIcon;

	public GTextField LevelNum;

	public GTextField Title2_3;

	public GGroup Title2;

	public GList ClaimableList;

	public UI_btn_BuyBtn BuyBtn;

	public UI_com_CSlider Slider;

	public UI_btn_Add AddBtn;

	public UI_btn_Minus MinusBtn;

	public GTextField QuickBuyText;

	public GLoader QuickBuyIcon;

	public UI_btn_QuickBuy QuickBuyBtn;

	public GTextField n26;

	public GLoader BuyLevelIcon;

	public GTextField BuyLevel;

	public GLoader n73;

	public GTextField Score;

	public GTextField n67;

	public GGroup SliderInfo;

	public UI_btn_Max MaxBtn;

	public GTextField n80;

	public const string URL = "ui://bfjg32huq1eq38";

	public static string Name = "UI_com_BuyBattlePass";

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq38";
	}

	public static UI_com_BuyBattlePass CreateInstance()
	{
		return (UI_com_BuyBattlePass)(object)UIPackage.CreateObject("GvGBattlePass3", "com_BuyBattlePass");
	}

	public static UI_com_BuyBattlePass CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BuyBattlePass).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq38", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected O, but got Unknown
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected O, but got Unknown
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Expected O, but got Unknown
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Expected O, but got Unknown
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected O, but got Unknown
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Expected O, but got Unknown
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mode = ((GComponent)this).GetController("Mode");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		n78 = (GImage)((GComponent)this).GetChild("n78");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://bfjg32huq1eq38".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		n79 = (GTextField)((GComponent)this).GetChild("n79");
		string id2 = "ui://bfjg32huq1eq38".Replace("ui://", "") + "-" + ((GObject)n79).id;
		((GObject)n79).text = LanguagesManager.GetDesc(id2);
		Title2_1 = (GTextField)((GComponent)this).GetChild("Title2_1");
		string id3 = "ui://bfjg32huq1eq38".Replace("ui://", "") + "-" + ((GObject)Title2_1).id;
		((GObject)Title2_1).text = LanguagesManager.GetDesc(id3);
		LevelIcon = (GLoader)((GComponent)this).GetChild("LevelIcon");
		LevelNum = (GTextField)((GComponent)this).GetChild("LevelNum");
		Title2_3 = (GTextField)((GComponent)this).GetChild("Title2_3");
		string id4 = "ui://bfjg32huq1eq38".Replace("ui://", "") + "-" + ((GObject)Title2_3).id;
		((GObject)Title2_3).text = LanguagesManager.GetDesc(id4);
		Title2 = (GGroup)((GComponent)this).GetChild("Title2");
		ClaimableList = (GList)((GComponent)this).GetChild("ClaimableList");
		BuyBtn = (UI_btn_BuyBtn)(object)((GComponent)this).GetChild("BuyBtn");
		Slider = (UI_com_CSlider)(object)((GComponent)this).GetChild("Slider");
		AddBtn = (UI_btn_Add)(object)((GComponent)this).GetChild("AddBtn");
		MinusBtn = (UI_btn_Minus)(object)((GComponent)this).GetChild("MinusBtn");
		QuickBuyText = (GTextField)((GComponent)this).GetChild("QuickBuyText");
		QuickBuyIcon = (GLoader)((GComponent)this).GetChild("QuickBuyIcon");
		QuickBuyBtn = (UI_btn_QuickBuy)(object)((GComponent)this).GetChild("QuickBuyBtn");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id5 = "ui://bfjg32huq1eq38".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id5);
		BuyLevelIcon = (GLoader)((GComponent)this).GetChild("BuyLevelIcon");
		BuyLevel = (GTextField)((GComponent)this).GetChild("BuyLevel");
		n73 = (GLoader)((GComponent)this).GetChild("n73");
		Score = (GTextField)((GComponent)this).GetChild("Score");
		n67 = (GTextField)((GComponent)this).GetChild("n67");
		string id6 = "ui://bfjg32huq1eq38".Replace("ui://", "") + "-" + ((GObject)n67).id;
		((GObject)n67).text = LanguagesManager.GetDesc(id6);
		SliderInfo = (GGroup)((GComponent)this).GetChild("SliderInfo");
		MaxBtn = (UI_btn_Max)(object)((GComponent)this).GetChild("MaxBtn");
		n80 = (GTextField)((GComponent)this).GetChild("n80");
		string id7 = "ui://bfjg32huq1eq38".Replace("ui://", "") + "-" + ((GObject)n80).id;
		((GObject)n80).text = LanguagesManager.GetDesc(id7);
	}
}
