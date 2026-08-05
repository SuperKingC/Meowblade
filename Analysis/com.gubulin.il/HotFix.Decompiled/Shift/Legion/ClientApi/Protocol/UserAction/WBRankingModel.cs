using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class WBRankingModel
{
	[ProtoMember(1)]
	public int LastRefreshTimestamp { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.RankModel")]
	public List<RankModel> RankModels { get; set; }
}
