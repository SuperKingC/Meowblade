using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class LotteryActivityPayload : ActivityContentPayload
{
	public string LotteryOption;

	public readonly string LotteryId;

	public readonly Dictionary<string, int> InsuranceLottery;

	public readonly string Desc;

	public readonly int Repeat = 1;

	public readonly List<Dictionary<string, int>> Tickets;

	public readonly int MaxDrawCnt;

	public static Func<string, string, Task<DrawCardResponse>> SendDrawCardRequest;

	public static Func<string, string, Task<DrawDynamicCardPoolResponse>> SendDrawDynamicCardPoolRequest;

	public LotteryActivityPayload(int payloadIndex, string lotteryOption, Dictionary<string, object> data, Activity activity)
		: base(data)
	{
		ContentIndex = payloadIndex;
		Activity = activity;
		LotteryOption = lotteryOption;
		if (data.TryGetValue("Lottery", out var value))
		{
			LotteryId = value.ToString();
		}
		if (data.TryGetValue("Desc", out var value2))
		{
			Desc = value2.ToString();
		}
		if (data.TryGetValue("Repeat", out var value3))
		{
			Repeat = Convert.ToInt32(value3);
		}
		InsuranceLottery = new Dictionary<string, int>();
		if (data.TryGetValue("Insurance", out var value4))
		{
			foreach (KeyValuePair<string, int> item in JsonHelper.ToObject<Dictionary<string, int>>(JsonHelper.ToJson(value4)))
			{
				InsuranceLottery.Add(item.Key, item.Value);
			}
		}
		Tickets = new List<Dictionary<string, int>>();
		if (data.TryGetValue("Tickets", out var value5))
		{
			for (int i = 0; i < ((ArrayList)value5).Count; i++)
			{
				Tickets.Add((Dictionary<string, int>)((ArrayList)value5)[i]);
			}
		}
		if (data.TryGetValue("MaxDrawCnt", out var value6))
		{
			MaxDrawCnt = Convert.ToInt32(value6);
		}
		else
		{
			MaxDrawCnt = -1;
		}
	}

	public bool CheckTicket(GameManagers managers, List<string> ticketItems, out Dictionary<string, int> ticketConfig)
	{
		ticketConfig = null;
		if (Tickets.Count < 1)
		{
			return true;
		}
		if (ticketItems == null || ticketItems.Count < 1)
		{
			ticketConfig = FindValidTicketConfig(managers);
			return ticketConfig != null;
		}
		foreach (Dictionary<string, int> ticket in Tickets)
		{
			if (ticket.Count != ticketItems.Count || ticket.Keys.Any((string itemId) => !ticketItems.Contains(itemId)))
			{
				continue;
			}
			ticketConfig = ticket;
			foreach (KeyValuePair<string, int> item in ticket)
			{
				if (managers.StockController.GetStock(item.Key) < item.Value)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public async Task<List<KeyValuePair<Bonus, int>>> Draw(GameManagers managers, List<string> ticketItems = null, string dynamicPoolId = null)
	{
		List<KeyValuePair<Bonus, int>> result = new List<KeyValuePair<Bonus, int>>();
		if (!CheckTicket(managers, ticketItems, out var ticketConfig))
		{
			return result;
		}
		bool drawCardResponseResult;
		int drawCardResponseErrorCode;
		List<ModelsBonus> drawCardResult;
		if (!string.IsNullOrEmpty(dynamicPoolId))
		{
			DrawDynamicCardPoolResponse drawCardResponse = await SendDrawDynamicCardPoolRequest(dynamicPoolId, LotteryOption);
			drawCardResponseResult = drawCardResponse.Result;
			drawCardResponseErrorCode = drawCardResponse.ErrorCode;
			drawCardResult = drawCardResponse.DrawResult;
		}
		else
		{
			DrawCardResponse drawCardResponse2 = await SendDrawCardRequest(Activity.ActivityId, LotteryOption);
			drawCardResponseResult = drawCardResponse2.Result;
			drawCardResponseErrorCode = drawCardResponse2.ErrorCode;
			drawCardResult = drawCardResponse2.DrawResult;
		}
		if (!drawCardResponseResult)
		{
			if (drawCardResponseErrorCode == 10401001)
			{
				LanguagesManager.GetErrorMessage(drawCardResponseErrorCode).Format(10).ToTip();
			}
			else
			{
				ILRequestHelper.ShowErrorCode(drawCardResponseErrorCode);
			}
			return result;
		}
		ConsumeTickets(managers, ticketConfig);
		List<ModelsBonus> drawResult = drawCardResult;
		for (int i = 0; i < drawResult.Count; i++)
		{
			ModelsBonus bonusConf = drawResult[i];
			Bonus bonus = Bonus.Get(bonusConf.ItemId, bonusConf.Qty, bonusConf.Type, bonusConf.IsShining, bonusConf.ExtraData);
			result.Add(new KeyValuePair<Bonus, int>(bonus, bonus.IsShining));
		}
		if (drawResult.Count == 10)
		{
			bool allLevelC = true;
			int levelCCnt = 0;
			foreach (KeyValuePair<Bonus, int> item in result)
			{
				Bonus bonus2 = item.Key;
				ItemType itemType = (ItemType)Item.ItemType(bonus2.ItemId);
				if (itemType != ItemType.SoldierPiece && itemType != ItemType.SummonStone)
				{
					continue;
				}
				List<Modifier> effects = Item.Effect(managers, bonus2.ItemId);
				if (effects == null)
				{
					continue;
				}
				foreach (Modifier item2 in effects)
				{
					if (item2.PayloadDictionary.TryGetValue("PotentialLevel", out var potentialLevel) && Convert.ToInt32(potentialLevel) > 0)
					{
						allLevelC = false;
						break;
					}
					potentialLevel = null;
				}
				if (!allLevelC)
				{
					break;
				}
				levelCCnt++;
			}
			if (allLevelC && levelCCnt > 0)
			{
				StockChangeRecord[] stockChangeRecords = new StockChangeRecord[ticketConfig.Count];
				int recordIndex = 0;
				Dictionary<string, int> refundDict = new Dictionary<string, int>();
				foreach (KeyValuePair<string, int> ticketKv in ticketConfig)
				{
					string refundItemId = ticketKv.Key;
					int refundQty = ticketKv.Value;
					stockChangeRecords[recordIndex++] = new StockChangeRecord
					{
						ItemId = refundItemId,
						Offset = refundQty,
						Context = 0,
						Type = 1
					};
					if (refundDict.ContainsKey(refundItemId))
					{
						refundDict[refundItemId] += refundQty;
					}
					else
					{
						refundDict.Add(refundItemId, refundQty);
					}
				}
				managers.StockController.ReadStockChangeRecords(stockChangeRecords);
				managers.Messenger.Broadcast("CHIEFDOM_WARNING", refundDict);
			}
		}
		if (Activity.Type == ActivityType.LegendItemLottery)
		{
			SharedMessenger.messengerInstance.Broadcast("DRAW_LEGEND_ITEM", drawResult.Count);
		}
		else
		{
			managers.Messenger.Broadcast("DRAW_CARD", drawResult.Count);
		}
		return result;
	}

	private void ConsumeTickets(GameManagers managers, Dictionary<string, int> ticketConfig = null)
	{
		if (ticketConfig == null || ticketConfig.Count < 1)
		{
			return;
		}
		StockChangeRecord[] array = new StockChangeRecord[ticketConfig.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item in ticketConfig)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = -item.Value,
				Context = 6,
				ContextValue = LotteryId,
				Type = 1
			};
		}
		managers.StockController.ReadStockChangeRecords(array);
	}

	private Dictionary<string, int> FindValidTicketConfig(GameManagers managers)
	{
		for (int num = Tickets.Count - 1; num >= 0; num--)
		{
			Dictionary<string, int> dictionary = Tickets[num];
			bool flag = true;
			foreach (KeyValuePair<string, int> item in dictionary)
			{
				if (managers.StockController.GetStock(item.Key) >= item.Value)
				{
					continue;
				}
				flag = false;
				break;
			}
			if (flag)
			{
				return dictionary;
			}
		}
		return null;
	}

	public override bool HasAnyNewMsg(GameManagers managers)
	{
		if (LotteryOption != "十连抽")
		{
			return false;
		}
		Dictionary<string, int> ticketConfig;
		return CheckTicket(managers, null, out ticketConfig);
	}
}
