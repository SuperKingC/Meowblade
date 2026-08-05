using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Announcement;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode3RoomOperationDiabledResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(2)]
	public string ServerStatusMessage { get; set; }

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Protocol.Announcement.GvGAnnouncement")]
	public List<GvGAnnouncement> GvGAnnouncements { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE3_ROOM_OPERATION_DISABLED;
}
