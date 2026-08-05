using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameMaths;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using UI.InstanceZones;
using UI.PvpSelectSoldiers;
using UI.Tips;
using UnityEngine;

namespace UI.QuickBattle;

public class UI_QuickBattlePanel : GComponent, IUiController
{
	public Controller PageController;

	public GGraph Mask;

	public UI_BattleLoader Stage;

	public UI_OurInfomationBar OurInfomationBar;

	public UI_EnemyInfomationBar EnemyInfomationBar;

	public UI_BattleMiniMap BattleMiniMap;

	public GTextField playRate;

	public GGraph n47;

	public GImage flashImage1;

	public GTextField OurCombat;

	public GTextField n12;

	public GGroup PowerMine;

	public GGraph n48;

	public GImage flashImage2;

	public GTextField EnemyCombat;

	public GTextField n16;

	public GGroup PowerEnemy;

	public UI_MakeWar MakeWar;

	public UI_SoldierFormation OurFormation0;

	public UI_SoldierFormation OurFormation1;

	public UI_SoldierFormation OurFormation2;

	public UI_SoldierFormation OurFormation3;

	public UI_SoldierFormation OurFormation4;

	public UI_SoldierFormation OurFormation5;

	public UI_SoldierFormation OurFormation6;

	public UI_SoldierFormation OurFormation7;

	public UI_SoldierFormation OurFormation8;

	public UI_SoldierFormation EnemyFormation0;

	public UI_SoldierFormation EnemyFormation1;

	public UI_SoldierFormation EnemyFormation2;

	public UI_SoldierFormation EnemyFormation3;

	public UI_SoldierFormation EnemyFormation4;

	public UI_SoldierFormation EnemyFormation5;

	public UI_SoldierFormation EnemyFormation6;

	public UI_SoldierFormation EnemyFormation7;

	public UI_SoldierFormation EnemyFormation8;

	public GImage n38;

	public GGraph n49;

	public GImage n50;

	public GTextField n39;

	public GImage n40;

	public GImage n41;

	public GButton exitBtn;

	public Transition Disappear;

	public Transition Appear;

	public const string URL = "ui://kqd1t06of2580";

	public static string Name = "UI_QuickBattlePanel";

	public static UI_QuickBattlePanel QuickBattlePanel;

	private List<string> curSoldiers = new List<string>();

	private static List<Vector2> ourVector2s = new List<Vector2>();

	private static List<Vector2> enemyVector2s = new List<Vector2>();

	private string _userName;

	private List<string> CapturedLevels = new List<string>();

	public bool LevelSettling;

	private Action _nextStep;

	private Dictionary<string, Vector2> ourFormationPos = new Dictionary<string, Vector2>();

	private Dictionary<string, Vector2> enemyFormationPos = new Dictionary<string, Vector2>();

	private List<UI_SoldierFormation> ourFormations = new List<UI_SoldierFormation>();

	private List<UI_SoldierFormation> enemyFormations = new List<UI_SoldierFormation>();

	private const int MaxFormationsNum = 9;

	private List<int> emptyFormations = new List<int>();

	private Dictionary<int, GButton> soldierButtons = new Dictionary<int, GButton>();

	private int playDelay = 0;

	private const int delayLimit = 4;

	private int nextFrameIncrease;

	private const int StandardFrameRate = 30;

	private float realTotalTime = 0f;

	private const float TimeDifference = 0.1f;

	private const int MaxSkipFrameMultiple = 3;

	private bool loadingScene;

	private int loadSceneDelayFrames;

	private bool isMoveMap;

	private bool waitingNextWave;

	private bool waitingPvpNextWave;

	private int clearStages;

	private Vector2 fortBluePos;

	private int IncrementalFrame;

	private int curFrame;

	public Coroutine frameCoroutine;

	public Coroutine loadCoroutine;

	public Coroutine fallCoroutine;

	public Level curLevel;

	public Chapter Chapter;

	private List<int> falling = new List<int>();

	private List<string> shaderList = new List<string>();

	private int curFallIndex;

	private int totalFallCount;

	private const int maxFormationCount = 5;

	private const int FallingFrames = 3;

	private const int FallCountEveryTime = 5;

	private const int LegendItemsLimit = 2;

	private int MaxSubLevelCount = 3;

	private bool autoPlay;

	private bool isPortal;

	private string curFormationId;

	private bool isPvpBattle;

	private Action pvpStartBattleAction;

	private long lastBattleFinishAt;

	private int targetRank;

	private int instanceZonesType;

	private Dictionary<string, string> soldierIconCache = new Dictionary<string, string>();

	private List<Obstacle> obstacles = new List<Obstacle>();

	private bool showSoldiersNumTip;

	private bool showDispatchSoldierTip;

	private const int MaxAvailableFormationNum = 5;

	public int CurrentLevelIndex
	{
		get
		{
			if (!curLevel.HasSubLevels())
			{
				return 0;
			}
			return GameController.Contexts.gameState.hasBattleFieldSubLevelIndex ? GameController.Contexts.gameState.battleFieldSubLevelIndex.value : (curLevel.SubLevels.Count - 1);
		}
	}

	public Level CurrentLevel
	{
		get
		{
			if (!curLevel.HasSubLevels())
			{
				return curLevel;
			}
			if (GameController.Contexts.gameState.hasBattleFieldSubLevelIndex)
			{
				ChapterManager.Levels.TryGetValue(curLevel.SubLevels[GameController.Contexts.gameState.battleFieldSubLevelIndex.value], out var level);
				return level;
			}
			ChapterManager.Levels.TryGetValue(curLevel.SubLevels.Last(), out var level2);
			return level2;
		}
	}

	public static string GetURL()
	{
		return "ui://kqd1t06of2580";
	}

	public static UI_QuickBattlePanel CreateInstance()
	{
		return (UI_QuickBattlePanel)(object)UIPackage.CreateObject("QuickBattle", "QuickBattlePanel");
	}

	public static UI_QuickBattlePanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QuickBattlePanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of2580", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
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
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Expected O, but got Unknown
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Expected O, but got Unknown
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Expected O, but got Unknown
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Expected O, but got Unknown
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Expected O, but got Unknown
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Expected O, but got Unknown
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Stage = (UI_BattleLoader)(object)((GComponent)this).GetChild("Stage");
		OurInfomationBar = (UI_OurInfomationBar)(object)((GComponent)this).GetChild("OurInfomationBar");
		EnemyInfomationBar = (UI_EnemyInfomationBar)(object)((GComponent)this).GetChild("EnemyInfomationBar");
		BattleMiniMap = (UI_BattleMiniMap)(object)((GComponent)this).GetChild("BattleMiniMap");
		playRate = (GTextField)((GComponent)this).GetChild("playRate");
		string id = "ui://kqd1t06of2580".Replace("ui://", "") + "-" + ((GObject)playRate).id;
		((GObject)playRate).text = LanguagesManager.GetDesc(id);
		n47 = (GGraph)((GComponent)this).GetChild("n47");
		flashImage1 = (GImage)((GComponent)this).GetChild("flashImage1");
		OurCombat = (GTextField)((GComponent)this).GetChild("OurCombat");
		n12 = (GTextField)((GComponent)this).GetChild("n12");
		string id2 = "ui://kqd1t06of2580".Replace("ui://", "") + "-" + ((GObject)n12).id;
		((GObject)n12).text = LanguagesManager.GetDesc(id2);
		PowerMine = (GGroup)((GComponent)this).GetChild("PowerMine");
		n48 = (GGraph)((GComponent)this).GetChild("n48");
		flashImage2 = (GImage)((GComponent)this).GetChild("flashImage2");
		EnemyCombat = (GTextField)((GComponent)this).GetChild("EnemyCombat");
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id3 = "ui://kqd1t06of2580".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id3);
		PowerEnemy = (GGroup)((GComponent)this).GetChild("PowerEnemy");
		MakeWar = (UI_MakeWar)(object)((GComponent)this).GetChild("MakeWar");
		OurFormation0 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation0");
		OurFormation1 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation1");
		OurFormation2 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation2");
		OurFormation3 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation3");
		OurFormation4 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation4");
		OurFormation5 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation5");
		OurFormation6 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation6");
		OurFormation7 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation7");
		OurFormation8 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("OurFormation8");
		EnemyFormation0 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("EnemyFormation0");
		EnemyFormation1 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("EnemyFormation1");
		EnemyFormation2 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("EnemyFormation2");
		EnemyFormation3 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("EnemyFormation3");
		EnemyFormation4 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("EnemyFormation4");
		EnemyFormation5 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("EnemyFormation5");
		EnemyFormation6 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("EnemyFormation6");
		EnemyFormation7 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("EnemyFormation7");
		EnemyFormation8 = (UI_SoldierFormation)(object)((GComponent)this).GetChild("EnemyFormation8");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n49 = (GGraph)((GComponent)this).GetChild("n49");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		n39 = (GTextField)((GComponent)this).GetChild("n39");
		string id4 = "ui://kqd1t06of2580".Replace("ui://", "") + "-" + ((GObject)n39).id;
		((GObject)n39).text = LanguagesManager.GetDesc(id4);
		n40 = (GImage)((GComponent)this).GetChild("n40");
		n41 = (GImage)((GComponent)this).GetChild("n41");
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		Disappear = ((GComponent)this).GetTransition("Disappear");
		Appear = ((GComponent)this).GetTransition("Appear");
	}

	public void BeforeDestroy()
	{
		QuickBattlePanel = null;
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		QuickBattlePanel = this;
		if (parameters.TryGetValue("CurLevel", out var value))
		{
			curLevel = (Level)value;
			curLevel.FromUiParams = QuickPlayReplayService.returnUiParams;
		}
		else
		{
			End();
		}
		if (parameters.TryGetValue("Type", out var value2))
		{
			instanceZonesType = (int)value2;
		}
		if (parameters.TryGetValue("Auto", out var value3))
		{
			autoPlay = (bool)value3;
		}
		if (parameters.TryGetValue("IsPortal", out var value4))
		{
			isPortal = (bool)value4;
		}
		if (parameters.TryGetValue("OurFormationId", out var value5))
		{
			curFormationId = value5?.ToString();
		}
		if (parameters.TryGetValue("IsPvpBattle", out var value6))
		{
			isPvpBattle = (bool)value6;
			pvpStartBattleAction = (Action)parameters["StartPvpBattleAction"];
			if (isPvpBattle)
			{
				((GObject)this).alpha = 0f;
			}
		}
		if (parameters.TryGetValue("lastFinishAt", out var value7))
		{
			lastBattleFinishAt = (long)value7;
		}
		if (parameters.TryGetValue("TargetRank", out var value8))
		{
			targetRank = (int)value8;
		}
		if (parameters.TryGetValue("UserName", out var value9))
		{
			_userName = (string)value9;
		}
		else
		{
			_userName = string.Empty;
		}
		IncrementalFrameInit();
		FormationsInit();
		RenderLevelInfo();
		BattleMiniMapInit();
		TaEnterLevel();
	}

	public void OnShow()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		PageController.selectedIndex = 0;
		if (autoPlay)
		{
			((GObject)MakeWar).touchable = false;
			((GObject)exitBtn).touchable = false;
			((GComponent)(object)this).SetTimeout(1f).OnComplete((GTweenCallback)delegate
			{
				GetLevelPlays();
			});
		}
		GObject showingUi = GameController.Contexts.Service<IUiService>().GetShowingUi(UI_InstanceZonesPanel.Name);
		((UI_InstanceZonesPanel)(object)showingUi)?.SetQuickBattlePanelBackVisible(_visible: true, 0.8f);
		if (isPvpBattle)
		{
			((GObject)this).touchable = false;
			PageController.selectedIndex = 2;
			if (((GObject)this).parent != null)
			{
				((GObject)this).parent.GetChildAt(0).alpha = 0f;
			}
			Stage.Type.selectedIndex = 1;
			((GComponent)(object)this).SetTimeout(0.75f).OnComplete(new GTweenCallback(GetLevelPlays));
		}
	}

	private void IncrementalFrameInit()
	{
		IncrementalFrame = 2;
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("OverlordContract") > 0)
		{
			IncrementalFrame = 4;
		}
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("PrimeContract") > 0)
		{
			IncrementalFrame = 6;
		}
		((GObject)playRate).text = string.Format("{0} {1}x", LanguagesManager.GetDesc("CsharpCodeZhTcText513"), IncrementalFrame);
	}

	private void EnableMaincityMonobehaviour()
	{
		GameController.Contexts.Service<BaseSceneService>().EnableMainCity(new Dictionary<MainCityEnableCommand, bool>
		{
			{
				MainCityEnableCommand.MonoBehaviour,
				false
			},
			{
				MainCityEnableCommand.Produce,
				false
			}
		});
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)exitBtn).onClick.Add(new EventCallback0(CloseMask));
		((GObject)MakeWar).onClick.Add(new EventCallback0(GetLevelPlays));
		((GObject)MakeWar).onClick.Add(new EventCallback0(EnableMaincityMonobehaviour));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)exitBtn).onClick.Remove(new EventCallback0(CloseMask));
		((GObject)MakeWar).onClick.Remove(new EventCallback0(GetLevelPlays));
		((GObject)MakeWar).onClick.Remove(new EventCallback0(EnableMaincityMonobehaviour));
	}

	private void RenderLevelInfo()
	{
		((GProgressBar)OurInfomationBar.HPBar).value = 100.0;
		((GProgressBar)EnemyInfomationBar.HPBar).value = 100.0;
		SetBattleUiUserInfo();
		SetEnemyInfo();
		if (!isPvpBattle)
		{
			SetBattleCombatPower();
		}
	}

	public void GetBattleResult(bool try_again = true)
	{
		SharedMessenger.Broadcast("STOP_QUICK_PLAY_REPLAY_WATCHER", QuickPlayReplayService.info.BattleId);
		QuickPlayReplayService.info.Clear();
		typeof(Interface_Battle).GetMethod("Destroy")?.Invoke(null, null);
		if (isPvpBattle)
		{
			GameController.Contexts.Service<IBattleFieldService>().GetRankBattleResult();
			return;
		}
		if (curLevel != null)
		{
			Chapter = GameManagers.Instance.ChapterManager.GetChapter(curLevel.ChapterId);
		}
		ILRequestHelper<GetBattleResultResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().GetBattleResult(-1L, QuickPlayReplayService.info.BattleId, QuickPlayReplayService.info.LevelId), delegate(GetBattleResultResponse response)
		{
			if (!response.Result)
			{
				if (try_again)
				{
					ILRuntimeDebug.LogError("QuickPlayReplayService " + QuickPlayReplayService.info.BattleId + " response Result is False,Now Try Again");
					ScriptApi.CreateTimer(1f, delegate
					{
						GetBattleResult(try_again: false);
					});
				}
				else
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
			}
			else
			{
				ProcessBattleResult(response);
			}
		}, 1f);
	}

	public void ProcessBattleResult(GetBattleResultResponse response)
	{
		Team winner = (Team)response.Winner;
		GameManagers.Instance.UserArchiveManager.SaveLevelEnemiesHp(curLevel, winner, response.BlueTeamHp);
		Activity result = GameManagers.Instance.ActivityManager.GetLevelActivityAsync(curLevel).GetAwaiter().GetResult();
		if (result == null || result.Type != ActivityType.TreasureHunt)
		{
			ClientBattleFieldLogic.UpdateSoldierStockWhenBattleEnd(GameManagers.Instance, response.RedTeamDeadStats);
		}
		List<string> soldierIdsInDeadStats = response.RedTeamDeadStats.Keys.ToList();
		ILRequestHelper<SyncStockResponse>.Request(null, () => GameController.Contexts.Service<INetworkService>().SyncStock(-1L, syncAllStock: false, soldierIdsInDeadStats), delegate(SyncStockResponse syncStockResponse)
		{
			if (!syncStockResponse.Result)
			{
				ILRuntimeDebug.LogError("战斗结束，同步士兵库存失败");
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				return;
			}
			foreach (KeyValuePair<string, int> stock in syncStockResponse.Stocks)
			{
				string key = stock.Key;
				int value = stock.Value;
				GameManagers.Instance.StockController.SetStock(key, value, StockInContext.AutoFill);
			}
		}, 1f);
		GameManagers.Instance.Messenger.Broadcast("BEFORE_LEVEL_COMPLETED", curLevel, (int)winner);
		ScriptApi.CreateTimer(2f, delegate
		{
			BattleEnd(response);
		});
	}

	public void BattleEnd(GetBattleResultResponse getBattleResultResponse)
	{
		if (!LevelSettling)
		{
			LevelSettling = true;
			_nextStep = async delegate
			{
				await ShowBattleBonuses(getBattleResultResponse);
				End();
			};
			if (curLevel.Chapter.Type == ChapterType.StoryMain)
			{
				CheckStoryPlayList();
				return;
			}
			_nextStep?.Invoke();
			_nextStep = null;
		}
	}

	public void CheckStoryPlayList(string storyId = null)
	{
		List<string> playingStories = GameManagers.Instance.StoryManager.PlayingStories;
		if (playingStories.Count <= 0)
		{
			_nextStep?.Invoke();
			_nextStep = null;
		}
	}

	public static string[,] GetUnitsFromBattleResultResponse(List<UnitBornRecord[]> records)
	{
		if (records == null)
		{
			return null;
		}
		int count = records.Count;
		string[,] array = new string[count, 12];
		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < records[i].Length; j++)
			{
				array[i, j] = records[i][j].UnitId;
			}
		}
		return array;
	}

	public static int[,] GetUnitsTotalFromBattleResultResponse(List<UnitBornRecord[]> records)
	{
		if (records == null)
		{
			return null;
		}
		int count = records.Count;
		int[,] array = new int[count, 12];
		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < records[i].Length; j++)
			{
				array[i, j] = records[i][j].Born;
			}
		}
		return array;
	}

	public static Dictionary<Team, BattleResultStats> GetBattleResultStats(GetBattleResultResponse response)
	{
		QuickPlayReplayService.BattleResultStats.Clear();
		QuickPlayReplayService.BattleResultStats = new Dictionary<Team, BattleResultStats>();
		QuickPlayReplayService.BattleResultStats.Add(Team.Red, new BattleResultStats
		{
			Units = GetUnitsFromBattleResultResponse(response.RedTeamBornRecords),
			UnitsTotal = GetUnitsTotalFromBattleResultResponse(response.RedTeamBornRecords),
			UnitsDead = response.RedTeamDeadStats,
			UnitsDamage = new Dictionary<string, float>(response.RedTeamDamageStats),
			CurrentHp = response.RedTeamHp.Sum((List<float> hp) => hp.Sum()),
			TotalHp = response.RedTeamHpTotal
		});
		QuickPlayReplayService.BattleResultStats.Add(Team.Blue, new BattleResultStats
		{
			Units = GetUnitsFromBattleResultResponse(response.BlueTeamBornRecords),
			UnitsTotal = GetUnitsTotalFromBattleResultResponse(response.BlueTeamBornRecords),
			UnitsDead = response.BlueTeamDeadStats,
			UnitsDamage = new Dictionary<string, float>(response.BlueTeamDamageStats),
			CurrentHp = response.BlueTeamHp.Sum((List<float> hp) => hp.Sum()),
			TotalHp = response.BlueTeamHpTotal
		});
		return QuickPlayReplayService.BattleResultStats;
	}

	private async Task ShowBattleBonuses(GetBattleResultResponse getBattleResultResponse)
	{
		clearStages = QuickPlayReplayService.info.SubLevelIndex + 1;
		UnpdateOffensiveProgress(isEnd: true, clearStages);
		CapturedLevels.Clear();
		Team winner = (Team)getBattleResultResponse.Winner;
		string battleId = QuickPlayReplayService.info.BattleId;
		Activity activityOfLevel = await GameManagers.Instance.ActivityManager.GetLevelActivityAsync(curLevel);
		if (activityOfLevel != null && winner == Team.Red)
		{
			GameManagers.Instance.ChapterManager.StatsInstanceLevel(activityOfLevel.ActivityId, CurrentLevel.LevelId, clearStages);
		}
		await ILRequestHelper<GetBattleBonusResponse>.RequestAsync(null, () => GameController.Contexts.Service<INetworkService>().GetBattleBonus(battleId, CurrentLevel.LevelId), delegate(GetBattleBonusResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				int num = ((winner == Team.Red) ? 1 : (-1));
				if (num == 1)
				{
					if (curLevel.BattleMode == BattleMode.MultiWaveAttackMode)
					{
						CapturedLevels.Add(CurrentLevel.LevelId);
						if (curLevel.HasSubLevels() && CapturedLevels.Count == curLevel.SubLevels.Count)
						{
							CapturedLevels.Add(curLevel.LevelId);
						}
					}
					else
					{
						CapturedLevels.Add(curLevel.LevelId);
					}
				}
				QuickPlayReplayService.info.result = num;
				Dictionary<string, object> dictionary = new Dictionary<string, object>
				{
					{ "result", num },
					{
						"stats",
						GetBattleResultStats(getBattleResultResponse)
					},
					{ "QuickBattle", true },
					{ "IsPortal", isPortal },
					{ "BattleId", battleId }
				};
				UpdateShowSoldiersNumTip();
				if (showSoldiersNumTip)
				{
					dictionary.Add("ShowSoldiersNumTip", true);
				}
				if (getBattleResultResponse.CanBackInTime)
				{
					dictionary.Add("CanBackInTime", getBattleResultResponse.CanBackInTime);
					dictionary.Add("FreeCount", getBattleResultResponse.ContractFreeBackInTimeTimes);
					dictionary.Add("Cost", getBattleResultResponse.BackInTimeCost);
				}
				Dictionary<string, List<Bonus>> dictionary2 = new Dictionary<string, List<Bonus>>();
				List<Bonus> list = new List<Bonus>();
				if (response.Bonuses != null && response.Bonuses.Count > 0)
				{
					foreach (KeyValuePair<string, BonusList> bonuse in response.Bonuses)
					{
						BonusList value = bonuse.Value;
						if (value != null && value.Value != null && value.Value.Count != 0)
						{
							foreach (ModelsBonus item in value.Value)
							{
								Bonus bonus = Bonus.Get(item.ItemId, item.Qty, item.Type);
								bonus.IsShining = item.IsShining;
								if (curLevel.BattleMode == BattleMode.MultiWaveAttackMode && bonuse.Key == CurrentLevel.LevelId && CapturedLevels.Contains(bonuse.Key))
								{
									list.Add(bonus);
								}
								else if (curLevel.BattleMode != BattleMode.MultiWaveAttackMode && CapturedLevels.Contains(bonuse.Key))
								{
									list.Add(bonus);
								}
								if (!dictionary2.TryGetValue(bonuse.Key, out var value2))
								{
									value2 = new List<Bonus>();
									dictionary2.Add(bonuse.Key, value2);
								}
								value2.Add(bonus);
							}
						}
					}
				}
				List<Bonus> list2 = new List<Bonus>();
				if (response.LotteryBonuses != null && response.LotteryBonuses.Count > 0)
				{
					foreach (KeyValuePair<string, BonusList> lotteryBonuse in response.LotteryBonuses)
					{
						BonusList value3 = lotteryBonuse.Value;
						if (value3 != null && value3.Value != null && value3.Value.Count != 0)
						{
							foreach (ModelsBonus item2 in value3.Value)
							{
								Bonus bonus2 = Bonus.Get(item2.ItemId, item2.Qty, item2.Type);
								bonus2.IsShining = item2.IsShining;
								list2.Add(bonus2);
							}
						}
					}
				}
				dictionary.Add("fixBonuses", dictionary2);
				dictionary.Add("lotteryBonuses", list2);
				dictionary.Add("capturedLevels", CapturedLevels);
				if (num == 1 || curLevel.BattleMode == BattleMode.MultiWaveAttackMode)
				{
					GameStateContext gameState = GameController.Contexts.gameState;
					BattleProgressStatsComponent battleProgressStats = gameState.battleProgressStats;
					if (num == 1)
					{
						if (!GameController.Contexts.gameState.hasBattleFieldSubLevelIndex && curLevel.HasSubLevels())
						{
							battleProgressStats.clearStages = curLevel.SubLevels.Count;
						}
						else
						{
							battleProgressStats.clearStages = CurrentLevelIndex + 1;
						}
						if (battleProgressStats.bonusRecord == null)
						{
							battleProgressStats.bonusRecord = new List<Bonus>();
						}
						List<(string, int)> list3 = new List<(string, int)>();
						foreach (Bonus item3 in battleProgressStats.bonusRecord)
						{
							list3.Add((item3.ItemId, item3.Type));
						}
						foreach (Bonus item4 in list)
						{
							int num2 = list3.IndexOf((item4.ItemId, item4.Type));
							if (num2 == -1)
							{
								list3.Add((item4.ItemId, item4.Type));
								battleProgressStats.bonusRecord.Add(item4);
							}
							else
							{
								battleProgressStats.bonusRecord[num2].Merge(item4);
							}
						}
					}
					dictionary.Add("clearStages", clearStages);
					dictionary.Add("stages", curLevel.SubLevels.Count);
					dictionary.Add("level", curLevel);
					QuickPlayReplayService.MaxBattleCount--;
					if (QuickPlayReplayService.MaxBattleCount > 0)
					{
						dictionary.Add("TicketNum", true);
					}
					GameController.Contexts.Service<IUiService>().OpenPanel("UI_GameEndPanelVictory", dictionary);
					if (curLevel.BattleMode != BattleMode.MultiWaveAttackMode || num == 1)
					{
						List<string> chapterLevelProgress = GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress(curLevel.ChapterId);
						bool flag = chapterLevelProgress == null || !chapterLevelProgress.Contains(curLevel.LevelId);
						if (curLevel.HasSubLevels())
						{
							foreach (string subLevel in curLevel.SubLevels)
							{
								ChapterManager.Levels.TryGetValue(subLevel, out var level);
								level.Accomplish(GameManagers.Instance);
							}
						}
						curLevel.Accomplish(GameManagers.Instance);
						GameManagers.Instance.Messenger.Broadcast("LEVEL_COMPLETED", battleId, CurrentLevel, (int)winner, flag);
						if (curLevel.HasSubLevels() && clearStages >= curLevel.SubLevels.Count)
						{
							GameManagers.Instance.Messenger.Broadcast("LEVEL_COMPLETED", battleId, curLevel, (int)winner, flag);
						}
						chapterLevelProgress = GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress(curLevel.ChapterId);
						if (Chapter.Level_IDs.Count <= chapterLevelProgress.Count)
						{
							GameManagers.Instance.Messenger.Broadcast("CHAPTER_COMPLETE", curLevel.ChapterId, flag);
						}
					}
					else
					{
						GameManagers.Instance.Messenger.Broadcast("LEVEL_COMPLETED", battleId, curLevel, (int)winner, arg4: false);
					}
				}
				else
				{
					GameController.Contexts.Service<IUiService>().OpenPanel("UI_GameEndPanelFail", dictionary);
					GameManagers.Instance.Messenger.Broadcast("LEVEL_COMPLETED", battleId, curLevel, (int)winner, arg4: false);
				}
			}
		});
	}

	private void SetBattleCombatPower()
	{
		if (string.IsNullOrWhiteSpace(curFormationId))
		{
			ILRequestHelper<GetFormationInfoResponse>.Request((EventContext)null, (Func<Task<GetFormationInfoResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetFormationInfo(-1L, curLevel.LevelId)), (Action<GetFormationInfoResponse>)delegate(GetFormationInfoResponse response)
			{
				if (!response.Result)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					SetFormationInfo(response.FormationId);
				}
			});
		}
		else
		{
			SetFormationInfo(curFormationId);
		}
	}

	private void SetFormationInfo(string _formationId)
	{
		SetOurPos(_formationId);
		switch (instanceZonesType)
		{
		case 0:
			SetEnemyPos(curLevel.Data.BlueFormationId);
			break;
		case 1:
		{
			ChapterManager.Levels.TryGetValue(curLevel.SubLevels[0], out var level);
			SetEnemyPos(level.Data.BlueFormationId);
			break;
		}
		case 2:
			SetEnemyPos(curLevel.Data.BlueFormationId);
			break;
		}
		OnAnyBattleFieldLevel();
	}

	private void SetOurPos(string fid)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		Formation formation = FormationManager.Formations[fid];
		Dictionary<string, Vector2> dictionary = new Dictionary<string, Vector2>
		{
			{
				"8.3_3.4",
				ourVector2s[7]
			},
			{
				"8.3_0",
				ourVector2s[0]
			},
			{
				"8.3_-3.4",
				ourVector2s[5]
			},
			{
				"4.9_3.4",
				ourVector2s[1]
			},
			{
				"4.9_0",
				ourVector2s[3]
			},
			{
				"4.9_-3.4",
				ourVector2s[2]
			},
			{
				"1.5_3.4",
				ourVector2s[8]
			},
			{
				"1.5_0",
				ourVector2s[4]
			},
			{
				"1.5_-3.4",
				ourVector2s[6]
			}
		};
		for (int i = 0; i < 5; i++)
		{
			if (formation.SlotPosition.ContainsKey(i))
			{
				string key = $"{formation.SlotPosition[i].x}_{formation.SlotPosition[i].y}";
				if (dictionary.ContainsKey(key))
				{
					((GObject)ourFormations[i]).xy = dictionary[key];
					dictionary.Remove(key);
				}
			}
		}
		List<Vector2> list = new List<Vector2>();
		foreach (KeyValuePair<string, Vector2> item in dictionary)
		{
			list.Add(item.Value);
		}
		for (int j = 5; j < ourFormations.Count; j++)
		{
			((GObject)ourFormations[j]).xy = list[j - 5];
		}
	}

	private void SetEnemyPos(string fid)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		Formation formation = FormationManager.Formations[fid];
		Dictionary<string, Vector2> dictionary = new Dictionary<string, Vector2>
		{
			{
				"8.3_3.4",
				enemyVector2s[8]
			},
			{
				"8.3_0",
				enemyVector2s[4]
			},
			{
				"8.3_-3.4",
				enemyVector2s[6]
			},
			{
				"4.9_3.4",
				enemyVector2s[1]
			},
			{
				"4.9_0",
				enemyVector2s[3]
			},
			{
				"4.9_-3.4",
				enemyVector2s[2]
			},
			{
				"1.5_3.4",
				enemyVector2s[7]
			},
			{
				"1.5_0",
				enemyVector2s[0]
			},
			{
				"1.5_-3.4",
				enemyVector2s[5]
			}
		};
		for (int i = 0; i < 5; i++)
		{
			if (formation.SlotPosition.ContainsKey(i))
			{
				string key = $"{formation.SlotPosition[i].x}_{formation.SlotPosition[i].y}";
				if (dictionary.ContainsKey(key))
				{
					((GObject)enemyFormations[i]).xy = dictionary[key];
					dictionary.Remove(key);
				}
			}
		}
		List<Vector2> list = new List<Vector2>();
		foreach (KeyValuePair<string, Vector2> item in dictionary)
		{
			list.Add(item.Value);
		}
		for (int j = 5; j < enemyFormations.Count; j++)
		{
			((GObject)enemyFormations[j]).xy = list[j - 5];
		}
	}

	public async void OnAnyBattleFieldLevel()
	{
		Level Level = curLevel;
		Chapter = GameManagers.Instance.ChapterManager.GetChapter(Level.ChapterId);
		GameStateContext gameState = GameController.Contexts.gameState;
		gameState.ReplaceBattleFieldMapIdentifier(Level.Data.MapIdentifier);
		gameState.ReplaceBattleFieldLength(Level.Data.Length);
		gameState.isBattleStarted = false;
		gameState.isCurrentLevelBattleStarted = false;
		BattleConfig redTeamBattleConfig = new BattleConfig();
		redTeamBattleConfig.BattleMode = (BattleMode)Level.Data.RedTeamBattleMode;
		if (redTeamBattleConfig.BattleMode == BattleMode.MultiWaveAttackMode)
		{
			Dictionary<string, int> pool = new Dictionary<string, int>();
			List<string> soldiers = GameManagers.Instance.UserArchiveManager.GetUnlockedSoldiers();
			foreach (string soldierId in soldiers)
			{
				pool.Add(soldierId, GameManagers.Instance.StockController.GetStock(soldierId));
			}
			redTeamBattleConfig.UnitsPool = pool;
		}
		redTeamBattleConfig.Obstacles = BattleFieldLogic.GetObstacles(Team.Red, Level);
		BattleConfig blueTeamBattleConfig = new BattleConfig();
		blueTeamBattleConfig.BattleMode = (BattleMode)Level.Data.BlueTeamBattleMode;
		blueTeamBattleConfig.Obstacles = BattleFieldLogic.GetObstacles(Team.Blue, Level);
		if (GameController.Contexts.config.hasFormationUnits)
		{
			BattleFieldLogic.UpdateFormationUnits(action: delegate
			{
				((GObject)OurCombat).text = CombatPower(redTeamBattleConfig.UnitsId, redTeamBattleConfig._units, redTeamBattleConfig.UnitsTotal).ToString();
				SetOurFormations(redTeamBattleConfig.UnitsId, redTeamBattleConfig.UnitsTotal, redTeamBattleConfig.UnitsPool, redTeamBattleConfig.UnitsBorn);
				SetDefensiveObstacles(redTeamBattleConfig.Obstacles);
				ShowOurIcons();
			}, managers: GameManagers.Instance, level: Level, team: Team.Red, battleConfig: redTeamBattleConfig);
		}
		if (string.IsNullOrEmpty(Level.Data.RedFormationId))
		{
			Activity activity = await GameManagers.Instance.ActivityManager.GetLevelActivityAsync(Level);
			string formationContext = ((activity == null) ? Level.FormationContext : activity.FormationTag);
			redTeamBattleConfig.FormationId[0] = GameManagers.Instance.UserArchiveManager.GetCurrentFormation(formationContext, Level.BattleMode.ToString());
		}
		BattleFieldLogic.UpdateFormationUnits(action: delegate
		{
			((GObject)EnemyCombat).text = CombatPower(blueTeamBattleConfig.UnitsId, blueTeamBattleConfig._units, blueTeamBattleConfig.UnitsTotal).ToString();
			SetEnemyFormations(blueTeamBattleConfig.UnitsId, blueTeamBattleConfig.UnitsTotal, blueTeamBattleConfig._units);
			ShowEnemyIcons();
		}, managers: GameManagers.Instance, level: Level, team: Team.Blue, battleConfig: blueTeamBattleConfig);
		redTeamBattleConfig.isRefresh = true;
		blueTeamBattleConfig.isRefresh = true;
	}

	public int CombatPower(List<List<string>> UnitsId, List<List<GameEntityData>> _units, int[,] UnitsTotal)
	{
		int count = UnitsId.Count;
		int[] array = new int[count];
		int count2 = UnitsId[0].Count;
		for (int i = 0; i < count; i++)
		{
			int num = 0;
			for (int j = 0; j < count2; j++)
			{
				GameEntityData gameEntityData = null;
				if (_units.Count <= i)
				{
					gameEntityData = null;
					continue;
				}
				if (_units[i].Count <= j)
				{
					gameEntityData = null;
					continue;
				}
				gameEntityData = _units[i][j];
				if (gameEntityData != null)
				{
					int num2 = UnitsTotal[i, j];
					num += _units[i][j].CombatPower * num2;
				}
			}
			array[i] = num;
		}
		return array[0];
	}

	private void SetBattleUiUserInfo()
	{
		OurInfomationBar.Avatar.Type.selectedIndex = 0;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, GameController.Contexts.gameState.user.value.UserId, OurInfomationBar.Avatar.Iconloader, OurInfomationBar.ArmyGroupName));
	}

	private void SetEnemyInfo()
	{
		EnemyInfomationBar.Avatar.Type.selectedIndex = 1;
		EnemyInfomationBar.Avatar.Iconloader.url = "ui://PublicResources/" + curLevel.EnemyTemplate.EnemyPortrait;
		((GObject)EnemyInfomationBar.ArmyGroupName).text = curLevel.Data.Name;
	}

	private void ShowEnemyIcons()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		if (autoPlay)
		{
			return;
		}
		float num = 0.05f;
		for (int i = 0; i < enemyFormations.Count; i++)
		{
			UI_SoldierFormation _btn = enemyFormations[i];
			((GComponent)(object)this).SetTimeout(num).OnComplete((GTweenCallback)delegate
			{
				_btn.ShowInfo.Play();
			});
			num += 0.05f;
		}
	}

	private void ShowOurIcons()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		if (autoPlay)
		{
			return;
		}
		float num = 0.05f;
		for (int i = 0; i < ourFormations.Count; i++)
		{
			UI_SoldierFormation _btn = ourFormations[i];
			((GComponent)(object)this).SetTimeout(num).OnComplete((GTweenCallback)delegate
			{
				_btn.ShowInfo.Play();
			});
			num += 0.05f;
		}
	}

	private void FormationsInit()
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		float num = 0.05f;
		for (int i = 0; i < 9; i++)
		{
			UI_SoldierFormation _redBtn = (UI_SoldierFormation)(object)((GComponent)this).GetChild($"OurFormation{i}");
			ourFormations.Add(_redBtn);
			ourVector2s.Add(((GObject)_redBtn).xy);
			if (autoPlay)
			{
				((GObject)_redBtn.Icon).alpha = 1f;
				((GObject)_redBtn.num).alpha = 1f;
				((GObject)_redBtn.n7).alpha = 1f;
				((GObject)_redBtn).alpha = 1f;
			}
			else
			{
				((GComponent)(object)this).SetTimeout(num).OnComplete((GTweenCallback)delegate
				{
					((GObject)_redBtn).TweenFade(1f, 0.1f);
				});
				num += 0.05f;
			}
		}
		for (int num2 = 0; num2 < 9; num2++)
		{
			UI_SoldierFormation _blueBtn = (UI_SoldierFormation)(object)((GComponent)this).GetChild($"EnemyFormation{num2}");
			enemyFormations.Add(_blueBtn);
			enemyVector2s.Add(((GObject)_blueBtn).xy);
			if (autoPlay)
			{
				((GObject)_blueBtn.Icon).alpha = 1f;
				((GObject)_blueBtn.num).alpha = 1f;
				((GObject)_blueBtn.n7).alpha = 1f;
				((GObject)_blueBtn).alpha = 1f;
			}
			else
			{
				((GComponent)(object)this).SetTimeout(num).OnComplete((GTweenCallback)delegate
				{
					((GObject)_blueBtn).TweenFade(1f, 0.1f);
				});
				num += 0.05f;
			}
		}
	}

	private void SetEnemyFormations(List<List<string>> units, int[,] UnitsTotal, List<List<GameEntityData>> _units)
	{
		int count = units.First().Count;
		for (int i = 0; i < enemyFormations.Count; i++)
		{
			if (count - 1 >= i)
			{
				string text = units[0][i];
				if (!string.IsNullOrWhiteSpace(text) && text != "Unlock" && text != "Lock")
				{
					GameEntityData entityData = _units[0][i];
					Soldier soldier = GameManagers.Instance.SoldierManager.Get(text);
					enemyFormations[i].Type.selectedIndex = 0;
					int num = UnitsTotal[0, i];
					((GObject)enemyFormations[i].num).text = $"{num}/{num}";
					RenderEnemyItem(soldier, enemyFormations[i].Icon, entityData);
				}
				else
				{
					enemyFormations[i].Type.selectedIndex = 1;
				}
			}
		}
	}

	private void SetDefensiveObstacles(Obstacle[] _obstacles)
	{
		if (instanceZonesType == 1)
		{
			obstacles.Clear();
			foreach (Obstacle item in _obstacles)
			{
				obstacles.Add(item);
			}
		}
	}

	private void SetOurFormations(List<List<string>> units, int[,] UnitsTotal, Dictionary<string, int> UnitsPool, Dictionary<string, int> UnitsBorn)
	{
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		int count = units.First().Count;
		for (int i = 0; i < ourFormations.Count; i++)
		{
			if (count - 1 < i)
			{
				continue;
			}
			string text = units[0][i];
			if (!string.IsNullOrWhiteSpace(text) && text != "Unlock" && text != "Lock")
			{
				curSoldiers.Add(text);
				Soldier soldier = GameManagers.Instance.SoldierManager.Get(text);
				ourFormations[i].Type.selectedIndex = 0;
				int num2 = GameManagers.Instance.StockController.GetStock(text);
				int soldierLevel = GameManagers.Instance.UserArchiveManager.GetSoldierLevel(text);
				int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(text, soldierLevel);
				num++;
				if (curLevel.BattleMode == BattleMode.MultiWaveAttackMode)
				{
					int num3 = 0;
					int num4 = 0;
					if (UnitsPool != null && UnitsBorn != null)
					{
						foreach (KeyValuePair<string, int> item in UnitsPool)
						{
							if (item.Key == text)
							{
								num3 = item.Value;
								break;
							}
						}
						foreach (KeyValuePair<string, int> item2 in UnitsBorn)
						{
							if (item2.Key == text)
							{
								num4 = item2.Value;
								break;
							}
						}
						num2 = num3 - num4;
					}
				}
				ourFormations[i].num.color = ((num2 < soldierFormationNumber) ? Color.red : Color.white);
				ourFormations[i].num.strokeColor = ((num2 < soldierFormationNumber) ? Color.white : Color.gray);
				((GObject)ourFormations[i].num).text = $"{num2}/{soldierFormationNumber}";
				if (num2 < soldierFormationNumber)
				{
					emptyFormations.Add(i);
				}
				if (!showSoldiersNumTip)
				{
					showSoldiersNumTip = num2 < soldierFormationNumber;
				}
				RenderSoldierItem(soldier, ourFormations[i].Icon);
			}
			else if (curLevel.BattleMode != BattleMode.DefenceMode && i < 5)
			{
				ourFormations[i].Type.selectedIndex = 0;
				((GObject)ourFormations[i].Icon).visible = false;
				((GObject)ourFormations[i].n7).visible = false;
				((GObject)ourFormations[i].num).visible = false;
				emptyFormations.Add(i);
			}
			else if (curLevel.BattleMode == BattleMode.DefenceMode)
			{
				ourFormations[i].Type.selectedIndex = 0;
				((GObject)ourFormations[i].Icon).visible = false;
				((GObject)ourFormations[i].n7).visible = false;
				((GObject)ourFormations[i].num).visible = false;
				emptyFormations.Add(i);
			}
			else
			{
				ourFormations[i].Type.selectedIndex = 1;
			}
		}
		showDispatchSoldierTip = num < 5;
	}

	private void PlayEmptyFormationsBreathe()
	{
		for (int i = 0; i < emptyFormations.Count; i++)
		{
			ourFormations[emptyFormations[i]].Breathe.Stop(true, true);
			ourFormations[emptyFormations[i]].Breathe.Play();
		}
	}

	private void UpdateShowSoldiersNumTip()
	{
		for (int i = 0; i < curSoldiers.Count; i++)
		{
			string text = curSoldiers[i];
			int stock = GameManagers.Instance.StockController.GetStock(text);
			int soldierLevel = GameManagers.Instance.UserArchiveManager.GetSoldierLevel(text);
			int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(text, soldierLevel);
			if (stock < soldierFormationNumber)
			{
				showSoldiersNumTip = true;
				break;
			}
		}
	}

	private void StartWarTip(Action action)
	{
		if (isPvpBattle)
		{
			action();
		}
		else if (showSoldiersNumTip || showDispatchSoldierTip)
		{
			string text = "";
			text = ((showSoldiersNumTip && showDispatchSoldierTip) ? (LanguagesManager.GetDesc("CsharpCodeZhTcText126") + "[color=#FF1919]" + LanguagesManager.GetDesc("CsharpCodeZhTcText127") + "[/color]，" + Environment.NewLine + "[size=33](" + LanguagesManager.GetDesc("CsharpCodeZhTcText514") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText254") + ")[/size]") : ((!showDispatchSoldierTip) ? (LanguagesManager.GetDesc("CsharpCodeZhTcText126") + "[color=#FF1919]" + LanguagesManager.GetDesc("CsharpCodeZhTcText252") + "[/color]，" + Environment.NewLine + "[size=33](" + LanguagesManager.GetDesc("CsharpCodeZhTcText514") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText254") + ")[/size]") : (LanguagesManager.GetDesc("CsharpCodeZhTcText126") + "[color=#FF1919]" + LanguagesManager.GetDesc("CsharpCodeZhTcText127") + "[/color]，" + Environment.NewLine + "[size=33](" + LanguagesManager.GetDesc("CsharpCodeZhTcText514") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText254") + ")[/size]")));
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					text ?? ""
				},
				{
					"Buttons",
					new Dictionary<string, Action> { 
					{
						"Confirm",
						delegate
						{
							((GObject)exitBtn).touchable = true;
							((GObject)MakeWar).touchable = true;
							PlayEmptyFormationsBreathe();
						}
					} }
				},
				{ "PageIndex", 4 },
				{ "ClickSound", "Confirm" },
				{ "Order", 999999 }
			});
		}
		else
		{
			action();
		}
	}

	private void RenderSoldierItem(Soldier soldier, UI_soliderItem btn)
	{
		string iconPath = UiHelper.GetIconPath(soldier.Id);
		btn.icon.url = "ui://PublicResources/" + iconPath;
		((GObject)btn.lv).text = soldier.Level.ToString();
		int num = (soldier.PotentialLevel + 2) / 2;
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(soldier.PotentialLevel);
		btn.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		btn.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(soldier.PotentialLevel);
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)btn.iconFrame).asLoader, soldier.PotentialLevel, shaderList);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(btn.SoulStoneLevel, soldier.PotentialLevel, soldier.PotentialProgress);
		RenderLegendItems(soldier, (GButton)(object)btn);
	}

	private void RenderLegendItems(Soldier soldier, GButton button)
	{
		if (LegendItemsHelper.SoldiersEquippedItems == null || !LegendItemsHelper.SoldiersEquippedItems.ContainsKey(soldier.Id))
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			((GComponent)button).GetChild($"legendItem{i}").visible = false;
			((GComponent)button).GetChild($"legendItem{i}").scaleY = 0.35f;
			((GComponent)button).GetChild($"legendItem{i}").scaleX = 0.35f;
		}
		int num = 0;
		for (int j = 0; j < LegendItemsHelper.SoldiersEquippedItems[soldier.Id].Length; j++)
		{
			if (num >= 2)
			{
				break;
			}
			GButton asButton = ((GComponent)button).GetChild($"legendItem{num}").asButton;
			if (!LegendItemsHelper.GetSoldierItemSlotState(soldier.Id, j))
			{
				((GObject)asButton).visible = false;
				((GObject)asButton).scaleY = 0f;
				continue;
			}
			long num2 = LegendItemsHelper.SoldiersEquippedItems[soldier.Id][j];
			((GObject)asButton).visible = true;
			if (num2 == 0)
			{
				((GObject)asButton).scaleY = 0f;
				((GObject)asButton).visible = false;
				continue;
			}
			((GObject)asButton).scaleY = 0.35f;
			((GObject)asButton).scaleX = 0.35f;
			UiHelper.RenderLegendItem(asButton, LegendItemsHelper.GetLegendItemUi(num2), UiHelper.TextColorType.Light, null, 2);
			num++;
		}
		bool flag = false;
		for (int k = 0; k < 2; k++)
		{
			GButton asButton2 = ((GComponent)button).GetChild($"legendItem{k}").asButton;
			if (((GObject)asButton2).visible)
			{
				break;
			}
			if (k == 1)
			{
				flag = true;
			}
		}
		((GComponent)button).GetChild("LegendItems").visible = !flag;
	}

	private void RenderEnemyItem(Soldier soldier, UI_soliderItem btn, GameEntityData entityData)
	{
		int result = 1;
		if (soldier.Skin == "UsePotentialLevel")
		{
			result = (soldier.PotentialLevel + 2) / 2;
		}
		else if (!int.TryParse(soldier.Skin.Substring(4), out result))
		{
			result = 1;
		}
		string iconPath = UiHelper.GetIconPath(string.IsNullOrEmpty(soldier.Data.ParentSoldierId) ? soldier.Id : soldier.Data.ParentSoldierId, result);
		btn.icon.url = "ui://PublicResources/" + iconPath;
		((GObject)btn.lv).text = entityData.Level.ToString();
		string iconFrameBorderSoldier = UiHelper.GetIconFrameBorderSoldier(entityData.PotentialLevel);
		btn.iconFrame.url = "ui://PublicResources/" + iconFrameBorderSoldier;
		btn.lvFrame.url = UiHelper.GetLevelFrameBorderSoldier(entityData.PotentialLevel);
		UiHelper.LoadSoldierIconFrameMaterial(((GObject)btn.iconFrame).asLoader, entityData.PotentialLevel, shaderList);
		FGUIManager.Instance.SetAlightSoulStoneForSoldierIcon(btn.SoulStoneLevel, entityData.PotentialLevel, soldier.PotentialProgress);
	}

	private void PlayDisappear()
	{
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		if (isPvpBattle)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvPBattleResultAnimationEffect.Name, new Dictionary<string, object> { { "isQuickBattle", true } });
			((GObject)this).alpha = 1f;
		}
		Disappear.Play();
		if (!isPvpBattle)
		{
			for (int i = 0; i < ourFormations.Count; i++)
			{
				ourFormations[i].Icon.Disappear.Play();
			}
			for (int j = 0; j < enemyFormations.Count; j++)
			{
				enemyFormations[j].Icon.Disappear.Play();
			}
			((GComponent)(object)this).SetTimeout(0.2f).OnComplete((GTweenCallback)delegate
			{
				for (int k = 0; k < ourFormations.Count; k++)
				{
					ourFormations[k].Disappear.Play();
				}
			});
			((GComponent)(object)this).SetTimeout(0.4f).OnComplete((GTweenCallback)delegate
			{
				for (int k = 0; k < enemyFormations.Count; k++)
				{
					enemyFormations[k].Disappear.Play();
				}
			});
		}
		else
		{
			for (int num = 0; num < ourFormations.Count; num++)
			{
				((GObject)ourFormations[num].Icon).visible = false;
			}
			for (int num2 = 0; num2 < enemyFormations.Count; num2++)
			{
				((GObject)enemyFormations[num2].Icon).visible = false;
			}
			for (int num3 = 0; num3 < ourFormations.Count; num3++)
			{
				((GObject)ourFormations[num3]).visible = false;
			}
			for (int num4 = 0; num4 < enemyFormations.Count; num4++)
			{
				((GObject)enemyFormations[num4]).visible = false;
			}
		}
		((GComponent)(object)this).SetTimeout(1.5f).OnComplete((GTweenCallback)delegate
		{
			curFrame = 1;
			StartFrameCoroutine();
		});
	}

	private void SoldierIconInit()
	{
		Dictionary<int, QuickPlayReplayFrame> uI_UseFrames = QuickPlayReplayService.info.UI_UseFrames;
		if (!uI_UseFrames.ContainsKey(curFrame))
		{
			return;
		}
		SharedMessenger.Broadcast("REFRESH_QUICK_PLAY_REPLAY_WATCHER");
		QuickPlayReplayFrame quickPlayReplayFrame = uI_UseFrames[curFrame];
		foreach (KeyValuePair<int, UnitShowInfo> item in quickPlayReplayFrame.Dict_UnitShowInfo)
		{
			if (soldierButtons.ContainsKey(item.Key))
			{
				GButton val = soldierButtons[item.Key];
				((GObject)val).SetXY((float)item.Value.x, (float)(-item.Value.y));
				if (QuickPlayReplayService.info.UnitInfos.ContainsKey(item.Key))
				{
					((GObject)val).visible = true;
				}
			}
			else if (QuickPlayReplayService.info.UnitInfos.ContainsKey(item.Key))
			{
				UnitInfo soldierInfo = QuickPlayReplayService.info.UnitInfos[item.Key];
				soldierButtons.Add(item.Key, GetUnitBtn(soldierInfo, item.Value));
				falling.Add(item.Key);
			}
		}
		UpdateDefensiveWaveText();
		curFrame++;
	}

	private GButton GetUnitBtn(UnitInfo soldierInfo, UnitShowInfo infoValue, bool playDown = false)
	{
		if (soldierInfo.isSoldier || soldierInfo.isBoss)
		{
			return GetSoldierBtn(soldierInfo, infoValue, playDown);
		}
		if (soldierInfo.isFort)
		{
			return GetFortBtn(soldierInfo, infoValue, playDown);
		}
		if (soldierInfo.isAbatis)
		{
			return GetAbatisBtn(soldierInfo, infoValue);
		}
		return GetSoldierBtn(soldierInfo, infoValue, playDown);
	}

	private GButton GetAbatisBtn(UnitInfo soldierInfo, UnitShowInfo infoValue)
	{
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		if (obstacles.Count <= 0)
		{
			GButton val = (GButton)(object)UI_AbatisHorizontal.CreateInstance_ILRuntime();
			((GComponent)Stage.BattleStage).AddChild((GObject)(object)val);
			return val;
		}
		int index = obstacles.Count - 1;
		Obstacle obstacle = obstacles[index];
		GButton val2 = null;
		val2 = (GButton)((!(obstacle.UnitId == "M_W_001")) ? ((object)UI_AbatisVertical.CreateInstance_ILRuntime()) : ((object)UI_AbatisHorizontal.CreateInstance_ILRuntime()));
		if (val2 != null)
		{
			((GComponent)Stage.BattleStage).AddChild((GObject)(object)val2);
			int num = Mathf.CeilToInt(obstacle.Size.x / 0.4f);
			int num2 = Mathf.CeilToInt(obstacle.Size.y / 0.4f);
			int numItems = num * num2;
			GList asList = ((GComponent)val2).GetChild("backList").asList;
			Vector3 val3 = default(Vector3);
			((Vector3)(ref val3))._002Ector(-22.52f + Const.BattleFieldOffset.x, 0f, Const.BattleFieldOffset.y);
			Vector3 val4 = VectorHelper.ToVector3(obstacle.Position + obstacle.Size / 2f, 0f) + new Vector3(3f, 0f, 0f);
			Vector3 val5 = Vector3.op_Implicit(val3 + val4);
			asList.numItems = numItems;
			asList.ResizeToFit(asList.numItems);
			((GObject)val2).SetXY(val5.x * 1000f, (0f - val5.z) * 1000f);
			((GObject)val2).visible = true;
		}
		obstacles.RemoveAt(index);
		return val2;
	}

	private GButton GetFortBtn(UnitInfo soldierInfo, UnitShowInfo infoValue, bool playDown = false)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		GButton val = null;
		if (soldierInfo.team == 200)
		{
			val = (GButton)(object)UI_FortRed.CreateInstance_ILRuntime();
		}
		else if (soldierInfo.team == 100)
		{
			val = (GButton)(object)UI_FortBlue.CreateInstance_ILRuntime();
			if (!playDown)
			{
				fortBluePos = new Vector2((float)infoValue.x, (float)(-infoValue.y));
			}
		}
		if (val != null)
		{
			((GComponent)Stage.BattleStage).AddChild((GObject)(object)val);
			((GObject)val).SetXY((float)infoValue.x, (float)(-infoValue.y));
			((GObject)val).visible = true;
			if (playDown)
			{
				((GComponent)val).GetController("Type").selectedIndex = 1;
			}
		}
		return val;
	}

	private GButton GetSoldierBtn(UnitInfo soldierInfo, UnitShowInfo infoValue, bool playDown = false)
	{
		GButton val = null;
		if (soldierInfo.team == 200)
		{
			val = (GButton)(object)UI_TeamRedBtn.CreateInstance_ILRuntime();
		}
		else if (soldierInfo.team == 100)
		{
			val = (GButton)(object)UI_TeamBlueBtn.CreateInstance_ILRuntime();
		}
		if (val != null)
		{
			((GComponent)((GComponent)((GComponent)val).GetChild("Icon").asButton).GetChild("IconBtn").asButton).GetChild("icon").asLoader.url = GetSoldierIcon(soldierInfo.Model, soldierInfo.Skin);
			((GComponent)Stage.BattleStage).AddChild((GObject)(object)val);
			((GObject)val).SetXY((float)infoValue.x, (float)(-infoValue.y));
			((GObject)val).visible = true;
			float num = soldierInfo.realScale / 4f;
			float num2 = (num * 60f + 6f) / (num * 60f) * 120f;
			((GComponent)((GComponent)val).GetChild("Icon").asButton).GetChild("healthBar").SetSize(num2, num2);
			((GObject)val).SetScale(num, num);
			if (playDown)
			{
				((GComponent)val).GetController("Type").selectedIndex = 1;
			}
		}
		return val;
	}

	private string GetSoldierIcon(string modelId, string skinName)
	{
		string s = skinName.Replace("skin", "");
		int num = int.Parse(s);
		if (num < 1)
		{
			num = 1;
		}
		string key = $"{modelId}_{num}";
		if (soldierIconCache.ContainsKey(key))
		{
			return soldierIconCache[key];
		}
		string soldierSummonIcon = UiHelper.GetSoldierSummonIcon(modelId, num);
		soldierIconCache.Add(key, soldierSummonIcon);
		return soldierSummonIcon;
	}

	private void PlayFalling()
	{
		Shuffle();
		curFallIndex = 0;
		totalFallCount = (falling.Count / 5 + 2) * 3;
		fallCoroutine = FGUIManager.Instance.OpenIEnumerator(FallSoldiersIcon());
	}

	private void Shuffle()
	{
		List<int> list = new List<int>();
		while (falling.Count > 0)
		{
			int index = Random.Range(0, falling.Count);
			list.Add(falling[index]);
			falling.RemoveAt(index);
		}
		for (int i = 0; i < list.Count; i++)
		{
			falling.Add(list[i]);
		}
	}

	private void PlayFight()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		isMoveMap = false;
		waitingNextWave = false;
		waitingPvpNextWave = false;
		((GComponent)(object)this).SetTimeout(0.25f).OnComplete((GTweenCallback)delegate
		{
			frameCoroutine = FGUIManager.Instance.OpenIEnumerator(PlayReplay());
		});
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < shaderList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Shader>(shaderList[i]);
		}
	}

	private void CloseMask()
	{
		End();
		GObject showingUi = GameController.Contexts.Service<IUiService>().GetShowingUi(UI_InstanceZonesPanel.Name);
		((UI_InstanceZonesPanel)(object)showingUi)?.SetQuickBattlePanelBackVisible(_visible: false);
	}

	private void GetLevelPlays()
	{
		((GObject)MakeWar).touchable = false;
		((GObject)exitBtn).touchable = false;
		int _frames = (isPvpBattle ? 30 : 10);
		Action action = delegate
		{
			if (isPvpBattle)
			{
				Action action2 = delegate
				{
					//IL_0034: Unknown result type (might be due to invalid IL or missing references)
					//IL_003e: Expected O, but got Unknown
					pvpStartBattleAction?.Invoke();
					((GComponent)(object)this).SetTimeout(1f).OnComplete(new GTweenCallback(PlayDisappear));
				};
				QuickPlayReplayService.Instance.StartRankQuickPlay(curLevel.LevelId, targetRank, lastBattleFinishAt, IncrementalFrame, action2, curLevel, _frames, exitBtn, (GButton)(object)MakeWar, _userName);
			}
			else
			{
				QuickPlayReplayService.Instance.StartQuickPlay(curLevel.LevelId, IncrementalFrame, PlayDisappear, curLevel, _frames, exitBtn, (GButton)(object)MakeWar);
			}
		};
		StartWarTip(action);
	}

	private void StartFrameCoroutine()
	{
		SharedMessenger.Broadcast("START_QUICK_PLAY_REPLAY_WATCHER", QuickPlayReplayService.info.BattleId);
		PageController.selectedIndex = ((!isPvpBattle) ? 1 : 3);
		loadCoroutine = FGUIManager.Instance.OpenIEnumerator(LoadSoldiers());
	}

	private void GetSoldierInfo()
	{
		Dictionary<int, QuickPlayReplayFrame> uI_UseFrames = QuickPlayReplayService.info.UI_UseFrames;
		if (!uI_UseFrames.ContainsKey(curFrame))
		{
			return;
		}
		SharedMessenger.Broadcast("REFRESH_QUICK_PLAY_REPLAY_WATCHER");
		if (!waitingNextWave && !waitingPvpNextWave)
		{
			QuickPlayReplayFrame quickPlayReplayFrame = uI_UseFrames[curFrame];
			foreach (KeyValuePair<int, UnitShowInfo> item in quickPlayReplayFrame.Dict_UnitShowInfo)
			{
				if (soldierButtons.ContainsKey(item.Key))
				{
					if (!loadingScene)
					{
						GButton val = soldierButtons[item.Key];
						if (val is UI_FortBlue)
						{
							((GObject)val).SetXY(fortBluePos.x, fortBluePos.y);
						}
						else if (item.Value.x != int.MaxValue && item.Value.y != int.MaxValue)
						{
							((GObject)val).SetXY((float)item.Value.x, (float)(-item.Value.y));
						}
						if (QuickPlayReplayService.info.UnitInfos.ContainsKey(item.Key))
						{
							((GObject)val).visible = true;
						}
					}
				}
				else if (QuickPlayReplayService.info.UnitInfos.ContainsKey(item.Key))
				{
					UnitInfo soldierInfo = QuickPlayReplayService.info.UnitInfos[item.Key];
					soldierButtons.Add(item.Key, GetUnitBtn(soldierInfo, item.Value, playDown: true));
				}
			}
			OnAnyTeamHealthPointsTotal(quickPlayReplayFrame.redTeamCurHealth, quickPlayReplayFrame.redTeamTotalHealth, quickPlayReplayFrame.blueTeamCurHealth, quickPlayReplayFrame.blueTeamTotalHealth);
			foreach (KeyValuePair<int, GButton> soldierButton in soldierButtons)
			{
				if (!QuickPlayReplayService.info.UnitInfos.ContainsKey(soldierButton.Key))
				{
					((GObject)soldierButton.Value).visible = false;
				}
				else if (QuickPlayReplayService.info.UnitInfos[soldierButton.Key].DeadFrame <= curFrame || QuickPlayReplayService.info.UnitInfos[soldierButton.Key].DestroyFrame <= curFrame)
				{
					((GObject)soldierButton.Value).visible = false;
				}
			}
			PlayPvpWaveEndEffect(curFrame);
			if (QuickPlayReplayService.info.KeyFrames.ContainsKey(curFrame))
			{
				QuickPlayReplayService.info.KeyFrames[curFrame].has_played = true;
			}
		}
		CheckTimeDifference();
		CurFrameIncrease();
	}

	private IEnumerator PlayReplay(float wait_tm = 0f)
	{
		if (wait_tm > 0f)
		{
			yield return (object)new WaitForSeconds(wait_tm);
		}
		if (isMoveMap)
		{
			SharedMessenger.Broadcast("REFRESH_QUICK_PLAY_REPLAY_WATCHER");
			yield break;
		}
		if (waitingPvpNextWave)
		{
			SharedMessenger.Broadcast("REFRESH_QUICK_PLAY_REPLAY_WATCHER");
			yield return null;
			frameCoroutine = FGUIManager.Instance.OpenIEnumerator(PlayReplay());
			yield break;
		}
		if (playDelay >= 4)
		{
			playDelay = 0;
			yield return (object)new WaitForSeconds(0.06f);
			frameCoroutine = FGUIManager.Instance.OpenIEnumerator(PlayReplay());
			yield break;
		}
		playDelay++;
		int _Use_Frame_LastIndex = QuickPlayReplayService.info.UI_UseFrames.Count - 1;
		if (QuickPlayReplayService.info.isPlayingFinish && curFrame > QuickPlayReplayService.info.UI_UseFrames.Keys.ToList()?[_Use_Frame_LastIndex])
		{
			SentrySdk.AddBreadcrumb($"PlayReplay PlayingFinish, curFrame={curFrame}, _Use_Frame_LastIndex={_Use_Frame_LastIndex}, GetBattleResult");
			GetBattleResult();
			FGUIManager.Instance.CloseIEnumerator(frameCoroutine);
		}
		else
		{
			GetSoldierInfo();
			realTotalTime += Time.deltaTime;
			yield return null;
			frameCoroutine = FGUIManager.Instance.OpenIEnumerator(PlayReplay());
		}
	}

	private IEnumerator LoadSoldiers()
	{
		if (curFrame > 2)
		{
			FGUIManager.Instance.CloseIEnumerator(loadCoroutine);
			PlayFalling();
		}
		else
		{
			SoldierIconInit();
			yield return null;
			loadCoroutine = FGUIManager.Instance.OpenIEnumerator(LoadSoldiers());
		}
	}

	private IEnumerator FallSoldiersIcon()
	{
		SharedMessenger.Broadcast("REFRESH_QUICK_PLAY_REPLAY_WATCHER");
		if (curFallIndex > totalFallCount)
		{
			FGUIManager.Instance.CloseIEnumerator(fallCoroutine);
			PlayFight();
			yield break;
		}
		if (curFallIndex <= totalFallCount && curFallIndex % 3 == 0)
		{
			int endIndex = falling.Count - 5;
			int i = falling.Count - 1;
			while (i >= endIndex && i >= 0)
			{
				((GComponent)soldierButtons[falling[i]]).GetController("Type").selectedIndex = 1;
				falling.RemoveAt(i);
				i--;
			}
		}
		curFallIndex++;
		yield return null;
		fallCoroutine = FGUIManager.Instance.OpenIEnumerator(FallSoldiersIcon());
	}

	private void CurFrameIncrease()
	{
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		BattleInfo battleInfo = QuickPlayReplayService.info.BattleInfo;
		if (battleInfo.BlueTeamHealthZeroFrame != null && GetNextWaitPlayFrame() > battleInfo.BlueTeamHealthZeroFrame.KeyFrame && !battleInfo.BlueTeamHealthZeroFrame.has_played)
		{
			flag = true;
			curFrame = battleInfo.BlueTeamHealthZeroFrame.KeyFrame;
			battleInfo.BlueTeamHealthZeroFrame.has_played = true;
		}
		if (battleInfo.BlueTeamHealthMaxFrame != null && GetNextWaitPlayFrame() > battleInfo.BlueTeamHealthMaxFrame.KeyFrame && !battleInfo.BlueTeamHealthMaxFrame.has_played)
		{
			flag = true;
			curFrame = battleInfo.BlueTeamHealthMaxFrame.KeyFrame;
			battleInfo.BlueTeamHealthMaxFrame.has_played = true;
		}
		if (battleInfo.RedTeamHealthZeroFrame != null && GetNextWaitPlayFrame() > battleInfo.RedTeamHealthZeroFrame.KeyFrame && !battleInfo.RedTeamHealthZeroFrame.has_played)
		{
			flag = true;
			curFrame = battleInfo.RedTeamHealthZeroFrame.KeyFrame;
			battleInfo.RedTeamHealthZeroFrame.has_played = true;
		}
		if (battleInfo.RedTeamHealthMaxFrame != null && GetNextWaitPlayFrame() > battleInfo.RedTeamHealthMaxFrame.KeyFrame && !battleInfo.RedTeamHealthMaxFrame.has_played)
		{
			flag = true;
			curFrame = battleInfo.RedTeamHealthMaxFrame.KeyFrame;
			battleInfo.RedTeamHealthMaxFrame.has_played = true;
		}
		if (flag && QuickPlayReplayService.info.UI_UseFrames.ContainsKey(curFrame))
		{
			QuickPlayReplayFrame quickPlayReplayFrame = QuickPlayReplayService.info.UI_UseFrames[curFrame];
			OnAnyTeamHealthPointsTotal(quickPlayReplayFrame.redTeamCurHealth, quickPlayReplayFrame.redTeamTotalHealth, quickPlayReplayFrame.blueTeamCurHealth, quickPlayReplayFrame.blueTeamTotalHealth);
		}
		KingHealthPointsTotalRecord kingsHealth = default(KingHealthPointsTotalRecord);
		foreach (QuickPlayReplayKeyFrame value4 in QuickPlayReplayService.info.KeyFrames.Values)
		{
			if (value4.has_played)
			{
				continue;
			}
			int frame = value4.KeyFrame;
			if (frame == 1 || GetNextWaitPlayFrame() <= value4.KeyFrame)
			{
				continue;
			}
			curFrame = frame;
			value4.has_played = true;
			if (value4.Types.IndexOf(1) >= 0)
			{
				isMoveMap = true;
				waitingNextWave = true;
				PlayMoveMap();
			}
			if (value4.Types.IndexOf(2) >= 0)
			{
				waitingNextWave = false;
				UpdateDefensiveWaveText();
			}
			if (value4.Types.IndexOf(0) >= 0)
			{
			}
			if (value4.Types.IndexOf(4) >= 0)
			{
				foreach (object datum in value4.data)
				{
					if (datum == null)
					{
						continue;
					}
					Type type = datum.GetType();
					if (type.Equals(Type.Missing))
					{
						continue;
					}
					PropertyInfo property = type.GetProperty("Id");
					if (property == null)
					{
						continue;
					}
					object value = property.GetValue(datum);
					if (value == null)
					{
						continue;
					}
					int key = (int)value;
					if (!soldierButtons.TryGetValue(key, out var value2))
					{
						continue;
					}
					PropertyInfo property2 = type.GetProperty("Scale");
					if (!(property2 == null))
					{
						object value3 = property2.GetValue(datum);
						if (value3 != null)
						{
							int num = (int)value3;
							((GObject)value2).SetScale((float)num / 4f, (float)num / 4f);
						}
					}
				}
			}
			if (value4.Types.IndexOf(5) < 0)
			{
				return;
			}
			waitingPvpNextWave = true;
			using (List<object>.Enumerator enumerator3 = value4.data.GetEnumerator())
			{
				if (enumerator3.MoveNext())
				{
					object current3 = enumerator3.Current;
					Dictionary<string, object> dictionary = (Dictionary<string, object>)current3;
					int pvp_Index = (int)dictionary["PvP_Idx"];
					ref KingHealthPointsTotalRecord reference = ref kingsHealth;
					object obj = dictionary["kingsHealth"];
					reference = (KingHealthPointsTotalRecord)((obj is KingHealthPointsTotalRecord) ? obj : null);
					Action action = delegate
					{
						if (pvp_Index < RankDataHelper.info.NeedLegionSize - 1)
						{
							KingHealthPointsTotalRecord obj2 = kingsHealth;
							if (obj2 != null && obj2.RedCurrent > 0)
							{
								KingHealthPointsTotalRecord obj3 = kingsHealth;
								if (obj3 != null && obj3.BlueCurrent > 0)
								{
									waitingPvpNextWave = false;
									SharedMessenger.Broadcast("ON_PVP_QUICK_BATTLE_WAVE_START_CHANGE_LEGION_INDEX", pvp_Index + 1);
									return;
								}
							}
						}
						if (frameCoroutine != null)
						{
							FGUIManager.Instance.CloseIEnumerator(frameCoroutine);
						}
						SentrySdk.AddBreadcrumb($"CurFrameIncrease Add KeyFrame PvpEffect @{frame} onFinish, GetBattleResult");
						GetBattleResult();
					};
					dictionary.Add("onFinished", action);
					List<Vector2> list = new List<Vector2>();
					foreach (KeyValuePair<int, GButton> soldierButton in soldierButtons)
					{
						if (((GObject)soldierButton.Value).visible)
						{
							Vector2 val = ((GObject)soldierButton.Value).LocalToGlobal(Vector2.one / 2f);
							Vector2 item = ((GObject)this).RootToLocal(val, GRoot.inst);
							list.Add(item);
						}
					}
					dictionary.Add("spawnPos", list);
					if (UnityUiService.Instance.DictUI.ContainsKey(UI_PvPBattleResultAnimationEffect.Name))
					{
						SharedMessenger.Broadcast("ON_PVP_RESULT_ANIM", dictionary);
					}
					else
					{
						action();
					}
				}
			}
			foreach (KeyValuePair<int, GButton> soldierButton2 in soldierButtons)
			{
				((GComponent)Stage.BattleStage).RemoveChild((GObject)(object)soldierButton2.Value, true);
			}
			soldierButtons.Clear();
			return;
		}
		if (waitingNextWave)
		{
			curFrame += 20;
		}
		else
		{
			curFrame = ((nextFrameIncrease > 0) ? nextFrameIncrease : GetNextPlayFrame());
		}
		nextFrameIncrease = 0;
	}

	private void PlayPvpWaveEndEffect(int _frame)
	{
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		if (!QuickPlayReplayService.info.KeyFrames.ContainsKey(_frame))
		{
			return;
		}
		QuickPlayReplayKeyFrame quickPlayReplayKeyFrame = QuickPlayReplayService.info.KeyFrames[_frame];
		if (quickPlayReplayKeyFrame.has_played || quickPlayReplayKeyFrame.KeyFrame == 1 || quickPlayReplayKeyFrame.Types.IndexOf(5) < 0)
		{
			return;
		}
		waitingPvpNextWave = true;
		using (List<object>.Enumerator enumerator = quickPlayReplayKeyFrame.data.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				object current = enumerator.Current;
				Dictionary<string, object> dictionary = (Dictionary<string, object>)current;
				int pvp_Index = (int)dictionary["PvP_Idx"];
				KingHealthPointsTotalRecord kingsHealth = default(KingHealthPointsTotalRecord);
				ref KingHealthPointsTotalRecord reference = ref kingsHealth;
				object obj = dictionary["kingsHealth"];
				reference = (KingHealthPointsTotalRecord)((obj is KingHealthPointsTotalRecord) ? obj : null);
				Action action = delegate
				{
					if (pvp_Index < RankDataHelper.info.NeedLegionSize - 1)
					{
						KingHealthPointsTotalRecord obj2 = kingsHealth;
						if (obj2 != null && obj2.RedCurrent > 0)
						{
							KingHealthPointsTotalRecord obj3 = kingsHealth;
							if (obj3 != null && obj3.BlueCurrent > 0)
							{
								waitingPvpNextWave = false;
								SharedMessenger.Broadcast("ON_PVP_QUICK_BATTLE_WAVE_START_CHANGE_LEGION_INDEX", pvp_Index + 1);
								return;
							}
						}
					}
					if (frameCoroutine != null)
					{
						FGUIManager.Instance.CloseIEnumerator(frameCoroutine);
					}
					SentrySdk.AddBreadcrumb($"PvpWaveEndEffect@{_frame} onFinish, GetBattleResult");
					GetBattleResult();
				};
				dictionary.Add("onFinished", action);
				List<Vector2> list = new List<Vector2>();
				List<Vector2> list2 = new List<Vector2>();
				foreach (GButton value in soldierButtons.Values)
				{
					if (((GObject)value).visible)
					{
						Vector2 val = ((GObject)value).LocalToGlobal(Vector2.one / 2f);
						Vector2 item = ((GObject)this).RootToLocal(val, GRoot.inst);
						if (value is UI_TeamRedBtn)
						{
							list2.Add(item);
						}
						else if (value is UI_TeamBlueBtn)
						{
							list.Add(item);
						}
					}
				}
				dictionary.Add("redAttackerSpawnPos", list2);
				dictionary.Add("blueAttackerSpawnPos", list);
				if (UnityUiService.Instance.DictUI.ContainsKey(UI_PvPBattleResultAnimationEffect.Name))
				{
					SharedMessenger.Broadcast("ON_PVP_RESULT_ANIM", dictionary);
				}
				else
				{
					action();
				}
			}
		}
		foreach (KeyValuePair<int, GButton> soldierButton in soldierButtons)
		{
			((GComponent)Stage.BattleStage).RemoveChild((GObject)(object)soldierButton.Value, true);
		}
		soldierButtons.Clear();
	}

	private int GetNextWaitPlayFrame()
	{
		if (nextFrameIncrease > 0)
		{
			return nextFrameIncrease;
		}
		return GetNextPlayFrame();
	}

	private int GetNextPlayFrame()
	{
		return (Mathf.CeilToInt((float)curFrame / (float)IncrementalFrame) + 1) * IncrementalFrame + 1;
	}

	private void CheckTimeDifference()
	{
	}

	private void BattleMiniMapInit()
	{
		BattleMiniMap.Type.selectedIndex = instanceZonesType;
		if (BattleMiniMap.Type.selectedIndex == 1)
		{
			((GObject)BattleMiniMap.DefensiveWave).text = LanguagesManager.GetDesc("CsharpCodeZhTcText145") + "1" + LanguagesManager.GetDesc("CsharpCodeZhTcText515");
			MaxSubLevelCount = curLevel.SubLevels.Count;
		}
		else if (BattleMiniMap.Type.selectedIndex == 2)
		{
			loadSceneDelayFrames = 48 / IncrementalFrame;
			UnpdateOffensiveProgress(isEnd: false, 0);
		}
	}

	private void UpdateDefensiveWaveText()
	{
		if (instanceZonesType == 2)
		{
			if (BattleMiniMap.Type.selectedIndex == 2 && QuickPlayReplayService.info.BattleInfo.Frame_SubLevelIndexRecord.ContainsKey(curFrame))
			{
				loadSceneDelayFrames = 30;
				loadingScene = false;
				clearStages = QuickPlayReplayService.info.BattleInfo.Frame_SubLevelIndexRecord[curFrame];
				SentrySdk.AddBreadcrumb($"UpdateOffensiveProgress, isEnd=false, clearStages={clearStages}, curFrame={curFrame}");
				UnpdateOffensiveProgress(isEnd: false, clearStages);
				((GProgressBar)OurInfomationBar.HPBar).TweenValue(100.0, 0.1f);
			}
		}
		else if (instanceZonesType == 1 && QuickPlayReplayService.info.BattleInfo.Frame_SubLevelIndexRecord.ContainsKey(curFrame))
		{
			SentrySdk.AddBreadcrumb($"Update Defensive Wave {QuickPlayReplayService.info.BattleInfo.Frame_SubLevelIndexRecord[curFrame] + 1} UI Text, curFrame={curFrame}");
			((GObject)BattleMiniMap.DefensiveWave).text = string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText145"), QuickPlayReplayService.info.BattleInfo.Frame_SubLevelIndexRecord[curFrame] + 1, LanguagesManager.GetDesc("CsharpCodeZhTcText515"));
		}
	}

	public void OnAnyTeamHealthPointsTotal(float redCurrent, float redTotal, float blueCurrent, float blueTotal)
	{
		if (!(redTotal < 0f) && !(blueTotal < 0f) && !(redCurrent < 0f) && !(blueCurrent < 0f))
		{
			double num = ((redTotal > 0f) ? (redCurrent / redTotal * 100f) : 0f);
			double num2 = ((blueTotal > 0f) ? (blueCurrent / blueTotal * 100f) : 0f);
			((GProgressBar)OurInfomationBar.HPBar).TweenValue(num, 0.1f);
			((GProgressBar)EnemyInfomationBar.HPBar).TweenValue(num2, 0.1f);
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
			List<float> value = new List<float> { redCurrent, redTotal, blueCurrent, blueTotal };
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("HealthData", value);
			SharedMessenger.Broadcast("ON_PVP_QUICK_BATTLE_TEAMHEALTH_CHANGE", dictionary);
		}
	}

	private void PlayMoveMap()
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		if (Stage.Move.playing || clearStages >= curLevel.SubLevels.Count - 1)
		{
			return;
		}
		Stage.Move.Play();
		Stage.Move.SetHook("Reload", (TransitionHook)delegate
		{
			foreach (KeyValuePair<int, GButton> soldierButton in soldierButtons)
			{
				((GComponent)Stage.BattleStage).RemoveChild((GObject)(object)soldierButton.Value, true);
			}
			soldierButtons.Clear();
			isMoveMap = false;
			CurFrameIncrease();
			frameCoroutine = FGUIManager.Instance.OpenIEnumerator(PlayReplay(0.5f));
		});
	}

	private void UnpdateOffensiveProgress(bool isEnd = false, int curStages = 1)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		if (instanceZonesType == 2)
		{
			if (curStages == 0)
			{
				clearStages = 0;
			}
			((GObject)BattleMiniMap.offensiveProgressList).data = isEnd;
			((GObject)BattleMiniMap.offensiveProgressList).alpha = 1f;
			BattleMiniMap.offensiveProgressList.itemRenderer = new ListItemRenderer(RenderOffensiveProgressItem);
			BattleMiniMap.offensiveProgressList.numItems = curLevel.SubLevels.Count;
		}
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
		int num = ((clearStages > curLevel.SubLevels.Count - 1) ? 2 : clearStages);
		bool flag = (bool)((GObject)BattleMiniMap.offensiveProgressList).data;
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

	private void TaEnterLevel()
	{
		if (instanceZonesType == 0)
		{
			ThinkingDataHelper.Instance.SoulEnterTrack(curLevel.ChapterId, curLevel.LevelId);
		}
		else if (instanceZonesType == 1)
		{
			ThinkingDataHelper.Instance.DefendEnterTrack(curLevel.ChapterId, curLevel.LevelId.Last().ToString());
		}
		else if (instanceZonesType == 2)
		{
			ThinkingDataHelper.Instance.AttackEnterTrack(curLevel.LevelId, curLevel.Difficult);
		}
	}

	public int GetCurFrame()
	{
		return curFrame;
	}
}
