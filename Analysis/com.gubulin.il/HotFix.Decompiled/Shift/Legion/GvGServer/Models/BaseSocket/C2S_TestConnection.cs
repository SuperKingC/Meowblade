using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.BaseSocket;

[ProtoContract]
public class C2S_TestConnection : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_TestConnection()
	{
		base.PackageId = SocketManager.ePackageId.C2S_TestConnection;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
