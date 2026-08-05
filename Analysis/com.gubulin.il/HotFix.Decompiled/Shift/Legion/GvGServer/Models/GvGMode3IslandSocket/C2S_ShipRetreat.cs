using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;

[ProtoContract]
public class C2S_ShipRetreat : SocketManager.BaseSocketPackageBodyContext
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
	}

	public C2S_ShipRetreat()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ShipRetreat;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
