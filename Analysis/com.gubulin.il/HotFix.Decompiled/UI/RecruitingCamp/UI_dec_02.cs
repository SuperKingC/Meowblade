using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecruitingCamp;

public class UI_dec_02 : GComponent
{
	public GImage n212;

	public GImage n213;

	public GImage n214;

	public GImage n215;

	public GImage n216;

	public GImage n217;

	public Transition t0;

	public Transition t1;

	public Transition t2;

	public Transition t3;

	public Transition t4;

	public const string URL = "ui://72fujxhkq91k3x";

	public static string Name = "UI_dec_02";

	public static string GetURL()
	{
		return "ui://72fujxhkq91k3x";
	}

	public static UI_dec_02 CreateInstance()
	{
		return (UI_dec_02)(object)UIPackage.CreateObject("RecruitingCamp", "dec_02");
	}

	public static UI_dec_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhkq91k3x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n212 = (GImage)((GComponent)this).GetChild("n212");
		n213 = (GImage)((GComponent)this).GetChild("n213");
		n214 = (GImage)((GComponent)this).GetChild("n214");
		n215 = (GImage)((GComponent)this).GetChild("n215");
		n216 = (GImage)((GComponent)this).GetChild("n216");
		n217 = (GImage)((GComponent)this).GetChild("n217");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
		t2 = ((GComponent)this).GetTransition("t2");
		t3 = ((GComponent)this).GetTransition("t3");
		t4 = ((GComponent)this).GetTransition("t4");
	}
}
