using System.Collections.Generic;

public interface IAnyCurrentFormationListener
{
	void OnAnyCurrentFormation(ConfigEntity entity, Dictionary<string, Dictionary<string, string>> value);
}
