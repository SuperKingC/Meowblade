using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Building;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ChangeWorkshopProduceConfigResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Protocol.Building.ProduceState")]
	public ProduceState[] ProduceStates;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CHANGE_WORKSHOP_PRODUCE_CONFIG_REQUEST;
}
