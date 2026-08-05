using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Announcement;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGRoomOperationDisabledResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2)]
	public string ServerStatusMessage { get; set; }

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Protocol.Announcement.GvGAnnouncement")]
	public List<GvGAnnouncement> GvGAnnouncements { get; set; } = new List<GvGAnnouncement>();

	public int PacketId => PacketIds.USER_ACTION_GVG_ROOM_OPERATION_DISABLED;
}
