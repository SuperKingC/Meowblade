using System.Collections.Generic;
using Shift.Legion.Common.Models;

public interface IAnyOfflineBonusesListener
{
	void OnAnyOfflineBonuses(GameStateEntity entity, List<Bonus> value);
}
