using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using HotFix.Sources.Base.Scripts.UI;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums.Sources;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;
using UnityEngine;

namespace Shift.Legion.ClientApi.Models;

public class WarOfRealmInfo
{
	public WarStageLotterySettlement WarStageLotterySettlement;

	public List<StockChangeRecord> StockChangeRecords;

	private static readonly StageStatus[] OrderedStages = new StageStatus[18]
	{
		StageStatus.Round1_PreStage,
		StageStatus.Round1_Stage128,
		StageStatus.Round1_Stage64,
		StageStatus.Round1_Stage32,
		StageStatus.Round1_Stage16,
		StageStatus.Round1_Stage8FirstRound,
		StageStatus.Round1_Stage8SecondRound,
		StageStatus.Round1_SemiFinal,
		StageStatus.Round1_Final,
		StageStatus.Round2_PreStage,
		StageStatus.Round2_Stage128,
		StageStatus.Round2_Stage64,
		StageStatus.Round2_Stage32,
		StageStatus.Round2_Stage16,
		StageStatus.Round2_Stage8FirstRound,
		StageStatus.Round2_Stage8SecondRound,
		StageStatus.Round2_SemiFinal,
		StageStatus.Round2_Final
	};

	private List<DateTimeOffset> _roundIDuration;

	private List<DateTimeOffset> _roundIIDuration;

	public int StartAtTimestamp { get; set; }

	public int EndAtTimestamp { get; set; }

	public List<WarOfRealmMission> Missions { get; set; }

	public Dictionary<int, Dictionary<string, int>> FreeBonusDict { get; set; }

	public Dictionary<int, string> PaidBonusDict { get; set; }

	public int Score { get; set; }

	public List<string> CompletedMissions { get; set; }

	public List<int> Claimed { get; set; }

	public Dictionary<eMissionType, int> MissionProgressDict { get; set; }

	public List<StageInfo> StageInfoList { get; set; }

	public WarRankDataInfo WarRankDataInfo { get; set; }

	public bool SettlementClaimed { get; set; }

	public PlayerSettlementInfoModel PlayerSettlementInfo { get; set; }

	public string ActivityId { get; set; }

	public List<LeaderboardBonusConfig> LeaderboardBonus { get; set; }

	public List<WarRealmStoreItem> StoreContents { get; set; }

	public Dictionary<StageStatus, LotteryInfo> LotteryInfoDict { get; set; } = new Dictionary<StageStatus, LotteryInfo>();

	public Dictionary<StageStatus, MatchInfo> MatchInfoDict { get; set; } = new Dictionary<StageStatus, MatchInfo>();

	public bool Approval { get; set; }

	public List<WeekScoreRecord> ScoreHistoryRecords { get; set; } = new List<WeekScoreRecord>();

	public int ScoreHistoryTotalScore { get; set; }

	public StageStatus CurrentStageStatus => (StageStatus)(GetCurrentStageInfo()?.StageStatus ?? (-1));

	public List<DateTimeOffset> RoundIDuration
	{
		get
		{
			if (_roundIDuration == null)
			{
				_roundIDuration = new List<DateTimeOffset>();
				StageInfo stageInfo = GetStageInfo(StageStatus.Round1_PreStage);
				if (stageInfo == null)
				{
					ILRuntimeDebug.LogError("Not Found Round1 PreStage");
					_roundIDuration.Add(default(DateTimeOffset));
				}
				else
				{
					_roundIDuration.Add(DateTimeHelper.Parse(stageInfo.BeginTime));
				}
				StageInfo stageInfo2 = GetStageInfo(StageStatus.Round1_Final);
				if (stageInfo2 == null)
				{
					ILRuntimeDebug.LogError("Not Found Round1 FinalStage");
					_roundIDuration.Add(default(DateTimeOffset));
				}
				else
				{
					_roundIDuration.Add(DateTimeHelper.Parse(stageInfo2.EndTime));
				}
			}
			return _roundIDuration;
		}
	}

	public List<DateTimeOffset> RoundIIDuration
	{
		get
		{
			if (_roundIIDuration == null)
			{
				_roundIIDuration = new List<DateTimeOffset>();
				StageInfo stageInfo = GetStageInfo(StageStatus.Round2_PreStage);
				if (stageInfo == null)
				{
					ILRuntimeDebug.LogError("Not Found Round1 PreStage");
					_roundIIDuration.Add(default(DateTimeOffset));
				}
				else
				{
					_roundIIDuration.Add(DateTimeHelper.Parse(stageInfo.BeginTime));
				}
				StageInfo stageInfo2 = GetStageInfo(StageStatus.Round2_Final);
				if (stageInfo2 == null)
				{
					ILRuntimeDebug.LogError("Not Found Round1 FinalStage");
					_roundIIDuration.Add(default(DateTimeOffset));
				}
				else
				{
					_roundIIDuration.Add(DateTimeHelper.Parse(stageInfo2.EndTime));
				}
			}
			return _roundIIDuration;
		}
	}

	public string GetDisplayDuration()
	{
		string text = DateTimeHelper.Parse(StartAtTimestamp).ToOffset(DateTimeHelper.TimezoneOffset).ToString("yyyy/M/d HH:mm");
		string text2 = DateTimeHelper.Parse(EndAtTimestamp).ToOffset(DateTimeHelper.TimezoneOffset).ToString("yyyy/M/d HH:mm");
		return text + " - " + text2;
	}

	public string GetBattleBeginDescription()
	{
		StageInfo currentStageInfo = GetCurrentStageInfo();
		if (currentStageInfo.StageStatus == 1 || currentStageInfo.StageStatus == 10)
		{
			int serverNowTimestamp = DateTimeHelper.ServerNowTimestamp;
			int num = Mathf.FloorToInt((float)(currentStageInfo.BeginTime - serverNowTimestamp) / 86400f);
			if (num > 7)
			{
				int num2 = Mathf.FloorToInt((float)num / 7f);
				return string.Format(LanguagesManager.GetDesc("AllServersChampionshipBeginForecast"), $"{num2}");
			}
			if (num >= 0)
			{
				num = Mathf.Max(num, 1);
				return string.Format(LanguagesManager.GetDesc("AllServersChampionshipBeginForecast_Days"), $"{num}");
			}
		}
		return string.Empty;
	}

	public StageInfo GetCurrentStageInfo()
	{
		int serverNowTimestamp = DateTimeHelper.ServerNowTimestamp;
		StageInfo stageInfo = null;
		foreach (StageInfo stageInfo2 in StageInfoList)
		{
			if (serverNowTimestamp >= stageInfo2.BeginTime && serverNowTimestamp < stageInfo2.EndTime)
			{
				stageInfo = stageInfo2;
				break;
			}
		}
		if (stageInfo == null)
		{
			ILRuntimeDebug.LogError($"Get Current StageInfo Failed, Timestamp {serverNowTimestamp} Out of Range");
			return null;
		}
		return stageInfo;
	}

	public StageInfo GetStageInfo(StageStatus status)
	{
		foreach (StageInfo stageInfo in StageInfoList)
		{
			if (stageInfo.StageStatus == (int)status)
			{
				return stageInfo;
			}
		}
		return null;
	}

	public static StageStatus GetPrevStageStatus(StageStatus status)
	{
		for (int i = 0; i < OrderedStages.Length; i++)
		{
			if (OrderedStages[i] == status)
			{
				return (i == 0) ? StageStatus.Unknown : OrderedStages[i - 1];
			}
		}
		return StageStatus.Unknown;
	}

	public static StageStatus GetNextStageStatus(StageStatus status)
	{
		for (int i = 0; i < OrderedStages.Length; i++)
		{
			if (OrderedStages[i] == status)
			{
				return (i == OrderedStages.Length - 1) ? StageStatus.Unknown : OrderedStages[i + 1];
			}
		}
		return StageStatus.Unknown;
	}

	public bool IsRoundI()
	{
		DateTimeOffset serverNow = DateTimeHelper.ServerNow;
		return serverNow > RoundIDuration[0] && serverNow < RoundIDuration[1];
	}

	public bool IsRoundII()
	{
		DateTimeOffset serverNow = DateTimeHelper.ServerNow;
		return serverNow > RoundIIDuration[0] && serverNow < RoundIIDuration[1];
	}

	public void UpdateAllServersChampionshipClaimed(List<int> claimed)
	{
		Claimed = claimed;
	}

	public WarRankData GetPlayerRankDataForCurrentStagePhase(int userId)
	{
		if (WarRankDataInfo?.WarRankDatas != null)
		{
			foreach (WarRankData warRankData in WarRankDataInfo.WarRankDatas)
			{
				if (warRankData.UserId == userId)
				{
					return warRankData;
				}
			}
		}
		return null;
	}

	public bool IsStageInPrepare(StageStatus status, int timestamp)
	{
		StageInfo stageInfo = GetStageInfo(status);
		return timestamp >= stageInfo.BeginTime && timestamp < stageInfo.SettleTime;
	}

	public bool IsStageInBattle(StageStatus status, int timestamp)
	{
		StageInfo stageInfo = GetStageInfo(status);
		return timestamp >= stageInfo.SettleTime && timestamp < stageInfo.DisplayTime;
	}

	public bool IsStageSettled(StageStatus status, int timestamp)
	{
		StageInfo stageInfo = GetStageInfo(status);
		return timestamp >= stageInfo.DisplayTime;
	}

	public void UpdateMissionProgress(List<WarOfRealmPacket> missionProgressList)
	{
		int num = 0;
		int num2 = 0;
		foreach (WarOfRealmPacket missionProgress in missionProgressList)
		{
			if (!MissionProgressDict.TryGetValue(missionProgress.MissionType, out var value))
			{
				value = 0;
			}
			int currentValue = missionProgress.CurrentValue;
			MissionProgressDict[missionProgress.MissionType] = currentValue;
			for (int i = 0; i < Missions.Count; i++)
			{
				WarOfRealmMission warOfRealmMission = Missions[i];
				if (warOfRealmMission.Type == missionProgress.MissionType && warOfRealmMission.TargetValue > value && warOfRealmMission.TargetValue <= currentValue)
				{
					num += warOfRealmMission.Score;
					num2 += warOfRealmMission.LotteryCoin;
				}
			}
		}
		if (num > 0)
		{
			Score += num;
		}
		if (num2 > 0)
		{
			GameManagers.Instance.StockController.ReadStockChangeRecords(new StockChangeRecord[1]
			{
				new StockChangeRecord
				{
					ItemId = RankDataHelper.AllServerChampionshipBetCoin,
					Offset = num2,
					Type = 1,
					Context = 56
				}
			});
		}
	}
}
