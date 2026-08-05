using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmGetScoreHistoryRequest : IRequestPacket, IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_WAROFREALM_GET_SCOREHISTORY;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }
}
