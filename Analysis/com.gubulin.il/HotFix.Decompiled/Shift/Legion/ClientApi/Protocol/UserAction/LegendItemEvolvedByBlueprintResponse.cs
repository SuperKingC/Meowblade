using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class LegendItemEvolvedByBlueprintResponse : IPacketBody
{
	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(1)]
	public bool CanEvolved { get; set; }

	[ProtoMember(2)]
	public byte[] ExtraData { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_LEGENDITEM_EVOLVED_BY_BLUEPRINT;
}
