using System;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class NeutralDungeonData
{
	public Activity Activity;

	public DateTimeOffset CurBeginTime;

	public DateTimeOffset CurEndTime;

	public string AdId;

	public string AdName;

	public string AdDesc;

	public string AdBgUrl;

	public DateTimeOffset AdBeginTime;

	public DateTimeOffset AdEndTime;

	public bool HasTickets()
	{
		return true;
	}

	public bool HasUnlocked()
	{
		bool result = true;
		if (Activity.LevelCase != null && Activity.LevelCase.Count > 0)
		{
			foreach (string item in Activity.LevelCase)
			{
				if (GameManagers.Instance.UserArchiveManager.IsLevelCompleted(item))
				{
					continue;
				}
				result = false;
				break;
			}
		}
		return result;
	}

	public int TimeGoingOn()
	{
		DateTimeOffset dateTimeOffset = DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime());
		if (CurBeginTime == default(DateTimeOffset))
		{
			return int.MinValue;
		}
		return (int)(dateTimeOffset - CurBeginTime).TotalSeconds;
	}

	public string GetTicketExtraLimitDesc()
	{
		int num = 0;
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("OverlordContract") > 0)
		{
			num++;
		}
		if (GameManagers.Instance.LeaseholdManager.GetLeaseholdItemRemainingTime("PrimeContract") > 0)
		{
			num++;
		}
		return num switch
		{
			1 => "[color=#FFF04C](+1)[/color]", 
			2 => "[color=#FFF04C](+2)[/color]", 
			_ => "", 
		};
	}
}
