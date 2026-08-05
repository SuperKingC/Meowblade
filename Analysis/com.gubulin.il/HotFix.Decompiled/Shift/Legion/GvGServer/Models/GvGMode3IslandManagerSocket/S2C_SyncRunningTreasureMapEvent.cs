using System;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class S2C_SyncRunningTreasureMapEvent : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int MUID;

		[ProtoMember(2)]
		public string MConfigId;

		[ProtoMember(3)]
		public int IslandId;

		[ProtoMember(4)]
		public long Timestamp_ms;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_SyncRunningTreasureMapEvent()
	{
		base.PackageId = SocketManager.ePackageId.S2C_SyncRunningTreasureMapEvent;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
