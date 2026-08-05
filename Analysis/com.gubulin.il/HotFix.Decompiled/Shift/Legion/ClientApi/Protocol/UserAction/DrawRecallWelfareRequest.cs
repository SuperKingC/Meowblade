using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class DrawRecallWelfareRequest : IPacketBody, IRequestPacket
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public List<int> Indexs { get; set; }

	public int PacketId => PacketIds.USER_ACTION_DRAW_RECALLWELFARE_REQUEST;
}
