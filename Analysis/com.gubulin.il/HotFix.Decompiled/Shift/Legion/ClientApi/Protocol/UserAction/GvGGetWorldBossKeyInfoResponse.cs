using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvGServer.Models.Map;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGGetWorldBossKeyInfoResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.Map.WBKeyInfo")]
	public List<WBKeyInfo> Infos { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_GET_WORLDBOSS_KEYINFO;
}
