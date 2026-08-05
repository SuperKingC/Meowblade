using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SetAsNewGuideModeRequest : IRequestPacket, IPacketBody
{
	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public string GuideMode { get; set; }

	[ProtoMember(2)]
	public string StoryNodeConfigVersion { get; set; }

	public int PacketId => PacketIds.USER_ACTION_SET_AS_NEW_GUIDE_MODE_REQUEST;
}
