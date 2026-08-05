using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Store;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetMissionActivityStoreItemsResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(5, TypeName = "Shift.Legion.ClientApi.Protocol.Store.StoreItemList")]
	[ProtoMap]
	public List<StoreItemList> StoreItemsDict;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_MISSION_ACTIVITY_STORE_ITEMS_REQUEST;

	public void UsedOnlyForAOTCodeGeneration()
	{
		new Dictionary<int, StoreItem[]>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
