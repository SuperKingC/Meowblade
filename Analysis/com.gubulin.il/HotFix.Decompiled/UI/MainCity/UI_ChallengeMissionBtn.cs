using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_ChallengeMissionBtn : GButton
{
	public Controller isUnLocked;

	public GImage n3;

	public GImage n6;

	public GImage n12;

	public GImage n13;

	public GTextField countDownUnlock;

	public GTextField countDownLock;

	public GTextField endSoon;

	public GMovieClip n14;

	public GTextField n15;

	public GImage n8;

	public Transition t0;

	public const string URL = "ui://j611zmym7wjav44u";

	public static string Name = "UI_ChallengeMissionBtn";

	public static string GetURL()
	{
		return "ui://j611zmym7wjav44u";
	}

	public static UI_ChallengeMissionBtn CreateInstance()
	{
		return (UI_ChallengeMissionBtn)(object)UIPackage.CreateObject("MainCity", "ChallengeMissionBtn");
	}

	public static UI_ChallengeMissionBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChallengeMissionBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmym7wjav44u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isUnLocked = ((GComponent)this).GetController("isUnLocked");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		countDownUnlock = (GTextField)((GComponent)this).GetChild("countDownUnlock");
		string id = "ui://j611zmym7wjav44u".Replace("ui://", "") + "-" + ((GObject)countDownUnlock).id;
		((GObject)countDownUnlock).text = LanguagesManager.GetDesc(id);
		countDownLock = (GTextField)((GComponent)this).GetChild("countDownLock");
		string id2 = "ui://j611zmym7wjav44u".Replace("ui://", "") + "-" + ((GObject)countDownLock).id;
		((GObject)countDownLock).text = LanguagesManager.GetDesc(id2);
		endSoon = (GTextField)((GComponent)this).GetChild("endSoon");
		string id3 = "ui://j611zmym7wjav44u".Replace("ui://", "") + "-" + ((GObject)endSoon).id;
		((GObject)endSoon).text = LanguagesManager.GetDesc(id3);
		n14 = (GMovieClip)((GComponent)this).GetChild("n14");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id4 = "ui://j611zmym7wjav44u".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id4);
		n8 = (GImage)((GComponent)this).GetChild("n8");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
