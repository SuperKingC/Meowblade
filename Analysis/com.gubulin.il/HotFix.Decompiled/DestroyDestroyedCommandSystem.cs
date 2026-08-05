using System.Collections.Generic;
using Entitas;

public sealed class DestroyDestroyedCommandSystem : ICleanupSystem, ISystem
{
	private readonly IGroup<CommandEntity> _group;

	private readonly List<CommandEntity> _buffer = new List<CommandEntity>();

	public DestroyDestroyedCommandSystem(Contexts contexts)
	{
		_group = ((Context<CommandEntity>)contexts.command).GetGroup(CommandMatcher.Destroyed);
	}

	public void Cleanup()
	{
		foreach (CommandEntity entity in _group.GetEntities(_buffer))
		{
			((Entity)entity).Destroy();
		}
	}
}
