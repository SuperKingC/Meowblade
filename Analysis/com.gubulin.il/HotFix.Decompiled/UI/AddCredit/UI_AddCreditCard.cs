using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AddCredit;

public class UI_AddCreditCard : GButton
{
	public Controller button;

	public Controller RewardController;

	public Controller Discount;

	public GImage back;

	public GImage iconBack;

	public GLoader icon;

	public UI_FirstTimeDouble FirstTimeDouble;

	public GGraph n8;

	public GTextField result;

	public GTextField reward;

	public GTextField tip;

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

	public const string URL = "ui://4pot8w0vavmf2";

	public static string Name = "UI_AddCreditCard";

	public static string GetURL()
	{
		return "ui://4pot8w0vavmf2";
	}

	public static UI_AddCreditCard CreateInstance()
	{
		return (UI_AddCreditCard)(object)UIPackage.CreateObject("AddCredit", "AddCreditCard");
	}

	public static UI_AddCreditCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AddCreditCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4pot8w0vavmf2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
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
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected O, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected O, but got Unknown
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RewardController = ((GComponent)this).GetController("RewardController");
		Discount = ((GComponent)this).GetController("Discount");
		back = (GImage)((GComponent)this).GetChild("back");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		FirstTimeDouble = (UI_FirstTimeDouble)(object)((GComponent)this).GetChild("FirstTimeDouble");
		n8 = (GGraph)((GComponent)this).GetChild("n8");
		result = (GTextField)((GComponent)this).GetChild("result");
		string id = "ui://4pot8w0vavmf2".Replace("ui://", "") + "-" + ((GObject)result).id;
		((GObject)result).text = LanguagesManager.GetDesc(id);
		reward = (GTextField)((GComponent)this).GetChild("reward");
		string id2 = "ui://4pot8w0vavmf2".Replace("ui://", "") + "-" + ((GObject)reward).id;
		((GObject)reward).text = LanguagesManager.GetDesc(id2);
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id3 = "ui://4pot8w0vavmf2".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id3);
		Discount_2 = (GComponent)((GComponent)this).GetChild("Discount");
		Line = (GGraph)((GComponent)this).GetChild("Line");
		Price2nd = (GTextField)((GComponent)this).GetChild("Price2nd");
		string id4 = "ui://4pot8w0vavmf2".Replace("ui://", "") + "-" + ((GObject)Price2nd).id;
		((GObject)Price2nd).text = LanguagesManager.GetDesc(id4);
		originalCurrencyIcon = (GLoader)((GComponent)this).GetChild("originalCurrencyIcon");
		originalPriceTitle = (GTextField)((GComponent)this).GetChild("originalPriceTitle");
		string id5 = "ui://4pot8w0vavmf2".Replace("ui://", "") + "-" + ((GObject)originalPriceTitle).id;
		((GObject)originalPriceTitle).text = LanguagesManager.GetDesc(id5);
		Price1st = (GTextField)((GComponent)this).GetChild("Price1st");
		currentCurrencyIcon = (GLoader)((GComponent)this).GetChild("currentCurrencyIcon");
		currentPriceTitle = (GTextField)((GComponent)this).GetChild("currentPriceTitle");
		string id6 = "ui://4pot8w0vavmf2".Replace("ui://", "") + "-" + ((GObject)currentPriceTitle).id;
		((GObject)currentPriceTitle).text = LanguagesManager.GetDesc(id6);
		priceGroup = (GGroup)((GComponent)this).GetChild("priceGroup");
		curIntlPriceText = (GTextField)((GComponent)this).GetChild("curIntlPriceText");
		string id7 = "ui://4pot8w0vavmf2".Replace("ui://", "") + "-" + ((GObject)curIntlPriceText).id;
		((GObject)curIntlPriceText).text = LanguagesManager.GetDesc(id7);
		originIntlPriceText = (GTextField)((GComponent)this).GetChild("originIntlPriceText");
		string id8 = "ui://4pot8w0vavmf2".Replace("ui://", "") + "-" + ((GObject)originIntlPriceText).id;
		((GObject)originIntlPriceText).text = LanguagesManager.GetDesc(id8);
		deleteLine = (GGraph)((GComponent)this).GetChild("deleteLine");
		priceGroupIntl = (GGroup)((GComponent)this).GetChild("priceGroupIntl");
	}

	public void SetControllerPageText(int pageIndex)
	{
		string id = string.Format("{0}-{1}-{2}", "ui://4pot8w0vavmf2".Replace("ui://", ""), ((GObject)currentPriceTitle).id, pageIndex);
		((GObject)currentPriceTitle).text = LanguagesManager.GetDesc(id);
	}
}
