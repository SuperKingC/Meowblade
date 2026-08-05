using System.Collections.Generic;
using GameDataEditor;
using GameMaths;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models.LegendItem;

public class LegendItemEnhancementConfig
{
	public string ConfigId;

	public int EnhanceLevel;

	public int UnlockedSubEntries;

	public int ExpNeedFromPrevLevel;

	public int TotalExpNeed;

	public Dictionary<string, ItemEntryData> EnhancedAttrs;

	public Dictionary<string, ItemEntryData> DeltaAttrsFromPrevLevel;

	public LegendItemEnhancementConfig(GDELegendItemEnhancementData data)
	{
		ConfigId = data.EnhanceConfigId;
		EnhanceLevel = data.EnhanceLevel;
		UnlockedSubEntries = data.SubPropertiesUnlock;
		ExpNeedFromPrevLevel = data.ExpRequire;
		TotalExpNeed = ExpNeedFromPrevLevel;
		DeltaAttrsFromPrevLevel = new Dictionary<string, ItemEntryData>();
		EnhancedAttrs = new Dictionary<string, ItemEntryData>();
		if (!string.IsNullOrEmpty(data.MainProperiesPayload))
		{
			foreach (Dictionary<string, string> item in JsonHelper.ToObject<List<Dictionary<string, string>>>(data.MainProperiesPayload))
			{
				string text = item["Key"];
				string text2 = item["Value"];
				ItemEntryData itemEntryData = new ItemEntryData
				{
					Key = text
				};
				if (text2.EndsWith("%"))
				{
					text += "_PCT";
					itemEntryData.IsPercent = true;
					itemEntryData.Value = Mathf.RoundToInt(NumericParser.Float(text2.TrimEnd('%')) * 10000f);
				}
				else
				{
					itemEntryData.Value = Mathf.RoundToInt(NumericParser.Float(text2) * 10000f);
				}
				DeltaAttrsFromPrevLevel.Add(text, itemEntryData);
				EnhancedAttrs.Add(text, itemEntryData);
			}
		}
		LegendItemEnhancementConfig legendItemEnhancementConfig = null;
		if (EnhanceLevel > 1)
		{
			legendItemEnhancementConfig = GetEnhanceConfig(ConfigId, EnhanceLevel - 1);
		}
		if (legendItemEnhancementConfig == null)
		{
			return;
		}
		TotalExpNeed += legendItemEnhancementConfig.TotalExpNeed;
		foreach (KeyValuePair<string, ItemEntryData> enhancedAttr in legendItemEnhancementConfig.EnhancedAttrs)
		{
			ItemEntryData value = enhancedAttr.Value;
			if (EnhancedAttrs.TryGetValue(enhancedAttr.Key, out var value2))
			{
				value2.Value += value.Value;
				continue;
			}
			value2 = value;
			EnhancedAttrs.Add(enhancedAttr.Key, value2);
		}
	}

	public static LegendItemEnhancementConfig GetEnhanceConfig(string configId, int enhanceLevel)
	{
		if (enhanceLevel < 1)
		{
			return null;
		}
		if (!LegendItemManager.LegendItemEnhancementConfigs.TryGetValue(configId, out var value))
		{
			value = new Dictionary<int, LegendItemEnhancementConfig>();
			LegendItemManager.LegendItemEnhancementConfigs.Add(configId, value);
		}
		if (!value.TryGetValue(enhanceLevel, out var value2))
		{
			if (!LegendItemManager.LegendItemEnhancementDataDict.TryGetValue(configId, out var value3) || !value3.TryGetValue(enhanceLevel, out var value4))
			{
				return null;
			}
			value2 = new LegendItemEnhancementConfig(value4);
			value.Add(enhanceLevel, value2);
		}
		return value2;
	}
}
