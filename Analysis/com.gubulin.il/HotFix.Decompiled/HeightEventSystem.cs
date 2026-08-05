using System.Collections.Generic;
using Entitas;

public sealed class HeightEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IHeightListener> _listenerBuffer;

	public HeightEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IHeightListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.Height) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasHeight && entity.hasHeightListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			HeightComponent height = entity.height;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.heightListener.value);
			foreach (IHeightListener item in _listenerBuffer)
			{
				item.OnHeight(entity, height.value);
			}
		}
	}
}
