using System;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class S2C_IslandAction : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int EntityId;

		[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model.FlightSchedule")]
		public FlightSchedule FlightSchedule;

		[ProtoMember(3)]
		public int ShipState;

		[ProtoMember(4)]
		public int ShipTargetIslandId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_IslandAction()
	{
		base.PackageId = SocketManager.ePackageId.S2C_IslandAction;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
