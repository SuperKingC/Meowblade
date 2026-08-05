using System.Collections.Generic;
using Entitas;

public sealed class SpecialFxEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<ISpecialFxListener> _listenerBuffer;

	public SpecialFxEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<ISpecialFxListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.SpecialFx) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasSpecialFx && entity.hasSpecialFxListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			SpecialFxComponent specialFx = entity.specialFx;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.specialFxListener.value);
			foreach (ISpecialFxListener item in _listenerBuffer)
			{
				item.OnSpecialFx(entity, specialFx.value);
			}
		}
	}
}
