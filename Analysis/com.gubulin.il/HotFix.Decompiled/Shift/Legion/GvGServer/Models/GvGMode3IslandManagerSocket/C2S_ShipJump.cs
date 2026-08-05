using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_ShipJump : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ShipEntityId;

		[ProtoMember(2)]
		public int JumpEnd;

		[ProtoMember(3)]
		public bool UseOuterTech;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_ShipJump()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ShipJump;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
