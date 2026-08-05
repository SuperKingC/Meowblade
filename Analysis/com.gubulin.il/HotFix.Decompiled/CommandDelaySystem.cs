using System.Collections.Generic;
using Entitas;

public sealed class CommandDelaySystem : IExecuteSystem, ISystem
{
	private readonly Contexts _contexts;

	private readonly IGroup<CommandEntity> _group;

	private readonly List<CommandEntity> _buffer;

	public CommandDelaySystem(Contexts contexts)
	{
		_contexts = contexts;
		_group = ((Context<CommandEntity>)_contexts.command).GetGroup(CommandMatcher.CommandDelay);
		_buffer = new List<CommandEntity>();
	}

	public void Execute()
	{
		_group.GetEntities(_buffer);
		foreach (CommandEntity item in _buffer)
		{
			item.commandDelay.value -= _contexts.input.fixedDeltaTime.value;
			if (item.commandDelay.value <= 0f)
			{
				item.RemoveCommandDelay();
			}
		}
	}
}
