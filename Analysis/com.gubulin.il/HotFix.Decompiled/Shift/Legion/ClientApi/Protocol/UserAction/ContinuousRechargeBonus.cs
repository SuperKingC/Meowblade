using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class ContinuousRechargeBonus
{
	public Dictionary<string, float> Bonus { get; set; }

	public BonusStatus BonusStatus { get; set; }

	public string RechargeTime { get; set; }

	public string ClaimedTime { get; set; }
}
