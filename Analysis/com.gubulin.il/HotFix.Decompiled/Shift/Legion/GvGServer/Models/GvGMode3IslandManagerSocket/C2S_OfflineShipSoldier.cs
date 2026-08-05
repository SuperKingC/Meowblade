using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_OfflineShipSoldier : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(2)]
		public string ShipId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_OfflineShipSoldier()
	{
		base.PackageId = SocketManager.ePackageId.C2S_OfflineShipSoldier;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
