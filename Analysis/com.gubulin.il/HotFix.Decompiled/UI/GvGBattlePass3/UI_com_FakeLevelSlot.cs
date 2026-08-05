using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattlePass3;

public class UI_com_FakeLevelSlot : GComponent
{
	public Controller button;

	public Controller Progress;

	public Controller Type;

	public GImage n54;

	public GImage n55;

	public GImage n56;

	public GImage n42;

	public GImage n52;

	public GImage n53;

	public GImage n45;

	public GImage n47;

	public GImage n46;

	public GImage n43;

	public GMovieClip n51;

	public Transition t0;

	public const string URL = "ui://bfjg32hurdmf5m";

	public static string Name = "UI_com_FakeLevelSlot";

	public static string GetURL()
	{
		return "ui://bfjg32hurdmf5m";
	}

	public static UI_com_FakeLevelSlot CreateInstance()
	{
		return (UI_com_FakeLevelSlot)(object)UIPackage.CreateObject("GvGBattlePass3", "com_FakeLevelSlot");
	}

	public static UI_com_FakeLevelSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FakeLevelSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://bfjg32hurdmf5m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Progress = ((GComponent)this).GetController("Progress");
		Type = ((GComponent)this).GetController("Type");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n42 = (GImage)((GComponent)this).GetChild("n42");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n51 = (GMovieClip)((GComponent)this).GetChild("n51");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
