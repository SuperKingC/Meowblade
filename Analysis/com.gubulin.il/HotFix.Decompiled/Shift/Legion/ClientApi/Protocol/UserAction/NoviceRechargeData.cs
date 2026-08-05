using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class NoviceRechargeData
{
	public string FirstRechargeEnableTime;

	public string ContinusRechargeEnableTime;

	public int Score;

	public Dictionary<string, ContinuousRechargeBonus> Progress;
}
