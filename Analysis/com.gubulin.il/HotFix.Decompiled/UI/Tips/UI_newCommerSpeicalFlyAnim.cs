using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_newCommerSpeicalFlyAnim : GComponent
{
	public Controller showIcon;

	public GGraph mask;

	public GImage n4;

	public UI_newCommerSpecialIcon animIcon;

	public GImage n17;

	public GImage n5;

	public GImage n6;

	public GImage n14;

	public GImage n15;

	public GMovieClip n8;

	public GImage n9;

	public UI_PromptBubble n10;

	public GGraph flyEndPos;

	public GGroup n7;

	public GImage n16;

	public GMovieClip n18;

	public Transition t0;

	public Transition t1;

	public Transition t2;

	public Transition t3;

	public Transition t4;

	public const string URL = "ui://47lbpgx9ru7mj5ltey";

	public static string Name = "UI_newCommerSpeicalFlyAnim";

	public static string GetURL()
	{
		return "ui://47lbpgx9ru7mj5ltey";
	}

	public static UI_newCommerSpeicalFlyAnim CreateInstance()
	{
		return (UI_newCommerSpeicalFlyAnim)(object)UIPackage.CreateObject("Tips", "newCommerSpeicalFlyAnim");
	}

	public static UI_newCommerSpeicalFlyAnim CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_newCommerSpeicalFlyAnim).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9ru7mj5ltey", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
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
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		showIcon = ((GComponent)this).GetController("showIcon");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		animIcon = (UI_newCommerSpecialIcon)(object)((GComponent)this).GetChild("animIcon");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n8 = (GMovieClip)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (UI_PromptBubble)(object)((GComponent)this).GetChild("n10");
		flyEndPos = (GGraph)((GComponent)this).GetChild("flyEndPos");
		n7 = (GGroup)((GComponent)this).GetChild("n7");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n18 = (GMovieClip)((GComponent)this).GetChild("n18");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
		t2 = ((GComponent)this).GetTransition("t2");
		t3 = ((GComponent)this).GetTransition("t3");
		t4 = ((GComponent)this).GetTransition("t4");
	}
}
