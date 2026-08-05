using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3.RealTime;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Ship;

[ProtoContract]
public class C2S_GetRealTimeGroupCountLimitModel : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string NonStr;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.RealTime.RealTimeGroupCountLimitModel")]
		public RealTimeGroupCountLimitModel Model;
	}

	public C2S_GetRealTimeGroupCountLimitModel()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetRealTimeGroupCountLimitModel;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
