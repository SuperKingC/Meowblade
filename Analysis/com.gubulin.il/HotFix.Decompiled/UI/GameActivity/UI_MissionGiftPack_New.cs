using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_MissionGiftPack_New : GComponent
{
	public Controller RewardStatus;

	public Controller IsFree;

	public Controller bg;

	public Controller ClaimStatus;

	public Controller DisplayTimer;

	public GImage back;

	public GGroup n38;

	public GImage mask;

	public GGroup mask1;

	public GTextField num;

	public GTextField name;

	public GGraph tipBg;

	public GTextField tip;

	public GTextField initPriceTitle;

	public GLoader initCurrencyIcon;

	public GTextField initPrice;

	public GGraph line;

	public GTextField curPriceTitle;

	public GLoader curCurrencyIcon;

	public GTextField curPrice;

	public GGroup priceGroup;

	public GTextField curIntlPriceText;

	public GTextField originIntlPriceText;

	public GGraph deleteLine;

	public GGroup priceGroupIntl;

	public GImage n28;

	public UI_Timer Timer;

	public UI_RedeemGiftBtn RedeemBtn;

	public GGroup n32;

	public GTextField n40;

	public GImage n34;

	public GGroup mask3;

	public UI_MissionGiftIconBtn Icon;

	public GImage n45;

	public GButton ReceivedBtn;

	public GComponent Discount;

	public GGraph back2;

	public GLoader icon2nd;

	public GTextField name2nd;

	public GTextField num2nd;

	public GGroup n23;

	public const string URL = "ui://29q48tv6j6fy7x";

	public static string Name = "UI_MissionGiftPack_New";

	public static string GetURL()
	{
		return "ui://29q48tv6j6fy7x";
	}

	public static UI_MissionGiftPack_New CreateInstance()
	{
		return (UI_MissionGiftPack_New)(object)UIPackage.CreateObject("GameActivity", "MissionGiftPack_New");
	}

	public static UI_MissionGiftPack_New CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MissionGiftPack_New).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6j6fy7x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected O, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected O, but got Unknown
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Expected O, but got Unknown
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Expected O, but got Unknown
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Expected O, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Expected O, but got Unknown
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Expected O, but got Unknown
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Expected O, but got Unknown
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Expected O, but got Unknown
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Expected O, but got Unknown
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Expected O, but got Unknown
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Expected O, but got Unknown
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Expected O, but got Unknown
		//IL_0507: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Expected O, but got Unknown
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0527: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RewardStatus = ((GComponent)this).GetController("RewardStatus");
		IsFree = ((GComponent)this).GetController("IsFree");
		bg = ((GComponent)this).GetController("bg");
		ClaimStatus = ((GComponent)this).GetController("ClaimStatus");
		DisplayTimer = ((GComponent)this).GetController("DisplayTimer");
		back = (GImage)((GComponent)this).GetChild("back");
		n38 = (GGroup)((GComponent)this).GetChild("n38");
		mask = (GImage)((GComponent)this).GetChild("mask");
		mask1 = (GGroup)((GComponent)this).GetChild("mask1");
		num = (GTextField)((GComponent)this).GetChild("num");
		name = (GTextField)((GComponent)this).GetChild("name");
		tipBg = (GGraph)((GComponent)this).GetChild("tipBg");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://29q48tv6j6fy7x".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		initPriceTitle = (GTextField)((GComponent)this).GetChild("initPriceTitle");
		string id2 = "ui://29q48tv6j6fy7x".Replace("ui://", "") + "-" + ((GObject)initPriceTitle).id;
		((GObject)initPriceTitle).text = LanguagesManager.GetDesc(id2);
		initCurrencyIcon = (GLoader)((GComponent)this).GetChild("initCurrencyIcon");
		initPrice = (GTextField)((GComponent)this).GetChild("initPrice");
		line = (GGraph)((GComponent)this).GetChild("line");
		curPriceTitle = (GTextField)((GComponent)this).GetChild("curPriceTitle");
		string id3 = "ui://29q48tv6j6fy7x".Replace("ui://", "") + "-" + ((GObject)curPriceTitle).id;
		((GObject)curPriceTitle).text = LanguagesManager.GetDesc(id3);
		curCurrencyIcon = (GLoader)((GComponent)this).GetChild("curCurrencyIcon");
		curPrice = (GTextField)((GComponent)this).GetChild("curPrice");
		priceGroup = (GGroup)((GComponent)this).GetChild("priceGroup");
		curIntlPriceText = (GTextField)((GComponent)this).GetChild("curIntlPriceText");
		string id4 = "ui://29q48tv6j6fy7x".Replace("ui://", "") + "-" + ((GObject)curIntlPriceText).id;
		((GObject)curIntlPriceText).text = LanguagesManager.GetDesc(id4);
		originIntlPriceText = (GTextField)((GComponent)this).GetChild("originIntlPriceText");
		string id5 = "ui://29q48tv6j6fy7x".Replace("ui://", "") + "-" + ((GObject)originIntlPriceText).id;
		((GObject)originIntlPriceText).text = LanguagesManager.GetDesc(id5);
		deleteLine = (GGraph)((GComponent)this).GetChild("deleteLine");
		priceGroupIntl = (GGroup)((GComponent)this).GetChild("priceGroupIntl");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		Timer = (UI_Timer)(object)((GComponent)this).GetChild("Timer");
		RedeemBtn = (UI_RedeemGiftBtn)(object)((GComponent)this).GetChild("RedeemBtn");
		n32 = (GGroup)((GComponent)this).GetChild("n32");
		n40 = (GTextField)((GComponent)this).GetChild("n40");
		string id6 = "ui://29q48tv6j6fy7x".Replace("ui://", "") + "-" + ((GObject)n40).id;
		((GObject)n40).text = LanguagesManager.GetDesc(id6);
		n34 = (GImage)((GComponent)this).GetChild("n34");
		mask3 = (GGroup)((GComponent)this).GetChild("mask3");
		Icon = (UI_MissionGiftIconBtn)(object)((GComponent)this).GetChild("Icon");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		ReceivedBtn = (GButton)((GComponent)this).GetChild("ReceivedBtn");
		Discount = (GComponent)((GComponent)this).GetChild("Discount");
		back2 = (GGraph)((GComponent)this).GetChild("back2");
		icon2nd = (GLoader)((GComponent)this).GetChild("icon2nd");
		name2nd = (GTextField)((GComponent)this).GetChild("name2nd");
		string id7 = "ui://29q48tv6j6fy7x".Replace("ui://", "") + "-" + ((GObject)name2nd).id;
		((GObject)name2nd).text = LanguagesManager.GetDesc(id7);
		num2nd = (GTextField)((GComponent)this).GetChild("num2nd");
		n23 = (GGroup)((GComponent)this).GetChild("n23");
	}
}
