using System.Collections;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public class LineLoader : ObjectPoolingLoaderBase<string, LineController>
{
	private class WaitToCreateLine
	{
		public string Id;

		public int ManhattanDist;
	}

	private const int MaxSimultaneousLoading = 20;

	public LineLoader(Transform worldTrans)
		: base(worldTrans, "GvG/GvGLineBase", "Lines", 100)
	{
	}

	public override IEnumerator LazyUpdate()
	{
		if (NeedInterruptionAndReload)
		{
			yield break;
		}
		List<NavLineConfigData> lineConfigList = WorldMapConfigHelper.Configs.NavLine_List;
		Vector2 screenCenter = new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
		Vec2 viewCenter = PositionHelper.GetScreenToFloorPos(screenCenter);
		Rect loadingRect = new Rect(viewCenter.x - 175f, viewCenter.y - 87.5f, 350f, 175f);
		HashSet<string> newVisibleLineIds = new HashSet<string>();
		foreach (NavLineConfigData lineConfig in lineConfigList)
		{
			if (((Rect)(ref loadingRect)).Overlaps(lineConfig.ViewRect))
			{
				newVisibleLineIds.Add(lineConfig.Props.Id);
			}
		}
		Dictionary<string, LineController> newActiveLines = new Dictionary<string, LineController>();
		foreach (LineController lineController in ActiveObjects.Values)
		{
			if (newVisibleLineIds.Contains(lineController.LineId))
			{
				newActiveLines.Add(lineController.LineId, lineController);
				continue;
			}
			lineController.Unload();
			ObjectPool.Release(lineController);
		}
		ActiveObjects.Clear();
		ActiveObjects = newActiveLines;
		List<WaitToCreateLine> LineIdsToCreate = new List<WaitToCreateLine>();
		Dictionary<string, NavLineConfigData> posDict = WorldMapConfigHelper.Configs.NavLine_Dict;
		foreach (string lineId in newVisibleLineIds)
		{
			if (!ActiveObjects.ContainsKey(lineId))
			{
				LineIdsToCreate.Add(new WaitToCreateLine
				{
					Id = lineId,
					ManhattanDist = (int)PositionHelper.ManhattanDistance(posDict[lineId].Center, viewCenter)
				});
			}
		}
		if (NeedInterruptionAndReload)
		{
			yield break;
		}
		SortInManhattanDistance(LineIdsToCreate);
		yield return null;
		List<LineController> loadingLine = new List<LineController>();
		foreach (WaitToCreateLine line in LineIdsToCreate)
		{
			LineController lineController2 = ObjectPool.Get();
			ActiveObjects.Add(line.Id, lineController2);
			lineController2.Load(line.Id);
			loadingLine.Add(lineController2);
			while (NeedWaitForIdleLoadingTask(loadingLine, 20))
			{
				yield return null;
			}
			if (NeedInterruptionAndReload)
			{
				break;
			}
		}
		while (NeedWaitForIdleLoadingTask(loadingLine, 1))
		{
			yield return null;
		}
	}

	private void SortInManhattanDistance(List<WaitToCreateLine> lineIdsToCreate)
	{
		lineIdsToCreate.Sort((WaitToCreateLine a, WaitToCreateLine b) => a.ManhattanDist - b.ManhattanDist);
	}

	private bool NeedWaitForIdleLoadingTask(List<LineController> loadingList, int maxTaskCount)
	{
		if (loadingList.Count >= maxTaskCount)
		{
			for (int num = loadingList.Count - 1; num >= 0; num--)
			{
				if (!loadingList[num].IsLoading)
				{
					loadingList.RemoveAt(num);
				}
			}
			return true;
		}
		return false;
	}

	public new void UnloadAll()
	{
		base.UnloadAll();
	}
}
