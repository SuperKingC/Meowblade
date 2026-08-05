using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using GameDataEditor;
using GameMaths;
using HotFix;
using ObjectPool;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.LegendItemDungeon;
using UnityEngine;

public static class ClientBattleFieldLogic
{
	private static List<Coroutine> _list_Coroutine_ChangeDifferentBattleConfig;

	private static List<CoroutineWithData> _list_cd_IEnumerator_ChangeDifferentBattleConfig;

	public static int GetCurrentLevelIndex(Contexts contexts)
	{
		Level value = contexts.gameState.battleFieldLevel.value;
		if (!value.HasSubLevels())
		{
			return 0;
		}
		return contexts.gameState.hasBattleFieldSubLevelIndex ? contexts.gameState.battleFieldSubLevelIndex.value : 0;
	}

	public static void ClearUnits(List<GameEntity> entities, Team team = Team.None)
	{
		foreach (GameEntity entity in entities)
		{
			if (team == Team.None || !entity.hasTeam || entity.team.value == team)
			{
				entity.isVisible = false;
				entity.isDead = true;
				entity.isDestroyable = true;
			}
		}
	}

	public static void ClearUnitsByPortalId(List<GameEntity> entities, Team team, BattleConfig_Pos _pos)
	{
		foreach (GameEntity entity in entities)
		{
			if (entity.hasTeam && entity.team.value == team && entity.hasPortalId && entity.portalId.value == _pos.portalId)
			{
				entity.isVisible = false;
				entity.isDead = true;
				entity.isDestroyable = true;
			}
		}
	}

	public static void ChangeFormat(Contexts contexts, List<GameEntity> entities, BattleConfig config)
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		foreach (GameEntity entity in entities)
		{
			if (entity.hasTeam && entity.team.value == Team.Red && entity.hasPortalId)
			{
				int value = entity.portalId.value;
				GameEntityData gameEntityData = config.Units(0, value);
				config.UnitsBorn.TryGetValue(gameEntityData.Identifier, out var value2);
				int num = config.UnitsTotal[0, value];
				if (config.UnitsPool != null)
				{
					num = Math.Max(Math.Min(num, config.UnitsPool[gameEntityData.Identifier] - value2), 0);
				}
				Vector2 stagingPoint = contexts.Service<IStagingService>().GetStagingPoint(Team.Red, value, gameEntityData.Radius, entity.portalUnitIndex.value, num);
				entity.ReplacePosition(VectorHelper.ToVector3(stagingPoint, 0f));
			}
		}
	}

	public static Vector3 GetStagingAreaPositionsForTeam_ByIndex(Team team, int idx, float battleFieldLength, string formationId, float stagingAreaOffset)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		return GetStagingAreaPosition(team, idx, battleFieldLength, formationId, stagingAreaOffset);
	}

	public static Vector3[] GetStagingAreaPositionsForTeam(Team team, float battleFieldLength, string formationId, float stagingAreaOffset, Vector3[] buffer = null)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		if (buffer == null)
		{
			buffer = (Vector3[])(object)new Vector3[12];
		}
		for (int i = 0; i < 12; i++)
		{
			buffer[i] = GetStagingAreaPosition(team, i, battleFieldLength, formationId, stagingAreaOffset);
		}
		return buffer;
	}

	public static Vector2 GetStagingAreaSizesForTeam_ByIndex(Team team, string formationId, int idx, Vector2[] buffer = null)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return GetStagingAreaSize(team, idx, formationId);
	}

	public static Vector2[] GetStagingAreaSizesForTeam(Team team, string formationId, Vector2[] buffer = null)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (buffer == null)
		{
			buffer = (Vector2[])(object)new Vector2[12];
		}
		for (int i = 0; i < 12; i++)
		{
			buffer[i] = GetStagingAreaSize(team, i, formationId);
		}
		return buffer;
	}

	public static void UpdateSoldierStockWhenBattleEnd(GameManagers managers, Dictionary<string, int> unitsDead, string levelId = null)
	{
		if (unitsDead == null || unitsDead.Count < 1)
		{
			return;
		}
		string currentBattleId = managers.UserArchiveManager.GetCurrentBattleId();
		StockChangeRecord[] array = new StockChangeRecord[unitsDead.Count];
		int num = 0;
		GDELevelAssistanceData gDELevelAssistanceData = null;
		string key = "LevelAssistance_" + levelId;
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode() && !string.IsNullOrEmpty(levelId) && GDMgr.Has<GDELevelAssistanceData>(key))
		{
			gDELevelAssistanceData = GDMgr.Get<GDELevelAssistanceData>(key);
		}
		foreach (KeyValuePair<string, int> item in unitsDead)
		{
			GDESoldierData gDESoldierData = GDMgr.Get<GDESoldierData>(item.Key);
			if (gDESoldierData == null)
			{
				array[num++] = new StockChangeRecord
				{
					ItemId = string.Empty,
					Offset = 0,
					Context = 19,
					ContextValue = currentBattleId
				};
				continue;
			}
			if (gDELevelAssistanceData != null && gDELevelAssistanceData.EnableAssistance)
			{
				if (gDELevelAssistanceData.AssistanceSoldier.Contains(item.Key))
				{
					array[num++] = new StockChangeRecord
					{
						ItemId = string.Empty,
						Offset = 0,
						Context = 19,
						ContextValue = currentBattleId
					};
					continue;
				}
				bool flag = false;
				for (int i = 0; i < gDELevelAssistanceData.AssistanceSoldier.Count; i++)
				{
					string rootIdForSoldier = SoldierManager.GetRootIdForSoldier(gDELevelAssistanceData.AssistanceSoldier[i]);
					if (rootIdForSoldier == item.Key)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					array[num++] = new StockChangeRecord
					{
						ItemId = string.Empty,
						Offset = 0,
						Context = 19,
						ContextValue = currentBattleId
					};
					continue;
				}
			}
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = -item.Value,
				Context = 19,
				ContextValue = currentBattleId
			};
		}
		managers.StockController.ReadStockChangeRecords(array);
	}

	public static void UpdateSoldierStockWhenTreasureHuntBattleEnd(GameManagers managers, Dictionary<string, int> unitsDead)
	{
		int num = 0;
		for (int i = 0; i < LegendItemDungeonUiHelper.CurSoldiers.Count; i++)
		{
			KeyValuePair<string, int> keyValuePair = LegendItemDungeonUiHelper.CurSoldiers[i];
			string key = keyValuePair.Key;
			if (unitsDead.TryGetValue(key, out var value))
			{
				LegendItemDungeonUiHelper.CurSoldiers[i] = new KeyValuePair<string, int>(key, Math.Max(keyValuePair.Value - value, 0));
				num++;
				if (num >= unitsDead.Count)
				{
					break;
				}
			}
		}
	}

	public static bool HasSameUnitsBetweenBattleConfig(BattleConfig oldConfig, BattleConfig newConfig)
	{
		if (oldConfig == null || newConfig == null)
		{
			return false;
		}
		if (oldConfig.UnitsId.Count == 0 || newConfig.UnitsId.Count == 0)
		{
			return false;
		}
		List<string> list = oldConfig.UnitsId[0];
		List<string> list2 = newConfig.UnitsId[0];
		if (list.Count != list2.Count)
		{
			return false;
		}
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] != list2[i])
			{
				return false;
			}
		}
		return true;
	}

	public static List<BattleConfig_Pos> FindDifferentBetweenBattleConfig(BattleConfig _OldConfig, BattleConfig _NewConfig)
	{
		List<BattleConfig_Pos> list = new List<BattleConfig_Pos>();
		string text = string.Empty;
		if (_OldConfig.FormationId != null && _OldConfig.FormationId.Length >= 0)
		{
			text = _OldConfig.FormationId[0];
		}
		string text2 = string.Empty;
		if (_NewConfig.FormationId != null && _NewConfig.FormationId.Length >= 0)
		{
			text2 = _NewConfig.FormationId[0];
		}
		bool flag = text == text2;
		int num = 0;
		int num2 = 0;
		if (_NewConfig != null)
		{
			num = _NewConfig.UnitsId.Count;
			num2 = _NewConfig.UnitsId[0].Count;
		}
		int num3 = 0;
		int num4 = 0;
		if (_OldConfig != null)
		{
			num3 = _OldConfig.UnitsId.Count;
			num4 = _OldConfig.UnitsId[0].Count;
		}
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				if (i >= num3 || j > num4)
				{
					list.Add(new BattleConfig_Pos(i, j, _NewConfig.UnitsId[i][j]));
				}
				else if (_OldConfig.UnitsId[i][j] != _NewConfig.UnitsId[i][j])
				{
					list.Add(new BattleConfig_Pos(i, j, _NewConfig.UnitsId[i][j]));
				}
				else if (!flag && !string.IsNullOrEmpty(_NewConfig.UnitsId[i][j]))
				{
					list.Add(new BattleConfig_Pos(i, j, _NewConfig.UnitsId[i][j]));
				}
			}
		}
		return list;
	}

	public static void CleanChangeDifferentBattleConfig()
	{
		if (_list_Coroutine_ChangeDifferentBattleConfig == null)
		{
			_list_Coroutine_ChangeDifferentBattleConfig = new List<Coroutine>();
		}
		if (_list_cd_IEnumerator_ChangeDifferentBattleConfig == null)
		{
			_list_cd_IEnumerator_ChangeDifferentBattleConfig = new List<CoroutineWithData>();
		}
		foreach (CoroutineWithData item in _list_cd_IEnumerator_ChangeDifferentBattleConfig)
		{
			item.Stop();
		}
		_list_cd_IEnumerator_ChangeDifferentBattleConfig.Clear();
		foreach (Coroutine item2 in _list_Coroutine_ChangeDifferentBattleConfig)
		{
			FGUIManager.Instance.CloseIEnumerator(item2);
		}
		_list_Coroutine_ChangeDifferentBattleConfig.Clear();
	}

	public static void ChangeDifferentBattleConfig(Contexts contexts, Team team, BattleConfig_Pos _pos, int currentLevelIndex = 0)
	{
		_list_Coroutine_ChangeDifferentBattleConfig.Add(FGUIManager.Instance.OpenIEnumerator(IEnumerator_ChangeDifferentBattleConfig(contexts, team, _pos, currentLevelIndex)));
	}

	private static IEnumerator IEnumerator_ChangeDifferentBattleConfig(Contexts contexts, Team team, BattleConfig_Pos _pos, int currentLevelIndex = 0)
	{
		BattleConfig config = contexts.config.battleConfig.Red;
		UnitBornRecord[] bornRecords = new UnitBornRecord[12];
		if (config.UnitsBorn == null)
		{
			config.UnitsBorn = new Dictionary<string, int>();
		}
		GameEntityData entityData;
		for (entityData = config.Units(currentLevelIndex, _pos.portalId); entityData == null; entityData = contexts.config.battleConfig.Red.Units(currentLevelIndex, _pos.portalId))
		{
			yield return (object)new WaitForSeconds(0.1f);
			if (!contexts.config.hasBattleConfig)
			{
				yield break;
			}
		}
		if (entityData != null)
		{
			config.UnitsBorn.TryGetValue(entityData.Identifier, out var unitBorn);
			int num = config.UnitsTotal[currentLevelIndex, _pos.portalId];
			if (config.UnitsPool != null)
			{
				num = Math.Max(Math.Min(num, config.UnitsPool[entityData.Identifier] - unitBorn), 0);
			}
			CoroutineWithData _cd = new CoroutineWithData((MonoBehaviour)(object)FGUIManager.Instance, IEnumerator_CreateRedTeamSoldier(contexts, config.FormationId[currentLevelIndex], _pos.portalId, entityData, num, config.UnitsHp?[_pos.portalId]));
			_list_cd_IEnumerator_ChangeDifferentBattleConfig.Add(_cd);
			yield return _cd.Coroutine;
			int born = (int)_cd.Result;
			config.UnitsBorn[entityData.Identifier] = unitBorn + born;
			bornRecords[_pos.portalId] = new UnitBornRecord(entityData.Identifier, born);
			GameEntityData[] boss = config.Boss;
			if (((boss != null) ? boss[currentLevelIndex] : null) != null)
			{
				CreateBoss(contexts, Team.Red, config.Boss[currentLevelIndex]);
			}
			GameStateContext gameState = contexts.gameState;
			if (!gameState.isCurrentLevelBattleStarted)
			{
				gameState.ReplaceRefreshTeamHealthPointsTotal(team);
				float redHpCurrent = 1f;
				float redHpTotal = 1f;
				float blueHpCurrent = 1f;
				float blueHpTotal = 1f;
				gameState.ReplaceTeamHealthPointsTotal(redHpCurrent, redHpTotal, blueHpCurrent, blueHpTotal);
			}
		}
	}

	public static void Staging(Contexts contexts, Team team = Team.None, int currentLevelIndex = 0)
	{
		FGUIManager.Instance.OpenIEnumerator(IEnumerator_Staging(contexts, team, currentLevelIndex));
	}

	private static IEnumerator IEnumerator_Staging(Contexts contexts, Team team = Team.None, int currentLevelIndex = 0)
	{
		GameStateContext gameState = contexts.gameState;
		int soldier_create_cnt = 0;
		if (team == Team.None || team == Team.Red)
		{
			UnitBornRecord[] bornRecords = new UnitBornRecord[12];
			BattleConfig config = contexts.config.battleConfig.Red;
			for (int i = 0; i < 5; i++)
			{
				if (config.IsUnitRefreshed)
				{
					break;
				}
				yield return null;
			}
			if (config.UnitsBorn == null)
			{
				config.UnitsBorn = new Dictionary<string, int>();
			}
			for (int portalId = 0; portalId < 12; portalId++)
			{
				GameEntityData entityData = config.Units(currentLevelIndex, portalId);
				if (entityData != null)
				{
					config.UnitsBorn.TryGetValue(entityData.Identifier, out var unitBorn);
					int num = config.UnitsTotal[currentLevelIndex, portalId];
					if (config.UnitsPool != null)
					{
						num = Math.Max(Math.Min(num, config.UnitsPool[entityData.Identifier] - unitBorn), 0);
					}
					soldier_create_cnt += num;
					CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)FGUIManager.Instance, IEnumerator_CreateRedTeamSoldier(contexts, config.FormationId[currentLevelIndex], portalId, entityData, num, config.UnitsHp?[portalId], 3));
					yield return cd.Coroutine;
					int born = (int)cd.Result;
					config.UnitsBorn[entityData.Identifier] = unitBorn + born;
					bornRecords[portalId] = new UnitBornRecord(entityData.Identifier, born);
				}
			}
			GameEntityData[] boss = config.Boss;
			if (((boss != null) ? boss[currentLevelIndex] : null) != null)
			{
				CreateBoss(contexts, Team.Red, config.Boss[currentLevelIndex]);
			}
			yield return null;
		}
		yield return null;
		if (team == Team.None || team == Team.Blue)
		{
			UnitBornRecord[] bornRecords2 = new UnitBornRecord[12];
			BattleConfig config2 = contexts.config.battleConfig.Blue;
			for (int j = 0; j < 5; j++)
			{
				if (config2.IsUnitRefreshed)
				{
					break;
				}
				yield return null;
			}
			if (config2.UnitsBorn == null)
			{
				config2.UnitsBorn = new Dictionary<string, int>();
			}
			for (int k = 0; k < 12; k++)
			{
				GameEntityData entityData2 = config2.Units(currentLevelIndex, k);
				if (entityData2 != null)
				{
					int num2 = config2.UnitsTotal[currentLevelIndex, k];
					soldier_create_cnt += num2;
					CoroutineWithData cd2 = new CoroutineWithData((MonoBehaviour)(object)FGUIManager.Instance, IEnumerator_CreateBlueTeamSoldier(contexts, config2.FormationId[currentLevelIndex], k, entityData2, num2, config2.UnitsHp?[k], 3));
					yield return cd2.Coroutine;
					int born2 = (int)cd2.Result;
					if (config2.UnitsBorn.ContainsKey(entityData2.Identifier))
					{
						config2.UnitsBorn[entityData2.Identifier] += born2;
					}
					else
					{
						config2.UnitsBorn.Add(entityData2.Identifier, born2);
					}
					bornRecords2[k] = new UnitBornRecord(entityData2.Identifier, born2);
					yield return null;
				}
			}
			GameEntityData[] boss2 = config2.Boss;
			if (((boss2 != null) ? boss2[currentLevelIndex] : null) != null)
			{
				CreateBoss(contexts, Team.Blue, config2.Boss[currentLevelIndex]);
			}
			yield return null;
		}
		if (!gameState.isCurrentLevelBattleStarted)
		{
			gameState.ReplaceRefreshTeamHealthPointsTotal(team);
			float redHpCurrent = 1f;
			float redHpTotal = 1f;
			float blueHpCurrent = 1f;
			float blueHpTotal = 1f;
			gameState.ReplaceTeamHealthPointsTotal(redHpCurrent, redHpTotal, blueHpCurrent, blueHpTotal);
		}
		yield return (object)new WaitForSeconds(1f);
		gameState.ReplaceLoadingProgress(100);
	}

	private static IEnumerator IEnumerator_CreateRedTeamSoldier(Contexts contexts, string formationId, int portalId, GameEntityData entityData, int total, List<float> unitsHp, int skip = 1)
	{
		int born = 0;
		float radius = GetStagingAreaVisionRadius(Team.Red, portalId, formationId);
		for (int portalUnitIndex = 0; portalUnitIndex < total; portalUnitIndex++)
		{
			GameEntity entity = contexts.Service<ICreateUnitService>().CreateSoldier(-1, entityData, Team.Red, portalId, portalUnitIndex, total, radius);
			if (portalUnitIndex % skip == 1)
			{
				yield return null;
			}
			if (entity != null)
			{
				born++;
			}
		}
		yield return born;
	}

	private static int CreateRedTeamSoldier(Contexts contexts, string formationId, int portalId, GameEntityData entityData, int total, List<float> unitsHp)
	{
		int num = 0;
		float stagingAreaVisionRadius = GetStagingAreaVisionRadius(Team.Red, portalId, formationId);
		for (int i = 0; i < total; i++)
		{
			GameEntity gameEntity = contexts.Service<ICreateUnitService>().CreateSoldier(-1, entityData, Team.Red, portalId, i, total, stagingAreaVisionRadius);
			if (gameEntity != null)
			{
				num++;
			}
		}
		return num;
	}

	private static void CreateBoss(Contexts contexts, Team team, GameEntityData entityData)
	{
		contexts.Service<ICreateUnitService>().CreateSoldier(-1, entityData, team, -1, 0, 1, 0f);
	}

	private static IEnumerator IEnumerator_CreateBlueTeamSoldier(Contexts contexts, string formationId, int portalId, GameEntityData entityData, int total, List<float> unitsHp, int skip = 1)
	{
		int born = 0;
		float radius = GetStagingAreaVisionRadius(Team.Blue, portalId, formationId);
		for (int portalUnitIndex = 0; portalUnitIndex < total; portalUnitIndex++)
		{
			if (unitsHp == null || (portalUnitIndex < unitsHp.Count && !(unitsHp[portalUnitIndex] <= 0f)))
			{
				GameEntity entity = contexts.Service<ICreateUnitService>().CreateSoldier(-1, entityData, Team.Blue, portalId, portalUnitIndex, total, radius);
				if (portalUnitIndex % skip == 1)
				{
					yield return null;
				}
				if (entity != null)
				{
					born++;
				}
			}
		}
		yield return born;
	}

	private static int CreateBlueTeamSoldier(Contexts contexts, string formationId, int portalId, GameEntityData entityData, int total, List<float> unitsHp)
	{
		int num = 0;
		float stagingAreaVisionRadius = GetStagingAreaVisionRadius(Team.Blue, portalId, formationId);
		for (int i = 0; i < total; i++)
		{
			if (unitsHp == null || (i < unitsHp.Count && !(unitsHp[i] <= 0f)))
			{
				GameEntity gameEntity = contexts.Service<ICreateUnitService>().CreateSoldier(-1, entityData, Team.Blue, portalId, i, total, stagingAreaVisionRadius);
				if (gameEntity != null)
				{
					num++;
				}
			}
		}
		return num;
	}

	public static void CreateObstacles(Contexts contexts, Team team, Obstacle[] obstacles)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		if (obstacles == null || obstacles.Length == 0)
		{
			return;
		}
		Vector3 campPosition = GetCampPosition(team, contexts.config.battleConfig.BattleFieldLength);
		foreach (Obstacle obstacle in obstacles)
		{
			if (obstacle == null || string.IsNullOrEmpty(obstacle.UnitId))
			{
				continue;
			}
			GameEntityData entityData = GameEntityData.GetEntityData(null, obstacle.UnitId);
			Vector3 val = VectorHelper.ToVector3(obstacle.Position + obstacle.Size / 2f, 0f) + new Vector3(contexts.config.stagingAreaOffset.value, 0f, 0f);
			Vector3 position = ((team != Team.Red) ? (campPosition - val) : (campPosition + val));
			GameEntity gameEntity = contexts.Service<ICreateUnitService>().CreateSoldier(-1, entityData, team, position, 0f);
			gameEntity.isAiObject = false;
			gameEntity.isBuildingUnit = true;
			gameEntity.ReplaceUnitScale(0.01f);
			int width = Mathf.CeilToInt(obstacle.Size.x / 0.4f);
			int height = Mathf.CeilToInt(obstacle.Size.y / 0.4f);
			int num = width * height;
			if (num <= 1)
			{
				continue;
			}
			gameEntity.ReplaceGroupUnits(ObjectPool<PooledList<int>>.Spawn((Func<PooledList<int>>)(() => new PooledList<int>(width * height))));
			gameEntity.ReplaceModel("entangling_roots");
			gameEntity.ReplaceSkin("default");
			for (int num2 = 0; num2 < width; num2++)
			{
				for (int num3 = 0; num3 < height; num3++)
				{
					Vector3 position2 = campPosition + VectorHelper.ToVector3(obstacle.Position + new Vector2(((float)num2 + 0.5f) * 0.4f, ((float)num3 + 0.5f) * 0.4f), 0f) + new Vector3(contexts.config.stagingAreaOffset.value, 0f, 0f);
					if (team == Team.Blue)
					{
						position2 = campPosition - VectorHelper.ToVector3(obstacle.Position + new Vector2(((float)num2 + 0.5f) * 0.4f, ((float)num3 + 0.5f) * 0.4f), 0f) - new Vector3(contexts.config.stagingAreaOffset.value, 0f, 0f);
					}
					GameEntity gameEntity2 = contexts.Service<ICreateUnitService>().CreateSoldier(-1, entityData, team, position2, 0f);
					gameEntity2.isUnit = false;
					gameEntity2.isGameObject = true;
					gameEntity2.isAiObject = false;
					gameEntity2.isBuildingUnit = true;
					((List<int>)(object)gameEntity.groupUnits.value).Add(gameEntity2.id.value);
				}
			}
		}
	}

	public static void ClearAllObstacles(Contexts contexts)
	{
		IGroup<GameEntity> val = ((Context<GameEntity>)contexts.game).GetGroup(GameMatcher.BuildingUnit);
		GameEntity[] entities = val.GetEntities();
		GameEntity[] array = entities;
		foreach (GameEntity gameEntity in array)
		{
			if (gameEntity.isBuildingUnit)
			{
				gameEntity.isDestroyable = true;
			}
		}
	}

	public static Vector3 GetStagingAreaPosition(Team team, int index, float battleFieldLength, string formationId, float stagingAreaOffset)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		int num = ((team == Team.Red) ? 1 : (-1));
		Vector3 campPosition = GetCampPosition(team, battleFieldLength);
		GDEFormationData formation = FormationManager.GetFormation(formationId);
		Vector2 val = FormationManager.SlotPositionOfFormation(formation, index);
		return new Vector3(campPosition.x + (float)num * (stagingAreaOffset + val.x), campPosition.y, campPosition.z + val.y);
	}

	public static Vector2 GetStagingAreaSize(Team team, int index, string formationId)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		GDEFormationData formation = FormationManager.GetFormation(formationId);
		return FormationManager.SlotSizeOfFormation(formation, index);
	}

	public static float GetStagingAreaVisionRadius(Team team, int index, string formationId)
	{
		GDEFormationData formation = FormationManager.GetFormation(formationId);
		return FormationManager.SlotVisionRadiusOfFormation(formation, index);
	}

	public static Vector3 GetCampPosition(Team team, float battleFieldLength)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		if (team == Team.Red)
		{
			return new Vector3((0f - battleFieldLength) / 2f + 2.48f + Const.BattleFieldOffset.x, 0f, Const.BattleFieldOffset.y);
		}
		return new Vector3(battleFieldLength / 2f - 2.48f + Const.BattleFieldOffset.x, 0f, Const.BattleFieldOffset.y);
	}

	public static void SetBattleFieldCameraMoveLimit(Contexts contexts)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		Vector3 newSize = default(Vector3);
		((Vector3)(ref newSize))._002Ector(contexts.gameState.battleFieldLength.value / 2f, 0f, 5.4f);
		Vector3 cameraPositionForScene = contexts.Service<ICameraService>().GetCameraPositionForScene("BattleField");
		cameraPositionForScene.x = 0f;
		contexts.gameState.ReplaceCameraMoveLimit(cameraPositionForScene, newSize);
	}

	public static void StartBattle(Contexts contexts, string battleId)
	{
		Level value = contexts.gameState.battleFieldLevel.value;
		Chapter chapter = value.Chapter;
		if (value.ParentLevel == null && chapter != null && (chapter.Type == ChapterType.StoryMain || chapter.Type == ChapterType.StorySub))
		{
			GameManagers.Instance.UserArchiveManager.SetCurrentLevelId(value.LevelId);
		}
		if (!value.HasSubLevels() || (contexts.gameState.hasBattleFieldSubLevelIndex && contexts.gameState.battleFieldSubLevelIndex.value == 0))
		{
			if (!contexts.gameState.hasBattleProgressStats)
			{
				contexts.gameState.ReplaceBattleProgressStats(new List<Bonus>(), 0);
			}
			BattleProgressStatsComponent battleProgressStats = contexts.gameState.battleProgressStats;
			battleProgressStats.clearStages = 0;
			battleProgressStats.bonusRecord.Clear();
		}
		Dictionary<string, int> battleCostOfLevel = GameManagers.Instance.ActivityManager.GetBattleCostOfLevel(value);
		if (battleCostOfLevel != null)
		{
			StockChangeRecord[] array = new StockChangeRecord[battleCostOfLevel.Count];
			int num = 0;
			foreach (KeyValuePair<string, int> item in battleCostOfLevel)
			{
				array[num++] = new StockChangeRecord
				{
					ItemId = item.Key,
					Offset = -item.Value,
					Context = 6,
					ContextValue = battleId
				};
			}
			GameManagers.Instance.StockController.ReadStockChangeRecords(array);
		}
		GameManagers.Instance.Messenger.Broadcast("BATTLE_START", value);
	}

	public static void StartBattle(Contexts contexts, string battleId, Level currentLevel)
	{
		if (!contexts.gameState.hasBattleProgressStats)
		{
			contexts.gameState.ReplaceBattleProgressStats(new List<Bonus>(), 0);
		}
		if (!currentLevel.HasSubLevels() || (contexts.gameState.hasBattleFieldSubLevelIndex && contexts.gameState.battleFieldSubLevelIndex.value == 0))
		{
			BattleProgressStatsComponent battleProgressStats = contexts.gameState.battleProgressStats;
			battleProgressStats.clearStages = 0;
			battleProgressStats.bonusRecord.Clear();
		}
		Dictionary<string, int> battleCostOfLevel = GameManagers.Instance.ActivityManager.GetBattleCostOfLevel(currentLevel);
		if (battleCostOfLevel != null)
		{
			StockChangeRecord[] array = new StockChangeRecord[battleCostOfLevel.Count];
			int num = 0;
			foreach (KeyValuePair<string, int> item in battleCostOfLevel)
			{
				array[num++] = new StockChangeRecord
				{
					ItemId = item.Key,
					Offset = -item.Value,
					Context = 6,
					ContextValue = battleId
				};
			}
			GameManagers.Instance.StockController.ReadStockChangeRecords(array);
		}
		GameManagers.Instance.Messenger.Broadcast("SPECIAL_LEVEL_BATTLE_START", currentLevel);
	}
}
