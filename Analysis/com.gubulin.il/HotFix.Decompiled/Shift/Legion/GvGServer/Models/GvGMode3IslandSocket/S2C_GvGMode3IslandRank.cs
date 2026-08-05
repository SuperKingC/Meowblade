using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;

[ProtoContract]
public class S2C_GvGMode3IslandRank : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3IslandRankInfo")]
		public List<GvGMode3IslandRankInfo> InfosNormal;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3IslandRankInfo")]
		public List<GvGMode3IslandRankInfo> InfosRE;

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3IslandRankInfo")]
		public List<GvGMode3IslandRankInfo> InfosBossDamage;

		[ProtoMember(4, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FinalProgress.GvGMode3CampRankInfo")]
		public List<GvGMode3CampRankInfo> BrawlCampRank;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public static Action<Request> OnPushEvent = delegate
	{
	};

	public S2C_GvGMode3IslandRank()
	{
		base.PackageId = SocketManager.ePackageId.S2C_GvGMode3IslandRank;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		OnPushEvent?.Invoke((Request)base.Req);
	}
}
