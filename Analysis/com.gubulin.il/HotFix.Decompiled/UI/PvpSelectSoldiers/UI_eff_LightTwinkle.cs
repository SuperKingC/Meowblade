using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_eff_LightTwinkle : GComponent
{
	public GImage n130;

	public Transition t0;

	public const string URL = "ui://82mo10n5sn0gjdt0";

	public static string Name = "UI_eff_LightTwinkle";

	public static string GetURL()
	{
		return "ui://82mo10n5sn0gjdt0";
	}

	public static UI_eff_LightTwinkle CreateInstance()
	{
		return (UI_eff_LightTwinkle)(object)UIPackage.CreateObject("PvpSelectSoldiers", "eff_LightTwinkle");
	}

	public static UI_eff_LightTwinkle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_LightTwinkle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5sn0gjdt0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n130 = (GImage)((GComponent)this).GetChild("n130");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
