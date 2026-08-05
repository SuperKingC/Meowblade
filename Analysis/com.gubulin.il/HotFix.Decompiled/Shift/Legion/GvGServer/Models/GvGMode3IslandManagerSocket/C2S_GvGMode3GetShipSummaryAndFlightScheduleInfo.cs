using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GvGMode3GetShipSummaryAndFlightScheduleInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public List<int> ShipEntityIds;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model.GvGMode3GetShipSummaryAndFlightScheduleInfo")]
		public List<GvGMode3GetShipSummaryAndFlightScheduleInfo> Infos;
	}

	public C2S_GvGMode3GetShipSummaryAndFlightScheduleInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GvGMode3GetShipSummaryAndFlightScheduleInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
