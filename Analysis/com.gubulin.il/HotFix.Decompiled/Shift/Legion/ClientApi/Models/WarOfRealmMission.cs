using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class WarOfRealmMission
{
	[ProtoMember(1)]
	public string MissionId { get; set; }

	[ProtoMember(2)]
	public eMissionType Type { get; set; }

	[ProtoMember(3)]
	public int TargetValue { get; set; }

	[ProtoMember(4)]
	public int Score { get; set; }

	[ProtoMember(5)]
	public int LotteryCoin { get; set; }
}
