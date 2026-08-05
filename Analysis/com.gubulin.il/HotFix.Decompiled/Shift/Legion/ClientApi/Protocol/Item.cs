using System;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class Item : ICloneable
{
	public const int TypeItem = 1;

	public const int TypeSoldier = 1;

	public const int TypeTechnology = 1;

	public const int TypeSimplePool = 4;

	[ProtoMember(1)]
	public int Id { get; set; }

	[ProtoMember(2)]
	public int Type { get; set; }

	[ProtoMember(3)]
	public int Qty { get; set; }

	public object Clone()
	{
		return MemberwiseClone();
	}
}
