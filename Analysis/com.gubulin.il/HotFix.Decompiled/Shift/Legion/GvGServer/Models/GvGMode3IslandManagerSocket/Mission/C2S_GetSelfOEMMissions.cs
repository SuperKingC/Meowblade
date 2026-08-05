using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_GetSelfOEMMissions : SocketManager.BaseSocketPackageBodyContext
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

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Mission.SelfOEMMission_ToProtocol")]
		public List<SelfOEMMission_ToProtocol> OEMMissions;
	}

	public C2S_GetSelfOEMMissions()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetSelfOEMMissions;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
