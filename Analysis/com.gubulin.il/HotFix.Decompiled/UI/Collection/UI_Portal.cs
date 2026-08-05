using FairyGUI;
using FairyGUI.Utils;

namespace UI.Collection;

public class UI_Portal : GComponent
{
	public GImage clickBg;

	public GLoader Icon;

	public GGraph spine;

	public GImage n61;

	public GImage n62;

	public GImage n63;

	public GImage n64;

	public GImage n65;

	public GImage n66;

	public GImage n67;

	public GImage n68;

	public GImage n69;

	public GImage n70;

	public GImage n71;

	public GGroup imageGroup1;

	public GImage n74;

	public GImage n75;

	public GImage n76;

	public GImage n77;

	public GImage n78;

	public GImage n79;

	public GImage n80;

	public GImage n81;

	public GImage n82;

	public GImage n83;

	public GImage n84;

	public GGroup imageGroup2;

	public GImage n86;

	public GImage n87;

	public GImage n88;

	public GImage n89;

	public GImage n90;

	public GImage n91;

	public GImage n92;

	public GImage n93;

	public GImage n94;

	public GImage n95;

	public GImage n96;

	public GGroup imageGroup3;

	public Transition t0;

	public Transition UpAndDownEarth;

	public Transition UpAndDownWind;

	public Transition UpAndDownWater;

	public const string URL = "ui://ehe4tm5zrqq41u";

	public static string Name = "UI_Portal";

	public static string GetURL()
	{
		return "ui://ehe4tm5zrqq41u";
	}

	public static UI_Portal CreateInstance()
	{
		return (UI_Portal)(object)UIPackage.CreateObject("Collection", "Portal");
	}

	public static UI_Portal CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Portal).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ehe4tm5zrqq41u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Expected O, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		clickBg = (GImage)((GComponent)this).GetChild("clickBg");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		spine = (GGraph)((GComponent)this).GetChild("spine");
		n61 = (GImage)((GComponent)this).GetChild("n61");
		n62 = (GImage)((GComponent)this).GetChild("n62");
		n63 = (GImage)((GComponent)this).GetChild("n63");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		n66 = (GImage)((GComponent)this).GetChild("n66");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		n69 = (GImage)((GComponent)this).GetChild("n69");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		n71 = (GImage)((GComponent)this).GetChild("n71");
		imageGroup1 = (GGroup)((GComponent)this).GetChild("imageGroup1");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		n75 = (GImage)((GComponent)this).GetChild("n75");
		n76 = (GImage)((GComponent)this).GetChild("n76");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n78 = (GImage)((GComponent)this).GetChild("n78");
		n79 = (GImage)((GComponent)this).GetChild("n79");
		n80 = (GImage)((GComponent)this).GetChild("n80");
		n81 = (GImage)((GComponent)this).GetChild("n81");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n83 = (GImage)((GComponent)this).GetChild("n83");
		n84 = (GImage)((GComponent)this).GetChild("n84");
		imageGroup2 = (GGroup)((GComponent)this).GetChild("imageGroup2");
		n86 = (GImage)((GComponent)this).GetChild("n86");
		n87 = (GImage)((GComponent)this).GetChild("n87");
		n88 = (GImage)((GComponent)this).GetChild("n88");
		n89 = (GImage)((GComponent)this).GetChild("n89");
		n90 = (GImage)((GComponent)this).GetChild("n90");
		n91 = (GImage)((GComponent)this).GetChild("n91");
		n92 = (GImage)((GComponent)this).GetChild("n92");
		n93 = (GImage)((GComponent)this).GetChild("n93");
		n94 = (GImage)((GComponent)this).GetChild("n94");
		n95 = (GImage)((GComponent)this).GetChild("n95");
		n96 = (GImage)((GComponent)this).GetChild("n96");
		imageGroup3 = (GGroup)((GComponent)this).GetChild("imageGroup3");
		t0 = ((GComponent)this).GetTransition("t0");
		UpAndDownEarth = ((GComponent)this).GetTransition("UpAndDownEarth");
		UpAndDownWind = ((GComponent)this).GetTransition("UpAndDownWind");
		UpAndDownWater = ((GComponent)this).GetTransition("UpAndDownWater");
	}
}
