using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_ChallengeTabBtn : GButton
{
	public Controller button;

	public Controller SelectState;

	public Controller Index;

	public GImage icon1;

	public GImage n28;

	public GLoader n49;

	public GGroup n30;

	public GImage icon2;

	public GImage n31;

	public GLoader n50;

	public GGroup n33;

	public GImage icon3;

	public GImage n34;

	public GLoader n51;

	public GGroup n36;

	public GImage icon4;

	public GImage n37;

	public GLoader n52;

	public GGroup n39;

	public GImage icon5;

	public GImage n40;

	public GLoader n53;

	public GGroup n42;

	public GImage icon6;

	public GImage n43;

	public GLoader n54;

	public GGroup n45;

	public GImage n27;

	public GImage n46;

	public GImage n47;

	public GGroup n48;

	public GImage tick;

	public GImage note;

	public Transition t0;

	public const string URL = "ui://mapat4i5pjcu8f";

	public static string Name = "UI_ChallengeTabBtn";

	public static string GetURL()
	{
		return "ui://mapat4i5pjcu8f";
	}

	public static UI_ChallengeTabBtn CreateInstance()
	{
		return (UI_ChallengeTabBtn)(object)UIPackage.CreateObject("ProgressionMission", "ChallengeTabBtn");
	}

	public static UI_ChallengeTabBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChallengeTabBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5pjcu8f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		SelectState = ((GComponent)this).GetController("SelectState");
		Index = ((GComponent)this).GetController("Index");
		icon1 = (GImage)((GComponent)this).GetChild("icon1");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n49 = (GLoader)((GComponent)this).GetChild("n49");
		n30 = (GGroup)((GComponent)this).GetChild("n30");
		icon2 = (GImage)((GComponent)this).GetChild("icon2");
		n31 = (GImage)((GComponent)this).GetChild("n31");
		n50 = (GLoader)((GComponent)this).GetChild("n50");
		n33 = (GGroup)((GComponent)this).GetChild("n33");
		icon3 = (GImage)((GComponent)this).GetChild("icon3");
		n34 = (GImage)((GComponent)this).GetChild("n34");
		n51 = (GLoader)((GComponent)this).GetChild("n51");
		n36 = (GGroup)((GComponent)this).GetChild("n36");
		icon4 = (GImage)((GComponent)this).GetChild("icon4");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		n52 = (GLoader)((GComponent)this).GetChild("n52");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
		icon5 = (GImage)((GComponent)this).GetChild("icon5");
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n53 = (GLoader)((GComponent)this).GetChild("n53");
		n42 = (GGroup)((GComponent)this).GetChild("n42");
		icon6 = (GImage)((GComponent)this).GetChild("icon6");
		n43 = (GImage)((GComponent)this).GetChild("n43");
		n54 = (GLoader)((GComponent)this).GetChild("n54");
		n45 = (GGroup)((GComponent)this).GetChild("n45");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n48 = (GGroup)((GComponent)this).GetChild("n48");
		tick = (GImage)((GComponent)this).GetChild("tick");
		note = (GImage)((GComponent)this).GetChild("note");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
