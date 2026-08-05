using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PlayerRankInfo : GButton
{
	public Controller button;

	public Controller isShowMedal;

	public GImage n30;

	public GGraph Back;

	public GList enemy;

	public GImage n22;

	public GTextField WaveNumber;

	public GGroup n32;

	public UI_RankingListAvatar Avatar;

	public UI_RankListLevelDiy Rank;

	public GTextField Layer;

	public GTextField LegionCombatPower;

	public GTextField ScoreIncome;

	public GTextField PlayerName;

	public GTextField n28;

	public GTextField n29;

	public GGroup n33;

	public UI_Fight Capture;

	public GImage n24;

	public GTextField CdTime;

	public GTextField lockTip;

	public GGroup n34;

	public GList medalList;

	public const string URL = "ui://82mo10n5js4q6v";

	public static string Name = "UI_PlayerRankInfo";

	public static string GetURL()
	{
		return "ui://82mo10n5js4q6v";
	}

	public static UI_PlayerRankInfo CreateInstance()
	{
		return (UI_PlayerRankInfo)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PlayerRankInfo");
	}

	public static UI_PlayerRankInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PlayerRankInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5js4q6v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		isShowMedal = ((GComponent)this).GetController("isShowMedal");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		Back = (GGraph)((GComponent)this).GetChild("Back");
		enemy = (GList)((GComponent)this).GetChild("enemy");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		WaveNumber = (GTextField)((GComponent)this).GetChild("WaveNumber");
		n32 = (GGroup)((GComponent)this).GetChild("n32");
		Avatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("Avatar");
		Rank = (UI_RankListLevelDiy)(object)((GComponent)this).GetChild("Rank");
		Layer = (GTextField)((GComponent)this).GetChild("Layer");
		LegionCombatPower = (GTextField)((GComponent)this).GetChild("LegionCombatPower");
		ScoreIncome = (GTextField)((GComponent)this).GetChild("ScoreIncome");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id = "ui://82mo10n5js4q6v".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id);
		n29 = (GTextField)((GComponent)this).GetChild("n29");
		string id2 = "ui://82mo10n5js4q6v".Replace("ui://", "") + "-" + ((GObject)n29).id;
		((GObject)n29).text = LanguagesManager.GetDesc(id2);
		n33 = (GGroup)((GComponent)this).GetChild("n33");
		Capture = (UI_Fight)(object)((GComponent)this).GetChild("Capture");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		CdTime = (GTextField)((GComponent)this).GetChild("CdTime");
		lockTip = (GTextField)((GComponent)this).GetChild("lockTip");
		string id3 = "ui://82mo10n5js4q6v".Replace("ui://", "") + "-" + ((GObject)lockTip).id;
		((GObject)lockTip).text = LanguagesManager.GetDesc(id3);
		n34 = (GGroup)((GComponent)this).GetChild("n34");
		medalList = (GList)((GComponent)this).GetChild("medalList");
	}
}
