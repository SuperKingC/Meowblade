using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class UseGVGStoreFormulaRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string FormulaId { get; set; }

	[ProtoMember(2)]
	public int InputIndex { get; set; }

	[ProtoMember(3)]
	public int OutputIndex { get; set; }

	[ProtoMember(4)]
	public int StoreItemIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_GVG_STORE_USE_FORMULA;
}
