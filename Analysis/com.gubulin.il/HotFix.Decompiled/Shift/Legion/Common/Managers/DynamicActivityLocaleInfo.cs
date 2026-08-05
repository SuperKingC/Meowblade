using System;
using System.Collections.Generic;
using HotFix;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public class DynamicActivityLocaleInfo
{
	public string Name;

	public string Desc;

	public string BackgroundImageUrl;

	public static DynamicActivityLocaleInfo DynamicActivityLocaleInfoFromDesc(string dynamicActivityDesc)
	{
		try
		{
			Dictionary<string, DynamicActivityLocaleInfo> dictionary = JsonHelper.ToObject<Dictionary<string, DynamicActivityLocaleInfo>>(dynamicActivityDesc);
			if (dictionary.TryGetValue(HotUpdateProcess.LanguageKey, out var value))
			{
				return value;
			}
		}
		catch (Exception exception)
		{
			ILRuntimeDebug.LogException(exception);
			return null;
		}
		return null;
	}
}
