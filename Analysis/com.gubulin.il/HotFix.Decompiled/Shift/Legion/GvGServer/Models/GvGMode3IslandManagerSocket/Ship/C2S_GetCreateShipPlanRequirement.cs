using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Ship;

[ProtoContract]
public class C2S_GetCreateShipPlanRequirement : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string ShipId;

		[ProtoMember(2)]
		public int TargetIslandId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int 代理作战Count;

		[ProtoMember(3)]
		public int FoodCost;

		[ProtoMember(4, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.RealTimeFoodCostReduceModel")]
		public RealTimeFoodCostReduceModel Model;
	}

	public C2S_GetCreateShipPlanRequirement()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetCreateShipPlanRequirement;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
