using System.Collections;
using System.Collections.Generic;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class Cache_PrinceRedDot : CacheBaseBehavior
{
	public static string ON_REDDOT_CHANGE = typeof(Cache_PrinceRedDot).Name;

	public static string ON_PAGE_REDDOT_CHANGE = typeof(Cache_PrinceRedDot).Name + "Page";

	private Dictionary<AchievementCat, Dictionary<AchievementType, List<Achievement>>> _PageAchievements;

	private Dictionary<AchievementCat, bool> _PageRedDots;

	private bool _IsShowRedDot;

	public bool IsShowRedDot
	{
		get
		{
			return _IsShowRedDot;
		}
		set
		{
			if (value != _IsShowRedDot)
			{
				_IsShowRedDot = value;
				SharedMessenger.Broadcast(ON_REDDOT_CHANGE, this);
			}
		}
	}

	public override IEnumerator Init()
	{
		_PageAchievements = new Dictionary<AchievementCat, Dictionary<AchievementType, List<Achievement>>>();
		_PageRedDots = new Dictionary<AchievementCat, bool>();
		base.DelayUpdateFromNow = 2f;
		TimeInterval = 2f;
		_IsShowRedDot = false;
		yield return null;
		List<AchievementCat> pageNames = new List<AchievementCat>
		{
			AchievementCat.Lord,
			AchievementCat.Dungeon,
			AchievementCat.Legion,
			AchievementCat.Region,
			AchievementCat.Technology,
			AchievementCat.Item
		};
		foreach (AchievementCat name in pageNames)
		{
			if (!_PageAchievements.ContainsKey(name))
			{
				_PageAchievements.Add(name, new Dictionary<AchievementType, List<Achievement>>());
			}
			List<Achievement> achievementList = AchievementManager.GetAchievementsByCategory(name);
			if (achievementList.Count > 0)
			{
				foreach (Achievement achievement in achievementList)
				{
					if (!_PageAchievements[name].ContainsKey(achievement.Type))
					{
						_PageAchievements[name].Add(achievement.Type, new List<Achievement>());
					}
					_PageAchievements[name][achievement.Type].Add(achievement);
				}
			}
			_PageRedDots.Add(name, value: false);
			yield return null;
		}
	}

	public override void DeferredUpdate()
	{
		bool isShowRedDot = false;
		bool flag = false;
		foreach (KeyValuePair<AchievementCat, Dictionary<AchievementType, List<Achievement>>> pageAchievement in _PageAchievements)
		{
			bool flag2 = false;
			foreach (KeyValuePair<AchievementType, List<Achievement>> item in pageAchievement.Value)
			{
				foreach (Achievement item2 in item.Value)
				{
					switch (item2.Status(GameManagers.Instance))
					{
					case AchievementStatus.PendingToClaim:
						isShowRedDot = true;
						flag2 = true;
						break;
					case AchievementStatus.Ongoing:
						break;
					default:
						continue;
					}
					break;
				}
				if (flag2)
				{
					break;
				}
			}
			if (_PageRedDots[pageAchievement.Key] != flag2)
			{
				_PageRedDots[pageAchievement.Key] = flag2;
				flag = true;
			}
		}
		IsShowRedDot = isShowRedDot;
		IsUpdateEnabled = false;
		if (flag)
		{
			SharedMessenger.Broadcast(ON_PAGE_REDDOT_CHANGE, this);
		}
	}

	public override void OnAllCachesInit()
	{
		SharedMessenger.AddListener<List<Achievement>>("ACHIEVEMENT_COMPLETE", OnAchivementComplete);
		SharedMessenger.AddListener<string>("ACHIEVEMENT_BONUS_CLAIMED", OnAchivementClaimed);
	}

	private void OnAchivementComplete(List<Achievement> achievements)
	{
		foreach (Achievement achievement in achievements)
		{
			if (_PageAchievements.ContainsKey(achievement.Category))
			{
				IsUpdateEnabled = true;
				base.DelayUpdateFromNow = 0.5f;
				break;
			}
		}
	}

	private void OnAchivementClaimed(string achievementId)
	{
		if (AchievementManager.Achievements.TryGetValue(achievementId, out var value) && _PageAchievements.ContainsKey(value.Category))
		{
			IsUpdateEnabled = true;
			base.DelayUpdateFromNow = 0.5f;
		}
	}

	public bool HasPageRedDot(AchievementCat pageName)
	{
		if (_PageRedDots.TryGetValue(pageName, out var value))
		{
			return value;
		}
		return false;
	}
}
