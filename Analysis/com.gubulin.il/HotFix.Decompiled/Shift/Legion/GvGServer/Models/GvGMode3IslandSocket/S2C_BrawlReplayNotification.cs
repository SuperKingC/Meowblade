using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;

[ProtoContract]
public class S2C_BrawlReplayNotification : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public float AliveConfigExtraScore;

		[ProtoMember(2)]
		public float AliveConfigPar;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public S2C_BrawlReplayNotification()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BrawlReplayNotification;
		base.Req = new Request();
		base.Resp = new Response();
	}
}
