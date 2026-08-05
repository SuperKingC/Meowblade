using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using ProtoBuf;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;

[ProtoContract]
public class C2S_BrawlEvent_GetDetailInfoByIsland : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int IslandId;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public int IslandId;

		[ProtoMember(3)]
		public int CampSignUpCountNow;

		[ProtoMember(4)]
		public int CampSignUpCountMax;

		[ProtoMember(5)]
		public int SignUpShipRace;

		[ProtoMember(6)]
		public bool HasSignUpOnThisIsland;

		[ProtoMember(7)]
		public int IslandSubType;

		[ProtoMember(10)]
		public int ReplayDuration;

		[ProtoMember(11, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.Mission.BrawlEvent.BrawlEventRankRewardsConfig_ToProtocol")]
		public List<BrawlEventRankRewardsConfig_ToProtocol> FinalRewards;

		[ProtoMember(12)]
		public int MUID;

		public string MissionConfigId;

		public eGvGMode3CampMissionSubType GetSubType()
		{
			return (eGvGMode3CampMissionSubType)IslandSubType;
		}

		public bool HasBattleReplay()
		{
			return ReplayDuration > 0;
		}

		public string GetReplayName()
		{
			return GetBrawlEventBattleReplayName(MUID);
		}
	}

	public C2S_BrawlEvent_GetDetailInfoByIsland()
	{
		base.PackageId = SocketManager.ePackageId.C2S_BrawlEvent_GetDetailInfoByIsland;
		base.Resp = new Response();
		base.Req = new Request();
	}

	public static string GetBrawlEventBattleReplayName(int muid)
	{
		string envStr = GameDataService.Instance.EnvStr;
		int curIZId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId;
		return $"{envStr}_BR_{curIZId}_{muid}";
	}
}
