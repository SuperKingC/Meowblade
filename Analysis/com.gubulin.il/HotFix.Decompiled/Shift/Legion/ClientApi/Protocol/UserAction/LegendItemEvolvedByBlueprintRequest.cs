using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class LegendItemEvolvedByBlueprintRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string BluePrintId { get; set; }

	[ProtoMember(2)]
	public string MainId { get; set; }

	[ProtoMember(3)]
	public List<string> RandomIds { get; set; }

	[ProtoMember(4)]
	public List<string> AnyIds { get; set; }

	[ProtoMember(5, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> UniversalLegendItem { get; set; }

	public int PacketId => PacketIds.USER_ACTION_LEGENDITEM_EVOLVED_BY_BLUEPRINT;
}
