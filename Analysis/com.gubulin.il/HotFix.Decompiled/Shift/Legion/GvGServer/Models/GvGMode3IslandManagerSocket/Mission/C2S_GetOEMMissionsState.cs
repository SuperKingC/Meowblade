using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_GetOEMMissionsState : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public List<int> MUIDList;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Mission.OEMMissionState_ToProtocol")]
		public List<OEMMissionState_ToProtocol> States;
	}

	public C2S_GetOEMMissionsState()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetOEMMissionsState;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
