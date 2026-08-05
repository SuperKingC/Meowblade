using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class WarGroupLotterySettlement
{
	[ProtoMember(1)]
	public int GroupIndex { get; set; }

	[ProtoMember(2)]
	public List<int> WinUserIds { get; set; }

	[ProtoMember(3)]
	public List<int> LossUserIds { get; set; }

	[ProtoMember(4)]
	public int WinTokenCnt { get; set; }

	public int TotalLotteryCnt
	{
		get
		{
			int num = 0;
			if (WinUserIds != null)
			{
				num = WinUserIds.Count;
			}
			if (LossUserIds != null)
			{
				num += LossUserIds.Count;
			}
			return num;
		}
	}

	public int TotalWinCnt => WinUserIds?.Count ?? 0;
}
