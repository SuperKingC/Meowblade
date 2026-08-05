using System.Collections.Generic;
using Entitas;

public sealed class AnimationInitializedEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IAnimationInitializedListener> _listenerBuffer;

	public AnimationInitializedEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IAnimationInitializedListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.AnimationInitialized) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.isAnimationInitialized && entity.hasAnimationInitializedListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.animationInitializedListener.value);
			foreach (IAnimationInitializedListener item in _listenerBuffer)
			{
				item.OnAnimationInitialized(entity);
			}
		}
	}
}
