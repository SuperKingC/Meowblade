using System;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BrawlUi;

public class BrawlClaimedUiInfo : IBrawlClaimedUiInfo
{
	public int DayIndex { get; private set; }

	public string Date { get; }

	public int ClaimedStatus { get; private set; }

	public int IsGenerated { get; private set; }

	public BrawlClaimedUiInfo(BrawlEventSettleClaimedInfo info, int maxCanRecord, DateTimeOffset begin)
	{
		DayIndex = info.Day;
		IsGenerated = ((info.Day <= maxCanRecord) ? 1 : 0);
		Date = $"{begin.AddDays(info.Day).ToLocalTime(): MM/dd}";
		ClaimedStatus = InitClaimedStatus(info, maxCanRecord);
	}

	public void SetClaimed()
	{
		ClaimedStatus = 1;
	}

	private static int InitClaimedStatus(BrawlEventSettleClaimedInfo info, int maxCanRecord)
	{
		if (info.IsClaimed)
		{
			return 1;
		}
		if (info.MessageId > 0 && info.Day <= maxCanRecord)
		{
			return 0;
		}
		return 2;
	}
}
