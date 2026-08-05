using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_MakeWar : GButton
{
	public Controller button;

	public Controller Status;

	public UI_com_01 nextRewardInfo;

	public GImage sword_r;

	public GImage sword_l;

	public GMovieClip n18;

	public GImage n9;

	public GGroup n12;

	public GImage n10;

	public GImage n11;

	public GGroup n14;

	public Transition CommonIdle;

	public Transition CommonBegin;

	public const string URL = "ui://twlbabicgktv3";

	public static string Name = "UI_MakeWar";

	public static string GetURL()
	{
		return "ui://twlbabicgktv3";
	}

	public static UI_MakeWar CreateInstance()
	{
		return (UI_MakeWar)(object)UIPackage.CreateObject("Battle", "MakeWar");
	}

	public static UI_MakeWar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MakeWar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicgktv3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
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
		Status = ((GComponent)this).GetController("Status");
		nextRewardInfo = (UI_com_01)(object)((GComponent)this).GetChild("nextRewardInfo");
		sword_r = (GImage)((GComponent)this).GetChild("sword-r");
		sword_l = (GImage)((GComponent)this).GetChild("sword-l");
		n18 = (GMovieClip)((GComponent)this).GetChild("n18");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n12 = (GGroup)((GComponent)this).GetChild("n12");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n14 = (GGroup)((GComponent)this).GetChild("n14");
		CommonIdle = ((GComponent)this).GetTransition("CommonIdle");
		CommonBegin = ((GComponent)this).GetTransition("CommonBegin");
	}
}
