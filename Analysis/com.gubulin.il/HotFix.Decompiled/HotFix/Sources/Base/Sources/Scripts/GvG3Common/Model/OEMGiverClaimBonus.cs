using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

[ProtoContract]
public class OEMGiverClaimBonus
{
	[ProtoMember(1, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.ForgedExtraAmplifier")]
	public List<ForgedExtraAmplifier> Amps = new List<ForgedExtraAmplifier>();

	[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> ReturnCost_ToProtocol;
}
