using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_Share伟大航路DiscoveredIsland : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int IslandId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_Share伟大航路DiscoveredIsland()
	{
		base.PackageId = SocketManager.ePackageId.C2S_Share伟大航路DiscoveredIsland;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
