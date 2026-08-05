using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.IslandManagerSocket;

[ProtoContract]
public class C2S_GetEOIEntitiesInfo
{
	[ProtoMember(1)]
	public int UserId;

	[ProtoMember(2)]
	public int CampId;

	[ProtoMember(3)]
	public List<int> ShipEntities;
}
