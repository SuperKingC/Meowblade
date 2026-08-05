using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

public static class DateTimeHelper
{
	public const string DateTimeOffsetFormat = "yyyy-MM-dd HH:mm:ss%K";

	public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

	public const string DateTimeFormat_Compact = "yyyy/M/d HH:mm";

	public const string DateFormat = "yyyy-MM-dd";

	public const string DateFormat_Compact = "yyyy/M/d";

	public static TimeSpan RefreshHours = TimeSpan.FromHours(6.0);

	public static TimeSpan TimezoneOffset = TimeSpan.FromHours(8.0);

	public static readonly DateTimeOffset BaseTime = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

	public static Regex RegexTime = new Regex("^(\\d+\\:?)+$");

	public static Regex RegexDateTimeWithOffset = new Regex("[\\+\\-]\\d{2}\\:\\d{2}");

	public static Regex RegexFullTimeFormatWithTimeOffset = new Regex("^\\d{1,2}\\:\\d{1,2}\\:\\d{1,2}(\\.\\d{1,8})?[\\+\\-]\\d{2}\\:\\d{2}$");

	public static int TimeStamp => (int)Now.Subtract(BaseTime).TotalSeconds;

	public static long Now_Milliseconds => (long)Now.Subtract(BaseTime).TotalMilliseconds;

	public static long Ticks => Now.Ticks;

	public static DateTimeOffset ServerNow => ParseTimeStamp((int)GameController.Instance.GetServerTime());

	public static int ServerNowTimestamp => (int)GameController.Instance.GetServerTime();

	public static DateTimeOffset Now => DateTimeOffset.UtcNow;

	public static DateTimeOffset Today
	{
		get
		{
			DateTimeOffset now = Now;
			return new DateTimeOffset(now.Year, now.Month, now.Day, 0, 0, 0, TimeSpan.Zero);
		}
	}

	public static DateTimeOffset ParseTimeStamp(int timestamp)
	{
		return BaseTime.Add(TimeSpan.FromSeconds(timestamp));
	}

	public static DateTimeOffset ParseMillisecondsTimeStamp(long timestamp)
	{
		return BaseTime.Add(TimeSpan.FromMilliseconds(timestamp));
	}

	public static int GetTimeStamp(DateTimeOffset dateTimeOffset)
	{
		return (int)dateTimeOffset.Subtract(BaseTime).TotalSeconds;
	}

	public static int GetTimeStamp(DateTime time)
	{
		return (int)new DateTimeOffset(time).ToUniversalTime().Subtract(BaseTime).TotalSeconds;
	}

	public static DateTimeOffset GetDailyRefreshTime(DateTimeOffset now)
	{
		if (now == default(DateTimeOffset))
		{
			now = Parse(953666901);
		}
		return GetDailyRefreshTime(now, TimezoneOffset, RefreshHours);
	}

	public static DateTimeOffset GetDailyRefreshTime(DateTimeOffset now, TimeSpan timezoneOffset, TimeSpan refreshHour)
	{
		if (now == default(DateTimeOffset))
		{
			throw new ArgumentException("当前时间不正确");
		}
		if (now.Offset != timezoneOffset)
		{
			now = now.ToOffset(timezoneOffset);
		}
		DateTimeOffset dateTimeOffset = new DateTimeOffset(now.Year, now.Month, now.Day, refreshHour.Hours, refreshHour.Minutes, refreshHour.Seconds, timezoneOffset);
		if (now < dateTimeOffset)
		{
			return dateTimeOffset.AddDays(-1.0);
		}
		return dateTimeOffset;
	}

	public static DateTimeOffset GetWeeklyRefreshTime(DateTimeOffset now, TimeSpan timezoneOffset, TimeSpan refreshHour)
	{
		if (now.Offset != timezoneOffset)
		{
			now = now.ToOffset(timezoneOffset);
		}
		int num = (int)(now.DayOfWeek + 6) % 7;
		DateTimeOffset dateTimeOffset = now.AddDays(-num);
		DateTimeOffset dateTimeOffset2 = new DateTimeOffset(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, refreshHour.Hours, refreshHour.Minutes, refreshHour.Seconds, timezoneOffset);
		if (num == 0 && dateTimeOffset < dateTimeOffset2)
		{
			return dateTimeOffset2.AddDays(-7.0);
		}
		return dateTimeOffset2;
	}

	public static DateTimeOffset GetMonthlyRefreshTime(DateTimeOffset now, TimeSpan timezoneOffset, TimeSpan refreshHour)
	{
		if (now.Offset != timezoneOffset)
		{
			now = now.ToOffset(timezoneOffset);
		}
		int num = -(now.Day - 1);
		DateTimeOffset dateTimeOffset = now.AddDays(num);
		DateTimeOffset dateTimeOffset2 = new DateTimeOffset(now.Year, now.Month, 1, refreshHour.Hours, refreshHour.Minutes, refreshHour.Seconds, timezoneOffset);
		if (num == 0 && dateTimeOffset < dateTimeOffset2)
		{
			return dateTimeOffset2.AddMonths(-1);
		}
		return dateTimeOffset2;
	}

	public static DateTimeOffset Parse(double timestamp)
	{
		return BaseTime.AddSeconds(timestamp);
	}

	public static DateTimeOffset Parse(int timestamp)
	{
		return BaseTime.AddSeconds(timestamp);
	}

	public static DateTimeOffset Parse(string dateTimeStr, DateTimeOffset now)
	{
		try
		{
			if (!dateTimeStr.Contains("+") && !dateTimeStr.EndsWith("Z"))
			{
				dateTimeStr += "+00:00";
			}
			if (RegexTime.IsMatch(dateTimeStr))
			{
				DateTimeOffset dateTimeOffset = now;
				DateTimeOffset dateTimeOffset2 = DateTimeOffset.Parse(dateTimeStr).ToOffset(TimeSpan.Zero);
				return new DateTimeOffset(dateTimeOffset.Year, dateTimeOffset.Month, dateTimeOffset.Day, dateTimeOffset2.Hour, dateTimeOffset2.Minute, dateTimeOffset2.Second, TimeSpan.Zero);
			}
			return DateTimeOffset.Parse(dateTimeStr).ToOffset(TimeSpan.Zero);
		}
		catch (Exception exception)
		{
			ILRuntimeDebug.LogException(exception);
			throw;
		}
	}

	public static bool TryParse(string dateTimeStr, out DateTimeOffset dateTime)
	{
		dateTime = default(DateTimeOffset);
		if (!RegexDateTimeWithOffset.IsMatch(dateTimeStr))
		{
			return false;
		}
		try
		{
			if (DateTimeOffset.TryParse(dateTimeStr, out dateTime))
			{
				dateTime = dateTime.ToOffset(TimeSpan.Zero);
				return true;
			}
			return false;
		}
		catch (Exception exception)
		{
			ILRuntimeDebug.LogException(exception);
			throw;
		}
	}

	public static bool TryParseTime(DateTimeOffset now, string timeStr, out DateTimeOffset dateTime)
	{
		dateTime = default(DateTimeOffset);
		if (!RegexFullTimeFormatWithTimeOffset.IsMatch(timeStr))
		{
			return false;
		}
		try
		{
			timeStr = now.ToString("yyyy-MM-dd ", DateTimeFormatInfo.InvariantInfo) + timeStr;
			return DateTimeOffset.TryParse(timeStr, out dateTime);
		}
		catch (Exception exception)
		{
			ILRuntimeDebug.LogException(exception);
			throw;
		}
	}

	public static DateTimeOffset GetDateTime(int year, int month, int day)
	{
		return new DateTimeOffset(year, month, day, 0, 0, 0, TimeSpan.Zero);
	}

	public static DateTimeOffset GetDateTime(int year, int month, int day, int hour, int minute, int second)
	{
		return new DateTimeOffset(year, month, day, hour, minute, second, TimeSpan.Zero);
	}

	public static List<TimeSpan> TimeSpansPaser(List<string> str)
	{
		List<TimeSpan> list = new List<TimeSpan>();
		foreach (string item in str)
		{
			int num = int.Parse(item);
			int hours = num / 100;
			int minutes = num % 100;
			list.Add(new TimeSpan(hours, minutes, 0));
		}
		if (list[1] < list[0])
		{
			list[1] = list[1].Add(TimeSpan.FromDays(1.0));
		}
		return list;
	}

	public static int GetToday0000Timestamp()
	{
		return GetTimeStamp(GetDailyRefreshTime(ServerNow, TimezoneOffset, TimeSpan.FromHours(0.0)));
	}
}
