using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PlayerListGroup : GComponent
{
	public Controller SchedulePage;

	public Controller MatchStage;

	public Controller HasData;

	public GImage n14;

	public GImage n15;

	public GTextField FirstMatchPlayerListTitle;

	public GTextField PlayerListTitle;

	public UI_HelpBtn HelpBtn;

	public GList PlayerList;

	public UI_btn_PointToShortlist PointToShortlistBtn;

	public UI_btn_PointToShortlist PointTopPosition;

	public UI_btn_PointToShortlist PointBottomPosition;

	public GImage n69;

	public GTextField NoDataTip;

	public GGroup PlayerListGroup;

	public const string URL = "ui://82mo10n5wb6qjdtj";

	public static string Name = "UI_PlayerListGroup";

	public static string GetURL()
	{
		return "ui://82mo10n5wb6qjdtj";
	}

	public static UI_PlayerListGroup CreateInstance()
	{
		return (UI_PlayerListGroup)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PlayerListGroup");
	}

	public static UI_PlayerListGroup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PlayerListGroup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5wb6qjdtj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SchedulePage = ((GComponent)this).GetController("SchedulePage");
		MatchStage = ((GComponent)this).GetController("MatchStage");
		HasData = ((GComponent)this).GetController("HasData");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		FirstMatchPlayerListTitle = (GTextField)((GComponent)this).GetChild("FirstMatchPlayerListTitle");
		string id = "ui://82mo10n5wb6qjdtj".Replace("ui://", "") + "-" + ((GObject)FirstMatchPlayerListTitle).id;
		((GObject)FirstMatchPlayerListTitle).text = LanguagesManager.GetDesc(id);
		PlayerListTitle = (GTextField)((GComponent)this).GetChild("PlayerListTitle");
		string id2 = "ui://82mo10n5wb6qjdtj".Replace("ui://", "") + "-" + ((GObject)PlayerListTitle).id;
		((GObject)PlayerListTitle).text = LanguagesManager.GetDesc(id2);
		HelpBtn = (UI_HelpBtn)(object)((GComponent)this).GetChild("HelpBtn");
		PlayerList = (GList)((GComponent)this).GetChild("PlayerList");
		PointToShortlistBtn = (UI_btn_PointToShortlist)(object)((GComponent)this).GetChild("PointToShortlistBtn");
		PointTopPosition = (UI_btn_PointToShortlist)(object)((GComponent)this).GetChild("PointTopPosition");
		PointBottomPosition = (UI_btn_PointToShortlist)(object)((GComponent)this).GetChild("PointBottomPosition");
		n69 = (GImage)((GComponent)this).GetChild("n69");
		NoDataTip = (GTextField)((GComponent)this).GetChild("NoDataTip");
		string id3 = "ui://82mo10n5wb6qjdtj".Replace("ui://", "") + "-" + ((GObject)NoDataTip).id;
		((GObject)NoDataTip).text = LanguagesManager.GetDesc(id3);
		PlayerListGroup = (GGroup)((GComponent)this).GetChild("PlayerListGroup");
	}
}
