using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_SeasonBuffEffectIcon : GComponent
{
	public UI_com_Ability n2;

	public Transition Move;

	public const string URL = "ui://twlbabicol04mg";

	public static string Name = "UI_SeasonBuffEffectIcon";

	public static string GetURL()
	{
		return "ui://twlbabicol04mg";
	}

	public static UI_SeasonBuffEffectIcon CreateInstance()
	{
		return (UI_SeasonBuffEffectIcon)(object)UIPackage.CreateObject("Battle", "SeasonBuffEffectIcon");
	}

	public static UI_SeasonBuffEffectIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SeasonBuffEffectIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicol04mg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		n2 = (UI_com_Ability)(object)((GComponent)this).GetChild("n2");
		Move = ((GComponent)this).GetTransition("Move");
	}
}
