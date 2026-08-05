using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Sources.Models;

public class WarOfRealmGroupBattleRecordGroup
{
	public float WinRate { get; set; }

	public List<WarOfRealmPersonalBattleRecord> Records { get; set; }
}
