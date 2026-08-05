using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class MissionStateRecordWithProgress
{
	[ProtoMember(1)]
	public string MissionConfigId { get; set; }

	[ProtoMember(2)]
	public int MUID { get; set; }

	[ProtoMember(3)]
	public int MState { get; set; }

	[ProtoMember(5)]
	public List<long> ProgressValue { get; set; }

	[ProtoMember(6)]
	public bool HasClaimed { get; set; }

	[ProtoMember(7)]
	public long ExpiredTimestamp_ms { get; set; }
}
