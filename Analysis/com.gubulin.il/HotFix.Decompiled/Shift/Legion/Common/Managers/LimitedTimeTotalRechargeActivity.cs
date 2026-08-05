using System.Collections.Generic;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public class LimitedTimeTotalRechargeActivity
{
	public string ActivityId { get; set; }

	public string ActivityName { get; set; }

	public string ImgUrl { get; set; }

	public string Desc { get; set; }

	public string Currency { get; set; }

	public List<LimitedTimeTotalRechargeInfo> BonusInfos { get; set; } = new List<LimitedTimeTotalRechargeInfo>();

	public string[] BeginTime { get; set; }

	public string[] EndTime { get; set; }

	public LimitedTimeTotalRechargeActivity(LTTR_Model activityModel)
	{
		ActivityId = activityModel.ActivityId;
		ActivityName = activityModel.Name;
		BeginTime = activityModel.BeginTime;
		EndTime = activityModel.EndTime;
		ImgUrl = activityModel.ImgUrl;
		Desc = activityModel.Desc;
		Currency = activityModel.Currency;
		foreach (string key in activityModel.Config.Keys)
		{
			LimitedTimeTotalRechargeInfo item = JsonHelper.ToObject<LimitedTimeTotalRechargeInfo>(activityModel.Config[key]);
			BonusInfos.Add(item);
		}
	}

	public bool HasAnyInform()
	{
		foreach (LimitedTimeTotalRechargeInfo bonusInfo in BonusInfos)
		{
			if (ArchiveExtension_DynamicActivity_LTTR.GetOneBonusState(ActivityId, bonusInfo.RMB) == ArchiveExtension_DynamicActivity_LTTR.BonusState.Pending)
			{
				return true;
			}
		}
		return false;
	}
}
