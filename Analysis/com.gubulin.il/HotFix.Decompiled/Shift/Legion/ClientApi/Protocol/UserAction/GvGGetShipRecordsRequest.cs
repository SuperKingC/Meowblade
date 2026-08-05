using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGGetShipRecordsRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string IZConfigId { get; set; }

	[ProtoMember(2)]
	public string IZId { get; set; }

	[ProtoMember(3)]
	public int Idx { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_GET_SHIP_RECORDS;
}
