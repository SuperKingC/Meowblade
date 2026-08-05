using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_LaunchShip : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ShipEntityId;

		[ProtoMember(3)]
		public int IslandId = -1;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int ShipTargetIslandId;

		[ProtoMember(3)]
		public int ShipState;
	}

	public C2S_LaunchShip()
	{
		base.PackageId = SocketManager.ePackageId.C2S_LaunchShip;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
