using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;

[ProtoContract]
public class C2S_GetFinalProgressRank : SocketManager.BaseSocketPackageBodyContext
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

		[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress.GvGMode3CampRankInfo")]
		public List<GvGMode3CampRankInfo> EngeryRankInfo;

		[ProtoMember(3, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress.GvGMode3CampRankInfo")]
		public List<GvGMode3CampRankInfo> BossDamageRankInfo;
	}

	public C2S_GetFinalProgressRank()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetFinalProgressRank;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
