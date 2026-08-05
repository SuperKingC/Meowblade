using System.Collections.Generic;
using Entitas;

public sealed class UnitBaseImageRemovedEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IUnitBaseImageRemovedListener> _listenerBuffer;

	public UnitBaseImageRemovedEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IUnitBaseImageRemovedListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Removed<GameEntity>(GameMatcher.UnitBaseImage) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return !entity.hasUnitBaseImage && entity.hasUnitBaseImageRemovedListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.unitBaseImageRemovedListener.value);
			foreach (IUnitBaseImageRemovedListener item in _listenerBuffer)
			{
				item.OnUnitBaseImageRemoved(entity);
			}
		}
	}
}
