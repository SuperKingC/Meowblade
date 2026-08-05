using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class CheckCanQuickBattleResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public long Tick;

	[ProtoMember(3)]
	public string Message;

	public int PacketId => PacketIds.USER_ACTION_GET_CHECK_CAN_QUICK_BATTLE_REQUEST;
}
