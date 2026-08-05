using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;

[ProtoContract]
public class C2S_ChangeGvGMode3BattleStrategy : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ShipEntityId;

		[ProtoMember(2)]
		public int CampId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public C2S_ChangeGvGMode3BattleStrategy()
	{
		base.PackageId = SocketManager.ePackageId.C2S_ChangeGvGMode3BattleStrategy;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
