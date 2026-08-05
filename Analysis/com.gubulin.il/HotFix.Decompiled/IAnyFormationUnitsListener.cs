using System.Collections.Generic;

public interface IAnyFormationUnitsListener
{
	void OnAnyFormationUnits(ConfigEntity entity, Dictionary<string, Dictionary<string, List<string>>> value);
}
