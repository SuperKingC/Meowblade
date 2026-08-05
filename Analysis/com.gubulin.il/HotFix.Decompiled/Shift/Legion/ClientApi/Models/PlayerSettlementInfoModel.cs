using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class PlayerSettlementInfoModel
{
	[ProtoMember(1)]
	public int FinalRank { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> RItems { get; set; }
}
