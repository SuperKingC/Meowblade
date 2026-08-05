using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class BuffConfig
{
	public string NormalBuff { get; set; }

	public string WeekDayBuff { get; set; }

	public List<string> WeekendBuff { get; set; }
}
