using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace Shift.Legion.ClientApi.Sources.Protocol.UserAction;

[ProtoContract]
public class GetDynamicStarKeyStoreResponse : IPacketBody
{
	[ProtoMember(6, TypeName = "Shift.Legion.ClientApi.Sources.Protocol.UserAction.JsonActivityData")]
	public List<JsonActivityData> JsonActivityDatas { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_ACTIVITY_STARKEYSSTORE_REQUEST;
}
