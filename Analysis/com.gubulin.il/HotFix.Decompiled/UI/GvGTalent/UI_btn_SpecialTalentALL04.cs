using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_btn_SpecialTalentALL04 : GButton
{
	public Controller button;

	public Controller Invested;

	public Controller Lv;

	public GImage n6;

	public GImage n11;

	public GImage n12;

	public GLoader n13;

	public GTextField Point;

	public UI_com_SpecialTalentsDialog Desc;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://4r1llhd8jrfh58";

	public static string Name = "UI_btn_SpecialTalentALL04";

	public static string GetURL()
	{
		return "ui://4r1llhd8jrfh58";
	}

	public static UI_btn_SpecialTalentALL04 CreateInstance()
	{
		return (UI_btn_SpecialTalentALL04)(object)UIPackage.CreateObject("GvGTalent", "btn_SpecialTalentALL04");
	}

	public static UI_btn_SpecialTalentALL04 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SpecialTalentALL04).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8jrfh58", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Invested = ((GComponent)this).GetController("Invested");
		Lv = ((GComponent)this).GetController("Lv");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GLoader)((GComponent)this).GetChild("n13");
		Point = (GTextField)((GComponent)this).GetChild("Point");
		Desc = (UI_com_SpecialTalentsDialog)(object)((GComponent)this).GetChild("Desc");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
