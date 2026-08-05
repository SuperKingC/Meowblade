using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_com_OEMMission : GComponent
{
	public Controller Status;

	public Controller DoubleRewards;

	public GImage n11;

	public UI_com_AmplifierSlot Amplifier;

	public GTextField Countdown;

	public GTextField UserName;

	public GImage n12;

	public GImage n14;

	public GImage n13;

	public GImage n15;

	public GImage n2;

	public const string URL = "ui://tt2iq07onhzvr";

	public static string Name = "UI_com_OEMMission";

	public static string GetURL()
	{
		return "ui://tt2iq07onhzvr";
	}

	public static UI_com_OEMMission CreateInstance()
	{
		return (UI_com_OEMMission)(object)UIPackage.CreateObject("GvGExchange3", "com_OEMMission");
	}

	public static UI_com_OEMMission CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OEMMission).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07onhzvr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
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
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		DoubleRewards = ((GComponent)this).GetController("DoubleRewards");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		Amplifier = (UI_com_AmplifierSlot)(object)((GComponent)this).GetChild("Amplifier");
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n2 = (GImage)((GComponent)this).GetChild("n2");
	}
}
