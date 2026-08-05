using ProtoBuf;
using Shift.Legion.Common.Managers;

[ProtoContract]
public class C2S_TestCommand : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int MapViewLevel;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int MapViewLevel;

		[ProtoMember(3)]
		public string testStr;
	}

	public C2S_TestCommand()
	{
		base.PackageId = SocketManager.ePackageId.C2S_TestCommand;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
