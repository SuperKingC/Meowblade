using Entitas;
using ObjectPool;

[Game]
public sealed class GroupUnitsComponent : IComponent
{
	public PooledList<int> value;
}
