using System;

public static class StringExtensions
{
	public static string ReplaceFirst(this string text, string search, string replace)
	{
		int num = text.IndexOf(search, StringComparison.Ordinal);
		if (num < 0)
		{
			return text;
		}
		return text.Substring(0, num) + replace + text.Substring(num + search.Length);
	}
}
