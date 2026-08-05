using ProtoBuf;
using Shift.Legion.Common.Managers;

[ProtoContract]
public class C2S_RegistUserSessionCommand : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string NonStr;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public string NonStr;

		[ProtoMember(3)]
		public int RegistUserFailFlag;
	}

	public C2S_RegistUserSessionCommand()
	{
		base.PackageId = SocketManager.ePackageId.C2S_Regist;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
