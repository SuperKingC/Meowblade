using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_RandomEventBubble : GButton
{
	public Controller HasCountdown;

	public Controller EventType;

	public Controller SmallIcontype;

	public Controller button;

	public GImage n10;

	public GImage n0;

	public GImage n3;

	public GImage n15;

	public GLoader Icon;

	public GImage n6;

	public GImage n5;

	public GGroup n7;

	public GLoader n4;

	public GLoader n16;

	public GMovieClip n13;

	public GGroup n14;

	public GImage mask;

	public GImage n11;

	public GGroup n12;

	public GTextField Countdown;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2dc6m88";

	public static string Name = "UI_com_RandomEventBubble";

	public static string GetURL()
	{
		return "ui://4eq8fgd2dc6m88";
	}

	public static UI_com_RandomEventBubble CreateInstance()
	{
		return (UI_com_RandomEventBubble)(object)UIPackage.CreateObject("GvGWorldMap3", "com_RandomEventBubble");
	}

	public static UI_com_RandomEventBubble CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RandomEventBubble).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2dc6m88", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasCountdown = ((GComponent)this).GetController("HasCountdown");
		EventType = ((GComponent)this).GetController("EventType");
		SmallIcontype = ((GComponent)this).GetController("SmallIcontype");
		button = ((GComponent)this).GetController("button");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n7 = (GGroup)((GComponent)this).GetChild("n7");
		n4 = (GLoader)((GComponent)this).GetChild("n4");
		n16 = (GLoader)((GComponent)this).GetChild("n16");
		n13 = (GMovieClip)((GComponent)this).GetChild("n13");
		n14 = (GGroup)((GComponent)this).GetChild("n14");
		mask = (GImage)((GComponent)this).GetChild("mask");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		n12 = (GGroup)((GComponent)this).GetChild("n12");
		Countdown = (GTextField)((GComponent)this).GetChild("Countdown");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
