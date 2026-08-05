using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;

namespace Shift.Legion.Common.Managers;

public class Cache_BlackMarketStoreItem : CacheBaseBehavior
{
	public Dictionary<string, StoreItem[]> BlackMarket_StoreItem;

	public override IEnumerator Init()
	{
		TimeInterval = 0f;
		base.DelayUpdateFromNow = 0f;
		BlackMarket_StoreItem = new Dictionary<string, StoreItem[]>();
		IsUpdateEnabled = false;
		GetBlackMarketData();
		yield return null;
	}

	public void GetBlackMarketData()
	{
		Activity storeActivity = FGUIManager.Instance.GetBlackMarketerActivity("UI_GiftBagPanel");
		if (storeActivity == null)
		{
			return;
		}
		Dictionary<string, ActivityContentPayload> dictionary = storeActivity.ContentPayload(GameManagers.Instance);
		foreach (string _key in dictionary.Keys)
		{
			Task<GetStoreActivityItemsResponse> _task = GameController.Contexts.Service<INetworkService>().GetStoreActivityItems(storeActivity.ActivityId, _key);
			_task.GetAwaiter().OnCompleted(delegate
			{
				string key = storeActivity.ActivityId + ":" + _key;
				if (_task.Result.StoreItems != null)
				{
					BlackMarket_StoreItem.Add(key, _task.Result.StoreItems);
				}
			});
		}
	}
}
