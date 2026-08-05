using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoulKeyStore;

public class UI_AddCreditCard : GButton
{
	public Controller button;

	public Controller RewardController;

	public Controller Discount;

	public Controller Soulkeytype;

	public GImage n44;

	public GImage n43;

	public GLoader back;

	public GGroup n32;

	public GLoader back2;

	public GGroup n33;

	public GGraph sfxBack;

	public GLoader icon;

	public GImage n39;

	public GImage n38;

	public GGroup n42;

	public UI_dec_cardeffect n40;

	public UI_FirstTimeDouble FirstTimeDouble;

	public GTextField result2;

	public GTextField reward2;

	public GGroup n37;

	public GTextField result;

	public GTextField reward;

	public GGroup n36;

	public GComponent Discount_2;

	public GTextField Price2nd;

	public GGraph Line;

	public GLoader originalCurrencyIcon;

	public GTextField originalPriceTitle;

	public GTextField Price1st;

	public GLoader currentCurrencyIcon;

	public GTextField currentPriceTitle;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://3nd2hqkivzbkc";

	public static string Name = "UI_AddCreditCard";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://3nd2hqkivzbkc".Replace("ui://", ""), ((GObject)currentPriceTitle).id, Discount.selectedIndex);
		((GObject)currentPriceTitle).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://3nd2hqkivzbkc";
	}

	public static UI_AddCreditCard CreateInstance()
	{
		return (UI_AddCreditCard)(object)UIPackage.CreateObject("SoulKeyStore", "AddCreditCard");
	}

	public static UI_AddCreditCard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AddCreditCard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://3nd2hqkivzbkc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Expected O, but got Unknown
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Expected O, but got Unknown
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Expected O, but got Unknown
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Expected O, but got Unknown
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Expected O, but got Unknown
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Expected O, but got Unknown
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RewardController = ((GComponent)this).GetController("RewardController");
		Discount = ((GComponent)this).GetController("Discount");
		Soulkeytype = ((GComponent)this).GetController("Soulkeytype");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		back = (GLoader)((GComponent)this).GetChild("back");
		n32 = (GGroup)((GComponent)this).GetChild("n32");
		back2 = (GLoader)((GComponent)this).GetChild("back2");
		n33 = (GGroup)((GComponent)this).GetChild("n33");
		sfxBack = (GGraph)((GComponent)this).GetChild("sfxBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n42 = (GGroup)((GComponent)this).GetChild("n42");
		n40 = (UI_dec_cardeffect)(object)((GComponent)this).GetChild("n40");
		FirstTimeDouble = (UI_FirstTimeDouble)(object)((GComponent)this).GetChild("FirstTimeDouble");
		result2 = (GTextField)((GComponent)this).GetChild("result2");
		string id = "ui://3nd2hqkivzbkc".Replace("ui://", "") + "-" + ((GObject)result2).id;
		((GObject)result2).text = LanguagesManager.GetDesc(id);
		reward2 = (GTextField)((GComponent)this).GetChild("reward2");
		string id2 = "ui://3nd2hqkivzbkc".Replace("ui://", "") + "-" + ((GObject)reward2).id;
		((GObject)reward2).text = LanguagesManager.GetDesc(id2);
		n37 = (GGroup)((GComponent)this).GetChild("n37");
		result = (GTextField)((GComponent)this).GetChild("result");
		string id3 = "ui://3nd2hqkivzbkc".Replace("ui://", "") + "-" + ((GObject)result).id;
		((GObject)result).text = LanguagesManager.GetDesc(id3);
		reward = (GTextField)((GComponent)this).GetChild("reward");
		string id4 = "ui://3nd2hqkivzbkc".Replace("ui://", "") + "-" + ((GObject)reward).id;
		((GObject)reward).text = LanguagesManager.GetDesc(id4);
		n36 = (GGroup)((GComponent)this).GetChild("n36");
		Discount_2 = (GComponent)((GComponent)this).GetChild("Discount");
		Price2nd = (GTextField)((GComponent)this).GetChild("Price2nd");
		string id5 = "ui://3nd2hqkivzbkc".Replace("ui://", "") + "-" + ((GObject)Price2nd).id;
		((GObject)Price2nd).text = LanguagesManager.GetDesc(id5);
		Line = (GGraph)((GComponent)this).GetChild("Line");
		originalCurrencyIcon = (GLoader)((GComponent)this).GetChild("originalCurrencyIcon");
		originalPriceTitle = (GTextField)((GComponent)this).GetChild("originalPriceTitle");
		string id6 = "ui://3nd2hqkivzbkc".Replace("ui://", "") + "-" + ((GObject)originalPriceTitle).id;
		((GObject)originalPriceTitle).text = LanguagesManager.GetDesc(id6);
		Price1st = (GTextField)((GComponent)this).GetChild("Price1st");
		currentCurrencyIcon = (GLoader)((GComponent)this).GetChild("currentCurrencyIcon");
		currentPriceTitle = (GTextField)((GComponent)this).GetChild("currentPriceTitle");
		string id7 = "ui://3nd2hqkivzbkc".Replace("ui://", "") + "-" + ((GObject)currentPriceTitle).id;
		((GObject)currentPriceTitle).text = LanguagesManager.GetDesc(id7);
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
