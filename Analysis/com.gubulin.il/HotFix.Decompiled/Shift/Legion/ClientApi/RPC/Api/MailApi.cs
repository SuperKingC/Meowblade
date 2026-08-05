using System;
using System.Threading.Tasks;
using Shift.Legion.ClientApi.Protocol.Archive;
using Shift.Legion.ClientApi.Protocol.Mailing;

namespace Shift.Legion.ClientApi.RPC.Api;

public class MailApi : Api
{
	public Task<MailListResponse> GetMailListAsync()
	{
		TaskCompletionSource<MailListResponse> tcs = new TaskCompletionSource<MailListResponse>();
		RPCConnection.QueueRequest(new MailListRequest(), delegate(RPCContext context)
		{
			try
			{
				MailListResponse result = context.Payload.As<MailListResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<bool> MarkAsReadAsync(int id)
	{
		TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		RPCConnection.QueueRequest(new MailOperation
		{
			Id = id,
			Operation = 0
		}, delegate
		{
			tcs.SetResult(result: true);
		});
		return tcs.Task;
	}

	public Task<bool> MarkAllAsReadAsync()
	{
		TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		RPCConnection.QueueRequest(new MailOperation
		{
			Id = 0,
			Operation = 1
		}, delegate
		{
			tcs.SetResult(result: true);
		});
		return tcs.Task;
	}

	public Task<bool> DeleteMailAsync(int id)
	{
		TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		RPCConnection.QueueRequest(new MailOperation
		{
			Id = id,
			Operation = 2
		}, delegate
		{
			tcs.SetResult(result: true);
		});
		return tcs.Task;
	}

	public Task<bool> DeleteAllAsync()
	{
		TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		RPCConnection.QueueRequest(new MailOperation
		{
			Id = 0,
			Operation = 3
		}, delegate
		{
			tcs.SetResult(result: true);
		});
		return tcs.Task;
	}

	public Task<MailOperateResponse> ClaimMailPayloadsAsync(int id)
	{
		TaskCompletionSource<MailOperateResponse> tcs = new TaskCompletionSource<MailOperateResponse>();
		RPCConnection.QueueRequest(new MailOperation
		{
			Id = id,
			Operation = 4
		}, delegate(RPCContext context)
		{
			try
			{
				MailOperateResponse result = context.Payload.As<MailOperateResponse>();
				tcs.SetResult(result);
			}
			catch (Exception)
			{
				tcs.SetResult(null);
			}
		});
		return tcs.Task;
	}

	public Task<MailOperateResponse> ClaimAllPayloadsAsync()
	{
		TaskCompletionSource<MailOperateResponse> tcs = new TaskCompletionSource<MailOperateResponse>();
		RPCConnection.QueueRequest(new MailOperation
		{
			Id = 0,
			Operation = 5
		}, delegate(RPCContext context)
		{
			try
			{
				MailOperateResponse result = context.Payload.As<MailOperateResponse>();
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
