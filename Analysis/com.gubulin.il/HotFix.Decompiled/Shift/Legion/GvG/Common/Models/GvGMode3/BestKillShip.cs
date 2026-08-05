using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public class BestKillShip
{
	public string Name;

	public eRace Race;

	public List<BestKillSoldierInfo> SoldierInfos;

	public int ShipMultiKillCount;
}
