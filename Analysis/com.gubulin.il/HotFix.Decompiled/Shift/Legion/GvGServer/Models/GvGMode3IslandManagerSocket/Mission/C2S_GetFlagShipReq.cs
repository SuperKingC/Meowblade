using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_GetFlagShipReq : SocketManager.BaseSocketPackageBodyContext
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

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Mission.FlagShipReqMission_ToProtocol")]
		public List<FlagShipReqMission_ToProtocol> Missions;
	}

	public C2S_GetFlagShipReq()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetFlagShipReq;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
