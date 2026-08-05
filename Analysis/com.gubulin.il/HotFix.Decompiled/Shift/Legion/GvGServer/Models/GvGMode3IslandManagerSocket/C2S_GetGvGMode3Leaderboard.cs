using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetGvGMode3Leaderboard : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int LeaderboardType;

		[ProtoMember(2)]
		public int LeaderboardSubType;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3LeaderboardData")]
		public GvGMode3LeaderboardData LeaderboardData;

		[ProtoMember(3)]
		public int NextUpdateTimestamp;
	}

	public C2S_GetGvGMode3Leaderboard()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetGvGMode3Leaderboard;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
