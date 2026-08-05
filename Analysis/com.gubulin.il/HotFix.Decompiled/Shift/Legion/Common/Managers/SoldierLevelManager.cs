using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameDataEditor;
using GameMaths;

namespace Shift.Legion.Common.Managers;

public class SoldierLevelManager : Manager
{
	private static List<string> _expKeyList;

	private static List<int> _expValueList;

	public static readonly string[] ExpItems = new string[4] { "I40004", "I40005", "I40006", "I40007" };

	private static List<string> ExpKeyList
	{
		get
		{
			if (_expKeyList == null)
			{
				IEnumerable<GDESoldierExperienceData> allItems = GDMgr.GetAllItems<GDESoldierExperienceData>();
				_expKeyList = new List<string>();
				foreach (GDESoldierExperienceData item in allItems)
				{
					_expKeyList.Add(item.Key);
				}
			}
			return _expKeyList;
		}
	}

	public static List<int> ExpValueList
	{
		get
		{
			if (_expValueList == null)
			{
				_expValueList = new List<int>();
				_expValueList.Add(0);
				foreach (string expKey in ExpKeyList)
				{
					_expValueList.Add(GDMgr.Get<GDESoldierExperienceData>(expKey).Experience);
				}
			}
			return _expValueList;
		}
	}

	public SoldierLevelManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		return null;
	}

	public Action AddExperience(int exp, string soldierId, bool broadcastInform = true)
	{
		int level = Managers.UserArchiveManager.GetSoldierLevel(soldierId);
		int nextLevel = level + 1;
		int soldierExp = Managers.UserArchiveManager.GetSoldierExp(soldierId);
		int levelExp = GetLevelExp(nextLevel);
		exp = Mathf.RoundToInt((float)exp * (1f + Managers.ModifierManager.GetPercentFloatPayload("SoldierExpGain", 1)));
		if (levelExp != -1)
		{
			if (exp + soldierExp < levelExp)
			{
				Managers.UserArchiveManager.SetSoldierExp(soldierId, exp + soldierExp);
			}
			else
			{
				if (nextLevel <= Managers.UserArchiveManager.GetSoldierMaxLevel(soldierId))
				{
					int num = exp + soldierExp - levelExp;
					levelExp = GetLevelExp(nextLevel + 1);
					while (num >= levelExp)
					{
						if (nextLevel >= Managers.UserArchiveManager.GetSoldierMaxLevel(soldierId))
						{
							num = levelExp;
							break;
						}
						num -= levelExp;
						nextLevel++;
						levelExp = GetLevelExp(nextLevel + 1);
						if (levelExp < 0)
						{
							break;
						}
					}
					Managers.UserArchiveManager.SetSoldierExp(soldierId, num);
					Managers.UserArchiveManager.SetSoldierLevel(soldierId, nextLevel);
					if (broadcastInform)
					{
						SoldierLevelChanged();
					}
					return SoldierLevelChanged;
				}
				Managers.UserArchiveManager.SetSoldierExp(soldierId, levelExp);
			}
		}
		return null;
		void SoldierLevelChanged()
		{
			Managers.Messenger.Broadcast("SOLDIER_LEVEL_CHANGED", soldierId, level, nextLevel);
		}
	}

	public static int GetLevelExp(int level)
	{
		if (level > ExpValueList.Count)
		{
			return -1;
		}
		return ExpValueList[level - 1];
	}

	public static int GetLevelTotalExp(int level)
	{
		if (level > ExpValueList.Count)
		{
			return -1;
		}
		int num = 0;
		for (int i = 0; i < ExpValueList.Count && i <= level - 1; i++)
		{
			num += ExpValueList[i];
		}
		return num;
	}

	public static int GetMaxLevel()
	{
		return ExpValueList.Count;
	}
}
