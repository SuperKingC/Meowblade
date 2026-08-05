using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_PostOEMMission : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int AmpIdx;

		[ProtoMember(2)]
		public bool IsExtra;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_PostOEMMission()
	{
		base.PackageId = SocketManager.ePackageId.C2S_PostOEMMission;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
