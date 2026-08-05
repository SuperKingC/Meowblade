using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_BrawlEvent_GetDetailInfoByMUID : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int MUID;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent.BrawlEventRankRewardsConfig_ToProtocol")]
		public List<BrawlEventRankRewardsConfig_ToProtocol> FinalRewards;
	}

	public C2S_BrawlEvent_GetDetailInfoByMUID()
	{
		base.PackageId = SocketManager.ePackageId.C2S_BrawlEvent_GetDetailInfoByMUID;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
