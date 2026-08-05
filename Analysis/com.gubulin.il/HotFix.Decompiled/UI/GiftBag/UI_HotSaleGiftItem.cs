using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GiftBag;

public class UI_HotSaleGiftItem : GComponent
{
	public Controller IsShowTime;

	public GImage n0;

	public GGraph n18;

	public GImage n20;

	public GLoader icon;

	public GComponent Discount;

	public GTextField countLimit;

	public GTextField timeLimit;

	public GTextField name;

	public GTextField content;

	public GGraph iconSfx;

	public GImage clockIcon;

	public GTextField Price1st;

	public GLoader currentCurrencyIcon;

	public GTextField currentPriceTitle;

	public GGroup priceGroup;

	public GTextField curIntlPriceText;

	public GGroup priceGroupIntl;

	public const string URL = "ui://4fqsd8h6t1jru";

	public static string Name = "UI_HotSaleGiftItem";

	public static string GetURL()
	{
		return "ui://4fqsd8h6t1jru";
	}

	public static UI_HotSaleGiftItem CreateInstance()
	{
		return (UI_HotSaleGiftItem)(object)UIPackage.CreateObject("GiftBag", "HotSaleGiftItem");
	}

	public static UI_HotSaleGiftItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_HotSaleGiftItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4fqsd8h6t1jru", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
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
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected O, but got Unknown
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsShowTime = ((GComponent)this).GetController("IsShowTime");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n18 = (GGraph)((GComponent)this).GetChild("n18");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		Discount = (GComponent)((GComponent)this).GetChild("Discount");
		countLimit = (GTextField)((GComponent)this).GetChild("countLimit");
		string id = "ui://4fqsd8h6t1jru".Replace("ui://", "") + "-" + ((GObject)countLimit).id;
		((GObject)countLimit).text = LanguagesManager.GetDesc(id);
		timeLimit = (GTextField)((GComponent)this).GetChild("timeLimit");
		string id2 = "ui://4fqsd8h6t1jru".Replace("ui://", "") + "-" + ((GObject)timeLimit).id;
		((GObject)timeLimit).text = LanguagesManager.GetDesc(id2);
		name = (GTextField)((GComponent)this).GetChild("name");
		string id3 = "ui://4fqsd8h6t1jru".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id3);
		content = (GTextField)((GComponent)this).GetChild("content");
		string id4 = "ui://4fqsd8h6t1jru".Replace("ui://", "") + "-" + ((GObject)content).id;
		((GObject)content).text = LanguagesManager.GetDesc(id4);
		iconSfx = (GGraph)((GComponent)this).GetChild("iconSfx");
		clockIcon = (GImage)((GComponent)this).GetChild("clockIcon");
		Price1st = (GTextField)((GComponent)this).GetChild("Price1st");
		currentCurrencyIcon = (GLoader)((GComponent)this).GetChild("currentCurrencyIcon");
		currentPriceTitle = (GTextField)((GComponent)this).GetChild("currentPriceTitle");
		string id5 = "ui://4fqsd8h6t1jru".Replace("ui://", "") + "-" + ((GObject)currentPriceTitle).id;
		((GObject)currentPriceTitle).text = LanguagesManager.GetDesc(id5);
		priceGroup = (GGroup)((GComponent)this).GetChild("priceGroup");
		curIntlPriceText = (GTextField)((GComponent)this).GetChild("curIntlPriceText");
		priceGroupIntl = (GGroup)((GComponent)this).GetChild("priceGroupIntl");
	}
}
