using System;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class UserExpData
{
	public readonly GDEUserExperienceData Data;

	public readonly int Level;

	public readonly int Exp;

	public readonly List<Bonus> BonusList;

	public readonly List<Modifier> ModifierList;

	public readonly Dictionary<string, Dictionary<string, object>> UiUnlock;

	public readonly List<string> UnlockedUiList;

	public readonly Dictionary<string, int> BuildingMaxLevel;

	public readonly Dictionary<string, int> ItemMaxLevel;

	public readonly int SoldierMaxStars;

	public readonly int SoldierMaxEvoLevel;

	public readonly int FormationSlots;

	public readonly int InvitingSlots;

	public readonly List<string> DescList;

	public readonly List<string> IconList;

	public readonly List<string> TagList;

	private readonly GameManagers _managers;

	public Dictionary<string, Modifier> allPrevModifiers;

	public static Action<int, string, string, string> CreateChangeCurrentFormationUnitCommand;

	public Dictionary<string, Modifier> AllPrevModifiers
	{
		get
		{
			if (allPrevModifiers == null)
			{
				allPrevModifiers = new Dictionary<string, Modifier>();
				if (_managers.ConfigDataManager.UserExpData.TryGetValue(Level - 1, out var value))
				{
					foreach (Modifier value2 in value.AllPrevModifiers.Values)
					{
						allPrevModifiers.Add(value2.ModifierId, value2);
					}
					foreach (Modifier modifier in value.ModifierList)
					{
						if (allPrevModifiers.ContainsKey(modifier.ModifierId))
						{
							allPrevModifiers[modifier.ModifierId] = modifier;
						}
						else
						{
							allPrevModifiers.Add(modifier.ModifierId, modifier);
						}
					}
				}
			}
			return allPrevModifiers;
		}
	}

	public UserExpData(GameManagers managers, GDEUserExperienceData data)
	{
		_managers = managers;
		Data = data;
		Level = data.Level;
		Exp = data.Exp;
		BonusList = new List<Bonus>();
		if (!string.IsNullOrEmpty(data.Bonus))
		{
			foreach (KeyValuePair<string, int> item2 in JsonHelper.ToObject<Dictionary<string, int>>(data.Bonus))
			{
				BonusList.Add(Bonus.Get(item2.Key, item2.Value));
			}
		}
		ModifierList = new List<Modifier>();
		if (!string.IsNullOrEmpty(data.Modifier))
		{
			foreach (KeyValuePair<string, Dictionary<string, object>> item3 in JsonHelper.ToObject<Dictionary<string, Dictionary<string, object>>>(data.Modifier))
			{
				Modifier item = new Modifier(_managers, item3.Key, item3.Value);
				ModifierList.Add(item);
			}
		}
		UnlockedUiList = new List<string>();
		UiUnlock = new Dictionary<string, Dictionary<string, object>>();
		if (!string.IsNullOrEmpty(data.UIUnlock))
		{
			foreach (KeyValuePair<string, Dictionary<string, object>> item4 in JsonHelper.ToObject<Dictionary<string, Dictionary<string, object>>>(data.UIUnlock))
			{
				UiUnlock.Add(item4.Key, item4.Value);
			}
			foreach (KeyValuePair<string, Dictionary<string, object>> item5 in UiUnlock)
			{
			}
		}
		BuildingMaxLevel = new Dictionary<string, int>();
		if (!string.IsNullOrEmpty(data.BuildingMaxLevel))
		{
			foreach (KeyValuePair<string, int> item6 in JsonHelper.ToObject<Dictionary<string, int>>(data.BuildingMaxLevel))
			{
				BuildingMaxLevel.Add(item6.Key, item6.Value);
			}
		}
		ItemMaxLevel = new Dictionary<string, int>();
		if (!string.IsNullOrEmpty(data.ItemMaxLevel))
		{
			foreach (KeyValuePair<string, int> item7 in JsonHelper.ToObject<Dictionary<string, int>>(data.ItemMaxLevel))
			{
				if (item7.Key == "CollectableResource")
				{
					foreach (string collectableItem in Item.CollectableItemList)
					{
						ItemMaxLevel.Add(collectableItem, item7.Value);
					}
				}
				else
				{
					ItemMaxLevel.Add(item7.Key, item7.Value);
				}
			}
		}
		SoldierMaxStars = data.SoldierMaxStars;
		SoldierMaxEvoLevel = data.SoldierMaxEvoLevel;
		FormationSlots = data.FormationSlots;
		InvitingSlots = data.InvitingSlots;
		DescList = data.Desc;
		IconList = data.Icon;
		TagList = data.Tag;
	}

	public static void LevelUpTo(GameManagers managers, int newLevel)
	{
		if (!managers.ConfigDataManager.UserExpData.TryGetValue(newLevel, out var value))
		{
			return;
		}
		foreach (Bonus bonus in value.BonusList)
		{
			bonus.Claim(managers);
		}
		foreach (Modifier modifier in value.ModifierList)
		{
			if (value.AllPrevModifiers.TryGetValue(modifier.ModifierId, out var value2))
			{
				managers.ModifierManager.ReadFromModifier(value2, -1);
			}
			managers.ModifierManager.ReadFromModifier(modifier);
		}
		foreach (KeyValuePair<string, int> item in value.BuildingMaxLevel)
		{
			managers.UserArchiveManager.SetBuildingMaxLevel(item.Key, item.Value);
		}
		foreach (KeyValuePair<string, int> item2 in value.ItemMaxLevel)
		{
			managers.UserArchiveManager.SetItemMaxLevel(item2.Key, item2.Value);
		}
		if (value.SoldierMaxEvoLevel > 0)
		{
		}
		if (value.SoldierMaxStars > 0)
		{
		}
		if (value.FormationSlots <= 0)
		{
			return;
		}
		string text = ChapterType.StoryMain.ToString();
		string text2 = BattleMode.RushMode.ToString();
		List<string> list = managers.UserArchiveManager.GetBattleFormation(text, text2).Values.ToList();
		for (int i = 0; i < value.FormationSlots; i++)
		{
			if (list[i] == "Lock")
			{
				managers.FormationUnitsManager.ChangeFormationUnit(text, text2, i, "Unlock");
				CreateChangeCurrentFormationUnitCommand(i, "Unlock", text, text2);
			}
		}
	}
}
