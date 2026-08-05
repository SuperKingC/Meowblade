using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGGetIZInfosRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public bool NeedCustomizeTables { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_GET_IZ_INFOS;
}
