using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_ChangeCameraPos : SocketManager.BaseSocketPackageBodyContext
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

		[ProtoMember(3, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model.EOI_ShipInfo")]
		public List<EOI_ShipInfo> EOI_ShipEntityIds;

		[ProtoMember(4)]
		public int X;

		[ProtoMember(5)]
		public int Z;
	}

	public C2S_ChangeCameraPos()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ChangeCameraPos;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
