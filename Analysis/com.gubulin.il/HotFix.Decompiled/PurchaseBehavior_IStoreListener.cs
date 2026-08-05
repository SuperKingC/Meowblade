using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;
using UI.Tips;
using UnityEngine;
using UnityEngine.Purchasing;

public class PurchaseBehavior_IStoreListener
{
	public StoreController _purchaseController;

	public TaskCompletionSource<bool> _purchaseInitTaskCompletionSource;

	public Action<string, string, string, string, int> CheckOrderAction;

	public int lastPendingOrderId = 0;

	public PendingOrder LastPendingOrder;

	public void RegistStoreListener(StoreController storeController)
	{
		_purchaseController = storeController;
		_purchaseController.OnStoreDisconnected += OnStoreDisconnected;
		_purchaseController.OnProductsFetched += OnProductsFetched;
		_purchaseController.OnProductsFetchFailed += OnProductsFetchFailed;
		_purchaseController.OnPurchasesFetchFailed += OnPurchasesFetchFailed;
		_purchaseController.OnPurchasePending += OnPurchasePending;
		_purchaseController.OnPurchasesFetched += OnPurchasesFetched;
		_purchaseController.OnPurchaseFailed += OnPurchaseFailed;
	}

	private void OnStoreDisconnected(StoreConnectionFailureDescription failureDesc)
	{
		GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
		SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("StoreConnectFailedTip") + ":" + failureDesc.Message }, 121, arg3: false);
		_purchaseInitTaskCompletionSource?.TrySetResult(result: false);
	}

	private void OnProductsFetched(IList<Product> products)
	{
		GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
		_purchaseInitTaskCompletionSource?.TrySetResult(result: true);
	}

	private void OnProductsFetchFailed(ProductFetchFailed failureDesc)
	{
		GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
		SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("ProductFetchFailedTip") + ":" + failureDesc.FailureReason }, 121, arg3: false);
		string text = "PurchaseBehavior UnityPurchasing OnProductsFetchFailed:" + failureDesc.FailureReason;
		if (failureDesc.FailedFetchProducts.Count > 0)
		{
			text += " ,Products:";
			foreach (ProductDefinition failedFetchProduct in failureDesc.FailedFetchProducts)
			{
				text = text + failedFetchProduct.id + ", ";
			}
			text = text.TrimEnd(' ', ',');
		}
		else
		{
			text += ", No FailedFetchProducts";
		}
		ILRuntimeDebug.LogError(text);
		_purchaseInitTaskCompletionSource?.TrySetResult(result: false);
	}

	private void OnPurchasesFetchFailed(PurchasesFetchFailureDescription failureDesc)
	{
		GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
		SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("PurchasesFetchFailed") + ":" + failureDesc.Message }, 121, arg3: false);
	}

	private void OnPurchasesFetched(Orders orders)
	{
		foreach (PendingOrder pendingOrder in orders.PendingOrders)
		{
			OnPurchasePending(pendingOrder);
		}
	}

	private void OnPurchasePending(PendingOrder pendingOrder)
	{
		LastPendingOrder = pendingOrder;
		ProcessPurchase();
	}

	private void ProcessPurchase()
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Invalid comparison between Unknown and I4
		GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: true);
		if (LastPendingOrder == null)
		{
			return;
		}
		IOrderInfo info = ((Order)LastPendingOrder).Info;
		IPurchasedProductInfo val = info.PurchasedProductInfo[0];
		string productId = val.productId;
		string transactionID = info.TransactionID;
		string text = info.Receipt;
		if ((int)Application.platform == 8)
		{
			if (string.IsNullOrEmpty(text) || text.IndexOf("}", StringComparison.Ordinal) < 0)
			{
				IAppleOrderInfo apple = info.Apple;
				text = "{\"JwsRepresentation\":\"" + ((apple != null) ? apple.jwsRepresentation : null) + "\"}";
			}
			else
			{
				string text3;
				if (text.Replace(" ", "").Length <= 2)
				{
					string text2 = text;
					IAppleOrderInfo apple2 = info.Apple;
					text3 = text2.Replace("}", "\"JwsRepresentation\":\"" + ((apple2 != null) ? apple2.jwsRepresentation : null) + "\"}");
				}
				else
				{
					string text4 = text;
					IAppleOrderInfo apple3 = info.Apple;
					text3 = text4.Replace("}", ",\"JwsRepresentation\":\"" + ((apple3 != null) ? apple3.jwsRepresentation : null) + "\"}");
				}
				text = text3;
			}
		}
		if (lastPendingOrderId > 0)
		{
			CheckOrderAction?.Invoke(lastPendingOrderId.ToString(), productId, transactionID, text, 5);
			return;
		}
		Task<SyncPendingReceiptsResponse> task = GameController.Contexts.Service<INetworkService>().SyncPendingReceipts(productId, text);
		task.GetAwaiter().OnCompleted(delegate
		{
		});
		_purchaseController.ConfirmPurchase(LastPendingOrder);
		lastPendingOrderId = 0;
		LastPendingOrder = null;
		GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
	}

	public void OnPurchaseFailed(FailedOrder failedOrder)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		lastPendingOrderId = 0;
		GameController.Contexts.Service<IUiService>().ShowPaymentWaitingAnimation(show: false);
		SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { string.Format("{0}: {1}", LanguagesManager.GetDesc("CsharpCodeZhTcText62"), failedOrder.FailureReason) }, 121, arg3: false);
		if ((int)Application.platform == 8)
		{
			UI_TakeItems.TakeItemsPanel?.End();
		}
	}
}
