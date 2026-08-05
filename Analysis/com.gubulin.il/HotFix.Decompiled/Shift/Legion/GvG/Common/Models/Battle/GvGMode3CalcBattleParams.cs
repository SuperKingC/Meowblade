using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using ILRuntime_LitJson;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace Shift.Legion.GvG.Common.Models.Battle;

public class GvGMode3CalcBattleParams
{
	[JsonIgnore]
	private const string HideAbilityId = "WorldBossHP_001";

	[JsonIgnore]
	private List<ItemAbility> _redAbilities;

	[JsonIgnore]
	private List<ItemAbility> _blueAbilities;

	public string BattleId { get; set; }

	public int UserId { get; set; }

	public Dictionary<string, int> RedTeam { get; set; }

	public List<ItemAbility> RedItemAbilities { get; set; }

	public string RedDiffCombatPower { get; set; }

	public Dictionary<string, int> BlueTeam { get; set; }

	public List<ItemAbility> BlueItemAbilities { get; set; }

	public string BlueDiffCombatPower { get; set; }

	public List<ItemAbility> GetRedAbilities()
	{
		if (_redAbilities != null)
		{
			return _redAbilities;
		}
		return _redAbilities = ((RedItemAbilities == null) ? new List<ItemAbility>() : RedItemAbilities.Where((ItemAbility a) => a.AbilityLevel > 0 && IsDisplayable(a)).ToList());
	}

	public List<ItemAbility> GetBlueAbilities()
	{
		if (_blueAbilities != null)
		{
			return _blueAbilities;
		}
		return _blueAbilities = ((BlueItemAbilities == null) ? new List<ItemAbility>() : BlueItemAbilities.Where((ItemAbility a) => a.AbilityLevel > 0 && IsDisplayable(a)).ToList());
	}

	private bool IsDisplayable(ItemAbility ability)
	{
		if (ability.AbilityData == null)
		{
			ILRuntimeDebug.LogError($"[GvGMode3CalcBattleParams] {ability.AbilityId} Is GDEAdata null:{GDMgr.TryGetWithErrorHandling<GDEAbilityData>(ability.AbilityId) == null}");
		}
		return (Singleton<AbilityDataManager>.Instance.GetSpecialTagValue(ability.AbilityData.Key, "BuffType") != 0) ? (ability.AbilityData.Key != "WorldBossHP_001") : (ability.AbilityLevel > 0);
	}
}
