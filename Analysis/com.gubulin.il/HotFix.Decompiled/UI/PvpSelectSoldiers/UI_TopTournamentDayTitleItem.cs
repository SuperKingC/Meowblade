using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_TopTournamentDayTitleItem : GButton
{
	public Controller button;

	public GTextField CurrentDay;

	public const string URL = "ui://82mo10n5aveldh2";

	public static string Name = "UI_TopTournamentDayTitleItem";

	public static string GetURL()
	{
		return "ui://82mo10n5aveldh2";
	}

	public static UI_TopTournamentDayTitleItem CreateInstance()
	{
		return (UI_TopTournamentDayTitleItem)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopTournamentDayTitleItem");
	}

	public static UI_TopTournamentDayTitleItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopTournamentDayTitleItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5aveldh2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		CurrentDay = (GTextField)((GComponent)this).GetChild("CurrentDay");
	}
}
