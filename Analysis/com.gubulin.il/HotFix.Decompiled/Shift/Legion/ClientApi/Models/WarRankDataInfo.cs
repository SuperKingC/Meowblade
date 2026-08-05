using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class WarRankDataInfo
{
	[ProtoMember(1)]
	public int StageStatus { get; set; }

	[ProtoMember(2)]
	public int Week { get; set; }

	[ProtoMember(3)]
	public int Day { get; set; }

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Models.WarRankData")]
	public List<WarRankData> WarRankDatas { get; set; }
}
