using System;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class S2C_SyncFinalProgressInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(99)]
		public int ErrorCode;

		[ProtoMember(1)]
		public int Progress;

		[ProtoMember(2)]
		public int Step;

		[ProtoMember(3)]
		public bool HasSettlement;

		[ProtoMember(4)]
		public int SettlementTimestamp;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_SyncFinalProgressInfo()
	{
		base.PackageId = SocketManager.ePackageId.S2C_SyncFinalProgressInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
