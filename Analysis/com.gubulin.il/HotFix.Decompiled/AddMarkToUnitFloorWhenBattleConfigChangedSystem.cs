using System.Collections.Generic;
using Entitas;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Services;

public class AddMarkToUnitFloorWhenBattleConfigChangedSystem : ReactiveSystem<ConfigEntity>
{
	private readonly List<string> _oldUnits;

	private readonly Contexts _contexts;

	public AddMarkToUnitFloorWhenBattleConfigChangedSystem(Contexts contexts)
		: base((IContext<ConfigEntity>)(object)contexts.config)
	{
		base.init((IContext<ConfigEntity>)(object)contexts.config);
		_contexts = contexts;
		_oldUnits = new List<string>(5) { null, null, null, null, null };
	}

	protected override ICollector<ConfigEntity> GetTrigger(IContext<ConfigEntity> context)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		return CollectorContextExtension.CreateCollector<ConfigEntity>(context, new TriggerOnEvent<ConfigEntity>[1] { TriggerOnEventMatcherExtension.Added<ConfigEntity>(ConfigMatcher.BattleConfig) });
	}

	protected override bool Filter(ConfigEntity entity)
	{
		return _contexts.config.hasBattleConfig;
	}

	protected override void Execute(List<ConfigEntity> entities)
	{
		int currentLevelIndex = _contexts.Service<IBattleFieldService>().CurrentLevelIndex;
		List<List<string>> unitsId = _contexts.config.battleConfig.Red.UnitsId;
		if (unitsId == null || unitsId[0].Count != 5)
		{
			return;
		}
		for (int i = 0; i < 5; i++)
		{
			string text = unitsId[currentLevelIndex][i];
			if (text != null && _oldUnits[i] != unitsId[currentLevelIndex][i])
			{
				CommandFactory.CreateAddEnterMarkToUnitsCommand(_contexts, Team.Red, i);
			}
		}
		_oldUnits.Clear();
		for (int j = 0; j < 5; j++)
		{
			_oldUnits.Add(unitsId[currentLevelIndex][j]);
		}
	}
}
