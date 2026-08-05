using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Base.Scripts.Managers;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UnityEngine;

public class SaveGameDataSystem : BaseExecuteSystem
{
	private new readonly Contexts _contexts;

	public readonly int CheckingCycle;

	private int _i;

	private int SyncProduceMinInterval = 1;

	private DateTimeOffset lastSyncProduceAt;

	private int LastCheckUnshipOrders_IOS;

	private bool CheckingUnshipOrders_IOS;

	private int LastCheckUnshipOrders_Intl;

	private bool CheckingUnshipOrders_Intl;

	public SaveGameDataSystem(Contexts contexts)
		: base(contexts)
	{
		SyncProduceMinInterval = 1;
		_contexts = contexts;
		CheckingCycle = Mathf.RoundToInt(1f / contexts.Service<ITimeService>().FixedDeltaTime());
	}

	public override void Execute()
	{
		if (!_contexts.gameState.hasUser)
		{
			return;
		}
		if (_i % CheckingCycle == 0)
		{
			try
			{
				Save();
			}
			catch (Exception)
			{
			}
			_i = 0;
		}
		_i++;
	}

	private async void Save()
	{
		if (!_contexts.gameState.hasCharacterArchive || GameManagers.Instance == null || GameManagers.Instance.UserArchiveManager == null || !Contexts.sharedInstance.Service<BaseSceneService>().GetEnableMainCityProduce())
		{
			return;
		}
		DateTimeOffset now = DateTimeHelper.Now;
		bool getAllProduceStates = false;
		if (!Contexts.sharedInstance.Service<BaseSceneService>().get_FirstSyncAfterEnteredMainCity())
		{
			getAllProduceStates = true;
			Contexts.sharedInstance.Service<BaseSceneService>().SyncedAfterEnteredMainCity();
		}
		else if ((lastSyncProduceAt != default(DateTimeOffset) && (int)(now - lastSyncProduceAt).TotalSeconds < SyncProduceMinInterval) || !GameManagers.Instance.StockController.NeedSyncProduce)
		{
			return;
		}
		if (GameManagers.Instance.StockController.NeedGetAllProduceStatus)
		{
			GameManagers.Instance.StockController.NeedGetAllProduceStatus = false;
			getAllProduceStates = true;
		}
		SyncProduceResponse syncProdResponse = await _contexts.Service<INetworkService>().SyncProduce(-1L, getAllProduceStates);
		if (GameController.List_OrderID == null)
		{
			GameController.List_OrderID = new List<int>();
		}
		if ((getAllProduceStates || GameController.List_OrderID.Count > 0) && ((int)Application.platform == 11 || (int)Application.platform == 8 || (int)Application.platform == 7 || (int)Application.platform == 2 || (int)Application.platform == 1))
		{
			SyncPayOrder(await _contexts.Service<INetworkService>().CheckUnshipOrders());
		}
		if ((int)Application.platform == 8)
		{
			if (GameController.HasPendingOrders_IOS)
			{
				int serverTimestamp = (int)GameController.Instance.GetServerTime();
				if (LastCheckUnshipOrders_IOS == 0)
				{
					LastCheckUnshipOrders_IOS = serverTimestamp;
				}
				if (serverTimestamp - LastCheckUnshipOrders_IOS >= 10 && !CheckingUnshipOrders_IOS)
				{
					LastCheckUnshipOrders_IOS = serverTimestamp;
					CheckingUnshipOrders_IOS = true;
					Task<CheckUnshipOrders_IOS_Response> checkingTask = _contexts.Service<INetworkService>().CheckUnshipOrders_IOS();
					checkingTask.GetAwaiter().OnCompleted(delegate
					{
						CheckUnshipOrders_IOS_Response result = checkingTask.Result;
						if (result.Result)
						{
							GameController.HasPendingOrders_IOS = result.HasPendingOrders;
						}
						CheckingUnshipOrders_IOS = false;
					});
				}
			}
		}
		else if ((int)Application.platform == 11 && HotUpdateProcess.Instance.IsRegionOutCN && GameController.HasPendingOrders_Intl)
		{
			int serverTimestamp2 = (int)GameController.Instance.GetServerTime();
			if (LastCheckUnshipOrders_Intl == 0)
			{
				LastCheckUnshipOrders_Intl = serverTimestamp2;
			}
			if (serverTimestamp2 - LastCheckUnshipOrders_Intl >= 10 && !CheckingUnshipOrders_Intl)
			{
				LastCheckUnshipOrders_Intl = serverTimestamp2;
				CheckingUnshipOrders_Intl = true;
				Task<CheckUnshipOrders_Intl_Response> checkingTask2 = _contexts.Service<INetworkService>().CheckUnshipOrders_Intl();
				checkingTask2.GetAwaiter().OnCompleted(delegate
				{
					CheckUnshipOrders_Intl_Response result = checkingTask2.Result;
					if (result.Result)
					{
						GameController.HasPendingOrders_Intl = result.HasPendingOrders;
					}
					CheckingUnshipOrders_Intl = false;
				});
			}
		}
		lastSyncProduceAt = now;
		GameManagers.Instance.StockController.ReadStockChangeRecords(syncProdResponse.StockChangeRecords);
		GameManagers.Instance.StockController.SyncPendingConsumedStock(syncProdResponse.PendingStocks);
		GameManagers.Instance.ProduceManager.SyncProduceStatus(syncProdResponse);
		if (FGUIManager.Instance.MaincityUi != null)
		{
			FGUIManager.Instance.MaincityUi.MoneyNumInit = true;
		}
		Singleton<GvGCollectingManager>.Instance.SyncGvGCollectingProduce();
	}

	private void SyncPayOrder(CheckUnshipOrdersResponse _rsp)
	{
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Invalid comparison between Unknown and I4
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Invalid comparison between Unknown and I4
		if (_rsp.Orders == null)
		{
			return;
		}
		Order firstPaidOrder = null;
		foreach (Order order in _rsp.Orders)
		{
			if (firstPaidOrder == null && order.PaidTotal > 0f)
			{
				firstPaidOrder = order;
			}
			if (GameController.List_OrderID.IndexOf(order.OrderId) >= 0)
			{
				GameController.List_OrderID.Remove(order.OrderId);
			}
			GameManagers.Instance.StoreManager.ClaimStoreItem(order.StoreItemId);
			if (HotUpdateProcess.Instance.IsRegionOutCN)
			{
				float num = 0f;
				GDEStoreContentConfigData gDEStoreContentConfigData = GDMgr.Get<GDEStoreContentConfigData>(order.StoreItemId);
				if (gDEStoreContentConfigData != null && !string.IsNullOrEmpty(gDEStoreContentConfigData.InternationalPrice))
				{
					List<Dictionary<string, int>> list = JsonHelper.ToObject<List<Dictionary<string, int>>>(gDEStoreContentConfigData.InternationalPrice);
					Dictionary<string, int> dictionary = list[0];
					num = dictionary.Values.First();
				}
				ThinkingDataHelper.Instance.OrderFinishedTrack(order.OrderId, order.StoreItemId, "USD", num, order.Payment);
				EventManager.LogPurchase(order, 1, num);
				FGUIManager.Instance.Stats_Dynamic_SignInParallel(num);
			}
			else
			{
				ThinkingDataHelper.Instance.OrderFinishedTrack(order.OrderId, order.StoreItemId, "RMB", order.PaidTotal, order.Payment);
				FGUIManager.Instance.Stats_Dynamic_SignInParallel(order.PaidTotal);
			}
			EventManager.LogSpecificStoreItemsForFacebook(order.StoreItemId);
		}
		bool flag = GameManagers.Instance.UserArchiveManager.IsRechargeFirstTime();
		float deltaRechargeTotal = _rsp.RechargeTotal - GameManagers.Instance.UserArchiveManager.GetTotalRecharge();
		if (deltaRechargeTotal > float.Epsilon && flag)
		{
			GameManagers.Instance.UserArchiveManager.SetTotalRecharge(_rsp.RechargeTotal);
			SharedMessenger.Broadcast("ON_RECHARGE", deltaRechargeTotal);
			if ((int)Application.platform == 8)
			{
				AndroidBasicPlugInManager.Instance.GetIp(delegate
				{
					OceanEngineEventManager.Instance.InvokeAction(OceanEngineEventManager.eventType.Pay, firstPaidOrder.StoreItemId, 1, firstPaidOrder.Payment, firstPaidOrder.Currency, firstPaidOrder.PaidTotal);
					TapTapEventManager.Instance.InvokeAction_IOS(TapTapEventManager.TapTapEventType.Pay, deltaRechargeTotal * 100f);
					BiliBiliEventManager.Instance.InvokeAction(BiliBiliEventManager.BiliBiliEventType.USER_COST);
				});
			}
			else if ((int)Application.platform == 11)
			{
				AndroidBasicPlugInManager.Instance.GetIp(delegate
				{
					if (HotUpdateProcess.ChannelCode == "taptap" || HotUpdateProcess.ChannelCode == "tapplay")
					{
						TapTapEventManager.Instance.InvokeAction(TapTapEventManager.TapTapEventType.Pay, deltaRechargeTotal * 100f);
					}
					else if (HotUpdateProcess.ChannelCode == "bilibili")
					{
						BiliBiliEventManager.Instance.InvokeAction(BiliBiliEventManager.BiliBiliEventType.USER_COST);
					}
					else if (HotUpdateProcess.ChannelCode == "toutiao-android")
					{
						if (firstPaidOrder == null)
						{
							ILRuntimeDebug.LogError($"deltaRechargeTotal={deltaRechargeTotal} but firstPaidOrder is null");
						}
						else
						{
							OceanEngineEventManager.Instance.InvokeAction(OceanEngineEventManager.eventType.Pay, firstPaidOrder.StoreItemId, 1, firstPaidOrder.Payment, firstPaidOrder.Currency, firstPaidOrder.PaidTotal);
						}
					}
					else if (HotUpdateProcess.ChannelCode == "gdt-android")
					{
						if (firstPaidOrder == null)
						{
							ILRuntimeDebug.LogError($"deltaRechargeTotal={deltaRechargeTotal} but firstPaidOrder is null");
						}
						else
						{
							((GDTSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GDT]).OnPurchase(firstPaidOrder.StoreItemId, 1, firstPaidOrder.Payment, (int)(firstPaidOrder.PaidTotal * 100f));
						}
					}
				});
			}
		}
		GameManagers.Instance.UserArchiveManager.SetTotalRecharge(_rsp.RechargeTotal);
	}
}
