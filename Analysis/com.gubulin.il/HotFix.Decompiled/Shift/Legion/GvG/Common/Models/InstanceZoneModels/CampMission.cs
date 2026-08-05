using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.InstanceZoneModels;

[ProtoContract]
public class CampMission
{
	[ProtoMember(1)]
	public string Id { get; set; }

	[ProtoMember(3)]
	public int State { get; set; }

	[ProtoMember(4)]
	public string MissionConfigId { get; set; }

	[ProtoMember(5)]
	public int PickedTimestamp { get; set; }

	public bool CanPickUp()
	{
		if (State == 1)
		{
			return true;
		}
		return false;
	}
}
