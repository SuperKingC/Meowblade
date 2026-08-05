using System.Collections.Generic;
using System.Text.RegularExpressions;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.Common.Managers;

namespace UI.Battle;

public class GuideMode5SpecialLevel
{
	public int LevelIndex;

	public string LevelId;

	public Dictionary<string, int> Rewards;

	private static List<GuideMode5SpecialLevel> _cache;

	public static List<GuideMode5SpecialLevel> GetConfig()
	{
		if (_cache != null)
		{
			return _cache;
		}
		_cache = new List<GuideMode5SpecialLevel>();
		string configKey = "GuideModeSpecialLevels5";
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() || GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6())
		{
			configKey = "GuideModeSpecialLevels6";
		}
		else if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode7())
		{
			configKey = "GuideModeSpecialLevels7";
		}
		Dictionary<string, Dictionary<string, int>> dictionary = configKey.ToConfiguration<Dictionary<string, Dictionary<string, int>>>();
		foreach (KeyValuePair<string, Dictionary<string, int>> item2 in dictionary)
		{
			Match match = Regex.Match(item2.Key, "\\d+");
			int levelIndex = int.Parse(match.Value);
			GuideMode5SpecialLevel item = new GuideMode5SpecialLevel
			{
				LevelId = item2.Key,
				LevelIndex = levelIndex,
				Rewards = item2.Value
			};
			_cache.Add(item);
		}
		_cache.Sort((GuideMode5SpecialLevel a, GuideMode5SpecialLevel b) => a.LevelIndex.CompareTo(b.LevelIndex));
		return _cache;
	}
}
