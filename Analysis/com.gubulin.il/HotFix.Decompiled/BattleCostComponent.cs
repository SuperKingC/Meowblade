using System.Collections.Generic;
using Entitas;

[Game]
public sealed class BattleCostComponent : IComponent
{
	public Dictionary<string, int> value;
}
