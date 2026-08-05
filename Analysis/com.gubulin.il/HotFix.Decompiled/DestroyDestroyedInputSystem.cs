using System.Collections.Generic;
using Entitas;

public sealed class DestroyDestroyedInputSystem : ICleanupSystem, ISystem
{
	private readonly IGroup<InputEntity> _group;

	private readonly List<InputEntity> _buffer = new List<InputEntity>();

	public DestroyDestroyedInputSystem(Contexts contexts)
	{
		_group = ((Context<InputEntity>)contexts.input).GetGroup(InputMatcher.Destroyed);
	}

	public void Cleanup()
	{
		foreach (InputEntity entity in _group.GetEntities(_buffer))
		{
			((Entity)entity).Destroy();
		}
	}
}
