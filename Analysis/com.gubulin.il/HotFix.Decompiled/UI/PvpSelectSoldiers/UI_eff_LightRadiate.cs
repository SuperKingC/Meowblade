using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_eff_LightRadiate : GComponent
{
	public GImage n131;

	public Transition t0;

	public const string URL = "ui://82mo10n5sn0gjdsz";

	public static string Name = "UI_eff_LightRadiate";

	public static string GetURL()
	{
		return "ui://82mo10n5sn0gjdsz";
	}

	public static UI_eff_LightRadiate CreateInstance()
	{
		return (UI_eff_LightRadiate)(object)UIPackage.CreateObject("PvpSelectSoldiers", "eff_LightRadiate");
	}

	public static UI_eff_LightRadiate CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_LightRadiate).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5sn0gjdsz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n131 = (GImage)((GComponent)this).GetChild("n131");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
