using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetShipNearestFlagShipOrMoonIsland : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ShipEntityId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int IslandId;
	}

	public C2S_GetShipNearestFlagShipOrMoonIsland()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetShipNearestFlagShipOrMoonIsland;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
