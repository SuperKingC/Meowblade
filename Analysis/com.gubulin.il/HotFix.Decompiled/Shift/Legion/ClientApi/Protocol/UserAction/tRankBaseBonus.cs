using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class tRankBaseBonus
{
	public int StartIdx { get; set; }

	public int EndIdx { get; set; }

	public Dictionary<string, object> Bonus { get; set; }
}
