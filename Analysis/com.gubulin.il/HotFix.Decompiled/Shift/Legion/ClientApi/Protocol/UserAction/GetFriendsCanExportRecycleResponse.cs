using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetFriendsCanExportRecycleResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Protocol.UserInfo")]
	public List<UserInfo> Friends;

	public int PacketId => PacketIds.USER_ACTION_GET_FRIENDS_CAN_EXPORT_RECYCLE;

	public void UsedOnlyForAOTCodeGeneration()
	{
		new List<UserInfo>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
