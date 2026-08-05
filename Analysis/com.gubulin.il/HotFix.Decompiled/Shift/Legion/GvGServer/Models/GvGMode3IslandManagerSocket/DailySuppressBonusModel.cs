using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using ProtoBuf;
using UnityEngine;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class DailySuppressBonusModel
{
	private static Dictionary<string, int> _limitPerZoneConfig;

	public static Dictionary<string, int> LimitConfig
	{
		get
		{
			if (_limitPerZoneConfig == null)
			{
				_limitPerZoneConfig = "SuppressLimitPerZone".ToConfiguration<Dictionary<string, int>>();
			}
			return _limitPerZoneConfig;
		}
	}

	[ProtoMember(1)]
	public int Total { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.DailySuppressBonusTimesPerZone")]
	public List<DailySuppressBonusTimesPerZone> DailySuppressBonusTimesPerZones { get; set; }

	[ProtoMember(3)]
	public int DailySuppressBonusLimit { get; set; }

	[ProtoMember(4)]
	public int DailySuppressBonusExtraLimit { get; set; }

	public int GetRemainCount()
	{
		int dailyLimit = GetDailyLimit();
		return Mathf.Max(dailyLimit - Total, 0);
	}

	public int GetDailyLimit()
	{
		return DailySuppressBonusExtraLimit + DailySuppressBonusLimit;
	}

	public bool ShouldShowRemainCount(string zoneId)
	{
		if (GameLocalDataManager.GetBool("ShowSuppressBonusLimit"))
		{
			return true;
		}
		int remainCount = GetRemainCount();
		if ((float)remainCount <= (float)GetDailyLimit() * 0.2f)
		{
			return true;
		}
		DailySuppressBonusTimesPerZone zoneData = GetZoneData(zoneId);
		int remainCount2 = zoneData.GetRemainCount();
		return (float)remainCount2 <= (float)zoneData.DailySuppressBonusTimesLimit * 0.2f;
	}

	public DailySuppressBonusTimesPerZone GetZoneData(string zoneId)
	{
		if (DailySuppressBonusTimesPerZones != null)
		{
			foreach (DailySuppressBonusTimesPerZone dailySuppressBonusTimesPerZone in DailySuppressBonusTimesPerZones)
			{
				if (dailySuppressBonusTimesPerZone.ZoneId == zoneId)
				{
					return dailySuppressBonusTimesPerZone;
				}
			}
		}
		int dailySuppressBonusTimesLimit = LimitConfig[zoneId];
		return new DailySuppressBonusTimesPerZone
		{
			DailySuppressBonusTimes = 0,
			DailySuppressBonusTimesLimit = dailySuppressBonusTimesLimit,
			ZoneId = zoneId
		};
	}
}
