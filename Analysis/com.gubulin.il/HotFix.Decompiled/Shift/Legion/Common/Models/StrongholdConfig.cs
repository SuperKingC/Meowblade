using System.Collections.Generic;

namespace Shift.Legion.Common.Models;

public class StrongholdConfig
{
	public string StrongholdId;

	public Dictionary<string, float> Productions = new Dictionary<string, float>();

	public string Occupant;

	public object Clone()
	{
		StrongholdConfig strongholdConfig = new StrongholdConfig
		{
			StrongholdId = StrongholdId,
			Productions = new Dictionary<string, float>(),
			Occupant = Occupant
		};
		foreach (KeyValuePair<string, float> production in Productions)
		{
			strongholdConfig.Productions.Add(production.Key, production.Value);
		}
		return strongholdConfig;
	}
}
