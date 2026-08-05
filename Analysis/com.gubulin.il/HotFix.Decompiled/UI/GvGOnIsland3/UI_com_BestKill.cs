using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_BestKill : GComponent
{
	public Controller State;

	public GGraph n16;

	public GGraph ChangeVfx;

	public GImage n20;

	public GGraph LoopVfx;

	public GGraph AppearVfx;

	public UI_com_Avatar Avatar;

	public GComponent ShipSkin;

	public GTextField PlayerName;

	public UI_com_BestKillNumber BestKillNumber;

	public GImage n21;

	public GGraph DisappearVfx;

	public GImage n15;

	public GImage n25;

	public GGroup n8;

	public GGraph Disappear2Vfx;

	public GImage n18;

	public GMovieClip n22;

	public GMovieClip n23;

	public GMovieClip n24;

	public GMovieClip n26;

	public GMovieClip n27;

	public Transition Change;

	public Transition DisAppear2;

	public Transition Appear;

	public Transition DisAppear;

	public const string URL = "ui://ebc4ciwrl44l1c";

	public static string Name = "UI_com_BestKill";

	public static string GetURL()
	{
		return "ui://ebc4ciwrl44l1c";
	}

	public static UI_com_BestKill CreateInstance()
	{
		return (UI_com_BestKill)(object)UIPackage.CreateObject("GvGOnIsland3", "com_BestKill");
	}

	public static UI_com_BestKill CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BestKill).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrl44l1c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n16 = (GGraph)((GComponent)this).GetChild("n16");
		ChangeVfx = (GGraph)((GComponent)this).GetChild("ChangeVfx");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		LoopVfx = (GGraph)((GComponent)this).GetChild("LoopVfx");
		AppearVfx = (GGraph)((GComponent)this).GetChild("AppearVfx");
		Avatar = (UI_com_Avatar)(object)((GComponent)this).GetChild("Avatar");
		ShipSkin = (GComponent)((GComponent)this).GetChild("ShipSkin");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		string id = "ui://ebc4ciwrl44l1c".Replace("ui://", "") + "-" + ((GObject)PlayerName).id;
		((GObject)PlayerName).text = LanguagesManager.GetDesc(id);
		BestKillNumber = (UI_com_BestKillNumber)(object)((GComponent)this).GetChild("BestKillNumber");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		DisappearVfx = (GGraph)((GComponent)this).GetChild("DisappearVfx");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n8 = (GGroup)((GComponent)this).GetChild("n8");
		Disappear2Vfx = (GGraph)((GComponent)this).GetChild("Disappear2Vfx");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n22 = (GMovieClip)((GComponent)this).GetChild("n22");
		n23 = (GMovieClip)((GComponent)this).GetChild("n23");
		n24 = (GMovieClip)((GComponent)this).GetChild("n24");
		n26 = (GMovieClip)((GComponent)this).GetChild("n26");
		n27 = (GMovieClip)((GComponent)this).GetChild("n27");
		Change = ((GComponent)this).GetTransition("Change");
		DisAppear2 = ((GComponent)this).GetTransition("DisAppear2");
		Appear = ((GComponent)this).GetTransition("Appear");
		DisAppear = ((GComponent)this).GetTransition("DisAppear");
	}
}
