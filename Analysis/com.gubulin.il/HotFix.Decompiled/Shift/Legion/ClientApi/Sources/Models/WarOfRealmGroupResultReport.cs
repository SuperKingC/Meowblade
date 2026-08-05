using System.Collections.Generic;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.Sources.Models;

public class WarOfRealmGroupResultReport
{
	public Dictionary<string, List<WarOfRealmPersonalBattleRecord>> StageGroupBattleRecord { get; set; }

	public Dictionary<string, List<RankChangeRecord>> StageUserBattleRecord { get; set; }
}
