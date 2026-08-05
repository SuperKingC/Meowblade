using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

[ProtoContract]
public class GvGMode3LocalIslandVersions
{
	[ProtoMember(1)]
	public int IZId = -1;

	[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.IslandDataVersionModel")]
	public List<IslandDataVersionModel> IslandVesionsList = new List<IslandDataVersionModel>();
}
