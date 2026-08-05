using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvGServer.Models.Map;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGGetIZInfosResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.Map.InstanceZone_Protocol")]
	public List<InstanceZone_Protocol> IZInfos { get; set; }

	[ProtoMember(3)]
	public string CustomizeTables { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVG_GET_IZ_INFOS;
}
