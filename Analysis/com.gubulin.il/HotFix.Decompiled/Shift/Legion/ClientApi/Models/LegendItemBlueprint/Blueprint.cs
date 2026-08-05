using System;
using System.Collections.Generic;
using System.Text;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using GameDataEditor;
using ProtoBuf;
using Shift.Legion.Common.Interfaces;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Models.LegendItemBlueprint;

[ProtoContract]
public class Blueprint : IId
{
	[ProtoMember(1)]
	public string Id;

	[ProtoMember(2)]
	public int CreateTimestamp;

	[ProtoMember(3)]
	public string MainId;

	public Dictionary<string, int> Random;

	[ProtoMember(4)]
	public string _jsonRandom;

	public Dictionary<string, int> Any;

	[ProtoMember(5)]
	public string _jsonAny;

	public Dictionary<string, int> Other;

	[ProtoMember(6)]
	public string _jsonOther;

	private string evoId;

	[ProtoMember(7)]
	public List<string> NewSubEntryPools;

	[ProtoMember(8)]
	public List<int> NewSubEntryUnlockLevels;

	[ProtoMember(9)]
	public List<string> NewFxEntries;

	[ProtoMember(10)]
	public string SetAlias;

	[ProtoMember(11)]
	public string EnhanceFxEntryId;

	[ProtoMember(12)]
	public int Score;

	private List<BlueprintFxText> blueprintFxTexts;

	private string evoLegendItemName;

	private string desc;

	private string iconUrl;

	public string EvoId
	{
		get
		{
			if (string.IsNullOrEmpty(evoId))
			{
				evoId = (LegendItemManager.LegendItemTemplates.TryGetValue(MainId, out var value) ? value.EvoId : string.Empty);
			}
			return evoId;
		}
	}

	public Dictionary<string, int> GetRandom()
	{
		if (Random != null)
		{
			return Random;
		}
		if (!string.IsNullOrEmpty(_jsonRandom))
		{
			Random = JsonHelper.ToObject<Dictionary<string, int>>(_jsonRandom);
		}
		return Random ?? (Random = new Dictionary<string, int>());
	}

	public Dictionary<string, int> GetAny()
	{
		if (Any != null)
		{
			return Any;
		}
		if (!string.IsNullOrEmpty(_jsonAny))
		{
			Any = JsonHelper.ToObject<Dictionary<string, int>>(_jsonAny);
		}
		return Any ?? (Any = new Dictionary<string, int>());
	}

	public Dictionary<string, int> GetOther()
	{
		if (Other != null)
		{
			return Other;
		}
		if (!string.IsNullOrEmpty(_jsonOther))
		{
			Other = JsonHelper.ToObject<Dictionary<string, int>>(_jsonOther);
		}
		return Other ?? (Other = new Dictionary<string, int>());
	}

	public string GetId()
	{
		return Id;
	}

	public Blueprint Clone()
	{
		return JsonHelper.ToObject<Blueprint>(JsonHelper.ToJson(this));
	}

	public List<BlueprintFxText> GetBlueprintFxTexts()
	{
		if (blueprintFxTexts != null)
		{
			return blueprintFxTexts;
		}
		blueprintFxTexts = new List<BlueprintFxText>();
		BlueprintFxText blueprintEnhanceFxTexts = GetBlueprintEnhanceFxTexts();
		if (blueprintEnhanceFxTexts != null)
		{
			blueprintFxTexts.Add(blueprintEnhanceFxTexts);
		}
		List<BlueprintFxText> blueprintNewFxTexts = GetBlueprintNewFxTexts();
		if (blueprintNewFxTexts != null && blueprintNewFxTexts.Count > 0)
		{
			blueprintFxTexts.AddRange(blueprintNewFxTexts);
		}
		BlueprintFxText blueprintSetAliasTexts = GetBlueprintSetAliasTexts();
		if (blueprintSetAliasTexts != null)
		{
			blueprintFxTexts.Add(blueprintSetAliasTexts);
		}
		return blueprintFxTexts;
	}

	private List<BlueprintFxText> GetBlueprintNewFxTexts()
	{
		List<BlueprintFxText> list = new List<BlueprintFxText>();
		if (NewFxEntries == null || NewFxEntries.Count <= 0)
		{
			return list;
		}
		for (int i = 0; i < NewFxEntries.Count; i++)
		{
			string text = NewFxEntries[i];
			if (!string.IsNullOrEmpty(text))
			{
				string text2 = LegendItemsHelper.GetBlueprintFxDesc(text).Replace("[color=#aef224]", "[color=#afabab]").Replace("<img src='ui://PublicResources/icon_arrow_green_up' width='33' height='33'/>", "");
				list.Add(new BlueprintFxText
				{
					FxTextType = 1,
					Text = text2
				});
			}
		}
		return list;
	}

	private BlueprintFxText GetBlueprintEnhanceFxTexts()
	{
		if (string.IsNullOrEmpty(EnhanceFxEntryId))
		{
			return null;
		}
		string blueprintFxDesc = LegendItemsHelper.GetBlueprintFxDesc(EnhanceFxEntryId);
		return new BlueprintFxText
		{
			FxTextType = 0,
			Text = blueprintFxDesc
		};
	}

	private BlueprintFxText GetBlueprintSetAliasTexts()
	{
		if (string.IsNullOrEmpty(SetAlias))
		{
			return null;
		}
		return new BlueprintFxText
		{
			FxTextType = 2,
			Text = GetSetAliasEffectDecs(SetAlias)
		};
	}

	public static string GetSetAliasEffectDecs(string setAlias)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(GetSetAliasEffectDecsFirstLine(setAlias));
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append(Environment.NewLine);
		stringBuilder.Append(LegendItemsHelper.GetBlueprintSetDesc(setAlias));
		return stringBuilder.ToString();
	}

	public static string GetSetAliasEffectDecsFirstLine(string setAlias)
	{
		return "[color=#f5c73e]" + LanguagesManager.GetDesc("CsharpCodeZhTcText840") + "[color=#13c865][" + setAlias + "][/color]" + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText841") + "[/color]";
	}

	public string GetEvoItemName()
	{
		if (string.IsNullOrEmpty(EvoId))
		{
			return string.Empty;
		}
		if (string.IsNullOrEmpty(evoLegendItemName))
		{
			evoLegendItemName = (LegendItemManager.LegendItemTemplates.TryGetValue(EvoId, out var value) ? value.Name : string.Empty);
		}
		return evoLegendItemName;
	}

	public string GetName()
	{
		if (string.IsNullOrEmpty(EvoId))
		{
			return string.Empty;
		}
		if (string.IsNullOrEmpty(evoLegendItemName))
		{
			evoLegendItemName = (LegendItemManager.LegendItemTemplates.TryGetValue(EvoId, out var value) ? value.Name : string.Empty);
		}
		return GetName(evoLegendItemName);
	}

	public static string GetName(string evoLegendItemName)
	{
		return "[color=#DA5700]" + LegendItemsHelper.GetBlueprintNamePrefix() + evoLegendItemName + "[/color]";
	}

	public static string GetNameWithoutColor(string evoLegendItemName)
	{
		return LegendItemsHelper.GetBlueprintNamePrefix() + evoLegendItemName;
	}

	public string GetNameTwoRows()
	{
		if (string.IsNullOrEmpty(EvoId))
		{
			return string.Empty;
		}
		if (string.IsNullOrEmpty(evoLegendItemName))
		{
			evoLegendItemName = (LegendItemManager.LegendItemTemplates.TryGetValue(EvoId, out var value) ? value.Name : string.Empty);
		}
		return "[color=#DA5700]" + LegendItemsHelper.GetBlueprintNamePrefix() + Environment.NewLine + evoLegendItemName + "[/color]";
	}

	public string GetDesc()
	{
		if (!string.IsNullOrEmpty(desc))
		{
			return desc;
		}
		desc = GetDesc(EvoId);
		return desc;
	}

	public static string GetDesc(string legendItemId)
	{
		return LanguagesManager.GetDesc("Blueprint_Desc_" + legendItemId);
	}

	public string GetIconName()
	{
		if (!string.IsNullOrEmpty(iconUrl))
		{
			return iconUrl;
		}
		iconUrl = GetIconName(EvoId);
		return iconUrl;
	}

	public static string GetIconName(string evoId)
	{
		GDELegendItemData value;
		return LegendItemManager.LegendItemTemplates.TryGetValue(evoId, out value) ? (value.Icon + "_Blue") : string.Empty;
	}
}
