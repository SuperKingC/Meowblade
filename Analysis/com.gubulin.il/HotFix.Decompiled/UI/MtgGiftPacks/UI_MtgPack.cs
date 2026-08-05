using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MtgGiftPacks;

public class UI_MtgPack : GButton
{
	public Controller button;

	public Controller Discount;

	public GImage back;

	public GImage iconBack;

	public GLoader icon;

	public GGraph n8;

	public GTextField result;

	public GComponent Discount_2;

	public GGraph Line;

	public GTextField Price2nd;

	public GLoader originalCurrencyIcon;

	public GTextField originalPriceTitle;

	public GTextField Price1st;

	public GLoader currentCurrencyIcon;

	public GTextField currentPriceTitle;

	public GGroup priceGroup;

	public GTextField curIntlPriceText;

	public GTextField originIntlPriceText;

	public GGraph deleteLine;

	public GGroup priceGroupIntl;

	public const string URL = "ui://4pzrvwm6mksc2";

	public static string Name = "UI_MtgPack";

	public static string GetURL()
	{
		return "ui://4pzrvwm6mksc2";
	}

	public static UI_MtgPack CreateInstance()
	{
		return (UI_MtgPack)(object)UIPackage.CreateObject("MtgGiftPacks", "MtgPack");
	}

	public static UI_MtgPack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MtgPack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4pzrvwm6mksc2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
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
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Expected O, but got Unknown
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Discount = ((GComponent)this).GetController("Discount");
		back = (GImage)((GComponent)this).GetChild("back");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n8 = (GGraph)((GComponent)this).GetChild("n8");
		result = (GTextField)((GComponent)this).GetChild("result");
		string id = "ui://4pzrvwm6mksc2".Replace("ui://", "") + "-" + ((GObject)result).id;
		((GObject)result).text = LanguagesManager.GetDesc(id);
		Discount_2 = (GComponent)((GComponent)this).GetChild("Discount");
		Line = (GGraph)((GComponent)this).GetChild("Line");
		Price2nd = (GTextField)((GComponent)this).GetChild("Price2nd");
		string id2 = "ui://4pzrvwm6mksc2".Replace("ui://", "") + "-" + ((GObject)Price2nd).id;
		((GObject)Price2nd).text = LanguagesManager.GetDesc(id2);
		originalCurrencyIcon = (GLoader)((GComponent)this).GetChild("originalCurrencyIcon");
		originalPriceTitle = (GTextField)((GComponent)this).GetChild("originalPriceTitle");
		string id3 = "ui://4pzrvwm6mksc2".Replace("ui://", "") + "-" + ((GObject)originalPriceTitle).id;
		((GObject)originalPriceTitle).text = LanguagesManager.GetDesc(id3);
		Price1st = (GTextField)((GComponent)this).GetChild("Price1st");
		currentCurrencyIcon = (GLoader)((GComponent)this).GetChild("currentCurrencyIcon");
		currentPriceTitle = (GTextField)((GComponent)this).GetChild("currentPriceTitle");
		string id4 = "ui://4pzrvwm6mksc2".Replace("ui://", "") + "-" + ((GObject)currentPriceTitle).id;
		((GObject)currentPriceTitle).text = LanguagesManager.GetDesc(id4);
		priceGroup = (GGroup)((GComponent)this).GetChild("priceGroup");
		curIntlPriceText = (GTextField)((GComponent)this).GetChild("curIntlPriceText");
		string id5 = "ui://4pzrvwm6mksc2".Replace("ui://", "") + "-" + ((GObject)curIntlPriceText).id;
		((GObject)curIntlPriceText).text = LanguagesManager.GetDesc(id5);
		originIntlPriceText = (GTextField)((GComponent)this).GetChild("originIntlPriceText");
		string id6 = "ui://4pzrvwm6mksc2".Replace("ui://", "") + "-" + ((GObject)originIntlPriceText).id;
		((GObject)originIntlPriceText).text = LanguagesManager.GetDesc(id6);
		deleteLine = (GGraph)((GComponent)this).GetChild("deleteLine");
		priceGroupIntl = (GGroup)((GComponent)this).GetChild("priceGroupIntl");
	}
}
