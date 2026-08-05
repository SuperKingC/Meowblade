using System;
using System.Threading.Tasks;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.RPC.Api;

public class StoreApi : Api
{
	public Task<PlaceOrderResponse> PlaceOrder(string storeItemId, string paymentType, int priceIndex = -1, int quantity = 1, string payParams = "")
	{
		TaskCompletionSource<PlaceOrderResponse> tcs = new TaskCompletionSource<PlaceOrderResponse>();
		RPCConnection.QueueRequest(new PlaceOrderRequest
		{
			StoreItemId = storeItemId,
			PaymentType = paymentType,
			PriceIndex = priceIndex,
			Qty = quantity,
			PayParams = payParams
		}, delegate(RPCContext context)
		{
			try
			{
				PlaceOrderResponse result = context.Payload.As<PlaceOrderResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<CheckOrderResponse> CheckOrder(string orderId, string transactionId, string orderMsg = "")
	{
		TaskCompletionSource<CheckOrderResponse> tcs = new TaskCompletionSource<CheckOrderResponse>();
		RPCConnection.QueueRequest(new CheckOrderRequest
		{
			OrderId = orderId,
			TransactionId = transactionId,
			OrderMsg = orderMsg
		}, delegate(RPCContext context)
		{
			try
			{
				CheckOrderResponse result = context.Payload.As<CheckOrderResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<SyncPendingReceiptsResponse> SyncPendingReceipts(string productId, string receipt)
	{
		TaskCompletionSource<SyncPendingReceiptsResponse> tcs = new TaskCompletionSource<SyncPendingReceiptsResponse>();
		RPCConnection.QueueRequest(new SyncPendingReceiptsRequest
		{
			ProductId = productId,
			Receipt = receipt
		}, delegate(RPCContext context)
		{
			try
			{
				SyncPendingReceiptsResponse result = context.Payload.As<SyncPendingReceiptsResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}
}
