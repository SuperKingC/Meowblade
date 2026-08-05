using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class SceneBattleFieldArguments : SceneArguments
{
	public const string LevelIdKey = "LevelId";

	public const string LevelInstKey = "LevelInst";

	public const string BattleCostKey = "BattleCostKey";

	public string LevelId
	{
		get
		{
			return (string)Data["LevelId"];
		}
		set
		{
			Data["LevelId"] = value;
		}
	}

	public Level LevelInst
	{
		get
		{
			if (Data.TryGetValue("LevelInst", out var value))
			{
				return (Level)value;
			}
			return null;
		}
		set
		{
			Data["LevelInst"] = value;
		}
	}

	public Dictionary<string, int> BattleCost
	{
		get
		{
			if (Data.TryGetValue("BattleCostKey", out var value))
			{
				return (Dictionary<string, int>)value;
			}
			return null;
		}
		set
		{
			Data["BattleCostKey"] = value;
		}
	}

	public SceneBattleFieldArguments(Dictionary<string, object> dic)
		: base(dic)
	{
	}
}
