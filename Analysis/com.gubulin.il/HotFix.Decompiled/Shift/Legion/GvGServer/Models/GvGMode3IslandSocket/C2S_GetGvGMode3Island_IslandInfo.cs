using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandSocket;

[ProtoContract]
public class C2S_GetGvGMode3Island_IslandInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public string NonStr;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public string jsonIslandBuffs;

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3BestKill")]
		public GvGMode3BestKill BestKill;

		[ProtoMember(4, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3IslandRankInfo")]
		public List<GvGMode3IslandRankInfo> NormalRankData;

		[ProtoMember(5)]
		public string BossSoldierId;

		[ProtoMember(6)]
		public string HoldingPercent;

		[ProtoMember(8)]
		public int IslandId;

		[ProtoMember(9)]
		public bool isSystemPaused;

		[ProtoMember(10)]
		public long BossHp;

		[ProtoMember(11)]
		public long BossMaxHp;

		[ProtoMember(12)]
		public int NPCSoldierCount;

		[ProtoMember(13)]
		public int IslandOriginalCamp;

		[ProtoMember(14, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3IslandRankInfo")]
		public List<GvGMode3IslandRankInfo> RERankData;

		[ProtoMember(15)]
		public string HasREEvent;

		[ProtoMember(16)]
		public int HoldingCamp;

		[ProtoMember(17, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.GvGMode3IslandRankInfo")]
		public List<GvGMode3IslandRankInfo> BossDamageRankData;

		[ProtoMember(18, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.IEvent_火力支援")]
		public IEvent_火力支援 Event_火力支援;
	}

	public C2S_GetGvGMode3Island_IslandInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetGvGMode3Island_IslandInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
