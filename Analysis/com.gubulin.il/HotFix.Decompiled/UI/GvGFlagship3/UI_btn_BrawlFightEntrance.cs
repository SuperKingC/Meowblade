using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGFlagship3;

public class UI_btn_BrawlFightEntrance : GButton
{
	public Controller button;

	public Controller StepType;

	public UI_dec_portal01 n17;

	public UI_dec_portal02 n18;

	public GImage n9;

	public GImage n10;

	public GImage n12;

	public GImage n11;

	public GImage redNote;

	public GImage n16;

	public GImage n14;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://tvr786zlnt904l";

	public static string Name = "UI_btn_BrawlFightEntrance";

	public static string GetURL()
	{
		return "ui://tvr786zlnt904l";
	}

	public static UI_btn_BrawlFightEntrance CreateInstance()
	{
		return (UI_btn_BrawlFightEntrance)(object)UIPackage.CreateObject("GvGFlagship3", "btn_BrawlFightEntrance");
	}

	public static UI_btn_BrawlFightEntrance CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BrawlFightEntrance).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tvr786zlnt904l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		StepType = ((GComponent)this).GetController("StepType");
		n17 = (UI_dec_portal01)(object)((GComponent)this).GetChild("n17");
		n18 = (UI_dec_portal02)(object)((GComponent)this).GetChild("n18");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		redNote = (GImage)((GComponent)this).GetChild("redNote");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
