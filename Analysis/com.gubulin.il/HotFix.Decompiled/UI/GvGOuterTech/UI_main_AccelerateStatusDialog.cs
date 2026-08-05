using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOuterTech;

public class UI_main_AccelerateStatusDialog : GComponent
{
	public Controller AccStatus;

	public GImage back;

	public GImage n6;

	public GImage n15;

	public GImage n20;

	public GTextField n1;

	public GTextField n2;

	public GTextField TotalHeld;

	public GGroup n5;

	public GTextField n7;

	public GTextField TotalJoined;

	public GGroup n9;

	public GTextField n10;

	public GTextField TotalAccCnt;

	public GLoader n13;

	public GGroup n12;

	public GButton HelpBtn;

	public GTextField n16;

	public GTextField n17;

	public GTextField n18;

	public GTextField n31;

	public GTextField n19;

	public GImage n22;

	public GLoader n23;

	public GTextField ClaimCnt;

	public GImage n25;

	public GImage n26;

	public GTextField n27;

	public GTextField NextClaimCnt;

	public GLoader n29;

	public GGroup n30;

	public const string URL = "ui://th385mttn6wlo91";

	public static string Name = "UI_main_AccelerateStatusDialog";

	public static string GetURL()
	{
		return "ui://th385mttn6wlo91";
	}

	public static UI_main_AccelerateStatusDialog CreateInstance()
	{
		return (UI_main_AccelerateStatusDialog)(object)UIPackage.CreateObject("GvGOuterTech", "main_AccelerateStatusDialog");
	}

	public static UI_main_AccelerateStatusDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_AccelerateStatusDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttn6wlo91", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Expected O, but got Unknown
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Expected O, but got Unknown
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Expected O, but got Unknown
		//IL_0465: Unknown result type (might be due to invalid IL or missing references)
		//IL_046f: Expected O, but got Unknown
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Expected O, but got Unknown
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Expected O, but got Unknown
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Expected O, but got Unknown
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Expected O, but got Unknown
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		AccStatus = ((GComponent)this).GetController("AccStatus");
		back = (GImage)((GComponent)this).GetChild("back");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://th385mttn6wlo91".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n2 = (GTextField)((GComponent)this).GetChild("n2");
		string id2 = "ui://th385mttn6wlo91".Replace("ui://", "") + "-" + ((GObject)n2).id;
		((GObject)n2).text = LanguagesManager.GetDesc(id2);
		TotalHeld = (GTextField)((GComponent)this).GetChild("TotalHeld");
		n5 = (GGroup)((GComponent)this).GetChild("n5");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id3 = "ui://th385mttn6wlo91".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id3);
		TotalJoined = (GTextField)((GComponent)this).GetChild("TotalJoined");
		n9 = (GGroup)((GComponent)this).GetChild("n9");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id4 = "ui://th385mttn6wlo91".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id4);
		TotalAccCnt = (GTextField)((GComponent)this).GetChild("TotalAccCnt");
		n13 = (GLoader)((GComponent)this).GetChild("n13");
		n12 = (GGroup)((GComponent)this).GetChild("n12");
		HelpBtn = (GButton)((GComponent)this).GetChild("HelpBtn");
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id5 = "ui://th385mttn6wlo91".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id5);
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id6 = "ui://th385mttn6wlo91".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id6);
		n18 = (GTextField)((GComponent)this).GetChild("n18");
		string id7 = "ui://th385mttn6wlo91".Replace("ui://", "") + "-" + ((GObject)n18).id;
		((GObject)n18).text = LanguagesManager.GetDesc(id7);
		n31 = (GTextField)((GComponent)this).GetChild("n31");
		string id8 = "ui://th385mttn6wlo91".Replace("ui://", "") + "-" + ((GObject)n31).id;
		((GObject)n31).text = LanguagesManager.GetDesc(id8);
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id9 = "ui://th385mttn6wlo91".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id9);
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n23 = (GLoader)((GComponent)this).GetChild("n23");
		ClaimCnt = (GTextField)((GComponent)this).GetChild("ClaimCnt");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n27 = (GTextField)((GComponent)this).GetChild("n27");
		string id10 = "ui://th385mttn6wlo91".Replace("ui://", "") + "-" + ((GObject)n27).id;
		((GObject)n27).text = LanguagesManager.GetDesc(id10);
		NextClaimCnt = (GTextField)((GComponent)this).GetChild("NextClaimCnt");
		n29 = (GLoader)((GComponent)this).GetChild("n29");
		n30 = (GGroup)((GComponent)this).GetChild("n30");
	}
}
