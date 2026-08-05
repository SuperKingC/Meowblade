using System.Collections.Generic;
using Entitas;

public sealed class AnyRedTeamCampPositionEventSystem : ReactiveSystem<GameStateEntity>
{
	private readonly IGroup<GameStateEntity> _listeners;

	private readonly List<GameStateEntity> _entityBuffer;

	private readonly List<IAnyRedTeamCampPositionListener> _listenerBuffer;

	public AnyRedTeamCampPositionEventSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_listeners = ((Context<GameStateEntity>)contexts.gameState).GetGroup(GameStateMatcher.AnyRedTeamCampPositionListener);
		_entityBuffer = new List<GameStateEntity>();
		_listenerBuffer = new List<IAnyRedTeamCampPositionListener>();
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[1] { TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.RedTeamCampPosition) });
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return entity.hasRedTeamCampPosition;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		foreach (GameStateEntity entity in entities)
		{
			RedTeamCampPositionComponent redTeamCampPosition = entity.redTeamCampPosition;
			foreach (GameStateEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyRedTeamCampPositionListener.value);
				foreach (IAnyRedTeamCampPositionListener item in _listenerBuffer)
				{
					item.OnAnyRedTeamCampPosition(entity, redTeamCampPosition.value);
				}
			}
		}
	}
}
