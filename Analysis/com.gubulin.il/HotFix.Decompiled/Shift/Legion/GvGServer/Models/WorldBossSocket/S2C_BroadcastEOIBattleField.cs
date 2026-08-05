using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using UnityEngine;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

public class S2C_BroadcastEOIBattleField : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public long LastUpdateTime;

		[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.WorldBossSocket.BroadcastGroupInfo")]
		public List<BroadcastGroupInfo> Infos;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public S2C_BroadcastEOIBattleField()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BroadcastEOIBattleField;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		Request request = (Request)base.Req;
		if ((Object)(object)GvGWorldController.Instance != (Object)null && GvGWorldController.Instance.IsInitialized)
		{
			((MonoBehaviour)GvGWorldController.Instance).StartCoroutine(GvGWorldController.Instance.UpdateGroups(request.LastUpdateTime, request.Infos));
		}
	}
}
