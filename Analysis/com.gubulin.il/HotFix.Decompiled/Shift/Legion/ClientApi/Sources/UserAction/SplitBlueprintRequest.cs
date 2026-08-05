using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace Shift.Legion.ClientApi.Sources.UserAction;

[ProtoContract]
public class SplitBlueprintRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string BlueprintId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SPLITBLUEPRINT_REQUEST;
}
