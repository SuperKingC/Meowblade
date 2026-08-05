using System.Collections.Generic;
using Entitas;

public sealed class DestroyExpiredFloatingTextSystem : IExecuteSystem, ISystem
{
	private readonly IGroup<GameEntity> _group;

	private readonly List<GameEntity> _buffer;

	public DestroyExpiredFloatingTextSystem(Contexts contexts)
	{
		_group = ((Context<GameEntity>)contexts.game).GetGroup((IMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.FloatingText, GameMatcher.Duration, GameMatcher.ElapsedTime));
		_buffer = new List<GameEntity>();
	}

	public void Execute()
	{
		_group.GetEntities(_buffer);
		foreach (GameEntity item in _buffer)
		{
			if (item.elapsedTime.value > item.duration.value)
			{
				item.isDestroyed = true;
			}
		}
	}
}
