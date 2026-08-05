using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Scripts.MainCity;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.Sources.Models;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Enums.Sources;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.Helpers;
using UI.GameEndPanels;
using UI.PvpSelectSoldiers;
using UI.QuickBattle;
using UnityEngine;
using UnityEngine.Networking;

namespace HotFix.Sources.Base.Scripts.UI;

public static class RankDataHelper
{
	public class tRankStartGame
	{
		public List<int> UserInRank;

		public int MaxUserCount;

		public double AverageCompbatPower;

		public int Id { get; set; }

		public int State { get; set; } = 0;

		public string SeasonName { get; set; }

		public int Turn { get; set; }

		public string ZoneName { get; set; }

		public DateTimeOffset StartAt { get; set; }

		public DateTimeOffset EndAt { get; set; }

		public DateTimeOffset BattleStartAt { get; set; }

		public DateTimeOffset BattleEndAt { get; set; }

		public List<global::Shift.Legion.ClientApi.Models.tRankBaseBonus> RankBonus { get; set; } = new List<global::Shift.Legion.ClientApi.Models.tRankBaseBonus>();

		public List<global::Shift.Legion.ClientApi.Models.tRankBaseBonus> ScoreBonus { get; set; } = new List<global::Shift.Legion.ClientApi.Models.tRankBaseBonus>();

		public int StartAtTimestamp { get; set; }

		public int EndAtTimestamp { get; set; }

		public int BattleStartAtTimestamp { get; set; }

		public int BattleEndAtTimestamp { get; set; }

		public tRankStartGame()
		{
		}

		public tRankStartGame(GetCurrentPvPRankGameResponse currentPvPRankGameInfo)
		{
			if (currentPvPRankGameInfo == null || currentPvPRankGameInfo.CurrentPvPRankGame == null)
			{
				SeasonName = LanguagesManager.GetDesc("CsharpCodeZhTcText375");
				Turn = -1;
				ZoneName = LanguagesManager.GetDesc("CsharpCodeZhTcText376");
				UnlockedBlocks = 8;
				RankBonus = new List<global::Shift.Legion.ClientApi.Models.tRankBaseBonus>();
				ScoreBonus = new List<global::Shift.Legion.ClientApi.Models.tRankBaseBonus>();
				StartAtTimestamp = 0;
				EndAtTimestamp = 0;
				BattleStartAtTimestamp = 0;
				BattleEndAtTimestamp = 0;
			}
			else
			{
				SeasonName = currentPvPRankGameInfo.CurrentPvPRankGame.SeasonName;
				Turn = currentPvPRankGameInfo.CurrentPvPRankGame.Turn;
				ZoneName = currentPvPRankGameInfo.CurrentPvPRankGame.ZoneName;
				StartAtTimestamp = currentPvPRankGameInfo.CurrentPvPRankGame.StartAt;
				EndAtTimestamp = currentPvPRankGameInfo.CurrentPvPRankGame.EndAt;
				BattleStartAtTimestamp = currentPvPRankGameInfo.CurrentPvPRankGame.BattleStartAt;
				BattleEndAtTimestamp = currentPvPRankGameInfo.CurrentPvPRankGame.BattleEndAt;
				UnlockedBlocks = currentPvPRankGameInfo.CurrentPvPRankGame.UnlockedBlocks;
				RankBonus = currentPvPRankGameInfo.CurrentPvPRankGame.RankBonus;
				ScoreBonus = currentPvPRankGameInfo.CurrentPvPRankGame.ScoreBonus;
			}
		}
	}

	public class PvpSeasonStoreActivity
	{
		public string ActivityId { get; set; }

		public DateTimeOffset StartAt { get; set; }

		public DateTimeOffset EndAt { get; set; }

		public List<global::Shift.Legion.Common.Models.Store.StoreItem> FirstThreeStoreItems { get; set; }

		public List<global::Shift.Legion.Common.Models.Store.StoreItem> OtherStoreItems { get; set; }

		public PvpSeasonStoreActivity(SimpleDynamicPromotionActivity topTournament, SimpleDynamicPromotionActivity normal)
		{
			ActivityId = normal.ActivityId;
			StartAt = topTournament.BeginTime[0];
			EndAt = topTournament.EndTime[0];
			if (topTournament.StoreItems != null && topTournament.StoreItems.Length != 0)
			{
				FirstThreeStoreItems = new List<global::Shift.Legion.Common.Models.Store.StoreItem>();
				List<global::Shift.Legion.Common.Models.Store.StoreItem> list = new List<global::Shift.Legion.Common.Models.Store.StoreItem>();
				for (int i = 0; i < topTournament.StoreItems.Length; i++)
				{
					list.Add(FGUIManager.Instance.GetStoreItem(topTournament.StoreItems[i]));
				}
				FirstThreeStoreItems.AddRange(list);
			}
			if (normal.StoreItems != null && normal.StoreItems.Length != 0)
			{
				OtherStoreItems = new List<global::Shift.Legion.Common.Models.Store.StoreItem>();
				global::Shift.Legion.ClientApi.Protocol.Store.StoreItem[] array = FGUIManager.Instance.GiftBagSort(normal.StoreItems);
				List<global::Shift.Legion.Common.Models.Store.StoreItem> list2 = new List<global::Shift.Legion.Common.Models.Store.StoreItem>();
				for (int j = 0; j < array.Length; j++)
				{
					list2.Add(FGUIManager.Instance.GetStoreItem(array[j]));
				}
				OtherStoreItems.AddRange(list2);
			}
		}
	}

	public const string RankScoreItemId = "RankScore";

	public static bool LastBattleRankUp;

	public static int LastRankScore;

	public const int MaxRank = 800;

	public const int UserNumEachFloor = 100;

	public const int ExpireCode = 100393;

	public const string RankLevelId = "RankBattleFieldLevel";

	public const string RankLevelIdPrefix = "RankBattleField";

	private const string PvPRankProgressKey = "PvPRankProgress";

	private const string _PVP_RANK_TOP_RANK_KEY = "PvPRankTopRank";

	private static int _pvpMaxAttackBuff;

	private static List<Dictionary<string, object>> _pvpAttackBuffList;

	private static int _pvpDefenseBuffSingleTime;

	private static Dictionary<string, int> _pvpDefenseBuffSingleCost;

	private static int _pvpMaxDefenseBuffTime;

	private static List<string> _pvpDefenseBuffAbilities;

	private static Dictionary<string, int> _pvpClearCdSingleCost;

	private static int _pvpClearCdSingleTime;

	private static int _pvpBattleFailureCd;

	public static RankBattleInfo info;

	public const float SoliderLegendItemIconScale = 0.35f;

	private static Dictionary<int, Dictionary<string, int>> _displayProductions;

	private static Dictionary<int, Dictionary<string, int>> _displayRankBonus;

	private static Dictionary<int, Dictionary<string, int>> _settlementBonusDisplay;

	private static Dictionary<int, int> _legionSizeDictionary;

	public static tRankStartGame RankStartGameInfo;

	public const int StartHours = 10;

	public const int EndHours = 2;

	public static string AllServerChampionshipSeasonMissionScore = "SeasonMissionScore";

	public static string AllServerChampionshipBetCoin = "I40099";

	public static string AllServerChampionshipExchangeCoin = "I40100";

	private const string WarOfRealmLotteryConfigKey = "WarofRealmLotteryConfig";

	private static List<WarOfRealmLotteryConfigEntry> _cachedLotteryConfigs;

	public static WarOfRealmInfo AllServersChampionshipInfo;

	private static Dictionary<string, WarOfRealmGroupResultReport> _groupResultReportCache = new Dictionary<string, WarOfRealmGroupResultReport>();

	private static int LastUpdateSeasonInfoHourValue = -1;

	private static string LastUpdateAllServersChampionshipInfoCacheKey = "";

	public static tRankSeasonInfo RankSeasonInfo;

	private const int Increment = 17;

	private const int MinLength = 6;

	private const int MaxLength = 15;

	private const int addValue = 100523;

	private const byte _key = 69;

	private const int max = 731564543;

	public const int UnlockBlockNeedUserNum = 50;

	public static int UnlockedBlocks;

	public static int UnlockNextBlockProgress;

	public static string PvPRankScoreItem;

	public static bool IsInTopTournament;

	public const int IdleBonusBoxOpenNum = 1000;

	public static PvpSeasonStoreActivity SeasonStoreActivity;

	private static List<string> openUiOnReturnMainCityPanels = new List<string>();

	private static Dictionary<string, object> pvpBattleLogPanelParameters = new Dictionary<string, object>();

	private static List<string> _backedUpPanelNames = new List<string>();

	private static Dictionary<string, Dictionary<string, object>> _backedUpPanelParams = new Dictionary<string, Dictionary<string, object>>();

	private static Dictionary<string, Dictionary<string, object>> _panelExtraState = new Dictionary<string, Dictionary<string, object>>();

	public static PvPRankProgress PvpRankProgress
	{
		get
		{
			UserArchiveManager userArchiveManager = GameManagers.Instance.UserArchiveManager;
			if (!userArchiveManager.Contains("PvPRankProgress"))
			{
				userArchiveManager.SetConfigValue("PvPRankProgress", new PvPRankProgress());
			}
			return userArchiveManager.GetConfig<PvPRankProgress>("PvPRankProgress").GetValue();
		}
	}

	public static Config<TopRankRecord> PvPRankTopRank
	{
		get
		{
			UserArchiveManager userArchiveManager = GameManagers.Instance.UserArchiveManager;
			if (!userArchiveManager.Contains("PvPRankTopRank"))
			{
				int topRank = PvpRankProgress.TopRank;
				TopRankRecord value = new TopRankRecord
				{
					HistoryTopRank = topRank,
					CurrentTopRank = topRank,
					Checked = true
				};
				userArchiveManager.SetConfigValue("PvPRankTopRank", value);
			}
			return userArchiveManager.GetConfig<TopRankRecord>("PvPRankTopRank");
		}
	}

	public static int PvPMaxAttackBuff
	{
		get
		{
			if (_pvpMaxAttackBuff <= 0)
			{
				_pvpMaxAttackBuff = Convert.ToInt32(GDMgr.Get<GDEConfigurationData>("PvPMaxAttackBuff").Config);
			}
			return _pvpMaxAttackBuff;
		}
	}

	private static List<Dictionary<string, object>> PvpAttackBuffList
	{
		get
		{
			if (_pvpAttackBuffList == null)
			{
				_pvpAttackBuffList = JsonHelper.ToObject<List<Dictionary<string, object>>>(GDMgr.Get<GDEConfigurationData>("PvpAttackBuffList").Config);
			}
			return _pvpAttackBuffList;
		}
	}

	public static int PvPDefenseBuffSingleTime
	{
		get
		{
			if (_pvpDefenseBuffSingleTime <= 0)
			{
				_pvpDefenseBuffSingleTime = Convert.ToInt32(GDMgr.Get<GDEConfigurationData>("PvPDefenseBuffSingleTime").Config);
			}
			return _pvpDefenseBuffSingleTime;
		}
	}

	public static Dictionary<string, int> PvPDefenseBuffSingleCost
	{
		get
		{
			if (_pvpDefenseBuffSingleCost == null)
			{
				_pvpDefenseBuffSingleCost = JsonHelper.ToObject<Dictionary<string, int>>(GDMgr.Get<GDEConfigurationData>("PvPDefenseBuffSingleCost").Config);
			}
			return _pvpDefenseBuffSingleCost;
		}
	}

	public static List<string> PvPDefenseBuffAbilities
	{
		get
		{
			if (_pvpDefenseBuffAbilities == null)
			{
				_pvpDefenseBuffAbilities = JsonHelper.ToObject<List<string>>(GDMgr.Get<GDEConfigurationData>("PvPDefenseBuffAbilities").Config);
			}
			return _pvpDefenseBuffAbilities;
		}
	}

	public static int PvPMaxDefenseBuffTime
	{
		get
		{
			if (_pvpMaxDefenseBuffTime <= 0)
			{
				_pvpMaxDefenseBuffTime = Convert.ToInt32(GDMgr.Get<GDEConfigurationData>("PvPMaxDefenseBuffTime").Config);
			}
			return _pvpMaxDefenseBuffTime;
		}
	}

	public static Dictionary<string, int> PvPClearCdSingleCost
	{
		get
		{
			if (_pvpClearCdSingleCost == null)
			{
				_pvpClearCdSingleCost = JsonHelper.ToObject<Dictionary<string, int>>(GDMgr.Get<GDEConfigurationData>("PvPClearCdSingleCost").Config);
			}
			return _pvpClearCdSingleCost;
		}
	}

	public static int PvPClearCdSingleTime
	{
		get
		{
			if (_pvpClearCdSingleTime <= 0)
			{
				_pvpClearCdSingleTime = Convert.ToInt32(GDMgr.Get<GDEConfigurationData>("PvPClearCdSingleTime").Config);
			}
			return _pvpClearCdSingleTime;
		}
	}

	public static int PvPBattleFailureCd
	{
		get
		{
			if (_pvpBattleFailureCd <= 0)
			{
				_pvpBattleFailureCd = Convert.ToInt32(GDMgr.Get<GDEConfigurationData>("PvPBattleFailureCd").Config);
			}
			return _pvpBattleFailureCd;
		}
	}

	public static bool IsServerWideBattleOpen
	{
		get
		{
			string value;
			return HotUpdateProcess.Instance.Configs.TryGetValue("PvPVersion", out value) && value == "1";
		}
	}

	public static bool IsServerWideBattle => IsServerWideBattleOpen && AllServersChampionshipInfo != null;

	public static bool IsWeekendPeakBattle
	{
		get
		{
			long serverTime = GameController.Instance.GetServerTime();
			DateTime localDateTime = DateTimeHelper.ParseTimeStamp((int)serverTime).LocalDateTime;
			return localDateTime.DayOfWeek == DayOfWeek.Saturday || localDateTime.DayOfWeek == DayOfWeek.Sunday;
		}
	}

	public static int PeakBattleTeamCount => IsWeekendPeakBattle ? 4 : 3;

	public static int CurrentWarOfRealmTeamCount
	{
		get
		{
			WarOfRealmInfo allServersChampionshipInfo = AllServersChampionshipInfo;
			if (allServersChampionshipInfo == null)
			{
				return 5;
			}
			return GetWarOfRealmTeamCount(allServersChampionshipInfo.CurrentStageStatus);
		}
	}

	public static bool HasTopTournamentFormationConfig { get; private set; }

	public static bool IsPvPLevel(string levelId)
	{
		return !string.IsNullOrEmpty(levelId) && levelId.StartsWith("RankBattleField");
	}

	public static void UpdateRankBattleReplayResult(string _battleId, int _result, Dictionary<Team, BattleResultStats> _battleResultStats)
	{
		if (info != null && info.BattleId == _battleId)
		{
			info.Result = _result;
			info.BattleResultStats = _battleResultStats;
		}
	}

	public static void SetRankBattleReplayResult(int _result, Dictionary<Team, BattleResultStats> _battleResultStats)
	{
	}

	public static void BattleLookBack()
	{
		if (info != null)
		{
			GameLocalDataManager.ClearReplayCache();
			PlayBattleReplayData playBattleReplayData = new PlayBattleReplayData
			{
				BattleId = info.BattleId,
				TargetFrame = 9999,
				LevelId = info.LevelId,
				LocalSource = false,
				ReplayMode = 3,
				MaskDuration = 0
			};
			GameLocalDataManager.SetLastReplay(playBattleReplayData);
			QuickPlayReplayService.info.BattleId = string.Empty;
			GameManagers.Instance.Messenger.Broadcast<PlayBattleReplayData, CustomTaskCompletionSource<bool>>("ACTION_PLAY_BATTLE_REPLAY", playBattleReplayData, null);
		}
	}

	public static void AddAttackBuffCnt(Action action, int addBuffCnt = 1)
	{
		ILRequestHelper<PvPRankAddAttackBuffResponse>.Request((EventContext)null, (Func<Task<PvPRankAddAttackBuffResponse>>)(() => GameController.Contexts.Service<INetworkService>().AddRankAttackBuff(addBuffCnt)), (Action<PvPRankAddAttackBuffResponse>)delegate(PvPRankAddAttackBuffResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				SetPvpRankProgressAttackBuffCnt(response.AttackBuffCnt);
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.CostRecords);
				action();
				List<string> arg = new List<string> { string.Format("PvP{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText385"), response.AttackBuffCnt) };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
		});
	}

	public static void AddDefenseBuffTime(int _addTime, Action action)
	{
		ILRequestHelper<PvPRankAddDefenseBuffResponse>.Request((EventContext)null, (Func<Task<PvPRankAddDefenseBuffResponse>>)(() => GameController.Contexts.Service<INetworkService>().AddDefenseBuff(_addTime)), (Action<PvPRankAddDefenseBuffResponse>)delegate(PvPRankAddDefenseBuffResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				SetPvpRankProgressDefenseBuffExpiredAt(response.DefenseBuffExpiredAt);
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.CostRecords);
				action();
				List<string> arg = new List<string> { "PvP" + LanguagesManager.GetDesc("CsharpCodeZhTcText386") + UiHelper.ParseTimeChinsesDH(_addTime) };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
		});
	}

	public static void ClearRankCd(int _targetId, Action action)
	{
		ILRequestHelper<PvPRankClearCdResponse>.Request((EventContext)null, (Func<Task<PvPRankClearCdResponse>>)(() => GameController.Contexts.Service<INetworkService>().ClearRankCd(_targetId)), (Action<PvPRankClearCdResponse>)delegate(PvPRankClearCdResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				int cdFinishAt = (int)GameController.Instance.GetServerTime();
				SetPvpRankProgressCdFinishAt(_targetId.ToString(), cdFinishAt);
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.CostRecords);
				action();
				List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText387") + "PvP" + LanguagesManager.GetDesc("CsharpCodeZhTcText388") + "CD" };
				SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			}
		});
	}

	public static void SetPvpRankProgressAttackBuffCnt(int attackBuffCnt)
	{
		UserArchiveManager userArchiveManager = GameManagers.Instance.UserArchiveManager;
		PvPRankProgress pvpRankProgress = PvpRankProgress;
		pvpRankProgress.AttackBuffCnt = attackBuffCnt;
		userArchiveManager.SetConfigValue("PvPRankProgress", pvpRankProgress);
	}

	public static Dictionary<string, int> GetAttackBuffCost(int buffNum)
	{
		Dictionary<string, object> dictionary = PvpAttackBuffList[buffNum];
		if (!dictionary.ContainsKey("Cost"))
		{
			return null;
		}
		Dictionary<string, object> dictionary2 = (Dictionary<string, object>)dictionary["Cost"];
		Dictionary<string, int> dictionary3 = new Dictionary<string, int>();
		using (Dictionary<string, object>.Enumerator enumerator = dictionary2.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				KeyValuePair<string, object> current = enumerator.Current;
				string s = JsonHelper.ToJson(current.Value);
				int value = int.Parse(s);
				dictionary3.Add(current.Key, value);
			}
		}
		return dictionary3;
	}

	public static List<string> GetAttackBuffAbilities(int buffNum)
	{
		Dictionary<string, object> dictionary = PvpAttackBuffList[buffNum];
		if (!dictionary.ContainsKey("Abilities"))
		{
			return null;
		}
		object obj = dictionary["Abilities"];
		string json = JsonHelper.ToJson(obj);
		return JsonHelper.ToObject<List<string>>(json);
	}

	public static void SetPvpRankProgressDefenseBuffExpiredAt(int defenseBuffExpiredAt)
	{
		UserArchiveManager userArchiveManager = GameManagers.Instance.UserArchiveManager;
		PvPRankProgress pvpRankProgress = PvpRankProgress;
		pvpRankProgress.DefenseBuffExpiredAt = defenseBuffExpiredAt;
		userArchiveManager.SetConfigValue("PvPRankProgress", pvpRankProgress);
	}

	public static void SetPvpRankProgressCdFinishAt(string _userId, int cdFinishAt)
	{
		UserArchiveManager userArchiveManager = GameManagers.Instance.UserArchiveManager;
		PvPRankProgress pvpRankProgress = PvpRankProgress;
		if (pvpRankProgress.CdFinishAt.ContainsKey(_userId))
		{
			pvpRankProgress.CdFinishAt[_userId] = cdFinishAt;
		}
		else
		{
			pvpRankProgress.CdFinishAt.Add(_userId, cdFinishAt);
		}
		userArchiveManager.SetConfigValue("PvPRankProgress", pvpRankProgress);
	}

	public static int GetPvpRankProgressCdFinishAt(string _userId)
	{
		PvPRankProgress pvpRankProgress = PvpRankProgress;
		if (pvpRankProgress.CdFinishAt.ContainsKey(_userId))
		{
			return pvpRankProgress.CdFinishAt[_userId] - (int)GameController.Instance.GetServerTime();
		}
		return 0;
	}

	public static int GetUserTopRank()
	{
		int topRank = PvpRankProgress.TopRank;
		return (topRank <= 0 || topRank > 800) ? 801 : topRank;
	}

	public static void SetUserTopRank(int newRank)
	{
		if (newRank > 0 && newRank <= 800)
		{
			UserArchiveManager userArchiveManager = GameManagers.Instance.UserArchiveManager;
			PvPRankProgress pvpRankProgress = PvpRankProgress;
			pvpRankProgress.TopRank = newRank;
			userArchiveManager.SetConfigValue("PvPRankProgress", pvpRankProgress);
			TopRankRecord value = PvPRankTopRank.GetValue();
			value.CurrentTopRank = newRank;
			userArchiveManager.SetConfigValue("PvPRankTopRank", value);
			SharedMessenger.messengerInstance.Broadcast("PVP_RANK_UPDATE_PROGRESS", newRank);
		}
	}

	public static Dictionary<string, int> GetRankScoreReward(int _rank)
	{
		if (_displayProductions == null)
		{
			_displayProductions = new Dictionary<int, Dictionary<string, int>>();
		}
		int num = ((_rank > 0 && _rank <= 800) ? _rank : 0);
		if (!_displayProductions.ContainsKey(num))
		{
			GDERankConfigData gDERankConfigData = GDMgr.Get<GDERankConfigData>($"RankConfig{num}");
			Dictionary<string, int> value = JsonHelper.ToObject<Dictionary<string, int>>(gDERankConfigData.DisplayProductions);
			_displayProductions.Add(num, value);
		}
		return _displayProductions[num];
	}

	private static Dictionary<string, int> GetRankBonus(int _rank)
	{
		if (_displayRankBonus == null)
		{
			_displayRankBonus = new Dictionary<int, Dictionary<string, int>>();
		}
		int num = ((_rank > 0 && _rank <= 800) ? _rank : 0);
		if (!_displayRankBonus.ContainsKey(num))
		{
			GDERankConfigData gDERankConfigData = GDMgr.Get<GDERankConfigData>($"RankConfig{num}");
			Dictionary<string, int> value = JsonHelper.ToObject<Dictionary<string, int>>(gDERankConfigData.DisplayRankBonus);
			_displayRankBonus.Add(num, value);
		}
		return _displayRankBonus[num];
	}

	public static Dictionary<string, int> GetTopRankUpBonus(int curRank)
	{
		int userTopRank = GetUserTopRank();
		if (curRank >= userTopRank)
		{
			return null;
		}
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		Dictionary<string, int> rankBonus = GetRankBonus(curRank);
		Dictionary<string, int> rankBonus2 = GetRankBonus(userTopRank);
		foreach (KeyValuePair<string, int> item in rankBonus)
		{
			if (rankBonus2.ContainsKey(item.Key))
			{
				dictionary.Add(item.Key, item.Value - rankBonus2[item.Key]);
			}
		}
		StockChangeRecord[] array = new StockChangeRecord[dictionary.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item2 in dictionary)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item2.Key,
				Offset = item2.Value,
				Context = 45,
				ContextValue = curRank.ToString(),
				Type = 1
			};
		}
		GameManagers.Instance.StockController.ReadStockChangeRecords(array);
		SetUserTopRank(curRank);
		return dictionary;
	}

	public static Dictionary<string, int> GetSettlementBonus(int _rank)
	{
		return null;
	}

	public static int GetPvpLegionSize(int _rank)
	{
		int num = ((_rank > 0 && _rank <= 800) ? _rank : 0);
		if (_legionSizeDictionary == null)
		{
			_legionSizeDictionary = new Dictionary<int, int>();
		}
		if (!_legionSizeDictionary.ContainsKey(num))
		{
			GDERankConfigData gDERankConfigData = GDMgr.Get<GDERankConfigData>($"RankConfig{num}");
			_legionSizeDictionary.Add(num, gDERankConfigData.LegionSize);
		}
		return _legionSizeDictionary[num];
	}

	public static string GetNpcIconName(int npcRank)
	{
		if (npcRank <= 0 || npcRank > 800)
		{
			return "";
		}
		List<string> list = new List<string> { "I30020", "I30040", "I30023", "I30037", "I30009", "I30027", "I30017", "I30016", "I30029", "I30030" };
		if (npcRank <= 100)
		{
			return $"ui://PublicResources/{list[npcRank % 10]}_{5}";
		}
		if (npcRank <= 300)
		{
			return $"ui://PublicResources/{list[npcRank % 10]}_{4}";
		}
		if (npcRank <= 500)
		{
			return $"ui://PublicResources/{list[npcRank % 10]}_{3}";
		}
		return $"ui://PublicResources/{list[npcRank % 10]}_{2}";
	}

	public static int GetCurrentSeasonIs(bool isBattleEnd, out List<tRankStartGame> turns)
	{
		if (RankSeasonInfo.TurnsInfo == null || RankSeasonInfo.TurnsInfo.Count <= 0)
		{
			turns = new List<tRankStartGame>();
			return 2;
		}
		int num = (int)GameController.Instance.GetServerTime();
		RankSeasonInfo.TurnsInfo.Sort(TurnsInfoSortByStartAt);
		List<tRankStartGame> list = new List<tRankStartGame>();
		for (int i = 0; i < RankSeasonInfo.TurnsInfo.Count; i++)
		{
			int startAtTimestamp = RankSeasonInfo.TurnsInfo[i].StartAtTimestamp;
			int num2 = (isBattleEnd ? RankSeasonInfo.TurnsInfo[i].BattleEndAtTimestamp : RankSeasonInfo.TurnsInfo[i].EndAtTimestamp);
			if (num >= startAtTimestamp && num <= num2)
			{
				turns = list;
				return 0;
			}
			list.Add(RankSeasonInfo.TurnsInfo[i]);
		}
		list.Clear();
		for (int j = 0; j < RankSeasonInfo.TurnsInfo.Count; j++)
		{
			int startAtTimestamp2 = RankSeasonInfo.TurnsInfo[j].StartAtTimestamp;
			if (num < startAtTimestamp2)
			{
				turns = list;
				return 1;
			}
			list.Add(RankSeasonInfo.TurnsInfo[j]);
		}
		turns = list;
		return 2;
	}

	public static int TurnsInfoSortByStartAt(tRankStartGame a, tRankStartGame b)
	{
		int startAtTimestamp = a.StartAtTimestamp;
		int startAtTimestamp2 = b.StartAtTimestamp;
		if (startAtTimestamp > startAtTimestamp2)
		{
			return 1;
		}
		if (startAtTimestamp < startAtTimestamp2)
		{
			return -1;
		}
		return 0;
	}

	public static async void GetPvpRankSeasonInfo(Action action)
	{
		GetPVPRankSeasonInfoResponse rankSeasonInfoResponse = await GameController.Contexts.Service<INetworkService>().GetPVPRankSeasonInfo(-1L);
		if (rankSeasonInfoResponse.Result)
		{
			UpdateRankProgressOnSeasonChange(rankSeasonInfoResponse.SeasonInfo.TurnId);
			UpdatePvPPurchaseStat(rankSeasonInfoResponse.SeasonInfo.Id);
			UpdateRankSeasonInfo(rankSeasonInfoResponse.SeasonInfo);
			UpdateRankProgressOnLoginSuccess(rankSeasonInfoResponse.RankProgress);
			UpdateSeasonStoreActivity(rankSeasonInfoResponse.StoreActivityNormal, rankSeasonInfoResponse.StoreActivityTopTournament);
			GetPvPRankScoreItem();
			if (RankZoneChosen())
			{
				GetCurrentPvPRankGameResponse currentPvPRankGameInfo = await GameController.Contexts.Service<INetworkService>().GetCurrentPvPRankGameInfo();
				if (currentPvPRankGameInfo.Result)
				{
					RankStartGameInfo = new tRankStartGame(currentPvPRankGameInfo);
				}
				else
				{
					RankStartGameInfo = new tRankStartGame(null);
				}
			}
			SetCurHourValue();
			if (RankSeasonInfo.Id == -1)
			{
				string _tip = LanguagesManager.GetDesc("CsharpCodeZhTcText389") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText390");
				if (RankSeasonInfo.TurnsInfo != null && RankSeasonInfo.TurnsInfo.Count > 0)
				{
					int curServerTime = (int)GameController.Instance.GetServerTime();
					RankSeasonInfo.TurnsInfo.Sort(TurnsInfoSortByStartAt);
					for (int i = 0; i < RankSeasonInfo.TurnsInfo.Count; i++)
					{
						int startTime = RankSeasonInfo.TurnsInfo[i].StartAtTimestamp;
						if (curServerTime < startTime)
						{
							_tip = LanguagesManager.GetDesc("CsharpCodeZhTcText391") + UiHelper.ParseTimeChinsesDH_Foo(startTime - curServerTime) + LanguagesManager.GetDesc("CsharpCodeZhTcText392");
							break;
						}
					}
				}
				List<string> tipList_foo = new List<string> { _tip };
				SharedMessenger.Broadcast("SHOW_TIPS", tipList_foo, 1, arg3: false);
			}
			else
			{
				action?.Invoke();
			}
		}
		else
		{
			action?.Invoke();
			RankStartGameInfo = new tRankStartGame(null);
		}
	}

	public static IEnumerator GetPvpRankSeasonCoroutine()
	{
		Task<GetPVPRankSeasonInfoResponse> task = GameController.Contexts.Service<INetworkService>().GetPVPRankSeasonInfo(-1L);
		while (!task.IsCompleted)
		{
			yield return (object)new WaitForSeconds(0.1f);
		}
		GetPVPRankSeasonInfoResponse rankSeasonInfoResponse = task.Result;
		int errCode = rankSeasonInfoResponse?.ErrorCode ?? (-1);
		if (errCode == 0)
		{
			UpdateRankProgressOnSeasonChange(rankSeasonInfoResponse.SeasonInfo.TurnId);
			UpdatePvPPurchaseStat(rankSeasonInfoResponse.SeasonInfo.Id);
			UpdateRankSeasonInfo(rankSeasonInfoResponse.SeasonInfo);
			UpdateRankProgressOnLoginSuccess(rankSeasonInfoResponse.RankProgress);
			UpdateSeasonStoreActivity(rankSeasonInfoResponse.StoreActivityNormal, rankSeasonInfoResponse.StoreActivityTopTournament);
			SetCurHourValue();
		}
		else
		{
			ILRequestHelper.ShowErrorCode(errCode);
		}
	}

	public static List<WarOfRealmLotteryConfigEntry> GetLotteryConfigs()
	{
		if (_cachedLotteryConfigs == null)
		{
			_cachedLotteryConfigs = "WarofRealmLotteryConfig".ToConfiguration<List<WarOfRealmLotteryConfigEntry>>();
		}
		return _cachedLotteryConfigs;
	}

	public static WarOfRealmLotteryConfigEntry GetMatchedLotteryConfig(StageStatus stageStatus)
	{
		List<WarOfRealmLotteryConfigEntry> lotteryConfigs = GetLotteryConfigs();
		foreach (WarOfRealmLotteryConfigEntry item in lotteryConfigs)
		{
			if (item.StageStatus != null && item.StageStatus.Contains((int)stageStatus))
			{
				return item;
			}
		}
		return (lotteryConfigs.Count > 0) ? lotteryConfigs[0] : null;
	}

	public static string GetLotteryRewardItemId(StageStatus stageStatus)
	{
		WarOfRealmLotteryConfigEntry matchedLotteryConfig = GetMatchedLotteryConfig(stageStatus);
		if (matchedLotteryConfig?.Bonus != null && matchedLotteryConfig.Bonus.Count > 0)
		{
			using Dictionary<string, int>.Enumerator enumerator = matchedLotteryConfig.Bonus.GetEnumerator();
			if (enumerator.MoveNext())
			{
				return enumerator.Current.Key;
			}
		}
		return null;
	}

	public static IEnumerator GetAllServersChampionshipInfoCoroutine()
	{
		Task<WarOfRealmGetInfoResponse> task = GameController.Contexts.Service<INetworkService>().GetWarOfRealmInfo();
		while (!task.IsCompleted)
		{
			yield return (object)new WaitForSeconds(0.1f);
		}
		WarOfRealmGetInfoResponse allServersChampionshipInfo = task.Result;
		int errCode = allServersChampionshipInfo?.ErrorCode ?? (-1);
		switch (errCode)
		{
		case 0:
		{
			AllServersChampionshipInfo = new WarOfRealmInfo
			{
				ActivityId = allServersChampionshipInfo.ActivityId,
				StartAtTimestamp = allServersChampionshipInfo.BeginTs,
				EndAtTimestamp = allServersChampionshipInfo.EndTs,
				Missions = (allServersChampionshipInfo.Missions ?? new List<WarOfRealmMission>()),
				FreeBonusDict = (allServersChampionshipInfo.FreeBonusDict ?? new Dictionary<int, Dictionary<string, int>>()),
				PaidBonusDict = (allServersChampionshipInfo.PaidBonusDict ?? new Dictionary<int, string>()),
				Score = allServersChampionshipInfo.Score,
				MissionProgressDict = (allServersChampionshipInfo.MissionProgressDict ?? new Dictionary<eMissionType, int>()),
				Claimed = (allServersChampionshipInfo.Claimed ?? new List<int>()),
				StageInfoList = allServersChampionshipInfo.StageInfo,
				WarRankDataInfo = allServersChampionshipInfo.WarRankData,
				SettlementClaimed = allServersChampionshipInfo.Settlement,
				PlayerSettlementInfo = allServersChampionshipInfo.PlayerSettlementInfo,
				Approval = allServersChampionshipInfo.Approval
			};
			List<string> completedMissions = new List<string>();
			if (allServersChampionshipInfo.CompletedSeasonMission != null)
			{
				completedMissions.AddRange(allServersChampionshipInfo.CompletedSeasonMission);
			}
			if (allServersChampionshipInfo.CompletedWeeklyMission != null)
			{
				completedMissions.AddRange(allServersChampionshipInfo.CompletedWeeklyMission);
			}
			if (!string.IsNullOrEmpty(allServersChampionshipInfo.LeaderboardBonus))
			{
				AllServersChampionshipInfo.LeaderboardBonus = JsonHelper.ToObject<List<LeaderboardBonusConfig>>(allServersChampionshipInfo.LeaderboardBonus);
			}
			if (!string.IsNullOrEmpty(allServersChampionshipInfo.StoreContents))
			{
				AllServersChampionshipInfo.StoreContents = JsonHelper.ToObject<List<WarRealmStoreItem>>(allServersChampionshipInfo.StoreContents);
				AllServersChampionshipInfo.StoreContents.Sort((WarRealmStoreItem a, WarRealmStoreItem b) => a.Index.CompareTo(b.Index));
			}
			AllServersChampionshipInfo.CompletedMissions = completedMissions;
			ClearGroupResultReportCache();
			StageStatus currentStageStatus = AllServersChampionshipInfo.CurrentStageStatus;
			if ((currentStageStatus == StageStatus.Round1_PreStage || currentStageStatus == StageStatus.Round2_PreStage) && AllServersChampionshipInfo.WarRankDataInfo?.WarRankDatas != null && AllServersChampionshipInfo.WarRankDataInfo.WarRankDatas.Count > 0)
			{
				AllServersChampionshipInfo.MatchInfoDict[currentStageStatus] = new MatchInfo
				{
					WarRankDataInfo = AllServersChampionshipInfo.WarRankDataInfo
				};
			}
			Task<LotteryInfo> lotteryGroupInfoTask = GetLotteryGroupInfo(allServersChampionshipInfo.ActivityId, currentStageStatus);
			Task<MatchInfo> matchGroupInfoTask = GetMatchGroupInfo(allServersChampionshipInfo.ActivityId, currentStageStatus);
			while (!lotteryGroupInfoTask.IsCompleted || !matchGroupInfoTask.IsCompleted)
			{
				yield return (object)new WaitForSeconds(0.1f);
			}
			Task<WarOfRealmGetScoreHistoryResponse> scoreHistoryTask = GameController.Contexts.Service<INetworkService>().WarOfRealmScoreHistory();
			while (!scoreHistoryTask.IsCompleted)
			{
				yield return (object)new WaitForSeconds(0.1f);
			}
			WarOfRealmGetScoreHistoryResponse scoreHistoryResponse = scoreHistoryTask.Result;
			if (scoreHistoryResponse != null && scoreHistoryResponse.ErrorCode == 0)
			{
				AllServersChampionshipInfo.ScoreHistoryRecords = scoreHistoryResponse.ScoreRecords ?? new List<WeekScoreRecord>();
				AllServersChampionshipInfo.ScoreHistoryTotalScore = scoreHistoryResponse.TotalScore;
			}
			else
			{
				ILRuntimeDebug.LogError($"Get WarOfRealm ScoreHistory Failed, ErrorCode={scoreHistoryResponse?.ErrorCode}");
			}
			UpdateAllServersChampionshipInfoCacheKey();
			break;
		}
		case 81311550:
			AllServersChampionshipInfo = null;
			break;
		default:
			ILRequestHelper.ShowErrorCode(errCode);
			break;
		}
	}

	public static async Task<LotteryInfo> GetLotteryGroupInfo(string activityId, StageStatus stageStatus)
	{
		if (AllServersChampionshipInfo.LotteryInfoDict.TryGetValue(stageStatus, out var lotteryInfo))
		{
			return lotteryInfo;
		}
		INetworkService service = GameController.Contexts.Service<INetworkService>();
		WarOfRealmSettlementResponse response = await service.SettlementWarOfRealm(activityId, (int)stageStatus);
		if (response == null)
		{
			ILRuntimeDebug.LogError($"10793 response is null, activityId={activityId}, status={stageStatus}");
			ILRequestHelper.ShowErrorCode(-1);
			return null;
		}
		if (response.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			return null;
		}
		lotteryInfo = new LotteryInfo
		{
			WarGroupLotteried = response.WarGroupLotteried,
			WarStageLotterySettlement = response.WarStageLotterySettlement,
			WinUserCnt = response.WinUserCnt,
			WinCoinCnt = response.WinCoinCnt
		};
		AllServersChampionshipInfo.LotteryInfoDict[stageStatus] = lotteryInfo;
		AllServersChampionshipInfo.WarStageLotterySettlement = response.WarStageLotterySettlement;
		AllServersChampionshipInfo.StockChangeRecords = response.StockChangeRecords;
		return lotteryInfo;
	}

	public static async Task<MatchInfo> GetMatchGroupInfo(string activityId, StageStatus stageStatus)
	{
		if (AllServersChampionshipInfo.MatchInfoDict.TryGetValue(stageStatus, out var matchInfo))
		{
			return matchInfo;
		}
		INetworkService service = GameController.Contexts.Service<INetworkService>();
		WarOfRealmGetStageRecordResponse response = await service.GetWarOfRealmStageRecord(activityId, (int)stageStatus);
		if (response == null)
		{
			ILRuntimeDebug.LogError($"10795 response is null, activityId={activityId}, status={stageStatus}");
			ILRequestHelper.ShowErrorCode(-1);
			return null;
		}
		if (response.ErrorCode != 0)
		{
			if (response.ErrorCode == 81311577)
			{
				return null;
			}
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			return null;
		}
		matchInfo = new MatchInfo
		{
			WarGroupPlayers = response.GetGroupInfo,
			SettlementInfoList = response.GetSettlementInfoList,
			UserInTop8 = response.UserInTop8,
			WarRankDataInfo = response.WarRankDataInfo
		};
		AllServersChampionshipInfo.MatchInfoDict[stageStatus] = matchInfo;
		return matchInfo;
	}

	public static bool SeasonBetStoreIsNewRefreshed()
	{
		int seasonBetStoreLastRefreshTime = GameLocalDataManager.GetSeasonBetStoreLastRefreshTime();
		return IsServerWideBattle && DateTimeHelper.ServerNowTimestamp >= seasonBetStoreLastRefreshTime;
	}

	public static void SeasonBetStoreMarkReviewed()
	{
		if (IsServerWideBattle)
		{
			int timeStamp = DateTimeHelper.GetTimeStamp(AllServersChampionshipInfo.IsRoundI() ? AllServersChampionshipInfo.RoundIDuration[1] : AllServersChampionshipInfo.RoundIIDuration[1]);
			GameLocalDataManager.SetSeasonBetStoreLastRefreshTime(timeStamp);
		}
	}

	public static bool SeasonMissionHasFreeBonusToClaim()
	{
		if (AllServersChampionshipInfo == null)
		{
			return false;
		}
		List<int> list = AllServersChampionshipInfo.FreeBonusDict.Keys.ToList();
		list.Sort();
		foreach (int item in list)
		{
			if (AllServersChampionshipInfo.Score < item)
			{
				break;
			}
			if (AllServersChampionshipInfo.Claimed.Contains(item))
			{
				continue;
			}
			return true;
		}
		return false;
	}

	public static void ClearGroupResultReportCache()
	{
		if (_groupResultReportCache.Count > 0)
		{
			_groupResultReportCache.Clear();
		}
	}

	private static string GetGroupResultCacheKey(string activityId, int stageStatus, int groupId)
	{
		return $"{activityId}_{stageStatus}_{groupId}";
	}

	public static string GetGroupResultCDNUrl(string activityId, int stageStatus, int groupId)
	{
		string text = HotUpdateProcess.Instance.RegionModel.Zone.url.res[0];
		StageStatus stageStatus2 = (StageStatus)stageStatus;
		string text2 = stageStatus2.ToString();
		return $"{text}/war/{activityId}/{text2}_{groupId}_GroupResultReport.json";
	}

	public static IEnumerator TryLoadGroupResultFromCDN(string activityId, int stageStatus, int groupId, Action<WarOfRealmGroupResultReport> onComplete)
	{
		string cacheKey = GetGroupResultCacheKey(activityId, stageStatus, groupId);
		if (_groupResultReportCache.TryGetValue(cacheKey, out var cachedReport))
		{
			onComplete?.Invoke(cachedReport);
			yield break;
		}
		string url = GetGroupResultCDNUrl(activityId, stageStatus, groupId);
		UnityWebRequest www = UnityWebRequest.Get(url);
		try
		{
			yield return www.SendWebRequest();
			if (string.IsNullOrEmpty(www.error) && www.responseCode == 200)
			{
				string json = www.downloadHandler.text;
				WarOfRealmGroupResultReport report = JsonHelper.ToObject<WarOfRealmGroupResultReport>(json);
				if (report?.StageGroupBattleRecord != null || report?.StageUserBattleRecord != null)
				{
					_groupResultReportCache[cacheKey] = report;
					onComplete?.Invoke(report);
					yield break;
				}
			}
		}
		finally
		{
			((IDisposable)www)?.Dispose();
		}
		onComplete?.Invoke(null);
	}

	public static string GetStageGroupTitle(StageStatus stageStatus, int groupIndex)
	{
		groupIndex++;
		switch (stageStatus)
		{
		case StageStatus.Round1_Stage128:
		case StageStatus.Round2_Stage128:
			return "ServerWideGroupTitle128".ToLanguage(groupIndex);
		case StageStatus.Round1_Stage64:
		case StageStatus.Round2_Stage64:
			return "ServerWideGroupTitle64".ToLanguage(groupIndex);
		case StageStatus.Round1_Stage32:
		case StageStatus.Round2_Stage32:
			return "ServerWideGroupTitle32".ToLanguage(groupIndex);
		case StageStatus.Round1_Stage16:
		case StageStatus.Round2_Stage16:
			return "ServerWideGroupTitle16".ToLanguage(groupIndex);
		case StageStatus.Round1_Stage8FirstRound:
		case StageStatus.Round1_Stage8SecondRound:
		case StageStatus.Round1_SemiFinal:
		case StageStatus.Round1_Final:
		case StageStatus.Round2_Stage8FirstRound:
		case StageStatus.Round2_Stage8SecondRound:
		case StageStatus.Round2_SemiFinal:
		case StageStatus.Round2_Final:
			return "ServerWideGroupTitleFinal".ToLanguage();
		default:
			return string.Empty;
		}
	}

	public static string GetStageTitle(StageStatus stageStatus)
	{
		switch (stageStatus)
		{
		case StageStatus.Round1_Stage128:
		case StageStatus.Round2_Stage128:
			return "ServerWideStageTitle128".ToLanguage();
		case StageStatus.Round1_Stage64:
		case StageStatus.Round2_Stage64:
			return "ServerWideStageTitle64".ToLanguage();
		case StageStatus.Round1_Stage32:
		case StageStatus.Round2_Stage32:
			return "ServerWideStageTitle32".ToLanguage();
		case StageStatus.Round1_Stage16:
		case StageStatus.Round2_Stage16:
			return "ServerWideStageTitle16".ToLanguage();
		case StageStatus.Round1_Stage8FirstRound:
		case StageStatus.Round1_Stage8SecondRound:
		case StageStatus.Round2_Stage8FirstRound:
		case StageStatus.Round2_Stage8SecondRound:
			return "ServerWideStageTitle8".ToLanguage();
		case StageStatus.Round1_SemiFinal:
		case StageStatus.Round2_SemiFinal:
			return "ServerWideStageTitleSemiFinal".ToLanguage();
		case StageStatus.Round1_Final:
		case StageStatus.Round2_Final:
			return "ServerWideStageTitleFinal".ToLanguage();
		default:
			return string.Empty;
		}
	}

	public static void SetCurHourValue()
	{
		long serverTime = GameController.Instance.GetServerTime();
		LastUpdateSeasonInfoHourValue = DateTimeHelper.ParseTimeStamp((int)serverTime).LocalDateTime.Hour;
	}

	public static bool NeedUpdateSeasonInfo()
	{
		long serverTime = GameController.Instance.GetServerTime();
		int hour = DateTimeHelper.ParseTimeStamp((int)serverTime).LocalDateTime.Hour;
		return hour != LastUpdateSeasonInfoHourValue;
	}

	public static void UpdateAllServersChampionshipInfoCacheKey()
	{
		if (AllServersChampionshipInfo == null)
		{
			LastUpdateAllServersChampionshipInfoCacheKey = string.Empty;
		}
		else
		{
			LastUpdateAllServersChampionshipInfoCacheKey = GetAllServersChampionshipInfoCacheKey();
		}
	}

	public static string GetAllServersChampionshipInfoCacheKey()
	{
		if (AllServersChampionshipInfo == null)
		{
			return string.Empty;
		}
		int serverNowTimestamp = DateTimeHelper.ServerNowTimestamp;
		string text = "";
		StageInfo currentStageInfo = AllServersChampionshipInfo.GetCurrentStageInfo();
		return string.Format(arg2: currentStageInfo.IsPreparing(serverNowTimestamp) ? $"{WarOfRealm_Extensions.StagePhase.Preparing}" : (currentStageInfo.IsBattling(serverNowTimestamp) ? $"{WarOfRealm_Extensions.StagePhase.Battling}" : ((!currentStageInfo.IsSettled(serverNowTimestamp)) ? $"{WarOfRealm_Extensions.StagePhase.NotBegin}" : $"{WarOfRealm_Extensions.StagePhase.Settled}")), format: "{0}-{1}-{2}", arg0: AllServersChampionshipInfo.ActivityId, arg1: AllServersChampionshipInfo.CurrentStageStatus);
	}

	public static bool NeedUpdateAllServersChampionshipInfo()
	{
		if (AllServersChampionshipInfo == null)
		{
			return true;
		}
		return GetAllServersChampionshipInfoCacheKey() != LastUpdateAllServersChampionshipInfoCacheKey;
	}

	public static void OpenAllServersChampionshipPanel()
	{
		if (AllServersChampionshipInfo == null)
		{
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("AllServersChampionshipNotOpenTip") }, 1, arg3: false);
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_ServerWideConquestPanel.Name, null);
		}
	}

	public static async void OpenPvpEntrance()
	{
		if (!NeedUpdateSeasonInfo())
		{
			if (RankSeasonInfo.Id == -1)
			{
				ShowSeasonInfoTip();
			}
			else
			{
				OpenRankBattlePanels();
			}
			return;
		}
		GetPVPRankSeasonInfoResponse rankSeasonInfoResponse = await GameController.Contexts.Service<INetworkService>().GetPVPRankSeasonInfo(-1L);
		if (rankSeasonInfoResponse.Result)
		{
			UpdateRankProgressOnSeasonChange(rankSeasonInfoResponse.SeasonInfo.TurnId);
			UpdatePvPPurchaseStat(rankSeasonInfoResponse.SeasonInfo.Id);
			UpdateRankSeasonInfo(rankSeasonInfoResponse.SeasonInfo);
			UpdateRankProgressOnLoginSuccess(rankSeasonInfoResponse.RankProgress);
			UpdateSeasonStoreActivity(rankSeasonInfoResponse.StoreActivityNormal, rankSeasonInfoResponse.StoreActivityTopTournament);
			if (RankZoneChosen())
			{
				GetCurrentPvPRankGameResponse currentPvPRankGameInfo = await GameController.Contexts.Service<INetworkService>().GetCurrentPvPRankGameInfo();
				if (currentPvPRankGameInfo.Result)
				{
					RankStartGameInfo = new tRankStartGame(currentPvPRankGameInfo);
				}
				else
				{
					RankStartGameInfo = new tRankStartGame(null);
				}
			}
			SetCurHourValue();
			if (RankSeasonInfo.Id == -1)
			{
				ShowSeasonInfoTip();
			}
			else
			{
				OpenRankBattlePanels();
			}
		}
		else
		{
			OpenRankBattlePanels();
			RankStartGameInfo = new tRankStartGame(null);
		}
	}

	public static void UpdateAllServerChampionshipRankBonusCheckedCache()
	{
		if (AllServersChampionshipInfo.PlayerSettlementInfo != null && AllServersChampionshipInfo.PlayerSettlementInfo.FinalRank != int.MaxValue)
		{
			GameLocalDataManager.SetAllServersChampionshipStageRankCheckedCache(AllServersChampionshipInfo.ActivityId + "_Eliminated");
		}
		else
		{
			GameLocalDataManager.SetAllServersChampionshipStageRankCheckedCache($"{AllServersChampionshipInfo.ActivityId}_{AllServersChampionshipInfo.CurrentStageStatus}");
		}
	}

	public static bool AllServerChampionshipRankBonusChecked()
	{
		string allServersChampionshipStageRankCheckedCache = GameLocalDataManager.GetAllServersChampionshipStageRankCheckedCache();
		return allServersChampionshipStageRankCheckedCache == $"{AllServersChampionshipInfo.ActivityId}_{AllServersChampionshipInfo.CurrentStageStatus}" || allServersChampionshipStageRankCheckedCache == AllServersChampionshipInfo.ActivityId + "_Eliminated";
	}

	public static void GoSetFormationForAllServerChampionship()
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

	public static void ClaimAllServerChampionshipRankBonus()
	{
		ILRequestHelper<WarOfRealmClaimRankBonusResponse>.Request((EventContext)null, (Func<Task<WarOfRealmClaimRankBonusResponse>>)(() => GameController.Contexts.Service<INetworkService>().ClaimWarOfRealmRankBonus(AllServersChampionshipInfo.ActivityId)), (Action<WarOfRealmClaimRankBonusResponse>)delegate(WarOfRealmClaimRankBonusResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				AllServersChampionshipInfo.SettlementClaimed = true;
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
			}
		});
	}

	private static void OpenRankBattlePanels()
	{
		UiAudioManager.Instance.PlayBackgroundSound("Building18_Click");
		OpenPvpEntrancePanel();
	}

	private static void ShowSeasonInfoTip()
	{
		string item = LanguagesManager.GetDesc("CsharpCodeZhTcText389") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText390");
		if (RankSeasonInfo.TurnsInfo != null && RankSeasonInfo.TurnsInfo.Count > 0)
		{
			int num = (int)GameController.Instance.GetServerTime();
			RankSeasonInfo.TurnsInfo.Sort(TurnsInfoSortByStartAt);
			for (int i = 0; i < RankSeasonInfo.TurnsInfo.Count; i++)
			{
				int startAtTimestamp = RankSeasonInfo.TurnsInfo[i].StartAtTimestamp;
				if (num < startAtTimestamp)
				{
					item = LanguagesManager.GetDesc("CsharpCodeZhTcText391") + UiHelper.ParseTimeChinsesDH_Foo(startAtTimestamp - num) + LanguagesManager.GetDesc("CsharpCodeZhTcText392");
					break;
				}
			}
		}
		List<string> arg = new List<string> { item };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private static void ShowSeasonSettlementTip()
	{
		if (!(((PVPEntrance)GameManagers.Instance.BuildingManager.GetBuildingByType("18")).Controller is PVPEntranceController pVPEntranceController))
		{
			ILRuntimeDebug.LogError("PVPEntranceController is null");
			return;
		}
		pVPEntranceController.UpdateEntranceStatus();
		List<string> tipList = new List<string>();
		if (pVPEntranceController.EntranceActive)
		{
			tipList = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText393") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText394") };
		}
		if (tipList.Count > 0)
		{
			ScriptApi.CreateTimer(0.8f, delegate
			{
				SharedMessenger.Broadcast("SHOW_TIPS", tipList, 1, arg3: false);
			});
		}
	}

	public static void UpdateRankSeasonInfo(tRankSeasonInfo _info)
	{
		RankSeasonInfo = _info;
		RankStartGameInfo = RankSeasonInfo.GetRankStartGameInfo();
	}

	public static void UpdateSeasonStoreActivity(SimpleDynamicPromotionActivity storeActivityNormal, SimpleDynamicPromotionActivity storeActivityTopTournament)
	{
		if (storeActivityNormal != null && storeActivityTopTournament != null)
		{
			SeasonStoreActivity = new PvpSeasonStoreActivity(storeActivityTopTournament, storeActivityNormal);
		}
	}

	public static void ChoosePvpLadderOrAllServersChampionship()
	{
		if (IsServerWideBattle)
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_PVPSeasonEntrancePanel.Name, null);
		}
		else
		{
			OpenPvpEntrance();
		}
	}

	public static void OpenPvpEntrancePanel()
	{
		Dictionary<string, object> parameters = new Dictionary<string, object>();
		ShowSeasonSettlementTip();
		if (RankZoneChosen())
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_LadderTournamentPanel.Name, null);
		}
		else
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_PvpZoneChoose.Name, parameters);
		}
	}

	public static string OpenPvpMainPanelOnReturnMainCity()
	{
		if (RankZoneChosen())
		{
			return UI_LadderTournamentPanel.Name;
		}
		return UI_PvpZoneChoose.Name;
	}

	public static bool RankZoneChosen()
	{
		return !string.IsNullOrEmpty(PvpRankProgress.RankServerName);
	}

	public static string UserId_Obfuscating(int _id)
	{
		Random random = new Random();
		byte[] bytes = BitConverter.GetBytes(_id);
		for (int i = 0; i < bytes.Length - 1; i++)
		{
			bytes[i] ^= 69;
		}
		bytes[3] = (byte)random.Next(1, 5);
		int num = BitConverter.ToInt32(bytes, 0);
		return string.Format("{0}{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText395"), num);
	}

	public static int UserId_De_Obfuscating(string str)
	{
		int value = int.Parse(str.Substring(2));
		byte[] bytes = BitConverter.GetBytes(value);
		for (int i = 0; i < bytes.Length - 1; i++)
		{
			bytes[i] ^= 69;
		}
		bytes[3] = 0;
		return BitConverter.ToInt32(bytes, 0);
	}

	public static bool PvpSeasonIsEnable()
	{
		if (RankSeasonInfo == null)
		{
			return false;
		}
		if (RankSeasonInfo.Id == -1)
		{
			return false;
		}
		bool flag = GameManagers.Instance.UserArchiveManager.IsLevelCompleted("P401");
		bool flag2 = !string.IsNullOrEmpty(PvpRankProgress.RankServerName);
		if (!flag && !flag2)
		{
			return false;
		}
		int num = (int)GameController.Instance.GetServerTime();
		int startAtTimestamp = RankSeasonInfo.StartAtTimestamp;
		int endAtTimestamp = RankSeasonInfo.EndAtTimestamp;
		if (num < startAtTimestamp || num > endAtTimestamp)
		{
			return false;
		}
		return true;
	}

	public static string GetPvpRankRangeText(int rangeIndex)
	{
		if (rangeIndex < 1 || rangeIndex > 8)
		{
			return "";
		}
		List<string> list = new List<string>
		{
			LanguagesManager.GetDesc("CsharpCodeZhTcText377"),
			LanguagesManager.GetDesc("CsharpCodeZhTcText378"),
			LanguagesManager.GetDesc("CsharpCodeZhTcText379"),
			LanguagesManager.GetDesc("CsharpCodeZhTcText380"),
			LanguagesManager.GetDesc("CsharpCodeZhTcText381"),
			LanguagesManager.GetDesc("CsharpCodeZhTcText382"),
			LanguagesManager.GetDesc("CsharpCodeZhTcText383"),
			LanguagesManager.GetDesc("CsharpCodeZhTcText384")
		};
		return list[rangeIndex - 1];
	}

	public static void UpdateUnlockedBlocksInfo(int unlockedBlocks, int unlockNextBlockProgress)
	{
		UnlockedBlocks = unlockedBlocks;
		UnlockNextBlockProgress = unlockNextBlockProgress;
	}

	public static void UpdateRankProgressOnLoginSuccess(PvPRankProgress pvPRankProgress)
	{
		GameManagers.Instance.UserArchiveManager.SetConfigValue("PvPRankProgress", pvPRankProgress);
	}

	public static void UpdateRankProgressOnSeasonChange(int pvpRankGameId)
	{
		if (PvpRankProgress.TurnId != pvpRankGameId)
		{
			UserArchiveManager userArchiveManager = GameManagers.Instance.UserArchiveManager;
			PvPRankProgress pvpRankProgress = PvpRankProgress;
			pvpRankProgress.Reset();
			pvpRankProgress.TurnId = pvpRankGameId;
			pvpRankProgress.TopRank = -1;
			pvpRankProgress.RivalFormationUnitsMarks.Clear();
			pvpRankProgress.RankServerName = "";
			userArchiveManager.SetConfigValue("PvPRankProgress", pvpRankProgress);
		}
	}

	public static void UpdatePvPPurchaseStat(int seasonId)
	{
		if (PvpRankProgress.Id != seasonId)
		{
			UserArchiveManager userArchiveManager = GameManagers.Instance.UserArchiveManager;
			PvPRankProgress pvpRankProgress = PvpRankProgress;
			GameManagers.Instance.StoreManager.PurchaseStat.GetValue().ClearPvPPurchaseStat();
			GameManagers.Instance.StoreManager.PurchaseStat.Save();
			pvpRankProgress.Id = seasonId;
			userArchiveManager.SetConfigValue("PvPRankProgress", pvpRankProgress);
		}
	}

	public static void UpdateRankProgressRankServerName(string rsName)
	{
		PvpRankProgress.RankServerName = rsName;
		GameManagers.Instance.UserArchiveManager.SetConfigValue("PvPRankProgress", PvpRankProgress);
	}

	public static void GetIdleBonus(Action action)
	{
		ILRequestHelper<ClaimPvPRankScoreResponse>.Request((EventContext)null, (Func<Task<ClaimPvPRankScoreResponse>>)(() => GameController.Contexts.Service<INetworkService>().ClaimPvPRankScore(-1L)), (Action<ClaimPvPRankScoreResponse>)delegate(ClaimPvPRankScoreResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				SetPvpRankProgressClaimedScore(response.ClaimedScore);
				Dictionary<string, int> dictionary = new Dictionary<string, int> { { PvPRankScoreItem, response.ClaimedScore } };
				StockChangeRecord[] array = new StockChangeRecord[dictionary.Count];
				int num = 0;
				foreach (KeyValuePair<string, int> item in dictionary)
				{
					array[num++] = new StockChangeRecord
					{
						ItemId = item.Key,
						Offset = item.Value,
						Context = 47,
						ContextValue = response.ClaimedScore.ToString(),
						Type = 1
					};
				}
				GameManagers.Instance.StockController.ReadStockChangeRecords(array);
				action?.Invoke();
				string arg = global::Shift.Legion.Common.Models.Item.Name(GameManagers.Instance, PvPRankScoreItem);
				List<string> arg2 = new List<string> { string.Format("{0}{1}{2}", LanguagesManager.GetDesc("CsharpCodeZhTcText396"), arg, response.ClaimedScore) };
				SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
				ThinkingDataHelper.Instance.GetPvpIdleReward(PvPRankScoreItem, response.ClaimedScore);
				if (response.ClaimedScore > 0)
				{
					GameManagers.Instance.Messenger.Broadcast("PVP_RANK_SCORE_CLAIMED");
				}
			}
		});
	}

	public static int GetWaitForClaimIdleBonusNum()
	{
		int num = PvpRankProgress.Score - PvpRankProgress.ClaimedScore;
		return (num >= 0) ? num : 0;
	}

	public static void SetPvpRankProgressClaimedScore(int claimedScoreAdd)
	{
		PvpRankProgress.ClaimedScore += claimedScoreAdd;
		GameManagers.Instance.UserArchiveManager.SetConfigValue("PvPRankProgress", PvpRankProgress);
	}

	public static void UpdatePvpRankProgressScore(int newScore)
	{
		PvpRankProgress.Score = newScore;
		GameManagers.Instance.UserArchiveManager.SetConfigValue("PvPRankProgress", PvpRankProgress);
	}

	public static int GetWarOfRealmTeamCount(StageStatus stage)
	{
		if (stage == StageStatus.Round1_Stage128 || stage == StageStatus.Round1_Stage64 || stage == StageStatus.Round2_Stage128 || stage == StageStatus.Round2_Stage64)
		{
			return 3;
		}
		if (stage == StageStatus.Round1_Stage32 || stage == StageStatus.Round1_Stage16 || stage == StageStatus.Round2_Stage32 || stage == StageStatus.Round2_Stage16)
		{
			return 4;
		}
		return 5;
	}

	public static async Task GetTopBattleFormations()
	{
		GetPvPTopTournamentFormationResponse response = await GameController.Contexts.Service<INetworkService>().GetPvPTopTournamentFormation();
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
		}
		else
		{
			SetHasTopTournamentFormationConfig(response.CurFormation);
		}
	}

	private static void SetHasTopTournamentFormationConfig(RankBattleTopTournamentConfig config)
	{
		if (config != null)
		{
			List<string> formationsId = config.FormationsId;
			bool flag = formationsId != null && formationsId.Count > 0;
			bool flag2 = !string.IsNullOrEmpty(config._Units);
			HasTopTournamentFormationConfig = flag || flag2;
		}
	}

	public static void GetPvPRankScoreItem()
	{
		string config = GDMgr.Get<GDEConfigurationData>("PvPRankScoreItem").Config;
		PvPRankScoreItem = config;
	}

	public static int GetPvPRankScoreItemNum()
	{
		if (string.IsNullOrEmpty(PvPRankScoreItem))
		{
			return 0;
		}
		return GameManagers.Instance.StockController.GetStock(PvPRankScoreItem);
	}

	public static bool PeakBattleUnlocked()
	{
		return IsInTopTournament && GetUserTopRank() <= 3 && GameLocalDataManager.GetCurPvpTurnPeakBattleState(PvpRankProgress.TurnId.ToString());
	}

	public static bool NeedPlayPeakBattleUnlockEffect()
	{
		return IsInTopTournament && GetUserTopRank() <= 3 && !GameLocalDataManager.GetCurPvpTurnPeakBattleState(PvpRankProgress.TurnId.ToString());
	}

	public static string GetLastTurnLastDayTitle()
	{
		List<tRankStartGame> turns;
		int currentSeasonIs = GetCurrentSeasonIs(isBattleEnd: false, out turns);
		if (turns.Count <= 0 && currentSeasonIs != 0)
		{
			return "";
		}
		long num = GameController.Instance.GetServerTime() + 28800;
		return UiHelper.GetDateStringMMdd(DateTimeHelper.ParseTimeStamp((int)num).AddDays(-1.0));
	}

	public static Dictionary<int, string> GetTopTournamentLogDayIndex()
	{
		if (RankStartGameInfo == null)
		{
			return null;
		}
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		long serverTime = GameController.Instance.GetServerTime();
		DateTime localDateTime = DateTimeHelper.ParseTimeStamp(RankStartGameInfo.StartAtTimestamp).LocalDateTime;
		DateTime localDateTime2 = DateTimeHelper.ParseTimeStamp((int)serverTime).LocalDateTime;
		int days = (localDateTime2 - localDateTime).Days;
		int day = localDateTime.Day;
		int num = day + days;
		int num2 = num;
		int num3 = day - 1;
		for (int i = day; i < num; i++)
		{
			int num4 = num2 - i;
			DateTime refreshTimeOffset = localDateTime.AddDays(num4);
			if (JudgeTurnDayIndexEnable(num4, localDateTime2, refreshTimeOffset))
			{
				string dateStringMMdd = UiHelper.GetDateStringMMdd(localDateTime.AddDays(i - day));
				dictionary.Add(i - num3, dateStringMMdd);
			}
		}
		return dictionary;
	}

	private static bool JudgeTurnDayIndexEnable(int dayDifference, DateTime currentTimeOffset, DateTime refreshTimeOffset)
	{
		if (dayDifference >= 2)
		{
			return true;
		}
		if (dayDifference <= 0)
		{
			return false;
		}
		if (currentTimeOffset > refreshTimeOffset)
		{
			return true;
		}
		return false;
	}

	public static bool HasAnyInform()
	{
		if (!PvpSeasonIsEnable())
		{
			return false;
		}
		return GetWaitForClaimIdleBonusNum() >= 1000;
	}

	public static void SetPanelsOpenUiOnReturnMainCityData(List<string> panels, Dictionary<string, object> parameters)
	{
		openUiOnReturnMainCityPanels.Clear();
		for (int i = 0; i < panels.Count; i++)
		{
			if (GameController.Contexts.Service<IUiService>().HasShowingUi(panels[i]))
			{
				openUiOnReturnMainCityPanels.Add(panels[i]);
			}
		}
		pvpBattleLogPanelParameters = parameters;
	}

	public static void OpenPvpPanelOnReturnMainCity()
	{
		for (int i = 0; i < openUiOnReturnMainCityPanels.Count; i++)
		{
			if (openUiOnReturnMainCityPanels[i] == UI_PvpBattleLogPanel.Name && pvpBattleLogPanelParameters != null && pvpBattleLogPanelParameters.Count > 0)
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(openUiOnReturnMainCityPanels[i], pvpBattleLogPanelParameters);
			}
			else
			{
				GameController.Contexts.Service<IUiService>().OpenPanel(openUiOnReturnMainCityPanels[i], null);
			}
		}
		RestoreBackedUpPanels();
	}

	public static void SetPanelExtraState(string panelName, Dictionary<string, object> state)
	{
		if (state != null && state.Count > 0)
		{
			_panelExtraState[panelName] = state;
		}
	}

	public static void BackupOpenPanelsForReplay(List<string> ignoreList = null)
	{
		_backedUpPanelNames.Clear();
		_backedUpPanelParams.Clear();
		_panelExtraState.Clear();
		SharedMessenger.Broadcast("BACKUP_PANEL_EXTRA_STATE");
		List<string> openPanelNames = UnityUiService.Instance.GetOpenPanelNames();
		for (int i = 0; i < openPanelNames.Count; i++)
		{
			string text = openPanelNames[i];
			if (ignoreList == null || !ignoreList.Contains(text))
			{
				_backedUpPanelNames.Add(text);
				Dictionary<string, object> panelOpenParams = UnityUiService.Instance.GetPanelOpenParams(text);
				if (panelOpenParams != null)
				{
					_backedUpPanelParams[text] = panelOpenParams;
				}
			}
		}
	}

	public static void RestoreBackedUpPanels()
	{
		for (int i = 0; i < _backedUpPanelNames.Count; i++)
		{
			string text = _backedUpPanelNames[i];
			Dictionary<string, object> value = null;
			_backedUpPanelParams.TryGetValue(text, out value);
			if (_panelExtraState.TryGetValue(text, out var value2) && value2 != null)
			{
				if (value == null)
				{
					value = new Dictionary<string, object>();
				}
				foreach (KeyValuePair<string, object> item in value2)
				{
					value[item.Key] = item.Value;
				}
			}
			GameController.Contexts.Service<IUiService>().OpenPanel(text, value);
		}
		_backedUpPanelNames.Clear();
		_backedUpPanelParams.Clear();
		_panelExtraState.Clear();
	}

	public static void ClearBackedUpPanels()
	{
		_backedUpPanelNames.Clear();
		_backedUpPanelParams.Clear();
		_panelExtraState.Clear();
	}

	public static void ReturnToLadderTournamentPanel()
	{
		List<string> panelsName = new List<string>
		{
			UI_DamageMeter.Name,
			UI_PvpBattleVictory.Name,
			UI_PvpBattleFail.Name,
			UI_QuickBattlePanel.Name,
			UI_PvPBattleResultAnimationEffect.Name,
			UI_PvpSelectSoldiersPanel.Name
		};
		GameController.Contexts.Service<IUiService>().CloseSomePanels(panelsName, reservePackageRes: true, ignoreLoading: true, edgeMaskVisible: true);
		if (UI_LadderTournamentPanel.LadderTournamentPanel != null)
		{
			UI_LadderTournamentPanel.LadderTournamentPanel.PlayersRanks.PlayersArmys.numItems = 0;
			UI_LadderTournamentPanel.LadderTournamentPanel.UpdatePanel();
		}
	}

	public static void ReturnLadderPanelOnGetRankBattleResultFailed(string battleId)
	{
		if (QuickPlayReplayService.info.BattleId == battleId)
		{
			List<string> panelsName = new List<string>
			{
				UI_DamageMeter.Name,
				UI_PvpBattleVictory.Name,
				UI_PvpBattleFail.Name,
				UI_QuickBattlePanel.Name,
				UI_PvPBattleResultAnimationEffect.Name,
				UI_PvpSelectSoldiersPanel.Name
			};
			GameController.Contexts.Service<IUiService>().CloseSomePanels(panelsName, reservePackageRes: true, ignoreLoading: true, edgeMaskVisible: true);
			if (UI_LadderTournamentPanel.LadderTournamentPanel != null)
			{
				UI_LadderTournamentPanel.LadderTournamentPanel.PlayersRanks.PlayersArmys.numItems = 0;
				UI_LadderTournamentPanel.LadderTournamentPanel.UpdatePanel();
			}
		}
		else
		{
			CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
			{
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", null },
				{
					"LoadingAnimationDirection",
					LoadingAnimationDirection.Left
				},
				{
					"OpenUiOnReturn",
					UI_LadderTournamentPanel.Name
				}
			}));
		}
	}

	public static void ScoreBonusSort(List<global::Shift.Legion.ClientApi.Models.tRankBaseBonus> list)
	{
		int count = list.Count;
		for (int i = 0; i < count - 1; i++)
		{
			for (int j = 0; j < count - i - 1; j++)
			{
				if (list[j].StartIdx > list[j + 1].StartIdx)
				{
					global::Shift.Legion.ClientApi.Models.tRankBaseBonus value = list[j];
					list[j] = list[j + 1];
					list[j + 1] = value;
				}
			}
		}
	}
}
