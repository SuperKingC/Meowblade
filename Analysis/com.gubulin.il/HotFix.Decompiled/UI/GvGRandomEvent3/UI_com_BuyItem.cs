using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGRandomEvent3;

public class UI_com_BuyItem : GComponent
{
	public Controller type;

	public GImage nameBack;

	public GTextField ItemName;

	public GLoader StoreItem;

	public UI_com_ItemsCounter ItemsCounter;

	public GButton ConfirmBuyBtn;

	public GTextField n14;

	public GLoader ItemIcon;

	public GTextField Count;

	public GGroup n18;

	public GGroup n16;

	public GList Cost;

	public GTextField n11;

	public GGroup n13;

	public GTextField BuyLimitTitle;

	public GTextField BuyLimit;

	public GGroup BuyLimitGroup;

	public const string URL = "ui://p4ocf6q09ewlf";

	public static string Name = "UI_com_BuyItem";

	public static string GetURL()
	{
		return "ui://p4ocf6q09ewlf";
	}

	public static UI_com_BuyItem CreateInstance()
	{
		return (UI_com_BuyItem)(object)UIPackage.CreateObject("GvGRandomEvent3", "com_BuyItem");
	}

	public static UI_com_BuyItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BuyItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://p4ocf6q09ewlf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		type = ((GComponent)this).GetController("type");
		nameBack = (GImage)((GComponent)this).GetChild("nameBack");
		ItemName = (GTextField)((GComponent)this).GetChild("ItemName");
		StoreItem = (GLoader)((GComponent)this).GetChild("StoreItem");
		ItemsCounter = (UI_com_ItemsCounter)(object)((GComponent)this).GetChild("ItemsCounter");
		ConfirmBuyBtn = (GButton)((GComponent)this).GetChild("ConfirmBuyBtn");
		n14 = (GTextField)((GComponent)this).GetChild("n14");
		string id = "ui://p4ocf6q09ewlf".Replace("ui://", "") + "-" + ((GObject)n14).id;
		((GObject)n14).text = LanguagesManager.GetDesc(id);
		ItemIcon = (GLoader)((GComponent)this).GetChild("ItemIcon");
		Count = (GTextField)((GComponent)this).GetChild("Count");
		string id2 = "ui://p4ocf6q09ewlf".Replace("ui://", "") + "-" + ((GObject)Count).id;
		((GObject)Count).text = LanguagesManager.GetDesc(id2);
		n18 = (GGroup)((GComponent)this).GetChild("n18");
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		Cost = (GList)((GComponent)this).GetChild("Cost");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id3 = "ui://p4ocf6q09ewlf".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id3);
		n13 = (GGroup)((GComponent)this).GetChild("n13");
		BuyLimitTitle = (GTextField)((GComponent)this).GetChild("BuyLimitTitle");
		string id4 = "ui://p4ocf6q09ewlf".Replace("ui://", "") + "-" + ((GObject)BuyLimitTitle).id;
		((GObject)BuyLimitTitle).text = LanguagesManager.GetDesc(id4);
		BuyLimit = (GTextField)((GComponent)this).GetChild("BuyLimit");
		BuyLimitGroup = (GGroup)((GComponent)this).GetChild("BuyLimitGroup");
	}
}
