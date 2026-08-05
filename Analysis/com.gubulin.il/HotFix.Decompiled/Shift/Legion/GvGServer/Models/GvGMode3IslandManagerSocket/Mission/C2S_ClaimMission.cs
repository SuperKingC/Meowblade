using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_ClaimMission : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public List<int> MUIDs;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_ClaimMission()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ClaimMission;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
