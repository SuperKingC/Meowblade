using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Entitas;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using GameMaths;
using GvG2;
using HotFix;
using HotFix.Base.Scripts.Chapter;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.MainCity;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common;
using Shift.Legion.Helpers;
using UI.Battle_PauseSetEffect;
using UI.EnemyIntroduction;
using UI.GameEndPanels;
using UI.Guide;
using UI.LegendItemDungeon;
using UI.Legion;
using UI.MaskCover;
using UI.Playback;
using UI.PvpSelectSoldiers;
using UI.RecruitingCamp;
using UI.Tips;
using UI.UpGrade;
using UI.WorldMap;
using UnityEngine;

namespace UI.Battle;

public class UI_Battle : GComponent, IUiController, IAnyTeamHealthPointsTotalListener, IAnyCurrentLevelBattleStartedRemovedListener, IAnyBattleTimeLeftListener, IAnyBattleFieldLengthListener, IAnyRedTeamCombatPowerListener, IAnyBlueTeamCombatPowerListener, IAnyLoadingPanelStatusListener, IAnyBattleFieldSubLevelIndexListener, IAnyBattleWaveTimeLeftListener, IAnyShowBattleWaveCountdownListener, IAnyShowBattleWaveCountdownRemovedListener, IAnyNextLevelComingListener, IAnyNextLevelComingRemovedListener, IAnyFreeBattleModeListener, IAnyOfflineBonusesListener, IAnyBattleConfigListener, IAnyCameraMoveLimitListener, IAnyCameraSizeListener, IAnyCameraAspectListener, IAnyMouseScrollDeltaListener, IAnyZoomDeltaListener
{
	private enum CampType
	{
		OurCamp,
		EnemyCamp
	}

	public class PvpEnemyInfo
	{
		public bool IsUser;

		public string NpcUrl;

		public int UserId;

		public string UserName;
	}

	public class PvpRedUserInfo
	{
		public bool IsUser;

		public string NpcUrl;

		public int UserId;

		public string UserName;
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action<SyncFormationUnitsResponse> _003C_003E9__140_1;

		public static Action<GameObject> _003C_003E9__155_0;

		public static Action<SyncFormationUnitsResponse> _003C_003E9__160_1;

		public static Action<ChangeFormationUnitResponse> _003C_003E9__177_1;

		public static Func<Task<GetRecentReplaysResponse>> _003C_003E9__180_0;

		public static Func<Task<GetTreasureHuntBattlePresetFormationResponse>> _003C_003E9__210_0;

		public static Action<RetreatResponse> _003C_003E9__211_1;

		public static Func<Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem, LegendItemBrief> _003C_003E9__228_0;

		public static Action _003C_003E9__268_5;

		public static Action _003C_003E9__268_7;

		public static PlayCompleteCallback _003C_003E9__312_0;

		internal void _003CBeforeDestroy_003Eb__140_1(SyncFormationUnitsResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
		}

		internal void _003CChangeMainCityBtnStatus_003Eb__155_0(GameObject workplaceSmoke2)
		{
			workplaceSmoke2.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
			UiAudioManager.Instance.LoadSoundsForSfx(workplaceSmoke2, "BalloonBlast");
		}

		internal void _003CChangeFormation_003Eb__160_1(SyncFormationUnitsResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
		}

		internal void _003COnCampClose_003Eb__177_1(ChangeFormationUnitResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
		}

		internal Task<GetRecentReplaysResponse> _003CGetRecentReplays_003Eb__180_0()
		{
			return GameController.Contexts.Service<INetworkService>().GetRecentReplays();
		}

		internal Task<GetTreasureHuntBattlePresetFormationResponse> _003COpenPresetFormationPanel_003Eb__210_0()
		{
			return GameController.Contexts.Service<INetworkService>().GetTreasureHuntBattlePresetFormation();
		}

		internal void _003CRetreatEvent_003Eb__211_1(RetreatResponse response)
		{
			CommandFactory.CreateRetreatCommand(GameController.Contexts);
		}

		internal LegendItemBrief _003COpenArmyGroup_003Eb__228_0(Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem _equipped)
		{
			return LegendItemBrief.Parse(_equipped);
		}

		internal void _003CStartBattleBtnClicked_003Eb__268_5()
		{
		}

		internal void _003CStartBattleBtnClicked_003Eb__268_7()
		{
		}

		internal void _003COnAnyBattleFieldSubLevelIndex_003Eb__312_0()
		{
		}
	}

	public Controller OpenFormationControll;

	public Controller ChangePageControll;

	public Controller LevelTypeController;

	public UI_MakeWar MakeWarBtn;

	public UI_btn_EnterMaincity EnterMaincity;

	public GImage titleBack;

	public GImage titleBack2;

	public GImage n107;

	public GImage n106;

	public GButton BackToCityBtn;

	public UI_ScoutBtn ScoutBtn;

	public UI_CampBtn CampBtn;

	public UI_WorldMapBtn WorldBtn;

	public UI_MissionCompletedPlayback MissionCompletedPlayback;

	public UI_MissionCompletedPlayback StrategyGuide;

	public GImage titleBack1;

	public GTextField CombatPowerName;

	public GTextField CombatPower;

	public GGraph combatArrowSfxBack;

	public GGraph CombatPowerSfxBack;

	public GGroup titleGroup;

	public GImage CurrentCardNameBackRight;

	public GTextField NextCardname;

	public GGroup nextName;

	public GImage CurrentCardNameBackLeft;

	public GTextField CurrentCardName;

	public GGroup curName;

	public UI_CampInfoWindow CampInfoWindow;

	public GGroup PreparePage;

	public GGraph BigMap;

	public UI_OurInfomationBar OurInfomationBar;

	public UI_EnemyInfomationBar EnemyInfomationBar;

	public GImage timerBack;

	public GTextField Timer;

	public GImage n99;

	public GGroup timingGroup;

	public UI_GvGCountDown GvGCountDown;

	public UI_GvGBossHpBar GvGBossHpBar;

	public UI_GvGTotalDamageNew GvGBossTotalDamage;

	public GGraph MiniMapHandle;

	public GButton BattleToCityBtn;

	public GGraph MiniMapTexture;

	public GGroup BattlePage;

	public GList offensiveProgressList;

	public UI_NextCardBtn NextCardBtn;

	public UI_ScreenshotBtn ScreenshotBtn;

	public UI_HpSwitchBtn HpSwitchBtn;

	public UI_PreCardBtn PreCardBtn;

	public UI_RestartBtn RestartBtn;

	public UI_FormationItemBtn EnemyFormationItem0;

	public UI_FormationItemBtn EnemyFormationItem1;

	public UI_FormationItemBtn EnemyFormationItem2;

	public UI_FormationItemBtn EnemyFormationItem3;

	public UI_FormationItemBtn EnemyFormationItem4;

	public UI_FormationItemBtn EnemyFormationItem5;

	public UI_FormationMask FormationMask;

	public UI_FormationBtn OpenFormationBtn;

	public GList FormationList;

	public UI_CombatAlert CombatAlert;

	public UI_ReinforceCountdown ReinforceCountdown;

	public GImage n108;

	public UI_RetreatBtn RetreatBtn;

	public UI_OpenPresetBtn OpenPresetBtn;

	public UI_CountdownBtn CountdownBtn;

	public UI_CountdownBtn PlaceSoldierLimitTip;

	public UI_ReplaceSoldierTip ReplaceSoldierTip;

	public UI_SoldierIconOnTouch SoldierIcon;

	public UI_show MeterSwitch;

	public GTextField tip;

	public UI_FullscreenEffectStage FullscreenEffectStage;

	public UI_StartBattleTipPanel StartBattleTipPanel;

	public UI_Com_StoryInfo StoryInfo;

	public Transition CombatAlertShake;

	public Transition ReinforceCountdownShake;

	public Transition CombatPowerIncrease;

	public Transition CombatPowerReduce;

	public Transition Mass;

	public Transition NameTrans;

	public const string URL = "ui://twlbabicgktvh";

	public static string Name = "UI_Battle";

	private const float BigMapRatio = 80f;

	public static UI_Battle BattlePanel;

	public static bool fadeBeforeStarting;

	private GList _gainList;

	private GList _enemyInfoList;

	private GList _rewardsList;

	private string[] _enemyIds;

	private int _currentFormationIndex;

	private List<string> _intrinsicRewardsList;

	private List<UI_FormationItemBtn> _formationItemBtns = new List<UI_FormationItemBtn>();

	private List<UI_FormationItemBtn> _EnmeyFormationItemBtns = new List<UI_FormationItemBtn>();

	private GGraph redBossBtn;

	private GameEntityData redBossData;

	private GameEntityData blueBossData;

	private Controller _formationInfoControll;

	private int _currentFormationItemIndex;

	private int _curLevelTimeLimit;

	private Coroutine _softGuideClick;

	private UI_GuideFinger _guideFinger;

	private List<string> textureList = new List<string>();

	private string OpenUIOnReturn;

	private bool WorldMapBtnVisible = true;

	private bool isForeword;

	private string curTouchBlockSid;

	private string currentFormation;

	private Vector2 formationItemInitPos;

	private Vector3 farthestNeedReplaceFormationPos = -Vector3.one * 10000f;

	private Vector2 countdownBtnInitPos;

	private bool showSoldiersNumTip;

	private bool showDispatchSoldierTip;

	private List<Formation> TotalFormations = new List<Formation>();

	private List<string> UnlockFormations = new List<string>();

	private List<float> formationVision = new List<float>();

	private bool needRefreshFormationUiOnWave = true;

	private bool hideUI;

	private CampType _currentType = CampType.OurCamp;

	private Level _level;

	private GDELevelAssistanceData _levelAssistanceConfig;

	private int clearStages;

	private int _refreshFormationButtonsNumberInfoTimer = -1;

	private bool unitChanged;

	private List<string> curUnitData = new List<string>();

	public static List<LevelBattleReplay> curStrategyGuide = new List<LevelBattleReplay>();

	private List<LevelBattleReplay> curMissionGuide = new List<LevelBattleReplay>();

	private Coroutine _Coroutine_UpdateCampBtnPos;

	public static PvpEnemyInfo pvpEnemyInfo;

	public static PvpRedUserInfo pvpRedInfo;

	private GameStateEntity _gameStateEntity;

	private ConfigEntity _configEntity;

	private GameStateEntity _replayGameStateEntity;

	private InputEntity _inputEntity;

	private bool isMouseMoving = false;

	private int _levelBattleReplayResponseCount;

	private const int LevelBattleReplayResponseLimit = 2;

	private int ReplayType = 1;

	private int _oldBorn;

	private string unlockFormationItemSoldierIdCache;

	private Tweener _tweener;

	private int enemyCombatPower;

	private Coroutine HideFormationItemBtnCoroutine;

	private Dictionary<int, Vec3> _CacheformationPos = null;

	private bool battleStartedOnCombatDataIsNull;

	private bool IsStartWarSuccess;

	private bool IsSetReplayUiType;

	private bool IsMakeWarBtnEfectPlaying;

	private bool IsWatchingEnemy;

	private static readonly List<ChapterType> dungeonInstanceChapterTypes = new List<ChapterType>
	{
		ChapterType.RepeatableInstance,
		ChapterType.RepeatableInstanceDefensive,
		ChapterType.RepeatableInstanceNeutral,
		ChapterType.RepeatableInstanceOffensive,
		ChapterType.RepeatableInstancePortal,
		ChapterType.TreasureHunt
	};

	private float _mapLength;

	private float _ratio;

	private const float _miniMapWidth = 157f;

	private float _miniMapLength;

	private ICameraService _cameraService;

	private Camera _miniMapCamera;

	private float _offsetX;

	private float _offsetZ;

	private Vector3 _cameraTempPos;

	private Vector3 _cameraMoveLimitPosition;

	private Vector3 _cameraMoveLimitSize;

	private float _cameraSize;

	private float _cameraAspect;

	private const float CameraMaxSize = 5.4f;

	private const float CameraMiniSize = 3f;

	private const float MapWidth = 10.8f;

	private RenderTexture miniMapTexture;

	private Vector2 _cur_touch;

	private Vector2 _touch_deltaPosition;

	private bool IsLive001 => _level?.LevelId == "Live001";

	private bool IsP1130 => GameController.Contexts.Service<IBattleFieldService>().Level?.LevelId == "P1130";

	private bool GvG3CommonBattle => Singleton<GvGMode3BattleRecordsManager>.Instance.RecordLevelInfo != null && _level?.LevelId == "EventislandGVG_001" && !Singleton<GvGMode3BattleRecordsManager>.Instance.RecordLevelInfo.HasBoss;

	private bool GvG3BossBattle => Singleton<GvGMode3BattleRecordsManager>.Instance.RecordLevelInfo != null && _level?.LevelId == "EventislandGVG_001" && Singleton<GvGMode3BattleRecordsManager>.Instance.RecordLevelInfo.HasBoss;

	private bool IsGvGModel2Level => GvGInstanceZone.IsComeAgainLevelId.Contains(_level?.LevelId);

	private bool IsGvGLevel => GvGConfigHelper.WorldBossLevelId.Contains(_level?.LevelId);

	public static string GetURL()
	{
		return "ui://twlbabicgktvh";
	}

	public static UI_Battle CreateInstance()
	{
		return (UI_Battle)(object)UIPackage.CreateObject("Battle", "Battle");
	}

	public static UI_Battle CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Battle).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicgktvh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
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
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Expected O, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Expected O, but got Unknown
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Expected O, but got Unknown
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Expected O, but got Unknown
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Expected O, but got Unknown
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Expected O, but got Unknown
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c9: Expected O, but got Unknown
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Expected O, but got Unknown
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Expected O, but got Unknown
		//IL_061f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0629: Expected O, but got Unknown
		//IL_0661: Unknown result type (might be due to invalid IL or missing references)
		//IL_066b: Expected O, but got Unknown
		//IL_0711: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		OpenFormationControll = ((GComponent)this).GetController("OpenFormationControll");
		ChangePageControll = ((GComponent)this).GetController("ChangePageControll");
		LevelTypeController = ((GComponent)this).GetController("LevelTypeController");
		MakeWarBtn = (UI_MakeWar)(object)((GComponent)this).GetChild("MakeWarBtn");
		EnterMaincity = (UI_btn_EnterMaincity)(object)((GComponent)this).GetChild("EnterMaincity");
		titleBack = (GImage)((GComponent)this).GetChild("titleBack");
		titleBack2 = (GImage)((GComponent)this).GetChild("titleBack2");
		n107 = (GImage)((GComponent)this).GetChild("n107");
		n106 = (GImage)((GComponent)this).GetChild("n106");
		BackToCityBtn = (GButton)((GComponent)this).GetChild("BackToCityBtn");
		ScoutBtn = (UI_ScoutBtn)(object)((GComponent)this).GetChild("ScoutBtn");
		CampBtn = (UI_CampBtn)(object)((GComponent)this).GetChild("CampBtn");
		WorldBtn = (UI_WorldMapBtn)(object)((GComponent)this).GetChild("WorldBtn");
		MissionCompletedPlayback = (UI_MissionCompletedPlayback)(object)((GComponent)this).GetChild("MissionCompletedPlayback");
		StrategyGuide = (UI_MissionCompletedPlayback)(object)((GComponent)this).GetChild("StrategyGuide");
		titleBack1 = (GImage)((GComponent)this).GetChild("titleBack1");
		CombatPowerName = (GTextField)((GComponent)this).GetChild("CombatPowerName");
		string id = "ui://twlbabicgktvh".Replace("ui://", "") + "-" + ((GObject)CombatPowerName).id;
		((GObject)CombatPowerName).text = LanguagesManager.GetDesc(id);
		CombatPower = (GTextField)((GComponent)this).GetChild("CombatPower");
		string id2 = "ui://twlbabicgktvh".Replace("ui://", "") + "-" + ((GObject)CombatPower).id;
		((GObject)CombatPower).text = LanguagesManager.GetDesc(id2);
		combatArrowSfxBack = (GGraph)((GComponent)this).GetChild("combatArrowSfxBack");
		CombatPowerSfxBack = (GGraph)((GComponent)this).GetChild("CombatPowerSfxBack");
		titleGroup = (GGroup)((GComponent)this).GetChild("titleGroup");
		CurrentCardNameBackRight = (GImage)((GComponent)this).GetChild("CurrentCardNameBackRight");
		NextCardname = (GTextField)((GComponent)this).GetChild("NextCardname");
		string id3 = "ui://twlbabicgktvh".Replace("ui://", "") + "-" + ((GObject)NextCardname).id;
		((GObject)NextCardname).text = LanguagesManager.GetDesc(id3);
		nextName = (GGroup)((GComponent)this).GetChild("nextName");
		CurrentCardNameBackLeft = (GImage)((GComponent)this).GetChild("CurrentCardNameBackLeft");
		CurrentCardName = (GTextField)((GComponent)this).GetChild("CurrentCardName");
		string id4 = "ui://twlbabicgktvh".Replace("ui://", "") + "-" + ((GObject)CurrentCardName).id;
		((GObject)CurrentCardName).text = LanguagesManager.GetDesc(id4);
		curName = (GGroup)((GComponent)this).GetChild("curName");
		CampInfoWindow = (UI_CampInfoWindow)(object)((GComponent)this).GetChild("CampInfoWindow");
		PreparePage = (GGroup)((GComponent)this).GetChild("PreparePage");
		BigMap = (GGraph)((GComponent)this).GetChild("BigMap");
		OurInfomationBar = (UI_OurInfomationBar)(object)((GComponent)this).GetChild("OurInfomationBar");
		EnemyInfomationBar = (UI_EnemyInfomationBar)(object)((GComponent)this).GetChild("EnemyInfomationBar");
		timerBack = (GImage)((GComponent)this).GetChild("timerBack");
		Timer = (GTextField)((GComponent)this).GetChild("Timer");
		string id5 = "ui://twlbabicgktvh".Replace("ui://", "") + "-" + ((GObject)Timer).id;
		((GObject)Timer).text = LanguagesManager.GetDesc(id5);
		n99 = (GImage)((GComponent)this).GetChild("n99");
		timingGroup = (GGroup)((GComponent)this).GetChild("timingGroup");
		GvGCountDown = (UI_GvGCountDown)(object)((GComponent)this).GetChild("GvGCountDown");
		GvGBossHpBar = (UI_GvGBossHpBar)(object)((GComponent)this).GetChild("GvGBossHpBar");
		GvGBossTotalDamage = (UI_GvGTotalDamageNew)(object)((GComponent)this).GetChild("GvGBossTotalDamage");
		MiniMapHandle = (GGraph)((GComponent)this).GetChild("MiniMapHandle");
		BattleToCityBtn = (GButton)((GComponent)this).GetChild("BattleToCityBtn");
		MiniMapTexture = (GGraph)((GComponent)this).GetChild("MiniMapTexture");
		BattlePage = (GGroup)((GComponent)this).GetChild("BattlePage");
		offensiveProgressList = (GList)((GComponent)this).GetChild("offensiveProgressList");
		NextCardBtn = (UI_NextCardBtn)(object)((GComponent)this).GetChild("NextCardBtn");
		ScreenshotBtn = (UI_ScreenshotBtn)(object)((GComponent)this).GetChild("ScreenshotBtn");
		HpSwitchBtn = (UI_HpSwitchBtn)(object)((GComponent)this).GetChild("HpSwitchBtn");
		PreCardBtn = (UI_PreCardBtn)(object)((GComponent)this).GetChild("PreCardBtn");
		RestartBtn = (UI_RestartBtn)(object)((GComponent)this).GetChild("RestartBtn");
		EnemyFormationItem0 = (UI_FormationItemBtn)(object)((GComponent)this).GetChild("EnemyFormationItem0");
		EnemyFormationItem1 = (UI_FormationItemBtn)(object)((GComponent)this).GetChild("EnemyFormationItem1");
		EnemyFormationItem2 = (UI_FormationItemBtn)(object)((GComponent)this).GetChild("EnemyFormationItem2");
		EnemyFormationItem3 = (UI_FormationItemBtn)(object)((GComponent)this).GetChild("EnemyFormationItem3");
		EnemyFormationItem4 = (UI_FormationItemBtn)(object)((GComponent)this).GetChild("EnemyFormationItem4");
		EnemyFormationItem5 = (UI_FormationItemBtn)(object)((GComponent)this).GetChild("EnemyFormationItem5");
		FormationMask = (UI_FormationMask)(object)((GComponent)this).GetChild("FormationMask");
		OpenFormationBtn = (UI_FormationBtn)(object)((GComponent)this).GetChild("OpenFormationBtn");
		FormationList = (GList)((GComponent)this).GetChild("FormationList");
		CombatAlert = (UI_CombatAlert)(object)((GComponent)this).GetChild("CombatAlert");
		ReinforceCountdown = (UI_ReinforceCountdown)(object)((GComponent)this).GetChild("ReinforceCountdown");
		n108 = (GImage)((GComponent)this).GetChild("n108");
		RetreatBtn = (UI_RetreatBtn)(object)((GComponent)this).GetChild("RetreatBtn");
		OpenPresetBtn = (UI_OpenPresetBtn)(object)((GComponent)this).GetChild("OpenPresetBtn");
		CountdownBtn = (UI_CountdownBtn)(object)((GComponent)this).GetChild("CountdownBtn");
		PlaceSoldierLimitTip = (UI_CountdownBtn)(object)((GComponent)this).GetChild("PlaceSoldierLimitTip");
		ReplaceSoldierTip = (UI_ReplaceSoldierTip)(object)((GComponent)this).GetChild("ReplaceSoldierTip");
		SoldierIcon = (UI_SoldierIconOnTouch)(object)((GComponent)this).GetChild("SoldierIcon");
		MeterSwitch = (UI_show)(object)((GComponent)this).GetChild("MeterSwitch");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id6 = "ui://twlbabicgktvh".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id6);
		FullscreenEffectStage = (UI_FullscreenEffectStage)(object)((GComponent)this).GetChild("FullscreenEffectStage");
		StartBattleTipPanel = (UI_StartBattleTipPanel)(object)((GComponent)this).GetChild("StartBattleTipPanel");
		StoryInfo = (UI_Com_StoryInfo)(object)((GComponent)this).GetChild("StoryInfo");
		CombatAlertShake = ((GComponent)this).GetTransition("CombatAlertShake");
		ReinforceCountdownShake = ((GComponent)this).GetTransition("ReinforceCountdownShake");
		CombatPowerIncrease = ((GComponent)this).GetTransition("CombatPowerIncrease");
		CombatPowerReduce = ((GComponent)this).GetTransition("CombatPowerReduce");
		Mass = ((GComponent)this).GetTransition("Mass");
		NameTrans = ((GComponent)this).GetTransition("NameTrans");
	}

	public void OnBigMapTouchBegin(EventContext context)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		_cur_touch = context.inputEvent.position;
		context.CaptureTouch();
	}

	public void OnBigMapTouchMove(EventContext context)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		_touch_deltaPosition = context.inputEvent.position - _cur_touch;
		_cur_touch = context.inputEvent.position;
		_cameraTempPos = Vector3.op_Implicit(_cameraService.Position);
		CameraMove(_cameraTempPos.x - _touch_deltaPosition.x / 80f, _cameraTempPos.z - _touch_deltaPosition.y / 80f);
	}

	public void BeforeDestroy()
	{
		Tweener tweener = _tweener;
		if (tweener != null)
		{
			TweenExtensions.Kill((Tween)(object)tweener, false);
		}
		_tweener = null;
		TimerEntity entityWithId = GameController.Contexts.timer.GetEntityWithId(_refreshFormationButtonsNumberInfoTimer);
		if (entityWithId != null && ((Entity)entityWithId).isEnabled)
		{
			((Entity)entityWithId).Destroy();
		}
		Activity levelActivity = GameManagers.Instance.ActivityManager.GetLevelActivity(_level);
		string context = ((levelActivity == null) ? _level.FormationContext : levelActivity.FormationTag);
		string subContext = _level.BattleMode.ToString();
		List<string> formationUnits = new List<string>(GameManagers.Instance.UserArchiveManager.GetBattleFormation(context, _level.BattleMode.ToString()).Values);
		ChangeFormationUnitsOnNewGuideMode4Live001(formationUnits);
		ILRequestHelper<SyncFormationUnitsResponse>.Request((EventContext)null, (Func<Task<SyncFormationUnitsResponse>>)(() => GameController.Contexts.Service<INetworkService>().SyncFormationUnits(-1L, context, subContext, formationUnits)), (Action<SyncFormationUnitsResponse>)delegate(SyncFormationUnitsResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
		});
	}

	public void Destroy()
	{
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("Battle.StartBtn", MakeWarBtn);
		instance.Unregister("Battle.EnterMainCity", EnterMaincity);
		instance.Unregister("Battle.FormationBtn", OpenFormationBtn);
		instance.Unregister("Battle.ScoutBtn", ScoutBtn);
		instance.Unregister("Battle.BackToPrepareBtn", ScoutBtn);
		instance.Unregister("Battle.BackToMainCityBtn", BackToCityBtn);
		instance.Unregister("Battle.MissionCompletedPlayback", MissionCompletedPlayback);
		if (instance.TagDicts.TryGetValue("Battle.Formations", out var value))
		{
			foreach (object item in value)
			{
				Dictionary<string, object> dictionary = (Dictionary<string, object>)item;
				dictionary.Clear();
			}
			value.Clear();
		}
		instance.Unregister("Battle.Formations");
		instance.Unregister("Battle.UnlockFormation", OpenFormationBtn.UnlockBtn);
		object obj = instance.FindObjectByTag("Battle.ArmyGroup1");
		if (obj != null)
		{
			instance.Unregister("Battle.ArmyGroup1", obj);
		}
		object obj2 = instance.FindObjectByTag("Battle.ArmyGroup2");
		if (obj2 != null)
		{
			instance.Unregister("Battle.ArmyGroup2", obj2);
		}
		object obj3 = instance.FindObjectByTag("Battle.ArmyGroup3");
		if (obj3 != null)
		{
			instance.Unregister("Battle.ArmyGroup3", obj3);
		}
		object obj4 = instance.FindObjectByTag("Battle.ArmyGroup4");
		if (obj4 != null)
		{
			instance.Unregister("Battle.ArmyGroup4", obj4);
		}
		object obj5 = instance.FindObjectByTag("Battle.ArmyGroup5");
		if (obj5 != null)
		{
			instance.Unregister("Battle.ArmyGroup5", obj5);
		}
		object obj6 = instance.FindObjectByTag("Battle.EnemyGroup1");
		if (obj6 != null)
		{
			instance.Unregister("Battle.EnemyGroup1", obj6);
		}
		object obj7 = instance.FindObjectByTag("Battle.EnemyGroup2");
		if (obj7 != null)
		{
			instance.Unregister("Battle.EnemyGroup2", obj7);
		}
		object obj8 = instance.FindObjectByTag("Battle.EnemyGroup3");
		if (obj8 != null)
		{
			instance.Unregister("Battle.EnemyGroup3", obj8);
		}
		object obj9 = instance.FindObjectByTag("Battle.EnemyGroup4");
		if (obj9 != null)
		{
			instance.Unregister("Battle.EnemyGroup4", obj9);
		}
		object obj10 = instance.FindObjectByTag("Battle.EnemyGroup5");
		if (obj10 != null)
		{
			instance.Unregister("Battle.EnemyGroup5", obj10);
		}
		GameController.Contexts.gameState.isBattleStarted = false;
		FGUIManager.Instance.CloseIEnumerator(_Coroutine_UpdateCampBtnPos);
		BattlePanel = null;
		miniMapTexture.Release();
		miniMapTexture = null;
		_miniMapCamera.targetTexture.Release();
		_miniMapCamera.targetTexture = null;
		((Behaviour)_miniMapCamera).enabled = false;
		((GObject)MiniMapTexture).displayObject.Dispose();
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
		FormationList.onClickItem.Remove(new EventCallback1(OnFormationChange));
		foreach (UI_FormationItemBtn formationItemBtn in _formationItemBtns)
		{
			((GObject)formationItemBtn).Dispose();
		}
		_formationItemBtns.Clear();
		foreach (UI_FormationItemBtn enmeyFormationItemBtn in _EnmeyFormationItemBtns)
		{
			((GObject)enmeyFormationItemBtn).Dispose();
		}
		_EnmeyFormationItemBtns.Clear();
		GGraph obj11 = redBossBtn;
		if (obj11 != null)
		{
			((GObject)obj11).Dispose();
		}
		_Coroutine_UpdateCampBtnPos = null;
		((GObject)StartBattleTipPanel.Dialog.Confirm).onClick.Clear();
		((GObject)StartBattleTipPanel.Dialog.GoToRecruit).onClick.Clear();
		((GObject)StartBattleTipPanel.Dialog.CloseBtn).onClick.Clear();
		GameController.Contexts.Service<IUiService>().ClosePanel(UI_Battle_PauseSetEffect.Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		isMouseMoving = false;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		FullscreenEffectStage.InitSeasonBuff();
		BattlePanel = this;
		_formationInfoControll = OpenFormationBtn.Content.controll;
		((GObject)FormationMask.mask.tip).text = LanguagesManager.GetDesc("CsharpCodeZhTcText99") + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText100");
		InitData(parameters);
		InitMap();
		SetScoutBtnVisible(!GameManagers.Instance.UserArchiveManager.IsNewGuideMode() || (!(_level.LevelId == "P001") && !(_level.LevelId == "P002")));
		_refreshFormationButtonsNumberInfoTimer = ScriptApi.CreateTimer(GameController.Contexts, 1f, RefreshFormationButtonsNumberInfo, -1);
		if (RankDataHelper.IsPvPLevel(_level.LevelId))
		{
			((GObject)OurInfomationBar).visible = false;
			((GObject)EnemyInfomationBar).visible = false;
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvPBattleResultAnimationEffect.Name, null);
		}
	}

	private void SetBattleUiUserInfo()
	{
		if (RankDataHelper.IsPvPLevel(_level?.LevelId) && pvpRedInfo != null)
		{
			if (pvpRedInfo.IsUser)
			{
				OurInfomationBar.Avatar.Type.selectedIndex = 0;
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, pvpRedInfo.UserId, OurInfomationBar.Avatar.Iconloader, OurInfomationBar.ArmyGroupName));
				FGUIManager.Instance.GetUserMedal(pvpRedInfo.UserId, OurInfomationBar.n8);
			}
			else
			{
				OurInfomationBar.Avatar.Type.selectedIndex = 1;
				OurInfomationBar.Avatar.Iconloader.url = pvpRedInfo.NpcUrl;
				((GObject)OurInfomationBar.ArmyGroupName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText51");
			}
			return;
		}
		if ((IsGvGLevel || GvG3BossBattle || GvG3CommonBattle) && pvpRedInfo != null)
		{
			if (pvpRedInfo.IsUser)
			{
				OurInfomationBar.Avatar.Type.selectedIndex = 0;
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, pvpRedInfo.UserId, OurInfomationBar.Avatar.Iconloader, OurInfomationBar.ArmyGroupName));
				FGUIManager.Instance.GetUserMedal(pvpRedInfo.UserId, OurInfomationBar.n8);
			}
			else
			{
				OurInfomationBar.Avatar.Type.selectedIndex = 1;
				((GObject)OurInfomationBar.ArmyGroupName).text = pvpRedInfo.UserName;
				OurInfomationBar.Avatar.Iconloader.url = pvpRedInfo.NpcUrl;
			}
			return;
		}
		if (IsGvGModel2Level && pvpRedInfo != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, pvpRedInfo.UserId, OurInfomationBar.Avatar.Iconloader, OurInfomationBar.ArmyGroupName));
			FGUIManager.Instance.GetUserMedal(pvpRedInfo.UserId, OurInfomationBar.n8);
			return;
		}
		string lastReplayUserName = GameLocalDataManager.GetLastReplayUserName();
		if (string.IsNullOrWhiteSpace(lastReplayUserName) || GameLocalDataManager.GetLastReplayUserId() == GameController.Contexts.gameState.user.value.UserId)
		{
			OurInfomationBar.Avatar.Type.selectedIndex = 0;
			int userId = GameController.Contexts.gameState.user.value.UserId;
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, userId, OurInfomationBar.Avatar.Iconloader, OurInfomationBar.ArmyGroupName));
			FGUIManager.Instance.GetUserMedal(userId, OurInfomationBar.n8);
		}
		else
		{
			OurInfomationBar.Avatar.Type.selectedIndex = 0;
			int lastReplayUserId = GameLocalDataManager.GetLastReplayUserId();
			FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, lastReplayUserId, OurInfomationBar.Avatar.Iconloader, OurInfomationBar.ArmyGroupName));
			FGUIManager.Instance.GetUserMedal(lastReplayUserId, OurInfomationBar.n8);
		}
	}

	private void CheckNameAndAvatarData()
	{
		if (!RankDataHelper.IsPvPLevel(_level?.LevelId) && !IsGvGLevel && !IsGvGModel2Level && !GvG3CommonBattle && !GvG3BossBattle)
		{
			pvpRedInfo = null;
			pvpEnemyInfo = null;
		}
	}

	private void PlayBack()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			{
				"SortingOrder",
				((GObject)this).sortingOrder + 1
			},
			{ "Type", 1 }
		};
		ChapterType type = _level.Chapter.Type;
		if (type == ChapterType.StoryMain)
		{
			dictionary.Add("BattleResult", 1);
			dictionary.Add("BattleStats", ReplayDownloadManager.LoadBattleResultFromCache(GameController.Contexts.gameState.replayBattleId.value));
		}
		else if (type == ChapterType.RepeatableInstance || type == ChapterType.RepeatableInstanceOffensive || type == ChapterType.RepeatableInstanceDefensive || type == ChapterType.RepeatableInstanceNeutral || type == ChapterType.RepeatableInstancePortal)
		{
			dictionary.Add("BattleResult", QuickPlayReplayService.info.result);
			dictionary.Add("BattleStats", QuickPlayReplayService.BattleResultStats);
			dictionary.Add("ReturnMainCity", true);
		}
		else if (IsGvGLevel)
		{
			dictionary.Add("BattleResult", GvGConfigHelper.RecordLevelInfo.Result);
			dictionary.Add("BattleStats", GvGConfigHelper.RecordLevelInfo.BattleResultStats);
			dictionary.Add("IsGvGReplay", true);
		}
		else if (IsGvGModel2Level)
		{
			dictionary.Add("BattleResult", Singleton<GvGInstanceZone>.Instance.RecordLevelInfo.Result);
			dictionary.Add("BattleStats", Singleton<GvGInstanceZone>.Instance.RecordLevelInfo.BattleResultStats);
			dictionary.Add("IsIslandComeAgain", true);
		}
		else if (GvG3CommonBattle || GvG3BossBattle)
		{
			dictionary.Add("BattleResult", Singleton<GvGMode3BattleRecordsManager>.Instance.RecordLevelInfo.Result);
			dictionary.Add("BattleStats", Singleton<GvGMode3BattleRecordsManager>.Instance.RecordLevelInfo.BattleResultStats);
			dictionary.Add("GvGMode3Replay", true);
			dictionary.Add("RedDetails", Singleton<GvGMode3BattleRecordsManager>.Instance.RecordLevelInfo.RedDetails);
			dictionary.Add("BlueDetails", Singleton<GvGMode3BattleRecordsManager>.Instance.RecordLevelInfo.BlueDetails);
		}
		else if (RankDataHelper.IsPvPLevel(_level.LevelId))
		{
			TryAddRankBattleParams(dictionary);
		}
		else if (RankDataHelper.info != null)
		{
			TryAddRankBattleParams(dictionary);
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_DamageMeter.Name, dictionary);
	}

	private void TryAddRankBattleParams(Dictionary<string, object> parameter)
	{
		if (RankDataHelper.info == null)
		{
			ILRuntimeDebug.LogError("TryAddRankBattleParams: RankDataHelper.info is null");
			return;
		}
		if (RankDataHelper.info.BattleResultStats.Count > 0)
		{
			parameter.Add("BattleResult", RankDataHelper.info.Result);
			parameter.Add("BattleStats", RankDataHelper.info.BattleResultStats);
			parameter.Add("isRankBattle", true);
			parameter.Add("BattleId", RankDataHelper.info.BattleId);
			return;
		}
		Dictionary<Team, BattleResultStats> dictionary = null;
		try
		{
			dictionary = ReplayDownloadManager.LoadBattleResultFromCache(RankDataHelper.info.BattleId);
		}
		catch (Exception ex)
		{
			ILRuntimeDebug.LogError("TryAddRankBattleParams: LoadBattleResultFromCache failed for BattleId=" + RankDataHelper.info.BattleId + ", error=" + ex.Message);
		}
		if (dictionary == null || dictionary.Count == 0)
		{
			dictionary = new Dictionary<Team, BattleResultStats>();
		}
		parameter.Add("BattleResult", RankDataHelper.info.Result);
		parameter.Add("BattleStats", dictionary);
		parameter.Add("isRankBattle", true);
		parameter.Add("BattleId", RankDataHelper.info.BattleId);
	}

	private void SetBattleUiType()
	{
		try
		{
			if (GameController.Contexts.gameState == null || GameController.Contexts.gameState.replayModeEntity == null)
			{
				return;
			}
			switch (GameController.Contexts.gameState.replayMode.value)
			{
			case 2:
				ChangePageControll.selectedIndex = 1;
				((GObject)this).alpha = 0f;
				((GObject)this).touchable = false;
				((GObject)this).visible = false;
				break;
			case 3:
				PlayBack();
				SetReplayUiType();
				SetRetreatBtnVisible(isVisible: false);
				((GObject)offensiveProgressList).TweenMoveY(((GObject)offensiveProgressList).y - 150f, 0.33f);
				foreach (KeyValuePair<int, GameObject> formationMark in FGUIManager.Instance.formationMarks)
				{
					formationMark.Value.SetActive(false);
				}
				_formationItemBtns.Clear();
				((GObject)OpenFormationBtn).visible = false;
				SharedMessenger.Broadcast("ENTER_REPLAY_LEVEL");
				break;
			default:
				if (fadeBeforeStarting)
				{
					ChangePageControll.selectedIndex = 1;
					((GObject)this).alpha = 0f;
				}
				break;
			}
			fadeBeforeStarting = false;
		}
		catch (Exception ex)
		{
			ILRuntimeDebug.LogError(ex.Message);
		}
	}

	private void LevelAssistance_SetOpenFormationBtn()
	{
		string key = "LevelAssistance_" + _level.LevelId;
		if (!GDMgr.Has<GDELevelAssistanceData>(key) || !GDMgr.Get<GDELevelAssistanceData>(key).EnableAssistance)
		{
			return;
		}
		if ((GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode2() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode2()) && _level.ChapterId == "C10000")
		{
			if (_level.LevelId == "P0001")
			{
				((GObject)OpenFormationBtn).visible = false;
			}
			else
			{
				((GObject)OpenFormationBtn).visible = true;
			}
		}
		else if ((GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode3()) && _level.ChapterId == "C10001")
		{
			((GObject)OpenFormationBtn).visible = true;
		}
		else if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
		{
			((GObject)OpenFormationBtn).visible = false;
		}
	}

	private void OpenLastReplayList()
	{
		if (ChangePageControll.selectedIndex == 0)
		{
			switch (GameLocalDataManager.GetLastOpenReplayList())
			{
			case 1:
				((GObject)MissionCompletedPlayback).onClick.Call();
				break;
			case 2:
				_currentType = CampType.EnemyCamp;
				SetCameraInEnemyPos();
				((GObject)StrategyGuide).onClick.Call();
				break;
			}
		}
	}

	public void OnShow()
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		GameStateContext gameState = GameController.Contexts.gameState;
		OnAnyCameraSize(null, gameState.cameraSize.value);
		OnAnyCameraAspect(null, gameState.cameraAspect.value);
		if (gameState.hasCameraMoveLimit)
		{
			OnAnyCameraMoveLimit(null, gameState.cameraMoveLimit.position, gameState.cameraMoveLimit.size);
		}
		if (!GameController.Contexts.gameState.isBattleStarted)
		{
			OnAnyCurrentLevelBattleStartedRemoved(null);
		}
		CheckNameAndAvatarData();
		SetBattleUiUserInfo();
		Level level = GameController.Contexts.Service<IBattleFieldService>().Level;
		if (level != null)
		{
			SetCurLevelEnemyIcon(level);
		}
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("Battle.StartBtn", MakeWarBtn);
		instance.Register("Battle.EnterMainCity", EnterMaincity);
		instance.Register("Battle.FormationBtn", OpenFormationBtn);
		instance.Register("Battle.ScoutBtn", ScoutBtn);
		instance.Register("Battle.BackToPrepareBtn", ScoutBtn);
		instance.Register("Battle.BackToMainCityBtn", BackToCityBtn);
		instance.Register("Battle.MissionCompletedPlayback", MissionCompletedPlayback);
		instance.Register("Battle.UnlockFormation", OpenFormationBtn.UnlockBtn);
		if (_formationItemBtns.Count > 0)
		{
			instance.Register("Battle.ArmyGroup1", _formationItemBtns[0]);
		}
		if (_formationItemBtns.Count > 1)
		{
			instance.Register("Battle.ArmyGroup2", _formationItemBtns[1]);
		}
		if (_formationItemBtns.Count > 2)
		{
			instance.Register("Battle.ArmyGroup3", _formationItemBtns[2]);
		}
		if (_formationItemBtns.Count > 3)
		{
			instance.Register("Battle.ArmyGroup4", _formationItemBtns[3]);
		}
		if (_formationItemBtns.Count > 4)
		{
			instance.Register("Battle.ArmyGroup5", _formationItemBtns[4]);
		}
		if (_EnmeyFormationItemBtns.Count > 0)
		{
			instance.Register("Battle.EnemyGroup1", _EnmeyFormationItemBtns[0]);
		}
		if (_EnmeyFormationItemBtns.Count > 1)
		{
			instance.Register("Battle.EnemyGroup2", _EnmeyFormationItemBtns[1]);
		}
		if (_EnmeyFormationItemBtns.Count > 2)
		{
			instance.Register("Battle.EnemyGroup3", _EnmeyFormationItemBtns[2]);
		}
		if (_EnmeyFormationItemBtns.Count > 3)
		{
			instance.Register("Battle.EnemyGroup4", _EnmeyFormationItemBtns[3]);
		}
		if (_EnmeyFormationItemBtns.Count > 4)
		{
			instance.Register("Battle.EnemyGroup5", _EnmeyFormationItemBtns[4]);
		}
		ShowAnim();
		bool visible = SetOpenFormationBtnStatus();
		((GObject)OpenFormationBtn.n40).visible = false;
		if (_level.BattleMode == BattleMode.MultiWaveAttackMode)
		{
			UnpdateOffensiveProgress(isEnd: false, 0);
			GList obj = offensiveProgressList;
			((GObject)obj).y = ((GObject)obj).y + 150f;
		}
		((GObject)FormationList).visible = visible;
		((GObject)CampBtn).visible = !IsP1130;
		for (int i = 0; i < _formationItemBtns.Count; i++)
		{
			((GObject)_formationItemBtns[i]).visible = false;
		}
		ChangePageControll.selectedIndex = (IsLive001 ? 2 : 0);
		FGUIManager.Instance.ShowNewOfflineBonuses();
		SetBattleUiType();
		InitMakeWarBtn();
		LevelAssistance_SetOpenFormationBtn();
		if (_level != null)
		{
			SharedMessenger.Broadcast("ENTER_STORY_MAIN_LEVEL", _level.LevelId);
		}
	}

	private void ShowAnim()
	{
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(ShowFadeInAnim());
	}

	private IEnumerator ShowFadeInAnim()
	{
		while (GameController.Contexts.gameState.hasLoadingPanelStatus && GameController.Contexts.gameState.loadingPanelStatus.value != LoadingPanelStatus.Closed)
		{
			yield return null;
		}
		bool isPlayMassAnim = true;
		Mass.Play((PlayCompleteCallback)delegate
		{
			isPlayMassAnim = false;
		});
		while (isPlayMassAnim)
		{
			yield return null;
		}
		Chapter chapter = _level.Chapter;
		bool isShowNewChapter = chapter.Type == ChapterType.StoryMain && !string.IsNullOrEmpty(_level.Desc);
		if (isShowNewChapter)
		{
			string localKey = "ChapterEnter_Key_" + _level.LevelId;
			if (GameLocalDataManager.HasKey(localKey))
			{
				isShowNewChapter = false;
			}
			else
			{
				GameLocalDataManager.SetInt(localKey, 1);
			}
		}
		bool isPlayingIntroductionAnim = false;
		float introductionStartTime = Time.time;
		bool isSkipIntroduction = false;
		if (isShowNewChapter)
		{
			((GObject)StoryInfo.ChapterName).text = chapter.Desc;
			((GObject)StoryInfo.LevelName).text = _level.Desc;
			((GObject)StoryInfo).visible = true;
			isPlayingIntroductionAnim = true;
			StoryInfo.t0.Play((PlayCompleteCallback)delegate
			{
				isPlayingIntroductionAnim = false;
			});
			((GObject)StoryInfo).onClick.Set((EventCallback0)delegate
			{
				float time = Time.time;
				if (time - introductionStartTime > 0.4f)
				{
					isSkipIntroduction = true;
				}
			});
		}
		while (isPlayingIntroductionAnim && !isSkipIntroduction)
		{
			yield return null;
		}
		StoryInfo.t0.Stop();
		((GObject)StoryInfo).visible = false;
		NameTrans.Play();
	}

	private void SoldierIconFade()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		((GObject)SoldierIcon).alpha = 0f;
		((GObject)SoldierIcon).xy = new Vector2(10000f, 10000f);
	}

	private void SoldierIconInit(Vector2 posVector2)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		string iconPath = UiHelper.GetIconPath(curTouchBlockSid);
		if (!string.IsNullOrWhiteSpace(iconPath))
		{
			((GObject)((GComponent)SoldierIcon).GetChild("SoulStoneLevel").asCom).alpha = 1f;
			((GComponent)SoldierIcon).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(curTouchBlockSid);
			((GObject)SoldierIcon).xy = posVector2;
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(curTouchBlockSid);
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
			((GComponent)SoldierIcon).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			UiHelper.LoadSoldierIconFrameMaterial(((GComponent)SoldierIcon).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)SoldierIcon).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
		}
	}

	private void ChangeMainCityBtnStatus(string btnName)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		if (btnName == "Battle.FormationBtn")
		{
			OpenFormationBtn.Status.selectedIndex = 1;
			FGUIManager.Instance.AddTextSpecialEffects(OpenFormationBtn.SfxBack, "workplaceSmoke_2", new Vector3(3.5f, 3.5f, 3.5f), "Default", 0.5f, delegate(GameObject workplaceSmoke2)
			{
				workplaceSmoke2.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
				UiAudioManager.Instance.LoadSoundsForSfx(workplaceSmoke2, "BalloonBlast");
			});
			((GObject)FormationList).visible = true;
			((GComponent)(object)this).SetTimeout(0.33f).OnComplete((GTweenCallback)delegate
			{
				((GObject)OpenFormationBtn.note).visible = true;
			});
		}
	}

	private void RegisterFormationGuideUi()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("Battle.Formations");
		for (int i = 0; i < FormationList.numItems; i++)
		{
			GButton asButton = ((GComponent)FormationList).GetChildAt(i).asButton;
			if (asButton != null && !string.IsNullOrEmpty(asButton.title))
			{
				dictionary.Add(asButton.title, asButton);
			}
		}
		instance.Register("Battle.Formations", dictionary);
	}

	private void UnlockNewFormation(string formationId)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		UpdateUnlockedFormations(formationId);
		FormationList.itemRenderer = new ListItemRenderer(FormationListRender);
		FormationList.numItems = TotalFormations.Count;
		RegisterFormationGuideUi();
		((GObject)OpenFormationBtn.note).visible = true;
		UiAudioManager.Instance.PlaySoundEffect("CardsShow");
	}

	private void UpdateUnlockedFormations(string formationId)
	{
		if (!TotalFormations.Exists((Formation formation) => formation.Id == formationId))
		{
			GDEFormationData gDEFormationData = GDMgr.Get<GDEFormationData>(formationId);
			if (gDEFormationData != null)
			{
				TotalFormations.Add(new Formation(gDEFormationData));
			}
		}
		if (!UnlockFormations.Contains(formationId))
		{
			UnlockFormations.Add(formationId);
		}
	}

	private void UnlockFormation(EventContext context)
	{
		string _formationId = ((GObject)FormationList).data.ToString();
		ILRequestHelper<UnlockFormationResponse>.Request((EventContext)null, (Func<Task<UnlockFormationResponse>>)(() => GameController.Contexts.Service<INetworkService>().UnlockFormation(-1L, _formationId)), (Action<UnlockFormationResponse>)delegate(UnlockFormationResponse unlockResponse)
		{
			if (unlockResponse.Result)
			{
				GameManagers.Instance.FormationManager.UnlockFormation(_formationId);
				UnlockFormations.Clear();
				Dictionary<string, GDEFormationData> unlockedFormations = GameManagers.Instance.FormationManager.GetUnlockedFormations();
				foreach (KeyValuePair<string, GDEFormationData> item in unlockedFormations)
				{
					UnlockFormations.Add(item.Value.Key);
				}
				List<Formation> source = FormationManager.PlayerUsableFormations.Values.ToList();
				TotalFormations.Clear();
				TotalFormations.AddRange(source.OrderByDescending((Formation formation) => UnlockFormations.Contains(formation.Id)));
				UnlockNewFormation(_formationId);
				OpenFormationBtnRender();
			}
		});
	}

	private async void ChangeFormation(EventContext context)
	{
		string _formationId = ((GObject)FormationList).data.ToString();
		Activity activity = await GameManagers.Instance.ActivityManager.GetLevelActivityAsync(_level);
		string formationContext = ((activity == null) ? _level.FormationContext : activity.FormationTag);
		string subContext = _level.BattleMode.ToString();
		ActionResult result = GameManagers.Instance.FormationManager.SetCurrentFormation(formationContext, subContext, _formationId);
		if (!result.Result)
		{
			ILRequestHelper.ShowMessage(result.ErrorMessage);
			return;
		}
		currentFormation = _formationId;
		((GObject)FormationList).data = currentFormation;
		List<string> formationUnits = new List<string>(GameManagers.Instance.UserArchiveManager.GetBattleFormation(formationContext, subContext).Values);
		ILRequestHelper<SyncFormationUnitsResponse>.Request(context, () => GameController.Contexts.Service<INetworkService>().SyncFormationUnits(-1L, formationContext, subContext, formationUnits), delegate(SyncFormationUnitsResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
		});
		ILRequestHelper<ChangeFormationResponse>.Request(context, () => GameController.Contexts.Service<INetworkService>().ChangeFormation(-1L, formationContext, subContext, _formationId), delegate(ChangeFormationResponse response)
		{
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				OpenFormationBtnInitData(_formationId);
				OpenFormationControll.selectedIndex = 0;
				_formationInfoControll.selectedIndex = 0;
				FormationList.itemRenderer = new ListItemRenderer(FormationListRender);
				FormationList.numItems = TotalFormations.Count;
				RegisterFormationGuideUi();
				Dictionary<string, Dictionary<string, string>> value = GameController.Contexts.config.currentFormation.value;
				if (!value.TryGetValue(formationContext, out var value2))
				{
					value2 = new Dictionary<string, string>();
					value.Add(formationContext, value2);
				}
				string key = subContext;
				if (value2.ContainsKey(key))
				{
					value2[key] = _formationId;
				}
				else
				{
					value2.Add(key, _formationId);
				}
				GameController.Contexts.config.ReplaceCurrentFormation(value);
			}
		});
	}

	private void OpenFormationBtnRender()
	{
		string text = ((GObject)FormationList).data.ToString();
		if (OpenFormationControll.selectedIndex == 0)
		{
			((GObject)OpenFormationBtn.n40).visible = false;
			return;
		}
		((GObject)OpenFormationBtn.n40).visible = true;
		if (UnlockFormations.Contains(text))
		{
			OpenFormationBtn.controll.selectedIndex = 2;
			((GObject)OpenFormationBtn.ConsumptionItem).visible = false;
			((GObject)OpenFormationBtn.UnlockBtn).visible = false;
			((GObject)OpenFormationBtn.ChangeBtn).visible = true;
			FormationMask.Type.selectedIndex = 0;
			return;
		}
		FormationMask.Type.selectedIndex = 1;
		Dictionary<string, object> nextFormationCost = GameManagers.Instance.FormationManager.GetNextFormationCost();
		((GComponent)OpenFormationBtn.ConsumptionItem).GetChild("reqDesc").asCom.GetChild("originPrice").visible = false;
		if (nextFormationCost == null)
		{
			OpenFormationBtn.controll.selectedIndex = 0;
			((GObject)OpenFormationBtn.ConsumptionItem).visible = false;
			((GObject)OpenFormationBtn.UnlockBtn).visible = false;
			((GObject)OpenFormationBtn.ChangeBtn).visible = false;
			return;
		}
		((GObject)OpenFormationBtn.ConsumptionItem).visible = true;
		((GObject)OpenFormationBtn.UnlockBtn).visible = true;
		((GObject)OpenFormationBtn.ChangeBtn).visible = false;
		KeyValuePair<string, object> keyValuePair = nextFormationCost.First();
		int stock = GameManagers.Instance.StockController.GetStock(keyValuePair.Key);
		OpenFormationBtn.controll.selectedIndex = ((stock >= (int)keyValuePair.Value) ? 1 : 0);
		FGUIManager.Instance.SetItemIconAndFrame(((GComponent)OpenFormationBtn.ConsumptionItem).GetChild("icon").asLoader, keyValuePair.Key, textureList);
		string text2 = (GameManagers.Instance.FormationManager.CanUnlockFormation(text) ? "#F6E2B2" : "#DC143C");
		GTextField asTextField = ((GComponent)OpenFormationBtn.ConsumptionItem).GetChild("reqDesc").asCom.GetChild("curPrice").asTextField;
		((GObject)asTextField).text = "[color=" + text2 + "]" + ((int)keyValuePair.Value).ShortNumberFormat() + "[/color]";
	}

	private bool SetOpenFormationBtnStatus(int selectIndex = 0)
	{
		if (RankDataHelper.IsPvPLevel(_level.LevelId))
		{
			OpenFormationBtn.Status.selectedIndex = 2;
			((GObject)OpenFormationBtn.Content).SetScale(1f, 1f);
			((GObject)OpenFormationBtn.note).alpha = 1f;
			return false;
		}
		if (_level.BattleMode == BattleMode.DefenceMode || selectIndex == 2)
		{
			OpenFormationBtn.Status.selectedIndex = 2;
			((GObject)OpenFormationBtn.Content).SetScale(1f, 1f);
			((GObject)OpenFormationBtn.note).alpha = 1f;
			return false;
		}
		bool flag = false;
		string key = "LevelAssistance_" + _level.LevelId;
		if (GDMgr.Has<GDELevelAssistanceData>(key) && GDMgr.Get<GDELevelAssistanceData>(key).EnableAssistance)
		{
			if ((GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode2() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode2()) && _level.ChapterId == "C10000")
			{
				flag = true;
			}
			else if ((GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode3()) && _level.ChapterId == "C10001")
			{
				flag = true;
			}
		}
		if (GameManagers.Instance.UserArchiveManager.GetUnlockedMainCityCom().Contains("Battle.FormationBtn") || flag)
		{
			OpenFormationBtn.Status.selectedIndex = 1;
			((GObject)OpenFormationBtn.Content).SetScale(1f, 1f);
			((GObject)OpenFormationBtn.note).alpha = 1f;
			return true;
		}
		OpenFormationBtn.Status.selectedIndex = 0;
		return false;
	}

	private void SetCurLevelEnemyIcon(Level curLevel)
	{
		if (RankDataHelper.IsPvPLevel(curLevel.LevelId) && pvpEnemyInfo != null)
		{
			if (pvpEnemyInfo.IsUser)
			{
				EnemyInfomationBar.Avatar.Type.selectedIndex = 0;
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, pvpEnemyInfo.UserId, EnemyInfomationBar.Avatar.Iconloader, EnemyInfomationBar.ArmyGroupName));
			}
			else
			{
				EnemyInfomationBar.Avatar.Type.selectedIndex = 1;
				EnemyInfomationBar.Avatar.Iconloader.url = pvpEnemyInfo.NpcUrl;
				((GObject)EnemyInfomationBar.ArmyGroupName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText51");
			}
		}
		else if ((IsGvGLevel || GvG3BossBattle || GvG3CommonBattle) && pvpEnemyInfo != null)
		{
			if (pvpEnemyInfo.IsUser)
			{
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, pvpEnemyInfo.UserId, EnemyInfomationBar.Avatar.Iconloader, EnemyInfomationBar.ArmyGroupName));
				return;
			}
			EnemyInfomationBar.Avatar.Iconloader.url = pvpEnemyInfo.NpcUrl;
			((GObject)EnemyInfomationBar.ArmyGroupName).text = pvpEnemyInfo.UserName;
		}
		else if (IsGvGModel2Level && pvpEnemyInfo != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, pvpEnemyInfo.UserId, EnemyInfomationBar.Avatar.Iconloader, EnemyInfomationBar.ArmyGroupName));
		}
		else
		{
			EnemyInfomationBar.Avatar.Type.selectedIndex = 1;
			string text = curLevel.EnemyTemplate.EnemyPortrait ?? "";
			if (!string.IsNullOrWhiteSpace(text))
			{
				EnemyInfomationBar.Avatar.Iconloader.url = "ui://PublicResources/" + text;
			}
			((GObject)EnemyInfomationBar.ArmyGroupName).text = curLevel.Data.Name;
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Expected O, but got Unknown
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected O, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected O, but got Unknown
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected O, but got Unknown
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected O, but got Unknown
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_045a: Expected O, but got Unknown
		//IL_0623: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Expected O, but got Unknown
		//IL_0640: Unknown result type (might be due to invalid IL or missing references)
		//IL_064a: Expected O, but got Unknown
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0667: Expected O, but got Unknown
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0684: Expected O, but got Unknown
		//IL_0697: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a1: Expected O, but got Unknown
		//IL_06af: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b9: Expected O, but got Unknown
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Expected O, but got Unknown
		_gameStateEntity = ((Context<GameStateEntity>)GameController.Contexts.gameState).CreateEntity();
		_gameStateEntity.AddAnyTeamHealthPointsTotalListener(this);
		_gameStateEntity.AddAnyCameraSizeListener(this);
		_gameStateEntity.AddAnyCameraMoveLimitListener(this);
		_gameStateEntity.AddAnyCurrentLevelBattleStartedRemovedListener(this);
		_gameStateEntity.AddAnyBattleTimeLeftListener(this);
		_gameStateEntity.AddAnyBattleFieldLengthListener(this);
		_gameStateEntity.AddAnyRedTeamCombatPowerListener(this);
		_gameStateEntity.AddAnyBlueTeamCombatPowerListener(this);
		_gameStateEntity.AddAnyLoadingPanelStatusListener(this);
		_gameStateEntity.AddAnyBattleFieldSubLevelIndexListener(this);
		_gameStateEntity.AddAnyFreeBattleModeListener(this);
		_gameStateEntity.AddAnyShowBattleWaveCountdownListener(this);
		_gameStateEntity.AddAnyShowBattleWaveCountdownRemovedListener(this);
		_gameStateEntity.AddAnyNextLevelComingListener(this);
		_gameStateEntity.AddAnyNextLevelComingRemovedListener(this);
		_gameStateEntity.AddAnyBattleWaveTimeLeftListener(this);
		_gameStateEntity.AddAnyOfflineBonusesListener(this);
		_configEntity = ((Context<ConfigEntity>)GameController.Contexts.config).CreateEntity();
		_configEntity.AddAnyBattleConfigListener(this);
		_inputEntity = ((Context<InputEntity>)GameController.Contexts.input).CreateEntity();
		_inputEntity.AddAnyMouseScrollDeltaListener(this);
		_inputEntity.AddAnyZoomDeltaListener(this);
		((GObject)BackToCityBtn).onClick.Add(new EventCallback0(BackToCityBtnClicked));
		((GObject)HpSwitchBtn).onClick.Add(new EventCallback0(HpSwitchBtnClicked));
		((GObject)MakeWarBtn).onClick.Add(new EventCallback1(StartBattleBtnClicked));
		((GObject)EnterMaincity).onClick.Add(new EventCallback0(BackToCityBtnClicked));
		((GObject)OpenFormationBtn).onClick.Add(new EventCallback0(FormationBtnClicked));
		((GObject)ScoutBtn).onClick.Add(new EventCallback0(ScoutBtnClicked));
		((GObject)BattleToCityBtn).onClick.Add(new EventCallback0(BackToCityBtnClicked));
		((GObject)WorldBtn).onClick.Add(new EventCallback0(WorldBtnClicked));
		((GObject)CampInfoWindow.CloseBtn).onClick.Add(new EventCallback0(CloseCampInfo));
		((GObject)CampBtn).onClick.Add(new EventCallback0(OpenCampInfoWindow));
		((GObject)RetreatBtn).onClick.Add(new EventCallback0(RetreatBtnClick));
		((GObject)OpenPresetBtn).onClick.Add(new EventCallback0(OpenPresetFormationPanel));
		((GObject)ReplaceSoldierTip).onClick.Add(new EventCallback0(CameraMoveToCamp));
		((GObject)OpenFormationBtn.ChangeBtn).onClick.Add(new EventCallback1(ChangeFormation));
		((GObject)OpenFormationBtn.UnlockBtn).onClick.Add(new EventCallback1(UnlockFormation));
		((GButton)MeterSwitch).onChanged.Add(new EventCallback0(MeterSwitchEvent));
		((GObject)MissionCompletedPlayback).onClick.Add(new EventCallback1(DownLoadRecentReplays));
		((GObject)StrategyGuide).onClick.Add(new EventCallback1(DownLoadLevelReplays));
		ChangePageControll.onChanged.Set(new EventCallback1(OnChangePageControll));
		OpenFormationControll.onChanged.Add(new EventCallback0(OnFormationControllerChanged));
		FullscreenEffectStage.RegisterUiEventListeners();
		FullscreenEffectStage.RegisterSeasonBuffUiEventListeners();
		List<List<string>> unitsId = GameController.Contexts.config.battleConfig.Blue.UnitsId;
		for (int i = 0; i < 12; i++)
		{
			string text = unitsId[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex][i];
			UI_FormationItemBtn uI_FormationItemBtn = UI_FormationItemBtn.CreateInstance();
			((GObject)uI_FormationItemBtn).SetPivot(0.5f, 0.5f, true);
			((GObject)uI_FormationItemBtn).alpha = 0f;
			((GComponent)this).AddChild((GObject)(object)uI_FormationItemBtn);
			_EnmeyFormationItemBtns.Add(uI_FormationItemBtn);
			((GObject)uI_FormationItemBtn).visible = false;
			if (!string.IsNullOrEmpty(text))
			{
				((GObject)uI_FormationItemBtn).data = text;
				((GObject)uI_FormationItemBtn).onClick.Add(new EventCallback1(OpenEnemyInfoPanel));
			}
		}
		if (GameController.Contexts.Service<IBattleFieldService>().Level.BattleMode == BattleMode.MultiWaveAttackMode || IsP1130)
		{
			UI_FormationItemBtn uI_FormationItemBtn2 = UI_FormationItemBtn.CreateInstance();
			((GObject)uI_FormationItemBtn2).SetPivot(0.5f, 0.5f, true);
			((GObject)uI_FormationItemBtn2).alpha = 0f;
			((GComponent)this).AddChild((GObject)(object)uI_FormationItemBtn2);
			_EnmeyFormationItemBtns.Add(uI_FormationItemBtn2);
			((GObject)uI_FormationItemBtn2).visible = false;
			BattleConfigComponent battleConfig = GameController.Contexts.config.battleConfig;
			((GObject)uI_FormationItemBtn2).name = "1130Boss";
			((GObject)uI_FormationItemBtn2).onClick.Set((EventCallback0)delegate
			{
				OpenBossInfoPanel(battleConfig.Blue.BossId[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex], battleConfig.Blue.Boss[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex]);
			});
		}
		SharedMessenger.AddListener<Team>("STAGING_AREA_POSITIONS_CHANGED", OnStagingAreaPositionsChanged);
		SharedMessenger.AddListener<EventContext, string, int>("ON_SOLDIER_SELECTED", OnCampClose);
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_UI", UnpdateOffensiveProgressOnOpenTakeItems);
		SharedMessenger.AddListener<Level>("SUB_LEVEL_CHANGED", SetCurLevelEnemyIcon);
		SharedMessenger.AddListener<int>("NEW_FORMATION_SLOT_UNLOCKED", UnlockFormationItem);
		SharedMessenger.AddListener<string>("MAIN_CITY_COM_UNLOCKED", ChangeMainCityBtnStatus);
		SharedMessenger.AddListener<string>("FORMATION_UNLOCKED", UnlockNewFormation);
		SharedMessenger.AddListener<string>("CLOSE_UI", CheckIsMainCityTop);
		SharedMessenger.AddListener<GvGBossHealthInfo>("UPDATE_GVG_RECORD_WORLD_BOSS_INFO", UpdateTotalDamage);
		SharedMessenger.AddListener("SET_RANK_UI_MODE", SetRankUiType);
		((GObject)MiniMapHandle).onTouchBegin.Add(new EventCallback1(OnMiniMapTouchBegin));
		((GObject)MiniMapHandle).onTouchMove.Add(new EventCallback1(OnMiniMapTouchMove));
		((GObject)BigMap).onTouchBegin.Add(new EventCallback1(OnBigMapTouchBegin));
		((GObject)BigMap).onTouchMove.Add(new EventCallback1(OnBigMapTouchMove));
		((GObject)MiniMapHandle).onClick.Add(new EventCallback1(OnClick));
		((GObject)this).onClick.Add(new EventCallback0(OnClickAnyPos));
	}

	private void OnClickAnyPos()
	{
		StopSoftGuideClick();
	}

	private void OnChangePageControll(EventContext context)
	{
		UpdateMakeWarBtnVisibility();
	}

	private void OnFormationControllerChanged()
	{
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode3())
		{
			bool flag = OpenFormationControll.selectedIndex == 0;
			((GObject)MakeWarBtn).touchable = flag;
			SharedMessenger.Broadcast("CHANGE_GUIDE_FINGER_VISIBLE", "Battle.StartBtn", flag);
		}
	}

	public void OnBlockTouchBegin(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		int num = int.Parse(((GObject)context.sender).data.ToString());
		if (_levelAssistanceConfig == null || (!_levelAssistanceConfig.LockPosition.Contains(num + 1) && ((!(_level.ChapterId == "C1000") && !(_level.ChapterId == "C1000")) || !_levelAssistanceConfig.AssistancePosition.Contains(num + 1))))
		{
			isMouseMoving = false;
			curTouchBlockSid = "";
			GObject touchTarget = GRoot.inst.touchTarget;
			if (touchTarget.name == "back" && touchTarget.data != null && !string.IsNullOrWhiteSpace(touchTarget.data.ToString()))
			{
				curTouchBlockSid = touchTarget.data.ToString();
				SoldierIconInit(((GObject)touchTarget.parent).xy);
			}
		}
	}

	public void OnBlockTouchMove(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		int num = int.Parse(((GObject)context.sender).data.ToString());
		if (_levelAssistanceConfig == null || (!_levelAssistanceConfig.LockPosition.Contains(num + 1) && ((!(_level.ChapterId == "C1000") && !(_level.ChapterId == "C1000")) || !_levelAssistanceConfig.AssistancePosition.Contains(num + 1))))
		{
			isMouseMoving = true;
			if (!string.IsNullOrWhiteSpace(curTouchBlockSid))
			{
				Vector2 val = default(Vector2);
				((Vector2)(ref val))._002Ector(context.inputEvent.x, context.inputEvent.y);
				val = ((GObject)this).GlobalToLocal(val);
				((GObject)SoldierIcon).xy = val;
				((GObject)SoldierIcon).alpha = 1f;
			}
		}
	}

	public async void OnBlockTouchEnd(EventContext context)
	{
		int slotIndex = int.Parse(((GObject)context.sender).data.ToString());
		if (_levelAssistanceConfig != null && (_levelAssistanceConfig.LockPosition.Contains(slotIndex + 1) || ((_level.ChapterId == "C1000" || _level.ChapterId == "C1000") && _levelAssistanceConfig.AssistancePosition.Contains(slotIndex + 1))))
		{
			return;
		}
		SoldierIconFade();
		GObject obj = GRoot.inst.touchTarget;
		if (!isMouseMoving)
		{
			return;
		}
		isMouseMoving = false;
		if (obj == null || !(obj.name == "back") || string.IsNullOrWhiteSpace(curTouchBlockSid))
		{
			return;
		}
		_currentFormationItemIndex = int.Parse(((GObject)obj.parent).data.ToString());
		if (_levelAssistanceConfig == null || (!_levelAssistanceConfig.LockPosition.Contains(_currentFormationItemIndex + 1) && ((!(_level.ChapterId == "C1000") && !(_level.ChapterId == "C1000")) || !_levelAssistanceConfig.AssistancePosition.Contains(_currentFormationItemIndex + 1))))
		{
			Activity activity = await GameManagers.Instance.ActivityManager.GetLevelActivityAsync(_level);
			Dictionary<string, string> formationConfig = ArchiveExtension_Formation.GetBattleFormation(context: (activity == null) ? _level.FormationContext : activity.FormationTag, subContext: _level.BattleMode.ToString(), manager: GameManagers.Instance.UserArchiveManager);
			List<string> units = new List<string>(formationConfig.Values);
			string cur_blocksid = units[_currentFormationItemIndex];
			if (curTouchBlockSid != cur_blocksid)
			{
				ArmsItemClickOnChoiceModel(context, curTouchBlockSid);
			}
		}
	}

	private void ArmsItemClickOnChoiceModel(EventContext eventContext, string soldierId)
	{
		SharedMessenger.Broadcast<EventContext, string, int>("ON_SOLDIER_SELECTED", eventContext, soldierId, 1);
	}

	public async void OnCampClose(EventContext eventContext, string soldierId, int chosenType)
	{
		if (chosenType != 1 && chosenType != 4 && chosenType != 8)
		{
			return;
		}
		Activity activity = await GameManagers.Instance.ActivityManager.GetLevelActivityAsync(_level);
		if (activity == null && _level.Chapter.Type == ChapterType.RepeatableInstanceOffensive)
		{
			SentrySdk.AddBreadcrumb("[LevelActivityDebug]Get Activity Of " + _level.LevelId + " Failed");
		}
		string context = ((activity == null) ? _level.FormationContext : activity.FormationTag);
		if (_levelAssistanceConfig != null)
		{
			for (int i = 0; i < _levelAssistanceConfig.AssistanceSoldier.Count; i++)
			{
				string assistanceSoldierId = SoldierManager.GetRootIdForSoldier(_levelAssistanceConfig.AssistanceSoldier[i]);
				if (soldierId == assistanceSoldierId)
				{
					ILRequestHelper.ShowErrorCode(82000001);
					return;
				}
			}
		}
		ActionResult result = GameManagers.Instance.FormationUnitsManager.ChangeFormationUnit(context, _level.BattleMode.ToString(), _currentFormationItemIndex, soldierId);
		if (!result.Result)
		{
			ILRequestHelper.ShowMessage(result.ErrorMessage);
			return;
		}
		if (soldierId[0] == 'S')
		{
			UiAudioManager.Instance.PlaySoldierVoice(soldierId, UiAudioManager.SoldierVoiceType.Onomatopoeia);
		}
		hideUI = false;
		ScoutBtnClicked();
		ScoutBtnClicked();
		hideUI = true;
		if (_level.BattleMode != BattleMode.MultiWaveAttackMode || OpenFormationControll.selectedIndex != 0 || !GameController.Contexts.gameState.hasReplayState || GameController.Contexts.gameState.replayState.value != 1)
		{
			return;
		}
		ILRequestHelper<ChangeFormationUnitResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().ChangeFormationUnit(-1L, context, _level.BattleMode.ToString(), _currentFormationItemIndex, soldierId), delegate(ChangeFormationUnitResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
		});
	}

	public void UnregisterUiEventListeners()
	{
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected O, but got Unknown
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected O, but got Unknown
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Expected O, but got Unknown
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Expected O, but got Unknown
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Expected O, but got Unknown
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Expected O, but got Unknown
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected O, but got Unknown
		//IL_058c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0596: Expected O, but got Unknown
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b3: Expected O, but got Unknown
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cb: Expected O, but got Unknown
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Expected O, but got Unknown
		_gameStateEntity.RemoveAnyTeamHealthPointsTotalListener(this);
		_gameStateEntity.RemoveAnyCameraSizeListener(this);
		_gameStateEntity.RemoveAnyCameraMoveLimitListener(this);
		_gameStateEntity.RemoveAnyCurrentLevelBattleStartedRemovedListener(this);
		_gameStateEntity.RemoveAnyBattleTimeLeftListener(this);
		_gameStateEntity.RemoveAnyBattleFieldLengthListener(this);
		_gameStateEntity.RemoveAnyRedTeamCombatPowerListener(this);
		_gameStateEntity.RemoveAnyBlueTeamCombatPowerListener(this);
		_gameStateEntity.RemoveAnyLoadingPanelStatusListener(this);
		_gameStateEntity.RemoveAnyBattleFieldSubLevelIndexListener(this);
		_gameStateEntity.RemoveAnyFreeBattleModeListener(this);
		_gameStateEntity.RemoveAnyShowBattleWaveCountdownListener(this);
		_gameStateEntity.RemoveAnyShowBattleWaveCountdownRemovedListener(this);
		_gameStateEntity.RemoveAnyNextLevelComingListener(this);
		_gameStateEntity.RemoveAnyNextLevelComingRemovedListener(this);
		_gameStateEntity.RemoveAnyBattleWaveTimeLeftListener(this);
		_gameStateEntity.RemoveAnyOfflineBonusesListener(this);
		((Entity)_gameStateEntity).Destroy();
		_configEntity.RemoveAnyBattleConfigListener(this);
		((Entity)_configEntity).Destroy();
		_inputEntity.RemoveAnyMouseScrollDeltaListener(this);
		_inputEntity.RemoveAnyZoomDeltaListener(this);
		((Entity)_inputEntity).Destroy();
		((GObject)BackToCityBtn).onClick.Remove(new EventCallback0(BackToCityBtnClicked));
		((GObject)WorldBtn).onClick.Remove(new EventCallback0(WorldBtnClicked));
		((GObject)HpSwitchBtn).onClick.Remove(new EventCallback0(HpSwitchBtnClicked));
		((GObject)MakeWarBtn).onClick.Remove(new EventCallback1(StartBattleBtnClicked));
		((GObject)EnterMaincity).onClick.Remove(new EventCallback0(BackToCityBtnClicked));
		((GObject)OpenFormationBtn).onClick.Remove(new EventCallback0(FormationBtnClicked));
		((GObject)ScoutBtn).onClick.Remove(new EventCallback0(ScoutBtnClicked));
		((GObject)BattleToCityBtn).onClick.Remove(new EventCallback0(BackToCityBtnClicked));
		((GObject)CampInfoWindow.CloseBtn).onClick.Remove(new EventCallback0(CloseCampInfo));
		((GObject)CampBtn).onClick.Remove(new EventCallback0(OpenCampInfoWindow));
		((GObject)RetreatBtn).onClick.Remove(new EventCallback0(RetreatBtnClick));
		((GObject)OpenPresetBtn).onClick.Remove(new EventCallback0(OpenPresetFormationPanel));
		((GObject)ReplaceSoldierTip).onClick.Remove(new EventCallback0(CameraMoveToCamp));
		((GObject)OpenFormationBtn.ChangeBtn).onClick.Remove(new EventCallback1(ChangeFormation));
		((GObject)OpenFormationBtn.UnlockBtn).onClick.Remove(new EventCallback1(UnlockFormation));
		((GButton)MeterSwitch).onChanged.Remove(new EventCallback0(MeterSwitchEvent));
		((GObject)MissionCompletedPlayback).onClick.Remove(new EventCallback1(DownLoadRecentReplays));
		((GObject)StrategyGuide).onClick.Remove(new EventCallback1(DownLoadLevelReplays));
		ChangePageControll.onChanged.Remove(new EventCallback1(OnChangePageControll));
		OpenFormationControll.onChanged.Remove(new EventCallback0(OnFormationControllerChanged));
		FullscreenEffectStage.UnregisterUiEventListeners();
		FullscreenEffectStage.UnregisterSeasonBuffUiEventListeners();
		for (int i = 0; i < _formationItemBtns.Count; i++)
		{
			((GObject)_formationItemBtns[i]).onClick.Remove(new EventCallback1(OpenArmyGroup));
		}
		for (int j = 1; j < _EnmeyFormationItemBtns.Count; j++)
		{
			if (_EnmeyFormationItemBtns[j] != null)
			{
				((GObject)_EnmeyFormationItemBtns[j]).onClick.Remove(new EventCallback1(OpenEnemyInfoPanel));
			}
		}
		SharedMessenger.RemoveListener<Team>("STAGING_AREA_POSITIONS_CHANGED", OnStagingAreaPositionsChanged);
		SharedMessenger.RemoveListener<EventContext, string, int>("ON_SOLDIER_SELECTED", OnCampClose);
		SharedMessenger.RemoveListener<string, Dictionary<string, object>>("OPEN_UI", UnpdateOffensiveProgressOnOpenTakeItems);
		SharedMessenger.RemoveListener<Level>("SUB_LEVEL_CHANGED", SetCurLevelEnemyIcon);
		SharedMessenger.RemoveListener<int>("NEW_FORMATION_SLOT_UNLOCKED", UnlockFormationItem);
		SharedMessenger.RemoveListener<string>("MAIN_CITY_COM_UNLOCKED", ChangeMainCityBtnStatus);
		SharedMessenger.RemoveListener<string>("FORMATION_UNLOCKED", UnlockNewFormation);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", CheckIsMainCityTop);
		SharedMessenger.RemoveListener("SET_RANK_UI_MODE", SetRankUiType);
		SharedMessenger.RemoveListener<GvGBossHealthInfo>("UPDATE_GVG_RECORD_WORLD_BOSS_INFO", UpdateTotalDamage);
		((GObject)MiniMapHandle).onTouchBegin.Remove(new EventCallback1(OnMiniMapTouchBegin));
		((GObject)MiniMapHandle).onTouchMove.Remove(new EventCallback1(OnMiniMapTouchMove));
		((GObject)BigMap).onTouchBegin.Remove(new EventCallback1(OnBigMapTouchBegin));
		((GObject)BigMap).onTouchMove.Remove(new EventCallback1(OnBigMapTouchMove));
		((GObject)MiniMapHandle).onClick.Remove(new EventCallback1(OnClick));
		((GObject)this).onClick.Remove(new EventCallback0(OnClickAnyPos));
	}

	public void CheckIsMainCityTop(string str)
	{
		if (UnityUiService.Instance.CheckIsMainCityShowed() && UnityUiService.Instance.edgeMaskPanel.ratio > 1f)
		{
			UnityUiService.Instance.SetEdgeMaskVisible(value: false);
		}
		if (str == UI_LoadingPanel.Name)
		{
			SetFormationItemBtnPos();
		}
	}

	private void GetRecentReplays(EventContext context)
	{
		if (curMissionGuide != null && curMissionGuide.Count > 0)
		{
			OpenPlayBackPanel();
			return;
		}
		ILRequestHelper<GetRecentReplaysResponse>.Request(context, () => GameController.Contexts.Service<INetworkService>().GetRecentReplays(), delegate(GetRecentReplaysResponse response)
		{
			if (!response.Result)
			{
				if (response.ErrorCode != 0)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
			}
			else
			{
				curMissionGuide = response.Replays;
				ReplayDownloadManager.OnRecentReplaysResponse(response);
				OpenPlayBackPanel();
			}
		});
	}

	private void GetLevelReplays(EventContext context)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		if (curStrategyGuide != null && curStrategyGuide.Count > 0 && curStrategyGuide[0].LevelId == _level.LevelId)
		{
			OpenPlayBackPanel();
			return;
		}
		string levelId = ((GObject)context.sender).data.ToString();
		ILRequestHelper<GetLevelReplaysResponse>.Request(context, () => GameController.Contexts.Service<INetworkService>().GetLevelReplays(levelId, random: false, string.Empty), delegate(GetLevelReplaysResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				UiHelper.ClearReplaySoldierCombatCache();
				curStrategyGuide = response.Replays;
				ReplayDownloadManager.OnLevelReplaysResponse(response);
				OpenPlayBackPanel();
			}
		});
	}

	private void DownLoadReplays(EventContext context)
	{
		_levelBattleReplayResponseCount = 0;
		GetRecentReplays(context);
		GetLevelReplays(context);
	}

	private void DownLoadRecentReplays(EventContext context)
	{
		if (!(_level.ChapterId == "FightTest"))
		{
			DownLoadReplays(context);
		}
	}

	private void DownLoadLevelReplays(EventContext context)
	{
		if (!(_level.ChapterId == "FightTest"))
		{
			DownLoadReplays(context);
		}
	}

	private void OpenPlayBackPanel()
	{
		_levelBattleReplayResponseCount++;
		if (_levelBattleReplayResponseCount >= 2)
		{
			if (_level.LevelId == "P1120")
			{
				ReplayType = 2;
			}
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{
					"Order",
					((GObject)this).sortingOrder
				},
				{ "Type", ReplayType },
				{ "LevelId", _level.LevelId },
				{ "RecentReplays", curMissionGuide },
				{ "LevelReplays", curStrategyGuide }
			};
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_PlayBack.Name, parameters);
		}
	}

	public void UnpdateOffensiveProgressOnOpenTakeItems(string uiName, Dictionary<string, object> uiParams)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		if (uiName == UI_TakeItems.Name && _level.BattleMode == BattleMode.MultiWaveAttackMode)
		{
			FGUIManager.Instance.BattleAudioManager.Enabled = false;
			UnpdateOffensiveProgress(isEnd: true);
			Vector3 campPosition = ClientBattleFieldLogic.GetCampPosition(Team.Blue, _level.Data.Length);
			float currentX = GameController.Contexts.Service<ICameraService>().Position.x;
			_tweener = (Tweener)(object)TweenSettingsExtensions.OnUpdate<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => currentX), (DOSetter<float>)delegate(float x)
			{
				currentX = x;
			}, campPosition.x, 0.3f), (TweenCallback)delegate
			{
				CameraMove(currentX, 0f);
			});
		}
		if (uiName == UI_Guide.Name)
		{
			DisplayMainCityEntrance();
		}
	}

	private IEnumerator UpdateCampBtnPos()
	{
		while (true)
		{
			yield return null;
			if (ChangePageControll.selectedIndex == 1 && _level.BattleMode == BattleMode.MultiWaveAttackMode)
			{
				SetCampBtnPos(isEnemy: false);
			}
			UpdateReplaceSoldierTipVisible(null);
		}
	}

	private void SetRedTeamCampBindgWithCamera()
	{
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		if (GameController.Contexts.gameState.loadingPanelStatus.value != LoadingPanelStatus.Closed)
		{
			return;
		}
		((GObject)nextName).visible = false;
		((GObject)curName).visible = true;
		if (isForeword)
		{
			SetBackToCityBtnVisible(WorldMapBtnVisible);
		}
		else
		{
			SetBackToCityBtnVisible(isVisible: true);
		}
		((GObject)MissionCompletedPlayback).visible = true;
		((GObject)WorldBtn).visible = WorldMapBtnVisible;
		((GObject)MissionCompletedPlayback).visible = WorldMapBtnVisible;
		((GObject)StrategyGuide).visible = false;
		if (_level.BattleMode == BattleMode.DefenceMode)
		{
			((GObject)PlaceSoldierLimitTip).visible = true;
		}
		GameObject val = GameObject.Find("MainCamera");
		Camera component = val.GetComponent<Camera>();
		((GObject)CampBtn).SetSize(458f, 783.5f);
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1.7777778f;
		float num3 = num / num2;
		float amendment = 0f;
		if (num3 < 1f)
		{
			amendment = (1920f / (float)Screen.width * (float)Screen.height - 1080f) / 2f;
		}
		UICameraBindingFoo uICameraBindingFoo = ((GObject)CampBtn).displayObject.gameObject.GetComponent<UICameraBindingFoo>();
		if ((Object)(object)uICameraBindingFoo == (Object)null)
		{
			uICameraBindingFoo = ((GObject)CampBtn).displayObject.gameObject.AddComponent<UICameraBindingFoo>();
		}
		uICameraBindingFoo.Binding_GObject = (GObject)(object)CampBtn;
		uICameraBindingFoo.Binding_Pos = ClientBattleFieldLogic.GetCampPosition(Team.Red, _level.Data.Length);
		uICameraBindingFoo.Binding_Cam = component;
		uICameraBindingFoo.Amendment = amendment;
		uICameraBindingFoo.StartBinding(1);
		Vector3 binding_Pos = default(Vector3);
		for (int i = 0; i < _formationItemBtns.Count; i++)
		{
			if (((GObject)_formationItemBtns[i]).alpha != 0f)
			{
				Vector3 val2 = Vector3.op_Implicit(GameController.Contexts.Service<IStagingService>().GetStagingAreaPosition_PortalIndex(Team.Red, i));
				((Vector3)(ref binding_Pos))._002Ector(val2.x, val2.y, val2.z);
				UICameraBindingFoo uICameraBindingFoo2 = ((GObject)_formationItemBtns[i]).displayObject.gameObject.GetComponent<UICameraBindingFoo>();
				if ((Object)(object)uICameraBindingFoo2 == (Object)null)
				{
					uICameraBindingFoo2 = ((GObject)_formationItemBtns[i]).displayObject.gameObject.AddComponent<UICameraBindingFoo>();
				}
				uICameraBindingFoo2.Binding_GObject = (GObject)(object)_formationItemBtns[i];
				uICameraBindingFoo2.Binding_Pos = binding_Pos;
				uICameraBindingFoo2.Binding_Cam = component;
				uICameraBindingFoo2.Amendment = amendment;
				uICameraBindingFoo2.StartBinding(2);
			}
		}
		if (HideFormationItemBtnCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(HideFormationItemBtnCoroutine);
			HideFormationItemBtnCoroutine = null;
		}
		HideFormationItemBtnCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(HideFormationItemBtn(isEnemy: false));
	}

	private void UnpdateOffensiveProgress(bool isEnd = false, int curStages = 1)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		if (curStages == 0)
		{
			clearStages = 0;
		}
		else
		{
			clearStages = ((GameController.Contexts.gameState.replayMode.value == 3) ? GameController.Contexts.gameState.battleFieldSubLevelIndex.value : GameController.Contexts.gameState.battleProgressStats.clearStages);
		}
		((GObject)offensiveProgressList).data = isEnd;
		((GObject)offensiveProgressList).alpha = 1f;
		offensiveProgressList.itemRenderer = new ListItemRenderer(RenderOffensiveProgressItem);
		offensiveProgressList.numItems = _level.SubLevels.Count;
	}

	private void RenderOffensiveProgressItem(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		if (index == 0)
		{
			((GComponent)asButton).GetController("InitItem").selectedIndex = 0;
		}
		else
		{
			((GComponent)asButton).GetController("InitItem").selectedIndex = 1;
		}
		int num = ((clearStages > _level.SubLevels.Count - 1) ? (_level.SubLevels.Count - 1) : clearStages);
		bool flag = (bool)((GObject)offensiveProgressList).data;
		if (index < num)
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 1;
		}
		else if (index == num)
		{
			if (flag)
			{
				((GComponent)asButton).GetController("Status").selectedIndex = 2;
			}
			else
			{
				((GComponent)asButton).GetController("Status").selectedIndex = 0;
			}
		}
		else
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 2;
		}
	}

	private void UpdateCpuntdowenBtnPos(object paramter)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		if (ChangePageControll.selectedIndex == 1 && _level.BattleMode == BattleMode.MultiWaveAttackMode)
		{
			Vector3 stagingAreaPosition = GameController.Contexts.Service<IStagingService>().GetStagingAreaPosition(Team.Red, 0);
			Vector2 val = Vector2.op_Implicit(GameController.Contexts.Service<ICameraService>().WorldToScreenPoint(stagingAreaPosition));
			val.y = (float)Screen.height - val.y;
			Vector2 val2 = ((GObject)this).GlobalToLocal(Vector2.op_Implicit(val));
			Vector2 val3 = formationItemInitPos - val2;
			((GObject)CountdownBtn).x = countdownBtnInitPos.x - val3.x;
			if (((GObject)CountdownBtn).x < 0f)
			{
				((GObject)CountdownBtn).alpha = 0f;
				((GObject)ReinforceCountdown).alpha = 1f;
			}
			else
			{
				((GObject)CountdownBtn).alpha = 1f;
				((GObject)ReinforceCountdown).alpha = 0f;
			}
		}
	}

	public void InitData(Dictionary<string, object> parameters)
	{
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected O, but got Unknown
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected O, but got Unknown
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		currentFormation = GameController.Contexts.config.battleConfig.Red.FormationId[0];
		Dictionary<string, GDEFormationData> unlockedFormations = GameManagers.Instance.FormationManager.GetUnlockedFormations();
		foreach (KeyValuePair<string, GDEFormationData> item in unlockedFormations)
		{
			UnlockFormations.Add(item.Value.Key);
		}
		((GObject)FormationList).data = currentFormation;
		if (parameters.TryGetValue("OpenUIOnReturn", out var value))
		{
			OpenUIOnReturn = (string)value;
		}
		_level = GameController.Contexts.Service<IBattleFieldService>().Level;
		string key = "LevelAssistance_" + _level.LevelId;
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode() && GDMgr.Has<GDELevelAssistanceData>(key))
		{
			_levelAssistanceConfig = GDMgr.Get<GDELevelAssistanceData>(key);
		}
		if (_levelAssistanceConfig != null && !_levelAssistanceConfig.EnableAssistance)
		{
			_levelAssistanceConfig = null;
		}
		List<string> arg = new List<string>(GameManagers.Instance.UserArchiveManager.GetBattleFormation(_level.FormationContext, _level.BattleMode.ToString()).Values);
		if (_levelAssistanceConfig != null)
		{
			FormationUnitsManager.ChangeFormationUnits(_level.FormationContext, _level.BattleMode.ToString(), arg);
		}
		UiHelper.StoryMainRetreatLevelId = null;
		((GObject)StrategyGuide).data = _level.LevelId;
		((GObject)MissionCompletedPlayback).data = _level.LevelId;
		CombatPowerName.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)143));
		CombatPower.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)143));
		hideUI = true;
		((GProgressBar)OurInfomationBar.HPBar).value = 100.0;
		((GProgressBar)EnemyInfomationBar.HPBar).value = 100.0;
		_curLevelTimeLimit = 0;
		((GObject)Timer).text = UiHelper.ParseTime(_curLevelTimeLimit);
		((GObject)CurrentCardName).text = GameController.Contexts.Service<IBattleFieldService>().Level.Data.Name;
		((GObject)NextCardname).text = LanguagesManager.GetDesc("CsharpCodeZhTcText102");
		((GObject)CombatPower).text = "";
		List<Formation> source = FormationManager.PlayerUsableFormations.Values.ToList();
		TotalFormations.AddRange(source.OrderByDescending((Formation formation) => UnlockFormations.Contains(formation.Id)));
		OpenFormationBtnInitData(currentFormation);
		FormationList.itemRenderer = new ListItemRenderer(FormationListRender);
		FormationList.numItems = TotalFormations.Count;
		RegisterFormationGuideUi();
		FormationList.onClickItem.Add(new EventCallback1(OnFormationChange));
		SetLevelType();
		_enemyIds = new string[5]
		{
			_level.Data.Enemy1,
			_level.Data.Enemy2,
			_level.Data.Enemy3,
			_level.Data.Enemy4,
			_level.Data.Enemy5
		};
		if (parameters.TryGetValue("WorldMapBtnVisible", out var value2))
		{
			WorldMapBtnVisible = (bool)value2;
		}
		_formationItemBtnsInit();
		PrepareUnlockFormationItem();
		BattleMode battleMode = _level.BattleMode;
		ChapterType type = _level.Chapter.Type;
		if (battleMode != BattleMode.RushMode)
		{
			((GObject)CampBtn).enabled = false;
		}
		if (_level.ChapterId == "C1000" || _level.ChapterId == "C10000" || _level.ChapterId == "C10001" || _level.ChapterId == "C1000" || _level.ChapterId == "C10002" || IsLive001)
		{
			WorldMapBtnVisible = false;
			isForeword = true;
			for (int num = 0; num < _formationItemBtns.Count; num++)
			{
				((GObject)_formationItemBtns[num]).touchable = false;
				((GObject)_formationItemBtns[num]).alpha = 1f;
				if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode2() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode2() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode3())
				{
					((GObject)_formationItemBtns[num]).touchable = true;
				}
			}
		}
		if (_level.IsPerspective())
		{
			foreach (UI_FormationItemBtn enmeyFormationItemBtn in _EnmeyFormationItemBtns)
			{
				((GObject)enmeyFormationItemBtn).scale = Vector2.one * 1.4f;
			}
		}
		if (GameController.Contexts.gameState.hasRedTeamCombatPower)
		{
			OnAnyRedTeamCombatPower(null, GameController.Contexts.gameState.redTeamCombatPower.value);
		}
		if (GameController.Contexts.gameState.hasBlueTeamCombatPower)
		{
			OnAnyBlueTeamCombatPower(null, GameController.Contexts.gameState.blueTeamCombatPower.value);
		}
		if (isForeword)
		{
			SetBackToCityBtnVisible(WorldMapBtnVisible);
		}
		else
		{
			SetBackToCityBtnVisible(isVisible: true);
		}
		((GObject)WorldBtn).visible = WorldMapBtnVisible;
		((GObject)MissionCompletedPlayback).visible = WorldMapBtnVisible;
		((GObject)MissionCompletedPlayback.Finger).visible = parameters.TryGetValue("SHOW_LEVEL_STRATEGY_REMINDER", out var value3) && (bool)value3;
		switch (battleMode)
		{
		case BattleMode.DefenceMode:
			LevelTypeController.selectedIndex = 1;
			((GObject)PlaceSoldierLimitTip).visible = true;
			SetDefencePlaceSoldierLimitText(0);
			break;
		case BattleMode.MultiWaveAttackMode:
			LevelTypeController.selectedIndex = 2;
			break;
		default:
			LevelTypeController.selectedIndex = 0;
			if (type == ChapterType.StoryMain)
			{
				ThinkingDataHelper.Instance.Track("mainline_enter");
				EnemyCache();
			}
			break;
		}
		if (type == ChapterType.RepeatableInstance || type == ChapterType.RepeatableInstancePortal)
		{
			ThinkingDataHelper.Instance.SoulEnterTrack(_level.ChapterId, _level.LevelId);
		}
		else
		{
			switch (type)
			{
			case ChapterType.RepeatableInstanceDefensive:
				ThinkingDataHelper.Instance.DefendEnterTrack(_level.ChapterId, _level.LevelId.Last().ToString());
				AlertHaloSwitchInit();
				break;
			case ChapterType.RepeatableInstanceOffensive:
				ThinkingDataHelper.Instance.AttackEnterTrack(_level.LevelId, _level.Difficult);
				break;
			case ChapterType.TreasureHunt:
				ThinkingDataHelper.Instance.LegendItemLevelEnterTrack(_level.LevelId);
				break;
			}
		}
		UpdateMapBtnNote();
		((GObject)ReplaceSoldierTip).touchable = true;
	}

	private void ChangeFormationUnitsOnNewGuideMode4Live001(List<string> formationUnits)
	{
		if (!(_level.LevelId != "Live001") && (GameManagers.Instance.UserArchiveManager.IsNewGuideMode4() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode7() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode4() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6()) && !(formationUnits[0] != "S001") && !(formationUnits[1] != "S002"))
		{
			formationUnits[0] = "S002";
			formationUnits[1] = "S001";
		}
	}

	public void UpdateMapBtnNote()
	{
		((GObject)WorldBtn.note).visible = GameManagers.Instance.NewMsgIncomingManager.HasAnyRegionWithNewMsg();
	}

	private void AlertHaloSwitchInit()
	{
		if (GameLocalDataManager.HasKey("AlertHaloSwitch"))
		{
			((GButton)MeterSwitch).selected = GameLocalDataManager.GetBool("AlertHaloSwitch");
			return;
		}
		((GButton)MeterSwitch).selected = true;
		GameLocalDataManager.SetBool("AlertHaloSwitch", value: true);
	}

	private void MeterSwitchEvent()
	{
		if (((GButton)MeterSwitch).selected)
		{
			GameLocalDataManager.SetBool("AlertHaloSwitch", value: true);
		}
		else
		{
			GameLocalDataManager.SetBool("AlertHaloSwitch", value: false);
		}
		foreach (KeyValuePair<int, GameObject> formationMark in FGUIManager.Instance.formationMarks)
		{
			((GObject)formationMark.Value.GetComponent<StagingArea>().haloCom).visible = ((GButton)MeterSwitch).selected;
		}
	}

	private void SetDefencePlaceSoldierLimitText(int curNum)
	{
		if (_level.BattleMode == BattleMode.DefenceMode)
		{
			string arg = "#EAE453";
			if (curNum <= 0)
			{
				arg = "#DC143C";
			}
			((GObject)PlaceSoldierLimitTip.timeTip).text = string.Format("{0}[color={1}]{2}[/color]/5", LanguagesManager.GetDesc("CsharpCodeZhTcText111"), arg, curNum);
		}
	}

	private void SetFormationBtnByUnitId(string unitId, int btnIndex)
	{
		RefreshSoldierPotentialDisplay(_formationItemBtns[btnIndex], unitId, btnIndex);
		if (unitId == "Lock")
		{
			((GObject)_formationItemBtns[btnIndex].UnitNumberInfo).visible = false;
			_formationItemBtns[btnIndex].Status.selectedIndex = 1;
			((GObject)_formationItemBtns[btnIndex].UnlcokTip).visible = true;
			string text = "";
			if (_levelAssistanceConfig != null && _levelAssistanceConfig.LockPosition != null && _levelAssistanceConfig.LockPosition.Contains(btnIndex + 1))
			{
				text = LanguagesManager.GetDesc("CsharpCodeZhTcText112") + "15";
			}
			else if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
			{
				switch (btnIndex)
				{
				case 3:
					text = LanguagesManager.GetDesc("CsharpCodeZhTcText13") + "1-10";
					break;
				case 4:
					text = LanguagesManager.GetDesc("CsharpCodeZhTcText112") + "15";
					break;
				}
			}
			else
			{
				switch (GameManagers.Instance.ConfigDataManager.GetUserLevelRequiredForFormationSlotUnlock(btnIndex + 1))
				{
				case 6:
					text = LanguagesManager.GetDesc("CsharpCodeZhTcText13") + "2-5";
					break;
				case 15:
					text = LanguagesManager.GetDesc("CsharpCodeZhTcText112") + "15";
					break;
				}
			}
			((GObject)_formationItemBtns[btnIndex].UnlcokTip).text = text + LanguagesManager.GetDesc("CsharpCodeZhTcText113");
			((GObject)_formationItemBtns[btnIndex]).touchable = false;
		}
		else if (unitId == "Unlock")
		{
			((GObject)_formationItemBtns[btnIndex].UnlcokTip).text = "";
			if (_level.BattleMode == BattleMode.MultiWaveAttackMode)
			{
				SetFormationItemSoldierIcon(_formationItemBtns[btnIndex], unitId, btnIndex);
			}
		}
		else
		{
			((GObject)_formationItemBtns[btnIndex].UnlcokTip).text = "";
			if (_level.BattleMode == BattleMode.MultiWaveAttackMode)
			{
				SetFormationItemSoldierIcon(_formationItemBtns[btnIndex], unitId, btnIndex);
			}
		}
	}

	private async void _formationItemBtnsInit()
	{
		GDEFormationData curFormationData = GDMgr.Get<GDEFormationData>(currentFormation);
		Activity activity = await GameManagers.Instance.ActivityManager.GetLevelActivityAsync(_level);
		string formationContext = ((activity == null) ? _level.FormationContext : activity.FormationTag);
		string mode = _level.BattleMode.ToString();
		if (_level.Chapter.Type == ChapterType.RepeatableInstanceDefensive)
		{
			GetFormationVisionRadius(GameManagers.Instance.UserArchiveManager.GetCurrentFormation(formationContext, mode));
		}
		bool isInit = curUnitData.Count <= 0;
		int enemyInfomationBarOrder = ((GComponent)this).GetChildIndex((GObject)(object)EnemyInfomationBar);
		List<string> infoData = GetFormationUnits(formationContext, mode);
		if (infoData == null)
		{
			int count = 12;
			infoData = new List<string>(count);
			for (int i = 0; i < count; i++)
			{
				infoData.Add("Unlock");
			}
		}
		int campBtnOrder = ((GComponent)this).GetChildIndex((GObject)(object)CampBtn);
		for (int j = 0; j < 12; j++)
		{
			bool available = GameManagers.Instance.FormationManager.IsFormationSlotAvailable(curFormationData, j);
			UI_FormationItemBtn formationItem;
			if (j < _formationItemBtns.Count)
			{
				formationItem = _formationItemBtns[j];
			}
			else
			{
				formationItem = UI_FormationItemBtn.CreateInstance();
				_formationItemBtns.Add(formationItem);
			}
			((GObject)formationItem).name = $"坑位UI{j}";
			((GComponent)this).AddChild((GObject)(object)formationItem);
			((GComponent)this).SetChildIndex((GObject)(object)formationItem, (_level.BattleMode != BattleMode.MultiWaveAttackMode) ? campBtnOrder : enemyInfomationBarOrder);
			((GObject)formationItem.back).data = infoData[j];
			if (!available)
			{
				((GObject)formationItem).alpha = 0f;
				((GObject)formationItem).touchable = false;
				((GObject)formationItem).SetSize(0f, 0f);
				if (isInit)
				{
					curUnitData.Add(null);
				}
				continue;
			}
			((GObject)formationItem).SetPivot(0.5f, 0.5f, true);
			((GObject)formationItem).alpha = 1f;
			((GObject)formationItem).data = j;
			((GObject)formationItem).onClick.Add(new EventCallback1(OpenArmyGroup));
			((GObject)formationItem).onTouchBegin.Add(new EventCallback1(OnBlockTouchBegin));
			((GObject)formationItem).onTouchMove.Add(new EventCallback1(OnBlockTouchMove));
			((GObject)formationItem).onTouchEnd.Add(new EventCallback1(OnBlockTouchEnd));
			((GObject)formationItem).touchable = true;
			formationItem.UnitNumberInfo.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
			((GComponent)formationItem).GetController("LevelTypeController").selectedIndex = 0;
			List<string> units = infoData;
			string unitId = ((j < units.Count) ? units[j] : "");
			SetFormationBtnByUnitId(unitId, j);
			SetFormationHalo(j, infoData[j], 0.1f * (float)j);
			if (isInit)
			{
				curUnitData.Add(infoData[j]);
			}
		}
		if (isInit)
		{
			ResetSoftGuideClick();
		}
	}

	private void GetFormationVisionRadius(string fId)
	{
		formationVision.Clear();
		formationVision.Add(FormationManager.GetFormation(fId).VisionRadius1);
		formationVision.Add(FormationManager.GetFormation(fId).VisionRadius2);
		formationVision.Add(FormationManager.GetFormation(fId).VisionRadius3);
		formationVision.Add(FormationManager.GetFormation(fId).VisionRadius4);
		formationVision.Add(FormationManager.GetFormation(fId).VisionRadius5);
		formationVision.Add(FormationManager.GetFormation(fId).VisionRadius6);
		formationVision.Add(FormationManager.GetFormation(fId).VisionRadius7);
		formationVision.Add(FormationManager.GetFormation(fId).VisionRadius8);
		formationVision.Add(FormationManager.GetFormation(fId).VisionRadius9);
		formationVision.Add(FormationManager.GetFormation(fId).VisionRadius10);
		formationVision.Add(FormationManager.GetFormation(fId).VisionRadius11);
		formationVision.Add(FormationManager.GetFormation(fId).VisionRadius12);
	}

	private void SetFormationHalo(int i, string unitId, float delayTime)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		((GComponent)(object)this).SetTimeout(delayTime).OnComplete((GTweenCallback)delegate
		{
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			if (_level.Chapter.Type == ChapterType.RepeatableInstanceDefensive && FGUIManager.Instance.formationMarks.ContainsKey(i))
			{
				if (FGUIManager.Instance.formationMarks[i].GetComponent<StagingArea>().haloCom == null)
				{
					ILRuntimeDebug.LogError($"formationVision{i} not Contains haloCom");
				}
				else if (IsUnitEmpty(unitId))
				{
					((GObject)FGUIManager.Instance.formationMarks[i].GetComponent<StagingArea>().haloCom).alpha = 0f;
				}
				else
				{
					((GObject)FGUIManager.Instance.formationMarks[i].GetComponent<StagingArea>().haloCom).alpha = 1f;
					FGUIManager.Instance.formationMarks[i].GetComponent<StagingArea>().haloCom.GetController("Type").selectedIndex = i;
					if (formationVision.Count - 1 >= i && i >= 0)
					{
						float a = formationVision[i];
						float attackDistance = new Soldier(unitId).AttackDistance;
						Vector2 formationHaloSize = GetFormationHaloSize(a, attackDistance);
						((GObject)FGUIManager.Instance.formationMarks[i].GetComponent<StagingArea>().haloCom).SetSize(formationHaloSize.x, formationHaloSize.y);
					}
				}
			}
		});
	}

	private Vector2 GetFormationHaloSize(float a, float b)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		float num = 0f;
		num = ((!(a > b)) ? b : a);
		return new Vector2(num * 100f * 2f, num * 100f * 2f);
	}

	private void SetFormationItemSoldierIcon(UI_FormationItemBtn btn, string soldierId, int index)
	{
		if (_levelAssistanceConfig != null && _levelAssistanceConfig.LockPosition.Contains(index + 1))
		{
			((GComponent)btn).GetChild("soldierIcon").visible = false;
			((GComponent)btn).GetChild("icon").asLoader.url = "";
			((GComponent)btn).GetChild("iconFrame").asLoader.url = "";
			((GObject)((GComponent)btn).GetChild("SoulStoneLevel").asCom).alpha = 0f;
			((GComponent)btn).GetController("Status").selectedIndex = 0;
			((GObject)btn).alpha = 1f;
			return;
		}
		if (IsUnitEmpty(soldierId))
		{
			((GComponent)btn).GetChild("soldierIcon").visible = false;
			((GComponent)btn).GetChild("icon").asLoader.url = "";
			((GComponent)btn).GetChild("iconFrame").asLoader.url = "";
			((GObject)((GComponent)btn).GetChild("SoulStoneLevel").asCom).alpha = 0f;
			if (!string.IsNullOrWhiteSpace(soldierId) && !(soldierId == "Unlock"))
			{
				return;
			}
			if (string.IsNullOrWhiteSpace(((GObject)btn.UnlcokTip).text))
			{
				((GComponent)btn).GetController("Status").selectedIndex = 0;
				showDispatchSoldierTip = true;
				((GObject)btn).alpha = 1f;
				return;
			}
			((GComponent)btn).GetController("Status").selectedIndex = 1;
			if (_level.ChapterId == "C1000" || _level.ChapterId == "C10000" || _level.ChapterId == "C10001" || _level.ChapterId == "C1000" || _level.ChapterId == "C10002" || IsLive001)
			{
				((GObject)btn).alpha = 0f;
			}
			return;
		}
		((GObject)btn).alpha = 1f;
		((GComponent)btn).GetController("Status").selectedIndex = 1;
		((GComponent)btn).GetController("LevelTypeController").selectedIndex = 2;
		string iconPath = UiHelper.GetIconPath(soldierId);
		if (!string.IsNullOrWhiteSpace(iconPath))
		{
			((GComponent)btn).GetChild("soldierIcon").visible = true;
			((GObject)((GComponent)btn).GetChild("SoulStoneLevel").asCom).alpha = 1f;
			((GComponent)btn).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldierId);
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
			((GComponent)btn).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			UiHelper.LoadSoldierIconFrameMaterial(((GComponent)btn).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)btn).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
		}
		else
		{
			((GComponent)btn).GetChild("soldierIcon").visible = false;
			((GComponent)btn).GetChild("icon").asLoader.url = "";
			((GComponent)btn).GetChild("iconFrame").asLoader.url = "";
			((GObject)((GComponent)btn).GetChild("SoulStoneLevel").asCom).alpha = 0f;
		}
	}

	private static bool IsUnitEmpty(string unitId)
	{
		return string.IsNullOrWhiteSpace(unitId) || unitId == "Lock" || unitId == "Unlock";
	}

	private static bool IsUnitLocked(string unitId)
	{
		return string.IsNullOrWhiteSpace(unitId) || unitId == "Lock";
	}

	private void RetreatBtnClick()
	{
		if (_level.BattleMode == BattleMode.MultiWaveAttackMode)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					"[color=#FFFF66]" + LanguagesManager.GetDesc("CsharpCodeZhTcText115") + "[/color]"
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{ "Confirm", RetreatEvent },
						{ "Cancel", null }
					}
				},
				{ "PageIndex", 2 },
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText116") + "?"
				},
				{ "FontSize", 34 },
				{
					"Order",
					((GObject)this).sortingOrder
				}
			});
		}
		else if (_level.Chapter.Type == ChapterType.StoryMain)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content_Page2",
					LanguagesManager.GetDesc("CsharpCodeZhTcText117") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText118") + "\n[color=#FF1919]" + LanguagesManager.GetDesc("CsharpCodeZhTcText119") + "[/color]"
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{ "Confirm", MainLevelRetreatEvent },
						{ "Cancel", null }
					}
				},
				{ "PageIndex", 2 },
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText120") + "?"
				},
				{ "FontSize", 34 },
				{
					"Order",
					((GObject)this).sortingOrder
				}
			});
		}
	}

	private void OpenPresetFormationPanel()
	{
		StopSoftGuideClick();
		ILRequestHelper<GetTreasureHuntBattlePresetFormationResponse>.Request((EventContext)null, (Func<Task<GetTreasureHuntBattlePresetFormationResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetTreasureHuntBattlePresetFormation()), (Action<GetTreasureHuntBattlePresetFormationResponse>)delegate(GetTreasureHuntBattlePresetFormationResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_PresetFormationPanel.Name, new Dictionary<string, object>
				{
					{ "IsUsingMode", true },
					{ "Level", _level },
					{
						"Callbacks",
						new Dictionary<string, Action<UI_PresetFormationPanel.SelectFormation>> { 
						{
							"OnUseFormationSuccess",
							delegate(UI_PresetFormationPanel.SelectFormation selectedFormation)
							{
								//IL_0054: Unknown result type (might be due to invalid IL or missing references)
								//IL_005e: Expected O, but got Unknown
								hideUI = false;
								ScoutBtnClicked();
								ScoutBtnClicked();
								hideUI = true;
								currentFormation = selectedFormation.FormationId;
								OpenFormationBtnInitData(currentFormation);
								((GObject)FormationList).data = currentFormation;
								FormationList.itemRenderer = new ListItemRenderer(FormationListRender);
								FormationList.numItems = TotalFormations.Count;
								RegisterFormationGuideUi();
								OpenFormationBtnRender();
							}
						} }
					},
					{ "PresetFormationData", response.CurFormation }
				});
			}
		});
	}

	private void RetreatEvent()
	{
		string battleId = GameManagers.Instance.UserArchiveManager.GetCurrentBattleId();
		ILRequestHelper<RetreatResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().Retreat(battleId), delegate
		{
			CommandFactory.CreateRetreatCommand(GameController.Contexts);
		}, 1f);
	}

	private void MainLevelRetreatEvent()
	{
		string battleId = GameManagers.Instance.UserArchiveManager.GetCurrentBattleId();
		ILRequestHelper<MainLevelRetreatResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().MainLevelRetreat(battleId), delegate
		{
			CommandFactory.CreateRetreatCommand(GameController.Contexts);
			UiHelper.StoryMainRetreatLevelId = _level.LevelId;
		}, 1f);
	}

	private void SetLevelType()
	{
		if (_level.BattleMode != BattleMode.DefenceMode)
		{
			if (_level.BattleMode == BattleMode.MultiWaveAttackMode || _level.Chapter.Type == ChapterType.StoryMain)
			{
				SetRetreatBtnVisible(_level.ChapterId != "C1000" && _level.ChapterId != "C10000" && _level.ChapterId != "C10001" && _level.ChapterId != "C1000" && _level.ChapterId != "C10002");
			}
			else if (_level.Chapter.Type == ChapterType.TreasureHunt)
			{
				((GObject)OpenPresetBtn).visible = true;
				((GObject)OpenPresetBtn).touchable = true;
			}
		}
	}

	private void UpdateReplaceSoldierTipVisible(object paramter)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		if (_level == null || _level.BattleMode != BattleMode.MultiWaveAttackMode)
		{
			return;
		}
		if (farthestNeedReplaceFormationPos.x <= -10000f)
		{
			((GObject)ReplaceSoldierTip).visible = false;
			return;
		}
		float x = GameController.Contexts.Service<ICameraService>().Position.x;
		x -= FGUIManager.Instance.cameraFrameX / 2f;
		if (x > farthestNeedReplaceFormationPos.x)
		{
			((GObject)ReplaceSoldierTip).visible = true;
		}
		else
		{
			((GObject)ReplaceSoldierTip).visible = false;
		}
	}

	private void CameraMoveToCamp()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		float currentX = GameController.Contexts.Service<ICameraService>().Position.x;
		Vector3 campPosition = ClientBattleFieldLogic.GetCampPosition(Team.Red, _level.Data.Length);
		_tweener = (Tweener)(object)TweenSettingsExtensions.OnComplete<TweenerCore<float, float, FloatOptions>>(TweenSettingsExtensions.OnUpdate<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => currentX), (DOSetter<float>)delegate(float x)
		{
			currentX = x;
		}, campPosition.x, 0.5f), (TweenCallback)delegate
		{
			CameraMove(currentX, 0f);
		}), (TweenCallback)delegate
		{
			PlayDispatchTip();
		});
	}

	private bool IsRedUnitsBornChanged()
	{
		if (!GameController.Contexts.config.hasBattleConfig)
		{
			_oldBorn = 0;
			return false;
		}
		if (GameController.Contexts.config.battleConfig.Red.UnitsBorn == null)
		{
			_oldBorn = 0;
			return false;
		}
		int num = 0;
		foreach (KeyValuePair<string, int> item in GameController.Contexts.config.battleConfig.Red.UnitsBorn)
		{
			num += item.Value;
		}
		bool result = _oldBorn != num;
		_oldBorn = num;
		return result;
	}

	private void RefreshFormationButtonsNumberInfo()
	{
		if (IsRedUnitsBornChanged())
		{
			OnFormationUnitsChanged();
		}
	}

	private void StopSoftGuideClick()
	{
		if (_softGuideClick != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(_softGuideClick);
			_softGuideClick = null;
		}
		if (_guideFinger != null)
		{
			_guideFinger.CloseGuide();
			_guideFinger = null;
		}
	}

	private void ResetSoftGuideClick()
	{
		StopSoftGuideClick();
		if (_level != null && Chapter.First3Chapters.Contains(_level.Chapter.ChapterId) && !IsSetReplayUiType && GameManagers.Instance.StoryManager.PlayingStories.Count <= 0)
		{
			_softGuideClick = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(SoftGuideClick());
		}
	}

	private IEnumerator SoftGuideClick()
	{
		yield return (object)new WaitForSeconds(5f);
		if (GameManagers.Instance.StoryManager.PlayingStories.Count > 0 || ((GObject)this).isDisposed)
		{
			yield break;
		}
		_softGuideClick = null;
		HashSet<string> currentSoldiers = new HashSet<string>();
		string formationContext = _level.FormationContext;
		string mode = _level.BattleMode.ToString();
		List<string> redUnits = GetFormationUnits(formationContext, mode);
		foreach (string redUnit in redUnits)
		{
			if (!IsUnitEmpty(redUnit))
			{
				currentSoldiers.Add(redUnit);
			}
		}
		Dictionary<string, int>.KeyCollection soldierQuery = GameManagers.Instance.StockController.GetOwnedSoldiers(onlyUnlocked: true, includeEmptyStock: false).Keys;
		int maxPotential = -1;
		foreach (string soldierId in soldierQuery)
		{
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
			if (!currentSoldiers.Contains(soldier.Id))
			{
				int potential = soldier.PotentialLevel;
				if (potential > maxPotential)
				{
					maxPotential = potential;
				}
			}
		}
		int count = Mathf.Min(redUnits.Count, 5);
		for (int i = 0; i < count; i++)
		{
			bool needFinger = false;
			string soldier2 = redUnits[i];
			if (!IsUnitLocked(soldier2))
			{
				if (_levelAssistanceConfig?.AssistanceSoldier != null && _levelAssistanceConfig.AssistanceSoldier.Contains(soldier2))
				{
					continue;
				}
				if (IsUnitEmpty(soldier2))
				{
					needFinger = true;
				}
				else
				{
					Soldier s = GameManagers.Instance.SoldierManager.Get(soldier2);
					int potentialLevel = s.PotentialLevel;
					if (potentialLevel < maxPotential)
					{
						needFinger = true;
					}
				}
			}
			if (needFinger && _formationItemBtns.Count > i)
			{
				UI_FormationItemBtn btn = _formationItemBtns[i];
				_guideFinger = UI_GuideFinger.CreateInstance();
				_guideFinger.SoftGuideClick((GObject)(object)btn);
				break;
			}
		}
	}

	private void UpdateBattleWaveTimeLeft(int value)
	{
		if (_level != null && _level.BattleMode == BattleMode.MultiWaveAttackMode)
		{
			if (value >= 30 && needRefreshFormationUiOnWave)
			{
				needRefreshFormationUiOnWave = false;
				UnpdateOffensiveProgress();
			}
			string text = UiHelper.ParseTime(value);
			text = text.Substring(3);
			((GObject)CountdownBtn.timeTip).text = LanguagesManager.GetDesc("CsharpCodeZhTcText121") + ":" + text;
			if (value <= 1)
			{
				needRefreshFormationUiOnWave = true;
			}
		}
	}

	private void PrepareUnlockFormationItem()
	{
		if (_level.Chapter.Type == ChapterType.StoryMain && GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
		{
			switch (GameManagers.Instance.UserArchiveManager.GetUserLevel())
			{
			case 3:
				PrepareUnlockFormationItem(4);
				break;
			case 15:
				PrepareUnlockFormationItem(5);
				break;
			}
		}
	}

	private void PrepareUnlockFormationItem(int index)
	{
		string configKey = $"NEW_FORMATION_SLOT_UNLOCKED_{index}";
		List<string> list = configKey.ToConfiguration<List<string>>();
		List<string> activatedStories = GameManagers.Instance.StoryManager.ActivatedStories;
		bool flag = false;
		foreach (string item in list)
		{
			if (activatedStories.Contains(item))
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			int num = index - 1;
			string formationContext = _level.FormationContext;
			string text = _level.BattleMode.ToString();
			string text2 = GetFormationUnits(formationContext, text)[num];
			unlockFormationItemSoldierIdCache = text2;
			CommandFactory.CreateChangeCurrentFormationUnitCommand(num, "Unlock", formationContext, text);
			SetFormationBtnByUnitId("Lock", num);
		}
	}

	private void UnlockFormationItem(int index)
	{
		FGUIManager.Instance.OpenIEnumerator(Real_UnlockFormationItem(index));
	}

	private IEnumerator Real_UnlockFormationItem(int index)
	{
		UI_FormationItemBtn btn = _formationItemBtns[index - 1];
		((GObject)btn.UnitNumberInfo).visible = false;
		btn.Status.selectedIndex = 1;
		((GObject)btn.UnlcokTip).visible = true;
		string unlockTip = "";
		if (_levelAssistanceConfig != null && _levelAssistanceConfig.LockPosition != null && _levelAssistanceConfig.LockPosition.Contains(index))
		{
			unlockTip = LanguagesManager.GetDesc("CsharpCodeZhTcText112") + "15";
		}
		else if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
		{
			switch (index)
			{
			case 4:
				unlockTip = LanguagesManager.GetDesc("CsharpCodeZhTcText13") + "1-10";
				break;
			case 5:
				unlockTip = LanguagesManager.GetDesc("CsharpCodeZhTcText112") + "15";
				break;
			}
		}
		else
		{
			switch (GameManagers.Instance.ConfigDataManager.GetUserLevelRequiredForFormationSlotUnlock(index))
			{
			case 6:
				unlockTip = LanguagesManager.GetDesc("CsharpCodeZhTcText13") + "2-5";
				break;
			case 15:
				unlockTip = LanguagesManager.GetDesc("CsharpCodeZhTcText112") + "15";
				break;
			}
		}
		((GObject)btn.UnlcokTip).text = unlockTip + LanguagesManager.GetDesc("CsharpCodeZhTcText113");
		((GObject)btn).touchable = false;
		((GObject)MakeWarBtn).touchable = false;
		((GObject)OpenPresetBtn).touchable = false;
		string formationContext = _level.FormationContext;
		string mode = _level.BattleMode.ToString();
		string curSoldierId = (string.IsNullOrEmpty(unlockFormationItemSoldierIdCache) ? GetFormationUnits(formationContext, mode)[index - 1] : unlockFormationItemSoldierIdCache);
		CommandFactory.CreateChangeCurrentFormationUnitCommand(index - 1, "Unlock", formationContext, mode);
		((GObject)btn.UnlcokTip).TweenFade(0f, 0.75f);
		yield return (object)new WaitForSecondsRealtime(0.75f);
		UI_UnlockAnimation UnlockAnimation = UI_UnlockAnimation.CreateInstance();
		((GComponent)btn).AddChild((GObject)(object)UnlockAnimation);
		((GObject)UnlockAnimation).SetXY(((GObject)btn).width / 2f, ((GObject)btn).height / 2f);
		yield return (object)new WaitForSecondsRealtime(0.417f);
		((GComponent)btn).RemoveChild((GObject)(object)UnlockAnimation);
		((GObject)UnlockAnimation).Dispose();
		yield return null;
		((GObject)btn.UnitNumberInfo).visible = true;
		if (FGUIManager.Instance.formationMarks != null)
		{
			StagingArea stagingArea = FGUIManager.Instance.formationMarks[index - 1].GetComponent<StagingArea>();
			stagingArea.SetFrameColor(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
		}
		yield return (object)new WaitForSecondsRealtime(0.5f);
		string maxPowerSoldierId = LegionHelper.GetPlayerMaxPowerSoldierToBattle(GameManagers.Instance, GetFormationUnits(formationContext, mode));
		string currentSoldierId = ((!string.IsNullOrEmpty(maxPowerSoldierId)) ? maxPowerSoldierId : curSoldierId);
		CommandFactory.CreateChangeCurrentFormationUnitCommand(index - 1, currentSoldierId, formationContext, _level.BattleMode.ToString());
		yield return (object)new WaitForSecondsRealtime(1f);
		((GObject)btn).touchable = true;
		((GObject)MakeWarBtn).touchable = true;
		((GObject)OpenPresetBtn).touchable = true;
	}

	public void OpenArmyGroup(EventContext context)
	{
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		UI_FormationItemBtn uI_FormationItemBtn = (UI_FormationItemBtn)(object)context.sender;
		if (!((GObject)uI_FormationItemBtn).touchable)
		{
			return;
		}
		int num = int.Parse(((GObject)uI_FormationItemBtn).data.ToString());
		if (_levelAssistanceConfig != null)
		{
			if (_levelAssistanceConfig.LockPosition.Contains(num + 1))
			{
				return;
			}
			BattleConfigComponent battleConfig = GameController.Contexts.config.battleConfig;
			GameEntityData gameEntityData = battleConfig.Red.Units(GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex, num);
			string text = gameEntityData?.Identifier;
			if (text != null && _levelAssistanceConfig.AssistanceSoldier.Contains(text))
			{
				int index = _levelAssistanceConfig.AssistanceSoldier.IndexOf(text);
				GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(text);
				int num2 = _levelAssistanceConfig.AssistanceQty[index];
				Dictionary<string, object> dictionary = new Dictionary<string, object>
				{
					{ "SoldierId", gameEntityData.Identifier },
					{ "EntityData", gameEntityData },
					{ "Num", num2 },
					{
						"IsAssistanceSoldier",
						_level.ChapterId != "C10000" && _level.ChapterId != "C10001"
					}
				};
				List<Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem> list = new List<Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem>();
				string[] array = gDESoldierData.Tags.Split(' ');
				if (array.Length != 0)
				{
					string[] array2 = array;
					foreach (string text2 in array2)
					{
						if (!string.IsNullOrEmpty(text2) && text2.StartsWith("FakeLegendItem"))
						{
							GDEConfigurationData gDEConfigurationData = GDMgr.Get<GDEConfigurationData>(text2);
							if (gDEConfigurationData != null)
							{
								Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem item = JsonHelper.ToObject<Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem>(gDEConfigurationData.Config);
								list.Add(item);
							}
						}
					}
				}
				if (list.Count > 0)
				{
					dictionary.Add("FakeLegendItem", list.Select((Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models.LegendItem _equipped) => LegendItemBrief.Parse(_equipped)).ToList());
				}
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_EnemyIntroduction.Name, dictionary);
				return;
			}
		}
		_currentFormationItemIndex = int.Parse(((GObject)context.sender).data.ToString());
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		switch (_level.Chapter.Type)
		{
		case ChapterType.RepeatableInstance:
		case ChapterType.RepeatableInstanceOffensive:
		case ChapterType.RepeatableInstanceDefensive:
		case ChapterType.RepeatableInstancePortal:
			dictionary2.Add("Style", "4");
			break;
		case ChapterType.TreasureHunt:
			dictionary2.Add("OnlyUnlocked", 1);
			dictionary2.Add("Style", "8");
			break;
		default:
			dictionary2.Add("Style", "1");
			break;
		}
		dictionary2.Add("Spine", null);
		dictionary2.Add("SoldierFilter", _level.SoldierFilters);
		if (_level.LevelId == LegendItemDungeonUiHelper.CurLevelId)
		{
			dictionary2.Add("IsLegendItemDungeon", true);
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegionPanel.Name, dictionary2);
	}

	public void OpenEnemyInfoPanel(EventContext context)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		if (!((GObject)CampInfoWindow).visible && context != null && context.sender != null && ((GObject)context.sender).data != null)
		{
			string value = ((GObject)context.sender).data.ToString();
			int num = _EnmeyFormationItemBtns.IndexOf((UI_FormationItemBtn)(object)context.sender);
			BattleConfigComponent battleConfig = GameController.Contexts.config.battleConfig;
			GameEntityData value2 = battleConfig.Blue.Units(GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex, num);
			int num2 = battleConfig.Blue.UnitsTotal[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex, num];
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_EnemyIntroduction.Name, new Dictionary<string, object>
			{
				{ "SoldierId", value },
				{ "EntityData", value2 },
				{ "Num", num2 }
			});
		}
	}

	public void OpenBossInfoPanel(string bossId, GameEntityData bossData)
	{
		if (!((GObject)CampInfoWindow).visible)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_EnemyIntroduction.Name, new Dictionary<string, object>
			{
				{ "SoldierId", bossId },
				{ "EntityData", bossData },
				{ "Num", 1 },
				{ "IsZBoss002", true }
			});
		}
	}

	public void OpenCampInfoWindow()
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		if (_currentType == CampType.OurCamp)
		{
			return;
		}
		if (_currentType == CampType.EnemyCamp)
		{
			if (_level.Chapter.Type == ChapterType.TreasureHunt)
			{
				return;
			}
			RewardsListData();
			CampInfoWindow.InfoPageControll.selectedIndex = 0;
			for (int i = 0; i < _EnmeyFormationItemBtns.Count; i++)
			{
				if (_EnmeyFormationItemBtns[i] != null)
				{
					((GObject)_EnmeyFormationItemBtns[i]).visible = false;
				}
			}
		}
		((GObject)CampInfoWindow).visible = true;
		((GObject)CampInfoWindow.content).y = -650f;
		((GComponent)(object)this).SetTimeout(0.1f).OnComplete(new GTweenCallback(CampInfoWindow.showSelf.Play));
	}

	public void CloseCampInfo()
	{
		((GObject)CampInfoWindow).visible = false;
		if (_currentType != CampType.EnemyCamp)
		{
			return;
		}
		for (int i = 0; i < _EnmeyFormationItemBtns.Count; i++)
		{
			if (_EnmeyFormationItemBtns[i] != null)
			{
				((GObject)_EnmeyFormationItemBtns[i]).visible = true;
			}
		}
	}

	public void CampGainListData()
	{
		CampInfoWindow.CampGainList.RemoveChildrenToPool();
		for (int i = 0; i < 2; i++)
		{
			CampInfoWindow.CampGainList.AddItemFromPool();
			((GComponent)CampInfoWindow.CampGainList).GetChildAt(i).asCom.GetChild("IconLoader").asLoader.url = "";
			((GObject)((GComponent)CampInfoWindow.CampGainList).GetChildAt(i).asCom.GetChild("Amount").asTextField).text = "";
		}
	}

	public void WorldBtnClicked()
	{
		if (!(_level.ChapterId == "FightTest"))
		{
			RestoreFormation();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("FromBattleField", true);
			dictionary.Add("BattleField", this);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorldMapPanel.Name, dictionary);
		}
	}

	public void ScoutBtnClicked()
	{
		if (hideUI)
		{
			HideAll();
		}
		SharedMessenger.Broadcast("ON_SCOUT_BTN_CLICK", _currentType != CampType.OurCamp);
		if (_currentType == CampType.OurCamp)
		{
			_currentType = CampType.EnemyCamp;
			StopSoftGuideClick();
			SetCampBtnPos(isEnemy: true, animated: true);
			switch (_level.Chapter.Type)
			{
			case ChapterType.StoryMain:
				ThinkingDataHelper.Instance.Track("mainline_scout");
				break;
			case ChapterType.RepeatableInstance:
			case ChapterType.RepeatableInstancePortal:
				ThinkingDataHelper.Instance.SoulScoutTrack(_level.ChapterId, _level.LevelId);
				break;
			case ChapterType.RepeatableInstanceDefensive:
				ThinkingDataHelper.Instance.DefendScoutTrack(_level.ChapterId, _level.LevelId);
				break;
			case ChapterType.RepeatableInstanceOffensive:
				ThinkingDataHelper.Instance.AttackScoutTrack(_level.LevelId, _level.Difficult);
				break;
			}
		}
		else
		{
			_currentType = CampType.OurCamp;
			ResetSoftGuideClick();
			SetCampBtnPos(isEnemy: false, animated: true);
		}
		ScoutBtn.Status.SetSelectedIndex((_currentType != CampType.OurCamp) ? 1 : 0);
	}

	private void SetCameraInEnemyPos()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		Team team = Team.Blue;
		Vector3 campPos = ClientBattleFieldLogic.GetCampPosition(team, _level.Data.Length);
		((GObject)nextName).visible = !IsP1130;
		((GObject)curName).visible = false;
		SetBackToCityBtnVisible(isVisible: false);
		((GObject)WorldBtn).visible = false;
		((GObject)MissionCompletedPlayback).visible = false;
		((GObject)StrategyGuide).visible = WorldMapBtnVisible;
		if (_level.BattleMode == BattleMode.DefenceMode)
		{
			((GObject)PlaceSoldierLimitTip).visible = false;
		}
		float currentX = GameController.Contexts.Service<ICameraService>().Position.x;
		_tweener = (Tweener)(object)TweenSettingsExtensions.OnComplete<TweenerCore<float, float, FloatOptions>>(TweenSettingsExtensions.OnUpdate<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => currentX), (DOSetter<float>)delegate(float x)
		{
			currentX = x;
		}, campPos.x, 0.5f), (TweenCallback)delegate
		{
			CameraMove(currentX, 0f);
		}), (TweenCallback)delegate
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			InternalSetCampBtnPos(Vector3.op_Implicit(campPos), isEnemy: true);
		});
	}

	private void SetBackToCityBtnVisible(bool isVisible)
	{
		((GObject)BackToCityBtn).visible = isVisible;
		((GObject)n106).visible = isVisible;
	}

	private void SetScoutBtnVisible(bool isVisible)
	{
		((GObject)ScoutBtn).visible = isVisible;
		((GObject)n107).visible = isVisible;
	}

	private void SetRetreatBtnVisible(bool isVisible)
	{
		((GObject)RetreatBtn).visible = isVisible;
		((GObject)n108).visible = isVisible;
	}

	public void SetCampBtnPos(bool isEnemy, bool animated = false, float duration = 0.5f)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		if (GameController.Contexts.gameState.loadingPanelStatus.value != LoadingPanelStatus.Closed)
		{
			return;
		}
		Team team = (isEnemy ? Team.Blue : Team.Red);
		Vector3 campPos = ClientBattleFieldLogic.GetCampPosition(team, _level.Data.Length);
		if (isEnemy)
		{
			((GObject)nextName).visible = !IsP1130;
			((GObject)curName).visible = false;
			SetBackToCityBtnVisible(isVisible: false);
			((GObject)WorldBtn).visible = false;
			((GObject)MissionCompletedPlayback).visible = false;
			((GObject)StrategyGuide).visible = WorldMapBtnVisible;
			if (_level.BattleMode == BattleMode.DefenceMode)
			{
				((GObject)PlaceSoldierLimitTip).visible = false;
			}
		}
		else
		{
			((GObject)nextName).visible = false;
			((GObject)curName).visible = true;
			if (isForeword)
			{
				SetBackToCityBtnVisible(WorldMapBtnVisible);
			}
			else
			{
				SetBackToCityBtnVisible(isVisible: true);
			}
			((GObject)MissionCompletedPlayback).visible = true;
			((GObject)WorldBtn).visible = WorldMapBtnVisible;
			((GObject)MissionCompletedPlayback).visible = WorldMapBtnVisible;
			((GObject)StrategyGuide).visible = false;
			if (_level.BattleMode == BattleMode.DefenceMode)
			{
				((GObject)PlaceSoldierLimitTip).visible = true;
			}
		}
		if (animated)
		{
			float currentX = GameController.Contexts.Service<ICameraService>().Position.x;
			Tweener tweener = _tweener;
			if (tweener != null)
			{
				TweenExtensions.Kill((Tween)(object)tweener, false);
			}
			_tweener = (Tweener)(object)TweenSettingsExtensions.OnComplete<TweenerCore<float, float, FloatOptions>>(TweenSettingsExtensions.OnUpdate<TweenerCore<float, float, FloatOptions>>(DOTween.To((DOGetter<float>)(() => currentX), (DOSetter<float>)delegate(float x)
			{
				currentX = x;
			}, campPos.x, duration), (TweenCallback)delegate
			{
				CameraMove(currentX, 0f);
			}), (TweenCallback)delegate
			{
				//IL_0008: Unknown result type (might be due to invalid IL or missing references)
				//IL_000d: Unknown result type (might be due to invalid IL or missing references)
				InternalSetCampBtnPos(Vector3.op_Implicit(campPos), isEnemy);
				_tweener = null;
			});
		}
		else
		{
			InternalSetCampBtnPos(Vector3.op_Implicit(campPos), isEnemy);
		}
	}

	private void InternalSetCampBtnPos(Vector3 campPos, bool isEnemy)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = Vector2.op_Implicit(GameController.Contexts.Service<ICameraService>().WorldToScreenPoint(Vector3.op_Implicit(campPos)));
		val.y = (float)Screen.height - val.y;
		Vector2 val2 = ((GObject)GRoot.inst).GlobalToLocal(Vector2.op_Implicit(val));
		float num = FGUIManager.Instance.ScreenAmendY();
		val2.y -= num;
		((GObject)CampBtn).SetXY(val2.x, val2.y);
		((GObject)CampBtn).SetSize(458f, 783.5f);
		if (!isEnemy)
		{
			SetFormationItemBtnPos();
		}
		else
		{
			SetEnmeyFormationBtnPos();
		}
		if (HideFormationItemBtnCoroutine != null)
		{
			((MonoBehaviour)FGUIManager.Instance).StopCoroutine(HideFormationItemBtnCoroutine);
			HideFormationItemBtnCoroutine = null;
		}
		HideFormationItemBtnCoroutine = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(HideFormationItemBtn(isEnemy));
	}

	private void EnemyCache()
	{
		BattleConfigComponent battleConfig = GameController.Contexts.config.battleConfig;
		enemyCombatPower = battleConfig.Blue.CombatPower[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex];
	}

	private void UpdateMakeWarBtnVisibility()
	{
		bool flag = IsSetReplayUiType || IsStartWarSuccess || ChangePageControll.selectedIndex == 1;
		if (IsLive001)
		{
			((GObject)MakeWarBtn).visible = false;
		}
		else if (flag)
		{
			((GObject)MakeWarBtn).visible = IsMakeWarBtnEfectPlaying;
		}
		else
		{
			((GObject)MakeWarBtn).visible = !IsWatchingEnemy;
		}
	}

	private void InitMakeWarBtn()
	{
		bool visible = false;
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode5() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode7())
		{
			bool flag = _level.Chapter.Type == ChapterType.StoryMain;
			bool flag2 = _level.Chapter.ChapterId == "C1001";
			if (flag && flag2)
			{
				string levelId = _level.LevelId;
				Match match = Regex.Match(levelId, "\\d+");
				if (match.Success)
				{
					int num = int.Parse(match.Value);
					List<GuideMode5SpecialLevel> config = GuideMode5SpecialLevel.GetConfig();
					foreach (GuideMode5SpecialLevel item in config)
					{
						if (item.LevelIndex >= num)
						{
							visible = true;
							if (item.LevelIndex == num)
							{
								((GObject)MakeWarBtn.nextRewardInfo.infoText).text = "MakeWarNextRewardTip1".ToLanguage();
								break;
							}
							int num2 = item.LevelIndex - num + 1;
							((GObject)MakeWarBtn.nextRewardInfo.infoText).text = "MakeWarNextRewardTip2".ToLanguage().Format(num2);
							break;
						}
					}
				}
			}
		}
		((GObject)MakeWarBtn.nextRewardInfo).visible = visible;
	}

	public IEnumerator HideFormationItemBtn(bool isEnemy)
	{
		IsWatchingEnemy = isEnemy;
		UpdateMakeWarBtnVisibility();
		if (_level.Chapter.Type == ChapterType.TreasureHunt)
		{
			((GObject)OpenPresetBtn).visible = !isEnemy;
		}
		((GObject)CampBtn).visible = !IsP1130;
		bool OpenFormationVisible = ((!isEnemy) ? SetOpenFormationBtnStatus() : SetOpenFormationBtnStatus(2));
		((GObject)FormationList).visible = OpenFormationVisible;
		if (!battleStartedOnCombatDataIsNull)
		{
			for (int i = 0; i < _formationItemBtns.Count; i++)
			{
				((GObject)_formationItemBtns[i]).visible = !isEnemy;
			}
		}
		if (redBossBtn != null)
		{
			((GObject)redBossBtn).visible = !isEnemy;
		}
		for (int j = 0; j < _EnmeyFormationItemBtns.Count; j++)
		{
			if (_EnmeyFormationItemBtns[j] != null)
			{
				((GObject)_EnmeyFormationItemBtns[j]).visible = isEnemy;
			}
		}
		if (GameController.Contexts.gameState.hasReplayState && GameController.Contexts.gameState.replayState.value == 1)
		{
			yield break;
		}
		BattleConfigComponent battleConfig = null;
		for (int k = 0; k < 100; k++)
		{
			if (GameController.Contexts.config.hasBattleConfig)
			{
				break;
			}
			yield return (object)new WaitForSeconds(0.1f);
		}
		if (GameController.Contexts.config.hasBattleConfig)
		{
			battleConfig = GameController.Contexts.config.battleConfig;
			for (int l = 0; l < 50; l++)
			{
				if (battleConfig.Red.IsUnitRefreshed)
				{
					break;
				}
				yield return (object)new WaitForSeconds(0.1f);
			}
		}
		if (isEnemy)
		{
			((GObject)CombatPowerName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText122") + LanguagesManager.Colon;
			((GObject)CombatPower).text = ((_level.Chapter.Type == ChapterType.RepeatableInstanceDefensive) ? _level.Chapter.RecommendPower.ToString() : battleConfig?.Blue.CombatPower[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex].ToString());
			if (IsP1130)
			{
				((GObject)CombatPower).text = "????????";
			}
			CombatPower.color = Color32.op_Implicit(new Color32((byte)243, (byte)98, (byte)51, byte.MaxValue));
			CombatPowerName.color = Color32.op_Implicit(new Color32((byte)243, (byte)98, (byte)51, byte.MaxValue));
		}
		else
		{
			((GObject)CombatPowerName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText123") + LanguagesManager.Colon;
			int curRedTeamCombatPower = 0;
			if (battleConfig != null)
			{
				curRedTeamCombatPower = battleConfig.Red.CombatPower[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex];
			}
			if (((GObject)CombatPower).data != null)
			{
				int oldCombatPower = (int)((GObject)CombatPower).data;
				if (oldCombatPower < curRedTeamCombatPower)
				{
					CombatPowerIncrease.Play();
					CombatPowerIncrease.SetHook("SfxPoint", (TransitionHook)delegate
					{
						//IL_0016: Unknown result type (might be due to invalid IL or missing references)
						//IL_004b: Unknown result type (might be due to invalid IL or missing references)
						FGUIManager.Instance.AddTextSpecialEffects(CombatPowerSfxBack, FGUIManager.Instance.uiGreen, Vector3.zero);
						FGUIManager.Instance.AddTextSpecialEffects(combatArrowSfxBack, "ui_arrow_green_up", new Vector3(100f, 100f, 100f));
					});
				}
				else if (oldCombatPower > curRedTeamCombatPower)
				{
					CombatPowerReduce.Play();
					CombatPowerReduce.SetHook("SfxPoint", (TransitionHook)delegate
					{
						//IL_0016: Unknown result type (might be due to invalid IL or missing references)
						//IL_004b: Unknown result type (might be due to invalid IL or missing references)
						FGUIManager.Instance.AddTextSpecialEffects(CombatPowerSfxBack, FGUIManager.Instance.uiRed, Vector3.zero);
						FGUIManager.Instance.AddTextSpecialEffects(combatArrowSfxBack, "ui_arrow_red_down", new Vector3(100f, 100f, 100f));
					});
				}
			}
			((GObject)CombatPower).text = curRedTeamCombatPower.ToString();
			((GObject)CombatPower).data = curRedTeamCombatPower;
			CombatPower.color = Color32.op_Implicit(new Color32(byte.MaxValue, (byte)251, (byte)186, byte.MaxValue));
			CombatPowerName.color = Color32.op_Implicit(new Color32(byte.MaxValue, (byte)251, (byte)186, byte.MaxValue));
		}
		((GObject)CombatPower).visible = true;
		((GObject)CombatPowerName).visible = true;
	}

	public void HideAll()
	{
		((GObject)MakeWarBtn).visible = false;
		((GObject)CampBtn).visible = false;
		((GObject)OpenPresetBtn).visible = false;
		SetOpenFormationBtnStatus(2);
		if (_level.BattleMode == BattleMode.DefenceMode)
		{
			((GObject)PlaceSoldierLimitTip).visible = false;
		}
		((GObject)FormationList).visible = false;
		for (int i = 0; i < _formationItemBtns.Count; i++)
		{
			((GObject)_formationItemBtns[i]).visible = false;
		}
		if (redBossBtn != null)
		{
			((GObject)redBossBtn).visible = false;
		}
		for (int j = 0; j < _EnmeyFormationItemBtns.Count; j++)
		{
			if (_EnmeyFormationItemBtns[j] != null)
			{
				((GObject)_EnmeyFormationItemBtns[j]).visible = false;
			}
		}
		((GObject)CombatPower).visible = false;
		((GObject)CombatPowerName).visible = false;
	}

	public void FormationListRender(int index, GObject gObject)
	{
		GButton asButton = gObject.asButton;
		Formation formation = TotalFormations[index];
		asButton.title = formation.Id;
		((GObject)((GComponent)asButton).GetChild("Name_t").asTextField).text = formation.Name;
		((GObject)((GComponent)asButton).GetChild("Level").asTextField).text = "1" + LanguagesManager.GetDesc("CsharpCodeZhTcText124");
		((GComponent)asButton).GetChild("Icon").asLoader.url = "ui://Battle/" + formation.Icon;
		((GObject)((GComponent)asButton).GetChild("heightLightGroup").asGroup).visible = ((GObject)FormationList).data.ToString() == formation.Id;
		((GObject)asButton).grayed = false;
		((GObject)asButton).touchable = true;
		if (currentFormation == formation.Id)
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 2;
		}
		else if (UnlockFormations.Contains(formation.Id))
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 1;
		}
		else
		{
			((GComponent)asButton).GetController("Status").selectedIndex = 0;
		}
		((UI_FormationItem)(object)asButton).SetControllerPageText(((GComponent)asButton).GetController("Status").selectedIndex);
	}

	public async void OnFormationChange(EventContext context)
	{
		ResetSoftGuideClick();
		string formationId = ((GButton)context.data).title;
		((GObject)FormationList).data = formationId;
		FormationList.itemRenderer = new ListItemRenderer(FormationListRender);
		FormationList.numItems = TotalFormations.Count;
		RegisterFormationGuideUi();
		OpenFormationBtnRender();
		Activity activity = await GameManagers.Instance.ActivityManager.GetLevelActivityAsync(_level);
		string formationContext = ((activity == null) ? _level.FormationContext : activity.FormationTag);
		Dictionary<string, Dictionary<string, string>> formationConfig = GameController.Contexts.config.currentFormation.value;
		if (!formationConfig.TryGetValue(formationContext, out var formationByMode))
		{
			formationByMode = new Dictionary<string, string>();
			formationConfig.Add(formationContext, formationByMode);
		}
		string mode = _level.BattleMode.ToString();
		if (formationByMode.ContainsKey(mode))
		{
			formationByMode[mode] = formationId;
		}
		else
		{
			formationByMode.Add(mode, formationId);
		}
		GameManagers.Instance.UserArchiveManager.SetCurrentFormation(formationContext, mode, formationId);
		GameController.Contexts.config.ReplaceCurrentFormation(formationConfig);
	}

	private void OpenFormationBtnInitData(string formationId)
	{
		GDEFormationData gDEFormationData = GDMgr.Get<GDEFormationData>(formationId);
		((GObject)OpenFormationBtn.Content.title).text = formationId;
		((GObject)((GComponent)OpenFormationBtn.Content).GetChild("Name_t").asTextField).text = gDEFormationData.Name;
		((GObject)((GComponent)OpenFormationBtn.Content).GetChild("Describe").asTextField).text = gDEFormationData.Description;
		((GObject)((GComponent)OpenFormationBtn.Content).GetChild("Level").asTextField).text = "1" + LanguagesManager.GetDesc("CsharpCodeZhTcText124");
		((GComponent)OpenFormationBtn.Content).GetChild("Icon").asLoader.url = "ui://Battle/" + gDEFormationData.Icon;
	}

	public void SetFormationItemBtnPos()
	{
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Expected O, but got Unknown
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected O, but got Unknown
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		if (IsStartWarSuccess)
		{
			return;
		}
		if (_CacheformationPos == null)
		{
			_CacheformationPos = new Dictionary<int, Vec3>();
		}
		ICameraService cameraService = GameController.Contexts.Service<ICameraService>();
		Vector3 position = default(Vector3);
		for (int i = 0; i < _formationItemBtns.Count; i++)
		{
			if (((GObject)_formationItemBtns[i]).alpha != 0f)
			{
				if (!_CacheformationPos.ContainsKey(i))
				{
					Vector3 val = Vector3.op_Implicit(GameController.Contexts.Service<IStagingService>().GetStagingAreaPosition_PortalIndex(Team.Red, i));
					_CacheformationPos.Add(i, new Vec3(val.x, val.y, val.z));
				}
				((Vector3)(ref position))._002Ector(_CacheformationPos[i].x, _CacheformationPos[i].y, _CacheformationPos[i].z);
				Vector2 val2 = Vector2.op_Implicit(cameraService.WorldToScreenPoint(position));
				val2.y = (float)Screen.height - val2.y;
				Vector2 val3 = ((GObject)GRoot.inst).GlobalToLocal(Vector2.op_Implicit(val2));
				float num = FGUIManager.Instance.ScreenAmendY();
				val3.y -= num;
				((GObject)_formationItemBtns[i]).visible = !battleStartedOnCombatDataIsNull;
				((GObject)_formationItemBtns[i]).SetXY(val3.x, val3.y);
			}
		}
		if (redBossBtn != null)
		{
			((GObject)redBossBtn).visible = true;
		}
		for (int j = 0; j < _EnmeyFormationItemBtns.Count; j++)
		{
			if (_EnmeyFormationItemBtns[j] != null)
			{
				((GObject)_EnmeyFormationItemBtns[j]).visible = false;
			}
		}
		BattleConfigComponent battleConfig = GameController.Contexts.config.battleConfig;
		if (string.IsNullOrWhiteSpace(battleConfig.Red.BossId[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex]))
		{
			return;
		}
		Vector3 campPosition = ClientBattleFieldLogic.GetCampPosition(Team.Red, _level.Data.Length);
		Vector3 val4 = Camera.main.WorldToScreenPoint(Vector3.op_Implicit(campPosition));
		val4.y = (float)Screen.height - val4.y;
		Vector2 val5 = ((GObject)GRoot.inst).GlobalToLocal(Vector2.op_Implicit(val4));
		float num2 = FGUIManager.Instance.ScreenAmendY();
		val5.y -= num2;
		if (redBossBtn == null)
		{
			redBossBtn = new GGraph();
			((GObject)redBossBtn).SetPivot(0.5f, 0.5f, true);
			((GObject)redBossBtn).SetSize(200f, 200f);
			redBossBtn.DrawRect(200f, 200f, 0, Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)0)), Color32.op_Implicit(new Color32((byte)101, (byte)101, (byte)101, (byte)0)));
			((GComponent)this).AddChild((GObject)(object)redBossBtn);
			((GObject)redBossBtn).visible = false;
			((GObject)redBossBtn).onClick.Add((EventCallback0)delegate
			{
				OpenBossInfoPanel(battleConfig.Red.BossId[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex], battleConfig.Red.Boss[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex]);
			});
		}
		if (redBossBtn != null)
		{
			((GObject)redBossBtn).visible = true;
			((GObject)redBossBtn).touchable = true;
			((GObject)redBossBtn).SetXY(val5.x, val5.y);
		}
	}

	public void SetEnmeyFormationBtnPos()
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		BattleConfigComponent battleConfig = GameController.Contexts.config.battleConfig;
		int num = 0;
		if (!string.IsNullOrWhiteSpace(battleConfig.Blue.BossId[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex]))
		{
			num = 1;
			if (_level.BattleMode == BattleMode.MultiWaveAttackMode || IsP1130)
			{
				num = 0;
			}
			Vector3 campPosition = ClientBattleFieldLogic.GetCampPosition(Team.Blue, _level.Data.Length);
			Vector2 val = Vector2.op_Implicit(GameController.Contexts.Service<ICameraService>().WorldToScreenPoint(campPosition));
			val.y = (float)Screen.height - val.y;
			Vector2 val2 = ((GObject)GRoot.inst).GlobalToLocal(Vector2.op_Implicit(val));
			float num2 = FGUIManager.Instance.ScreenAmendY();
			val2.y -= num2;
			int index = 0;
			if (_level.BattleMode != BattleMode.MultiWaveAttackMode && !IsP1130)
			{
				((GObject)_EnmeyFormationItemBtns[index]).visible = true;
				((GObject)_EnmeyFormationItemBtns[index]).SetXY(val2.x, val2.y);
				((GObject)_EnmeyFormationItemBtns[index]).onClick.Set((EventCallback0)delegate
				{
					OpenBossInfoPanel(battleConfig.Blue.BossId[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex], battleConfig.Blue.Boss[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex]);
				});
			}
			else
			{
				UI_FormationItemBtn uI_FormationItemBtn = _EnmeyFormationItemBtns[_EnmeyFormationItemBtns.Count - 1];
				if (uI_FormationItemBtn != null)
				{
					((GObject)uI_FormationItemBtn).SetXY(val2.x, val2.y);
				}
			}
		}
		List<List<string>> unitsId = battleConfig.Blue.UnitsId;
		int count = unitsId.First().Count;
		for (int num3 = num; num3 < _EnmeyFormationItemBtns.Count; num3++)
		{
			if (_EnmeyFormationItemBtns[num3] != null && num3 < 12)
			{
				Vector3 stagingAreaPosition = GameController.Contexts.Service<IStagingService>().GetStagingAreaPosition(Team.Blue, num3 - num);
				Vector2 val3 = Vector2.op_Implicit(GameController.Contexts.Service<ICameraService>().WorldToScreenPoint(stagingAreaPosition));
				val3.y = (float)Screen.height - val3.y;
				Vector2 val4 = ((GObject)GRoot.inst).GlobalToLocal(Vector2.op_Implicit(val3));
				float num4 = FGUIManager.Instance.ScreenAmendY();
				val4.y -= num4;
				if (count - 1 >= num3 - num && !string.IsNullOrWhiteSpace(unitsId[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex][num3 - num]))
				{
					((GObject)_EnmeyFormationItemBtns[num3]).visible = true;
					((GObject)_EnmeyFormationItemBtns[num3]).SetXY(val4.x, val4.y);
				}
			}
		}
	}

	public void CurrentTotalGainListData()
	{
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_046d: Expected O, but got Unknown
		CampInfoWindow.CurrentTotalGainList.RemoveChildrenToPool();
		int num = 0;
		foreach (KeyValuePair<string, float> formattedAutoProduction in GameManagers.Instance.UserArchiveManager.GetFormattedAutoProductions())
		{
			string itemId = formattedAutoProduction.Key;
			CampInfoWindow.CurrentTotalGainList.AddItemFromPool();
			GButton asButton = ((GComponent)((GComponent)CampInfoWindow.CurrentTotalGainList).GetChildAt(num).asButton).GetChild("itemBtn").asButton;
			((GObject)asButton).touchable = false;
			((GObject)((GComponent)asButton).GetChild("title").asTextField).visible = false;
			((GObject)((GComponent)asButton).GetChild("name").asTextField).visible = false;
			((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(itemId);
			int num2 = Shift.Legion.Common.Models.Item.Level(GameManagers.Instance, itemId);
			int num3 = ((num2 > 0) ? num2 : 4);
			((GComponent)asButton).GetChild("frame").asLoader.url = $"ui://PublicResources/kuang_round 2_lv{num3}";
			((GObject)((GComponent)((GComponent)CampInfoWindow.CurrentTotalGainList).GetChildAt(num).asButton).GetChild("description").asTextField).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId) + LanguagesManager.GetDesc("CsharpCodeZhTcText104");
			((GObject)((GComponent)((GComponent)CampInfoWindow.CurrentTotalGainList).GetChildAt(num).asButton).GetChild("Amount").asTextField).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(formattedAutoProduction.Value.ToString());
			((GComponent)((GComponent)CampInfoWindow.CurrentTotalGainList).GetChildAt(num).asButton).GetChild("FrameLoader").visible = true;
			((GComponent)((GComponent)CampInfoWindow.CurrentTotalGainList).GetChildAt(num).asButton).GetChild("FrameLoader").onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
			if (formattedAutoProduction.Key == "Money")
			{
				float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("AutoProduceEfficiency");
				bool flag = GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("PrimeContract") > 0;
				if (percentFloatPayload > 0f || flag)
				{
					string text = "";
					int num4 = 0;
					text = ((percentFloatPayload > 0f && !flag) ? (LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(formattedAutoProduction.Value / (1f + percentFloatPayload)))) : ((!(percentFloatPayload <= 0f && flag)) ? (LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(formattedAutoProduction.Value / (2f + percentFloatPayload)))) : (LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(formattedAutoProduction.Value / 2f)))));
					((GComponent)((GComponent)CampInfoWindow.CurrentTotalGainList).GetChildAt(num).asButton).GetChild("ExclamationMarkBtn").visible = true;
					((GComponent)((GComponent)CampInfoWindow.CurrentTotalGainList).GetChildAt(num).asButton).GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
					{
						{ "Title", text },
						{
							"Pos",
							(object)new Vector2(960f, 460f)
						}
					};
					((GComponent)((GComponent)CampInfoWindow.CurrentTotalGainList).GetChildAt(num).asButton).GetChild("ExclamationMarkBtn").onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
				}
				else
				{
					((GComponent)((GComponent)CampInfoWindow.CurrentTotalGainList).GetChildAt(num).asButton).GetChild("ExclamationMarkBtn").visible = false;
				}
			}
		}
	}

	public void EnemyInfoListData()
	{
		if (_level == null)
		{
			return;
		}
		int index = 0;
		_enemyInfoList.RemoveChildrenToPool();
		for (int i = 0; i < 5; i++)
		{
			if (!string.IsNullOrEmpty(_enemyIds[i]))
			{
				_enemyInfoList.AddItemFromPool();
				GameEntityData data = GameEntityData.GetEntityData(GameManagers.Instance, _enemyIds[i]);
				AssetsManager.Instance.LoadAsset<Texture2D>(data.Icon).Then((Action<Texture2D>)delegate(Texture2D asset)
				{
					//IL_0036: Unknown result type (might be due to invalid IL or missing references)
					//IL_0040: Expected O, but got Unknown
					((GComponent)_enemyInfoList).GetChildAt(index).asCom.GetChild("IconLoader").asLoader.texture = new NTexture((Texture)(object)asset);
					textureList.Add(data.Icon);
				});
				((GObject)((GComponent)_enemyInfoList).GetChildAt(index).asCom.GetChild("IconLoader").asLoader).data = "nihao";
				((GObject)((GComponent)_enemyInfoList).GetChildAt(index).asCom.GetChild("Boss").asTextField).text = "";
				((GObject)((GComponent)_enemyInfoList).GetChildAt(index).asCom).data = _enemyIds[i];
				int num = index;
				index = num + 1;
			}
		}
	}

	public void RewardsListData()
	{
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected O, but got Unknown
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Expected O, but got Unknown
		IntrinsicRewardsData();
		CampInfoWindow.CampGainList.RemoveChildrenToPool();
		int num = 0;
		Level level = GameController.Contexts.Service<IBattleFieldService>().Level;
		foreach (KeyValuePair<string, float> item in level.FormattedAutoProduceBonus(GameManagers.Instance))
		{
			string itemId = item.Key;
			CampInfoWindow.CampGainList.AddItemFromPool();
			GButton asButton = ((GComponent)((GComponent)CampInfoWindow.CampGainList).GetChildAt(num).asButton).GetChild("itemBtn").asButton;
			((GObject)asButton).touchable = false;
			((GObject)((GComponent)asButton).GetChild("title").asTextField).visible = false;
			((GObject)((GComponent)asButton).GetChild("name").asTextField).visible = false;
			((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(itemId);
			int num2 = Shift.Legion.Common.Models.Item.Level(GameManagers.Instance, itemId);
			int num3 = ((num2 > 0) ? num2 : 4);
			((GComponent)asButton).GetChild("frame").asLoader.url = $"ui://PublicResources/kuang_round 2_lv{num3}";
			((GObject)((GComponent)((GComponent)CampInfoWindow.CampGainList).GetChildAt(num).asButton).GetChild("description").asTextField).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId) + LanguagesManager.GetDesc("CsharpCodeZhTcText104");
			float levelMoneyOutput = UiHelper.GetLevelMoneyOutput(level.LevelId);
			((GObject)((GComponent)((GComponent)CampInfoWindow.CampGainList).GetChildAt(num).asButton).GetChild("Amount").asTextField).text = $"+{Convert.ToInt32(levelMoneyOutput)}";
			((GComponent)((GComponent)CampInfoWindow.CampGainList).GetChildAt(num).asButton).GetChild("FrameLoader").visible = true;
			((GComponent)((GComponent)CampInfoWindow.CampGainList).GetChildAt(num).asButton).GetChild("FrameLoader").onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
			if (!(itemId == "Money"))
			{
				continue;
			}
			float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("AutoProduceEfficiency");
			float value = levelMoneyOutput / (1f + percentFloatPayload);
			if (percentFloatPayload > 0f)
			{
				string value2 = "";
				if (percentFloatPayload > 1f)
				{
					value2 = LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(value));
				}
				else if (percentFloatPayload >= 1f)
				{
					value2 = LanguagesManager.GetDesc("CsharpCodeZhTcText106") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(value));
				}
				else if (percentFloatPayload > 0f)
				{
					value2 = LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1}/h", LanguagesManager.GetDesc("CsharpCodeZhTcText125"), Convert.ToInt32(value));
				}
				((GComponent)((GComponent)CampInfoWindow.CampGainList).GetChildAt(num).asButton).GetChild("ExclamationMarkBtn").visible = true;
				((GComponent)((GComponent)CampInfoWindow.CampGainList).GetChildAt(num).asButton).GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
				{
					{ "Title", value2 },
					{
						"Pos",
						(object)new Vector2(960f, 460f)
					}
				};
				((GComponent)((GComponent)CampInfoWindow.CampGainList).GetChildAt(num).asButton).GetChild("ExclamationMarkBtn").onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
			}
			else
			{
				((GComponent)((GComponent)CampInfoWindow.CampGainList).GetChildAt(num).asButton).GetChild("ExclamationMarkBtn").visible = false;
			}
		}
	}

	public void FormationBtnClicked()
	{
		if (!((GObject)OpenFormationBtn.Content).visible)
		{
			return;
		}
		if (unitChanged && OpenFormationControll.selectedIndex != 0 && currentFormation != ((GObject)FormationList).data.ToString() && UnlockFormations.Contains(((GObject)FormationList).data.ToString()))
		{
			ShowChangeFormationTip();
			return;
		}
		if (((GObject)OpenFormationBtn.note).visible)
		{
			((GObject)OpenFormationBtn.note).visible = false;
		}
		RestoreFormation();
		((GObject)FormationMask).visible = OpenFormationControll.selectedIndex == 0;
		int selectedIndex = ((OpenFormationControll.selectedIndex == 0) ? 1 : 0);
		OpenFormationControll.selectedIndex = selectedIndex;
		_formationInfoControll.SetSelectedIndex((_formationInfoControll.selectedIndex == 0) ? 1 : 0);
		OpenFormationBtnRender();
	}

	private async void RestoreFormation()
	{
		if (OpenFormationControll.selectedIndex != 0 && currentFormation != ((GObject)FormationList).data.ToString())
		{
			((GObject)FormationList).data = currentFormation;
			OpenFormationBtnInitData(currentFormation);
			FormationList.itemRenderer = new ListItemRenderer(FormationListRender);
			FormationList.numItems = TotalFormations.Count;
			RegisterFormationGuideUi();
			Activity activity = await GameManagers.Instance.ActivityManager.GetLevelActivityAsync(_level);
			string formationContext = ((activity == null) ? _level.FormationContext : activity.FormationTag);
			Dictionary<string, Dictionary<string, string>> formationConfig = GameController.Contexts.config.currentFormation.value;
			if (!formationConfig.TryGetValue(formationContext, out var formationByMode))
			{
				formationByMode = new Dictionary<string, string>();
				formationConfig.Add(formationContext, formationByMode);
			}
			string mode = _level.BattleMode.ToString();
			if (formationByMode.ContainsKey(mode))
			{
				formationByMode[mode] = currentFormation;
			}
			else
			{
				formationByMode.Add(mode, currentFormation);
			}
			GameManagers.Instance.UserArchiveManager.SetCurrentFormation(formationContext, mode, currentFormation);
			GameController.Contexts.config.ReplaceCurrentFormation(formationConfig);
		}
	}

	public void BackToCityBtnClicked()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)BackToCityBtn).onClick.Remove(new EventCallback0(BackToCityBtnClicked));
		RestoreFormation();
		if (_level.LevelId == LegendItemDungeonUiHelper.CurLevelId)
		{
			LegendItemDungeonUiHelper.CurLevelId = "";
		}
		CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
		{
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{
				"LoadingAnimationDirection",
				LoadingAnimationDirection.Left
			},
			{ "OpenUiOnReturn", _level.FromUi },
			{ "UiParamsOnReturn", _level.FromUiParams }
		}));
		SetRedTeamCampBindgWithCamera();
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		GameLocalDataManager.ClearReplayCache();
	}

	public void HpSwitchBtnClicked()
	{
		GameController.Contexts.config.ReplaceHealBarSwitcher(!GameController.Contexts.config.healBarSwitcher.value);
	}

	public void StartBattleBtnClicked(EventContext eventContext)
	{
		StopSoftGuideClick();
		if (RankDataHelper.IsPvPLevel(_level.LevelId))
		{
			ILRuntimeDebug.LogError($"{GameManagers.Instance.UserId} Click StartBattleBtn On {_level.LevelId}");
		}
		else if (!AnySoldierInFormation())
		{
			string[] array = new string[2]
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText107"),
				LanguagesManager.GetDesc("CsharpCodeZhTcText107")
			};
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { array[GameManagers.Instance.RandomManager.Int(array.Length)] }, 1, arg3: false);
		}
		else if (CanPlayDispatchTip() && (showSoldiersNumTip || showDispatchSoldierTip))
		{
			string text = "";
			if (showSoldiersNumTip && !showDispatchSoldierTip)
			{
				Action confirmAction = delegate
				{
					MakeWar(eventContext);
				};
				ShowStartBattleTipPanel(confirmAction);
				return;
			}
			text = LanguagesManager.GetDesc("CsharpCodeZhTcText126") + "[color=#FF1919]" + LanguagesManager.GetDesc("CsharpCodeZhTcText127") + "[/color]，" + LanguagesManager.GetDesc("CsharpCodeZhTcText128") + "？";
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					text ?? ""
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								MakeWar(eventContext);
							}
						},
						{
							"Cancel",
							delegate
							{
								PlayDispatchTip();
							}
						}
					}
				},
				{ "PageIndex", 0 },
				{ "ClickSound", "Confirm" },
				{ "Mirror", true },
				{
					"Order",
					((GObject)this).sortingOrder
				}
			});
		}
		else if (((GObject)CombatPower).data == null)
		{
			battleStartedOnCombatDataIsNull = true;
			MakeWar(eventContext);
		}
		else if (_level.Chapter.Type == ChapterType.RepeatableInstanceDefensive && (float)(int)((GObject)CombatPower).data < _level.Chapter.RecommendPower)
		{
			string text2 = LanguagesManager.GetDesc("CsharpCodeZhTcText129") + "！" + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText130") + "[color=#FF1919]" + LanguagesManager.GetDesc("CsharpCodeZhTcText131") + "[/color]，" + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText132") + "[color=#FF1919]" + LanguagesManager.GetDesc("CsharpCodeZhTcText133") + "[/color]" + LanguagesManager.GetDesc("CsharpCodeZhTcText134") + "！" + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText135") + "？";
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					text2 ?? ""
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								MakeWar(eventContext);
							}
						},
						{
							"Cancel",
							delegate
							{
							}
						}
					}
				},
				{ "PageIndex", 0 },
				{ "ClickSound", "Confirm" },
				{ "Mirror", true },
				{
					"Order",
					((GObject)this).sortingOrder
				}
			});
		}
		else if (!UiHelper.CombatCapabilityUpToPar(_level.LevelId, (int)((GObject)CombatPower).data, enemyCombatPower))
		{
			string text3 = LanguagesManager.GetDesc("CsharpCodeZhTcText136") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText137") + "[color=#ff1919]" + LanguagesManager.GetDesc("CsharpCodeZhTcText138") + "[/color]，" + LanguagesManager.GetDesc("CsharpCodeZhTcText128") + "？" + Environment.NewLine + "[size=32][color=#AFF627](" + LanguagesManager.GetDesc("CsharpCodeZhTcText139") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText140") + ")[/color][/size]";
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					text3 ?? ""
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								MakeWar(eventContext);
							}
						},
						{
							"Cancel",
							delegate
							{
							}
						}
					}
				},
				{ "PageIndex", 0 },
				{ "ClickSound", "Confirm" },
				{ "Mirror", true },
				{
					"Order",
					((GObject)this).sortingOrder
				}
			});
		}
		else
		{
			MakeWar(eventContext);
		}
		bool CanPlayDispatchTip()
		{
			if ((GameManagers.Instance.UserArchiveManager.IsNewGuideMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode3()) && _level.LevelId == "P101")
			{
				return false;
			}
			return _level.ChapterId != "C1000" && _level.ChapterId != "C10000" && _level.ChapterId != "C10001" && _level.ChapterId != "C1000" && _level.ChapterId != "C10002" && _level.BattleMode != BattleMode.DefenceMode;
		}
	}

	private void GoToRecruit()
	{
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode())
		{
			GameManagers.Instance.NewGuideMissionManager.MonoInstance.AddUiStory(new List<string> { "Story_GuideMission15a" });
		}
		else
		{
			OpenCamp();
		}
	}

	private void ShowStartBattleTipPanel(Action confirmAction)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		((GObject)StartBattleTipPanel).visible = true;
		((GObject)StartBattleTipPanel.Dialog.Confirm).onClick.Set((EventCallback0)delegate
		{
			confirmAction?.Invoke();
			((GObject)StartBattleTipPanel).visible = false;
		});
		((GObject)StartBattleTipPanel.Dialog.GoToRecruit).onClick.Set(new EventCallback0(GoToRecruit));
		((GObject)StartBattleTipPanel.Dialog.CloseBtn).onClick.Set((EventCallback0)delegate
		{
			PlayDispatchTip();
			((GObject)StartBattleTipPanel).visible = false;
		});
	}

	private void OpenCamp()
	{
		if (_level.ChapterId == "C1000" || _level.ChapterId == "C10000" || _level.ChapterId == "C10001" || _level.ChapterId == "C1000" || _level.ChapterId == "C10002")
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText108") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 120, arg3: false);
			return;
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType("10");
		if (buildingByType.Status == BuildingStatus.Banned)
		{
			List<string> arg2 = new List<string>
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
				LanguagesManager.GetDesc("CsharpCodeZhTcText22")
			};
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 120, arg3: false);
			return;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = "";
		if (buildingByType.Status == BuildingStatus.Ready)
		{
			dictionary.Add("Parent", this);
			dictionary.Add("Building", buildingByType);
			text = UI_UpGradePanel.Name;
		}
		else if (buildingByType.Level == 0)
		{
			dictionary.Add("Building", buildingByType);
			dictionary.Add("Parent", this);
			text = UI_UpGradePanel.Name;
		}
		else
		{
			text = UI_RecruitingCamp.Name;
		}
		CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
		{
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{
				"LoadingAnimationDirection",
				LoadingAnimationDirection.Left
			},
			{ "OpenUiOnReturn", text },
			{ "UiParamsOnReturn", dictionary }
		}));
	}

	private void PlayDispatchTip(bool loop = false)
	{
		GameStateContext gameState = GameController.Contexts.gameState;
		List<List<string>> unitsId = GameController.Contexts.config.battleConfig.Red.UnitsId;
		int num = 1;
		if (loop)
		{
			num = -1;
		}
		for (int i = 0; i < _formationItemBtns.Count; i++)
		{
			if (_levelAssistanceConfig != null && _levelAssistanceConfig.LockPosition.Contains(i + 1))
			{
				continue;
			}
			string text = unitsId[0][i];
			if (string.IsNullOrEmpty(text))
			{
				((GObject)_formationItemBtns[i].UnitNumberInfo).text = string.Empty;
				if (!string.IsNullOrWhiteSpace(((GObject)_formationItemBtns[i].UnlcokTip).text))
				{
					_formationItemBtns[i].Status.selectedIndex = 1;
					if (((GComponent)_formationItemBtns[i]).GetTransition("Breath").playing)
					{
						((GComponent)_formationItemBtns[i]).GetTransition("Breath").Stop();
					}
				}
				else
				{
					if (((GComponent)_formationItemBtns[i]).GetTransition("Breath").playing)
					{
						((GComponent)_formationItemBtns[i]).GetTransition("Breath").Stop();
					}
					((GComponent)_formationItemBtns[i]).GetTransition("Breath").Play(num, 0f, (PlayCompleteCallback)null);
				}
				continue;
			}
			if (((GComponent)_formationItemBtns[i]).GetTransition("numTip").playing)
			{
				((GComponent)_formationItemBtns[i]).GetTransition("numTip").Stop();
			}
			int num2 = GameManagers.Instance.StockController.GetStock(text);
			int soldierLevel = GameManagers.Instance.UserArchiveManager.GetSoldierLevel(text);
			int num3 = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(text, soldierLevel);
			if (_level.BattleMode == BattleMode.MultiWaveAttackMode && ChangePageControll.selectedIndex == 1)
			{
				Dictionary<string, int> unitsPool = GameController.Contexts.config.battleConfig.Red.UnitsPool;
				Dictionary<string, int> unitsBorn = GameController.Contexts.config.battleConfig.Red.UnitsBorn;
				int num4 = 0;
				int num5 = 0;
				if (unitsPool != null && unitsBorn != null)
				{
					foreach (KeyValuePair<string, int> item in unitsPool)
					{
						if (item.Key == text)
						{
							num4 = item.Value;
							break;
						}
					}
					foreach (KeyValuePair<string, int> item2 in unitsBorn)
					{
						if (item2.Key == text)
						{
							num5 = item2.Value;
							break;
						}
					}
					num2 = num4 - num5;
				}
			}
			else if (ChangePageControll.selectedIndex == 0 || ChangePageControll.selectedIndex == 2)
			{
				num2 = (int)((GObject)_formationItemBtns[i].UnitNumberInfo).data;
			}
			if (_levelAssistanceConfig != null && _levelAssistanceConfig.AssistancePosition.Contains(i + 1))
			{
				int num6 = _levelAssistanceConfig.AssistancePosition.IndexOf(i + 1);
				if (num6 != -1)
				{
					num2 = _levelAssistanceConfig.AssistanceQty[num6];
					num3 = num2;
				}
			}
			if (num2 < num3)
			{
				_formationItemBtns[i].Status.selectedIndex = 0;
				((GComponent)_formationItemBtns[i]).GetTransition("numTip").Play(num, 0f, (PlayCompleteCallback)null);
				if (((GComponent)_formationItemBtns[i]).GetTransition("Breath").playing)
				{
					((GComponent)_formationItemBtns[i]).GetTransition("Breath").Stop();
				}
				((GComponent)_formationItemBtns[i]).GetTransition("Breath").Play(num, 0f, (PlayCompleteCallback)null);
			}
		}
	}

	private async void MakeWar(EventContext eventContext)
	{
		GameLocalDataManager.ClearLastReplayUserInfo();
		SetBattleUiUserInfo();
		OnBeginStartWar();
		string levelId = _level.LevelId;
		string levelBattleMode = _level.BattleMode.ToString();
		Activity activity = await GameManagers.Instance.ActivityManager.GetLevelActivityAsync(_level);
		if (dungeonInstanceChapterTypes.Contains(_level.Chapter.Type) && activity == null)
		{
			ILRuntimeDebug.LogError($"[GetLevelActivity]Wrong Result of GetLevelActivity, LevelId={_level.LevelId}, ChapterId={_level.ChapterId}, ChapterType={_level.Chapter.Type}");
		}
		string context = ((activity == null) ? _level.FormationContext : activity.FormationTag);
		string activityId = activity?.ActivityId;
		List<string> formationUnits = new List<string>(GameManagers.Instance.UserArchiveManager.GetBattleFormation(context, levelBattleMode).Values);
		ILRequestHelper<SyncFormationUnitsResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().SyncFormationUnits(-1L, context, _level.BattleMode.ToString(), formationUnits), delegate(SyncFormationUnitsResponse response)
		{
			if (levelId != _level.LevelId)
			{
				ILRequestHelper.ShowErrorCode(82100000);
				OnStartWarFailed();
			}
			else
			{
				Activity levelActivity = GameManagers.Instance.ActivityManager.GetLevelActivity(_level);
				if (activityId != levelActivity?.ActivityId)
				{
					ILRequestHelper.ShowErrorCode(82100001);
					OnStartWarFailed();
				}
				else
				{
					string text = ((levelActivity == null) ? _level.FormationContext : levelActivity.FormationTag);
					if (context != text)
					{
						ILRequestHelper.ShowErrorCode(82100002);
						OnStartWarFailed();
					}
					else if (!response.Result)
					{
						ILRequestHelper.ShowErrorCode(response.ErrorCode);
						OnStartWarFailed();
					}
					else
					{
						ILRequestHelper<StartBattleResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().StartBattle(-1L, _level.LevelId, null, null, null, quickBattle: false), delegate(StartBattleResponse startBattleResponse)
						{
							if (!startBattleResponse.Result)
							{
								ILRequestHelper.ShowErrorCode(startBattleResponse.ErrorCode);
								OnStartWarFailed();
							}
							else
							{
								SentrySdk.AddBreadcrumb("UI_Battle MakeWar Button Start Battle " + startBattleResponse.BattleId + ", " + _level.LevelId);
								OnStartWarSuccess();
								GameLocalDataManager.ClearReplayCache();
								ClientBattleFieldLogic.CleanChangeDifferentBattleConfig();
								OnStartBattleCompleted(startBattleResponse.BattleId);
								if (_level.Chapter.Type == ChapterType.TreasureHunt)
								{
									int lastFloorIndex = LegendItemDungeonUiHelper.GetLastFloorIndex(UI_LegendItemDungeonPanel.explorationState == ExplorationState.Completed);
									GameLocalDataManager.SetLastDungeonBattleMinLevel(lastFloorIndex);
								}
								if (_level.ChapterId == "C10000" || _level.ChapterId == "C10001")
								{
									if (!HotUpdateProcess.Instance.Configs.ContainsKey("QTE_FILTER"))
									{
										GameController.Contexts.Service<IUiService>().OpenPanel(UI_Battle_PauseSetEffect.Name, null);
									}
									else if (HotUpdateProcess.Instance.Configs["QTE_FILTER"] == "1" && GameManagers.Instance.UserId % 2 == 1)
									{
										GameController.Contexts.Service<IUiService>().OpenPanel(UI_Battle_PauseSetEffect.Name, null);
									}
								}
							}
						});
					}
				}
			}
		});
	}

	private void OnBeginStartWar()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		MakeWarBtn.CommonIdle.Stop();
		IsMakeWarBtnEfectPlaying = true;
		MakeWarBtn.CommonBegin.Play((PlayCompleteCallback)delegate
		{
			IsMakeWarBtnEfectPlaying = false;
			UpdateMakeWarBtnVisibility();
		});
	}

	private void OnStartWarSuccess()
	{
		IsStartWarSuccess = true;
		UpdateMakeWarBtnVisibility();
	}

	private void OnStartWarFailed()
	{
		MakeWarBtn.CommonBegin.Stop();
		MakeWarBtn.CommonBegin.Play(0, 0f, 0f, 0f, (PlayCompleteCallback)null);
		IsMakeWarBtnEfectPlaying = false;
		((GObject)MakeWarBtn.n12).alpha = 1f;
		MakeWarBtn.CommonIdle.Play(-1, 0f, (PlayCompleteCallback)null);
		IsStartWarSuccess = false;
		UpdateMakeWarBtnVisibility();
	}

	private void SetRankUiType()
	{
		SetReplayUiType();
	}

	private void SetReplayUiType(bool hideMakeWar = true)
	{
		IsSetReplayUiType = true;
		UpdateMakeWarBtnVisibility();
		((GObject)OpenPresetBtn).visible = false;
		SetOpenFormationBtnStatus(2);
		((GObject)FormationList).visible = false;
		((GObject)CampBtn).visible = false;
		SetScoutBtnVisible(isVisible: false);
		((GObject)StrategyGuide).visible = false;
		for (int i = 0; i < _formationItemBtns.Count; i++)
		{
			((GObject)_formationItemBtns[i]).visible = false;
		}
		if (redBossBtn != null)
		{
			((GObject)redBossBtn).visible = false;
		}
		for (int j = 0; j < _EnmeyFormationItemBtns.Count; j++)
		{
			if (_EnmeyFormationItemBtns[j] != null)
			{
				((GObject)_EnmeyFormationItemBtns[j]).visible = false;
			}
		}
		ChangePageControll.selectedIndex = 1;
		SetGvGBattleReplayUiType();
	}

	private void SetGvGBattleReplayUiType()
	{
		if (IsGvGLevel || GvG3BossBattle)
		{
			((GObject)OurInfomationBar).visible = false;
			((GObject)EnemyInfomationBar).visible = false;
			((GObject)timingGroup).visible = false;
			((GObject)GvGBossHpBar).visible = true;
			((GObject)GvGCountDown).visible = true;
			((GObject)GvGBossTotalDamage).visible = true;
			RenderGvGBossInfo();
			UpdateGvGTime(UiHelper.ParseTime(_curLevelTimeLimit));
			GvGBossHpBar.BossHpBar.BossHpBarInit();
		}
	}

	private void UpdateTotalDamage(GvGBossHealthInfo healthInfo)
	{
		bool flag = (bool)((GObject)GvGBossTotalDamage).data;
		if (healthInfo.TotalDamage >= 1 && !flag)
		{
			((GObject)GvGBossTotalDamage).TweenFade(1f, 0.1f);
			((GObject)GvGBossTotalDamage).data = true;
		}
		((GObject)GvGBossTotalDamage.Damage).text = $"{healthInfo.TotalDamage}";
		SwitchSfxByDamage(healthInfo.TotalDamage);
		if (healthInfo.HpCount >= 0 && ((GObject)GvGBossHpBar).alpha <= 0f)
		{
			((GObject)GvGBossHpBar).TweenFade(1f, 0.1f);
		}
		GvGBossHpBar.BossHpBar.UpdateBossHpBarCount(healthInfo.HpCount, GvGBossHpBar.HpBarCount);
	}

	private void SwitchSfxByDamage(long damage)
	{
		if (damage <= 500000)
		{
			GvGBossTotalDamage.SfxController.selectedIndex = 0;
		}
		else if (damage <= 1000000)
		{
			GvGBossTotalDamage.SfxController.selectedIndex = 1;
		}
		else if (damage <= 2500000)
		{
			GvGBossTotalDamage.SfxController.selectedIndex = 2;
		}
		else if (damage <= 5000000)
		{
			GvGBossTotalDamage.SfxController.selectedIndex = 3;
		}
		else if (damage <= 10000000)
		{
			GvGBossTotalDamage.SfxController.selectedIndex = 4;
		}
		else
		{
			GvGBossTotalDamage.SfxController.selectedIndex = 5;
		}
	}

	private void UpdateGvGBossHpValue(float currentValue)
	{
		if (IsGvGLevel || GvG3BossBattle)
		{
			GvGBossHpBar.BossHpBar.UpdateBossHpBarValue(currentValue);
		}
	}

	private void UpdateGvGTime(string countDownValue)
	{
		if (IsGvGLevel || GvG3BossBattle)
		{
			((GObject)GvGCountDown.Time).text = countDownValue;
		}
	}

	private void RenderGvGBossInfo()
	{
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		if (pvpEnemyInfo.IsUser)
		{
			GvGBossHpBar.BossIcon.BossAvatar.Type.selectedIndex = 0;
			((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, pvpEnemyInfo.UserId, GvGBossHpBar.BossIcon.BossAvatar.Iconloader, GvGBossHpBar.BossName));
		}
		else
		{
			GvGBossHpBar.BossIcon.BossAvatar.Type.selectedIndex = 1;
			GvGBossHpBar.BossIcon.BossAvatar.Iconloader.url = pvpEnemyInfo.NpcUrl;
			((GObject)GvGBossHpBar.BossName).text = pvpEnemyInfo.UserName;
		}
		((GObject)GvGBossTotalDamage).alpha = 0f;
		((GObject)GvGBossTotalDamage).data = false;
		((GObject)GvGBossHpBar).alpha = 0f;
		int num = (GvG3BossBattle ? Singleton<GvGMode3BattleRecordsManager>.Instance.RecordLevelInfo.BossLevel : GvGConfigHelper.RecordLevelInfo.WorldBossLevel);
		((GObject)GvGBossHpBar.BossLevel).text = $"Lv{num}";
		List<ItemAbility> list = (GvG3BossBattle ? Singleton<GvGMode3BattleRecordsManager>.Instance.RecordLevelInfo.Abilities : GvGConfigHelper.RecordLevelInfo.WorldBossDebuffItemAbilities);
		if (list == null)
		{
			return;
		}
		foreach (ItemAbility item in list)
		{
			int abilityLevel = item.AbilityLevel;
			UI_BossAbility bossBtn = (UI_BossAbility)(object)GvGBossHpBar.BossAbilitties.AddItemFromPool();
			if (bossBtn != null)
			{
				GDEAbilityData abilityData = item.AbilityData;
				((GObject)bossBtn.Title).text = $"Lv{abilityLevel}";
				bossBtn.Icon.url = item.Icon;
				((GObject)bossBtn).onClick.Set((EventCallback0)delegate
				{
					ShowSkillDetailPopup(abilityData, bossBtn.Icon.url, abilityLevel);
				});
			}
		}
	}

	public void ShowSkillDetailPopup(GDEAbilityData abilityData, string iconUrl, int level)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (abilityData != null)
		{
			Vector2 val = default(Vector2);
			((Vector2)(ref val))._002Ector(960f, 665f);
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "Pos", val },
				{ "Data", abilityData },
				{ "Limit", 0 },
				{ "State", true },
				{ "GList", null },
				{ "SkillIconUrl", iconUrl },
				{ "Level", level }
			};
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, parameters);
		}
	}

	private void OnStartBattleCompleted(string battleId)
	{
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		GameManagers.Instance.UserArchiveManager.SetCurrentBattleId(battleId);
		SetReplayUiType(hideMakeWar: false);
		if (_level.BattleMode == BattleMode.MultiWaveAttackMode)
		{
			SetOpenFormationBtnStatus();
			((GObject)FormationList).visible = true;
			for (int i = 0; i < _formationItemBtns.Count; i++)
			{
				((GObject)_formationItemBtns[i]).visible = !battleStartedOnCombatDataIsNull;
			}
			SetRedTeamCampBindgWithCamera();
			((GObject)offensiveProgressList).TweenMoveY(((GObject)offensiveProgressList).y - 150f, 0.33f);
			for (int num = TotalFormations.Count - 1; num >= 0; num--)
			{
				if (!UnlockFormations.Contains(TotalFormations[num].Id))
				{
					TotalFormations.RemoveAt(num);
				}
			}
			FormationList.itemRenderer = new ListItemRenderer(FormationListRender);
			FormationList.numItems = TotalFormations.Count;
			RegisterFormationGuideUi();
		}
		if (_level.BattleMode == BattleMode.DefenceMode)
		{
			((GObject)PlaceSoldierLimitTip).visible = false;
		}
		ClientBattleFieldLogic.StartBattle(GameController.Contexts, battleId);
		if (_level.Chapter.Type == ChapterType.RepeatableInstanceDefensive)
		{
			((GObject)MeterSwitch).visible = false;
			((GObject)tip).visible = false;
			foreach (KeyValuePair<int, GameObject> formationMark in FGUIManager.Instance.formationMarks)
			{
				((GObject)formationMark.Value.GetComponent<StagingArea>().haloCom).visible = false;
			}
		}
		List<string> value = GameManagers.Instance.AchievementManager.ActivatedLegendItemSets.GetValue();
		BattleConfig red = GameController.Contexts.config.battleConfig.Red;
		List<Shift.Legion.Common.Models.LegendItem.LegendItem> list = new List<Shift.Legion.Common.Models.LegendItem.LegendItem>();
		for (int j = 0; j < red.UnitsId[0].Count; j++)
		{
			string text = red.UnitsId[0][j];
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(text);
			if (gDESoldierData.IsPlayer)
			{
				List<Shift.Legion.Common.Models.LegendItem.LegendItem> soldierEquippedItemInstances = GameManagers.Instance.SoldierEquipmentManager.GetSoldierEquippedItemInstances(text);
				if (soldierEquippedItemInstances != null)
				{
					list.AddRange(soldierEquippedItemInstances);
				}
			}
		}
		Dictionary<string, HashSet<string>> dictionary = LegendItemManager.CountSetPieces(list);
		foreach (KeyValuePair<string, HashSet<string>> item in dictionary)
		{
			GDELegendItemSetData gDELegendItemSetData = GDMgr.Get<GDELegendItemSetData>(item.Key);
			if (gDELegendItemSetData != null && gDELegendItemSetData.SetPiecesQty <= item.Value.Count && !value.Contains(item.Key))
			{
				value.Add(item.Key);
			}
		}
		GameManagers.Instance.AchievementManager.ActivatedLegendItemSets.SetValue(value);
		SharedMessenger.Broadcast("LEGEND_ITEMS_CHANGED", 31);
		SharedMessenger.Broadcast("LEGEND_ITEMS_CHANGED", 36);
	}

	public void IntrinsicRewardsData()
	{
		CampInfoWindow.AwardList.RemoveChildrenToPool();
		int num = 0;
		List<KeyValuePair<Bonus, int>> levelBonus = GameController.Contexts.Service<IBattleFieldService>().Level.GetLevelBonus(GameManagers.Instance);
		foreach (KeyValuePair<Bonus, int> item in levelBonus)
		{
			Bonus key = item.Key;
			if (key.Qty > 0 && key.Type != 2)
			{
				CampInfoWindow.AwardList.AddItemFromPool();
				LaodV_DropListItems(num, key.ItemId, key.Qty);
				num++;
			}
		}
	}

	private void LaodV_DropListItems(int index, string image, int num)
	{
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		GButton asButton = ((GComponent)CampInfoWindow.AwardList).GetChildAt(index).asButton;
		GLoader asLoader = ((GComponent)asButton).GetChild("icon").asLoader;
		string itemId = image;
		if (itemId == "UserExp")
		{
			asLoader.url = "ui://PublicResources/icon_exp";
			if (GameManagers.Instance.ModifierManager.GetPercentFloatPayload("UserExpGain") > 0f)
			{
				((GComponent)asButton).GetChild("ExclamationMarkBtn").visible = true;
				((GTextField)((GComponent)asButton).GetChild("title").asRichTextField).color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, byte.MaxValue));
				((GComponent)asButton).GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
				{
					{
						"Title",
						LanguagesManager.GetDesc("CsharpCodeZhTcText109") + Environment.NewLine + string.Format("{0}：{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText142"), num)
					},
					{
						"Pos",
						(object)new Vector2(960f, 460f)
					}
				};
				((GComponent)asButton).GetChild("ExclamationMarkBtn").onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
				float value = (float)num * (1f + GameManagers.Instance.ModifierManager.GetPercentFloatPayload("UserExpGain"));
				((GComponent)asButton).GetChild("title").text = $"+{Convert.ToInt32(value)}";
			}
			else
			{
				((GComponent)asButton).GetChild("ExclamationMarkBtn").visible = false;
				((GTextField)((GComponent)asButton).GetChild("title").asRichTextField).color = Color32.op_Implicit(new Color32(byte.MaxValue, (byte)253, (byte)225, byte.MaxValue));
				asButton.title = $"+{num}";
			}
		}
		else
		{
			if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
			{
				FGUIManager.Instance.SetItemIconAndFrame(asLoader, itemId, textureList);
			}
			else
			{
				asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(image);
			}
			asButton.title = $"+{num}";
		}
		((GObject)asLoader).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
	}

	public void OnAnyTeamHealthPointsTotal(GameStateEntity entity, float redCurrent, float redTotal, float blueCurrent, float blueTotal)
	{
		float num = ((redTotal > 0f) ? (redCurrent / redTotal * 100f) : 0f);
		float num2 = ((blueTotal > 0f) ? (blueCurrent / blueTotal * 100f) : 0f);
		((GProgressBar)OurInfomationBar.HPBar).TweenValue((double)num, 0.1f);
		((GProgressBar)EnemyInfomationBar.HPBar).TweenValue((double)num2, 0.1f);
		if (FGUIManager.Instance.BothHealthBarValues.ContainsKey("RedHealthBarValue"))
		{
			FGUIManager.Instance.BothHealthBarValues["RedHealthBarValue"] = num;
		}
		else
		{
			FGUIManager.Instance.BothHealthBarValues.Add("RedHealthBarValue", num);
		}
		if (FGUIManager.Instance.BothHealthBarValues.ContainsKey("BlueHealthBarValue"))
		{
			FGUIManager.Instance.BothHealthBarValues["BlueHealthBarValue"] = num2;
		}
		else
		{
			FGUIManager.Instance.BothHealthBarValues.Add("BlueHealthBarValue", num2);
		}
		if (((GProgressBar)OurInfomationBar.HPBar).value <= 0.0)
		{
			((GObject)OurInfomationBar.HPBar.bar).visible = false;
		}
		else
		{
			((GObject)OurInfomationBar.HPBar.bar).visible = true;
		}
		if (((GProgressBar)EnemyInfomationBar.HPBar).value <= 0.0)
		{
			((GObject)EnemyInfomationBar.HPBar.bar).visible = false;
		}
		else
		{
			((GObject)EnemyInfomationBar.HPBar.bar).visible = true;
		}
		UpdateGvGBossHpValue(num2);
	}

	public void OnAnyCurrentLevelBattleStartedRemoved(GameStateEntity entity)
	{
		OnFormationUnitsChanged();
	}

	public void OnAnyLoadingPanelStatus(GameStateEntity entity, LoadingPanelStatus value)
	{
		switch (value)
		{
		case LoadingPanelStatus.Closed:
			SetCampBtnPos(isEnemy: false);
			OpenLastReplayList();
			DisplayMainCityEntrance();
			break;
		case LoadingPanelStatus.Opening:
			break;
		case LoadingPanelStatus.Showing:
			break;
		case LoadingPanelStatus.Closing:
			break;
		default:
			throw new ArgumentOutOfRangeException("value", value, null);
		}
	}

	public void OnAnyBattleTimeLeft(GameStateEntity entity, int value)
	{
		string text = UiHelper.ParseTime(value);
		((GObject)Timer).text = text;
		UpdateGvGTime(text);
	}

	private void ShowChangeFormationTip()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				LanguagesManager.GetDesc("CsharpCodeZhTcText143") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText144") + "？"
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
							((GObject)OpenFormationBtn.ChangeBtn).onClick.Call();
							((GObject)OpenFormationBtn).onClick.Call();
							unitChanged = false;
						}
					},
					{
						"Cancel",
						delegate
						{
							unitChanged = false;
							((GObject)OpenFormationBtn).onClick.Call();
						}
					}
				}
			},
			{ "PageIndex", 0 },
			{ "ClickSound", "Confirm" },
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	public void OnFormationUnitsChanged()
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_054a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		if (!GameController.Contexts.config.hasBattleConfig)
		{
			return;
		}
		BattleConfigComponent battleConfig = GameController.Contexts.config.battleConfig;
		showSoldiersNumTip = false;
		showDispatchSoldierTip = false;
		List<List<string>> unitsId = battleConfig.Red.UnitsId;
		int num = 0;
		if (_level.BattleMode == BattleMode.MultiWaveAttackMode && ChangePageControll.selectedIndex == 1)
		{
			farthestNeedReplaceFormationPos = -Vector3.one * 10000f;
		}
		if (_level.BattleMode == BattleMode.DefenceMode && ChangePageControll.selectedIndex == 0)
		{
			SetDefencePlaceSoldierLimitText(0);
		}
		if (_level.Chapter.Type == ChapterType.RepeatableInstanceDefensive)
		{
			string formationContext = _level.FormationContext;
			string subContext = _level.BattleMode.ToString();
			GetFormationVisionRadius(GameManagers.Instance.UserArchiveManager.GetCurrentFormation(formationContext, subContext));
		}
		List<string> list = new List<string>();
		for (int i = 0; i < _formationItemBtns.Count; i++)
		{
			string text = unitsId[0][i];
			list.Add(text);
			UI_FormationItemBtn uI_FormationItemBtn = _formationItemBtns[i];
			((GObject)uI_FormationItemBtn.back).data = text;
			SetFormationHalo(i, text, 0.1f * (float)i);
			if (string.IsNullOrEmpty(text))
			{
				((GObject)uI_FormationItemBtn.UnitNumberInfo).text = string.Empty;
				SetFormationItemSoldierIcon(_formationItemBtns[i], text, i);
				HideSoldierPotential(uI_FormationItemBtn);
				continue;
			}
			if (((GComponent)uI_FormationItemBtn).GetTransition("numTip").playing)
			{
				((GComponent)uI_FormationItemBtn).GetTransition("numTip").Stop();
			}
			if (((GComponent)uI_FormationItemBtn).GetTransition("Breath").playing)
			{
				((GComponent)uI_FormationItemBtn).GetTransition("Breath").Stop();
			}
			uI_FormationItemBtn.Status.selectedIndex = 1;
			num++;
			((GComponent)uI_FormationItemBtn).GetController("LevelTypeController").selectedIndex = 0;
			int num2 = GameManagers.Instance.StockController.GetStock(text);
			int soldierLevel = GameManagers.Instance.UserArchiveManager.GetSoldierLevel(text);
			int num3 = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(text, soldierLevel);
			if (_level.BattleMode == BattleMode.MultiWaveAttackMode && ChangePageControll.selectedIndex == 1)
			{
				Dictionary<string, int> unitsPool = battleConfig.Red.UnitsPool;
				Dictionary<string, int> unitsBorn = battleConfig.Red.UnitsBorn;
				int num4 = 0;
				int num5 = 0;
				if (unitsPool != null && unitsBorn != null)
				{
					foreach (KeyValuePair<string, int> item in unitsPool)
					{
						if (item.Key == text)
						{
							num4 = item.Value;
							break;
						}
					}
					foreach (KeyValuePair<string, int> item2 in unitsBorn)
					{
						if (item2.Key == text)
						{
							num5 = item2.Value;
							break;
						}
					}
					num2 = num4 - num5;
					if (num2 < num3)
					{
						Vector3 stagingAreaPosition = GameController.Contexts.Service<IStagingService>().GetStagingAreaPosition(Team.Red, i);
						if (farthestNeedReplaceFormationPos.x <= -10000f)
						{
							farthestNeedReplaceFormationPos = Vector3.op_Implicit(stagingAreaPosition);
						}
						else if (stagingAreaPosition.x < farthestNeedReplaceFormationPos.x)
						{
							farthestNeedReplaceFormationPos = Vector3.op_Implicit(stagingAreaPosition);
						}
					}
				}
			}
			else if (_level.Chapter.Type == ChapterType.TreasureHunt)
			{
				num2 = LegendItemDungeonUiHelper.GetSoldierCurNum(text);
			}
			if (_levelAssistanceConfig != null && _levelAssistanceConfig.AssistancePosition.Contains(i + 1))
			{
				Soldier soldier = GameManagers.Instance.SoldierManager.Get(_levelAssistanceConfig.AssistanceSoldier?[0]);
				Soldier soldier2 = GameManagers.Instance.SoldierManager.Get(soldier.Data.ParentSoldierId);
				((GObject)uI_FormationItemBtn.SoldierName).text = soldier2?.Name ?? "";
				int num6 = _levelAssistanceConfig.AssistanceSoldier.IndexOf(text);
				if (num6 != -1)
				{
					num2 = _levelAssistanceConfig.AssistanceQty[num6];
					num3 = num2;
				}
				((GObject)uI_FormationItemBtn.UnitNumberInfo).data = num2;
				((GObject)uI_FormationItemBtn.SoldierDesc).text = Regex.Match(soldier2.Desc, "(?<=Title:)([^:\\.])*(?=\\#)").Value;
			}
			else
			{
				uI_FormationItemBtn.Assistance.selectedIndex = 0;
				((GObject)uI_FormationItemBtn.UnitNumberInfo).data = num2;
				uI_FormationItemBtn.UnitNumberInfo.color = ((num2 < num3) ? Color.red : Color.white);
			}
			((GObject)uI_FormationItemBtn.UnitNumberInfo).text = $"{num2}/{num3}";
			RefreshSoldierPotentialDisplay(uI_FormationItemBtn, text, i);
			if (num2 < num3)
			{
				showSoldiersNumTip = true;
			}
			if (_level.BattleMode == BattleMode.DefenceMode)
			{
				SetDefencePlaceSoldierLimitText(num);
			}
			if (_level.BattleMode == BattleMode.MultiWaveAttackMode)
			{
				SetFormationItemSoldierIcon(_formationItemBtns[i], text, i);
			}
		}
		if (OpenFormationControll.selectedIndex != 0)
		{
			if (curUnitData.Count <= 0)
			{
				unitChanged = true;
			}
			else
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (curUnitData[j] != list[j])
					{
						unitChanged = true;
						break;
					}
				}
			}
			curUnitData.Clear();
			curUnitData.AddRange(list);
		}
		SetFormationItemBtnPos();
	}

	private bool AnySoldierInFormation()
	{
		if (!GameController.Contexts.config.hasBattleConfig)
		{
			return false;
		}
		if ((GameManagers.Instance.UserArchiveManager.IsNewGuideMode2() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode2() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode3() || GameManagers.Instance.UserArchiveManager.IsNewGuideMode3()) && _levelAssistanceConfig != null && _levelAssistanceConfig.EnableAssistance && (_levelAssistanceConfig.ChapterId == "C10000" || _levelAssistanceConfig.ChapterId == "C10001"))
		{
			return true;
		}
		BattleConfigComponent battleConfig = GameController.Contexts.config.battleConfig;
		List<List<string>> unitsId = battleConfig.Red.UnitsId;
		int[,] unitsTotal = battleConfig.Red.UnitsTotal;
		List<string> list = new List<string>();
		if (_levelAssistanceConfig != null && _levelAssistanceConfig.AssistanceSoldier != null)
		{
			list.AddRange(_levelAssistanceConfig.AssistanceSoldier);
		}
		for (int i = 0; i < _formationItemBtns.Count; i++)
		{
			string text = unitsId[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex][i];
			if (!string.IsNullOrEmpty(text) && !list.Contains(text) && unitsTotal[GameController.Contexts.Service<IBattleFieldService>().CurrentLevelIndex, i] > 0)
			{
				return true;
			}
		}
		return false;
	}

	private void RefreshSoldierPotentialDisplay(UI_FormationItemBtn btn, string unitId, int index)
	{
		if (_levelAssistanceConfig != null && _levelAssistanceConfig.AssistancePosition.Contains(index + 1))
		{
			((GObject)btn.UserLevel).text = "Lv.50";
			btn.PotentialLevel.SetSelectedIndex(9);
			btn.Assistance.SetSelectedIndex((!(_level.Chapter.ChapterId == "C10000") && !(_level.Chapter.ChapterId == "C10001")) ? 1 : 0);
			return;
		}
		btn.Assistance.SetSelectedIndex(0);
		bool flag = _level.BattleMode == BattleMode.MultiWaveAttackMode;
		if (IsUnitEmpty(unitId) || flag)
		{
			btn.PotentialLevel.SetSelectedIndex(10);
			return;
		}
		int soldierPotentialLevel = GameManagers.Instance.UserArchiveManager.GetSoldierPotentialLevel(unitId);
		btn.PotentialLevel.SetSelectedIndex(soldierPotentialLevel);
		int soldierLevel = GameManagers.Instance.UserArchiveManager.GetSoldierLevel(unitId);
		((GObject)btn.UserLevel).text = $"Lv.{soldierLevel}";
	}

	private void HideSoldierPotential(UI_FormationItemBtn btn)
	{
		btn.PotentialLevel.SetSelectedIndex(10);
	}

	public void OnAnyRedTeamCombatPower(GameStateEntity entity, int value)
	{
	}

	public void OnAnyBlueTeamCombatPower(GameStateEntity entity, int value)
	{
	}

	public void OnStagingAreaPositionsChanged(Team team)
	{
		if (team == Team.Red)
		{
			if (_CacheformationPos == null)
			{
				_CacheformationPos = new Dictionary<int, Vec3>();
			}
			_CacheformationPos.Clear();
			_formationItemBtnsInit();
			SetRedTeamCampBindgWithCamera();
			OnFormationUnitsChanged();
		}
	}

	public void OnAnyBattleConfig(ConfigEntity entity, BattleConfig red, BattleConfig blue, float battleFieldLength)
	{
		FGUIManager.Instance.OpenIEnumerator(IEnumerator_OnAnyBattleConfig());
	}

	private IEnumerator IEnumerator_OnAnyBattleConfig()
	{
		yield return null;
		OnFormationUnitsChanged();
	}

	public void OnAnyBattleFieldSubLevelIndex(GameStateEntity entity, int value)
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		if (value > 0 && _level.BattleMode == BattleMode.DefenceMode)
		{
			UiAudioManager.Instance.PlayBackgroundSound("MiniLevelWin");
			((GObject)CombatAlert.tip).text = string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText145"), value + 1, LanguagesManager.GetDesc("CsharpCodeZhTcText146")) + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText110");
			Transition combatAlertShake = CombatAlertShake;
			object obj = _003C_003Ec._003C_003E9__312_0;
			if (obj == null)
			{
				PlayCompleteCallback val = delegate
				{
				};
				_003C_003Ec._003C_003E9__312_0 = val;
				obj = (object)val;
			}
			combatAlertShake.Play(-1, 0f, (PlayCompleteCallback)obj);
		}
	}

	public void OnAnyFreeBattleMode(GameStateEntity entity)
	{
		((GObject)CombatAlert).visible = false;
	}

	public void OnAnyShowBattleWaveCountdown(GameStateEntity entity)
	{
		OnShowBattleWaveCountdownChanged(value: true);
	}

	public void OnAnyShowBattleWaveCountdownRemoved(GameStateEntity entity)
	{
		OnShowBattleWaveCountdownChanged(value: false);
	}

	public void OnShowBattleWaveCountdownChanged(bool value)
	{
		((GObject)CountdownBtn).visible = value;
	}

	public void OnAnyBattleWaveTimeLeft(GameStateEntity entity, int value)
	{
		UpdateBattleWaveTimeLeft(value);
	}

	public void OnAnyNextLevelComing(GameStateEntity entity)
	{
		if (_level.BattleMode == BattleMode.DefenceMode)
		{
			((GObject)CombatAlert).visible = true;
		}
	}

	public void OnAnyNextLevelComingRemoved(GameStateEntity entity)
	{
		((GObject)CombatAlert).visible = false;
	}

	public void OnAnyOfflineBonuses(GameStateEntity entity, List<Bonus> value)
	{
		FGUIManager.Instance.ShowNewOfflineBonuses();
	}

	public static List<string> GetFormationUnits(string formationContext, string mode)
	{
		Dictionary<string, Dictionary<string, List<string>>> value = GameController.Contexts.config.formationUnits.value;
		if (value.TryGetValue(formationContext, out var value2) && value2.TryGetValue(mode, out var value3))
		{
			return value3;
		}
		return null;
	}

	private void DisplayMainCityEntrance()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		if (IsLive001)
		{
			((GObject)EnterMaincity).visible = true;
			UnityBattleField unityBattleField = (UnityBattleField)((Context<GameEntity>)GameController.Contexts.game).GetGroup(GameMatcher.BattleField).GetEntities()[0].battleField.value;
			if (unityBattleField.BackgroundController is PrefabMapController prefabMapController)
			{
				Vector3 position = prefabMapController.Map.Find("main/fx/UiWrapper").position;
				Vector2 val = WorldToLocalUiPos(position);
				((GObject)EnterMaincity).SetXY(val.x, val.y);
				CheckUiPos((GObject)(object)EnterMaincity);
			}
		}
	}

	private static Vector2 WorldToLocalUiPos(Vector3 worldPos)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = Camera.main.WorldToScreenPoint(worldPos);
		val.y = (float)Screen.height - val.y;
		Vector2 result = ((GObject)GRoot.inst).GlobalToLocal(Vector2.op_Implicit(val));
		float num = FGUIManager.Instance.ScreenAmendY();
		result.y -= num;
		return result;
	}

	private void CheckUiPos(GObject childUi)
	{
		if (childUi.pivotAsAnchor)
		{
			float num = childUi.width / 2f;
			float num2 = childUi.height / 2f;
			float num3 = Mathf.Clamp(childUi.x, 0f + num + 40f, ((GObject)this).width - num - 40f);
			float num4 = Mathf.Clamp(childUi.y, 0f + num2, ((GObject)this).height - num2);
			childUi.SetXY(num3, num4);
		}
	}

	public void RefrenshArmyGroupBar(float our, float enemy)
	{
		((GProgressBar)OurInfomationBar.HPBar).value = our;
		((GProgressBar)EnemyInfomationBar.HPBar).value = enemy;
	}

	public void InitMap()
	{
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		_cameraService = GameController.Contexts.Service<ICameraService>();
		GameObject val = GameObject.Find("MiniMapCamera");
		if ((Object)(object)val == (Object)null)
		{
			Debug.LogError((object)"找不到小地图相机 MiniMapCamera");
			return;
		}
		_miniMapCamera = val.GetComponent<Camera>();
		if ((Object)(object)_miniMapCamera == (Object)null)
		{
			Debug.LogError((object)"找不到小地图相机");
		}
		((Behaviour)_miniMapCamera).enabled = true;
		_mapLength = GameController.Contexts.Service<IBattleFieldService>().CurrentLevel.Data.Length + 3f;
		_miniMapCamera.aspect = _mapLength / 10.8f;
		_ratio = 14.537037f;
		_miniMapLength = _mapLength * _ratio;
		int num = 13;
		if (_level != null && _level.BattleMode == BattleMode.MultiWaveAttackMode)
		{
			num = 53;
		}
		((GObject)MiniMapTexture).SetSize(_miniMapLength, 157f);
		((GObject)MiniMapHandle).SetSize(_miniMapLength, 157f + (float)num);
		((GObject)MiniMapTexture).SetXY(((GObject)MiniMapHandle).x, ((GObject)MiniMapHandle).y);
		miniMapTexture = new RenderTexture(Mathf.FloorToInt(_miniMapLength), Mathf.FloorToInt(157f), 0);
		Image val2 = new Image();
		((DisplayObject)val2).pivot = new Vector2(0.5f, 1f);
		_miniMapCamera.targetTexture = miniMapTexture;
		val2.texture = new NTexture((Texture)(object)miniMapTexture);
		MiniMapTexture.SetNativeObject((DisplayObject)(object)val2);
	}

	public void OnMiniMapTouchBegin(EventContext context)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		_cur_touch = context.inputEvent.position;
		context.CaptureTouch();
	}

	public void OnMiniMapTouchMove(EventContext context)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		_touch_deltaPosition = context.inputEvent.position - _cur_touch;
		_cur_touch = context.inputEvent.position;
		_cameraTempPos = Vector3.op_Implicit(_cameraService.Position);
		CameraMove(_cameraTempPos.x + _touch_deltaPosition.x / _ratio, _cameraTempPos.z + _touch_deltaPosition.y / _ratio);
	}

	public void CameraMove(float posX, float posZ)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		Vector3 position = _cameraService.Position;
		float num = (float)Screen.width / (float)Screen.height / 1.7777778f;
		Vector3 cameraMoveLimitPosition = _cameraMoveLimitPosition;
		float num2 = _cameraSize * _cameraService.Aspect;
		Vector3 val = _cameraMoveLimitSize - new Vector3(num2, 0f, _cameraSize);
		if (posX < cameraMoveLimitPosition.x + val.x && posX > cameraMoveLimitPosition.x - val.x)
		{
			Vector3 val2 = default(Vector3);
			((Vector3)(ref val2))._002Ector(posX, position.y, position.z);
			position = Vector3.op_Implicit(Vector3.Slerp(Vector3.op_Implicit(position), val2, 1f));
		}
		else
		{
			int num3 = ((posX > cameraMoveLimitPosition.x) ? 1 : (-1));
			Vector3 val3 = default(Vector3);
			((Vector3)(ref val3))._002Ector(cameraMoveLimitPosition.x + (float)num3 * val.x, position.y, position.z);
			position = Vector3.op_Implicit(Vector3.Slerp(Vector3.op_Implicit(position), val3, 1f));
		}
		if (posZ < cameraMoveLimitPosition.z + val.z && posZ > cameraMoveLimitPosition.z - val.z)
		{
			Vector3 val4 = default(Vector3);
			((Vector3)(ref val4))._002Ector(position.x, position.y, posZ);
			position = Vector3.op_Implicit(Vector3.Slerp(Vector3.op_Implicit(position), val4, 1f));
		}
		else
		{
			int num4 = ((posZ > cameraMoveLimitPosition.z) ? 1 : (-1));
			Vector3 val5 = default(Vector3);
			((Vector3)(ref val5))._002Ector(position.x, position.y, cameraMoveLimitPosition.z + (float)num4 * val.z);
			position = Vector3.op_Implicit(Vector3.Slerp(Vector3.op_Implicit(position), val5, 1f));
		}
		GameController.Contexts.gameState.isCameraFollowingUnit = false;
		GameController.Contexts.Service<ICameraService>().SetPosition(position);
	}

	public void OnClick(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		Vector2 position = context.inputEvent.position;
		Vector2 xy = ((GObject)MiniMapHandle).xy;
		float num = (position.x - xy.x) / _ratio;
		float num2 = (position.y - xy.y) / _ratio;
		CameraMove(_cameraMoveLimitPosition.x + num, _cameraMoveLimitPosition.z - num2);
	}

	public void MapZoom(float threshold)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		float num = _cameraSize + threshold;
		float num2 = 0f;
		float num3 = 0f;
		Vector3 val = Vector3.op_Implicit(_cameraService.Position);
		float num4 = num * _cameraService.Aspect;
		float num5 = num;
		if (num <= 5.4f && num >= 3f)
		{
			float num6 = val.x + num4;
			float num7 = val.x - num4;
			float num8 = val.z + num5;
			float num9 = val.z - num5;
			if (num6 > _cameraMoveLimitPosition.x + _cameraMoveLimitSize.x)
			{
				num2 = num6 - (_cameraMoveLimitPosition.x + _cameraMoveLimitSize.x);
			}
			else if (num7 < _cameraMoveLimitPosition.x - _cameraMoveLimitSize.x)
			{
				num2 = num7 - (_cameraMoveLimitPosition.x - _cameraMoveLimitSize.x);
			}
			if (num8 > _cameraMoveLimitPosition.z + _cameraMoveLimitSize.z)
			{
				num3 = num8 - (_cameraMoveLimitPosition.z + _cameraMoveLimitSize.z);
			}
			else if (num9 < _cameraMoveLimitPosition.z - _cameraMoveLimitSize.z)
			{
				num3 = num9 - (_cameraMoveLimitPosition.z - _cameraMoveLimitSize.z);
			}
			CameraMove(val.x - num2, val.z - num3);
			_cameraService.Size = num;
		}
	}

	public void OnAnyCameraMoveLimit(GameStateEntity entity, Vector3 cameraPosition, Vector3 size)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		_cameraMoveLimitPosition = cameraPosition;
		_cameraMoveLimitSize = size;
	}

	public void OnAnyCameraSize(GameStateEntity entity, float value)
	{
		_cameraSize = value;
	}

	public void OnAnyMouseScrollDelta(InputEntity entity, float value)
	{
		if (GameController.Contexts.gameState.isBattleStarted)
		{
			MapZoom(value);
		}
	}

	public void OnAnyZoomDelta(InputEntity entity, float value)
	{
		if (GameController.Contexts.gameState.isBattleStarted)
		{
			MapZoom(value);
		}
	}

	public void OnAnyCameraAspect(GameStateEntity entity, float value)
	{
		_cameraAspect = value;
	}

	public void OnAnyBattleFieldLength(GameStateEntity entity, float value)
	{
		InitMap();
	}
}
