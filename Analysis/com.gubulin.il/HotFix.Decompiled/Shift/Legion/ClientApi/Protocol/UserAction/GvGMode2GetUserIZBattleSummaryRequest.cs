using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode2GetUserIZBattleSummaryRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int[] IZIds { get; set; }

	[ProtoMember(2)]
	public int test_userId { get; set; } = -1;

	public int PacketId => PacketIds.USER_ACTION_GVGMODE2_GET_USER_IZ_BATTLE_SUMMARY;
}
