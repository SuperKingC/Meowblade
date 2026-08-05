using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_ChcekTopTournamentLog : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://82mo10n5aveldgj";

	public static string Name = "UI_ChcekTopTournamentLog";

	public static string GetURL()
	{
		return "ui://82mo10n5aveldgj";
	}

	public static UI_ChcekTopTournamentLog CreateInstance()
	{
		return (UI_ChcekTopTournamentLog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ChcekTopTournamentLog");
	}

	public static UI_ChcekTopTournamentLog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ChcekTopTournamentLog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5aveldgj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
