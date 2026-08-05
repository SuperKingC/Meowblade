using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.UI;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;
using ILRuntime_LitJson;
using JetBrains.Annotations;
using Shift.Legion.ClientApi;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;
using UnityEngine;

public class GameLocalDataManager
{
	public class PvpScoreRankingListLocalData
	{
		public List<ScoreRankSummary> ScoreRankList;

		public int ModifiedDate;
	}

	public class PvpTotalRankingListLocalData
	{
		public List<SimpleRankSummary> SimpleRankList;

		public int ModifiedDate;
	}

	public class SelfLocalData
	{
		public long ExpiredTime;

		public bool isPending;
	}

	public class UserLocalData
	{
		public int UserId;

		public string NickName;

		public long ModifiedDate;
	}

	public class UserMedalData
	{
		public string Medals;

		public long ModifiedDate;

		[JsonIgnore]
		private List<GvGMedalRecord> _medalRecords;

		[JsonIgnore]
		public List<GvGMedalRecord> MedalRecords
		{
			get
			{
				if (_medalRecords == null)
				{
					try
					{
						if (Medals == "null")
						{
							Medals = null;
						}
						if (string.IsNullOrEmpty(Medals))
						{
							_medalRecords = new List<GvGMedalRecord>();
						}
						else
						{
							_medalRecords = JsonHelper.ToObject<List<GvGMedalRecord>>(Medals);
						}
					}
					catch (Exception ex)
					{
						ILRuntimeDebug.LogError("Get Medal Failed " + Medals + " with message " + ex.Message);
					}
					finally
					{
						if (_medalRecords == null)
						{
							_medalRecords = new List<GvGMedalRecord>();
						}
					}
					for (int num = _medalRecords.Count - 1; num > 0; num--)
					{
						GvGMedalRecord gvGMedalRecord = _medalRecords[num];
						for (int num2 = num - 1; num2 >= 0; num2--)
						{
							GvGMedalRecord gvGMedalRecord2 = _medalRecords[num2];
							if (gvGMedalRecord2.MedalId == gvGMedalRecord.MedalId)
							{
								gvGMedalRecord2.Level += gvGMedalRecord.Level;
								_medalRecords.RemoveAt(num);
								break;
							}
						}
					}
					_medalRecords.Sort(MedalSort);
				}
				return _medalRecords;
			}
		}
	}

	private class GvGIZProgress
	{
		public string IZId;

		public List<int> IZProgress;
	}

	private class GvGAbilityInfo
	{
		public int Level;

		public string NameAndLevelText;
	}

	public class LevelAssistanceFormation
	{
		public string LevelId;

		public string FormationId;

		public List<string> UnitsId;
	}

	public struct GuestInfo
	{
		public string GuestUserId;

		public int ExpireAt;
	}

	public class MilitaryAssistantData
	{
		public string ActivityId;

		public string ActivityMark;

		public string LevelId;

		public string LevelDesc;

		public int LevelDifficulty;

		public int LevelIndex;

		public int ChallengeCnt;

		public int ChallengePlan;

		public MilitaryAssistantStatus Status;

		public MilitaryAssistantData()
		{
			ActivityId = null;
			ActivityMark = null;
			LevelId = null;
			LevelDifficulty = -1;
			LevelIndex = -1;
			ChallengeCnt = 0;
			ChallengePlan = 0;
			Status = MilitaryAssistantStatus.Preparing;
		}
	}

	public enum MilitaryAssistantStatus
	{
		Preparing,
		Battling,
		Done
	}

	public enum FirstInstallAndRegistFlag
	{
		Install = 1,
		Regist = 2,
		Reset = 4
	}

	private static readonly string[] commonKeyList = new string[14]
	{
		"BgmSwitch", "SoundSwitch", "LanguagePrefer", "ZonePrefer", "HasChosenLanguage", "SpecialActivityExpire", "PvpScoreRankingList", "PvpTotalRankingList", "PvpUserLocalData_New", "BattleModelQualityStringSetting",
		"GuestInfo", "IsFirstInstallAndRegist", "DebugInfoSwitch", "FrameRatePrefer"
	};

	private const string LastReplayLevelId = "LastReplayLevelId";

	private const string LastReplayBattleId = "LastReplayBattleId";

	private const string LastReplayTargetFrame = "LastReplayTargetFrame";

	private const string LastReplayLocalSource = "LastReplayLocalSource";

	private const string LastOpenReplayList = "LastOpenReplayList";

	private const string LastReplayName = "LastReplayName";

	private const string LastReplayAvatar = "LastReplayAvatar";

	private const string LastReplayUserId = "LastReplayUserId";

	public const string LastLoginTime = "LastLoginTime";

	public const string CurLoginTime = "CurLoginTime";

	public const string TodayPlayTime = "TodayPlayTime";

	public const string BattleModelQualityStringSetting = "BattleModelQualityStringSetting";

	public const string MouseEffectSetting = "MouseEffectSetting";

	public const string PVP_Rank_BattleConfig = "PVP_Rank_BattleConfig";

	public const string PVP_Rank_EnemyConfig = "PVP_Rank_EnemyConfig";

	public const string GvGMode2GuideKey = "GvGMode2GuideKey_u{0}";

	public const string GvGStorehouseRedDotSaveData = "GvGStorehouseRedDotSaveData";

	private const string LastLegendExplorationFloorIndex = "LastLegendExplorationFloorIndex";

	private const string LastLegendExplorationLevelOffsetX = "LastLegendExplorationLevelOffsetX";

	private const string LastLegendExplorationSoldiers = "LastLegendExplorationSoldiers";

	private const string LastDungeonBattleMinLevel = "LastDungeonBattleMinLevel";

	private const string ResetDungeonBattleMinLevel = "ResetDungeonBattleMinLevel";

	private const string ReforgeLockSubEntries = "ReforgeSubEntries";

	private const string TimeLimitInstanceZoneQuickBattleSwitch = "TimeLimitInstanceZoneQuickBattleSwitch";

	private const string DefensiveInstanceZoneQuickBattleSwitch = "DefensiveInstanceZoneQuickBattleSwitch";

	private const string OffensiveInstanceZoneQuickBattleSwitch = "OffensiveInstanceZoneQuickBattleSwitch";

	private const string InstanceZoneQuickBattleSwitch = "InstanceZoneQuickBattleSwitch";

	private const string SpecialActivityExpire = "SpecialActivityExpire";

	private const string PvpScoreRankingList = "PvpScoreRankingList";

	private const string PvpTotalRankingList = "PvpTotalRankingList";

	private const string GvGSelectedSoldiers = "GvGGetSelectedSoldiers";

	private const string DungeonPreset = "DungeonPreset";

	private const string PvpUserBattleArmy = "PvpUserBattleArmy";

	private const string PvpQuickBattleSwitch = "PvpQuickBattleSwitch";

	private const string SelfUserDataKey = "SelfUserData";

	private const string PvpUserLocalData = "PvpUserLocalData_New";

	private const string GvgUserLocalDataKey = "GvgUserLocalData_Medal";

	private static Dictionary<string, UserLocalData> _userLocalDatas;

	private static Dictionary<string, UserMedalData> _userMedalDatas;

	private const string UserGvGRecordDetailLocalData = "UserGvGRecordDetailLocalData";

	private const string UserGvGShipRecordsListData = "UserGvGShipRecordsListData";

	private const string PvpAllTurnsPeakBattle = "PvpAllTurnsPeakBattle";

	private const string GvGStoreNextUpdateTimestamp = "GvGStoreNextUpdateTimestamp";

	private const string GvGStoreHasCheck = "GvGStoreHasCheck";

	public const string GvgStoreConfirmActivate = "TipKey_GvgStoreConfirmActivate";

	public const string GvgStoreConfirmBuyItem = "TipKey_GvgStoreConfirmBuyItem";

	public const string GvgRebellionConfirmOperation = "TipKey_GvgRebellionConfirmOperation";

	public const string GvgStoreSelectStoneBoxIndex = "IntKey_GvgStoreSelectStoneBoxIndex";

	private const string UserGvGAbilitiesInfo = "UserGvGAbilitiesInfo";

	private const string UserGvGIZProgress = "UserGvGIZProgress";

	private const string MarqueeContentSaveKey = "MarqueeContentSaveKey";

	private const string IslandComeAgainSoldiers = "IslandComeAgainSoldiersKey";

	private const string IslandComeAgainBattleRecord = "IslandComeAgainBattleRecordKey";

	private const string IslandLogsCheckedKey = "IslandLogsChecked";

	public const string FriendsChatSessionIdsKey = "FriendsChatSessionIdsKey";

	private static int m_playerId;

	private const string CurrentActivityOfTypePrefix = "CurrentActivityOfType.";

	private const string ActivityLastStayAtPrefix = "ActivityLastStayAt.";

	public const string NewComerSpecialIconShow = "NewComerSpecialIconShow";

	private const string AppleAdReportedUsersKey = "AppleAdReportedUsers";

	private const string LevelAssistanceFormationKey = "LevelAssistanceFormation";

	public const string GuestInfoKey = "GuestInfo";

	public const string SpeedPlanLastClaim = "SpeedPlanLastClaim";

	public const string AlwaysShowSuppressBonusLimit = "ShowSuppressBonusLimit";

	public const string UseRpcTipDontShowAgainByIzId_Shop = "UseRpcTipDontShowAgainByIzId_Shop";

	public const string UseRpcTipDontShowAgainByIzId_Dialog = "UseRpcTipDontShowAgainByIzId_Dialog";

	public const string DontShowUseDormantTip = "DontShowUseDormantTip";

	public const string SpeedPlanLastPurchase = "SpeedPlanLastPurchase";

	public const string HotFixResListKey = "HotFixResList";

	private const string MilitaryAssistantDataKey = "MilitaryAssistantData.";

	public const string MilitaryAssistantRunningTipsDontShowAgainKey = "TipKey_MilitaryAssistantRunningTipsDontShowAgain";

	public const string LegendItemDungeonPlayingIntroDontShowAgainKey = "TipKey_LegendItemDungeonPlayingIntroDontShowAgain";

	public const string AutoChallengeDontShowAgainKey = "TipKey_AutoChallenge";

	public const string AllServersChampionshipStageRankCheckedKey = "AllServersChampionshipChecked";

	public const string SeasonBetStoreLastRefreshTimeKey = "SeasonBetStoreLastRefreshTime";

	public const string PvpClickAssistantDontShowAgainKey = "TipKey_PvpClickAssistant";

	public const string LastCheckedTopTournamentTurnIdKey = "LastCheckedTopTournamentTurnId";

	private const string LastReplayStuckAt = "LastReplayStuckAt";

	private const string TodayReplayStuckTimes = "TodayReplayStuckTimes";

	private const string LastUserLoginAtKey = "LastUserLoginAt.";

	private const string ServerLocationPreferKey = "ServerLocationPrefer";

	private const string PrivacyAgreementKey = "PrivacyAgreement";

	public const string ZonePreferKey = "ZonePrefer";

	public const string LanguagePreferKey = "LanguagePrefer";

	public const string HasChosenLanguageKey = "HasChosenLanguage";

	public const string IsFirstInstallAndRegistKey = "IsFirstInstallAndRegist";

	public const string DebugInfoSwitch = "DebugInfoSwitch";

	public const string FrameRatePreferKey = "FrameRatePrefer";

	private static GameManagers _gameManagers => GameManagers.Instance;

	private static Dictionary<string, UserLocalData> UserLocalDatas
	{
		get
		{
			if (_userLocalDatas == null)
			{
				string text = GetString("PvpUserLocalData_New");
				if (string.IsNullOrEmpty(text))
				{
					_userLocalDatas = new Dictionary<string, UserLocalData>();
				}
				else
				{
					_userLocalDatas = JsonHelper.ToObject<Dictionary<string, UserLocalData>>(text);
				}
			}
			return _userLocalDatas;
		}
	}

	private static Dictionary<string, UserMedalData> UserMedalDatas
	{
		get
		{
			if (_userMedalDatas == null)
			{
				string text = GetString("GvgUserLocalData_Medal");
				if (string.IsNullOrEmpty(text))
				{
					_userMedalDatas = new Dictionary<string, UserMedalData>();
				}
				else
				{
					_userMedalDatas = JsonHelper.ToObject<Dictionary<string, UserMedalData>>(text);
				}
			}
			return _userMedalDatas;
		}
	}

	public static void SetBool(string key, bool value)
	{
		if (commonKeyList.Contains(key))
		{
			PlayerPrefs.SetString(key, value.ToString());
		}
		else
		{
			PlayerPrefs.SetString(key + m_playerId, value.ToString());
		}
	}

	public static bool GetBool(string key)
	{
		try
		{
			if (commonKeyList.Contains(key))
			{
				return bool.Parse(PlayerPrefs.GetString(key));
			}
			return bool.Parse(PlayerPrefs.GetString(key + m_playerId));
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static T GetTypeFromJson<T>(string key, Func<T> defaultConstructor = null)
	{
		if (defaultConstructor == null)
		{
			defaultConstructor = () => default(T);
		}
		string text = (commonKeyList.Contains(key) ? key : (key + m_playerId));
		string text2 = null;
		try
		{
			if (PlayerPrefs.HasKey(text))
			{
				text2 = PlayerPrefs.GetString(text);
				return JsonHelper.ToObject<T>(text2);
			}
			return defaultConstructor();
		}
		catch (Exception)
		{
			return defaultConstructor();
		}
	}

	public static void SetTypeToJson<T>(string key, T value)
	{
		string text = (commonKeyList.Contains(key) ? key : (key + m_playerId));
		PlayerPrefs.SetString(text, JsonHelper.ToJson(value));
	}

	public static T GetTypeFromProtoBase64<T>(string key, Func<T> defaultConstructor = null)
	{
		if (defaultConstructor == null)
		{
			defaultConstructor = () => default(T);
		}
		string text = (commonKeyList.Contains(key) ? key : (key + m_playerId));
		string text2 = null;
		try
		{
			if (PlayerPrefs.HasKey(text))
			{
				text2 = PlayerPrefs.GetString(text);
				return Convert.FromBase64String(text2).Deserialize<T>();
			}
			return defaultConstructor();
		}
		catch (Exception)
		{
			return defaultConstructor();
		}
	}

	public static void SetTypeToProtoBase64<T>(string key, T value)
	{
		string text = (commonKeyList.Contains(key) ? key : (key + m_playerId));
		PlayerPrefs.SetString(text, Convert.ToBase64String(value.Serialize()));
	}

	public static void SetString(string key, string value)
	{
		if (commonKeyList.Contains(key))
		{
			PlayerPrefs.SetString(key, value);
		}
		else
		{
			PlayerPrefs.SetString(key + m_playerId, value);
		}
	}

	public static string GetString(string key)
	{
		if (commonKeyList.Contains(key))
		{
			return PlayerPrefs.GetString(key);
		}
		return PlayerPrefs.GetString(key + m_playerId);
	}

	public static void SetFloat(string key, float value)
	{
		if (commonKeyList.Contains(key))
		{
			PlayerPrefs.SetFloat(key, value);
		}
		else
		{
			PlayerPrefs.SetFloat(key + m_playerId, value);
		}
	}

	public static float GetFloat(string key)
	{
		if (commonKeyList.Contains(key))
		{
			return PlayerPrefs.GetFloat(key);
		}
		return PlayerPrefs.GetFloat(key + m_playerId);
	}

	public static void SetInt(string key, int value)
	{
		if (commonKeyList.Contains(key))
		{
			PlayerPrefs.SetInt(key, value);
		}
		else
		{
			PlayerPrefs.SetInt(key + m_playerId, value);
		}
	}

	public static int GetInt(string key)
	{
		if (commonKeyList.Contains(key))
		{
			return PlayerPrefs.GetInt(key);
		}
		return PlayerPrefs.GetInt(key + m_playerId);
	}

	public static bool HasKey(string key)
	{
		if (commonKeyList.Contains(key))
		{
			return PlayerPrefs.HasKey(key);
		}
		return PlayerPrefs.HasKey(key + m_playerId);
	}

	public static void DeleteKey(string key)
	{
		if (commonKeyList.Contains(key))
		{
			PlayerPrefs.DeleteKey(key);
		}
		else
		{
			PlayerPrefs.DeleteKey(key + m_playerId);
		}
	}

	public static void ClearUserCache()
	{
		ClearQuickBattleCache();
		ClearSpecialActivityExpire();
		ClearSelfUserLocalData();
	}

	public static void ClearLoginTimeData()
	{
		DeleteKey("TodayPlayTime");
		DeleteKey("LastLoginTime");
		DeleteKey("CurLoginTime");
	}

	public static object GetLastReplay()
	{
		string text = GetString("LastReplayLevelId");
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		string text2 = GetString("LastReplayBattleId");
		if (string.IsNullOrWhiteSpace(text2))
		{
			return null;
		}
		int num = GetInt("LastReplayTargetFrame");
		if (num == 0)
		{
			return null;
		}
		bool localSource = GetBool("LastReplayLocalSource");
		PlayBattleReplayData playBattleReplayData = new PlayBattleReplayData
		{
			BattleId = text2,
			TargetFrame = num - 1,
			LevelId = text,
			LocalSource = localSource,
			ReplayMode = 3,
			MaskDuration = 0
		};
		return playBattleReplayData;
	}

	public static void SetLastReplay(PlayBattleReplayData replayData)
	{
		SetString("LastReplayLevelId", replayData.LevelId);
		SetString("LastReplayBattleId", replayData.BattleId);
		SetInt("LastReplayTargetFrame", replayData.TargetFrame);
		SetBool("LastReplayLocalSource", replayData.LocalSource);
	}

	public static int GetLastOpenReplayList()
	{
		return GetInt("LastOpenReplayList");
	}

	public static void SetLastOpenReplayList(int value)
	{
		SetInt("LastOpenReplayList", value);
	}

	public static string GetLastReplayUserName()
	{
		return GetString("LastReplayName");
	}

	public static int GetLastReplayUserId()
	{
		return GetInt("LastReplayUserId");
	}

	public static string GetLastReplayUserAvatar()
	{
		return GetString("LastReplayAvatar");
	}

	public static void SetLastReplayUserInfo(string userName, string userAvatar)
	{
		SetString("LastReplayName", userName);
		SetString("LastReplayAvatar", userAvatar);
	}

	public static void SetLastReplayUserId(int id)
	{
		SetInt("LastReplayUserId", id);
	}

	public static void ClearLastReplayUserInfo()
	{
		DeleteKey("LastReplayName");
		DeleteKey("LastReplayAvatar");
		DeleteKey("LastReplayUserId");
	}

	public static void ClearLastOpenReplayListCache()
	{
		DeleteKey("LastOpenReplayList");
	}

	public static void ClearReplayCache()
	{
		DeleteKey("LastOpenReplayList");
		DeleteKey("LastReplayLevelId");
		DeleteKey("LastReplayBattleId");
		DeleteKey("LastReplayTargetFrame");
		DeleteKey("LastReplayLocalSource");
	}

	public static void ClearAllCache()
	{
		ClearReplayCache();
		ClearLastReplayUserInfo();
		ClearSelfUserLocalData();
	}

	public static void SetLegendExplorationSoldiers(List<string> soldiers)
	{
		if (soldiers != null && soldiers.Count > 0)
		{
			SetString("LastLegendExplorationSoldiers", JsonHelper.ToJson(soldiers));
		}
	}

	public static List<string> GetLastLegendExplorationSoldiers()
	{
		string text = GetString("LastLegendExplorationSoldiers");
		if (!string.IsNullOrEmpty(text))
		{
			return JsonHelper.ToObject<List<string>>(text);
		}
		return new List<string>();
	}

	public static int GetLastDungeonBattleMinLevel()
	{
		return GetInt("LastDungeonBattleMinLevel");
	}

	public static void SetLastDungeonBattleMinLevel(int value)
	{
		int num = GetInt("LastDungeonBattleMinLevel");
		if (GetBool("ResetDungeonBattleMinLevel") || value < num)
		{
			SetBool("ResetDungeonBattleMinLevel", value: false);
			SetInt("LastDungeonBattleMinLevel", value);
		}
	}

	public static void ReadyToResetDungeonBattleMinLevel()
	{
		SetBool("ResetDungeonBattleMinLevel", value: true);
	}

	public static int GetLastLegendExplorationIndex()
	{
		return GetInt("LastLegendExplorationFloorIndex");
	}

	public static void SetLastLegendExplorationFloorIndex(int value)
	{
		SetInt("LastLegendExplorationFloorIndex", value);
	}

	public static void SetLastLegendExplorationLevelOffsetX(float value)
	{
		SetFloat("LastLegendExplorationLevelOffsetX", value);
	}

	public static float GetLastLegendExplorationLevelOffsetX()
	{
		return GetFloat("LastLegendExplorationLevelOffsetX");
	}

	public static void ClearLastLegendExplorationId()
	{
		DeleteKey("LastLegendExplorationFloorIndex");
		DeleteKey("LastLegendExplorationLevelOffsetX");
		DeleteKey("LastLegendExplorationSoldiers");
	}

	public static string GetReforgeSubEntries()
	{
		return GetString("ReforgeSubEntries");
	}

	public static void ClearReforgeSubEntries()
	{
		DeleteKey("ReforgeSubEntries");
	}

	public static void SetReforgeSubEntries(string reforgeSubEntriesValue)
	{
		SetString("ReforgeSubEntries", reforgeSubEntriesValue);
	}

	public static void SetInstanceZoneQuickBattleSwitch(List<string> _data)
	{
		SetString("InstanceZoneQuickBattleSwitch", JsonHelper.ToJson(_data));
	}

	public static List<string> GetInstanceZoneQuickBattleSwitch()
	{
		string text = GetString("InstanceZoneQuickBattleSwitch");
		if (string.IsNullOrWhiteSpace(text))
		{
			return new List<string>();
		}
		return JsonHelper.ToObject<List<string>>(text);
	}

	public static int GetTimeLimitInstanceZoneQuickBattleSwitch()
	{
		return GetInt("TimeLimitInstanceZoneQuickBattleSwitch");
	}

	public static void SetTimeLimitInstanceZoneQuickBattleSwitch(int _selectIndex)
	{
		SetInt("TimeLimitInstanceZoneQuickBattleSwitch", _selectIndex);
	}

	public static int GetDefensiveInstanceZoneQuickBattleSwitch()
	{
		return GetInt("DefensiveInstanceZoneQuickBattleSwitch");
	}

	public static void SetDefensiveInstanceZoneQuickBattleSwitch(int _selectIndex)
	{
		SetInt("DefensiveInstanceZoneQuickBattleSwitch", _selectIndex);
	}

	public static int GetOffensiveInstanceZoneQuickBattleSwitch()
	{
		return GetInt("OffensiveInstanceZoneQuickBattleSwitch");
	}

	public static void SetOffensiveInstanceZoneQuickBattleSwitch(int _selectIndex)
	{
		SetInt("OffensiveInstanceZoneQuickBattleSwitch", _selectIndex);
	}

	public static void ClearQuickBattleCache()
	{
		DeleteKey("TimeLimitInstanceZoneQuickBattleSwitch");
		DeleteKey("DefensiveInstanceZoneQuickBattleSwitch");
		DeleteKey("OffensiveInstanceZoneQuickBattleSwitch");
		DeleteKey("InstanceZoneQuickBattleSwitch");
	}

	private static void SetSpecialActivityExpire(List<string> activitiesId)
	{
		if (activitiesId != null && activitiesId.Count > 0)
		{
			string value = JsonHelper.ToJson(activitiesId);
			SetString("SpecialActivityExpire", value);
		}
	}

	private static List<string> GetSpecialActivityExpire()
	{
		List<string> result = new List<string>();
		string text = GetString("SpecialActivityExpire");
		if (!string.IsNullOrWhiteSpace(text))
		{
			result = JsonHelper.ToObject<List<string>>(text);
		}
		return result;
	}

	public static bool CanShowSpecialActivityExpireTip(string activityId)
	{
		List<string> specialActivityExpire = GetSpecialActivityExpire();
		bool flag = !specialActivityExpire.Contains(activityId);
		if (flag)
		{
			specialActivityExpire.Add(activityId);
			SetSpecialActivityExpire(specialActivityExpire);
		}
		return flag;
	}

	private static void ClearSpecialActivityExpire()
	{
		DeleteKey("SpecialActivityExpire");
	}

	public static void SetPvpScoreRankingList(List<ScoreRankSummary> scoreRankList, int modifiedDate)
	{
		if (scoreRankList != null && scoreRankList.Count > 0)
		{
			PvpScoreRankingListLocalData obj = new PvpScoreRankingListLocalData
			{
				ScoreRankList = scoreRankList,
				ModifiedDate = modifiedDate
			};
			SetString(RankDataHelper.RankSeasonInfo?.TurnId.ToString() + "PvpScoreRankingList", JsonHelper.ToJson(obj));
		}
	}

	public static List<ScoreRankSummary> GetPvpScoreRankingList()
	{
		string text = GetString(RankDataHelper.RankSeasonInfo?.TurnId.ToString() + "PvpScoreRankingList");
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		PvpScoreRankingListLocalData pvpScoreRankingListLocalData = JsonHelper.ToObject<PvpScoreRankingListLocalData>(text);
		if (pvpScoreRankingListLocalData.ModifiedDate <= (int)GameController.Instance.GetServerTime())
		{
			return null;
		}
		return pvpScoreRankingListLocalData.ScoreRankList;
	}

	public static void SetSimpleRankingList(List<SimpleRankSummary> simpleRankList, int modifiedDate)
	{
		if (simpleRankList != null && simpleRankList.Count > 0)
		{
			PvpTotalRankingListLocalData obj = new PvpTotalRankingListLocalData
			{
				SimpleRankList = simpleRankList,
				ModifiedDate = modifiedDate
			};
			SetString(RankDataHelper.RankSeasonInfo?.TurnId.ToString() + "PvpTotalRankingList", JsonHelper.ToJson(obj));
		}
	}

	public static List<SimpleRankSummary> GetSimpleRankingList()
	{
		string text = GetString(RankDataHelper.RankSeasonInfo?.TurnId.ToString() + "PvpTotalRankingList");
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		PvpTotalRankingListLocalData pvpTotalRankingListLocalData = JsonHelper.ToObject<PvpTotalRankingListLocalData>(text);
		if (pvpTotalRankingListLocalData.ModifiedDate <= (int)GameController.Instance.GetServerTime())
		{
			return null;
		}
		return pvpTotalRankingListLocalData.SimpleRankList;
	}

	public static GvGSelectedSoldiersConfig GetGvGSelectedSoldiersConfigs()
	{
		string text = GetString("GvGGetSelectedSoldiers");
		if (string.IsNullOrWhiteSpace(text))
		{
			return new GvGSelectedSoldiersConfig();
		}
		return JsonHelper.ToObject<GvGSelectedSoldiersConfig>(text);
	}

	public static void SetGvGSelectedSoldiersConfigs(GvGSelectedSoldiersConfig _config)
	{
		SetString("GvGGetSelectedSoldiers", JsonHelper.ToJson(_config));
	}

	public static RankBattleTopTournamentConfig GetDungeonPresetFormationConfigs()
	{
		string text = GetString("DungeonPreset");
		if (string.IsNullOrWhiteSpace(text))
		{
			text = "{\"FormationsId\":[],\"_Units\":\"\"}";
		}
		return JsonHelper.ToObject<RankBattleTopTournamentConfig>(text);
	}

	public static void SetDungeonPresetFormationConfigs(RankBattleTopTournamentConfig _config)
	{
		SetString("DungeonPreset", JsonHelper.ToJson(_config));
	}

	public static RankBattleFormationUnitsConfig GetPvpBattleFormationUnitsConfigs(int legionSize)
	{
		string text = GetString("PvpUserBattleArmy");
		if (string.IsNullOrWhiteSpace(text))
		{
			return GameManagers.Instance.UserArchiveManager.GetRankBattleFormationConfig();
		}
		Dictionary<string, RankBattleFormationUnitsConfig> dictionary = JsonHelper.ToObject<Dictionary<string, RankBattleFormationUnitsConfig>>(text);
		if (dictionary.Count < 0 || !dictionary.ContainsKey(legionSize.ToString()))
		{
			return GameManagers.Instance.UserArchiveManager.GetRankBattleFormationConfig();
		}
		return dictionary[legionSize.ToString()];
	}

	public static void SetPvpBattleFormationUnitsConfigs(int legionSize, RankBattleFormationUnitsConfig _config)
	{
		if (_config == null)
		{
			return;
		}
		string text = GetString("PvpUserBattleArmy");
		string key = legionSize.ToString();
		if (string.IsNullOrWhiteSpace(text))
		{
			Dictionary<string, RankBattleFormationUnitsConfig> obj = new Dictionary<string, RankBattleFormationUnitsConfig> { { key, _config } };
			SetString("PvpUserBattleArmy", JsonHelper.ToJson(obj));
			return;
		}
		Dictionary<string, RankBattleFormationUnitsConfig> dictionary = JsonHelper.ToObject<Dictionary<string, RankBattleFormationUnitsConfig>>(text);
		if (!dictionary.ContainsKey(key))
		{
			dictionary.Add(key, _config);
		}
		else
		{
			dictionary[key] = _config;
		}
		SetString("PvpUserBattleArmy", JsonHelper.ToJson(dictionary));
	}

	public static int GetPvpQuickBattleSwitch()
	{
		return GetInt("PvpQuickBattleSwitch");
	}

	public static void SetPvpQuickBattleSwitch(int switchIndex)
	{
		if (switchIndex >= 0 && switchIndex <= 2)
		{
			SetInt("PvpQuickBattleSwitch", switchIndex);
		}
	}

	public static SelfLocalData GetSelfUserLocalData()
	{
		string text = GetString("SelfUserData");
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		return JsonHelper.ToObject<SelfLocalData>(text);
	}

	public static void SetSelfUserLocalData(SelfLocalData data)
	{
		SetString("SelfUserData", JsonHelper.ToJson(data));
	}

	public static void ClearSelfUserLocalData()
	{
		string selfAvatarLocalPath = UiHelper.GetSelfAvatarLocalPath();
		if (File.Exists(selfAvatarLocalPath))
		{
			File.Delete(selfAvatarLocalPath);
		}
		DeleteKey("SelfUserData");
	}

	public static UserLocalData GetSomeUserLocalData(int userId)
	{
		if (userId <= 0)
		{
			return null;
		}
		if (UserLocalDatas.TryGetValue(userId.ToString(), out var value))
		{
			return value;
		}
		return null;
	}

	public static void SetSomeUserLocalData(int userId, UserLocalData _userLocalData, bool forceSave = true)
	{
		if (userId > 0 && _userLocalData != null)
		{
			UserLocalDatas[userId.ToString()] = _userLocalData;
			if (forceSave)
			{
				SetString("PvpUserLocalData_New", JsonHelper.ToJson(UserLocalDatas));
			}
		}
	}

	public static UserMedalData GetUserMedalData(int userId)
	{
		if (userId <= 0)
		{
			return null;
		}
		UserMedalDatas.TryGetValue(userId.ToString(), out var value);
		long serverTime = GameController.Instance.GetServerTime();
		if (value != null && serverTime < value.ModifiedDate)
		{
			return value;
		}
		return null;
	}

	public static void SetUserMedalData(int userId, string medals)
	{
		if (userId > 0)
		{
			UserMedalData value = new UserMedalData
			{
				Medals = medals,
				ModifiedDate = GameController.Instance.GetServerTime() + 3600
			};
			UserMedalDatas[userId.ToString()] = value;
			SetString("GvgUserLocalData_Medal", JsonHelper.ToJson(UserMedalDatas));
		}
	}

	private static int MedalSort(GvGMedalRecord a, GvGMedalRecord b)
	{
		int num = b.Config.Rarity - a.Config.Rarity;
		if (num != 0)
		{
			return num;
		}
		return a.Config.Index - b.Config.Index;
	}

	public static BattleRecordDetail GetUserGvGRecordDetailLocalData(string recordDetailLocalId)
	{
		if (string.IsNullOrEmpty(recordDetailLocalId))
		{
			return null;
		}
		string text = GetString("UserGvGRecordDetailLocalData");
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		Dictionary<string, BattleRecordDetail> dictionary = JsonHelper.ToObject<Dictionary<string, BattleRecordDetail>>(text);
		if (dictionary.TryGetValue(recordDetailLocalId, out var value))
		{
			return value;
		}
		return null;
	}

	public static void SetUserGvGRecordDetailLocalData(string recordDetailLocalId, BattleRecordDetail data)
	{
		if (!string.IsNullOrEmpty(recordDetailLocalId) && data != null)
		{
			string text = GetString("UserGvGRecordDetailLocalData");
			Dictionary<string, BattleRecordDetail> dictionary = ((!string.IsNullOrWhiteSpace(text)) ? JsonHelper.ToObject<Dictionary<string, BattleRecordDetail>>(text) : new Dictionary<string, BattleRecordDetail>());
			if (dictionary.ContainsKey(recordDetailLocalId))
			{
				dictionary[recordDetailLocalId] = data;
			}
			else
			{
				dictionary.Add(recordDetailLocalId, data);
			}
			SetString("UserGvGRecordDetailLocalData", JsonHelper.ToJson(dictionary));
		}
	}

	public static void SetUserGvGShipRecordsListData(string recordId, GvGShipRecords records)
	{
		if (!string.IsNullOrEmpty(recordId) && records != null)
		{
			string text = GetString("UserGvGShipRecordsListData");
			Dictionary<string, GvGShipRecords> dictionary = ((!string.IsNullOrWhiteSpace(text)) ? JsonHelper.ToObject<Dictionary<string, GvGShipRecords>>(text) : new Dictionary<string, GvGShipRecords>());
			if (!dictionary.ContainsKey(recordId))
			{
				dictionary.Add(recordId, records);
				SetString("UserGvGShipRecordsListData", JsonHelper.ToJson(dictionary));
			}
		}
	}

	public static List<GvGShipRecords> GetUserGvGShipRecordsListData(GvGShipRecords records)
	{
		if (records == null)
		{
			return null;
		}
		string text = GetString("UserGvGShipRecordsListData");
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		Dictionary<string, GvGShipRecords> dictionary = JsonHelper.ToObject<Dictionary<string, GvGShipRecords>>(text);
		if (!dictionary.ContainsKey(records.RecordId.ToString()))
		{
			return null;
		}
		List<GvGShipRecords> list = new List<GvGShipRecords>();
		foreach (KeyValuePair<string, GvGShipRecords> item in dictionary)
		{
			if (GvGShipRecordsSort(records, item.Value) == -1)
			{
				list.Add(item.Value);
			}
		}
		if (list.Count <= 0)
		{
			return null;
		}
		list.Sort(GvGShipRecordsSort);
		return (list.Count > 5) ? list.Take(5).ToList() : list;
	}

	public static List<GvGShipRecords> GetUserGvGShipRecordsListData()
	{
		string text = GetString("UserGvGShipRecordsListData");
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		Dictionary<string, GvGShipRecords> dictionary = JsonHelper.ToObject<Dictionary<string, GvGShipRecords>>(text);
		List<GvGShipRecords> list = new List<GvGShipRecords>();
		list = dictionary.Values.ToList();
		if (list.Count <= 0)
		{
			return null;
		}
		list.Sort(GvGShipRecordsSort);
		return (list.Count > 5) ? list.Take(5).ToList() : list;
	}

	public static int GvGShipRecordsSort(GvGShipRecords a, GvGShipRecords b)
	{
		if (a.CreatedTime > b.CreatedTime)
		{
			return -1;
		}
		if (a.CreatedTime < b.CreatedTime)
		{
			return 1;
		}
		if (a.RecordId > b.RecordId)
		{
			return -1;
		}
		if (a.RecordId < b.RecordId)
		{
			return 1;
		}
		return 0;
	}

	public static bool GetCurPvpTurnPeakBattleState(string curTurnId)
	{
		if (string.IsNullOrWhiteSpace(curTurnId))
		{
			return false;
		}
		string text = GetString("PvpAllTurnsPeakBattle");
		if (string.IsNullOrWhiteSpace(text))
		{
			return false;
		}
		List<string> list = JsonHelper.ToObject<List<string>>(text);
		return list.Contains(curTurnId);
	}

	public static void SetUnlockPeakBattleTurnId(string curTurnId)
	{
		if (!string.IsNullOrWhiteSpace(curTurnId))
		{
			string text = GetString("PvpAllTurnsPeakBattle");
			List<string> list = ((!string.IsNullOrWhiteSpace(text)) ? JsonHelper.ToObject<List<string>>(text) : new List<string>());
			if (!list.Contains(curTurnId))
			{
				list.Add(curTurnId);
			}
			SetString("PvpAllTurnsPeakBattle", JsonHelper.ToJson(list));
		}
	}

	public static void ClearLastPvpData()
	{
		DeleteKey("PvpUserBattleArmy");
	}

	public static int GetGvGStoreNextUpdateTimestamp()
	{
		return GetInt("GvGStoreNextUpdateTimestamp");
	}

	public static void SetGvGStoreNextUpdateTimestamp(int timestamp)
	{
		SetInt("GvGStoreNextUpdateTimestamp", timestamp);
	}

	public static bool GetGvGStoreHasCheck()
	{
		return GetBool("GvGStoreHasCheck");
	}

	public static void SetGvGStoreHasCheck(bool b)
	{
		SetBool("GvGStoreHasCheck", b);
	}

	public static int GetGvgStoreConfirmActivateDontShowAgainUntil()
	{
		if (HasKey("TipKey_GvgStoreConfirmActivate"))
		{
			return GetInt("TipKey_GvgStoreConfirmActivate");
		}
		return 0;
	}

	public static void SetGvgStoreConfirmActivateDontShowAgainUntil(int time)
	{
		SetInt("TipKey_GvgStoreConfirmActivate", time);
	}

	public static int GetGvgStoreConfirmBuyItemDontShowAgainUntil()
	{
		if (HasKey("TipKey_GvgStoreConfirmBuyItem"))
		{
			return GetInt("TipKey_GvgStoreConfirmBuyItem");
		}
		return 0;
	}

	public static void SetGvgStoreConfirmBuyItemDontShowAgainUntil(int time)
	{
		SetInt("TipKey_GvgStoreConfirmBuyItem", time);
	}

	public static void SetUserGvGIZProgress(string izId, int IZProgress)
	{
		Dictionary<string, GvGIZProgress> userGvGIZProgress = GetUserGvGIZProgress();
		if (!userGvGIZProgress.ContainsKey(izId))
		{
			userGvGIZProgress.Add(izId, new GvGIZProgress
			{
				IZId = izId,
				IZProgress = new List<int> { IZProgress }
			});
			SetString("UserGvGIZProgress", JsonHelper.ToJson(userGvGIZProgress));
		}
		else
		{
			if (!userGvGIZProgress[izId].IZProgress.Contains(IZProgress))
			{
				userGvGIZProgress[izId].IZProgress.Add(IZProgress);
			}
			SetString("UserGvGIZProgress", JsonHelper.ToJson(userGvGIZProgress));
		}
	}

	public static bool PlaytGvGIZProgressChange(string izId, int IZProgress)
	{
		Dictionary<string, GvGIZProgress> userGvGIZProgress = GetUserGvGIZProgress();
		if (!userGvGIZProgress.ContainsKey(izId))
		{
			SetUserGvGIZProgress(izId, IZProgress);
			return true;
		}
		if (!userGvGIZProgress[izId].IZProgress.Contains(IZProgress))
		{
			SetUserGvGIZProgress(izId, IZProgress);
			return true;
		}
		return false;
	}

	private static Dictionary<string, GvGIZProgress> GetUserGvGIZProgress()
	{
		string text = GetString("UserGvGIZProgress");
		Dictionary<string, GvGIZProgress> result = new Dictionary<string, GvGIZProgress>();
		if (!string.IsNullOrEmpty(text))
		{
			result = JsonHelper.ToObject<Dictionary<string, GvGIZProgress>>(text);
		}
		return result;
	}

	public static string GetSomeGvGAbilityInfo(string wbId, string activityId, int level, string text)
	{
		if (string.IsNullOrEmpty(wbId) || string.IsNullOrEmpty(activityId))
		{
			return "";
		}
		string text2 = GetString("UserGvGAbilitiesInfo");
		Dictionary<string, GvGAbilityInfo> dictionary = new Dictionary<string, GvGAbilityInfo>();
		if (!string.IsNullOrEmpty(text2))
		{
			dictionary = JsonHelper.ToObject<Dictionary<string, GvGAbilityInfo>>(text2);
		}
		string key = wbId + "_" + activityId;
		if (!dictionary.ContainsKey(key))
		{
			SetSomeGvGAbilityInfo(wbId, activityId, level, text);
			return "";
		}
		int level2 = dictionary[key].Level;
		if (level2 > level)
		{
			SetSomeGvGAbilityInfo(wbId, activityId, level, text);
			return dictionary[key].NameAndLevelText;
		}
		return "";
	}

	public static void SetSomeGvGAbilityInfo(string wbId, string activityId, int level, string text)
	{
		if (!string.IsNullOrEmpty(wbId) && !string.IsNullOrEmpty(activityId) && !string.IsNullOrEmpty(text))
		{
			string text2 = GetString("UserGvGAbilitiesInfo");
			Dictionary<string, GvGAbilityInfo> dictionary = new Dictionary<string, GvGAbilityInfo>();
			if (!string.IsNullOrEmpty(text2))
			{
				dictionary = JsonHelper.ToObject<Dictionary<string, GvGAbilityInfo>>(text2);
			}
			string key = wbId + "_" + activityId;
			if (dictionary.ContainsKey(key))
			{
				dictionary[key].Level = level;
				dictionary[key].NameAndLevelText = text;
			}
			else
			{
				dictionary.Add(key, new GvGAbilityInfo
				{
					Level = level,
					NameAndLevelText = text
				});
			}
			SetString("UserGvGAbilitiesInfo", JsonHelper.ToJson(dictionary));
		}
	}

	private static List<int> LoadMaqueeContentSaveData()
	{
		string text = GetString("MarqueeContentSaveKey");
		if (string.IsNullOrEmpty(text))
		{
			return new List<int>();
		}
		return JsonHelper.ToObject<List<int>>(text);
	}

	private static void SaveMaqueeContentSaveData(List<int> data)
	{
		SetString("MarqueeContentSaveKey", JsonHelper.ToJson(data));
	}

	public static bool IsMarqueePlayed(int Id)
	{
		List<int> list = LoadMaqueeContentSaveData();
		return list.Contains(Id);
	}

	public static void SetMarqueePlayed(int Id)
	{
		List<int> list = LoadMaqueeContentSaveData();
		if (!list.Contains(Id))
		{
			list.Add(Id);
		}
		SaveMaqueeContentSaveData(list);
	}

	public static List<string> LoadIslandComeAgainSoldiers()
	{
		string text = GetString("IslandComeAgainSoldiersKey");
		if (string.IsNullOrEmpty(text))
		{
			return new List<string>();
		}
		return JsonHelper.ToObject<List<string>>(text);
	}

	public static void SaveIslandComeAgainSoldiers(List<string> soldiers)
	{
		if (soldiers != null && soldiers.Count >= 5)
		{
			SetString("IslandComeAgainSoldiersKey", JsonHelper.ToJson(soldiers));
		}
	}

	public static Dictionary<int, List<UserIslandEntityBattleRecordSummary>> LoadIslandComeAgainBattleRecords()
	{
		string text = GetString("IslandComeAgainBattleRecordKey");
		Dictionary<int, List<UserIslandEntityBattleRecordSummary>> dictionary = new Dictionary<int, List<UserIslandEntityBattleRecordSummary>>();
		if (string.IsNullOrEmpty(text))
		{
			return dictionary;
		}
		Dictionary<string, List<UserIslandEntityBattleRecordSummary>> dictionary2 = JsonHelper.ToObject<Dictionary<string, List<UserIslandEntityBattleRecordSummary>>>(text);
		foreach (KeyValuePair<string, List<UserIslandEntityBattleRecordSummary>> item in dictionary2)
		{
			dictionary.Add(int.Parse(item.Key), item.Value);
		}
		return dictionary;
	}

	public static void SaveIslandComeAgainBattleRecords(Dictionary<int, List<UserIslandEntityBattleRecordSummary>> records)
	{
		if (records != null && records.Count > 0)
		{
			SetString("IslandComeAgainBattleRecordKey", JsonHelper.ToJson(records));
		}
	}

	public static bool IslandLogChecked(string processId)
	{
		string text = GetString("IslandLogsChecked");
		return !string.IsNullOrEmpty(text) && JsonHelper.ToObject<List<string>>(text).Contains(processId);
	}

	public static void CheckIslandLog([NotNull] string processId)
	{
		if (string.IsNullOrEmpty(processId))
		{
			throw new ArgumentException("Value cannot be null or empty.", "processId");
		}
		string text = GetString("IslandLogsChecked");
		List<string> list = ((!string.IsNullOrEmpty(text)) ? JsonHelper.ToObject<List<string>>(text) : new List<string>());
		if (!list.Contains(processId))
		{
			list.Add(processId);
		}
		SetString("IslandLogsChecked", JsonHelper.ToJson(list));
	}

	public static string GetFriendsChatSessionSaveKey(int friendId)
	{
		return $"FriendsChatWith_{friendId}";
	}

	public static void SetID(int id)
	{
		m_playerId = id;
	}

	public static void SaveObjectDate<T>(string key, T t, bool common = false)
	{
		if (common)
		{
			PlayerPrefs.SetString(key, JsonHelper.ToJson(t));
		}
		else
		{
			PlayerPrefs.SetString(key + m_playerId, JsonHelper.ToJson(t));
		}
		PlayerPrefs.Save();
	}

	public static T GetObjectData<T>(string key, bool common = false) where T : new()
	{
		string text = null;
		text = ((!common) ? PlayerPrefs.GetString(key + m_playerId, (string)null) : PlayerPrefs.GetString(key, (string)null));
		if (string.IsNullOrEmpty(text))
		{
			return new T();
		}
		return JsonHelper.ToObject<T>(text);
	}

	public static void SetObjectData<T>(string key, T val, bool common = false) where T : new()
	{
		if (!common)
		{
			key += m_playerId;
		}
		PlayerPrefs.SetString(key, JsonHelper.ToJson(val));
	}

	public static string GetActivityLastStayAt(string activityId)
	{
		if (!ActivityManager.Activities.TryGetValue(activityId, out var value))
		{
			return activityId;
		}
		if (value.Data.Singleton)
		{
			string key = "CurrentActivityOfType." + value.Type;
			string text = GetString(key);
			if (text != activityId)
			{
				SetString(key, activityId);
				DeleteKey("ActivityLastStayAt." + text);
				return activityId;
			}
		}
		string key2 = "ActivityLastStayAt." + activityId;
		string text2 = GetString(key2);
		if (string.IsNullOrEmpty(text2))
		{
			text2 = activityId;
			SetString(key2, text2);
		}
		return text2;
	}

	public static void SetActivityLastStayAt(string activityId)
	{
		if (ActivityManager.Activities.TryGetValue(activityId, out var value))
		{
			Activity activity = value;
			Activity value2;
			while (!string.IsNullOrEmpty(activity.Parent) && ActivityManager.Activities.TryGetValue(activity.Parent, out value2))
			{
				activity = value2;
			}
			SetString("ActivityLastStayAt." + activity.ActivityId, activityId);
		}
	}

	public static List<int> GetAppleAdReportedUsers()
	{
		return GetObjectData<List<int>>("AppleAdReportedUsers", common: true);
	}

	public static void MarkUserReportedAppleAd(int userId)
	{
		List<int> appleAdReportedUsers = GetAppleAdReportedUsers();
		if (!appleAdReportedUsers.Contains(userId))
		{
			appleAdReportedUsers.Add(userId);
			SetObjectData("AppleAdReportedUsers", appleAdReportedUsers, common: true);
		}
	}

	public static LevelAssistanceFormation GetLevelAssistanceBattleFormation()
	{
		string text = GetString(m_playerId + "LevelAssistanceFormation");
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		return JsonHelper.ToObject<LevelAssistanceFormation>(text);
	}

	public static void SetLevelAssistanceBattleFormation(LevelAssistanceFormation levelAssistanceFormation)
	{
		SetString(m_playerId + "LevelAssistanceFormation", JsonHelper.ToJson(levelAssistanceFormation));
	}

	public static void UpdateGuestId(string newGuestId)
	{
		GuestInfo guestInfo = new GuestInfo
		{
			GuestUserId = newGuestId,
			ExpireAt = DateTimeHelper.GetTimeStamp(DateTimeHelper.ServerNow) + 2592000
		};
		SetString("GuestInfo", JsonHelper.ToJson(guestInfo));
	}

	public static GuestInfo GetGuestInfo()
	{
		string text = GetString("GuestInfo");
		if (string.IsNullOrEmpty(text))
		{
			return default(GuestInfo);
		}
		return JsonHelper.ToObject<GuestInfo>(text);
	}

	public static void ClearGuestId()
	{
		DeleteKey("GuestInfo");
	}

	public static int GetSpeedPlanLastClaim()
	{
		return GetInt("SpeedPlanLastClaim");
	}

	public static void SetSpeedPlanLastClaim(int claimAt)
	{
		SetInt("SpeedPlanLastClaim", claimAt);
	}

	public static void ClearSpeedPlanLastClaim()
	{
		DeleteKey("SpeedPlanLastClaim");
	}

	public static int GetSpeedPlanLastPurchase()
	{
		return GetInt("SpeedPlanLastPurchase");
	}

	public static void SetSpeedPlanLastPurchase(int purchaseAt)
	{
		SetInt("SpeedPlanLastPurchase", purchaseAt);
	}

	public static void ClearSpeedPlanLastPurchase()
	{
		DeleteKey("SpeedPlanLastPurchase");
	}

	public static bool GetUseRpcTipDontShowAgainByIzId_Shop(string curIzIdStr)
	{
		string text = GetString("UseRpcTipDontShowAgainByIzId_Shop");
		return text == curIzIdStr;
	}

	public static void MarkUseRpcTipDontShowAgainByIzId_Shop(string curIzIdStr)
	{
		SetString("UseRpcTipDontShowAgainByIzId_Shop", curIzIdStr);
	}

	public static bool GetUseRpcTipDontShowAgainByIzId_Dialog(string curIzIdStr)
	{
		string text = GetString("UseRpcTipDontShowAgainByIzId_Dialog");
		return text == curIzIdStr;
	}

	public static void MarkUseRpcTipDontShowAgainByIzId_Dialog(string curIzIdStr)
	{
		SetString("UseRpcTipDontShowAgainByIzId_Dialog", curIzIdStr);
	}

	public static bool GetDontShowUseDormantTip()
	{
		if (!HasKey("DontShowUseDormantTip"))
		{
			SetBool("DontShowUseDormantTip", value: true);
		}
		return GetBool("DontShowUseDormantTip");
	}

	public static void MarkDontShowUseDormantTip(bool dontShow)
	{
		SetBool("DontShowUseDormantTip", dontShow);
	}

	public static List<string> GetHotFixResPathList()
	{
		return GetObjectData<List<string>>("HotFixResList", common: true);
	}

	public static void SetHotFixResPathList(List<string> newList)
	{
		SetObjectData("HotFixResList", newList, common: true);
	}

	public static MilitaryAssistantData GetMilitaryAssistantData(string mark)
	{
		Dictionary<string, MilitaryAssistantData> objectData = GetObjectData<Dictionary<string, MilitaryAssistantData>>("MilitaryAssistantData.");
		if (objectData.TryGetValue(mark, out var value))
		{
			return value;
		}
		return null;
	}

	public static void SetMilitaryAssistantData(MilitaryAssistantData data)
	{
		Dictionary<string, MilitaryAssistantData> objectData = GetObjectData<Dictionary<string, MilitaryAssistantData>>("MilitaryAssistantData.");
		objectData[data.ActivityMark] = data;
		SetObjectData("MilitaryAssistantData.", objectData);
	}

	public static void ClearMilitaryAssistantData()
	{
		PlayerPrefs.DeleteKey("MilitaryAssistantData.");
	}

	public static int GetMilitaryAssistantRunningTipsDontShowAgainUntil()
	{
		string text = GetString("TipKey_MilitaryAssistantRunningTipsDontShowAgain");
		if (string.IsNullOrEmpty(text))
		{
			return 0;
		}
		return int.Parse(text);
	}

	public static int GetLegendItemDungeonPlayingIntroDontShowAgainUntil()
	{
		string text = GetString("TipKey_LegendItemDungeonPlayingIntroDontShowAgain");
		if (string.IsNullOrEmpty(text))
		{
			return 0;
		}
		return int.Parse(text);
	}

	public static int GetAutoChallengeDontShowAgainUntil()
	{
		string text = GetString("TipKey_AutoChallenge");
		if (string.IsNullOrEmpty(text))
		{
			return 0;
		}
		return int.Parse(text);
	}

	public static long GetPvpClickAssistantDontShowAgainUtil()
	{
		string text = GetString("TipKey_PvpClickAssistant");
		if (string.IsNullOrEmpty(text))
		{
			return 0L;
		}
		return long.Parse(text);
	}

	public static void SetLastCheckedTopTournamentTurnId(string turnId)
	{
		PlayerPrefs.SetString("LastCheckedTopTournamentTurnId", turnId);
	}

	public static string GetLastCheckedTopTournamentTurnId()
	{
		return PlayerPrefs.GetString("LastCheckedTopTournamentTurnId");
	}

	public static string GetAllServersChampionshipStageRankCheckedCache()
	{
		return PlayerPrefs.GetString("AllServersChampionshipChecked");
	}

	public static void SetAllServersChampionshipStageRankCheckedCache(string cacheVal)
	{
		PlayerPrefs.SetString("AllServersChampionshipChecked", cacheVal);
	}

	public static int GetSeasonBetStoreLastRefreshTime()
	{
		return PlayerPrefs.GetInt("SeasonBetStoreLastRefreshTime");
	}

	public static void SetSeasonBetStoreLastRefreshTime(int value)
	{
		PlayerPrefs.SetInt("SeasonBetStoreLastRefreshTime", value);
	}

	private static void RefreshLastReplayStuckTimes()
	{
		DateTimeOffset now = (((Object)(object)GameController.Instance == (Object)null) ? DateTimeHelper.Now : DateTimeHelper.ServerNow);
		int timeStamp = DateTimeHelper.GetTimeStamp(DateTimeHelper.GetDailyRefreshTime(now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours));
		int num = GetInt("LastReplayStuckAt");
		if (timeStamp > num)
		{
			SetInt("LastReplayStuckAt", timeStamp);
			SetInt("TodayReplayStuckTimes", 0);
		}
	}

	public static int GetTodayReplayStuckTimes()
	{
		RefreshLastReplayStuckTimes();
		return GetInt("TodayReplayStuckTimes");
	}

	public static void IncrementTodayReplayStuckTimes()
	{
		RefreshLastReplayStuckTimes();
		int value = GetInt("TodayReplayStuckTimes") + 1;
		SetInt("TodayReplayStuckTimes", value);
	}

	public static void UpdateLastUserLoginAt()
	{
		SetInt("LastUserLoginAt.", DateTimeHelper.TimeStamp);
	}

	public static int GetLastUserLoginAt()
	{
		return GetInt("LastUserLoginAt.");
	}

	public static void ClearUserLoginAt()
	{
		DeleteKey("LastUserLoginAt.");
	}

	public static string GetServerLocationPrefer()
	{
		return GetString("ServerLocationPrefer");
	}

	public static void SetServerLocationPrefer(string serverLoc)
	{
		SetString("ServerLocationPrefer", serverLoc);
	}

	public static string GetLanguagePrefer()
	{
		return GetString("LanguagePrefer");
	}

	public static void SetLanguagePrefer(string lang)
	{
		SetString("LanguagePrefer", lang);
	}

	public static void SetZonePrefer(string zone)
	{
		SetString("ZonePrefer", zone);
	}

	public static string GetZonePrefer()
	{
		return GetString("ZonePrefer");
	}

	public static bool GetPrivacyAgreement()
	{
		return GetBool("PrivacyAgreement");
	}

	public static void SetPrivacyAgreement(bool agree)
	{
		SetBool("PrivacyAgreement", agree);
	}

	public static bool HasChosenLanguagePrefer()
	{
		return GetBool("HasChosenLanguage");
	}

	public static void MarkChosenLanguagePrefer(bool hasChosen)
	{
		SetBool("HasChosenLanguage", hasChosen);
	}

	public static int GetFirstInstallAndRegistMark()
	{
		return GetInt("IsFirstInstallAndRegist");
	}

	public static void MarkFirstInstallAndRegist(FirstInstallAndRegistFlag firstInstallAndRegistFlag)
	{
		int num = GetInt("IsFirstInstallAndRegist");
		num |= (int)firstInstallAndRegistFlag;
		SetInt("IsFirstInstallAndRegist", num);
	}

	public static int GetFrameRate()
	{
		return GetInt("FrameRatePrefer");
	}

	public static void SetFrameRate(int targetFrameRate)
	{
		SetInt("FrameRatePrefer", targetFrameRate);
	}
}
