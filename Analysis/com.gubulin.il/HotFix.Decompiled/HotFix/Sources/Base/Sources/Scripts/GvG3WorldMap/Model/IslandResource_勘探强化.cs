using System.Collections.Generic;
using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

[ProtoContract]
public class IslandResource_勘探强化
{
	[ProtoMember(1)]
	public int IslandId;

	[ProtoMember(2)]
	public int EndTimestamp;

	[ProtoMember(3)]
	public List<string> Items;
}
