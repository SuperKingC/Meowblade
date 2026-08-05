using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace Shift.Legion.ClientApi.Sources.Protocol.UserAction;

[ProtoContract]
public class GetDynamicStarKeyStoreExchangeKeyRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string FormulaId { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_ACTIVITY_EXCHANGEKEYS_REQUEST;
}
