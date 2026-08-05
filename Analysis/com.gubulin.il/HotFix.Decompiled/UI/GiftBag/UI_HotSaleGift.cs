using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GiftBag;

public class UI_HotSaleGift : GComponent
{
	public Controller DiscountPage;

	public Controller LimitPage;

	public Controller IsEmpty;

	public Controller IsLevelNotClear;

	public GTextField hotSaleName;

	public UI_ConfirmBuyBtn ConfirmBuyBtn;

	public GList HotSaleList;

	public GGraph Line;

	public GTextField limit;

	public GComponent Discount;

	public GTextField Price1st;

	public GLoader currentCurrencyIcon;

	public GTextField currentPriceTitle;

	public GTextField Price2nd;

	public GLoader originalCurrencyIcon;

	public GTextField originalPriceTitle;

	public GList giftList;

	public GImage n44;

	public GImage n45;

	public GImage n46;

	public GTextField tip;

	public GTextField n48;

	public GGroup empty;

	public const string URL = "ui://4fqsd8h6avmfk";

	public static string Name = "UI_HotSaleGift";

	public static string GetURL()
	{
		return "ui://4fqsd8h6avmfk";
	}

	public static UI_HotSaleGift CreateInstance()
	{
		return (UI_HotSaleGift)(object)UIPackage.CreateObject("GiftBag", "HotSaleGift");
	}

	public static UI_HotSaleGift CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HotSaleGift).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6avmfk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
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
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		DiscountPage = ((GComponent)this).GetController("DiscountPage");
		LimitPage = ((GComponent)this).GetController("LimitPage");
		IsEmpty = ((GComponent)this).GetController("IsEmpty");
		IsLevelNotClear = ((GComponent)this).GetController("IsLevelNotClear");
		hotSaleName = (GTextField)((GComponent)this).GetChild("hotSaleName");
		ConfirmBuyBtn = (UI_ConfirmBuyBtn)(object)((GComponent)this).GetChild("ConfirmBuyBtn");
		HotSaleList = (GList)((GComponent)this).GetChild("HotSaleList");
		Line = (GGraph)((GComponent)this).GetChild("Line");
		limit = (GTextField)((GComponent)this).GetChild("limit");
		Discount = (GComponent)((GComponent)this).GetChild("Discount");
		Price1st = (GTextField)((GComponent)this).GetChild("Price1st");
		currentCurrencyIcon = (GLoader)((GComponent)this).GetChild("currentCurrencyIcon");
		currentPriceTitle = (GTextField)((GComponent)this).GetChild("currentPriceTitle");
		string id = "ui://4fqsd8h6avmfk".Replace("ui://", "") + "-" + ((GObject)currentPriceTitle).id;
		((GObject)currentPriceTitle).text = LanguagesManager.GetDesc(id);
		Price2nd = (GTextField)((GComponent)this).GetChild("Price2nd");
		string id2 = "ui://4fqsd8h6avmfk".Replace("ui://", "") + "-" + ((GObject)Price2nd).id;
		((GObject)Price2nd).text = LanguagesManager.GetDesc(id2);
		originalCurrencyIcon = (GLoader)((GComponent)this).GetChild("originalCurrencyIcon");
		originalPriceTitle = (GTextField)((GComponent)this).GetChild("originalPriceTitle");
		string id3 = "ui://4fqsd8h6avmfk".Replace("ui://", "") + "-" + ((GObject)originalPriceTitle).id;
		((GObject)originalPriceTitle).text = LanguagesManager.GetDesc(id3);
		giftList = (GList)((GComponent)this).GetChild("giftList");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id4 = "ui://4fqsd8h6avmfk".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id4);
		n48 = (GTextField)((GComponent)this).GetChild("n48");
		string id5 = "ui://4fqsd8h6avmfk".Replace("ui://", "") + "-" + ((GObject)n48).id;
		((GObject)n48).text = LanguagesManager.GetDesc(id5);
		empty = (GGroup)((GComponent)this).GetChild("empty");
	}
}
