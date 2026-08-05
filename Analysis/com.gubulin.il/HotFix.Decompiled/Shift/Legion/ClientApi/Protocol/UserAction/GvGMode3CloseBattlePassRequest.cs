using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3CloseBattlePassRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public int IZId;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_CLOSE_BATTLE_PASS;
}
