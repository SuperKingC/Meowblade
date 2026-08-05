using System.Collections.Generic;
using Entitas;

public sealed class FloatingTextAlphaEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IFloatingTextAlphaListener> _listenerBuffer;

	public FloatingTextAlphaEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IFloatingTextAlphaListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.FloatingTextAlpha) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasFloatingTextAlpha && entity.hasFloatingTextAlphaListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			FloatingTextAlphaComponent floatingTextAlpha = entity.floatingTextAlpha;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.floatingTextAlphaListener.value);
			foreach (IFloatingTextAlphaListener item in _listenerBuffer)
			{
				item.OnFloatingTextAlpha(entity, floatingTextAlpha.value);
			}
		}
	}
}
