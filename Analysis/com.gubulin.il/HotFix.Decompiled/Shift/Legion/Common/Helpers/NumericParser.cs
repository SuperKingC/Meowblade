using System.Globalization;

namespace Shift.Legion.Common.Helpers;

public static class NumericParser
{
	public static bool TryFloat(string raw, out float value)
	{
		value = 0f;
		if (string.IsNullOrWhiteSpace(raw))
		{
			SentrySdk.AddBreadcrumb("[NumericParser] TryFloat failed: input is null/whitespace");
			return false;
		}
		string text = raw.Trim();
		bool flag = float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
		if (!flag)
		{
			SentrySdk.AddBreadcrumb("[NumericParser] TryFloat failed: raw='" + raw + "' trimmed='" + text + "' culture='" + CultureInfo.CurrentCulture.Name + "'");
		}
		return flag;
	}

	public static float Float(string raw, float defaultVal = 0f)
	{
		float value;
		return TryFloat(raw, out value) ? value : defaultVal;
	}

	public static float FloatPercent(string raw, float defaultVal = 0f)
	{
		if (string.IsNullOrWhiteSpace(raw))
		{
			return defaultVal;
		}
		raw = raw.Trim().Replace("％", "%");
		if (raw.EndsWith("%"))
		{
			raw = raw.Substring(0, raw.Length - 1);
			return Float(raw, defaultVal) / 100f;
		}
		return Float(raw, defaultVal);
	}

	public static bool TryDouble(string raw, out double value)
	{
		value = 0.0;
		if (string.IsNullOrWhiteSpace(raw))
		{
			SentrySdk.AddBreadcrumb("[NumericParser] TryDouble failed: input is null/whitespace");
			return false;
		}
		string text = raw.Trim();
		bool flag = double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
		if (!flag)
		{
			SentrySdk.AddBreadcrumb("[NumericParser] TryDouble failed: raw='" + raw + "' trimmed='" + text + "' culture='" + CultureInfo.CurrentCulture.Name + "'");
		}
		return flag;
	}

	public static double Double(string raw, double defaultVal = 0.0)
	{
		double value;
		return TryDouble(raw, out value) ? value : defaultVal;
	}

	public static double DoublePercent(string raw, double defaultVal = 0.0)
	{
		if (string.IsNullOrWhiteSpace(raw))
		{
			return defaultVal;
		}
		raw = raw.Trim().Replace("％", "%");
		if (raw.EndsWith("%"))
		{
			raw = raw.Substring(0, raw.Length - 1);
			return Double(raw, defaultVal) / 100.0;
		}
		return Double(raw, defaultVal);
	}
}
