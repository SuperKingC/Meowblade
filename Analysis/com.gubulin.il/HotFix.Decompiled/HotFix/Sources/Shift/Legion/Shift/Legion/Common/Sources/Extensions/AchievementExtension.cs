using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;

public static class AchievementExtension
{
	private const string _TARGET_COMPLETE = "1";

	private const string _TARGET_NOT_COMPLETE = "0";

	public static string GetProgressCurrentValue(this Achievement achievement)
	{
		return achievement.Type switch
		{
			AchievementType.PvPRank => achievement.VerifyTarget(GameManagers.Instance) ? "1" : "0", 
			AchievementType.GvGRareStone => achievement.VerifyTarget(GameManagers.Instance) ? $"{achievement.TargetValue}" : $"{achievement.CurrentValue(GameManagers.Instance)}", 
			_ => $"{achievement.CurrentValue(GameManagers.Instance): 0.#}", 
		};
	}

	public static string GetProgressTargetValue(this Achievement achievement)
	{
		AchievementType type = achievement.Type;
		AchievementType achievementType = type;
		if (achievementType == AchievementType.PvPRank)
		{
			return "1";
		}
		return $"{achievement.TargetValue: 0.#}";
	}
}
