using System.Collections.Generic;
using ProtoBuf;

namespace GvG2.Common.Models;

[ProtoContract]
public class IslandCampSummary
{
	[ProtoMember(1)]
	public int CampId;

	[ProtoMember(2)]
	public List<int> UserIds;

	[ProtoMember(3)]
	public int HoldingPercent;
}
