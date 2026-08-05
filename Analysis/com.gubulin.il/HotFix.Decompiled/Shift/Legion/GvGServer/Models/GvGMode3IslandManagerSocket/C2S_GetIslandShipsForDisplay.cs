using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetIslandShipsForDisplay : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public List<int> IslandIds;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.EOI_IslandShipInfoOnIsland")]
		public List<EOI_IslandShipInfoOnIsland> IslandShips;
	}

	public C2S_GetIslandShipsForDisplay()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetIslandShipsForDisplay;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
