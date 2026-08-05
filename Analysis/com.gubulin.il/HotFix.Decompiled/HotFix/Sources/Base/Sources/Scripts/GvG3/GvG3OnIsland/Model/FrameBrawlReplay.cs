using System.Collections.Generic;
using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3OnIsland.Model;

[ProtoContract]
public class FrameBrawlReplay
{
	[ProtoMember(1)]
	public int Second = 0;

	[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3OnIsland.Model.BaseBrawlReplay")]
	public List<BaseBrawlReplay> Info = new List<BaseBrawlReplay>();
}
