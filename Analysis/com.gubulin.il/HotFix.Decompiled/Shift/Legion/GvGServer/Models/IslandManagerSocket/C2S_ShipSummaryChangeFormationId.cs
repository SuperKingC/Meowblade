using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.IslandManagerSocket;

public class C2S_ShipSummaryChangeFormationId : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ShipEntityId;

		[ProtoMember(2)]
		public string FormationId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_ShipSummaryChangeFormationId()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ShipSummaryChangeFormationId;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
