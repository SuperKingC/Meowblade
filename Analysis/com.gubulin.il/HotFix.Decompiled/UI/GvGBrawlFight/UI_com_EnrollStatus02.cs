using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_com_EnrollStatus02 : GComponent
{
	public Controller modeType;

	public GImage n5;

	public GImage n15;

	public GImage n12;

	public GLoader n13;

	public GLoader n14;

	public GTextField IslandName;

	public UI_btn_HelpBtn02 helpBtn;

	public GGroup Anim;

	public Transition t0;

	public const string URL = "ui://hozu168rcc2a6z";

	public static string Name = "UI_com_EnrollStatus02";

	public static string GetURL()
	{
		return "ui://hozu168rcc2a6z";
	}

	public static UI_com_EnrollStatus02 CreateInstance()
	{
		return (UI_com_EnrollStatus02)(object)UIPackage.CreateObject("GvGBrawlFight", "com_EnrollStatus02");
	}

	public static UI_com_EnrollStatus02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_EnrollStatus02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rcc2a6z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		modeType = ((GComponent)this).GetController("modeType");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GLoader)((GComponent)this).GetChild("n13");
		n14 = (GLoader)((GComponent)this).GetChild("n14");
		IslandName = (GTextField)((GComponent)this).GetChild("IslandName");
		helpBtn = (UI_btn_HelpBtn02)(object)((GComponent)this).GetChild("helpBtn");
		Anim = (GGroup)((GComponent)this).GetChild("Anim");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
