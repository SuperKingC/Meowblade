using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_settlement_0 : GComponent
{
	public Controller Title;

	public Controller Type;

	public UI_mc_settlement_1 n7;

	public GImage n6;

	public GImage n4;

	public GImage n2;

	public GImage n9;

	public GImage n10;

	public GImage n11;

	public GImage n12;

	public GImage n8;

	public GLoader Logo;

	public Transition t0;

	public const string URL = "ui://k2sprg26uctj75";

	public static string Name = "UI_mc_settlement_0";

	public static string GetURL()
	{
		return "ui://k2sprg26uctj75";
	}

	public static UI_mc_settlement_0 CreateInstance()
	{
		return (UI_mc_settlement_0)(object)UIPackage.CreateObject("IslandComeAgain", "mc_settlement_0");
	}

	public static UI_mc_settlement_0 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_settlement_0).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26uctj75", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
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
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Title = ((GComponent)this).GetController("Title");
		Type = ((GComponent)this).GetController("Type");
		n7 = (UI_mc_settlement_1)(object)((GComponent)this).GetChild("n7");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		Logo = (GLoader)((GComponent)this).GetChild("Logo");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
