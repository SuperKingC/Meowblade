using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models.LegendItemBlueprint;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class LegendItemBlueprintGetResponse : IPacketBody
{
	[ProtoMember(99)]
	public bool Result { get; set; }

	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Models.LegendItemBlueprint.Blueprint")]
	public List<Blueprint> Blueprints { get; set; } = new List<Blueprint>();

	[ProtoMember(2)]
	public bool DisplayBlueprintsUi { get; set; }

	[ProtoMember(3)]
	public List<string> LockedBlueprints { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_LEGENDITEMBLUEPRINT_GET;
}
