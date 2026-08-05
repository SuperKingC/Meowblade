using System.Collections.Generic;

namespace Shift.Legion.GvGServer.Models.Map;

public class WBInfo
{
	public string WBId { get; set; }

	public bool IsBossDead { get; set; }

	public bool CanReborn { get; set; }

	public decimal BossCurHp { get; set; }

	public decimal BossMaxHp { get; set; }

	public List<Ability> WBAbilities { get; set; }

	public List<Ability> RedAbilities { get; set; }

	public List<Ability> Extra_WBAbilities { get; set; }

	public List<Ability> Extra_RedAbilities { get; set; }

	public int NextRebornTimestamp { get; set; }

	public int RebornCooldown { get; set; }

	public int DeadCnt { get; set; }

	public int RebornCount { get; set; }

	public Ability GetCurrentRedAbility()
	{
		List<Ability> list = new List<Ability>();
		if (RedAbilities != null)
		{
			list.AddRange(RedAbilities);
		}
		if (Extra_RedAbilities != null)
		{
			list.AddRange(Extra_RedAbilities);
		}
		return (list.Count > 0) ? list[0] : null;
	}

	public List<Ability> GetBossAbilities()
	{
		List<Ability> list = new List<Ability>();
		if (RedAbilities != null)
		{
			list.AddRange(RedAbilities);
		}
		if (Extra_RedAbilities != null)
		{
			list.AddRange(Extra_RedAbilities);
		}
		return (list.Count > 0) ? list : null;
	}
}
