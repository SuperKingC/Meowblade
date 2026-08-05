using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_AddCreditCard : GButton
{
	public Controller button;

	public Controller RewardController;

	public Controller Discount;

	public Controller region;

	public GImage back;

	public GImage iconBack;

	public GLoader icon;

	public UI_FirstTimeDouble FirstTimeDouble;

	public GTextField result;

	public GTextField reward;

	public GImage n28;

	public GTextField Price2nd;

	public GGraph Line;

	public GLoader originalCurrencyIcon;

	public GTextField originalPriceTitle;

	public GTextField currentPriceTitle;

	public GLoader currentCurrencyIcon;

	public GTextField Price1st;

	public GGroup priceZhGroup;

	public GTextField currentPriceTitleSea;

	public GTextField Price1stSea;

	public GGroup priceSeaGroup;

	public const string URL = "ui://kozswd8hndja4";

	public static string Name = "UI_AddCreditCard";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://kozswd8hndja4".Replace("ui://", ""), ((GObject)currentPriceTitle).id, Discount.selectedIndex);
		((GObject)currentPriceTitle).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://kozswd8hndja4";
	}

	public static UI_AddCreditCard CreateInstance()
	{
		return (UI_AddCreditCard)(object)UIPackage.CreateObject("SpecialActivity", "AddCreditCard");
	}

	public static UI_AddCreditCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AddCreditCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hndja4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected O, but got Unknown
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RewardController = ((GComponent)this).GetController("RewardController");
		Discount = ((GComponent)this).GetController("Discount");
		region = ((GComponent)this).GetController("region");
		back = (GImage)((GComponent)this).GetChild("back");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		FirstTimeDouble = (UI_FirstTimeDouble)(object)((GComponent)this).GetChild("FirstTimeDouble");
		result = (GTextField)((GComponent)this).GetChild("result");
		string id = "ui://kozswd8hndja4".Replace("ui://", "") + "-" + ((GObject)result).id;
		((GObject)result).text = LanguagesManager.GetDesc(id);
		reward = (GTextField)((GComponent)this).GetChild("reward");
		string id2 = "ui://kozswd8hndja4".Replace("ui://", "") + "-" + ((GObject)reward).id;
		((GObject)reward).text = LanguagesManager.GetDesc(id2);
		n28 = (GImage)((GComponent)this).GetChild("n28");
		Price2nd = (GTextField)((GComponent)this).GetChild("Price2nd");
		string id3 = "ui://kozswd8hndja4".Replace("ui://", "") + "-" + ((GObject)Price2nd).id;
		((GObject)Price2nd).text = LanguagesManager.GetDesc(id3);
		Line = (GGraph)((GComponent)this).GetChild("Line");
		originalCurrencyIcon = (GLoader)((GComponent)this).GetChild("originalCurrencyIcon");
		originalPriceTitle = (GTextField)((GComponent)this).GetChild("originalPriceTitle");
		string id4 = "ui://kozswd8hndja4".Replace("ui://", "") + "-" + ((GObject)originalPriceTitle).id;
		((GObject)originalPriceTitle).text = LanguagesManager.GetDesc(id4);
		currentPriceTitle = (GTextField)((GComponent)this).GetChild("currentPriceTitle");
		string id5 = "ui://kozswd8hndja4".Replace("ui://", "") + "-" + ((GObject)currentPriceTitle).id;
		((GObject)currentPriceTitle).text = LanguagesManager.GetDesc(id5);
		currentCurrencyIcon = (GLoader)((GComponent)this).GetChild("currentCurrencyIcon");
		Price1st = (GTextField)((GComponent)this).GetChild("Price1st");
		priceZhGroup = (GGroup)((GComponent)this).GetChild("priceZhGroup");
		currentPriceTitleSea = (GTextField)((GComponent)this).GetChild("currentPriceTitleSea");
		string id6 = "ui://kozswd8hndja4".Replace("ui://", "") + "-" + ((GObject)currentPriceTitleSea).id;
		((GObject)currentPriceTitleSea).text = LanguagesManager.GetDesc(id6);
		Price1stSea = (GTextField)((GComponent)this).GetChild("Price1stSea");
		priceSeaGroup = (GGroup)((GComponent)this).GetChild("priceSeaGroup");
	}
}
