using System.Collections.Generic;
using Entitas;

public class UpdateCastingAbilityElapsedTimeSystem : ReactiveSystem<InputEntity>
{
	private readonly Contexts _contexts;

	private readonly IGroup<GameEntity> _group;

	private readonly List<GameEntity> _buffer;

	public UpdateCastingAbilityElapsedTimeSystem(Contexts contexts)
		: base((IContext<InputEntity>)(object)contexts.input)
	{
		base.init((IContext<InputEntity>)(object)contexts.input);
		_contexts = contexts;
		_group = ((Context<GameEntity>)contexts.game).GetGroup((IMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.CastingAbility, GameMatcher.CastingAbilityCastTime));
		_buffer = new List<GameEntity>();
	}

	protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
	{
		return CollectorContextExtension.CreateCollector<InputEntity>(context, InputMatcher.Tick);
	}

	protected override bool Filter(InputEntity entity)
	{
		return true;
	}

	protected override void Execute(List<InputEntity> entities)
	{
		_group.GetEntities(_buffer);
		int count = _buffer.Count;
		for (int i = 0; i < count; i++)
		{
			GameEntity gameEntity = _buffer[i];
			gameEntity.ReplaceCastingAbilityElapsedTime(gameEntity.castingAbilityElapsedTime.value + _contexts.input.fixedDeltaTime.value);
		}
	}
}
