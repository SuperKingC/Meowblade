using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_Activate火力支援 : SocketManager.BaseSocketPackageBodyContext
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

		[ProtoMember(2)]
		public int TimeOfUsage_Base;
	}

	public C2S_Activate火力支援()
	{
		base.PackageId = SocketManager.ePackageId.C2S_Activate火力支援;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
