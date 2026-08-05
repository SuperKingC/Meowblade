using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_EffectIcon : GComponent
{
	public GLoader Icon;

	public GImage n1;

	public Transition Move;

	public const string URL = "ui://twlbabicol04me";

	public static string Name = "UI_EffectIcon";

	public static string GetURL()
	{
		return "ui://twlbabicol04me";
	}

	public static UI_EffectIcon CreateInstance()
	{
		return (UI_EffectIcon)(object)UIPackage.CreateObject("Battle", "EffectIcon");
	}

	public static UI_EffectIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EffectIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicol04me", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		Move = ((GComponent)this).GetTransition("Move");
	}
}
