using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_btn_BuyBtn : GButton
{
	public Controller button;

	public GImage back;

	public GLoader icon;

	public GTextField Price;

	public GLoader Currency;

	public GGroup priceGroup;

	public GTextField curIntlPriceText;

	public const string URL = "ui://bfjg32huq1eq2u";

	public static string Name = "UI_btn_BuyBtn";

	public static string GetURL()
	{
		return "ui://bfjg32huq1eq2u";
	}

	public static UI_btn_BuyBtn CreateInstance()
	{
		return (UI_btn_BuyBtn)(object)UIPackage.CreateObject("GvGBattlePass3", "btn_BuyBtn");
	}

	public static UI_btn_BuyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BuyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32huq1eq2u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		Price = (GTextField)((GComponent)this).GetChild("Price");
		string id = "ui://bfjg32huq1eq2u".Replace("ui://", "") + "-" + ((GObject)Price).id;
		((GObject)Price).text = LanguagesManager.GetDesc(id);
		Currency = (GLoader)((GComponent)this).GetChild("Currency");
		priceGroup = (GGroup)((GComponent)this).GetChild("priceGroup");
		curIntlPriceText = (GTextField)((GComponent)this).GetChild("curIntlPriceText");
	}
}
