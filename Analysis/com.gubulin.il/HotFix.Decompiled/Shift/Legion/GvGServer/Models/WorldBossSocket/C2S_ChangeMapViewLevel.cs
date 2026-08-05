using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

public class C2S_ChangeMapViewLevel : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int MapViewLevel;

		[ProtoMember(2)]
		public int TargetId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int MapViewLevel;

		[ProtoMember(3)]
		public int TargetId;
	}

	public C2S_ChangeMapViewLevel()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ChangeMapViewLevel;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
