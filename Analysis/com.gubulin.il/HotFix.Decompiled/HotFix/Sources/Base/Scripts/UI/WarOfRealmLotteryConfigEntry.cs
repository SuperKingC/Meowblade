using System.Collections.Generic;

namespace HotFix.Sources.Base.Scripts.UI;

public class WarOfRealmLotteryConfigEntry
{
	public List<int> StageStatus { get; set; }

	public Dictionary<string, int> Bonus { get; set; }

	public float WinRate { get; set; }

	public float LossRate { get; set; }

	public string LotteryTokenItemId { get; set; }

	public List<int> LotteryTokenLevel { get; set; }

	public int MaxLotteryUser { get; set; }
}
