using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3.Collecting;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetRealTimeShipSummarySpeedModel : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string ShipId;

		[ProtoMember(2)]
		public int TargetIslandId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Collecting.RealTimeShipSummarySpeedModel")]
		public RealTimeShipSummarySpeedModel Model;
	}

	public C2S_GetRealTimeShipSummarySpeedModel()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetRealTimeShipSummarySpeedModel;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
