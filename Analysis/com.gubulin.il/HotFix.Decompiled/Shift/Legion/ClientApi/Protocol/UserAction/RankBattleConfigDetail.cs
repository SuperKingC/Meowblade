using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class RankBattleConfigDetail
{
	public List<Dictionary<string, List<RankSoldierEquipmentsInfo>>> SoldierEquipments = new List<Dictionary<string, List<RankSoldierEquipmentsInfo>>>();
}
