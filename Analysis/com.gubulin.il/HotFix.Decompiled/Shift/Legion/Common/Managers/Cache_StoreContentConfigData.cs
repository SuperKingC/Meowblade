using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public class Cache_StoreContentConfigData : CacheBaseBehavior
{
	private List<string> StoreItemsGameLevelFilter;

	public override IEnumerator Init()
	{
		TimeInterval = 0f;
		base.DelayUpdateFromNow = 0f;
		StoreItemsGameLevelFilter = new List<string>();
		IsUpdateEnabled = false;
		yield return LoadAllStoreItemsGameLevelFilter();
		yield return null;
	}

	private IEnumerator LoadAllStoreItemsGameLevelFilter()
	{
		foreach (GDEStoreContentConfigGameLevelFilterData gameLevelFilterData in GDMgr.GetAllItems<GDEStoreContentConfigGameLevelFilterData>())
		{
			List<string> gameLevelFilter = new List<string>();
			if (!string.IsNullOrEmpty(gameLevelFilterData.GameLevelFilter))
			{
				gameLevelFilter = JsonHelper.ToObject<List<string>>(gameLevelFilterData.GameLevelFilter);
			}
			if (gameLevelFilter == null || gameLevelFilter.Count <= 0)
			{
				continue;
			}
			for (int i = 0; i < gameLevelFilter.Count; i++)
			{
				if (!StoreItemsGameLevelFilter.Contains(gameLevelFilter[i]))
				{
					StoreItemsGameLevelFilter.Add(gameLevelFilter[i]);
				}
			}
		}
		yield return null;
	}

	public void UpdateBlackMarketStoreItems(string levelId)
	{
		if (StoreItemsGameLevelFilter != null && StoreItemsGameLevelFilter.Count > 0 && StoreItemsGameLevelFilter.Contains(levelId))
		{
			FGUIManager.Instance.BlackMarket_StoreItem = null;
		}
	}

	public void UpdateBlackMarketStoreItemsOnUserLevelUp()
	{
		FGUIManager.Instance.BlackMarket_StoreItem = null;
	}
}
