using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class S2C_GetFinalProgressBossDamageTodayTop3 : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgressBossDamageInfo")]
		public List<FinalProgressBossDamageInfo> TodayTop3;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_GetFinalProgressBossDamageTodayTop3()
	{
		base.PackageId = SocketManager.ePackageId.S2C_GetFinalProgressBossDamageTodayTop3;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
