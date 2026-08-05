using System.Collections.Generic;
using Entitas;

public class TickElapsedTimeSystem : ReactiveSystem<InputEntity>
{
	private readonly Contexts _contexts;

	private readonly IGroup<GameEntity> _gameGroup;

	private List<GameEntity> _gameBuffer;

	private readonly IGroup<TimerEntity> _timerGroup;

	private List<TimerEntity> _timerBuffer;

	public TickElapsedTimeSystem(Contexts contexts)
		: base((IContext<InputEntity>)(object)contexts.input)
	{
		base.init((IContext<InputEntity>)(object)contexts.input);
		_contexts = contexts;
		_gameGroup = ((Context<GameEntity>)_contexts.game).GetGroup((IMatcher<GameEntity>)(object)GameMatcher.AllOf(GameMatcher.TickElapsedTime));
		_gameBuffer = new List<GameEntity>();
		_timerGroup = ((Context<TimerEntity>)_contexts.timer).GetGroup((IMatcher<TimerEntity>)(object)TimerMatcher.AllOf(TimerMatcher.TickElapsedTime));
		_timerBuffer = new List<TimerEntity>();
	}

	protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
	{
		return CollectorContextExtension.CreateCollector<InputEntity>(context, InputMatcher.Tick);
	}

	protected override bool Filter(InputEntity entity)
	{
		return true;
	}

	protected override void Execute(List<InputEntity> entities)
	{
		_gameGroup.GetEntities(_gameBuffer);
		foreach (GameEntity item in _gameBuffer)
		{
			float newValue = item.tickElapsedTime.value + _contexts.input.fixedDeltaTime.value;
			item.ReplaceTickElapsedTime(newValue);
		}
		_timerGroup.GetEntities(_timerBuffer);
		foreach (TimerEntity item2 in _timerBuffer)
		{
			float newValue = item2.tickElapsedTime.value + _contexts.input.fixedDeltaTime.value;
			item2.ReplaceTickElapsedTime(newValue);
		}
	}
}
