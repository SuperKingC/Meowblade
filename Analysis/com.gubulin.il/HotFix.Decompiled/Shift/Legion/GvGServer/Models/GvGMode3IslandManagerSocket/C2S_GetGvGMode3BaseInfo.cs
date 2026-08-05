using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.RealTime;
using Shift.Legion.GvG.Common.Models.OuterTech;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

[ProtoContract]
public class C2S_GetGvGMode3BaseInfo : SocketManager.BaseSocketPackageBodyContext
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
		public string jsonObserverRecord;

		private GvGMode3ObserverRecord _ObserverRecord;

		[ProtoMember(3)]
		public int IZVersionNumber;

		[ProtoMember(4)]
		public List<int> DetectedIslands;

		[ProtoMember(7)]
		public List<int> ActiveTalents;

		[ProtoMember(8)]
		public List<int> SpecialTalents;

		[ProtoMember(10)]
		public int IZEndTimestamp;

		[ProtoMember(12)]
		public int IZBeginTimestamp;

		[ProtoMember(13)]
		public int FinalProgressBegin;

		[ProtoMember(14)]
		public int Settlement;

		[ProtoMember(20)]
		public List<int> UserIds;

		[ProtoMember(21)]
		public int UserPlayDays;

		[ProtoMember(30)]
		public int TreasureMap_MUID = -1;

		[ProtoMember(31)]
		public string TreasureMap_MConfigId = "";

		[ProtoMember(32)]
		public long TreasureMap_Timestamp_ms = -1L;

		[ProtoMember(33)]
		public int TreasureMap_IslandId = -1;

		[ProtoMember(51)]
		public bool HasBattlePassPaidCert;

		[ProtoMember(52)]
		public string BattlePassClaimedBonus;

		[ProtoMember(53)]
		public float CurTotalContributionPoints;

		[ProtoMember(55)]
		public string jsonPlayerBuffQueue;

		[ProtoMember(60)]
		public bool HasSettlement;

		[ProtoMember(61)]
		public int SettlementTimestamp;

		[ProtoMember(70, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.IslandDataVersionModel")]
		public List<IslandDataVersionModel> IslandDataVersion;

		[ProtoMember(80)]
		public int WaitToClaimSystemMessageIdsCount;

		[ProtoMember(81, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.FlagShipAttackEvent")]
		public List<FlagShipAttackEvent> FlagShipAttackEvent;

		[ProtoMember(82, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.FlagShipStateInfo")]
		public List<FlagShipStateInfo> FlagShipStateInfo;

		[ProtoMember(83, TypeName = "Shift.Legion.GvG.Common.Models.OuterTech.OuterTechModel")]
		public OuterTechModel OuterTechModel;

		[ProtoMember(84, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.RealTime.RealTimeFoodOnBoardModel")]
		public RealTimeFoodOnBoardModel RealTimeFoodOnBoardModel;

		[ProtoMember(90)]
		public int FlagShipMaxFood;

		[ProtoMember(91)]
		public int FlagShipCurFood;

		[ProtoMember(92)]
		public bool DailyContributionBoxClaimed;

		[ProtoMember(93)]
		public bool DailySupplyPackClaimed;

		[ProtoMember(94)]
		public bool OEMAmplifiersCanBeReceived;

		[ProtoMember(95)]
		public int FlagShipMissionLastRefreshTimestamp;

		[ProtoMember(96)]
		public bool PollutantsCanBePurified;

		[ProtoMember(97)]
		public bool OEMAmplifiersHasFailed;

		[ProtoMember(98)]
		public List<int> UnreachableIslands;

		[ProtoMember(99)]
		public List<int> CampFlagshipIslandOfInterest;

		[ProtoMember(100)]
		public int BattlePassVersion;

		[ProtoMember(101)]
		public bool HasBattlePassPremiumPaidCert;

		[ProtoMember(102)]
		public string InsuranceShipId;

		[ProtoMember(103)]
		public List<string> StockLimitOccupiedSoldiers;

		[ProtoMember(104)]
		public int BattlePassInsuranceTimes;

		[ProtoMember(105, TypeName = "Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.DailySuppressBonusModel")]
		public DailySuppressBonusModel DailySuppressBonusModel;

		public GvGMode3ObserverRecord ObserverRecord
		{
			get
			{
				if (_ObserverRecord == null && !string.IsNullOrEmpty(jsonObserverRecord))
				{
					_ObserverRecord = JsonHelper.ToObject<GvGMode3ObserverRecord>(jsonObserverRecord);
				}
				return _ObserverRecord;
			}
			set
			{
				_ObserverRecord = value;
				jsonObserverRecord = JsonHelper.ToJson(_ObserverRecord);
			}
		}

		public Dictionary<string, List<int>> BattlePassClaimedBonusDic => string.IsNullOrEmpty(BattlePassClaimedBonus) ? new Dictionary<string, List<int>>() : JsonHelper.ToObject<Dictionary<string, List<int>>>(BattlePassClaimedBonus);

		public int TotalContributionPoints => (int)CurTotalContributionPoints;
	}

	public C2S_GetGvGMode3BaseInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetGvGMode3BaseInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
