using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class Chapter
{
	public const string Prologue1Id = "C1000";

	public const string Prologue2Id = "C10000";

	public const string Prologue3Id = "C10001";

	public const string Prologue4Id = "C10002";

	public const string LIVE001 = "Live1";

	public static HashSet<string> PrologueChapters = new HashSet<string> { "C1000", "C10000", "C10001", "C10002" };

	public static HashSet<string> First3Chapters = new HashSet<string> { "C1001", "C1002", "C1003" };

	public GDEChapterData Data;

	public string ChapterId;

	private Dictionary<int, Level> _Levels;

	public List<string> Level_IDs;

	public Dictionary<string, int> DoneBonus;

	public string Name;

	public string Desc;

	public string ImageUrl;

	public string Region;

	public float RecommendPower;

	public ChapterType Type;

	public bool Repeatable;

	public bool PreserveEnemy;

	public Levelship Levelship;

	public Chapter NextChapter;

	public Chapter PrevChapter;

	public Dictionary<int, Level> Levels
	{
		get
		{
			if (_Levels == null)
			{
				_Levels = new Dictionary<int, Level>();
			}
			for (int i = 0; i < Level_IDs.Count; i++)
			{
				if (!_Levels.ContainsKey(i))
				{
					GDELevelData data = GDMgr.Get<GDELevelData>(Level_IDs[i]);
					_Levels.Add(i, new Level(data));
				}
			}
			return _Levels;
		}
	}

	public Level GetLevels(int i)
	{
		if (i < 0)
		{
			return null;
		}
		if (i >= Level_IDs.Count)
		{
			return null;
		}
		if (_Levels == null)
		{
			_Levels = new Dictionary<int, Level>();
		}
		if (!_Levels.ContainsKey(i))
		{
			GDELevelData data = GDMgr.Get<GDELevelData>(Level_IDs[i]);
			_Levels.Add(i, new Level(data));
		}
		return _Levels[i];
	}

	public Chapter(GDEChapterData data, List<Level> levels = null)
	{
		Data = data;
		ChapterId = data.Key;
		Name = data.Name;
		Desc = data.Desc;
		ImageUrl = data.Image;
		Region = data.Region;
		RecommendPower = data.RecommendPower;
		Type = (ChapterType)data.Type;
		Repeatable = data.Repeatable;
		PreserveEnemy = data.PreserveEnemy;
		Levelship = (Levelship)data.Levelship;
		if (!string.IsNullOrEmpty(data.DoneBonus))
		{
			DoneBonus = JsonHelper.ToObject<Dictionary<string, int>>(data.DoneBonus);
		}
		Level_IDs = new List<string>();
		if (!string.IsNullOrEmpty(data.Levels))
		{
			Level_IDs = data.Levels.Split(',').ToList();
		}
	}

	public List<string> GetProgress(GameManagers managers)
	{
		return managers.UserArchiveManager.GetChapterLevelProgress(ChapterId);
	}
}
