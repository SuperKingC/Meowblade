using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetNeedToSyncEOIShips : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int X;

		[ProtoMember(2)]
		public int Z;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model.EOI_ShipInfo")]
		public List<EOI_ShipInfo> NeedToSyncShips;
	}

	public C2S_GetNeedToSyncEOIShips()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetNeedToSyncEOIShips;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
