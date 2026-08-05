using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.PlayerCommand;

[ProtoContract]
public class C2S_CancelPlayerCommand : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int MUID;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_CancelPlayerCommand()
	{
		base.PackageId = SocketManager.ePackageId.C2S_CancelPlayerCommand;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
