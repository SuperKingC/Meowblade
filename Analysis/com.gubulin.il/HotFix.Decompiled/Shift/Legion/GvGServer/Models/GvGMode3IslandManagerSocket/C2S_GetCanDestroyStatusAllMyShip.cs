using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetCanDestroyStatusAllMyShip : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int Non;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(3, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.ShipCanDestroyStatus")]
		public List<ShipCanDestroyStatus> CanDestroyStatus;
	}

	public C2S_GetCanDestroyStatusAllMyShip()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetCanDestroyStatusAllMyShip;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
