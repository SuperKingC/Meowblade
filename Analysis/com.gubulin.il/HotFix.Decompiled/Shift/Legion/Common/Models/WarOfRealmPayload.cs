using System.Collections.Generic;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class WarOfRealmPayload : ActivityContentPayload
{
	public string PageName { get; set; }

	public List<WarOfRealmMission> Missions { get; set; }

	public Dictionary<int, Dictionary<string, int>> FreeBonus { get; set; }

	public Dictionary<int, string> PaidBonus { get; set; }

	public WarOfRealmPayload(int payloadIndex, string pageName, Dictionary<string, object> data, Activity activity)
		: base(data)
	{
		ContentIndex = payloadIndex;
		PageName = pageName;
		Activity = activity;
		if (data.TryGetValue("Missions", out var value))
		{
			Missions = JsonHelper.ToObject<List<WarOfRealmMission>>(value.ToString());
		}
		if (data.TryGetValue("FreeBonus", out var value2))
		{
			FreeBonus = JsonHelper.ToObject<Dictionary<int, Dictionary<string, int>>>(value2.ToString());
		}
		if (data.TryGetValue("PaidBonus", out var value3))
		{
			PaidBonus = JsonHelper.ToObject<Dictionary<int, string>>(value3.ToString());
		}
	}
}
