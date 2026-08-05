using System.Collections.Generic;
using HotFix;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models.Store;

namespace Shift.Legion.Common.Models;

public class BlackMarket : Building
{
	public object Controller;

	private readonly List<Activity> _buffer = new List<Activity>();

	public BlackMarket(GameManagers managers)
		: base(managers, "16")
	{
	}

	public override bool HasAnyInform()
	{
		if (base.HasAnyInform())
		{
			return true;
		}
		if (Level < 1)
		{
			return false;
		}
		List<Activity> activitiesByType = Managers.ActivityManager.GetActivitiesByType(ActivityType.Lottery, _buffer, isSort: false);
		if (activitiesByType != null)
		{
			foreach (Activity item in activitiesByType)
			{
				if (item.HasAnyNewMsg(Managers))
				{
					return true;
				}
			}
		}
		activitiesByType = Managers.ActivityManager.GetActivitiesByType(ActivityType.BlackMarket, _buffer);
		if (activitiesByType == null)
		{
			return false;
		}
		string text = "GiftPackMerchant";
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			text = text + "_" + HotUpdateProcess.RegionKey;
		}
		foreach (Activity item2 in activitiesByType)
		{
			if (item2.ActivityId == "DungeonContractMerchant")
			{
				List<StoreItem> list = new List<StoreItem>();
				foreach (ActivityContentPayload value in item2.ContentPayload(Managers).Values)
				{
					StoreActivityPayload storeActivityPayload = (StoreActivityPayload)value;
					list.AddRange(storeActivityPayload.StoreItems(Managers).Values);
				}
				foreach (StoreItem item3 in list)
				{
					foreach (KeyValuePair<string, int> leaseholdItem in item3.LeaseholdItems)
					{
						if (Managers.LeaseholdManager.CanClaimDailyBonus(leaseholdItem.Key))
						{
							return true;
						}
					}
				}
			}
			else if (item2.ActivityId == text && item2.HasAnyNewMsg(Managers))
			{
				return true;
			}
		}
		return false;
	}
}
