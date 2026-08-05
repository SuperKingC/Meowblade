using System.Collections.Generic;
using Entitas;

public sealed class CastingAbilityElapsedTimeEventSystem : ReactiveSystem<GameEntity>
{
	private readonly List<ICastingAbilityElapsedTimeListener> _listenerBuffer;

	public CastingAbilityElapsedTimeEventSystem(Contexts contexts)
		: base((IContext<GameEntity>)(object)contexts.game)
	{
		base.init((IContext<GameEntity>)(object)contexts.game);
		_listenerBuffer = new List<ICastingAbilityElapsedTimeListener>();
	}

	protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameEntity>(context, new TriggerOnEvent<GameEntity>[1] { TriggerOnEventMatcherExtension.Added<GameEntity>(GameMatcher.CastingAbilityElapsedTime) });
	}

	protected override bool Filter(GameEntity entity)
	{
		return entity.hasCastingAbilityElapsedTime && entity.hasCastingAbilityElapsedTimeListener;
	}

	protected override void Execute(List<GameEntity> entities)
	{
		foreach (GameEntity entity in entities)
		{
			CastingAbilityElapsedTimeComponent castingAbilityElapsedTime = entity.castingAbilityElapsedTime;
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.castingAbilityElapsedTimeListener.value);
			foreach (ICastingAbilityElapsedTimeListener item in _listenerBuffer)
			{
				item.OnCastingAbilityElapsedTime(entity, castingAbilityElapsedTime.value);
			}
		}
	}
}
