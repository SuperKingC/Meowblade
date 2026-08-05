using ProtoBuf;
using Shift.Legion.Common.Managers;
using UnityEngine;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class S2C_StartOneBattle : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string BattleId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public S2C_StartOneBattle()
	{
		base.PackageId = SocketManager.ePackageId.S2C_StartOneBattle;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		Request arg = (Request)base.Req;
		if ((Object)(object)GvGWorldController.Instance != (Object)null && GvGWorldController.Instance.IsInitialized)
		{
			SharedMessenger.Broadcast("ON_GVG_ONE_BATTLE_START", arg);
		}
	}
}
