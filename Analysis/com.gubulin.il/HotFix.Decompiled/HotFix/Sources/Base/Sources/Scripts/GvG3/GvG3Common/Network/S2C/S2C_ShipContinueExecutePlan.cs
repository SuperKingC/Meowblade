using System;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.S2C;

[ProtoContract]
public class S2C_ShipContinueExecutePlan : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int EntityId;

		[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Model.ShipPlanStatusInfo")]
		public ShipPlanStatusInfo ShipPlanStatusInfo;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_ShipContinueExecutePlan()
	{
		base.PackageId = SocketManager.ePackageId.S2C_ShipContinueExecutePlan;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
