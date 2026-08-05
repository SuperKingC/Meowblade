using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

[ProtoContract]
public class GvGMode3LocalIslandData
{
	[ProtoMember(1)]
	public int IZId = -1;

	[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model.GvGMode3IslandEntityInfo")]
	public GvGMode3IslandEntityInfo Info = new GvGMode3IslandEntityInfo();
}
