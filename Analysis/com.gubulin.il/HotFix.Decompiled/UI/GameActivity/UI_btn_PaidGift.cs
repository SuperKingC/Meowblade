using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_btn_PaidGift : GButton
{
	public Controller button;

	public Controller State;

	public GImage n19;

	public GImage n21;

	public GLoader Icon;

	public GImage n25;

	public GImage n20;

	public GTextField n9;

	public GTextField Number;

	public GImage n10;

	public GMovieClip n26;

	public GMovieClip n27;

	public GMovieClip n28;

	public GComponent Discount;

	public GTextField CurIntlPriceText;

	public GTextField OriginIntlPriceText;

	public GTextField n17;

	public GTextField LimitCount;

	public GImage n22;

	public GGroup n24;

	public GImage n29;

	public Transition t0;

	public const string URL = "ui://29q48tv6ji0ub2";

	public static string Name = "UI_btn_PaidGift";

	public static string GetURL()
	{
		return "ui://29q48tv6ji0ub2";
	}

	public static UI_btn_PaidGift CreateInstance()
	{
		return (UI_btn_PaidGift)(object)UIPackage.CreateObject("GameActivity", "btn_PaidGift");
	}

	public static UI_btn_PaidGift CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_PaidGift).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6ji0ub2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id = "ui://29q48tv6ji0ub2".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id);
		Number = (GTextField)((GComponent)this).GetChild("Number");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n26 = (GMovieClip)((GComponent)this).GetChild("n26");
		n27 = (GMovieClip)((GComponent)this).GetChild("n27");
		n28 = (GMovieClip)((GComponent)this).GetChild("n28");
		Discount = (GComponent)((GComponent)this).GetChild("Discount");
		CurIntlPriceText = (GTextField)((GComponent)this).GetChild("CurIntlPriceText");
		string id2 = "ui://29q48tv6ji0ub2".Replace("ui://", "") + "-" + ((GObject)CurIntlPriceText).id;
		((GObject)CurIntlPriceText).text = LanguagesManager.GetDesc(id2);
		OriginIntlPriceText = (GTextField)((GComponent)this).GetChild("OriginIntlPriceText");
		string id3 = "ui://29q48tv6ji0ub2".Replace("ui://", "") + "-" + ((GObject)OriginIntlPriceText).id;
		((GObject)OriginIntlPriceText).text = LanguagesManager.GetDesc(id3);
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id4 = "ui://29q48tv6ji0ub2".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id4);
		LimitCount = (GTextField)((GComponent)this).GetChild("LimitCount");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n24 = (GGroup)((GComponent)this).GetChild("n24");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
