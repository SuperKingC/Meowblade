using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Entitas;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion;
using Shift.Legion.Client.Sources.Extensions;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Spine.Unity;
using UI.GameEndPanels;
using UI.GiftBag;
using UI.MilitaryIntelligence;
using UI.MonthCard;
using UI.PublicResources;
using UI.QuickBattle;
using UI.SpecialActivity;
using UI.Tips;
using UI.UpGrade;
using UI.WorkShop;
using UnityEngine;

namespace UI.InstanceZones;

public class UI_InstanceZonesPanel : GComponent, IUiController, IAnyLoadingPanelStatusListener
{
	private enum InstanceZonesType
	{
		Common,
		Defensive,
		Offensive,
		SpringFestival,
		Advanced,
		NeutralDungeon
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Action<GameObject> _003C_003E9__183_2;

		public static EventCallback0 _003C_003E9__207_0;

		public static EventCallback0 _003C_003E9__207_1;

		public static EventCallback0 _003C_003E9__207_2;

		public static EventCallback0 _003C_003E9__207_3;

		public static GTweenCallback _003C_003E9__217_0;

		public static Action<GameObject> _003C_003E9__218_0;

		public static Action<GameObject> _003C_003E9__218_1;

		public static Action<GameObject> _003C_003E9__218_2;

		public static Func<string, global::_003C_003Ef__AnonymousType0<string, Soldier>> _003C_003E9__254_0;

		public static Func<global::_003C_003Ef__AnonymousType0<string, Soldier>, int> _003C_003E9__254_1;

		public static Func<global::_003C_003Ef__AnonymousType0<string, Soldier>, Soldier> _003C_003E9__254_2;

		public static Action<GameObject> _003C_003E9__258_0;

		public static Action<GameObject> _003C_003E9__258_2;

		internal void _003CShowOffensiveCardsInTurn_003Eb__183_2(GameObject sparkleGold)
		{
			sparkleGold.AddComponent<HotFix_DestroySelf>().destroyTime = 0.8f;
		}

		internal void _003CRemoveBattleEvent_003Eb__207_0()
		{
		}

		internal void _003CRemoveBattleEvent_003Eb__207_1()
		{
		}

		internal void _003CRemoveBattleEvent_003Eb__207_2()
		{
		}

		internal void _003CRemoveBattleEvent_003Eb__207_3()
		{
		}

		internal async void _003CReceiveIntegralBonuses_003Eb__217_0()
		{
		}

		internal void _003CPlayReceiveSfx_003Eb__218_0(GameObject leftIconSfx)
		{
			if ((Object)(object)leftIconSfx == (Object)null)
			{
				ILRuntimeDebug.LogError("UI_InstanceZonesPanel.PlayReceiveSfx, leftIconSfx is null");
			}
			else
			{
				leftIconSfx.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
			}
		}

		internal void _003CPlayReceiveSfx_003Eb__218_1(GameObject rightIconSfx)
		{
			if ((Object)(object)rightIconSfx == (Object)null)
			{
				ILRuntimeDebug.LogError("UI_InstanceZonesPanel.PlayReceiveSfx, rightIconSfx is null");
			}
			else
			{
				rightIconSfx.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
			}
		}

		internal void _003CPlayReceiveSfx_003Eb__218_2(GameObject middleIconSfx)
		{
			if ((Object)(object)middleIconSfx == (Object)null)
			{
				ILRuntimeDebug.LogError("UI_InstanceZonesPanel.PlayReceiveSfx, middleIconSfx is null");
			}
			else
			{
				middleIconSfx.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
			}
		}

		internal global::_003C_003Ef__AnonymousType0<string, Soldier> _003CGetCurLegionCombat_003Eb__254_0(string sid)
		{
			return new
			{
				sid = sid,
				s = GameManagers.Instance.SoldierManager.Get(sid)
			};
		}

		internal int _003CGetCurLegionCombat_003Eb__254_1(global::_003C_003Ef__AnonymousType0<string, Soldier> t)
		{
			return t.s.CombatPower * Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(t.s.Id, t.s.Level);
		}

		internal Soldier _003CGetCurLegionCombat_003Eb__254_2(global::_003C_003Ef__AnonymousType0<string, Soldier> t)
		{
			return t.s;
		}

		internal void _003CRenderMissionList_003Eb__258_0(GameObject smoke96Comb)
		{
			smoke96Comb.AddComponent<HotFix_DestroySelf>().destroyTime = 1.2f;
		}

		internal void _003CRenderMissionList_003Eb__258_2(GameObject workplaceSmoke2)
		{
			workplaceSmoke2.AddComponent<HotFix_DestroySelf>().destroyTime = 1.2f;
		}
	}

	public Controller PageController;

	public GGraph blackMask;

	public GLoader background;

	public UI_Title Title;

	public GTextField replenishTime;

	public GButton backBtn;

	public UI_Com_NeutralMain NeutralDungeonPanel;

	public UI_workerButton addWorkerBtn;

	public GImage bottomBack;

	public GImage n48;

	public GImage n178;

	public GImage n179;

	public GGraph n180;

	public GGroup leftBackGroup;

	public GImage n53;

	public GImage n177;

	public GGroup rightBackGroup;

	public GImage n130;

	public GImage n131;

	public GImage n132;

	public GImage n133;

	public GImage n134;

	public GImage n135;

	public GImage n136;

	public GImage n137;

	public GImage n138;

	public GGroup rightBackGroup2;

	public GGraph baseSpine;

	public GGraph AnimaPlaceholder;

	public GGraph maskSpine;

	public GGroup soldierModelGroup;

	public GImage n51;

	public GTextField activityTitle;

	public GTextField activityDescription;

	public GTextField activityTime;

	public GList activityRewardList;

	public GLoader bigprizeIcon;

	public GGroup ContentGroup;

	public GImage n74;

	public GGraph DefensiveRightBtn;

	public GTextField tip;

	public GGroup DefensiveRightBack;

	public GLoader MapIcon;

	public GList missionList;

	public UI_ProgressBar1 integralProgressBackBar;

	public GList integralNodeList1;

	public UI_integralNodeList integralNodeList;

	public GGroup integralGroup;

	public GButton PageTurningLeftBtn;

	public UI_ReceiveBtn ReceiveBtn;

	public GButton PageTurningRightBtn;

	public GImage n181;

	public GTextField difficultyLevel;

	public GImage n184;

	public UI_DefensiveLeftBack DefensiveLeftBack;

	public GList DefensiveMissionList;

	public UI_RefreshCardBtn RefreshCardBtn;

	public UI_OffensiveCardPool OffensiveCardPool;

	public GGraph point00;

	public GGraph point01;

	public GGraph point02;

	public GGraph point03;

	public GGraph point04;

	public GGraph point05;

	public GGroup ponits0;

	public GGraph point30;

	public GGraph point31;

	public GGraph point32;

	public GGraph point33;

	public GGraph point34;

	public GGraph point35;

	public GGraph point36;

	public GGraph point37;

	public GGraph point38;

	public GGraph point39;

	public GGraph point310;

	public GGraph point311;

	public GGroup points3;

	public GGraph point40;

	public GGraph point41;

	public GGraph point42;

	public GGraph point43;

	public GGraph point44;

	public GGraph point45;

	public GGroup ponits4;

	public UI_MapEntrance MapEntrance;

	public UI_LevelCardPanel LevelCardPanel;

	public UI_QuickBattlePanelBack QuickBattlePanelBack;

	public GGraph missibleSfxBack;

	public GGraph missbleEndPos;

	public GGraph Mask;

	public GImage n182;

	public GTextField curIntegral;

	public GTextField textSeparator;

	public GTextField maxIntegral;

	public GGroup n188;

	public GGroup Integral;

	public Transition showTip;

	public const string URL = "ui://f4wr270rmm8n0";

	public static string Name = "UI_InstanceZonesPanel";

	private UI_RefreshCardPopup RefreshCardPopup;

	private static object _refreshCardPopupLocker = new object();

	public List<GLoader> AddOnClickGloader = new List<GLoader>();

	private GameStateEntity _gameStateEntity;

	private List<string> textureList = new List<string>();

	private string description;

	private string time;

	private string _soldierId;

	private int _soldierEvo;

	private string titleIcon;

	private string itemIcon;

	private GameObject portalSfx;

	private GameObject titleBonusSpine;

	private List<GButton> integralButtonList = new List<GButton>();

	public Activity curActivity;

	private List<string> _BonusExhibition = new List<string>();

	private int curCombat;

	private float unClaimed;

	private float noClaimed;

	private float widthRatio;

	private float nextNodeScore;

	private GComponent curNode;

	private GComponent nextNode;

	private int curBonusPage = 1;

	private int TotalBonusesPage = 1;

	private int initBonusPage = 1;

	private bool inMotion;

	private GTweener integralMoveGTweener;

	private int Type;

	private List<Level> levels = new List<Level>();

	private List<GButton> offensiveCardsPool = new List<GButton>();

	private List<GButton> offensiveCards = new List<GButton>();

	private List<Vector2> newList = new List<Vector2>();

	private List<UI_LevelBtn> TimeLimitLevelBtns = new List<UI_LevelBtn>();

	private List<UI_Btn_NeutralLevelBtn> NeutralDungeonLevelBtns = new List<UI_Btn_NeutralLevelBtn>();

	private List<KeyValuePair<int, Vector2>> TimeLimitLevelPoisitions = new List<KeyValuePair<int, Vector2>>();

	private UI_ClearStagesTipPanel ClearStagesTipPanel;

	private int curSelectedTimeLimitLevelIndex;

	private int curSelectedNeutralDungeonLevelIndex;

	private Coroutine TimeLimitRemainingCoroutine;

	private float GetScore;

	private double scoreBarValue;

	private string CompletedLevelId;

	private List<GComponent> canReceiveNodes = new List<GComponent>();

	private const int timeLimitInstanceLevelCounts = 6;

	private const int springFestivalInstanceLevelCounts = 12;

	private const int commonLevelBtnBonusCounts = 2;

	private const int advancedLevelBtnBonusCounts = 3;

	private const int neutralLevelBtnBonusCounts = 1;

	private string curActivityFormationId;

	private bool CurFormationIdReading;

	private List<string> quickBattleSwitch = new List<string>();

	private const int boxDisplayNum = 4;

	public UI_ProductionNumFloating NumFloating;

	private InstanceZonesType instanceZonesType;

	private List<tKeyValue<string, string>> curOffensiveLevelBonuses = new List<tKeyValue<string, string>>();

	private IUiController parentUiController;

	private Dictionary<string, object> parametersTemp;

	private bool _rendering_NeutralDungeonLevelBtns = false;

	private Dictionary<int, int> refreshTicketUnix = new Dictionary<int, int>();

	private int nextrefreshTicketHour;

	private Coroutine UpdateReplenishTimeCoroutine;

	public void SetControllerPageText()
	{
		if (PageController.selectedIndex == 0 || PageController.selectedIndex == 4)
		{
			string id = string.Format("{0}-{1}-{2}", "ui://f4wr270rmm8n0".Replace("ui://", ""), ((GObject)difficultyLevel).id, PageController.selectedIndex);
			((GObject)difficultyLevel).text = LanguagesManager.GetDesc(id);
		}
	}

	public static string GetURL()
	{
		return "ui://f4wr270rmm8n0";
	}

	public static UI_InstanceZonesPanel CreateInstance()
	{
		return (UI_InstanceZonesPanel)(object)UIPackage.CreateObject("InstanceZones", "InstanceZonesPanel");
	}

	public static UI_InstanceZonesPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_InstanceZonesPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rmm8n0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected O, but got Unknown
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Expected O, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected O, but got Unknown
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected O, but got Unknown
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Expected O, but got Unknown
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Expected O, but got Unknown
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Expected O, but got Unknown
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0457: Expected O, but got Unknown
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_046d: Expected O, but got Unknown
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Expected O, but got Unknown
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Expected O, but got Unknown
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04db: Expected O, but got Unknown
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Expected O, but got Unknown
		//IL_0513: Unknown result type (might be due to invalid IL or missing references)
		//IL_051d: Expected O, but got Unknown
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Expected O, but got Unknown
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Expected O, but got Unknown
		//IL_0592: Unknown result type (might be due to invalid IL or missing references)
		//IL_059c: Expected O, but got Unknown
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c8: Expected O, but got Unknown
		//IL_0600: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Expected O, but got Unknown
		//IL_0616: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Expected O, but got Unknown
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0636: Expected O, but got Unknown
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Expected O, but got Unknown
		//IL_0658: Unknown result type (might be due to invalid IL or missing references)
		//IL_0662: Expected O, but got Unknown
		//IL_066e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0678: Expected O, but got Unknown
		//IL_0684: Unknown result type (might be due to invalid IL or missing references)
		//IL_068e: Expected O, but got Unknown
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a4: Expected O, but got Unknown
		//IL_06b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ba: Expected O, but got Unknown
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d0: Expected O, but got Unknown
		//IL_06dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e6: Expected O, but got Unknown
		//IL_06f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fc: Expected O, but got Unknown
		//IL_0708: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Expected O, but got Unknown
		//IL_071e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0728: Expected O, but got Unknown
		//IL_0734: Unknown result type (might be due to invalid IL or missing references)
		//IL_073e: Expected O, but got Unknown
		//IL_074a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0754: Expected O, but got Unknown
		//IL_0760: Unknown result type (might be due to invalid IL or missing references)
		//IL_076a: Expected O, but got Unknown
		//IL_0776: Unknown result type (might be due to invalid IL or missing references)
		//IL_0780: Expected O, but got Unknown
		//IL_078c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0796: Expected O, but got Unknown
		//IL_07a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ac: Expected O, but got Unknown
		//IL_07b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c2: Expected O, but got Unknown
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d8: Expected O, but got Unknown
		//IL_07e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ee: Expected O, but got Unknown
		//IL_07fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0804: Expected O, but got Unknown
		//IL_0810: Unknown result type (might be due to invalid IL or missing references)
		//IL_081a: Expected O, but got Unknown
		//IL_0826: Unknown result type (might be due to invalid IL or missing references)
		//IL_0830: Expected O, but got Unknown
		//IL_083c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0846: Expected O, but got Unknown
		//IL_0894: Unknown result type (might be due to invalid IL or missing references)
		//IL_089e: Expected O, but got Unknown
		//IL_08aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b4: Expected O, but got Unknown
		//IL_08c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ca: Expected O, but got Unknown
		//IL_08d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e0: Expected O, but got Unknown
		//IL_08ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f6: Expected O, but got Unknown
		//IL_0902: Unknown result type (might be due to invalid IL or missing references)
		//IL_090c: Expected O, but got Unknown
		//IL_0918: Unknown result type (might be due to invalid IL or missing references)
		//IL_0922: Expected O, but got Unknown
		//IL_092e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0938: Expected O, but got Unknown
		//IL_0944: Unknown result type (might be due to invalid IL or missing references)
		//IL_094e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		blackMask = (GGraph)((GComponent)this).GetChild("blackMask");
		background = (GLoader)((GComponent)this).GetChild("background");
		Title = (UI_Title)(object)((GComponent)this).GetChild("Title");
		replenishTime = (GTextField)((GComponent)this).GetChild("replenishTime");
		string id = "ui://f4wr270rmm8n0".Replace("ui://", "") + "-" + ((GObject)replenishTime).id;
		((GObject)replenishTime).text = LanguagesManager.GetDesc(id);
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		NeutralDungeonPanel = (UI_Com_NeutralMain)(object)((GComponent)this).GetChild("NeutralDungeonPanel");
		addWorkerBtn = (UI_workerButton)(object)((GComponent)this).GetChild("addWorkerBtn");
		bottomBack = (GImage)((GComponent)this).GetChild("bottomBack");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n178 = (GImage)((GComponent)this).GetChild("n178");
		n179 = (GImage)((GComponent)this).GetChild("n179");
		n180 = (GGraph)((GComponent)this).GetChild("n180");
		leftBackGroup = (GGroup)((GComponent)this).GetChild("leftBackGroup");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n177 = (GImage)((GComponent)this).GetChild("n177");
		rightBackGroup = (GGroup)((GComponent)this).GetChild("rightBackGroup");
		n130 = (GImage)((GComponent)this).GetChild("n130");
		n131 = (GImage)((GComponent)this).GetChild("n131");
		n132 = (GImage)((GComponent)this).GetChild("n132");
		n133 = (GImage)((GComponent)this).GetChild("n133");
		n134 = (GImage)((GComponent)this).GetChild("n134");
		n135 = (GImage)((GComponent)this).GetChild("n135");
		n136 = (GImage)((GComponent)this).GetChild("n136");
		n137 = (GImage)((GComponent)this).GetChild("n137");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		rightBackGroup2 = (GGroup)((GComponent)this).GetChild("rightBackGroup2");
		baseSpine = (GGraph)((GComponent)this).GetChild("baseSpine");
		AnimaPlaceholder = (GGraph)((GComponent)this).GetChild("AnimaPlaceholder");
		maskSpine = (GGraph)((GComponent)this).GetChild("maskSpine");
		soldierModelGroup = (GGroup)((GComponent)this).GetChild("soldierModelGroup");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		activityTitle = (GTextField)((GComponent)this).GetChild("activityTitle");
		string id2 = "ui://f4wr270rmm8n0".Replace("ui://", "") + "-" + ((GObject)activityTitle).id;
		((GObject)activityTitle).text = LanguagesManager.GetDesc(id2);
		activityDescription = (GTextField)((GComponent)this).GetChild("activityDescription");
		activityTime = (GTextField)((GComponent)this).GetChild("activityTime");
		activityRewardList = (GList)((GComponent)this).GetChild("activityRewardList");
		bigprizeIcon = (GLoader)((GComponent)this).GetChild("bigprizeIcon");
		ContentGroup = (GGroup)((GComponent)this).GetChild("ContentGroup");
		n74 = (GImage)((GComponent)this).GetChild("n74");
		DefensiveRightBtn = (GGraph)((GComponent)this).GetChild("DefensiveRightBtn");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id3 = "ui://f4wr270rmm8n0".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id3);
		DefensiveRightBack = (GGroup)((GComponent)this).GetChild("DefensiveRightBack");
		MapIcon = (GLoader)((GComponent)this).GetChild("MapIcon");
		missionList = (GList)((GComponent)this).GetChild("missionList");
		integralProgressBackBar = (UI_ProgressBar1)(object)((GComponent)this).GetChild("integralProgressBackBar");
		integralNodeList1 = (GList)((GComponent)this).GetChild("integralNodeList1");
		integralNodeList = (UI_integralNodeList)(object)((GComponent)this).GetChild("integralNodeList");
		integralGroup = (GGroup)((GComponent)this).GetChild("integralGroup");
		PageTurningLeftBtn = (GButton)((GComponent)this).GetChild("PageTurningLeftBtn");
		ReceiveBtn = (UI_ReceiveBtn)(object)((GComponent)this).GetChild("ReceiveBtn");
		PageTurningRightBtn = (GButton)((GComponent)this).GetChild("PageTurningRightBtn");
		n181 = (GImage)((GComponent)this).GetChild("n181");
		difficultyLevel = (GTextField)((GComponent)this).GetChild("difficultyLevel");
		string id4 = "ui://f4wr270rmm8n0".Replace("ui://", "") + "-" + ((GObject)difficultyLevel).id;
		((GObject)difficultyLevel).text = LanguagesManager.GetDesc(id4);
		n184 = (GImage)((GComponent)this).GetChild("n184");
		DefensiveLeftBack = (UI_DefensiveLeftBack)(object)((GComponent)this).GetChild("DefensiveLeftBack");
		DefensiveMissionList = (GList)((GComponent)this).GetChild("DefensiveMissionList");
		RefreshCardBtn = (UI_RefreshCardBtn)(object)((GComponent)this).GetChild("RefreshCardBtn");
		OffensiveCardPool = (UI_OffensiveCardPool)(object)((GComponent)this).GetChild("OffensiveCardPool");
		point00 = (GGraph)((GComponent)this).GetChild("point00");
		point01 = (GGraph)((GComponent)this).GetChild("point01");
		point02 = (GGraph)((GComponent)this).GetChild("point02");
		point03 = (GGraph)((GComponent)this).GetChild("point03");
		point04 = (GGraph)((GComponent)this).GetChild("point04");
		point05 = (GGraph)((GComponent)this).GetChild("point05");
		ponits0 = (GGroup)((GComponent)this).GetChild("ponits0");
		point30 = (GGraph)((GComponent)this).GetChild("point30");
		point31 = (GGraph)((GComponent)this).GetChild("point31");
		point32 = (GGraph)((GComponent)this).GetChild("point32");
		point33 = (GGraph)((GComponent)this).GetChild("point33");
		point34 = (GGraph)((GComponent)this).GetChild("point34");
		point35 = (GGraph)((GComponent)this).GetChild("point35");
		point36 = (GGraph)((GComponent)this).GetChild("point36");
		point37 = (GGraph)((GComponent)this).GetChild("point37");
		point38 = (GGraph)((GComponent)this).GetChild("point38");
		point39 = (GGraph)((GComponent)this).GetChild("point39");
		point310 = (GGraph)((GComponent)this).GetChild("point310");
		point311 = (GGraph)((GComponent)this).GetChild("point311");
		points3 = (GGroup)((GComponent)this).GetChild("points3");
		point40 = (GGraph)((GComponent)this).GetChild("point40");
		point41 = (GGraph)((GComponent)this).GetChild("point41");
		point42 = (GGraph)((GComponent)this).GetChild("point42");
		point43 = (GGraph)((GComponent)this).GetChild("point43");
		point44 = (GGraph)((GComponent)this).GetChild("point44");
		point45 = (GGraph)((GComponent)this).GetChild("point45");
		ponits4 = (GGroup)((GComponent)this).GetChild("ponits4");
		MapEntrance = (UI_MapEntrance)(object)((GComponent)this).GetChild("MapEntrance");
		LevelCardPanel = (UI_LevelCardPanel)(object)((GComponent)this).GetChild("LevelCardPanel");
		QuickBattlePanelBack = (UI_QuickBattlePanelBack)(object)((GComponent)this).GetChild("QuickBattlePanelBack");
		missibleSfxBack = (GGraph)((GComponent)this).GetChild("missibleSfxBack");
		missbleEndPos = (GGraph)((GComponent)this).GetChild("missbleEndPos");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		n182 = (GImage)((GComponent)this).GetChild("n182");
		curIntegral = (GTextField)((GComponent)this).GetChild("curIntegral");
		textSeparator = (GTextField)((GComponent)this).GetChild("textSeparator");
		maxIntegral = (GTextField)((GComponent)this).GetChild("maxIntegral");
		n188 = (GGroup)((GComponent)this).GetChild("n188");
		Integral = (GGroup)((GComponent)this).GetChild("Integral");
		showTip = ((GComponent)this).GetTransition("showTip");
	}

	private void ShowRefreshCardPopup()
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected O, but got Unknown
		lock (_refreshCardPopupLocker)
		{
			if (RefreshCardPopup == null)
			{
				RefreshCardPopup = UI_RefreshCardPopup.CreateInstance();
			}
		}
		((GComponent)this).AddChild((GObject)(object)RefreshCardPopup);
		FGUIManager.SetToFullScreen((GObject)(object)RefreshCardPopup);
		((GObject)RefreshCardPopup).SetXY(0f, 0f);
		((GObject)RefreshCardPopup).sortingOrder = 1;
		((GObject)RefreshCardPopup.ConfirmDialog.RefreshCardBtn).onClick.Set(new EventCallback0(GetNewOffensiveCards));
		((GObject)RefreshCardPopup.ConfirmDialog.exitBtn).onClick.Set(new EventCallback0(CloseRefreshCardPopup));
		if (curActivity.ResetCost.Count > 0)
		{
			Dictionary<string, int> resetCostConfig;
			bool flag = curActivity.CanReset(GameManagers.Instance, null, out resetCostConfig);
			int num = 0;
			string itemId = "";
			if (flag)
			{
				((GObject)RefreshCardPopup.ConfirmDialog.RefreshCardBtn).enabled = true;
				KeyValuePair<string, int> keyValuePair = Enumerable.First(resetCostConfig);
				itemId = keyValuePair.Key;
				num = keyValuePair.Value;
			}
			else
			{
				((GObject)RefreshCardPopup.ConfirmDialog.RefreshCardBtn).enabled = false;
				Dictionary<string, int> dictionary = curActivity.ResetCost.First();
				itemId = dictionary.Keys.First();
				num = dictionary.Values.First();
			}
			FGUIManager.Instance.SetItemIconAndFrame(((GComponent)RefreshCardPopup.ConfirmDialog.DialogMiddleContent.ConsumptionItem).GetChild("icon").asLoader, itemId, textureList);
			GComponent asCom = ((GComponent)RefreshCardPopup.ConfirmDialog.DialogMiddleContent.ConsumptionItem).GetChild("reqDesc").asCom;
			int stock = GameManagers.Instance.StockController.GetStock(itemId);
			string text = ((stock < num) ? "#DC143C" : "#F6E2B2");
			string text2 = "#F6E2B2";
			GComponent asCom2 = asCom.GetChild("originPrice").asCom;
			((GObject)asCom2).SetSize(0f, 0f);
			((GObject)asCom2).visible = false;
			if (stock < num)
			{
				((GObject)RefreshCardPopup.ConfirmDialog.RefreshCardBtn).enabled = false;
			}
			else
			{
				((GObject)RefreshCardPopup.ConfirmDialog.RefreshCardBtn).enabled = true;
			}
			int number = stock;
			GTextField asTextField = asCom.GetChild("curPrice").asTextField;
			((GObject)asTextField).text = $"[color={text}]{number.ShortNumberFormat()}[/color][color={text2}]/{num}[/color]";
			((GObject)RefreshCardPopup.ConfirmDialog.DialogMiddleContent).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
		}
		else
		{
			((GObject)RefreshCardPopup.ConfirmDialog.RefreshCardBtn).enabled = false;
		}
		RefreshCardPopup.showTip.Play();
	}

	private void CloseRefreshCardPopup()
	{
		if (RefreshCardPopup != null)
		{
			((GComponent)this).RemoveChild((GObject)(object)RefreshCardPopup, false);
		}
	}

	public void Init(Dictionary<string, object> parameters)
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		AddOnClickGloader = new List<GLoader>();
		parametersTemp = parameters;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		((GObject)blackMask).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		if (parameters.TryGetValue("SortingOrder", out var value))
		{
			((GObject)this).sortingOrder = (int)value;
		}
		else
		{
			((GObject)this).sortingOrder = 1;
		}
		addWorkerBtn.num.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)153));
		parentUiController = null;
		if (parameters.TryGetValue("Parent", out var value2))
		{
			parentUiController = (IUiController)value2;
		}
		if (parameters.TryGetValue("Activity", out var value3))
		{
			Activity activity = value3 as Activity;
			if (activity != null)
			{
				curActivity = activity;
				((GObject)ContentGroup).visible = false;
				((GObject)MapIcon).visible = false;
				List<string> checkingActivities = new List<string> { activity.ActivityId };
				if (activity.Type == ActivityType.HomePageActivity)
				{
					IUiService uiService = Contexts.sharedInstance.Service<IUiService>();
					int changeId = uiService.SetUiNotTouchable(Name);
					uiService.ShowWaitingAnimation(show: true);
					((GObject)this).alpha = 0f;
					GameManagers.Instance.ActivityManager.CheckActivities(checkingActivities, null, delegate
					{
						if (activity.ActivityProgress(GameManagers.Instance).IsNew)
						{
							GameManagers.Instance.ActivityManager.ReviewActivities(checkingActivities);
						}
						UpdateMainPanel(parameters);
						uiService.ShowWaitingAnimation(show: false);
						uiService.SetUiTouchable(changeId);
					});
					((GObject)this).alpha = 1f;
				}
				else
				{
					if (activity.ActivityProgress(GameManagers.Instance).IsNew)
					{
						GameManagers.Instance.ActivityManager.ReviewActivities(checkingActivities);
					}
					UpdateMainPanel(parameters);
				}
				return;
			}
		}
		Debug.LogError((object)"副本没有指定对应的活动");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		_gameStateEntity = ((Context<GameStateEntity>)GameController.Contexts.gameState).CreateEntity();
		_gameStateEntity.AddAnyLoadingPanelStatusListener(this);
		((GObject)backBtn).onClick.Add(new EventCallback0(GoBack));
		((GObject)addWorkerBtn.addButton).onClick.Add(new EventCallback0(WorkerAddClick));
		((GComponent)integralNodeList).scrollPane.onScroll.Add(new EventCallback0(UpdateBar));
		((GObject)RefreshCardBtn).onClick.Add(new EventCallback0(ShowRefreshCardPopup));
		((GObject)DefensiveRightBtn).onClick.Add(new EventCallback0(SetOffensiveMainInfo));
		((GObject)ReceiveBtn).onClick.Add(new EventCallback0(ReceiveIntegralBonuses));
		((GObject)PageTurningLeftBtn).data = -1;
		((GObject)PageTurningRightBtn).data = 1;
		((GObject)PageTurningLeftBtn).onClick.Add(new EventCallback1(PageTurning));
		((GObject)PageTurningRightBtn).onClick.Add(new EventCallback1(PageTurning));
		((GObject)LevelCardPanel.Mask).onClick.Add(new EventCallback0(CloseLevelCard));
		((GObject)NeutralDungeonPanel.LevelCardPanel.Mask).onClick.Add(new EventCallback0(CloseNeutralDungeonLevelCard));
		Timers.inst.Add(1f, 0, new TimerCallback(UpdateInstancezonesRemainingTime), (object)null);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<string>("CLOSE_UI", OnBackToInstanceZonesPanel);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		_gameStateEntity.RemoveAnyLoadingPanelStatusListener(this);
		((GObject)backBtn).onClick.Remove(new EventCallback0(GoBack));
		((GObject)addWorkerBtn.addButton).onClick.Remove(new EventCallback0(WorkerAddClick));
		((GComponent)integralNodeList).scrollPane.onScroll.Remove(new EventCallback0(UpdateBar));
		((GObject)RefreshCardBtn).onClick.Remove(new EventCallback0(ShowRefreshCardPopup));
		((GObject)DefensiveRightBtn).onClick.Remove(new EventCallback0(SetOffensiveMainInfo));
		((GObject)ReceiveBtn).onClick.Remove(new EventCallback0(ReceiveIntegralBonuses));
		((GObject)PageTurningLeftBtn).onClick.Remove(new EventCallback1(PageTurning));
		((GObject)PageTurningRightBtn).onClick.Remove(new EventCallback1(PageTurning));
		((GObject)LevelCardPanel.Mask).onClick.Remove(new EventCallback0(CloseLevelCard));
		((GObject)NeutralDungeonPanel.LevelCardPanel.Mask).onClick.Remove(new EventCallback0(CloseNeutralDungeonLevelCard));
		Timers.inst.Remove(new TimerCallback(UpdateInstancezonesRemainingTime));
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnBackToInstanceZonesPanel);
	}

	public void OnShow()
	{
		if (curActivity.Type == ActivityType.TimeLimitInstance)
		{
			curActivity.ActivityProgress(GameManagers.Instance).IsNew = false;
			UIPanel component = ((Component)GameManagers.Instance.BuildingManager.GetBuildingByType("14").GameObject.transform.Find("Decoration/Icon")).gameObject.GetComponent<UIPanel>();
			component.ui.GetChild("newIcon").visible = false;
			if (GetScore > 0f)
			{
				PlayGetScore();
			}
		}
		foreach (Activity item in GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.AttackInstance))
		{
			foreach (KeyValuePair<string, ActivityContentPayload> item2 in item.ContentPayload(GameManagers.Instance))
			{
				GameManagers.Instance.NewMsgIncomingManager.CheckActivityContent(item.ActivityId, item2.Key);
			}
		}
		foreach (Activity item3 in GameManagers.Instance.ActivityManager.GetActivitiesByType(ActivityType.DefenseInstance))
		{
			foreach (KeyValuePair<string, ActivityContentPayload> item4 in item3.ContentPayload(GameManagers.Instance))
			{
				GameManagers.Instance.NewMsgIncomingManager.CheckActivityContent(item3.ActivityId, item4.Key);
			}
		}
		UpdateBar();
		ShowOffensiveCardsInTurn();
		if (TimeLimitRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(TimeLimitRemainingCoroutine);
		}
		TimeLimitRemainingCoroutine = FGUIManager.Instance.OpenIEnumerator(RefreshTimeLimitLevelStatus());
	}

	public void BeforeDestroy()
	{
		if (TimeLimitRemainingCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(TimeLimitRemainingCoroutine);
		}
		if (UpdateReplenishTimeCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(UpdateReplenishTimeCoroutine);
		}
	}

	public void Destroy()
	{
		TimeLimitLevelPoisitions.Clear();
		NeutralDungeonLevelBtns.Clear();
		TimeLimitLevelBtns.Clear();
		newList.Clear();
		canReceiveNodes.Clear();
		offensiveCards.Clear();
		offensiveCardsPool.Clone<GButton>();
		integralButtonList.Clear();
		foreach (GLoader item in AddOnClickGloader)
		{
			((GObject)item).onClick.Clear();
		}
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("DungeonInstancePanel.FirstLevelEntrance");
		instance.Unregister("DungeonInstancePanel.FirstLevelMassButton");
		instance.Unregister("DungeonInstancePanel.LevelEntrance");
		instance.Unregister("DungeonInstancePanel.LevelMassButton");
		instance.Unregister("DungeonInstancePanel.ScoreBonusBar");
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
	}

	private void GetCurLevelFormationId(string levelId)
	{
		if (!string.IsNullOrWhiteSpace(curActivityFormationId) || CurFormationIdReading)
		{
			return;
		}
		CurFormationIdReading = true;
		ILRequestHelper<GetFormationInfoResponse>.Request((EventContext)null, (Func<Task<GetFormationInfoResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetFormationInfo(-1L, levelId)), (Action<GetFormationInfoResponse>)delegate(GetFormationInfoResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				CurFormationIdReading = false;
				curActivityFormationId = response.FormationId;
			}
		});
	}

	private void GetTimeLimitLevelPoisitions()
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		TimeLimitLevelPoisitions.Clear();
		int num = 6;
		if (PageController.selectedIndex == 3)
		{
			num = 12;
		}
		for (int i = 0; i < num; i++)
		{
			int key = ((((GComponent)this).GetChild($"point{PageController.selectedIndex}{i}").data != null) ? Convert.ToInt32(((GComponent)this).GetChild($"point{PageController.selectedIndex}{i}").data) : 0);
			TimeLimitLevelPoisitions.Add(new KeyValuePair<int, Vector2>(key, ((GComponent)this).GetChild($"point{PageController.selectedIndex}{i}").xy));
		}
	}

	private void UpdateMainPanel(Dictionary<string, object> parameters)
	{
		if (!((GObject)this).isDisposed)
		{
			GetData(parameters);
			UpdateTicketsNum();
			SetText();
			SetBuildingName();
		}
	}

	private void SetBuildingName()
	{
		if (instanceZonesType == InstanceZonesType.Common || instanceZonesType == InstanceZonesType.Advanced)
		{
			((GObject)Title.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText265");
		}
		else if (instanceZonesType == InstanceZonesType.Defensive)
		{
			((GObject)Title.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText266");
		}
		else if (instanceZonesType == InstanceZonesType.Offensive)
		{
			((GObject)Title.buildingName).text = LanguagesManager.GetDesc("CsharpCodeZhTcText267");
		}
		else if (instanceZonesType == InstanceZonesType.NeutralDungeon)
		{
			((GObject)Title.buildingName).text = LanguagesManager.GetDesc("NeutralDungeon_Title_PlaceHolder");
		}
		else
		{
			((GObject)Title.buildingName).text = curActivity.Name ?? "";
		}
	}

	private void LoadTitleBonus()
	{
		if (!string.IsNullOrWhiteSpace(titleIcon))
		{
			bigprizeIcon.url = "ui://PublicResources/" + titleIcon;
		}
		else if (!string.IsNullOrWhiteSpace(_soldierId))
		{
			LoadAnima();
		}
		else if (!string.IsNullOrWhiteSpace(itemIcon))
		{
			bigprizeIcon.url = "ui://PublicResources/" + UiHelper.GetIconPath(itemIcon);
		}
	}

	private void RenderActivityRewardListFirst(GButton buton)
	{
		if (!string.IsNullOrWhiteSpace(titleIcon))
		{
			AssetsManager.Instance.LoadAsset<Texture2D>(titleIcon).Then((Action<Texture2D>)delegate(Texture2D asset)
			{
				//IL_0017: Unknown result type (might be due to invalid IL or missing references)
				//IL_0021: Expected O, but got Unknown
				((GComponent)buton).GetChild("icon").asLoader.texture = new NTexture((Texture)(object)asset);
				textureList.Add(titleIcon);
			});
			((GObject)((GComponent)buton).GetChild("title").asRichTextField).text = titleIcon;
		}
		else if (!string.IsNullOrWhiteSpace(_soldierId))
		{
			AssetsManager.Instance.LoadAsset<Texture2D>(UiHelper.GetIconPath(_soldierId, _soldierEvo)).Then((Action<Texture2D>)delegate(Texture2D asset)
			{
				//IL_0017: Unknown result type (might be due to invalid IL or missing references)
				//IL_0021: Expected O, but got Unknown
				((GComponent)buton).GetChild("icon").asLoader.texture = new NTexture((Texture)(object)asset);
				textureList.Add(UiHelper.GetIconPath(_soldierId, _soldierEvo));
			});
			Soldier soldier = GameManagers.Instance.SoldierManager.Get(_soldierId);
			((GObject)((GComponent)buton).GetChild("title").asRichTextField).text = soldier.Name;
		}
		else if (!string.IsNullOrWhiteSpace(itemIcon))
		{
			string itemId = itemIcon;
			AssetsManager.Instance.LoadAsset<Texture2D>(UiHelper.GetIcon(itemId)).Then((Action<Texture2D>)delegate(Texture2D asset)
			{
				//IL_001c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0026: Expected O, but got Unknown
				((GComponent)buton).GetChild("icon").asLoader.texture = new NTexture((Texture)(object)asset);
				textureList.Add(UiHelper.GetIcon(itemId));
			});
			((GObject)((GComponent)buton).GetChild("title").asRichTextField).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, itemId);
			if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
			{
				((GComponent)buton).GetChild("chipNote").visible = true;
			}
		}
	}

	private void ResolveTitleBonus(string titleBonus)
	{
		if (titleBonus.Contains(":"))
		{
			string[] array = titleBonus.Split(':');
			if (array[0] == "Sprite")
			{
				titleIcon = array[1];
				((GObject)soldierModelGroup).visible = false;
			}
			else if (array[0] == "GameObject")
			{
				_soldierId = array[1];
				if (array.Length > 2)
				{
					_soldierEvo = int.Parse(array[2]);
				}
				else
				{
					_soldierEvo = 1;
				}
				((GObject)soldierModelGroup).visible = true;
			}
		}
		else
		{
			itemIcon = titleBonus;
			((GObject)soldierModelGroup).visible = false;
		}
	}

	private void UpdateInstancezonesRemainingTime(object parameter)
	{
		if (curActivity == null || curActivity.Period == ActivityPeriod.Permanent)
		{
			return;
		}
		if (Type == 1 || Type == 2)
		{
			if (curActivity != null)
			{
				((GObject)DefensiveLeftBack.DefensiveRemainingTime).text = UiHelper.ParseTimeChinsesDH(Convert.ToInt32(curActivity.CurRemainingTime(DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime())).TotalSeconds)) + LanguagesManager.GetDesc("CsharpCodeZhTcText281");
			}
		}
		else
		{
			if (Type != 5)
			{
				return;
			}
			NeutralDungeonData neutralDungeonData = FGUIManager.Instance.NeutralDungeonData;
			if (neutralDungeonData.Activity.GetStatus(GameManagers.Instance) != ActivityStatus.Enabled)
			{
				return;
			}
			DateTimeOffset serverNow = DateTimeHelper.ServerNow;
			if (neutralDungeonData.TimeGoingOn() > 0)
			{
				int num = (int)(FGUIManager.Instance.NeutralDungeonData.CurEndTime - serverNow).TotalSeconds;
				int num2 = 1800;
				num += num2;
				bool flag = false;
				if (num > 86400)
				{
					num %= 86400;
					flag = true;
				}
				else
				{
					num -= num2;
				}
				if (flag)
				{
					((GObject)NeutralDungeonPanel.CdTimer).text = UiHelper.ParseTimeChinsesDH(num) + LanguagesManager.GetDesc("CsharpCodeZhTcText281");
				}
				else
				{
					((GObject)NeutralDungeonPanel.CdTimer).text = UiHelper.ParseTimeChinsesDH(num) + LanguagesManager.GetDesc("CsharpCodeZhTcText559");
				}
			}
		}
	}

	private string GetLevelDifficulty(int difficulty)
	{
		string result = "";
		switch (difficulty)
		{
		case 1:
			result = LanguagesManager.GetDesc("CsharpCodeZhTcText268");
			break;
		case 2:
			result = LanguagesManager.GetDesc("CsharpCodeZhTcText269");
			break;
		case 3:
			result = LanguagesManager.GetDesc("CsharpCodeZhTcText270");
			break;
		case 4:
			result = LanguagesManager.GetDesc("CsharpCodeZhTcText271");
			break;
		case 5:
			result = LanguagesManager.GetDesc("CsharpCodeZhTcText272");
			break;
		}
		return result;
	}

	private void ReplaceCards()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				"[color=#FFFF66]" + LanguagesManager.GetDesc("CsharpCodeZhTcText282") + "[/color]"
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{ "Confirm", GetNewOffensiveCards },
					{ "Cancel", null }
				}
			},
			{ "PageIndex", 1 },
			{
				"Title",
				LanguagesManager.GetDesc("CsharpCodeZhTcText273")
			},
			{ "FontSize", 34 },
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	private void GetNewOffensiveCards()
	{
		CloseRefreshCardPopup();
		ILRequestHelper<ActivityResetResponse>.Request((EventContext)null, (Func<Task<ActivityResetResponse>>)(() => GameController.Contexts.Service<INetworkService>().ActivityReset(curActivity.ActivityId)), (Action<ActivityResetResponse>)delegate(ActivityResetResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else if (response.ActivityConfig == null || response.ActivityConfig.ActivityId != curActivity.ActivityId)
			{
				ILRequestHelper.ShowErrorCode(82000007);
			}
			else if (!curActivity.Reset(GameManagers.Instance, null, autoReset: false, response.ActivityConfig))
			{
				ILRequestHelper.ShowErrorCode(82000006);
			}
			else
			{
				SetNewOffensiveCards(isInit: true);
				ShowOffensiveCardsInTurn();
				GameManagers.Instance.ActivityManager.UpdateLevelActivityCache(curActivity.ActivityId);
			}
		});
	}

	private void ShowOffensiveCardsInTurn()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		float num = 0.2f;
		for (int i = 0; i < offensiveCards.Count; i++)
		{
			int index = i;
			GButton _btn = offensiveCards[index];
			GTweenCallback val = default(GTweenCallback);
			((GComponent)(object)this).SetTimeout(num).OnComplete((GTweenCallback)delegate
			{
				//IL_001d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0082: Unknown result type (might be due to invalid IL or missing references)
				//IL_0087: Unknown result type (might be due to invalid IL or missing references)
				//IL_0089: Expected O, but got Unknown
				//IL_008e: Expected O, but got Unknown
				((GObject)_btn).SetPivot(0.5f, 0.5f);
				((GObject)_btn).TweenScale(Vector2.one, 0.2f);
				((GObject)_btn).TweenFade(1f, 0.2f);
				if (((GComponent)_btn).GetController("Style").selectedIndex == 1)
				{
					GTweener obj = ((GComponent)(object)this).SetTimeout(0.2f);
					GTweenCallback obj2 = val;
					if (obj2 == null)
					{
						GTweenCallback val2 = delegate
						{
							//IL_003f: Unknown result type (might be due to invalid IL or missing references)
							FGUIManager.Instance.AddTextSpecialEffects(((GComponent)offensiveCards[index]).GetChild("SfxBack").asGraph, "sparkle_gold", new Vector3(120f, 120f, 120f), "Default", 0.5f, delegate(GameObject sparkleGold)
							{
								sparkleGold.AddComponent<HotFix_DestroySelf>().destroyTime = 0.8f;
							});
						};
						GTweenCallback val3 = val2;
						val = val2;
						obj2 = val3;
					}
					obj.OnComplete(obj2);
				}
			});
			num += 0.2f;
		}
	}

	private void SetNewOffensiveCards(bool isInit = false)
	{
		DefensiveLeftBack.PageController.selectedIndex = 1;
		levels.Clear();
		foreach (ActivityContentPayload value in curActivity.ContentPayload(GameManagers.Instance).Values)
		{
			if (value is ChapterActivityPayload chapterActivityPayload)
			{
				if (chapterActivityPayload.Chapter == null)
				{
					Debug.LogError((object)("活动" + curActivity.ActivityId + "没有配置章节" + chapterActivityPayload.ChapterId));
					return;
				}
				if (chapterActivityPayload.Levels(GameManagers.Instance).Count < 1)
				{
					Debug.LogError((object)("活动" + curActivity.ActivityId + "章节" + chapterActivityPayload.ChapterId + "没有配置关卡"));
					return;
				}
				levels.AddRange(chapterActivityPayload.Levels(GameManagers.Instance));
				int num = 0;
				if (isInit)
				{
					num = chapterActivityPayload.GetLevelPosOnUI(GameManagers.Instance);
					GameLocalDataManager.SetInt("LevelPosOnUI", num);
				}
				else if (GameLocalDataManager.HasKey("LevelPosOnUI"))
				{
					num = GameLocalDataManager.GetInt("LevelPosOnUI");
				}
				else
				{
					num = chapterActivityPayload.GetLevelPosOnUI(GameManagers.Instance);
					GameLocalDataManager.SetInt("LevelPosOnUI", num);
				}
				SetOffensiveCardsPos(num);
				ClearStagesProgressInit(chapterActivityPayload);
			}
		}
		for (int i = 0; i < levels.Count; i++)
		{
			GetCurLevelFormationId(levels[i].LevelId);
			ThinkingDataHelper.Instance.AttackRefreshTrack(levels[i].LevelId, levels[i].Difficult);
		}
		RenderOffensiveCardPool();
	}

	private void ClearStagesProgressInit(ChapterActivityPayload chapterActivityPayload)
	{
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		if (chapterActivityPayload.CaseConfig == null)
		{
			((GObject)DefensiveLeftBack.ClearStagesProgress).visible = false;
			return;
		}
		if (!chapterActivityPayload.CaseConfig.ContainsKey("ClearStages"))
		{
			((GObject)DefensiveLeftBack.ClearStagesProgress).visible = false;
			return;
		}
		List<float> list = chapterActivityPayload.CaseConfig["ClearStages"];
		int totalClearStagesByActivity = GameManagers.Instance.ChapterManager.GetTotalClearStagesByActivity(curActivity.ActivityId);
		((GProgressBar)DefensiveLeftBack.ClearStagesProgress).value = ((float)totalClearStagesByActivity - list[0]) / (list[1] - list[0]) * 100f;
		DefensiveLeftBack.ClearStagesProgress.Status.selectedIndex = chapterActivityPayload.ContentIndex;
		DefensiveLeftBack.ClearStagesProgress.logo.Status.selectedIndex = chapterActivityPayload.ContentIndex;
		DefensiveLeftBack.ClearStagesProgress.bar.Status.selectedIndex = chapterActivityPayload.ContentIndex;
		bool flag = totalClearStagesByActivity >= 3600;
		if ((float)totalClearStagesByActivity < list[1] + 1f)
		{
			DefensiveLeftBack.ClearStagesProgress.Type.selectedIndex = 0;
			((GObject)DefensiveLeftBack.ClearStagesProgress.curNum).text = $"{totalClearStagesByActivity}";
		}
		else
		{
			DefensiveLeftBack.ClearStagesProgress.Type.selectedIndex = 1;
			((GObject)DefensiveLeftBack.ClearStagesProgress.tip).text = (flag ? ConstStr.DEFENSIVE_LEVEL_MAX : ConstStr.DEFENSIVE_LEVEL_UP_TIP);
		}
		((GObject)DefensiveLeftBack.ClearStagesProgress.totalNum).text = $"{Convert.ToInt32(list[1]) + 1}";
		((GObject)DefensiveLeftBack.ClearStagesProgress).data = ((chapterActivityPayload.Tips != null) ? chapterActivityPayload.Tips.First() : "");
		((GObject)DefensiveLeftBack.ClearStagesProgress.logo).data = Convert.ToInt32(list[1]) + 1;
		((GObject)DefensiveLeftBack.ClearStagesProgress).onClick.Set(new EventCallback0(ShowClearStagesTip));
		((GObject)DefensiveLeftBack.ClearStagesProgress).touchable = !flag;
	}

	private void ShowClearStagesTip()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		string langKey = ((GObject)DefensiveLeftBack.ClearStagesProgress).data.ToString();
		int num = Convert.ToInt32(((GObject)DefensiveLeftBack.ClearStagesProgress.logo).data);
		ClearStagesTipPanel = UI_ClearStagesTipPanel.CreateInstance();
		((GObject)ClearStagesTipPanel.mask).onClick.Add(new EventCallback0(CloseClearStagesTip));
		((GObject)ClearStagesTipPanel.Dialog.num).text = $"{GameManagers.Instance.ChapterManager.GetTotalClearStagesByActivity(curActivity.ActivityId)}/{num}";
		((GObject)ClearStagesTipPanel.Dialog.tip).text = langKey.ToLanguage();
		((GComponent)GRoot.inst).AddChild((GObject)(object)ClearStagesTipPanel);
		((GObject)ClearStagesTipPanel).sortingOrder = ((GObject)this).sortingOrder;
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)ClearStagesTipPanel);
		ClearStagesTipPanel.ShowSelf.Play();
	}

	private void CloseClearStagesTip()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)ClearStagesTipPanel.mask).onClick.Remove(new EventCallback0(CloseClearStagesTip));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)ClearStagesTipPanel, true);
	}

	private void SetOffensiveCardsPos(int aimPos)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		List<Vector2> list = new List<Vector2>();
		for (int i = 0; i < 6; i++)
		{
			list.Add(((GComponent)OffensiveCardPool).GetChild($"point{i}").xy);
		}
		newList.Clear();
		int num = aimPos;
		num = ((num > 2) ? 2 : num);
		for (int j = 0; j < 5; j++)
		{
			newList.Add(((GComponent)OffensiveCardPool).GetChild($"point{num}{j}").xy);
		}
		for (int k = 0; k < newList.Count; k++)
		{
		}
	}

	private void OffensiveCardClickEvent(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		GComponent asCom = ((GObject)context.sender).asCom;
		for (int i = 0; i < offensiveCards.Count; i++)
		{
			((GComponent)offensiveCards[i]).GetController("Selected").selectedIndex = 0;
		}
		asCom.GetController("Selected").selectedIndex = 1;
		DefensiveLeftBack.PageController.selectedIndex = 2;
		object data = ((GObject)context.sender).data;
		int levelIndex = (int)data;
		RenderOffensiveCardDetails(levelIndex);
	}

	private void RenderOffensiveCardPool()
	{
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < offensiveCards.Count; i++)
		{
			((GComponent)OffensiveCardPool).RemoveChild((GObject)(object)offensiveCards[i]);
		}
		offensiveCardsPool.AddRange(offensiveCards);
		offensiveCards.Clear();
		for (int j = 0; j < levels.Count && j <= 4; j++)
		{
			if (offensiveCardsPool.Count >= 1)
			{
				GButton val = offensiveCardsPool[0];
				((GObject)val).SetPivot(0f, 0f);
				offensiveCardsPool.RemoveAt(0);
				((GObject)val).SetXY(newList[j].x, newList[j].y);
				offensiveCards.Add(val);
				((GComponent)OffensiveCardPool).AddChild((GObject)(object)val);
				RenderOffensiveCard(val, j);
			}
			else
			{
				GButton val = (GButton)(object)UI_OffensiveCard.CreateInstance_ILRuntime();
				((GObject)val).SetPivot(0f, 0f);
				offensiveCards.Add(val);
				((GObject)val).SetXY(newList[j].x, newList[j].y);
				((GComponent)OffensiveCardPool).AddChild((GObject)(object)val);
				RenderOffensiveCard(val, j);
			}
		}
		UiTagManager instance = UiTagManager.Instance;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		instance.Unregister("DungeonInstancePanel.FirstLevelEntrance");
		instance.Unregister("DungeonInstancePanel.FirstLevelMassButton");
		for (int k = 0; k < offensiveCards.Count; k++)
		{
			dictionary.Add($"{k + 1}", offensiveCards[k]);
			dictionary2.Add($"{k + 1}", DefensiveLeftBack.MakeWarBtn);
			if (k == 0)
			{
				instance.Register("DungeonInstancePanel.FirstLevelEntrance", offensiveCards[k]);
				instance.Register("DungeonInstancePanel.FirstLevelMassButton", DefensiveLeftBack.MakeWarBtn);
			}
		}
		instance.Unregister("DungeonInstancePanel.LevelEntrance");
		instance.Unregister("DungeonInstancePanel.LevelMassButton");
		instance.Register("DungeonInstancePanel.LevelEntrance", dictionary);
		instance.Register("DungeonInstancePanel.LevelMassButton", dictionary2);
	}

	private void RenderOffensiveCard(GButton com, int levelIndex)
	{
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected O, but got Unknown
		((GComponent)com).GetController("Selected").selectedIndex = 0;
		if (levelIndex >= levels.Count)
		{
			Debug.LogError((object)"副本活动数据错误");
			return;
		}
		Level level = levels[levelIndex];
		ChapterActivityPayload chapterActivityPayload = curActivity.ContentPayload(GameManagers.Instance)[level.ChapterId] as ChapterActivityPayload;
		if (chapterActivityPayload?.LevelProgress(GameManagers.Instance) != null)
		{
			switch (chapterActivityPayload.LevelProgress(GameManagers.Instance)[levelIndex].Value)
			{
			case LevelStatus.Pending:
				((GComponent)com).GetController("PageController").selectedIndex = 0;
				break;
			case LevelStatus.Battling:
				((GComponent)com).GetController("PageController").selectedIndex = 0;
				break;
			case LevelStatus.Completed:
				((GComponent)com).GetController("PageController").selectedIndex = 1;
				break;
			}
			List<KeyValuePair<Bonus, int>> levelLotteryBonus = level.GetLevelLotteryBonus(GameManagers.Instance);
			if (levelLotteryBonus.Count > 0)
			{
				Bonus key = levelLotteryBonus.First().Key;
				string itemId = key.ItemId;
				FGUIManager.Instance.SetItemIconAndFrame(((GComponent)com).GetChild("Icon").asLoader, itemId, textureList, "", frameVisible: false);
			}
			if (level.Difficult - 1 >= 4)
			{
				((GComponent)com).GetController("Style").selectedIndex = 1;
			}
			else if (level.Difficult - 1 >= 3)
			{
				((GComponent)com).GetController("Style").selectedIndex = 2;
			}
			else
			{
				((GComponent)com).GetController("Style").selectedIndex = 0;
			}
			RenderStarList(level.Difficult, ((GComponent)com).GetChild("classList").asList);
			((GObject)com).SetScale(2f, 2f);
			((GObject)com).alpha = 0f;
			((GObject)com).data = levelIndex;
			((GObject)com).onClick.Set(new EventCallback1(OffensiveCardClickEvent));
			GDELevelData gDELevelData = GDMgr.Get<GDELevelData>(level.LevelId);
			if (!string.IsNullOrEmpty(gDELevelData.ParentLevelId))
			{
				((GComponent)com).GetChild("LevelName").text = GDMgr.Get<GDELevelData>(gDELevelData.ParentLevelId).Name;
			}
			else
			{
				((GComponent)com).GetChild("LevelName").text = gDELevelData.Name;
			}
		}
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

	private void RenderOffensiveCardDetails(int levelIndex)
	{
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Expected O, but got Unknown
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Expected O, but got Unknown
		//IL_0438: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Expected O, but got Unknown
		if (levelIndex >= levels.Count)
		{
			Debug.LogError((object)"副本活动数据错误");
			return;
		}
		Level level = levels[levelIndex];
		DefensiveLeftBack.PageController.selectedIndex = 2;
		((GObject)DefensiveLeftBack.MapName).text = level.Name ?? "";
		((GObject)DefensiveLeftBack.difficulty).text = GetLevelDifficulty(level.Difficult) ?? "";
		((GObject)DefensiveLeftBack.enemyNum).text = $"{level.GetTotalEnemies(GameManagers.Instance)}";
		((GObject)DefensiveLeftBack.levelIntroduction).text = level.Desc ?? "";
		List<KeyValuePair<Bonus, int>> levelLotteryBonus = level.GetLevelLotteryBonus(GameManagers.Instance);
		if (levelLotteryBonus.Count > 0)
		{
			Bonus titleBonus = levelLotteryBonus.First().Key;
			((GObject)DefensiveLeftBack.mainRewardNum).text = $"+{titleBonus.Qty}";
			string itemId = titleBonus.ItemId;
			FGUIManager.Instance.SetItemIconAndFrame(DefensiveLeftBack.mainRewardIcon, itemId, textureList, "", frameVisible: false, 0.65f);
			((GObject)DefensiveLeftBack.mainRewardIcon).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(titleBonus.ItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
			((GObject)DefensiveLeftBack.mainRewardNum).text = $"+{titleBonus.Qty}";
		}
		bool flag = false;
		ChapterActivityPayload contentPayload = curActivity.ContentPayload(GameManagers.Instance)[level.ChapterId] as ChapterActivityPayload;
		if (contentPayload?.LevelProgress(GameManagers.Instance) == null)
		{
			flag = true;
		}
		else
		{
			LevelStatus value = contentPayload.LevelProgress(GameManagers.Instance)[levelIndex].Value;
			flag = value != LevelStatus.Completed;
		}
		bool visible = true;
		((GObject)DefensiveLeftBack.quickBtn).visible = visible;
		((GObject)DefensiveLeftBack.quickBtn).data = level.LevelId;
		((GObject)DefensiveLeftBack.quickBtn).onClick.Set(new EventCallback1(OffensiveLevelQuickSwitch));
		CanQuickPlayOffensiveLevel(DefensiveLeftBack.quickBtn, level.LevelId);
		if (!flag)
		{
			((GObject)DefensiveLeftBack.quickBtn).visible = false;
		}
		((GObject)DefensiveLeftBack.MakeWarBtn).enabled = flag;
		if (level.BonusDesc.Count == 0)
		{
		}
		curOffensiveLevelBonuses.Clear();
		foreach (KeyValuePair<string, string> item in level.BonusDesc)
		{
			curOffensiveLevelBonuses.Add(new tKeyValue<string, string>(item.Key, item.Value));
		}
		DefensiveLeftBack.OffensiveRewardList.itemRenderer = new ListItemRenderer(RenderOffensiveCardReward);
		DefensiveLeftBack.OffensiveRewardList.numItems = curOffensiveLevelBonuses.Count;
		RenderStarList(level.Difficult, DefensiveLeftBack.classList);
		((GObject)DefensiveLeftBack.MakeWarBtn).data = levelIndex;
		((GObject)DefensiveLeftBack.MakeWarBtn).onClick.Set((EventCallback1)delegate
		{
			if (DefensiveLeftBack.quickBtn.Status.selectedIndex == 1)
			{
				if (CanPlayQuickBattle(contentPayload, levelIndex))
				{
					if (parametersTemp.ContainsKey("Parent"))
					{
						parametersTemp.Remove("Parent");
					}
					QuickPlayReplayService.returnUiParams = parametersTemp;
					QuickPlayReplayService.returnUiName = curActivity.UiName;
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_QuickBattlePanel.Name, new Dictionary<string, object>
					{
						{ "CurLevel", level },
						{ "Type", 2 },
						{ "OurFormationId", curActivityFormationId }
					});
				}
			}
			else
			{
				MakeWar((GButton)(object)DefensiveLeftBack.MakeWarBtn, contentPayload, levelIndex);
			}
		});
	}

	private void SetOffensiveMainInfo()
	{
		for (int i = 0; i < offensiveCards.Count; i++)
		{
			((GComponent)offensiveCards[i]).GetController("Selected").selectedIndex = 0;
		}
		DefensiveLeftBack.PageController.selectedIndex = 1;
		string text = "#FFFFFF";
		if (GameManagers.Instance.StockController.GetStock(curActivity.TicketItem) == 0)
		{
			text = "#DC143C";
		}
		((GObject)DefensiveLeftBack.OffensiveTip1st).text = string.Format("[color={0}]{1}:{2}{3}[/color]", text, LanguagesManager.GetDesc("CsharpCodeZhTcText283"), GameManagers.Instance.StockController.GetStock(curActivity.TicketItem), LanguagesManager.GetDesc("CsharpCodeZhTcText236"));
		((GObject)DefensiveLeftBack.DefensiveIntroduction).text = curActivity.Desc ?? "";
		if (curActivity.Period != ActivityPeriod.Permanent)
		{
			((GObject)DefensiveLeftBack.DefensiveRemainingTime).text = UiHelper.ParseTimeChinsesDH(Convert.ToInt32(curActivity.CurRemainingTime(DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime())).TotalSeconds)) + LanguagesManager.GetDesc("CsharpCodeZhTcText281");
		}
		else
		{
			((GObject)DefensiveLeftBack.DefensiveRemainingTime).text = "";
		}
	}

	private void ShowOffensiveMainInfo()
	{
		SetOffensiveMainInfo();
		SetNewOffensiveCards();
	}

	private bool MakeWar(GButton btn, ChapterActivityPayload contentPayload, int levelIndex)
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected O, but got Unknown
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		RemoveBattleEvent();
		curActivity.CheckStatus(GameManagers.Instance, out var _, sendEvent: true);
		ActivityStatus status = curActivity.GetStatus(GameManagers.Instance);
		if (curActivity.CheckOverPeriod(GameManagers.Instance) || (status != ActivityStatus.Enabled && status != ActivityStatus.Settlement))
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText274") }, 1, arg3: false);
			End();
			return false;
		}
		if (levelIndex >= contentPayload.Levels(GameManagers.Instance).Count)
		{
			Debug.LogError((object)"副本活动数据错误");
			((GObject)btn).onClick.Set((EventCallback0)delegate
			{
				MakeWar(btn, contentPayload, levelIndex);
			});
			return false;
		}
		if (contentPayload?.Chapter == null)
		{
			((GObject)btn).onClick.Set((EventCallback0)delegate
			{
				MakeWar(btn, contentPayload, levelIndex);
			});
			return false;
		}
		string ticketItem = curActivity.TicketItem;
		if (GameManagers.Instance.StockController.GetStock(ticketItem) < contentPayload.Tickets)
		{
			string nameById = SchemaIndexHelper.GetNameById(GameManagers.Instance, ticketItem);
			List<string> arg = new List<string> { nameById + LanguagesManager.GetDesc("CsharpCodeZhTcText284") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			((GObject)btn).onClick.Set((EventCallback0)delegate
			{
				MakeWar(btn, contentPayload, levelIndex);
			});
			return false;
		}
		if (contentPayload.Play(GameManagers.Instance, levelIndex))
		{
			ScriptApi.CreateTimer(2f, End);
			return true;
		}
		SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText275") }, 1, arg3: false);
		((GObject)btn).onClick.Set((EventCallback0)delegate
		{
			MakeWar(btn, contentPayload, levelIndex);
		});
		return false;
	}

	private bool CanPlayQuickBattle(ChapterActivityPayload contentPayload, int levelIndex)
	{
		curActivity.CheckStatus(GameManagers.Instance, out var _, sendEvent: true);
		if (curActivity.CheckOverPeriod(GameManagers.Instance) || (curActivity.GetStatus(GameManagers.Instance) != ActivityStatus.Enabled && curActivity.GetStatus(GameManagers.Instance) != ActivityStatus.Settlement))
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText274") }, 1, arg3: false);
			End();
			return false;
		}
		if (levelIndex >= contentPayload.Levels(GameManagers.Instance).Count)
		{
			Debug.LogError((object)"副本活动数据错误");
			return false;
		}
		if (contentPayload?.Chapter == null)
		{
			return false;
		}
		string ticketItem = curActivity.TicketItem;
		if (GameManagers.Instance.StockController.GetStock(ticketItem) < contentPayload.Tickets)
		{
			string nameById = SchemaIndexHelper.GetNameById(GameManagers.Instance, ticketItem);
			List<string> arg = new List<string> { nameById + LanguagesManager.GetDesc("CsharpCodeZhTcText284") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return false;
		}
		return true;
	}

	private void RenderOffensiveCardReward(int index, GObject obj)
	{
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		((GComponent)asButton).GetChild("title").text = curOffensiveLevelBonuses[index].Value ?? "";
		string itemId = curOffensiveLevelBonuses[index].Key;
		if (itemId == "UserExp")
		{
			FGUIManager.Instance.SetItemIconAndFrame(((GComponent)asButton).GetChild("icon").asLoader, itemId, textureList);
		}
		else if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 3)
		{
			FGUIManager.Instance.SetItemIconAndFrame(((GComponent)asButton).GetChild("icon").asLoader, itemId, textureList);
		}
		else
		{
			((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(curOffensiveLevelBonuses[index].Key);
		}
		((GObject)asButton).onClick.Set((EventCallback0)delegate
		{
			FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
		});
	}

	private void SetDefensivePanel(Dictionary<string, object> parameters)
	{
		parametersTemp = parameters;
		widthRatio = 1f;
		curCombat = LegionHelper.GetPlayerMaxPossibleCombatPower(GameManagers.Instance);
		((GObject)DefensiveLeftBack.DefensiveActivityTitle).text = curActivity.Name ?? "";
		string text = "#FFFFFF";
		if (GameManagers.Instance.StockController.GetStock(curActivity.TicketItem) == 0)
		{
			text = "#DC143C";
		}
		((GObject)DefensiveLeftBack.OffensiveTip1st).text = string.Format("[color={0}]{1}:{2}{3}[/color]", text, LanguagesManager.GetDesc("CsharpCodeZhTcText283"), GameManagers.Instance.StockController.GetStock(curActivity.TicketItem), LanguagesManager.GetDesc("CsharpCodeZhTcText236"));
		((GObject)DefensiveLeftBack.DefensiveIntroduction).text = curActivity.Desc ?? "";
		((GObject)DefensiveLeftBack.DefensiveRemainingTime).text = ((curActivity.Period != ActivityPeriod.Permanent) ? (UiHelper.ParseTimeChinsesDH(Convert.ToInt32(curActivity.CurRemainingTime(DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime())).TotalSeconds)) + LanguagesManager.GetDesc("CsharpCodeZhTcText281")) : "");
		if (string.IsNullOrWhiteSpace(curActivity.BackgroundUrl))
		{
			DefensiveLeftBack.DefensiveMapIcon.url = "ui://InstanceZones/pic_defense_formation_1";
		}
		else
		{
			DefensiveLeftBack.DefensiveMapIcon.url = "ui://InstanceZones/" + curActivity.BackgroundUrl;
		}
		RndererMissionList(DefensiveMissionList);
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("DungeonInstancePanel.LevelEntrance");
		instance.Unregister("DungeonInstancePanel.LevelMassButton");
		instance.Unregister("DungeonInstancePanel.FirstLevelEntrance");
		instance.Unregister("DungeonInstancePanel.FirstLevelMassButton");
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		for (int i = 0; i < DefensiveMissionList.numItems; i++)
		{
			GComponent asCom = ((GComponent)DefensiveMissionList).GetChildAt(i).asCom;
			GObject child = asCom.GetChild("assembledBtn");
			dictionary.Add($"{i + 1}", asCom);
			dictionary2.Add($"{i + 1}", child);
			if (i == 0)
			{
				instance.Register("DungeonInstancePanel.FirstLevelEntrance", asCom);
				instance.Register("DungeonInstancePanel.FirstLevelMassButton", child);
			}
		}
		instance.Register("DungeonInstancePanel.LevelEntrance", dictionary);
		instance.Register("DungeonInstancePanel.LevelMassButton", dictionary2);
	}

	private void SetCommonPanel(Dictionary<string, object> parameters)
	{
		if (!parameters.ContainsKey("Activity"))
		{
			End();
			return;
		}
		if (parameters.TryGetValue("GetScore", out var value))
		{
			GetScore = (float)value;
		}
		else
		{
			GetScore = 0f;
		}
		if (parameters.TryGetValue("LevelId", out var value2))
		{
			CompletedLevelId = (string)value2;
		}
		else
		{
			CompletedLevelId = "";
		}
		parametersTemp = parameters;
		((GObject)ContentGroup).visible = true;
		((GObject)MapIcon).visible = true;
		((GObject)activityTitle).text = curActivity.Name;
		if (string.IsNullOrWhiteSpace(curActivity.BackgroundUrl))
		{
			MapIcon.url = "ui://InstanceZones/pic_dungeon_sp_map";
		}
		else
		{
			MapIcon.url = "ui://InstanceZones/" + curActivity.BackgroundUrl;
		}
		widthRatio = 1f;
		curCombat = LegionHelper.GetPlayerMaxPossibleCombatPower(GameManagers.Instance);
		time = LanguagesManager.GetDesc("CsharpCodeZhTcText285") + "：" + curActivity.GetPeriodTimeDesc();
		description = curActivity.Desc;
		if (instanceZonesType == InstanceZonesType.Common)
		{
			integralProgressBackBar.bar.Type.selectedIndex = 0;
			integralNodeList.IntegralProgress.bar.bar.Type.selectedIndex = 0;
			GameLocalDataManager.SetActivityLastStayAt(curActivity.ActivityId);
		}
		else if (instanceZonesType == InstanceZonesType.Advanced)
		{
			integralProgressBackBar.bar.Type.selectedIndex = 1;
			integralNodeList.IntegralProgress.bar.bar.Type.selectedIndex = 1;
			GameLocalDataManager.SetActivityLastStayAt(curActivity.ActivityId);
		}
		else
		{
			integralProgressBackBar.bar.Type.selectedIndex = 0;
			integralNodeList.IntegralProgress.bar.bar.Type.selectedIndex = 0;
		}
		SetIntegralProgress();
		if (instanceZonesType == InstanceZonesType.Common || instanceZonesType == InstanceZonesType.Advanced)
		{
			ResolveTitleBonus(curActivity.TitleBonus);
			LoadTitleBonus();
		}
		SetPageBtnStatus();
		RenderMissionList();
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("DungeonInstancePanel.LevelEntrance");
		instance.Unregister("DungeonInstancePanel.FirstLevelEntrance");
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
		for (int i = 0; i < TimeLimitLevelBtns.Count; i++)
		{
			UI_LevelBtn uI_LevelBtn = TimeLimitLevelBtns[i];
			GObject child = ((GComponent)uI_LevelBtn).GetChild("assembledBtn");
			dictionary.Add($"{i + 1}", uI_LevelBtn);
			dictionary2.Add($"{i + 1}", dictionary2);
			if (i == 0)
			{
				instance.Register("DungeonInstancePanel.FirstLevelEntrance", uI_LevelBtn);
			}
		}
		instance.Register("DungeonInstancePanel.LevelEntrance", dictionary);
		instance.Register("DungeonInstancePanel.ScoreBonusBar", integralNodeList);
	}

	private void SetOffensivePanel(Dictionary<string, object> parameters = null)
	{
		parametersTemp = parameters;
		widthRatio = 1f;
		curCombat = LegionHelper.GetPlayerMaxPossibleCombatPower(GameManagers.Instance);
		ShowOffensiveMainInfo();
	}

	private void SetNeutralPanel()
	{
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(RenderMissionList_NeutralDungeon());
		RenderNeutralDungeonTicketTip();
		UpdateInstancezonesRemainingTime(null);
		Task<NeutralDungeonData> neutralDungeonActivity = FGUIManager.Instance.GetNeutralDungeonActivity(forceUpdate: true);
		neutralDungeonActivity.GetAwaiter().OnCompleted(delegate
		{
			RenderNeutralDungeonTicketTip();
		});
	}

	private void GetData(Dictionary<string, object> parameters)
	{
		Type = (parameters.TryGetValue("Type", out var value) ? Convert.ToInt32(value) : 0);
		if (curActivity.DifficultyLevel > 0)
		{
			Type = 4;
		}
		quickBattleSwitch = GameLocalDataManager.GetInstanceZoneQuickBattleSwitch();
		switch (Type)
		{
		case 0:
			instanceZonesType = InstanceZonesType.Common;
			ReplenishTimeInit();
			PageController.selectedIndex = 0;
			GetTimeLimitLevelPoisitions();
			SetCommonPanel(parameters);
			break;
		case 1:
			instanceZonesType = InstanceZonesType.Defensive;
			PageController.selectedIndex = 1;
			DefensiveLeftBack.PageController.selectedIndex = 0;
			SetDefensivePanel(parameters);
			break;
		case 2:
			instanceZonesType = InstanceZonesType.Offensive;
			PageController.selectedIndex = 2;
			DefensiveLeftBack.PageController.selectedIndex = 1;
			SetOffensivePanel(parameters);
			break;
		case 3:
			instanceZonesType = InstanceZonesType.SpringFestival;
			PageController.selectedIndex = 3;
			GetTimeLimitLevelPoisitions();
			SetCommonPanel(parameters);
			break;
		case 4:
			instanceZonesType = InstanceZonesType.Advanced;
			ReplenishTimeInit();
			PageController.selectedIndex = 4;
			GetTimeLimitLevelPoisitions();
			SetCommonPanel(parameters);
			break;
		case 5:
			instanceZonesType = InstanceZonesType.NeutralDungeon;
			PageController.selectedIndex = 5;
			SetNeutralPanel();
			break;
		}
		SetControllerPageText();
	}

	private void GoBack()
	{
		if (!(parentUiController is UI_MilitaryIntelligencePanel) && !(parentUiController is UI_SpecialActivityPanel) && instanceZonesType != InstanceZonesType.SpringFestival && !GameController.Contexts.Service<IUiService>().HasShowingUi(UI_MilitaryIntelligencePanel.Name))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_MilitaryIntelligencePanel.Name, null);
		}
		End();
	}

	public void End()
	{
		if (parentUiController is UI_MilitaryIntelligencePanel uI_MilitaryIntelligencePanel)
		{
			uI_MilitaryIntelligencePanel.CardLoaderInit();
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
	}

	public void RemoveBattleEvent()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		UI_DefensiveLeftBack defensiveLeftBack = DefensiveLeftBack;
		if (defensiveLeftBack != null)
		{
			UI_MakeWar makeWarBtn = defensiveLeftBack.MakeWarBtn;
			if (makeWarBtn != null)
			{
				EventListener onClick = ((GObject)makeWarBtn).onClick;
				object obj = _003C_003Ec._003C_003E9__207_0;
				if (obj == null)
				{
					EventCallback0 val = delegate
					{
					};
					_003C_003Ec._003C_003E9__207_0 = val;
					obj = (object)val;
				}
				onClick.Set((EventCallback0)obj);
			}
		}
		EventListener onClick2 = ((GObject)((GComponent)LevelCardPanel.Dailog).GetChild("assembledBtn").asButton).onClick;
		object obj2 = _003C_003Ec._003C_003E9__207_1;
		if (obj2 == null)
		{
			EventCallback0 val2 = delegate
			{
			};
			_003C_003Ec._003C_003E9__207_1 = val2;
			obj2 = (object)val2;
		}
		onClick2.Set((EventCallback0)obj2);
		EventListener onClick3 = ((GObject)((GComponent)NeutralDungeonPanel.LevelCardPanel.Dialog).GetChild("assembledBtn").asButton).onClick;
		object obj3 = _003C_003Ec._003C_003E9__207_2;
		if (obj3 == null)
		{
			EventCallback0 val3 = delegate
			{
			};
			_003C_003Ec._003C_003E9__207_2 = val3;
			obj3 = (object)val3;
		}
		onClick3.Set((EventCallback0)obj3);
		for (int num = 0; num < DefensiveMissionList.numItems; num++)
		{
			EventListener onClick4 = ((GObject)((GComponent)DefensiveMissionList).GetChildAt(num).asCom.GetChild("assembledBtn").asButton).onClick;
			object obj4 = _003C_003Ec._003C_003E9__207_3;
			if (obj4 == null)
			{
				EventCallback0 val4 = delegate
				{
				};
				_003C_003Ec._003C_003E9__207_3 = val4;
				obj4 = (object)val4;
			}
			onClick4.Set((EventCallback0)obj4);
		}
	}

	private void ActivityRewardClick(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GComponent val = (GComponent)context.sender;
		string itemId = (string)((GObject)val).data;
		FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
	}

	private void AssembleClickTip()
	{
		if (Type == 0)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText276") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
		}
	}

	private void WorkerAddClick()
	{
		if (PageController.selectedIndex == 0 || PageController.selectedIndex == 4)
		{
			if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_GiftBagPanel.Name, new Dictionary<string, object>
				{
					{
						"Activity",
						FGUIManager.Instance.GetBlackMarketerActivity("UI_GiftBagPanel")
					},
					{
						"Order",
						((GObject)this).sortingOrder
					}
				});
			}
			else
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
		}
		else if (PageController.selectedIndex == 3)
		{
			if (GameManagers.Instance.BuildingManager.GetBuildingByType("13").Status == BuildingStatus.Banned)
			{
				List<string> arg2 = new List<string>
				{
					LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
					LanguagesManager.GetDesc("CsharpCodeZhTcText22")
				};
				SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
			}
			else if (GameManagers.Instance.BuildingManager.GetBuildingByType("13").Status == BuildingStatus.Ready)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("Parent", this);
				dictionary.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType("13"));
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary);
			}
			else if (GameManagers.Instance.BuildingManager.GetBuildingByType("13").Level == 0)
			{
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("Building", GameManagers.Instance.BuildingManager.GetBuildingByType("13"));
				dictionary2.Add("Parent", this);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_Main_UpGradePanel.Name, dictionary2);
			}
			else
			{
				Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
				dictionary3.Add("BuildingType", "13");
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_WorkShopPanel.Name, dictionary3);
			}
		}
	}

	private void SkillListRenderer(Soldier soldier, string bossIcon)
	{
		((GObject)DefensiveLeftBack.BossName).text = soldier.Name;
		((GObject)DefensiveLeftBack.showPicture.icon).asCom.GetChild("icon").asLoader.url = "ui://PublicResources/" + bossIcon;
		List<string> list = new List<string>();
		string currentLevelFeatureAbilityId = soldier.GetCurrentLevelFeatureAbilityId();
		for (int i = 0; i < soldier.AbilityList.Count; i++)
		{
			if (!(soldier.AbilityList[i] == soldier.FeatureAbility) && GDMgr.TryGetWithErrorHandling<GDEAbilityData>(soldier.AbilityList[i]).Visible)
			{
				list.Add(soldier.AbilityList[i]);
			}
		}
		RenderSkillListItem(currentLevelFeatureAbilityId, (GButton)(object)DefensiveLeftBack.DefensiveSpecialSkill, isUnLocked: true, 0);
		DefensiveLeftBack.DefensiveSpecialSkill.Status.selectedIndex = 1;
		DefensiveLeftBack.DefensiveSkillList.numItems = list.Count;
		for (int j = 0; j < list.Count; j++)
		{
			bool isUnLocked = true;
			RenderSkillListItem(list[j], ((GComponent)DefensiveLeftBack.DefensiveSkillList).GetChildAt(j).asButton, isUnLocked, 0);
		}
		DefensiveLeftBack.DefensiveSkillList.numItems = list.Count;
	}

	private void RenderSkillListItem(string skillId, GButton button, bool isUnLocked, int limit)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		GDEAbilityData abilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(skillId);
		((GComponent)((GComponent)((GObject)button).asButton).GetChild("IconBtn").asButton).GetChild("IconLoader").asLoader.LoadAbilityIcon(abilityData.Icon);
		if (isUnLocked)
		{
			((GComponent)((GObject)button).asButton).GetChild("IconBtn").grayed = false;
			((GObject)button).touchable = true;
			((GObject)button).onClick.Set((EventCallback0)delegate
			{
				SkillDetailPopup(abilityData, limit, isUnLocked);
			});
		}
		else
		{
			((GComponent)((GObject)button).asButton).GetChild("IconBtn").grayed = true;
			((GObject)button).onClick.Set((EventCallback0)delegate
			{
				SkillDetailPopup(abilityData, limit, isUnLocked);
			});
			((GObject)button).touchable = true;
		}
		int num = 5 - 5 * ((GComponent)DefensiveLeftBack.DefensiveSkillList).GetChildIndex((GObject)(object)button);
		((GComponent)((GObject)button).asButton).GetChild("n16").rotation = num;
	}

	public void SkillDetailPopup(GDEAbilityData abilityData, int limit, bool isUnlock)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = ((GObject)DefensiveLeftBack.DefensiveSkillList).LocalToGlobal(Vector2.zero);
		val = ((GObject)this).GlobalToLocal(val) + new Vector2(200f, 20f);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Pos", val);
		dictionary.Add("Data", abilityData);
		dictionary.Add("Limit", limit);
		dictionary.Add("State", isUnlock);
		dictionary.Add("GList", DefensiveLeftBack.DefensiveSkillList);
		dictionary.Add("SortingOrder", ((GObject)this).sortingOrder);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, dictionary);
	}

	private void MissionListRenderer(int index, GObject obj)
	{
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected O, but got Unknown
		//IL_0702: Unknown result type (might be due to invalid IL or missing references)
		//IL_070c: Expected O, but got Unknown
		//IL_06ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d4: Expected O, but got Unknown
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Expected O, but got Unknown
		//IL_0540: Unknown result type (might be due to invalid IL or missing references)
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, ActivityContentPayload> dictionary = curActivity.ContentPayload(GameManagers.Instance);
		if (index >= dictionary.Count)
		{
			Debug.LogError((object)"副本活动数据错误");
			return;
		}
		UI_DefensiveTaskCom button = (UI_DefensiveTaskCom)(object)obj.asCom;
		string text = dictionary.Keys.ToArray()[index];
		ChapterActivityPayload contentPayload = dictionary[text] as ChapterActivityPayload;
		if (contentPayload?.Chapter == null)
		{
			Debug.LogError((object)("活动" + curActivity.ActivityId + "没有配置章节" + text));
			return;
		}
		if (contentPayload.Levels(GameManagers.Instance).Count < 1)
		{
			Debug.LogError((object)("活动" + curActivity.ActivityId + "章节" + text + "没有配置关卡"));
			return;
		}
		button.Difficulty.selectedIndex = index;
		Chapter chapter = ChapterManager.Chapters[text];
		((GObject)button.combat).text = $"{chapter.RecommendPower:N0}";
		bool flag = (float)curCombat >= chapter.RecommendPower;
		button.CombatPower.SetSelectedIndex((!flag) ? 1 : 0);
		string url = $"ui://InstanceZones/关卡难度{index + 1}";
		for (int i = 0; i < 4; i++)
		{
			((GComponent)button).GetChild($"reward{i}").visible = false;
		}
		Level level = contentPayload.Levels(GameManagers.Instance).Last();
		if (level.HasSubLevels())
		{
			ChapterManager.Levels.TryGetValue(level.SubLevels.Last(), out level);
		}
		List<Soldier> bossInfo = level.BossInfo;
		string icon = level.Data.Icon;
		if (bossInfo.Count > 0)
		{
			SkillListRenderer(bossInfo.Last(), icon);
		}
		else
		{
			((GObject)DefensiveLeftBack.showPicture.icon).asCom.GetChild("icon").asLoader.url = "ui://PublicResources/" + icon;
		}
		if (contentPayload.Levels(GameManagers.Instance).Count > 0)
		{
			Level level2 = contentPayload.Levels(GameManagers.Instance).First();
			int num = 0;
			foreach (KeyValuePair<string, string> item in level2.BonusDesc)
			{
				int num2 = num;
				((GComponent)button).GetChild($"reward{num2}").visible = true;
				if (item.Key == "UserExp")
				{
					FGUIManager.Instance.SetItemIconAndFrame(((GComponent)button).GetChild($"rewardIcon{num2}").asLoader, item.Key, textureList);
				}
				else
				{
					((GComponent)button).GetChild($"rewardIcon{num2}").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(item.Key);
				}
				((GComponent)button).GetChild($"rewardNum{num}").text = item.Value;
				num++;
				((GComponent)button).GetChild($"rewardIcon{num2}").onClick.Set((EventCallback0)delegate
				{
					UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
					FGUIManager.Instance.ItemTip(item.Key, ((GObject)this).sortingOrder, noCheckBtn: true);
				});
			}
			((GComponent)button).GetChild("difficultyIcon").asLoader.url = url;
			((GObject)((GComponent)button).GetChild("missionIndex").asTextField).text = level2.Name ?? "";
			((GObject)((GComponent)button).GetChild("missionName").asTextField).text = "";
			float recommendPower = contentPayload.Chapter.RecommendPower;
			((GObject)((GComponent)button).GetChild("combat").asTextField).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(recommendPower.ToString("F0"));
			Color32 val = (((float)curCombat >= recommendPower) ? new Color32((byte)23, (byte)137, (byte)20, byte.MaxValue) : new Color32((byte)196, (byte)29, (byte)25, byte.MaxValue));
			((GComponent)button).GetChild("combat").asTextField.color = Color32.op_Implicit(val);
		}
		UI_PropetryLock uI_PropetryLock = ((GComponent)button).GetChild("quickBtn") as UI_PropetryLock;
		((GObject)uI_PropetryLock).visible = true;
		((GObject)uI_PropetryLock).onClick.Set(new EventCallback1(DefensiveLevelQuickSwitch));
		((GObject)uI_PropetryLock).data = contentPayload;
		CanQuickPlayDefensiveLevel(contentPayload, uI_PropetryLock);
		for (int num3 = 0; num3 < 3; num3++)
		{
			GObject child = ((GComponent)button).GetChild($"cornerIcon{num3 + 1}");
			if (child != null)
			{
				GImage asImage = child.asImage;
				if (num3 % 2 == 0)
				{
					((GObject)asImage).SetXY(((GObject)asImage).x, (float)Random.Range(30, 90));
				}
				else
				{
					((GObject)asImage).SetXY((float)Random.Range(150, 550), ((GObject)asImage).y);
				}
			}
		}
		GetCurLevelFormationId(contentPayload.Levels(GameManagers.Instance)[0].LevelId);
		GButton assembledBtn = ((GComponent)button).GetChild("assembledBtn").asButton;
		if (curActivity.UnlockedContent(GameManagers.Instance).Contains(text))
		{
			((GObject)assembledBtn).onClick.Set((EventCallback0)delegate
			{
				if (((GComponent)((GComponent)button).GetChild("quickBtn").asButton).GetController("Status").selectedIndex == 1)
				{
					if (CanPlayQuickBattle(contentPayload, 0))
					{
						QuickPlayReplayService.MaxBattleCount = GameManagers.Instance.StockController.GetStock(curActivity.TicketItem);
						QuickPlayReplayService.CurTicketIcon = UiHelper.GetIcon(curActivity.TicketItem);
						if (parametersTemp.ContainsKey("Parent"))
						{
							parametersTemp.Remove("Parent");
						}
						QuickPlayReplayService.returnUiParams = parametersTemp;
						QuickPlayReplayService.returnUiName = curActivity.UiName;
						GameController.Contexts.Service<IUiService>().OpenPanel(UI_QuickBattlePanel.Name, new Dictionary<string, object>
						{
							{
								"CurLevel",
								contentPayload.Levels(GameManagers.Instance)[0]
							},
							{ "Type", 1 },
							{ "OurFormationId", curActivityFormationId }
						});
					}
				}
				else
				{
					MakeWar(assembledBtn, contentPayload, 0);
				}
			});
			((GComponent)button).GetController("CanPlay").selectedIndex = 0;
		}
		else
		{
			((GObject)assembledBtn).onClick.Set(new EventCallback0(AssembleClickTip));
			((GComponent)button).GetController("CanPlay").selectedIndex = 1;
			((GComponent)button).GetChild("tip1st").text = string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText286"), index, LanguagesManager.GetDesc("CsharpCodeZhTcText113"));
		}
	}

	private void ActivityRewardListRenderer(int index, GObject obj)
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		string text = _BonusExhibition[index];
		if (Shift.Legion.Common.Models.Item.ItemType(text) == 3)
		{
			FGUIManager.Instance.SetItemIconAndFrame(((GComponent)asButton).GetChild("icon").asLoader, text, textureList);
		}
		else
		{
			((GComponent)asButton).GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIcon(text);
		}
		((GObject)((GComponent)asButton).GetChild("title").asRichTextField).text = SchemaIndexHelper.GetNameById(GameManagers.Instance, text);
		((GObject)asButton).data = text;
		((GObject)asButton).onClick.Set(new EventCallback1(ActivityRewardClick));
	}

	private void ProgressNodeRenderer(int type, GComponent button, Dictionary<string, float> nodeBonus)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ad: Expected O, but got Unknown
		//IL_0e5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e64: Expected O, but got Unknown
		//IL_0aa3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aad: Expected O, but got Unknown
		//IL_0ef6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3c: Unknown result type (might be due to invalid IL or missing references)
		((GObject)button.GetChild("omissionMark").asTextField).visible = false;
		switch (type)
		{
		case 0:
			button.GetChild("arrow").asImage.color = Color32.op_Implicit(new Color32((byte)84, (byte)67, (byte)24, byte.MaxValue));
			button.GetChild("nodeBtn").asCom.GetChild("back").asGraph.color = Color32.op_Implicit(new Color32((byte)88, (byte)52, (byte)20, byte.MaxValue));
			button.GetChild("nodeBtn").SetScale(1f, 1f);
			((GObject)button.GetChild("omissionMark").asTextField).visible = false;
			((GObject)button.GetChild("pointsRequired").asGroup).visible = true;
			((GObject)button.GetChild("nodeBtn").asCom).data = 0;
			((GObject)button.GetChild("nodeBtn").asCom.GetChild("stroke").asGraph).visible = false;
			break;
		case 1:
			button.GetChild("arrow").asImage.color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
			button.GetChild("nodeBtn").asCom.GetChild("back").asGraph.color = Color32.op_Implicit(new Color32((byte)226, (byte)116, (byte)27, byte.MaxValue));
			button.GetChild("nodeBtn").SetScale(1.1f, 1.1f);
			((GObject)button.GetChild("omissionMark").asTextField).visible = false;
			((GObject)button.GetChild("pointsRequired").asGroup).visible = true;
			((GObject)button.GetChild("nodeBtn").asCom).data = 1;
			((GObject)button.GetChild("nodeBtn").asCom.GetChild("stroke").asGraph).visible = false;
			if (curNode == null)
			{
				curNode = button;
			}
			canReceiveNodes.Add(button);
			break;
		case 2:
			button.GetChild("arrow").asImage.color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
			button.GetChild("nodeBtn").asCom.GetChild("back").asGraph.color = Color32.op_Implicit(new Color32((byte)226, (byte)116, (byte)27, byte.MaxValue));
			button.GetChild("nodeBtn").SetScale(1.1f, 1.1f);
			((GObject)button.GetChild("omissionMark").asTextField).visible = false;
			((GObject)button.GetChild("pointsRequired").asGroup).visible = true;
			((GObject)button.GetChild("nodeBtn").asCom).data = 2;
			((GObject)button.GetChild("nodeBtn").asCom.GetChild("stroke").asGraph).visible = false;
			canReceiveNodes.Add(button);
			break;
		case 3:
			button.GetChild("arrow").asImage.color = Color32.op_Implicit(new Color32((byte)84, (byte)67, (byte)24, byte.MaxValue));
			button.GetChild("nodeBtn").asCom.GetChild("back").asGraph.color = Color32.op_Implicit(new Color32((byte)88, (byte)52, (byte)20, byte.MaxValue));
			button.GetChild("nodeBtn").SetScale(1f, 1f);
			((GObject)button.GetChild("omissionMark").asTextField).visible = false;
			((GObject)button.GetChild("pointsRequired").asGroup).visible = true;
			((GObject)button.GetChild("nodeBtn").asCom).data = 3;
			((GObject)button.GetChild("nodeBtn").asCom.GetChild("stroke").asGraph).visible = false;
			if (nextNode == null)
			{
				nextNode = button;
			}
			break;
		case 4:
			button.GetChild("arrow").asImage.color = Color32.op_Implicit(new Color32((byte)84, (byte)67, (byte)24, byte.MaxValue));
			button.GetChild("nodeBtn").asCom.GetChild("back").asGraph.color = Color32.op_Implicit(new Color32((byte)88, (byte)52, (byte)20, byte.MaxValue));
			button.GetChild("nodeBtn").SetScale(1f, 1f);
			((GObject)button.GetChild("omissionMark").asTextField).visible = false;
			((GObject)button.GetChild("pointsRequired").asGroup).visible = true;
			((GObject)button.GetChild("nodeBtn").asCom).data = 4;
			((GObject)button.GetChild("nodeBtn").asCom.GetChild("stroke").asGraph).visible = false;
			break;
		}
		Controller controller = button.GetChild("nodeBtn").asCom.GetController("ShowItems");
		button.GetChild("nodeBtn").asCom.GetChild("Items").y = -96f;
		controller.selectedIndex = 0;
		if (type != 0 && Shift.Legion.Common.Models.Item.ItemType(nodeBonus.First().Key) == 15)
		{
			controller.selectedIndex = 1;
			List<Modifier> list = Shift.Legion.Common.Models.Item.Effect(GameManagers.Instance, nodeBonus.First().Key);
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (Modifier item in list)
			{
				if (!(item.ModifierId == "Items"))
				{
					continue;
				}
				foreach (KeyValuePair<string, object> item2 in item.PayloadDictionary)
				{
					dictionary.Add(item2.Key, Convert.ToInt32(item2.Value));
				}
			}
			for (int i = 0; i < 4; i++)
			{
				GLoader asLoader = button.GetChild("nodeBtn").asCom.GetChild($"icon{i}").asLoader;
				GTextField asTextField = button.GetChild("nodeBtn").asCom.GetChild($"num{i}").asTextField;
				if (i >= dictionary.Count)
				{
					((GObject)asLoader).visible = false;
					((GObject)asTextField).visible = false;
					continue;
				}
				KeyValuePair<string, int> _item = dictionary.ToList()[i];
				((GObject)asTextField).text = "x" + Convert.ToInt32(_item.Value).ShortNumberFormat();
				FGUIManager.Instance.SetItemIconAndFrame(asLoader, _item.Key, textureList);
				((GObject)asLoader).onClick.Set((EventCallback0)delegate
				{
					FGUIManager.Instance.ItemTip(_item.Key, ((GObject)this).sortingOrder, noCheckBtn: true);
				});
				AddOnClickGloader.Add(asLoader);
			}
		}
		if (nodeBonus.Count > 1)
		{
			int num = 0;
			((GObject)button.GetChild("nodeBtn").asCom.GetChild("middleIcon").asCom).visible = false;
			{
				foreach (KeyValuePair<string, float> nodeBonu in nodeBonus)
				{
					if (num > 1)
					{
						break;
					}
					string key = nodeBonu.Key;
					string empty = string.Empty;
					empty = ((num != 0) ? "rightIcon" : "leftIcon");
					((GObject)button.GetChild("nodeBtn").asCom.GetChild(empty).asCom.GetChild("debris").asImage).visible = false;
					Controller controller2 = button.GetChild("nodeBtn").asCom.GetChild(empty).asCom.GetController("Type");
					controller2.selectedIndex = 0;
					if (Shift.Legion.Common.Models.Item.ItemType(key) == 3)
					{
						controller2.selectedIndex = 2;
						FGUIManager.Instance.SetItemIconAndFrame(button.GetChild("nodeBtn").asCom.GetChild(empty).asCom.GetChild("leftIcon").asLoader, key, textureList);
					}
					else
					{
						button.GetChild("nodeBtn").asCom.GetChild(empty).asCom.GetChild("leftIcon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(nodeBonu.Key);
						if (Shift.Legion.Common.Models.Item.ItemType(key) == 8 || Shift.Legion.Common.Models.Item.ItemType(key) == 10)
						{
							controller2.selectedIndex = 1;
						}
					}
					if (type == 0)
					{
						button.GetChild("nodeBtn").asCom.GetChild(empty).asCom.GetChild("num").visible = false;
					}
					else
					{
						button.GetChild("nodeBtn").asCom.GetChild(empty).asCom.GetChild("num").visible = true;
					}
					((GObject)button.GetChild("nodeBtn").asCom.GetChild(empty).asCom.GetChild("num").asTextField).text = $"{(int)nodeBonu.Value}";
					((GObject)button.GetChild("nodeBtn").asCom.GetChild(empty).asCom).data = nodeBonu.Key;
					((GObject)button.GetChild("nodeBtn").asCom.GetChild(empty).asCom).onClick.Set(new EventCallback1(ItemTip));
					Controller controller3 = button.GetChild("nodeBtn").asCom.GetController("Status");
					switch (type)
					{
					case 0:
						controller3.selectedIndex = 0;
						break;
					default:
						if (type != 2)
						{
							controller3.selectedIndex = 3;
							break;
						}
						goto case 1;
					case 1:
					{
						GGraph asGraph = button.GetChild("nodeBtn").asCom.GetChild(empty).asCom.GetChild("SfxBack").asGraph;
						FGUIManager.Instance.AddTextSpecialEffects(asGraph, "rubby_light_white", new Vector3(45f, 45f, 45f));
						controller3.selectedIndex = type;
						break;
					}
					}
					num++;
				}
				return;
			}
		}
		((GObject)button.GetChild("nodeBtn").asCom.GetChild("leftIcon").asCom).visible = false;
		((GObject)button.GetChild("nodeBtn").asCom.GetChild("rightIcon").asCom).visible = false;
		foreach (KeyValuePair<string, float> nodeBonu2 in nodeBonus)
		{
			string key2 = nodeBonu2.Key;
			((GObject)button.GetChild("nodeBtn").asCom.GetChild("middleIcon").asCom.GetChild("debris").asImage).visible = false;
			Controller controller4 = button.GetChild("nodeBtn").asCom.GetChild("middleIcon").asCom.GetController("Type");
			controller4.selectedIndex = 0;
			if (Shift.Legion.Common.Models.Item.ItemType(key2) == 3)
			{
				controller4.selectedIndex = 2;
				FGUIManager.Instance.SetItemIconAndFrame(button.GetChild("nodeBtn").asCom.GetChild("middleIcon").asCom.GetChild("leftIcon").asLoader, key2, textureList);
			}
			else
			{
				button.GetChild("nodeBtn").asCom.GetChild("middleIcon").asCom.GetChild("leftIcon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(nodeBonu2.Key);
				if (Shift.Legion.Common.Models.Item.ItemType(key2) == 8 || Shift.Legion.Common.Models.Item.ItemType(key2) == 10)
				{
					controller4.selectedIndex = 1;
				}
			}
			if (type == 0)
			{
				button.GetChild("nodeBtn").asCom.GetChild("middleIcon").asCom.GetChild("num").visible = false;
			}
			else
			{
				button.GetChild("nodeBtn").asCom.GetChild("middleIcon").asCom.GetChild("num").visible = true;
			}
			((GObject)button.GetChild("nodeBtn").asCom.GetChild("middleIcon").asCom.GetChild("num").asTextField).text = $"{(int)nodeBonu2.Value}";
			((GObject)button.GetChild("nodeBtn").asCom.GetChild("middleIcon").asCom).data = nodeBonu2.Key;
			((GObject)button.GetChild("nodeBtn").asCom.GetChild("middleIcon").asCom).onClick.Set(new EventCallback1(ItemTip));
			Controller controller5 = button.GetChild("nodeBtn").asCom.GetController("Status");
			switch (type)
			{
			case 0:
				controller5.selectedIndex = 0;
				break;
			default:
				if (type != 2)
				{
					controller5.selectedIndex = 3;
					break;
				}
				goto case 1;
			case 1:
			{
				GGraph asGraph2 = button.GetChild("nodeBtn").asCom.GetChild("middleIcon").asCom.GetChild("SfxBack").asGraph;
				FGUIManager.Instance.AddTextSpecialEffects(asGraph2, "rubby_light_white", new Vector3(45f, 45f, 45f));
				controller5.selectedIndex = type;
				break;
			}
			}
		}
	}

	private void ReceiveIntegralBonuses()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		SetInitBonusPage();
		PlayReceiveSfx();
		((GObject)Mask).touchable = true;
		GTweener obj = ((GObject)integralNodeList).TweenFade(((GObject)integralNodeList).alpha, 1f);
		object obj2 = _003C_003Ec._003C_003E9__217_0;
		if (obj2 == null)
		{
			GTweenCallback val = async delegate
			{
			};
			_003C_003Ec._003C_003E9__217_0 = val;
			obj2 = (object)val;
		}
		obj.OnComplete((GTweenCallback)obj2);
		ILRequestHelper<ActivityClaimResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().ActivityClaim(curActivity.ActivityId), delegate(ActivityClaimResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				((GObject)Mask).touchable = false;
			}
			else if (response.ActivityId != curActivity.ActivityId)
			{
				ILRequestHelper.ShowErrorCode(82100004);
				((GObject)Mask).touchable = false;
			}
			else
			{
				if (response.ClaimProgress != null)
				{
					curActivity.ActivityProgress(GameManagers.Instance).ClaimProgress = response.ClaimProgress;
				}
				if (response.BonusList != null && response.BonusList.Count > 0)
				{
					FGUIManager.Instance.ClaimBonusFromApiModels(response.BonusList, delegate(ModelsBonus bonusApiModel)
					{
						ThinkingDataHelper.Instance.SoulPointRewardTrack(curActivity.Name, bonusApiModel.ItemId, bonusApiModel.Qty, curActivity.Score(GameManagers.Instance));
					});
				}
				GameManagers.Instance.UserArchiveManager.SetActivityProgress(curActivity.ActivityProgress(GameManagers.Instance));
				if (parentUiController is UI_MilitaryIntelligencePanel uI_MilitaryIntelligencePanel)
				{
					uI_MilitaryIntelligencePanel.CardLoaderInit();
				}
				PlayMissileSfx();
				SetIntegralProgress();
				((GObject)Mask).touchable = false;
			}
		}, 1f);
	}

	private void PlayReceiveSfx()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		if (!(curNode is UI_IntegralNode uI_IntegralNode) || ((GObject)uI_IntegralNode).isDisposed)
		{
			return;
		}
		GGraph sfxBack = uI_IntegralNode.nodeBtn.leftIcon.SfxBack;
		FGUIManager.Instance.AddTextSpecialEffects(sfxBack, "activating_white", new Vector3(90f, 90f, 90f), "Default", 0.5f, delegate(GameObject leftIconSfx)
		{
			if ((Object)(object)leftIconSfx == (Object)null)
			{
				ILRuntimeDebug.LogError("UI_InstanceZonesPanel.PlayReceiveSfx, leftIconSfx is null");
			}
			else
			{
				leftIconSfx.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
			}
		});
		GGraph sfxBack2 = uI_IntegralNode.nodeBtn.rightIcon.SfxBack;
		FGUIManager.Instance.AddTextSpecialEffects(sfxBack2, "activating_white", new Vector3(90f, 90f, 90f), "Default", 0.5f, delegate(GameObject rightIconSfx)
		{
			if ((Object)(object)rightIconSfx == (Object)null)
			{
				ILRuntimeDebug.LogError("UI_InstanceZonesPanel.PlayReceiveSfx, rightIconSfx is null");
			}
			else
			{
				rightIconSfx.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
			}
		});
		GGraph sfxBack3 = uI_IntegralNode.nodeBtn.middleIcon.SfxBack;
		FGUIManager.Instance.AddTextSpecialEffects(sfxBack3, "activating_white", new Vector3(90f, 90f, 90f), "Default", 0.5f, delegate(GameObject middleIconSfx)
		{
			if ((Object)(object)middleIconSfx == (Object)null)
			{
				ILRuntimeDebug.LogError("UI_InstanceZonesPanel.PlayReceiveSfx, middleIconSfx is null");
			}
			else
			{
				middleIconSfx.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
			}
		});
	}

	private void IntegralProgressClick(EventContext context)
	{
		context.StopPropagation();
	}

	private void ItemTip(EventContext context)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		context.StopPropagation();
		GComponent val = (GComponent)context.sender;
		string itemId = (string)((GObject)val).data;
		FGUIManager.Instance.ItemTip(itemId, ((GObject)this).sortingOrder, noCheckBtn: true);
	}

	private int GetScoreNodeState(float curNum, bool showLastScore = false)
	{
		float num = curActivity.Score(GameManagers.Instance);
		if (showLastScore)
		{
			num -= GetScore;
		}
		int num2 = 0;
		unClaimed = 0f;
		if (unClaimed < 0.1f)
		{
			List<float> list = new List<float>();
			foreach (KeyValuePair<float, Dictionary<string, float>> item in curActivity.BonusProgress)
			{
				if (num >= item.Key && !curActivity.ClaimProgress(GameManagers.Instance).Contains(item.Key))
				{
					list.Add(item.Key);
				}
			}
			if (list.Count > 0)
			{
				unClaimed = list[0];
			}
		}
		if (noClaimed < 0.1f)
		{
			List<float> list2 = new List<float>();
			if (curActivity.ClaimProgress(GameManagers.Instance) == null)
			{
			}
			foreach (KeyValuePair<float, Dictionary<string, float>> item2 in curActivity.BonusProgress)
			{
				if (num < item2.Key && !curActivity.ClaimProgress(GameManagers.Instance).Contains(item2.Key))
				{
					list2.Add(item2.Key);
				}
			}
			if (list2.Count > 0)
			{
				noClaimed = list2[0];
			}
		}
		if (num >= curNum)
		{
			if (curActivity.ClaimProgress(GameManagers.Instance).Contains(curNum))
			{
				return 0;
			}
			if (curNum <= unClaimed)
			{
				return 1;
			}
			return 2;
		}
		if (curNum <= noClaimed)
		{
			return 3;
		}
		return 4;
	}

	private void UpdateTicketsNum()
	{
		string text = "#F3DDAA";
		if (GameManagers.Instance.StockController.GetStock(curActivity.TicketItem) <= 0)
		{
			text = "#DC143C";
		}
		int stock = GameManagers.Instance.StockController.GetStock(curActivity.TicketItem);
		((GObject)addWorkerBtn.num).text = GameManagers.Instance.StockController.GetStock(curActivity.TicketItem).ShortNumberFormat() ?? "";
		((GObject)addWorkerBtn.num).data = stock;
		((GObject)addWorkerBtn.MaxNum).text = curActivity.TicketLimit.ShortNumberFormat() ?? "";
		((GObject)addWorkerBtn.ExtraLimit).text = curActivity.GetTicketExtraLimitDesc() ?? "";
		string ticketItem = curActivity.TicketItem;
		addWorkerBtn.icon.url = "ui://PublicResources/" + UiHelper.GetIcon(ticketItem);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (!(itemId == curActivity.TicketItem))
		{
			return;
		}
		int stock = GameManagers.Instance.StockController.GetStock(itemId);
		((GObject)addWorkerBtn.num).data = stock;
		if (Type == 1 || Type == 2)
		{
			string text = "#FFFFFF";
			if (GameManagers.Instance.StockController.GetStock(curActivity.TicketItem) == 0)
			{
				text = "#DC143C";
			}
			((GObject)DefensiveLeftBack.OffensiveTip1st).text = string.Format("[color={0}]{1}:{2}{3}[/color]", text, LanguagesManager.GetDesc("CsharpCodeZhTcText283"), GameManagers.Instance.StockController.GetStock(curActivity.TicketItem), LanguagesManager.GetDesc("CsharpCodeZhTcText236"));
		}
		else
		{
			if (Type != 0 && Type != 4)
			{
				return;
			}
			int stock2 = GameManagers.Instance.StockController.GetStock(curActivity.TicketItem);
			((GObject)((GComponent)addWorkerBtn).GetChild("num").asTextField).text = stock2.ToString();
			int num = ((((GComponent)addWorkerBtn).GetChild("num").data != null) ? ((int)((GComponent)addWorkerBtn).GetChild("num").data) : stock2);
			if (num != stock2 && stock2 > num)
			{
				int num2 = stock2 - num;
				if (NumFloating == null)
				{
					NumFloating = UI_ProductionNumFloating.CreateInstance_ILRuntime();
				}
				if (!((GObject)NumFloating).onStage)
				{
					FGUIManager.Instance.AddNumFloatingForCouponBtn(NumFloating, (GComponent)(object)addWorkerBtn, stock2 - num);
					return;
				}
				((GObject)NumFloating.Title).text = $"+{(int)((GObject)NumFloating.Title).data + num2}";
				((GObject)NumFloating.Title).data = (int)((GObject)NumFloating.Title).data + num2;
			}
		}
	}

	private void OnBackToInstanceZonesPanel(string uiName)
	{
		if ((!(uiName != UI_MonthCardPanel.Name) || !(uiName != UI_DamageMeter.Name)) && instanceZonesType == InstanceZonesType.NeutralDungeon)
		{
			UpdateMainPanel(parametersTemp);
		}
	}

	private void PlayGetScore()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		inMotion = true;
		((GComponent)(object)this).SetTimeout(1.5f).OnComplete((GTweenCallback)delegate
		{
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			int num = ((canReceiveNodes.Count > 4) ? 4 : canReceiveNodes.Count);
			for (int i = 0; i < num; i++)
			{
				GGraph asGraph = canReceiveNodes[i].GetChild("nodeBtn").asCom.GetChild("middleIcon").asCom.GetChild("SfxBack").asGraph;
				FGUIManager.Instance.AddTextSpecialEffects(asGraph, "activating_white_sp", new Vector3(45f, 45f, 45f));
			}
		});
		((GComponent)(object)this).SetTimeout(3f).OnComplete((GTweenCallback)delegate
		{
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			int num = ((canReceiveNodes.Count > 4) ? 4 : canReceiveNodes.Count);
			for (int i = 0; i < num; i++)
			{
				GGraph asGraph = canReceiveNodes[i].GetChild("nodeBtn").asCom.GetChild("middleIcon").asCom.GetChild("SfxBack").asGraph;
				FGUIManager.Instance.AddTextSpecialEffects(asGraph, "rubby_light_white", new Vector3(45f, 45f, 45f));
			}
		});
		((GComponent)(object)this).SetTimeout(3.2f).OnComplete((GTweenCallback)delegate
		{
			inMotion = false;
		});
	}

	private void SetIntegralProgress(bool showLastScore = false)
	{
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ea: Expected O, but got Unknown
		curNode = null;
		nextNode = null;
		float num = curActivity.Score(GameManagers.Instance);
		if (showLastScore)
		{
			num -= GetScore;
		}
		GComponent asCom = ((GComponent)integralNodeList).GetChildAt(0).asCom;
		for (int num2 = integralButtonList.Count - 1; num2 >= 0; num2--)
		{
			asCom.RemoveChild((GObject)(object)integralButtonList[num2], true);
		}
		float num3 = 329.25f;
		int num4 = 0;
		float num5 = 0f;
		int num6 = 0;
		int index = 0;
		List<float> list = new List<float>();
		canReceiveNodes.Clear();
		foreach (KeyValuePair<float, Dictionary<string, float>> item in curActivity.BonusProgress)
		{
			list.Add(item.Key);
			UI_IntegralNode uI_IntegralNode = UI_IntegralNode.CreateInstance_ILRuntime();
			((GObject)uI_IntegralNode).sortingOrder = 1;
			asCom.AddChild((GObject)(object)uI_IntegralNode);
			if (num4 == 0)
			{
				((GObject)uI_IntegralNode).SetXY(num3 * 0.45f, ((GObject)uI_IntegralNode).height / 2f);
			}
			else
			{
				((GObject)uI_IntegralNode).SetXY(((float)num4 + 0.45f) * num3, ((GObject)uI_IntegralNode).height / 2f);
				num5 = item.Key;
			}
			if (num4 == curActivity.BonusProgress.Count - 1)
			{
				((GObject)asCom).SetSize(((GObject)asCom.GetChildAt(num4 + 1).asButton).x + num3 * 0.45f, ((GObject)asCom).height);
			}
			integralButtonList.Add((GButton)(object)uI_IntegralNode);
			((GObject)((GComponent)uI_IntegralNode).GetChild("nodeBtn").asCom).onClick.Set(new EventCallback1(IntegralProgressClick));
			((GObject)((GComponent)uI_IntegralNode).GetChild("integral").asTextField).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(item.Key.ToString());
			((GComponent)uI_IntegralNode).GetChild("integralIcon").asLoader.url = "ui://PublicResources/" + curActivity.ScoreItem;
			ProgressNodeRenderer(GetScoreNodeState(item.Key, showLastScore), (GComponent)(object)uI_IntegralNode, item.Value);
			num4++;
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (num / list[i] >= 0.9999f && num / list[i] <= 1.0001f)
			{
				num6 = i;
				if (i != list.Count - 1)
				{
					nextNodeScore = list[num6 + 1];
				}
				else
				{
					nextNodeScore = list[num6];
				}
			}
			else if (i != list.Count - 1)
			{
				if (list[i] < num && list[i + 1] >= num)
				{
					num6 = i;
					index = i + 1;
					nextNodeScore = list[index];
				}
				else if (num < list[0])
				{
					nextNodeScore = list[0];
				}
			}
		}
		if (num / list[num6] >= 0.9999f && num / list[num6] <= 1.0001f)
		{
			double num7 = ((float)num6 + 0.45f) * num3 / ((GObject)asCom).width;
			asCom.GetChild("bar").asProgress.value = num7 * 100.0;
		}
		else if (num > list[0])
		{
			double num8 = (((float)num6 + 0.45f) * num3 + (num - list[num6]) / (list[index] - list[num6]) * num3) / ((GObject)asCom).width;
			asCom.GetChild("bar").asProgress.value = num8 * 100.0;
		}
		else
		{
			double num9 = num / list[0] * num3 * 0.45f / ((GObject)asCom).width;
			asCom.GetChild("bar").asProgress.value = num9 * 100.0;
		}
		if (!showLastScore)
		{
			scoreBarValue = asCom.GetChild("bar").asProgress.value;
		}
		if (num >= num5)
		{
			asCom.GetChild("bar").asProgress.value = 100.0;
		}
		UpdateBar();
		TotalBonusesPage = ((list.Count % 4 != 0) ? (list.Count / 4 + 1) : (list.Count / 4));
		((GObject)curIntegral).text = $"{(int)num}";
		((GObject)maxIntegral).text = $"{nextNodeScore}";
		if (curNode == null)
		{
			((GObject)ReceiveBtn).enabled = false;
			((GObject)ReceiveBtn.note).visible = false;
		}
		else
		{
			((GObject)ReceiveBtn).enabled = true;
			((GObject)ReceiveBtn.note).visible = true;
		}
		if (!showLastScore)
		{
			SetInitBonusPage(slow: true);
		}
		else
		{
			SetInitBonusPage();
		}
		((GObject)integralNodeList).TweenFade(((GObject)integralNodeList).alpha, 0.5f).OnComplete((GTweenCallback)delegate
		{
			UpIntegralNode();
		});
	}

	private void PageTurning(EventContext context)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (!inMotion)
		{
			int direction = (int)((GObject)(GButton)context.sender).data;
			PageRefresh(direction, slow: true);
		}
	}

	private void PageRefresh(int direction, bool slow = false, float slowTime = 1f)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		GComponent asCom = ((GComponent)integralNodeList).GetChildAt(0).asCom;
		float num = (float)(1 - curBonusPage) * ((GObject)integralNodeList).width;
		if (slow)
		{
			inMotion = true;
			integralMoveGTweener = ((GObject)asCom).TweenMoveX(num - (float)direction * ((GObject)integralNodeList).width, slowTime).OnComplete((GTweenCallback)delegate
			{
				UpdateBar();
				inMotion = false;
			}).OnUpdate(new GTweenCallback(UpIntegralNode));
		}
		else
		{
			((GObject)asCom).x = num - (float)direction * ((GObject)integralNodeList).width;
		}
		curBonusPage += direction;
		SetPageBtnStatus();
	}

	private void UpIntegralNode()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		foreach (GButton integralButton in integralButtonList)
		{
			if (!((GObject)integralButton).isDisposed)
			{
				Vector2 val = ((GObject)integralButton).LocalToGlobal(Vector2.one / 2f);
				bool visible = ((!(val.x < ((GObject)integralNodeList).x - ((GObject)integralNodeList).width / 2f) && !(val.x > ((GObject)integralNodeList).x + ((GObject)integralNodeList).width / 2f)) ? true : false);
				GComponent asCom = ((GComponent)integralButton).GetChild("nodeBtn").asCom;
				((GObject)asCom.GetChild("leftIcon").asCom.GetChild("SfxBack").asGraph).visible = visible;
				((GObject)asCom.GetChild("rightIcon").asCom.GetChild("SfxBack").asGraph).visible = visible;
				((GObject)asCom.GetChild("middleIcon").asCom.GetChild("SfxBack").asGraph).visible = visible;
			}
		}
	}

	private void SetPageBtnStatus()
	{
		if (curBonusPage == 1)
		{
			((GObject)PageTurningLeftBtn).enabled = false;
			((GObject)PageTurningRightBtn).enabled = true;
		}
		else if (curBonusPage == TotalBonusesPage)
		{
			((GObject)PageTurningLeftBtn).enabled = true;
			((GObject)PageTurningRightBtn).enabled = false;
		}
		else
		{
			((GObject)PageTurningLeftBtn).enabled = true;
			((GObject)PageTurningRightBtn).enabled = true;
		}
	}

	private void SetInitBonusPage(bool slow = false, float slowTime = 1f)
	{
		if (nextNode == null && curNode == null)
		{
			GComponent asCom = ((GComponent)integralNodeList).GetChildAt(0).asCom;
			initBonusPage = (int)asCom.GetChild("bar").asProgress.value / 25 + 1;
		}
		else if (curNode != null)
		{
			initBonusPage = (int)((GObject)curNode).x / (int)((GObject)integralNodeList).width + 1;
		}
		else if (nextNode != null)
		{
			initBonusPage = (int)((GObject)nextNode).x / (int)((GObject)integralNodeList).width + 1;
		}
		int num = initBonusPage - curBonusPage;
		if (num != 0)
		{
			if (inMotion && integralMoveGTweener != null)
			{
				integralMoveGTweener.Kill(true);
			}
			if (slow)
			{
				PageRefresh(num, slow: true, slowTime);
			}
			else
			{
				PageRefresh(num);
			}
		}
	}

	private void RendererActivityRewardList(int num)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		activityRewardList.itemRenderer = new ListItemRenderer(ActivityRewardListRenderer);
		activityRewardList.numItems = num;
	}

	private void RndererMissionList(GList selectList)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		int count = curActivity.ContentPayload(GameManagers.Instance).Count;
		selectList.itemRenderer = new ListItemRenderer(MissionListRenderer);
		selectList.numItems = count;
		if (count > 4)
		{
			selectList.lineGap = 3;
		}
		else
		{
			selectList.lineGap = 11;
		}
	}

	private void SetLevelCardXY(Vector2 aimPos)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		float num = ((GObject)MapIcon).x + ((GObject)MapIcon).width / 2f;
		if (aimPos.x < num)
		{
			((GObject)LevelCardPanel.Dailog).x = aimPos.x + 65.5f + 202f;
		}
		else
		{
			((GObject)LevelCardPanel.Dailog).x = aimPos.x - 65.5f - 202f;
		}
	}

	private void SetNeutralDungeonLevelCardXY(Vector2 aimPos)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		float num = ((GObject)MapIcon).x + ((GObject)MapIcon).width / 2f;
		if (aimPos.x < num)
		{
			((GObject)NeutralDungeonPanel.LevelCardPanel.Dialog).x = aimPos.x + 65.5f + 202f;
		}
		else
		{
			((GObject)NeutralDungeonPanel.LevelCardPanel.Dialog).x = aimPos.x - 65.5f - 202f;
		}
	}

	private IEnumerator RefreshTimeLimitLevelStatus()
	{
		while (true)
		{
			for (int i = 0; i < TimeLimitLevelBtns.Count; i++)
			{
				UI_LevelBtn _btn = TimeLimitLevelBtns[i];
				if (_btn.AvailableStatus.selectedIndex != 0)
				{
					continue;
				}
				ChapterActivityPayload contentPayload = (ChapterActivityPayload)((GObject)_btn).data;
				if (contentPayload.LevelProgress(GameManagers.Instance) == null || contentPayload.LevelProgress(GameManagers.Instance).Count == 0)
				{
					_btn.AvailableStatus.selectedIndex = 1;
					_btn.CombatStatus.selectedIndex = 0;
					continue;
				}
				switch (contentPayload.LevelProgress(GameManagers.Instance)[0].Value)
				{
				case LevelStatus.Pending:
					_btn.AvailableStatus.selectedIndex = 1;
					_btn.CombatStatus.selectedIndex = 0;
					break;
				case LevelStatus.Battling:
					_btn.AvailableStatus.selectedIndex = 1;
					_btn.CombatStatus.selectedIndex = 1;
					break;
				case LevelStatus.Completed:
				{
					_btn.CombatStatus.selectedIndex = 0;
					DateTimeOffset timeData = contentPayload.GetLevelCooldownRecord(contentPayload.Activity.ActivityProgress(GameManagers.Instance))[contentPayload.Levels(GameManagers.Instance)[0].LevelId];
					TimeSpan curTimeSpan = timeData - DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime());
					if (curTimeSpan.TotalSeconds <= 0.0)
					{
						_btn.AvailableStatus.selectedIndex = 1;
						break;
					}
					_btn.AvailableStatus.selectedIndex = 0;
					double _time = ((curTimeSpan.TotalSeconds < 0.0) ? 0.0 : curTimeSpan.TotalSeconds);
					((GObject)_btn.countDown).text = string.Format("{0}S{1}", Convert.ToInt32(_time), LanguagesManager.GetDesc("CsharpCodeZhTcText287"));
					break;
				}
				}
			}
			yield return (object)new WaitForSeconds(1f);
		}
	}

	private void PlayMissileSfx()
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		if (curNode != null && missibleSfxBack != null)
		{
			Vector2 val = ((GObject)curNode.GetChild("nodeBtn").asCom.GetChild("leftIcon").asCom.GetChild("SfxBack").asGraph).LocalToGlobal(Vector2.one / 2f);
			val = ((GObject)this).GlobalToLocal(val);
			((GObject)missibleSfxBack).SetXY(val.x, val.y);
			FGUIManager.Instance.AddTextSpecialEffects(missibleSfxBack, "exp_missile_green", Vector3.zero);
			((GObject)missibleSfxBack).TweenMove(((GObject)missbleEndPos).xy, 0.5f);
			UiAudioManager.Instance.PlaySoundEffect("Missile");
		}
	}

	private void LevelBtnCliclEvent(EventContext context)
	{
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		UI_LevelBtn uI_LevelBtn = (UI_LevelBtn)(object)context.sender;
		if (uI_LevelBtn.AvailableStatus.selectedIndex == 0 || uI_LevelBtn.AvailableStatus.selectedIndex == 2)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText277") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		curSelectedTimeLimitLevelIndex = TimeLimitLevelBtns.IndexOf(uI_LevelBtn);
		if (curSelectedTimeLimitLevelIndex < 0 || curSelectedTimeLimitLevelIndex > TimeLimitLevelBtns.Count - 1)
		{
			return;
		}
		UpdateLevelBtnsSelectedStatus();
		ChapterActivityPayload contentPayload = (ChapterActivityPayload)((GObject)uI_LevelBtn).data;
		RenderTimeLevelCard(contentPayload);
		SetLevelCardXY(((GObject)uI_LevelBtn).xy);
		((GObject)LevelCardPanel).visible = true;
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("DungeonInstancePanel.LevelMassButton");
		instance.Unregister("DungeonInstancePanel.FirstLevelMassButton");
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		UI_assembledBtn assembledBtn = LevelCardPanel.Dailog.assembledBtn;
		for (int i = 0; i < TimeLimitLevelBtns.Count; i++)
		{
			dictionary.Add($"{i + 1}", assembledBtn);
			if (i == 0)
			{
				instance.Register("DungeonInstancePanel.FirstLevelMassButton", assembledBtn);
			}
		}
		instance.Register("DungeonInstancePanel.LevelMassButton", dictionary);
	}

	private void LevelBtnClickEvent_NeutralDungeon(EventContext context)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		UI_Btn_NeutralLevelBtn uI_Btn_NeutralLevelBtn = (UI_Btn_NeutralLevelBtn)(object)context.sender;
		ChapterActivityPayload contentPayload = (ChapterActivityPayload)((GObject)uI_Btn_NeutralLevelBtn).data;
		curSelectedNeutralDungeonLevelIndex = NeutralDungeonLevelBtns.IndexOf(uI_Btn_NeutralLevelBtn);
		if (curSelectedNeutralDungeonLevelIndex < 0 || curSelectedNeutralDungeonLevelIndex >= NeutralDungeonLevelBtns.Count)
		{
			return;
		}
		UpdateLevelBtnsSelectedStatus();
		RenderNeutralDungeonLevelCard(contentPayload);
		SetNeutralDungeonLevelCardXY(((GObject)uI_Btn_NeutralLevelBtn).xy);
		((GObject)NeutralDungeonPanel.LevelCardPanel).visible = true;
		UiTagManager instance = UiTagManager.Instance;
		instance.Unregister("DungeonInstancePanel.LevelMassButton");
		instance.Unregister("DungeonInstancePanel.FirstLevelMassButton");
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		UI_assembledBtn assembledBtn = NeutralDungeonPanel.LevelCardPanel.Dialog.assembledBtn;
		for (int i = 0; i < NeutralDungeonLevelBtns.Count; i++)
		{
			dictionary.Add($"{i + 1}", assembledBtn);
			if (i == 0)
			{
				instance.Register("DungeonInstancePanel.FirstLevelMassButton", assembledBtn);
			}
		}
		instance.Register("DungeonInstancePanel.LevelMassButton", dictionary);
	}

	private void UpdateLevelBtnsSelectedStatus()
	{
		for (int i = 0; i < TimeLimitLevelBtns.Count; i++)
		{
			if (curSelectedTimeLimitLevelIndex == i)
			{
				TimeLimitLevelBtns[i].SelecedtStatus.selectedIndex = 1;
			}
			else
			{
				TimeLimitLevelBtns[i].SelecedtStatus.selectedIndex = 0;
			}
		}
		for (int j = 0; j < NeutralDungeonLevelBtns.Count; j++)
		{
			if (curSelectedNeutralDungeonLevelIndex == j)
			{
				NeutralDungeonLevelBtns[j].SelecedtStatus.selectedIndex = 1;
			}
			else
			{
				NeutralDungeonLevelBtns[j].SelecedtStatus.selectedIndex = 0;
			}
		}
	}

	private void RenderTimeLevelCard(ChapterActivityPayload contentPayload)
	{
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Expected O, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		if (contentPayload?.Chapter == null)
		{
			Debug.LogError((object)("活动" + curActivity.ActivityId + "没有配置章节"));
			return;
		}
		if (contentPayload.Levels(GameManagers.Instance).Count < 1)
		{
			Debug.LogError((object)("活动" + curActivity.ActivityId + "没有配置关卡"));
			return;
		}
		if (contentPayload.IsPortal)
		{
			LevelCardPanel.Dailog.Type.selectedIndex = 1;
		}
		else
		{
			LevelCardPanel.Dailog.Type.selectedIndex = 0;
		}
		for (int i = 0; i < 4; i++)
		{
			((GComponent)LevelCardPanel.Dailog).GetChild($"reward{i}").visible = false;
		}
		bool visible = true;
		((GObject)LevelCardPanel.Dailog.quickBtn).visible = visible;
		((GObject)LevelCardPanel.Dailog.quickBtn).onClick.Set(new EventCallback1(TimeLimitLevelQuickSwitch));
		((GObject)LevelCardPanel.Dailog.quickBtn).data = contentPayload;
		CanQuickPlayTimeLimitLevel(contentPayload);
		if (contentPayload.Levels(GameManagers.Instance).Count > 0)
		{
			Level level = contentPayload.Levels(GameManagers.Instance).First();
			int num = 0;
			foreach (KeyValuePair<string, string> item in level.BonusDesc)
			{
				int num2 = num;
				((GComponent)LevelCardPanel.Dailog).GetChild($"reward{num2}").visible = true;
				if (item.Key == "UserExp")
				{
					FGUIManager.Instance.SetItemIconAndFrame(((GComponent)LevelCardPanel.Dailog).GetChild($"rewardIcon{num2}").asLoader, item.Key, textureList);
				}
				else
				{
					((GComponent)LevelCardPanel.Dailog).GetChild($"rewardIcon{num2}").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(item.Key);
				}
				((GComponent)LevelCardPanel.Dailog).GetChild($"rewardNum{num}").text = item.Value;
				num++;
				((GComponent)LevelCardPanel.Dailog).GetChild($"rewardIcon{num2}").onClick.Set((EventCallback0)delegate
				{
					UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
					FGUIManager.Instance.ItemTip(item.Key, ((GObject)this).sortingOrder, noCheckBtn: true);
				});
			}
			((GObject)((GComponent)LevelCardPanel.Dailog).GetChild("missionName").asTextField).text = level.Name ?? "";
			float recommendPower = contentPayload.Chapter.RecommendPower;
			((GObject)((GComponent)LevelCardPanel.Dailog).GetChild("combat").asTextField).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(recommendPower.ToString("F0"));
			curCombat = GetCurLegionCombat(level.SoldierFilters);
			((GComponent)LevelCardPanel.Dailog).GetChild("curPower").text = $"({curCombat})";
			Color32 val = (((float)curCombat >= recommendPower) ? new Color32((byte)23, (byte)137, (byte)20, byte.MaxValue) : new Color32((byte)196, (byte)29, (byte)25, byte.MaxValue));
			((GComponent)LevelCardPanel.Dailog).GetChild("combat").asTextField.color = Color32.op_Implicit(val);
		}
		GButton assembledBtn = ((GComponent)LevelCardPanel.Dailog).GetChild("assembledBtn").asButton;
		((GObject)((GObject)assembledBtn).asButton).onClick.Set((EventCallback0)delegate
		{
			if (LevelCardPanel.Dailog.quickBtn.Status.selectedIndex == 1)
			{
				if (CanPlayQuickBattle(contentPayload, 0))
				{
					QuickPlayReplayService.MaxBattleCount = GameManagers.Instance.StockController.GetStock(curActivity.TicketItem);
					QuickPlayReplayService.CurTicketIcon = UiHelper.GetIcon(curActivity.TicketItem);
					if (parametersTemp.ContainsKey("Parent"))
					{
						parametersTemp.Remove("Parent");
					}
					QuickPlayReplayService.returnUiParams = parametersTemp;
					QuickPlayReplayService.returnUiName = curActivity.UiName;
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_QuickBattlePanel.Name, new Dictionary<string, object>
					{
						{
							"CurLevel",
							contentPayload.Levels(GameManagers.Instance)[0]
						},
						{ "IsPortal", contentPayload.IsPortal },
						{ "Type", 0 },
						{ "OurFormationId", curActivityFormationId }
					});
					CloseLevelCard();
				}
			}
			else
			{
				MakeWar(assembledBtn, contentPayload, 0);
			}
		});
	}

	private void RenderNeutralDungeonLevelCard(ChapterActivityPayload contentPayload)
	{
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Expected O, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Expected O, but got Unknown
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		if (contentPayload?.Chapter == null)
		{
			Debug.LogError((object)("活动" + curActivity.ActivityId + "没有配置章节"));
			return;
		}
		if (contentPayload.Levels(GameManagers.Instance).Count < 1)
		{
			Debug.LogError((object)("活动" + curActivity.ActivityId + "没有配置关卡"));
			return;
		}
		UI_Com_NeutralLevelCard neutralLevelCard = NeutralDungeonPanel.LevelCardPanel.Dialog;
		int num = 0;
		while (true)
		{
			GObject child = ((GComponent)neutralLevelCard).GetChild($"reward{num++}");
			if (child == null || num > 100)
			{
				break;
			}
			child.visible = false;
		}
		bool visible = true;
		((GObject)neutralLevelCard.quickBtn).visible = visible;
		((GObject)neutralLevelCard.quickBtn).onClick.Set(new EventCallback1(NeutralDungeonLevelQuickSwitch));
		((GObject)neutralLevelCard.quickBtn).data = contentPayload;
		CanQuickPlayNeutralDungeonLevel(contentPayload);
		if (contentPayload.Levels(GameManagers.Instance).Count > 0)
		{
			Level level = contentPayload.Levels(GameManagers.Instance).First();
			int num2 = 0;
			foreach (KeyValuePair<string, string> item in level.BonusDesc)
			{
				int num3 = num2;
				((GComponent)neutralLevelCard).GetChild($"reward{num3}").visible = true;
				if (item.Key == "UserExp")
				{
					FGUIManager.Instance.SetItemIconAndFrame(((GComponent)neutralLevelCard).GetChild($"rewardIcon{num3}").asLoader, item.Key, textureList);
				}
				else
				{
					((GComponent)neutralLevelCard).GetChild($"rewardIcon{num3}").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(item.Key);
				}
				((GComponent)neutralLevelCard).GetChild($"rewardNum{num2}").text = item.Value;
				num2++;
				((GComponent)neutralLevelCard).GetChild($"rewardIcon{num3}").onClick.Set((EventCallback0)delegate
				{
					UiAudioManager.Instance.PlaySoundEffect("GeneralClick");
					FGUIManager.Instance.ItemTip(item.Key, ((GObject)this).sortingOrder, noCheckBtn: true);
				});
			}
			((GObject)((GComponent)neutralLevelCard).GetChild("missionName").asTextField).text = level.Name ?? "";
			float recommendPower = contentPayload.Chapter.RecommendPower;
			((GObject)((GComponent)neutralLevelCard).GetChild("combat").asTextField).text = UiHelper.RemoveSurplusZeroBehindDecimalPoint(recommendPower.ToString("F0"));
			curCombat = GetCurLegionCombat(level.SoldierFilters);
			((GComponent)neutralLevelCard).GetChild("curPower").text = $"({curCombat})";
			Color32 val = (((float)curCombat >= recommendPower) ? new Color32((byte)23, (byte)137, (byte)20, byte.MaxValue) : new Color32((byte)196, (byte)29, (byte)25, byte.MaxValue));
			((GComponent)neutralLevelCard).GetChild("combat").asTextField.color = Color32.op_Implicit(val);
		}
		GButton assembledBtn = ((GComponent)neutralLevelCard).GetChild("assembledBtn").asButton;
		((GObject)((GObject)assembledBtn).asButton).onClick.Set((EventCallback0)delegate
		{
			if (neutralLevelCard.quickBtn.Status.selectedIndex == 1)
			{
				if (CanPlayQuickBattle(contentPayload, 0))
				{
					QuickPlayReplayService.MaxBattleCount = GameManagers.Instance.StockController.GetStock(curActivity.TicketItem);
					QuickPlayReplayService.CurTicketIcon = UiHelper.GetIcon(curActivity.TicketItem);
					if (parametersTemp.ContainsKey("Parent"))
					{
						parametersTemp.Remove("Parent");
					}
					QuickPlayReplayService.returnUiParams = parametersTemp;
					QuickPlayReplayService.returnUiName = curActivity.UiName;
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_QuickBattlePanel.Name, new Dictionary<string, object>
					{
						{
							"CurLevel",
							contentPayload.Levels(GameManagers.Instance)[0]
						},
						{ "IsPortal", contentPayload.IsPortal },
						{ "Type", 0 },
						{ "OurFormationId", curActivityFormationId }
					});
					CloseLevelCard();
				}
			}
			else
			{
				MakeWar(assembledBtn, contentPayload, 0);
			}
		});
	}

	public void SetQuickBattlePanelBackVisible(bool _visible, float alpha = 1f)
	{
		((GObject)QuickBattlePanelBack).visible = _visible;
		if (_visible)
		{
			((GObject)QuickBattlePanelBack.Mask).alpha = alpha;
			((GObject)QuickBattlePanelBack).sortingOrder = 10001;
		}
		else
		{
			GameController.Contexts.Service<BaseSceneService>().EnableMainCity(new Dictionary<MainCityEnableCommand, bool>
			{
				{
					MainCityEnableCommand.MonoBehaviour,
					true
				},
				{
					MainCityEnableCommand.Produce,
					true
				}
			});
		}
	}

	private void CanQuickPlayTimeLimitLevel(ChapterActivityPayload contentPayload)
	{
		if (((GObject)MapEntrance).visible)
		{
			string levelId = contentPayload.Levels(GameManagers.Instance)[0].LevelId;
			bool flag = GameManagers.Instance.UserArchiveManager.IsLevelCompleted(levelId);
			Dictionary<string, int> value = GameManagers.Instance.ActivityManager.ActivityMaxDifficultyLevels.GetValue();
			if (!flag || !value.TryGetValue(ActivityType.TimeLimitInstance.ToString(), out var value2) || value2 < 1)
			{
				LevelCardPanel.Dailog.quickBtn.Status.selectedIndex = 0;
			}
			else
			{
				LevelCardPanel.Dailog.quickBtn.Status.selectedIndex = GetQuickBtnStatus(levelId);
			}
		}
		else
		{
			LevelCardPanel.Dailog.quickBtn.Status.selectedIndex = 2;
		}
	}

	private void CanQuickPlayNeutralDungeonLevel(ChapterActivityPayload contentPayload)
	{
		string levelId = contentPayload.Levels(GameManagers.Instance)[0].LevelId;
		if (!GameManagers.Instance.UserArchiveManager.IsLevelCompleted(levelId))
		{
			NeutralDungeonPanel.LevelCardPanel.Dialog.quickBtn.Status.selectedIndex = 2;
		}
		else
		{
			NeutralDungeonPanel.LevelCardPanel.Dialog.quickBtn.Status.selectedIndex = GetQuickBtnStatus(levelId);
		}
	}

	private bool CanQuickPlayDefensiveLevel(ChapterActivityPayload contentPayload, UI_PropetryLock _quickBtn)
	{
		if (curActivity.GetUnlockedContentLength(GameManagers.Instance) < 4)
		{
			_quickBtn.Status.selectedIndex = 2;
			return false;
		}
		string levelId = contentPayload.Levels(GameManagers.Instance)[0].LevelId;
		if (!GameManagers.Instance.UserArchiveManager.IsLevelCompleted(levelId))
		{
			_quickBtn.Status.selectedIndex = 0;
			return false;
		}
		_quickBtn.Status.selectedIndex = GetQuickBtnStatus(levelId);
		return true;
	}

	private int GetQuickBtnStatus(string _levelId)
	{
		if (quickBattleSwitch.Contains(_levelId))
		{
			return 1;
		}
		return 0;
	}

	private bool CanQuickPlayOffensiveLevel(UI_PropetryLock _quickBtn, string _levelId)
	{
		if (GameManagers.Instance.ChapterManager.GetTotalClearStagesByActivity(curActivity.ActivityId) <= 675)
		{
			_quickBtn.Status.selectedIndex = 2;
			return false;
		}
		_quickBtn.Status.selectedIndex = GameLocalDataManager.GetOffensiveInstanceZoneQuickBattleSwitch();
		return true;
	}

	private void OffensiveLevelQuickSwitch(EventContext context)
	{
		UI_PropetryLock uI_PropetryLock = (UI_PropetryLock)(object)context.sender;
		if (uI_PropetryLock.Status.selectedIndex == 2)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText288") + "675" + LanguagesManager.GetDesc("CsharpCodeZhTcText289") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 999, arg3: false);
			return;
		}
		if (uI_PropetryLock.Status.selectedIndex == 1)
		{
			uI_PropetryLock.Status.selectedIndex = 0;
		}
		else if (uI_PropetryLock.Status.selectedIndex == 0)
		{
			uI_PropetryLock.Status.selectedIndex = 1;
		}
		GameLocalDataManager.SetOffensiveInstanceZoneQuickBattleSwitch(uI_PropetryLock.Status.selectedIndex);
	}

	private void DefensiveLevelQuickSwitch(EventContext context)
	{
		UI_PropetryLock uI_PropetryLock = (UI_PropetryLock)(object)context.sender;
		if (uI_PropetryLock.Status.selectedIndex == 2)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText286") + "4" + LanguagesManager.GetDesc("CsharpCodeZhTcText289") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 999, arg3: false);
			return;
		}
		ChapterActivityPayload chapterActivityPayload = ((GObject)uI_PropetryLock).data as ChapterActivityPayload;
		string levelId = chapterActivityPayload.Levels(GameManagers.Instance)[0].LevelId;
		if (!GameManagers.Instance.UserArchiveManager.IsLevelCompleted(levelId))
		{
			List<string> arg2 = new List<string>
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText278"),
				"（" + LanguagesManager.GetDesc("CsharpCodeZhTcText290") + "）"
			};
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 999, arg3: false);
		}
		else
		{
			UpdateQuickBattleSwitch(levelId, uI_PropetryLock);
		}
	}

	private void UpdateQuickBattleSwitch(string _levelId, UI_PropetryLock switchBtn)
	{
		if (switchBtn.Status.selectedIndex == 1)
		{
			switchBtn.Status.selectedIndex = 0;
			if (quickBattleSwitch.Contains(_levelId))
			{
				quickBattleSwitch.Remove(_levelId);
			}
		}
		else if (switchBtn.Status.selectedIndex == 0)
		{
			switchBtn.Status.selectedIndex = 1;
			if (!quickBattleSwitch.Contains(_levelId))
			{
				quickBattleSwitch.Add(_levelId);
			}
		}
		GameLocalDataManager.SetInstanceZoneQuickBattleSwitch(quickBattleSwitch);
	}

	private void TimeLimitLevelQuickSwitch(EventContext context)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		if (LevelCardPanel.Dailog.quickBtn.Status.selectedIndex == 2)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText279") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 999, arg3: false);
			return;
		}
		ChapterActivityPayload chapterActivityPayload = ((GObject)context.sender).data as ChapterActivityPayload;
		Dictionary<string, int> value = GameManagers.Instance.ActivityManager.ActivityMaxDifficultyLevels.GetValue();
		if (!value.TryGetValue(ActivityType.TimeLimitInstance.ToString(), out var value2) || value2 < 1)
		{
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText280") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 999, arg3: false);
			return;
		}
		string levelId = chapterActivityPayload.Levels(GameManagers.Instance)[0].LevelId;
		if (!GameManagers.Instance.UserArchiveManager.IsLevelCompleted(levelId))
		{
			List<string> arg3 = new List<string>
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText278"),
				"（" + LanguagesManager.GetDesc("CsharpCodeZhTcText290") + "）"
			};
			SharedMessenger.Broadcast("SHOW_TIPS", arg3, 999, arg3: false);
		}
		else
		{
			UpdateQuickBattleSwitch(levelId, LevelCardPanel.Dailog.quickBtn);
		}
	}

	private void NeutralDungeonLevelQuickSwitch(EventContext context)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		if (NeutralDungeonPanel.LevelCardPanel.Dialog.quickBtn.Status.selectedIndex == 2)
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText278") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 999, arg3: false);
			return;
		}
		ChapterActivityPayload chapterActivityPayload = ((GObject)context.sender).data as ChapterActivityPayload;
		string levelId = chapterActivityPayload.Levels(GameManagers.Instance)[0].LevelId;
		if (!GameManagers.Instance.UserArchiveManager.IsLevelCompleted(levelId))
		{
			List<string> arg2 = new List<string>
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText278"),
				"（" + LanguagesManager.GetDesc("CsharpCodeZhTcText290") + "）"
			};
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 999, arg3: false);
		}
		else
		{
			UpdateQuickBattleSwitch(levelId, NeutralDungeonPanel.LevelCardPanel.Dialog.quickBtn);
		}
	}

	private int GetCurLegionCombat(List<List<string>> filters)
	{
		string text = GameController.Contexts.Service<IBattleFieldService>().Level?.FormationContext ?? ChapterType.StoryMain.ToString();
		string text2 = GameController.Contexts.Service<IBattleFieldService>().Level?.BattleMode.ToString() ?? BattleMode.RushMode.ToString();
		var source = from sid in GameManagers.Instance.StockController.GetOwnedSoldiers(onlyUnlocked: true).Keys
			select new
			{
				sid = sid,
				s = GameManagers.Instance.SoldierManager.Get(sid)
			} into t
			orderby t.s.CombatPower * Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(t.s.Id, t.s.Level) descending
			select t;
		List<Soldier> list = new List<Soldier>();
		list.AddRange(source.Select(t => t.s));
		UiHelper.FiltrateSoldiersByRace(filters, list);
		int num = 0;
		for (int num2 = 0; num2 < 5 && num2 <= list.Count - 1; num2++)
		{
			num += list[num2].CombatPower * Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(list[num2].Id, list[num2].Level);
		}
		return num;
	}

	private void CloseLevelCard()
	{
		curSelectedTimeLimitLevelIndex = -1;
		((GObject)LevelCardPanel).visible = false;
		UpdateLevelBtnsSelectedStatus();
	}

	private void CloseNeutralDungeonLevelCard()
	{
		curSelectedNeutralDungeonLevelIndex = -1;
		((GObject)NeutralDungeonPanel.LevelCardPanel).visible = false;
		UpdateLevelBtnsSelectedStatus();
	}

	private void CleanLevelBtns()
	{
		for (int num = TimeLimitLevelBtns.Count - 1; num >= 0; num--)
		{
			((GComponent)this).RemoveChild((GObject)(object)TimeLimitLevelBtns[num], true);
		}
		TimeLimitLevelBtns.Clear();
		for (int num2 = NeutralDungeonLevelBtns.Count - 1; num2 >= 0; num2--)
		{
			((GComponent)NeutralDungeonPanel).RemoveChild((GObject)(object)NeutralDungeonLevelBtns[num2], true);
		}
		NeutralDungeonLevelBtns.Clear();
	}

	private void RenderMissionList()
	{
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Expected O, but got Unknown
		//IL_064a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Expected O, but got Unknown
		((GObject)MapEntrance).sortingOrder = 9999;
		CleanLevelBtns();
		int num = 0;
		Dictionary<string, ActivityContentPayload> dictionary = curActivity.ContentPayload(GameManagers.Instance);
		foreach (KeyValuePair<string, ActivityContentPayload> item in curActivity.ContentPayload(GameManagers.Instance))
		{
			ChapterActivityPayload chapterActivityPayload = item.Value as ChapterActivityPayload;
			if (chapterActivityPayload != null && chapterActivityPayload.IsPortal)
			{
				RenderPortalLevel(chapterActivityPayload);
				continue;
			}
			UI_LevelBtn levelBtn = UI_LevelBtn.CreateInstance_ILRuntime();
			TimeLimitLevelBtns.Add(levelBtn);
			((GComponent)this).AddChild((GObject)(object)levelBtn);
			((GObject)levelBtn).data = chapterActivityPayload;
			int num2 = 0;
			if (chapterActivityPayload.IconPosition == null || chapterActivityPayload.IconPosition.Length < 2 || (Mathf.Abs(chapterActivityPayload.IconPosition[0] - 0f) < float.Epsilon && Mathf.Abs(chapterActivityPayload.IconPosition[1] - 0f) < float.Epsilon))
			{
				int index = num % TimeLimitLevelPoisitions.Count;
				((GObject)levelBtn).xy = TimeLimitLevelPoisitions[index].Value;
				num2 = TimeLimitLevelPoisitions[index].Key;
			}
			else
			{
				((GObject)levelBtn).SetXY(chapterActivityPayload.IconPosition[0], chapterActivityPayload.IconPosition[1]);
			}
			if (string.IsNullOrWhiteSpace(chapterActivityPayload.IconUrl))
			{
				levelBtn.icon.url = $"ui://InstanceZones/icon_tent_springfestival_{num2}";
				levelBtn.light.url = $"ui://InstanceZones/icon_tent_springfestival_{num2}_outline";
			}
			else
			{
				levelBtn.icon.url = "ui://InstanceZones/" + chapterActivityPayload.IconUrl;
				levelBtn.light.url = "ui://InstanceZones/" + chapterActivityPayload.IconUrl + "_outline";
			}
			if (chapterActivityPayload.LevelProgress(GameManagers.Instance) == null || chapterActivityPayload.LevelProgress(GameManagers.Instance).Count == 0)
			{
				levelBtn.AvailableStatus.selectedIndex = 1;
				levelBtn.CombatStatus.selectedIndex = 0;
			}
			else
			{
				switch (chapterActivityPayload.LevelProgress(GameManagers.Instance)[0].Value)
				{
				case LevelStatus.Pending:
					levelBtn.AvailableStatus.selectedIndex = 1;
					levelBtn.CombatStatus.selectedIndex = 0;
					break;
				case LevelStatus.Battling:
					levelBtn.AvailableStatus.selectedIndex = 1;
					levelBtn.CombatStatus.selectedIndex = 1;
					break;
				case LevelStatus.Completed:
				{
					levelBtn.CombatStatus.selectedIndex = 0;
					DateTimeOffset dateTimeOffset = chapterActivityPayload.GetLevelCooldownRecord(chapterActivityPayload.Activity.ActivityProgress(GameManagers.Instance))[chapterActivityPayload.Levels(GameManagers.Instance)[0].LevelId];
					TimeSpan timeSpan = dateTimeOffset - DateTimeHelper.Parse((int)GameController.Instance.GetServerTime());
					if (timeSpan.TotalSeconds <= 0.0)
					{
						levelBtn.AvailableStatus.selectedIndex = 1;
						break;
					}
					levelBtn.AvailableStatus.selectedIndex = 0;
					double value = ((timeSpan.TotalSeconds < 0.0) ? 0.0 : timeSpan.TotalSeconds);
					((GObject)levelBtn.countDown).text = string.Format("{0}S{1}", Convert.ToInt32(value), LanguagesManager.GetDesc("CsharpCodeZhTcText287"));
					break;
				}
				}
			}
			Level level = chapterActivityPayload.Levels(GameManagers.Instance).First();
			GetCurLevelFormationId(level.LevelId);
			if (!string.IsNullOrWhiteSpace(CompletedLevelId) && CompletedLevelId == level.LevelId)
			{
				levelBtn.AvailableStatus.selectedIndex = 2;
				levelBtn.CombatStatus.selectedIndex = 1;
				FGUIManager.Instance.AddTextSpecialEffects(levelBtn.SfxBack1, "Smoke96comb", new Vector3(1.5f, 1.5f, 1.5f), "Default", 0.5f, delegate(GameObject smoke96Comb)
				{
					smoke96Comb.AddComponent<HotFix_DestroySelf>().destroyTime = 1.2f;
				});
				((GComponent)(object)this).SetTimeout(1.2f).OnComplete((GTweenCallback)delegate
				{
					//IL_0049: Unknown result type (might be due to invalid IL or missing references)
					levelBtn.AvailableStatus.selectedIndex = 0;
					levelBtn.CombatStatus.selectedIndex = 0;
					FGUIManager.Instance.AddTextSpecialEffects(levelBtn.SfxBack2, "workplaceSmoke_2", new Vector3(2.5f, 2.5f, 2.5f), "Default", 0.5f, delegate(GameObject workplaceSmoke2)
					{
						workplaceSmoke2.AddComponent<HotFix_DestroySelf>().destroyTime = 1.2f;
					});
				});
			}
			levelBtn.SelecedtStatus.selectedIndex = 0;
			int num3 = 0;
			foreach (KeyValuePair<string, string> item2 in level.BonusDesc)
			{
				if ((num3 < 2 || instanceZonesType != InstanceZonesType.Common) && (num3 < 3 || instanceZonesType != InstanceZonesType.Advanced))
				{
					((GComponent)levelBtn).GetChild($"BonusDesc{num3}").visible = true;
					int num4 = num3;
					((GComponent)levelBtn).GetChild($"bonusIcon{num4}").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(item2.Key);
					((GComponent)levelBtn).GetChild($"bonusNum{num3}").text = item2.Value;
					num3++;
				}
			}
			((GObject)levelBtn).onClick.Set(new EventCallback1(LevelBtnCliclEvent));
			num++;
		}
		((GObject)LevelCardPanel).sortingOrder = 10000;
		curSelectedTimeLimitLevelIndex = -1;
	}

	private IEnumerator RenderMissionList_NeutralDungeon()
	{
		if (NeutralDungeonPanel == null || ((GObject)NeutralDungeonPanel).isDisposed || _rendering_NeutralDungeonLevelBtns)
		{
			yield break;
		}
		_rendering_NeutralDungeonLevelBtns = true;
		UI_Com_NeutralMain neutralDungeonPanel = NeutralDungeonPanel;
		((GObject)backBtn).sortingOrder = 10000;
		((GObject)neutralDungeonPanel).sortingOrder = 9999;
		CleanLevelBtns();
		int levelIndex = 1;
		Dictionary<string, ActivityContentPayload> contentPayloads = curActivity.ContentPayload(GameManagers.Instance);
		foreach (KeyValuePair<string, ActivityContentPayload> item2 in contentPayloads)
		{
			ChapterActivityPayload contentPayload = item2.Value as ChapterActivityPayload;
			UI_Btn_NeutralLevelBtn levelBtn = UI_Btn_NeutralLevelBtn.CreateInstance_ILRuntime();
			NeutralDungeonLevelBtns.Add(levelBtn);
			((GComponent)neutralDungeonPanel).AddChild((GObject)(object)levelBtn);
			((GObject)levelBtn).data = contentPayload;
			GObject levelPoint = ((GComponent)neutralDungeonPanel).GetChild($"level{levelIndex++}_pos");
			((GObject)levelBtn).SetXY(levelPoint.x, levelPoint.y);
			if (string.IsNullOrWhiteSpace(contentPayload.IconUrl))
			{
				int.TryParse(levelPoint.data.ToString(), out var levelBtnType);
				levelBtn.icon.url = $"ui://InstanceZones/icon_tent_springfestival_{levelBtnType}";
				levelBtn.light.url = $"ui://InstanceZones/icon_tent_springfestival_{levelBtnType}_outline";
			}
			else
			{
				levelBtn.icon.url = "ui://InstanceZones/" + contentPayload.IconUrl;
				levelBtn.light.url = "ui://InstanceZones/" + contentPayload.IconUrl + "_outline";
			}
			Level _level = contentPayload.Levels(GameManagers.Instance).First();
			GetCurLevelFormationId(_level.LevelId);
			levelBtn.SelecedtStatus.selectedIndex = 0;
			int itemIndex = 0;
			foreach (KeyValuePair<string, string> item in _level.BonusDesc)
			{
				if (itemIndex < 1)
				{
					((GComponent)levelBtn).GetChild($"BonusDesc{itemIndex}").visible = true;
					if (item.Key == "UserExp")
					{
						FGUIManager.Instance.SetItemIconAndFrame(((GComponent)levelBtn).GetChild($"bonusIcon{itemIndex}").asLoader, "UserExp", textureList);
					}
					else
					{
						((GComponent)levelBtn).GetChild($"bonusIcon{itemIndex}").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(item.Key);
					}
					((GComponent)levelBtn).GetChild($"bonusNum{itemIndex}").text = item.Value;
					itemIndex++;
				}
			}
			((GObject)levelBtn).onClick.Set(new EventCallback1(LevelBtnClickEvent_NeutralDungeon));
			((GComponent)levelBtn).GetTransition("showSelf").Play();
			yield return (object)new WaitForEndOfFrame();
		}
		((GObject)neutralDungeonPanel.LevelCardPanel).sortingOrder = 10000;
		curSelectedTimeLimitLevelIndex = -1;
		_rendering_NeutralDungeonLevelBtns = false;
	}

	private void RenderNeutralDungeonTicketTip()
	{
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		if (NeutralDungeonPanel != null && !((GObject)NeutralDungeonPanel).isDisposed)
		{
			Activity activity = FGUIManager.Instance.NeutralDungeonData.Activity;
			int stock = GameManagers.Instance.StockController.GetStock(activity.TicketItem);
			((GObject)NeutralDungeonPanel.TicketTip).text = $"{stock}/3";
			int num = 0;
			NeutralDungeonPanel.ExtraTicket1.c1.selectedIndex = 1;
			if (GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("OverlordContract") > 0)
			{
				num++;
				NeutralDungeonPanel.ExtraTicket1.c1.selectedIndex = 0;
			}
			NeutralDungeonPanel.ExtraTicket2.c1.selectedIndex = 1;
			if (GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("PrimeContract") > 0)
			{
				num++;
				NeutralDungeonPanel.ExtraTicket2.c1.selectedIndex = 0;
			}
			switch (num)
			{
			case 1:
				((GObject)NeutralDungeonPanel.ExtraTicketTip).text = "(+1)";
				break;
			case 2:
				((GObject)NeutralDungeonPanel.ExtraTicketTip).text = "(+2)";
				break;
			default:
				((GObject)NeutralDungeonPanel.ExtraTicketTip).text = "";
				break;
			}
			((GObject)NeutralDungeonPanel.TicketTipsClickCover).onClick.Set(new EventCallback0(JumpToMonthCardPanel));
		}
	}

	private void JumpToMonthCardPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_MonthCardPanel.Name, new Dictionary<string, object>
		{
			{
				"Activity",
				FGUIManager.Instance.GetBlackMarketerActivity("UI_MonthCardPanel")
			},
			{
				"Order",
				((GObject)this).sortingOrder
			},
			{ "Parent", this }
		});
	}

	private void RenderPortalLevel(ChapterActivityPayload contentPayload)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		if (!contentPayload.ShowPortal(GameManagers.Instance))
		{
			((GObject)MapEntrance).visible = false;
			return;
		}
		((GObject)MapEntrance).visible = true;
		MapEntrance.Title.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
		if ((Object)(object)portalSfx == (Object)null)
		{
			portalSfx = FGUIManager.Instance.AddTextSpecialEffects(MapEntrance.SfxContainer, "ui_dungeon_portal_red", new Vector3(80f, 80f, 80f));
		}
		((GObject)MapEntrance).data = contentPayload;
		if (contentPayload.CanPortal(GameManagers.Instance))
		{
			if (instanceZonesType == InstanceZonesType.Common)
			{
				MapEntrance.TypeController.selectedIndex = 1;
			}
			else if (instanceZonesType == InstanceZonesType.Advanced)
			{
				MapEntrance.TypeController.selectedIndex = 2;
			}
			((GObject)MapEntrance.note).visible = contentPayload.PortalTargetActivity.CanClaimBonus(GameManagers.Instance);
			((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
			{
				//IL_0021: Unknown result type (might be due to invalid IL or missing references)
				//IL_002b: Expected O, but got Unknown
				if (!((GObject)this).isDisposed)
				{
					((GObject)MapEntrance).onClick.Set(new EventCallback1(WormholeEvent));
				}
			});
		}
		else
		{
			((GObject)MapEntrance.note).visible = false;
			MapEntrance.TypeController.selectedIndex = 0;
			((GObject)MapEntrance).onClick.Set(new EventCallback1(MapEntranceEvent));
		}
		MapEntrance.SetControllerPageText();
	}

	public void WormholeEvent(EventContext context)
	{
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		((GObject)MapEntrance).onClick.Clear();
		foreach (KeyValuePair<string, ActivityContentPayload> item in curActivity.ContentPayload(GameManagers.Instance))
		{
			if (!(item.Value is ChapterActivityPayload { IsPortal: not false } chapterActivityPayload))
			{
				continue;
			}
			parametersTemp["Type"] = int.Parse(chapterActivityPayload.PortalTargetActivity.UiParams["Type"].ToString());
			curActivity = chapterActivityPayload.PortalTargetActivity;
			parametersTemp["Activity"] = curActivity;
			if (parametersTemp.ContainsKey("GetScore"))
			{
				parametersTemp.Remove("GetScore");
			}
			if (parametersTemp.ContainsKey("LevelId"))
			{
				parametersTemp.Remove("LevelId");
			}
			break;
		}
		curActivityFormationId = "";
		UnityUiService.Instance.ShowScreenSfx(((GObject)MapEntrance).xy, 60f, "ui_dungeon_fullscreen_red", 1f);
		UiAudioManager.Instance.PlayBackgroundSound("Portal");
		((GComponent)(object)this).SetTimeout(0.45f).OnComplete((GTweenCallback)delegate
		{
			((GProgressBar)integralNodeList.IntegralProgress.bar).value = 100.0;
			((GObject)integralNodeList.IntegralProgress).width = 2960f;
			UpdateMainPanel(parametersTemp);
			UpdateBar();
		});
	}

	public void UpdateTimeLimitInstanceZones()
	{
		if (instanceZonesType == InstanceZonesType.Common || instanceZonesType == InstanceZonesType.Advanced)
		{
			parametersTemp["Type"] = PageController.selectedIndex;
			if (parametersTemp.ContainsKey("GetScore"))
			{
				parametersTemp.Remove("GetScore");
			}
			if (parametersTemp.ContainsKey("LevelId"))
			{
				parametersTemp.Remove("LevelId");
			}
			UpdateMainPanel(parametersTemp);
		}
		else
		{
			if (instanceZonesType != InstanceZonesType.Offensive && instanceZonesType != InstanceZonesType.Defensive)
			{
				return;
			}
			List<ActivityType> activityTypes = new List<ActivityType>
			{
				ActivityType.AttackInstance,
				ActivityType.DefenseInstance
			};
			GameManagers.Instance.ActivityManager.CheckActivities(null, activityTypes, delegate
			{
				parametersTemp["Type"] = PageController.selectedIndex;
				if (parametersTemp.ContainsKey("GetScore"))
				{
					parametersTemp.Remove("GetScore");
				}
				if (parametersTemp.ContainsKey("LevelId"))
				{
					parametersTemp.Remove("LevelId");
				}
				GameController.Contexts.Service<IUiService>().OpenPanel(Name, parametersTemp);
			});
		}
	}

	private void MapEntranceEvent(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		ChapterActivityPayload contentPayload = ((GObject)context.sender).data as ChapterActivityPayload;
		RenderTimeLevelCard(contentPayload);
		SetLevelCardXY(((GObject)MapEntrance).xy);
		((GObject)LevelCardPanel).visible = true;
	}

	private void SetText()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		((GObject)activityDescription).text = description;
		((GObject)activityTime).text = time;
		activityTitle.strokeColor = Color32.op_Implicit(new Color32((byte)0, (byte)0, (byte)0, (byte)229));
	}

	public void LoadAnima()
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)titleBonusSpine != (Object)null)
		{
			return;
		}
		ref GameObject reference = ref titleBonusSpine;
		Object obj = Object.Instantiate(Resources.Load("Items/Spine", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		titleBonusSpine.GetComponent<Canvas>().sortingLayerName = "Default";
		SpawnManager.Instance.LoadSoldierSpine(titleBonusSpine, $"{_soldierId}_skin{_soldierEvo}").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			if (!((Object)(object)titleBonusSpine == (Object)null) && !((GObject)this).isDisposed)
			{
				SkeletonGraphic component = ((Component)titleBonusSpine.transform.GetChild(0)).gameObject.GetComponent<SkeletonGraphic>();
				component.skeletonDataAsset = asset;
				component.initialSkinName = $"skin{_soldierEvo}";
				component.Initialize(true);
				((Component)titleBonusSpine.transform.GetChild(0)).gameObject.SetActive(true);
			}
		});
		GoWrapper nativeObject = new GoWrapper(titleBonusSpine);
		AnimaPlaceholder.SetNativeObject((DisplayObject)(object)nativeObject);
		FGUIManager.Instance.AddTextSpecialEffects(baseSpine, "MagicCircleBase", new Vector3(100f, 100f, 100f));
		FGUIManager.Instance.AddTextSpecialEffects(maskSpine, "MagicCircleMask", new Vector3(100f, 100f, 100f));
	}

	private void UpdateBar()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		GComponent asCom = ((GComponent)integralNodeList).GetChildAt(0).asCom;
		double num2 = asCom.GetChild("bar").asProgress.value / 100.0;
		double num3 = (double)((GObject)asCom.GetChild("bar").asProgress).width * num2;
		num = (double)((GObject)asCom.GetChild("bar").asProgress).LocalToGlobal(new Vector2(0f, 0.5f)).x + num3 - (double)(((GObject)integralProgressBackBar).x + 26f);
		if (num <= 0.0)
		{
			((GProgressBar)integralProgressBackBar).value = 0.0;
		}
		else if (num > 0.0 && num < 1317.0)
		{
			((GProgressBar)integralProgressBackBar).value = 2.0;
		}
		else if (num >= 1317.0)
		{
			((GProgressBar)integralProgressBackBar).value = 100.0;
		}
		if (curActivity.Score(GameManagers.Instance) == 0f)
		{
			((GProgressBar)integralProgressBackBar).value = 0.0;
		}
	}

	private void TicketRefreshTimeInit()
	{
		refreshTicketUnix.Clear();
		DateTimeOffset dateTimeOffset = new DateTimeOffset(DateTimeHelper.Now.DateTime, new TimeSpan(8, 0, 0));
		DateTimeOffset dateTimeOffset2 = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime()).Add(dateTimeOffset.Offset);
		for (int i = 0; i < UiHelper.RefreshTicketHours.Count; i++)
		{
			int num = UiHelper.RefreshTicketHours[i];
			DateTimeOffset dateTimeOffset3 = new DateTimeOffset(dateTimeOffset2.Year, dateTimeOffset2.Month, dateTimeOffset2.Day, num, 0, 0, TimeSpan.Zero);
			refreshTicketUnix.Add((int)dateTimeOffset3.ToUnixTimeSeconds(), num);
		}
	}

	private int GetNextTicketRefreshTime()
	{
		DateTimeOffset dateTimeOffset = new DateTimeOffset(DateTimeHelper.Now.DateTime, new TimeSpan(8, 0, 0));
		long num = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime()).Add(dateTimeOffset.Offset).ToUnixTimeSeconds();
		int num2 = 0;
		foreach (KeyValuePair<int, int> item in refreshTicketUnix)
		{
			if (num < item.Key)
			{
				num2 = item.Value;
				if (num2 >= 24)
				{
					num2 %= 24;
				}
				break;
			}
		}
		return num2;
	}

	private IEnumerator UpdateReplenishTime()
	{
		int _hour = GetNextTicketRefreshTime();
		if (nextrefreshTicketHour != _hour)
		{
			nextrefreshTicketHour = _hour;
			FakeAddTicket();
			((GObject)replenishTime).text = string.Format("{0}1{1},{2} {3}:00", LanguagesManager.GetDesc("CsharpCodeZhTcText291"), LanguagesManager.GetDesc("CsharpCodeZhTcText292"), LanguagesManager.GetDesc("CsharpCodeZhTcText293"), nextrefreshTicketHour);
			TicketRefreshTimeInit();
		}
		yield return (object)new WaitForSeconds(30f);
		UpdateReplenishTimeCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateReplenishTime());
	}

	private void ReplenishTimeInit()
	{
		if (UpdateReplenishTimeCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(UpdateReplenishTimeCoroutine);
		}
		TicketRefreshTimeInit();
		UpdateReplenishTimeCoroutine = FGUIManager.Instance.OpenIEnumerator(UpdateReplenishTime());
	}

	private void FakeAddTicket()
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		int stock = GameManagers.Instance.StockController.GetStock(curActivity.TicketItem);
		int num = ((stock + 1 > curActivity.TicketLimit) ? curActivity.TicketLimit : (stock + 1));
		string text = "#F3DDAA";
		if (num <= 0)
		{
			text = "#DC143C";
		}
		((GObject)addWorkerBtn.num).text = UiHelper.ToAddCouponBtnText($"{num}", curActivity.TicketLimit.ShortNumberFormat() ?? "");
		((GObject)addWorkerBtn.num).data = stock;
		FGUIManager.Instance.AddTextSpecialEffects(addWorkerBtn.textBack, FGUIManager.Instance.uiGreen, Vector3.zero, "Default", 0.5f, delegate(GameObject uiGreen)
		{
			UiHelper.DestoryUiSfx(addWorkerBtn.textBack, uiGreen, 1f);
		});
	}

	public void OnAnyLoadingPanelStatus(GameStateEntity entity, LoadingPanelStatus value)
	{
		switch (value)
		{
		case LoadingPanelStatus.Opening:
			UnityUiService.Instance.SetEdgeMaskVisible(UnityUiService.Instance.edgeMaskPanel.ratio <= 1f);
			break;
		case LoadingPanelStatus.Closed:
		case LoadingPanelStatus.Showing:
		case LoadingPanelStatus.Closing:
			break;
		default:
			throw new ArgumentOutOfRangeException("value", value, null);
		}
	}
}
