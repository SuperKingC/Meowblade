using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3GetBattlePassDataResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(2)]
	public float ContributionPoints { get; set; }

	[ProtoMember(3)]
	public bool HasAdvancedPass { get; set; }

	[ProtoMember(4)]
	public bool HasPremiumPass { get; set; }

	[ProtoMember(5)]
	public int BattlePassVersion { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_GET_BATTLE_PASS_DATA;
}
