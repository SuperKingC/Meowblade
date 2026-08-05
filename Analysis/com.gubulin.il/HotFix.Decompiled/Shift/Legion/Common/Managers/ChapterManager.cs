using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class ChapterManager : Manager
{
	public static class Levels
	{
		public static bool TryGetValue(string key, out Level level)
		{
			if (_levels == null)
			{
				_levels = new Dictionary<string, Level>();
			}
			if (!_levels.ContainsKey(key))
			{
				GDELevelData gDELevelData = GDMgr.Get<GDELevelData>(key);
				if (gDELevelData == null)
				{
					level = null;
					ILRuntimeDebug.LogError("LogError Levels.TryGetValue key={0}", key);
					return false;
				}
				level = new Level(gDELevelData);
				_levels.Add(key, level);
			}
			level = _levels[key];
			return true;
		}
	}

	private const string LevelProgressStatsKey = "LevelProgressStats";

	private Config<LevelProgressConfig> _levelProgressStats;

	private static Dictionary<string, Chapter> _chapters;

	private static Dictionary<string, Chapter> _mainStoryChapters;

	private static Dictionary<string, Level> _levels;

	private static Dictionary<string, List<Chapter>> _regionChaptersDict;

	public Config<LevelProgressConfig> LevelProgressStats
	{
		get
		{
			if (_levelProgressStats == null)
			{
				UserArchiveManager userArchiveManager = Managers.UserArchiveManager;
				if (userArchiveManager.Contains("LevelProgressStats"))
				{
					_levelProgressStats = userArchiveManager.GetConfig<LevelProgressConfig>("LevelProgressStats");
				}
				else
				{
					DateTimeOffset dailyRefreshTime = DateTimeHelper.GetDailyRefreshTime(DateTimeHelper.Now, DateTimeHelper.TimezoneOffset, DateTimeHelper.RefreshHours);
					userArchiveManager.SetConfigValue("LevelProgressStats", new LevelProgressConfig(dailyRefreshTime));
					_levelProgressStats = userArchiveManager.GetConfig<LevelProgressConfig>("LevelProgressStats");
				}
			}
			return _levelProgressStats;
		}
	}

	public static Dictionary<string, Chapter> Chapters
	{
		get
		{
			if (_chapters == null)
			{
				LoadChapters();
			}
			return _chapters;
		}
	}

	public static Dictionary<string, Chapter> MainStoryChapters
	{
		get
		{
			if (_mainStoryChapters == null)
			{
				LoadChapters();
			}
			return _mainStoryChapters;
		}
	}

	public static Dictionary<string, List<Chapter>> RegionChaptersDict
	{
		get
		{
			if (_regionChaptersDict == null)
			{
				_regionChaptersDict = new Dictionary<string, List<Chapter>>();
				foreach (GDEChapterData allItem in GDMgr.GetAllItems<GDEChapterData>())
				{
					Chapter item = Chapters[allItem.Key];
					if (!_regionChaptersDict.ContainsKey(allItem.Region))
					{
						_regionChaptersDict.Add(allItem.Region, new List<Chapter>());
					}
					_regionChaptersDict[allItem.Region].Add(item);
				}
			}
			return _regionChaptersDict;
		}
	}

	public int GetTotalClearStagesByActivity(string activityId)
	{
		LevelProgressConfig value = LevelProgressStats.GetValue();
		Dictionary<string, int> value2;
		return value.ClearStageStats.TryGetValue(activityId, out value2) ? value2.Sum((KeyValuePair<string, int> kv) => kv.Value) : 0;
	}

	public int GetTotalClearStagesUntilLastCheckByActivity(string activityId)
	{
		LevelProgressConfig value = LevelProgressStats.GetValue();
		Dictionary<string, int> value2;
		return value.ClearStageStatsUntilLastCheck.TryGetValue(activityId, out value2) ? value2.Sum((KeyValuePair<string, int> kv) => kv.Value) : 0;
	}

	private static void LoadChapters()
	{
		_chapters = new Dictionary<string, Chapter>();
		_mainStoryChapters = new Dictionary<string, Chapter>();
		foreach (GDEChapterData allItem in GDMgr.GetAllItems<GDEChapterData>())
		{
			Chapter chapter = new Chapter(allItem);
			_chapters.Add(chapter.ChapterId, chapter);
			if (chapter.Type == ChapterType.StoryMain)
			{
				_mainStoryChapters.Add(chapter.ChapterId, chapter);
			}
		}
		foreach (string key in _chapters.Keys)
		{
			Chapter chapter2 = _chapters[key];
			if (!string.IsNullOrEmpty(chapter2.Data.NextChapter) && _chapters.TryGetValue(chapter2.Data.NextChapter, out var value))
			{
				chapter2.NextChapter = value;
				value.PrevChapter = chapter2;
			}
		}
	}

	public ChapterManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		return null;
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<Level>("LEVEL_BONUS_CLAIMED", OnLevelComplete);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<Level>("LEVEL_BONUS_CLAIMED", OnLevelComplete);
	}

	public List<string> GetChapterLevel_IDs(string chapterId)
	{
		if (Chapters.TryGetValue(chapterId, out var value))
		{
			return value.Level_IDs;
		}
		return null;
	}

	public Chapter GetChapter(string chapterId)
	{
		if (Chapters.TryGetValue(chapterId, out var value))
		{
			return value;
		}
		return null;
	}

	public Chapter GetNextChapter(string currentChapterId)
	{
		if (Chapters.TryGetValue(currentChapterId, out var value))
		{
			return value.NextChapter;
		}
		return null;
	}

	public Chapter GetPreviousChapter(string currentChapterId)
	{
		if (Chapters.TryGetValue(currentChapterId, out var value))
		{
			return value.PrevChapter;
		}
		return null;
	}

	public Level GetLevelInstance(string levelId)
	{
		Levels.TryGetValue(levelId, out var level);
		return level;
	}

	public bool IsChapterDone(string chapterId)
	{
		List<string> chapterLevelProgress = Managers.UserArchiveManager.GetChapterLevelProgress(chapterId);
		return (GetChapterLevel_IDs(chapterId)?.Count ?? 0) <= chapterLevelProgress.Count;
	}

	public void OnLevelComplete(Level level)
	{
		Chapters.TryGetValue(level.ChapterId, out var value);
		if (value == null)
		{
		}
		if (value != null && value.Type == ChapterType.StoryMain)
		{
			Managers.UserArchiveManager.SetCurrentLevelId(GetNextLevelIdOfLevel(level));
		}
	}

	public static string GetNextLevelIdOfLevel(Level level)
	{
		if (level.Chapter == null || level.Chapter.Levelship != Levelship.Default)
		{
			return null;
		}
		bool flag = false;
		string result = null;
		foreach (string level_ID in level.Chapter.Level_IDs)
		{
			if (flag)
			{
				result = level_ID;
				break;
			}
			if (level_ID == level.LevelId)
			{
				flag = true;
			}
		}
		return result;
	}

	public void StatsInstanceLevel(string activityId, string levelId)
	{
		LevelProgressConfig value = LevelProgressStats.GetValue();
		if (!value.ClearStageStats.TryGetValue(activityId, out var value2))
		{
			value2 = new Dictionary<string, int>();
			value.ClearStageStats.Add(activityId, value2);
		}
		if (value2.ContainsKey(levelId))
		{
			value2[levelId]++;
		}
		else
		{
			value2.Add(levelId, 1);
		}
		LevelProgressStats.Save();
	}

	public void StatsInstanceLevel(string activityId, string levelId, int completeNum)
	{
		LevelProgressConfig value = LevelProgressStats.GetValue();
		if (!value.ClearStageStats.TryGetValue(activityId, out var value2))
		{
			value2 = new Dictionary<string, int>();
			value.ClearStageStats.Add(activityId, value2);
		}
		if (value2.ContainsKey(levelId))
		{
			value2[levelId] += completeNum;
		}
		else
		{
			value2.Add(levelId, completeNum);
		}
		LevelProgressStats.Save();
	}
}
