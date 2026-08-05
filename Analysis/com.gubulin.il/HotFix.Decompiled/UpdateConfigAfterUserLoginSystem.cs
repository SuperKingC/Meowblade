using System.Collections.Generic;
using Entitas;
using Shift.Legion.Common.Managers;

public class UpdateConfigAfterUserLoginSystem : ReactiveSystem<GameStateEntity>
{
	private readonly Contexts _contexts;

	public UpdateConfigAfterUserLoginSystem(Contexts contexts)
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
			TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.User),
			TriggerOnEventMatcherExtension.Added<GameStateEntity>(GameStateMatcher.DataReady)
		});
	}

	protected override bool Filter(GameStateEntity entity)
	{
		return _contexts.gameState.isDataReady && _contexts.gameState.hasUser;
	}

	protected override void Execute(List<GameStateEntity> entities)
	{
		ConfigContext config = _contexts.config;
		InitConfigHelper.Init(config);
		Dictionary<string, Dictionary<string, string>> currentFormation = GameManagers.Instance.UserArchiveManager.GetCurrentFormation();
		Dictionary<string, Dictionary<string, List<string>>> dictionary = new Dictionary<string, Dictionary<string, List<string>>>();
		foreach (KeyValuePair<string, Dictionary<string, string>> item in currentFormation)
		{
			string key = item.Key;
			dictionary.Add(key, new Dictionary<string, List<string>>());
			foreach (KeyValuePair<string, string> item2 in item.Value)
			{
				string key2 = item2.Key;
				dictionary[key].Add(key2, new List<string>(GameManagers.Instance.UserArchiveManager.GetBattleFormation(key, key2).Values));
			}
		}
		config.ReplaceCurrentFormation(currentFormation);
		config.ReplaceFormationUnits(dictionary);
		config.isShowDamage = GameManagers.Instance.UserArchiveManager.GetConfigValue<int>("SHOW_DAMAGE") == 1;
	}
}
