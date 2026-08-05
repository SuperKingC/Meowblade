using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;

namespace Shift.Legion.ClientApi.Sources.Protocol.UserAction;

[ProtoContract]
public class GetDynamicSecretTreasuryResponse : IPacketBody
{
	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public float TotalCharged { get; set; }

	[ProtoMember(5)]
	public int StartTime { get; set; }

	[ProtoMember(6)]
	public int EndTime { get; set; }

	[ProtoMember(7)]
	public string ImageUrl { get; set; }

	[ProtoMember(8)]
	public string Desc { get; set; }

	[ProtoMember(9, TypeName = "Shift.Legion.ClientApi.Sources.Protocol.UserAction.SecretTreasuryBonus")]
	public List<SecretTreasuryBonus> BonusConfigs { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_ACTIVITY_SECRETTREASURY_REQUEST;
}
