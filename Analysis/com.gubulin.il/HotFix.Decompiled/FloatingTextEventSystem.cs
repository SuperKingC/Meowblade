using System.Collections.Generic;
using Entitas;

public sealed class FloatingTextEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<IFloatingTextListener> _listenerBuffer;

	public FloatingTextEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<IFloatingTextListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.FloatingText) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasFloatingText && entity.hasFloatingTextListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		foreach (GameEntity entity in entities)
		{
			FloatingTextComponent floatingText = entity.floatingText;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.floatingTextListener.value);
			foreach (IFloatingTextListener item in _listenerBuffer)
			{
				item.OnFloatingText(entity, floatingText.color, floatingText.text);
			}
		}
	}
}
