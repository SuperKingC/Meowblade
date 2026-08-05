using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Sweep;

public class C2S_BuySweepCount : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public bool IsBuyCount;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int RemainingSweepCount;

		[ProtoMember(3)]
		public int TodayPurchasedCount;

		[ProtoMember(4)]
		public int TodayRefillCountByPurchase;
	}

	public C2S_BuySweepCount()
	{
		base.PackageId = SocketManager.ePackageId.C2S_BuySweepCount;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
