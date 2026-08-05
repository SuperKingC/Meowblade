using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_RechargeReward : GButton
{
	public Controller button;

	public GImage iconBack;

	public GLoader icon;

	public GTextField num;

	public GTextField curPrice;

	public GTextField initPrice;

	public GGraph line;

	public GLoader initCurrencyIcon;

	public GLoader curCurrencyIcon;

	public GTextField curPriceTitle;

	public GTextField initPriceTitle;

	public GTextField price;

	public const string URL = "ui://29q48tv6gawy13";

	public static string Name = "UI_RechargeReward";

	public static string GetURL()
	{
		return "ui://29q48tv6gawy13";
	}

	public static UI_RechargeReward CreateInstance()
	{
		return (UI_RechargeReward)(object)UIPackage.CreateObject("GameActivity", "RechargeReward");
	}

	public static UI_RechargeReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RechargeReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6gawy13", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://29q48tv6gawy13".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		curPrice = (GTextField)((GComponent)this).GetChild("curPrice");
		initPrice = (GTextField)((GComponent)this).GetChild("initPrice");
		line = (GGraph)((GComponent)this).GetChild("line");
		initCurrencyIcon = (GLoader)((GComponent)this).GetChild("initCurrencyIcon");
		curCurrencyIcon = (GLoader)((GComponent)this).GetChild("curCurrencyIcon");
		curPriceTitle = (GTextField)((GComponent)this).GetChild("curPriceTitle");
		string id2 = "ui://29q48tv6gawy13".Replace("ui://", "") + "-" + ((GObject)curPriceTitle).id;
		((GObject)curPriceTitle).text = LanguagesManager.GetDesc(id2);
		initPriceTitle = (GTextField)((GComponent)this).GetChild("initPriceTitle");
		string id3 = "ui://29q48tv6gawy13".Replace("ui://", "") + "-" + ((GObject)initPriceTitle).id;
		((GObject)initPriceTitle).text = LanguagesManager.GetDesc(id3);
		price = (GTextField)((GComponent)this).GetChild("price");
	}
}
