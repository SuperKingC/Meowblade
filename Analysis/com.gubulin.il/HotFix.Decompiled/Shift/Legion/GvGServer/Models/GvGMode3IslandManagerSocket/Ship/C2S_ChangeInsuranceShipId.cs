using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Ship;

[ProtoContract]
public class C2S_ChangeInsuranceShipId : SocketManager.BaseSocketPackageBodyContext
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
	}

	public C2S_ChangeInsuranceShipId()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ChangeInsuranceShipId;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
