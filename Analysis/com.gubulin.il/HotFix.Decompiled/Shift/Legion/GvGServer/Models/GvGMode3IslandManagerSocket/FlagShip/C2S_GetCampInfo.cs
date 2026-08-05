using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

[ProtoContract]
public class C2S_GetCampInfo : SocketManager.BaseSocketPackageBodyContext
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
		public int CampUserCount;

		[ProtoMember(3)]
		public int CampShipCount;

		[ProtoMember(4)]
		public int IslandCount;

		[ProtoMember(5, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip.CampUserInfo")]
		public List<CampUserInfo> Users;
	}

	public C2S_GetCampInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetCampInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
