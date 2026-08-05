using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PvpStoreReward : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n4;

	public GImage n3;

	public GImage n5;

	public UI_ExchangeBtn ExchangeBtn;

	public GLoader Icon;

	public GTextField RewardName;

	public GTextField Price1st;

	public GLoader currentCurrencyIcon;

	public GTextField countLimit;

	public GImage n17;

	public GImage n18;

	public GImage n19;

	public const string URL = "ui://82mo10n5t7wpde8";

	public static string Name = "UI_PvpStoreReward";

	public static string GetURL()
	{
		return "ui://82mo10n5t7wpde8";
	}

	public static UI_PvpStoreReward CreateInstance()
	{
		return (UI_PvpStoreReward)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpStoreReward");
	}

	public static UI_PvpStoreReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpStoreReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5t7wpde8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		ExchangeBtn = (UI_ExchangeBtn)(object)((GComponent)this).GetChild("ExchangeBtn");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		RewardName = (GTextField)((GComponent)this).GetChild("RewardName");
		string id = "ui://82mo10n5t7wpde8".Replace("ui://", "") + "-" + ((GObject)RewardName).id;
		((GObject)RewardName).text = LanguagesManager.GetDesc(id);
		Price1st = (GTextField)((GComponent)this).GetChild("Price1st");
		currentCurrencyIcon = (GLoader)((GComponent)this).GetChild("currentCurrencyIcon");
		countLimit = (GTextField)((GComponent)this).GetChild("countLimit");
		string id2 = "ui://82mo10n5t7wpde8".Replace("ui://", "") + "-" + ((GObject)countLimit).id;
		((GObject)countLimit).text = LanguagesManager.GetDesc(id2);
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GImage)((GComponent)this).GetChild("n19");
	}
}
