using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class C2S_GetBattleDamageDetailInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int EntityId;

		[ProtoMember(2)]
		public string BattleId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public long Frame;

		[ProtoMember(3)]
		public long Damage;
	}

	public C2S_GetBattleDamageDetailInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetBattleDamageDetailInfo;
		base.Req = new Request();
		base.Resp = new Response();
	}
}
