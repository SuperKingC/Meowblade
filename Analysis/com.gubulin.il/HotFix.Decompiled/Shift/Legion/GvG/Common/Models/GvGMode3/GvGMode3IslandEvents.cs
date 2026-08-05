using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class GvGMode3IslandEvents
{
	[ProtoMember(1)]
	public int IslandId;

	[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.IslandEventInfo")]
	public List<IslandEventInfo> EventList;
}
