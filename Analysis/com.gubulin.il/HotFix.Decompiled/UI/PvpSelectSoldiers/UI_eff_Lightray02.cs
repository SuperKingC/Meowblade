using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_eff_Lightray02 : GComponent
{
	public GImage n120;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://82mo10n5ielxjdsr";

	public static string Name = "UI_eff_Lightray02";

	public static string GetURL()
	{
		return "ui://82mo10n5ielxjdsr";
	}

	public static UI_eff_Lightray02 CreateInstance()
	{
		return (UI_eff_Lightray02)(object)UIPackage.CreateObject("PvpSelectSoldiers", "eff_Lightray02");
	}

	public static UI_eff_Lightray02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_Lightray02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5ielxjdsr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n120 = (GImage)((GComponent)this).GetChild("n120");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
