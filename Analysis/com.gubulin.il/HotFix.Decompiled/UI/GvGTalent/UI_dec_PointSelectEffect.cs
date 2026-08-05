using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_dec_PointSelectEffect : GComponent
{
	public GImage n2;

	public GImage n3;

	public GImage n4;

	public Transition t0;

	public Transition t1;

	public Transition t2;

	public const string URL = "ui://4r1llhd8tchc3g";

	public static string Name = "UI_dec_PointSelectEffect";

	public static string GetURL()
	{
		return "ui://4r1llhd8tchc3g";
	}

	public static UI_dec_PointSelectEffect CreateInstance()
	{
		return (UI_dec_PointSelectEffect)(object)UIPackage.CreateObject("GvGTalent", "dec_PointSelectEffect");
	}

	public static UI_dec_PointSelectEffect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_PointSelectEffect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8tchc3g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
		t2 = ((GComponent)this).GetTransition("t2");
	}
}
