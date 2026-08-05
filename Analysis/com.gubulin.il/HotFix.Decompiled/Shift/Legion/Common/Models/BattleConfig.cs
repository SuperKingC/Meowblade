using System;
using System.Collections;
using System.Collections.Generic;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class BattleConfig
{
	public bool isRefresh = false;

	public float BossDamageMultiplier;

	public Dictionary<string, int> UnitsPool;

	public Dictionary<string, int> UnitsBorn;

	public List<List<string>> _unitsId;

	public bool IsUnitRefreshed = true;

	public List<List<GameEntityData>> _units;

	private string[] _bossId;

	private GameEntityData[] _boss;

	public int[,] UnitsTotal;

	public List<List<float>> UnitsHp;

	public BattleMode BattleMode;

	public List<List<float>> CombatPowerModifier;

	public string[] FormationId;

	public Obstacle[] Obstacles;

	public List<List<string>> UnitsId
	{
		get
		{
			return _unitsId;
		}
		set
		{
			_unitsId = value;
			_units = null;
		}
	}

	public string[] BossId
	{
		get
		{
			return _bossId;
		}
		set
		{
			_bossId = value;
			_boss = null;
		}
	}

	public GameEntityData[] Boss => _boss;

	public int[] CombatPower
	{
		get
		{
			int count = UnitsId.Count;
			int[] array = new int[count];
			int count2 = UnitsId[0].Count;
			for (int i = 0; i < count; i++)
			{
				int num = 0;
				for (int j = 0; j < count2; j++)
				{
					if (Units(i, j) != null)
					{
						num += _units[i][j].CombatPower * UnitsTotal[i, j];
					}
				}
				array[i] = num;
			}
			return array;
		}
	}

	public GameEntityData Units(int row, int col)
	{
		if (_units == null)
		{
			return null;
		}
		if (_units.Count <= row)
		{
			return null;
		}
		if (_units[row].Count <= col)
		{
			return null;
		}
		return _units[row][col];
	}

	public void SetAllFormationIdAs(string formationId)
	{
		for (int i = 0; i < FormationId.Length; i++)
		{
			FormationId[i] = formationId;
		}
	}

	public void RefreshUnits(GameManagers gameManagers, Team team = Team.None, Action Callback = null)
	{
		IsUnitRefreshed = false;
		FGUIManager.Instance.OpenIEnumerator(IEnumerator_RefreshUnits(gameManagers, team, Callback));
	}

	public IEnumerator IEnumerator_RefreshUnits(GameManagers gameManagers, Team team = Team.None, Action Callback = null)
	{
		yield return null;
		_units = null;
		_boss = null;
		int levels = _unitsId.Count;
		int num = _unitsId[0].Count;
		float powerModifier = 1f;
		_units = new List<List<GameEntityData>>();
		for (int i = 0; i < levels; i++)
		{
			List<GameEntityData> _list_GameEntityData = new List<GameEntityData>();
			for (int j = 0; j < num; j++)
			{
				_list_GameEntityData.Add(null);
			}
			_units.Add(_list_GameEntityData);
		}
		for (int k = 0; k < levels; k++)
		{
			if (k != 0)
			{
				continue;
			}
			for (int l = 0; l < num; l++)
			{
				string unitId = _unitsId[k][l];
				if (!string.IsNullOrEmpty(unitId))
				{
					if (CombatPowerModifier != null)
					{
						powerModifier = CombatPowerModifier[k][l];
					}
					_units[k][l] = GameEntityData.GetEntityData(gameManagers, unitId, powerModifier, -1, team);
				}
			}
		}
		int count = _bossId.Length;
		float powerModifier2 = 1f;
		_boss = new GameEntityData[count];
		for (int m = 0; m < count; m++)
		{
			string bossId = _bossId[m];
			if (CombatPowerModifier != null)
			{
				float totalCombatPowerModifier = 0f;
				for (int n = 0; n < num; n++)
				{
					totalCombatPowerModifier += CombatPowerModifier[m][n];
				}
				powerModifier2 = totalCombatPowerModifier / (float)num;
			}
			if (!string.IsNullOrEmpty(bossId))
			{
				_boss[m] = GameEntityData.GetEntityData(gameManagers, bossId, powerModifier2);
			}
		}
		IsUnitRefreshed = true;
		Callback?.Invoke();
	}

	public BattleConfig Clone()
	{
		BattleConfig battleConfig = new BattleConfig
		{
			FormationId = (string[])FormationId?.Clone(),
			_bossId = (string[])_bossId?.Clone(),
			_boss = (GameEntityData[])_boss?.Clone(),
			UnitsTotal = (int[,])UnitsTotal?.Clone(),
			UnitsHp = UnitsHp,
			UnitsBorn = UnitsBorn,
			UnitsPool = UnitsPool,
			BattleMode = BattleMode,
			Obstacles = (Obstacle[])Obstacles?.Clone()
		};
		battleConfig._units = new List<List<GameEntityData>>();
		foreach (List<GameEntityData> unit in _units)
		{
			List<GameEntityData> list = new List<GameEntityData>();
			foreach (GameEntityData item in unit)
			{
				if (item != null)
				{
					list.Add((GameEntityData)item.Clone());
				}
				else
				{
					list.Add(null);
				}
			}
			battleConfig._units.Add(list);
		}
		battleConfig._unitsId = new List<List<string>>();
		foreach (List<string> item2 in _unitsId)
		{
			List<string> list2 = new List<string>();
			foreach (string item3 in item2)
			{
				if (item3 != null)
				{
					list2.Add((string)item3.Clone());
				}
				else
				{
					list2.Add(null);
				}
			}
			battleConfig._unitsId.Add(list2);
		}
		battleConfig.CombatPowerModifier = new List<List<float>>();
		foreach (List<float> item4 in CombatPowerModifier)
		{
			List<float> list3 = new List<float>();
			foreach (float item5 in item4)
			{
				list3.Add(item5);
			}
			battleConfig.CombatPowerModifier.Add(list3);
		}
		return battleConfig;
	}

	public static bool IsFormationEquals(BattleConfig config1, BattleConfig config2)
	{
		if (config1 == null || config2 == null)
		{
			return false;
		}
		if (config1.FormationId.Length != config2.FormationId.Length)
		{
			return false;
		}
		for (int i = 0; i < config1.FormationId.Length; i++)
		{
			if (config1.FormationId[i] != config2.FormationId[i])
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsObstaclesEquals(BattleConfig config1, BattleConfig config2)
	{
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		if (config1 == null || config2 == null)
		{
			return false;
		}
		if (config1.Obstacles == null && config2.Obstacles == null)
		{
			return true;
		}
		if (config1.Obstacles == null || config2.Obstacles == null)
		{
			return false;
		}
		if (config1.Obstacles.Length != config2.Obstacles.Length)
		{
			return false;
		}
		for (int i = 0; i < config1.Obstacles.Length; i++)
		{
			if (config1.Obstacles[i].Position != config2.Obstacles[i].Position || config1.Obstacles[i].Size != config2.Obstacles[i].Size || config1.Obstacles[i].UnitId != config2.Obstacles[i].UnitId)
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsUnitsEquals(BattleConfig config1, BattleConfig config2)
	{
		if (config1 == null || config2 == null)
		{
			return false;
		}
		if (config1.UnitsId.Count != config2.UnitsId.Count || config1.UnitsId[0].Count != config2.UnitsId[0].Count)
		{
			return false;
		}
		int count = config1.UnitsId.Count;
		int count2 = config1.UnitsId[0].Count;
		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < count2; j++)
			{
				if (config1.UnitsId[i][j] != config2.UnitsId[i][j])
				{
					return false;
				}
			}
		}
		return true;
	}

	public static bool IsBossEquals(BattleConfig config1, BattleConfig config2)
	{
		if (config1 == null || config2 == null)
		{
			return false;
		}
		if (config1.BossId.Length != config2.BossId.Length)
		{
			return false;
		}
		for (int i = 0; i < config1.BossId.Length; i++)
		{
			if (config1.BossId[i] != config2.BossId[i])
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsCombatPowerModifierEquals(BattleConfig config1, BattleConfig config2)
	{
		if (config1 == null || config2 == null)
		{
			return false;
		}
		if (config1.CombatPowerModifier == null && config2.CombatPowerModifier == null)
		{
			return true;
		}
		if (config1.CombatPowerModifier == null || config2.CombatPowerModifier == null)
		{
			return false;
		}
		if (config1.CombatPowerModifier.Count != config2.CombatPowerModifier.Count)
		{
			return false;
		}
		for (int i = 0; i < config1.CombatPowerModifier.Count; i++)
		{
			if (config1.CombatPowerModifier[i].Count != config2.CombatPowerModifier[i].Count)
			{
				return false;
			}
			for (int j = 0; j < config1.CombatPowerModifier[i].Count; j++)
			{
				float num = config1.CombatPowerModifier[i][j];
				if (Math.Abs(num - config2.CombatPowerModifier[i][j]) > float.Epsilon)
				{
					return false;
				}
			}
		}
		return true;
	}
}
