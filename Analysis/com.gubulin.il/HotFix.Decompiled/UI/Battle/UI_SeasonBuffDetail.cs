using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_SeasonBuffDetail : GComponent
{
	public Controller Show;

	public GImage n1;

	public GImage n8;

	public GImage n5;

	public GRichTextField EffectNameLevel;

	public GTextField EffectText;

	public UI_com_Ability BuffIcon;

	public Transition Appear;

	public Transition Disappear;

	public Transition AppearImmediately;

	public Transition DisappearImmediately;

	public const string URL = "ui://twlbabicol04ma";

	public static string Name = "UI_SeasonBuffDetail";

	public static string GetURL()
	{
		return "ui://twlbabicol04ma";
	}

	public static UI_SeasonBuffDetail CreateInstance()
	{
		return (UI_SeasonBuffDetail)(object)UIPackage.CreateObject("Battle", "SeasonBuffDetail");
	}

	public static UI_SeasonBuffDetail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SeasonBuffDetail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicol04ma", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Show = ((GComponent)this).GetController("Show");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		EffectNameLevel = (GRichTextField)((GComponent)this).GetChild("EffectNameLevel");
		EffectText = (GTextField)((GComponent)this).GetChild("EffectText");
		BuffIcon = (UI_com_Ability)(object)((GComponent)this).GetChild("BuffIcon");
		Appear = ((GComponent)this).GetTransition("Appear");
		Disappear = ((GComponent)this).GetTransition("Disappear");
		AppearImmediately = ((GComponent)this).GetTransition("AppearImmediately");
		DisappearImmediately = ((GComponent)this).GetTransition("DisappearImmediately");
	}
}
