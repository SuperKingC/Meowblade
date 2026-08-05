using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.InstanceZoneModels;

[ProtoContract]
public class CampMissionConfig
{
	[ProtoMember(1)]
	public string Id { get; set; }
}
