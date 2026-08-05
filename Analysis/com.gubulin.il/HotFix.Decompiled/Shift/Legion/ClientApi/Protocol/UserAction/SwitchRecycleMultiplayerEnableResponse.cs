using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SwitchRecycleMultiplayerEnableResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(4)]
	public bool Enable;

	public int PacketId => PacketIds.USER_ACTION_SWITCH_RECYCLE_ENABLE;
}
