using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGRoomOperationResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3)]
	public string JsonResult { get; set; }

	[ProtoMember(4)]
	public string ServerStatusMessage { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_ROOM_OPERATION;
}
