using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_dec_TalentOn : GComponent
{
	public Controller OuterTechIsActive;

	public GImage n11;

	public GImage n10;

	public GImage n12;

	public GGroup n14;

	public GImage n15;

	public GImage n13;

	public GImage n17;

	public GGroup n16;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://4r1llhd8jrfh54";

	public static string Name = "UI_dec_TalentOn";

	public static string GetURL()
	{
		return "ui://4r1llhd8jrfh54";
	}

	public static UI_dec_TalentOn CreateInstance()
	{
		return (UI_dec_TalentOn)(object)UIPackage.CreateObject("GvGTalent", "dec_TalentOn");
	}

	public static UI_dec_TalentOn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_TalentOn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8jrfh54", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		OuterTechIsActive = ((GComponent)this).GetController("OuterTechIsActive");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n14 = (GGroup)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n16 = (GGroup)((GComponent)this).GetChild("n16");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
