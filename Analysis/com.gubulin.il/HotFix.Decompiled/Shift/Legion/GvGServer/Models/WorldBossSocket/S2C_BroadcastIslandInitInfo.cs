using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using UnityEngine;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class S2C_BroadcastIslandInitInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public long LastUpdateTime;

		[ProtoMember(2, TypeName = "Shift.Legion.GvGServer.Models.WorldBossSocket.BroadcastGroupInitInfo")]
		public List<BroadcastGroupInitInfo> InitInfos;

		[ProtoMember(3, TypeName = "Shift.Legion.GvGServer.Models.WorldBossSocket.BroadcastGroupInfo")]
		public List<BroadcastGroupInfo> GroupInfos;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;
	}

	public S2C_BroadcastIslandInitInfo()
	{
		base.PackageId = SocketManager.ePackageId.S2C_BroadcastIslandInitInfo;
		base.Req = new Request();
		base.Resp = new Response();
	}

	public override void OnPush()
	{
		Request request = (Request)base.Req;
		if ((Object)(object)GvGWorldController.Instance != (Object)null && GvGWorldController.Instance.IsInitialized)
		{
			((MonoBehaviour)GvGWorldController.Instance).StartCoroutine(GvGWorldController.Instance.CreateGroups(request.LastUpdateTime, request.InitInfos, request.GroupInfos));
		}
	}
}
