using System.Collections.Generic;
using Entitas;

public sealed class AnyBlueTeamCombatPowerEventSystem : ReactiveSystem<GameStateEntity>
{
	private readonly IGroup<GameStateEntity> _listeners;

	private readonly List<GameStateEntity> _entityBuffer;

	private readonly List<IAnyBlueTeamCombatPowerListener> _listenerBuffer;

	public AnyBlueTeamCombatPowerEventSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_listeners = ((Context<GameStateEntity>)contexts.gameState).GetGroup(GameStateMatcher.AnyBlueTeamCombatPowerListener);
		_entityBuffer = new List<GameStateEntity>();
		_listenerBuffer = new List<IAnyBlueTeamCombatPowerListener>();
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[1] { TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.BlueTeamCombatPower) });
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return entity.hasBlueTeamCombatPower;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		foreach (GameStateEntity entity in entities)
		{
			BlueTeamCombatPowerComponent blueTeamCombatPower = entity.blueTeamCombatPower;
			foreach (GameStateEntity entity2 in _listeners.GetEntities(_entityBuffer))
			{
				_listenerBuffer.Clear();
				_listenerBuffer.AddRange(entity2.anyBlueTeamCombatPowerListener.value);
				foreach (IAnyBlueTeamCombatPowerListener item in _listenerBuffer)
				{
					item.OnAnyBlueTeamCombatPower(entity, blueTeamCombatPower.value);
				}
			}
		}
	}
}
