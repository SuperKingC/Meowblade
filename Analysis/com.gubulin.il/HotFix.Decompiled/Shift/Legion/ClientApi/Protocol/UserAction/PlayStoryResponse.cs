using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class PlayStoryResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(3)]
	public long Tick;

	[ProtoMember(4)]
	public string PlayingStoreLine;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_PLAY_STORY_REQUEST;
}
