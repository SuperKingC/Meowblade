using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_OrcBuyBtn : GButton
{
	public Controller button;

	public Controller State;

	public GImage icon;

	public GImage n10;

	public GLoader Currency;

	public GTextField Price;

	public GGroup priceGroup;

	public GTextField PriceIntl;

	public GGroup priceGroupIntl;

	public const string URL = "ui://29q48tv6mbra58";

	public static string Name = "UI_OrcBuyBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6mbra58";
	}

	public static UI_OrcBuyBtn CreateInstance()
	{
		return (UI_OrcBuyBtn)(object)UIPackage.CreateObject("GameActivity", "OrcBuyBtn");
	}

	public static UI_OrcBuyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OrcBuyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6mbra58", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		icon = (GImage)((GComponent)this).GetChild("icon");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		Currency = (GLoader)((GComponent)this).GetChild("Currency");
		Price = (GTextField)((GComponent)this).GetChild("Price");
		priceGroup = (GGroup)((GComponent)this).GetChild("priceGroup");
		PriceIntl = (GTextField)((GComponent)this).GetChild("PriceIntl");
		priceGroupIntl = (GGroup)((GComponent)this).GetChild("priceGroupIntl");
	}
}
