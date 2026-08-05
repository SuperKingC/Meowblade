using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3OnIsland.Model;

[ProtoContract]
public class BaseBrawlReplay
{
	[ProtoMember(1)]
	public long Frame { get; set; }

	[ProtoMember(2)]
	public int IdxInFrame { get; set; }

	[ProtoMember(3)]
	public int PackageId { get; set; }

	[ProtoMember(4)]
	public byte[] Data { get; set; }
}
