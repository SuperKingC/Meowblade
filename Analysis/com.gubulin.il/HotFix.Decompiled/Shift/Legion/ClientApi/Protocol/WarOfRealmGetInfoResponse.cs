using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmGetInfoResponse : IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_WAROFREALM_GETINFO_REQUEST;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public int BeginTs { get; set; }

	[ProtoMember(2)]
	public int EndTs { get; set; }

	[ProtoMember(3)]
	public List<WarOfRealmMission> Missions { get; set; }

	[ProtoMember(4)]
	public string FreeBonus { get; set; }

	public Dictionary<int, Dictionary<string, int>> FreeBonusDict
	{
		get
		{
			if (string.IsNullOrEmpty(FreeBonus))
			{
				return new Dictionary<int, Dictionary<string, int>>();
			}
			return JsonHelper.ToObject<Dictionary<int, Dictionary<string, int>>>(FreeBonus);
		}
	}

	[ProtoMember(5)]
	public string PaidBonus { get; set; }

	public Dictionary<int, string> PaidBonusDict
	{
		get
		{
			if (string.IsNullOrEmpty(PaidBonus))
			{
				return new Dictionary<int, string>();
			}
			return JsonHelper.ToObject<Dictionary<int, string>>(PaidBonus);
		}
	}

	[ProtoMember(6)]
	public int Score { get; set; }

	[ProtoMember(7)]
	public List<string> CompletedWeeklyMission { get; set; }

	[ProtoMember(8)]
	public List<string> CompletedSeasonMission { get; set; }

	[ProtoMember(9)]
	public string MissionProgress { get; set; }

	[ProtoMember(10)]
	public List<int> Claimed { get; set; }

	public Dictionary<eMissionType, int> MissionProgressDict
	{
		get
		{
			if (string.IsNullOrEmpty(MissionProgress))
			{
				return new Dictionary<eMissionType, int>();
			}
			Dictionary<string, int> dictionary = JsonHelper.ToObject<Dictionary<string, int>>(MissionProgress);
			Dictionary<eMissionType, int> dictionary2 = new Dictionary<eMissionType, int>();
			foreach (KeyValuePair<string, int> item in dictionary)
			{
				eMissionType key = (eMissionType)Enum.Parse(typeof(eMissionType), item.Key);
				dictionary2[key] = item.Value;
			}
			return dictionary2;
		}
	}

	[ProtoMember(20, TypeName = "Shift.Legion.ClientApi.Models.StageInfo")]
	public List<StageInfo> StageInfo { get; set; }

	[ProtoMember(21, TypeName = "Shift.Legion.ClientApi.Models.WarRankDataInfo")]
	public WarRankDataInfo WarRankData { get; set; }

	[ProtoMember(22)]
	public bool Settlement { get; set; }

	[ProtoMember(23, TypeName = "Shift.Legion.ClientApi.Models.PlayerSettlementInfoModel")]
	public PlayerSettlementInfoModel PlayerSettlementInfo { get; set; }

	[ProtoMember(24)]
	public string LeaderboardBonus { get; set; }

	[ProtoMember(25)]
	public string StoreContents { get; set; }

	[ProtoMember(26)]
	public bool Approval { get; set; }

	[ProtoMember(99)]
	public string ActivityId { get; set; }
}
