using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class UseGVGStoreFormulaResponse : IPacketBody
{
	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public string Blueprints { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_GVG_STORE_USE_FORMULA;
}
