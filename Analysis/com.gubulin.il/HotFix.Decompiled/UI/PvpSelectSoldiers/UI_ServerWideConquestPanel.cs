using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.Models;
using Shift.Legion.Common.Enums.Sources;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_ServerWideConquestPanel : GComponent, IUiController
{
	private class BetSettingListData
	{
		public StageStatus StageStatus { get; set; }

		public int GroupIndex { get; set; }

		public WarGroupLottery GroupData { get; set; }
	}

	public Controller SchedulePage;

	public Controller IsMeInShortlist;

	public Controller MatchStage;

	public Controller showScoreDetail;

	public GLoader background;

	public GButton BackBtn;

	public UI_Title PanelTitle;

	public GComponent AddExchangeCoin;

	public GComponent AddBetTicket;

	public GImage Background;

	public GImage n51;

	public GImage n47;

	public GImage n48;

	public GImage n50;

	public GImage n107;

	public GImage SchedulePreviewTable;

	public UI_ServerWideSubTitle SchedulePreviewTitle;

	public GTextField StageTime1;

	public GTextField StageTime2;

	public GTextField StageTime3;

	public GTextField StageTime4;

	public GTextField StageTime5;

	public GImage n54;

	public GTextField FirstMatchCountdownTitle;

	public GTextField FirstMatchCountdownText;

	public GGroup FirstMatchCountdownGroup;

	public GImage n60;

	public GImage n64;

	public GTextField RuntimeShortlistLineTitle;

	public GTextField RuntimeShortlistLineText;

	public GImage n65;

	public GGroup RuntimeShortlistLineGroup;

	public GGroup FirstMatchInfoGroup;

	public UI_MyselfInFirstMatch MyselfInFirstMatch;

	public UI_PlayerListGroup PlayerListGroup;

	public GImage n36;

	public UI_Avatar PlayerAvatar;

	public GImage DevilRibbon;

	public GTextField MeInShortlistText;

	public GImage n40;

	public GGroup MeInShortlistGroup;

	public UI_eff_RuneCircle eff_RuneCircle;

	public UI_eff_MagicCircle eff_MagicCircle;

	public UI_dec_RuneCircleLeft eff_RuneCircleLeft;

	public UI_dec_RuneCircleRight eff_RuneCircleRight;

	public GImage n113;

	public UI_eff_Lightray02 n120;

	public GGroup FinalMatchDecoGroup;

	public GLoader FinalMatchFlagLeft;

	public GLoader FinalMatchFlagRight;

	public GGroup FinalMatchFlagGroup;

	public GList FinalMatchLoseList;

	public GImage n121;

	public UI_ServerWideSubTitle MatchStageTitle;

	public GTextField MatchStageDuration;

	public GTextField MatchExtraInfo;

	public GGroup MatchStageInfoGroup;

	public UI_btn_SetArray SetArrayBtn;

	public GGroup SetArrayBtnGroup;

	public GImage n85;

	public GTextField BetListTip1;

	public GImage n87;

	public GImage n88;

	public GGroup BetListTipGroup1;

	public GLoader n90;

	public GTextField BetListTip2;

	public GGroup BetListTipGroup2;

	public GGroup BetListTipGroup;

	public GList BetSettingList1;

	public GList BetSettingList2;

	public GList BetSettingList3;

	public GList BetSettingList4;

	public GGroup BetSettingListGroup;

	public UI_eff_LightTwinkle n130;

	public GList FinalMatchPlayerList1;

	public GList FinalMatchPlayerList2;

	public GList FinalMatchPlayerList3;

	public GGroup FinalMatchPlayerGroup;

	public UI_eff_LightRadiate n131;

	public UI_btn_BetSetting_Final FinalBetSettingBtn;

	public GImage n144;

	public UI_dec_light01 n149;

	public GImage n148;

	public UI_btn_FinalTopPlayerNo23 FinalTopPlayerNo2;

	public GTextField TotallyBingoCountTitle;

	public GTextField TotallyBingoCountText;

	public GGroup TotallyBingoCountGroup;

	public UI_BetRewardCountLabel BetRewardCountLabel;

	public GGroup FinalResultInfoGroup;

	public UI_btn_FinalTopPlayerNo23 FinalTopPlayerNo3;

	public UI_btn_FinalTopPlayerNo1 FinalTopPlayerNo1;

	public GMovieClip n153;

	public GMovieClip n154;

	public UI_PlayerLoseComboPanel PlayerLoseCombo;

	public GGroup FinalResultGroup;

	public UI_ServerWideTitle ScheduleTitle;

	public UI_btn_TurnPageLeft TurnPageLeftBtn;

	public UI_btn_TurnPageRight TurnPageRightBtn;

	public GTextField DescriptionText1;

	public GTextField DescriptionText2;

	public UI_btn_ServerWideFunction BonusInfoBtn;

	public UI_btn_ServerWideFunction PlayRulesBtn;

	public GGraph closeMask;

	public UI_ServerWidePointsDetailslog PointsDetails;

	public Transition TurnPage;

	public Transition TurnPage5To4;

	public Transition TurnPage4To5;

	public Transition TurnPageTo0;

	public Transition TurnPageFinalMatch;

	public Transition TurnPageFinalResult;

	public const string URL = "ui://82mo10n5exsyjdqg";

	public static string Name = "UI_ServerWideConquestPanel";

	private const int PlayOffsPageIndex = 5;

	private const int RankListHeight = 700;

	private const int RankListItemHeight = 130;

	private const int RankListLocatorYOffset = 40;

	private int _shortlistedRank;

	private int _shortlistedSplitterY = -1;

	private List<WarRankData> _rankDataListForStagePage;

	private Dictionary<string, int> _weekWeightConfig;

	public const string StateKeyCurStageAndPageIndex = "CurStageAndPageIndex";

	private List<StageAndPage> _stageAndPagePairs;

	private int _curStageAndPageIndex = -1;

	private bool _stageRankSettled = false;

	private static readonly List<StageStatus> StageStatusForPreStageTo128 = new List<StageStatus>
	{
		StageStatus.Round1_PreStage,
		StageStatus.Round2_PreStage
	};

	private static readonly List<StageStatus> StageStatusForStage128To64 = new List<StageStatus>
	{
		StageStatus.Round1_Stage128,
		StageStatus.Round2_Stage128
	};

	private static readonly List<StageStatus> StageStatusForStage64To32 = new List<StageStatus>
	{
		StageStatus.Round1_Stage64,
		StageStatus.Round2_Stage64
	};

	private static readonly List<StageStatus> StageStatusForStage32To16 = new List<StageStatus>
	{
		StageStatus.Round1_Stage32,
		StageStatus.Round2_Stage32
	};

	private static readonly List<StageStatus> StageStatusForStage16To8 = new List<StageStatus>
	{
		StageStatus.Round1_Stage16,
		StageStatus.Round2_Stage16
	};

	private static readonly List<StageStatus> StageStatusForStage8To4 = new List<StageStatus>
	{
		StageStatus.Round1_Stage8FirstRound,
		StageStatus.Round2_Stage8FirstRound,
		StageStatus.Round1_Stage8SecondRound,
		StageStatus.Round2_Stage8SecondRound
	};

	private static readonly List<StageStatus> StageStatusForSemiFinal = new List<StageStatus>
	{
		StageStatus.Round1_SemiFinal,
		StageStatus.Round2_SemiFinal
	};

	private static readonly List<StageStatus> StageStatusForFinal = new List<StageStatus>
	{
		StageStatus.Round1_Final,
		StageStatus.Round2_Final
	};

	private static readonly StageStatus[] Round1BetStageSequence = new StageStatus[4]
	{
		StageStatus.Round1_Stage128,
		StageStatus.Round1_Stage64,
		StageStatus.Round1_Stage32,
		StageStatus.Round1_Stage16
	};

	private static readonly StageStatus[] Round2BetStageSequence = new StageStatus[4]
	{
		StageStatus.Round2_Stage128,
		StageStatus.Round2_Stage64,
		StageStatus.Round2_Stage32,
		StageStatus.Round2_Stage16
	};

	public static string GetURL()
	{
		return "ui://82mo10n5exsyjdqg";
	}

	public static UI_ServerWideConquestPanel CreateInstance()
	{
		return (UI_ServerWideConquestPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "ServerWideConquestPanel");
	}

	public static UI_ServerWideConquestPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ServerWideConquestPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5exsyjdqg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected O, but got Unknown
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Expected O, but got Unknown
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Expected O, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected O, but got Unknown
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Expected O, but got Unknown
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Expected O, but got Unknown
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_043a: Expected O, but got Unknown
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Expected O, but got Unknown
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0466: Expected O, but got Unknown
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_047c: Expected O, but got Unknown
		//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04be: Expected O, but got Unknown
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected O, but got Unknown
		//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0500: Expected O, but got Unknown
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Expected O, but got Unknown
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Expected O, but got Unknown
		//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d9: Expected O, but got Unknown
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0605: Expected O, but got Unknown
		//IL_0611: Unknown result type (might be due to invalid IL or missing references)
		//IL_061b: Expected O, but got Unknown
		//IL_0627: Unknown result type (might be due to invalid IL or missing references)
		//IL_0631: Expected O, but got Unknown
		//IL_063d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Expected O, but got Unknown
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Expected O, but got Unknown
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_0673: Expected O, but got Unknown
		//IL_0695: Unknown result type (might be due to invalid IL or missing references)
		//IL_069f: Expected O, but got Unknown
		//IL_06ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b5: Expected O, but got Unknown
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_070a: Expected O, but got Unknown
		//IL_072c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0736: Expected O, but got Unknown
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		//IL_074c: Expected O, but got Unknown
		//IL_0758: Unknown result type (might be due to invalid IL or missing references)
		//IL_0762: Expected O, but got Unknown
		//IL_07ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b7: Expected O, but got Unknown
		//IL_07c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cd: Expected O, but got Unknown
		//IL_07d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e3: Expected O, but got Unknown
		//IL_07ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f9: Expected O, but got Unknown
		//IL_0805: Unknown result type (might be due to invalid IL or missing references)
		//IL_080f: Expected O, but got Unknown
		//IL_085a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0864: Expected O, but got Unknown
		//IL_0870: Unknown result type (might be due to invalid IL or missing references)
		//IL_087a: Expected O, but got Unknown
		//IL_0886: Unknown result type (might be due to invalid IL or missing references)
		//IL_0890: Expected O, but got Unknown
		//IL_089c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a6: Expected O, but got Unknown
		//IL_08b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bc: Expected O, but got Unknown
		//IL_08c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d2: Expected O, but got Unknown
		//IL_08de: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e8: Expected O, but got Unknown
		//IL_090a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0914: Expected O, but got Unknown
		//IL_0920: Unknown result type (might be due to invalid IL or missing references)
		//IL_092a: Expected O, but got Unknown
		//IL_0936: Unknown result type (might be due to invalid IL or missing references)
		//IL_0940: Expected O, but got Unknown
		//IL_094c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0956: Expected O, but got Unknown
		//IL_098e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0998: Expected O, but got Unknown
		//IL_09ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c4: Expected O, but got Unknown
		//IL_09e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f0: Expected O, but got Unknown
		//IL_09fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a06: Expected O, but got Unknown
		//IL_0a12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1c: Expected O, but got Unknown
		//IL_0a3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a48: Expected O, but got Unknown
		//IL_0a80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8a: Expected O, but got Unknown
		//IL_0a96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa0: Expected O, but got Unknown
		//IL_0ac2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acc: Expected O, but got Unknown
		//IL_0b1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b24: Expected O, but got Unknown
		//IL_0b30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3a: Expected O, but got Unknown
		//IL_0b72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SchedulePage = ((GComponent)this).GetController("SchedulePage");
		IsMeInShortlist = ((GComponent)this).GetController("IsMeInShortlist");
		MatchStage = ((GComponent)this).GetController("MatchStage");
		showScoreDetail = ((GComponent)this).GetController("showScoreDetail");
		background = (GLoader)((GComponent)this).GetChild("background");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		PanelTitle = (UI_Title)(object)((GComponent)this).GetChild("PanelTitle");
		AddExchangeCoin = (GComponent)((GComponent)this).GetChild("AddExchangeCoin");
		AddBetTicket = (GComponent)((GComponent)this).GetChild("AddBetTicket");
		Background = (GImage)((GComponent)this).GetChild("Background");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n107 = (GImage)((GComponent)this).GetChild("n107");
		SchedulePreviewTable = (GImage)((GComponent)this).GetChild("SchedulePreviewTable");
		SchedulePreviewTitle = (UI_ServerWideSubTitle)(object)((GComponent)this).GetChild("SchedulePreviewTitle");
		StageTime1 = (GTextField)((GComponent)this).GetChild("StageTime1");
		string id = "ui://82mo10n5exsyjdqg".Replace("ui://", "") + "-" + ((GObject)StageTime1).id;
		((GObject)StageTime1).text = LanguagesManager.GetDesc(id);
		StageTime2 = (GTextField)((GComponent)this).GetChild("StageTime2");
		string id2 = "ui://82mo10n5exsyjdqg".Replace("ui://", "") + "-" + ((GObject)StageTime2).id;
		((GObject)StageTime2).text = LanguagesManager.GetDesc(id2);
		StageTime3 = (GTextField)((GComponent)this).GetChild("StageTime3");
		string id3 = "ui://82mo10n5exsyjdqg".Replace("ui://", "") + "-" + ((GObject)StageTime3).id;
		((GObject)StageTime3).text = LanguagesManager.GetDesc(id3);
		StageTime4 = (GTextField)((GComponent)this).GetChild("StageTime4");
		string id4 = "ui://82mo10n5exsyjdqg".Replace("ui://", "") + "-" + ((GObject)StageTime4).id;
		((GObject)StageTime4).text = LanguagesManager.GetDesc(id4);
		StageTime5 = (GTextField)((GComponent)this).GetChild("StageTime5");
		string id5 = "ui://82mo10n5exsyjdqg".Replace("ui://", "") + "-" + ((GObject)StageTime5).id;
		((GObject)StageTime5).text = LanguagesManager.GetDesc(id5);
		n54 = (GImage)((GComponent)this).GetChild("n54");
		FirstMatchCountdownTitle = (GTextField)((GComponent)this).GetChild("FirstMatchCountdownTitle");
		string id6 = "ui://82mo10n5exsyjdqg".Replace("ui://", "") + "-" + ((GObject)FirstMatchCountdownTitle).id;
		((GObject)FirstMatchCountdownTitle).text = LanguagesManager.GetDesc(id6);
		FirstMatchCountdownText = (GTextField)((GComponent)this).GetChild("FirstMatchCountdownText");
		FirstMatchCountdownGroup = (GGroup)((GComponent)this).GetChild("FirstMatchCountdownGroup");
		n60 = (GImage)((GComponent)this).GetChild("n60");
		n64 = (GImage)((GComponent)this).GetChild("n64");
		RuntimeShortlistLineTitle = (GTextField)((GComponent)this).GetChild("RuntimeShortlistLineTitle");
		string id7 = "ui://82mo10n5exsyjdqg".Replace("ui://", "") + "-" + ((GObject)RuntimeShortlistLineTitle).id;
		((GObject)RuntimeShortlistLineTitle).text = LanguagesManager.GetDesc(id7);
		RuntimeShortlistLineText = (GTextField)((GComponent)this).GetChild("RuntimeShortlistLineText");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		RuntimeShortlistLineGroup = (GGroup)((GComponent)this).GetChild("RuntimeShortlistLineGroup");
		FirstMatchInfoGroup = (GGroup)((GComponent)this).GetChild("FirstMatchInfoGroup");
		MyselfInFirstMatch = (UI_MyselfInFirstMatch)(object)((GComponent)this).GetChild("MyselfInFirstMatch");
		PlayerListGroup = (UI_PlayerListGroup)(object)((GComponent)this).GetChild("PlayerListGroup");
		n36 = (GImage)((GComponent)this).GetChild("n36");
		PlayerAvatar = (UI_Avatar)(object)((GComponent)this).GetChild("PlayerAvatar");
		DevilRibbon = (GImage)((GComponent)this).GetChild("DevilRibbon");
		MeInShortlistText = (GTextField)((GComponent)this).GetChild("MeInShortlistText");
		string id8 = "ui://82mo10n5exsyjdqg".Replace("ui://", "") + "-" + ((GObject)MeInShortlistText).id;
		((GObject)MeInShortlistText).text = LanguagesManager.GetDesc(id8);
		n40 = (GImage)((GComponent)this).GetChild("n40");
		MeInShortlistGroup = (GGroup)((GComponent)this).GetChild("MeInShortlistGroup");
		eff_RuneCircle = (UI_eff_RuneCircle)(object)((GComponent)this).GetChild("eff_RuneCircle");
		eff_MagicCircle = (UI_eff_MagicCircle)(object)((GComponent)this).GetChild("eff_MagicCircle");
		eff_RuneCircleLeft = (UI_dec_RuneCircleLeft)(object)((GComponent)this).GetChild("eff_RuneCircleLeft");
		eff_RuneCircleRight = (UI_dec_RuneCircleRight)(object)((GComponent)this).GetChild("eff_RuneCircleRight");
		n113 = (GImage)((GComponent)this).GetChild("n113");
		n120 = (UI_eff_Lightray02)(object)((GComponent)this).GetChild("n120");
		FinalMatchDecoGroup = (GGroup)((GComponent)this).GetChild("FinalMatchDecoGroup");
		FinalMatchFlagLeft = (GLoader)((GComponent)this).GetChild("FinalMatchFlagLeft");
		FinalMatchFlagRight = (GLoader)((GComponent)this).GetChild("FinalMatchFlagRight");
		FinalMatchFlagGroup = (GGroup)((GComponent)this).GetChild("FinalMatchFlagGroup");
		FinalMatchLoseList = (GList)((GComponent)this).GetChild("FinalMatchLoseList");
		n121 = (GImage)((GComponent)this).GetChild("n121");
		MatchStageTitle = (UI_ServerWideSubTitle)(object)((GComponent)this).GetChild("MatchStageTitle");
		MatchStageDuration = (GTextField)((GComponent)this).GetChild("MatchStageDuration");
		MatchExtraInfo = (GTextField)((GComponent)this).GetChild("MatchExtraInfo");
		string id9 = "ui://82mo10n5exsyjdqg".Replace("ui://", "") + "-" + ((GObject)MatchExtraInfo).id;
		((GObject)MatchExtraInfo).text = LanguagesManager.GetDesc(id9);
		MatchStageInfoGroup = (GGroup)((GComponent)this).GetChild("MatchStageInfoGroup");
		SetArrayBtn = (UI_btn_SetArray)(object)((GComponent)this).GetChild("SetArrayBtn");
		SetArrayBtnGroup = (GGroup)((GComponent)this).GetChild("SetArrayBtnGroup");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		BetListTip1 = (GTextField)((GComponent)this).GetChild("BetListTip1");
		string id10 = "ui://82mo10n5exsyjdqg".Replace("ui://", "") + "-" + ((GObject)BetListTip1).id;
		((GObject)BetListTip1).text = LanguagesManager.GetDesc(id10);
		n87 = (GImage)((GComponent)this).GetChild("n87");
		n88 = (GImage)((GComponent)this).GetChild("n88");
		BetListTipGroup1 = (GGroup)((GComponent)this).GetChild("BetListTipGroup1");
		n90 = (GLoader)((GComponent)this).GetChild("n90");
		BetListTip2 = (GTextField)((GComponent)this).GetChild("BetListTip2");
		string id11 = "ui://82mo10n5exsyjdqg".Replace("ui://", "") + "-" + ((GObject)BetListTip2).id;
		((GObject)BetListTip2).text = LanguagesManager.GetDesc(id11);
		BetListTipGroup2 = (GGroup)((GComponent)this).GetChild("BetListTipGroup2");
		BetListTipGroup = (GGroup)((GComponent)this).GetChild("BetListTipGroup");
		BetSettingList1 = (GList)((GComponent)this).GetChild("BetSettingList1");
		BetSettingList2 = (GList)((GComponent)this).GetChild("BetSettingList2");
		BetSettingList3 = (GList)((GComponent)this).GetChild("BetSettingList3");
		BetSettingList4 = (GList)((GComponent)this).GetChild("BetSettingList4");
		BetSettingListGroup = (GGroup)((GComponent)this).GetChild("BetSettingListGroup");
		n130 = (UI_eff_LightTwinkle)(object)((GComponent)this).GetChild("n130");
		FinalMatchPlayerList1 = (GList)((GComponent)this).GetChild("FinalMatchPlayerList1");
		FinalMatchPlayerList2 = (GList)((GComponent)this).GetChild("FinalMatchPlayerList2");
		FinalMatchPlayerList3 = (GList)((GComponent)this).GetChild("FinalMatchPlayerList3");
		FinalMatchPlayerGroup = (GGroup)((GComponent)this).GetChild("FinalMatchPlayerGroup");
		n131 = (UI_eff_LightRadiate)(object)((GComponent)this).GetChild("n131");
		FinalBetSettingBtn = (UI_btn_BetSetting_Final)(object)((GComponent)this).GetChild("FinalBetSettingBtn");
		n144 = (GImage)((GComponent)this).GetChild("n144");
		n149 = (UI_dec_light01)(object)((GComponent)this).GetChild("n149");
		n148 = (GImage)((GComponent)this).GetChild("n148");
		FinalTopPlayerNo2 = (UI_btn_FinalTopPlayerNo23)(object)((GComponent)this).GetChild("FinalTopPlayerNo2");
		TotallyBingoCountTitle = (GTextField)((GComponent)this).GetChild("TotallyBingoCountTitle");
		TotallyBingoCountText = (GTextField)((GComponent)this).GetChild("TotallyBingoCountText");
		TotallyBingoCountGroup = (GGroup)((GComponent)this).GetChild("TotallyBingoCountGroup");
		BetRewardCountLabel = (UI_BetRewardCountLabel)(object)((GComponent)this).GetChild("BetRewardCountLabel");
		FinalResultInfoGroup = (GGroup)((GComponent)this).GetChild("FinalResultInfoGroup");
		FinalTopPlayerNo3 = (UI_btn_FinalTopPlayerNo23)(object)((GComponent)this).GetChild("FinalTopPlayerNo3");
		FinalTopPlayerNo1 = (UI_btn_FinalTopPlayerNo1)(object)((GComponent)this).GetChild("FinalTopPlayerNo1");
		n153 = (GMovieClip)((GComponent)this).GetChild("n153");
		n154 = (GMovieClip)((GComponent)this).GetChild("n154");
		PlayerLoseCombo = (UI_PlayerLoseComboPanel)(object)((GComponent)this).GetChild("PlayerLoseCombo");
		FinalResultGroup = (GGroup)((GComponent)this).GetChild("FinalResultGroup");
		ScheduleTitle = (UI_ServerWideTitle)(object)((GComponent)this).GetChild("ScheduleTitle");
		TurnPageLeftBtn = (UI_btn_TurnPageLeft)(object)((GComponent)this).GetChild("TurnPageLeftBtn");
		TurnPageRightBtn = (UI_btn_TurnPageRight)(object)((GComponent)this).GetChild("TurnPageRightBtn");
		DescriptionText1 = (GTextField)((GComponent)this).GetChild("DescriptionText1");
		DescriptionText2 = (GTextField)((GComponent)this).GetChild("DescriptionText2");
		BonusInfoBtn = (UI_btn_ServerWideFunction)(object)((GComponent)this).GetChild("BonusInfoBtn");
		PlayRulesBtn = (UI_btn_ServerWideFunction)(object)((GComponent)this).GetChild("PlayRulesBtn");
		closeMask = (GGraph)((GComponent)this).GetChild("closeMask");
		PointsDetails = (UI_ServerWidePointsDetailslog)(object)((GComponent)this).GetChild("PointsDetails");
		TurnPage = ((GComponent)this).GetTransition("TurnPage");
		TurnPage5To4 = ((GComponent)this).GetTransition("TurnPage5To4");
		TurnPage4To5 = ((GComponent)this).GetTransition("TurnPage4To5");
		TurnPageTo0 = ((GComponent)this).GetTransition("TurnPageTo0");
		TurnPageFinalMatch = ((GComponent)this).GetTransition("TurnPageFinalMatch");
		TurnPageFinalResult = ((GComponent)this).GetTransition("TurnPageFinalResult");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters != null && parameters.TryGetValue("CurStageAndPageIndex", out var value))
		{
			_curStageAndPageIndex = (int)value;
		}
		CheckBetBonus();
		RenderBetCoins();
		RenderExchangeCoins();
		if (!RankDataHelper.NeedUpdateAllServersChampionshipInfo())
		{
			SetBuildingName();
			ArrangeStaticContent();
			UpdateTurnPageSwitcher();
		}
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(RenderPageOfStage());
	}

	public void OnShow()
	{
		RefreshBetCoins();
		RefreshExchangeCoins();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected O, but got Unknown
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(End));
		((GObject)PlayerListGroup.HelpBtn).onClick.Add(new EventCallback0(PlayerListHelp));
		((GObject)PlayRulesBtn).onClick.Add(new EventCallback0(PlayRulesHelp));
		((GObject)BonusInfoBtn).onClick.Add(new EventCallback0(ShowBonusPreview));
		((GObject)SetArrayBtn.SetArrayBtn).onClick.Add(new EventCallback0(OnClickSetArray));
		BetSettingList1.onClickItem.Add(new EventCallback1(OnBetSettingListItemClick));
		BetSettingList2.onClickItem.Add(new EventCallback1(OnBetSettingListItemClick));
		BetSettingList3.onClickItem.Add(new EventCallback1(OnBetSettingListItemClick));
		BetSettingList4.onClickItem.Add(new EventCallback1(OnBetSettingListItemClick));
		((GObject)TurnPageLeftBtn).onClick.Add(new EventCallback0(TurnSchedulePageLeft));
		((GObject)TurnPageRightBtn).onClick.Add(new EventCallback0(TurnSchedulePageRight));
		((GObject)PlayerLoseCombo).onClick.Add(new EventCallback0(ToggleLosePlayersList));
		((GObject)FinalBetSettingBtn).onClick.Add(new EventCallback0(OnFinalBetSettingClick));
		((GComponent)PlayerListGroup.PlayerList).scrollPane.onScroll.Add(new EventCallback0(OnRankListScroll));
		((GObject)PlayerListGroup.PointToShortlistBtn).onClick.Add(new EventCallback0(ScrollToSplitter));
		((GObject)MyselfInFirstMatch.ScoreBtn).onClick.Add(new EventCallback0(OpenScoreDetail));
		((GObject)closeMask).onClick.Add(new EventCallback0(CloseScoreDetail));
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<string>("CLOSE_UI", OnChildPanelClose);
		SharedMessenger.AddListener("BACKUP_PANEL_EXTRA_STATE", OnBackupPanelExtraState);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		((GObject)SetArrayBtn.SetArrayBtn).onClick.Clear();
		((GObject)BackBtn).onClick.Clear();
		((GObject)PlayerListGroup.HelpBtn).onClick.Clear();
		((GObject)PlayRulesBtn).onClick.Clear();
		((GObject)BonusInfoBtn).onClick.Clear();
		BetSettingList1.onClickItem.Clear();
		BetSettingList2.onClickItem.Clear();
		BetSettingList3.onClickItem.Clear();
		BetSettingList4.onClickItem.Clear();
		((GObject)TurnPageLeftBtn).onClick.Clear();
		((GObject)TurnPageRightBtn).onClick.Clear();
		((GObject)PlayerLoseCombo).onClick.Clear();
		((GObject)FinalBetSettingBtn).onClick.Clear();
		((GObject)MyselfInFirstMatch.ScoreBtn).onClick.Clear();
		((GObject)closeMask).onClick.Clear();
		((GComponent)PlayerListGroup.PlayerList).scrollPane.onScroll.Remove(new EventCallback0(OnRankListScroll));
		((GObject)PlayerListGroup.PointToShortlistBtn).onClick.Clear();
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnChildPanelClose);
		SharedMessenger.RemoveListener("BACKUP_PANEL_EXTRA_STATE", OnBackupPanelExtraState);
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	private void OnChildPanelClose(string uiName)
	{
		if (uiName == UI_ServerWideBetSettingPanel.Name)
		{
			UpdatePlayersDataOnStage();
		}
		if (uiName == UI_SelectServerWideBattleArrayPanel.Name && ((GObject)SetArrayBtn).visible)
		{
			SetArrayBtn.IsArraySetFinished.selectedIndex = (GameManagers.Instance.UserArchiveManager.HasSavedWarOfRealmFormation() ? 1 : 0);
		}
	}

	private void OnClickSetArray()
	{
		ILRequestHelper<GetWarOfRealmFormationResponse>.Request((EventContext)null, (Func<Task<GetWarOfRealmFormationResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetWarOfRealmFormation()), (Action<GetWarOfRealmFormationResponse>)delegate(GetWarOfRealmFormationResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_SelectServerWideBattleArrayPanel.Name, new Dictionary<string, object> { { "FormationResponse", response } });
			}
		});
	}

	private async Task UpdateWarOfRealmFormationSavedFlag()
	{
		UserArchiveManager archiveMgr = GameManagers.Instance.UserArchiveManager;
		if (archiveMgr.HasSavedWarOfRealmFormation())
		{
			return;
		}
		try
		{
			GetWarOfRealmFormationResponse response = await GameController.Contexts.Service<INetworkService>().GetWarOfRealmFormation();
			if (response == null || response.ErrorCode != 0 || response.Formation == null)
			{
				return;
			}
			List<List<SoldierWithLegendItemId>> units = response.Formation.Units;
			if (units == null)
			{
				return;
			}
			for (int i = 0; i < units.Count; i++)
			{
				List<SoldierWithLegendItemId> team = units[i];
				if (team == null)
				{
					continue;
				}
				for (int j = 0; j < team.Count; j++)
				{
					string sid = team[j]?.SoldierId;
					if (!string.IsNullOrEmpty(sid) && sid != "Unlock" && sid != "Lock")
					{
						archiveMgr.SetWarOfRealmFormationSaved(saved: true);
						return;
					}
				}
			}
		}
		catch (Exception arg)
		{
			ILRuntimeDebug.LogError($"[全服争霸] 检查阵容保存标记失败: {arg}");
		}
	}

	private Dictionary<string, object> GetCurrentState()
	{
		return new Dictionary<string, object> { { "CurStageAndPageIndex", _curStageAndPageIndex } };
	}

	private void OnBackupPanelExtraState()
	{
		RankDataHelper.SetPanelExtraState(Name, GetCurrentState());
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private IEnumerator RenderPageOfStage(bool forceUpdate = false)
	{
		if (RankDataHelper.NeedUpdateAllServersChampionshipInfo() || forceUpdate)
		{
			yield return RankDataHelper.GetAllServersChampionshipInfoCoroutine();
			SetBuildingName();
			ArrangeStaticContent();
			UpdateTurnPageSwitcher();
		}
		yield return EnsureCurrentPageData();
		UpdateMatchStage();
		UpdatePlayersDataOnStage();
		RenderRankList();
		BindBetSettingListData();
		RenderPointsDetails();
	}

	private IEnumerator EnsureCurrentPageData()
	{
		StageAndPage curStageAndPage = _stageAndPagePairs[_curStageAndPageIndex];
		StageStatus status = curStageAndPage.StageStatus;
		if (curStageAndPage.Page == 5)
		{
			status = RankDataHelper.AllServersChampionshipInfo.CurrentStageStatus;
		}
		Task<LotteryInfo> lotteryGroupInfoTask = RankDataHelper.GetLotteryGroupInfo(RankDataHelper.AllServersChampionshipInfo.ActivityId, status);
		Task<MatchInfo> matchGroupInfoTask = RankDataHelper.GetMatchGroupInfo(RankDataHelper.AllServersChampionshipInfo.ActivityId, status);
		while (!lotteryGroupInfoTask.IsCompleted || !matchGroupInfoTask.IsCompleted)
		{
			yield return (object)new WaitForSeconds(0.1f);
		}
	}

	private void CheckBetBonus()
	{
		WarStageLotterySettlement warStageLotterySettlement = RankDataHelper.AllServersChampionshipInfo?.WarStageLotterySettlement;
		if (warStageLotterySettlement == null)
		{
			return;
		}
		RankDataHelper.AllServersChampionshipInfo.WarStageLotterySettlement = null;
		List<StockChangeRecord> list = RankDataHelper.AllServersChampionshipInfo?.StockChangeRecords;
		if (list != null && list.Count > 0)
		{
			GameManagers.Instance.StockController.ReadStockChangeRecords(list);
			RankDataHelper.AllServersChampionshipInfo.StockChangeRecords = null;
		}
		StageStatus stageStatus = (StageStatus)warStageLotterySettlement.StageStatus;
		if (StageStatusForFinal.Contains(stageStatus))
		{
			StageInfo stageInfo = RankDataHelper.AllServersChampionshipInfo?.GetStageInfo(stageStatus);
			if (stageInfo != null && stageInfo.IsSettled(DateTimeHelper.ServerNowTimestamp))
			{
				return;
			}
		}
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{
				"StageStatus",
				(StageStatus)warStageLotterySettlement.StageStatus
			},
			{ "WarStageLotterySettlement", warStageLotterySettlement }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_ServerWideMatchResultPanel.Name, parameters);
	}

	private void RenderBetCoins()
	{
		AddBetTicket.GetChild("num").text = "0";
		AddBetTicket.GetChild("addButton").visible = false;
		AddBetTicket.GetChild("diamond").asLoader.url = "ui://PublicResources/" + RankDataHelper.AllServerChampionshipBetCoin;
		UiHelper.NumberTextChangeGTween(0f, GameManagers.Instance.StockController.GetStock(RankDataHelper.AllServerChampionshipBetCoin), AddBetTicket.GetChild("num").asTextField, 1f, (EaseType)19);
	}

	private void RenderExchangeCoins()
	{
		AddExchangeCoin.GetChild("num").text = "0";
		AddExchangeCoin.GetChild("addButton").visible = false;
		AddExchangeCoin.GetChild("diamond").asLoader.url = "ui://PublicResources/" + RankDataHelper.AllServerChampionshipExchangeCoin;
		UiHelper.NumberTextChangeGTween(0f, GameManagers.Instance.StockController.GetStock(RankDataHelper.AllServerChampionshipExchangeCoin), AddExchangeCoin.GetChild("num").asTextField, 1f, (EaseType)19);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (itemId == RankDataHelper.AllServerChampionshipBetCoin)
		{
			RefreshBetCoins();
		}
		else if (itemId == RankDataHelper.AllServerChampionshipExchangeCoin)
		{
			RefreshExchangeCoins();
		}
	}

	private void RefreshBetCoins()
	{
		GTextField asTextField = AddBetTicket.GetChild("num").asTextField;
		int num = int.Parse(((GObject)asTextField).text);
		int stock = GameManagers.Instance.StockController.GetStock(RankDataHelper.AllServerChampionshipBetCoin);
		UiHelper.NumberTextChangeGTween(num, stock, asTextField, 1f, (EaseType)19);
	}

	private void RefreshExchangeCoins()
	{
		GTextField asTextField = AddExchangeCoin.GetChild("num").asTextField;
		int num = int.Parse(((GObject)asTextField).text);
		int stock = GameManagers.Instance.StockController.GetStock(RankDataHelper.AllServerChampionshipExchangeCoin);
		UiHelper.NumberTextChangeGTween(num, stock, asTextField, 1f, (EaseType)19);
	}

	private void BindBetSettingListData()
	{
		WarOfRealmInfo allServersChampionshipInfo = RankDataHelper.AllServersChampionshipInfo;
		if (allServersChampionshipInfo?.StageInfoList == null)
		{
			return;
		}
		StageStatus[] array;
		if (allServersChampionshipInfo.IsRoundI())
		{
			array = Round1BetStageSequence;
		}
		else
		{
			if (!allServersChampionshipInfo.IsRoundII())
			{
				ILRuntimeDebug.LogError("BindBetSettingListData: Cannot determine current round from StageInfoList");
				return;
			}
			array = Round2BetStageSequence;
		}
		GList[] array2 = (GList[])(object)new GList[4] { BetSettingList1, BetSettingList2, BetSettingList3, BetSettingList4 };
		for (int i = 0; i < array2.Length && i < array.Length; i++)
		{
			if (allServersChampionshipInfo.GetStageInfo(array[i]) != null)
			{
				BindListItemsData(array2[i], array[i]);
			}
		}
	}

	private void BindListItemsData(GList list, StageStatus stageStatus)
	{
		for (int i = 0; i < list.numItems; i++)
		{
			GObject childAt = ((GComponent)list).GetChildAt(i);
			childAt.data = new BetSettingListData
			{
				StageStatus = stageStatus,
				GroupIndex = i
			};
		}
	}

	private void OnBetSettingListItemClick(EventContext context)
	{
		object data = context.data;
		if (!(((GObject)(((data is GObject) ? data : null)?)).data is BetSettingListData { StageStatus: var stageStatus } betSettingListData))
		{
			ILRuntimeDebug.LogError("BetSettingList.data 未绑定 BetSettingListData (sender=" + ((object)context.sender)?.GetType().Name + ", data=" + context.data?.GetType().Name + ")");
			return;
		}
		string text = RankDataHelper.AllServersChampionshipInfo?.ActivityId ?? "";
		StageInfo stageInfo = RankDataHelper.AllServersChampionshipInfo?.GetCurrentStageInfo();
		if ((StageStatus?)stageStatus == (StageStatus?)stageInfo?.StageStatus && stageInfo.IsPreparing(DateTimeHelper.ServerNowTimestamp))
		{
			UI_ServerWideBetSettingPanel.Open(text, stageStatus, betSettingListData.GroupIndex);
			return;
		}
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			["ActivityId"] = text,
			["StageStatus"] = stageStatus,
			["GroupIndex"] = betSettingListData.GroupIndex
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_ServerWideBattleReportSelectPanel.Name, parameters);
	}

	private void OnFinalBetSettingClick()
	{
		StageInfo stageInfo = RankDataHelper.AllServersChampionshipInfo?.GetCurrentStageInfo();
		if (stageInfo != null)
		{
			StageStatus stageStatus = (StageStatus)stageInfo.StageStatus;
			string activityId = RankDataHelper.AllServersChampionshipInfo?.ActivityId ?? "";
			int serverNowTimestamp = DateTimeHelper.ServerNowTimestamp;
			if (stageInfo.IsPreparing(serverNowTimestamp))
			{
				UI_ServerWideBetSettingPanel.Open(activityId, stageStatus, 0);
			}
		}
	}

	private void SetBuildingName()
	{
		if (RankDataHelper.AllServersChampionshipInfo.IsRoundI())
		{
			((GObject)PanelTitle.buildingName).text = LanguagesManager.GetDesc("AllServersChampionshipRound1Title");
		}
		else
		{
			((GObject)PanelTitle.buildingName).text = LanguagesManager.GetDesc("AllServersChampionshipRound2Title");
		}
	}

	private void ArrangeStaticContent()
	{
		if (RankDataHelper.AllServersChampionshipInfo.IsRoundI())
		{
			((GObject)StageTime1).text = DateTimeHelper.Parse(RankDataHelper.AllServersChampionshipInfo.GetStageInfo(StageStatus.Round1_Stage128).BeginTime).ToString("yyyy/M/d");
			((GObject)StageTime2).text = DateTimeHelper.Parse(RankDataHelper.AllServersChampionshipInfo.GetStageInfo(StageStatus.Round1_Stage64).BeginTime).ToString("yyyy/M/d");
			((GObject)StageTime3).text = DateTimeHelper.Parse(RankDataHelper.AllServersChampionshipInfo.GetStageInfo(StageStatus.Round1_Stage32).BeginTime).ToString("yyyy/M/d");
			((GObject)StageTime4).text = DateTimeHelper.Parse(RankDataHelper.AllServersChampionshipInfo.GetStageInfo(StageStatus.Round1_Stage16).BeginTime).ToString("yyyy/M/d");
			((GObject)StageTime5).text = DateTimeHelper.Parse(RankDataHelper.AllServersChampionshipInfo.GetStageInfo(StageStatus.Round1_Stage8SecondRound).BeginTime).ToString("yyyy/M/d");
			_stageAndPagePairs = new List<StageAndPage>
			{
				new StageAndPage
				{
					Page = 0,
					StageStatus = StageStatus.Round1_PreStage
				},
				new StageAndPage
				{
					Page = 1,
					StageStatus = StageStatus.Round1_Stage128
				},
				new StageAndPage
				{
					Page = 2,
					StageStatus = StageStatus.Round1_Stage64
				},
				new StageAndPage
				{
					Page = 3,
					StageStatus = StageStatus.Round1_Stage32
				},
				new StageAndPage
				{
					Page = 4,
					StageStatus = StageStatus.Round1_Stage16
				},
				new StageAndPage
				{
					Page = 5,
					StageStatus = StageStatus.Unknown
				}
			};
		}
		else
		{
			((GObject)StageTime1).text = DateTimeHelper.Parse(RankDataHelper.AllServersChampionshipInfo.GetStageInfo(StageStatus.Round2_Stage128).BeginTime).ToString("yyyy/M/d");
			((GObject)StageTime2).text = DateTimeHelper.Parse(RankDataHelper.AllServersChampionshipInfo.GetStageInfo(StageStatus.Round2_Stage64).BeginTime).ToString("yyyy/M/d");
			((GObject)StageTime3).text = DateTimeHelper.Parse(RankDataHelper.AllServersChampionshipInfo.GetStageInfo(StageStatus.Round2_Stage32).BeginTime).ToString("yyyy/M/d");
			((GObject)StageTime4).text = DateTimeHelper.Parse(RankDataHelper.AllServersChampionshipInfo.GetStageInfo(StageStatus.Round2_Stage16).BeginTime).ToString("yyyy/M/d");
			((GObject)StageTime5).text = DateTimeHelper.Parse(RankDataHelper.AllServersChampionshipInfo.GetStageInfo(StageStatus.Round2_Stage8SecondRound).BeginTime).ToString("yyyy/M/d");
			_stageAndPagePairs = new List<StageAndPage>
			{
				new StageAndPage
				{
					Page = 0,
					StageStatus = StageStatus.Round2_PreStage
				},
				new StageAndPage
				{
					Page = 1,
					StageStatus = StageStatus.Round2_Stage128
				},
				new StageAndPage
				{
					Page = 2,
					StageStatus = StageStatus.Round2_Stage64
				},
				new StageAndPage
				{
					Page = 3,
					StageStatus = StageStatus.Round2_Stage32
				},
				new StageAndPage
				{
					Page = 4,
					StageStatus = StageStatus.Round2_Stage16
				},
				new StageAndPage
				{
					Page = 5,
					StageStatus = StageStatus.Unknown
				}
			};
		}
		if (_curStageAndPageIndex == -1)
		{
			_curStageAndPageIndex = GetCurrentMaxPageIndex();
		}
	}

	private async Task RenderRankList()
	{
		StageStatus status = _stageAndPagePairs[_curStageAndPageIndex].StageStatus;
		if (status == StageStatus.Unknown)
		{
			return;
		}
		_stageRankSettled = RankDataHelper.AllServersChampionshipInfo.GetStageInfo(status).IsSettled(DateTimeHelper.ServerNowTimestamp);
		if (!_stageRankSettled && _curStageAndPageIndex > 0)
		{
			status = _stageAndPagePairs[_curStageAndPageIndex - 1].StageStatus;
		}
		if (StageStatusForPreStageTo128.Contains(status))
		{
			if (_stageRankSettled)
			{
				_shortlistedRank = 128;
			}
			else
			{
				_shortlistedRank = int.MaxValue;
			}
		}
		else if (StageStatusForStage128To64.Contains(status))
		{
			_shortlistedRank = 64;
		}
		else if (StageStatusForStage64To32.Contains(status))
		{
			_shortlistedRank = 32;
		}
		else if (StageStatusForStage32To16.Contains(status))
		{
			_shortlistedRank = 16;
		}
		else
		{
			if (!StageStatusForStage16To8.Contains(status))
			{
				return;
			}
			_shortlistedRank = 8;
		}
		_rankDataListForStagePage = new List<WarRankData>((await RankDataHelper.GetMatchGroupInfo(RankDataHelper.AllServersChampionshipInfo.ActivityId, status))?.WarRankDataInfo?.WarRankDatas ?? new List<WarRankData>());
		if (!_stageRankSettled)
		{
			_rankDataListForStagePage = _rankDataListForStagePage.Take(_shortlistedRank).ToList();
		}
		_shortlistedSplitterY = -1;
		((GObject)PlayerListGroup.PointToShortlistBtn).visible = false;
		if (_rankDataListForStagePage.Count > _shortlistedRank)
		{
			_rankDataListForStagePage.Insert(_shortlistedRank, null);
			_shortlistedSplitterY = 130 * _shortlistedRank + 12;
			((GObject)PlayerListGroup.PointToShortlistBtn).y = 740f;
			((GObject)PlayerListGroup.PointToShortlistBtn).visible = true;
		}
		PlayerListGroup.HasData.selectedIndex = ((_rankDataListForStagePage.Count > 0) ? 1 : 0);
		PlayerListGroup.PlayerList.SetVirtual();
		PlayerListGroup.PlayerList.itemProvider = new ListItemProvider(RankProvider);
		PlayerListGroup.PlayerList.itemRenderer = new ListItemRenderer(RankRenderer);
		PlayerListGroup.PlayerList.numItems = _rankDataListForStagePage.Count;
		int now = DateTimeHelper.ServerNowTimestamp;
		WarRankData selfRankData = _rankDataListForStagePage.FirstOrDefault((WarRankData rankData) => rankData?.UserId == GameController.Contexts.gameState.user.value.UserId);
		if (selfRankData != null)
		{
			IsMeInShortlist.selectedIndex = ((_stageRankSettled && selfRankData.Rank <= _shortlistedRank) ? 1 : 0);
			((GObject)MeInShortlistText).text = string.Format(LanguagesManager.GetDesc($"Top{_shortlistedRank}Shortlisted"), _shortlistedRank);
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.SetSelfImageByWebRequestAndStorageWithoutFadeIn(Name, PlayerAvatar.HeadPortrait.PlayerIcon));
		}
		if (status == StageStatus.Round1_PreStage || status == StageStatus.Round2_PreStage)
		{
			StageInfo stageInfo = RankDataHelper.AllServersChampionshipInfo.GetStageInfo(status);
			int timeTopDisplay = stageInfo.DisplayTime - now;
			((GObject)FirstMatchCountdownText).text = ((timeTopDisplay > 0) ? UiHelper.ParseTimeChinsesDH(timeTopDisplay) : "--");
			if (_rankDataListForStagePage.Count >= 128)
			{
				((GObject)RuntimeShortlistLineText).text = $"{_rankDataListForStagePage[127].Score}";
			}
			else if (_rankDataListForStagePage.Count > 0)
			{
				((GObject)RuntimeShortlistLineText).text = $"{_rankDataListForStagePage[_rankDataListForStagePage.Count - 1].Score}";
			}
			else
			{
				((GObject)RuntimeShortlistLineText).text = "--";
			}
			((GObject)MyselfInFirstMatch.HonorTitle).visible = false;
			if (selfRankData == null)
			{
				MyselfInFirstMatch.IsMeInShortlist.selectedIndex = 0;
				MyselfInFirstMatch.HasMeScore.selectedIndex = 0;
				((GObject)MyselfInFirstMatch.RankNumber).text = "--";
				((GObject)MyselfInFirstMatch.ScoreNumber).text = "--";
			}
			else
			{
				MyselfInFirstMatch.IsMeInShortlist.selectedIndex = ((selfRankData.Rank <= _shortlistedRank) ? 1 : 0);
				MyselfInFirstMatch.HasMeScore.selectedIndex = ((selfRankData.Score > 0) ? 1 : 0);
				((GObject)MyselfInFirstMatch.RankNumber).text = ((selfRankData.Rank > 0) ? $"{selfRankData.Rank}" : "--");
				((GObject)MyselfInFirstMatch.ScoreNumber).text = ((selfRankData.Score > 0) ? $"{selfRankData.Score}" : "--");
			}
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorageWithoutFadeIn(Name, GameController.Contexts.gameState.user.value.UserId, MyselfInFirstMatch.PlayerAvatar.HeadPortrait.PlayerIcon, MyselfInFirstMatch.PlayerName));
			FGUIManager.Instance.GetUserMedal(GameController.Contexts.gameState.user.value.UserId, MyselfInFirstMatch.MedalList, MyselfInFirstMatch.HasMedal);
		}
	}

	private string RankProvider(int index)
	{
		if (index == _shortlistedRank)
		{
			return "ui://82mo10n5exsyjdqx";
		}
		return "ui://82mo10n5exsyjdqu";
	}

	private void RankRenderer(int index, GObject gObject)
	{
		if (gObject is UI_PlayerListShortlistLine uI_PlayerListShortlistLine)
		{
			((GObject)uI_PlayerListShortlistLine.ScoreTypeName).text = LanguagesManager.GetDesc($"Top{index}Shortlisted");
			return;
		}
		UI_PlayerListItem uI_PlayerListItem = gObject.asCom as UI_PlayerListItem;
		WarRankData warRankData = _rankDataListForStagePage[index];
		uI_PlayerListItem.SchedulePage.selectedIndex = SchedulePage.selectedIndex;
		uI_PlayerListItem.MatchStage.selectedIndex = ((_stageRankSettled || warRankData.Score > 0) ? 2 : 0);
		if (warRankData.UserId == GameController.Contexts.gameState.user.value.UserId)
		{
			uI_PlayerListItem.IsMe.selectedIndex = 1;
		}
		else
		{
			uI_PlayerListItem.IsMe.selectedIndex = 0;
		}
		uI_PlayerListItem.RankLevel.selectedIndex = 0;
		if (warRankData.Rank == 1)
		{
			uI_PlayerListItem.RankLevel.selectedIndex = 3;
		}
		else if (warRankData.Rank == 2)
		{
			uI_PlayerListItem.RankLevel.selectedIndex = 2;
		}
		else if (warRankData.Rank == 3)
		{
			uI_PlayerListItem.RankLevel.selectedIndex = 1;
		}
		((GObject)uI_PlayerListItem.RankNumber).text = $"{warRankData.Rank}";
		((GObject)uI_PlayerListItem.ScoreNumber).text = $"{warRankData.Score}";
		((GObject)uI_PlayerListItem.NoScoreDefault).text = "----";
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorageWithoutFadeIn(Name, warRankData.UserId, uI_PlayerListItem.PlayerAvatar.HeadPortrait.PlayerIcon, uI_PlayerListItem.PlayerName));
		FGUIManager.Instance.GetUserMedal(warRankData.UserId, uI_PlayerListItem.MedalList, uI_PlayerListItem.HasMedal);
		((GObject)uI_PlayerListItem).grayed = warRankData.Rank > _shortlistedRank;
	}

	private void OnRankListScroll()
	{
		if (((GObject)PlayerListGroup.PointToShortlistBtn).visible)
		{
			float scrollingPosY = ((GComponent)PlayerListGroup.PlayerList).scrollPane.scrollingPosY;
			float num = (float)_shortlistedSplitterY - scrollingPosY;
			if (num > 700f)
			{
				num = 700f;
			}
			else if (num < 0f)
			{
				num = 0f;
			}
			((GObject)PlayerListGroup.PointToShortlistBtn).y = 40f + num;
		}
	}

	private void ScrollToSplitter()
	{
		((GComponent)PlayerListGroup.PlayerList).scrollPane.SetPosY((float)_shortlistedSplitterY - 466.66666f, true);
	}

	private void PlayRulesHelp()
	{
		UiHelper.OpenHelpPage("全服争霸", "玩法", "全服争霸", "全服争霸玩法说明");
	}

	private void PlayerListHelp()
	{
		UiHelper.OpenHelpPage("全服争霸", "玩法", "全服争霸", "全服争霸排行榜说明");
	}

	private void ShowBonusPreview()
	{
		Dictionary<string, object> parameters = new Dictionary<string, object> { 
		{
			"BonusList",
			RankDataHelper.AllServersChampionshipInfo.LeaderboardBonus
		} };
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_ServerWideRewardPanel.Name, parameters);
	}

	private void TurnSchedulePageLeft()
	{
		if (_curStageAndPageIndex != 0)
		{
			_curStageAndPageIndex--;
			UpdateTurnPageSwitcher();
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(RenderPageOfStage());
		}
	}

	private void TurnSchedulePageRight()
	{
		int currentMaxPageIndex = GetCurrentMaxPageIndex();
		if (_curStageAndPageIndex != currentMaxPageIndex)
		{
			_curStageAndPageIndex++;
			UpdateTurnPageSwitcher();
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(RenderPageOfStage());
		}
	}

	private int GetCurrentMaxPageIndex()
	{
		int num = -1;
		StageStatus currentStageStatus = RankDataHelper.AllServersChampionshipInfo.CurrentStageStatus;
		for (int i = 0; i < _stageAndPagePairs.Count; i++)
		{
			if (_stageAndPagePairs[i].StageStatus == currentStageStatus)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			num = _stageAndPagePairs.Count - 1;
		}
		return num;
	}

	private void UpdateTurnPageSwitcher()
	{
		int currentMaxPageIndex = GetCurrentMaxPageIndex();
		if (currentMaxPageIndex == 0)
		{
			TurnPageLeftBtn.Enabled.selectedIndex = 0;
			TurnPageRightBtn.Enabled.selectedIndex = 0;
		}
		else if (_curStageAndPageIndex == 0)
		{
			TurnPageLeftBtn.Enabled.selectedIndex = 0;
			TurnPageRightBtn.Enabled.selectedIndex = 1;
		}
		else if (_curStageAndPageIndex == currentMaxPageIndex)
		{
			TurnPageLeftBtn.Enabled.selectedIndex = 1;
			TurnPageRightBtn.Enabled.selectedIndex = 0;
		}
		else
		{
			TurnPageLeftBtn.Enabled.selectedIndex = 1;
			TurnPageRightBtn.Enabled.selectedIndex = 1;
		}
	}

	private void ToggleLosePlayersList()
	{
		if (PlayerLoseCombo.Status.selectedIndex == 0)
		{
			PlayerLoseCombo.Status.selectedIndex = 1;
		}
		else
		{
			PlayerLoseCombo.Status.selectedIndex = 0;
		}
	}

	private async Task UpdatePlayersDataOnStage()
	{
		StageStatus stageStatus = _stageAndPagePairs[_curStageAndPageIndex].StageStatus;
		if (stageStatus != StageStatus.Round1_PreStage && stageStatus != StageStatus.Round2_PreStage)
		{
			if (stageStatus == StageStatus.Round1_Stage128 || stageStatus == StageStatus.Round2_Stage128)
			{
				await _loadPlayersDataByStage(stageStatus, BetSettingList1);
			}
			else if (stageStatus == StageStatus.Round1_Stage64 || stageStatus == StageStatus.Round2_Stage64)
			{
				await _loadPlayersDataByStage(stageStatus, BetSettingList2);
			}
			else if (stageStatus == StageStatus.Round1_Stage32 || stageStatus == StageStatus.Round2_Stage32)
			{
				await _loadPlayersDataByStage(stageStatus, BetSettingList3);
			}
			else if (stageStatus == StageStatus.Round1_Stage16 || stageStatus == StageStatus.Round2_Stage16)
			{
				await _loadPlayersDataByStage(stageStatus, BetSettingList4);
			}
			else
			{
				await _loadPlayersDataByStage_PlayOffs();
			}
		}
	}

	private async Task UpdateMatchStage()
	{
		StageAndPage curStageAndPage = _stageAndPagePairs[_curStageAndPageIndex];
		StageStatus status = curStageAndPage.StageStatus;
		int page = curStageAndPage.Page;
		int now = DateTimeHelper.ServerNowTimestamp;
		if (page == 5)
		{
			status = RankDataHelper.AllServersChampionshipInfo.CurrentStageStatus;
			if (status == StageStatus.Round1_SemiFinal || status == StageStatus.Round2_SemiFinal)
			{
				page = 6;
			}
			else if (status == StageStatus.Round1_Final || status == StageStatus.Round2_Final)
			{
				StageInfo currentStageInfo = RankDataHelper.AllServersChampionshipInfo.GetCurrentStageInfo();
				if ((currentStageInfo.StageStatus == 9 || currentStageInfo.StageStatus == 18) && currentStageInfo.IsSettled(DateTimeHelper.ServerNowTimestamp))
				{
					page = 8;
					BetRewardCountLabel.isTotal.selectedIndex = 1;
				}
				else
				{
					page = 7;
				}
			}
		}
		SchedulePage.selectedIndex = page;
		if (status == RankDataHelper.AllServersChampionshipInfo.CurrentStageStatus)
		{
			if (RankDataHelper.AllServersChampionshipInfo.IsStageInPrepare(status, now))
			{
				MatchStage.selectedIndex = 0;
			}
			else if (RankDataHelper.AllServersChampionshipInfo.IsStageInBattle(status, now))
			{
				MatchStage.selectedIndex = 1;
			}
			else if (RankDataHelper.AllServersChampionshipInfo.IsStageSettled(status, now))
			{
				MatchStage.selectedIndex = 2;
			}
			else
			{
				ILRuntimeDebug.LogError("MatchStage Status Error");
			}
			MatchInfo matchInfo = await RankDataHelper.GetMatchGroupInfo(RankDataHelper.AllServersChampionshipInfo.ActivityId, status);
			bool participated = false;
			if (matchInfo?.WarGroupPlayers != null)
			{
				foreach (List<int> groupPlayers in matchInfo.WarGroupPlayers.Values)
				{
					if (groupPlayers.Contains(GameController.Contexts.gameState.user.value.UserId))
					{
						participated = true;
						break;
					}
				}
			}
			((GObject)SetArrayBtn).visible = participated;
			((GObject)SetArrayBtn).grayed = MatchStage.selectedIndex == 0;
			await UpdateWarOfRealmFormationSavedFlag();
			SetArrayBtn.IsArraySetFinished.selectedIndex = (GameManagers.Instance.UserArchiveManager.HasSavedWarOfRealmFormation() ? 1 : 0);
		}
		else
		{
			MatchStage.selectedIndex = 2;
			((GObject)SetArrayBtn).visible = false;
		}
		StageInfo stageInfo = RankDataHelper.AllServersChampionshipInfo.GetStageInfo(status);
		switch (status)
		{
		case StageStatus.Round1_PreStage:
		case StageStatus.Round2_PreStage:
		{
			string startAt = DateTimeHelper.Parse(stageInfo.BeginTime).ToOffset(DateTimeHelper.TimezoneOffset).ToString("yyyy/M/d HH:mm");
			string endAt = DateTimeHelper.Parse(stageInfo.SettleTime).ToOffset(DateTimeHelper.TimezoneOffset).ToString("yyyy/M/d HH:mm");
			((GObject)DescriptionText1).text = string.Format(LanguagesManager.GetDesc("AllServersChampionshipOpenTip"), startAt + " - " + endAt);
			break;
		}
		case StageStatus.Round1_Final:
		case StageStatus.Round2_Final:
			if (RankDataHelper.AllServersChampionshipInfo.IsStageSettled(status, now))
			{
				((GObject)DescriptionText1).text = string.Format(LanguagesManager.GetDesc("AllServersChampionshipCloseTip"), DateTimeHelper.Parse(stageInfo.EndTime).ToOffset(DateTimeHelper.TimezoneOffset).ToString("yyyy/M/d HH:mm"));
				break;
			}
			((GObject)DescriptionText2).text = string.Format(LanguagesManager.GetDesc("AllServersChampionshipPrepareStageTip"), DateTimeHelper.Parse(stageInfo.SettleTime).ToOffset(DateTimeHelper.TimezoneOffset).ToString("yyyy/M/d HH:mm"));
			((GObject)DescriptionText1).text = string.Format(LanguagesManager.GetDesc("AllServersChampionshipDisplayStageTip"), DateTimeHelper.Parse(stageInfo.DisplayTime).ToOffset(DateTimeHelper.TimezoneOffset).ToString("yyyy/M/d HH:mm"));
			break;
		default:
			((GObject)DescriptionText2).text = string.Format(LanguagesManager.GetDesc("AllServersChampionshipPrepareStageTip"), DateTimeHelper.Parse(stageInfo.SettleTime).ToOffset(DateTimeHelper.TimezoneOffset).ToString("yyyy/M/d HH:mm"));
			((GObject)DescriptionText1).text = string.Format(LanguagesManager.GetDesc("AllServersChampionshipDisplayStageTip"), DateTimeHelper.Parse(stageInfo.DisplayTime).ToOffset(DateTimeHelper.TimezoneOffset).ToString("yyyy/M/d HH:mm"));
			break;
		}
	}

	private async Task _loadPlayersDataByStage(StageStatus status, GList betSettingList)
	{
		bool isLocked = RankDataHelper.AllServersChampionshipInfo.CurrentStageStatus == status && RankDataHelper.AllServersChampionshipInfo.IsStageInBattle(status, DateTimeHelper.ServerNowTimestamp);
		for (int i = 0; i < betSettingList.numItems; i++)
		{
			GComponent groupBtn = ((GComponent)betSettingList).GetChildAt(i).asCom;
			groupBtn.GetController("IsLocked").selectedIndex = (isLocked ? 1 : 0);
			((GObject)groupBtn).touchable = !isLocked;
		}
		Task<LotteryInfo> lotteryGroupInfoTask = RankDataHelper.GetLotteryGroupInfo(RankDataHelper.AllServersChampionshipInfo.ActivityId, status);
		Task<MatchInfo> matchGroupInfoTask = RankDataHelper.GetMatchGroupInfo(RankDataHelper.AllServersChampionshipInfo.ActivityId, status);
		LotteryInfo lotteryInfo = await lotteryGroupInfoTask;
		MatchInfo matchInfo = await matchGroupInfoTask;
		CheckBetBonus();
		for (int j = 0; j < betSettingList.numItems; j++)
		{
			GComponent groupBtn2 = ((GComponent)betSettingList).GetChildAt(j).asCom;
			groupBtn2.GetController("IsBingo").selectedIndex = 0;
			groupBtn2.GetController("HasBet").selectedIndex = 0;
			if (lotteryInfo.WarGroupLotteried != null && lotteryInfo.WarGroupLotteried.Count > 0)
			{
				WarGroupLottery groupData = null;
				foreach (WarGroupLottery gl in lotteryInfo.WarGroupLotteried)
				{
					if (gl.GroupIndex == j)
					{
						groupData = gl;
						break;
					}
				}
				object data = ((GObject)groupBtn2).data;
				if (data is BetSettingListData betSettingData)
				{
					betSettingData.GroupData = groupData;
				}
				if (groupData?.WarLotteries != null)
				{
					List<int> shortlistedUsers = groupData.WinUserId ?? new List<int>();
					bool isBingo = false;
					int lotteryAmount = 0;
					foreach (WarLottery lotteryData in groupData.WarLotteries)
					{
						if (shortlistedUsers.Contains(lotteryData.UserId))
						{
							isBingo = true;
						}
						lotteryAmount += lotteryData.Amount;
					}
					if (isBingo)
					{
						groupBtn2.GetController("IsBingo").selectedIndex = 1;
					}
					else if (lotteryAmount > 0)
					{
						groupBtn2.GetController("HasBet").selectedIndex = 1;
					}
				}
			}
			List<int> playerList = matchInfo.WarGroupPlayers[j];
			groupBtn2.GetController("IsMeIn").selectedIndex = (playerList.Contains(GameController.Contexts.gameState.user.value.UserId) ? 1 : 0);
		}
	}

	private StageStatus GetLatestAvailableBattleReportStage(StageStatus maxStage)
	{
		int serverNowTimestamp = DateTimeHelper.ServerNowTimestamp;
		StageStatus[] array = new StageStatus[8]
		{
			StageStatus.Round1_Final,
			StageStatus.Round1_SemiFinal,
			StageStatus.Round1_Stage8SecondRound,
			StageStatus.Round1_Stage8FirstRound,
			StageStatus.Round1_Stage16,
			StageStatus.Round1_Stage32,
			StageStatus.Round1_Stage64,
			StageStatus.Round1_Stage128
		};
		StageStatus[] array2 = new StageStatus[8]
		{
			StageStatus.Round2_Final,
			StageStatus.Round2_SemiFinal,
			StageStatus.Round2_Stage8SecondRound,
			StageStatus.Round2_Stage8FirstRound,
			StageStatus.Round2_Stage16,
			StageStatus.Round2_Stage32,
			StageStatus.Round2_Stage64,
			StageStatus.Round2_Stage128
		};
		StageStatus[] array3 = ((maxStage >= StageStatus.Round1_PreStage && maxStage <= StageStatus.Round1_Final) ? array : array2);
		StageStatus[] array4 = array3;
		foreach (StageStatus stageStatus in array4)
		{
			if (stageStatus <= maxStage)
			{
				StageInfo stageInfo = RankDataHelper.AllServersChampionshipInfo.GetStageInfo(stageStatus);
				if (stageInfo != null && serverNowTimestamp >= stageInfo.DisplayTime)
				{
					return stageStatus;
				}
			}
		}
		return StageStatus.Unknown;
	}

	private async Task _loadPlayersDataByStage_PlayOffs()
	{
		StageInfo currentStageInfo = RankDataHelper.AllServersChampionshipInfo.GetCurrentStageInfo();
		StageStatus currentStageStatus = (StageStatus)currentStageInfo.StageStatus;
		if ((currentStageStatus == StageStatus.Round1_Final || currentStageStatus == StageStatus.Round2_Final) && RankDataHelper.AllServersChampionshipInfo.IsStageSettled(currentStageStatus, DateTimeHelper.ServerNowTimestamp))
		{
			_loadPlayersDataForFinalResult(currentStageStatus);
			return;
		}
		GList winnerList = FinalMatchPlayerList1;
		int winnerPlayerUiSelectIndex = 1;
		if (currentStageStatus == StageStatus.Round1_SemiFinal || currentStageStatus == StageStatus.Round2_SemiFinal)
		{
			winnerList = FinalMatchPlayerList2;
			winnerPlayerUiSelectIndex = 2;
		}
		else if (currentStageStatus == StageStatus.Round1_Final || currentStageStatus == StageStatus.Round2_Final)
		{
			winnerList = FinalMatchPlayerList3;
			winnerPlayerUiSelectIndex = 3;
		}
		GList loserList = FinalMatchLoseList;
		Task<LotteryInfo> lotteryGroupInfoTask = RankDataHelper.GetLotteryGroupInfo(RankDataHelper.AllServersChampionshipInfo.ActivityId, currentStageStatus);
		Task<MatchInfo> matchGroupInfoTask = RankDataHelper.GetMatchGroupInfo(RankDataHelper.AllServersChampionshipInfo.ActivityId, currentStageStatus);
		LotteryInfo lotteryInfo = await lotteryGroupInfoTask;
		MatchInfo matchInfo = await matchGroupInfoTask;
		CheckBetBonus();
		bool hasBetOnChampion = false;
		if (lotteryInfo.WarGroupLotteried != null && lotteryInfo.WarGroupLotteried.Count > 0)
		{
			WarGroupLottery firstGroup = lotteryInfo.WarGroupLotteried[0];
			if (firstGroup.WarLotteries != null)
			{
				foreach (WarLottery lottery in firstGroup.WarLotteries)
				{
					if (lottery.Amount > 0)
					{
						hasBetOnChampion = true;
						break;
					}
				}
			}
		}
		FinalBetSettingBtn.HasBet.selectedIndex = (hasBetOnChampion ? 1 : 0);
		List<int> allBetsList = new List<int>();
		List<int> betWinList = new List<int>();
		new List<int>();
		if (lotteryInfo.WarGroupLotteried != null && lotteryInfo.WarGroupLotteried.Count > 0)
		{
			WarGroupLottery groupLottery = lotteryInfo.WarGroupLotteried[0];
			if (groupLottery.WarLotteries != null)
			{
				foreach (WarLottery lotteryData in groupLottery.WarLotteries)
				{
					if (lotteryData.Amount > 0)
					{
						allBetsList.Add(lotteryData.UserId);
					}
				}
			}
			if (groupLottery.WinUserId != null)
			{
				foreach (int userId in groupLottery.WinUserId)
				{
					if (allBetsList.Contains(userId))
					{
						betWinList.Add(userId);
					}
				}
			}
		}
		List<int> betLoseList = allBetsList.Except(betWinList).ToList();
		List<int> winners = new List<int>();
		List<WarRankData> losers = new List<WarRankData>();
		List<int> koList = new List<int>();
		if (matchInfo.SettlementInfoList?.FirstOrDefault().Value != null)
		{
			int totalKO = 0;
			switch (currentStageStatus)
			{
			case StageStatus.Round1_Stage8SecondRound:
			case StageStatus.Round2_Stage8SecondRound:
				totalKO = 4;
				break;
			case StageStatus.Round1_SemiFinal:
			case StageStatus.Round2_SemiFinal:
				totalKO = 2;
				break;
			}
			if (matchInfo.SettlementInfoList != null && matchInfo.SettlementInfoList.Count > 0)
			{
				koList.AddRange((from settlementInfo in matchInfo.SettlementInfoList[0].OrderByDescending((WarRankData settlementInfo) => settlementInfo.Rank).Take(totalKO)
					select settlementInfo.UserId).ToList());
			}
		}
		winners.AddRange(matchInfo.WarGroupPlayers[0].Except(koList));
		if (matchInfo.UserInTop8 != null && matchInfo.UserInTop8.Count > 0)
		{
			losers.AddRange(matchInfo.UserInTop8);
		}
		else if (matchInfo.SettlementInfoList != null && matchInfo.SettlementInfoList.Count > 0)
		{
			losers.AddRange(matchInfo.SettlementInfoList[0]);
		}
		else if (matchInfo.WarRankDataInfo?.WarRankDatas != null && matchInfo.WarRankDataInfo.WarRankDatas.Count > 0)
		{
			losers.AddRange(matchInfo.WarRankDataInfo.WarRankDatas);
		}
		losers.RemoveAll((WarRankData warRankData) => winners.Contains(warRankData.UserId));
		bool hasPrevStageBattleReport = currentStageStatus != StageStatus.Round1_Stage8FirstRound && currentStageStatus != StageStatus.Round2_Stage8FirstRound;
		StageStatus winnerMaxStage;
		if (currentStageStatus == StageStatus.Round1_Final || currentStageStatus == StageStatus.Round2_Final)
		{
			winnerMaxStage = currentStageStatus;
		}
		else
		{
			winnerMaxStage = WarOfRealmInfo.GetNextStageStatus(currentStageStatus);
		}
		StageStatus winnerReportStage = GetLatestAvailableBattleReportStage(winnerMaxStage);
		bool isRound1 = currentStageStatus >= StageStatus.Round1_PreStage && currentStageStatus <= StageStatus.Round1_Final;
		winnerList.RemoveChildrenToPool();
		foreach (int userId2 in winners)
		{
			UI_btn_PlayerBetAndReport playerBtn = winnerList.AddItemFromPool() as UI_btn_PlayerBetAndReport;
			playerBtn.Usage.selectedIndex = winnerPlayerUiSelectIndex;
			if (betWinList.Contains(userId2))
			{
				playerBtn.IsBingo.selectedIndex = 1;
			}
			if (betLoseList.Contains(userId2))
			{
				playerBtn.HasBet.selectedIndex = 1;
			}
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorageWithoutFadeIn(Name, userId2, playerBtn.PlayerAvatar.HeadPortrait.PlayerIcon, playerBtn.PlayerName));
			FGUIManager.Instance.GetUserMedal(userId2, playerBtn.MedalList, playerBtn.HasMedal);
			playerBtn.ShowMode.selectedIndex = 0;
			if (hasPrevStageBattleReport && winnerReportStage != StageStatus.Unknown)
			{
				((GObject)playerBtn.BattleReportIcon).visible = true;
				((GObject)playerBtn).onClick.Set((EventCallback0)delegate
				{
					_viewPlayerBattleReports(userId2, winnerMaxStage);
				});
			}
			else
			{
				((GObject)playerBtn.BattleReportIcon).visible = false;
			}
		}
		loserList.RemoveChildrenToPool();
		foreach (WarRankData rankData in losers)
		{
			UI_btn_PlayerLoseInFinalMatch playerBtn2 = loserList.AddItemFromPool() as UI_btn_PlayerLoseInFinalMatch;
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorageWithoutFadeIn(Name, rankData.UserId, playerBtn2.PlayerAvatar.HeadPortrait.PlayerIcon, playerBtn2.PlayerName));
			FGUIManager.Instance.GetUserNickName(rankData.UserId, playerBtn2.PlayerName);
			((GObject)playerBtn2.title).text = $"{rankData.Rank}";
			StageStatus loserMaxStage;
			if (rankData.Rank <= 2)
			{
				loserMaxStage = (isRound1 ? StageStatus.Round1_Final : StageStatus.Round2_Final);
			}
			else if (rankData.Rank <= 4)
			{
				loserMaxStage = (isRound1 ? StageStatus.Round1_SemiFinal : StageStatus.Round2_SemiFinal);
			}
			else
			{
				loserMaxStage = (isRound1 ? StageStatus.Round1_Stage8SecondRound : StageStatus.Round2_Stage8SecondRound);
			}
			StageStatus loserReportStage = GetLatestAvailableBattleReportStage(loserMaxStage);
			if (hasPrevStageBattleReport && loserReportStage != StageStatus.Unknown)
			{
				((GObject)playerBtn2.BattleReportIcon).visible = true;
				((GObject)playerBtn2).onClick.Set((EventCallback0)delegate
				{
					_viewPlayerBattleReports(rankData.UserId, loserMaxStage);
				});
			}
			else
			{
				((GObject)playerBtn2.BattleReportIcon).visible = false;
			}
		}
	}

	private async Task _loadPlayersDataForFinalResult(StageStatus status)
	{
		Task<LotteryInfo> lotteryGroupInfoTask = RankDataHelper.GetLotteryGroupInfo(RankDataHelper.AllServersChampionshipInfo.ActivityId, status);
		Task<MatchInfo> matchGroupInfoTask = RankDataHelper.GetMatchGroupInfo(RankDataHelper.AllServersChampionshipInfo.ActivityId, status);
		LotteryInfo lotteryInfo = await lotteryGroupInfoTask;
		MatchInfo matchInfo = await matchGroupInfoTask;
		CheckBetBonus();
		List<int> allBetsList = new List<int>();
		List<int> betWinList = new List<int>();
		if (lotteryInfo.WarGroupLotteried != null && lotteryInfo.WarGroupLotteried.Count > 0)
		{
			WarGroupLottery groupLottery = lotteryInfo.WarGroupLotteried[0];
			if (groupLottery.WarLotteries != null)
			{
				foreach (WarLottery lotteryData in groupLottery.WarLotteries)
				{
					if (lotteryData.Amount > 0)
					{
						allBetsList.Add(lotteryData.UserId);
					}
				}
			}
			if (groupLottery.WinUserId != null)
			{
				foreach (int userId in groupLottery.WinUserId)
				{
					if (allBetsList.Contains(userId))
					{
						betWinList.Add(userId);
					}
				}
			}
		}
		PlayerLoseCombo.list.RemoveChildrenToPool();
		foreach (WarRankData rankData in matchInfo.UserInTop8)
		{
			if (rankData.Rank <= 3)
			{
				_renderFinalTopPlayer(rankData.Rank, rankData.UserId, status);
				if (rankData.Rank == 1 && betWinList.Contains(rankData.UserId))
				{
					FinalTopPlayerNo1.IsBingo.selectedIndex = 1;
				}
				continue;
			}
			UI_btn_PlayerLoseInFinalMatch losePlayerBtn = PlayerLoseCombo.list.AddItemFromPool("ui://82mo10n5sn0gjdsw") as UI_btn_PlayerLoseInFinalMatch;
			((GObject)losePlayerBtn.title).text = $"{rankData.Rank}";
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorageWithoutFadeIn(Name, rankData.UserId, losePlayerBtn.PlayerAvatar.HeadPortrait.PlayerIcon, ((GObject)losePlayerBtn.PlayerName).asTextField));
			((GObject)losePlayerBtn).onClick.Set((EventCallback0)delegate
			{
				_viewPlayerBattleReports(rankData.UserId, status);
			});
		}
		((GObject)TotallyBingoCountTitle).text = LanguagesManager.GetDesc(RankDataHelper.AllServersChampionshipInfo.IsRoundI() ? "AllServersChampionBetWinCnt_Round1" : "AllServersChampionBetWinCnt_Round2");
		((GObject)TotallyBingoCountText).text = $"{lotteryInfo.WinUserCnt}";
		TotallyBingoCountGroup.EnsureBoundsCorrect();
		((GObject)BetRewardCountLabel.CountText).text = $"x{lotteryInfo.WinCoinCnt}";
		BetRewardCountLabel.TotallyRewardCountGroup.EnsureBoundsCorrect();
	}

	private void _renderFinalTopPlayer(int rank, int userId, StageStatus status, int groupId = 0)
	{
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected O, but got Unknown
		GComponent val;
		switch (rank)
		{
		case 1:
			val = (GComponent)(object)FinalTopPlayerNo1;
			break;
		case 2:
			val = (GComponent)(object)FinalTopPlayerNo2;
			FinalTopPlayerNo2.Rank.selectedIndex = 0;
			break;
		case 3:
			val = (GComponent)(object)FinalTopPlayerNo3;
			FinalTopPlayerNo2.Rank.selectedIndex = 1;
			break;
		default:
			ILRuntimeDebug.LogError($"_renderFinalTopPlayer do not render player for rank {rank}");
			return;
		}
		((GObject)val).data = userId;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorageWithoutFadeIn(Name, userId, ((UI_Avatar)(object)val.GetChild("PlayerAvatar")).HeadPortrait.PlayerIcon, val.GetChild("PlayerName").asTextField));
		FGUIManager.Instance.GetUserMedal(userId, val.GetChild("MedalList").asList, val.GetController("HasMedal"));
		StageStatus maxReportStage = ((rank <= 2) ? status : (status - 1));
		GObject child = val.GetChild("battleLogBtn");
		if (child != null)
		{
			child.onClick.Set((EventCallback0)delegate
			{
				_viewPlayerBattleReports(userId, maxReportStage);
			});
		}
	}

	private void _viewPlayerBattleReports(int userId, StageStatus maxStage)
	{
		string text = RankDataHelper.AllServersChampionshipInfo?.ActivityId;
		if (!string.IsNullOrEmpty(text))
		{
			StageStatus latestAvailableBattleReportStage = GetLatestAvailableBattleReportStage(maxStage);
			if (latestAvailableBattleReportStage != StageStatus.Unknown)
			{
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(TryLoadMultiStagePlayerRecords(userId, latestAvailableBattleReportStage, text));
			}
		}
	}

	private List<StageStatus> GetStagesDescendingFromLatest(StageStatus latestStage)
	{
		StageStatus[] array = new StageStatus[4]
		{
			StageStatus.Round1_Final,
			StageStatus.Round1_SemiFinal,
			StageStatus.Round1_Stage8SecondRound,
			StageStatus.Round1_Stage8FirstRound
		};
		StageStatus[] array2 = new StageStatus[4]
		{
			StageStatus.Round2_Final,
			StageStatus.Round2_SemiFinal,
			StageStatus.Round2_Stage8SecondRound,
			StageStatus.Round2_Stage8FirstRound
		};
		StageStatus[] array3 = ((latestStage >= StageStatus.Round1_PreStage && latestStage <= StageStatus.Round1_Final) ? array : array2);
		List<StageStatus> list = new List<StageStatus>();
		StageStatus[] array4 = array3;
		foreach (StageStatus stageStatus in array4)
		{
			if (stageStatus <= latestStage)
			{
				list.Add(stageStatus);
			}
		}
		return list;
	}

	private IEnumerator TryLoadMultiStagePlayerRecords(int userId, StageStatus latestStage, string activityId)
	{
		Dictionary<int, List<RankChangeRecord>> recordGroups = new Dictionary<int, List<RankChangeRecord>>();
		List<StageStatus> allStages = GetStagesDescendingFromLatest(latestStage);
		foreach (StageStatus stage in allStages)
		{
			List<RankChangeRecord> records = null;
			yield return RankDataHelper.TryLoadGroupResultFromCDN(activityId, (int)stage, 0, delegate(WarOfRealmGroupResultReport report)
			{
				if (report?.StageUserBattleRecord != null && !report.StageUserBattleRecord.TryGetValue(userId.ToString(), out records))
				{
				}
			});
			if (records != null && records.Count > 0)
			{
				recordGroups[(int)stage] = records;
			}
		}
		if (recordGroups.Count > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ServerWideBattleLogPanel.Name, new Dictionary<string, object>
			{
				{ "UserId", userId },
				{ "BattleRecordGroups", recordGroups }
			});
		}
		else
		{
			_viewPlayerBattleReportsFromAPI(userId, latestStage);
		}
	}

	private void _viewPlayerBattleReportsFromAPI(int userId, StageStatus stageStatus)
	{
		ILRequestHelper<WarOfRealmGetWarBattleRecordResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().GetWarOfRealmWarBattleRecord((int)stageStatus, userId), delegate(WarOfRealmGetWarBattleRecordResponse response)
		{
			if (response == null)
			{
				ILRuntimeDebug.LogError("获取玩家战报失败：响应为空");
				ILRequestHelper.ShowMessage("获取战报失败，请稍后重试");
			}
			else if (response.ErrorCode != 0)
			{
				ILRuntimeDebug.LogError($"获取玩家战报失败, ErrorCode={response.ErrorCode}");
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				List<RankChangeRecord> getBattleRecordsList = response.GetBattleRecordsList;
				if (getBattleRecordsList == null || getBattleRecordsList.Count == 0)
				{
					SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("PlayerHasNoBattleReplayTip") }, 121, arg3: false);
				}
				else
				{
					Dictionary<int, List<RankChangeRecord>> value = new Dictionary<int, List<RankChangeRecord>> { 
					{
						(int)stageStatus,
						getBattleRecordsList
					} };
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_ServerWideBattleLogPanel.Name, new Dictionary<string, object>
					{
						{ "UserId", userId },
						{ "BattleRecordGroups", value }
					});
				}
			}
		}, 1f);
	}

	private void OpenScoreDetail()
	{
		showScoreDetail.selectedIndex = 1;
	}

	private void CloseScoreDetail()
	{
		showScoreDetail.selectedIndex = 0;
	}

	private void RenderPointsDetails()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		_weekWeightConfig = "WarOfRealmWeekWeight".ToConfiguration<Dictionary<string, int>>();
		PointsDetails.scoreList.itemRenderer = new ListItemRenderer(RenderScoreDetailItem);
		PointsDetails.scoreList.numItems = 7;
		int num = RankDataHelper.AllServersChampionshipInfo?.ScoreHistoryTotalScore ?? 0;
		((GObject)PointsDetails.PointsNumber).text = $"{num}";
	}

	private void RenderScoreDetailItem(int index, GObject obj)
	{
		if (!(obj is UI_Pointsslot uI_Pointsslot))
		{
			return;
		}
		int num = index + 1;
		uI_Pointsslot.lineBack.selectedIndex = index % 2;
		int value;
		int num2 = ((_weekWeightConfig != null && _weekWeightConfig.TryGetValue($"{num}", out value)) ? value : 0);
		List<WeekScoreRecord> list = RankDataHelper.AllServersChampionshipInfo?.ScoreHistoryRecords;
		WeekScoreRecord weekScoreRecord = null;
		if (list != null)
		{
			foreach (WeekScoreRecord item in list)
			{
				if (item.Week == num)
				{
					weekScoreRecord = item;
					break;
				}
			}
		}
		((GObject)uI_Pointsslot.n1).text = $"{num}";
		((GObject)uI_Pointsslot.n2).text = $"{num2}";
		if (weekScoreRecord != null)
		{
			uI_Pointsslot.hasScore.selectedIndex = 1;
			((GObject)uI_Pointsslot.n3).text = $"{weekScoreRecord.TotalScore / num2}";
			((GObject)uI_Pointsslot.n4).text = $"{weekScoreRecord.TotalScore}";
		}
		else
		{
			uI_Pointsslot.hasScore.selectedIndex = 0;
			((GObject)uI_Pointsslot.n3).text = "-";
			((GObject)uI_Pointsslot.n4).text = "-";
		}
	}
}
