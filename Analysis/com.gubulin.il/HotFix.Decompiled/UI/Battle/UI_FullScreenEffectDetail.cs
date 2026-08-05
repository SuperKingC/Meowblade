using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_FullScreenEffectDetail : GComponent
{
	public Controller Show;

	public GImage n1;

	public GImage n5;

	public GLoader Icon;

	public GImage n4;

	public GRichTextField EffectNameLevel;

	public GTextField EffectText;

	public Transition Appear;

	public Transition Disappear;

	public Transition AppearImmediately;

	public Transition DisappearImmediately;

	public const string URL = "ui://twlbabicol04mf";

	public static string Name = "UI_FullScreenEffectDetail";

	public static string GetURL()
	{
		return "ui://twlbabicol04mf";
	}

	public static UI_FullScreenEffectDetail CreateInstance()
	{
		return (UI_FullScreenEffectDetail)(object)UIPackage.CreateObject("Battle", "FullScreenEffectDetail");
	}

	public static UI_FullScreenEffectDetail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FullScreenEffectDetail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicol04mf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Show = ((GComponent)this).GetController("Show");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		EffectNameLevel = (GRichTextField)((GComponent)this).GetChild("EffectNameLevel");
		EffectText = (GTextField)((GComponent)this).GetChild("EffectText");
		Appear = ((GComponent)this).GetTransition("Appear");
		Disappear = ((GComponent)this).GetTransition("Disappear");
		AppearImmediately = ((GComponent)this).GetTransition("AppearImmediately");
		DisappearImmediately = ((GComponent)this).GetTransition("DisappearImmediately");
	}
}
