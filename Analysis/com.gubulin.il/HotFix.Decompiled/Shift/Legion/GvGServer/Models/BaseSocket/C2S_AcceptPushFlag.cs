using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.BaseSocket;

[ProtoContract]
public class C2S_AcceptPushFlag : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public bool isAcceptPushIslandSummary;

		[ProtoMember(2)]
		public int isAcceptPushIslandCampSummary;

		public Request Clone()
		{
			return (Request)MemberwiseClone();
		}
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_AcceptPushFlag()
	{
		base.PackageId = SocketManager.ePackageId.C2S_AcceptPushFlag;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
