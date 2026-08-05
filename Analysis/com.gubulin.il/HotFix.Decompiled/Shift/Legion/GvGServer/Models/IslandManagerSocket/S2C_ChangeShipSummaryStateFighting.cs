using System;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.IslandManagerSocket;

[ProtoContract]
public class S2C_ChangeShipSummaryStateFighting : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ShipSummaryState;

		[ProtoMember(2)]
		public int ShipSummaryStayIslandId;

		[ProtoMember(3)]
		public int IslandPid;

		[ProtoMember(4)]
		public int IslandExternalSocketPort;
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

	public S2C_ChangeShipSummaryStateFighting()
	{
		base.PackageId = SocketManager.ePackageId.S2C_ChangeShipSummaryStateFighting;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
