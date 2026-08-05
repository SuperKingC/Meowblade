using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_MainStorylineStepBar : GProgressBar
{
	public Controller IsEternalNight;

	public Controller IsCurrentStep;

	public Controller IsLastStep;

	public UI_dec_storylinestepbar bar;

	public GImage n15;

	public UI_IslandIcon IslandIcon;

	public GImage n1;

	public GMovieClip n13;

	public GMovieClip n14;

	public GImage n6;

	public GTextField Conutdown;

	public GImage n12;

	public GGroup n10;

	public UI_com_01 FlagShip;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2qf7c7j";

	public static string Name = "UI_MainStorylineStepBar";

	public static string GetURL()
	{
		return "ui://4eq8fgd2qf7c7j";
	}

	public static UI_MainStorylineStepBar CreateInstance()
	{
		return (UI_MainStorylineStepBar)(object)UIPackage.CreateObject("GvGWorldMap3", "MainStorylineStepBar");
	}

	public static UI_MainStorylineStepBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MainStorylineStepBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2qf7c7j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsEternalNight = ((GComponent)this).GetController("IsEternalNight");
		IsCurrentStep = ((GComponent)this).GetController("IsCurrentStep");
		IsLastStep = ((GComponent)this).GetController("IsLastStep");
		bar = (UI_dec_storylinestepbar)(object)((GComponent)this).GetChild("bar");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		IslandIcon = (UI_IslandIcon)(object)((GComponent)this).GetChild("IslandIcon");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n13 = (GMovieClip)((GComponent)this).GetChild("n13");
		n14 = (GMovieClip)((GComponent)this).GetChild("n14");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		Conutdown = (GTextField)((GComponent)this).GetChild("Conutdown");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n10 = (GGroup)((GComponent)this).GetChild("n10");
		FlagShip = (UI_com_01)(object)((GComponent)this).GetChild("FlagShip");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
