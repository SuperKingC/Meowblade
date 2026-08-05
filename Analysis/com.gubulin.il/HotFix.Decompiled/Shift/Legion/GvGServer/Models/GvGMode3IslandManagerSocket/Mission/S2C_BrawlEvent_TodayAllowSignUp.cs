using System;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class S2C_BrawlEvent_TodayAllowSignUp : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int Non;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_BrawlEvent_TodayAllowSignUp()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BrawlEvent_TodayAllowSignUp;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
