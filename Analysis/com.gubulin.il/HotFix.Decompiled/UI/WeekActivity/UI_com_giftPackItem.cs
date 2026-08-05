using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_com_giftPackItem : GButton
{
	public Controller button;

	public Controller region;

	public Controller RewardController;

	public Controller CurrencyType;

	public GImage back;

	public GTextField reward;

	public GTextField currentPriceTitle;

	public GLoader currentCurrencyIcon;

	public GTextField Price1st;

	public GGroup priceZhGroup;

	public GTextField currentPriceTitleSea;

	public GTextField Price1stSea;

	public GGroup priceSeaGroup;

	public GList giftList;

	public GImage n60;

	public const string URL = "ui://jl0c82y5hah9f";

	public static string Name = "UI_com_giftPackItem";

	public static string GetURL()
	{
		return "ui://jl0c82y5hah9f";
	}

	public static UI_com_giftPackItem CreateInstance()
	{
		return (UI_com_giftPackItem)(object)UIPackage.CreateObject("WeekActivity", "com_giftPackItem");
	}

	public static UI_com_giftPackItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_giftPackItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5hah9f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		region = ((GComponent)this).GetController("region");
		RewardController = ((GComponent)this).GetController("RewardController");
		CurrencyType = ((GComponent)this).GetController("CurrencyType");
		back = (GImage)((GComponent)this).GetChild("back");
		reward = (GTextField)((GComponent)this).GetChild("reward");
		string id = "ui://jl0c82y5hah9f".Replace("ui://", "") + "-" + ((GObject)reward).id;
		((GObject)reward).text = LanguagesManager.GetDesc(id);
		currentPriceTitle = (GTextField)((GComponent)this).GetChild("currentPriceTitle");
		string id2 = "ui://jl0c82y5hah9f".Replace("ui://", "") + "-" + ((GObject)currentPriceTitle).id;
		((GObject)currentPriceTitle).text = LanguagesManager.GetDesc(id2);
		currentCurrencyIcon = (GLoader)((GComponent)this).GetChild("currentCurrencyIcon");
		Price1st = (GTextField)((GComponent)this).GetChild("Price1st");
		priceZhGroup = (GGroup)((GComponent)this).GetChild("priceZhGroup");
		currentPriceTitleSea = (GTextField)((GComponent)this).GetChild("currentPriceTitleSea");
		string id3 = "ui://jl0c82y5hah9f".Replace("ui://", "") + "-" + ((GObject)currentPriceTitleSea).id;
		((GObject)currentPriceTitleSea).text = LanguagesManager.GetDesc(id3);
		Price1stSea = (GTextField)((GComponent)this).GetChild("Price1stSea");
		priceSeaGroup = (GGroup)((GComponent)this).GetChild("priceSeaGroup");
		giftList = (GList)((GComponent)this).GetChild("giftList");
		n60 = (GImage)((GComponent)this).GetChild("n60");
	}
}
