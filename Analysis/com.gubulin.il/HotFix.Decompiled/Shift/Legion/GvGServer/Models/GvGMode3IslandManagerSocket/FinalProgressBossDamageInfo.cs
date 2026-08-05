using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class FinalProgressBossDamageInfo
{
	[ProtoMember(1)]
	public string ShipId { get; set; }

	[ProtoMember(2)]
	public long TotalDamage { get; set; }
}
