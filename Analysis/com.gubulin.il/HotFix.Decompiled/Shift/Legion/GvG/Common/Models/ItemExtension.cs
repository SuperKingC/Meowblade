using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvG.Common.Models;

public static class ItemExtension
{
	private static Dictionary<string, eMultiBattleBuffType> _cache = new Dictionary<string, eMultiBattleBuffType>();

	public static eMultiBattleBuffType GetMultiBattleBuffType(this GDEItemData itemData)
	{
		if (_cache.TryGetValue(itemData.Key, out var value))
		{
			return value;
		}
		ItemType itemType = (ItemType)itemData.ItemType;
		if (itemType != ItemType.GvGMultiBattleBuff)
		{
			return (eMultiBattleBuffType)0;
		}
		GvGMode3MultiBattleBuffConfig gvGMode3MultiBattleBuffConfig = JsonHelper.ToObject<GvGMode3MultiBattleBuffConfig>(itemData.Effect);
		value = (eMultiBattleBuffType)gvGMode3MultiBattleBuffConfig.Type;
		_cache[itemData.Key] = value;
		return value;
	}

	public static bool IsCampBuff(this eMultiBattleBuffType type)
	{
		return type == eMultiBattleBuffType.AbilityOnCampBonus || type == eMultiBattleBuffType.ScoreOnCampBonus;
	}

	public static bool IsPlayerBuff(this eMultiBattleBuffType type)
	{
		return type == eMultiBattleBuffType.AbilityOnPlayerBonus || type == eMultiBattleBuffType.ScoreOnPlayerBonus;
	}
}
