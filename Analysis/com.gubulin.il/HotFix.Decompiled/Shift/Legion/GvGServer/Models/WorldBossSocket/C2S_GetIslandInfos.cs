using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class C2S_GetIslandInfos : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public List<int> Ids_WaitToGet { get; set; } = new List<int>();
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public long LastUpdateTime;

		[ProtoMember(2)]
		public List<int> TotalIds;

		[ProtoMember(3, TypeName = "Shift.Legion.GvGServer.Models.WorldBossSocket.BroadcastGroupInitInfo")]
		public List<BroadcastGroupInitInfo> InitInfos = new List<BroadcastGroupInitInfo>();

		[ProtoMember(4, TypeName = "Shift.Legion.GvGServer.Models.WorldBossSocket.BroadcastGroupInfo")]
		public List<BroadcastGroupInfo> GroupInfos = new List<BroadcastGroupInfo>();
	}

	public C2S_GetIslandInfos()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetIslandInfos;
		base.Req = new Request();
		base.Resp = new Response();
	}
}
