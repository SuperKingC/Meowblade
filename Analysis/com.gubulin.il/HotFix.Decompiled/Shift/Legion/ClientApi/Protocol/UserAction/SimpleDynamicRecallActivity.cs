using System;
using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class SimpleDynamicRecallActivity
{
	public string ActivityId { get; set; }

	public string ActivityName { get; set; }

	public string PageName { get; set; }

	public string Desc { get; set; }

	public List<DateTimeOffset> BeginTime { get; set; }

	public List<DateTimeOffset> EndTime { get; set; }

	public bool IsAvailable
	{
		get
		{
			if (BeginTime == null || BeginTime.Count == 0)
			{
				ILRuntimeDebug.LogError("[SimpleDynamicRecallActivity] BeginTime 为空");
				return false;
			}
			if (EndTime == null || EndTime.Count == 0)
			{
				ILRuntimeDebug.LogError("[SimpleDynamicRecallActivity] EndTime 为空");
				return false;
			}
			DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime());
			return dateTimeOffset.CompareTo(BeginTime[0]) > 0 && dateTimeOffset.CompareTo(EndTime[0]) < 0;
		}
	}
}
