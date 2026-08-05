using ProtoBuf;
using Shift.Legion.Common.Managers;
using UnityEngine;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class S2C_BroadcastBossHp : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public long BossCurHp;

		[ProtoMember(2)]
		public long BossMaxHp;

		[ProtoMember(3)]
		public bool IsDead;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public S2C_BroadcastBossHp()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BroadcastBossHp;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		Request res = (Request)base.Req;
		if ((Object)(object)GvGWorldController.Instance != (Object)null && GvGWorldController.Instance.IsInitialized)
		{
			GvGWorldController.Instance.UpdateBossHp(res);
		}
	}
}
