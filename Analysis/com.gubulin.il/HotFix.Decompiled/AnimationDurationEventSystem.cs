using System.Collections.Generic;
using Entitas;

public sealed class AnimationDurationEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IAnimationDurationListener> _listenerBuffer;

	public AnimationDurationEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IAnimationDurationListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.AnimationDuration) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasAnimationDuration && entity.hasAnimationDurationListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			AnimationDurationComponent animationDuration = entity.animationDuration;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.animationDurationListener.value);
			foreach (IAnimationDurationListener item in _listenerBuffer)
			{
				item.OnAnimationDuration(entity, animationDuration.value);
			}
		}
	}
}
