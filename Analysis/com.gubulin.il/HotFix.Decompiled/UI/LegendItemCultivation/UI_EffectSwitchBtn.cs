using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_EffectSwitchBtn : GButton
{
	public Controller button;

	public GImage icon;

	public const string URL = "ui://b9wlonaqtpmth2";

	public static string Name = "UI_EffectSwitchBtn";

	public static string GetURL()
	{
		return "ui://b9wlonaqtpmth2";
	}

	public static UI_EffectSwitchBtn CreateInstance()
	{
		return (UI_EffectSwitchBtn)(object)UIPackage.CreateObject("LegendItemCultivation", "EffectSwitchBtn");
	}

	public static UI_EffectSwitchBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EffectSwitchBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqtpmth2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		icon = (GImage)((GComponent)this).GetChild("icon");
	}
}
