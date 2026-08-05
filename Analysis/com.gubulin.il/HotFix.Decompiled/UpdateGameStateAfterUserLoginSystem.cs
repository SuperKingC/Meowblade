using System.Collections.Generic;
using System.Linq;
using Entitas;
using Shift.Legion.Common.Managers;

public class UpdateGameStateAfterUserLoginSystem : ReactiveSystem<GameStateEntity>
{
	private readonly GameStateContext _context;

	public UpdateGameStateAfterUserLoginSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_context = contexts.gameState;
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[2]
		{
			TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.User),
			TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.DataReady)
		});
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return _context.isDataReady && _context.hasUser;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		InitGameStateHelper.Init(_context);
		if (_context.hasUnlockedSoldiers)
		{
			_context.unlockedSoldiers.value.Clear();
			_context.unlockedSoldiers.value.AddRange(GameManagers.Instance.UserArchiveManager.GetUnlockedSoldiers());
		}
		else
		{
			_context.ReplaceUnlockedSoldiers(GameManagers.Instance.UserArchiveManager.GetUnlockedSoldiers().ToList());
		}
	}
}
