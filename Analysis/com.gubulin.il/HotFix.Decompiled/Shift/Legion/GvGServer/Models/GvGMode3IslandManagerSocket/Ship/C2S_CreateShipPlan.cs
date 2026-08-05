using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Ship;

[ProtoContract]
public class C2S_CreateShipPlan : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string ShipId;

		[ProtoMember(2)]
		public int PlanType;

		[ProtoMember(3)]
		public int PlanExecuteTimestamp;

		[ProtoMember(4)]
		public int PlanAttackCount;

		[ProtoMember(5)]
		public int TargetIslandId;

		[ProtoMember(6, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.TakeOutSoldierInfo")]
		public List<TakeOutSoldierInfo> TakeOutSoldier;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_CreateShipPlan()
	{
		base.PackageId = SocketManager.ePackageId.C2S_CreateShipPlan;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
