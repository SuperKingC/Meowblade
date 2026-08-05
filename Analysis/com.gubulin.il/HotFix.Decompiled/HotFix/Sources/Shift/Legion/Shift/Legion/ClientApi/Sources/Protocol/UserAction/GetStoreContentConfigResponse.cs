using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol.UserAction;

[ProtoContract]
public class GetStoreContentConfigResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public List<string> StoreContentConfigs { get; set; } = new List<string>();

	public int PacketId => PacketIds.USER_ACTION_GET_STORE_CONTENT_CONFIG_ACTIVITY;
}
