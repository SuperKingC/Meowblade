using System;
using System.Collections.Generic;
using System.Linq;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvGServer.Models.WorldBossSocket;

namespace Shift.Legion.Common.Models;

public static class GvGBattleConfig_Extension
{
	public static void GetGvGInspectInfo(this GameManagers gameManager, List<UnitInfo_Protocol> UnitsInfo, decimal MaxBossHp, Action<Dictionary<string, GvGInspectInfo>> Callback = null)
	{
		Dictionary<string, GvGInspectInfo> dict = new Dictionary<string, GvGInspectInfo>();
		gameManager.generateWorldBossBattleConfig(UnitsInfo, 0uL, 0.6f, delegate(BattleConfig battleconfig)
		{
			for (int i = 0; i < battleconfig.UnitsId.Count; i++)
			{
				for (int j = 0; j < battleconfig.UnitsId[i].Count; j++)
				{
					GameEntityData gameEntityData = battleconfig.Units(i, j);
					if (gameEntityData != null)
					{
						GvGInspectInfo gvGInspectInfo = new GvGInspectInfo
						{
							Atk = (int)gameEntityData.AttackDamage,
							Def = (int)gameEntityData.Armor,
							MaxHp = ((int)gameEntityData.Health).ToString(),
							CombatPower = gameEntityData.CombatPower.ToString()
						};
						if (gameEntityData.Tags.Contains("WORLD_BOSS"))
						{
							gvGInspectInfo.CombatPower = Math.Floor((double)gameEntityData.CombatPower + (double)MaxBossHp * 0.15000000596046448).ToString();
							gvGInspectInfo.MaxHp = MaxBossHp.ToString();
						}
						else
						{
							gvGInspectInfo.CombatPower = (gameEntityData.CombatPower * battleconfig.UnitsTotal[i, j]).ToString();
						}
						dict.Add(gameEntityData.Identifier, gvGInspectInfo);
					}
				}
			}
			Callback?.Invoke(dict);
		});
	}

	public static void generateWorldBossBattleConfig(this GameManagers gameManagers, List<UnitInfo_Protocol> UnitsInfo, ulong BossCurHp, float BaseMod = 1f, Action<BattleConfig> Callback = null)
	{
		BattleConfig battleConfig = new BattleConfig();
		battleConfig.UnitsId = new List<List<string>>();
		battleConfig.CombatPowerModifier = new List<List<float>>();
		battleConfig.UnitsTotal = new int[1, 12];
		battleConfig.BossId = new string[1];
		for (int i = 0; i < 1; i++)
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
		int num = 0;
		List<int> playerMaxPowerfulLegionLevelsInfo = LegionHelper.GetPlayerMaxPowerfulLegionLevelsInfo(gameManagers);
		battleConfig.BossDamageMultiplier = gameManagers.ModifierManager.GetPercentFloatPayload("BossDamage");
		for (int k = 0; k < UnitsInfo.Count; k++)
		{
			string soldierId = UnitsInfo[k].SoldierId;
			int num2 = UnitsInfo[k].PerTeamMemberCnt;
			if (string.IsNullOrEmpty(soldierId))
			{
				continue;
			}
			if (playerMaxPowerfulLegionLevelsInfo != null)
			{
				if (gameManagers.SoldierManager.Get(soldierId).Tags.Contains("WORLD_BOSS"))
				{
					num2 = 1;
				}
				else
				{
					int level = ((num < playerMaxPowerfulLegionLevelsInfo.Count) ? playerMaxPowerfulLegionLevelsInfo[num] : playerMaxPowerfulLegionLevelsInfo.Last());
					num2 = Singleton<SoldierFormationManager>.Instance.GetSoldierFormationNumber(soldierId, level);
				}
			}
			battleConfig.UnitsId[0][k] = soldierId;
			battleConfig.UnitsTotal[0, k] = num2;
			num++;
		}
		LegionPowerConfig value = gameManagers.SoldierManager.LegionPowerConfig.GetValue();
		Dictionary<string, int> formationInfo = value.FormationInfo;
		bool flag = false;
		if (formationInfo.Count < 5)
		{
			flag = true;
			foreach (KeyValuePair<string, int> item in formationInfo)
			{
				string key = item.Key;
				if (gameManagers.UserArchiveManager.GetSoldierLevel(key) > 10)
				{
					flag = false;
					break;
				}
			}
		}
		float playerLegionCombatPower = (flag ? 11350f : ((float)value.MaxPower));
		battleConfig.RefreshUnits(gameManagers, Team.None, delegate
		{
			for (int l = 0; l < battleConfig.CombatPowerModifier.Count; l++)
			{
				int count = battleConfig.CombatPowerModifier[0].Count;
				List<int> list3 = new List<int>();
				for (int m = 0; m < count; m++)
				{
					string text = battleConfig.UnitsId[l][m];
					if (!string.IsNullOrEmpty(text) && text != "Lock" && text != "Unlock" && !battleConfig.Units(l, m).Tags.Contains("WORLD_BOSS"))
					{
						list3.Add(m);
					}
				}
				float num3 = playerLegionCombatPower / (float)list3.Count;
				for (int n = 0; n < count; n++)
				{
					if (battleConfig.Units(l, n) != null)
					{
						if (battleConfig.Units(l, n).Tags.Contains("WORLD_BOSS"))
						{
							battleConfig.CombatPowerModifier[l][n] = 1f;
						}
						else
						{
							battleConfig.CombatPowerModifier[l][n] = BaseMod * num3 / (float)(battleConfig.Units(l, n).CombatPower * battleConfig.UnitsTotal[l, n]);
						}
					}
				}
			}
			battleConfig.RefreshUnits(gameManagers, Team.None, delegate
			{
				Callback?.Invoke(battleConfig);
			});
		});
	}
}
