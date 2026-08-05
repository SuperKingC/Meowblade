using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PushGiftBag;

public class UI_Dialog : GComponent
{
	public Controller HasTimeLimit;

	public GImage back;

	public GImage btnBg;

	public GGraph SpineBack;

	public UI_Title Title;

	public UI_ConfirmBuyBtn ConfirmBuyBtn;

	public GList ItemList;

	public GTextField NoCountdownText;

	public GGraph Line;

	public GTextField Price2nd;

	public GLoader originalCurrencyIcon;

	public GTextField originalPriceTitle;

	public GTextField Price1st;

	public GLoader currentCurrencyIcon;

	public GTextField currentPriceTitle;

	public GGroup priceGroup;

	public GTextField curIntlPriceText;

	public GGroup priceGroupIntl;

	public GImage n34;

	public GTextField n35;

	public GImage n29;

	public GTextField countdown;

	public GGroup n38;

	public GImage n37;

	public const string URL = "ui://ume49e0adecwb";

	public static string Name = "UI_Dialog";

	public static string GetURL()
	{
		return "ui://ume49e0adecwb";
	}

	public static UI_Dialog CreateInstance()
	{
		return (UI_Dialog)(object)UIPackage.CreateObject("PushGiftBag", "Dialog");
	}

	public static UI_Dialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Dialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ume49e0adecwb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected O, but got Unknown
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasTimeLimit = ((GComponent)this).GetController("HasTimeLimit");
		back = (GImage)((GComponent)this).GetChild("back");
		btnBg = (GImage)((GComponent)this).GetChild("btnBg");
		SpineBack = (GGraph)((GComponent)this).GetChild("SpineBack");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		ConfirmBuyBtn = (UI_ConfirmBuyBtn)(object)((GComponent)this).GetChild("ConfirmBuyBtn");
		ItemList = (GList)((GComponent)this).GetChild("ItemList");
		NoCountdownText = (GTextField)((GComponent)this).GetChild("NoCountdownText");
		Line = (GGraph)((GComponent)this).GetChild("Line");
		Price2nd = (GTextField)((GComponent)this).GetChild("Price2nd");
		string id = "ui://ume49e0adecwb".Replace("ui://", "") + "-" + ((GObject)Price2nd).id;
		((GObject)Price2nd).text = LanguagesManager.GetDesc(id);
		originalCurrencyIcon = (GLoader)((GComponent)this).GetChild("originalCurrencyIcon");
		originalPriceTitle = (GTextField)((GComponent)this).GetChild("originalPriceTitle");
		string id2 = "ui://ume49e0adecwb".Replace("ui://", "") + "-" + ((GObject)originalPriceTitle).id;
		((GObject)originalPriceTitle).text = LanguagesManager.GetDesc(id2);
		Price1st = (GTextField)((GComponent)this).GetChild("Price1st");
		currentCurrencyIcon = (GLoader)((GComponent)this).GetChild("currentCurrencyIcon");
		currentPriceTitle = (GTextField)((GComponent)this).GetChild("currentPriceTitle");
		string id3 = "ui://ume49e0adecwb".Replace("ui://", "") + "-" + ((GObject)currentPriceTitle).id;
		((GObject)currentPriceTitle).text = LanguagesManager.GetDesc(id3);
		priceGroup = (GGroup)((GComponent)this).GetChild("priceGroup");
		curIntlPriceText = (GTextField)((GComponent)this).GetChild("curIntlPriceText");
		priceGroupIntl = (GGroup)((GComponent)this).GetChild("priceGroupIntl");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n35 = (GTextField)((GComponent)this).GetChild("n35");
		string id4 = "ui://ume49e0adecwb".Replace("ui://", "") + "-" + ((GObject)n35).id;
		((GObject)n35).text = LanguagesManager.GetDesc(id4);
		n29 = (GImage)((GComponent)this).GetChild("n29");
		countdown = (GTextField)((GComponent)this).GetChild("countdown");
		string id5 = "ui://ume49e0adecwb".Replace("ui://", "") + "-" + ((GObject)countdown).id;
		((GObject)countdown).text = LanguagesManager.GetDesc(id5);
		n38 = (GGroup)((GComponent)this).GetChild("n38");
		n37 = (GImage)((GComponent)this).GetChild("n37");
	}
}
