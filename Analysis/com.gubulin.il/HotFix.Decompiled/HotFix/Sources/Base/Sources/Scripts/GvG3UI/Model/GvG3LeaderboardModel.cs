using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvG3LeaderboardModel
{
	public static GvG3LeaderboardModel Instance = new GvG3LeaderboardModel();

	public int NextUpdateTimestamp = 0;

	private Dictionary<string, GvGMode3LeaderboardData> Leaderboard_Dict;

	private bool IsGettingGSData = false;

	public bool IsDoubleChecked;

	public string IZConfigId;

	public bool IsAllRankingFinalized => NextUpdateTimestamp == -1;

	public GvG3LeaderboardModel()
	{
		Leaderboard_Dict = new Dictionary<string, GvGMode3LeaderboardData>();
	}

	public void GetData(eLeaderboardType _LBType, eLeaderboardSubType _subType, Action<GvGMode3LeaderboardData> onFinished = null)
	{
		string typeStr = $"{_LBType}";
		if (_LBType == eLeaderboardType.BOSS输出榜_全副本)
		{
			typeStr += $"_{_subType}";
		}
		if (Leaderboard_Dict.TryGetValue(typeStr, out var value))
		{
			onFinished?.Invoke(value);
		}
		else
		{
			if (IsGettingGSData)
			{
				return;
			}
			if (Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement)
			{
				IsGettingGSData = true;
				GetGSData(delegate(SkyIslandSettlementModel model)
				{
					SkyIslandPlayerSettlementModel playerSettlement = Singleton<GvGMode3RoomManager>.Instance.PlayerSettlement;
					int campId = playerSettlement.CampId;
					List<KeyValuePair<eLeaderboardType, SettlementRankData>> list = new List<KeyValuePair<eLeaderboardType, SettlementRankData>>();
					list.AddRange(playerSettlement.selfRankDatas);
					list.AddRange(playerSettlement.selfFinalProgressRankDatas);
					foreach (KeyValuePair<eLeaderboardType, SettlementRankData> item in list)
					{
						eLeaderboardType key = item.Key;
						string text = $"{key}";
						SettlementRankData value2 = item.Value;
						if (key == eLeaderboardType.BOSS输出榜_全副本)
						{
							Leaderboard_Dict.Add($"{key}_{eLeaderboardSubType.Today}", null);
							text += $"_{eLeaderboardSubType.Total}";
						}
						GvGMode3LeaderboardData gvGMode3LeaderboardData = new GvGMode3LeaderboardData
						{
							IsBonusClaimed = value2.HasClaimed,
							MyRankData = value2.Data,
							MyRanking = value2.Rank
						};
						using (Dictionary<string, int>.KeyCollection.Enumerator enumerator2 = value2.Reward.Keys.GetEnumerator())
						{
							if (enumerator2.MoveNext())
							{
								string current2 = enumerator2.Current;
								gvGMode3LeaderboardData.BonusItemId = current2;
							}
						}
						Leaderboard_Dict.Add(text, gvGMode3LeaderboardData);
					}
					IsDoubleChecked = model.IsDoubleChecked;
					IZConfigId = model.IZConfigId;
					Leaderboard_Dict[$"{eLeaderboardType.远征总贡献榜_阵营}"].RankList = model.campTotal[campId];
					Leaderboard_Dict[$"{eLeaderboardType.战斗贡献榜_全副本}"].RankList = model.Fighting;
					Leaderboard_Dict[$"{eLeaderboardType.采集贡献榜_全副本}"].RankList = model.Collecting;
					Leaderboard_Dict[$"{eLeaderboardType.制造贡献榜_全副本}"].RankList = model.ForgeAmplifier;
					if (!WorldMapConfigHelper.IsBrawlFightEvent(IZConfigId))
					{
						Leaderboard_Dict[$"{eLeaderboardType.BOSS输出榜_全副本}_{eLeaderboardSubType.Total}"].RankList = model.BossDamageRankIZTotal;
						Leaderboard_Dict[$"{eLeaderboardType.阴影之石捐献榜_全副本}"].RankList = model.ShadowEnergy;
						Leaderboard_Dict[$"{eLeaderboardType.BOSS单日最高输出榜_全副本}"].RankList = model.BossDailyDamageRankIZTotal;
					}
					else
					{
						Leaderboard_Dict[$"{eLeaderboardType.乱斗永夜个人积分榜}"].RankList = model.BrawlEventPlayerScoreRankIZTotal;
						Leaderboard_Dict[$"{eLeaderboardType.乱斗永夜个人获胜榜}"].RankList = model.BrawlEventPlayerWinRankIZTotal;
					}
					foreach (GvGMode3LeaderboardData value4 in Leaderboard_Dict.Values)
					{
						if (value4 != null)
						{
							if (value4.RankList != null)
							{
								value4.ListMaxCount = value4.RankList.Count;
							}
							else
							{
								value4.ListMaxCount = 5;
							}
						}
					}
					if (Leaderboard_Dict.TryGetValue(typeStr, out var value3))
					{
						onFinished?.Invoke(value3);
					}
					else
					{
						ILRuntimeDebug.LogError("[GvG3LeaderboardModel] typeStr = " + typeStr + " 排行榜类型不存在");
					}
				});
			}
			else
			{
				Leaderboard_Dict.Add(typeStr, new GvGMode3LeaderboardData());
				GetGvGData(_LBType, _subType, delegate(GvGMode3LeaderboardData newData)
				{
					Leaderboard_Dict[typeStr] = newData;
					onFinished?.Invoke(newData);
				});
			}
		}
	}

	private void GetGvGData(eLeaderboardType _LBType, eLeaderboardSubType _subType, Action<GvGMode3LeaderboardData> onFinished)
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetGvGMode3Leaderboard
		{
			Req = new C2S_GetGvGMode3Leaderboard.Request
			{
				LeaderboardType = (int)_LBType,
				LeaderboardSubType = (int)_subType
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetGvGMode3Leaderboard.Response response = (C2S_GetGvGMode3Leaderboard.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke(new GvGMode3LeaderboardData());
			}
			else
			{
				GvGMode3LeaderboardData leaderboardData = response.LeaderboardData;
				if (leaderboardData.RankList == null)
				{
					leaderboardData.RankList = new List<GvGMode3PlayerRankInfo>();
				}
				if (Singleton<GvGMode3RoomManager>.Instance.IsIZInSettlement || Singleton<WorldStateManager>.Instance.Data.ProgressData.HasSettlement)
				{
					NextUpdateTimestamp = -1;
				}
				else
				{
					NextUpdateTimestamp = response.NextUpdateTimestamp;
				}
				onFinished?.Invoke(leaderboardData);
			}
		});
	}

	private void GetGSData(Action<SkyIslandSettlementModel> onFinished)
	{
		ILRequestHelper<GvGMode3GetIZSettlementRecordResponse>.Request((EventContext)null, (Func<Task<GvGMode3GetIZSettlementRecordResponse>>)(() => GameController.Contexts.Service<INetworkService>().GvGMode3GetIZSettlementRecord(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.LastIZId)), (Action<GvGMode3GetIZSettlementRecordResponse>)delegate(GvGMode3GetIZSettlementRecordResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
				onFinished?.Invoke(new SkyIslandSettlementModel());
			}
			else
			{
				NextUpdateTimestamp = -1;
				SkyIslandSettlementModel obj = JsonHelper.ToObject<SkyIslandSettlementModel>(response.jsonIZrSettlement);
				onFinished?.Invoke(obj);
			}
		});
	}

	public void ClearCache()
	{
		Leaderboard_Dict.Clear();
	}
}
