using System.Collections.Generic;
using System.Reflection;
using GameDataEditor;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class ProductEvoData
{
	public const int MAX_EVO_LEVEL = 6;

	public readonly string ItemId;

	public readonly Dictionary<int, Dictionary<string, int>> EvoRequire;

	public readonly Dictionary<int, Dictionary<string, int>> FragEvoRequire;

	public readonly Dictionary<int, Dictionary<string, float>> EvoFixBonus;

	public readonly Dictionary<int, Dictionary<string, float>> EvoPercentBonus;

	public readonly Dictionary<int, Dictionary<string, float>> FragEvoFixBonus;

	public readonly Dictionary<int, Dictionary<string, float>> FragEvoPercentBonus;

	public ProductEvoData(string id)
	{
		ItemId = id.Substring(1);
		EvoRequire = new Dictionary<int, Dictionary<string, int>>();
		FragEvoRequire = new Dictionary<int, Dictionary<string, int>>();
		EvoFixBonus = new Dictionary<int, Dictionary<string, float>>();
		EvoPercentBonus = new Dictionary<int, Dictionary<string, float>>();
		FragEvoFixBonus = new Dictionary<int, Dictionary<string, float>>();
		FragEvoPercentBonus = new Dictionary<int, Dictionary<string, float>>();
		GDEProductEvoData gDEProductEvoData = GDMgr.Get<GDEProductEvoData>(id);
		if (gDEProductEvoData == null)
		{
			return;
		}
		for (int i = 1; i <= 6; i++)
		{
			PropertyInfo property = gDEProductEvoData.GetType().GetProperty($"Demand{i}");
			if (property != null)
			{
				object value = property.GetValue(gDEProductEvoData);
				if (value != null)
				{
					EvoRequire.Add(i, JsonHelper.ToObject<Dictionary<string, int>>(value.ToString()));
				}
				else
				{
					EvoRequire.Add(i, null);
				}
			}
			EvoFixBonus.Add(i, new Dictionary<string, float>());
			EvoPercentBonus.Add(i, new Dictionary<string, float>());
			PropertyInfo property2 = gDEProductEvoData.GetType().GetProperty($"Level{i}");
			if (property2 != null)
			{
				object value2 = property2.GetValue(gDEProductEvoData);
				if (value2 != null)
				{
					foreach (KeyValuePair<string, object> item in JsonHelper.ToObject<Dictionary<string, object>>(value2.ToString()))
					{
						string text = item.Value.ToString();
						if (text.IndexOf('%') == -1)
						{
							float value3 = NumericParser.Float(text);
							EvoFixBonus[i].Add(item.Key, value3);
						}
						else
						{
							float value3 = NumericParser.FloatPercent(text);
							EvoPercentBonus[i].Add(item.Key, value3);
						}
					}
				}
			}
			PropertyInfo property3 = gDEProductEvoData.GetType().GetProperty($"FragDemand{i}");
			if (property3 != null)
			{
				object value4 = property3.GetValue(gDEProductEvoData);
				if (value4 != null)
				{
					FragEvoRequire.Add(i, JsonHelper.ToObject<Dictionary<string, int>>(value4.ToString()));
				}
				else
				{
					FragEvoRequire.Add(i, null);
				}
			}
			FragEvoFixBonus.Add(i, new Dictionary<string, float>());
			FragEvoPercentBonus.Add(i, new Dictionary<string, float>());
			PropertyInfo property4 = gDEProductEvoData.GetType().GetProperty($"FragLevel{i}");
			if (!(property4 != null))
			{
				continue;
			}
			object value5 = property4.GetValue(gDEProductEvoData);
			if (value5 == null)
			{
				continue;
			}
			foreach (KeyValuePair<string, object> item2 in JsonHelper.ToObject<Dictionary<string, object>>(value5.ToString()))
			{
				string text2 = item2.Value.ToString();
				if (text2.IndexOf('%') == -1)
				{
					float value6 = NumericParser.Float(text2);
					FragEvoFixBonus[i].Add(item2.Key, value6);
				}
				else
				{
					float value6 = NumericParser.FloatPercent(text2);
					FragEvoPercentBonus[i].Add(item2.Key, value6);
				}
			}
		}
	}

	public static ProductEvoData GetEvoData(string itemId)
	{
		return ConfigDataManager.ProductEvoData.ContainsKey(itemId) ? ConfigDataManager.ProductEvoData[itemId] : null;
	}
}
