using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3ChangeShipConfigResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(2)]
	public string json { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_CHANGE_SHIP_CONFIG;
}
