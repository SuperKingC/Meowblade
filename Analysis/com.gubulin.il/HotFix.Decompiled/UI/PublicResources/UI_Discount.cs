using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_Discount : GComponent
{
	public Controller PageController;

	public Controller TurnOff;

	public GImage ribbon_0;

	public GImage ribbon_1;

	public GImage ribbon_2;

	public GImage n14;

	public GImage n5;

	public GImage n7;

	public GImage n6;

	public GImage n46;

	public GTextField discount;

	public GTextField discountDiyGold;

	public GTextField discountDiyGold_s;

	public GTextField discountDiyPurple;

	public GTextField discountDiyPurple_s;

	public GTextField discountDiyBlue;

	public GTextField discountDiyBlue_s;

	public GImage n41;

	public GImage n42;

	public GGroup mask;

	public const string URL = "ui://kt6rg65oavmfmh";

	public static string Name = "UI_Discount";

	public static string GetURL()
	{
		return "ui://kt6rg65oavmfmh";
	}

	public static UI_Discount CreateInstance()
	{
		return (UI_Discount)(object)UIPackage.CreateObject("PublicResources", "Discount");
	}

	public static UI_Discount CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Discount).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oavmfmh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected O, but got Unknown
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected O, but got Unknown
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		TurnOff = ((GComponent)this).GetController("TurnOff");
		ribbon_0 = (GImage)((GComponent)this).GetChild("ribbon_0");
		ribbon_1 = (GImage)((GComponent)this).GetChild("ribbon_1");
		ribbon_2 = (GImage)((GComponent)this).GetChild("ribbon_2");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		discount = (GTextField)((GComponent)this).GetChild("discount");
		string id = "ui://kt6rg65oavmfmh".Replace("ui://", "") + "-" + ((GObject)discount).id;
		((GObject)discount).text = LanguagesManager.GetDesc(id);
		discountDiyGold = (GTextField)((GComponent)this).GetChild("discountDiyGold");
		string id2 = "ui://kt6rg65oavmfmh".Replace("ui://", "") + "-" + ((GObject)discountDiyGold).id;
		((GObject)discountDiyGold).text = LanguagesManager.GetDesc(id2);
		discountDiyGold_s = (GTextField)((GComponent)this).GetChild("discountDiyGold_s");
		string id3 = "ui://kt6rg65oavmfmh".Replace("ui://", "") + "-" + ((GObject)discountDiyGold_s).id;
		((GObject)discountDiyGold_s).text = LanguagesManager.GetDesc(id3);
		discountDiyPurple = (GTextField)((GComponent)this).GetChild("discountDiyPurple");
		string id4 = "ui://kt6rg65oavmfmh".Replace("ui://", "") + "-" + ((GObject)discountDiyPurple).id;
		((GObject)discountDiyPurple).text = LanguagesManager.GetDesc(id4);
		discountDiyPurple_s = (GTextField)((GComponent)this).GetChild("discountDiyPurple_s");
		string id5 = "ui://kt6rg65oavmfmh".Replace("ui://", "") + "-" + ((GObject)discountDiyPurple_s).id;
		((GObject)discountDiyPurple_s).text = LanguagesManager.GetDesc(id5);
		discountDiyBlue = (GTextField)((GComponent)this).GetChild("discountDiyBlue");
		string id6 = "ui://kt6rg65oavmfmh".Replace("ui://", "") + "-" + ((GObject)discountDiyBlue).id;
		((GObject)discountDiyBlue).text = LanguagesManager.GetDesc(id6);
		discountDiyBlue_s = (GTextField)((GComponent)this).GetChild("discountDiyBlue_s");
		string id7 = "ui://kt6rg65oavmfmh".Replace("ui://", "") + "-" + ((GObject)discountDiyBlue_s).id;
		((GObject)discountDiyBlue_s).text = LanguagesManager.GetDesc(id7);
		n41 = (GImage)((GComponent)this).GetChild("n41");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		mask = (GGroup)((GComponent)this).GetChild("mask");
	}
}
