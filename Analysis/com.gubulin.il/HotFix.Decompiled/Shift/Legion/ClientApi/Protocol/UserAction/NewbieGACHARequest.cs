using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class NewbieGACHARequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public string ActivityId;

	[ProtoMember(2)]
	public int NextProgress;

	[ProtoMember(3)]
	public int Select = -1;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_NEWBIE_GACHA_REQUEST;
}
