using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecruitingCamp;

public class UI_dec_03 : GComponent
{
	public GImage n78;

	public GImage n79;

	public GImage n81;

	public GImage n82;

	public GImage n83;

	public Transition t0;

	public Transition t1;

	public Transition t2;

	public Transition t3;

	public const string URL = "ui://72fujxhk9yvp40";

	public static string Name = "UI_dec_03";

	public static string GetURL()
	{
		return "ui://72fujxhk9yvp40";
	}

	public static UI_dec_03 CreateInstance()
	{
		return (UI_dec_03)(object)UIPackage.CreateObject("RecruitingCamp", "dec_03");
	}

	public static UI_dec_03 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_03).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72fujxhk9yvp40", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n78 = (GImage)((GComponent)this).GetChild("n78");
		n79 = (GImage)((GComponent)this).GetChild("n79");
		n81 = (GImage)((GComponent)this).GetChild("n81");
		n82 = (GImage)((GComponent)this).GetChild("n82");
		n83 = (GImage)((GComponent)this).GetChild("n83");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
		t2 = ((GComponent)this).GetTransition("t2");
		t3 = ((GComponent)this).GetTransition("t3");
	}
}
