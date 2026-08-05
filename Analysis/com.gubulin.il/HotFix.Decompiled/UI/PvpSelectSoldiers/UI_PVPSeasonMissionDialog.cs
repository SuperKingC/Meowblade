using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PVPSeasonMissionDialog : GComponent
{
	public Controller PageController;

	public Controller CardState;

	public Controller CardRewardListState;

	public GImage Background;

	public GButton ExitButton;

	public GImage n2;

	public GImage n3;

	public GTextField RemainingTime;

	public GTextField TipText;

	public GGraph n9;

	public UI_btn_SeasonMissionTab WeeklyTab;

	public UI_btn_SeasonMissionTab SeasonTab;

	public GList MissionList;

	public GImage n16;

	public GImage n20;

	public GImage n45;

	public GImage n11;

	public GLoader CurrentScoreIcon;

	public GTextField n13;

	public GTextField CurrentScore;

	public GGraph n52;

	public GGraph n51;

	public UI_ScoreBonusNode ScoreBonusNode;

	public GButton TurnPageUpBtn;

	public GButton TurnPageDownBtn;

	public GGraph mask;

	public GLoader CardRewardIcon;

	public UI_RewardMissileWrapper RewardMissileWrapper;

	public GMovieClip n48;

	public Transition GetReward;

	public const string URL = "ui://82mo10n5g21rdpa";

	public static string Name = "UI_PVPSeasonMissionDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5g21rdpa";
	}

	public static UI_PVPSeasonMissionDialog CreateInstance()
	{
		return (UI_PVPSeasonMissionDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PVPSeasonMissionDialog");
	}

	public static UI_PVPSeasonMissionDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PVPSeasonMissionDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5g21rdpa", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		CardState = ((GComponent)this).GetController("CardState");
		CardRewardListState = ((GComponent)this).GetController("CardRewardListState");
		Background = (GImage)((GComponent)this).GetChild("Background");
		ExitButton = (GButton)((GComponent)this).GetChild("ExitButton");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		RemainingTime = (GTextField)((GComponent)this).GetChild("RemainingTime");
		TipText = (GTextField)((GComponent)this).GetChild("TipText");
		n9 = (GGraph)((GComponent)this).GetChild("n9");
		WeeklyTab = (UI_btn_SeasonMissionTab)(object)((GComponent)this).GetChild("WeeklyTab");
		SeasonTab = (UI_btn_SeasonMissionTab)(object)((GComponent)this).GetChild("SeasonTab");
		MissionList = (GList)((GComponent)this).GetChild("MissionList");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n20 = (GImage)((GComponent)this).GetChild("n20");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		CurrentScoreIcon = (GLoader)((GComponent)this).GetChild("CurrentScoreIcon");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id = "ui://82mo10n5g21rdpa".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id);
		CurrentScore = (GTextField)((GComponent)this).GetChild("CurrentScore");
		n52 = (GGraph)((GComponent)this).GetChild("n52");
		n51 = (GGraph)((GComponent)this).GetChild("n51");
		ScoreBonusNode = (UI_ScoreBonusNode)(object)((GComponent)this).GetChild("ScoreBonusNode");
		TurnPageUpBtn = (GButton)((GComponent)this).GetChild("TurnPageUpBtn");
		TurnPageDownBtn = (GButton)((GComponent)this).GetChild("TurnPageDownBtn");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		CardRewardIcon = (GLoader)((GComponent)this).GetChild("CardRewardIcon");
		RewardMissileWrapper = (UI_RewardMissileWrapper)(object)((GComponent)this).GetChild("RewardMissileWrapper");
		n48 = (GMovieClip)((GComponent)this).GetChild("n48");
		GetReward = ((GComponent)this).GetTransition("GetReward");
	}
}
