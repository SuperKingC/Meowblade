using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.RPC.Api;

public class CommonApi : Api
{
	private DateTime _lastPingTime;

	private static int i = 3;

	public void KeepAlive()
	{
		if (!GameController.Contexts.gameState.isDataReady || string.IsNullOrEmpty(RPCConnection.Token) || !(DateTime.UtcNow.Subtract(_lastPingTime).TotalMilliseconds > 2000.0))
		{
			return;
		}
		_lastPingTime = DateTime.UtcNow;
		long ms = DateTimeHelper.Now.ToUnixTimeMilliseconds();
		RPCConnection.QueueRequest(new PingRequest(), delegate(RPCContext context)
		{
			try
			{
				PingResponse pingResponse = context.Payload.As<PingResponse>();
				List<PushItem> pushItems = pingResponse.PushItems;
				if (pushItems != null)
				{
					foreach (PushItem item in pushItems)
					{
						SharedMessenger.Broadcast("ON_PING_PUSH_ITEM", item);
					}
				}
			}
			catch (Exception)
			{
			}
			if (i > 0)
			{
				float num = DateTimeHelper.Now.ToUnixTimeMilliseconds() - ms;
				ThinkingDataHelper.Instance.PingRecord((int)(num * 1000f));
				i--;
			}
		});
	}

	public Task<PullDataResponse> PullData()
	{
		TaskCompletionSource<PullDataResponse> tcs = new TaskCompletionSource<PullDataResponse>();
		RPCConnection.QueueRequest(new PullDataRequest(), delegate(RPCContext context)
		{
			try
			{
				PullDataResponse result = context.Payload.As<PullDataResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<ServerInfoResponse> ServerInfo()
	{
		TaskCompletionSource<ServerInfoResponse> tcs = new TaskCompletionSource<ServerInfoResponse>();
		RPCConnection.QueueRequest(new ServerInfoRequest(), delegate(RPCContext context)
		{
			try
			{
				ServerInfoResponse result = context.Payload.As<ServerInfoResponse>();
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
