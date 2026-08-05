using System.Collections.Generic;
using Entitas;

public sealed class UnitBaseImageEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IUnitBaseImageListener> _listenerBuffer;

	public UnitBaseImageEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IUnitBaseImageListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.UnitBaseImage) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasUnitBaseImage && entity.hasUnitBaseImageListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			UnitBaseImageComponent unitBaseImage = entity.unitBaseImage;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.unitBaseImageListener.value);
			foreach (IUnitBaseImageListener item in _listenerBuffer)
			{
				item.OnUnitBaseImage(entity, unitBaseImage.value);
			}
		}
	}
}
