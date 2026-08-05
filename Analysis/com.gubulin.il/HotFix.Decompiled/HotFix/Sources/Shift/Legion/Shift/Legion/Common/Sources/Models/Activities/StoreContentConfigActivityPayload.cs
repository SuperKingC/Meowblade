using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Models.Activities;

public class StoreContentConfigActivityPayload : ActivityContentPayload
{
	public string PageName { get; set; }

	public List<GDEStoreContentConfigData> GDEStoreContentConfigDatas { get; set; }

	public StoreContentConfigActivityPayload(int payloadIndex, string pageName, Dictionary<string, object> data, Activity activity)
		: base(data)
	{
		ContentIndex = payloadIndex;
		PageName = pageName;
		Activity = activity;
		if (data.TryGetValue("GDEStoreContentConfigDatas", out var value))
		{
			GDEStoreContentConfigDatas = JsonHelper.ToObject<List<GDEStoreContentConfigData>>(value.ToString());
		}
	}
}
