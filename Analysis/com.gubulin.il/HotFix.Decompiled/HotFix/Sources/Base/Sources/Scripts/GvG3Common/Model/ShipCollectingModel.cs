using System.Collections.Generic;
using Shift.Legion.ClientApi.Protocol.Building;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

public class ShipCollectingModel
{
	public string ShipId;

	public int Index;

	public eRace ShipRace;

	public List<ProduceState> WorkersStates;
}
