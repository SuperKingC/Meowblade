using System.Collections.Generic;
using Entitas;

public class UpdateDeadElapsedTickSystem : BaseExecuteSystem
{
	private readonly IGroup<GameEntity> _group;

	private readonly List<GameEntity> _buffer;

	public UpdateDeadElapsedTickSystem(Contexts contexts)
		: base(contexts)
	{
		_group = ((Context<GameEntity>)contexts.game).GetGroup(GameMatcher.DeadElapsedTick);
		_buffer = new List<GameEntity>();
	}

	public override void Execute()
	{
		_group.GetEntities(_buffer);
		foreach (GameEntity item in _buffer)
		{
			item.deadElapsedTick.value++;
		}
	}
}
