using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class WarGroupLottery
{
	[ProtoMember(1)]
	public int GroupIndex { get; set; }

	[ProtoMember(2)]
	public List<WarLottery> WarLotteries { get; set; }

	[ProtoMember(3)]
	public List<int> WinUserId { get; set; }
}
