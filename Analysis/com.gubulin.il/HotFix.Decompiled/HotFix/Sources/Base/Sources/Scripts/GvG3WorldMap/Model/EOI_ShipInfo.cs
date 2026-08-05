using ProtoBuf;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

[ProtoContract]
public class EOI_ShipInfo
{
	[ProtoMember(1)]
	public int UserId;

	[ProtoMember(2)]
	public int CampId;

	[ProtoMember(3)]
	public int ShipEntityId;

	[ProtoMember(4)]
	public int ShipRace;
}
