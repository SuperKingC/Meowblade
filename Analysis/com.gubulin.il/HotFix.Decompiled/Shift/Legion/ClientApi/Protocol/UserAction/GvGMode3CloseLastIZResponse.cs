using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3CloseLastIZResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(2)]
	public string jsonGvGMode3Record { get; set; }

	[ProtoMember(3)]
	public List<string> ClearPurchaseStat { get; set; }

	[ProtoMember(4)]
	public string JsonSoldierReturns { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_CLOSE_LASTIZ;
}
