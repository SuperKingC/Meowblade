using System;
using System.Collections.Generic;
using GvG2.Common.Models;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.IslandManagerSocket;

[ProtoContract]
public class S2C_IslandSummary : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1, TypeName = "GvG2.Common.Models.IslandSummary")]
		public List<IslandSummary> IslandSummaries;
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

	public S2C_IslandSummary()
	{
		base.PackageId = SocketManager.ePackageId.S2C_IslandSummary;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
