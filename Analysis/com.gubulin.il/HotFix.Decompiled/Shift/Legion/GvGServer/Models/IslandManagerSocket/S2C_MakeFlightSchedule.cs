using System;
using GvG2.Common.Models;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.IslandManagerSocket;

[ProtoContract]
public class S2C_MakeFlightSchedule : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int EntityId;

		[ProtoMember(2, TypeName = "GvG2.Common.Models.FlightSchedule")]
		public FlightSchedule FlightSchedule;

		[ProtoMember(3)]
		public int ShipSummaryState;

		[ProtoMember(4)]
		public int ShipSummaryStayIslandId;
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

	public S2C_MakeFlightSchedule()
	{
		base.PackageId = SocketManager.ePackageId.S2C_MakeFlightSchedule;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
