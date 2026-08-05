using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_TakeContent : GComponent
{
	public Controller OperationPageController;

	public Controller NestingGiftBagType;

	public Controller HelpType;

	public GImage nameBack;

	public GTextField NestingGiftBagTitle;

	public GTextField name;

	public GImage n93;

	public GImage n89;

	public GLoader n90;

	public UI_PriceContainer Price;

	public GButton confirmBtn;

	public GList materialList;

	public GList selectedList;

	public GGraph tipBack;

	public GTextField tip;

	public GButton ConfirmBuyBtn;

	public GButton ConfirmTakeBtn;

	public GButton ConfirmSelectBtn;

	public GButton ConfirmBtn;

	public GGraph tip1stBack;

	public GTextField tip1stText;

	public GGroup tip1st;

	public GTextField title2nd;

	public GLoader compoundNumBack;

	public GTextField compoundNum;

	public UI_increaseButton increaseBtn;

	public UI_reduceButton reduceBtn;

	public UI_MaxValueBtn MaxValueBtn;

	public GGroup n77;

	public UI_ItemsCounter ItemsCounter;

	public GComponent DiscountCom;

	public GMovieClip n94;

	public GImage n95;

	public GButton Help;

	public GTextField BuyLimitTitle;

	public GTextField BuyLimit;

	public GGroup BuyLimitGroup;

	public GTextField TimeLimitTitle;

	public GTextField TimeLimit;

	public GGroup TimeLimitGroup;

	public Transition ShowSelectedItem;

	public const string URL = "ui://47lbpgx9h7os2k";

	public static string Name = "UI_TakeContent";

	public static string GetURL()
	{
		return "ui://47lbpgx9h7os2k";
	}

	public static UI_TakeContent CreateInstance()
	{
		return (UI_TakeContent)(object)UIPackage.CreateObject("Tips", "TakeContent");
	}

	public static UI_TakeContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TakeContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9h7os2k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
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
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
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
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Expected O, but got Unknown
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Expected O, but got Unknown
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Expected O, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected O, but got Unknown
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected O, but got Unknown
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Expected O, but got Unknown
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Expected O, but got Unknown
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Expected O, but got Unknown
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Expected O, but got Unknown
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		//IL_051b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		OperationPageController = ((GComponent)this).GetController("OperationPageController");
		NestingGiftBagType = ((GComponent)this).GetController("NestingGiftBagType");
		HelpType = ((GComponent)this).GetController("HelpType");
		nameBack = (GImage)((GComponent)this).GetChild("nameBack");
		NestingGiftBagTitle = (GTextField)((GComponent)this).GetChild("NestingGiftBagTitle");
		name = (GTextField)((GComponent)this).GetChild("name");
		string id = "ui://47lbpgx9h7os2k".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id);
		n93 = (GImage)((GComponent)this).GetChild("n93");
		n89 = (GImage)((GComponent)this).GetChild("n89");
		n90 = (GLoader)((GComponent)this).GetChild("n90");
		Price = (UI_PriceContainer)(object)((GComponent)this).GetChild("Price");
		confirmBtn = (GButton)((GComponent)this).GetChild("confirmBtn");
		materialList = (GList)((GComponent)this).GetChild("materialList");
		selectedList = (GList)((GComponent)this).GetChild("selectedList");
		tipBack = (GGraph)((GComponent)this).GetChild("tipBack");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://47lbpgx9h7os2k".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		ConfirmBuyBtn = (GButton)((GComponent)this).GetChild("ConfirmBuyBtn");
		ConfirmTakeBtn = (GButton)((GComponent)this).GetChild("ConfirmTakeBtn");
		ConfirmSelectBtn = (GButton)((GComponent)this).GetChild("ConfirmSelectBtn");
		ConfirmBtn = (GButton)((GComponent)this).GetChild("ConfirmBtn");
		tip1stBack = (GGraph)((GComponent)this).GetChild("tip1stBack");
		tip1stText = (GTextField)((GComponent)this).GetChild("tip1stText");
		tip1st = (GGroup)((GComponent)this).GetChild("tip1st");
		title2nd = (GTextField)((GComponent)this).GetChild("title2nd");
		string id3 = "ui://47lbpgx9h7os2k".Replace("ui://", "") + "-" + ((GObject)title2nd).id;
		((GObject)title2nd).text = LanguagesManager.GetDesc(id3);
		compoundNumBack = (GLoader)((GComponent)this).GetChild("compoundNumBack");
		compoundNum = (GTextField)((GComponent)this).GetChild("compoundNum");
		increaseBtn = (UI_increaseButton)(object)((GComponent)this).GetChild("increaseBtn");
		reduceBtn = (UI_reduceButton)(object)((GComponent)this).GetChild("reduceBtn");
		MaxValueBtn = (UI_MaxValueBtn)(object)((GComponent)this).GetChild("MaxValueBtn");
		n77 = (GGroup)((GComponent)this).GetChild("n77");
		ItemsCounter = (UI_ItemsCounter)(object)((GComponent)this).GetChild("ItemsCounter");
		DiscountCom = (GComponent)((GComponent)this).GetChild("DiscountCom");
		n94 = (GMovieClip)((GComponent)this).GetChild("n94");
		n95 = (GImage)((GComponent)this).GetChild("n95");
		Help = (GButton)((GComponent)this).GetChild("Help");
		BuyLimitTitle = (GTextField)((GComponent)this).GetChild("BuyLimitTitle");
		string id4 = "ui://47lbpgx9h7os2k".Replace("ui://", "") + "-" + ((GObject)BuyLimitTitle).id;
		((GObject)BuyLimitTitle).text = LanguagesManager.GetDesc(id4);
		BuyLimit = (GTextField)((GComponent)this).GetChild("BuyLimit");
		string id5 = "ui://47lbpgx9h7os2k".Replace("ui://", "") + "-" + ((GObject)BuyLimit).id;
		((GObject)BuyLimit).text = LanguagesManager.GetDesc(id5);
		BuyLimitGroup = (GGroup)((GComponent)this).GetChild("BuyLimitGroup");
		TimeLimitTitle = (GTextField)((GComponent)this).GetChild("TimeLimitTitle");
		string id6 = "ui://47lbpgx9h7os2k".Replace("ui://", "") + "-" + ((GObject)TimeLimitTitle).id;
		((GObject)TimeLimitTitle).text = LanguagesManager.GetDesc(id6);
		TimeLimit = (GTextField)((GComponent)this).GetChild("TimeLimit");
		string id7 = "ui://47lbpgx9h7os2k".Replace("ui://", "") + "-" + ((GObject)TimeLimit).id;
		((GObject)TimeLimit).text = LanguagesManager.GetDesc(id7);
		TimeLimitGroup = (GGroup)((GComponent)this).GetChild("TimeLimitGroup");
		ShowSelectedItem = ((GComponent)this).GetTransition("ShowSelectedItem");
	}
}
