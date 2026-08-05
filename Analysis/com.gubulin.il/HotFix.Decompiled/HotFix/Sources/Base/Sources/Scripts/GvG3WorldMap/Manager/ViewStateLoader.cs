using System.Collections;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.Common.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public class ViewStateLoader : DataLoaderBase
{
	private const int MaxSimultaneousShipLoading = 30;

	private HashSet<int> LastShipIds;

	public eLoaderMode Mode = eLoaderMode.ChangePos;

	public ViewStateLoader()
	{
		LastShipIds = new HashSet<int>();
	}

	public override IEnumerator Reload()
	{
		WorldStateManager worldStateManager = Singleton<WorldStateManager>.Instance;
		yield return null;
		if (NeedInterruptionAndReload)
		{
			yield break;
		}
		Vector2 screenCenter = new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
		Vec2 viewCenter = PositionHelper.GetScreenToFloorPos(screenCenter);
		bool isWaitingReq = true;
		if (Mode == eLoaderMode.ChangePos)
		{
			worldStateManager.GetEOIEntityIdsByCameraPos(viewCenter, delegate
			{
				isWaitingReq = false;
			});
		}
		else if (Mode == eLoaderMode.SyncChanges)
		{
			worldStateManager.GetNeedToSyncEOIEntityIdsByCameraPos(viewCenter, delegate
			{
				isWaitingReq = false;
			});
		}
		while (isWaitingReq)
		{
			yield return null;
			if (NeedInterruptionAndReload)
			{
				yield break;
			}
		}
		List<int> newShipIds = null;
		if (Mode == eLoaderMode.ChangePos)
		{
			newShipIds = new List<int>();
			HashSet<int> remainingShipIds = new HashSet<int>();
			foreach (int id in worldStateManager.Data.EOI_ShipSimpleEntityIds)
			{
				if (!LastShipIds.Contains(id))
				{
					newShipIds.Add(id);
				}
				else
				{
					remainingShipIds.Add(id);
				}
			}
			LastShipIds = remainingShipIds;
		}
		else if (Mode == eLoaderMode.SyncChanges)
		{
			newShipIds = worldStateManager.Data.EOI_ShipSimpleEntityIds;
		}
		List<List<int>> waitToSyncShipIds = newShipIds.Slice(30);
		bool isWaitingReq2 = false;
		int shipParamIndex = 0;
		while (shipParamIndex < waitToSyncShipIds.Count && !NeedInterruptionAndReload)
		{
			if (shipParamIndex < waitToSyncShipIds.Count && !isWaitingReq2)
			{
				isWaitingReq2 = true;
				List<int> param = waitToSyncShipIds[shipParamIndex++];
				LastShipIds.UnionWith(param);
				worldStateManager.GetShipsState(param, delegate
				{
					isWaitingReq2 = false;
				});
			}
			yield return (object)new WaitForSeconds(0.5f);
		}
		while (isWaitingReq2)
		{
			yield return null;
		}
	}

	public void ClearCache()
	{
		LastShipIds.Clear();
	}

	public new void UnloadAll()
	{
	}
}
