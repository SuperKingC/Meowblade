using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_eff_TitleSpark : GComponent
{
	public GImage n41;

	public Transition t0;

	public Transition Start;

	public const string URL = "ui://82mo10n5y310doq";

	public static string Name = "UI_eff_TitleSpark";

	public static string GetURL()
	{
		return "ui://82mo10n5y310doq";
	}

	public static UI_eff_TitleSpark CreateInstance()
	{
		return (UI_eff_TitleSpark)(object)UIPackage.CreateObject("PvpSelectSoldiers", "eff_TitleSpark");
	}

	public static UI_eff_TitleSpark CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_eff_TitleSpark).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5y310doq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n41 = (GImage)((GComponent)this).GetChild("n41");
		t0 = ((GComponent)this).GetTransition("t0");
		Start = ((GComponent)this).GetTransition("Start");
	}
}
