using System.Collections.Generic;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

public class CalcOfflineBonusCommandExecutor
{
	private readonly Contexts _contexts;

	public CalcOfflineBonusCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute()
	{
		GameManagers managers = GameManagers.Instance;
		if (_contexts.gameState.offlineSeconds.value <= managers.UserArchiveManager.GetOfflineYieldTimeOffset() || !_contexts.gameState.isMainCityInitialized)
		{
			return;
		}
		managers.Messenger.Broadcast<List<string>, bool>("BUILDING_NEED_PAUSE_PRODUCE", null, arg2: true);
		ILRequestHelper<GetOfflineYieldBonusResponse>.Request(null, () => _contexts.Service<INetworkService>().GetOfflineYieldBonuses(), delegate(GetOfflineYieldBonusResponse response)
		{
			if (!response.Result || response.Bonuses == null || response.Bonuses.Count < 1)
			{
				managers.Messenger.Broadcast<List<string>, bool>("BUILDING_NEED_RESUME_PRODUCE", null, arg2: false);
			}
			else
			{
				GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				List<Bonus> list = new List<Bonus>();
				foreach (ModelsBonus bonuse in response.Bonuses)
				{
					list.Add(Bonus.Get(bonuse.ItemId, bonuse.Qty));
				}
				_contexts.gameState.ReplaceOfflineBonuses(list);
				managers.Messenger.Broadcast<List<string>, bool>("BUILDING_NEED_RESUME_PRODUCE", null, arg2: false);
			}
		}, 1f);
	}
}
