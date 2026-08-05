using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_PriceContainer : GComponent
{
	public Controller DiscountPageController;

	public GTextField originalPriceTitle;

	public GRichTextField originalPrice;

	public GLoader originalCurrencyIcon;

	public GTextField currentPriceTitle;

	public GRichTextField currentPrice;

	public GLoader currentCurrencyIcon;

	public GGraph line;

	public GGroup priceGroup;

	public GTextField curIntlPriceText;

	public GTextField originIntlPriceText;

	public GGraph deleteLine;

	public GGroup priceGroupIntl;

	public const string URL = "ui://47lbpgx9e6o8tax";

	public static string Name = "UI_PriceContainer";

	public static string GetURL()
	{
		return "ui://47lbpgx9e6o8tax";
	}

	public static UI_PriceContainer CreateInstance()
	{
		return (UI_PriceContainer)(object)UIPackage.CreateObject("Tips", "PriceContainer");
	}

	public static UI_PriceContainer CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PriceContainer).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9e6o8tax", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		DiscountPageController = ((GComponent)this).GetController("DiscountPageController");
		originalPriceTitle = (GTextField)((GComponent)this).GetChild("originalPriceTitle");
		string id = "ui://47lbpgx9e6o8tax".Replace("ui://", "") + "-" + ((GObject)originalPriceTitle).id;
		((GObject)originalPriceTitle).text = LanguagesManager.GetDesc(id);
		originalPrice = (GRichTextField)((GComponent)this).GetChild("originalPrice");
		originalCurrencyIcon = (GLoader)((GComponent)this).GetChild("originalCurrencyIcon");
		currentPriceTitle = (GTextField)((GComponent)this).GetChild("currentPriceTitle");
		string id2 = "ui://47lbpgx9e6o8tax".Replace("ui://", "") + "-" + ((GObject)currentPriceTitle).id;
		((GObject)currentPriceTitle).text = LanguagesManager.GetDesc(id2);
		currentPrice = (GRichTextField)((GComponent)this).GetChild("currentPrice");
		currentCurrencyIcon = (GLoader)((GComponent)this).GetChild("currentCurrencyIcon");
		line = (GGraph)((GComponent)this).GetChild("line");
		priceGroup = (GGroup)((GComponent)this).GetChild("priceGroup");
		curIntlPriceText = (GTextField)((GComponent)this).GetChild("curIntlPriceText");
		originIntlPriceText = (GTextField)((GComponent)this).GetChild("originIntlPriceText");
		string id3 = "ui://47lbpgx9e6o8tax".Replace("ui://", "") + "-" + ((GObject)originIntlPriceText).id;
		((GObject)originIntlPriceText).text = LanguagesManager.GetDesc(id3);
		deleteLine = (GGraph)((GComponent)this).GetChild("deleteLine");
		priceGroupIntl = (GGroup)((GComponent)this).GetChild("priceGroupIntl");
	}
}
