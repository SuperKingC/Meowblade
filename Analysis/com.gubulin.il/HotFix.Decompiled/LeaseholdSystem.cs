using System;
using System.Collections.Generic;
using System.Linq;
using GameMaths;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;

public sealed class LeaseholdSystem : BaseExecuteSystem
{
	private int checkingCycle = 50;

	public LeaseholdSystem(Contexts contexts)
		: base(contexts)
	{
		checkingCycle = Mathf.RoundToInt(1f / contexts.Service<ITimeService>().FixedDeltaTime());
	}

	public override void Execute()
	{
		if (_contexts.Service<BaseSceneService>().IsSceneBattleField || GameManagers.Instance == null || !GameManagers.Instance.Initialized || !_contexts.gameState.hasUser || !_contexts.gameState.isDataReady || _contexts.input.tick.value % checkingCycle != 0 || _contexts.Service<BaseSceneService>().IsSceneBattleField)
		{
			return;
		}
		DateTimeOffset now = DateTimeHelper.Now;
		Dictionary<string, Dictionary<string, object>> value = GameManagers.Instance.LeaseholdManager.LeaseholdItemRecords.GetValue();
		string[] array = value.Keys.ToArray();
		string[] array2 = array;
		foreach (string text in array2)
		{
			Dictionary<string, object> dictionary = value[text];
			if (dictionary.TryGetValue("ExpireAt", out var value2) && DateTimeHelper.TryParse(value2.ToString(), out var dateTime) && dateTime.CompareTo(now) == -1)
			{
				GameManagers.Instance.LeaseholdManager.UnregisterLeaseholdItems(text);
			}
		}
	}
}
