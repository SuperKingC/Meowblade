using System.Collections.Generic;
using Entitas;

public sealed class AnyBlueTeamCampPositionEventSystem : ReactiveSystem<GameStateEntity>
{
	private readonly IGroup<GameStateEntity> _listeners;

	private readonly List<GameStateEntity> _entityBuffer;

	private readonly List<IAnyBlueTeamCampPositionListener> _listenerBuffer;

	public AnyBlueTeamCampPositionEventSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_listeners = ((Context<GameStateEntity>)contexts.gameState).GetGroup(GameStateMatcher.AnyBlueTeamCampPositionListener);
		_entityBuffer = new List<GameStateEntity>();
		_listenerBuffer = new List<IAnyBlueTeamCampPositionListener>();
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[1] { TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.BlueTeamCampPosition) });
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return entity.hasBlueTeamCampPosition;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		foreach (GameStateEntity entity in entities)
		{
			BlueTeamCampPositionComponent blueTeamCampPosition = entity.blueTeamCampPosition;
			foreach (GameStateEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyBlueTeamCampPositionListener.value);
				foreach (IAnyBlueTeamCampPositionListener item in _listenerBuffer)
				{
					item.OnAnyBlueTeamCampPosition(entity, blueTeamCampPosition.value);
				}
			}
		}
	}
}
