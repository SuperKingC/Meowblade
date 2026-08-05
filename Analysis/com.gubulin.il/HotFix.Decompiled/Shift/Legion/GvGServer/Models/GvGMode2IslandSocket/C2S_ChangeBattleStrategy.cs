using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode2IslandSocket;

[ProtoContract]
public class C2S_ChangeBattleStrategy : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int CampId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_ChangeBattleStrategy()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ChangeBattleStrategy;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
