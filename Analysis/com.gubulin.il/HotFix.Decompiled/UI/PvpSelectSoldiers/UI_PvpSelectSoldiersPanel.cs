using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using Entitas;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.Battle;
using UI.Legion;
using UI.MilitaryAFKAssistant;
using UI.MonthCard;
using UI.QuickBattle;
using UI.Tips;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_PvpSelectSoldiersPanel : GComponent, IUiController, IAnyLoadingPanelStatusListener
{
	private class SelectFormations
	{
		public Dictionary<string, SelectFormation> Data = new Dictionary<string, SelectFormation>();

		public bool CheckValid()
		{
			bool flag = true;
			if (Data == null)
			{
				Data = new Dictionary<string, SelectFormation>();
				for (int i = 0; i < 3; i++)
				{
					Data.Add(i.ToString(), new SelectFormation(i));
				}
			}
			for (int j = 0; j < 3; j++)
			{
				if (!Data.ContainsKey(j.ToString()))
				{
					Data.Add(j.ToString(), new SelectFormation(j));
				}
			}
			List<KeyValuePair<string, SelectFormation>> list = Data.ToList();
			for (int k = 0; k < list.Count; k++)
			{
				flag &= list[k].Value.CheckValid();
				for (int num = list[k].Value.SoldiersId.Count - 1; num >= 0; num--)
				{
					string text = list[k].Value.SoldiersId[num];
					if (string.IsNullOrEmpty(text) || text == "Unlock" || text == "Lock")
					{
						list[k].Value.SoldiersId[num] = "";
					}
				}
			}
			return flag;
		}
	}

	private class SelectFormation
	{
		public int ArrayId { get; set; }

		public List<string> SoldiersId { get; set; } = null;

		public List<SoldierDetail> SoldiersDetail { get; set; } = null;

		public string FormationId { get; set; } = string.Empty;

		public SelectFormation(int ArrayId)
		{
			this.ArrayId = ArrayId;
			CheckValid();
		}

		public void ClearData()
		{
			SoldiersId = null;
			FormationId = string.Empty;
			CheckValid();
		}

		public bool CheckValid()
		{
			if (SoldiersId == null)
			{
				SoldiersId = new List<string> { "", "", "", "", "" };
			}
			if (SoldiersId.Count > 5)
			{
				SoldiersId = SoldiersId.GetRange(0, 5);
			}
			if (string.IsNullOrEmpty(FormationId))
			{
				FormationId = "FA01";
			}
			if (FormationId == string.Empty)
			{
				return false;
			}
			return true;
		}
	}

	public enum ClickResult
	{
		Empty,
		UnNamedFailed,
		ChallengeFailedNotEnoughTroop,
		ChallengeFailedNotFoundEnemy,
		ChallengeSuccess
	}

	public Controller SoldiersStatus;

	public Controller Type;

	public GGraph blackMask;

	public GLoader background;

	public GImage n44;

	public GImage n46;

	public UI_OurInfomationBar OurInfomationBar;

	public UI_EnemyInfomationBar EnemyInfomationBar;

	public UI_ChangeBtn ChallengeBtn;

	public UI_SettingBtn SettingBtn;

	public UI_ClickAssistantBtn clickAssistant;

	public UI_GetSelfRankBtn GetSelfRankBtn;

	public GGraph QuickBattleBackground;

	public UI_QuickBattleStage QuickBattleStage;

	public UI_StandardFormationSketchMap MyStandardFormationSketchMap;

	public UI_EnemyStandardFormationSketchMap EnemyStandardFormationSketchMap;

	public GGraph n53;

	public GImage flashImage_mine;

	public GTextField OurCombat;

	public GTextField n11;

	public GGroup PowerMine;

	public GList EnemyFormationsList;

	public GGraph n54;

	public GImage flashImage_enemy;

	public GTextField EnemyCombat;

	public GTextField n21;

	public GGroup PowerEnemy;

	public GList EnemyFormations;

	public UI_PvpSelectOurFormationsDetialBack FormationsDetialBack;

	public UI_OpenSoliders SoldiersSwitch;

	public GList Soliders;

	public UI_CurFormation CurFormation;

	public UI_PreparationTime PreparationTime;

	public UI_PropetryLock PropetryLock;

	public GGraph TestBack;

	public UI_GetRankBtn GetRankBtn;

	public UI_GetSelfRankBtn SetEnemyDataBtn;

	public GGroup TestBtns;

	public GGraph TestBtnsSwitch;

	public GTextField n37;

	public GGroup Switch;

	public GButton backBtn;

	public GRichTextField n48;

	public GTextField SimpleModeTips;

	public UI_RightGradient n58;

	public UI_LeftGradient n56;

	public UI_LeftGradient n61;

	public GGroup gradientEdges;

	public UI_SeasonBuffLabel SeasonBuffLabel;

	public Transition MainUiFade;

	public const string URL = "ui://82mo10n5gox20";

	public static string Name = "UI_PvpSelectSoldiersPanel";

	public static UI_PvpSelectSoldiersPanel PvpSelectSoldiersPanel;

	public static Func<ClickResult, string, bool> ContinueFailedHandler;

	private GameStateEntity _gameStateEntity;

	private UI_PvpTeamMoveInfo pvpTeamMoveInfoButton;

	private int myRank;

	private string curTouchArrayId;

	private float curTouchFormationBtnY;

	private int curTouchBtnIndex;

	private bool isMouseMoving = false;

	private int curRankBattleCd;

	private Coroutine RankBattleCdCoroutine;

	private const int ArrayNum = 3;

	private List<Formation> unlockFormations = new List<Formation>();

	public List<string> selectedSoldierId = new List<string>();

	private SelectFormations selectFormations = new SelectFormations();

	private string curSelectFormationArrayId;

	private int curSoldierIndex;

	public List<RankSummary> _rankSummaryList;

	public RankSummary aimRankInfo;

	private RankRecord _rankRecord;

	public List<string> selectedEnemySoldierId = new List<string>();

	private SelectFormations selectEnemyFormations = new SelectFormations();

	private string curSelectEnemyFormationArrayId;

	private List<List<GameEntityData>> _enemyUnits;

	private List<List<int>> unitsTotal;

	private List<Dictionary<string, List<RankSoldierEquipmentsInfo>>> enemyEquipments;

	private string NpcName => LanguagesManager.GetDesc("CsharpCodeZhTcText51");

	public static string GetURL()
	{
		return "ui://82mo10n5gox20";
	}

	public static UI_PvpSelectSoldiersPanel CreateInstance()
	{
		return (UI_PvpSelectSoldiersPanel)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpSelectSoldiersPanel");
	}

	public static UI_PvpSelectSoldiersPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpSelectSoldiersPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5gox20", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected O, but got Unknown
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Expected O, but got Unknown
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Expected O, but got Unknown
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected O, but got Unknown
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Expected O, but got Unknown
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected O, but got Unknown
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Expected O, but got Unknown
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SoldiersStatus = ((GComponent)this).GetController("SoldiersStatus");
		Type = ((GComponent)this).GetController("Type");
		blackMask = (GGraph)((GComponent)this).GetChild("blackMask");
		background = (GLoader)((GComponent)this).GetChild("background");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		n46 = (GImage)((GComponent)this).GetChild("n46");
		OurInfomationBar = (UI_OurInfomationBar)(object)((GComponent)this).GetChild("OurInfomationBar");
		EnemyInfomationBar = (UI_EnemyInfomationBar)(object)((GComponent)this).GetChild("EnemyInfomationBar");
		ChallengeBtn = (UI_ChangeBtn)(object)((GComponent)this).GetChild("ChallengeBtn");
		SettingBtn = (UI_SettingBtn)(object)((GComponent)this).GetChild("SettingBtn");
		clickAssistant = (UI_ClickAssistantBtn)(object)((GComponent)this).GetChild("clickAssistant");
		GetSelfRankBtn = (UI_GetSelfRankBtn)(object)((GComponent)this).GetChild("GetSelfRankBtn");
		QuickBattleBackground = (GGraph)((GComponent)this).GetChild("QuickBattleBackground");
		QuickBattleStage = (UI_QuickBattleStage)(object)((GComponent)this).GetChild("QuickBattleStage");
		MyStandardFormationSketchMap = (UI_StandardFormationSketchMap)(object)((GComponent)this).GetChild("MyStandardFormationSketchMap");
		EnemyStandardFormationSketchMap = (UI_EnemyStandardFormationSketchMap)(object)((GComponent)this).GetChild("EnemyStandardFormationSketchMap");
		n53 = (GGraph)((GComponent)this).GetChild("n53");
		flashImage_mine = (GImage)((GComponent)this).GetChild("flashImage_mine");
		OurCombat = (GTextField)((GComponent)this).GetChild("OurCombat");
		n11 = (GTextField)((GComponent)this).GetChild("n11");
		string id = "ui://82mo10n5gox20".Replace("ui://", "") + "-" + ((GObject)n11).id;
		((GObject)n11).text = LanguagesManager.GetDesc(id);
		PowerMine = (GGroup)((GComponent)this).GetChild("PowerMine");
		EnemyFormationsList = (GList)((GComponent)this).GetChild("EnemyFormationsList");
		n54 = (GGraph)((GComponent)this).GetChild("n54");
		flashImage_enemy = (GImage)((GComponent)this).GetChild("flashImage_enemy");
		EnemyCombat = (GTextField)((GComponent)this).GetChild("EnemyCombat");
		n21 = (GTextField)((GComponent)this).GetChild("n21");
		string id2 = "ui://82mo10n5gox20".Replace("ui://", "") + "-" + ((GObject)n21).id;
		((GObject)n21).text = LanguagesManager.GetDesc(id2);
		PowerEnemy = (GGroup)((GComponent)this).GetChild("PowerEnemy");
		EnemyFormations = (GList)((GComponent)this).GetChild("EnemyFormations");
		FormationsDetialBack = (UI_PvpSelectOurFormationsDetialBack)(object)((GComponent)this).GetChild("FormationsDetialBack");
		SoldiersSwitch = (UI_OpenSoliders)(object)((GComponent)this).GetChild("SoldiersSwitch");
		Soliders = (GList)((GComponent)this).GetChild("Soliders");
		CurFormation = (UI_CurFormation)(object)((GComponent)this).GetChild("CurFormation");
		PreparationTime = (UI_PreparationTime)(object)((GComponent)this).GetChild("PreparationTime");
		PropetryLock = (UI_PropetryLock)(object)((GComponent)this).GetChild("PropetryLock");
		TestBack = (GGraph)((GComponent)this).GetChild("TestBack");
		GetRankBtn = (UI_GetRankBtn)(object)((GComponent)this).GetChild("GetRankBtn");
		SetEnemyDataBtn = (UI_GetSelfRankBtn)(object)((GComponent)this).GetChild("SetEnemyDataBtn");
		TestBtns = (GGroup)((GComponent)this).GetChild("TestBtns");
		TestBtnsSwitch = (GGraph)((GComponent)this).GetChild("TestBtnsSwitch");
		n37 = (GTextField)((GComponent)this).GetChild("n37");
		string id3 = "ui://82mo10n5gox20".Replace("ui://", "") + "-" + ((GObject)n37).id;
		((GObject)n37).text = LanguagesManager.GetDesc(id3);
		Switch = (GGroup)((GComponent)this).GetChild("Switch");
		backBtn = (GButton)((GComponent)this).GetChild("backBtn");
		n48 = (GRichTextField)((GComponent)this).GetChild("n48");
		string id4 = "ui://82mo10n5gox20".Replace("ui://", "") + "-" + ((GObject)n48).id;
		((GObject)n48).text = LanguagesManager.GetDesc(id4);
		SimpleModeTips = (GTextField)((GComponent)this).GetChild("SimpleModeTips");
		string id5 = "ui://82mo10n5gox20".Replace("ui://", "") + "-" + ((GObject)SimpleModeTips).id;
		((GObject)SimpleModeTips).text = LanguagesManager.GetDesc(id5);
		n58 = (UI_RightGradient)(object)((GComponent)this).GetChild("n58");
		n56 = (UI_LeftGradient)(object)((GComponent)this).GetChild("n56");
		n61 = (UI_LeftGradient)(object)((GComponent)this).GetChild("n61");
		gradientEdges = (GGroup)((GComponent)this).GetChild("gradientEdges");
		SeasonBuffLabel = (UI_SeasonBuffLabel)(object)((GComponent)this).GetChild("SeasonBuffLabel");
		MainUiFade = ((GComponent)this).GetTransition("MainUiFade");
	}

	public void BeforeDestroy()
	{
		if (RankBattleCdCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RankBattleCdCoroutine);
		}
		PvpSelectSoldiersPanel = null;
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		((GObject)blackMask).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		PvpSelectSoldiersPanel = this;
		Type.selectedIndex = 1;
		ChallengeDataInit(parameters);
		SelectFormationsInit();
		GetAllUnlockFormations();
		RenderSoldiers();
		RenderEnemyArrayIndex();
		ShowCurSelectFormation();
		((GObject)ChallengeBtn.level).visible = false;
		((GObject)ChallengeBtn.n7).visible = false;
		DisplaySeasonBuff();
	}

	public void OnShow()
	{
		PropetryLockInit();
		PreparationTimeInit();
		SetChallengeBtnLockStatus();
		InitClickAssistantButton();
	}

	public void RegisterUiEventListeners()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		_gameStateEntity = ((Context<GameStateEntity>)GameController.Contexts.gameState).CreateEntity();
		_gameStateEntity.AddAnyLoadingPanelStatusListener(this);
		((GObject)backBtn).onClick.Add(new EventCallback0(ExitPanel));
		((GObject)ChallengeBtn.ConfirmBtn).onClick.Add(new EventCallback0(ChallengeLevel));
		((GObject)SettingBtn.ConfirmBtn).onClick.Add(new EventCallback0(SettingLevel));
		((GObject)GetRankBtn.ConfirmBtn).onClick.Add(new EventCallback0(GetSomeRank));
		((GObject)GetSelfRankBtn.ConfirmBtn).onClick.Add(new EventCallback0(GetSelfRank));
		((GObject)SoldiersSwitch).onClick.Set(new EventCallback0(ChangeSoldiersStatus));
		((GObject)SetEnemyDataBtn).onClick.Add(new EventCallback0(OpenSettingPanel));
		((GObject)TestBtnsSwitch).onClick.Add(new EventCallback0(TestBtnsVisible));
		((GObject)PreparationTime).onClick.Add(new EventCallback1(PreparationTimeClickEvent));
		((GObject)PropetryLock).onClick.Add(new EventCallback0(ChangeBattleModeSwitch));
		SharedMessenger.AddListener<EventContext, string, int>("ON_SOLDIER_SELECTED", MyStandardFormationSketchMap.OnCampClose);
		SharedMessenger.AddListener<EventContext, string, int>("ON_SOLDIER_SELECTED", EnemyStandardFormationSketchMap.OnCampClose);
		SharedMessenger.AddListener<int>("ON_PVP_QUICK_BATTLE_WAVE_START_CHANGE_LEGION_INDEX", ChangeQuickBattleStageLegionIndex);
		((GObject)clickAssistant).onClick.Set(new EventCallback0(OnClickClickAssistant));
		SharedMessenger.AddListener<string>("CLOSE_UI", OnUIClose);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		_gameStateEntity.RemoveAnyLoadingPanelStatusListener(this);
		((GObject)backBtn).onClick.Remove(new EventCallback0(ExitPanel));
		((GObject)ChallengeBtn.ConfirmBtn).onClick.Remove(new EventCallback0(ChallengeLevel));
		((GObject)SettingBtn.ConfirmBtn).onClick.Remove(new EventCallback0(SettingLevel));
		((GObject)GetRankBtn.ConfirmBtn).onClick.Remove(new EventCallback0(GetSomeRank));
		((GObject)GetSelfRankBtn.ConfirmBtn).onClick.Remove(new EventCallback0(GetSelfRank));
		((GObject)SoldiersSwitch).onClick.Remove(new EventCallback0(ChangeSoldiersStatus));
		((GObject)SetEnemyDataBtn).onClick.Remove(new EventCallback0(OpenSettingPanel));
		((GObject)TestBtnsSwitch).onClick.Remove(new EventCallback0(OpenSettingPanel));
		((GObject)PreparationTime).onClick.Remove(new EventCallback1(PreparationTimeClickEvent));
		((GObject)PropetryLock).onClick.Remove(new EventCallback0(ChangeBattleModeSwitch));
		SharedMessenger.RemoveListener<EventContext, string, int>("ON_SOLDIER_SELECTED", MyStandardFormationSketchMap.OnCampClose);
		SharedMessenger.RemoveListener<EventContext, string, int>("ON_SOLDIER_SELECTED", EnemyStandardFormationSketchMap.OnCampClose);
		SharedMessenger.RemoveListener<int>("ON_PVP_QUICK_BATTLE_WAVE_START_CHANGE_LEGION_INDEX", ChangeQuickBattleStageLegionIndex);
		((GObject)clickAssistant).onClick.Clear();
		SharedMessenger.RemoveListener<string>("CLOSE_UI", OnUIClose);
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private void ExitPanel()
	{
		End();
	}

	private void OpenSettingPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpEnemySettingPanel.Name, null);
	}

	private void SettingLevel()
	{
		if (!SaveEnemyDataLocal())
		{
			RenderSoldiers();
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText479") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText480") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		if (string.IsNullOrWhiteSpace(((GObject)SettingBtn.level).text))
		{
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText477") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
			return;
		}
		List<string> list = new List<string>();
		if (int.TryParse(((GObject)SettingBtn.level).text, out var result))
		{
			list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText481") + ((GObject)SettingBtn.level).text + LanguagesManager.GetDesc("CsharpCodeZhTcText482"));
			SetFormationUnitsOfRank(result);
		}
		else
		{
			list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText483") + " " + LanguagesManager.GetDesc("CsharpCodeZhTcText484") + " " + ((GObject)SettingBtn.level).text);
		}
		SharedMessenger.Broadcast("SHOW_TIPS", list, 1, arg3: false);
	}

	private void ChallengeLevel()
	{
		int result;
		if (string.IsNullOrWhiteSpace(((GObject)ChallengeBtn.level).text))
		{
			if (ContinueFailedHandler == null || !ContinueFailedHandler(ClickResult.UnNamedFailed, LanguagesManager.GetDesc("CsharpCodeZhTcText477")))
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText477") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
		}
		else if (int.TryParse(((GObject)ChallengeBtn.level).text, out result))
		{
			SentrySdk.AddBreadcrumb("[ReplayInfoDebug]SyncRankFormationUnits_And_StartRankBattle By Manual Challenge");
			SyncRankFormationUnits_And_StartRankBattle(result, PlayStartQuickBattle);
		}
		else if (ContinueFailedHandler == null || !ContinueFailedHandler(ClickResult.UnNamedFailed, LanguagesManager.GetDesc("CsharpCodeZhTcText483") + " " + LanguagesManager.GetDesc("CsharpCodeZhTcText484") + " " + ((GObject)ChallengeBtn.level).text))
		{
			List<string> list = new List<string>();
			list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText483") + " " + LanguagesManager.GetDesc("CsharpCodeZhTcText484") + " " + ((GObject)ChallengeBtn.level).text);
			SharedMessenger.Broadcast("SHOW_TIPS", list, 1, arg3: false);
		}
	}

	private void GetSomeRank()
	{
		if (string.IsNullOrWhiteSpace(((GObject)GetRankBtn.level).text))
		{
			List<string> arg = new List<string> { "size" + LanguagesManager.GetDesc("CsharpCodeZhTcText487") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		if (string.IsNullOrWhiteSpace(((GObject)GetRankBtn.size).text))
		{
			List<string> arg2 = new List<string> { "_fromRank" + LanguagesManager.GetDesc("CsharpCodeZhTcText487") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
			return;
		}
		if (int.TryParse(((GObject)GetRankBtn.size).text, out var result) && int.TryParse(((GObject)GetRankBtn.level).text, out var result2))
		{
			ShowSomeRankInfo(result2, result);
			return;
		}
		List<string> list = new List<string>();
		list.Add("level" + LanguagesManager.GetDesc("CsharpCodeZhTcText488") + "size " + LanguagesManager.GetDesc("CsharpCodeZhTcText484") + " " + ((GObject)ChallengeBtn.level).text);
		SharedMessenger.Broadcast("SHOW_TIPS", list, 1, arg3: false);
	}

	private void ChallengeDataInit(Dictionary<string, object> parameters)
	{
		if (parameters != null && parameters.Count > 0)
		{
			if (parameters.TryGetValue("MyRank", out var value))
			{
				myRank = (int)value;
				((GObject)GetRankBtn.size).text = $"{myRank}";
				ShowUserInfo(myRank);
			}
			if (parameters.TryGetValue("EnemyRankData", out var value2))
			{
				aimRankInfo = (RankSummary)value2;
				aimRankInfo.CheckValid();
				((GObject)ChallengeBtn.level).text = aimRankInfo.Rank.ToString();
			}
			if (parameters.TryGetValue("EnemyRankDetailInfo", out var value3))
			{
				RankRecord rankRecord = (RankRecord)value3;
				RankBattleConfig rankBattleConfig = rankRecord.RankBattleConfig;
				_enemyUnits = rankBattleConfig._units;
				unitsTotal = rankBattleConfig.UnitsTotal;
				enemyEquipments = rankRecord.RankBattleConfigDetails.SoldierEquipments;
				rankBattleConfig.TryCopyLegendItemBrief(enemyEquipments);
				UpdateEnemyRankData(rankBattleConfig._unitsId, rankBattleConfig.SoldiersDetail, rankBattleConfig.FormationId);
				ShowReceivedEnemyFormation();
				RenderEnemyArrayIndex();
				ShowEnemyInfo();
			}
			int num = ((myRank < 1 || myRank > 800) ? 801 : myRank);
			((GObject)ChallengeBtn).visible = num > aimRankInfo.Rank;
		}
	}

	private void ShowCurSelectFormation(string _arrayId = "")
	{
		curSelectFormationArrayId = (string.IsNullOrEmpty(_arrayId) ? selectFormations.Data.ToList().First().Key : _arrayId);
		MyStandardFormationSketchMap.SetOurPos(selectFormations.Data[curSelectFormationArrayId.ToString()].FormationId, selectFormations.Data[curSelectFormationArrayId.ToString()].SoldiersId, selectedSoldierId);
		CurFormation.CurFormationInit(selectFormations.Data[curSelectFormationArrayId].FormationId);
	}

	private void SelectFormationsInit()
	{
		LoadLocal();
	}

	private void GetAllUnlockFormations()
	{
		Dictionary<string, GDEFormationData> unlockedFormations = GameManagers.Instance.FormationManager.GetUnlockedFormations();
		List<string> unlockFormationsId = new List<string>();
		foreach (KeyValuePair<string, GDEFormationData> item in unlockedFormations)
		{
			unlockFormationsId.Add(item.Value.Key);
		}
		List<Formation> source = FormationManager.PlayerUsableFormations.Values.ToList();
		unlockFormations.Clear();
		unlockFormations.AddRange(source.OrderByDescending((Formation formation) => unlockFormationsId.Contains(formation.Id)));
		for (int num = unlockFormations.Count - 1; num >= 0; num--)
		{
			if (!unlockFormationsId.Contains(unlockFormations[num].Id))
			{
				unlockFormations.RemoveAt(num);
			}
		}
		CurFormation.GetAllUnlockFormations(unlockFormations);
	}

	private void ShowUserInfo(int rank)
	{
		int userId = GameController.Contexts.gameState.user.value.UserId;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, userId, OurInfomationBar.Avatar.HeadPortrait.icon, OurInfomationBar.ArmyGroupName));
		FGUIManager.Instance.GetUserMedal(userId, OurInfomationBar.OurMedalList);
		((GObject)OurInfomationBar.ArmyGroupLevel).text = GetUserGradeText(rank);
	}

	public void ShowEnemyInfo()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		if (aimRankInfo == null)
		{
			return;
		}
		if (aimRankInfo.UserId != 0)
		{
			((GComponent)(object)this).SetTimeout(0.25f).OnComplete((GTweenCallback)delegate
			{
				EnemyInfomationBar.Avatar.HeadPortrait.Type.selectedIndex = 0;
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, aimRankInfo.UserId, EnemyInfomationBar.Avatar.HeadPortrait.icon, EnemyInfomationBar.ArmyGroupName));
				FGUIManager.Instance.GetUserMedal(aimRankInfo.UserId, EnemyInfomationBar.EnemyMedalList);
			});
		}
		else
		{
			EnemyInfomationBar.Avatar.HeadPortrait.Type.selectedIndex = 1;
			((GObject)EnemyInfomationBar.ArmyGroupName).text = NpcName;
			EnemyInfomationBar.Avatar.HeadPortrait.icon.url = RankDataHelper.GetNpcIconName(aimRankInfo.Rank);
		}
		((GObject)EnemyInfomationBar.ArmyGroupLevel).text = GetUserGradeText(aimRankInfo.Rank);
	}

	private void RenderEnemyAllSelectedFormations()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		EnemyFormations.itemRenderer = new ListItemRenderer(RenderEnemyFormation);
		EnemyFormations.numItems = unlockFormations.Count;
	}

	private void RenderEnemyFormation(int index, GObject obj)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		GButton asButton = obj.asButton;
		((GComponent)asButton).GetChild("FormationName").text = unlockFormations[index].Name;
		((GObject)asButton).data = unlockFormations[index].Id;
		((GObject)asButton).onClick.Set(new EventCallback1(SelectEnemyFormation));
	}

	private void SelectEnemyFormation(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string formationId = ((GObject)context.sender).data.ToString();
		selectEnemyFormations.Data[curSelectEnemyFormationArrayId].FormationId = formationId;
		ShowCurEnemyFormation(curSelectEnemyFormationArrayId);
	}

	private void ChangeSoldiersStatus()
	{
		if (SoldiersSwitch.Status.selectedIndex == 0)
		{
			SoldiersSwitch.Status.selectedIndex = 1;
		}
		else
		{
			SoldiersSwitch.Status.selectedIndex = 0;
		}
		SoldiersStatus.selectedIndex = SoldiersSwitch.Status.selectedIndex;
	}

	private void RenderSoldiers()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		Soliders.itemRenderer = new ListItemRenderer(RenderSoldierItem);
		Soliders.numItems = 3;
		if (Soliders.numItems >= 1)
		{
			GComponent asCom = ((GComponent)Soliders).GetChildAt(0).asCom;
			GButton asButton = asCom.GetChild("ArrayIndex").asButton;
			((GComponent)asButton).GetController("btnaddd").selectedIndex = 1;
		}
	}

	private void RenderSoldierItem(int index, GObject obj)
	{
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected O, but got Unknown
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
		UI_BattleArray uI_BattleArray = obj as UI_BattleArray;
		List<KeyValuePair<string, SelectFormation>> list = selectFormations.Data.ToList();
		if (index > list.Count - 1)
		{
			((GObject)uI_BattleArray).enabled = false;
			return;
		}
		((GObject)uI_BattleArray.ArrayIndex).touchable = true;
		((GObject)uI_BattleArray.ArrayIndex.indexText).text = $"{index + 1}";
		RenderSelectSoldiers(uI_BattleArray.enemy, list[index].Key);
		if (string.IsNullOrEmpty(list[index].Value.FormationId))
		{
			uI_BattleArray.formationIcon.url = "";
		}
		else
		{
			Formation formation = FormationManager.Formations[list[index].Value.FormationId];
			uI_BattleArray.formationIcon.url = "ui://PvpSelectSoldiers/" + formation.Icon;
		}
		GGraph selectFormation = uI_BattleArray.SelectFormation;
		((GObject)selectFormation).name = ((GObject)selectFormation).name + $"{index + 1}";
		((GObject)uI_BattleArray.CurFormation).onClick.Set(new EventCallback1(CurFormationClick));
		((GObject)uI_BattleArray.ArrayIndex).data = index;
		((GObject)uI_BattleArray.ArrayIndex).onClick.Set(new EventCallback1(UpdateCurSelectFormationArrayId));
		((GObject)uI_BattleArray.clearBtn).data = index;
		((GObject)uI_BattleArray.clearBtn).onClick.Set(new EventCallback1(ClearCurSelectFormationData));
		((GObject)uI_BattleArray).data = list[index].Key;
		((GObject)uI_BattleArray).onTouchBegin.Set(new EventCallback1(OnBlockTouchBegin));
		((GObject)uI_BattleArray).onTouchMove.Set(new EventCallback1(OnBlockTouchMove));
		((GObject)uI_BattleArray).onTouchEnd.Set(new EventCallback1(OnBlockTouchEnd));
		if (index < RankDataHelper.GetPvpLegionSize(aimRankInfo.Rank))
		{
			((GObject)uI_BattleArray).enabled = true;
		}
		else
		{
			((GObject)uI_BattleArray).enabled = false;
		}
	}

	private void UpdateCurSelectFormationArrayId(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		object data = val.data;
		if (data != null)
		{
			string text = data.ToString();
			curSelectFormationArrayId = text;
			ShowCurSelectFormation(curSelectFormationArrayId);
			GComponent asCom = ((GComponent)Soliders).GetChildAt(0).asCom;
			GComponent asCom2 = ((GComponent)Soliders).GetChildAt(1).asCom;
			GComponent asCom3 = ((GComponent)Soliders).GetChildAt(2).asCom;
			GButton asButton = asCom.GetChild("ArrayIndex").asButton;
			GButton asButton2 = asCom2.GetChild("ArrayIndex").asButton;
			GButton asButton3 = asCom3.GetChild("ArrayIndex").asButton;
			Controller controller = ((GComponent)asButton).GetController("btnaddd");
			Controller controller2 = ((GComponent)asButton2).GetController("btnaddd");
			int num = (((GComponent)asButton3).GetController("btnaddd").selectedIndex = 0);
			int selectedIndex = (controller2.selectedIndex = num);
			controller.selectedIndex = selectedIndex;
			UI_ArrayIndex uI_ArrayIndex = ((GObject)context.sender) as UI_ArrayIndex;
			((GComponent)uI_ArrayIndex).GetController("btnaddd").selectedIndex = 1;
		}
	}

	private void ClearCurSelectFormationData(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		GObject val = (GObject)context.sender;
		object data = val.data;
		if (data == null)
		{
			return;
		}
		int num = (int)data;
		string text = data.ToString();
		List<string> soldiersId = selectFormations.Data[text].SoldiersId;
		for (int num2 = selectedSoldierId.Count - 1; num2 >= 0; num2--)
		{
			if (soldiersId.Contains(selectedSoldierId[num2]))
			{
				selectedSoldierId.RemoveAt(num2);
			}
		}
		selectFormations.Data[text].ClearData();
		RenderSoldierItem(num, ((GComponent)Soliders).GetChildAt(num));
		ShowCurSelectFormation(text);
		context.StopPropagation();
	}

	private void CurFormationClick(EventContext context)
	{
		UI_CurFormation uI_CurFormation = (UI_CurFormation)(object)context.sender;
		if (uI_CurFormation.Status.selectedIndex == 0)
		{
			uI_CurFormation.Status.selectedIndex = 1;
			RenderUnlockFormations(uI_CurFormation);
		}
		else if (uI_CurFormation.Status.selectedIndex == 1)
		{
			uI_CurFormation.Status.selectedIndex = 0;
			RenderCurFormation(uI_CurFormation.MainFormation, selectFormations.Data[curSelectFormationArrayId.ToString()].FormationId);
		}
		context.StopPropagation();
	}

	private void RenderUnlockFormations(UI_CurFormation _curFormation)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		_curFormation.Formations.itemRenderer = new ListItemRenderer(RenderFormation);
		_curFormation.Formations.numItems = unlockFormations.Count;
	}

	private void RenderFormation(int index, GObject obj)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		UI_FormationBtn uI_FormationBtn = obj as UI_FormationBtn;
		RenderCurFormation(uI_FormationBtn, unlockFormations[index].Id);
		((GObject)uI_FormationBtn).data = unlockFormations[index].Id;
		((GObject)uI_FormationBtn).onClick.Set(new EventCallback1(SelectArrayFormation));
	}

	private void RenderCurFormation(UI_FormationBtn _curFormationBtn, string _formationId)
	{
		if (string.IsNullOrEmpty(_formationId))
		{
			((GObject)_curFormationBtn.name).text = "";
			_curFormationBtn.formationIcon.url = "";
		}
		else
		{
			Formation formation = FormationManager.Formations[_formationId];
			((GObject)_curFormationBtn.name).text = formation.Name;
			_curFormationBtn.formationIcon.url = "ui://PvpSelectSoldiers/" + formation.Icon;
		}
	}

	private void SelectArrayFormation(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		string text = ((GObject)context.sender).data.ToString();
		if (!string.IsNullOrEmpty(text) && selectFormations.Data.ContainsKey(curSelectFormationArrayId.ToString()))
		{
			selectFormations.Data[curSelectFormationArrayId.ToString()].FormationId = text;
			MyStandardFormationSketchMap.SetOurPos(selectFormations.Data[curSelectFormationArrayId.ToString()].FormationId, selectFormations.Data[curSelectFormationArrayId.ToString()].SoldiersId, selectedSoldierId);
		}
	}

	private void RenderSelectSoldiers(GList soldierGList, string arrayId)
	{
		FGUIManager.Instance.ClearCache_SoliderSoulStone();
		soldierGList.RemoveChildrenToPool();
		for (int i = 0; i < selectFormations.Data[arrayId].SoldiersId.Count; i++)
		{
			string text = selectFormations.Data[arrayId].SoldiersId[i];
			if (!string.IsNullOrEmpty(text) && text != "Unlock" && text != "Lock")
			{
				string soldierId = selectFormations.Data[arrayId].SoldiersId[i];
				GObject obj = soldierGList.AddItemFromPool();
				RenderSelectSoldierItem(i, obj, soldierId);
			}
		}
	}

	private void RenderSelectSoldierItem(int index, GObject obj, string soldierId)
	{
		UI_enemyItem uI_enemyItem = obj as UI_enemyItem;
		string iconPath = UiHelper.GetIconPath(soldierId);
		uI_enemyItem.icon.url = "ui://PublicResources/" + iconPath;
		Soldier soldier = GameManagers.Instance.SoldierManager.Get(soldierId);
		((GObject)uI_enemyItem.lv).text = $"{soldier.Level}";
		int num = (soldier.PotentialLevel + 2) / 2;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		uI_enemyItem.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		uI_enemyItem.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		((GObject)uI_enemyItem.n47).visible = false;
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)uI_enemyItem.iconFrame).asLoader, soldier.PotentialLevel);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(uI_enemyItem.SoulStoneLevel, soldier.PotentialLevel, null);
	}

	private void ChangeSelectSoldier(EventContext context)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		curSoldierIndex = (int)((GObject)context.sender).data;
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{ "Style", "6" },
			{ "PvpSoldiersFilter", selectedSoldierId }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegionPanel.Name, parameters);
	}

	public void OnCampClose(EventContext eventContext, string soldierId, int chosenType)
	{
	}

	public void OnBlockTouchBegin(EventContext context)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		if (SoldiersStatus.selectedIndex == 1 && !isMouseMoving)
		{
			curTouchArrayId = "";
			curTouchFormationBtnY = 0f;
			GObject touchTarget = GRoot.inst.touchTarget;
			if (touchTarget.name.Contains("SelectFormation"))
			{
				GObject val = (GObject)context.sender;
				curTouchArrayId = val.data.ToString();
				curTouchFormationBtnY = ((GObject)touchTarget.parent).y;
				curTouchBtnIndex = ((GComponent)Soliders).GetChildIndex(val);
				Vector2 val2 = default(Vector2);
				((Vector2)(ref val2))._002Ector(context.inputEvent.x, context.inputEvent.y);
				Vector2 touchPos = ((GObject)UnityUiService.Instance.maskCover).GlobalToLocal(val2);
				Vector2 formationBtnGlobalPos = val.LocalToRoot(new Vector2(val.width / 2f - 20f, val.height / 2f + 20f), GRoot.inst);
				UI_PvpTeamMoveInfo.ShowMainUi(formationBtnGlobalPos, touchPos, curTouchBtnIndex + 1);
			}
		}
	}

	public void OnBlockTouchMove(EventContext context)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		if (SoldiersStatus.selectedIndex == 1)
		{
			isMouseMoving = true;
			Vector2 val = default(Vector2);
			((Vector2)(ref val))._002Ector(context.inputEvent.x, context.inputEvent.y);
			Vector2 touchPos = ((GObject)UnityUiService.Instance.maskCover).GlobalToLocal(val);
			UI_PvpTeamMoveInfo.ChangePosOnMoving(touchPos);
		}
	}

	public void OnBlockTouchEnd(EventContext context)
	{
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		if (SoldiersStatus.selectedIndex != 1)
		{
			return;
		}
		GObject touchTarget = GRoot.inst.touchTarget;
		if (isMouseMoving)
		{
			isMouseMoving = false;
			if (touchTarget != null && touchTarget.name.Contains("SelectFormation") && !string.IsNullOrWhiteSpace(curTouchArrayId))
			{
				UI_BattleArray uI_BattleArray = touchTarget.parent as UI_BattleArray;
				float y = ((GObject)uI_BattleArray).y;
				string text = ((GObject)uI_BattleArray).data.ToString();
				int childIndex = ((GComponent)Soliders).GetChildIndex((GObject)(object)uI_BattleArray);
				string formationId = selectFormations.Data[text].FormationId;
				List<string> soldiersId = selectFormations.Data[text].SoldiersId;
				UI_BattleArray uI_BattleArray2 = ((GComponent)Soliders).GetChildAt(curTouchBtnIndex) as UI_BattleArray;
				((GObject)uI_BattleArray2).y = y;
				((GObject)uI_BattleArray2).data = text;
				((GObject)uI_BattleArray2.ArrayIndex).data = childIndex;
				((GObject)uI_BattleArray2.clearBtn).data = childIndex;
				((GObject)uI_BattleArray2.ArrayIndex.indexText).text = $"{childIndex + 1}";
				GGraph selectFormation = uI_BattleArray2.SelectFormation;
				((GObject)selectFormation).name = ((GObject)selectFormation).name + $"{childIndex + 1}";
				((GComponent)Soliders).SetChildIndex((GObject)(object)uI_BattleArray2, childIndex);
				selectFormations.Data[text].FormationId = selectFormations.Data[curTouchArrayId].FormationId;
				selectFormations.Data[text].SoldiersId = selectFormations.Data[curTouchArrayId].SoldiersId;
				((GObject)uI_BattleArray).y = curTouchFormationBtnY;
				((GObject)uI_BattleArray).data = curTouchArrayId;
				((GObject)uI_BattleArray.ArrayIndex).data = curTouchBtnIndex;
				((GObject)uI_BattleArray.clearBtn).data = curTouchBtnIndex;
				((GObject)uI_BattleArray.ArrayIndex.indexText).text = $"{curTouchBtnIndex + 1}";
				GGraph selectFormation2 = uI_BattleArray.SelectFormation;
				((GObject)selectFormation2).name = ((GObject)selectFormation2).name + $"{curTouchBtnIndex + 1}";
				((GComponent)Soliders).SetChildIndex((GObject)(object)uI_BattleArray, curTouchBtnIndex);
				selectFormations.Data[curTouchArrayId].FormationId = formationId;
				selectFormations.Data[curTouchArrayId].SoldiersId = soldiersId;
				((GObject)uI_BattleArray2.ArrayIndex).onClick.Call();
				ShowCurSelectFormation(text);
				Vector2 formationBtnGlobalPos = ((GObject)uI_BattleArray2).LocalToRoot(new Vector2(((GObject)uI_BattleArray2).width / 2f - 20f, ((GObject)uI_BattleArray2).height / 2f + 20f), GRoot.inst);
				UI_PvpTeamMoveInfo.MainUiDisappear(formationBtnGlobalPos, null);
			}
			else
			{
				UI_PvpTeamMoveInfo.Disappear();
			}
		}
		else if (!touchTarget.name.Contains("ArrayIndex"))
		{
			UI_PvpTeamMoveInfo.Disappear();
		}
	}

	public void UpdateSomeSoldierBtn(int _index, string _sid)
	{
		Dictionary<string, SelectFormation> data = selectFormations.Data;
		SelectFormation selectFormation = data[curSelectFormationArrayId.ToString()];
		List<string> soldiersId = selectFormation.SoldiersId;
		soldiersId[_index] = _sid;
		RenderSelectSoldiers(((GComponent)((GComponent)Soliders).GetChildAt(int.Parse(curSelectFormationArrayId)).asButton).GetChild("enemy").asList, curSelectFormationArrayId);
	}

	public void UpdateCurSelectFormation(string _fid)
	{
		if (selectFormations.Data.ContainsKey(curSelectFormationArrayId))
		{
			selectFormations.Data[curSelectFormationArrayId].FormationId = _fid;
			MyStandardFormationSketchMap.SetOurPos(selectFormations.Data[curSelectFormationArrayId].FormationId, selectFormations.Data[curSelectFormationArrayId].SoldiersId, selectedSoldierId);
			if (!string.IsNullOrEmpty(_fid))
			{
				Formation formation = FormationManager.Formations[_fid];
				UI_BattleArray uI_BattleArray = ((GComponent)Soliders).GetChildAt(int.Parse(curSelectFormationArrayId)).asButton as UI_BattleArray;
				uI_BattleArray.formationIcon.url = "ui://PvpSelectSoldiers/" + formation.Icon;
			}
		}
	}

	public void UpdateSomeEnemyBtn(int _index, string _sid)
	{
		List<string> soldiersId = selectEnemyFormations.Data[curSelectEnemyFormationArrayId].SoldiersId;
		soldiersId[_index] = _sid;
	}

	public void UpdateSelectedSoldierId(string _sid, bool isAdd)
	{
		if (isAdd)
		{
			if (!selectedSoldierId.Contains(_sid))
			{
				selectedSoldierId.Add(_sid);
			}
		}
		else if (selectedSoldierId.Contains(_sid))
		{
			selectedSoldierId.Remove(_sid);
		}
	}

	private void SetChallengeBtnLockStatus()
	{
		((GObject)ChallengeBtn.lockTip).visible = RankDataHelper.UnlockedBlocks > GetEnemyRankRange();
	}

	private int GetEnemyRankRange()
	{
		if (aimRankInfo == null)
		{
			return RankDataHelper.UnlockedBlocks;
		}
		if (aimRankInfo.Rank < 1 || aimRankInfo.Rank > 800)
		{
			return RankDataHelper.UnlockedBlocks;
		}
		return (aimRankInfo.Rank % 100 == 0) ? (aimRankInfo.Rank / 100) : (aimRankInfo.Rank / 100 + 1);
	}

	private void PreparationTimeInit()
	{
		curRankBattleCd = RankDataHelper.GetPvpRankProgressCdFinishAt(((aimRankInfo.UserId == 0) ? (-1 * aimRankInfo.Rank) : aimRankInfo.UserId).ToString());
		if (curRankBattleCd <= 0)
		{
			curRankBattleCd = 0;
			((GObject)PreparationTime).visible = false;
		}
		((GObject)PreparationTime.Time).text = LanguagesManager.GetDesc("CsharpCodeZhTcText485") + Environment.NewLine + UiHelper.ParseTime(curRankBattleCd);
		if (curRankBattleCd > 0 && RankBattleCdCoroutine == null)
		{
			RankBattleCdCoroutine = FGUIManager.Instance.OpenIEnumerator(RenderRankBattleCd(curRankBattleCd));
		}
	}

	private IEnumerator RenderRankBattleCd(int battleCd)
	{
		if (battleCd <= 0 && RankBattleCdCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RankBattleCdCoroutine);
			((GObject)PreparationTime).visible = false;
			yield break;
		}
		yield return (object)new WaitForSeconds(1f);
		battleCd--;
		curRankBattleCd = battleCd;
		((GObject)PreparationTime.Time).text = LanguagesManager.GetDesc("CsharpCodeZhTcText485") + Environment.NewLine + UiHelper.ParseTime(battleCd);
		RankBattleCdCoroutine = FGUIManager.Instance.OpenIEnumerator(RenderRankBattleCd(battleCd));
	}

	public void ClearRankBattleCdText()
	{
		curRankBattleCd = 0;
		if (RankBattleCdCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RankBattleCdCoroutine);
			((GObject)PreparationTime).visible = false;
		}
		((GObject)PreparationTime.Time).text = LanguagesManager.GetDesc("CsharpCodeZhTcText485") + Environment.NewLine + UiHelper.ParseTime(curRankBattleCd);
	}

	private string GetUserGradeText(int rank)
	{
		if (rank < 1 || rank > 800)
		{
			return LanguagesManager.GetDesc("CsharpCodeZhTcText455");
		}
		int rangeIndex = ((rank % 100 == 0) ? (rank / 100) : (rank / 100 + 1));
		return string.Format("{0}{1}{2}{3}", RankDataHelper.GetPvpRankRangeText(rangeIndex), LanguagesManager.GetDesc("CsharpCodeZhTcText145"), rank, LanguagesManager.GetDesc("CsharpCodeZhTcText356"));
	}

	private void DefenseTimeClickEvent(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_AddRankDefenseBuffDialog.Name, null);
	}

	private void AttackStrengthenClickEvent(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_AddRankAttackBuffDialog.Name, null);
	}

	private void PreparationTimeClickEvent(EventContext context)
	{
		int num = ((aimRankInfo.UserId == 0) ? (-1 * aimRankInfo.Rank) : aimRankInfo.UserId);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_AddRankClearCDDialog.Name, new Dictionary<string, object>
		{
			{ "CurRankBattleCd", curRankBattleCd },
			{ "TargetId", num }
		});
	}

	private void PlayStartQuickBattle()
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		Type.selectedIndex = 2;
		((GObject)MyStandardFormationSketchMap.Background).alpha = 0f;
		((GObject)EnemyStandardFormationSketchMap.Background).alpha = 0f;
		((GObject)QuickBattleStage.MyLegionIndex.indexText).text = "1";
		((GObject)QuickBattleStage.EnemyLegionIndex.indexText).text = "1";
		QuickBattleStage.ShowQuickBattleStage.Play();
		((GComponent)(object)this).SetTimeout(0.3f).OnComplete((GTweenCallback)delegate
		{
			SoldiersBtnDisappear();
		});
	}

	private void SoldiersBtnDisappear()
	{
		MyStandardFormationSketchMap.AllDisappear();
		((GObject)MyStandardFormationSketchMap).touchable = false;
		EnemyStandardFormationSketchMap.AllDisappear();
		((GObject)EnemyStandardFormationSketchMap).touchable = false;
	}

	private void ChangeQuickBattleStageLegionIndex(int _index)
	{
		QuickBattleStage.Type.selectedIndex = _index;
		string text = (_index + 1).ToString();
		((GObject)QuickBattleStage.MyLegionIndex.indexText).text = text;
		((GObject)QuickBattleStage.EnemyLegionIndex.indexText).text = text;
	}

	private void PropetryLockInit()
	{
		bool flag = IsPassed520();
		((GObject)SimpleModeTips).visible = !flag;
		if (!flag)
		{
			PropetryLock.Status.selectedIndex = 2;
		}
		else
		{
			PropetryLock.Status.selectedIndex = GameLocalDataManager.GetPvpQuickBattleSwitch();
		}
	}

	private void OnUIClose(string uiName)
	{
		InitClickAssistantButton();
	}

	private static bool IsPassed520()
	{
		return GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1005").Contains("P520");
	}

	public static bool IsPassed830()
	{
		return GameManagers.Instance.UserArchiveManager.IsLevelCompleted("P830");
	}

	private void OnClickClickAssistant()
	{
		switch (clickAssistant.Status.selectedIndex)
		{
		case 1:
		{
			string desc2 = LanguagesManager.GetDesc("DisablePvpClickAssistantTip1");
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { desc2 }, ((GObject)this).sortingOrder, arg3: false);
			break;
		}
		case 2:
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
			string desc = LanguagesManager.GetDesc("DisablePvpClickAssistantTip2");
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { desc }, ((GObject)this).sortingOrder, arg3: false);
			break;
		}
		case 3:
		{
			long pvpClickAssistantDontShowAgainUtil = GameLocalDataManager.GetPvpClickAssistantDontShowAgainUtil();
			if (DateTimeHelper.GetTimeStamp(DateTimeHelper.ServerNow) >= pvpClickAssistantDontShowAgainUtil)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_ConfirmPopupDontShowAgain.Name, new Dictionary<string, object>
				{
					{ "TipKey", "TipKey_PvpClickAssistant" },
					{
						"TipValue",
						DateTimeHelper.GetTimeStamp(DateTimeHelper.GetWeeklyRefreshTime(DateTimeHelper.ServerNow, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours).AddDays(7.0))
					},
					{
						"TipContent",
						LanguagesManager.GetDesc("CsharpCodeTextAutoChallengeTipDontShowAgain")
					},
					{
						"Content",
						LanguagesManager.GetDesc("StartPvpClickAssistantTip1")
					},
					{
						"Buttons",
						new Dictionary<string, Action>
						{
							{
								"Confirm",
								delegate
								{
									StartPvpClickAssistant();
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
					{ "ClickSound", "Confirm" },
					{ "Order", 999999 }
				});
			}
			else
			{
				StartPvpClickAssistant();
			}
			break;
		}
		}
	}

	private void StartPvpClickAssistant()
	{
		UnityUiService.Instance.OpenPanel(UI_main_PvpRankAFKAssistant.Name, new Dictionary<string, object>());
	}

	private void InitClickAssistantButton()
	{
		((GObject)clickAssistant).visible = ((GObject)ChallengeBtn).visible;
		if (!Define.IsClickAssistantOpen())
		{
			clickAssistant.Status.SetSelectedIndex(0);
			return;
		}
		bool flag = GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("OverlordContract") > 0;
		int selectedIndex = (IsPassed520() ? ((!IsPassed830()) ? 1 : (flag ? 3 : 2)) : 0);
		clickAssistant.Status.SetSelectedIndex(selectedIndex);
	}

	private bool SaveLocal()
	{
		int pvpLegionSize = RankDataHelper.GetPvpLegionSize(aimRankInfo.Rank);
		bool result = selectFormations.CheckValid();
		List<SelectFormation> list = selectFormations.Data.Values.ToList();
		List<string> list2 = new List<string>();
		List<List<string>> list3 = new List<List<string>>();
		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (num >= pvpLegionSize)
			{
				break;
			}
			list2.Add(list[i].FormationId);
			list3.Add(list[i].SoldiersId);
			num++;
		}
		GameManagers.Instance.UserArchiveManager.SetRankBattleFormationConfig(list2, list3);
		GameLocalDataManager.SetPvpBattleFormationUnitsConfigs(pvpLegionSize, new RankBattleFormationUnitsConfig
		{
			FormationsId = list2,
			UnitsId = list3
		});
		return result;
	}

	public void LoadLocal()
	{
		selectFormations.Data = null;
		int pvpLegionSize = RankDataHelper.GetPvpLegionSize(aimRankInfo.Rank);
		RankBattleFormationUnitsConfig pvpBattleFormationUnitsConfigs = GameLocalDataManager.GetPvpBattleFormationUnitsConfigs(pvpLegionSize);
		int num = 0;
		if (pvpBattleFormationUnitsConfigs != null)
		{
			selectFormations.Data = new Dictionary<string, SelectFormation>();
			for (int i = 0; i < pvpBattleFormationUnitsConfigs.FormationsId.Count; i++)
			{
				if (num >= pvpLegionSize)
				{
					break;
				}
				SelectFormation selectFormation = new SelectFormation(i);
				selectFormation.FormationId = pvpBattleFormationUnitsConfigs.FormationsId[i];
				selectFormation.SoldiersId = ((pvpBattleFormationUnitsConfigs.UnitsId.Count > i) ? pvpBattleFormationUnitsConfigs.UnitsId[i] : null);
				selectFormations.Data.Add(i.ToString(), selectFormation);
				num++;
			}
		}
		selectFormations.CheckValid();
		foreach (KeyValuePair<string, SelectFormation> datum in selectFormations.Data)
		{
			for (int j = 0; j < datum.Value.SoldiersId.Count; j++)
			{
				string text = datum.Value.SoldiersId[j];
				if (!string.IsNullOrEmpty(text) && text != "Lock" && text != "Unlock")
				{
					selectedSoldierId.Add(text);
				}
			}
		}
	}

	public void SyncRankFormationUnits_And_StartRankBattle(int target_rank, Action prepareFxAction)
	{
		List<string> formationsId = new List<string>();
		List<List<string>> unitsId = new List<List<string>>();
		int num = 0;
		int pvpLegionSize = RankDataHelper.GetPvpLegionSize(target_rank);
		foreach (SelectFormation value in selectFormations.Data.Values)
		{
			if (num >= pvpLegionSize)
			{
				break;
			}
			formationsId.Add(value.FormationId);
			unitsId.Add(value.SoldiersId.ToList());
			num++;
		}
		Action action = delegate
		{
			ILRequestHelper<SyncRankFormationUnitsResponse>.Request((EventContext)null, (Func<Task<SyncRankFormationUnitsResponse>>)(() => GameController.Contexts.Service<INetworkService>().SyncRankFormationUnits(-1L, formationsId, unitsId)), (Action<SyncRankFormationUnitsResponse>)delegate(SyncRankFormationUnitsResponse response)
			{
				if (!response.Result)
				{
					SharedMessenger.Broadcast("SET_UI_TOUCHABLE", UI_PvpBattleVictory.Name);
					if (ContinueFailedHandler == null || !ContinueFailedHandler(ClickResult.UnNamedFailed, LanguagesManager.GetErrorMessage(response.ErrorCode)))
					{
						ILRequestHelper.ShowErrorCode(response.ErrorCode);
					}
				}
				else
				{
					SaveLocal();
					StartRankBattle(target_rank, prepareFxAction);
				}
			});
		};
		ShowPerhapsFailTip(unitsId, pvpLegionSize, action);
	}

	private void ShowPerhapsFailTip(List<List<string>> unitsId, int myLegionSize, Action action)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		int num = 0;
		List<int> needShakeArrayBtnIndex = new List<int>();
		int num2 = ((unitsId.Count >= myLegionSize) ? myLegionSize : unitsId.Count);
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < unitsId[i].Count; j++)
			{
				string text = unitsId[i][j];
				if (string.IsNullOrEmpty(text) || text == "Unlock" || text == "Lock")
				{
					num++;
					flag2 = true;
					if (!needShakeArrayBtnIndex.Contains(i))
					{
						needShakeArrayBtnIndex.Add(i);
					}
					continue;
				}
				int stock = GameManagers.Instance.StockController.GetStock(text);
				int soldierLevel = GameManagers.Instance.UserArchiveManager.GetSoldierLevel(text);
				int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(text, soldierLevel);
				if (stock < soldierFormationNumber)
				{
					flag3 = true;
					if (!needShakeArrayBtnIndex.Contains(i))
					{
						needShakeArrayBtnIndex.Add(i);
					}
				}
			}
			if (num >= unitsId[i].Count)
			{
				flag = true;
				if (!needShakeArrayBtnIndex.Contains(i))
				{
					needShakeArrayBtnIndex.Add(i);
				}
			}
			num = 0;
		}
		if (!flag && !flag2 && !flag3)
		{
			action();
			return;
		}
		Action action2 = delegate
		{
			MyStandardFormationSketchMap.PlayPosShake();
			for (int k = 0; k < needShakeArrayBtnIndex.Count; k++)
			{
				((GComponent)((GComponent)Soliders).GetChildAt(needShakeArrayBtnIndex[k]).asButton).GetTransition("Shake").Play();
			}
		};
		UnityUiService.Instance.ShowWaitingAnimation(show: false);
		SharedMessenger.Broadcast("SET_UI_TOUCHABLE", UI_PvpBattleVictory.Name);
		if (ContinueFailedHandler == null || !ContinueFailedHandler(ClickResult.ChallengeFailedNotEnoughTroop, null))
		{
			UiHelper.ShowConfirmDialog(LanguagesManager.GetDesc("CsharpCodeZhTcText337") + "[color=#FF1919]" + LanguagesManager.GetDesc("CsharpCodeZhTcText127") + "[/color]", action2);
		}
	}

	private void ChangeBattleModeSwitch()
	{
		if (PropetryLock.Status.selectedIndex != 2)
		{
			PropetryLock.Status.selectedIndex = ((PropetryLock.Status.selectedIndex <= 0) ? 1 : 0);
			GameLocalDataManager.SetPvpQuickBattleSwitch(PropetryLock.Status.selectedIndex);
		}
	}

	private async void StartRankBattle(int target_rank, Action prepareFxAction)
	{
		if (aimRankInfo == null)
		{
			if (ContinueFailedHandler == null || !ContinueFailedHandler(ClickResult.UnNamedFailed, LanguagesManager.GetDesc("TipGetAimRankInfoFailed")))
			{
				SharedMessenger.Broadcast("SET_UI_TOUCHABLE", UI_PvpBattleVictory.Name);
			}
			return;
		}
		SoldiersStatus.selectedIndex = 0;
		UI_Battle.pvpEnemyInfo = new UI_Battle.PvpEnemyInfo();
		if (aimRankInfo.UserId != 0)
		{
			UI_Battle.pvpEnemyInfo.IsUser = true;
			UI_Battle.pvpEnemyInfo.UserId = aimRankInfo.UserId;
		}
		else
		{
			UI_Battle.pvpEnemyInfo.IsUser = false;
			UI_Battle.pvpEnemyInfo.NpcUrl = EnemyInfomationBar.Avatar.HeadPortrait.icon.url;
		}
		UI_Battle.pvpRedInfo = new UI_Battle.PvpRedUserInfo
		{
			IsUser = true,
			UserId = GameController.Contexts.gameState.user.value.UserId,
			NpcUrl = ""
		};
		if (PropetryLock.Status.selectedIndex == 1)
		{
			if (ContinueFailedHandler == null || !ContinueFailedHandler(ClickResult.ChallengeSuccess, null))
			{
			}
			QuickPlayReplayService.info.LastBattleFinishAt = aimRankInfo.LastBattleFinishAt;
			QuickPlayReplayService.info.TargetRank = target_rank;
			((GObject)ChallengeBtn.ConfirmBtn).touchable = false;
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_QuickBattlePanel.Name, new Dictionary<string, object>
			{
				{
					"CurLevel",
					new Level(GDMgr.Get<GDELevelData>("RankBattleFieldLevel"))
				},
				{ "Type", 0 },
				{ "lastFinishAt", aimRankInfo.LastBattleFinishAt },
				{ "TargetRank", target_rank },
				{ "IsPvpBattle", true },
				{ "StartPvpBattleAction", prepareFxAction },
				{
					"UserName",
					((GObject)EnemyInfomationBar.ArmyGroupName).text
				}
			}, multiMode: false, ignoreQueue: false, delegate
			{
				SharedMessenger.Broadcast("SET_UI_TOUCHABLE", UI_PvpBattleVictory.Name);
			});
			return;
		}
		ILRequestHelper<StartRankBattleResponse>.Request((EventContext)null, (Func<Task<StartRankBattleResponse>>)(() => GameController.Contexts.Service<INetworkService>().StartRankBattle(-1L, target_rank, aimRankInfo.LastBattleFinishAt)), (Action<StartRankBattleResponse>)delegate(StartRankBattleResponse response)
		{
			if (10114000 == response.ErrorCode || 10114017 == response.ErrorCode || 10114018 == response.ErrorCode || 80000012 == response.ErrorCode || 80000013 == response.ErrorCode || 80000998 == response.ErrorCode)
			{
				string desc = LanguagesManager.GetDesc("ErrorCode_" + response.ErrorCode);
				UiHelper.ShowConfirmDialog(desc, ExitPanel);
			}
			else if (10114016 == response.ErrorCode)
			{
				int num = (int)GameController.Instance.GetServerTime();
				DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp(num);
				DateTimeOffset dateTimeOffset2 = new DateTimeOffset(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, 10, 0, 0, DateTimeHelper.TimezoneOffset);
				int num2 = DateTimeHelper.GetTimeStamp(dateTimeOffset2);
				if (num2 < num)
				{
					num2 += 86400;
				}
				string message = string.Format("{0}{1}{2}{3}{4}{5}{6}/{7}{8}", RankDataHelper.GetPvpRankRangeText(GetEnemyRankRange()), LanguagesManager.GetDesc("CsharpCodeZhTcText489"), LanguagesManager.Comma, LanguagesManager.GetDesc("CsharpCodeZhTcText490"), RankDataHelper.GetPvpRankRangeText(RankDataHelper.UnlockedBlocks), LanguagesManager.GetDesc("CsharpCodeZhTcText491"), RankDataHelper.UnlockNextBlockProgress, 50, LanguagesManager.GetDesc("CsharpCodeZhTcText492")) + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText493") + UiHelper.ParseTimeChinsesDH_Foo(num2 - num) + LanguagesManager.GetDesc("CsharpCodeZhTcText494");
				UiHelper.ShowConfirmDialog(message, null);
			}
			else if (!response.Result)
			{
				ILRequestHelper.ShowErrorCodeAndData(response.ErrorCode, new object[1] { ((GObject)EnemyInfomationBar.ArmyGroupName).text }.ToArray());
			}
			else
			{
				SentrySdk.AddBreadcrumb($"UI_PvpSelectSoldiersPanel Start Rank Battle {response.BattleId}, TargetRank={target_rank}");
				((GObject)ChallengeBtn.ConfirmBtn).touchable = false;
				RankDataHelper.info = new RankBattleInfo(response.BattleId);
				RankDataHelper.info.NeedLegionSize = RankDataHelper.GetPvpLegionSize(aimRankInfo.Rank);
				OpenBattleScene(response.BattleId);
				ThinkingDataHelper.Instance.PvpBattleStart();
				GameManagers.Instance.Messenger.Broadcast("PVP_RANK_BATTLE_START");
			}
		});
	}

	private void OpenBattleScene(string battleid)
	{
		if (UI_LadderTournamentPanel.LadderTournamentPanel?.updatePanelCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(UI_LadderTournamentPanel.LadderTournamentPanel?.updatePanelCoroutine);
		}
		UI_Battle.fadeBeforeStarting = true;
		CommandFactory.CreateOpenSceneCommand("BattleField", new SceneBattleFieldArguments(new Dictionary<string, object>
		{
			{ "LevelId", "RankBattleFieldLevel" },
			{ "Asset", "Prefabs/BattleField" },
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{
				"LoadedCallback",
				(Action<string>)delegate
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_StartRankBattleCountdown.Name, new Dictionary<string, object> { { "BattleId", battleid } });
					WaitToStartBattle(battleid);
					WaitToStartBattle(battleid);
				}
			}
		}));
	}

	private async void WaitToStartBattle(string battleid)
	{
		GameLocalDataManager.ClearReplayCache();
		ClientBattleFieldLogic.CleanChangeDifferentBattleConfig();
		GameManagers.Instance.UserArchiveManager.SetCurrentBattleId(battleid);
	}

	private void SetFormationUnitsOfRank(int rank)
	{
		List<string> formationsId = new List<string>();
		List<List<string>> unitsId = new List<List<string>>();
		foreach (SelectFormation value in selectEnemyFormations.Data.Values)
		{
			formationsId.Add(value.FormationId);
			unitsId.Add(value.SoldiersId.ToList());
		}
		ILRequestHelper<SetFormationUnitsOfRankResponse>.Request((EventContext)null, (Func<Task<SetFormationUnitsOfRankResponse>>)(() => GameController.Contexts.Service<INetworkService>().SetFormationUnitsOfRank(rank, formationsId, unitsId)), (Action<SetFormationUnitsOfRankResponse>)delegate(SetFormationUnitsOfRankResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText478") };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
		});
	}

	private void GetUserRankList(int fromRank, int ranksSize, Action action)
	{
		ILRequestHelper<GetRankListResponse>.Request((EventContext)null, (Func<Task<GetRankListResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetRankList()), (Action<GetRankListResponse>)delegate(GetRankListResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				int aimRank = fromRank - ranksSize + 1;
				_rankSummaryList = response.RankSummaryList;
				GetAimRankInfo(aimRank);
				ShowEnemyInfo();
				action();
			}
		});
	}

	private void GetDetailInfo(int rank)
	{
		if (aimRankInfo == null)
		{
			return;
		}
		ILRequestHelper<GetDetailRankInfoResponse>.Request((EventContext)null, (Func<Task<GetDetailRankInfoResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetDetailRankInfo(-1L, rank, aimRankInfo.LastRequestAt)), (Action<GetDetailRankInfoResponse>)delegate(GetDetailRankInfoResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				RankBattleConfig rankBattleConfig = response.EnemyRankRecord.RankBattleConfig;
				_enemyUnits = rankBattleConfig._units;
				unitsTotal = rankBattleConfig.UnitsTotal;
				enemyEquipments = response.EnemyRankRecord.RankBattleConfigDetails.SoldierEquipments;
				rankBattleConfig.TryCopyLegendItemBrief(enemyEquipments);
				UpdateEnemyRankData(rankBattleConfig._unitsId, rankBattleConfig.SoldiersDetail, rankBattleConfig.FormationId);
				ShowReceivedEnemyFormation();
				RenderEnemyArrayIndex();
			}
		});
	}

	private void GetSelfRank()
	{
		ILRequestHelper<GetSelfRankResponse>.Request((EventContext)null, (Func<Task<GetSelfRankResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetSelfRank(-1L)), (Action<GetSelfRankResponse>)delegate(GetSelfRankResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				((GObject)GetRankBtn.size).text = $"{response.Rank}";
				ShowUserInfo(response.Rank);
			}
		});
	}

	private void ShowSomeRankInfo(int _size, int _fromRank)
	{
		List<string> list = new List<string>();
		int num = ((_fromRank <= 0) ? 500 : _fromRank);
		if (num > 500)
		{
			list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText495") + "fromRank" + LanguagesManager.GetDesc("CsharpCodeZhTcText496") + "500");
			SharedMessenger.Broadcast("SHOW_TIPS", list, 1, arg3: false);
			return;
		}
		if (_size > 10 || _size <= 0)
		{
			list.Add("_size" + LanguagesManager.GetDesc("CsharpCodeZhTcText497") + "0" + LanguagesManager.GetDesc("CsharpCodeZhTcText498") + "10");
			SharedMessenger.Broadcast("SHOW_TIPS", list, 1, arg3: false);
			return;
		}
		_size++;
		int aimRank = num - _size + 1;
		if (aimRank <= 0)
		{
			list.Add(LanguagesManager.GetDesc("CsharpCodeZhTcText499") + "1~500");
			SharedMessenger.Broadcast("SHOW_TIPS", list, 1, arg3: false);
			return;
		}
		Type.selectedIndex = 1;
		Action action = delegate
		{
			((GObject)ChallengeBtn.level).text = aimRank.ToString();
			GetDetailInfo(aimRank);
		};
		GetUserRankList(num, _size, action);
	}

	private void GetAimRankInfo(int aimRank)
	{
		if (_rankSummaryList == null || _rankSummaryList.Count <= 0)
		{
			return;
		}
		for (int num = _rankSummaryList.Count - 1; num >= 0; num--)
		{
			if (aimRank == _rankSummaryList[num].Rank)
			{
				aimRankInfo = _rankSummaryList[num];
				aimRankInfo.CheckValid();
				break;
			}
		}
	}

	private void TestBtnsVisible()
	{
		((GObject)TestBtns).visible = !((GObject)TestBtns).visible;
	}

	public void UpdateSelectedEnemySoldierId(string _sid, bool isAdd)
	{
		if (isAdd)
		{
			if (!selectedEnemySoldierId.Contains(_sid))
			{
				selectedEnemySoldierId.Add(_sid);
			}
		}
		else if (selectedEnemySoldierId.Contains(_sid))
		{
			selectedEnemySoldierId.Remove(_sid);
		}
	}

	private bool SaveEnemyDataLocal()
	{
		bool result = selectEnemyFormations.CheckValid();
		GameLocalDataManager.SetString("PVP_Rank_EnemyConfig", JsonHelper.ToJson(selectEnemyFormations.Data));
		return result;
	}

	private void LoadEnemyDataLocal()
	{
		selectEnemyFormations.Data = null;
		string text = GameLocalDataManager.GetString("PVP_Rank_EnemyConfig");
		if (!string.IsNullOrEmpty(text))
		{
			selectEnemyFormations.Data = JsonHelper.ToObject<Dictionary<string, SelectFormation>>(text);
		}
		selectEnemyFormations.CheckValid();
		foreach (KeyValuePair<string, SelectFormation> datum in selectEnemyFormations.Data)
		{
			for (int i = 0; i < datum.Value.SoldiersId.Count; i++)
			{
				string text2 = datum.Value.SoldiersId[i];
				if (!string.IsNullOrEmpty(text2) && text2 != "Lock" && text2 != "Unlock")
				{
					selectedEnemySoldierId.Add(text2);
				}
			}
		}
	}

	private void UpdateEnemyRankData(List<List<string>> unitsId, List<List<SoldierDetail>> soldiersDetail, string[] formationId)
	{
		selectEnemyFormations.Data = null;
		if (unitsId != null && formationId != null && unitsId.Count > 0 && formationId.Length != 0)
		{
			selectEnemyFormations.Data = new Dictionary<string, SelectFormation>();
			for (int i = 0; i < formationId.Length; i++)
			{
				SelectFormation value = new SelectFormation(i)
				{
					FormationId = formationId[i],
					SoldiersId = ((unitsId.Count > i) ? unitsId[i] : null),
					SoldiersDetail = ((soldiersDetail != null && soldiersDetail.Count > i) ? soldiersDetail[i] : null)
				};
				selectEnemyFormations.Data.Add(i.ToString(), value);
			}
		}
		selectEnemyFormations.CheckValid();
		selectedEnemySoldierId.Clear();
		foreach (KeyValuePair<string, SelectFormation> datum in selectEnemyFormations.Data)
		{
			for (int j = 0; j < datum.Value.SoldiersId.Count; j++)
			{
				string text = datum.Value.SoldiersId[j];
				if (!string.IsNullOrEmpty(text) && text != "Lock" && text != "Unlock")
				{
					selectedEnemySoldierId.Add(text);
				}
			}
		}
	}

	private void ShowCurEnemyFormation(string _arrayId = "")
	{
		curSelectEnemyFormationArrayId = (string.IsNullOrEmpty(_arrayId) ? selectEnemyFormations.Data.ToList().First().Key : _arrayId);
		EnemyStandardFormationSketchMap.SetOurPos(selectEnemyFormations.Data[curSelectEnemyFormationArrayId].FormationId, selectEnemyFormations.Data[curSelectEnemyFormationArrayId].SoldiersId, selectedEnemySoldierId, null, null, null, selectEnemyFormations.Data[curSelectEnemyFormationArrayId].SoldiersDetail);
	}

	private void ShowReceivedEnemyFormation(string _arrayId = "")
	{
		if (aimRankInfo == null)
		{
			return;
		}
		curSelectEnemyFormationArrayId = (string.IsNullOrEmpty(_arrayId) ? selectEnemyFormations.Data.ToList().First().Key : _arrayId);
		if (aimRankInfo == null || aimRankInfo.IsRecentBattle || !(curSelectEnemyFormationArrayId != "0"))
		{
			int num = int.Parse(curSelectEnemyFormationArrayId);
			if (selectEnemyFormations.Data.ContainsKey(curSelectEnemyFormationArrayId))
			{
				Dictionary<string, List<RankSoldierEquipmentsInfo>> soldierEquipments = ((enemyEquipments != null && enemyEquipments.Count > num) ? enemyEquipments[num] : null);
				EnemyStandardFormationSketchMap.SetOurPos(selectEnemyFormations.Data[curSelectEnemyFormationArrayId].FormationId, selectEnemyFormations.Data[curSelectEnemyFormationArrayId].SoldiersId, selectedEnemySoldierId, _enemyUnits[num], unitsTotal[num], soldierEquipments, selectEnemyFormations.Data[curSelectEnemyFormationArrayId].SoldiersDetail);
			}
		}
	}

	private void RenderEnemyArrayIndex()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		EnemyFormationsList.itemRenderer = new ListItemRenderer(RenderEnemyIndex);
		EnemyFormationsList.numItems = 3;
		if (EnemyFormationsList.numItems > 0)
		{
			GButton asButton = ((GComponent)EnemyFormationsList).GetChildAt(0).asButton;
			((GComponent)asButton).GetController("btnadd").selectedIndex = 1;
		}
	}

	private void RenderEnemyIndex(int index, GObject obj)
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		if (aimRankInfo == null)
		{
			return;
		}
		UI_ArrayIndex uI_ArrayIndex = obj as UI_ArrayIndex;
		((GObject)uI_ArrayIndex.indexText).text = $"{index + 1}";
		((GObject)uI_ArrayIndex.LockIcon).visible = false;
		if (index >= RankDataHelper.GetPvpLegionSize(aimRankInfo.Rank))
		{
			((GObject)uI_ArrayIndex).enabled = false;
			return;
		}
		((GObject)uI_ArrayIndex).enabled = true;
		if (!aimRankInfo.IsRecentBattle && index > 0)
		{
			((GObject)uI_ArrayIndex).onClick.Set(new EventCallback0(ShowCanNotClickTip));
			((GObject)uI_ArrayIndex.LockIcon).visible = true;
			return;
		}
		List<KeyValuePair<string, SelectFormation>> list = selectEnemyFormations.Data.ToList();
		if (index > list.Count - 1)
		{
			((GObject)uI_ArrayIndex).onClick.Clear();
			return;
		}
		string key = list[index].Key;
		((GObject)uI_ArrayIndex).data = key;
		((GObject)uI_ArrayIndex).onClick.Set(new EventCallback1(CheckSomeEnemyArray));
	}

	private void ShowCanNotClickTip()
	{
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText486") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder + 1, arg3: false);
	}

	private void CheckSomeEnemyArray(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		string arrayId = ((GObject)context.sender).data.ToString();
		if (Type.selectedIndex == 0)
		{
			ShowCurEnemyFormation(arrayId);
		}
		else if (Type.selectedIndex == 1)
		{
			ShowReceivedEnemyFormation(arrayId);
		}
		for (int i = 0; i < EnemyFormationsList.numItems; i++)
		{
			((GComponent)((GComponent)EnemyFormationsList).GetChildAt(i).asButton).GetController("btnadd").selectedIndex = 0;
		}
		UI_ArrayIndex uI_ArrayIndex = ((GObject)context.sender) as UI_ArrayIndex;
		((GComponent)uI_ArrayIndex).GetController("btnadd").selectedIndex = 1;
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

	private void DisplaySeasonBuff()
	{
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		if (!RankDataHelper.IsServerWideBattle)
		{
			((GObject)SeasonBuffLabel).visible = false;
			return;
		}
		BuffConfig buffConfig = RankDataHelper.RankSeasonInfo?.BuffConfig;
		if (buffConfig == null || string.IsNullOrEmpty(buffConfig.NormalBuff))
		{
			((GObject)SeasonBuffLabel).visible = false;
			return;
		}
		GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(buffConfig.NormalBuff);
		if (gDEAbilityData == null)
		{
			((GObject)SeasonBuffLabel).visible = false;
			return;
		}
		((GObject)SeasonBuffLabel).visible = true;
		SeasonBuffLabel.BuffIcon.icon.url = gDEAbilityData.Icon.ToPublicResourcesRgbIcon();
		SeasonBuffLabel.BuffIcon.Type.selectedIndex = 0;
		string capturedBuffId = buffConfig.NormalBuff;
		((GObject)SeasonBuffLabel.BuffIcon).onClick.Set((EventCallback1)delegate(EventContext context)
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			context.StopPropagation();
			GDEAbilityData gDEAbilityData2 = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(capturedBuffId);
			if (gDEAbilityData2 != null)
			{
				Vector2 val = ((GObject)GRoot.inst).GlobalToLocal(context.inputEvent.position);
				GameController.Contexts.Service<IUiService>().OpenPanel(UI_SkillDetailPopup.Name, new Dictionary<string, object>
				{
					{ "Pos", val },
					{ "Data", gDEAbilityData2 },
					{ "Limit", 1 },
					{ "State", true },
					{ "GList", null }
				});
			}
		});
	}
}
