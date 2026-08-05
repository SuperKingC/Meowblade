using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_GetMissions : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int Progress;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission.MissionStateRecordWithProgress")]
		public List<MissionStateRecordWithProgress> MissionStateRecordWithProgress;

		[ProtoMember(3, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission.CampMainProgress")]
		public List<CampMainProgress> MainProgress;

		[ProtoMember(4)]
		public bool SelfClaimCampRankReward;

		[ProtoMember(7)]
		public string MissionCanClaim;

		[ProtoMember(8)]
		public string RankCanClaim;
	}

	public C2S_GetMissions()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetMissions;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
