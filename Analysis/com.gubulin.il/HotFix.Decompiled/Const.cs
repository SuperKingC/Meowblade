using GameMaths;

public class Const
{
	public const string WeChatAPPID = "wxa6206f99c0f8caaf";

	public const string BattleModelQualityString_Low = "_low";

	public const string BattleModelQualityString_Original = "";

	public const string MouseEffectOn = "on";

	public const string MouseEffectOff = "off";

	public const float BattleModelQualityScaleLimit = 1.5f;

	public const float FixedDeltaTime = 0.0333333f;

	public const float DesignScreenRatio = 1.7777778f;

	public const float MaxUiContentWidth = 2560f;

	public const float MinUiContentRatio = 1.7777778f;

	public const float MaxUiContentRatio = 2.3703704f;

	public const float WorldUnit = 0.01f;

	public const float BaseUnitScale = 0.15f;

	public const float UnitScaleY = 1.414f;

	public const float BattleFieldCampXMargin = 2.48f;

	public const float BattleFieldHeight = 5.35f;

	public const float BattleFieldOffsetY = 0f;

	public const float BattleFieldXMargin = 0.125f;

	public const int CampSlotsAmount = 5;

	public const int FormationStagingAreaAmount = 12;

	public const float ProjectileArrivalDistanceMin = 0.01f;

	public static readonly Vector3 NormalCamDist = new Vector3(0f, 21.26f, -20f);

	public const float FOV_移轴 = 10f;

	public static readonly Vector3 PostProcessCamDist_移轴 = new Vector3(0f, 55f, -54f);

	public const float FOV_开场透视 = 20f;

	public static readonly Vector3 PostProcessCamDist_开场透视 = new Vector3(0f, 21f, -21f);

	public const float FOV_常规透视 = 10f;

	public static readonly Vector3 PostProcessCamDist_常规透视 = new Vector3(0f, 42.8f, -42.3f);

	public const string SceneBattleField = "BattleField";

	public const string SceneMainCityLeft = "MainCity.Left";

	public const string SceneMainCityRight = "MainCity.Right";

	public const string SceneWorldMap = "WorldMap";

	public const string SceneGvGWorld = "SceneGvGWorld";

	public const string SceneGVG2 = "SceneGVG2";

	public const string TimeLineMainCityLordAppear = "MainCity.LordAppear";

	public const int BattleResultWin = 1;

	public const int BattleResultDefeat = -1;

	public const float ArriveDistance = 1.5f;

	public const float ArriveDistanceSqr = 2.25f;

	public const float ObstacleBaseSize = 0.4f;

	public static readonly float[] agentTypeRadiusMap = new float[6] { 0f, 0.25f, 0.3f, 0.4f, 0.5f, 0.75f };

	public const int GettingAttackedListCapacity = 10;

	public const int BattleWaveDuration = 30;

	public const float G = -0.098f;

	public static Vector2 BattleFieldOffset = new Vector2(0f, 0f);

	public const int SoldierItemMaxSlots = 3;

	public const int SoldierItemSlotStatusLocked = 0;

	public const int SoldierItemSlotStatusUnlocked = 1;

	public const string AnimationCarry = "carry";

	public const string AnimationRun = "run";

	public const string AnimationIdle = "idle";

	public const string MissibleA = "ui_missile_treasure_1";

	public const string MissibleB = "ui_missile_treasure_2";

	public const string MissibleC = "ui_missile_treasure_3";

	public const string ExplotionA = "ui_explotion_treasure_1";

	public const string ExplotionB = "ui_explotion_treasure_2";

	public const string ExplotionC = "ui_explotion_treasure_3";

	public const string BackUrl = "ui://xogvri2hs2vzl";

	public const string FrontUrl = "ui://xogvri2hs2vzm";

	public const string MiddleNote = "middle";

	public const float InitX = 960f;

	public const float InitY = 610f;

	public const string Prologue_Default = "C1000";

	public const string Prologue_NewGuideMode2 = "C10000";

	public const string Prologue_NewGuideMode3 = "C10001";

	public const string Prologue_NewGuideMode4 = "C1000";

	public const string Prologue_NewGuideMode7 = "C10002";

	public const string LIVE001 = "Live001";

	public const string ChatTimeFormat = "MM-dd HH:mm";

	public const string ActivityTimeFormat = "yyyy/MM/dd";

	public const string LegendItemTagOrc = "兽族";
}
