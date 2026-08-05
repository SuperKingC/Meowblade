using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_com_NpcShopItem : GComponent
{
	public Controller CanBuy;

	public Controller StockStatus;

	public Controller Rarity;

	public Controller hasOuterTech;

	public GImage n7;

	public GImage n8;

	public GImage n9;

	public GImage n10;

	public GImage n11;

	public GImage n6;

	public GImage n13;

	public GImage n12;

	public GTextField Stock;

	public GList Bonus;

	public UI_btn_Buy Buy;

	public GLoader StoreItem;

	public GLoader iconOuterTech;

	public GImage n15;

	public const string URL = "ui://p4ocf6q0dc6mc";

	public static string Name = "UI_com_NpcShopItem";

	public static string GetURL()
	{
		return "ui://p4ocf6q0dc6mc";
	}

	public static UI_com_NpcShopItem CreateInstance()
	{
		return (UI_com_NpcShopItem)(object)UIPackage.CreateObject("GvGRandomEvent3", "com_NpcShopItem");
	}

	public static UI_com_NpcShopItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_NpcShopItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q0dc6mc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CanBuy = ((GComponent)this).GetController("CanBuy");
		StockStatus = ((GComponent)this).GetController("StockStatus");
		Rarity = ((GComponent)this).GetController("Rarity");
		hasOuterTech = ((GComponent)this).GetController("hasOuterTech");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		Stock = (GTextField)((GComponent)this).GetChild("Stock");
		Bonus = (GList)((GComponent)this).GetChild("Bonus");
		Buy = (UI_btn_Buy)(object)((GComponent)this).GetChild("Buy");
		StoreItem = (GLoader)((GComponent)this).GetChild("StoreItem");
		iconOuterTech = (GLoader)((GComponent)this).GetChild("iconOuterTech");
		n15 = (GImage)((GComponent)this).GetChild("n15");
	}
}
