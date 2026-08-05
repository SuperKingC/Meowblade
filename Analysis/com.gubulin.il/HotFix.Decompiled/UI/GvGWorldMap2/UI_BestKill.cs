using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_BestKill : GComponent
{
	public Controller State;

	public GGraph n16;

	public GGraph ChangeVfx;

	public GGraph LoopVfx;

	public GGraph AppearVfx;

	public GImage n2;

	public GTextField PlayerName;

	public GImage n6;

	public UI_Avatar Avatar;

	public GImage n4;

	public GImage n3;

	public GGraph DisappearVfx;

	public UI_BestKillNumber BestKillNumber;

	public GImage n15;

	public GGroup n8;

	public GGraph Disappear2Vfx;

	public GImage n18;

	public Transition Appear;

	public Transition Change;

	public Transition DisAppear;

	public Transition DisAppear2;

	public const string URL = "ui://hd2s9kukngny5n";

	public static string Name = "UI_BestKill";

	public static string GetURL()
	{
		return "ui://hd2s9kukngny5n";
	}

	public static UI_BestKill CreateInstance()
	{
		return (UI_BestKill)(object)UIPackage.CreateObject("GvGWorldMap2", "BestKill");
	}

	public static UI_BestKill CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BestKill).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukngny5n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n16 = (GGraph)((GComponent)this).GetChild("n16");
		ChangeVfx = (GGraph)((GComponent)this).GetChild("ChangeVfx");
		LoopVfx = (GGraph)((GComponent)this).GetChild("LoopVfx");
		AppearVfx = (GGraph)((GComponent)this).GetChild("AppearVfx");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		string id = "ui://hd2s9kukngny5n".Replace("ui://", "") + "-" + ((GObject)PlayerName).id;
		((GObject)PlayerName).text = LanguagesManager.GetDesc(id);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		Avatar = (UI_Avatar)(object)((GComponent)this).GetChild("Avatar");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		DisappearVfx = (GGraph)((GComponent)this).GetChild("DisappearVfx");
		BestKillNumber = (UI_BestKillNumber)(object)((GComponent)this).GetChild("BestKillNumber");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n8 = (GGroup)((GComponent)this).GetChild("n8");
		Disappear2Vfx = (GGraph)((GComponent)this).GetChild("Disappear2Vfx");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		Appear = ((GComponent)this).GetTransition("Appear");
		Change = ((GComponent)this).GetTransition("Change");
		DisAppear = ((GComponent)this).GetTransition("DisAppear");
		DisAppear2 = ((GComponent)this).GetTransition("DisAppear2");
	}
}
