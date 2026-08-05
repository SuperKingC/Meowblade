using System.Collections.Generic;
using Entitas;
using Shift.Legion.Common.Services;

public class UnloadPreviousSceneOnSceneCreatedSystem : ReactiveSystem<GameEntity>
{
	private readonly Contexts _contexts;

	private readonly IGroup<GameEntity> _group;

	public UnloadPreviousSceneOnSceneCreatedSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_contexts = contexts;
		_group = ((Context<GameEntity>)contexts.game).GetGroup(GameMatcher.SceneName);
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.SceneName) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return !entity.isSceneLoaded;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		int value = entities[0].id.value;
		GameEntity[] entities2 = _group.GetEntities();
		GameEntity[] array = entities2;
		foreach (GameEntity gameEntity in array)
		{
			if (gameEntity.id.value != value && !gameEntity.isDestroyable)
			{
				_contexts.Service<BaseSceneService>().Destroy(gameEntity);
			}
		}
	}
}
