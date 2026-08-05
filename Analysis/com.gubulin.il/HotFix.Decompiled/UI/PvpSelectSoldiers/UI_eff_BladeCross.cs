using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_eff_BladeCross : GComponent
{
	public GImage n6;

	public GImage n7;

	public Transition t0;

	public const string URL = "ui://82mo10n5uwtxjdrt";

	public static string Name = "UI_eff_BladeCross";

	public static string GetURL()
	{
		return "ui://82mo10n5uwtxjdrt";
	}

	public static UI_eff_BladeCross CreateInstance()
	{
		return (UI_eff_BladeCross)(object)UIPackage.CreateObject("PvpSelectSoldiers", "eff_BladeCross");
	}

	public static UI_eff_BladeCross CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_BladeCross).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5uwtxjdrt", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
