using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class IslandBuff
{
	[ProtoMember(1, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Ability")]
	public Ability Ability;

	[ProtoMember(2)]
	public List<int> AffectedCampId;

	[ProtoMember(3)]
	public List<int> AffectedCampIdConfig;

	[ProtoMember(4)]
	public int FromIslandId;

	public int IslandBuffConfigId;
}
