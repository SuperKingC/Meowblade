using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_ShenJiHeader : GComponent
{
	public Controller State;

	public GGraph ClickGraph;

	public GImage scoreProgressBarBg;

	public GImage scoreProgressBar;

	public GTextField scoreProgressText;

	public UI_btn_ExchangeCoupon couponIcon;

	public GImage n50;

	public GMovieClip n51;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://fvc33k3glb9j4f";

	public static string Name = "UI_com_ShenJiHeader";

	public static string GetURL()
	{
		return "ui://fvc33k3glb9j4f";
	}

	public static UI_com_ShenJiHeader CreateInstance()
	{
		return (UI_com_ShenJiHeader)(object)UIPackage.CreateObject("GVGStore", "com_ShenJiHeader");
	}

	public static UI_com_ShenJiHeader CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShenJiHeader).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3glb9j4f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		ClickGraph = (GGraph)((GComponent)this).GetChild("ClickGraph");
		scoreProgressBarBg = (GImage)((GComponent)this).GetChild("scoreProgressBarBg");
		scoreProgressBar = (GImage)((GComponent)this).GetChild("scoreProgressBar");
		scoreProgressText = (GTextField)((GComponent)this).GetChild("scoreProgressText");
		couponIcon = (UI_btn_ExchangeCoupon)(object)((GComponent)this).GetChild("couponIcon");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n51 = (GMovieClip)((GComponent)this).GetChild("n51");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
