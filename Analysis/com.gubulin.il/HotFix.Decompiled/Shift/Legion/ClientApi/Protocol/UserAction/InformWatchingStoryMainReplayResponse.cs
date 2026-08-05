using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class InformWatchingStoryMainReplayResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public int PacketId => PacketIds.USER_ACTION_INFORM_WATCHING_STORY_MAIN_REPLAY;
}
