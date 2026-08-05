using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;

public class GvGCollectingManager : Singleton<GvGCollectingManager>
{
	private float SyncGvGProduceMinInterval = 30f;

	private float NextSyncTime = 0f;

	public Dictionary<string, ShipCollectingModel> ShipCollecting_Dict = new Dictionary<string, ShipCollectingModel>();

	public List<ShipCollectingModel> ShipCollecting_List = new List<ShipCollectingModel>();

	public int CampId;

	public Action OnCollectingSync = delegate
	{
	};

	public void SyncGvGCollectingProduce(bool forceRefresh = false)
	{
		if (!Define.GvGMode3UnderDevelopment())
		{
			return;
		}
		float now = Time.realtimeSinceStartup;
		if (!forceRefresh && now < NextSyncTime)
		{
			return;
		}
		NextSyncTime = now + SyncGvGProduceMinInterval;
		Singleton<GvGMode3RoomManager>.Instance.GetGSObserverRecord(delegate
		{
			ShipCollecting_Dict.Clear();
			ShipCollecting_List.Clear();
			GvGMode3ObserverRecord ob = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord;
			if (!ob.HasEnterIZ)
			{
				NextSyncTime = now + 10f;
				OnCollectingSync?.Invoke();
			}
			else
			{
				CampId = ob.ObCampId;
				ILRequestHelper<SyncGvGProduceResponse>.Request((EventContext)null, (Func<Task<SyncGvGProduceResponse>>)(() => GameController.Contexts.Service<INetworkService>().SyncGvGProduce(-1L)), (Action<SyncGvGProduceResponse>)delegate(SyncGvGProduceResponse response)
				{
					if (response.Result)
					{
						Dictionary<string, List<ProduceState>> dictionary = response.ShipProduceStates ?? new Dictionary<string, List<ProduceState>>();
						List<ProduceState> list = new List<ProduceState>();
						if (ob.Ships != null)
						{
							foreach (GvGMode3ShipModel ship in ob.Ships)
							{
								if (dictionary.TryGetValue(ship.ShipId, out var value) && value != null && value.Count == 0)
								{
									value = null;
								}
								ShipCollectingModel shipCollectingModel = new ShipCollectingModel
								{
									ShipId = ship.ShipId,
									ShipRace = (eRace)ship.PermanentData.ShipRace,
									Index = ship.PermanentData.Index,
									WorkersStates = value
								};
								ShipCollecting_Dict.Add(shipCollectingModel.ShipId, shipCollectingModel);
								ShipCollecting_List.Add(shipCollectingModel);
								if (value != null)
								{
									list.AddRange(value);
								}
							}
						}
						ShipCollecting_List.Sort(SortByShipIndex);
						SyncProduceResponse res = new SyncProduceResponse
						{
							StockChangeRecords = response.StockChangeRecords,
							ProduceStates = list.ToArray(),
							PendingStocks = response.PendingStocks
						};
						GameManagers.Instance.ProduceManager.SyncProduceStatus(res);
						OnCollectingSync?.Invoke();
					}
				});
			}
		});
	}

	private int SortByShipIndex(ShipCollectingModel a, ShipCollectingModel b)
	{
		return a.Index.CompareTo(b.Index);
	}
}
