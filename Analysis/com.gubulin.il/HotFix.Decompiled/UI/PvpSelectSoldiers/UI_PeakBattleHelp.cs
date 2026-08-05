using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PeakBattleHelp : GButton
{
	public Controller button;

	public GImage n5;

	public const string URL = "ui://82mo10n5x1jlddf";

	public static string Name = "UI_PeakBattleHelp";

	public static string GetURL()
	{
		return "ui://82mo10n5x1jlddf";
	}

	public static UI_PeakBattleHelp CreateInstance()
	{
		return (UI_PeakBattleHelp)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PeakBattleHelp");
	}

	public static UI_PeakBattleHelp CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PeakBattleHelp).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5x1jlddf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
