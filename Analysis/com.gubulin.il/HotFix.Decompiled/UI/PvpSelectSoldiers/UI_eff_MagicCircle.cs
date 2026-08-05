using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_eff_MagicCircle : GComponent
{
	public GImage n109;

	public Transition t0;

	public const string URL = "ui://82mo10n5ielxjdsh";

	public static string Name = "UI_eff_MagicCircle";

	public static string GetURL()
	{
		return "ui://82mo10n5ielxjdsh";
	}

	public static UI_eff_MagicCircle CreateInstance()
	{
		return (UI_eff_MagicCircle)(object)UIPackage.CreateObject("PvpSelectSoldiers", "eff_MagicCircle");
	}

	public static UI_eff_MagicCircle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_MagicCircle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5ielxjdsh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n109 = (GImage)((GComponent)this).GetChild("n109");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
