using System.Collections.Generic;
using Entitas;

public sealed class CommandDestroyedEventSystem : ReactiveSystem<CommandEntity>
{
	private readonly List<ICommandDestroyedListener> _listenerBuffer;

	public CommandDestroyedEventSystem(Contexts contexts)
		: base((IContext<CommandEntity>)(object)contexts.command)
	{
		base.init((IContext<CommandEntity>)(object)contexts.command);
		_listenerBuffer = new List<ICommandDestroyedListener>();
	}

	protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<CommandEntity>(context, new TriggerOnEvent<CommandEntity>[1] { TriggerOnEventMatcherExtension.Added<CommandEntity>(CommandMatcher.Destroyed) });
	}

	protected override bool Filter(CommandEntity entity)
	{
		return entity.isDestroyed && entity.hasCommandDestroyedListener;
	}

	protected override void Execute(List<CommandEntity> entities)
	{
		foreach (CommandEntity entity in entities)
		{
			_listenerBuffer.Clear();
			_listenerBuffer.AddRange(entity.commandDestroyedListener.value);
			foreach (ICommandDestroyedListener item in _listenerBuffer)
			{
				item.OnDestroyed(entity);
			}
		}
	}
}
