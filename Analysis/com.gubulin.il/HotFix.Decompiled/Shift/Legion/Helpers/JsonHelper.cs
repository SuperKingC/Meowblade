using ILRuntime_LitJson;

namespace Shift.Legion.Helpers;

public static class JsonHelper
{
	private static bool _initialized;

	public static void InitSettings()
	{
		if (!_initialized)
		{
			_initialized = true;
		}
	}

	public static string ToJson(object obj)
	{
		if (obj == null)
		{
			return null;
		}
		if (obj is int)
		{
			return obj.ToString();
		}
		if (obj is string)
		{
			return "\"" + obj.ToString() + "\"";
		}
		if (obj is bool)
		{
			if ((bool)obj)
			{
				return "True";
			}
			return "False";
		}
		return JsonMapper.ToJson(obj);
	}

	public static T ToObject<T>(string json)
	{
		if (string.IsNullOrEmpty(json))
		{
			return default(T);
		}
		return JsonMapper.ToObject<T>(json);
	}

	public static bool IsJArray(object obj)
	{
		return false;
	}

	public static bool IsJObject(object obj)
	{
		return false;
	}
}
