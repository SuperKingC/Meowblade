using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Base.Scripts.Utils;
using JetBrains.Annotations;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Spine.Unity;
using UI.Contract;
using UI.LegendItemDungeon;
using UI.LegendItemInfo;
using UI.LegendItems;
using UI.Legion;
using UI.PublicResources;
using UI.RecruitingCamp;
using UI.Tips;
using UI.UpGrade;
using UI.UpPropGrade;
using UI.UpgradePotential;
using UnityEngine;

namespace UI.SoldierCultivate;

public class UI_SoldierCultivate : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action<GameObject> _003C_003E9__111_0;

		public static Action<GameObject> _003C_003E9__121_0;

		public static Action<SkeletonAnimation> _003C_003E9__229_0;

		public static Action<GameObject> _003C_003E9__229_4;

		public static Action<GameObject> _003C_003E9__230_0;

		public static Action<GameObject> _003C_003E9__245_2;

		public static Action<GameObject> _003C_003E9__245_4;

		public static Action<GameObject> _003C_003E9__246_1;

		public static Action<GameObject> _003C_003E9__263_0;

		public static EventCallback0 _003C_003E9__265_2;

		public static Action<GameObject> _003C_003E9__266_0;

		public static Action<GameObject> _003C_003E9__284_2;

		public static Action<GameObject> _003C_003E9__284_0;

		public static Action<GameObject> _003C_003E9__290_1;

		public static Action<GameObject> _003C_003E9__290_3;

		public static Action<GameObject> _003C_003E9__290_4;

		public static Action<GameObject> _003C_003E9__290_5;

		public static Action<GameObject> _003C_003E9__294_3;

		public static Action<GameObject> _003C_003E9__299_0;

		public static Action<GameObject> _003C_003E9__301_2;

		public static Action<GameObject> _003C_003E9__301_3;

		public static Action<GameObject> _003C_003E9__354_3;

		public static Action _003C_003E9__355_4;

		public static Action<GameObject> _003C_003E9__358_2;

		public static Action<GameObject> _003C_003E9__358_3;

		public static Action<GameObject> _003C_003E9__359_1;

		internal void _003CRenderSoulStoneItem_003Eb__111_0(GameObject activatingWhite)
		{
			activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.3f;
		}

		internal void _003CUpdateSoulStoneIconAndData_003Eb__121_0(GameObject activatingWhite)
		{
			activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.3f;
		}

		internal void _003CShowPanel_003Eb__229_0(SkeletonAnimation animation)
		{
			SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
			animation.AnimationState.SetAnimation(0, "ui_title_lightray_rotate_yellow", true);
		}

		internal void _003CShowPanel_003Eb__229_4(GameObject uiRed)
		{
			uiRed.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
		}

		internal void _003CPlaySoldierLevelUpSfx_003Eb__230_0(GameObject armyLevelUp)
		{
			armyLevelUp.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
			UiAudioManager.Instance.LoadSoundsForSfx(armyLevelUp, "Refresh", playLoop: false, 0.25f);
		}

		internal void _003CLoaderSoldierData_003Eb__245_2(GameObject uiGreen)
		{
			uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
		}

		internal void _003CLoaderSoldierData_003Eb__245_4(GameObject rubbyBlastLangWhite)
		{
			rubbyBlastLangWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
			UiAudioManager.Instance.LoadSoundsForSfx(rubbyBlastLangWhite, "Refresh");
		}

		internal void _003CWaitToRefreshCombatPower_003Eb__246_1(GameObject uiGreen)
		{
			uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
		}

		internal void _003CUpgradeByExperienceBook_003Eb__263_0(GameObject expMissileGreen)
		{
			expMissileGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 1.35f;
		}

		internal void _003CShowExperiencePage_003Eb__265_2()
		{
			FGUIManager.Instance.StopLongPress();
		}

		internal void _003CAddTextSfx_003Eb__266_0(GameObject obj)
		{
			obj.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
		}

		internal void _003CRefreshDegreeElevationData_003Eb__284_2(GameObject activatingWhiteFoo)
		{
			activatingWhiteFoo.AddComponent<DestroySelf>().destroyTime = 1f;
		}

		internal void _003CRefreshDegreeElevationData_003Eb__284_0(GameObject activatingWhite)
		{
			UiAudioManager.Instance.LoadSoundsForSfx(activatingWhite, "Refresh");
			activatingWhite.AddComponent<DestroySelf>().destroyTime = 1f;
		}

		internal void _003COnSoldierEvoluteCompleted_003Eb__290_1(GameObject itemMissile)
		{
			itemMissile.AddComponent<HotFix_DestroySelf>().destroyTime = 0.3f;
		}

		internal void _003COnSoldierEvoluteCompleted_003Eb__290_3(GameObject rubbyBlastWhite)
		{
			rubbyBlastWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
			UiAudioManager.Instance.LoadSoundsForSfx(rubbyBlastWhite, "BalloonBlast");
		}

		internal void _003COnSoldierEvoluteCompleted_003Eb__290_4(GameObject uiGreen)
		{
			uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
		}

		internal void _003COnSoldierEvoluteCompleted_003Eb__290_5(GameObject uiRed)
		{
			uiRed.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
		}

		internal void _003CSoldierPotentialPanelUpdate_003Eb__294_3(GameObject activatingWhiteBig)
		{
			activatingWhiteBig.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			UiAudioManager.Instance.LoadSoundsForSfx(activatingWhiteBig, "Refresh");
		}

		internal void _003CUpdateSoldierPotentialRequirement_003Eb__299_0(GameObject uiGreen)
		{
			uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
		}

		internal void _003COnSoldierPotentialBreakthroughCompleted_003Eb__301_2(GameObject itemMissile)
		{
			itemMissile.AddComponent<HotFix_DestroySelf>().destroyTime = 0.3f;
		}

		internal void _003COnSoldierPotentialBreakthroughCompleted_003Eb__301_3(GameObject rubbyBlastWhite)
		{
			rubbyBlastWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
			UiAudioManager.Instance.LoadSoundsForSfx(rubbyBlastWhite, "BalloonBlast");
		}

		internal void _003CPlay4To0_003Eb__354_3(GameObject activatingWhite)
		{
			activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.3f;
		}

		internal void _003CFlashingLegendItemSlot_003Eb__355_4()
		{
			UiAudioManager.Instance.PlaySoundEffect("equipSlotUnlock");
		}

		internal void _003COnSoldierPotentialChange_003Eb__358_2(GameObject itemMissile)
		{
			itemMissile.AddComponent<HotFix_DestroySelf>().destroyTime = 0.3f;
		}

		internal void _003COnSoldierPotentialChange_003Eb__358_3(GameObject rubbyBlastWhite)
		{
			rubbyBlastWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
			UiAudioManager.Instance.LoadSoundsForSfx(rubbyBlastWhite, "BalloonBlast");
		}

		internal void _003CUpdateStoneSlot_003Eb__359_1(GameObject activatingWhite)
		{
			activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
			UiAudioManager.Instance.LoadSoundsForSfx(activatingWhite, "CardsShow");
		}
	}

	public Controller PageControll;

	public Controller Status;

	public Controller isOccupationeShow;

	public GLoader background;

	public GImage n211;

	public GImage n212;

	public GImage n213;

	public GGroup backRight;

	public UI_Title Title;

	public GImage n138;

	public GImage n218;

	public GImage n216;

	public GImage n217;

	public GImage n219;

	public GGroup backLeft;

	public GImage InfoBtnDark;

	public GImage PotentialBtnDark;

	public GImage BreakThrougBtnDark;

	public GImage DegreeElevationBtnDark;

	public GImage SoulStoneBtnDark;

	public GButton BackBtn;

	public GImage n101;

	public GImage n95;

	public GTextField DiamondAmount;

	public GButton DiamondBtn;

	public GGroup diamondgroup;

	public GComponent addWorkerBtn;

	public GGraph CombatPowerSfxBack;

	public UI_FormationSoldierAmountBtn FormationSoldierAmountBtn;

	public GGraph CombatPowerSpine;

	public GImage FormationSoldierAmountBack;

	public GImage n198;

	public GTextField n43;

	public GGraph FormationSoldierAmountSpine;

	public GTextField FormationSoldierAmount;

	public GImage n45;

	public GTextField CombatPower;

	public GImage CombatPowerIcon;

	public GTextField FormationAmountUpTip;

	public GGroup Bottomleftcorner;

	public GGraph SoldierVoiceClick;

	public GGraph baseSpine;

	public GGraph Spine;

	public GGraph maskSpine;

	public GComponent SoldierNamePotentialLevelBack;

	public GTextField SoldierName;

	public GTextField SoldierName_Max;

	public GLoader ShoulderStrap;

	public GList LevelStarList;

	public GGraph SoldierLevelSpine;

	public GTextField n39;

	public GTextField SoldierLevel;

	public GGroup detialLeft;

	public GGraph SoldierNamePotentialSfxBack;

	public GList SummonDemandList;

	public UI_DegreeElevationPage DegreeElevationPanel;

	public UI_SoldierPotentialPage SoldierPotentialPanel;

	public UI_SoldierInfoPage SoldierInfoPanel;

	public UI_SoldierBreakthrougPage SoldierBreakthrougPanel;

	public UI_SoldierSoulStonePage SoldierSoulStonePanel;

	public UI_com_PotentialPageGvG SoldierMythPage;

	public GImage InfoBtnLight;

	public UI_InfoBtn InfoBtn;

	public GImage PotentialBtnLight;

	public UI_PotentialBtn PotentialBtn;

	public GImage BreakThrougBtnLight;

	public UI_DegreeElevationBtn BreakThrougBtn;

	public GImage DegreeElevationBtnLight;

	public UI_SkinBtn DegreeElevationBtn;

	public UI_BreakthrougBtn SkinBtn;

	public GImage SoulStoneLight;

	public UI_SoulStoneBtn SoulStoneBtn;

	public GComponent PotentialIcon;

	public GGraph PotentialIconSfxBack;

	public GButton TurnPageLeftBtn;

	public UI_LegendSlot LegendSlot;

	public GButton TurnPageRightBtn;

	public GList SoldierLevelUpSfxLoader;

	public UI_RecruitingCampBtn RecruitingCampBtn;

	public GButton racePicture;

	public GButton occupationePicture;

	public GGraph potentialSfxEndPos;

	public GGraph motionSfxBack;

	public GGraph backMask;

	public Transition showBlackMask;

	public const string URL = "ui://7dantnbionm22k";

	public static string Name = "UI_SoldierCultivate";

	private int lastSoulNum = 60;

	private int aimSoulNum = 20;

	private List<string> curSoldierSoulStones = new List<string>();

	private Dictionary<string, int> lastSoulData = new Dictionary<string, int>();

	private Dictionary<string, int> curSoulData = new Dictionary<string, int>();

	private List<bool> SoulStonePlaySfxData = new List<bool>();

	private string _currentFillStone;

	private List<string> compositeTipList = new List<string>();

	public static UI_SoldierCultivate SoldierCultivatePanel;

	private readonly List<string> _skillList = new List<string>();

	private readonly string[] armorTypeNames = new string[4]
	{
		LanguagesManager.GetDesc("CsharpCodeZhTcText200"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText201"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText202"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText203")
	};

	private readonly string[] attackTypeNames = new string[4]
	{
		LanguagesManager.GetDesc("CsharpCodeZhTcText196"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText197"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText198"),
		LanguagesManager.GetDesc("CsharpCodeZhTcText199")
	};

	private Canvas canvas;

	private GameObject canvasObject;

	private GTextField[] consumes;

	private int CurrentPageIndex;

	private GLoader[] demandLoaders;

	private GLoader[] demandStockLoaders;

	public UI_ExperiencePage ExperiencePage;

	public UI_DetailPage DetailPage;

	public UI_SoulStoneResPanel SoulStoneResPanel;

	public UI_CompoundSoulStonePanel CompoundSoulStonePanel;

	public string[] expItems;

	public UI_SoldierFormationInfoPanel SoldierFormationInfoPanel;

	public UI_SoldierPotentialTipPanel SoldierPotentialTip;

	private LongPressGesture gesture1;

	private LongPressGesture gesture2;

	private LongPressGesture gesture3;

	private GoWrapper gw;

	private bool isFGUI;

	private UI_LegionPanel legionPanel;

	private Controller pageControll;

	private string[] potion = new string[4] { "I40004", "I40005", "I40006", "I40007" };

	private float previousAttack;

	private int previousBreakthroughMajorLevel;

	private float previousDefense;

	private int previousEvoLevel;

	private float previousFight;

	private int curSelectedExperienceBook = 0;

	private bool canPlayUpgradeSfx = false;

	private bool canPlayBreakthroughSfx = false;

	private float previousHealth;

	private float previousLevelLimit;

	private string productId;

	private GButton[] ProductList;

	private GameObject selectPanel;

	public Soldier soldier;

	public int curSoldierLevelLimit;

	public List<LongPressGesture> ExpGestures = new List<LongPressGesture>();

	public LongPressGesture ExpGesture;

	public bool isToMax;

	public string soldierId;

	private GTweener smokeTweener;

	private int SoldierIndex;

	public UI_SoldierPromotionPanel SoldierPromotionPanel;

	private GTextField[] stocks;

	public List<Soldier> UnlockSoldier;

	public List<GGraph> progressBarSfxBackList = new List<GGraph>();

	private GTweener soldierPotentialPanelGTweenerFoo;

	private GTweener soldierPotentialPanelGTweenerBar;

	private List<string> textureList = new List<string>();

	private bool levelChanged;

	private bool evoLevelChanged;

	private bool potentialLevelChanged;

	private bool potentialProgressChanged;

	public static bool legendItemsChanged;

	public static string lastLegendItemSoldierId = "";

	private List<GButton> LegendItemButtons = new List<GButton>();

	private const int LegendItemsLimit = 2;

	private const int LegendSlotUnlockPotentialLevelFoo = 4;

	private const int LegendSlotUnlockPotentialLevelBar = 8;

	private GTweener GTweenerExperienceProcessBar1;

	private GTweener GTweenerExperienceProcessBar2;

	private Tuple<LongPressGesture, UI_ExperiencePage, GGraph, int, double> getExpDataTuple;

	private Dictionary<string, GTweener> _timeoutDict = new Dictionary<string, GTweener>();

	private bool showLegendItemSlot;

	private const int MythStoneSlot = 4;

	private const string EA01Key = "EA01";

	private const string EA02Key = "EA02";

	private const string EA03Key = "EA03";

	private const string ui_myth_number_1 = "ui_myth_number_1";

	private const string ui_myth_number_2 = "ui_myth_number_2";

	private const string ui_myth_number_change = "ui_myth_number_change";

	private const string ui_myth_number_short_1 = "ui_myth_number_short_1";

	private const string ui_myth_number_short_2 = "ui_myth_number_short_2";

	private const string class_fx_8 = "class_fx_8";

	private const string class_fx_9_1 = "class_fx_9_1";

	private const string class_fx_9_2 = "class_fx_9_2";

	private const string ui_active_glow_orange_2 = "ui_active_glow_orange_2";

	private bool ShowLToM;

	private UI_occupationePicture OccupationBtn => (UI_occupationePicture)(object)occupationePicture;

	private bool MythAvailable => Define.SoldierMythUnderDevelopment();

	private bool LegendItemsSlotUnlock => LegendItemsHelper.GetSoldierItemSlotState(soldierId, 1);

	private bool MythOpened => GameManagers.Instance.UserArchiveManager.GetSoldierMyth(soldier.Id).Open;

	private bool IsNotMythPotentialLevel => soldier.PotentialLevel < 9;

	private Vector3 UiFxSize => Vector3.one * 100f;

	private List<KeyValuePair<string, int>> Requirements => GetMythRequirements();

	public static string GetURL()
	{
		return "ui://7dantnbionm22k";
	}

	public static UI_SoldierCultivate CreateInstance()
	{
		return (UI_SoldierCultivate)(object)UIPackage.CreateObject("SoldierCultivate", "SoldierCultivate");
	}

	public static UI_SoldierCultivate CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierCultivate).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbionm22k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
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
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected O, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_0398: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected O, but got Unknown
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Expected O, but got Unknown
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Expected O, but got Unknown
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Expected O, but got Unknown
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Expected O, but got Unknown
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Expected O, but got Unknown
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0479: Expected O, but got Unknown
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_048f: Expected O, but got Unknown
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Expected O, but got Unknown
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected O, but got Unknown
		//IL_0543: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Expected O, but got Unknown
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Expected O, but got Unknown
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected O, but got Unknown
		//IL_0585: Unknown result type (might be due to invalid IL or missing references)
		//IL_058f: Expected O, but got Unknown
		//IL_05da: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Expected O, but got Unknown
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fa: Expected O, but got Unknown
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Expected O, but got Unknown
		//IL_061c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Expected O, but got Unknown
		//IL_06b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c0: Expected O, but got Unknown
		//IL_06e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ec: Expected O, but got Unknown
		//IL_070e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0718: Expected O, but got Unknown
		//IL_073a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Expected O, but got Unknown
		//IL_077c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0786: Expected O, but got Unknown
		//IL_07a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b2: Expected O, but got Unknown
		//IL_07be: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c8: Expected O, but got Unknown
		//IL_07d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07de: Expected O, but got Unknown
		//IL_0800: Unknown result type (might be due to invalid IL or missing references)
		//IL_080a: Expected O, but got Unknown
		//IL_0816: Unknown result type (might be due to invalid IL or missing references)
		//IL_0820: Expected O, but got Unknown
		//IL_0842: Unknown result type (might be due to invalid IL or missing references)
		//IL_084c: Expected O, but got Unknown
		//IL_0858: Unknown result type (might be due to invalid IL or missing references)
		//IL_0862: Expected O, but got Unknown
		//IL_086e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0878: Expected O, but got Unknown
		//IL_0884: Unknown result type (might be due to invalid IL or missing references)
		//IL_088e: Expected O, but got Unknown
		//IL_089a: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageControll = ((GComponent)this).GetController("PageControll");
		Status = ((GComponent)this).GetController("Status");
		isOccupationeShow = ((GComponent)this).GetController("isOccupationeShow");
		background = (GLoader)((GComponent)this).GetChild("background");
		n211 = (GImage)((GComponent)this).GetChild("n211");
		n212 = (GImage)((GComponent)this).GetChild("n212");
		n213 = (GImage)((GComponent)this).GetChild("n213");
		backRight = (GGroup)((GComponent)this).GetChild("backRight");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		n218 = (GImage)((GComponent)this).GetChild("n218");
		n216 = (GImage)((GComponent)this).GetChild("n216");
		n217 = (GImage)((GComponent)this).GetChild("n217");
		n219 = (GImage)((GComponent)this).GetChild("n219");
		backLeft = (GGroup)((GComponent)this).GetChild("backLeft");
		InfoBtnDark = (GImage)((GComponent)this).GetChild("InfoBtnDark");
		PotentialBtnDark = (GImage)((GComponent)this).GetChild("PotentialBtnDark");
		BreakThrougBtnDark = (GImage)((GComponent)this).GetChild("BreakThrougBtnDark");
		DegreeElevationBtnDark = (GImage)((GComponent)this).GetChild("DegreeElevationBtnDark");
		SoulStoneBtnDark = (GImage)((GComponent)this).GetChild("SoulStoneBtnDark");
		BackBtn = (GButton)((GComponent)this).GetChild("BackBtn");
		n101 = (GImage)((GComponent)this).GetChild("n101");
		n95 = (GImage)((GComponent)this).GetChild("n95");
		DiamondAmount = (GTextField)((GComponent)this).GetChild("DiamondAmount");
		string id = "ui://7dantnbionm22k".Replace("ui://", "") + "-" + ((GObject)DiamondAmount).id;
		((GObject)DiamondAmount).text = LanguagesManager.GetDesc(id);
		DiamondBtn = (GButton)((GComponent)this).GetChild("DiamondBtn");
		diamondgroup = (GGroup)((GComponent)this).GetChild("diamondgroup");
		addWorkerBtn = (GComponent)((GComponent)this).GetChild("addWorkerBtn");
		CombatPowerSfxBack = (GGraph)((GComponent)this).GetChild("CombatPowerSfxBack");
		FormationSoldierAmountBtn = (UI_FormationSoldierAmountBtn)(object)((GComponent)this).GetChild("FormationSoldierAmountBtn");
		CombatPowerSpine = (GGraph)((GComponent)this).GetChild("CombatPowerSpine");
		FormationSoldierAmountBack = (GImage)((GComponent)this).GetChild("FormationSoldierAmountBack");
		n198 = (GImage)((GComponent)this).GetChild("n198");
		n43 = (GTextField)((GComponent)this).GetChild("n43");
		string id2 = "ui://7dantnbionm22k".Replace("ui://", "") + "-" + ((GObject)n43).id;
		((GObject)n43).text = LanguagesManager.GetDesc(id2);
		FormationSoldierAmountSpine = (GGraph)((GComponent)this).GetChild("FormationSoldierAmountSpine");
		FormationSoldierAmount = (GTextField)((GComponent)this).GetChild("FormationSoldierAmount");
		n45 = (GImage)((GComponent)this).GetChild("n45");
		CombatPower = (GTextField)((GComponent)this).GetChild("CombatPower");
		CombatPowerIcon = (GImage)((GComponent)this).GetChild("CombatPowerIcon");
		FormationAmountUpTip = (GTextField)((GComponent)this).GetChild("FormationAmountUpTip");
		string id3 = "ui://7dantnbionm22k".Replace("ui://", "") + "-" + ((GObject)FormationAmountUpTip).id;
		((GObject)FormationAmountUpTip).text = LanguagesManager.GetDesc(id3);
		Bottomleftcorner = (GGroup)((GComponent)this).GetChild("Bottomleftcorner");
		SoldierVoiceClick = (GGraph)((GComponent)this).GetChild("SoldierVoiceClick");
		baseSpine = (GGraph)((GComponent)this).GetChild("baseSpine");
		Spine = (GGraph)((GComponent)this).GetChild("Spine");
		maskSpine = (GGraph)((GComponent)this).GetChild("maskSpine");
		SoldierNamePotentialLevelBack = (GComponent)((GComponent)this).GetChild("SoldierNamePotentialLevelBack");
		SoldierName = (GTextField)((GComponent)this).GetChild("SoldierName");
		string id4 = "ui://7dantnbionm22k".Replace("ui://", "") + "-" + ((GObject)SoldierName).id;
		((GObject)SoldierName).text = LanguagesManager.GetDesc(id4);
		SoldierName_Max = (GTextField)((GComponent)this).GetChild("SoldierName_Max");
		string id5 = "ui://7dantnbionm22k".Replace("ui://", "") + "-" + ((GObject)SoldierName_Max).id;
		((GObject)SoldierName_Max).text = LanguagesManager.GetDesc(id5);
		ShoulderStrap = (GLoader)((GComponent)this).GetChild("ShoulderStrap");
		LevelStarList = (GList)((GComponent)this).GetChild("LevelStarList");
		SoldierLevelSpine = (GGraph)((GComponent)this).GetChild("SoldierLevelSpine");
		n39 = (GTextField)((GComponent)this).GetChild("n39");
		string id6 = "ui://7dantnbionm22k".Replace("ui://", "") + "-" + ((GObject)n39).id;
		((GObject)n39).text = LanguagesManager.GetDesc(id6);
		SoldierLevel = (GTextField)((GComponent)this).GetChild("SoldierLevel");
		detialLeft = (GGroup)((GComponent)this).GetChild("detialLeft");
		SoldierNamePotentialSfxBack = (GGraph)((GComponent)this).GetChild("SoldierNamePotentialSfxBack");
		SummonDemandList = (GList)((GComponent)this).GetChild("SummonDemandList");
		DegreeElevationPanel = (UI_DegreeElevationPage)(object)((GComponent)this).GetChild("DegreeElevationPanel");
		SoldierPotentialPanel = (UI_SoldierPotentialPage)(object)((GComponent)this).GetChild("SoldierPotentialPanel");
		SoldierInfoPanel = (UI_SoldierInfoPage)(object)((GComponent)this).GetChild("SoldierInfoPanel");
		SoldierBreakthrougPanel = (UI_SoldierBreakthrougPage)(object)((GComponent)this).GetChild("SoldierBreakthrougPanel");
		SoldierSoulStonePanel = (UI_SoldierSoulStonePage)(object)((GComponent)this).GetChild("SoldierSoulStonePanel");
		SoldierMythPage = (UI_com_PotentialPageGvG)(object)((GComponent)this).GetChild("SoldierMythPage");
		InfoBtnLight = (GImage)((GComponent)this).GetChild("InfoBtnLight");
		InfoBtn = (UI_InfoBtn)(object)((GComponent)this).GetChild("InfoBtn");
		PotentialBtnLight = (GImage)((GComponent)this).GetChild("PotentialBtnLight");
		PotentialBtn = (UI_PotentialBtn)(object)((GComponent)this).GetChild("PotentialBtn");
		BreakThrougBtnLight = (GImage)((GComponent)this).GetChild("BreakThrougBtnLight");
		BreakThrougBtn = (UI_DegreeElevationBtn)(object)((GComponent)this).GetChild("BreakThrougBtn");
		DegreeElevationBtnLight = (GImage)((GComponent)this).GetChild("DegreeElevationBtnLight");
		DegreeElevationBtn = (UI_SkinBtn)(object)((GComponent)this).GetChild("DegreeElevationBtn");
		SkinBtn = (UI_BreakthrougBtn)(object)((GComponent)this).GetChild("SkinBtn");
		SoulStoneLight = (GImage)((GComponent)this).GetChild("SoulStoneLight");
		SoulStoneBtn = (UI_SoulStoneBtn)(object)((GComponent)this).GetChild("SoulStoneBtn");
		PotentialIcon = (GComponent)((GComponent)this).GetChild("PotentialIcon");
		PotentialIconSfxBack = (GGraph)((GComponent)this).GetChild("PotentialIconSfxBack");
		TurnPageLeftBtn = (GButton)((GComponent)this).GetChild("TurnPageLeftBtn");
		LegendSlot = (UI_LegendSlot)(object)((GComponent)this).GetChild("LegendSlot");
		TurnPageRightBtn = (GButton)((GComponent)this).GetChild("TurnPageRightBtn");
		SoldierLevelUpSfxLoader = (GList)((GComponent)this).GetChild("SoldierLevelUpSfxLoader");
		RecruitingCampBtn = (UI_RecruitingCampBtn)(object)((GComponent)this).GetChild("RecruitingCampBtn");
		racePicture = (GButton)((GComponent)this).GetChild("racePicture");
		occupationePicture = (GButton)((GComponent)this).GetChild("occupationePicture");
		potentialSfxEndPos = (GGraph)((GComponent)this).GetChild("potentialSfxEndPos");
		motionSfxBack = (GGraph)((GComponent)this).GetChild("motionSfxBack");
		backMask = (GGraph)((GComponent)this).GetChild("backMask");
		showBlackMask = ((GComponent)this).GetTransition("showBlackMask");
	}

	private void GetCompositeTipList()
	{
		compositeTipList.Clear();
		GameManagers instance = GameManagers.Instance;
		List<Pieces> soulStoneCompositeDataBySoldier = PiecesManager.GetSoulStoneCompositeDataBySoldier(soldierId);
		int nextPotentialLevel = soldier.NextPotentialLevel;
		for (int i = 1; i <= nextPotentialLevel; i++)
		{
			SoldierPotentialData soldierPotential = ConfigDataManager.GetSoldierPotential(soldierId, i);
			if (soldierPotential == null)
			{
				Debug.LogWarning((object)$"无效的资质等级: {soldierId} => {i}");
				continue;
			}
			List<Pieces> piecesDataByCompositeResult = PiecesManager.GetPiecesDataByCompositeResult(soulStoneCompositeDataBySoldier, soldierPotential.Requirements(instance).Keys.ToArray());
			foreach (Pieces item in piecesDataByCompositeResult)
			{
				if (instance.PiecesManager.GetMaxComposite(item.PiecesId) > 0)
				{
					compositeTipList.Add(item.ItemId);
				}
			}
		}
	}

	private void OpenSoulStoneResPanel(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		Tuple<string, int, int> tuple = (Tuple<string, int, int>)((GObject)context.sender).data;
		if (!soldier.PotentialProgress.Contains(tuple.Item3))
		{
			SoulStoneResPanel = UI_SoulStoneResPanel.CreateInstance();
			((GObject)SoulStoneResPanel.mask).onClick.Add(new EventCallback0(CloseSoulStoneResPanel));
			((GObject)SoulStoneResPanel.StoneList).data = tuple.Item3;
			((GObject)SoulStoneResPanel.StoneList.soulStoneSelectList).data = tuple.Item1;
			_currentFillStone = tuple.Item1;
			((GObject)SoulStoneResPanel.StoneList.ConfirmBtn).onClick.Add(new EventCallback0(OnOneClickFillStone));
			SoulStoneResPanel.StoneList.SetButtonTitle();
			UiTagManager instance = UiTagManager.Instance;
			instance.Register("SoldierCultivate.OneClickFillStone", SoulStoneResPanel.StoneList.ConfirmBtn);
			UpdateSoulStoneResList();
			((GComponent)GRoot.inst).AddChild((GObject)(object)SoulStoneResPanel);
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)SoulStoneResPanel, scaleAdaption: true);
			SoulStoneResPanel.ShowSoulStoneList.Play();
		}
	}

	private void SoldierSoulStonePanelUpdate(string reason)
	{
		int num = ((soldier.PotentialLevel >= 7) ? 7 : 4);
		if (soldier.PotentialLevel >= 8)
		{
			SoldierSoulStonePanel.Status.selectedIndex = 1;
			((GObject)SoldierSoulStonePanel.QuickCompoundBtn).data = num;
			((GObject)SoldierSoulStonePanel.title).data = null;
			((GObject)SoldierSoulStonePanel.title2nd).data = null;
			SetSoulStoneGroupInit("");
		}
		else
		{
			Dictionary<string, int> dictionary = soldier.NextLevelPotential.Requirements(GameManagers.Instance);
			if (dictionary != null && dictionary.Count > 0)
			{
				string text = dictionary.Keys.First();
				int num2 = dictionary.Values.First();
				SoldierSoulStonePanel.Status.selectedIndex = 0;
				((GObject)SoldierSoulStonePanel.QuickCompoundBtn).data = num;
				((GObject)SoldierSoulStonePanel.title).data = text;
				((GObject)SoldierSoulStonePanel.title2nd).data = num2 - soldier.PotentialProgress.Count;
				SetSoulStoneGroupInit(text);
			}
			else
			{
				SoldierSoulStonePanel.Status.selectedIndex = 1;
				((GObject)SoldierSoulStonePanel.QuickCompoundBtn).data = num;
				((GObject)SoldierSoulStonePanel.title).data = null;
				((GObject)SoldierSoulStonePanel.title2nd).data = null;
				SetSoulStoneGroupInit("");
			}
		}
		((GObject)SoldierSoulStonePanel.n219).data = 0;
		((GObject)SoldierSoulStonePanel.soulStoneSelectList).data = null;
		((GObject)SoldierSoulStonePanel.CompoundBtn).enabled = false;
		UpdateSoldierSoulStonePanel();
		SetSoldierSoulStonePanelCompoundStatus();
		UpdateRedNoteStatus();
		SummonDemandListRender();
		SoldierSoulStonePanel.SetControllerPageText();
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("SoldierCultivate.SoulStoneCompositeBtn");
		instance.Register("SoldierCultivate.SoulStoneCompositeBtn", SoldierSoulStonePanel.CompoundBtn);
	}

	private void SetSoldierSoulStonePanelCompoundStatus()
	{
		if (((GObject)SoldierSoulStonePanel.title).data == null || Shift.Legion.Common.Models.Item.Rarity(((GObject)SoldierSoulStonePanel.title).data.ToString()) >= 5)
		{
			int targetPotentialLevel = ((soldier.PotentialLevel >= 7) ? 7 : 4);
			if (HasPiecesToCompositeUtilLevel(targetPotentialLevel))
			{
				SoldierSoulStonePanel.NumStatus.selectedIndex = 1;
			}
			else
			{
				SoldierSoulStonePanel.NumStatus.selectedIndex = 0;
			}
		}
		else
		{
			SoldierSoulStonePanel.NumStatus.selectedIndex = 0;
		}
	}

	private void SetSoulStoneGroupInit(string aimSoulStoneItemId)
	{
		if (string.IsNullOrWhiteSpace(aimSoulStoneItemId) || Shift.Legion.Common.Models.Item.Rarity(aimSoulStoneItemId) > 7)
		{
			SoldierSoulStonePanel.Status.selectedIndex = 1;
		}
		else if (Shift.Legion.Common.Models.Item.Rarity(aimSoulStoneItemId) == 1)
		{
			SoldierSoulStonePanel.Status.selectedIndex = 2;
			FGUIManager.Instance.SetSoulStoneIconAndFrame(SoldierSoulStonePanel.CSoulStone.iconBtn, aimSoulStoneItemId, textureList);
			int stock = GameManagers.Instance.StockController.GetStock(aimSoulStoneItemId);
			int num = (int)((GObject)SoldierSoulStonePanel.title2nd).data;
			string arg = "#178914";
			if (stock < num)
			{
				arg = "#FF1919";
			}
			((GObject)SoldierSoulStonePanel.num).text = $"[color={arg}]{stock}/{num}[/color]";
		}
		else
		{
			SoldierSoulStonePanel.Status.selectedIndex = 0;
			string soulStoneItemId = "I2" + $"{Shift.Legion.Common.Models.Item.Rarity(aimSoulStoneItemId) - 1}" + aimSoulStoneItemId.Substring(3);
			((GButton)SoldierSoulStonePanel.aimSoulStone).selected = false;
			FGUIManager.Instance.SetSoulStoneIconAndFrame(SoldierSoulStonePanel.aimSoulStone.iconBtn, aimSoulStoneItemId, textureList);
			for (int i = 1; i < 4; i++)
			{
				((GComponent)SoldierSoulStonePanel).GetChild($"soulStone{i}").asButton.selected = false;
				FGUIManager.Instance.SetSoulStoneIconAndFrame(((GComponent)((GComponent)SoldierSoulStonePanel).GetChild($"soulStone{i}").asButton).GetChild("iconBtn").asButton, soulStoneItemId, textureList);
			}
		}
		SoldierSoulStonePanel.SetControllerPageText();
	}

	private void UpdateSoulStoneGroup(string selectSoulStoneItemId, int selectNum)
	{
		if (string.IsNullOrWhiteSpace(selectSoulStoneItemId))
		{
			if (soldier.PotentialLevel >= 8)
			{
				SetSoulStoneGroupInit("");
			}
			else
			{
				Dictionary<string, int> dictionary = soldier.NextLevelPotential.Requirements(GameManagers.Instance);
				if (dictionary != null && dictionary.Count > 0)
				{
					string soulStoneGroupInit = dictionary.Keys.First();
					SetSoulStoneGroupInit(soulStoneGroupInit);
				}
				else
				{
					SetSoulStoneGroupInit("");
				}
			}
		}
		else if (Shift.Legion.Common.Models.Item.Rarity(selectSoulStoneItemId) > 6)
		{
			SoldierSoulStonePanel.Status.selectedIndex = 1;
		}
		else
		{
			SoldierSoulStonePanel.Status.selectedIndex = 0;
			string soulStoneItemId = "I2" + $"{Shift.Legion.Common.Models.Item.Rarity(selectSoulStoneItemId) + 1}" + selectSoulStoneItemId.Substring(3);
			if (selectNum < 3)
			{
				((GButton)SoldierSoulStonePanel.aimSoulStone).selected = false;
			}
			else
			{
				((GButton)SoldierSoulStonePanel.aimSoulStone).selected = true;
			}
			FGUIManager.Instance.SetSoulStoneIconAndFrame(SoldierSoulStonePanel.aimSoulStone.iconBtn, soulStoneItemId, textureList);
			for (int i = 1; i < 4; i++)
			{
				if (i <= selectNum)
				{
					((GComponent)SoldierSoulStonePanel).GetChild($"soulStone{i}").asButton.selected = true;
				}
				else
				{
					((GComponent)SoldierSoulStonePanel).GetChild($"soulStone{i}").asButton.selected = false;
				}
				FGUIManager.Instance.SetSoulStoneIconAndFrame(((GComponent)((GComponent)SoldierSoulStonePanel).GetChild($"soulStone{i}").asButton).GetChild("iconBtn").asButton, selectSoulStoneItemId, textureList);
			}
		}
		SoldierSoulStonePanel.SetControllerPageText();
	}

	private void UpdateSoldierSoulStonePanel()
	{
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected O, but got Unknown
		GetCurSoldierSoulStones(specialShow: false);
		GetCompositeTipList();
		if (lastSoulData.Count > 0)
		{
			SoulStonePlaySfxData.Clear();
			curSoulData = GetSoulStoneAndNum();
			foreach (KeyValuePair<string, int> curSoulDatum in curSoulData)
			{
				if (lastSoulData.ContainsKey(curSoulDatum.Key))
				{
					if (curSoulDatum.Value <= lastSoulData[curSoulDatum.Key])
					{
						for (int i = 0; i < curSoulDatum.Value; i++)
						{
							SoulStonePlaySfxData.Add(item: false);
						}
						continue;
					}
					for (int j = 0; j < lastSoulData[curSoulDatum.Key]; j++)
					{
						SoulStonePlaySfxData.Add(item: false);
					}
					for (int k = 0; k < curSoulDatum.Value - lastSoulData[curSoulDatum.Key]; k++)
					{
						SoulStonePlaySfxData.Add(item: true);
					}
				}
				else
				{
					for (int l = 0; l < curSoulDatum.Value; l++)
					{
						SoulStonePlaySfxData.Add(item: true);
					}
				}
			}
		}
		GList soulStoneSelectList = SoldierSoulStonePanel.soulStoneSelectList;
		soulStoneSelectList.SetVirtual();
		soulStoneSelectList.itemRenderer = new ListItemRenderer(SoulStoneItemInit);
		soulStoneSelectList.numItems = curSoldierSoulStones.Count;
		soulStoneSelectList.itemRenderer = new ListItemRenderer(RenderSoulStoneItem);
		soulStoneSelectList.numItems = curSoldierSoulStones.Count;
		SoulStonePlaySfxData.Clear();
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("SoldierCultivate.SoulStoneList");
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		for (int m = 0; m < curSoldierSoulStones.Count; m++)
		{
			int num = soulStoneSelectList.ItemIndexToChildIndex(m);
			if (num >= 0 && num < ((GComponent)soulStoneSelectList).numChildren)
			{
				GButton asButton = ((GComponent)soulStoneSelectList).GetChildAt(num).asButton;
				dictionary.Add($"{m + 1}", asButton);
			}
		}
		instance.Register("SoldierCultivate.SoulStoneList", dictionary);
	}

	private void GetCurSoldierSoulStones(bool specialShow = true)
	{
		curSoldierSoulStones.Clear();
		List<string> list = new List<string>();
		List<Pieces> soulStoneCompositeDataBySoldier = PiecesManager.GetSoulStoneCompositeDataBySoldier(soldierId);
		for (int i = 0; i < soulStoneCompositeDataBySoldier.Count; i++)
		{
			string itemId = soulStoneCompositeDataBySoldier[i].ItemId;
			for (int j = 0; j < GameManagers.Instance.StockController.GetStock(itemId); j++)
			{
				list.Add(itemId);
			}
		}
		if (specialShow)
		{
			string aimSoulStoneItemId = ((GObject)SoulStoneResPanel.StoneList.soulStoneSelectList).data.ToString();
			IEnumerable<string> enumerable = list.Where((string soulStone) => soulStone == aimSoulStoneItemId);
			IOrderedEnumerable<string> collection = list.Where((string soulStone) => soulStone != aimSoulStoneItemId).OrderByDescending(Shift.Legion.Common.Models.Item.Rarity);
			curSoldierSoulStones.AddRange(enumerable);
			curSoldierSoulStones.AddRange(collection);
			if (enumerable.ToList().Count > 0)
			{
				SoulStoneResPanel.StoneList.NumStatus.selectedIndex = 0;
			}
			else
			{
				SoulStoneResPanel.StoneList.NumStatus.selectedIndex = 1;
			}
		}
		else
		{
			IOrderedEnumerable<string> collection2 = list.OrderByDescending(Shift.Legion.Common.Models.Item.Rarity);
			curSoldierSoulStones.AddRange(collection2);
		}
	}

	private Dictionary<string, int> GetSoulStoneAndNum()
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		for (int i = 0; i < curSoldierSoulStones.Count; i++)
		{
			if (dictionary.ContainsKey(curSoldierSoulStones[i]))
			{
				dictionary[curSoldierSoulStones[i]]++;
			}
			else
			{
				dictionary.Add(curSoldierSoulStones[i], 1);
			}
		}
		return dictionary;
	}

	private void UpdateSoulStoneResList()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		GetCurSoldierSoulStones();
		GList soulStoneSelectList = SoulStoneResPanel.StoneList.soulStoneSelectList;
		soulStoneSelectList.SetVirtual();
		soulStoneSelectList.itemRenderer = new ListItemRenderer(RenderSoulStone);
		soulStoneSelectList.numItems = curSoldierSoulStones.Count;
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("SoldierCultivate.SoulStoneList");
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		for (int i = 0; i < curSoldierSoulStones.Count; i++)
		{
			int num = soulStoneSelectList.ItemIndexToChildIndex(i);
			if (num >= 0 && num < ((GComponent)soulStoneSelectList).numChildren)
			{
				GButton asButton = ((GComponent)soulStoneSelectList).GetChildAt(num).asButton;
				dictionary.Add($"{i + 1}", asButton);
			}
		}
		instance.Register("SoldierCultivate.SoulStoneList", dictionary);
	}

	private void RenderSoulStone(int index, GObject obj)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		int iconBtnStatus = 0;
		((GObject)asButton).touchable = true;
		string text = curSoldierSoulStones[index];
		if (text != ((GObject)SoulStoneResPanel.StoneList.soulStoneSelectList).data.ToString())
		{
			iconBtnStatus = 2;
			((GObject)asButton).touchable = false;
		}
		else
		{
			((GObject)asButton).onClick.Add(new EventCallback1(SelectSoulStone));
		}
		FGUIManager.Instance.SetSoulStoneIconAndFrame(((GComponent)asButton).GetChild("iconBtn").asButton, text, textureList, iconBtnStatus);
	}

	private void SoulStoneItemInit(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
		asButton.selected = false;
		((GObject)asButton).enabled = true;
	}

	private void RenderSoulStoneItem(int index, GObject obj)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		GButton asButton = obj.asButton;
		int iconBtnStatus = 0;
		((GObject)asButton).enabled = true;
		string text = curSoldierSoulStones[index];
		if (((GObject)SoldierSoulStonePanel.soulStoneSelectList).data == null || string.IsNullOrWhiteSpace(((GObject)SoldierSoulStonePanel.soulStoneSelectList).data.ToString()))
		{
			((GObject)asButton).onClick.Add(new EventCallback1(SelectSoulStoneItem));
		}
		else if (text != ((GObject)SoldierSoulStonePanel.soulStoneSelectList).data.ToString())
		{
			((GObject)asButton).enabled = false;
		}
		else
		{
			((GObject)asButton).onClick.Add(new EventCallback1(SelectSoulStoneItem));
		}
		FGUIManager.Instance.SetSoulStoneIconAndFrame(((GComponent)asButton).GetChild("iconBtn").asButton, text, textureList, iconBtnStatus);
		if (SoulStonePlaySfxData.Count > 0 && SoulStonePlaySfxData[index] && ((GComponent)SoldierSoulStonePanel.soulStoneSelectList).IsChildInView(obj))
		{
			FGUIManager.Instance.AddTextSpecialEffects(((GComponent)asButton).GetChild("SfxBack").asGraph, "activating_white", new Vector3(150f, 150f, 150f), "Default", 0.5f, delegate(GameObject activatingWhite)
			{
				activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.3f;
			});
		}
		((GComponent)asButton).GetChild("note").visible = compositeTipList.Contains(text);
	}

	private void SelectOrtherSoulStone(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GButton val = (GButton)context.sender;
		val.selected = false;
		int num = (int)((GObject)SoulStoneResPanel.SoulStoneList.soulStoneNum).data;
		((GObject)SoulStoneResPanel.SoulStoneList.soulStoneNum).data = num;
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText663") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)SoulStoneResPanel).sortingOrder + 1, arg3: false);
	}

	private void SelectSoulStone(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GButton val = (GButton)context.sender;
		SelectSoulStoneForUpProgress(context);
		CloseSoulStoneResPanel();
	}

	private void SelectSoulStoneItem(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		GButton val = (GButton)context.sender;
		int num = (int)((GObject)SoldierSoulStonePanel.n219).data;
		GList soulStoneSelectList = SoldierSoulStonePanel.soulStoneSelectList;
		if (val.selected)
		{
			if (num >= 3)
			{
				val.selected = false;
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText664") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
			}
			else
			{
				((GObject)SoldierSoulStonePanel.n219).data = num + 1;
				((GObject)soulStoneSelectList).data = curSoldierSoulStones[soulStoneSelectList.selectedIndex];
			}
		}
		else if (num > 0)
		{
			((GObject)SoldierSoulStonePanel.n219).data = num - 1;
			if (num - 1 <= 0)
			{
				((GObject)soulStoneSelectList).data = null;
			}
		}
		if ((int)((GObject)SoldierSoulStonePanel.n219).data >= 3)
		{
			((GObject)SoldierSoulStonePanel.CompoundBtn).enabled = true;
		}
		else
		{
			((GObject)SoldierSoulStonePanel.CompoundBtn).enabled = false;
		}
		if (((GObject)soulStoneSelectList).data == null)
		{
			UpdateSoulStoneGroup("", 0);
		}
		else
		{
			UpdateSoulStoneGroup(((GObject)soulStoneSelectList).data.ToString(), (int)((GObject)SoldierSoulStonePanel.n219).data);
		}
		soulStoneSelectList.itemRenderer = new ListItemRenderer(RenderSoulStoneItem);
		soulStoneSelectList.numItems = curSoldierSoulStones.Count;
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("SoldierCultivate.SoulStoneList");
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		for (int i = 0; i < curSoldierSoulStones.Count; i++)
		{
			int num2 = soulStoneSelectList.ItemIndexToChildIndex(i);
			if (num2 >= 0 && num2 < ((GComponent)soulStoneSelectList).numChildren)
			{
				GButton asButton = ((GComponent)soulStoneSelectList).GetChildAt(num2).asButton;
				dictionary.Add($"{i + 1}", asButton);
			}
		}
		instance.Register("SoldierCultivate.SoulStoneList", dictionary);
	}

	private void SelectSoulStoneForUpProgress(EventContext eventContext)
	{
		int entranceIndex = (int)((GObject)SoulStoneResPanel.StoneList).data;
		ILRequestHelper<SoldierAddPotentialProgressResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().SoldierAddPotentialProgress(-1L, soldier.Id, entranceIndex, 1), delegate(SoldierAddPotentialProgressResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				potentialProgressChanged = true;
				OnSoldierAddPotentialProgressCompleted(entranceIndex, 1);
			}
		});
	}

	private void OnSoldierAddPotentialProgressCompleted(int entranceIndex, int curNum)
	{
		List<int> list = new List<int>();
		if (soldier.CanAddPotentialProgress(entranceIndex))
		{
			soldier.AddPotentialProgress(entranceIndex);
			switch (entranceIndex)
			{
			case 1:
				list.Add(0);
				break;
			case 2:
				list.Add(1);
				break;
			case 4:
				list.Add(2);
				break;
			case 8:
				list.Add(3);
				break;
			}
		}
		for (int i = 0; i < curNum - 1; i++)
		{
			if (soldier.CanAddPotentialProgress(1))
			{
				soldier.AddPotentialProgress(1);
				list.Add(0);
				continue;
			}
			if (soldier.CanAddPotentialProgress(2))
			{
				soldier.AddPotentialProgress(2);
				list.Add(1);
				continue;
			}
			if (soldier.CanAddPotentialProgress(4))
			{
				soldier.AddPotentialProgress(4);
				list.Add(2);
			}
			if (soldier.CanAddPotentialProgress(8))
			{
				soldier.AddPotentialProgress(8);
				list.Add(3);
			}
		}
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		SoldierPotentialPanelUpdate(list);
		CloseSoulStoneResPanel();
		UpdatePotentialRedDotVisible();
	}

	private void CloseSoulStoneResPanel()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		((GObject)SoulStoneResPanel.StoneList.ConfirmBtn).onClick.Remove(new EventCallback0(OnOneClickFillStone));
		((GObject)SoulStoneResPanel.mask).onClick.Remove(new EventCallback0(CloseSoulStoneResPanel));
		((GObject)SoulStoneResPanel.SoulStoneList.ConfirmBtn).onClick.Remove(new EventCallback1(SelectSoulStoneForUpProgress));
		((GObject)SoulStoneResPanel.SoulStoneList.CompoundBtn).onClick.Remove(new EventCallback1(OpenCompoundSoulStonePanel));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)SoulStoneResPanel, true);
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("SoldierCultivate.SoulStoneList");
		instance.Unregister("SoldierCultivate.SoulStoneCompositeBtn");
		instance.Unregister("SoldierCultivate.SoulStoneConfirmBtn");
		instance.Unregister("SoldierCultivate.OneClickFillStone");
	}

	private IEnumerator FillStone(List<int> entrances)
	{
		int i = 0;
		while (i < entrances.Count)
		{
			int entranceIndex = entrances[i];
			int state = -1;
			ILRequestHelper<SoldierAddPotentialProgressResponse>.Request((EventContext)null, (Func<Task<SoldierAddPotentialProgressResponse>>)(() => GameController.Contexts.Service<INetworkService>().SoldierAddPotentialProgress(-1L, soldier.Id, entranceIndex, 1)), (Action<SoldierAddPotentialProgressResponse>)delegate(SoldierAddPotentialProgressResponse response)
			{
				if (!response.Result)
				{
					state = 0;
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					state = 1;
				}
			});
			while (state == -1)
			{
				yield return null;
			}
			if (state == 0)
			{
				break;
			}
			yield return null;
			potentialProgressChanged = true;
			OnSoldierAddPotentialProgressCompleted(entranceIndex, 1);
			int num = i + 1;
			i = num;
		}
	}

	private void OnOneClickFillStone()
	{
		int num = 0;
		string currentFillStone = _currentFillStone;
		for (int i = 0; i < curSoldierSoulStones.Count; i++)
		{
			if (curSoldierSoulStones[i] == currentFillStone)
			{
				num++;
			}
		}
		CloseSoulStoneResPanel();
		List<int> list = new List<int>();
		if (soldier.PotentialLevel < 8)
		{
			for (int j = 0; j < 3; j++)
			{
				GButton asButton = ((GComponent)SoldierPotentialPanel).GetChild($"SoulStone{j}").asButton;
				if ((double)((GObject)asButton).alpha > 0.5)
				{
					int item = 0;
					switch (j)
					{
					case 0:
						item = 1;
						break;
					case 1:
						item = 2;
						break;
					case 2:
						item = 4;
						break;
					}
					if (!soldier.PotentialProgress.Contains(item) && num > 0)
					{
						num--;
						list.Add(item);
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < 4; k++)
			{
				int item2 = 0;
				switch (k)
				{
				case 0:
					item2 = 1;
					break;
				case 1:
					item2 = 2;
					break;
				case 2:
					item2 = 4;
					break;
				case 3:
					item2 = 8;
					break;
				}
				if (!soldier.PotentialProgress.Contains(item2) && num > 0)
				{
					num--;
					list.Add(item2);
				}
			}
		}
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FillStone(list));
	}

	private void OpenCompoundSoulStonePanel(EventContext context)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		CompoundSoulStonePanel = UI_CompoundSoulStonePanel.CreateInstance();
		((GObject)CompoundSoulStonePanel.Dialog.exitBtn).onClick.Add(new EventCallback0(CloseCompoundSoulStonePanel));
		((GObject)CompoundSoulStonePanel.Dialog.ConfirmBtn).onClick.Add(new EventCallback1(CompoundSoulStone));
		((GObject)CompoundSoulStonePanel.Dialog.MaxBtn).onClick.Add(new EventCallback0(CompoundSoulStoneMaxEvent));
		((GObject)CompoundSoulStonePanel.Dialog.increaseBtn).onClick.Add(new EventCallback0(IncreaseCompoundNum));
		((GObject)CompoundSoulStonePanel.Dialog.reduceBtn).onClick.Add(new EventCallback0(ReduceCompoundNum));
		((GObject)CompoundSoulStonePanel.Dialog.TurnPageLeftBtn).onClick.Add(new EventCallback0(TurnPageLeftBtnEvent));
		((GObject)CompoundSoulStonePanel.Dialog.TurnPageRightBtn).onClick.Add(new EventCallback0(TurnPageRightBtnEvent));
		((GComponent)GRoot.inst).AddChild((GObject)(object)CompoundSoulStonePanel);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)CompoundSoulStonePanel);
		string text = ((GObject)context.sender).data.ToString();
		List<Pieces> soulStoneCompositeDataBySoldier = PiecesManager.GetSoulStoneCompositeDataBySoldier(soldierId);
		for (int i = 0; i < soulStoneCompositeDataBySoldier.Count; i++)
		{
			if (text == soulStoneCompositeDataBySoldier[i].ItemId)
			{
				((GObject)CompoundSoulStonePanel.Dialog.ConfirmBtn).data = soulStoneCompositeDataBySoldier[i];
				break;
			}
		}
		if (((GObject)CompoundSoulStonePanel.Dialog.ConfirmBtn).data == null)
		{
			CloseCompoundSoulStonePanel();
		}
		string itemId = ((Pieces)((GObject)CompoundSoulStonePanel.Dialog.ConfirmBtn).data).ItemId;
		int num = int.Parse(itemId[2].ToString()) - 2;
		CompoundSoulStonePanel.Dialog.Status.selectedIndex = ((num >= 0) ? num : 0);
		UpdateSoulStoneIconAndData();
		CompoundSoulStonePanel.Dialog.compoundNum.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		CompoundSoulStonePanel.ShowDialog.Play();
	}

	private void UpdateSoulStoneIconAndData(bool isInit = true)
	{
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		if (!isInit)
		{
			((GObject)CompoundSoulStonePanel.Dialog.aimSoulStone).alpha = 0f;
		}
		else
		{
			((GObject)CompoundSoulStonePanel.Dialog.aimSoulStone).alpha = 1f;
		}
		Pieces pieces = (Pieces)((GObject)CompoundSoulStonePanel.Dialog.ConfirmBtn).data;
		string itemId = pieces.ItemId;
		itemId = "I2" + $"{CompoundSoulStonePanel.Dialog.Status.selectedIndex + 2}" + itemId.Substring(3);
		if (isInit)
		{
			((GObject)CompoundSoulStonePanel.Dialog.tip1).data = itemId;
		}
		string text = "I2" + $"{CompoundSoulStonePanel.Dialog.Status.selectedIndex + 1}" + itemId.Substring(3);
		Pieces pieces2 = null;
		List<Pieces> soulStoneCompositeDataBySoldier = PiecesManager.GetSoulStoneCompositeDataBySoldier(soldierId);
		for (int i = 0; i < soulStoneCompositeDataBySoldier.Count; i++)
		{
			if (itemId == soulStoneCompositeDataBySoldier[i].ItemId)
			{
				((GObject)CompoundSoulStonePanel.Dialog.ConfirmBtn).data = soulStoneCompositeDataBySoldier[i];
			}
			if (text == soulStoneCompositeDataBySoldier[i].ItemId)
			{
				pieces2 = soulStoneCompositeDataBySoldier[i];
			}
		}
		((GObject)CompoundSoulStonePanel.Dialog.curSoulStone).data = GameManagers.Instance.StockController.GetStock(text);
		((GObject)CompoundSoulStonePanel.Dialog.aimSoulStone).data = GameManagers.Instance.StockController.GetStock(itemId);
		((GObject)CompoundSoulStonePanel.Dialog.compoundNum).data = 0;
		((GObject)CompoundSoulStonePanel.Dialog.MaxBtn).data = GameManagers.Instance.PiecesManager.GetMaxComposite(pieces2.PiecesId);
		FGUIManager.Instance.SetSoulStoneIconAndFrame(CompoundSoulStonePanel.Dialog.curSoulStone, text, textureList);
		FGUIManager.Instance.SetSoulStoneIconAndFrame(CompoundSoulStonePanel.Dialog.aimSoulStone, itemId, textureList);
		UpdateCompoundSoulStoneDialog();
		if (!isInit)
		{
			FGUIManager.Instance.AddTextSpecialEffects(CompoundSoulStonePanel.Dialog.aimSoulStoneSfxBck, "activating_white", new Vector3(180f, 180f, 180f), "Default", 0.5f, delegate(GameObject activatingWhite)
			{
				activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.3f;
			});
			((GObject)CompoundSoulStonePanel.Dialog.aimSoulStone).TweenFade(1f, 0.3f);
			if (((GObject)CompoundSoulStonePanel.Dialog.tip1).data.ToString() == itemId)
			{
				((GObject)CompoundSoulStonePanel.Dialog.tip1).visible = true;
				FGUIManager.Instance.AddTextSpecialEffects(CompoundSoulStonePanel.Dialog.tip1SfxBack, FGUIManager.Instance.uiGreen, new Vector3(120f, 120f, 120f));
			}
			else
			{
				((GObject)CompoundSoulStonePanel.Dialog.tip1).visible = false;
			}
		}
	}

	private void TurnPageLeftBtnEvent()
	{
		Controller status = CompoundSoulStonePanel.Dialog.Status;
		int selectedIndex = status.selectedIndex;
		status.selectedIndex = selectedIndex - 1;
		UpdateSoulStoneIconAndData(isInit: false);
	}

	private void TurnPageRightBtnEvent()
	{
		Controller status = CompoundSoulStonePanel.Dialog.Status;
		int selectedIndex = status.selectedIndex;
		status.selectedIndex = selectedIndex + 1;
		UpdateSoulStoneIconAndData(isInit: false);
	}

	private void CloseCompoundSoulStonePanel()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		((GObject)CompoundSoulStonePanel.Dialog.ConfirmBtn).onClick.Remove(new EventCallback1(CompoundSoulStone));
		((GObject)CompoundSoulStonePanel.Dialog.MaxBtn).onClick.Remove(new EventCallback0(CompoundSoulStoneMaxEvent));
		((GObject)CompoundSoulStonePanel.Dialog.increaseBtn).onClick.Remove(new EventCallback0(IncreaseCompoundNum));
		((GObject)CompoundSoulStonePanel.Dialog.reduceBtn).onClick.Remove(new EventCallback0(ReduceCompoundNum));
		((GObject)CompoundSoulStonePanel.Dialog.TurnPageLeftBtn).onClick.Remove(new EventCallback0(TurnPageLeftBtnEvent));
		((GObject)CompoundSoulStonePanel.Dialog.TurnPageRightBtn).onClick.Remove(new EventCallback0(TurnPageRightBtnEvent));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)CompoundSoulStonePanel, true);
	}

	private void OpenDrawPanel()
	{
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ContractPanel.Name, new Dictionary<string, object> { { "Parent", this } });
		}
		else
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	private void UpdateSoulStonePanelOnGetStones(string uiName)
	{
		if (uiName == UI_ContractPanel.Name)
		{
			ChangePageEvent();
		}
	}

	private void CompoundSoulStone(EventContext eventContext)
	{
		int num = Shift.Legion.Common.Models.Item.Rarity(((GObject)SoldierSoulStonePanel.soulStoneSelectList).data.ToString());
		if (num > 6)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText665") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
		}
		else if (soldier.PotentialLevel < 8)
		{
			Dictionary<string, int> dictionary = soldier.NextLevelPotential.Requirements(GameManagers.Instance);
			if (dictionary != null && dictionary.Count > 0)
			{
				string itemId = dictionary.Keys.First();
				if (num >= Shift.Legion.Common.Models.Item.Rarity(itemId))
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
					{
						{
							"Content",
							LanguagesManager.GetDesc("CsharpCodeZhTcText666") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText667") + "？"
						},
						{
							"Buttons",
							new Dictionary<string, Action>
							{
								{
									"Confirm",
									delegate
									{
										CompoundSoulEvent(eventContext);
									}
								},
								{ "Cancel", null }
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
					CompoundSoulEvent(eventContext);
				}
			}
			else
			{
				CompoundSoulEvent(eventContext);
			}
		}
		else
		{
			CompoundSoulEvent(eventContext);
		}
	}

	private void CompoundSoulEvent(EventContext eventContext)
	{
		lastSoulData = GetSoulStoneAndNum();
		string curPieceItemId = ((GObject)SoldierSoulStonePanel.soulStoneSelectList).data.ToString();
		List<Pieces> soulStoneCompositeDataBySoldier = PiecesManager.GetSoulStoneCompositeDataBySoldier(soldierId);
		Pieces curPiece = soulStoneCompositeDataBySoldier.FirstOrDefault((Pieces stone) => stone.ItemId == curPieceItemId);
		if (curPiece == null)
		{
			return;
		}
		ILRequestHelper<PiecesCompositeResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().PiecesComposite(-1L, curPiece.PiecesId, 1), delegate(PiecesCompositeResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				ActionResult actionResult = GameManagers.Instance.PiecesManager.Composite(curPiece.PiecesId, 1, broadcastInform: true);
				if (!actionResult.Result)
				{
					ILRequestHelper.ShowMessage(actionResult.ErrorMessage);
				}
				else
				{
					SoldierSoulStonePanelUpdate("CompoundSoulEvent");
				}
			}
		});
	}

	private void QuickCompoundSoulStone(EventContext eventContext)
	{
		lastSoulData = GetSoulStoneAndNum();
		int potentialLevel = (int)((GObject)SoldierSoulStonePanel.QuickCompoundBtn).data;
		ILRequestHelper<SoulStoneMaxCompositeToResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().SoulStoneMaxCompositeTo(-1L, soldierId, potentialLevel), delegate(SoulStoneMaxCompositeToResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				SoldierSoulStonePanelUpdate("QuickCompoundSoulStone 1");
			}
			else
			{
				if (response.CompositeResult != null)
				{
					StockChangeRecord[] array = new StockChangeRecord[response.CompositeResult.Count];
					int num = 0;
					foreach (KeyValuePair<string, int> item in response.CompositeResult)
					{
						string key = item.Key;
						int value = item.Value;
						array[num++] = new StockChangeRecord
						{
							ItemId = key,
							Offset = value,
							Context = 18,
							ContextValue = soldierId,
							Type = 1
						};
					}
					GameManagers.Instance.StockController.ReadStockChangeRecords(array);
				}
				if (response.CompositeInformData != null)
				{
					foreach (CompositeInformData informData in response.CompositeInformData)
					{
						SharedMessenger.Broadcast("PIECES_COMPOUND", new Pieces(GDMgr.Get<GDEPiecesData>(informData.PiecesId)), informData.CompositeCnt, informData.CompositeResult, informData.BonusList.Select(delegate(ModelsBonus bonusInfoKv)
						{
							ModelsBonus modelsBonus = informData.BonusList.First();
							Bonus key2 = Bonus.Get(bonusInfoKv.ItemId, bonusInfoKv.Qty, bonusInfoKv.Type);
							return new KeyValuePair<Bonus, int>(key2, modelsBonus.IsShining);
						}).ToList());
					}
				}
				SoldierSoulStonePanelUpdate("QuickCompoundSoulStone 2");
			}
		});
	}

	private bool HasPiecesToCompositeUtilLevel(int targetPotentialLevel)
	{
		List<Pieces> soulStoneCompositeDataBySoldier = PiecesManager.GetSoulStoneCompositeDataBySoldier(soldierId);
		if (soulStoneCompositeDataBySoldier == null)
		{
			return false;
		}
		for (int i = 1; i <= targetPotentialLevel + 1; i++)
		{
			SoldierPotentialData soldierPotential = ConfigDataManager.GetSoldierPotential(soldierId, i);
			if (soldierPotential == null)
			{
				continue;
			}
			List<Pieces> piecesDataByCompositeResult = PiecesManager.GetPiecesDataByCompositeResult(soulStoneCompositeDataBySoldier, soldierPotential.Requirements(GameManagers.Instance).Keys.ToArray());
			foreach (Pieces item in piecesDataByCompositeResult)
			{
				int maxComposite = GameManagers.Instance.PiecesManager.GetMaxComposite(item.PiecesId);
				if (maxComposite > 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void CompoundSoulStoneMaxEvent()
	{
		int num = Convert.ToInt32(((GObject)CompoundSoulStonePanel.Dialog.MaxBtn).data);
		((GObject)CompoundSoulStonePanel.Dialog.compoundNum).text = $"{num}";
		((GObject)CompoundSoulStonePanel.Dialog.compoundNum).data = num;
		UpdateCompoundSoulStoneDialog();
	}

	private void IncreaseCompoundNum()
	{
		int num = Convert.ToInt32(((GObject)CompoundSoulStonePanel.Dialog.compoundNum).data);
		int num2 = Convert.ToInt32(((GObject)CompoundSoulStonePanel.Dialog.MaxBtn).data);
		if (num < num2)
		{
			((GObject)CompoundSoulStonePanel.Dialog.compoundNum).data = num + 1;
			UpdateCompoundSoulStoneDialog();
		}
	}

	private void ReduceCompoundNum()
	{
		int num = Convert.ToInt32(((GObject)CompoundSoulStonePanel.Dialog.compoundNum).data);
		if (num > 0)
		{
			((GObject)CompoundSoulStonePanel.Dialog.compoundNum).data = num - 1;
			UpdateCompoundSoulStoneDialog();
		}
	}

	private void UpdateCompoundSoulStoneDialog()
	{
		int num = Convert.ToInt32(((GObject)CompoundSoulStonePanel.Dialog.compoundNum).data);
		int num2 = Convert.ToInt32(((GObject)CompoundSoulStonePanel.Dialog.MaxBtn).data);
		int num3 = Convert.ToInt32(((GObject)CompoundSoulStonePanel.Dialog.curSoulStone).data);
		int num4 = Convert.ToInt32(((GObject)CompoundSoulStonePanel.Dialog.aimSoulStone).data);
		if (num == 0)
		{
			((GObject)CompoundSoulStonePanel.Dialog.ConfirmBtn).enabled = false;
		}
		else
		{
			((GObject)CompoundSoulStonePanel.Dialog.ConfirmBtn).enabled = true;
		}
		string text = "#AFF627";
		string text2 = "#FFFFFF";
		string text3 = "#e72521";
		string text4 = ((num == num2) ? text3 : text);
		string arg = ((num > 0) ? text : text2);
		((GObject)CompoundSoulStonePanel.Dialog.curNum).text = $"[color={text4}]{num3 - num * 3}[/color]/[color={text2}]{3}[/color]";
		((GObject)CompoundSoulStonePanel.Dialog.aimNum).text = $"[color={arg}]{num + num4}[/color]";
		((GObject)CompoundSoulStonePanel.Dialog.compoundNum).text = $"{num}";
	}

	private void SoulStonesAddClickEvent()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		for (int i = 0; i < 3; i++)
		{
			GButton asButton = ((GComponent)SoldierPotentialPanel).GetChild($"SoulStone{i}").asButton;
			((GObject)asButton).onClick.Add(new EventCallback1(OpenSoulStoneResPanel));
		}
		if (MythAvailable)
		{
			for (int j = 0; j < 4; j++)
			{
				GButton asButton2 = ((GComponent)SoldierMythPage).GetChild($"SoulStone{j}").asButton;
				((GObject)asButton2).onClick.Add(new EventCallback1(OpenSoulStoneResPanel));
			}
		}
	}

	private void SoulStonesRemoveClickEvent()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected O, but got Unknown
		for (int i = 0; i < 3; i++)
		{
			GButton asButton = ((GComponent)SoldierPotentialPanel).GetChild($"SoulStone{i}").asButton;
			((GObject)asButton).onClick.Remove(new EventCallback1(OpenSoulStoneResPanel));
		}
		if (MythAvailable)
		{
			for (int j = 0; j < 4; j++)
			{
				GButton asButton2 = ((GComponent)SoldierMythPage).GetChild($"SoulStone{j}").asButton;
				((GObject)asButton2).onClick.Remove(new EventCallback1(OpenSoulStoneResPanel));
			}
		}
	}

	private void OpenRecruitingCamp()
	{
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("10").Status == BuildingStatus.Banned)
		{
			List<string> arg = new List<string>
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
				LanguagesManager.GetDesc("CsharpCodeZhTcText22")
			};
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
		else if (GameManagers.Instance.BuildingManager.GetBuildingByType("10").Status == BuildingStatus.Ready)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("Parent", this);
			dictionary.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType("10"));
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary);
		}
		else if (GameManagers.Instance.BuildingManager.GetBuildingByType("10").Level == 0)
		{
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			dictionary2.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType("10"));
			dictionary2.Add("Parent", this);
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary2);
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_RecruitingCamp.Name, null);
		}
	}

	public void BeforeDestroy()
	{
		GameManagers.Instance.NewMsgIncomingManager.SoldierChecked(soldierId);
	}

	public void Init([NotNull] Dictionary<string, object> parameters)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		DetailPage = null;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		((GObject)this).sortingOrder = 1;
		soldierId = (string)parameters["soldierId"];
		selectPanel = (GameObject)parameters["soldierPanel"];
		UnlockSoldier = (List<Soldier>)parameters["UnlockSoldierList"];
		if (parameters.ContainsKey("isFGUI"))
		{
			isFGUI = (bool)parameters["isFGUI"];
			legionPanel = (UI_LegionPanel)parameters["LegionPanel"];
		}
		showLegendItemSlot = GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1005").Contains("P520");
		showLegendItemSlot |= LegendItemsHelper.HasAnyLegendItem;
		ClearSoldierChangedInfo();
		UpdateWorkerNum();
		pageControll = PageControll;
		parameters.TryGetValue("Tab", out var value);
		if (value == null)
		{
			value = 0;
		}
		InitOccupation();
		LoadUnlockSoldier();
		SetPageBtnStatus();
		UpdateSoldierInfo();
		SetBuildingName();
		int currentPageIndex = (pageControll.selectedIndex = (int)value);
		CurrentPageIndex = currentPageIndex;
		ChangePageEvent();
		SoldierName.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		addWorkerBtn.GetChild("CurrentWorkerAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		addWorkerBtn.GetChild("separate").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		addWorkerBtn.GetChild("AllWorkerAmount").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		((GComponent)SoldierInfoPanel.UpSoldierLevelBtn).GetChild("level").asTextField.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		CombatPower.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		SoldierCultivatePanel = this;
	}

	private void InitOccupation()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		if (!HotUpdateProcess.Instance.IsRegionOutCN)
		{
			isOccupationeShow.SetSelectedIndex(1);
			((GObject)occupationePicture).onClick.Set((EventCallback0)delegate
			{
				UI_OccupationPanel.Show(soldier.Occupation);
			});
		}
	}

	private void RefreshOccupation()
	{
		if (!HotUpdateProcess.Instance.IsRegionOutCN)
		{
			OccupationBtn.Type.SetSelectedIndex(soldier.Occupation.Index);
		}
	}

	public void OnShow()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("SoldierCultivate.CloseBtn", BackBtn);
		instance.Register("SoldierCultivate.TabInfo", InfoBtn);
		instance.Register("SoldierCultivate.TabBreakthrough", BreakThrougBtn);
		instance.Register("SoldierCultivate.TabEvolute", DegreeElevationBtn);
		instance.Register("SoldierCultivate.TabPotential", PotentialBtn);
		instance.Register("SoldierCultivate.TabSoulStone", SoulStoneBtn);
		instance.Register("SoldierCultivate.LevelUpBtn", SoldierInfoPanel.UpSoldierLevelBtn);
		instance.Register("SoldierCultivate.UpgradePotentialBtn", SoldierPotentialPanel.PromoteBtn);
		instance.Register("SoldierCultivate.FirstSoulStone", SoldierPotentialPanel.SoulStone0);
		instance.Register("SoldierCultivate.SecondSoulStone", SoldierPotentialPanel.SoulStone1);
		instance.Register("SoldierCultivate.ThirdSoulStone", SoldierPotentialPanel.SoulStone2);
		instance.Register("SoldierCultivate.FormationSoldierAmountBtn", FormationSoldierAmountBtn);
		SoldierPotentialPanel.SetButtonTitle();
	}

	public void Destroy()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("SoldierCultivate.CloseBtn", BackBtn);
		instance.Unregister("SoldierCultivate.TabInfo", InfoBtn);
		instance.Unregister("SoldierCultivate.TabBreakthrough", BreakThrougBtn);
		instance.Unregister("SoldierCultivate.TabEvolute", DegreeElevationBtn);
		instance.Unregister("SoldierCultivate.TabPotential", PotentialBtn);
		instance.Unregister("SoldierCultivate.TabSoulStone", SoulStoneBtn);
		instance.Unregister("SoldierCultivate.LevelUpBtn", SoldierInfoPanel.UpSoldierLevelBtn);
		instance.Unregister("SoldierCultivate.UpgradePotentialBtn", SoldierPotentialPanel.PromoteBtn);
		instance.Unregister("SoldierCultivate.FirstSoulStone", SoldierPotentialPanel.SoulStone0);
		instance.Unregister("SoldierCultivate.SecondSoulStone", SoldierPotentialPanel.SoulStone1);
		instance.Unregister("SoldierCultivate.ThirdSoulStone", SoldierPotentialPanel.SoulStone2);
		instance.Unregister("SoldierCultivate.FormationSoldierAmountBtn", FormationSoldierAmountBtn);
		instance.Unregister("SoldierCultivate.Weapons");
		if (ExperiencePage != null)
		{
			((GComponent)this).RemoveChild((GObject)(object)ExperiencePage, true);
			for (int num = progressBarSfxBackList.Count - 1; num >= 0; num--)
			{
				((GComponent)this).RemoveChild((GObject)(object)progressBarSfxBackList[num], true);
			}
			progressBarSfxBackList.Clear();
		}
		if (DetailPage != null)
		{
			CloseDetailPage();
		}
		SoldierCultivatePanel = null;
		foreach (GTweener value in _timeoutDict.Values)
		{
			value.Kill(false);
		}
		_timeoutDict.Clear();
		GTweener obj = soldierPotentialPanelGTweenerFoo;
		if (obj != null)
		{
			obj.Kill(false);
		}
		GTweener obj2 = soldierPotentialPanelGTweenerBar;
		if (obj2 != null)
		{
			obj2.Kill(false);
		}
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected O, but got Unknown
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected O, but got Unknown
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected O, but got Unknown
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Expected O, but got Unknown
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected O, but got Unknown
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Expected O, but got Unknown
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Expected O, but got Unknown
		//IL_0461: Unknown result type (might be due to invalid IL or missing references)
		//IL_046b: Expected O, but got Unknown
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Add(new EventCallback0(ExitPanel));
		((GObject)BreakThrougBtn).onClick.Add(new EventCallback1(ChangePage));
		((GObject)DegreeElevationBtn).onClick.Add(new EventCallback1(ChangePage));
		((GObject)InfoBtn).onClick.Add(new EventCallback1(ChangePage));
		((GObject)PotentialBtn).onClick.Add(new EventCallback1(ChangePage));
		((GObject)SoulStoneBtn).onClick.Add(new EventCallback1(ChangePage));
		((GObject)SoldierInfoPanel.DetailedInfoBtn).onClick.Add(new EventCallback0(ShowDetailInfo));
		((GObject)SoldierInfoPanel.UpSoldierLevelBtn).onClick.Set((EventCallback0)delegate
		{
			ShowExperiencePage();
		});
		((GObject)SoldierBreakthrougPanel.ActivityBtn).onClick.Add(new EventCallback0(ActiveBtnEvent));
		((GObject)DegreeElevationPanel.DegreeElevationUp_Btn).onClick.Add(new EventCallback1(ElevationBtnEvent));
		((GObject)SoldierPotentialPanel.PromoteBtn).onClick.Add(new EventCallback1(PromoteBtnEvent));
		PageControll.onChanged.Add(new EventCallback0(CloseExperiencePageOnSwitchTAB));
		((GObject)TurnPageLeftBtn).data = -1;
		((GObject)TurnPageRightBtn).data = 1;
		((GObject)TurnPageLeftBtn).onClick.Add(new EventCallback1(PageTurning));
		((GObject)TurnPageRightBtn).onClick.Add(new EventCallback1(PageTurning));
		((GObject)FormationSoldierAmountBtn).onClick.Add(new EventCallback0(ShowSoldierFormationInfoPanel));
		((GObject)SoldierBreakthrougPanel.SoldierPromotionBtn).data = 1;
		((GObject)SoldierBreakthrougPanel.SoldierPromotionBtn).onClick.Add(new EventCallback1(OpenSoldierPromotionPanel));
		((GObject)DegreeElevationPanel.SoldierPromotionBtn).onClick.Add(new EventCallback0(ShowNextEvoLevelGrowUp));
		((GObject)SoldierPotentialPanel.UnlockSoldierBtn).data = 0;
		((GObject)SoldierPotentialPanel.UnlockSoldierBtn).onClick.Add(new EventCallback1(OpenSoldierPromotionPanel));
		((GObject)((GComponent)SoldierPotentialPanel.UnlockSkillList).GetChildAt(0).asButton).onClick.Add(new EventCallback1(SkillDetailPopupForPotentialUnlcok));
		((GObject)SoldierPotentialPanel.SoldierPromotionBtn).onClick.Add(new EventCallback0(OpenPotentialTip));
		((GObject)SoldierSoulStonePanel.CompoundBtn).onClick.Add(new EventCallback1(CompoundSoulStone));
		((GObject)SoldierSoulStonePanel.QuickCompoundBtn).onClick.Add(new EventCallback1(QuickCompoundSoulStone));
		((GObject)SoldierSoulStonePanel.QuicklyGain).onClick.Add(new EventCallback0(OpenDrawPanel));
		((GObject)RecruitingCampBtn).onClick.Add(new EventCallback0(OpenRecruitingCamp));
		((GObject)SoldierPotentialPanel.specialityBtn).onClick.Add(new EventCallback1(OpenSpecialityPanel));
		((GObject)SoldierInfoPanel.attackPropertyBtn).onClick.Add((EventCallback0)delegate
		{
			OpenAttackAndDefense((GObject)(object)SoldierInfoPanel.attackPropertyBtn, type: true, soldier.DamageType);
		});
		((GObject)SoldierInfoPanel.defensePropertyBtn).onClick.Add((EventCallback0)delegate
		{
			OpenAttackAndDefense((GObject)(object)SoldierInfoPanel.defensePropertyBtn, type: false, soldier.ArmorType);
		});
		MythEventRegister();
		ProductList = (GButton[])(object)new GButton[4] { DegreeElevationPanel.Product1, DegreeElevationPanel.Product2, DegreeElevationPanel.Product3, DegreeElevationPanel.Product4 };
		SoulStonesAddClickEvent();
		((GObject)DiamondBtn).onClick.Add(new EventCallback0(AddDiamondEvent));
		addWorkerBtn.GetChild("addButton").onClick.Add(new EventCallback0(AddWorkerEvent));
		((GObject)SoldierVoiceClick).onClick.Add(new EventCallback0(PlaySoldierVoice));
		SharedMessenger.AddListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		SharedMessenger.AddListener<string, int>("ON_SOLDIER_GET_EXP", UpdateSoldierExpBarOnGetExp);
		SharedMessenger.AddListener<string, int, int>("SOLDIER_LEVEL_CHANGED", UpdateSoldierExpBarOnLevelUp);
		SharedMessenger.AddListener<string>("CLOSE_UI", UpdateSoldierCombat);
		Timers.inst.Add(0.8f, 0, new TimerCallback(UpdateStock));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected O, but got Unknown
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected O, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Expected O, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Expected O, but got Unknown
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Expected O, but got Unknown
		//IL_0442: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Expected O, but got Unknown
		((GObject)BackBtn).onClick.Remove(new EventCallback0(ExitPanel));
		((GObject)BreakThrougBtn).onClick.Remove(new EventCallback1(ChangePage));
		((GObject)DegreeElevationBtn).onClick.Remove(new EventCallback1(ChangePage));
		((GObject)InfoBtn).onClick.Remove(new EventCallback1(ChangePage));
		((GObject)PotentialBtn).onClick.Remove(new EventCallback1(ChangePage));
		((GObject)SoulStoneBtn).onClick.Remove(new EventCallback1(ChangePage));
		((GObject)SoldierInfoPanel.DetailedInfoBtn).onClick.Remove(new EventCallback0(ShowDetailInfo));
		((GObject)SoldierInfoPanel.UpSoldierLevelBtn).onClick.Remove((EventCallback0)delegate
		{
			ShowExperiencePage();
		});
		((GObject)SoldierBreakthrougPanel.ActivityBtn).onClick.Remove(new EventCallback0(ActiveBtnEvent));
		((GObject)DegreeElevationPanel.DegreeElevationUp_Btn).onClick.Remove(new EventCallback1(ElevationBtnEvent));
		PageControll.onChanged.Remove(new EventCallback0(CloseExperiencePageOnSwitchTAB));
		((GObject)TurnPageLeftBtn).onClick.Remove(new EventCallback1(PageTurning));
		((GObject)TurnPageRightBtn).onClick.Remove(new EventCallback1(PageTurning));
		((GObject)FormationSoldierAmountBtn).onClick.Remove(new EventCallback0(ShowSoldierFormationInfoPanel));
		((GObject)SoldierBreakthrougPanel.SoldierPromotionBtn).onClick.Remove(new EventCallback1(OpenSoldierPromotionPanel));
		((GObject)DegreeElevationPanel.SoldierPromotionBtn).onClick.Remove(new EventCallback0(ShowNextEvoLevelGrowUp));
		((GObject)SoldierPotentialPanel.UnlockSoldierBtn).onClick.Remove(new EventCallback1(OpenSoldierPromotionPanel));
		((GObject)((GComponent)SoldierPotentialPanel.UnlockSkillList).GetChildAt(0).asButton).onClick.Remove(new EventCallback1(SkillDetailPopupForPotentialUnlcok));
		((GObject)SoldierPotentialPanel.SoldierPromotionBtn).onClick.Remove(new EventCallback0(OpenPotentialTip));
		((GObject)SoldierSoulStonePanel.CompoundBtn).onClick.Remove(new EventCallback1(CompoundSoulStone));
		((GObject)SoldierSoulStonePanel.QuickCompoundBtn).onClick.Remove(new EventCallback1(QuickCompoundSoulStone));
		((GObject)SoldierSoulStonePanel.QuicklyGain).onClick.Remove(new EventCallback0(OpenDrawPanel));
		((GObject)RecruitingCampBtn).onClick.Remove(new EventCallback0(OpenRecruitingCamp));
		((GObject)SoldierPotentialPanel.specialityBtn).onClick.Remove(new EventCallback1(OpenSpecialityPanel));
		((GObject)SoldierInfoPanel.attackPropertyBtn).onClick.Remove((EventCallback0)delegate
		{
			OpenAttackAndDefense((GObject)(object)SoldierInfoPanel.attackPropertyBtn, type: true, soldier.DamageType);
		});
		((GObject)SoldierInfoPanel.defensePropertyBtn).onClick.Remove((EventCallback0)delegate
		{
			OpenAttackAndDefense((GObject)(object)SoldierInfoPanel.defensePropertyBtn, type: false, soldier.ArmorType);
		});
		MythEventUnRegister();
		SoulStonesRemoveClickEvent();
		((GObject)DegreeElevationPanel.DegreeElevationUp_Btn).onClick.Remove(new EventCallback1(ElevationBtnEvent));
		((GObject)DiamondBtn).onClick.Remove(new EventCallback0(AddDiamondEvent));
		addWorkerBtn.GetChild("addButton").onClick.Remove(new EventCallback0(AddWorkerEvent));
		((GObject)SoldierVoiceClick).onClick.Remove(new EventCallback0(PlaySoldierVoice));
		SharedMessenger.RemoveListener<Building>("WORKERS_ALLOCATION_DISPLAY_CHANGED", UpdateWorkerNum);
		SharedMessenger.RemoveListener<string, int>("ON_SOLDIER_GET_EXP", UpdateSoldierExpBarOnGetExp);
		SharedMessenger.RemoveListener<string, int, int>("SOLDIER_LEVEL_CHANGED", UpdateSoldierExpBarOnLevelUp);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", UpdateSoldierCombat);
		Timers.inst.Remove(new TimerCallback(UpdateStock));
	}

	private void PlaySoldierVoice()
	{
		UiAudioManager.Instance.PlaySoldierVoice(soldierId, UiAudioManager.SoldierVoiceType.Voice);
	}

	private void UpdateSoldierCombat(string uiName)
	{
		if (uiName == UI_ProductUpGradePanel.Name)
		{
			LoaderSoldierData(soldierId);
		}
		UpdateSoulStonePanelOnGetStones(uiName);
	}

	private void CloseDetailPage()
	{
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)DetailPage, true);
		DetailPage = null;
	}

	private void SetBuildingName()
	{
		((GObject)Title.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText537");
	}

	private void UpdateSoldierInfo(bool needResetSelectedIndex = true)
	{
		if (DetailPage != null && !DetailPage.showSelf.playing)
		{
			CloseDetailPage();
		}
		LoaderSoldierData(UnlockSoldier[SoldierIndex].Id);
		if (needResetSelectedIndex)
		{
			int currentPageIndex = (pageControll.selectedIndex = 0);
			CurrentPageIndex = currentPageIndex;
			ChangePageEvent();
		}
		UpdateRedNoteStatus();
	}

	public void LoadUnlockSoldier()
	{
		for (int i = 0; i < UnlockSoldier.Count; i++)
		{
			if (UnlockSoldier[i].Id == soldierId)
			{
				SoldierIndex = i;
				break;
			}
		}
	}

	private void PageTurning(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int direction = (int)((GObject)(GButton)context.sender).data;
		PageRefresh(direction);
	}

	private void PageRefresh(int direction)
	{
		GameManagers.Instance.NewMsgIncomingManager.SoldierChecked(soldierId);
		ClearSoldierChangedInfo();
		LoadUnlockSoldier();
		SoldierIndex += direction;
		if (SoldierIndex < 0)
		{
			SoldierIndex = 0;
		}
		else if (SoldierIndex > UnlockSoldier.Count - 1)
		{
			SoldierIndex = UnlockSoldier.Count - 1;
		}
		if (soldierPotentialPanelGTweenerFoo != null)
		{
			soldierPotentialPanelGTweenerFoo.Kill(false);
		}
		if (soldierPotentialPanelGTweenerBar != null)
		{
			soldierPotentialPanelGTweenerBar.Kill(false);
		}
		SetPageBtnStatus();
		UpdateSoldierInfo(needResetSelectedIndex: false);
	}

	private void SetPageBtnStatus()
	{
		if (SoldierIndex == 0)
		{
			((GObject)TurnPageLeftBtn).enabled = false;
			((GObject)TurnPageRightBtn).enabled = true;
		}
		else if (SoldierIndex == UnlockSoldier.Count - 1)
		{
			((GObject)TurnPageLeftBtn).enabled = true;
			((GObject)TurnPageRightBtn).enabled = false;
		}
		else
		{
			((GObject)TurnPageLeftBtn).enabled = true;
			((GObject)TurnPageRightBtn).enabled = true;
		}
	}

	public void ChangeSoldier(bool flag)
	{
		if (flag)
		{
			SoldierIndex++;
			if (SoldierIndex < UnlockSoldier.Count)
			{
				soldierId = UnlockSoldier[SoldierIndex].Id;
			}
			else
			{
				SoldierIndex--;
			}
		}
		else
		{
			SoldierIndex--;
			if (SoldierIndex >= 0)
			{
				soldierId = UnlockSoldier[SoldierIndex].Id;
			}
			else
			{
				SoldierIndex++;
			}
		}
		int currentPageIndex = (pageControll.selectedIndex = 0);
		CurrentPageIndex = currentPageIndex;
		LoaderSoldierData(soldierId);
	}

	public void ChangePage(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int num = int.Parse(((GObject)context.sender).data.ToString());
		int currentPageIndex = (pageControll.selectedIndex = num);
		CurrentPageIndex = currentPageIndex;
		ChangePageEvent();
	}

	public void ChangePageEvent(bool isUpPotential = false)
	{
		if (CurrentPageIndex == 0)
		{
			RefreshSoldierDetailInfo(soldier, isInit: true);
		}
		else if (CurrentPageIndex == 1)
		{
			RefreshBreakthroughData(needSpecialeffects: false);
		}
		else if (CurrentPageIndex == 2)
		{
			RefreshDegreeElevationData();
		}
		else if (CurrentPageIndex == 3)
		{
			SoldierPotentialPanelUpdate(null, isUpPotential);
		}
		else if (CurrentPageIndex == 4)
		{
			lastSoulData.Clear();
			SoldierSoulStonePanelUpdate("ChangePageEvent");
		}
		SharedMessenger.Broadcast("OPEN_UI", Name, new Dictionary<string, object> { { "Tab", pageControll.selectedIndex } });
	}

	private void ClearSoldierChangedInfo()
	{
		levelChanged = false;
		evoLevelChanged = false;
		potentialLevelChanged = false;
		potentialProgressChanged = false;
		legendItemsChanged = false;
		lastLegendItemSoldierId = "";
	}

	private void RefreshLegionPanelSoldierBtnForClose()
	{
		if (isFGUI && legionPanel != null && !((GObject)legionPanel).isDisposed)
		{
			legionPanel.UpdateSoldierBtnFromCultivate(soldierId, legendItemsChanged, lastLegendItemSoldierId);
			((GObject)legionPanel.armsBtn.note).visible = GameManagers.Instance.NewMsgIncomingManager.AnySoldierHasNewMsg(flush: true);
		}
	}

	public void ExitPanel()
	{
		RefreshLegionPanelSoldierBtnForClose();
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		if ((Object)(object)selectPanel != (Object)null)
		{
			selectPanel.SetActive(true);
		}
		UI_LegendItemDungeonPanel.legendItemDungeonPanel?.SoldiersRender();
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	private void OpenPotentialTip()
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Expected O, but got Unknown
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		if (soldier.NextLevelPotential == null)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText542") + "," + LanguagesManager.GetDesc("CsharpCodeZhTcText543") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		SoldierPotentialTip = UI_SoldierPotentialTipPanel.CreateInstance();
		((GObject)SoldierPotentialTip.mask).onClick.Set((EventCallback0)delegate
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)SoldierPotentialTip);
			((GObject)SoldierPotentialTip).Dispose();
		});
		UI_PotentialLevelText_small uI_PotentialLevelText_small = (UI_PotentialLevelText_small)(object)SoldierPotentialTip.Tip.curPotential;
		if (uI_PotentialLevelText_small != null)
		{
			((GComponent)uI_PotentialLevelText_small).GetController("Level").selectedIndex = soldier.PotentialLevel;
			uI_PotentialLevelText_small.SetLPotentialLevelImage(soldier.PotentialLevel, MythAvailable);
		}
		((GObject)SoldierPotentialTip.Tip.curAttack).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(soldier.Attack)}") ?? "";
		((GObject)SoldierPotentialTip.Tip.curDefense).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(soldier.Defense)}") ?? "";
		((GObject)SoldierPotentialTip.Tip.curHealth).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(soldier.Health)}") ?? "";
		FakeSoldier fakeSoldier = new FakeSoldier(soldierId, soldier.Level, soldier.EvoLevel, soldier.NextPotentialLevel);
		UI_PotentialLevelText_small uI_PotentialLevelText_small2 = (UI_PotentialLevelText_small)(object)SoldierPotentialTip.Tip.nextPotential;
		if (uI_PotentialLevelText_small2 != null)
		{
			((GComponent)uI_PotentialLevelText_small2).GetController("Level").selectedIndex = fakeSoldier.PotentialLevel;
			uI_PotentialLevelText_small2.SetLPotentialLevelImage(fakeSoldier.PotentialLevel, MythAvailable);
		}
		((GObject)SoldierPotentialTip.Tip.nextAttack).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(fakeSoldier.Attack)}") ?? "";
		((GObject)SoldierPotentialTip.Tip.nextDefense).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(fakeSoldier.Defense)}") ?? "";
		((GObject)SoldierPotentialTip.Tip.nextHealth).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(fakeSoldier.Health)}") ?? "";
		float y = ((GObject)SoldierPotentialTip.Tip).y;
		Dictionary<string, int> dictionary = soldier.AbilitiesUnlockState();
		SoldierPotentialTip.Tip.PageController.selectedIndex = 0;
		foreach (KeyValuePair<string, int> item in dictionary)
		{
			if (item.Value == soldier.NextPotentialLevel)
			{
				GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(item.Key);
				if (gDEAbilityData.Visible)
				{
					((GObject)SoldierPotentialTip.Tip.skillName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText544") + ":" + gDEAbilityData.Name;
					SoldierPotentialTip.Tip.SkillIconLoader.LoadAbilityIcon(gDEAbilityData.Icon);
					SoldierPotentialTip.Tip.PageController.selectedIndex = 1;
					((GObject)SoldierPotentialTip.Tip.SkillIconLoader).data = new KeyValuePair<GDEAbilityData, bool>(gDEAbilityData, item.Value <= soldier.PotentialLevel);
					((GObject)SoldierPotentialTip.Tip.SkillIconLoader).onClick.Set(new EventCallback1(SkillDetailPopupForPotentialTip));
					break;
				}
			}
		}
		if (SoldierPotentialTip.Tip.PageController.selectedIndex == 0)
		{
			OpenShowNextPotentialLevelSoldierPanel();
			return;
		}
		((GObject)SoldierPotentialTip.Tip).y = y;
		((GObject)SoldierPotentialTip.Tip).SetScale(0.25f, 0.25f);
		((GObject)SoldierPotentialTip.Tip).alpha = 0f;
		((GComponent)GRoot.inst).AddChild((GObject)(object)SoldierPotentialTip);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)SoldierPotentialTip, scaleAdaption: true);
		((GObject)SoldierPotentialTip.Tip).TweenFade(1f, 0.2f);
		((GObject)SoldierPotentialTip.Tip).TweenScale(Vector2.one, 0.33f).SetEase((EaseType)26);
	}

	private void OpenShowNextPotentialLevelSoldierPanel()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		SoldierPromotionPanel = UI_SoldierPromotionPanel.CreateInstance();
		((GObject)SoldierPromotionPanel.mask).onClick.Set((EventCallback0)delegate
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)SoldierPromotionPanel);
			((GObject)SoldierPromotionPanel).Dispose();
		});
		FakeSoldier fakeSoldier = null;
		float y = ((GObject)DegreeElevationPanel).y + 1f;
		SoldierPromotionPanel.Dialog.PageController.selectedIndex = 2;
		fakeSoldier = new FakeSoldier(soldierId, soldier.Level, soldier.EvoLevel, soldier.NextPotentialLevel);
		int soldierLevelUpSfxNum = GetSoldierLevelUpSfxNum();
		if (soldierLevelUpSfxNum <= 2)
		{
			SoldierPromotionPanel.Dialog.Status.selectedIndex = 0;
		}
		else
		{
			SoldierPromotionPanel.Dialog.Status.selectedIndex = 1;
		}
		GameObject canvasObject1 = default(GameObject);
		ref GameObject reference = ref canvasObject1;
		Object obj = Object.Instantiate(Resources.Load("Items/Spine", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		canvasObject1.GetComponent<Canvas>().sortingLayerName = "Default";
		int potentialLevel = ((soldier.NextPotentialLevel <= 8) ? ((soldier.NextPotentialLevel + 2) / 2) : 6);
		SpawnManager.Instance.LoadSoldierSpine(canvasObject1, $"{soldierId}_skin{potentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (SoldierPromotionPanel != null && !((GObject)SoldierPromotionPanel).isDisposed)
			{
				SkeletonGraphic component = ((Component)canvasObject1.transform.GetChild(0)).gameObject.GetComponent<SkeletonGraphic>();
				component.skeletonDataAsset = asset;
				component.initialSkinName = $"skin{potentialLevel}";
				component.Initialize(true);
				((Component)canvasObject1.transform.GetChild(0)).gameObject.SetActive(true);
			}
		});
		canvasObject1.transform.localScale = new Vector3(0.84f, 0.84f, 0.84f);
		canvasObject1.transform.localPosition = -new Vector3(0f, 0f, 0f);
		canvasObject1.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		GoWrapper val = new GoWrapper(canvasObject1);
		((DisplayObject)val).SetXY(0.5f, 0.5f);
		((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
		SoldierPromotionPanel.Dialog.Spine.SetNativeObject((DisplayObject)(object)val);
		FGUIManager.Instance.AddTextSpecialEffects(SoldierPromotionPanel.Dialog.baseSpine, "MagicCircleBase", new Vector3(100f, 100f, 100f));
		FGUIManager.Instance.AddTextSpecialEffects(SoldierPromotionPanel.Dialog.maskSpine, "MagicCircleMask", new Vector3(100f, 100f, 100f));
		UI_PotentialLevelText_small uI_PotentialLevelText_small = (UI_PotentialLevelText_small)(object)SoldierPromotionPanel.Dialog.curPotential;
		if (uI_PotentialLevelText_small != null)
		{
			((GComponent)uI_PotentialLevelText_small).GetController("Level").selectedIndex = soldier.PotentialLevel;
			uI_PotentialLevelText_small.SetLPotentialLevelImage(soldier.PotentialLevel, MythAvailable);
		}
		UI_PotentialLevelText_small uI_PotentialLevelText_small2 = (UI_PotentialLevelText_small)(object)SoldierPromotionPanel.Dialog.nextPotential;
		if (uI_PotentialLevelText_small2 != null)
		{
			((GComponent)uI_PotentialLevelText_small2).GetController("Level").selectedIndex = soldier.NextPotentialLevel;
			uI_PotentialLevelText_small2.SetLPotentialLevelImage(soldier.NextPotentialLevel, MythAvailable);
		}
		((GObject)SoldierPromotionPanel.Dialog).y = y;
		((GObject)SoldierPromotionPanel.Dialog.CurAttackGrow).text = LanguagesManager.GetDesc("CsharpCodeZhTcText608") + "     [color=#D5BA7A]" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(soldier.Attack)}") + "[/color]";
		((GObject)SoldierPromotionPanel.Dialog.NextAttackGrow).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(fakeSoldier.Attack)}") ?? "";
		((GObject)SoldierPromotionPanel.Dialog.CurDefenseGrow).text = LanguagesManager.GetDesc("CsharpCodeZhTcText772") + "     [color=#D5BA7A]" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(soldier.Defense)}") + "[/color]";
		((GObject)SoldierPromotionPanel.Dialog.NextDefenseGrow).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(fakeSoldier.Defense)}") ?? "";
		((GObject)SoldierPromotionPanel.Dialog.CurHealthGrow).text = LanguagesManager.GetDesc("CsharpCodeZhTcText771") + "     [color=#D5BA7A]" + UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(soldier.Health)}") + "[/color]";
		((GObject)SoldierPromotionPanel.Dialog.NextHealthGrow).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(fakeSoldier.Health)}") ?? "";
		((GComponent)GRoot.inst).AddChild((GObject)(object)SoldierPromotionPanel);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)SoldierPromotionPanel, scaleAdaption: true);
		SoldierPromotionPanel.ShowDialog.Play();
	}

	private void ShowNextEvoLevelGrowUp()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		SoldierPromotionPanel = UI_SoldierPromotionPanel.CreateInstance();
		((GObject)SoldierPromotionPanel.mask).onClick.Set((EventCallback0)delegate
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)SoldierPromotionPanel);
			((GObject)SoldierPromotionPanel).Dispose();
		});
		FakeSoldier fakeSoldier = null;
		float num = ((GObject)DegreeElevationPanel).y + 1f;
		num = 275f;
		SoldierPromotionPanel.Dialog.PageController.selectedIndex = 0;
		SoldierPromotionPanel.Dialog.Status.selectedIndex = 3;
		fakeSoldier = new FakeSoldier(soldierId, soldier.Level, soldier.NextEvoLevel, soldier.PotentialLevel);
		((GObject)SoldierPromotionPanel.Dialog.EvoLevel).text = string.Format("{0}{1}", soldier.NextEvoLevel, LanguagesManager.GetDesc("CsharpCodeZhTcText372"));
		SoldierPromotionPanel.Dialog.EvolevelIcon.url = $"ui://PublicResources/icon_class_{soldier.NextEvoLevel}";
		((GObject)SoldierPromotionPanel.Dialog.curLevelLimit).text = $"{soldier.MaxLevel}";
		((GObject)SoldierPromotionPanel.Dialog.nextLevelLimit).text = $"{fakeSoldier.MaxLevel}";
		((GObject)SoldierPromotionPanel.Dialog).y = num;
		((GObject)SoldierPromotionPanel.Dialog.CurAttackGrow).text = string.Format("{0}     [color=#D5BA7A]{1}[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText608"), Convert.ToInt32(soldier.Attack));
		((GObject)SoldierPromotionPanel.Dialog.NextAttackGrow).text = $"{Convert.ToInt32(fakeSoldier.Attack)}";
		((GObject)SoldierPromotionPanel.Dialog.CurDefenseGrow).text = string.Format("{0}     [color=#D5BA7A]{1}[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText772"), Convert.ToInt32(soldier.Defense));
		((GObject)SoldierPromotionPanel.Dialog.NextDefenseGrow).text = $"{Convert.ToInt32(fakeSoldier.Defense)}";
		((GObject)SoldierPromotionPanel.Dialog.CurHealthGrow).text = string.Format("{0}     [color=#D5BA7A]{1}[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText771"), Convert.ToInt32(soldier.Health));
		((GObject)SoldierPromotionPanel.Dialog.NextHealthGrow).text = $"{Convert.ToInt32(fakeSoldier.Health)}";
		((GComponent)GRoot.inst).AddChild((GObject)(object)SoldierPromotionPanel);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)SoldierPromotionPanel, scaleAdaption: true);
		SoldierPromotionPanel.ShowDialog.Play();
	}

	private void OpenSoldierPromotionPanel(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		int num = Convert.ToInt32(((GObject)context.sender).data);
		SoldierPromotionPanel = UI_SoldierPromotionPanel.CreateInstance();
		((GObject)SoldierPromotionPanel.mask).onClick.Set((EventCallback0)delegate
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)SoldierPromotionPanel);
			((GObject)SoldierPromotionPanel).Dispose();
		});
		SoldierPromotionPanel.Dialog.PageController.selectedIndex = num;
		FakeSoldier fakeSoldier = null;
		SoldierPromotionPanel.PageController.selectedIndex = num;
		float y = ((GObject)DegreeElevationPanel).y + 1f;
		switch (num)
		{
		case 0:
		{
			SoldierPromotionPanel.Dialog.PageController.selectedIndex = 2;
			fakeSoldier = new FakeSoldier(soldierId, soldier.Level, soldier.EvoLevel, soldier.NextPotentialLevel);
			int soldierLevelUpSfxNum = GetSoldierLevelUpSfxNum();
			if (soldierLevelUpSfxNum <= 2)
			{
				SoldierPromotionPanel.Dialog.Status.selectedIndex = 0;
			}
			else
			{
				SoldierPromotionPanel.Dialog.Status.selectedIndex = 1;
			}
			GameObject canvasObject1 = default(GameObject);
			ref GameObject reference = ref canvasObject1;
			Object obj = Object.Instantiate(Resources.Load("Items/Spine", typeof(GameObject)));
			reference = (GameObject)(object)((obj is GameObject) ? obj : null);
			canvasObject1.GetComponent<Canvas>().sortingLayerName = "Default";
			int potentialLevel = ((soldier.NextPotentialLevel <= 8) ? ((soldier.NextPotentialLevel + 2) / 2) : 6);
			SpawnManager.Instance.LoadSoldierSpine(canvasObject1, $"{soldierId}_skin{potentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
			{
				if (SoldierPromotionPanel != null && !((GObject)SoldierPromotionPanel).isDisposed)
				{
					SkeletonGraphic component = ((Component)canvasObject1.transform.GetChild(0)).gameObject.GetComponent<SkeletonGraphic>();
					component.skeletonDataAsset = asset;
					component.initialSkinName = $"skin{potentialLevel}";
					component.Initialize(true);
					((Component)canvasObject1.transform.GetChild(0)).gameObject.SetActive(true);
				}
			});
			canvasObject1.transform.localScale = new Vector3(0.84f, 0.84f, 0.84f);
			canvasObject1.transform.localPosition = -new Vector3(0f, 0f, 0f);
			canvasObject1.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val = new GoWrapper(canvasObject1);
			((DisplayObject)val).SetXY(0.5f, 0.5f);
			((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
			SoldierPromotionPanel.Dialog.Spine.SetNativeObject((DisplayObject)(object)val);
			FGUIManager.Instance.AddTextSpecialEffects(SoldierPromotionPanel.Dialog.baseSpine, "MagicCircleBase", new Vector3(100f, 100f, 100f));
			FGUIManager.Instance.AddTextSpecialEffects(SoldierPromotionPanel.Dialog.maskSpine, "MagicCircleMask", new Vector3(100f, 100f, 100f));
			UI_PotentialLevelText_small uI_PotentialLevelText_small = (UI_PotentialLevelText_small)(object)SoldierPromotionPanel.Dialog.curPotential;
			if (uI_PotentialLevelText_small != null)
			{
				((GComponent)uI_PotentialLevelText_small).GetController("Level").selectedIndex = soldier.PotentialLevel;
				uI_PotentialLevelText_small.SetLPotentialLevelImage(soldier.PotentialLevel, MythAvailable);
			}
			UI_PotentialLevelText_small uI_PotentialLevelText_small2 = (UI_PotentialLevelText_small)(object)SoldierPromotionPanel.Dialog.nextPotential;
			if (uI_PotentialLevelText_small2 != null)
			{
				((GComponent)uI_PotentialLevelText_small2).GetController("Level").selectedIndex = soldier.NextPotentialLevel;
				uI_PotentialLevelText_small2.SetLPotentialLevelImage(soldier.NextPotentialLevel, MythAvailable);
			}
			break;
		}
		case 1:
			fakeSoldier = new FakeSoldier(soldierId, soldier.Level, soldier.EvoLevel, soldier.PotentialLevel);
			SoldierPromotionPanel.Dialog.Status.selectedIndex = 2;
			y = 320f;
			break;
		}
		((GObject)SoldierPromotionPanel.Dialog).y = y;
		((GObject)SoldierPromotionPanel.Dialog.CurAttackGrow).text = string.Format("{0}     [color=#D5BA7A]{1}[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText608"), Convert.ToInt32(soldier.Attack));
		((GObject)SoldierPromotionPanel.Dialog.NextAttackGrow).text = $"{Convert.ToInt32(fakeSoldier.Attack)}";
		((GObject)SoldierPromotionPanel.Dialog.CurDefenseGrow).text = string.Format("{0}     [color=#D5BA7A]{1}[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText772"), Convert.ToInt32(soldier.Defense));
		((GObject)SoldierPromotionPanel.Dialog.NextDefenseGrow).text = $"{Convert.ToInt32(fakeSoldier.Defense)}";
		((GObject)SoldierPromotionPanel.Dialog.CurHealthGrow).text = string.Format("{0}     [color=#D5BA7A]{1}[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText771"), Convert.ToInt32(soldier.Health));
		((GObject)SoldierPromotionPanel.Dialog.NextHealthGrow).text = $"{Convert.ToInt32(fakeSoldier.Health)}";
		((GComponent)GRoot.inst).AddChild((GObject)(object)SoldierPromotionPanel);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)SoldierPromotionPanel, scaleAdaption: true);
		SoldierPromotionPanel.ShowDialog.Play();
	}

	private void DirectlyToUpGradeEnd(UI_UpgradeSuccess panel)
	{
		if (panel.PageSwitch.selectedIndex != 0)
		{
			if (panel.showNextProperty1.playing)
			{
				panel.showNextProperty1.Stop();
			}
			((GObject)panel.nextSoldierIcon).alpha = 1f;
			((GObject)panel.nextFightGroup1).alpha = 1f;
			((GObject)panel.nextLevelGroup1).alpha = 1f;
			((GObject)panel.nextAttackGroup1).alpha = 1f;
			((GObject)panel.nextDeffenseGroup1).alpha = 1f;
			((GObject)panel.nextHealthGroup1).alpha = 1f;
			((GObject)panel.showSkill).alpha = 1f;
			((GObject)panel.confirmBtn).alpha = 1f;
			((GObject)panel.toEndMask).touchable = false;
			((GObject)panel.confirmBtn).touchable = true;
		}
	}

	private void DirectlyToBreakthroughEnd(UI_UpgradeSuccess panel, int starIndex)
	{
		if (panel.PageSwitch.selectedIndex == 0)
		{
			return;
		}
		if (panel.showNextProperty2.playing)
		{
			panel.showNextProperty2.Stop();
		}
		if (panel.starIncrease.playing)
		{
			panel.starIncrease.Stop();
		}
		((GObject)panel.nextSoldierIcon).alpha = 1f;
		((GObject)panel.nextFightGroup2).alpha = 1f;
		((GObject)panel.nextAttackGroup2).alpha = 1f;
		((GObject)panel.nextDeffenseGroup2).alpha = 1f;
		((GObject)panel.nextHealthGroup2).alpha = 1f;
		((GObject)panel.confirmBtn).alpha = 1f;
		for (int i = 0; i < 5; i++)
		{
			if (i < starIndex)
			{
				((GObject)((GComponent)panel).GetChild($"star{i}").asImage).alpha = 1f;
			}
			else
			{
				((GObject)((GComponent)panel).GetChild($"star{i}").asImage).alpha = 0f;
			}
		}
		((GObject)panel.toEndMask).touchable = false;
		((GObject)panel.confirmBtn).touchable = true;
	}

	private void DirectlyToPotentialEnd(UI_UpgradeSuccess panel)
	{
		if (panel.PageSwitch.selectedIndex != 0)
		{
			if (panel.showNextProperty3.playing)
			{
				panel.showNextProperty3.Stop();
				FGUIManager.Instance.OnSoldierChanged(soldier.Id, soldier.PotentialLevel - 1, soldier.PotentialLevel);
			}
			((GObject)panel.nextSoldierIcon).alpha = 1f;
			((GObject)panel.nextFightGroup2).alpha = 1f;
			((GObject)panel.nextAttackGroup2).alpha = 1f;
			((GObject)panel.nextDeffenseGroup2).alpha = 1f;
			((GObject)panel.nextHealthGroup2).alpha = 1f;
			((GObject)panel.confirmBtn).alpha = 1f;
			((GObject)panel.showSkill).alpha = 1f;
			((GObject)panel.toEndMask).touchable = false;
			((GObject)panel.confirmBtn).touchable = true;
		}
	}

	private void ShowPanel(int num)
	{
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_089c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a6: Expected O, but got Unknown
		//IL_08c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ca: Expected O, but got Unknown
		//IL_07f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c61: Expected O, but got Unknown
		//IL_0c7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_070e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0713: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_078c: Expected O, but got Unknown
		//IL_1052: Unknown result type (might be due to invalid IL or missing references)
		//IL_1057: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d4: Expected O, but got Unknown
		switch (num)
		{
		case 0:
		{
			UI_UpgradeSuccess panel2 = UI_UpgradeSuccess.CreateInstance();
			((GComponent)GRoot.inst).AddChild((GObject)(object)panel2);
			UiHelper.LoadSpine_AB(panel2.VictorySfx, "ui_title_lightray_rotate", 100f, delegate(SkeletonAnimation animation)
			{
				SpineHelper.SetSkin((ISkeletonAnimation)(object)animation, "skin1");
				animation.AnimationState.SetAnimation(0, "ui_title_lightray_rotate_yellow", true);
			});
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)panel2);
			canvasObject.GetComponent<Canvas>().sortingLayerName = "Default";
			((GObject)panel2.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText538");
			((GObject)panel2.toEndMask).touchable = true;
			UiAudioManager.Instance.SetMainCityBgmVolume(0f);
			UiAudioManager.Instance.PlayBackgroundSound("SoldierUp");
			((GObject)panel2.toEndMask).onClick.Add((EventCallback0)delegate
			{
				DirectlyToUpGradeEnd(panel2);
			});
			((GObject)panel2.confirmBtn).onClick.Add((EventCallback0)delegate
			{
				((GObject)panel2).Dispose();
				canPlayUpgradeSfx = true;
				LoaderSoldierData(soldierId);
				UiAudioManager.Instance.StopBackgroundSound("SoldierUp");
				UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
			});
			((GObject)panel2.confirmBtn).touchable = false;
			((GObject)panel2.curFight1).text = soldier.CombatPower.ToString();
			((GObject)panel2.curLevel1).text = soldier.MaxLevel.ToString();
			((GObject)panel2.curAttack1).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Attack).ToString());
			((GObject)panel2.curDeffense1).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Defense).ToString());
			((GObject)panel2.curHealth1).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Health).ToString());
			UI_armItem curSoldierIcon2 = panel2.curSoldierIcon;
			string text3 = "title";
			if (soldier.PotentialLevel >= 8)
			{
				text3 = "title_Max";
				((GComponent)curSoldierIcon2).GetController("Level").selectedIndex = 1;
			}
			else
			{
				((GComponent)curSoldierIcon2).GetController("Level").selectedIndex = 0;
			}
			if (soldier.PotentialLevel >= 8)
			{
				curSoldierIcon2.ShoulderStrap.url = $"ui://PublicResources/icon_class_{soldier.EvoLevel}_legend";
			}
			else
			{
				curSoldierIcon2.ShoulderStrap.url = $"ui://PublicResources/icon_class_{soldier.EvoLevel}";
			}
			((GComponent)((GObject)curSoldierIcon2).asButton).GetChild(text3).text = soldier.Name;
			((GComponent)curSoldierIcon2).GetChild(text3).asTextField.color = Color32.op_Implicit(UiHelper.GetColorByLevel(soldier.PotentialLevel));
			((GComponent)((GObject)curSoldierIcon2).asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
			string iconFrameBorderSoldier3 = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
			((GComponent)curSoldierIcon2).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier3;
			UiHelper.LoadSoldierIconFrameMaterial(((GComponent)curSoldierIcon2).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)curSoldierIcon2).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
			soldier.Evolute();
			if (soldier == null || soldier.Id != soldierId)
			{
				soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
			}
			RefreshOccupation();
			((GObject)panel2.nextFightGroup1).alpha = 0f;
			((GObject)panel2.nextLevelGroup1).alpha = 0f;
			((GObject)panel2.nextAttackGroup1).alpha = 0f;
			((GObject)panel2.nextDeffenseGroup1).alpha = 0f;
			((GObject)panel2.nextHealthGroup1).alpha = 0f;
			((GObject)panel2.nextFight1).text = soldier.CombatPower.ToString();
			((GObject)panel2.nextLevel1).text = soldier.MaxLevel.ToString();
			((GObject)panel2.nextAttack1).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Attack).ToString());
			((GObject)panel2.nextDeffense1).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Defense).ToString());
			((GObject)panel2.nextHealth1).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Health).ToString());
			UI_armItem nextSoldierIcon2 = panel2.nextSoldierIcon;
			if (soldier.PotentialLevel >= 8)
			{
				nextSoldierIcon2.ShoulderStrap.url = $"ui://PublicResources/icon_class_{soldier.EvoLevel}_legend";
			}
			else
			{
				nextSoldierIcon2.ShoulderStrap.url = $"ui://PublicResources/icon_class_{soldier.EvoLevel}";
			}
			((GComponent)((GObject)nextSoldierIcon2).asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
			string iconFrameBorderSoldier4 = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
			((GComponent)nextSoldierIcon2).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier4;
			UiHelper.LoadSoldierIconFrameMaterial(((GComponent)nextSoldierIcon2).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
			string text4 = "title";
			if (soldier.PotentialLevel >= 8)
			{
				text4 = "title_Max";
				((GComponent)nextSoldierIcon2).GetController("Level").selectedIndex = 1;
			}
			else
			{
				((GComponent)nextSoldierIcon2).GetController("Level").selectedIndex = 0;
			}
			((GComponent)((GObject)nextSoldierIcon2).asButton).GetChild(text4).text = soldier.Name;
			((GComponent)nextSoldierIcon2).GetChild(text4).asTextField.color = Color32.op_Implicit(UiHelper.GetColorByLevel(soldier.PotentialLevel));
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)nextSoldierIcon2).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
			panel2.PageSwitch.selectedIndex = 1;
			panel2.SetControllerPageText();
			panel2.showNextProperty1.Play((PlayCompleteCallback)delegate
			{
				((GObject)panel2.confirmBtn).touchable = true;
				((GObject)panel2.toEndMask).touchable = false;
			});
			break;
		}
		case 2:
		{
			if (!soldier.CanUpgradePotential())
			{
				((GObject)SoldierPotentialPanel.CurrentDemand_tSpine).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(SoldierPotentialPanel.CurrentDemand_tSpine, FGUIManager.Instance.uiRed, Vector3.zero, "Default", 0.5f, delegate(GameObject uiRed)
				{
					uiRed.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
				});
				break;
			}
			UI_UpgradeSuccess panel = UI_UpgradeSuccess.CreateInstance();
			((GComponent)GRoot.inst).AddChild((GObject)(object)panel);
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)panel);
			canvasObject.GetComponent<Canvas>().sortingLayerName = "Default";
			((GObject)panel.toEndMask).touchable = true;
			((GObject)panel.toEndMask).onClick.Add((EventCallback0)delegate
			{
				DirectlyToPotentialEnd(panel);
			});
			((GObject)panel.confirmBtn).onClick.Add((EventCallback0)delegate
			{
				((GObject)panel).Dispose();
				LoaderSoldierData(soldierId);
			});
			((GObject)panel.confirmBtn).touchable = false;
			((GObject)panel.curFight2).text = soldier.CombatPower.ToString();
			((GObject)panel.curAttack2).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Attack).ToString());
			((GObject)panel.curDeffense2).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Defense).ToString());
			((GObject)panel.curHealth2).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Health).ToString());
			UI_armItem curSoldierIcon = panel.curSoldierIcon;
			string text = "title";
			if (soldier.PotentialLevel >= 8)
			{
				text = "title_Max";
				((GComponent)curSoldierIcon).GetController("Level").selectedIndex = 1;
			}
			else
			{
				((GComponent)curSoldierIcon).GetController("Level").selectedIndex = 0;
			}
			((GComponent)((GObject)curSoldierIcon).asButton).GetChild(text).text = soldier.Name;
			((GComponent)curSoldierIcon).GetChild(text).asTextField.color = Color32.op_Implicit(UiHelper.GetColorByLevel(soldier.PotentialLevel));
			((GComponent)((GObject)curSoldierIcon).asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
			((GComponent)curSoldierIcon).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			UiHelper.LoadSoldierIconFrameMaterial(((GComponent)curSoldierIcon).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)curSoldierIcon).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
			soldier.UpgradePotential();
			if (soldier == null || soldier.Id != soldierId)
			{
				soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
			}
			RefreshOccupation();
			int potentialLevel = ((soldier.NextPotentialLevel <= 8) ? ((soldier.NextPotentialLevel + 2) / 2) : 6);
			GameObject canvasObject1 = default(GameObject);
			ref GameObject reference = ref canvasObject1;
			Object obj = Object.Instantiate(Resources.Load("Items/Spine", typeof(GameObject)));
			reference = (GameObject)(object)((obj is GameObject) ? obj : null);
			canvasObject1.GetComponent<Canvas>().sortingLayerName = "Default";
			PlayCompleteCallback val2 = default(PlayCompleteCallback);
			SpawnManager.Instance.LoadSoldierSpine(canvasObject1, $"{soldierId}_skin{potentialLevel - 1}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
			{
				//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cc: Expected O, but got Unknown
				if (panel != null && !((GObject)panel).isDisposed)
				{
					SkeletonGraphic skeletonGraphic = ((Component)canvasObject1.transform.GetChild(0)).gameObject.GetComponent<SkeletonGraphic>();
					skeletonGraphic.skeletonDataAsset = asset;
					skeletonGraphic.initialSkinName = $"skin{potentialLevel - 1}";
					skeletonGraphic.Initialize(true);
					((Component)canvasObject1.transform.GetChild(0)).gameObject.SetActive(true);
					SetTimeout(1f, "AddTextSpecialEffects").OnComplete((GTweenCallback)delegate
					{
						//IL_0040: Unknown result type (might be due to invalid IL or missing references)
						//IL_0082: Unknown result type (might be due to invalid IL or missing references)
						//IL_0087: Unknown result type (might be due to invalid IL or missing references)
						//IL_0089: Expected O, but got Unknown
						//IL_008e: Expected O, but got Unknown
						if (!((GObject)this).isDisposed)
						{
							FGUIManager.Instance.AddTextSpecialEffects(panel.cover, "LightningBlast", new Vector3(720f, 720f, 720f));
							GTweener obj2 = SetTimeout(0.75f, "LoadSoldierSpine");
							GTweenCallback obj3 = val2;
							if (obj3 == null)
							{
								GTweenCallback val3 = delegate
								{
									if (!((GObject)this).isDisposed)
									{
										SpawnManager.Instance.LoadSoldierSpine(canvasObject1, $"{soldierId}_skin{potentialLevel - 1}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset assetNext)
										{
											skeletonGraphic.skeletonDataAsset = assetNext;
											skeletonGraphic.initialSkinName = $"skin{potentialLevel}";
											skeletonGraphic.Initialize(true);
											string text5 = "idle";
											if (soldierId == "S043" || soldier.Id == "S044")
											{
												text5 = "idle_ui";
											}
											skeletonGraphic.AnimationState.AddAnimation(0, text5, false, 0.5f);
											skeletonGraphic.AnimationState.AddAnimation(0, "attack", false, 0f);
											skeletonGraphic.AnimationState.AddAnimation(0, text5, true, 0f);
										});
									}
								};
								GTweenCallback val4 = val3;
								val2 = val3;
								obj3 = val4;
							}
							obj2.OnComplete(obj3);
						}
					});
				}
			});
			canvasObject1.transform.localPosition = -new Vector3(0f, 0f, 0f);
			canvasObject1.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val = new GoWrapper(canvasObject1);
			((DisplayObject)val).SetXY(0f, 0f);
			((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
			panel.Spine.SetNativeObject((DisplayObject)(object)val);
			FGUIManager.Instance.AddTextSpecialEffects(panel.baseSpine, "MagicCircleBase", new Vector3(100f, 100f, 100f));
			FGUIManager.Instance.AddTextSpecialEffects(panel.maskSpine, "MagicCircleMask", new Vector3(100f, 100f, 100f));
			((GObject)panel.showSkill).alpha = 0f;
			for (int num2 = 0; num2 < _skillList.Count; num2++)
			{
				Dictionary<string, int> dictionary = soldier.AbilitiesUnlockState();
				if (dictionary[_skillList[num2]] == soldier.PotentialLevel)
				{
					((GObject)panel.showSkill).visible = true;
					GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(_skillList[num2]);
					panel.skillIcon.LoadAbilityIcon(gDEAbilityData.Icon);
					((GObject)panel.skillIntorduction).text = Singleton<AbilityDataManager>.Instance.GetDescription(gDEAbilityData.Key);
					break;
				}
				if (num2 == _skillList.Count - 1)
				{
					((GObject)panel.showSkill).visible = false;
				}
			}
			((GObject)panel.nextFightGroup2).alpha = 0f;
			((GObject)panel.nextAttackGroup2).alpha = 0f;
			((GObject)panel.nextDeffenseGroup2).alpha = 0f;
			((GObject)panel.nextHealthGroup2).alpha = 0f;
			((GObject)panel.nextFight2).text = soldier.CombatPower.ToString();
			((GObject)panel.nextAttack2).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Attack).ToString());
			((GObject)panel.nextDeffense2).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Defense).ToString());
			((GObject)panel.nextHealth2).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(Convert.ToInt32(soldier.Health).ToString());
			UI_armItem nextSoldierIcon = panel.nextSoldierIcon;
			((GComponent)((GObject)nextSoldierIcon).asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(soldier.Id);
			string iconFrameBorderSoldier2 = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
			((GComponent)nextSoldierIcon).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier2;
			UiHelper.LoadSoldierIconFrameMaterial(((GComponent)nextSoldierIcon).GetChild("iconFrame").asLoader, soldier.PotentialLevel);
			string text2 = "title";
			if (soldier.PotentialLevel >= 8)
			{
				text2 = "title_Max";
				((GComponent)nextSoldierIcon).GetController("Level").selectedIndex = 1;
			}
			else
			{
				((GComponent)nextSoldierIcon).GetController("Level").selectedIndex = 0;
			}
			((GComponent)((GObject)nextSoldierIcon).asButton).GetChild(text2).text = soldier.Name;
			((GComponent)nextSoldierIcon).GetChild(text2).asTextField.color = Color32.op_Implicit(UiHelper.GetColorByLevel(soldier.PotentialLevel));
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)nextSoldierIcon).GetChild("SoulStoneLevel").asCom, soldier.PotentialLevel, soldier.PotentialProgress);
			panel.PageSwitch.selectedIndex = 0;
			panel.SetControllerPageText();
			panel.showSoldierImageChange.Play((PlayCompleteCallback)delegate
			{
				//IL_003c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0041: Unknown result type (might be due to invalid IL or missing references)
				//IL_0043: Expected O, but got Unknown
				//IL_0048: Expected O, but got Unknown
				panel.PageSwitch.selectedIndex = 3;
				panel.SetControllerPageText();
				Transition showNextProperty = panel.showNextProperty3;
				PlayCompleteCallback obj2 = val2;
				if (obj2 == null)
				{
					PlayCompleteCallback val3 = delegate
					{
						((GObject)panel.confirmBtn).touchable = true;
						((GObject)panel.toEndMask).touchable = false;
						FGUIManager.Instance.OnSoldierChanged(soldier.Id, soldier.PotentialLevel - 1, soldier.PotentialLevel);
					};
					PlayCompleteCallback val4 = val3;
					val2 = val3;
					obj2 = val4;
				}
				showNextProperty.Play(obj2);
			});
			break;
		}
		}
	}

	public void PlaySoldierLevelUpSfx()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		SoldierLevelUpSfxLoader.RemoveChildrenToPool();
		for (int i = 0; i < GetSoldierLevelUpSfxNum(); i++)
		{
			GButton asButton = SoldierLevelUpSfxLoader.AddItemFromPool().asButton;
			FGUIManager.Instance.AddTextSpecialEffects(((GComponent)asButton).GetChild("SfxBack").asGraph, "army_level_up", new Vector3(80f, 80f, 80f), "Default", 0.5f, delegate(GameObject armyLevelUp)
			{
				armyLevelUp.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
				UiAudioManager.Instance.LoadSoundsForSfx(armyLevelUp, "Refresh", playLoop: false, 0.25f);
			});
		}
	}

	private int GetSoldierLevelUpSfxNum()
	{
		return GameManagers.Instance.SoldierManager.GetSoldierFxSize(soldierId) + 1;
	}

	public void UnloadSoldierSpine()
	{
		((GObject)Spine).displayObject.Dispose();
		((GObject)maskSpine).displayObject.Dispose();
		((GObject)baseSpine).displayObject.Dispose();
	}

	private void SetFormationAmountUpTip()
	{
		if (soldier.Level == curSoldierLevelLimit)
		{
			((GObject)FormationAmountUpTip).text = "";
			return;
		}
		int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldierId, soldier.Level);
		int num = 0;
		for (int i = soldier.NextLevel; i < curSoldierLevelLimit; i++)
		{
			int soldierFormationNumber2 = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldierId, i);
			if (soldierFormationNumber2 > soldierFormationNumber)
			{
				num = i;
				break;
			}
		}
		if (num == 0)
		{
			((GObject)FormationAmountUpTip).text = "";
		}
		else
		{
			((GObject)FormationAmountUpTip).text = string.Format("{0}:{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText545"), num);
		}
	}

	public void FlashingSlot(int slot)
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		if (slot >= 1)
		{
			return;
		}
		GObject slotIcon = ((GComponent)LegendItemButtons[slot]).GetChild("Icon");
		slotIcon.visible = false;
		GGraph _graph = ((GComponent)LegendItemButtons[slot]).GetChild("sfxBack").asGraph;
		FGUIManager.Instance.AddTextSpecialEffects(_graph, "activating_white", new Vector3(140f, 140f, 140f), "Default", 0.5f, delegate(GameObject activatingWhite)
		{
			UiHelper.DestoryUiSfx(_graph, activatingWhite, 1f);
		});
		SetTimeout(0.33f, "SlotIconVisible").OnComplete((GTweenCallback)delegate
		{
			if (!slotIcon.isDisposed)
			{
				slotIcon.visible = true;
			}
		});
	}

	public void LegendItemButtonsInit()
	{
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		((GObject)LegendSlot).visible = false;
		((GObject)SoldierPotentialPanel.LegendSlot).visible = false;
		if (!VersionManager.LegendItemSwitch || soldier.PotentialLevel < 4)
		{
			return;
		}
		if (!LegendItemsHelper.GetSoldierItemSlotState(soldierId, 0))
		{
			Dictionary<string, int> unlockSoldierItemSlotCost = LegendItemsHelper.GetUnlockSoldierItemSlotCost(soldierId, 0);
			if (unlockSoldierItemSlotCost.First().Value <= 0)
			{
				UnlockLegendItemSlot(0, LegendItemButtonsInit);
				return;
			}
		}
		LegendItemButtons.Clear();
		LegendSlot.LegendItemSlots.RemoveChildrenToPool();
		if (soldier.PotentialLevel >= 4)
		{
			((GObject)LegendSlot).visible = true;
			if (soldier.PotentialLevel < 8)
			{
				LegendItemButtons.Insert(0, LegendSlot.LegendItemSlots.AddItemFromPool().asButton);
			}
			else
			{
				for (int i = 0; i < 2; i++)
				{
					LegendItemButtons.Insert(0, LegendSlot.LegendItemSlots.AddItemFromPool().asButton);
				}
				if (!LegendItemsHelper.GetSoldierItemSlotState(soldierId, 1))
				{
					((GObject)SoldierPotentialPanel.LegendSlot).visible = true;
					((GObject)SoldierPotentialPanel.LegendSlot).data = 0L;
					((GObject)SoldierPotentialPanel.LegendSlot).onClick.Set(new EventCallback0(OpenUnlockSlotDialog));
				}
				else
				{
					((GObject)SoldierPotentialPanel.LegendSlot).visible = false;
				}
			}
			LegendSlot.LegendItemSlots.ResizeToFit(LegendSlot.LegendItemSlots.numItems);
		}
		LegendSlot.SlotNum.selectedIndex = ((LegendSlot.LegendItemSlots.numItems > 1) ? 1 : 0);
		((GObject)LegendSlot).enabled = showLegendItemSlot;
		((GObject)LegendSlot.Tip).visible = !showLegendItemSlot;
		((GObject)LegendSlot.note).visible = CanUnlockLegendItemSlotForUi();
		((GObject)LegendSlot.NewDot).visible = LegendItemSlotChecked();
		((GObject)SoldierPotentialPanel.LegendSlot.note).visible = CanUnlockLegendItemSlotForUi();
		((GObject)SoldierPotentialPanel.LegendSlot).enabled = showLegendItemSlot;
		((GObject)SoldierPotentialPanel.LegendSlot.Tip1).visible = !showLegendItemSlot;
		UpdateLegendItemSlot();
		SoldierSoulStonePanelUpdate("LegendItemButtonsInit");
	}

	private void UpdateLegendItemSlot()
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		for (int i = 0; i < LegendItemButtons.Count; i++)
		{
			Controller controller = ((GComponent)LegendItemButtons[i]).GetController("Type");
			if (!LegendItemsHelper.GetSoldierItemSlotState(soldierId, i))
			{
				((GObject)LegendItemButtons[i]).data = 0L;
				((GObject)LegendItemButtons[i]).onClick.Set(new EventCallback1(OpenUnlockDialog));
				controller.selectedIndex = 2;
				continue;
			}
			if (LegendItemsHelper.SoldiersEquippedItems == null || !LegendItemsHelper.SoldiersEquippedItems.ContainsKey(soldierId))
			{
				controller.selectedIndex = 1;
				((GObject)LegendItemButtons[i]).data = -1L;
			}
			else
			{
				for (int j = 0; j < LegendItemsHelper.SoldiersEquippedItems[soldierId].Length; j++)
				{
					long num = LegendItemsHelper.SoldiersEquippedItems[soldierId][i];
					if (num == 0)
					{
						controller.selectedIndex = 1;
						((GObject)LegendItemButtons[i]).data = -1L;
					}
					else
					{
						controller.selectedIndex = 0;
						UiHelper.RenderLegendItem(((GComponent)LegendItemButtons[i]).GetChild("Icon").asButton, LegendItemsHelper.GetLegendItemUi(num), UiHelper.TextColorType.Light, textureList, 2);
						((GObject)LegendItemButtons[i]).data = num;
					}
				}
			}
			((GObject)LegendItemButtons[i]).onClick.Set(new EventCallback1(OpenLegendPanel));
		}
	}

	private void OpenLegendPanel(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		GButton asButton = ((GObject)context.sender).asButton;
		int num = LegendItemButtons.IndexOf(asButton);
		if (num >= 0)
		{
			if (num == 1 && LegendItemSlotChecked())
			{
				CheckLegendItemSlot();
			}
			long num2 = (long)((GObject)asButton).data;
			if (num2 == -1)
			{
				UI_LegendItemsPanel.OpenPanelInfo = new LegendItemsPanelInfo(LegendItemsShowType.Choice, num2, soldierId, num);
				LegendItemsHelper.OpenLegendItemBlueprintListPanel(Action);
			}
			else
			{
				UI_LegendItemInfoDialog.DialogInfo = new LegendItemInfoDialogInfo(LegendItemsHelper.GetLegendItemUi(num2), soldierId, num, 0);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemInfoDialog.Name, null);
			}
		}
		static void Action()
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemsPanel.Name, null);
		}
	}

	private void OpenUnlockDialog(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		GButton asButton = ((GObject)context.sender).asButton;
		int slot = LegendItemButtons.IndexOf(asButton);
		if (slot >= 0)
		{
			Action value = delegate
			{
				UnlockLegendItemSlot(slot, LegendItemButtonsInit);
				FlashingSlot(slot);
			};
			Dictionary<string, int> unlockSoldierItemSlotCost = LegendItemsHelper.GetUnlockSoldierItemSlotCost(soldierId, slot);
			Dictionary<string, object> parameters = new Dictionary<string, object>
			{
				{ "Action", value },
				{
					"CostNum",
					unlockSoldierItemSlotCost.First().Value
				},
				{
					"ItemId",
					unlockSoldierItemSlotCost.First().Key
				}
			};
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UnlockPopup.Name, parameters);
		}
	}

	private void OpenUnlockSlotDialog()
	{
		Action value = delegate
		{
			UnlockLegendItemSlot(1, LegendItemButtonsInit);
			FlashingSlot(1);
		};
		Dictionary<string, int> unlockSoldierItemSlotCost = LegendItemsHelper.GetUnlockSoldierItemSlotCost(soldierId, 1);
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "Action", value },
			{
				"CostNum",
				unlockSoldierItemSlotCost.First().Value
			},
			{
				"ItemId",
				unlockSoldierItemSlotCost.First().Key
			}
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UnlockPopup.Name, parameters);
	}

	private void UnlockLegendItemSlot(int slot, Action action)
	{
		LegendItemsHelper.UnlockSoldierItemSlot(soldierId, slot, action);
	}

	public void LoaderSoldierData(string _soldierId, bool isUpGrade = false, bool isUpPotential = false)
	{
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Expected O, but got Unknown
		UnloadSoldierSpine();
		expItems = SoldierLevelManager.ExpItems;
		soldierId = _soldierId;
		if (soldier == null || soldier.Id != soldierId)
		{
			soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
		}
		RefreshOccupation();
		curSoldierLevelLimit = soldier.MaxLevel;
		LegendItemsHelper.UiGetLegendItems(LegendItemButtonsInit, ((GObject)this).sortingOrder);
		ref GameObject reference = ref canvasObject;
		Object obj = Object.Instantiate(Resources.Load("Items/Spine", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		canvasObject.GetComponent<Canvas>().sortingLayerName = "Default";
		int potentialLevel = ((soldier.PotentialLevel <= 8) ? ((soldier.PotentialLevel + 2) / 2) : 6);
		SpawnManager.Instance.LoadSoldierSpine(canvasObject, $"{soldierId}_skin{potentialLevel}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((GObject)this).isDisposed)
			{
				SkeletonGraphic component = ((Component)canvasObject.transform.GetChild(0)).gameObject.GetComponent<SkeletonGraphic>();
				if ((Object)(object)component != (Object)null)
				{
					component.skeletonDataAsset = asset;
					component.initialSkinName = $"skin{potentialLevel}";
					component.Initialize(true);
					((Component)canvasObject.transform.GetChild(0)).gameObject.SetActive(true);
				}
			}
		});
		canvasObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
		canvasObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
		gw = new GoWrapper(canvasObject);
		((DisplayObject)gw).SetXY(0f, 0f);
		((DisplayObject)gw).pivot = new Vector2(0.5f, 0.5f);
		Spine.SetNativeObject((DisplayObject)(object)gw);
		FGUIManager.Instance.AddTextSpecialEffects(baseSpine, "MagicCircleBase", new Vector3(100f, 100f, 100f) * 1.2f);
		FGUIManager.Instance.AddTextSpecialEffects(maskSpine, "MagicCircleMask", new Vector3(100f, 100f, 100f) * 1.2f);
		((GComponent)racePicture).GetController("Type").selectedIndex = FGUIManager.Instance.GetRaceIcon(soldier.Faction);
		((GObject)racePicture).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ShowRaceInfo(soldier.Faction, 0, ((GObject)this).sortingOrder);
		});
		((GObject)SoldierLevel).text = soldier.Level.ToString();
		int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, soldier.Level);
		if (((GObject)FormationSoldierAmount).text != "" && ((GObject)FormationSoldierAmount).text != soldierFormationNumber.ToString())
		{
			((GObject)FormationSoldierAmountSpine).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(FormationSoldierAmountSpine, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
		SetFormationAmountUpTip();
		((GObject)FormationSoldierAmount).text = soldierFormationNumber.ToString() ?? "";
		WaitToRefreshCombatPower(isUpGrade);
		if (isUpPotential)
		{
			GTweenCallback val = default(GTweenCallback);
			SetTimeout(0.35f, "LoaderSoldierData1").OnComplete((GTweenCallback)delegate
			{
				//IL_003e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0099: Unknown result type (might be due to invalid IL or missing references)
				//IL_009e: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a0: Expected O, but got Unknown
				//IL_00a5: Expected O, but got Unknown
				if (!((GObject)SoldierNamePotentialSfxBack).isDisposed)
				{
					FGUIManager.Instance.AddTextSpecialEffects(SoldierNamePotentialSfxBack, "rubby_blast_lang_white", new Vector3(100f, 100f, 100f), "Default", 0.5f, delegate(GameObject rubbyBlastLangWhite)
					{
						rubbyBlastLangWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
						UiAudioManager.Instance.LoadSoundsForSfx(rubbyBlastLangWhite, "Refresh");
					});
					GTweener obj2 = SetTimeout(0.15f, "LoaderSoldierData2");
					GTweenCallback obj3 = val;
					if (obj3 == null)
					{
						GTweenCallback val2 = delegate
						{
							if (!((GObject)SoldierNamePotentialLevelBack).isDisposed)
							{
								SoldierNamePotentialLevelBack.GetController("Level").selectedIndex = soldier.PotentialLevel;
							}
						};
						GTweenCallback val3 = val2;
						val = val2;
						obj3 = val3;
					}
					obj2.OnComplete(obj3);
				}
			});
		}
		else
		{
			SoldierNamePotentialLevelBack.GetController("Level").selectedIndex = soldier.PotentialLevel;
		}
		if (soldier.PotentialLevel >= 8)
		{
			Status.selectedIndex = 1;
			((GObject)SoldierName_Max).text = soldier.Name;
			ShoulderStrap.url = $"ui://PublicResources/icon_class_{soldier.EvoLevel}_legend";
		}
		else
		{
			Status.selectedIndex = 0;
			((GObject)SoldierName).text = soldier.Name;
			ShoulderStrap.url = $"ui://PublicResources/icon_class_{soldier.EvoLevel}";
		}
		UpdateSoldierStartList();
		if (!isUpGrade)
		{
			ChangePageEvent(isUpPotential);
		}
	}

	public void WaitToRefreshCombatPower(bool _isUpGrade)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		int num = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, soldier.Level);
		GTweenCallback1 val = default(GTweenCallback1);
		SetTimeout(0.5f, "RefreshCombatPower").OnComplete((GTweenCallback)delegate
		{
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Expected O, but got Unknown
			//IL_015f: Expected O, but got Unknown
			if (!((GObject)CombatPowerSpine).isDisposed)
			{
				if (((GObject)CombatPower).text != "" && ((GObject)CombatPower).text != (soldier.CombatPower * num).ToString())
				{
					((GObject)CombatPowerSpine).displayObject.Dispose();
					FGUIManager.Instance.AddTextSpecialEffects(CombatPowerSpine, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
					{
						uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
					});
				}
				if (_isUpGrade && ((GObject)CombatPower).data != null)
				{
					int num2 = (int)((GObject)CombatPower).data;
					int num3 = soldier.CombatPower * num;
					GTweener obj = GTween.To((float)num2, (float)num3, 0.5f).SetEase((EaseType)0);
					GTweenCallback1 obj2 = val;
					if (obj2 == null)
					{
						GTweenCallback1 val2 = delegate(GTweener tweener)
						{
							((GObject)CombatPower).text = $"{Mathf.Floor(tweener.value.x)}";
						};
						GTweenCallback1 val3 = val2;
						val = val2;
						obj2 = val3;
					}
					obj.OnUpdate(obj2);
				}
				else
				{
					((GObject)CombatPower).text = (soldier.CombatPower * num).ToString();
				}
				((GObject)CombatPower).data = soldier.CombatPower * num;
				((GObject)CombatPowerSfxBack).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(CombatPowerSfxBack, "combat_power", new Vector3(((GObject)CombatPowerSfxBack).width / 4f, ((GObject)CombatPowerSfxBack).height * 6f, ((GObject)CombatPowerSfxBack).height));
			}
		});
	}

	public void UpdateSoldierStartList()
	{
	}

	private void SetSoldierExpBar(bool isInit = false)
	{
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		if (isInit)
		{
			double nextLevelExpAfter = SoldierLevelManager.GetLevelTotalExp(soldier.NextLevel);
			double curLevelExp = SoldierLevelManager.GetLevelTotalExp(soldier.Level);
			double curLevelSoldierExp = GameManagers.Instance.UserArchiveManager.GetSoldierExp(soldierId);
			double num = curLevelSoldierExp + curLevelExp;
			double num2 = (num - curLevelExp) / (nextLevelExpAfter - curLevelExp) * 100.0;
			((GProgressBar)SoldierInfoPanel.ExperienceProcessBar).value = 0.0;
			((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).text = $"{0}";
			((GObject)SoldierInfoPanel.ExperienceProcessBar.experience).text = $"{nextLevelExpAfter - curLevelExp}";
			float curExpValue = 0f;
			((GProgressBar)SoldierInfoPanel.ExperienceProcessBar).TweenValue(num2, 0.5f).OnUpdate((GTweenCallback)delegate
			{
				curExpValue = Mathf.Lerp(curExpValue, (float)curLevelSoldierExp, 2f * Time.deltaTime);
				((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).text = $"{Convert.ToInt32(curExpValue)}";
				((GObject)SoldierInfoPanel.ExperienceProcessBar.experience).text = $"{nextLevelExpAfter - curLevelExp}";
			}).OnComplete((GTweenCallback)delegate
			{
				((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).text = $"{Convert.ToInt32(curLevelSoldierExp)}";
				((GObject)SoldierInfoPanel.ExperienceProcessBar.experience).text = $"{nextLevelExpAfter - curLevelExp}";
			});
			((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).data = (float)curLevelSoldierExp;
		}
	}

	public void RefreshSoldierDetailInfo(Soldier _soldier = null, bool isInit = false)
	{
		if (_soldier == null)
		{
			_soldier = soldier;
		}
		_soldier.EnsureAttr();
		((GObject)SoldierInfoPanel.LevelNum_t).text = ((_soldier.Level >= _soldier.MaxLevel) ? string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText319"), _soldier.EvoLevel + 1, LanguagesManager.GetDesc("CsharpCodeZhTcText546")) : "");
		if (_soldier.MaxLevel >= curSoldierLevelLimit && soldier.Level == soldier.MaxLevel)
		{
			((GObject)SoldierInfoPanel.LevelNum_t).text = LanguagesManager.GetDesc("CsharpCodeZhTcText539");
		}
		((GObject)SoldierInfoPanel.UpSoldierLevelBtn.level).text = $"{soldier.Level}";
		((GObject)SoldierInfoPanel.UpSoldierLevelBtn.redPoint).visible = SetUpSoldierLevelBtnNote();
		SoldierInfoPanel.attackLoader.url = $"ui://PublicResources/icon_atk_{_soldier.DamageType}";
		SoldierInfoPanel.defenseLoader.url = $"ui://PublicResources/icon_def_{_soldier.ArmorType}";
		SoldierInfoPanel.healthLoader.url = "ui://PublicResources/icon_hp";
		string text = ((HotUpdateProcess.LanguageKey == "eng") ? ":" : "：");
		((GObject)SoldierInfoPanel.attackTitle).text = attackTypeNames[_soldier.DamageType - 1] + text;
		((GObject)SoldierInfoPanel.defenseTitle).text = armorTypeNames[_soldier.ArmorType - 1] + text;
		((GObject)SoldierInfoPanel.healthTitle).text = LanguagesManager.GetDesc("CsharpCodeZhTcText204") + text;
		((GObject)SoldierInfoPanel.HealthNum_t).text = $"{Convert.ToInt32(_soldier.Health)}";
		((GObject)SoldierInfoPanel.AttackNum_t).text = $"{Convert.ToInt32(_soldier.Attack)}";
		((GObject)SoldierInfoPanel.DefenceNum_t).text = $"{Convert.ToInt32(_soldier.Defense)}";
		SetSoldierExpBar(isInit);
		SummonDemandListRender();
		SkillList(_soldier);
		UpdateExperiencePageInfo();
	}

	private bool SetUpSoldierLevelBtnNote()
	{
		bool flag = false;
		for (int i = 0; i < expItems.Length; i++)
		{
			flag = ((i != 0) ? (flag || Shift.Legion.Common.Models.Item.Stock(GameManagers.Instance, expItems[i]) > 0) : (Shift.Legion.Common.Models.Item.Stock(GameManagers.Instance, expItems[0]) > 0));
		}
		return flag && soldier.Level < soldier.MaxLevel;
	}

	public void ShowDetailInfo()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		if (DetailPage != null)
		{
			return;
		}
		DetailPage = UI_DetailPage.CreateInstance_ILRuntime();
		((GObject)DetailPage.CloseDetailpage).onClick.Add((EventCallback0)delegate
		{
			((GObject)DetailPage).Dispose();
			DetailPage = null;
		});
		((GObject)LegendSlot).onClick.Add((EventCallback0)delegate
		{
			if (DetailPage != null && !((GObject)DetailPage).isDisposed)
			{
				((GObject)DetailPage).Dispose();
				DetailPage = null;
			}
		});
		if (DetailPage != null && !((GObject)DetailPage).isDisposed)
		{
			Vector2 val = default(Vector2);
			((Vector2)(ref val))._002Ector(((GObject)SoldierInfoPanel).LocalToRoot(Vector2.zero, GRoot.inst).x + ((GObject)SoldierInfoPanel).width / 2f, ((GObject)SoldierInfoPanel).LocalToRoot(Vector2.zero, GRoot.inst).y - 20f);
			((GObject)DetailPage.Deta_HealthGrow_t).text = $"{soldier.HealthGrowUp:0}";
			((GObject)DetailPage.Deta_DefenseGrow_t).text = $"{soldier.DefenseGrowUp:0}";
			((GObject)DetailPage.Deta_AttackGrow_t).text = $"{soldier.AttackGrowUp:0}";
			((GObject)DetailPage.Deta_AttackType_t).text = attackTypeNames[soldier.Data.DamageType - 1];
			((GObject)DetailPage.Deta_DefenceType_t).text = armorTypeNames[soldier.Data.ArmorType - 1];
			string text = (soldier.Tags.Contains("远程") ? $"{soldier.AttackDistance:0.#}" : LanguagesManager.GetDesc("CsharpCodeZhTcText835"));
			((GObject)DetailPage.Deta_AttackDistance_t).text = text ?? "";
			((GObject)DetailPage.Deta_Health_t).text = $"{soldier.Health:0}";
			((GObject)DetailPage.Deta_Attack_t).text = $"{soldier.Attack:0}";
			((GObject)DetailPage.Deta_Defence_t).text = $"{soldier.Defense:0}";
			((GObject)DetailPage.Deta_AttackSpeed_t).text = $"{Math.Floor(soldier.AttackSpeed * 1000f) / 1000.0:0.000}";
			((GObject)DetailPage.Deta_MoveSpeed_t).text = $"{soldier.MoveSpeed:0.000}";
			((GObject)DetailPage.Deta_Crit_t).text = $"{soldier.CriticalChance * 100f:0.#}%";
			((GObject)DetailPage.Deta_CritDamage_t).text = $"{soldier.CriticalDamageModifier * 100f:0.#}%";
			((GObject)DetailPage.Deta_Hitrate_t).text = $"{soldier.HitRate * 100f:0.#}%";
			((GObject)DetailPage.Deta_Dodgehate_t).text = $"{soldier.EvasionRate * 100f:0.#}%";
			((GObject)DetailPage.Deta_Time_t).text = string.Format("{0}{1}", Singleton<SoldierProductManager>.Instance.GetSoldierProductData(soldier.Id).Time, LanguagesManager.GetDesc("CsharpCodeZhTcText92"));
			((GComponent)GRoot.inst).AddChild((GObject)(object)DetailPage);
			((GObject)DetailPage).sortingOrder = 3000;
			((GObject)DetailPage).SetXY(val.x, val.y);
			DetailPage.showSelf.Play();
		}
	}

	public void SummonDemandListRender()
	{
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		Dictionary<string, float> soldierProductRequirements = Singleton<SoldierProductManager>.Instance.GetSoldierProductRequirements(soldier.Id);
		SummonDemandList.RemoveChildrenToPool();
		int num = 0;
		foreach (KeyValuePair<string, float> item in soldierProductRequirements)
		{
			GButton asButton = SummonDemandList.AddItemFromPool().asButton;
			string key = item.Key;
			int num2 = ((Shift.Legion.Common.Models.Item.ItemType(key) == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(key) : Shift.Legion.Common.Models.Item.Level(GameManagers.Instance, key));
			num2 = ((num2 > 0) ? num2 : Shift.Legion.Common.Models.Item.Rarity(key));
			int num3 = num;
			((GComponent)SummonDemandList).GetChildAt(num3).asCom.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(key);
			((GComponent)SummonDemandList).GetChildAt(num3).asCom.GetChild("frame").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorder(2, num2);
			((GObject)((GComponent)asButton).GetChild("Title").asTextField).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, key);
			((GObject)((GComponent)asButton).GetChild("Amount").asTextField).text = $"{item.Value}";
			((GObject)asButton).data = item.Key;
			((GObject)asButton).onClick.Add(new EventCallback1(InfoPanelMaterialClickEvent));
			num++;
		}
	}

	public void SkillList(Soldier soldier)
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		SoldierInfoPanel.SkillList.RemoveChildrenToPool();
		Dictionary<string, int> dictionary = soldier.AbilitiesUnlockState();
		_skillList.Clear();
		string currentLevelFeatureAbilityId = soldier.GetCurrentLevelFeatureAbilityId();
		int featureAbilityLevel = soldier.GetFeatureAbilityLevel();
		GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(currentLevelFeatureAbilityId);
		((GObject)SoldierInfoPanel.specialityName).text = $"{gDEAbilityData.Name} LV{featureAbilityLevel}";
		((GObject)SoldierInfoPanel.specialityText).text = Singleton<AbilityDataManager>.Instance.GetDescription(gDEAbilityData.Key);
		((GObject)SoldierInfoPanel.specialityText).onClickLink.Set(new EventCallback1(OnClickSkillEffectLink));
		for (int i = 0; i < soldier.AbilityList.Count; i++)
		{
			string text = soldier.AbilityList[i];
			if (!(text == soldier.FeatureAbility))
			{
				GDEAbilityData gDEAbilityData2 = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(text);
				if (gDEAbilityData2.Visible)
				{
					_skillList.Add(soldier.AbilityList[i]);
				}
			}
		}
		for (int j = 0; j < _skillList.Count; j++)
		{
			SoldierInfoPanel.SkillList.AddItemFromPool();
			GDEAbilityData gDEAbilityData3 = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(_skillList[j]);
			bool flag = ((dictionary[_skillList[j]] <= soldier.PotentialLevel) ? true : false);
			int num = j;
			if (flag)
			{
				((GComponent)((GComponent)SoldierInfoPanel.SkillList).GetChildAt(num).asButton).GetChild("IconBtn").grayed = false;
				((GComponent)SoldierInfoPanel.SkillList).GetChildAt(num).onClick.Add(new EventCallback1(SkillDetailPopup));
			}
			else
			{
				((GComponent)((GComponent)SoldierInfoPanel.SkillList).GetChildAt(num).asButton).GetChild("IconBtn").grayed = true;
				((GComponent)SoldierInfoPanel.SkillList).GetChildAt(num).onClick.Add(new EventCallback1(SkillDetailPopup));
			}
			int num2 = 5 - 5 * num;
			((GComponent)((GComponent)SoldierInfoPanel.SkillList).GetChildAt(num).asButton).GetChild("n16").rotation = num2;
			((GComponent)((GComponent)((GComponent)SoldierInfoPanel.SkillList).GetChildAt(num).asButton).GetChild("IconBtn").asButton).GetChild("IconLoader").asLoader.LoadAbilityIcon(gDEAbilityData3.Icon);
			((GComponent)SoldierInfoPanel.SkillList).GetChildAt(num).data = new KeyValuePair<GDEAbilityData, bool>(gDEAbilityData3, flag);
		}
		if (SoldierInfoPanel.SkillList.numItems == 0)
		{
			((GObject)SoldierInfoPanel.skillTitleGroup).visible = false;
		}
		else
		{
			((GObject)SoldierInfoPanel.skillTitleGroup).visible = true;
		}
	}

	private void OnClickSkillEffectLink(EventContext e)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillEffectPanel.Name, new Dictionary<string, object> { 
		{
			"EffectKey",
			e.data.ToString()
		} });
	}

	public void SkillDetailPopupForPotentialUnlcok(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		GButton val = (GButton)context.sender;
		Tuple<GDEAbilityData, bool, int> tuple = (Tuple<GDEAbilityData, bool, int>)((GObject)val).data;
		int item = tuple.Item3;
		Vector2 val2 = default(Vector2);
		((Vector2)(ref val2))._002Ector(((GObject)GRoot.inst).LocalToRoot(new Vector2(((GObject)SoldierInfoPanel).x + ((GObject)SoldierInfoPanel).width / 2f, ((GObject)SoldierInfoPanel).y), GRoot.inst).x, ((GObject)GRoot.inst).LocalToRoot(new Vector2(((GObject)SoldierInfoPanel).x, ((GObject)SoldierInfoPanel).y + 611f), GRoot.inst).y);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Pos", val2);
		dictionary.Add("Data", tuple.Item1);
		dictionary.Add("Limit", item);
		dictionary.Add("State", tuple.Item2);
		dictionary.Add("GList", SoldierPotentialPanel.UnlockSkillList);
		dictionary.Add("IsShow", true);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, dictionary);
	}

	public void SkillDetailPopup(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		GButton val = (GButton)context.sender;
		KeyValuePair<GDEAbilityData, bool> keyValuePair = (KeyValuePair<GDEAbilityData, bool>)((GObject)val).data;
		Dictionary<string, int> dictionary = soldier.AbilitiesUnlockState();
		int num = dictionary[_skillList[((GComponent)SoldierInfoPanel.SkillList).GetChildIndex((GObject)(object)val)]];
		Vector2 val2 = default(Vector2);
		((Vector2)(ref val2))._002Ector(((GObject)GRoot.inst).LocalToRoot(new Vector2(((GObject)SoldierInfoPanel).x + ((GObject)SoldierInfoPanel).width / 2f, ((GObject)SoldierInfoPanel).y), GRoot.inst).x, ((GObject)GRoot.inst).LocalToRoot(new Vector2(((GObject)SoldierInfoPanel).x, ((GObject)SoldierInfoPanel).y + 701f), GRoot.inst).y);
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		dictionary2.Add("Pos", val2);
		dictionary2.Add("Data", keyValuePair.Key);
		dictionary2.Add("Limit", num);
		dictionary2.Add("State", keyValuePair.Value);
		dictionary2.Add("GList", SoldierInfoPanel.SkillList);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, dictionary2);
	}

	public void SkillDetailPopupForPotentialTip(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		GObject val = (GObject)context.sender;
		KeyValuePair<GDEAbilityData, bool> keyValuePair = (KeyValuePair<GDEAbilityData, bool>)val.data;
		Dictionary<string, int> dictionary = soldier.AbilitiesUnlockState();
		int num = dictionary[keyValuePair.Key.Key];
		Vector2 val2 = default(Vector2);
		((Vector2)(ref val2))._002Ector(((GObject)GRoot.inst).LocalToRoot(new Vector2(((GObject)SoldierInfoPanel).x + ((GObject)SoldierInfoPanel).width / 2f, ((GObject)SoldierInfoPanel).y), GRoot.inst).x, ((GObject)GRoot.inst).LocalToRoot(new Vector2(((GObject)SoldierInfoPanel).x, ((GObject)SoldierInfoPanel).y + 701f), GRoot.inst).y);
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		dictionary2.Add("Pos", val2);
		dictionary2.Add("Data", keyValuePair.Key);
		dictionary2.Add("Limit", num);
		dictionary2.Add("State", keyValuePair.Value);
		dictionary2.Add("GList", SoldierInfoPanel.SkillList);
		dictionary2.Add("IsShow", true);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, dictionary2);
	}

	public void InfoPanelMaterialClickEvent(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string value = ((GObject)(GComponent)context.sender).data.ToString();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("ItemId", value);
		dictionary.Add("ToSourceParameters", SetOpenWorkShopParameter());
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_MaterialIntroductionPanel.Name, dictionary);
	}

	private Dictionary<string, object> SetOpenWorkShopParameter()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Soldier", this);
		dictionary.Add("Weapons", soldier.WeaponList);
		return dictionary;
	}

	public void UpdateExperienceStock(UI_ExperiencePage ExperiencePage)
	{
		for (int i = 0; i < ExperiencePage.Dialog.potionList.numItems; i++)
		{
			((GObject)((GComponent)((GComponent)ExperiencePage.Dialog.potionList).GetChildAt(i).asButton).GetChild("title").asTextField).text = Shift.Legion.Common.Models.Item.Stock(GameManagers.Instance, expItems[i]).ShortNumberFormat() ?? "";
		}
	}

	private void CloseExperiencePageOnSwitchTAB()
	{
		if (pageControll.selectedIndex != 0 && DetailPage != null && !DetailPage.showSelf.playing)
		{
			CloseDetailPage();
		}
	}

	private void SelectExperienceBook(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		GButton val = (GButton)context.sender;
		curSelectedExperienceBook = ((GComponent)ExperiencePage.Dialog.potionList).GetChildIndex((GObject)(object)val);
		for (int i = 0; i < ExperiencePage.Dialog.potionList.numItems; i++)
		{
			if (i == curSelectedExperienceBook)
			{
				((GComponent)((GComponent)ExperiencePage.Dialog.potionList).GetChildAt(i).asButton).GetChild("hightLight").visible = true;
				((GComponent)((GComponent)ExperiencePage.Dialog.potionList).GetChildAt(i).asButton).GetChild("effectNum").asTextField.color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, (byte)225));
			}
			else
			{
				((GComponent)((GComponent)ExperiencePage.Dialog.potionList).GetChildAt(i).asButton).GetChild("hightLight").visible = false;
				((GComponent)((GComponent)ExperiencePage.Dialog.potionList).GetChildAt(i).asButton).GetChild("effectNum").asTextField.color = Color32.op_Implicit(new Color32((byte)213, (byte)186, (byte)122, (byte)225));
			}
		}
	}

	private void UpgradeByExperienceBook(EventContext context)
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Expected O, but got Unknown
		if (GTweenerExperienceProcessBar1 != null && !GTweenerExperienceProcessBar1.allCompleted)
		{
			GTweenerExperienceProcessBar1.Kill(true);
			GTweenerExperienceProcessBar1 = null;
			if (GTweenerExperienceProcessBar2 != null && !GTweenerExperienceProcessBar2.allCompleted)
			{
				GTweenerExperienceProcessBar2.Kill(true);
				GTweenerExperienceProcessBar2 = null;
			}
			isToMax = false;
		}
		if (GTweenerExperienceProcessBar2 != null && !GTweenerExperienceProcessBar2.allCompleted)
		{
			GTweenerExperienceProcessBar2.Kill(true);
			GTweenerExperienceProcessBar2 = null;
			isToMax = false;
		}
		bool isQuick = (bool)((GObject)context.sender).data;
		if (!isToMax)
		{
			GButton asButton = ((GComponent)ExperiencePage.Dialog.potionList).GetChildAt(curSelectedExperienceBook).asButton;
			Vector2 val = ((GObject)asButton).LocalToGlobal(Vector2.one / 2f);
			val = ((GObject)this).GlobalToLocal(val);
			GGraph progressBarSfxBack = new GGraph();
			((GObject)progressBarSfxBack).SetSize(36f, 36f);
			((GComponent)this).AddChild((GObject)(object)progressBarSfxBack);
			progressBarSfxBackList.Add(progressBarSfxBack);
			((GObject)progressBarSfxBack).visible = false;
			((GObject)progressBarSfxBack).sortingOrder = 2;
			((GObject)progressBarSfxBack).SetXY(val.x, val.y);
			FGUIManager.Instance.AddTextSpecialEffects(progressBarSfxBack, "exp_missile_green", Vector3.zero, "UI", 0.5f, delegate(GameObject expMissileGreen)
			{
				expMissileGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 1.35f;
			});
			Vector2 val2 = ((GObject)SoldierInfoPanel.ExperienceProcessBar.SfxBack).LocalToGlobal(Vector2.zero);
			val2 = ((GObject)this).GlobalToLocal(val2);
			JudgeProgressBarSfxVisible(curSelectedExperienceBook, progressBarSfxBack, isQuick);
			((GObject)progressBarSfxBack).TweenMove(val2, 0.44f).SetEase((EaseType)5).OnComplete((GTweenCallback)delegate
			{
				((GObject)progressBarSfxBack).AddRelation((GObject)(object)SoldierInfoPanel.ExperienceProcessBar.bar, (RelationType)6);
				ExperienceBtnEvent(curSelectedExperienceBook, ExperiencePage, ExpGesture, isQuick, progressBarSfxBack);
			});
		}
	}

	public void ShowSoldierFormationInfoPanel()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Expected O, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		SoldierFormationInfoPanel = UI_SoldierFormationInfoPanel.CreateInstance();
		((GObject)SoldierFormationInfoPanel.Dialog).alpha = 0f;
		Vector2 xy = ((GObject)FormationSoldierAmountBack).xy;
		List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>();
		for (int i = 1; i < 51; i++)
		{
			int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, i);
			if (list.Count > 0)
			{
				if (soldierFormationNumber != list[list.Count - 1].Key)
				{
					list.Add(new KeyValuePair<int, int>(soldierFormationNumber, i));
				}
			}
			else
			{
				list.Add(new KeyValuePair<int, int>(soldierFormationNumber, i));
			}
		}
		for (int num = list.Count - 5; num >= 0; num--)
		{
			if (list[num].Value <= soldier.Level)
			{
				list.RemoveAt(num);
			}
		}
		if (list.Count > 4)
		{
			list.RemoveRange(4, list.Count - 4);
		}
		for (int j = 0; j < list.Count; j++)
		{
			GTextField content = SoldierFormationInfoPanel.Dialog.Dialog.content;
			((GObject)content).text = ((GObject)content).text + string.Format("[color=#D5BA7A]{0}{1}[/color]", LanguagesManager.GetDesc("CsharpCodeZhTcText194"), list[j].Value);
			for (int k = 0; k < 4 - list[j].Value.ToString().Length; k++)
			{
				GTextField content2 = SoldierFormationInfoPanel.Dialog.Dialog.content;
				((GObject)content2).text = ((GObject)content2).text + "  ";
			}
			GTextField content3 = SoldierFormationInfoPanel.Dialog.Dialog.content;
			((GObject)content3).text = ((GObject)content3).text + string.Format("[color=#AFF627]{0}{1}[/color]", list[j].Key, LanguagesManager.GetDesc("CsharpCodeZhTcText547"));
			if (j != list.Count - 1)
			{
				GTextField content4 = SoldierFormationInfoPanel.Dialog.Dialog.content;
				((GObject)content4).text = ((GObject)content4).text + Environment.NewLine;
			}
		}
		((GComponent)GRoot.inst).AddChild((GObject)(object)SoldierFormationInfoPanel);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)SoldierFormationInfoPanel, scaleAdaption: true);
		((GObject)SoldierFormationInfoPanel.Dialog).SetScale(0.25f, 0.25f);
		((GObject)SoldierFormationInfoPanel.Dialog).SetXY(xy.x, xy.y - 60f);
		((GObject)SoldierFormationInfoPanel.mask).onClick.Set((EventCallback0)delegate
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)SoldierFormationInfoPanel);
			((GObject)SoldierFormationInfoPanel).Dispose();
		});
		((GObject)SoldierFormationInfoPanel.Dialog).TweenFade(1f, 0.1f);
		((GObject)SoldierFormationInfoPanel.Dialog).TweenScale(Vector2.one, 0.33f).SetEase((EaseType)26);
	}

	public void ShowExperiencePage()
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected O, but got Unknown
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Expected O, but got Unknown
		if (!soldier.IsUnlocked)
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText540") }, 1, arg3: false);
			return;
		}
		ExperiencePage = UI_ExperiencePage.CreateInstance();
		RenderPotionList(ExperiencePage.Dialog.potionList, 4);
		((GObject)ExperiencePage.Dialog.ExclamationMarkBtn).onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("SoldierExpGain");
		if (percentFloatPayload > 0f)
		{
			((GObject)ExperiencePage.Dialog.ExclamationMarkBtn).visible = true;
			((GObject)ExperiencePage.Dialog.ExclamationMarkBtn).data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1}%", LanguagesManager.GetDesc("CsharpCodeZhTcText548"), Convert.ToInt32(percentFloatPayload * 100f))
				},
				{
					"Pos",
					(object)new Vector2(1568f, 834f)
				}
			};
		}
		else
		{
			((GObject)ExperiencePage.Dialog.ExclamationMarkBtn).visible = false;
		}
		UpdateExperienceStock(ExperiencePage);
		((GComponent)this).AddChild((GObject)(object)ExperiencePage);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)ExperiencePage, scaleAdaption: true);
		((GObject)ExperiencePage).SetXY(0f, 0f);
		((GObject)ExperiencePage.mask).onClick.Set((EventCallback0)delegate
		{
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected O, but got Unknown
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			curSelectedExperienceBook = 0;
			((GObject)ExperiencePage.Dialog.UpgradeBtn).onClick.Remove(new EventCallback1(UpgradeByExperienceBook));
			((GObject)ExperiencePage.Dialog.QuickUpgradeBtn).onClick.Remove(new EventCallback1(UpgradeByExperienceBook));
			((GComponent)this).RemoveChild((GObject)(object)ExperiencePage, true);
			for (int num = progressBarSfxBackList.Count - 1; num >= 0; num--)
			{
				((GComponent)this).RemoveChild((GObject)(object)progressBarSfxBackList[num], true);
			}
			progressBarSfxBackList.Clear();
		});
		((GObject)ExperiencePage.Dialog.UpgradeBtn).data = false;
		((GObject)ExperiencePage.Dialog.QuickUpgradeBtn).data = true;
		((GObject)ExperiencePage.Dialog.UpgradeBtn).onClick.Add(new EventCallback1(UpgradeByExperienceBook));
		((GObject)ExperiencePage.Dialog.QuickUpgradeBtn).onClick.Add(new EventCallback1(UpgradeByExperienceBook));
		ExpGesture = new LongPressGesture((GObject)(object)ExperiencePage.Dialog.UpgradeBtn);
		ExpGesture.interval = 0.5f;
		ExpGesture.trigger = 0.25f;
		ExpGesture.onBegin.Add((EventCallback0)delegate
		{
			FGUIManager.Instance.StartLongPress(curSelectedExperienceBook, ExperiencePage, this, ExpGesture);
		});
		EventListener onEnd = ExpGesture.onEnd;
		object obj = _003C_003Ec._003C_003E9__265_2;
		if (obj == null)
		{
			EventCallback0 val = delegate
			{
				FGUIManager.Instance.StopLongPress();
			};
			_003C_003Ec._003C_003E9__265_2 = val;
			obj = (object)val;
		}
		onEnd.Add((EventCallback0)obj);
		UiTagManager uiTagManager = UiTagManager.Instance;
		if (ExperiencePage.Dialog.potionList.numItems > 0)
		{
			uiTagManager.Register("SoldierCultivate.FirstLevelUpItem", ((GComponent)ExperiencePage.Dialog.potionList).GetChildAt(0));
			uiTagManager.Register("SoldierCultivate.ConfirmLevelUpBtn", ExperiencePage.Dialog.UpgradeBtn);
			uiTagManager.Register("SoldierCultivate.ConfirmQuickLevelUpBtn", ExperiencePage.Dialog.QuickUpgradeBtn);
		}
		((GObject)ExperiencePage).onRemovedFromStage.Add((EventCallback0)delegate
		{
			if (ExperiencePage.Dialog.potionList.numItems > 0)
			{
				uiTagManager.Unregister("SoldierCultivate.FirstLevelUpItem", ((GComponent)ExperiencePage.Dialog.potionList).GetChildAt(0));
				uiTagManager.Unregister("SoldierCultivate.ConfirmLevelUpBtn", ExperiencePage.Dialog.UpgradeBtn);
				uiTagManager.Unregister("SoldierCultivate.ConfirmQuickLevelUpBtn", ExperiencePage.Dialog.QuickUpgradeBtn);
			}
		});
		UpdateExperiencePageInfo(isInit: true);
		ExperiencePage.showSelf.Play();
	}

	private void AddTextSfx(GGraph graph, string num)
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (((GObject)graph).data == null)
			{
				((GObject)graph).data = num;
				return;
			}
			string text = ((GObject)graph).data.ToString();
			if (!(text == num))
			{
				((GObject)graph).data = num;
				FGUIManager.Instance.AddTextSpecialEffects(graph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject obj)
				{
					obj.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
				});
			}
		}
		catch (Exception arg)
		{
			ILRuntimeDebug.LogError($"AddTextSfx Error !-> {((GObject)graph).name}:{num}, {arg}");
		}
	}

	public void UpdateExperiencePageInfo(bool isInit = false)
	{
		if (ExperiencePage == null || ExperiencePage.Dialog == null || ((GObject)ExperiencePage).isDisposed)
		{
			return;
		}
		((GObject)ExperiencePage.Dialog.curAttack).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(soldier.Attack)}") ?? "";
		AddTextSfx(ExperiencePage.Dialog.curAttackSfxBack, soldier.Attack.ToString());
		((GObject)ExperiencePage.Dialog.curDefense).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(soldier.Defense)}") ?? "";
		AddTextSfx(ExperiencePage.Dialog.curDefenseSfxBack, soldier.Defense.ToString());
		((GObject)ExperiencePage.Dialog.curHealth).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(soldier.Health)}") ?? "";
		AddTextSfx(ExperiencePage.Dialog.curHealthSfxBack, soldier.Health.ToString());
		int level = ((soldier.NextLevel > curSoldierLevelLimit) ? curSoldierLevelLimit : soldier.NextLevel);
		FakeSoldier fakeSoldier = new FakeSoldier(soldierId, level, soldier.EvoLevel, soldier.PotentialLevel);
		((GObject)ExperiencePage.Dialog.nextAttack).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(fakeSoldier.Attack)}") ?? "";
		AddTextSfx(ExperiencePage.Dialog.nextAttackSfxBack, fakeSoldier.Attack.ToString());
		((GObject)ExperiencePage.Dialog.nextDefense).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(fakeSoldier.Defense)}") ?? "";
		AddTextSfx(ExperiencePage.Dialog.nextDefenseSfxBack, fakeSoldier.Defense.ToString());
		((GObject)ExperiencePage.Dialog.nextHealth).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint($"{Convert.ToInt32(fakeSoldier.Health)}") ?? "";
		AddTextSfx(ExperiencePage.Dialog.nextHealthSfxBack, fakeSoldier.Health.ToString());
		((GObject)ExperiencePage.UpSoldierLevelLogo.level).text = soldier.Level.ToString();
		((GObject)ExperiencePage.UpSoldierLevelLogo.redPoint).visible = SetUpSoldierLevelBtnNote();
		int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, soldier.Level);
		((GObject)ExperiencePage.Dialog.CurNum.curNum).text = soldierFormationNumber.ToString();
		AddTextSfx(ExperiencePage.Dialog.CurNum.curNumSfxBack, soldierFormationNumber.ToString());
		if (soldier.Level >= curSoldierLevelLimit)
		{
			ExperiencePage.Dialog.LevelController.selectedIndex = 1;
		}
		else
		{
			ExperiencePage.Dialog.LevelController.selectedIndex = 0;
		}
		int num = soldierFormationNumber;
		if (soldier.Level >= curSoldierLevelLimit)
		{
			ExperiencePage.Dialog.Status.selectedIndex = 2;
			ExperiencePage.Dialog.NextNum.Status.selectedIndex = 2;
			((GObject)ExperiencePage.Dialog.NextNum.nextNum).text = num.ToString();
		}
		else
		{
			for (int i = soldier.Level + 1; i < curSoldierLevelLimit + 1; i++)
			{
				num = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldier.Id, i);
				if (num > soldierFormationNumber)
				{
					if (i == soldier.Level + 1)
					{
						ExperiencePage.Dialog.Status.selectedIndex = 0;
						ExperiencePage.Dialog.NextNum.Status.selectedIndex = 0;
						((GObject)ExperiencePage.Dialog.NextNum.numLevel).text = "";
					}
					else
					{
						ExperiencePage.Dialog.Status.selectedIndex = 1;
						((GObject)ExperiencePage.Dialog.NextNum.numLevel).text = "(" + i + LanguagesManager.GetDesc("CsharpCodeZhTcText124") + ")";
						ExperiencePage.Dialog.NextNum.Status.selectedIndex = 1;
					}
					break;
				}
			}
			if (num <= soldierFormationNumber)
			{
				ExperiencePage.Dialog.Status.selectedIndex = 2;
				ExperiencePage.Dialog.NextNum.Status.selectedIndex = 2;
			}
			((GObject)ExperiencePage.Dialog.NextNum.nextNum).text = num.ToString();
			AddTextSfx(ExperiencePage.Dialog.NextNum.nextNumSfxBack, num.ToString());
		}
		if (isInit && ExperiencePage.Dialog.UpdateNumContent.playing)
		{
			ExperiencePage.Dialog.UpdateNumContent.Stop(true, true);
		}
	}

	private void potionListItemRender(int index, GObject obj)
	{
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		string text = expItems[index];
		((GObject)((GComponent)asButton).GetChild("name").asTextField).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, text);
		((GComponent)asButton).GetChild("Loader").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorder(2, Shift.Legion.Common.Models.Item.Level(GameManagers.Instance, text));
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(text);
		string text2 = "";
		List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, text);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].ModifierId == "Bonus")
			{
				Dictionary<string, object> payloadDictionary = list[i].PayloadDictionary;
				int num = int.Parse(payloadDictionary["SoldierExp"].ToString());
				float value = (float)num * (1f + GameManagers.Instance.ModifierManager.GetPercentFloatPayload("SoldierExpGain"));
				text2 += string.Format("{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText549"), Convert.ToInt32(value));
				break;
			}
		}
		((GObject)((GComponent)asButton).GetChild("effectNum").asTextField).text = text2;
		asButton.title = "0";
		if (index == curSelectedExperienceBook)
		{
			((GComponent)((GComponent)ExperiencePage.Dialog.potionList).GetChildAt(index).asButton).GetChild("hightLight").visible = true;
			((GComponent)((GComponent)ExperiencePage.Dialog.potionList).GetChildAt(index).asButton).GetChild("effectNum").asTextField.color = Color32.op_Implicit(new Color32((byte)175, (byte)246, (byte)39, (byte)225));
		}
		else
		{
			((GComponent)((GComponent)ExperiencePage.Dialog.potionList).GetChildAt(index).asButton).GetChild("hightLight").visible = false;
			((GComponent)((GComponent)ExperiencePage.Dialog.potionList).GetChildAt(index).asButton).GetChild("effectNum").asTextField.color = Color32.op_Implicit(new Color32((byte)213, (byte)186, (byte)122, (byte)225));
		}
		((GObject)asButton).onClick.Set(new EventCallback1(SelectExperienceBook));
	}

	private void RenderPotionList(GList list, int num)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		list.itemRenderer = new ListItemRenderer(potionListItemRender);
		list.numItems = num;
	}

	public void JudgeProgressBarSfxVisible(int index, GGraph progressBarSfxBack, bool isQuick)
	{
		if (soldier.Level >= soldier.MaxLevel)
		{
			((GComponent)this).RemoveChild((GObject)(object)progressBarSfxBack, true);
			List<string> arg = new List<string>
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText23"),
				LanguagesManager.GetDesc("CsharpCodeZhTcText24")
			};
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		string expItemId = expItems[index];
		string nameById = SchemaIndexHelper.GetNameById(GameManagers.Instance, expItemId);
		int curStock = Shift.Legion.Common.Models.Item.Stock(GameManagers.Instance, expItemId);
		if (curStock - 1 < 0)
		{
			((GComponent)this).RemoveChild((GObject)(object)progressBarSfxBack, true);
			Action action = delegate
			{
				FGUIManager.Instance.OpenMilitaryIntelligencePanel("", new Dictionary<string, object>
				{
					{
						"SortingOrder",
						((GObject)this).sortingOrder
					},
					{ "FindTreasure", true }
				});
			};
			TurnToMilitaryIntelligence(nameById + LanguagesManager.GetDesc("CsharpCodeZhTcText45") + "!", action, LanguagesManager.GetDesc("CsharpCodeZhTcText78"));
		}
		else if (isQuick && !soldier.CanQuickLevelUp(expItemId))
		{
			((GComponent)this).RemoveChild((GObject)(object)progressBarSfxBack, true);
			int nextLevelExpBefore = SoldierLevelManager.GetLevelTotalExp(soldier.NextLevel);
			double upLevelBeforeExp = SoldierLevelManager.GetLevelTotalExp(soldier.Level);
			int soldierExp = GameManagers.Instance.UserArchiveManager.GetSoldierExp(soldierId);
			int curLevelSoldierRemainingExp = nextLevelExpBefore - (int)upLevelBeforeExp - soldierExp;
			Action action2 = delegate
			{
				UseSomeExperienceBooks(curStock, expItemId, curLevelSoldierRemainingExp, upLevelBeforeExp, nextLevelExpBefore, ExperiencePage, ExpGesture, progressBarSfxBack);
			};
			TurnToMilitaryIntelligence(LanguagesManager.GetDesc("CsharpCodeZhTcText550") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText551") + "？", action2, LanguagesManager.GetDesc("CsharpCodeZhTcText212"));
		}
		else
		{
			((GObject)progressBarSfxBack).visible = true;
		}
	}

	public async void ExperienceBtnEvent(int index, UI_ExperiencePage page, LongPressGesture gestureA, bool isQuick, GGraph progressBarSfxBack)
	{
		if (soldier.Level >= soldier.MaxLevel)
		{
			List<string> tipList = new List<string>
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText23"),
				LanguagesManager.GetDesc("CsharpCodeZhTcText24")
			};
			SharedMessenger.Broadcast("SHOW_TIPS", tipList, 1, arg3: false);
			return;
		}
		string expItemId = expItems[index];
		int nextLevelExpBefore = SoldierLevelManager.GetLevelTotalExp(soldier.NextLevel);
		double upLevelBeforeExp = SoldierLevelManager.GetLevelTotalExp(soldier.Level);
		int curLevelSoldierExp = GameManagers.Instance.UserArchiveManager.GetSoldierExp(soldierId);
		int curLevelSoldierRemainingExp = nextLevelExpBefore - (int)upLevelBeforeExp - curLevelSoldierExp;
		((GObject)SoldierInfoPanel.ExperienceProcessBar).data = new Tuple<LongPressGesture, UI_ExperiencePage, GGraph, int, double, bool>(gestureA, page, progressBarSfxBack, nextLevelExpBefore, upLevelBeforeExp, item6: false);
		int curStock = Shift.Legion.Common.Models.Item.Stock(GameManagers.Instance, expItemId);
		if (curStock - 1 >= 0 && soldier.Level < GameManagers.Instance.UserArchiveManager.GetSoldierMaxLevel(soldier.Id))
		{
			if (isQuick)
			{
				bool canLevelUp = true;
				((GObject)SoldierInfoPanel.ExperienceProcessBar).data = new Tuple<LongPressGesture, UI_ExperiencePage, GGraph, int, double, bool>(gestureA, page, progressBarSfxBack, nextLevelExpBefore, upLevelBeforeExp, canLevelUp);
				int itemNeeded = soldier.GetQuickLevelUpItemNeeded(expItemId);
				if (itemNeeded >= 0)
				{
					itemNeeded = Math.Max(itemNeeded, 1);
					ILRequestHelper<UseItemResponse>.Request((EventContext)null, (Func<Task<UseItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().UseItem(-1L, expItemId, itemNeeded, soldier.Id)), (Action<UseItemResponse>)delegate(UseItemResponse response)
					{
						if (!response.Result)
						{
							ILRequestHelper.ShowErrorCode(response.ErrorCode);
						}
						else
						{
							Shift.Legion.Common.Models.Item.UseForSoldier(GameManagers.Instance, expItemId, soldier, itemNeeded);
						}
					});
				}
				else
				{
					TurnToMilitaryIntelligence(action: delegate
					{
						UseSomeExperienceBooks(curStock, expItemId, curLevelSoldierRemainingExp, upLevelBeforeExp, nextLevelExpBefore, page, gestureA, progressBarSfxBack);
					}, _tip: LanguagesManager.GetDesc("CsharpCodeZhTcText550") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText551") + "？", confirmBtnTitle: LanguagesManager.GetDesc("CsharpCodeZhTcText212"));
				}
			}
			else
			{
				UseSomeExperienceBooks(1, expItemId, curLevelSoldierRemainingExp, upLevelBeforeExp, nextLevelExpBefore, page, gestureA, progressBarSfxBack);
			}
		}
		else if (Shift.Legion.Common.Models.Item.Stock(GameManagers.Instance, expItemId) <= 0)
		{
			string itemName = SchemaIndexHelper.GetNameById(GameManagers.Instance, expItemId);
			TurnToMilitaryIntelligence(action: delegate
			{
				FGUIManager.Instance.OpenMilitaryIntelligencePanel("", new Dictionary<string, object>
				{
					{
						"SortingOrder",
						((GObject)this).sortingOrder
					},
					{ "FindTreasure", true }
				});
			}, _tip: itemName + LanguagesManager.GetDesc("CsharpCodeZhTcText45") + "!", confirmBtnTitle: LanguagesManager.GetDesc("CsharpCodeZhTcText78"));
		}
	}

	private void UseSomeExperienceBooks(int count, string expItemId, int curLevelSoldierRemainingExp, double upLevelBeforeExp, int nextLevelExpBefore, UI_ExperiencePage page, LongPressGesture gestureA, GGraph progressBarSfxBack)
	{
		List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, expItemId);
		bool flag = false;
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].ModifierId == "Bonus")
			{
				string value = list[i].PayloadDictionary["SoldierExp"].ToString();
				int num = Convert.ToInt32(value);
				num = count * (int)((float)num * (1f + GameManagers.Instance.ModifierManager.GetPercentFloatPayload("SoldierExpGain")));
				flag = ((num >= curLevelSoldierRemainingExp) ? true : false);
				((GObject)SoldierInfoPanel.ExperienceProcessBar).data = new Tuple<LongPressGesture, UI_ExperiencePage, GGraph, int, double, bool>(gestureA, page, progressBarSfxBack, nextLevelExpBefore, upLevelBeforeExp, flag);
				break;
			}
		}
		ILRequestHelper<UseItemResponse>.Request((EventContext)null, (Func<Task<UseItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().UseItem(-1L, expItemId, count, soldier.Id)), (Action<UseItemResponse>)delegate(UseItemResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Shift.Legion.Common.Models.Item.UseForSoldier(GameManagers.Instance, expItemId, soldier, count);
			}
		});
	}

	private void TurnToMilitaryIntelligence(string _tip, Action action, string confirmBtnTitle)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				_tip ?? ""
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{ "Confirm", action },
					{ "Cancel", null }
				}
			},
			{ "PageIndex", 0 },
			{ "ClickSound", "Confirm" },
			{
				"Order",
				((GObject)this).sortingOrder
			},
			{ "ConfirmTitle", confirmBtnTitle }
		});
	}

	public void UpdateSoldierExpBarOnLevelUp(string soldierid, int level1, int level2)
	{
		if (((GObject)SoldierInfoPanel.ExperienceProcessBar).data != null && !(soldierid != soldier.Id))
		{
			levelChanged = true;
			Tuple<LongPressGesture, UI_ExperiencePage, GGraph, int, double, bool> tuple = (Tuple<LongPressGesture, UI_ExperiencePage, GGraph, int, double, bool>)((GObject)SoldierInfoPanel.ExperienceProcessBar).data;
			if (tuple.Item6)
			{
				PlayGetExpSfx();
			}
		}
	}

	public void UpdateSoldierExpBarOnGetExp(string soldierid, int curExp)
	{
		if (((GObject)SoldierInfoPanel.ExperienceProcessBar).data != null && !(soldierid != soldier.Id))
		{
			Tuple<LongPressGesture, UI_ExperiencePage, GGraph, int, double, bool> tuple = (Tuple<LongPressGesture, UI_ExperiencePage, GGraph, int, double, bool>)((GObject)SoldierInfoPanel.ExperienceProcessBar).data;
			if (!tuple.Item6)
			{
				PlayGetExpSfx();
			}
		}
	}

	public void PlayGetExpSfx()
	{
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Expected O, but got Unknown
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Expected O, but got Unknown
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e2: Expected O, but got Unknown
		if (GTweenerExperienceProcessBar1 != null && !GTweenerExperienceProcessBar1.allCompleted)
		{
			GTweenerExperienceProcessBar1.Kill(true);
			GTweenerExperienceProcessBar1 = null;
			if (GTweenerExperienceProcessBar2 != null && !GTweenerExperienceProcessBar2.allCompleted)
			{
				GTweenerExperienceProcessBar2.Kill(true);
				GTweenerExperienceProcessBar2 = null;
			}
			isToMax = false;
		}
		if (GTweenerExperienceProcessBar2 != null && !GTweenerExperienceProcessBar2.allCompleted)
		{
			GTweenerExperienceProcessBar2.Kill(true);
			GTweenerExperienceProcessBar2 = null;
			isToMax = false;
		}
		if (((GObject)SoldierInfoPanel.ExperienceProcessBar).data == null)
		{
			return;
		}
		Tuple<LongPressGesture, UI_ExperiencePage, GGraph, int, double, bool> getExpData = (Tuple<LongPressGesture, UI_ExperiencePage, GGraph, int, double, bool>)((GObject)SoldierInfoPanel.ExperienceProcessBar).data;
		double nextLevelExpAfter = SoldierLevelManager.GetLevelTotalExp(soldier.NextLevel);
		double curLevelExp = SoldierLevelManager.GetLevelTotalExp(soldier.Level);
		double curLevelSoldierExp = GameManagers.Instance.UserArchiveManager.GetSoldierExp(soldierId);
		double num = curLevelSoldierExp + curLevelExp;
		double exp = (num - curLevelExp) / (nextLevelExpAfter - curLevelExp) * 100.0;
		((GObject)SoldierInfoPanel.LevelNum_t).text = ((soldier.Level >= soldier.MaxLevel) ? string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText319"), soldier.EvoLevel + 1, LanguagesManager.GetDesc("CsharpCodeZhTcText546")) : "");
		if (soldier.MaxLevel >= curSoldierLevelLimit && soldier.Level == soldier.MaxLevel)
		{
			((GObject)SoldierInfoPanel.LevelNum_t).text = LanguagesManager.GetDesc("CsharpCodeZhTcText539");
		}
		((GObject)SoldierInfoPanel.UpSoldierLevelBtn.level).text = $"{soldier.Level}";
		((GObject)SoldierInfoPanel.UpSoldierLevelBtn.redPoint).visible = SetUpSoldierLevelBtnNote();
		if (nextLevelExpAfter > (double)getExpData.Item4)
		{
			getExpData.Item1.interval = 4f;
			isToMax = true;
			float getExp1st = (float)curLevelSoldierExp;
			if (((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).data != null)
			{
				getExp1st = (float)((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).data;
			}
			double _exp = (double)getExpData.Item4 - getExpData.Item5;
			UiAudioManager.Instance.PlaySoundEffect("ExperienceGrowth");
			GTweenerExperienceProcessBar1 = ((GProgressBar)SoldierInfoPanel.ExperienceProcessBar).TweenValue(100.0, 0.45f).OnUpdate((GTweenCallback)delegate
			{
				getExp1st = Mathf.Lerp(getExp1st, (float)_exp, 2.2222223f * Time.deltaTime);
				((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).text = $"{Convert.ToInt32(getExp1st)}";
				((GObject)SoldierInfoPanel.ExperienceProcessBar.experience).text = $"{_exp}";
			}).OnComplete((GTweenCallback)delegate
			{
				//IL_0225: Unknown result type (might be due to invalid IL or missing references)
				//IL_022a: Unknown result type (might be due to invalid IL or missing references)
				//IL_022c: Expected O, but got Unknown
				//IL_0231: Expected O, but got Unknown
				//IL_0258: Unknown result type (might be due to invalid IL or missing references)
				//IL_025d: Unknown result type (might be due to invalid IL or missing references)
				//IL_025f: Expected O, but got Unknown
				//IL_0264: Expected O, but got Unknown
				//IL_0309: Unknown result type (might be due to invalid IL or missing references)
				//IL_030e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0310: Expected O, but got Unknown
				//IL_0315: Expected O, but got Unknown
				if (!((GObject)SoldierInfoPanel).isDisposed)
				{
					if (getExpData.Item3 != null && !((GObject)getExpData.Item3).isDisposed)
					{
						((GObject)getExpData.Item3).visible = false;
					}
					((GObject)SoldierInfoPanel.ExperienceProcessBar.bar).alpha = 0f;
					((GProgressBar)SoldierInfoPanel.ExperienceProcessBar).value = 0.0;
					((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).text = $"{Convert.ToInt32(_exp)}";
					((GObject)SoldierInfoPanel.ExperienceProcessBar.experience).text = $"{_exp}";
					if (getExpData.Item3 != null && !((GObject)getExpData.Item3).isDisposed)
					{
						((GObject)getExpData.Item3).visible = true;
					}
					PlaySoldierLevelUpSfx();
					RefreshSoldierDetailInfo(soldier);
					UiAudioManager.Instance.PlaySoundEffect("LevelUp");
					((GObject)SoldierInfoPanel.ExperienceProcessBar.bar).alpha = 1f;
					UI_SoldierCultivate uI_SoldierCultivate = this;
					GTweener obj = ((GProgressBar)SoldierInfoPanel.ExperienceProcessBar).TweenValue(exp, 0.45f);
					GTweenCallback val = default(GTweenCallback);
					GTweenCallback obj2 = val;
					if (obj2 == null)
					{
						GTweenCallback val2 = delegate
						{
							float num2 = 0f;
							num2 = Mathf.Lerp(num2, (float)curLevelSoldierExp, 2.2222223f * Time.deltaTime);
							((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).text = $"{Convert.ToInt32(num2)}";
							((GObject)SoldierInfoPanel.ExperienceProcessBar.experience).text = $"{nextLevelExpAfter - curLevelExp}";
						};
						GTweenCallback val3 = val2;
						val = val2;
						obj2 = val3;
					}
					GTweener obj3 = obj.OnUpdate(obj2);
					GTweenCallback val4 = default(GTweenCallback);
					GTweenCallback obj4 = val4;
					if (obj4 == null)
					{
						GTweenCallback val5 = delegate
						{
							isToMax = false;
							((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).text = $"{Convert.ToInt32(curLevelSoldierExp)}";
							((GObject)SoldierInfoPanel.ExperienceProcessBar.experience).text = $"{nextLevelExpAfter - curLevelExp}";
						};
						GTweenCallback val3 = val5;
						val4 = val5;
						obj4 = val3;
					}
					uI_SoldierCultivate.GTweenerExperienceProcessBar2 = obj3.OnComplete(obj4);
					((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).data = (float)curLevelSoldierExp;
					if (getExpData.Item3 != null)
					{
						GTweener obj5 = ((GObject)getExpData.Item3).TweenFade(((GObject)getExpData.Item3).alpha, 0.55f);
						GTweenCallback val6 = default(GTweenCallback);
						GTweenCallback obj6 = val6;
						if (obj6 == null)
						{
							GTweenCallback val7 = delegate
							{
								((GObject)getExpData.Item3).relations.ClearAll();
								progressBarSfxBackList.Remove(getExpData.Item3);
								((GComponent)this).RemoveChild((GObject)(object)getExpData.Item3, true);
							};
							GTweenCallback val3 = val7;
							val6 = val7;
							obj6 = val3;
						}
						obj5.OnComplete(obj6);
					}
					UiAudioManager.Instance.PlaySoundEffect("ExperienceGrowth");
				}
			});
		}
		else
		{
			getExpData.Item1.interval = 0.5f;
			float curExpValue = 0f;
			if (((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).data != null)
			{
				curExpValue = (float)((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).data;
			}
			((GProgressBar)SoldierInfoPanel.ExperienceProcessBar).TweenValue(exp, 0.45f).OnUpdate((GTweenCallback)delegate
			{
				curExpValue = Mathf.Lerp(curExpValue, (float)curLevelSoldierExp, 2.2222223f * Time.deltaTime);
				((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).text = $"{Convert.ToInt32(curExpValue)}";
				((GObject)SoldierInfoPanel.ExperienceProcessBar.experience).text = $"{nextLevelExpAfter - curLevelExp}";
			}).OnComplete((GTweenCallback)delegate
			{
				((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).text = $"{Convert.ToInt32(curLevelSoldierExp)}";
				((GObject)SoldierInfoPanel.ExperienceProcessBar.experience).text = $"{nextLevelExpAfter - curLevelExp}";
			});
			((GObject)SoldierInfoPanel.ExperienceProcessBar.curExperience).data = (float)curLevelSoldierExp;
			if (getExpData.Item3 != null)
			{
				((GObject)getExpData.Item3).TweenFade(((GObject)getExpData.Item3).alpha, 0.45f).OnComplete((GTweenCallback)delegate
				{
					((GObject)getExpData.Item3).relations.ClearAll();
					progressBarSfxBackList.Remove(getExpData.Item3);
					((GComponent)this).RemoveChild((GObject)(object)getExpData.Item3, true);
				});
			}
			UiAudioManager.Instance.PlaySoundEffect("ExperienceGrowth");
		}
		UpdateExperienceStock(getExpData.Item2);
		WaitToRefreshCombatPower(_isUpGrade: true);
	}

	private void BreakThroughLevelTipInit()
	{
	}

	public void RefreshBreakthroughData(bool needSpecialeffects)
	{
	}

	public void ActiveBtnEvent()
	{
		if (!soldier.IsUnlocked)
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText540") }, 1, arg3: false);
		}
		else
		{
			LoaderSoldierData(soldierId);
			((GObject)SoldierBreakthrougPanel.ActivityBtn).touchable = false;
			ShowPanel(1);
		}
	}

	public void UpdateStock(object parameter)
	{
		GList consumptionList = DegreeElevationPanel.consumptionBtn.consumptionList;
		Dictionary<string, int> originEvoRequirement = soldier.OriginEvoRequirement;
		if (originEvoRequirement == null)
		{
			return;
		}
		for (int i = 0; i < consumptionList.numItems; i++)
		{
			GButton asButton = ((GComponent)consumptionList).GetChildAt(i).asButton;
			string text = ((GObject)((GComponent)asButton).GetChild("name").asTextField).text;
			int stock = GameManagers.Instance.StockController.GetStock(text);
			int num = (int)((GObject)asButton).data;
			string text2 = ((stock < num) ? "#DC143C" : "#50280A");
			if (!originEvoRequirement.TryGetValue(text, out var value))
			{
				value = num;
			}
			string text3 = "#50280A";
			((GObject)((GComponent)asButton).GetChild("reqDesc").asCom.GetChild("curPrice").asTextField).text = "[color=" + text2 + "]" + stock.ShortNumberFormat() + "[/color][color=" + text3 + "]/" + num.ShortNumberFormat() + "[/color]";
		}
		UpdateRedNoteStatus();
	}

	public void RefreshDegreeElevationData()
	{
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0634: Unknown result type (might be due to invalid IL or missing references)
		//IL_063e: Expected O, but got Unknown
		soldier.EnsureAttr();
		((GObject)DegreeElevationPanel.DegreeElevationUp_Btn).touchable = true;
		Dictionary<string, int> evoRequirement = soldier.EvoRequirement;
		int nextEvoLevel = soldier.NextEvoLevel;
		bool flag = nextEvoLevel > 6;
		if (flag)
		{
			DegreeElevationPanel.PositionControll.selectedIndex = 3;
			((GObject)DegreeElevationPanel.CurrentLevel).text = string.Format("{0}{1}", soldier.EvoLevel, LanguagesManager.GetDesc("CsharpCodeZhTcText372"));
			((GObject)DegreeElevationPanel.NextLevel).text = "??";
		}
		else
		{
			DegreeElevationPanel.PositionControll.selectedIndex = 0;
			FakeSoldier fakeSoldier = new FakeSoldier(soldier.Id, soldier.Level, soldier.NextEvoLevel, soldier.PotentialLevel);
			((GObject)DegreeElevationPanel.levelLimitTip).text = string.Format("{0}:{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText552"), fakeSoldier.MaxLevel);
		}
		if (soldier.WeaponList.Count <= 2)
		{
			DegreeElevationPanel.EquipStyle.selectedIndex = 0;
		}
		else
		{
			DegreeElevationPanel.EquipStyle.selectedIndex = 1;
		}
		for (int i = 1; i < 5; i++)
		{
			GGraph asGraph = ((GComponent)((GComponent)DegreeElevationPanel).GetChild($"Product{i}").asButton).GetChild("SfxBack").asGraph;
			((GObject)asGraph).SetXY(77f, 80f);
		}
		((GObject)((GComponent)DegreeElevationPanel).GetChild("PropsAndEquip").asGroup).visible = false;
		int evoLevel = (soldier.PotentialLevel + 2) / 2;
		DegreeElevationPanel.SoldierIconLoader.url = "ui://PublicResources/" + soldier.GetPortraitPathByEvoLevel(evoLevel);
		DegreeElevationPanel.SoldierFrameLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		UiHelper.LoadSoldierIconFrameMaterial(DegreeElevationPanel.SoldierFrameLoader, soldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(DegreeElevationPanel.SoliderSoulStoneLevel, soldier.PotentialLevel, soldier.PotentialProgress);
		((GObject)DegreeElevationPanel.CurrentLevel).text = string.Format("{0}{1}", soldier.EvoLevel, LanguagesManager.GetDesc("CsharpCodeZhTcText372"));
		if (flag)
		{
			((GObject)DegreeElevationPanel.NextLevel).text = "??";
			((GObject)DegreeElevationPanel.NextLevel_t).text = "";
		}
		else
		{
			((GObject)DegreeElevationPanel.NextLevel_t).text = string.Format("{0}{1}", nextEvoLevel, LanguagesManager.GetDesc("CsharpCodeZhTcText372"));
			((GObject)DegreeElevationPanel.NextLevel).text = string.Format("{0}{1}", nextEvoLevel, LanguagesManager.GetDesc("CsharpCodeZhTcText372"));
		}
		Dictionary<string, int> originEvoRequirement = soldier.OriginEvoRequirement;
		((GComponent)DegreeElevationPanel.consumptionBtn).GetChild("consumptionList").asList.numItems = 0;
		int weaponCnt = 0;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		if (!flag)
		{
			foreach (KeyValuePair<string, int> item in evoRequirement)
			{
				RenderDegreeElevationProductList(item.Key, item.Value, dictionary, isMaxLevel: false, ref weaponCnt);
			}
		}
		else
		{
			Dictionary<string, float> soldierProductRequirements = Singleton<SoldierProductManager>.Instance.GetSoldierProductRequirements(soldier.Id);
			SummonDemandList.RemoveChildrenToPool();
			int num = 0;
			foreach (KeyValuePair<string, float> item2 in soldierProductRequirements)
			{
				RenderDegreeElevationProductList(item2.Key, (int)item2.Value, dictionary, isMaxLevel: true, ref weaponCnt);
			}
		}
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("SoldierCultivate.Weapons");
		instance.Register("SoldierCultivate.Weapons", dictionary);
		DegreeElevationPanel.consumptionBtn.consumptionList.ResizeToFit(DegreeElevationPanel.consumptionBtn.consumptionList.numItems);
		DegreeElevationPanel.DemandIconLoader.url = "ui://PublicResources/tree_horatio_lucky_boy";
		DegreeElevationPanel.DemandFrameLoader.url = "ui://PublicResources/kuang_round_wood_1";
		SummonDemandListRender();
		if (soldier.CanEvolute())
		{
			((GObject)DegreeElevationPanel.DegreeElevationUp_Btn).enabled = true;
		}
		else
		{
			((GObject)DegreeElevationPanel.DegreeElevationUp_Btn).enabled = false;
		}
		if (canPlayUpgradeSfx)
		{
			for (int j = 1; j < 5; j++)
			{
				GGraph asGraph2 = ((GComponent)((GComponent)DegreeElevationPanel).GetChild($"Product{j}").asButton).GetChild("SfxBack").asGraph;
				FGUIManager.Instance.AddTextSpecialEffects(asGraph2, "activating_white", new Vector3(150f, 150f, 150f), "Default", 0.5f, delegate(GameObject activatingWhiteFoo)
				{
					activatingWhiteFoo.AddComponent<DestroySelf>().destroyTime = 1f;
				});
			}
			FGUIManager.Instance.AddTextSpecialEffects(DegreeElevationPanel.SoldierEquipSfxBack, "activating_white", new Vector3(250f, 250f, 250f), "Default", 0.5f, delegate(GameObject activatingWhite)
			{
				UiAudioManager.Instance.LoadSoundsForSfx(activatingWhite, "Refresh");
				activatingWhite.AddComponent<DestroySelf>().destroyTime = 1f;
			});
			((GObject)DegreeElevationPanel.SoldierEquipSfxBack).TweenFade(1f, 0.1f).OnComplete((GTweenCallback)delegate
			{
				((GObject)((GComponent)DegreeElevationPanel).GetChild("PropsAndEquip").asGroup).visible = true;
			});
			canPlayUpgradeSfx = false;
		}
		else
		{
			((GObject)((GComponent)DegreeElevationPanel).GetChild("PropsAndEquip").asGroup).visible = true;
		}
	}

	private void RenderDegreeElevationProductList(string itemKey, int itemValue, Dictionary<string, object> weaponsMap, bool isMaxLevel, ref int weaponCnt)
	{
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Expected O, but got Unknown
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Expected O, but got Unknown
		int num = Shift.Legion.Common.Models.Item.ItemType(itemKey);
		int num2 = Shift.Legion.Common.Models.Item.Stock(GameManagers.Instance, itemKey);
		int num3 = Shift.Legion.Common.Models.Item.Level(GameManagers.Instance, itemKey);
		int level = ((num == 2) ? GameManagers.Instance.UserArchiveManager.GetWeaponEvoLevel(itemKey) : num3);
		ItemType itemType = (ItemType)num;
		ItemType itemType2 = itemType;
		if (itemType2 == ItemType.Weapon || itemType2 == ItemType.Blueprint)
		{
			GButton val = ProductList[weaponCnt++];
			((GComponent)val).GetChild("IconLoader").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemKey);
			((GComponent)val).GetChild("FrameLoader").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorder(2, level);
			((GObject)val).data = itemKey;
			((GObject)val).onClick.Set(new EventCallback1(PopupProductUpgrade));
			weaponsMap.Add(itemKey, val);
			GTextField asTextField = ((GComponent)val).GetChild("Requirement").asTextField;
			((GObject)asTextField).text = "";
			bool flag = num2 >= itemValue;
			bool flag2 = true;
			if (num == 2)
			{
				if (isMaxLevel)
				{
					((GObject)asTextField).text = ((GObject)asTextField).text + string.Format("[color=#FFFFFF]{0}{1}[/color][color=#FFFFFF]", num3 - 1, LanguagesManager.GetDesc("CsharpCodeZhTcText124"));
				}
				else
				{
					int num4 = GameManagers.Instance.UserArchiveManager.GetSoldierMaxLevel(soldier.Id) + 1;
					flag2 = num3 >= num4;
					((GObject)asTextField).text = ((GObject)asTextField).text + string.Format("[color=#{0}]{1}{2}[/color][color=#FFFFFF]/{3}{4}[/color]", flag2 ? "FFFFFF" : "DC143C", num3 - 1, LanguagesManager.GetDesc("CsharpCodeZhTcText124"), num4 - 1, LanguagesManager.GetDesc("CsharpCodeZhTcText124"));
				}
			}
			GObject child = ((GComponent)DegreeElevationPanel).GetChild($"line{weaponCnt}");
			if (child != null)
			{
				child.grayed = !flag || !flag2;
			}
			return;
		}
		GButton asButton = DegreeElevationPanel.consumptionBtn.consumptionList.AddItemFromPool().asButton;
		GComponent asCom = ((GComponent)asButton).GetChild("reqDesc").asCom;
		string text = ((num2 < itemValue) ? "#DC143C" : "#50280A");
		string text2 = "#50280A";
		GComponent asCom2 = asCom.GetChild("originPrice").asCom;
		((GObject)asCom2).visible = false;
		GTextField asTextField2 = asCom.GetChild("curPrice").asTextField;
		((GObject)asTextField2).text = "[color=" + text + "]" + num2.ShortNumberFormat() + "[/color][color=" + text2 + "]/" + itemValue.ShortNumberFormat() + "[/color]";
		((GObject)((GComponent)asButton).GetChild("name").asTextField).text = itemKey;
		((GObject)asButton).data = itemValue;
		((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(itemKey);
		((GComponent)asButton).GetChild("frame").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconFrameBorder(2, level);
		float percentFloatPayload = GameManagers.Instance.ModifierManager.GetPercentFloatPayload("SoldierEvoCost");
		if (percentFloatPayload < 0f)
		{
			asCom.GetChild("ExclamationMarkBtn").visible = true;
			asCom.GetChild("ExclamationMarkBtn").data = new Dictionary<string, object>
			{
				{
					"Title",
					LanguagesManager.GetDesc("CsharpCodeZhTcText105") + Environment.NewLine + string.Format("{0}：{1}%", LanguagesManager.GetDesc("CsharpCodeZhTcText553"), Convert.ToInt32(Mathf.Abs(percentFloatPayload) * 100f))
				},
				{
					"Pos",
					(object)new Vector2(1428f, 626f)
				}
			};
			asCom.GetChild("ExclamationMarkBtn").onClick.Set(new EventCallback1(FGUIManager.Instance.OpenExclamationMarkPanel));
		}
		else
		{
			asCom.GetChild("ExclamationMarkBtn").visible = false;
		}
		((GObject)((GComponent)asButton).GetChild("icon").asLoader).onClick.Set((EventCallback0)delegate
		{
			ItemTip(itemKey);
		});
	}

	private void ItemTip(string itemId)
	{
		FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder);
	}

	private void UpdateRedNoteStatus()
	{
		((GObject)DegreeElevationBtn.note).visible = soldier.CanEvolute();
		UpdatePotentialRedDotVisible();
		((GObject)SoulStoneBtn.note).visible = soldier.HasSoulStoneToComposite();
	}

	private void UpdatePotentialRedDotVisible()
	{
		((GObject)PotentialBtn.note).visible = false;
		switch (soldier.PotentialLevel)
		{
		case 8:
			if (!LegendItemsSlotUnlock)
			{
				((GObject)PotentialBtn.note).visible = CanUnlockLegendItemSlot();
			}
			else
			{
				((GObject)PotentialBtn.note).visible = (soldier.CanUpgradePotential() || soldier.CanAddPotentialProgress(1) || soldier.CanAddPotentialProgress(2) || soldier.CanAddPotentialProgress(4) || soldier.CanAddPotentialProgress(8)) && MythAvailable;
			}
			break;
		case 9:
			((GObject)PotentialBtn.note).visible = CanMythPromote();
			break;
		default:
			if (soldier.PotentialLevel < 8)
			{
				((GObject)PotentialBtn.note).visible = soldier.CanUpgradePotential() || soldier.CanAddPotentialProgress(1) || soldier.CanAddPotentialProgress(2) || soldier.CanAddPotentialProgress(4);
			}
			break;
		}
	}

	public void ElevationBtnEvent(EventContext eventContext)
	{
		if (!soldier.IsUnlocked)
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText540") }, 1, arg3: false);
			return;
		}
		if (!soldier.CanEvolute())
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText554") + "！" }, 1, arg3: false);
			return;
		}
		ILRequestHelper<SoldierEvoluteResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().SoldierEvolute(-1L, soldier.Id), delegate(SoldierEvoluteResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				OnSoldierEvoluteCompleted();
				ThinkingDataHelper.Instance.OnEvoluteCompletedTrack(soldier.Id);
			}
		});
	}

	private void OnSoldierEvoluteCompleted()
	{
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		if (soldier.CanEvolute())
		{
			evoLevelChanged = true;
			((GObject)DegreeElevationPanel.DegreeElevationUp_Btn).touchable = false;
			Vector2 val = default(Vector2);
			((Vector2)(ref val))._002Ector(((GObject)DegreeElevationPanel.SoldierEquipSfxBack).width / 2f, ((GObject)DegreeElevationPanel.SoldierEquipSfxBack).height / 2f);
			for (int i = 1; i < 5; i++)
			{
				GGraph SfxBack = ((GComponent)((GComponent)DegreeElevationPanel).GetChild($"Product{i}").asButton).GetChild("SfxBack").asGraph;
				FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "item_missile", new Vector3(50f, 50f, 50f), "Default", 0.5f, delegate(GameObject itemMissile)
				{
					itemMissile.AddComponent<HotFix_DestroySelf>().destroyTime = 0.3f;
				});
				Vector2 val2 = ((GObject)DegreeElevationPanel).TransformPoint(((GObject)DegreeElevationPanel.SoldierEquipSfxBack).xy, (GObject)(object)((GComponent)DegreeElevationPanel).GetChild($"Product{i}").asButton);
				((GObject)SfxBack).TweenMove(val2, 0.2f).OnComplete((GTweenCallback)delegate
				{
					((GObject)SfxBack).SetXY(77f, 80f);
				});
			}
			((GObject)DegreeElevationPanel.SoldierEquipSfxBack).TweenFade(1f, 0.2f).OnComplete((GTweenCallback)delegate
			{
				//IL_0025: Unknown result type (might be due to invalid IL or missing references)
				FGUIManager.Instance.AddTextSpecialEffects(DegreeElevationPanel.SoldierEquipSfxBack, "rubby_blast_white", new Vector3(200f, 200f, 200f), "Default", 0.5f, delegate(GameObject rubbyBlastWhite)
				{
					rubbyBlastWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
					UiAudioManager.Instance.LoadSoundsForSfx(rubbyBlastWhite, "BalloonBlast");
				});
			});
			PopupSoldierEvoluteSuccess();
			for (int num = 0; num < DegreeElevationPanel.consumptionBtn.consumptionList.numItems; num++)
			{
				((GObject)((GComponent)((GComponent)DegreeElevationPanel.consumptionBtn.consumptionList).GetChildAt(num).asButton).GetChild("titleSpine").asGraph).displayObject.Dispose();
				FGUIManager.Instance.AddTextSpecialEffects(((GComponent)((GComponent)DegreeElevationPanel.consumptionBtn.consumptionList).GetChildAt(num).asButton).GetChild("titleSpine").asGraph, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
				{
					uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
				});
			}
			return;
		}
		for (int num2 = 0; num2 < DegreeElevationPanel.consumptionBtn.consumptionList.numItems; num2++)
		{
			((GObject)((GComponent)((GComponent)DegreeElevationPanel.consumptionBtn.consumptionList).GetChildAt(num2).asButton).GetChild("titleSpine").asGraph).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(((GComponent)((GComponent)DegreeElevationPanel.consumptionBtn.consumptionList).GetChildAt(num2).asButton).GetChild("titleSpine").asGraph, FGUIManager.Instance.uiRed, Vector3.zero, "Default", 0.5f, delegate(GameObject uiRed)
			{
				uiRed.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
	}

	private void PopupSoldierEvoluteSuccess()
	{
		soldier.Evolute();
		if (soldier == null || soldier.Id != soldierId)
		{
			soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
		}
		FakeSoldier value = new FakeSoldier(soldierId, soldier.Level, soldier.EvoLevel - 1, soldier.PotentialLevel);
		FakeSoldier value2 = new FakeSoldier(soldierId, soldier.Level, soldier.EvoLevel, soldier.PotentialLevel);
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "Soldier", value2 },
			{ "FakeSoldier", value }
		};
		UnityUiService.Instance.OpenPanel(UI_NewUpguadeSuccessPanel.Name, parameters);
		SharedMessenger.AddListener<string>("CLOSE_UI", OnUpguadeSuccessPanelClosed);
	}

	private void OnUpguadeSuccessPanelClosed(string uiName)
	{
		if (!(uiName != UI_NewUpguadeSuccessPanel.Name))
		{
			canPlayUpgradeSfx = true;
			LoaderSoldierData(soldierId);
			SharedMessenger.RemoveListener<string>("CLOSE_UI", OnUpguadeSuccessPanelClosed);
		}
	}

	public void PopupProductUpgrade(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string value = ((GObject)(GComponent)context.sender).data.ToString();
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("ProductId", value);
		dictionary.Add("Style", "Work");
		dictionary.Add("Soldier", this);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_ProductUpGradePanel.Name, dictionary);
	}

	private void SoldierPotentialPanelUpdate(List<int> addStoneList, bool isUpPotential = false)
	{
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected O, but got Unknown
		//IL_0756: Unknown result type (might be due to invalid IL or missing references)
		//IL_0760: Expected O, but got Unknown
		if (ShowMythPage(addStoneList))
		{
			return;
		}
		SoldierPotentialPanel.PageController.selectedIndex = soldier.PotentialLevel;
		for (int i = 0; i < 3; i++)
		{
			((GComponent)SoldierPotentialPanel).GetChild($"SoulStoneLineLight{i}").alpha = 1f;
			GObject child = ((GComponent)SoldierPotentialPanel).GetChild($"SoulStone{i}");
			if (i == 1)
			{
				child.alpha = ((soldier.PotentialLevel == 8) ? 0f : 1f);
			}
			else
			{
				child.alpha = ((soldier.PotentialLevel == 0 || soldier.PotentialLevel == 2 || soldier.PotentialLevel == 6) ? 1f : 0f);
			}
		}
		if (soldier.PotentialLevel < 8)
		{
			SoldierPotentialPanel.unlockTip1st.GetController("Level").selectedIndex = soldier.PotentialLevel + 1;
		}
		float time = 0f;
		if (isUpPotential)
		{
			time = 1.5f;
			soldierPotentialPanelGTweenerFoo = ((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
			{
				//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
				if (!((GObject)SoldierPotentialPanel).isDisposed)
				{
					SoldierPotentialPanel.LevelIconController.selectedIndex = soldier.PotentialLevel;
					Vector3 size = default(Vector3);
					((Vector3)(ref size))._002Ector(150f, 150f, 150f);
					GGraph spine = SoldierPotentialPanel.PotentialIconSfxBack;
					if (soldier.PotentialLevel % 2 != 0)
					{
						((Vector3)(ref size))._002Ector(50f, 50f, 50f);
						spine = SoldierPotentialPanel.SoldierEquipSfxBack;
					}
					else if (soldier.PotentialLevel >= 8)
					{
						spine = SoldierPotentialPanel.MaxLevelTitleSfxBack;
					}
					FGUIManager.Instance.AddTextSpecialEffects(spine, "activating_white_big", size, "Default", 0.5f, delegate(GameObject activatingWhiteBig)
					{
						activatingWhiteBig.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
						UiAudioManager.Instance.LoadSoundsForSfx(activatingWhiteBig, "Refresh");
					});
				}
			});
			soldierPotentialPanelGTweenerBar = ((GComponent)(object)this).SetTimeout(1.5f).OnComplete((GTweenCallback)delegate
			{
				//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
				if (!((GObject)SoldierPotentialPanel).isDisposed)
				{
					SoldierPotentialPanel.SfxController.selectedIndex = 1;
					for (int j = 0; j < 3; j++)
					{
						GObject soulStoneSlot = ((GComponent)SoldierPotentialPanel).GetChild($"SoulStone{j}");
						if (Mathf.Approximately(soulStoneSlot.alpha, 1f))
						{
							GGraph soulStoneGraph = ((GComponent)SoldierPotentialPanel).GetChild($"SoulStoneSfxBack{j}").asGraph;
							FGUIManager.Instance.AddTextSpecialEffects(soulStoneGraph, "activating_white", new Vector3(150f, 150f, 150f), "Default", 0.5f, delegate(GameObject activatingWhite)
							{
								if (!((GObject)soulStoneGraph).isDisposed && ((GObject)soulStoneGraph).displayObject != null && !((GObject)soulStoneGraph).displayObject.isDisposed)
								{
									((GObject)soulStoneGraph).SetXY(soulStoneSlot.x, soulStoneSlot.y);
									activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.3f;
									UiAudioManager.Instance.LoadSoundsForSfx(activatingWhite, "Refresh");
								}
							});
						}
					}
				}
			});
		}
		else
		{
			SoldierPotentialPanel.SfxController.selectedIndex = 1;
			SoldierPotentialPanel.LevelIconController.selectedIndex = soldier.PotentialLevel;
		}
		ShowNewLPotentialLevelLogo();
		((GObject)SoldierPotentialPanel.specialitySfxBack).visible = true;
		if (soldier.PotentialLevel == 6)
		{
			FGUIManager.Instance.AddTextSpecialEffects(SoldierPotentialPanel.specialitySfxBack, "ui_active_glow_orange", new Vector3(25f, 25f, 25f));
		}
		else if (soldier.PotentialLevel == 7)
		{
			FGUIManager.Instance.AddTextSpecialEffects(SoldierPotentialPanel.specialitySfxBack, "ui_active_glow_orange_2", new Vector3(25f, 25f, 25f));
		}
		else
		{
			((GObject)SoldierPotentialPanel.specialitySfxBack).visible = false;
		}
		FakeSoldier data = new FakeSoldier(soldier.Id, soldier.Level, soldier.EvoLevel, soldier.NextPotentialLevel);
		((GObject)SoldierPotentialPanel.specialityBtn).data = data;
		((GObject)SoldierPotentialPanel.PotentialIconSfxBack).displayObject.Dispose();
		SetTimeout(time, "PotentialPanelUpdate1").OnComplete((GTweenCallback)delegate
		{
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			if (!((GObject)SoldierPotentialPanel).isDisposed)
			{
				if (soldier.PotentialLevel != 0 && soldier.PotentialLevel != 8)
				{
					FGUIManager.Instance.AddTextSpecialEffects(SoldierPotentialPanel.PotentialIconSfxBack, $"class_fx_{soldier.PotentialLevel}", new Vector3(100f, 100f, 100f));
				}
				else
				{
					((GObject)SoldierPotentialPanel.PotentialIconSfxBack).displayObject.Dispose();
					if (soldier.PotentialLevel >= 8)
					{
						FGUIManager.Instance.AddTextSpecialEffects(SoldierPotentialPanel.PotentialIconSfxBack, $"class_fx_{soldier.PotentialLevel}_2", new Vector3(100f, 100f, 100f));
						if (MythAvailable)
						{
							FGUIManager.Instance.AddTextSpecialEffects(SoldierPotentialPanel.ui_myth_logo_2, "class_fx_8", UiFxSize);
						}
						else
						{
							FGUIManager.Instance.AddTextSpecialEffects(SoldierPotentialPanel.MaxLevelTitleSfxBack, $"class_fx_{soldier.PotentialLevel}_1", new Vector3(100f, 100f, 100f));
						}
					}
				}
			}
		});
		if (soldier.PotentialLevel >= 8)
		{
			((GComponent)SoldierPotentialPanel.SoldierAttribute).GetController("Status").selectedIndex = 0;
		}
		else
		{
			((GComponent)SoldierPotentialPanel.SoldierAttribute).GetController("Status").selectedIndex = 1;
		}
		for (int num = 0; num < 3; num++)
		{
			GGraph asGraph = ((GComponent)SoldierPotentialPanel).GetChild($"SoulStoneSfxBack{num}").asGraph;
			((GObject)asGraph).displayObject.Dispose();
		}
		((GObject)SoldierPotentialPanel.SoldierAttribute.attackGrowup).text = Convert.ToInt32(soldier.AttackGrowUp).ToString();
		((GObject)SoldierPotentialPanel.SoldierAttribute.defenseGrowup).text = Convert.ToInt32(soldier.DefenseGrowUp).ToString();
		((GObject)SoldierPotentialPanel.SoldierAttribute.healthGrowup).text = Convert.ToInt32(soldier.HealthGrowUp).ToString();
		if (soldier.PotentialLevel < 8)
		{
			Dictionary<string, int> dictionary = soldier.NextLevelPotential.Requirements(GameManagers.Instance);
			if (dictionary != null && dictionary.Count > 0)
			{
				string text = dictionary.Keys.First();
				int num2 = dictionary.Values.First();
				if (num2 > 1)
				{
					for (int num3 = 0; num3 < 3; num3++)
					{
						GButton asButton = ((GComponent)SoldierPotentialPanel).GetChild($"SoulStone{num3}").asButton;
						string soulStoneItemId = text;
						int num4 = (int)Math.Pow(2.0, num3);
						((GObject)asButton).data = new Tuple<string, int, int>(text, num2, num4);
						if (soldier.PotentialProgress != null && soldier.PotentialProgress.Count > 0)
						{
							if (soldier.PotentialProgress.Contains(num4))
							{
								FGUIManager.Instance.SetSoulStoneIconAndFrame(asButton, soulStoneItemId, textureList);
							}
							else
							{
								FGUIManager.Instance.SetSoulStoneIconAndFrame(asButton, soulStoneItemId, textureList, 1);
							}
						}
						else
						{
							FGUIManager.Instance.SetSoulStoneIconAndFrame(asButton, soulStoneItemId, textureList, 1);
						}
						((GComponent)asButton).GetChild("note").visible = soldier.CanAddPotentialProgress(num4);
					}
				}
				else
				{
					GButton asButton2 = ((GComponent)SoldierPotentialPanel).GetChild($"SoulStone{1}").asButton;
					((GObject)asButton2).data = new Tuple<string, int, int>(text, num2, 2);
					string soulStoneItemId2 = text;
					if (soldier.PotentialProgress != null && soldier.PotentialProgress.Count > 0)
					{
						if (soldier.PotentialProgress.Contains(2))
						{
							FGUIManager.Instance.SetSoulStoneIconAndFrame(asButton2, soulStoneItemId2, textureList);
						}
						else
						{
							FGUIManager.Instance.SetSoulStoneIconAndFrame(asButton2, soulStoneItemId2, textureList, 1);
						}
					}
					else
					{
						FGUIManager.Instance.SetSoulStoneIconAndFrame(asButton2, soulStoneItemId2, textureList, 1);
					}
					((GComponent)asButton2).GetChild("note").visible = soldier.CanAddPotentialProgress(2);
				}
				SetNextUnlockSkillIcon();
				SetNextUnlockSoldierIcon();
			}
		}
		if (addStoneList != null && addStoneList.Count > 0)
		{
			float num5 = 0.25f;
			for (int num6 = 0; num6 < addStoneList.Count; num6++)
			{
				int index = addStoneList[num6];
				GButton asButton3 = ((GComponent)SoldierPotentialPanel).GetChild($"SoulStone{index}").asButton;
				GButton asButton4 = ((GComponent)asButton3).GetChild("IconBtn").asButton;
				((GComponent)asButton4).GetController("Status").selectedIndex = 1;
				SetTimeout(num5, "PotentialPanelUpdate2").OnComplete((GTweenCallback)delegate
				{
					//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
					if (!((GObject)SoldierPotentialPanel).isDisposed)
					{
						GButton soulStone = ((GComponent)SoldierPotentialPanel).GetChild($"SoulStone{index}").asButton;
						GButton asButton5 = ((GComponent)soulStone).GetChild("IconBtn").asButton;
						GGraph soulStoneGraph = ((GComponent)SoldierPotentialPanel).GetChild($"SoulStoneSfxBack{index}").asGraph;
						FGUIManager.Instance.AddTextSpecialEffects(soulStoneGraph, "activating_white", new Vector3(150f, 150f, 150f), "Default", 0.5f, delegate(GameObject activatingWhite)
						{
							if (!((GObject)soulStoneGraph).isDisposed && ((GObject)soulStoneGraph).displayObject != null && !((GObject)soulStoneGraph).displayObject.isDisposed)
							{
								((GObject)soulStoneGraph).SetXY(((GObject)soulStone).x, ((GObject)soulStone).y);
								activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
								UiAudioManager.Instance.LoadSoundsForSfx(activatingWhite, "CardsShow");
							}
						});
						((GComponent)asButton5).GetController("Status").selectedIndex = 0;
					}
				});
				num5 += 0.25f;
			}
		}
		SummonDemandListRender();
		if (soldier.CanUpgradePotential())
		{
			((GObject)SoldierPotentialPanel.PromoteBtn).enabled = true;
		}
		else
		{
			((GObject)SoldierPotentialPanel.PromoteBtn).enabled = false;
		}
		((GObject)SoldierPotentialPanel.PromoteBtn.note).visible = soldier.CanUpgradePotential();
	}

	private void OpenSpecialityPanel(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		FakeSoldier value = ((GObject)context.sender).data as FakeSoldier;
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(((GObject)GRoot.inst).LocalToRoot(new Vector2(((GObject)SoldierInfoPanel).x + ((GObject)SoldierInfoPanel).width / 2f, ((GObject)SoldierInfoPanel).y), GRoot.inst).x, ((GObject)GRoot.inst).LocalToRoot(new Vector2(((GObject)SoldierInfoPanel).x, ((GObject)SoldierInfoPanel).y + 611f), GRoot.inst).y);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Pos", val);
		dictionary.Add("SpecialityData", value);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, dictionary);
	}

	private void SetNextUnlockSkillIcon()
	{
		if (SoldierPotentialPanel.PageController.selectedIndex % 2 != 0)
		{
			return;
		}
		Dictionary<string, int> dictionary = soldier.AbilitiesUnlockState();
		List<string> list = new List<string>();
		Dictionary<string, int> dictionary2 = soldier.AbilitiesUnlockState();
		for (int i = 0; i < soldier.AbilityList.Count; i++)
		{
			if (GDMgr.TryGetWithErrorHandling<GDEAbilityData>(soldier.AbilityList[i]).Visible)
			{
				list.Add(soldier.AbilityList[i]);
			}
		}
		for (int j = 0; j < list.Count; j++)
		{
			if (dictionary[list[j]] == soldier.NextPotentialLevel)
			{
				GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(list[j]);
				bool item = ((dictionary2[list[j]] <= soldier.PotentialLevel) ? true : false);
				((GComponent)((GComponent)((GComponent)SoldierPotentialPanel.UnlockSkillList).GetChildAt(0).asButton).GetChild("IconBtn").asButton).GetChild("IconLoader").asLoader.LoadAbilityIcon(gDEAbilityData.Icon);
				((GObject)((GComponent)SoldierPotentialPanel.UnlockSkillList).GetChildAt(0).asButton).data = new Tuple<GDEAbilityData, bool, int>(gDEAbilityData, item, soldier.NextPotentialLevel);
				break;
			}
		}
	}

	private void SetNextUnlockSoldierIcon()
	{
		if (SoldierPotentialPanel.PageController.selectedIndex % 2 != 0)
		{
			int itemLevel = (soldier.NextPotentialLevel + 2) / 2;
			string iconPath = UiHelper.GetIconPath(soldier.Id, itemLevel);
			((GComponent)SoldierPotentialPanel.UnlockSoldierBtn).GetChild("icon").asLoader.url = "ui://PublicResources/" + iconPath;
			string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.NextPotentialLevel);
			((GComponent)SoldierPotentialPanel.UnlockSoldierBtn).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
			FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)SoldierPotentialPanel.UnlockSoldierBtn).GetChild("SoulStoneLevel").asCom, soldier.NextPotentialLevel, new List<int>());
		}
	}

	private void SetSoldierPotentialIconInfo(bool isUpPotential = false)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		string text = UpdateSoldierPotentialRequirement(isCurrent: false, isUpPotential);
		SoldierPotentialPanel.DemandIconLoader2.url = "";
		((GObject)SoldierPotentialPanel.DemandBackLoader2).touchable = false;
		((GObject)SoldierPotentialPanel.DemandIconLoader2).touchable = false;
		string itemId = text;
		FGUIManager.Instance.SetItemIconAndFrame(SoldierPotentialPanel.DemandFrameLoader2, itemId, textureList);
		((GObject)SoldierPotentialPanel.DemandFrameLoader2).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: false, reserveRes: false, this);
		});
	}

	private string UpdateSoldierPotentialRequirement(bool isCurrent = false, bool isUpPotential = false)
	{
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, int> dictionary = soldier.NextLevelPotential.Requirements(GameManagers.Instance);
		string text = dictionary.Keys.First();
		int num = dictionary.Values.First();
		Dictionary<string, int> originRequirement = soldier.NextLevelPotential.OriginRequirement;
		GComponent currentDemand_t = SoldierPotentialPanel.CurrentDemand_t;
		int stock = GameManagers.Instance.StockController.GetStock(text);
		string text2 = ((stock < num) ? "#DC143C" : "#50280A");
		string text3 = "#50280A";
		GComponent asCom = currentDemand_t.GetChild("originPrice").asCom;
		if (originRequirement[text] > num)
		{
			text3 = "#AFF627";
			((GObject)asCom).visible = true;
			((GObject)asCom.GetChild("content").asTextField).text = originRequirement[text].ToString("F0");
		}
		else
		{
			((GObject)asCom).SetSize(0f, 0f);
			((GObject)asCom).visible = false;
		}
		int number = stock;
		if (isCurrent)
		{
			number = stock - num;
		}
		GTextField asTextField = currentDemand_t.GetChild("curPrice").asTextField;
		((GObject)asTextField).text = "[color=" + text2 + "]" + number.ShortNumberFormat() + "[/color][color=" + text3 + "]/" + num.ShortNumberFormat() + "[/color]";
		if (isUpPotential)
		{
			((GObject)SoldierPotentialPanel.CurrentDemand_tSpine).displayObject.Dispose();
			FGUIManager.Instance.AddTextSpecialEffects(SoldierPotentialPanel.CurrentDemand_tSpine, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
			{
				uiGreen.AddComponent<HotFix_DestroySelf>().destroyTime = 0.5f;
			});
		}
		return text;
	}

	private void PromoteBtnEvent(EventContext eventContext)
	{
		if (!soldier.IsUnlocked)
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText540") }, 1, arg3: false);
			return;
		}
		if (!soldier.CanUpgradePotential())
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText541") }, 1, arg3: false);
			return;
		}
		ILRequestHelper<SoldierPotentialBreakthroughResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().SoldierPotentialBreakthrough(-1L, soldier.Id), delegate(SoldierPotentialBreakthroughResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				OnSoldierPotentialBreakthroughCompleted();
			}
		});
	}

	private void OnSoldierPotentialBreakthroughCompleted()
	{
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		potentialLevelChanged = true;
		((GObject)GRoot.inst).touchable = false;
		for (int i = 0; i < 3; i++)
		{
			if (((GComponent)SoldierPotentialPanel).GetChild($"SoulStone{i}").alpha == 1f)
			{
				((GComponent)SoldierPotentialPanel).GetChild($"SoulStone{i}").TweenFade(0f, 0.2f);
				((GComponent)SoldierPotentialPanel).GetChild($"SoulStoneLineLight{i}").TweenFade(0f, 0.1f);
				GGraph asGraph = ((GComponent)SoldierPotentialPanel).GetChild($"SoulStoneSfxBack{i}").asGraph;
				FGUIManager.Instance.AddTextSpecialEffects(asGraph, "item_missile", new Vector3(50f, 50f, 50f), "Default", 0.5f, delegate(GameObject itemMissile)
				{
					itemMissile.AddComponent<HotFix_DestroySelf>().destroyTime = 0.3f;
				});
				((GObject)asGraph).TweenMove(((GObject)SoldierPotentialPanel.PotentialIconSfxBack).xy, 0.2f);
			}
		}
		SetTimeout(0.2f, "PotentialBreakthroughCompleted1").OnComplete((GTweenCallback)delegate
		{
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			if (!((GObject)SoldierPotentialPanel).isDisposed)
			{
				FGUIManager.Instance.AddTextSpecialEffects(SoldierPotentialPanel.PotentialIconSfxBack, "rubby_blast_white", new Vector3(200f, 200f, 200f), "Default", 0.5f, delegate(GameObject rubbyBlastWhite)
				{
					rubbyBlastWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
					UiAudioManager.Instance.LoadSoundsForSfx(rubbyBlastWhite, "BalloonBlast");
				});
			}
		});
		SetTimeout(0.3f, "PotentialBreakthroughCompleted2").OnComplete((GTweenCallback)delegate
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			if (!((GObject)SoldierPotentialPanel).isDisposed)
			{
				showBlackMask.Play((PlayCompleteCallback)delegate
				{
					SoldierPotentialPanel.SfxController.selectedIndex = 0;
					FGUIManager.Instance.SoldierCultivatePanel = this;
					soldier.UpgradePotential();
					((GObject)GRoot.inst).touchable = true;
				});
			}
		});
	}

	private void AddWorkerEvent()
	{
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText21") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private void AddDiamondEvent()
	{
	}

	private void UpdateWorkerNum(Building building = null)
	{
		Dungeon value = GameController.Contexts.game.dungeon.value;
		addWorkerBtn.GetChild("CurrentWorkerAmount").text = $"{Dungeon.GetFreeManPower(GameManagers.Instance)}";
		addWorkerBtn.GetChild("AllWorkerAmount").text = $"{Dungeon.GetTotalManPower(GameManagers.Instance)}";
	}

	private void RenderStarItem(int index, GObject obj)
	{
		GComponent asCom = obj.asCom;
		asCom.GetChild("icon").asLoader.url = "ui://PublicResources/icon_star_Light";
	}

	private void RenderStarList(int num, GList list)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		list.itemRenderer = new ListItemRenderer(RenderStarItem);
		list.numItems = num;
	}

	private void RenderCodeItem(int index, GObject obj)
	{
		GButton asButton = obj.asButton;
	}

	private void RenderCodeList(int num)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		SoldierBreakthrougPanel.breakThroughCodeList.itemRenderer = new ListItemRenderer(RenderCodeItem);
		SoldierBreakthrougPanel.breakThroughCodeList.numItems = num;
	}

	private void OpenAttackAndDefense(GObject button, bool type, int index)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = default(Vector2);
		((Vector2)(ref val))._002Ector(((GObject)GRoot.inst).LocalToRoot(new Vector2(((GObject)SoldierInfoPanel).x + ((GObject)SoldierInfoPanel).width / 2f, ((GObject)SoldierInfoPanel).y), GRoot.inst).x, ((GObject)GRoot.inst).LocalToRoot(new Vector2(button.x, button.y + 150f), GRoot.inst).y);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Pos", val);
		dictionary.Add("Type", type);
		dictionary.Add("Index", index);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SpearAndShield.Name, dictionary);
	}

	private GTweener SetTimeout(float time, string key)
	{
		if (_timeoutDict.TryGetValue(key, out var value))
		{
			value.Kill(false);
			_timeoutDict[key] = null;
		}
		return ((GComponent)(object)this).SetTimeout(time);
	}

	private void MythEventRegister()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		((GObject)SoldierMythPage.LPromoteBtn).onClick.Add(new EventCallback1(MythPromoteEvent));
		((GObject)SoldierMythPage.OpenPromote).onClick.Add(new EventCallback0(OpenMyth));
		((GObject)SoldierMythPage.MythPromoteBtn).onClick.Add(new EventCallback0(UpdateMythLevel));
		((GObject)SoldierMythPage.specialityBtn).onClick.Add(new EventCallback1(OpenSpecialityPanel));
		((GObject)SoldierMythPage.UnlockSoldierBtn).data = 0;
		((GObject)SoldierMythPage.UnlockSoldierBtn).onClick.Add(new EventCallback1(OpenSoldierPromotionPanel));
		((GObject)SoldierMythPage.PotentialIcon).data = 0;
		((GObject)SoldierMythPage.PotentialIcon).onClick.Add(new EventCallback1(OpenSoldierPromotionPanel));
		SharedMessenger.AddListener("SHOW_L_TO_M_PAGE", Play4To0);
	}

	private void MythEventUnRegister()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		((GObject)SoldierMythPage.LPromoteBtn).onClick.Remove(new EventCallback1(MythPromoteEvent));
		((GObject)SoldierMythPage.OpenPromote).onClick.Remove(new EventCallback0(OpenMyth));
		((GObject)SoldierMythPage.MythPromoteBtn).onClick.Remove(new EventCallback0(UpdateMythLevel));
		((GObject)SoldierMythPage.specialityBtn).onClick.Remove(new EventCallback1(OpenSpecialityPanel));
		((GObject)SoldierMythPage.UnlockSoldierBtn).onClick.Remove(new EventCallback1(OpenSoldierPromotionPanel));
		((GObject)SoldierMythPage.PotentialIcon).onClick.Remove(new EventCallback1(OpenSoldierPromotionPanel));
		SharedMessenger.RemoveListener("SHOW_L_TO_M_PAGE", Play4To0);
	}

	private void UpdateMythLevel()
	{
		if (!MythAvailable || soldier.PotentialLevel < 9)
		{
			return;
		}
		int nextLevel = GameManagers.Instance.UserArchiveManager.GetSoldierMyth(soldier.Id).Level + 1;
		ILRequestHelper<UpdateSoldierMythResponse>.Request((EventContext)null, (Func<Task<UpdateSoldierMythResponse>>)(() => GameController.Contexts.Service<INetworkService>().UpdateSoldierMyth(soldier.Id, nextLevel)), (Action<UpdateSoldierMythResponse>)delegate(UpdateSoldierMythResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameManagers.Instance.UserArchiveManager.AddOneSoldierMythLevel(soldier.Id, response.CurLevel);
				response.UpdateCostStock();
				PlayMythLevelUp(response.CurLevel - 1);
				UpdatePotentialRedDotVisible();
			}
		});
	}

	private void OpenMyth()
	{
		if (!MythAvailable || soldier.PotentialLevel < 9)
		{
			return;
		}
		ILRequestHelper<OpenSoldierMythResponse>.Request((EventContext)null, (Func<Task<OpenSoldierMythResponse>>)(() => GameController.Contexts.Service<INetworkService>().OpenSoldierMyth(soldier.Id)), (Action<OpenSoldierMythResponse>)delegate(OpenSoldierMythResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameManagers.Instance.UserArchiveManager.OpenSoldierMyth(soldier.Id);
				PlayMToM0(force: true);
				UpdatePotentialRedDotVisible();
			}
		});
	}

	private void CheckLegendItemSlot()
	{
		if (!MythAvailable || !LegendItemsSlotUnlock)
		{
			return;
		}
		ILRequestHelper<CheckLegendItemSlotResponse>.Request((EventContext)null, (Func<Task<CheckLegendItemSlotResponse>>)(() => GameController.Contexts.Service<INetworkService>().CheckLegendItemSlot(new List<string> { soldier.Id })), (Action<CheckLegendItemSlotResponse>)delegate(CheckLegendItemSlotResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				GameManagers.Instance.UserArchiveManager.SetLegendItemSlotCheckRecord(soldier.Id);
				((GObject)LegendSlot.NewDot).visible = LegendItemSlotChecked();
			}
		});
	}

	private void MythPromoteEvent(EventContext eventContext)
	{
		if (!MythAvailable)
		{
			return;
		}
		if (!soldier.IsUnlocked)
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText540") }, 1, arg3: false);
			return;
		}
		if (!soldier.CanUpgradePotential())
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText541") }, 1, arg3: false);
			return;
		}
		ILRequestHelper<SoldierPotentialBreakthroughResponse>.Request(eventContext, () => GameController.Contexts.Service<INetworkService>().SoldierPotentialBreakthrough(-1L, soldier.Id), delegate(SoldierPotentialBreakthroughResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				ShowLToM = true;
				OnSoldierPotentialChange();
			}
		});
	}

	private bool CanUnlockLegendItemSlot()
	{
		Dictionary<string, int> unlockSoldierItemSlotCost = LegendItemsHelper.GetUnlockSoldierItemSlotCost(soldierId, 1);
		return GameManagers.Instance.StockController.GetStock(unlockSoldierItemSlotCost.First().Key) >= unlockSoldierItemSlotCost.First().Value;
	}

	private bool CanUnlockLegendItemSlotForUi()
	{
		if (!MythAvailable)
		{
			return false;
		}
		if (soldier.PotentialLevel != 8)
		{
			return false;
		}
		if (LegendItemsSlotUnlock)
		{
			return false;
		}
		return CanUnlockLegendItemSlot();
	}

	private bool LegendItemSlotChecked()
	{
		if (!MythAvailable)
		{
			return false;
		}
		if (!LegendItemsSlotUnlock)
		{
			return false;
		}
		return !GameManagers.Instance.UserArchiveManager.GetLegendItemSlotCheckRecord(soldier.Id);
	}

	private void ShowNewLPotentialLevelLogo()
	{
		if (soldier.PotentialLevel == 8)
		{
			if (MythAvailable)
			{
				((GObject)SoldierPotentialPanel.n300).visible = false;
				((GObject)SoldierPotentialPanel.n301).visible = false;
				((GObject)SoldierPotentialPanel.n330).visible = true;
			}
			else
			{
				((GObject)SoldierPotentialPanel.n300).visible = true;
				((GObject)SoldierPotentialPanel.n301).visible = true;
				((GObject)SoldierPotentialPanel.n330).visible = false;
			}
		}
	}

	private bool ShowMythPage(List<int> addStoneList = null)
	{
		((GObject)SoldierPotentialPanel).visible = true;
		((GObject)SoldierMythPage).visible = false;
		if (soldier.PotentialLevel < 8)
		{
			return false;
		}
		if (!LegendItemsSlotUnlock)
		{
			return false;
		}
		if (Requirements == null || Requirements.Count <= 0)
		{
			return false;
		}
		if (!MythAvailable)
		{
			return false;
		}
		((GObject)SoldierPotentialPanel).visible = false;
		((GObject)SoldierMythPage).visible = true;
		if (ShowLToM)
		{
			ShowLToM = false;
			PlayLToM();
			return true;
		}
		LToM();
		UpdateMythPage();
		UpdateStoneSlot(addStoneList);
		return true;
	}

	private void PlayMToM0(bool force)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		RenderM0Page();
		if (((GObject)SoldierMythPage).isDisposed)
		{
			return;
		}
		if (force)
		{
			SoldierMythPage.ToM0.SetHook("ui_myth_to_myth0", (TransitionHook)delegate
			{
				//IL_003b: Unknown result type (might be due to invalid IL or missing references)
				if (!((GObject)SoldierMythPage).isDisposed)
				{
					SoldierMythPage.LevelIconController.selectedIndex = 2;
					FGUIManager.Instance.AddTextSpecialEffects(SoldierMythPage.ui_myth_to_myth0, "ui_myth_to_myth0", UiFxSize, "Default", 0.5f, delegate(GameObject toMyth0)
					{
						UiHelper.DestoryUiSfx(SoldierMythPage.ui_myth_to_myth0, toMyth0, 1f);
					});
				}
			});
			SoldierMythPage.ToM0.Play();
			return;
		}
		SoldierMythPage.ToM0.ClearHooks();
		SoldierMythPage.ToM0.Play((PlayCompleteCallback)delegate
		{
			if (!((GObject)SoldierMythPage).isDisposed)
			{
				((GObject)SoldierMythPage.ui_myth_to_myth0).visible = false;
			}
		});
		SoldierMythPage.ToM0.Stop(true, true);
	}

	private void RenderM0Page()
	{
		SetUiFx();
		int level = GameManagers.Instance.UserArchiveManager.GetSoldierMyth(soldier.Id).Level;
		SetMythPromoteBtnState();
		if (level <= 0)
		{
			((GObject)SoldierMythPage.NextAttack).text = "+" + GameManagers.Instance.UserArchiveManager.GetCurrentLevelPercentAttrText(soldier.Id, "EA02", 1);
			((GObject)SoldierMythPage.NextDefense).text = "+" + GameManagers.Instance.UserArchiveManager.GetCurrentLevelPercentAttrText(soldier.Id, "EA03", 1);
			((GObject)SoldierMythPage.NextHealth).text = "+" + GameManagers.Instance.UserArchiveManager.GetCurrentLevelPercentAttrText(soldier.Id, "EA01", 1);
		}
	}

	private void PlayLToM()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		SetUiFx();
		if (!MythOpened)
		{
			SoldierMythPage.LevelIconController.selectedIndex = 5;
			ShowCurrentEAValue();
			SoldierMythPage.ToM.Play((PlayCompleteCallback)delegate
			{
				ShowLToM = false;
				SoldierMythPage.LevelIconController.selectedIndex = 1;
			});
		}
	}

	private void LToM()
	{
		SetUiFx();
		if (!MythOpened)
		{
			SoldierMythPage.LevelIconController.selectedIndex = 5;
			ShowCurrentEAValue();
			SoldierMythPage.ToM.Play();
			SoldierMythPage.ToM.Stop(true, true);
			ShowLToM = false;
			SoldierMythPage.LevelIconController.selectedIndex = 1;
		}
	}

	private void Play4To0()
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		((GObject)SoldierPotentialPanel).visible = true;
		((GObject)SoldierMythPage).visible = false;
		if (soldier.PotentialLevel < 8 || Requirements == null || Requirements.Count <= 0 || !MythAvailable)
		{
			return;
		}
		((GObject)SoldierPotentialPanel).visible = false;
		((GObject)SoldierMythPage).visible = true;
		SetUiFx();
		SoldierMythPage.LevelIconController.selectedIndex = 4;
		ShowCurrentEAValue();
		((GObject)GRoot.inst).touchable = false;
		SoldierMythPage.ToL.SetHook("StonesAppear", (TransitionHook)delegate
		{
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			for (int i = 0; i < 4; i++)
			{
				GGraph asGraph = ((GComponent)SoldierMythPage).GetChild($"SoulStoneSfxBack{i}").asGraph;
				((GObject)asGraph).SetXY(((GComponent)SoldierMythPage).GetChild($"SoulStone{i}").x, ((GComponent)SoldierMythPage).GetChild($"SoulStone{i}").y);
				FGUIManager.Instance.AddTextSpecialEffects(asGraph, "activating_white", UiFxSize, "Default", 0.5f, delegate(GameObject activatingWhite)
				{
					activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.3f;
				});
			}
			FGUIManager.Instance.AddTextSpecialEffects(SoldierMythPage.PromoteItemSfxBack, "activating_white", UiFxSize, "Default", 0.5f, delegate(GameObject whiteBig)
			{
				UiHelper.DestoryUiSfx(SoldierMythPage.PromoteItemSfxBack, whiteBig, 1f);
				UiAudioManager.Instance.LoadSoundsForSfx(whiteBig, "Refresh");
			});
		});
		SoldierMythPage.ToL.Play((PlayCompleteCallback)delegate
		{
			SoldierMythPage.LevelIconController.selectedIndex = 0;
			RenderLPotentialLevel();
			((GObject)GRoot.inst).touchable = true;
			FlashingLegendItemSlot(1);
		});
	}

	private void FlashingLegendItemSlot(int slot)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		LegendSlot.ShowNewDot.SetHook("ChangeSlotType", new TransitionHook(ChangeSlotType));
		LegendSlot.ShowNewDot.SetHook("PlayFX", new TransitionHook(PlayParticleEffect));
		LegendSlot.ShowNewDot.SetHook("ShowDot", new TransitionHook(ChangeNewDotVisible));
		LegendSlot.ShowNewDot.Play();
		void ChangeNewDotVisible()
		{
			((GObject)LegendSlot.NewDot).visible = LegendItemSlotChecked();
		}
		void ChangeSlotType()
		{
			LegendItemButtonsInit();
			((GObject)LegendSlot.NewDot).visible = false;
		}
		void PlayParticleEffect()
		{
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			GGraph graph = ((GComponent)LegendItemButtons[slot]).GetChild("sfxBack").asGraph;
			FGUIManager.Instance.AddTextSpecialEffects(graph, "ui_active_strong", new Vector3(200f, 200f, 200f), "Default", 0.5f, delegate(GameObject effect)
			{
				UiHelper.DestoryUiSfx(graph, effect, 2.1f);
				EffectHelper.CoroutineDelay(1.3f, delegate
				{
					UiAudioManager.Instance.PlaySoundEffect("equipSlotUnlock");
				});
			});
		}
	}

	private void UpdateMythPage()
	{
		if (IsNotMythPotentialLevel)
		{
			SoldierMythPage.LevelIconController.selectedIndex = 0;
			RenderLPotentialLevel();
			ShowCurrentEAValue();
			SetUiFx();
			return;
		}
		if (!MythOpened)
		{
			if (ShowLToM)
			{
				SoldierMythPage.ToM.Play();
			}
			SoldierMythPage.LevelIconController.selectedIndex = 1;
			ShowCurrentEAValue();
			SetUiFx();
			return;
		}
		PlayMToM0(force: false);
		int level = GameManagers.Instance.UserArchiveManager.GetSoldierMyth(soldier.Id).Level;
		SetMythPromoteBtnState();
		if (level <= 0)
		{
			SoldierMythPage.LevelIconController.selectedIndex = 2;
			((GObject)SoldierMythPage.NextAttack).text = "+" + GameManagers.Instance.UserArchiveManager.GetCurrentLevelPercentAttrText(soldier.Id, "EA02", 1);
			((GObject)SoldierMythPage.NextDefense).text = "+" + GameManagers.Instance.UserArchiveManager.GetCurrentLevelPercentAttrText(soldier.Id, "EA03", 1);
			((GObject)SoldierMythPage.NextHealth).text = "+" + GameManagers.Instance.UserArchiveManager.GetCurrentLevelPercentAttrText(soldier.Id, "EA01", 1);
			SetUiFx();
			return;
		}
		SoldierMythPage.LevelIconController.selectedIndex = 3;
		((GObject)SoldierMythPage.MLevelText).text = GetMLevelText(level);
		((GObject)SoldierMythPage.CurrentLevel).text = $"Lv{level}";
		((GObject)SoldierMythPage.NextLevel).text = $"Lv{level + 1}";
		((GObject)SoldierMythPage.CurrentAttack).text = GameManagers.Instance.UserArchiveManager.GetCurrentLevelPercentAttrText(soldier.Id, "EA02");
		((GObject)SoldierMythPage.CurrentDefense).text = GameManagers.Instance.UserArchiveManager.GetCurrentLevelPercentAttrText(soldier.Id, "EA03");
		((GObject)SoldierMythPage.CurrentHealth).text = GameManagers.Instance.UserArchiveManager.GetCurrentLevelPercentAttrText(soldier.Id, "EA01");
		((GObject)SoldierMythPage.NextAttack).text = GameManagers.Instance.UserArchiveManager.GetNextLevelPercentAttrIncrementText(soldier.Id, "EA02");
		((GObject)SoldierMythPage.NextDefense).text = GameManagers.Instance.UserArchiveManager.GetNextLevelPercentAttrIncrementText(soldier.Id, "EA03");
		((GObject)SoldierMythPage.NextHealth).text = GameManagers.Instance.UserArchiveManager.GetNextLevelPercentAttrIncrementText(soldier.Id, "EA01");
		SetUiFx();
	}

	private string GetMLevelText(int level)
	{
		string text = level.ToString();
		string text2 = "";
		for (int i = 0; i < text.Length; i++)
		{
			text2 += $"<img src='ui://PublicResources/MythNumber{text[i]}'/>";
		}
		return text2;
	}

	private void OnSoldierPotentialChange()
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		potentialLevelChanged = true;
		((GObject)GRoot.inst).touchable = false;
		for (int i = 0; i < 4; i++)
		{
			((GComponent)SoldierMythPage).GetChild($"SoulStone{i}").TweenFade(0f, 0.2f);
			((GComponent)SoldierMythPage).GetChild($"SoulStoneLineLight{i}").TweenFade(0f, 0.1f);
			GGraph asGraph = ((GComponent)SoldierMythPage).GetChild($"SoulStoneSfxBack{i}").asGraph;
			FGUIManager.Instance.AddTextSpecialEffects(asGraph, "item_missile", new Vector3(50f, 50f, 50f), "Default", 0.5f, delegate(GameObject itemMissile)
			{
				itemMissile.AddComponent<HotFix_DestroySelf>().destroyTime = 0.3f;
			});
			((GObject)asGraph).TweenMove(((GObject)SoldierMythPage.ui_myth_logo_2).xy, 0.2f);
		}
		((GComponent)(object)this).SetTimeout(0.2f).OnComplete((GTweenCallback)delegate
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			FGUIManager.Instance.AddTextSpecialEffects(SoldierMythPage.PotentialIconSfxBack, "rubby_blast_white", new Vector3(200f, 200f, 200f), "Default", 0.5f, delegate(GameObject rubbyBlastWhite)
			{
				rubbyBlastWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
				UiAudioManager.Instance.LoadSoundsForSfx(rubbyBlastWhite, "BalloonBlast");
			});
		});
		((GComponent)(object)this).SetTimeout(0.3f).OnComplete((GTweenCallback)delegate
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Expected O, but got Unknown
			showBlackMask.Play((PlayCompleteCallback)delegate
			{
				FGUIManager.Instance.SoldierCultivatePanel = this;
				soldier.UpgradePotential();
				((GObject)GRoot.inst).touchable = true;
			});
		});
	}

	private void UpdateStoneSlot(List<int> addStoneList)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		if (addStoneList == null || addStoneList.Count <= 0)
		{
			return;
		}
		float num = 0.25f;
		for (int i = 0; i < addStoneList.Count; i++)
		{
			int index = addStoneList[i];
			GButton asButton = ((GComponent)SoldierMythPage).GetChild($"SoulStone{index}").asButton;
			GButton asButton2 = ((GComponent)asButton).GetChild("IconBtn").asButton;
			((GComponent)asButton2).GetController("Status").selectedIndex = 1;
			((GComponent)(object)this).SetTimeout(num).OnComplete((GTweenCallback)delegate
			{
				//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
				GGraph asGraph = ((GComponent)SoldierMythPage).GetChild($"SoulStoneSfxBack{index}").asGraph;
				((GObject)asGraph).SetXY(((GComponent)SoldierMythPage).GetChild($"SoulStone{index}").x, ((GComponent)SoldierMythPage).GetChild($"SoulStone{index}").y);
				FGUIManager.Instance.AddTextSpecialEffects(asGraph, "activating_white", new Vector3(150f, 150f, 150f), "Default", 0.5f, delegate(GameObject activatingWhite)
				{
					activatingWhite.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
					UiAudioManager.Instance.LoadSoundsForSfx(activatingWhite, "CardsShow");
				});
				GButton asButton3 = ((GComponent)SoldierMythPage).GetChild($"SoulStone{index}").asButton;
				GButton asButton4 = ((GComponent)asButton3).GetChild("IconBtn").asButton;
				((GComponent)asButton4).GetController("Status").selectedIndex = 0;
			});
			num += 0.25f;
		}
	}

	private void RenderLPotentialLevel()
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		((GObject)SoldierMythPage.LPromoteBtn).enabled = soldier.CanUpgradeMythPotential();
		SetMythSoldierIcon();
		FakeSoldier data = new FakeSoldier(soldier.Id, soldier.Level, soldier.EvoLevel, soldier.NextPotentialLevel);
		((GObject)SoldierMythPage.specialityBtn).data = data;
		FGUIManager.Instance.AddTextSpecialEffects(SoldierMythPage.specialitySfxBack, "ui_active_glow_orange_2", new Vector3(25f, 25f, 25f));
		RenderPromoteItem();
		RenderAllStoneSlot();
	}

	private void RenderPromoteItem()
	{
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		string itemId;
		if (Requirements != null && Requirements.Count > 0)
		{
			int index = Requirements.Count - 1;
			itemId = Requirements[index].Key;
			int value = Requirements[index].Value;
			FGUIManager.Instance.SetItemIconAndFrame(SoldierMythPage.PromoteItem, itemId, null, "", frameVisible: false);
			bool flag = GameManagers.Instance.StockController.GetStock(itemId) >= value;
			((GObject)SoldierMythPage.PromoteItem).grayed = !flag;
			((GObject)SoldierMythPage.PromoteItem).onClick.Clear();
			if (!flag)
			{
				((GObject)SoldierMythPage.PromoteItem).onClick.Set(new EventCallback0(ItemDesc));
			}
		}
		void ItemDesc()
		{
			FGUIManager.Instance.ItemTip(itemId, 1);
		}
	}

	private void RenderAllStoneSlot()
	{
		if (Requirements == null || Requirements.Count <= 0)
		{
			return;
		}
		string key = Requirements[0].Key;
		int value = Requirements[0].Value;
		for (int i = 0; i < 4; i++)
		{
			GButton asButton = ((GComponent)SoldierMythPage).GetChild($"SoulStone{i}").asButton;
			((GObject)asButton).visible = true;
			((GObject)asButton).alpha = 1f;
			string soulStoneItemId = key;
			int num = (int)Math.Pow(2.0, i);
			((GObject)asButton).data = new Tuple<string, int, int>(key, value, num);
			if (soldier.PotentialProgress != null && soldier.PotentialProgress.Count > 0)
			{
				if (soldier.PotentialProgress.Contains(num))
				{
					FGUIManager.Instance.SetSoulStoneIconAndFrame(asButton, soulStoneItemId);
				}
				else
				{
					FGUIManager.Instance.SetSoulStoneIconAndFrame(asButton, soulStoneItemId, null, 1);
				}
			}
			else
			{
				FGUIManager.Instance.SetSoulStoneIconAndFrame(asButton, soulStoneItemId, null, 1);
			}
			((GComponent)asButton).GetChild("note").visible = soldier.CanAddPotentialProgress(num);
		}
	}

	private void SetMythSoldierIcon()
	{
		int itemLevel = (soldier.NextPotentialLevel + 2) / 2;
		string iconPath = UiHelper.GetIconPath(soldier.Id, itemLevel);
		((GComponent)SoldierMythPage.UnlockSoldierBtn).GetChild("icon").asLoader.url = "ui://PublicResources/" + iconPath;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.NextPotentialLevel);
		((GComponent)SoldierMythPage.UnlockSoldierBtn).GetChild("iconFrame").asLoader.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(((GComponent)SoldierMythPage.UnlockSoldierBtn).GetChild("SoulStoneLevel").asCom, soldier.NextPotentialLevel, new List<int>());
	}

	private void ShowCurrentEAValue()
	{
		((GObject)SoldierMythPage.SoldierAttribute.attackGrowup).text = Convert.ToInt32(soldier.AttackGrowUp).ToString();
		((GObject)SoldierMythPage.SoldierAttribute.defenseGrowup).text = Convert.ToInt32(soldier.DefenseGrowUp).ToString();
		((GObject)SoldierMythPage.SoldierAttribute.healthGrowup).text = Convert.ToInt32(soldier.HealthGrowUp).ToString();
	}

	private void SetUiFx()
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		((GObject)SoldierMythPage.ui_myth_logo_1).visible = true;
		((GObject)SoldierMythPage.ui_myth_logo_2).visible = true;
		if (IsNotMythPotentialLevel)
		{
			FGUIManager.Instance.AddTextSpecialEffects(SoldierMythPage.ui_myth_logo_1, "class_fx_8", UiFxSize);
			((GObject)SoldierMythPage.ui_myth_logo_2).visible = false;
			return;
		}
		FGUIManager.Instance.AddTextSpecialEffects(SoldierMythPage.ui_myth_logo_2, "class_fx_9_2", UiFxSize);
		FGUIManager.Instance.AddTextSpecialEffects(SoldierMythPage.ui_myth_logo_1, "class_fx_9_1", UiFxSize);
		if (MythOpened)
		{
			if (GameManagers.Instance.UserArchiveManager.GetSoldierMyth(soldier.Id).Level >= 10)
			{
				FGUIManager.Instance.AddTextSpecialEffects(SoldierMythPage.ui_myth_number_2, "ui_myth_number_2", UiFxSize);
				FGUIManager.Instance.AddTextSpecialEffects(SoldierMythPage.ui_myth_number_1, "ui_myth_number_1", UiFxSize);
			}
			else
			{
				FGUIManager.Instance.AddTextSpecialEffects(SoldierMythPage.ui_myth_number_2, "ui_myth_number_short_2", UiFxSize);
				FGUIManager.Instance.AddTextSpecialEffects(SoldierMythPage.ui_myth_number_1, "ui_myth_number_short_1", UiFxSize);
			}
		}
	}

	private bool CanMythPromote()
	{
		if (soldier.PotentialLevel < 9)
		{
			return false;
		}
		if (!MythOpened)
		{
			return false;
		}
		if (Requirements == null || Requirements.Count <= 0)
		{
			return false;
		}
		string key = Requirements[0].Key;
		int sStoneCost = GameManagers.Instance.UserArchiveManager.GetSStoneCost(soldier.Id);
		int stock = GameManagers.Instance.StockController.GetStock(key);
		return stock >= sStoneCost;
	}

	private void SetMythPromoteBtnState()
	{
		if (Requirements != null && Requirements.Count > 0)
		{
			bool flag = CanMythPromote();
			((GObject)SoldierMythPage.MythPromoteBtn).enabled = flag;
			string arg = ((!flag) ? "#ff1a1a" : "#7C4B2A");
			string key = Requirements[0].Key;
			int sStoneCost = GameManagers.Instance.UserArchiveManager.GetSStoneCost(soldier.Id);
			int stock = GameManagers.Instance.StockController.GetStock(key);
			((GObject)SoldierMythPage.CostStoneNum).text = $"[color={arg}]{stock}[/color]/{sStoneCost}";
			FGUIManager.Instance.SetSoulStoneIconAndFrame(SoldierMythPage.CostStone, key);
		}
	}

	private void PlayMythLevelUp(int previousLevel)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		RefreshSoldierDetailInfo();
		WaitToRefreshCombatPower(_isUpGrade: false);
		if (previousLevel <= 0)
		{
			((GComponent)(object)this).SetTimeout(0.5f).OnComplete(new GTweenCallback(UpdateMythPage));
			SoldierMythPage.LevelValueUpdate.t0.Play();
			return;
		}
		((GObject)GRoot.inst).touchable = false;
		SoldierMythPage.t0.SetHook("myth_number_change", new TransitionHook(RefreshText));
		SoldierMythPage.t0.Play();
		SoldierMythPage.LevelValueUpdate.t0.Play();
		void RefreshText()
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Expected O, but got Unknown
			UpdateMythPage();
			GameObject ui_myth_number_change_fx = FGUIManager.Instance.AddTextSpecialEffects(SoldierMythPage.ui_myth_number_change, "ui_myth_number_change", UiFxSize);
			((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
			{
				SpawnManager.Instance.Destroy(ui_myth_number_change_fx);
			});
			((GObject)GRoot.inst).touchable = true;
		}
	}

	private List<KeyValuePair<string, int>> GetMythRequirements()
	{
		FakeSoldier fakeSoldier = new FakeSoldier(soldier.Id, soldier.Level, soldier.EvoLevel, 8);
		return fakeSoldier.NextLevelPotential?.Requirements(GameManagers.Instance).ToList();
	}
}
