using ProtoBuf;
using UnityEngine;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class DailySuppressBonusTimesPerZone
{
	[ProtoMember(1)]
	public string ZoneId { get; set; }

	[ProtoMember(2)]
	public int DailySuppressBonusTimes { get; set; }

	[ProtoMember(3)]
	public int DailySuppressBonusTimesLimit { get; set; }

	public int GetRemainCount()
	{
		int dailySuppressBonusTimesLimit = DailySuppressBonusTimesLimit;
		return Mathf.Max(dailySuppressBonusTimesLimit - DailySuppressBonusTimes, 0);
	}
}
