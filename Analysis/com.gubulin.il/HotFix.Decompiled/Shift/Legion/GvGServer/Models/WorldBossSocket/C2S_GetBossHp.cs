using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class C2S_GetBossHp : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int Non;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public long BossCurHp;

		[ProtoMember(3)]
		public long BossMaxHp;
	}

	public C2S_GetBossHp()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetBossHp;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
