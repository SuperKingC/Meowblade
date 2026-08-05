using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class Region
{
	public readonly GDERegionData Data;

	public readonly Dictionary<string, object> PrefabConfig;

	public readonly List<Chapter> Chapters;

	public readonly List<Stronghold> Strongholds;

	public readonly Dictionary<string, object> UnlockBonuses;

	public string RegionId => Data.Key;

	public string Desc => Data.Desc;

	public Region(GDERegionData data)
	{
		Data = data;
		if (!string.IsNullOrEmpty(data.PrefabConfig))
		{
			PrefabConfig = JsonHelper.ToObject<Dictionary<string, object>>(data.PrefabConfig);
		}
		if (!string.IsNullOrEmpty(data.UnlockBonuses))
		{
			UnlockBonuses = JsonHelper.ToObject<Dictionary<string, object>>(data.UnlockBonuses);
		}
		ChapterManager.RegionChaptersDict.TryGetValue(data.Key, out Chapters);
		if (Chapters == null)
		{
			Chapters = new List<Chapter>();
		}
		Strongholds = new List<Stronghold>();
	}

	public RegionStatus Status(GameManagers managers)
	{
		if (WorldMapManager.Cache_RegionStatus.ContainsKey(RegionId))
		{
			return WorldMapManager.Cache_RegionStatus[RegionId];
		}
		float num = RegionProgress(managers);
		RegionStatus regionStatus;
		if (num >= 1f)
		{
			string levelId = CurrentLevelId(managers);
			regionStatus = ((!managers.UserArchiveManager.IsLevelClaimed(levelId)) ? RegionStatus.Battling : RegionStatus.Occupied);
		}
		else if (num > 0f || managers.UserArchiveManager.CheckRegionUnlockBonusesClaimed(RegionId))
		{
			regionStatus = RegionStatus.Battling;
		}
		else
		{
			Region prevRegion = WorldMapManager.GetPrevRegion(RegionId);
			if (prevRegion != null)
			{
				regionStatus = ((prevRegion.Status(managers) == RegionStatus.Occupied) ? RegionStatus.Unlocked : RegionStatus.Locked);
			}
			else if (Chapters.Count < 1)
			{
				regionStatus = RegionStatus.Locked;
			}
			else
			{
				Chapter chapter = Chapters[0].PrevChapter;
				if (managers.UserArchiveManager.IsNewGuideMode2() || managers.UserArchiveManager.IsNewGuideForeignMode2())
				{
					chapter = managers.ChapterManager.GetChapter("C10000");
				}
				else if (managers.UserArchiveManager.IsNewGuideMode3() || managers.UserArchiveManager.IsNewGuideForeignMode3())
				{
					chapter = managers.ChapterManager.GetChapter("C10001");
				}
				else if (managers.UserArchiveManager.IsNewGuideMode4() || managers.UserArchiveManager.IsNewGuideMode5() || managers.UserArchiveManager.IsNewGuideMode6() || managers.UserArchiveManager.IsNewGuideForeignMode4() || managers.UserArchiveManager.IsNewGuideForeignMode5() || managers.UserArchiveManager.IsNewGuideForeignMode6())
				{
					chapter = managers.ChapterManager.GetChapter("C1000");
				}
				else if (managers.UserArchiveManager.IsNewGuideMode7())
				{
					chapter = managers.ChapterManager.GetChapter("C10002");
				}
				else if (managers.UserArchiveManager.IsNewGuideMode() || managers.UserArchiveManager.IsNewGuideForeignMode())
				{
					chapter = managers.ChapterManager.GetChapter("C1000");
				}
				regionStatus = ((chapter != null && chapter.GetProgress(managers).Count >= chapter.Level_IDs.Count) ? RegionStatus.Unlocked : RegionStatus.Locked);
			}
		}
		WorldMapManager.Cache_RegionStatus[RegionId] = regionStatus;
		return regionStatus;
	}

	public float RegionProgress(GameManagers managers)
	{
		int num = 0;
		int num2 = 0;
		bool flag = true;
		if (Chapters.Count > 0)
		{
			flag = false;
			foreach (Chapter chapter in Chapters)
			{
				if (chapter.Type == ChapterType.StoryMain)
				{
					num += chapter.Level_IDs.Count;
					num2 += chapter.GetProgress(managers).Count;
				}
			}
		}
		if (flag)
		{
			return 0f;
		}
		if (num == 0)
		{
			return 1f;
		}
		return (float)num2 / (float)num;
	}

	public bool IsStrongholdsEnabled(GameManagers managers)
	{
		return Status(managers) == RegionStatus.Occupied;
	}

	public Dictionary<string, float> AutoProductions(GameManagers managers)
	{
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		foreach (Chapter chapter in Chapters)
		{
			List<string> progress = chapter.GetProgress(managers);
			foreach (Level value in chapter.Levels.Values)
			{
				if (!progress.Contains(value.LevelId))
				{
					continue;
				}
				foreach (KeyValuePair<string, float> item in value.FormattedAutoProduceBonus(managers))
				{
					if (dictionary.ContainsKey(item.Key))
					{
						dictionary[item.Key] += item.Value;
					}
					else
					{
						dictionary.Add(item.Key, item.Value);
					}
				}
			}
		}
		return dictionary;
	}

	public Dictionary<string, float> OccupiedProductions(GameManagers managers)
	{
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		if (!IsStrongholdsEnabled(managers))
		{
			return dictionary;
		}
		foreach (Stronghold stronghold in Strongholds)
		{
			StrongholdConfig strongholdStatus = managers.UserArchiveManager.GetStrongholdStatus(stronghold.StrongholdId);
			if (strongholdStatus.Occupant == null)
			{
				continue;
			}
			foreach (KeyValuePair<string, float> production in strongholdStatus.Productions)
			{
				if (dictionary.ContainsKey(production.Key))
				{
					dictionary[production.Key] += production.Value * stronghold.Efficiency(managers);
				}
				else
				{
					dictionary.Add(production.Key, production.Value * stronghold.Efficiency(managers));
				}
			}
		}
		return dictionary;
	}

	public List<Bonus> ClaimUnlockBonuses(GameManagers managers)
	{
		List<Bonus> list = new List<Bonus>();
		if (Status(managers) == RegionStatus.Unlocked && !managers.UserArchiveManager.CheckRegionUnlockBonusesClaimed(RegionId))
		{
			if (UnlockBonuses != null)
			{
				foreach (KeyValuePair<string, object> unlockBonuse in UnlockBonuses)
				{
					Bonus bonus = Bonus.Get(unlockBonuse.Key, unlockBonuse.Value);
					bonus.Claim(managers);
					list.Add(bonus);
				}
			}
			managers.UserArchiveManager.RecordRegionUnlockBonuses(RegionId);
		}
		return list;
	}

	public string CurrentLevelId(GameManagers managers)
	{
		Dictionary<string, List<string>> levelProgress = managers.UserArchiveManager.GetLevelProgress();
		int num = 0;
		Chapter chapter = null;
		foreach (Chapter chapter3 in Chapters)
		{
			if (!levelProgress.ContainsKey(chapter3.ChapterId))
			{
				break;
			}
			chapter = chapter3;
			num++;
		}
		if (chapter == null || chapter.Level_IDs.Count < 1)
		{
			for (int i = num; i < Chapters?.Count; i++)
			{
				Chapter chapter2 = Chapters[i];
				if (chapter2.Level_IDs.Count > 0)
				{
					chapter = chapter2;
				}
			}
		}
		if (chapter == null || chapter.Level_IDs.Count < 1)
		{
			return null;
		}
		if (levelProgress.TryGetValue(chapter.ChapterId, out var value) && value.Count > 0)
		{
			return value.Last();
		}
		return chapter.Level_IDs.First();
	}
}
