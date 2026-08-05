using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

[ProtoContract]
public class OEMGiverBonus
{
	[ProtoMember(1)]
	public bool isCritical;

	[ProtoMember(2)]
	public bool isTiTan;

	[ProtoMember(3, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.ForgedExtraAmplifier")]
	public List<ForgedExtraAmplifier> Amps;
}
