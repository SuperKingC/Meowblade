using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyGUI;
using GameDataEditor;
using HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol.UserAction;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;

namespace UI.ReturningRewards;

public class RecallWelfareWrapper
{
	private class PrizeGroupInfo
	{
		public int Count { get; set; }

		public RecallWelfarePrize FirstItem { get; }

		public PrizeGroupInfo(RecallWelfarePrize initialItem)
		{
			FirstItem = initialItem;
			Count = 1;
		}
	}

	public const int DAY_SECONDS = 86400;

	private const string SCORE_KEY = "Score";

	private GetRecallWelfareResponse _response;

	public Action<int> OnTotalScoreChanged = delegate
	{
	};

	public async Task<GetRecallWelfareResponse> GetRecallWelfare()
	{
		if (_response != null)
		{
			return _response;
		}
		GetRecallWelfareResponse res = await GameController.Contexts.Service<INetworkService>().GetRecallWelfare();
		if (res.ErrorCode != 0)
		{
			return null;
		}
		_response = res;
		UpdateRecallWelfareClaimableRewards();
		return _response;
	}

	public void DrawRecallWelfare(List<int> ids, Action<Dictionary<int, IRecallWelfarePrize>> onDrawed = null, Action<List<StockChangeRecord>> onStockChanged = null)
	{
		ILRequestHelper<DrawRecallWelfareResponse>.Request((EventContext)null, (Func<Task<DrawRecallWelfareResponse>>)(() => GameController.Contexts.Service<INetworkService>().DrawRecallWelfare(ids)), (Action<DrawRecallWelfareResponse>)delegate(DrawRecallWelfareResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				_response.DrawRecord.AddRange(response.DrawResult);
				_response.TotalScore = response.TotalScore;
				OnTotalScoreChanged?.Invoke(response.TotalScore);
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				if (onDrawed != null)
				{
					Dictionary<int, IRecallWelfarePrize> obj = CreatePrizes(response.DrawResult);
					onDrawed(obj);
				}
				onStockChanged?.Invoke(response.StockChangeRecords);
			}
		});
	}

	public void ExchangeRecallWelfare(Action<ExchangeRecallWelfareResponse> onExchanged = null)
	{
		ILRequestHelper<ExchangeRecallWelfareResponse>.Request((EventContext)null, (Func<Task<ExchangeRecallWelfareResponse>>)(() => GameController.Contexts.Service<INetworkService>().ExchangeRecallWelfare()), (Action<ExchangeRecallWelfareResponse>)delegate(ExchangeRecallWelfareResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				_response.TotalScore = response.TotalScore;
				OnTotalScoreChanged?.Invoke(response.TotalScore);
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				_response.Money = response.Money;
				onExchanged?.Invoke(response);
			}
		});
	}

	public void UpdateRecallWelfareClaimableRewards()
	{
		CacheManager.Instance.Get<Cache_RecallWelfare_RedDot>().IsShowRedDot = _response.CompletedMission.Count > _response.ClaimedMission.Count;
	}

	public void OnPingPushItem(PushItem item)
	{
		if (_response == null || item.PacketId != PacketIds.PUSH_RECALLWELFARE_COMPLETEDMISSION)
		{
			return;
		}
		List<RecallWelfarePacket> list = JsonHelper.ToObject<List<RecallWelfarePacket>>(item.Body);
		Dictionary<eMissionType, RecallWelfarePacket> dictionary = new Dictionary<eMissionType, RecallWelfarePacket>();
		foreach (RecallWelfarePacket item2 in list)
		{
			if (!dictionary.TryGetValue(item2.MissionType, out var value) || item2.CurrentValue > value.CurrentValue)
			{
				dictionary[item2.MissionType] = item2;
			}
		}
		foreach (KeyValuePair<eMissionType, RecallWelfarePacket> item3 in dictionary)
		{
			int type = (int)item3.Key;
			RecallWelfareMissionProgress recallWelfareMissionProgress = _response.Progress.Find((RecallWelfareMissionProgress p) => p.MissionType == type);
			if (recallWelfareMissionProgress != null)
			{
				recallWelfareMissionProgress.CurrentValue = item3.Value.CurrentValue;
				continue;
			}
			_response.Progress.Add(new RecallWelfareMissionProgress
			{
				MissionType = type,
				CurrentValue = item3.Value.CurrentValue
			});
		}
		foreach (RecallWelfareMission mission in _response.Missions)
		{
			if (dictionary.TryGetValue((eMissionType)mission.Type, out var value2) && value2.CurrentValue >= mission.TargetValue && !_response.CompletedMission.Contains(mission.MissionId))
			{
				_response.CompletedMission.Add(mission.MissionId);
			}
		}
		UpdateRecallWelfareClaimableRewards();
	}

	public RecallWelfarePreviewParams CreatePreviewParams()
	{
		RecallWelfarePreviewParams recallWelfarePreviewParams = new RecallWelfarePreviewParams();
		if (_response.Prizes == null || !_response.Prizes.Any())
		{
			throw new Exception("RecallWelfareWrapper CreatePreviewParams Prizes is null or empty");
		}
		Dictionary<string, int> drawRecord = new Dictionary<string, int>();
		foreach (ERItem record in _response.DrawRecord)
		{
			string itemId = _response.Prizes.Find((RecallWelfarePrize p) => p.PrizeId == record.PrizeId).ItemId;
			if (drawRecord.ContainsKey(itemId))
			{
				drawRecord[itemId]++;
			}
			else
			{
				drawRecord[itemId] = 1;
			}
		}
		Dictionary<string, PrizeGroupInfo> dictionary = new Dictionary<string, PrizeGroupInfo>();
		foreach (RecallWelfarePrize prize in _response.Prizes)
		{
			if (!string.IsNullOrEmpty(prize.ItemId))
			{
				if (dictionary.TryGetValue(prize.ItemId, out var value))
				{
					value.Count++;
				}
				else
				{
					dictionary[prize.ItemId] = new PrizeGroupInfo(prize);
				}
			}
		}
		int value2;
		List<RecallWelfarePreviewReward> collection = dictionary.Select((KeyValuePair<string, PrizeGroupInfo> kvp) => new RecallWelfarePreviewReward(kvp.Value.FirstItem.ItemId, kvp.Value.Count - (drawRecord.TryGetValue(kvp.Value.FirstItem.ItemId, out value2) ? value2 : 0), kvp.Value.FirstItem.Qty, kvp.Value.FirstItem.Rarity)).ToList();
		recallWelfarePreviewParams.Rewards = new List<IRecallWelfarePreviewReward>(collection);
		return recallWelfarePreviewParams;
	}

	public List<IRecallWelfareMission> CreateMissions()
	{
		List<IRecallWelfareMission> list = new List<IRecallWelfareMission>();
		Dictionary<eMissionType, List<RecallWelfareMission>> dictionary = new Dictionary<eMissionType, List<RecallWelfareMission>>();
		foreach (RecallWelfareMission mission in _response.Missions)
		{
			eMissionType type = (eMissionType)mission.Type;
			if (!dictionary.ContainsKey(type))
			{
				dictionary[type] = new List<RecallWelfareMission> { mission };
			}
			else
			{
				dictionary[type].Add(mission);
			}
		}
		foreach (eMissionType key in dictionary.Keys)
		{
			int typeInt = (int)key;
			RecallWelfareMissionWrapper recallWelfareMissionWrapper = new RecallWelfareMissionWrapper(_response.Progress.Find((RecallWelfareMissionProgress p) => p.MissionType == typeInt)?.CurrentValue ?? 0, dictionary[key], _response.CompletedMission, _response.ClaimedMission);
			if (recallWelfareMissionWrapper.State != RecallWelfareMissionUiState.Hidden)
			{
				list.Add(recallWelfareMissionWrapper);
			}
		}
		return list;
	}

	public void ClaimRecallWelfareMissionReward(string missionId, Action onClaimed = null)
	{
		ILRequestHelper<ClaimRecallWelfareBonusResponse>.Request((EventContext)null, (Func<Task<ClaimRecallWelfareBonusResponse>>)(() => GameController.Contexts.Service<INetworkService>().ClaimRecallWelfareBonus(missionId)), (Action<ClaimRecallWelfareBonusResponse>)delegate(ClaimRecallWelfareBonusResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (!_response.ClaimedMission.Contains(missionId))
				{
					_response.ClaimedMission.Add(missionId);
				}
				UpdateRecallWelfareClaimableRewards();
				_response.TotalScore = response.TotalScore;
				OnTotalScoreChanged?.Invoke(response.TotalScore);
				onClaimed?.Invoke();
			}
		});
	}

	public RecallWelfareUiParams CreateRecallWelfareUiParams()
	{
		return new RecallWelfareUiParams
		{
			TotalScore = _response.TotalScore,
			EndTimestamp = _response.BeginTime + _response.ValidPeriod * 86400,
			DrawedPrizes = CreatePrizes(_response.DrawRecord),
			AllRewardsClaimed = (_response.Prizes.Count == _response.DrawRecord.Count),
			Money = _response.Money,
			PrizesCount = _response.Prizes.Count
		};
	}

	private Dictionary<int, IRecallWelfarePrize> CreatePrizes(IEnumerable<ERItem> drawRecord)
	{
		Dictionary<int, IRecallWelfarePrize> dictionary = new Dictionary<int, IRecallWelfarePrize>();
		foreach (ERItem record in drawRecord)
		{
			RecallWelfarePrizeCard value = new RecallWelfarePrizeCard(record.Index, _response.Prizes.Find((RecallWelfarePrize p) => p.PrizeId == record.PrizeId));
			dictionary[record.Index] = value;
		}
		return dictionary;
	}

	public void OrderShipSuccessEvent(List<Bonus> result, List<Bonus> bonuses)
	{
		if (_response != null)
		{
			result.AddRange(bonuses);
			int num = result.Where((Bonus b) => Shift.Legion.Common.Models.Item.ItemType(b.ItemId) == 126).Select(ReadScoreAddValue).Sum();
			_response.TotalScore += num;
			OnTotalScoreChanged?.Invoke(_response.TotalScore);
		}
		static int ReadScoreAddValue(Bonus bonus)
		{
			GDEItemData gDEItemData = GDMgr.Get<GDEItemData>(bonus.ItemId);
			Dictionary<string, object> dictionary = JsonHelper.ToObject<Dictionary<string, object>>(gDEItemData.Effect);
			object value;
			return dictionary.TryGetValue("Score", out value) ? (bonus.Qty * int.Parse(value.ToString())) : 0;
		}
	}
}
