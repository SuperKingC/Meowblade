using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_TopTournamentLogTitle : GButton
{
	public Controller button;

	public Controller Type;

	public Controller isShowMedal;

	public GGraph back;

	public GTextField UserName;

	public UI_ChcekTopTournamentLog ChcekTopTournamentLog;

	public UI_RankingListAvatar Avatar;

	public GList medalList;

	public const string URL = "ui://82mo10n5aveldgi";

	public static string Name = "UI_TopTournamentLogTitle";

	public static string GetURL()
	{
		return "ui://82mo10n5aveldgi";
	}

	public static UI_TopTournamentLogTitle CreateInstance()
	{
		return (UI_TopTournamentLogTitle)(object)UIPackage.CreateObject("PvpSelectSoldiers", "TopTournamentLogTitle");
	}

	public static UI_TopTournamentLogTitle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopTournamentLogTitle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5aveldgi", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		isShowMedal = ((GComponent)this).GetController("isShowMedal");
		back = (GGraph)((GComponent)this).GetChild("back");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		ChcekTopTournamentLog = (UI_ChcekTopTournamentLog)(object)((GComponent)this).GetChild("ChcekTopTournamentLog");
		Avatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("Avatar");
		medalList = (GList)((GComponent)this).GetChild("medalList");
	}
}
