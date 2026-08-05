using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetFriendsApplyInfoResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.FriendsApplyProto")]
	public List<FriendsApplyProto> Data { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public string Message { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_FRIENDS_APPLY_INFO;
}
