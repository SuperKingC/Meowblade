using System;
using System.Collections.Generic;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.Common.Models;

public class LotteryPendingResult
{
	public string From;

	public DateTimeOffset CreatedAt;

	public int TotalPick;

	public List<BonusConfig> BonusList;

	public Shift.Legion.ClientApi.Models.LotteryPendingResult ToProto()
	{
		Shift.Legion.ClientApi.Models.LotteryPendingResult lotteryPendingResult = new Shift.Legion.ClientApi.Models.LotteryPendingResult
		{
			From = From,
			CreatedAt = CreatedAt,
			TotalPick = TotalPick,
			BonusList = new List<ModelsBonus>()
		};
		foreach (BonusConfig bonus in BonusList)
		{
			lotteryPendingResult.BonusList.Add(new ModelsBonus
			{
				ItemId = bonus.ItemId,
				Qty = bonus.Qty,
				Type = bonus.Type,
				IsShining = bonus.IsShining
			});
		}
		return lotteryPendingResult;
	}
}
