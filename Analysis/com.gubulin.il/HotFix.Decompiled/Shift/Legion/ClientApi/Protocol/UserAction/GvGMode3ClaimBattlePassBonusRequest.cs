using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3ClaimBattlePassBonusRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public int IZId;

	[ProtoMember(2)]
	public string ActivityId;

	[ProtoMember(3)]
	public string Node;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_CLAIM_BATTLE_PASS_BONUS;
}
