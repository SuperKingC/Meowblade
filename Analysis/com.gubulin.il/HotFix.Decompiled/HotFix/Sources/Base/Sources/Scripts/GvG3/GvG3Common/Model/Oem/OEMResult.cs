using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;

[ProtoContract]
public class OEMResult
{
	[ProtoMember(1, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.ForgedExtraAmplifier")]
	public List<ForgedExtraAmplifier> AmpsList = new List<ForgedExtraAmplifier>();

	[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.ForgedExtraItem")]
	public List<ForgedExtraItem> ItemsList = new List<ForgedExtraItem>();

	public int TotalCount => AmpsList.Count + ItemsList.Count;
}
