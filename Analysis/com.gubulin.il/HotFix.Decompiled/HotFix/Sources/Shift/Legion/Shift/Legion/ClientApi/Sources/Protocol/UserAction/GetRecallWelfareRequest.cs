using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol.UserAction;

[ProtoContract]
public class GetRecallWelfareRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_RECALLWELFARE_REQUEST;
}
