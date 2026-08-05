using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using GameMaths;
using Shift.Legion.Common.Models;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Dungeon
{
	private const string DungeonLevelKey = "DUNGEON_LEVEL";

	private const string DungeonExpKey = "DUNGEON_EXP";

	public static int GetDungeonLevel(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<int>("DUNGEON_LEVEL");
	}

	public static bool DungeonIsLevelMax(this UserArchiveManager manager)
	{
		int key = manager.GetDungeonLevel() + 1;
		DungeonExpData value;
		return !manager.Managers.ConfigDataManager.DungeonExpData.TryGetValue(key, out value);
	}

	public static Action DungeonLevelUp(this UserArchiveManager manager, bool broadcastInform = true)
	{
		int nextLevel = manager.GetDungeonLevel() + 1;
		manager.SetConfigValue("DUNGEON_LEVEL", nextLevel);
		DungeonExpData.LevelUpTo(manager.Managers, nextLevel);
		if (broadcastInform)
		{
			LevelUp();
		}
		return LevelUp;
		void LevelUp()
		{
			manager.Managers.Messenger.Broadcast("DUNGEON_LEVEL_UP", nextLevel);
		}
	}

	public static int GetDungeonExp(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<int>("DUNGEON_EXP");
	}

	public static Action DungeonGainExp(this UserArchiveManager manager, int exp, bool broadcastInform = true)
	{
		exp = Mathf.RoundToInt((float)exp * (1f + manager.Managers.ModifierManager.GetPercentFloatPayload("DungeonExpGain")));
		int num = manager.GetDungeonExp() + exp;
		manager.SetConfigValue("DUNGEON_EXP", num);
		Action action = delegate
		{
			manager.Managers.Messenger.Broadcast("DUNGEON_GAIN_EXP", exp);
			SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("{0}+{1}", LanguagesManager.GetDesc("CsharpCodeZhTcText799"), exp) }, 121, arg3: false);
		};
		if (broadcastInform)
		{
			action();
		}
		while (num >= manager.Managers.ConfigDataManager.GetDungeonNextLevelExp())
		{
			Action action2 = manager.DungeonLevelUp(broadcastInform);
			if (broadcastInform)
			{
				action2();
			}
			action = (Action)Delegate.Combine(action, action2);
		}
		return action;
	}
}
