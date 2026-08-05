using System.Collections.Generic;
using System.Threading.Tasks;
using Entitas;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;

public sealed class InitWhenDataLoadedSystem : ReactiveSystem<GameStateEntity>
{
	private readonly Contexts _contexts;

	public InitWhenDataLoadedSystem(Contexts contexts)
		: base((IContext<GameStateEntity>)(object)contexts.gameState)
	{
		base.init((IContext<GameStateEntity>)(object)contexts.gameState);
		_contexts = contexts;
	}

	protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<GameStateEntity>(context, new TriggerOnEvent<GameStateEntity>[2]
		{
			TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.GameDataLoaded),
			TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.UserDataLoaded)
		});
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return _contexts.gameState.isGameDataLoaded && _contexts.gameState.isUserDataLoaded;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		GDMgr.CheckLoadFinished(AfterLoadData);
	}

	private void AfterLoadData()
	{
		GameManagers instance = GameManagers.Instance;
		instance.InitClientMethods();
		instance.Init(AfterManagersInit);
	}

	private void AfterManagersInit()
	{
		GameManagers managers = GameManagers.Instance;
		managers.AddEventListeners();
		_contexts.game.ReplaceDungeon(new Dungeon(managers));
		managers.Archive = _contexts.gameState.characterArchive.value;
		Task task = managers.InitManagers();
		task.GetAwaiter().OnCompleted(delegate
		{
			managers.AchievementManager.CheckAchievementsByType(AchievementType.SoldierSecondLegendItemSlotUnlocked);
			_contexts.gameState.isDataReady = true;
			CacheManager.Instance.Init();
		});
	}
}
