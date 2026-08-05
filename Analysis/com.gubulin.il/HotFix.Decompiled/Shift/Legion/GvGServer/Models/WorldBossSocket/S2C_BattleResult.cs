using ProtoBuf;
using Shift.Legion.Common.Managers;
using UnityEngine;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class S2C_BattleResult : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string BattleResultKey;

		[ProtoMember(2)]
		public string IZId;

		[ProtoMember(4)]
		public string WBId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public S2C_BattleResult()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BattleResult;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		Request req = (Request)base.Req;
		if ((Object)(object)GvGWorldController.Instance != (Object)null && GvGWorldController.Instance.IsInitialized)
		{
			GvGWorldController.Instance.OnBattleResult(req);
		}
	}
}
