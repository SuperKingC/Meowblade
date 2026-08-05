using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetGvGMedalRankResponse : IPacketBody
{
	[ProtoMember(1)]
	public int Rank { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMEDALRANK_REQUEST;

	public int DisplayRank => Rank + 1;
}
