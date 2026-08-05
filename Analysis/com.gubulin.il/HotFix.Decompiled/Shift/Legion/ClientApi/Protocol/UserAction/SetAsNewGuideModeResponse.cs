using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SetAsNewGuideModeResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string NewGuideMode;

	[ProtoMember(3)]
	public List<string> UndergoingStories;

	[ProtoMember(4)]
	public string FirstMission;

	[ProtoMember(5)]
	public string StoryNodeConfigVersion;

	[ProtoMember(6)]
	public string CurrentLevelId;

	public string Message;

	public int PacketId => PacketIds.USER_ACTION_SET_AS_NEW_GUIDE_MODE_REQUEST;
}
