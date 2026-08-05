using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemsStore;

public class UI_AddCreditCard : GButton
{
	public Controller button;

	public Controller RewardController;

	public Controller Discount;

	public GImage back;

	public GGraph sfxBack;

	public GLoader icon;

	public UI_FirstTimeDouble FirstTimeDouble;

	public GTextField result;

	public GTextField reward;

	public GComponent Discount_2;

	public GTextField Price2nd;

	public GGraph Line;

	public GLoader originalCurrencyIcon;

	public GTextField originalPriceTitle;

	public GTextField Price1st;

	public GLoader currentCurrencyIcon;

	public GTextField currentPriceTitle;

	public const string URL = "ui://i6o930evfjjs9";

	public static string Name = "UI_AddCreditCard";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://i6o930evfjjs9".Replace("ui://", ""), ((GObject)currentPriceTitle).id, Discount.selectedIndex);
		((GObject)currentPriceTitle).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://i6o930evfjjs9";
	}

	public static UI_AddCreditCard CreateInstance()
	{
		return (UI_AddCreditCard)(object)UIPackage.CreateObject("LegendItemsStore", "AddCreditCard");
	}

	public static UI_AddCreditCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AddCreditCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://i6o930evfjjs9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RewardController = ((GComponent)this).GetController("RewardController");
		Discount = ((GComponent)this).GetController("Discount");
		back = (GImage)((GComponent)this).GetChild("back");
		sfxBack = (GGraph)((GComponent)this).GetChild("sfxBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		FirstTimeDouble = (UI_FirstTimeDouble)(object)((GComponent)this).GetChild("FirstTimeDouble");
		result = (GTextField)((GComponent)this).GetChild("result");
		string id = "ui://i6o930evfjjs9".Replace("ui://", "") + "-" + ((GObject)result).id;
		((GObject)result).text = LanguagesManager.GetDesc(id);
		reward = (GTextField)((GComponent)this).GetChild("reward");
		string id2 = "ui://i6o930evfjjs9".Replace("ui://", "") + "-" + ((GObject)reward).id;
		((GObject)reward).text = LanguagesManager.GetDesc(id2);
		Discount_2 = (GComponent)((GComponent)this).GetChild("Discount");
		Price2nd = (GTextField)((GComponent)this).GetChild("Price2nd");
		string id3 = "ui://i6o930evfjjs9".Replace("ui://", "") + "-" + ((GObject)Price2nd).id;
		((GObject)Price2nd).text = LanguagesManager.GetDesc(id3);
		Line = (GGraph)((GComponent)this).GetChild("Line");
		originalCurrencyIcon = (GLoader)((GComponent)this).GetChild("originalCurrencyIcon");
		originalPriceTitle = (GTextField)((GComponent)this).GetChild("originalPriceTitle");
		string id4 = "ui://i6o930evfjjs9".Replace("ui://", "") + "-" + ((GObject)originalPriceTitle).id;
		((GObject)originalPriceTitle).text = LanguagesManager.GetDesc(id4);
		Price1st = (GTextField)((GComponent)this).GetChild("Price1st");
		currentCurrencyIcon = (GLoader)((GComponent)this).GetChild("currentCurrencyIcon");
		currentPriceTitle = (GTextField)((GComponent)this).GetChild("currentPriceTitle");
		string id5 = "ui://i6o930evfjjs9".Replace("ui://", "") + "-" + ((GObject)currentPriceTitle).id;
		((GObject)currentPriceTitle).text = LanguagesManager.GetDesc(id5);
	}
}
