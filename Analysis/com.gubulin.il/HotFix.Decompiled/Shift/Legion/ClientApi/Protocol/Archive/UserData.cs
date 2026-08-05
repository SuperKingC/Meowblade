using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Archive;

[ProtoContract]
public class UserData
{
	public const int TypeItem = 1;

	public const int TypeSoldier = 1;

	public const int TypeTechnology = 1;

	public const int TypeSimplePool = 4;

	[ProtoMember(1)]
	public string Key { get; set; }

	[ProtoMember(2)]
	public int Type { get; set; }

	[ProtoMember(3)]
	public int Version { get; set; }

	[ProtoMember(4)]
	public string Data { get; set; }

	public object Clone()
	{
		return MemberwiseClone();
	}
}
