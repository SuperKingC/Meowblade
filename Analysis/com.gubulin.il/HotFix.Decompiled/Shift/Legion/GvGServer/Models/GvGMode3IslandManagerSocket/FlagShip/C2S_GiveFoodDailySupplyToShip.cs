using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

[ProtoContract]
public class C2S_GiveFoodDailySupplyToShip : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string ShipId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int ShipCur;

		[ProtoMember(3)]
		public int FlagShipCur;
	}

	public C2S_GiveFoodDailySupplyToShip()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GiveFoodDailySupplyToShip;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
