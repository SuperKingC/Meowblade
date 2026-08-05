using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public static class GDMgr_Utils
{
	public class ParseData_ReviewStory
	{
		public string type;

		public string val;

		public string review_key;
	}

	public static T GDEData_Parse<T>(string val)
	{
		if (string.IsNullOrEmpty(val))
		{
			return default(T);
		}
		return JsonHelper.ToObject<T>(val);
	}
}
