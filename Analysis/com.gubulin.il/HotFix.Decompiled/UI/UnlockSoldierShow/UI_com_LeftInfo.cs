using FairyGUI;
using FairyGUI.Utils;

namespace UI.UnlockSoldierShow;

public class UI_com_LeftInfo : GComponent
{
	public Controller Rarity;

	public GImage n76;

	public GImage n81;

	public GImage n80;

	public GImage n79;

	public GImage n77;

	public GImage n75;

	public GImage n82;

	public GImage n83;

	public GImage n84;

	public GImage n73;

	public GTextField Identification;

	public GGroup n74;

	public GRichTextField Introduction;

	public GImage n70;

	public GImage n71;

	public GImage n72;

	public Transition t0;

	public Transition t1;

	public Transition t2;

	public const string URL = "ui://ia1am3ehbutlt21";

	public static string Name = "UI_com_LeftInfo";

	public static string GetURL()
	{
		return "ui://ia1am3ehbutlt21";
	}

	public static UI_com_LeftInfo CreateInstance()
	{
		return (UI_com_LeftInfo)(object)UIPackage.CreateObject("UnlockSoldierShow", "com_LeftInfo");
	}

	public static UI_com_LeftInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_LeftInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ia1am3ehbutlt21", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rarity = ((GComponent)this).GetController("Rarity");
		n76 = (GImage)((GComponent)this).GetChild("n76");
		n81 = (GImage)((GComponent)this).GetChild("n81");
		n80 = (GImage)((GComponent)this).GetChild("n80");
		n79 = (GImage)((GComponent)this).GetChild("n79");
		n77 = (GImage)((GComponent)this).GetChild("n77");
		n75 = (GImage)((GComponent)this).GetChild("n75");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n83 = (GImage)((GComponent)this).GetChild("n83");
		n84 = (GImage)((GComponent)this).GetChild("n84");
		n73 = (GImage)((GComponent)this).GetChild("n73");
		Identification = (GTextField)((GComponent)this).GetChild("Identification");
		n74 = (GGroup)((GComponent)this).GetChild("n74");
		Introduction = (GRichTextField)((GComponent)this).GetChild("Introduction");
		n70 = (GImage)((GComponent)this).GetChild("n70");
		n71 = (GImage)((GComponent)this).GetChild("n71");
		n72 = (GImage)((GComponent)this).GetChild("n72");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
		t2 = ((GComponent)this).GetTransition("t2");
	}
}
