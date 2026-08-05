using System.Collections.Generic;
using Entitas;

public sealed class RetreatCommandSystem : ReactiveSystem<CommandEntity>
{
	private readonly RetreatCommandExecutor _executor;

	public RetreatCommandSystem(Contexts contexts)
		: base((IContext<CommandEntity>)(object)contexts.command)
	{
		base.init((IContext<CommandEntity>)(object)contexts.command);
		_executor = new RetreatCommandExecutor(contexts);
	}

	protected override ICollector<CommandEntity> GetTrigger(IContext<CommandEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<CommandEntity>(context, new TriggerOnEvent<CommandEntity>[2]
		{
			TriggerOnEventMatcherExtension.Added<CommandEntity>(CommandMatcher.RetreatCommand),
			TriggerOnEventMatcherExtension.Removed<CommandEntity>(CommandMatcher.CommandDelay)
		});
	}

	protected override bool Filter(CommandEntity entity)
	{
		return entity.isRetreatCommand && !entity.hasCommandDelay;
	}

	protected override void Execute(List<CommandEntity> entities)
	{
		_executor.Prepare();
		foreach (CommandEntity entity in entities)
		{
			_executor.Execute();
			entity.isDestroyed = true;
		}
	}
}
