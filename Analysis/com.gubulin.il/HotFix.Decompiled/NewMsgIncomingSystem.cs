using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;

public sealed class NewMsgIncomingSystem : BaseExecuteSystem
{
	public NewMsgIncomingSystem(Contexts contexts)
		: base(contexts)
	{
	}

	public override void Execute()
	{
		if (GameManagers.Instance != null && GameManagers.Instance.Initialized && _contexts.gameState.hasUser && _contexts.gameState.isDataReady && _contexts.input.tick.value % 100 == 0 && !_contexts.Service<BaseSceneService>().IsSceneBattleField)
		{
			GameManagers.Instance.NewMsgIncomingManager.EnsureCheckDate();
		}
	}
}
