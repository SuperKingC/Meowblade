using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetGvGMode3ProcessByIZConfigIdRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string IZConfigId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_GET_PROCESS_BY_IZCONFIGID;
}
