using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.IslandManagerSocket;

[ProtoContract]
public class C2S_GetShipSummaryAndFlightSchedule : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public List<int> EntityIds;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.IslandManagerSocket.C2S_GetShipSummaryAndFlightScheduleInfo")]
		public List<C2S_GetShipSummaryAndFlightScheduleInfo> Infos;
	}

	public C2S_GetShipSummaryAndFlightSchedule()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetShipSummaryAndFlightSchedule;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
