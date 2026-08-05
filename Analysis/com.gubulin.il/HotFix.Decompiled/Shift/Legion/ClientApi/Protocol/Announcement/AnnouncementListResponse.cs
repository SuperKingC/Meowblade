using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Announcement;

[ProtoContract]
public class AnnouncementListResponse : IPacketBody
{
	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.Announcement.Announcement")]
	public List<Announcement> List;

	public int PacketId => PacketIds.ANNOUNCEMENT_LIST_REQUEST;

	public void UsedOnlyForAOTCodeGeneration()
	{
		new List<Announcement>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
