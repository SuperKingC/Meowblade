using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

[ProtoContract]
public class C2S_GetCampEnergy : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int non;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int CampEnergy;

		[ProtoMember(3)]
		public int IslandCount;

		[ProtoMember(4, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip.CampEnergyDetailInfo")]
		public List<CampEnergyDetailInfo> CampEnergyDetailInfos;

		[ProtoMember(5)]
		public int BrawlEventCampEnergyLastDay;

		[ProtoMember(6)]
		public int BrawlEventRankLastDay;
	}

	public C2S_GetCampEnergy()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetCampEnergy;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
