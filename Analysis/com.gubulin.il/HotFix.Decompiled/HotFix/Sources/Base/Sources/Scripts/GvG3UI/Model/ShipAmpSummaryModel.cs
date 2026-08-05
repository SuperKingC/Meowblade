using System.Collections.Generic;
using GameMaths;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class ShipAmpSummaryModel
{
	public enum eUIPropState
	{
		Normal,
		Increased,
		Decreased
	}

	public class TotalPropModel2 : TotalPropModel
	{
		public eUIPropState State;
	}

	public int TotalScore;

	public int TotalAmpCount;

	public List<TotalPropModel2> TotalPropList;

	public Dictionary<string, TotalPropModel2> TotalPropDict;

	public static ShipAmpSummaryModel CreateFromLoadedAmps(Dictionary<int, int> loadedAmps)
	{
		Dictionary<string, TotalPropModel2> dictionary = new Dictionary<string, TotalPropModel2>();
		List<TotalPropModel2> list = new List<TotalPropModel2>();
		int num = 0;
		int num2 = 0;
		foreach (KeyValuePair<int, int> loadedAmp in loadedAmps)
		{
			int key = loadedAmp.Key;
			int value = loadedAmp.Value;
			AmplifierModel amplifierModel = AmpConfigHelper.Configs.TryGetNormalAmplifier(key);
			num += value;
			num2 += amplifierModel.Score * value;
			foreach (KeyValuePair<string, float> item in amplifierModel.Desc)
			{
				string effectRangeDesc = amplifierModel.EffectRangeDesc;
				string key2 = item.Key;
				string key3 = effectRangeDesc + "_" + key2;
				ePropType ePropType2 = amplifierModel.DescType[item.Key];
				if (!dictionary.TryGetValue(key3, out var value2))
				{
					value2 = new TotalPropModel2
					{
						Idx = key,
						EffectRange = effectRangeDesc,
						PropName = key2,
						State = eUIPropState.Normal,
						DescType = ePropType2
					};
					dictionary.Add(key3, value2);
					list.Add(value2);
					switch (ePropType2)
					{
					case ePropType.Add:
						value2.Value = item.Value * (float)value;
						break;
					case ePropType.DRSum:
						value2.Value = Mathf.Pow(1f - item.Value / 100f, (float)value);
						break;
					}
				}
				else
				{
					switch (ePropType2)
					{
					case ePropType.Add:
						value2.Value += item.Value * (float)value;
						break;
					case ePropType.DRSum:
						value2.Value *= Mathf.Pow(1f - item.Value / 100f, (float)value);
						break;
					}
				}
			}
		}
		return new ShipAmpSummaryModel
		{
			TotalScore = num2,
			TotalAmpCount = num,
			TotalPropDict = dictionary,
			TotalPropList = list
		};
	}

	public void DiffWith(ShipAmpSummaryModel otherSummaryData)
	{
		foreach (KeyValuePair<string, TotalPropModel2> item in TotalPropDict)
		{
			TotalPropModel2 value = item.Value;
			value.State = eUIPropState.Normal;
			if (!otherSummaryData.TotalPropDict.TryGetValue(item.Key, out var value2))
			{
				continue;
			}
			if (value.DescType == ePropType.Add)
			{
				if (value.Value < value2.Value)
				{
					value.State = eUIPropState.Decreased;
				}
				else if (value.Value > value2.Value)
				{
					value.State = eUIPropState.Increased;
				}
			}
			else if (value.DescType == ePropType.DRSum)
			{
				if (value.Value > value2.Value)
				{
					value.State = eUIPropState.Decreased;
				}
				else if (value.Value < value2.Value)
				{
					value.State = eUIPropState.Increased;
				}
			}
		}
	}
}
