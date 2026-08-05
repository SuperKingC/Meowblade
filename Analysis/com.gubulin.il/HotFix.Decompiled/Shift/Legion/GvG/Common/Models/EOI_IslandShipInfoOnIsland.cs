using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models;

[ProtoContract]
public class EOI_IslandShipInfoOnIsland
{
	[ProtoMember(1)]
	public int IslandId;

	[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.EOI_ShipInfoOnIsland")]
	public List<EOI_ShipInfoOnIsland> IslandCapmShips;

	[ProtoMember(3)]
	public List<(int CampId, int UserCount)> CampShipCount;
}
