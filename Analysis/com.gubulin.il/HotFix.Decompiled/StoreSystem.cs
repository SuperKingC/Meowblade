using System;
using System.Collections.Generic;
using System.Linq;
using GameMaths;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;

public sealed class StoreSystem : BaseExecuteSystem
{
	private int checkingCycle = 50;

	public StoreSystem(Contexts contexts)
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
		GameManagers instance = GameManagers.Instance;
		Dictionary<string, Dictionary<string, DateTimeOffset>> value = instance.StoreManager.LimitTimeMerchandise.GetValue();
		string[] array = value.Keys.ToArray();
		string[] array2 = array;
		foreach (string key in array2)
		{
			Dictionary<string, DateTimeOffset> dictionary = value[key];
			string[] array3 = dictionary.Keys.ToArray();
			string[] array4 = array3;
			foreach (string text in array4)
			{
				if (dictionary[text].CompareTo(now) <= 0)
				{
					dictionary.Remove(text);
					instance.Messenger.Broadcast("LIMIT_TIME_MERCHANDISE_EXPIRED", text);
				}
			}
		}
	}
}
