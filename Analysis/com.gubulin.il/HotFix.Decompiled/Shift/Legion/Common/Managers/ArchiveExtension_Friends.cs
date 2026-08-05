using System;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Friends
{
	public class Model
	{
		public int DeleteFriendsLimit;

		public DateTimeOffset LastResetTime;

		public void Reset()
		{
			DeleteFriendsLimit = 3;
			LastResetTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
		}
	}

	private const string FriendsLimitInfoKey = "FriendsInfo";

	public static Model GetFriendsInfo(this UserArchiveManager manager)
	{
		Model model = manager.GetConfigValue<Model>("FriendsInfo");
		if (model == null)
		{
			model = new Model();
			model.Reset();
			manager.SetFriendsInfo(model);
		}
		return model;
	}

	public static void SetFriendsInfo(this UserArchiveManager manager, Model _model)
	{
		manager.SetConfigValue("FriendsInfo", _model);
	}

	public static void CheckFriendsInfo(this UserArchiveManager manager)
	{
		DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
		Model friendsInfo = manager.GetFriendsInfo();
		if (friendsInfo.LastResetTime != dailyRefreshTime)
		{
			friendsInfo.Reset();
			manager.SetFriendsInfo(friendsInfo);
		}
	}

	public static bool TryCountDownWhenDeleteFriend(this UserArchiveManager manager)
	{
		Model friendsInfo = manager.GetFriendsInfo();
		if (friendsInfo.DeleteFriendsLimit > 0)
		{
			friendsInfo.DeleteFriendsLimit--;
			manager.SetFriendsInfo(friendsInfo);
			return true;
		}
		return false;
	}
}
