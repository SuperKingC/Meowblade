using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_WarOrderBuyDialog : GComponent
{
	public Controller Mode;

	public GImage Background;

	public GGraph n65;

	public GImage n64;

	public GImage Title;

	public GImage Title2_1;

	public GLoader LevelIcon;

	public GTextField LevelNum;

	public GImage Title2_3;

	public GGroup Title2;

	public GList ClaimableList;

	public UI_BuyBtn BuyBtn;

	public UI_CSlider Slider;

	public UI_AddButton AddBtn;

	public UI_MinusButton MinusBtn;

	public GTextField QuickBuyText;

	public GLoader QuickBuyIcon;

	public UI_QuickBuyBtn QuickBuyBtn;

	public GTextField n26;

	public GLoader BuyLevelIcon;

	public GTextField BuyLevelNum;

	public GGroup SliderInfo;

	public UI_MaxBtn MaxBtn;

	public const string URL = "ui://ax280w58okbc1o";

	public static string Name = "UI_WarOrderBuyDialog";

	public static string GetURL()
	{
		return "ui://ax280w58okbc1o";
	}

	public static UI_WarOrderBuyDialog CreateInstance()
	{
		return (UI_WarOrderBuyDialog)(object)UIPackage.CreateObject("WarOrder", "WarOrderBuyDialog");
	}

	public static UI_WarOrderBuyDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WarOrderBuyDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58okbc1o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mode = ((GComponent)this).GetController("Mode");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n65 = (GGraph)((GComponent)this).GetChild("n65");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		Title = (GImage)((GComponent)this).GetChild("Title");
		Title2_1 = (GImage)((GComponent)this).GetChild("Title2_1");
		LevelIcon = (GLoader)((GComponent)this).GetChild("LevelIcon");
		LevelNum = (GTextField)((GComponent)this).GetChild("LevelNum");
		Title2_3 = (GImage)((GComponent)this).GetChild("Title2_3");
		Title2 = (GGroup)((GComponent)this).GetChild("Title2");
		ClaimableList = (GList)((GComponent)this).GetChild("ClaimableList");
		BuyBtn = (UI_BuyBtn)(object)((GComponent)this).GetChild("BuyBtn");
		Slider = (UI_CSlider)(object)((GComponent)this).GetChild("Slider");
		AddBtn = (UI_AddButton)(object)((GComponent)this).GetChild("AddBtn");
		MinusBtn = (UI_MinusButton)(object)((GComponent)this).GetChild("MinusBtn");
		QuickBuyText = (GTextField)((GComponent)this).GetChild("QuickBuyText");
		QuickBuyIcon = (GLoader)((GComponent)this).GetChild("QuickBuyIcon");
		QuickBuyBtn = (UI_QuickBuyBtn)(object)((GComponent)this).GetChild("QuickBuyBtn");
		n26 = (GTextField)((GComponent)this).GetChild("n26");
		string id = "ui://ax280w58okbc1o".Replace("ui://", "") + "-" + ((GObject)n26).id;
		((GObject)n26).text = LanguagesManager.GetDesc(id);
		BuyLevelIcon = (GLoader)((GComponent)this).GetChild("BuyLevelIcon");
		BuyLevelNum = (GTextField)((GComponent)this).GetChild("BuyLevelNum");
		string id2 = "ui://ax280w58okbc1o".Replace("ui://", "") + "-" + ((GObject)BuyLevelNum).id;
		((GObject)BuyLevelNum).text = LanguagesManager.GetDesc(id2);
		SliderInfo = (GGroup)((GComponent)this).GetChild("SliderInfo");
		MaxBtn = (UI_MaxBtn)(object)((GComponent)this).GetChild("MaxBtn");
	}
}
