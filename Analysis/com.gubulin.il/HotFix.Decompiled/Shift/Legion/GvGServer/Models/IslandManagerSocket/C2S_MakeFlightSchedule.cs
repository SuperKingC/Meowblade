using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.IslandManagerSocket;

[ProtoContract]
public class C2S_MakeFlightSchedule : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ShipEntityId;

		[ProtoMember(2)]
		public int StartId;

		[ProtoMember(3)]
		public int EndId;

		[ProtoMember(4)]
		public bool IsBackToCampBaseAndFillUp;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_MakeFlightSchedule()
	{
		base.PackageId = SocketManager.ePackageId.C2S_MakeFlightSchedule;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
