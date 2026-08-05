using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_com_BuyGvGinsurance : GComponent
{
	public Controller State;

	public GImage Background;

	public GImage n64;

	public GImage n83;

	public GImage n100;

	public GImage n81;

	public GImage n82;

	public GTextField n72;

	public GTextField n79;

	public GImage n80;

	public GTextField n85;

	public GTextField n99;

	public GImage n86;

	public GImage n87;

	public GTextField n91;

	public GTextField n92;

	public GTextField n93;

	public GTextField n94;

	public GTextField n96;

	public GButton Check;

	public GButton Buy;

	public GTextField n101;

	public GTextField n102;

	public GTextField RemainingCnt;

	public const string URL = "ui://bfjg32hujljf6k";

	public static string Name = "UI_com_BuyGvGinsurance";

	public static string GetURL()
	{
		return "ui://bfjg32hujljf6k";
	}

	public static UI_com_BuyGvGinsurance CreateInstance()
	{
		return (UI_com_BuyGvGinsurance)(object)UIPackage.CreateObject("GvGBattlePass3", "com_BuyGvGinsurance");
	}

	public static UI_com_BuyGvGinsurance CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BuyGvGinsurance).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32hujljf6k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected O, but got Unknown
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected O, but got Unknown
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Expected O, but got Unknown
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0401: Expected O, but got Unknown
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Expected O, but got Unknown
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		n83 = (GImage)((GComponent)this).GetChild("n83");
		n100 = (GImage)((GComponent)this).GetChild("n100");
		n81 = (GImage)((GComponent)this).GetChild("n81");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n72 = (GTextField)((GComponent)this).GetChild("n72");
		string id = "ui://bfjg32hujljf6k".Replace("ui://", "") + "-" + ((GObject)n72).id;
		((GObject)n72).text = LanguagesManager.GetDesc(id);
		n79 = (GTextField)((GComponent)this).GetChild("n79");
		string id2 = "ui://bfjg32hujljf6k".Replace("ui://", "") + "-" + ((GObject)n79).id;
		((GObject)n79).text = LanguagesManager.GetDesc(id2);
		n80 = (GImage)((GComponent)this).GetChild("n80");
		n85 = (GTextField)((GComponent)this).GetChild("n85");
		string id3 = "ui://bfjg32hujljf6k".Replace("ui://", "") + "-" + ((GObject)n85).id;
		((GObject)n85).text = LanguagesManager.GetDesc(id3);
		n99 = (GTextField)((GComponent)this).GetChild("n99");
		string id4 = "ui://bfjg32hujljf6k".Replace("ui://", "") + "-" + ((GObject)n99).id;
		((GObject)n99).text = LanguagesManager.GetDesc(id4);
		n86 = (GImage)((GComponent)this).GetChild("n86");
		n87 = (GImage)((GComponent)this).GetChild("n87");
		n91 = (GTextField)((GComponent)this).GetChild("n91");
		string id5 = "ui://bfjg32hujljf6k".Replace("ui://", "") + "-" + ((GObject)n91).id;
		((GObject)n91).text = LanguagesManager.GetDesc(id5);
		n92 = (GTextField)((GComponent)this).GetChild("n92");
		string id6 = "ui://bfjg32hujljf6k".Replace("ui://", "") + "-" + ((GObject)n92).id;
		((GObject)n92).text = LanguagesManager.GetDesc(id6);
		n93 = (GTextField)((GComponent)this).GetChild("n93");
		string id7 = "ui://bfjg32hujljf6k".Replace("ui://", "") + "-" + ((GObject)n93).id;
		((GObject)n93).text = LanguagesManager.GetDesc(id7);
		n94 = (GTextField)((GComponent)this).GetChild("n94");
		string id8 = "ui://bfjg32hujljf6k".Replace("ui://", "") + "-" + ((GObject)n94).id;
		((GObject)n94).text = LanguagesManager.GetDesc(id8);
		n96 = (GTextField)((GComponent)this).GetChild("n96");
		string id9 = "ui://bfjg32hujljf6k".Replace("ui://", "") + "-" + ((GObject)n96).id;
		((GObject)n96).text = LanguagesManager.GetDesc(id9);
		Check = (GButton)((GComponent)this).GetChild("Check");
		Buy = (GButton)((GComponent)this).GetChild("Buy");
		n101 = (GTextField)((GComponent)this).GetChild("n101");
		string id10 = "ui://bfjg32hujljf6k".Replace("ui://", "") + "-" + ((GObject)n101).id;
		((GObject)n101).text = LanguagesManager.GetDesc(id10);
		n102 = (GTextField)((GComponent)this).GetChild("n102");
		string id11 = "ui://bfjg32hujljf6k".Replace("ui://", "") + "-" + ((GObject)n102).id;
		((GObject)n102).text = LanguagesManager.GetDesc(id11);
		RemainingCnt = (GTextField)((GComponent)this).GetChild("RemainingCnt");
		string id12 = "ui://bfjg32hujljf6k".Replace("ui://", "") + "-" + ((GObject)RemainingCnt).id;
		((GObject)RemainingCnt).text = LanguagesManager.GetDesc(id12);
	}
}
