using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_RewardSlot2 : GButton
{
	public Controller State;

	public GImage n17;

	public GImage n16;

	public GImage n19;

	public GLoader Back;

	public GLoader Icon;

	public GTextField Num;

	public GImage n14;

	public GGroup n20;

	public GMovieClip n15;

	public GImage n18;

	public Transition t0;

	public const string URL = "ui://jl0c82y5ibyrq";

	public static string Name = "UI_RewardSlot2";

	public static string GetURL()
	{
		return "ui://jl0c82y5ibyrq";
	}

	public static UI_RewardSlot2 CreateInstance()
	{
		return (UI_RewardSlot2)(object)UIPackage.CreateObject("WeekActivity", "RewardSlot2");
	}

	public static UI_RewardSlot2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RewardSlot2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5ibyrq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		Back = (GLoader)((GComponent)this).GetChild("Back");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n20 = (GGroup)((GComponent)this).GetChild("n20");
		n15 = (GMovieClip)((GComponent)this).GetChild("n15");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
