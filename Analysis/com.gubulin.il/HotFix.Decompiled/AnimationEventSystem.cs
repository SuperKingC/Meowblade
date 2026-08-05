using System.Collections.Generic;
using Entitas;

public sealed class AnimationEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IAnimationListener> _listenerBuffer;

	public AnimationEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IAnimationListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Animation) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasAnimation && entity.hasAnimationListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			AnimationComponent animation = entity.animation;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.animationListener.value);
			foreach (IAnimationListener item in _listenerBuffer)
			{
				item.OnAnimation(entity, animation.value);
			}
		}
	}
}
