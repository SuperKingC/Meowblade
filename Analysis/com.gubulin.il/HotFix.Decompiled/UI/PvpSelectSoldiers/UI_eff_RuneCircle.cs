using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_eff_RuneCircle : GComponent
{
	public GImage n111;

	public GImage n110;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://82mo10n5ielxjdsg";

	public static string Name = "UI_eff_RuneCircle";

	public static string GetURL()
	{
		return "ui://82mo10n5ielxjdsg";
	}

	public static UI_eff_RuneCircle CreateInstance()
	{
		return (UI_eff_RuneCircle)(object)UIPackage.CreateObject("PvpSelectSoldiers", "eff_RuneCircle");
	}

	public static UI_eff_RuneCircle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_RuneCircle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5ielxjdsg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n111 = (GImage)((GComponent)this).GetChild("n111");
		n110 = (GImage)((GComponent)this).GetChild("n110");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
