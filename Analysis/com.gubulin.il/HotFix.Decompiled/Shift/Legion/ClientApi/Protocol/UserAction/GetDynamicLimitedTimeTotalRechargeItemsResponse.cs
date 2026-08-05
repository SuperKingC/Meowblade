using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetDynamicLimitedTimeTotalRechargeItemsResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(2)]
	public Dictionary<string, string> LTTR_Configs;

	[ProtoMember(3)]
	public string LTTR_Progress;

	public int PacketId => PacketIds.USER_ACTION_GET_DYNAMIC_ACTIVITY_LTTR_ITEMS_REQUEST;
}
