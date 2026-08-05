using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_dec_RuneCircleRight : GComponent
{
	public UI_eff_RuneCircle eff_RuneCircle1;

	public const string URL = "ui://82mo10n5ielxjdsn";

	public static string Name = "UI_dec_RuneCircleRight";

	public static string GetURL()
	{
		return "ui://82mo10n5ielxjdsn";
	}

	public static UI_dec_RuneCircleRight CreateInstance()
	{
		return (UI_dec_RuneCircleRight)(object)UIPackage.CreateObject("PvpSelectSoldiers", "dec_RuneCircleRight");
	}

	public static UI_dec_RuneCircleRight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_RuneCircleRight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5ielxjdsn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		eff_RuneCircle1 = (UI_eff_RuneCircle)(object)((GComponent)this).GetChild("eff_RuneCircle1");
	}
}
