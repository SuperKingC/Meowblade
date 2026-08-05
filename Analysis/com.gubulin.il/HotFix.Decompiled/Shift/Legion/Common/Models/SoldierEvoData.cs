using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class SoldierEvoData
{
	public readonly string SoldierId;

	public readonly int Level;

	public readonly Dictionary<string, int> EvoRequire;

	public readonly Dictionary<string, float> PercentBonus;

	public readonly Dictionary<string, float> FixedBonus;

	public SoldierEvoData(GDESoldierEvoData data)
	{
		SoldierId = data.SoldierId;
		Level = data.EvoLevel;
		EvoRequire = JsonHelper.ToObject<Dictionary<string, int>>(data.EvoRequire);
		PercentBonus = new Dictionary<string, float>();
		FixedBonus = new Dictionary<string, float>();
		if (string.IsNullOrEmpty(data.EvoAttributes))
		{
			return;
		}
		foreach (KeyValuePair<string, object> item in JsonHelper.ToObject<Dictionary<string, object>>(data.EvoAttributes))
		{
			string text = item.Value.ToString();
			if (text.IndexOf('%') == -1)
			{
				FixedBonus.Add(item.Key, NumericParser.Float(text));
			}
			else
			{
				PercentBonus.Add(item.Key, NumericParser.FloatPercent(text));
			}
		}
	}
}
