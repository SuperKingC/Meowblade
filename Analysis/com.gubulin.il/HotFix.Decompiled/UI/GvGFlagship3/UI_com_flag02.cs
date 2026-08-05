using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_com_flag02 : GComponent
{
	public Controller Camp;

	public GImage n30;

	public GImage n31;

	public GImage n32;

	public GImage n33;

	public GImage n29;

	public Transition t0;

	public Transition t1;

	public Transition t2;

	public Transition t3;

	public const string URL = "ui://tvr786zljb4i3f";

	public static string Name = "UI_com_flag02";

	public static string GetURL()
	{
		return "ui://tvr786zljb4i3f";
	}

	public static UI_com_flag02 CreateInstance()
	{
		return (UI_com_flag02)(object)UIPackage.CreateObject("GvGFlagship3", "com_flag02");
	}

	public static UI_com_flag02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_flag02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zljb4i3f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Camp = ((GComponent)this).GetController("Camp");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n32 = (GImage)((GComponent)this).GetChild("n32");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
		t2 = ((GComponent)this).GetTransition("t2");
		t3 = ((GComponent)this).GetTransition("t3");
	}
}
