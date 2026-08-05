using System.Collections.Generic;

namespace Shift.Legion.GvG.Helpers;

public static class ChkValue
{
	public static bool GetValue(this Dictionary<string, decimal> dict, string key, out decimal value)
	{
		if (dict.TryGetValue(key, out value))
		{
			return true;
		}
		return false;
	}
}
