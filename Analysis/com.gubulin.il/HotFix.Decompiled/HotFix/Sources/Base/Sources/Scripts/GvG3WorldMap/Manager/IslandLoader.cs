using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public class IslandLoader : ObjectPoolingLoaderBase<int, IslandController>
{
	private class WaitToCreateIsland
	{
		public int Id;

		public int ManhattanDist;
	}

	private const int MaxSimultaneousDataLoading = 30;

	private const int MaxSimultaneousModelLoading = 6;

	public Action OnLoadingFinished = null;

	public bool NeedReloadOldActive = false;

	public bool NeedReloadStates = false;

	public IslandLoader(Transform worldTrans)
		: base(worldTrans, "GvG/GvGIslandBase", "Islands", 50)
	{
	}

	public override IEnumerator LazyUpdate()
	{
		if (NeedInterruptionAndReload)
		{
			yield break;
		}
		Vector2 screenCenter = new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
		Vec2 viewCenter = PositionHelper.GetScreenToFloorPos(screenCenter);
		Rect loadingRect = new Rect(viewCenter.x - 175f, viewCenter.y - 87.5f, 350f, 175f);
		HashSet<int> curVisibleIslandIds = new HashSet<int>();
		if (WorldMapConfigHelper.Configs.QuadTree != null)
		{
			curVisibleIslandIds = new HashSet<int>(WorldMapConfigHelper.Configs.QuadTree.Search(loadingRect));
		}
		else
		{
			List<IslandConfigData> islandConfigList = WorldMapConfigHelper.Configs.Islands_List;
			foreach (IslandConfigData islandConfig in islandConfigList)
			{
				if (((Rect)(ref loadingRect)).Overlaps(islandConfig.ViewRect))
				{
					curVisibleIslandIds.Add(islandConfig.Props.Id);
				}
			}
		}
		yield return null;
		if (NeedInterruptionAndReload)
		{
			yield break;
		}
		Dictionary<int, IslandController> oldActiveIslands = new Dictionary<int, IslandController>();
		foreach (IslandController islandController in ActiveObjects.Values)
		{
			if (curVisibleIslandIds.Contains(islandController.IslandId))
			{
				oldActiveIslands.Add(islandController.IslandId, islandController);
				continue;
			}
			islandController.Unload();
			ObjectPool.Release(islandController);
		}
		ActiveObjects = oldActiveIslands;
		if (NeedReloadOldActive)
		{
			NeedReloadOldActive = false;
			yield return ReloadOldActiveController(oldActiveIslands);
			if (NeedInterruptionAndReload)
			{
				yield break;
			}
		}
		List<WaitToCreateIsland> IslandIdsToCreate = new List<WaitToCreateIsland>();
		Dictionary<int, IslandConfigData> islandDict = WorldMapConfigHelper.Configs.Islands_Dict;
		foreach (int islandId in curVisibleIslandIds)
		{
			if (!ActiveObjects.ContainsKey(islandId))
			{
				IslandIdsToCreate.Add(new WaitToCreateIsland
				{
					Id = islandId,
					ManhattanDist = (int)PositionHelper.ManhattanDistance(islandDict[islandId].Pos2D, viewCenter)
				});
			}
		}
		SortInManhattanDistance(IslandIdsToCreate);
		List<int> newIslandIds = new List<int>();
		foreach (WaitToCreateIsland island in IslandIdsToCreate)
		{
			newIslandIds.Add(island.Id);
		}
		List<List<int>> waitToSyncIslandIds = newIslandIds.Slice(30);
		if (NeedReloadStates)
		{
			waitToSyncIslandIds.AddRange(oldActiveIslands.Keys.ToList().Slice(30));
		}
		yield return null;
		if (NeedInterruptionAndReload)
		{
			yield break;
		}
		List<IslandController> loadingIsland = new List<IslandController>();
		bool isWaitingReq = false;
		int islandParamIndex = 0;
		int islandLoadingIndex = 0;
		while (true)
		{
			int i = loadingIsland.Count - 1;
			while (i >= 0)
			{
				if (!loadingIsland[i].IsLoading)
				{
					loadingIsland.RemoveAt(i);
				}
				int num = i - 1;
				i = num;
			}
			while (loadingIsland.Count < 6 && islandLoadingIndex < newIslandIds.Count)
			{
				int id = newIslandIds[islandLoadingIndex++];
				IslandController islandController2 = ObjectPool.Get();
				ActiveObjects.Add(id, islandController2);
				islandController2.Load(id);
				loadingIsland.Add(islandController2);
			}
			if (islandParamIndex < waitToSyncIslandIds.Count && !isWaitingReq)
			{
				isWaitingReq = true;
				List<int> param = waitToSyncIslandIds[islandParamIndex++];
				Singleton<WorldStateManager>.Instance.GetIslandsState(param, delegate
				{
					isWaitingReq = false;
				});
			}
			if (loadingIsland.Count == 0 && islandParamIndex == waitToSyncIslandIds.Count && !isWaitingReq)
			{
				break;
			}
			yield return null;
			if (NeedInterruptionAndReload)
			{
				yield break;
			}
		}
		OnLoadingFinished?.Invoke();
	}

	private IEnumerator ReloadOldActiveController(Dictionary<int, IslandController> oldActive)
	{
		List<List<IslandController>> waitToReloadControllerBatches = oldActive.Values.ToList().Slice(6);
		foreach (List<IslandController> batch in waitToReloadControllerBatches)
		{
			foreach (IslandController controller in batch)
			{
				controller.Reload();
			}
			yield return null;
			if (NeedInterruptionAndReload)
			{
				yield break;
			}
		}
	}

	private void SortInManhattanDistance(List<WaitToCreateIsland> islandIdsToCreate)
	{
		islandIdsToCreate.Sort((WaitToCreateIsland a, WaitToCreateIsland b) => a.ManhattanDist - b.ManhattanDist);
	}

	public new void UnloadAll()
	{
		foreach (IslandController value in ActiveObjects.Values)
		{
			value.Unload();
		}
		base.UnloadAll();
	}

	public IslandController GetIslandController(int islandId)
	{
		ActiveObjects.TryGetValue(islandId, out var value);
		return value;
	}
}
