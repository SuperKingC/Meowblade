using System;
using System.Threading.Tasks;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Announcement;

namespace Shift.Legion.ClientApi.RPC.Api;

public class AnnouncementApi : Api
{
	private static bool isfirst = true;

	public Task<AnnouncementListResponse> GetAnnouncementList()
	{
		TaskCompletionSource<AnnouncementListResponse> tcs = new TaskCompletionSource<AnnouncementListResponse>();
		RPCConnection.QueueRequest(new AnnouncementListRequest(), delegate(RPCContext context)
		{
			try
			{
				if (isfirst)
				{
					isfirst = false;
					Type typeFromHandle = typeof(AnnouncementListResponse);
					PType.RegisterType(typeFromHandle.FullName, typeFromHandle);
				}
				AnnouncementListResponse result = context.Payload.As<AnnouncementListResponse>();
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
