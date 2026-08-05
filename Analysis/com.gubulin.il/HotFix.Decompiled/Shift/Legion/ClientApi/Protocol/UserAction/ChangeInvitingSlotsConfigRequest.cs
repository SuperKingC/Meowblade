using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ChangeInvitingSlotsConfigRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(1)]
	public Dictionary<int, Tuple<int, string, int>> InvitingSlotsConfig;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CHANGE_INVITING_SLOTS_CONFIG;
}
