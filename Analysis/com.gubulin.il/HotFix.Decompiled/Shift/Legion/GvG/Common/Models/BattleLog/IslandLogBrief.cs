using System.Collections.Generic;
using System.Linq;

namespace Shift.Legion.GvG.Common.Models.BattleLog;

public class IslandLogBrief
{
	public int UserId { get; set; } = -1;

	public int CampId { get; set; } = -1;

	public List<IslandLogBrief_Ship> ShipReports { get; set; } = new List<IslandLogBrief_Ship>();

	public long Kill { get; set; } = -1L;

	public long Loss { get; set; } = -1L;

	public long BossDamage { get; set; } = -1L;

	public float HoldingScore { get; set; } = -1f;

	public long REKill { get; set; } = -1L;

	public long MaxREKill { get; set; } = -1L;

	public long REBossDamage { get; set; } = -1L;

	public long MaxREBossDamage { get; set; } = -1L;

	public float TotalScore { get; set; } = -1f;

	public float TotalRESCore { get; set; } = -1f;

	public int TotalRank { get; set; } = -1;

	public int RERank { get; set; } = -1;

	public int REBossEventRank { get; set; } = -1;

	public int RENPCEventRank { get; set; } = -1;

	public bool Expanded { get; set; } = false;

	public int Rank { get; set; }

	public float HoldingProgress => (float)ShipReports.Sum((IslandLogBrief_Ship sr) => sr.HoldingProgress) / 100f;
}
