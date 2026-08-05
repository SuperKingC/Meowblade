using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public static class GDESoldierMythData_Extensions
{
	public static Dictionary<string, float> GetFixAttr(this GDESoldierMythData gDESoldierMythData)
	{
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		Dictionary<string, object> dictionary2 = JsonHelper.ToObject<Dictionary<string, object>>(gDESoldierMythData.Attr);
		foreach (KeyValuePair<string, object> item in dictionary2)
		{
			float num = 0f;
			string text = item.Value.ToString();
			if (!text.Contains('%'))
			{
				num = NumericParser.Float(text);
				dictionary.Add(item.Key, num);
			}
		}
		return dictionary;
	}

	public static Dictionary<string, float> GetPercentAttr(this GDESoldierMythData gDESoldierMythData)
	{
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		Dictionary<string, object> dictionary2 = JsonHelper.ToObject<Dictionary<string, object>>(gDESoldierMythData.Attr);
		foreach (KeyValuePair<string, object> item in dictionary2)
		{
			float num = 0f;
			string text = item.Value.ToString();
			if (text.Contains('%'))
			{
				num = NumericParser.FloatPercent(text);
				dictionary.Add(item.Key, num);
			}
		}
		return dictionary;
	}

	public static Dictionary<string, float> GetPercentAttrUi(this GDESoldierMythData gDESoldierMythData)
	{
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		Dictionary<string, object> dictionary2 = JsonHelper.ToObject<Dictionary<string, object>>(gDESoldierMythData.Attr);
		foreach (KeyValuePair<string, object> item in dictionary2)
		{
			float num = 0f;
			string text = item.Value.ToString();
			if (text.Contains('%'))
			{
				num = NumericParser.Float(text.Replace("%", ""));
				dictionary.Add(item.Key, num);
			}
		}
		return dictionary;
	}
}
