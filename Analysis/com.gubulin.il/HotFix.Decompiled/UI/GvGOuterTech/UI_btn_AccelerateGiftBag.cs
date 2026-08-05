using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_btn_AccelerateGiftBag : GButton
{
	public Controller GiftBagStauts;

	public Controller CurrencyType;

	public GImage n158;

	public GImage n153;

	public GLoader n154;

	public GTextField Qty;

	public GImage n156;

	public GTextField BuyLimit;

	public GTextField RMBPrice;

	public GGroup RMBPriceDisplay;

	public GLoader CurrencyIcon;

	public GTextField Price;

	public GGroup PriceDisplay;

	public const string URL = "ui://th385mttn6wlo8x";

	public static string Name = "UI_btn_AccelerateGiftBag";

	public static string GetURL()
	{
		return "ui://th385mttn6wlo8x";
	}

	public static UI_btn_AccelerateGiftBag CreateInstance()
	{
		return (UI_btn_AccelerateGiftBag)(object)UIPackage.CreateObject("GvGOuterTech", "btn_AccelerateGiftBag");
	}

	public static UI_btn_AccelerateGiftBag CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_AccelerateGiftBag).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttn6wlo8x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		GiftBagStauts = ((GComponent)this).GetController("GiftBagStauts");
		CurrencyType = ((GComponent)this).GetController("CurrencyType");
		n158 = (GImage)((GComponent)this).GetChild("n158");
		n153 = (GImage)((GComponent)this).GetChild("n153");
		n154 = (GLoader)((GComponent)this).GetChild("n154");
		Qty = (GTextField)((GComponent)this).GetChild("Qty");
		n156 = (GImage)((GComponent)this).GetChild("n156");
		BuyLimit = (GTextField)((GComponent)this).GetChild("BuyLimit");
		RMBPrice = (GTextField)((GComponent)this).GetChild("RMBPrice");
		RMBPriceDisplay = (GGroup)((GComponent)this).GetChild("RMBPriceDisplay");
		CurrencyIcon = (GLoader)((GComponent)this).GetChild("CurrencyIcon");
		Price = (GTextField)((GComponent)this).GetChild("Price");
		PriceDisplay = (GGroup)((GComponent)this).GetChild("PriceDisplay");
	}
}
