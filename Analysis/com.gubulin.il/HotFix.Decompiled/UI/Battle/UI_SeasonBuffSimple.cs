using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_SeasonBuffSimple : GComponent
{
	public GImage n1;

	public GLoader Icon;

	public GRichTextField EffectNameLevel;

	public GImage n3;

	public Transition Appear;

	public const string URL = "ui://twlbabicol04m9";

	public static string Name = "UI_SeasonBuffSimple";

	public static string GetURL()
	{
		return "ui://twlbabicol04m9";
	}

	public static UI_SeasonBuffSimple CreateInstance()
	{
		return (UI_SeasonBuffSimple)(object)UIPackage.CreateObject("Battle", "SeasonBuffSimple");
	}

	public static UI_SeasonBuffSimple CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SeasonBuffSimple).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicol04m9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n1 = (GImage)((GComponent)this).GetChild("n1");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		EffectNameLevel = (GRichTextField)((GComponent)this).GetChild("EffectNameLevel");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		Appear = ((GComponent)this).GetTransition("Appear");
	}
}
