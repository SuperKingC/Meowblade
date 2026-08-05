using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PlayerListItem : GButton
{
	public Controller SchedulePage;

	public Controller RankLevel;

	public Controller HasMedal;

	public Controller HasHornorTitle;

	public Controller IsMe;

	public Controller MatchStage;

	public GLoader PlayerItemFrame;

	public GLoader RankTop3Deco;

	public UI_Avatar PlayerAvatar;

	public GTextField PlayerName;

	public GTextField ScoreTypeName;

	public GTextField NoScoreDefault;

	public GTextField ScoreNumber;

	public GGroup ScoreGroup;

	public GTextField RankNumber;

	public GLoader RankTop3;

	public GLoader HonorTitle;

	public GList MedalList;

	public GImage n36;

	public GTextField IsMeText;

	public GGroup IsMeGroup;

	public GGroup n39;

	public Transition t0;

	public const string URL = "ui://82mo10n5exsyjdqu";

	public static string Name = "UI_PlayerListItem";

	public static string GetURL()
	{
		return "ui://82mo10n5exsyjdqu";
	}

	public static UI_PlayerListItem CreateInstance()
	{
		return (UI_PlayerListItem)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PlayerListItem");
	}

	public static UI_PlayerListItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PlayerListItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5exsyjdqu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SchedulePage = ((GComponent)this).GetController("SchedulePage");
		RankLevel = ((GComponent)this).GetController("RankLevel");
		HasMedal = ((GComponent)this).GetController("HasMedal");
		HasHornorTitle = ((GComponent)this).GetController("HasHornorTitle");
		IsMe = ((GComponent)this).GetController("IsMe");
		MatchStage = ((GComponent)this).GetController("MatchStage");
		PlayerItemFrame = (GLoader)((GComponent)this).GetChild("PlayerItemFrame");
		RankTop3Deco = (GLoader)((GComponent)this).GetChild("RankTop3Deco");
		PlayerAvatar = (UI_Avatar)(object)((GComponent)this).GetChild("PlayerAvatar");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		ScoreTypeName = (GTextField)((GComponent)this).GetChild("ScoreTypeName");
		string id = "ui://82mo10n5exsyjdqu".Replace("ui://", "") + "-" + ((GObject)ScoreTypeName).id;
		((GObject)ScoreTypeName).text = LanguagesManager.GetDesc(id);
		NoScoreDefault = (GTextField)((GComponent)this).GetChild("NoScoreDefault");
		string id2 = "ui://82mo10n5exsyjdqu".Replace("ui://", "") + "-" + ((GObject)NoScoreDefault).id;
		((GObject)NoScoreDefault).text = LanguagesManager.GetDesc(id2);
		ScoreNumber = (GTextField)((GComponent)this).GetChild("ScoreNumber");
		ScoreGroup = (GGroup)((GComponent)this).GetChild("ScoreGroup");
		RankNumber = (GTextField)((GComponent)this).GetChild("RankNumber");
		RankTop3 = (GLoader)((GComponent)this).GetChild("RankTop3");
		HonorTitle = (GLoader)((GComponent)this).GetChild("HonorTitle");
		MedalList = (GList)((GComponent)this).GetChild("MedalList");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		IsMeText = (GTextField)((GComponent)this).GetChild("IsMeText");
		string id3 = "ui://82mo10n5exsyjdqu".Replace("ui://", "") + "-" + ((GObject)IsMeText).id;
		((GObject)IsMeText).text = LanguagesManager.GetDesc(id3);
		IsMeGroup = (GGroup)((GComponent)this).GetChild("IsMeGroup");
		n39 = (GGroup)((GComponent)this).GetChild("n39");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
