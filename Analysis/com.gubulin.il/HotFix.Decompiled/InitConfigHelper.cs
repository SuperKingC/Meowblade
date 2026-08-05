using System;
using System.Collections.Generic;
using GameMaths;
using ObjectPool;

public class InitConfigHelper
{
	public static void Init(ConfigContext config)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		config.isLoadViewFromResources = true;
		config.ReplaceHealBarSwitcher(newValue: true);
		config.ReplaceBattleDebugSwitcher(newValue: true);
		config.ReplaceUnitNumber(10);
		config.ReplaceBaseVisionRadius(1000);
		config.ReplaceStartFightingDistance(1000);
		config.ReplaceTheSpeedOfMarchingOn(2f);
		config.ReplaceStagingAreaOffset(3f);
		config.ReplaceStagingAreaSize(new Vector2(3.5f, 3.5f));
		config.ReplaceCurrentFormation(new Dictionary<string, Dictionary<string, string>>
		{
			{
				"StoryMain",
				new Dictionary<string, string>
				{
					{ "RushMode", "F01" },
					{ "MultiWaveAttackMode", "F01" },
					{ "DefenceMode", "FFB_01" }
				}
			},
			{
				"RepeatableInstance",
				new Dictionary<string, string>
				{
					{ "RushMode", "F01" },
					{ "MultiWaveAttackMode", "F01" },
					{ "DefenceMode", "FFB_01" }
				}
			}
		});
		config.ReplaceFormationUnits((Dictionary<string, Dictionary<string, List<string>>>)(object)ObjectPool<PooledDictionary<string, Dictionary<string, List<string>>>>.Spawn((Func<PooledDictionary<string, Dictionary<string, List<string>>>>)(() => new PooledDictionary<string, Dictionary<string, List<string>>>())));
		config.ReplaceAgentConfig(6, 0.75f, 0.5f, 0.5f);
		config.ReplaceRvoTimeStep(0.25f);
		config.ReplaceDefenceModeMeleeVisionRadius(0f);
		config.ReplaceDefenceModeRangedVisionRadius(0f);
	}

	private static bool GetConfigValue<T>(Dictionary<string, object> jsonConfig, string key, out T value)
	{
		if (jsonConfig.TryGetValue(key, out var value2))
		{
			value = (T)Convert.ChangeType(value2, typeof(T));
			return true;
		}
		value = default(T);
		return false;
	}
}
