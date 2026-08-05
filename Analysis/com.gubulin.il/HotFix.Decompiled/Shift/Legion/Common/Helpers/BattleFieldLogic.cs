using System;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using GameMaths;
using ObjectPool;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using UI.LegendItemDungeon;

namespace Shift.Legion.Common.Helpers;

public class BattleFieldLogic
{
	public static bool LimitPosition(float battleFieldLength, ref Vector3 pos, float radius = 0f, float xMargin = 0f)
	{
		bool result = false;
		float num = battleFieldLength / 2f - radius - xMargin;
		float num2 = 5.35f;
		if (pos.x > num)
		{
			pos.x = num;
			result = true;
		}
		else if (pos.x < 0f - num)
		{
			pos.x = 0f - num;
			result = true;
		}
		if (pos.z > num2)
		{
			pos.z = num2;
			result = true;
		}
		else if (pos.z < 0f - num2)
		{
			pos.z = 0f - num2;
			result = true;
		}
		return result;
	}

	public static void UpdateFormationUnits(GameManagers managers, Level level, Team team, BattleConfig battleConfig)
	{
		int num = ((!level.HasSubLevels()) ? 1 : level.SubLevels.Count);
		battleConfig.UnitsId = new List<List<string>>();
		battleConfig.CombatPowerModifier = new List<List<float>>();
		for (int i = 0; i < num; i++)
		{
			List<string> list = new List<string>();
			List<float> list2 = new List<float>();
			for (int j = 0; j < 12; j++)
			{
				list.Add(string.Empty);
				list2.Add(1f);
			}
			battleConfig.UnitsId.Add(list);
			battleConfig.CombatPowerModifier.Add(list2);
		}
		battleConfig.UnitsTotal = new int[num, 12];
		battleConfig.BossId = new string[num];
		battleConfig.FormationId = new string[num];
		battleConfig.Obstacles = GetObstacles(team, level);
		AddLevelToBattleConfig(managers, battleConfig, level, team, delegate
		{
			battleConfig.RefreshUnits(managers, Team.None, delegate
			{
				if (team != Team.Red)
				{
					battleConfig.UnitsHp = managers.UserArchiveManager.GetLevelEnemiesHp(level);
				}
			});
		});
	}

	public static void UpdateFormationUnits(GameManagers managers, Level level, Team team, BattleConfig battleConfig, Action action)
	{
		int num = ((!level.HasSubLevels()) ? 1 : level.SubLevels.Count);
		battleConfig.UnitsId = new List<List<string>>();
		battleConfig.CombatPowerModifier = new List<List<float>>();
		for (int i = 0; i < num; i++)
		{
			List<string> list = new List<string>();
			List<float> list2 = new List<float>();
			for (int j = 0; j < 12; j++)
			{
				list.Add(string.Empty);
				list2.Add(1f);
			}
			battleConfig.UnitsId.Add(list);
			battleConfig.CombatPowerModifier.Add(list2);
		}
		battleConfig.UnitsTotal = new int[num, 12];
		battleConfig.BossId = new string[num];
		battleConfig.FormationId = new string[num];
		battleConfig.Obstacles = GetObstacles(team, level);
		AddLevelToBattleConfig(managers, battleConfig, level, team, delegate
		{
			battleConfig.RefreshUnits(managers, Team.None, delegate
			{
				if (team == Team.Red)
				{
					action();
				}
				else
				{
					battleConfig.UnitsHp = managers.UserArchiveManager.GetLevelEnemiesHp(level);
					action();
				}
			});
		});
	}

	private static void AddLevelToBattleConfig(GameManagers managers, BattleConfig config, Level level, Team team, Action action)
	{
		if (level == null)
		{
			ILRuntimeDebug.LogError("AddLevelToBattleConfig level is null");
		}
		if (level.Data == null)
		{
			ILRuntimeDebug.LogError("AddLevelToBattleConfig level.Data is null");
		}
		if (config == null)
		{
			ILRuntimeDebug.LogError("AddLevelToBattleConfig config is null");
		}
		config.BattleMode = (BattleMode)((team == Team.Red) ? level.Data.RedTeamBattleMode : level.Data.BlueTeamBattleMode);
		string text = ((team == Team.Red) ? level.Data.RedTeamBoss : level.Data.BlueTeamBoss);
		if (string.IsNullOrEmpty(text))
		{
			text = null;
		}
		bool flag = level.HasSubLevels();
		List<string> levels = (flag ? level.SubLevels : new List<string> { level.LevelId });
		if (levels == null)
		{
			ILRuntimeDebug.LogError("AddLevelToBattleConfig levels is null");
		}
		Activity activity = null;
		activity = managers.ActivityManager.GetLevelActivity(levels[0]);
		for (int i = 0; i < levels.Count; i++)
		{
			Level level2 = null;
			if (activity != null && activity.Type == ActivityType.TreasureHunt)
			{
				level2 = level;
			}
			else
			{
				ChapterManager.Levels.TryGetValue(levels[i], out level2);
			}
			if (level2 == null)
			{
				ILRuntimeDebug.LogError("AddLevelToBattleConfig _checkingLevel is null");
			}
			if (team == Team.Red)
			{
				config.FormationId[i] = level2.Data.RedFormationId;
				if (string.IsNullOrEmpty(config.FormationId[i]))
				{
					string context = ((activity == null) ? level2.FormationContext : activity.FormationTag);
					config.FormationId[i] = managers.UserArchiveManager.GetCurrentFormation(context, level2.BattleMode.ToString());
				}
			}
			else
			{
				if (level2.EnemyTemplate == null)
				{
					if (!string.IsNullOrEmpty(level2.FromEnemyTemplatePool) && level.EnemyTemplate != null)
					{
						managers.ActivityManager.FlushLevelActivityCache();
						activity = managers.ActivityManager.GetLevelActivity(levels[0]);
						if (activity == null)
						{
							ILRuntimeDebug.LogError("AddLevelToBattleConfig 清理缓存后重新获取关卡" + level2.LevelId + "对应的活动失败");
						}
						else if (activity.Type != ActivityType.TreasureHunt)
						{
							ILRuntimeDebug.LogError($"AddLevelToBattleConfig 清理缓存后成功获取到关卡{level2.LevelId}对应的活动{activity.ActivityId}，但是活动类型为{activity.Type}");
						}
						if (activity != null && activity.Type == ActivityType.TreasureHunt)
						{
							level2 = level;
						}
					}
					if (level2.EnemyTemplate == null)
					{
						ILRuntimeDebug.LogError(string.Format("AddLevelToBattleConfig 获取关卡{0}敌方阵容失败, CheckingLevel.FromEnemyTemplatePool={1}, Level.FromEnemyTemplatePool={2}, ActivityId={3}, level.EnemyTemplate is null ? {4}", level2.LevelId, level2.FromEnemyTemplatePool, level.EnemyTemplate, (activity == null) ? "null" : activity.ActivityId, level.EnemyTemplate == null));
					}
				}
				config.FormationId[i] = level2.EnemyTemplate.FormationId;
			}
			GetLevelUnitsConfig(managers, config, level2, team, activity, out var unitsId, out var unitsTotal);
			for (int j = 0; j < unitsId.Length; j++)
			{
				config.UnitsId[i][j] = unitsId[j];
				config.UnitsTotal[i, j] = unitsTotal[j];
			}
			string text2 = ((team == Team.Red) ? level2.Data.RedTeamBoss : level2.Data.BlueTeamBoss);
			if (!string.IsNullOrEmpty(text2))
			{
				config.BossId[i] = text2;
			}
			else
			{
				config.BossId[i] = text;
			}
		}
		if (level.DynamicEnemy && team == Team.Blue)
		{
			float basePowerMod = (flag ? level.EnemyPowerModifier : 1f);
			LegionPowerConfig value = managers.SoldierManager.LegionPowerConfig.GetValue();
			Dictionary<string, int> formationInfo = value.FormationInfo;
			bool flag2 = false;
			if (formationInfo.Count < 5)
			{
				flag2 = true;
				foreach (KeyValuePair<string, int> item in formationInfo)
				{
					string key = item.Key;
					if (managers.UserArchiveManager.GetSoldierLevel(key) > 10)
					{
						flag2 = false;
						break;
					}
				}
			}
			float playerLegionCombatPower = (flag2 ? 11350f : ((float)value.MaxPower));
			config.RefreshUnits(managers, Team.None, delegate
			{
				if (config == null)
				{
					ILRuntimeDebug.LogError("AddLevelToBattleConfig config is null, After RefreshUnits");
				}
				int[] array = config.CombatPower.ToArray();
				if (activity != null && activity.Type == ActivityType.TreasureHunt)
				{
					for (int k = 0; k < levels.Count; k++)
					{
						ChapterManager.Levels.TryGetValue(levels[k], out var level3);
						int count = config.CombatPowerModifier[k].Count;
						List<int> list = new List<int>();
						for (int l = 0; l < count; l++)
						{
							string text3 = config.UnitsId[k][l];
							if (!string.IsNullOrEmpty(text3) && text3 != "Lock" && text3 != "Unlock")
							{
								list.Add(l);
							}
						}
						float num = playerLegionCombatPower / (float)list.Count;
						foreach (int item2 in list)
						{
							GameEntityData gameEntityData = config.Units(k, item2);
							if (gameEntityData != null)
							{
								config.CombatPowerModifier[k][item2] = basePowerMod * level3.EnemyPowerModifier * num / (float)(gameEntityData.CombatPower * config.UnitsTotal[k, item2]);
								gameEntityData.CombatPowerModifier = config.CombatPowerModifier[k][item2];
							}
						}
					}
				}
				else
				{
					int num2 = 0;
					if (num2 < levels.Count)
					{
						ChapterManager.Levels.TryGetValue(levels[num2], out var level4);
						int num3 = array[num2];
						float value2 = basePowerMod * level4.EnemyPowerModifier * playerLegionCombatPower / (float)num3;
						for (int m = 0; m < config.UnitsId[num2].Count; m++)
						{
							GameEntityData gameEntityData2 = config.Units(num2, m);
							if (gameEntityData2 != null)
							{
								config.CombatPowerModifier[num2][m] = value2;
								gameEntityData2.CombatPowerModifier = config.CombatPowerModifier[num2][m];
							}
						}
					}
				}
				action();
			});
		}
		else
		{
			action();
		}
	}

	private static void GetLevelUnitsConfig(GameManagers managers, BattleConfig config, Level level, Team team, Activity activityOfLevel, out string[] unitsId, out int[] unitsTotal)
	{
		unitsId = new string[12];
		unitsTotal = new int[12];
		switch (team)
		{
		case Team.Red:
		{
			Activity levelActivity = managers.ActivityManager.GetLevelActivity(level);
			string context = ((levelActivity == null) ? level.FormationContext : levelActivity.FormationTag);
			string subContext = level.BattleMode.ToString();
			Dictionary<string, string> battleFormation = managers.UserArchiveManager.GetBattleFormation(context, subContext);
			int num3 = 0;
			foreach (string value2 in battleFormation.Values)
			{
				if (string.IsNullOrEmpty(value2) || value2 == "Lock" || value2 == "Unlock")
				{
					num3++;
					continue;
				}
				unitsId[num3] = value2;
				num3++;
			}
			Dictionary<string, int> unitsPool = config.UnitsPool;
			Dictionary<string, int> unitsBorn = config.UnitsBorn;
			GDELevelAssistanceData gDELevelAssistanceData = null;
			string key = "LevelAssistance_" + level.LevelId;
			if (GDMgr.Has<GDELevelAssistanceData>(key))
			{
				gDELevelAssistanceData = GDMgr.Get<GDELevelAssistanceData>(key);
			}
			PooledDictionary<string, int> val = ObjectPool<PooledDictionary<string, int>>.Spawn((Func<PooledDictionary<string, int>>)(() => new PooledDictionary<string, int>()));
			for (int num4 = 0; num4 < unitsId.Length; num4++)
			{
				if (unitsId[num4] == null)
				{
					continue;
				}
				string text = unitsId[num4];
				int soldierLevel = managers.UserArchiveManager.GetSoldierLevel(text);
				int soldierFormationNumber = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(text, soldierLevel);
				if (!((Dictionary<string, int>)(object)val).ContainsKey(text))
				{
					((Dictionary<string, int>)(object)val).Add(text, 0);
				}
				int num5 = ((Dictionary<string, int>)(object)val)[text];
				if (gDELevelAssistanceData != null && GameManagers.Instance.UserArchiveManager.IsNewGuideMode() && gDELevelAssistanceData.AssistancePosition.Contains(num4 + 1) && gDELevelAssistanceData.EnableAssistance)
				{
					int num6 = 1;
					int num7 = gDELevelAssistanceData.AssistanceSoldier.IndexOf(text);
					if (num7 > -1)
					{
						num6 = gDELevelAssistanceData.AssistanceQty[num7];
					}
					unitsTotal[num4] = num6;
					num5 += unitsTotal[num4];
					((Dictionary<string, int>)(object)val)[text] = num5;
					continue;
				}
				int num8 = 0;
				if (levelActivity != null && levelActivity.Type == ActivityType.TreasureHunt)
				{
					foreach (KeyValuePair<string, int> curSoldier in LegendItemDungeonUiHelper.CurSoldiers)
					{
						if (curSoldier.Key == text)
						{
							num8 = curSoldier.Value;
							break;
						}
					}
				}
				else
				{
					num8 = managers.StockController.GetStock(text);
				}
				num8 -= num5;
				if (unitsPool != null && unitsPool.TryGetValue(text, out var value))
				{
					if (unitsBorn != null && unitsBorn.ContainsKey(text))
					{
						value -= unitsBorn[text];
					}
					num8 = value - num5;
				}
				unitsTotal[num4] = Math.Min(soldierFormationNumber, Math.Max(0, num8));
				num5 += unitsTotal[num4];
				((Dictionary<string, int>)(object)val)[text] = num5;
			}
			break;
		}
		case Team.Blue:
		{
			List<int> playerMaxPowerfulLegionLevelsInfo = LegionHelper.GetPlayerMaxPowerfulLegionLevelsInfo(managers);
			int num = 0;
			for (int i = 0; i < unitsId.Length; i++)
			{
				GetEnemyConfigByPortal(level.EnemyTemplate, i, out var enemyId, out var num2);
				if (string.IsNullOrEmpty(enemyId))
				{
					continue;
				}
				if (level.DynamicEnemy && playerMaxPowerfulLegionLevelsInfo != null)
				{
					if (managers.SoldierManager.Get(enemyId).Tags.Contains("IS_BOSS"))
					{
						num2 = 1;
					}
					else
					{
						int level2 = ((num < playerMaxPowerfulLegionLevelsInfo.Count) ? playerMaxPowerfulLegionLevelsInfo[num] : playerMaxPowerfulLegionLevelsInfo.Last());
						num2 = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(enemyId, level2);
					}
				}
				unitsId[i] = enemyId;
				unitsTotal[i] = num2;
				num++;
			}
			break;
		}
		}
	}

	public static Obstacle[] GetObstacles(Team team, Level level)
	{
		if (level.Data.RedTeamBattleMode == 1 && team != Team.Red)
		{
			return null;
		}
		if (level.Data.BlueTeamBattleMode == 1 && team != Team.Blue)
		{
			return null;
		}
		GetObstaclesOfLevel(level, out var obstacles);
		if (obstacles.Length == 0)
		{
			return null;
		}
		return obstacles;
	}

	private static void GetEnemyConfigByPortal(EnemyTemplate enemyTemplate, int portalIndex, out string enemyId, out int num)
	{
		switch (portalIndex)
		{
		case 0:
			enemyId = enemyTemplate.Enemy1;
			num = enemyTemplate.Number1;
			break;
		case 1:
			enemyId = enemyTemplate.Enemy2;
			num = enemyTemplate.Number2;
			break;
		case 2:
			enemyId = enemyTemplate.Enemy3;
			num = enemyTemplate.Number3;
			break;
		case 3:
			enemyId = enemyTemplate.Enemy4;
			num = enemyTemplate.Number4;
			break;
		case 4:
			enemyId = enemyTemplate.Enemy5;
			num = enemyTemplate.Number5;
			break;
		case 5:
			enemyId = enemyTemplate.Enemy6;
			num = enemyTemplate.Number6;
			break;
		case 6:
			enemyId = enemyTemplate.Enemy7;
			num = enemyTemplate.Number7;
			break;
		case 7:
			enemyId = enemyTemplate.Enemy8;
			num = enemyTemplate.Number8;
			break;
		case 8:
			enemyId = enemyTemplate.Enemy9;
			num = enemyTemplate.Number9;
			break;
		case 9:
			enemyId = enemyTemplate.Enemy10;
			num = enemyTemplate.Number10;
			break;
		case 10:
			enemyId = enemyTemplate.Enemy11;
			num = enemyTemplate.Number11;
			break;
		case 11:
			enemyId = enemyTemplate.Enemy12;
			num = enemyTemplate.Number12;
			break;
		default:
			enemyId = enemyTemplate.Enemy1;
			num = enemyTemplate.Number1;
			break;
		}
	}

	private static void GetObstaclesOfLevel(Level level, out Obstacle[] obstacles)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		string[] array = level.Data.Obstacles.Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
		obstacles = new Obstacle[array.Length];
		Vector2 position = default(Vector2);
		Vector2 size = default(Vector2);
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			string[] array2 = text.Split(',');
			if (array2.Length == 5)
			{
				NumericParser.TryFloat(array2[0], out var value);
				NumericParser.TryFloat(array2[1], out var value2);
				NumericParser.TryFloat(array2[2], out var value3);
				NumericParser.TryFloat(array2[3], out var value4);
				string unitId = array2[4];
				((Vector2)(ref position))._002Ector(value, value2);
				((Vector2)(ref size))._002Ector(value3, value4);
				obstacles[i] = new Obstacle
				{
					Position = position,
					Size = size,
					UnitId = unitId
				};
			}
		}
	}
}
