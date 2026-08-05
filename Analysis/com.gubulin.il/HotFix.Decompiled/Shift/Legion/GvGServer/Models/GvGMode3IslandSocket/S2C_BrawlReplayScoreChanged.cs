using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;

[ProtoContract]
public class S2C_BrawlReplayScoreChanged : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int EntityId;

		[ProtoMember(2)]
		public float ChangedScore;

		[ProtoMember(3)]
		public float Par;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public S2C_BrawlReplayScoreChanged()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BrawlReplayScoreChanged;
		base.Req = new Request();
		base.Resp = new Response();
	}
}
