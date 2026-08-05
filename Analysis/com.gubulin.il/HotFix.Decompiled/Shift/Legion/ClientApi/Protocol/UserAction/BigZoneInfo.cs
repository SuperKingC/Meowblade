using System.Collections.Generic;
using System.Linq;
using ILRuntime_LitJson;
using Shift.Legion.Rank.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class BigZoneInfo
{
	public int MaxZoneCount;

	public int MinZoneCount;

	public int UserId_StartIdx;

	public int UserId_EndIdx;

	public Dictionary<string, ZoneInfo> CurrentZoneDetail;

	public string BigZoneName { get; set; }

	public int BigZoneId { get; set; }

	public List<int> CanChooseBigZoneId { get; set; }

	[JsonIgnore]
	public int CurrentZoneCount => BigZone.Count;

	[JsonIgnore]
	public ZoneInfo CurrentZoneInfo
	{
		get
		{
			if (CurrentZoneDetail == null || CurrentZoneDetail.Count <= 0)
			{
				return null;
			}
			return CurrentZoneDetail.Values.ToList()[0];
		}
	}

	[JsonIgnore]
	public List<BigZoneInfo> BigZone { get; set; }

	public List<KeyValuePair<string, BigZoneInfo>> RandomZoneDetail()
	{
		List<KeyValuePair<string, BigZoneInfo>> list = new List<KeyValuePair<string, BigZoneInfo>>();
		for (int i = 0; i < BigZone.Count; i++)
		{
			list.Add(new KeyValuePair<string, BigZoneInfo>(BigZone[i].CurrentZoneInfo.RSName, BigZone[i]));
		}
		return list.Choose(list.Count);
	}
}
