using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_DoSoulGuide : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int EntityId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int SoulGuideCDTimestamp;
	}

	public C2S_DoSoulGuide()
	{
		base.PackageId = SocketManager.ePackageId.C2S_DoSoulGuide;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
