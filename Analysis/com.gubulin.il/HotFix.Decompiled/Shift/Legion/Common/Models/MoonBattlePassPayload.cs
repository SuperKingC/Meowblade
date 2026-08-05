using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class MoonBattlePassPayload : ActivityContentPayload
{
	public MoonBattlePassPayload(int payloadIndex, Dictionary<string, object> data, Activity activity)
		: base(data)
	{
	}
}
