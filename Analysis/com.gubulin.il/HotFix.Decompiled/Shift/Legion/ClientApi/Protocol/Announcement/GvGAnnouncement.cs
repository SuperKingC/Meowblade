using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Announcement;

[ProtoContract]
public class GvGAnnouncement
{
	[ProtoMember(1)]
	public int Id;

	[ProtoMember(2)]
	public string Content;

	[ProtoMember(3)]
	public int Type;

	[ProtoMember(4)]
	public int From;
}
