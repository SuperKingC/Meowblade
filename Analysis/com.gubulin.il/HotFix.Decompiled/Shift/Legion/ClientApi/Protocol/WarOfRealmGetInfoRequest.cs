using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmGetInfoRequest : IRequestPacket, IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_WAROFREALM_GETINFO_REQUEST;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }
}
