using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class GetCurrentPvPRankGameResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(3)]
	public PvPRankGame CurrentPvPRankGame;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_CURRENT_PVP_RANK_GAME_REQUEST;
}
