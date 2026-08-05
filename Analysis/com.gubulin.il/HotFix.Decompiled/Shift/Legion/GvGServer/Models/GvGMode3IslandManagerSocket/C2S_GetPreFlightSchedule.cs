using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetPreFlightSchedule : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string ShipId;

		[ProtoMember(2)]
		public int StartId;

		[ProtoMember(3)]
		public int EndId;

		[ProtoMember(4)]
		public int Action;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public float FlyDist;

		[ProtoMember(3)]
		public long FoodCost;

		[ProtoMember(4)]
		public int ShipSummarySpeed;

		[ProtoMember(5)]
		public int TimeCost;

		[ProtoMember(6)]
		public int[] Route;

		[ProtoMember(7)]
		public int JumpDist;

		[ProtoMember(8)]
		public int JumpFoodCost;

		[ProtoMember(9)]
		public int FreeJumps;
	}

	public C2S_GetPreFlightSchedule()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetPreFlightSchedule;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
