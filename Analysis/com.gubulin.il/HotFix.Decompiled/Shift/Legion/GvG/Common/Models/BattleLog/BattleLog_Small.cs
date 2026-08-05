using ILRuntime_LitJson;

namespace Shift.Legion.GvG.Common.Models.BattleLog;

public class BattleLog_Small
{
	public eBattleLogShipAlias RedAlias;

	public string ProcessId { get; set; }

	public string BattleId { get; set; }

	public int RedShipDeadCnt { get; set; }

	public int BlueShipDeadCnt { get; set; }

	public long Timestamp_ms { get; set; }

	public int RedLossCount { get; set; }

	public int BlueLossCount { get; set; }

	public int Winner { get; set; }

	public long BossHp { get; set; }

	[JsonIgnore]
	public bool Win { get; set; }

	[JsonIgnore]
	public bool Offensive { get; set; }
}
