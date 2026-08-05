using System.Collections.Generic;
using Entitas;

public sealed class FlowLightFxEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IFlowLightFxListener> _listenerBuffer;

	public FlowLightFxEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IFlowLightFxListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.FlowLightFx) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasFlowLightFx && entity.hasFlowLightFxListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			FlowLightFxComponent flowLightFx = entity.flowLightFx;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.flowLightFxListener.value);
			foreach (IFlowLightFxListener item in _listenerBuffer)
			{
				item.OnFlowLightFx(entity, flowLightFx.id, flowLightFx.power, flowLightFx.speed);
			}
		}
	}
}
