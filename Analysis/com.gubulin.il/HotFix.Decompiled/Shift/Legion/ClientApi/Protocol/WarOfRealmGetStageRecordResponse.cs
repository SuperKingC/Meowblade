using System.Collections.Generic;
using ILRuntime_LitJson;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmGetStageRecordResponse : IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_WAROFREALM_GETSTAGERECORD;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public string GroupInfo { get; set; }

	[JsonIgnore]
	public Dictionary<int, List<int>> GetGroupInfo
	{
		get
		{
			if (string.IsNullOrEmpty(GroupInfo))
			{
				return new Dictionary<int, List<int>>();
			}
			Dictionary<string, List<int>> dictionary = JsonHelper.ToObject<Dictionary<string, List<int>>>(GroupInfo);
			Dictionary<int, List<int>> dictionary2 = new Dictionary<int, List<int>>();
			foreach (KeyValuePair<string, List<int>> item in dictionary)
			{
				int key = int.Parse(item.Key);
				dictionary2[key] = item.Value;
			}
			return dictionary2;
		}
	}

	[ProtoMember(2)]
	public string SettlementInfo { get; set; }

	[JsonIgnore]
	public Dictionary<int, List<WarRankData>> GetSettlementInfoList
	{
		get
		{
			if (string.IsNullOrEmpty(SettlementInfo))
			{
				return new Dictionary<int, List<WarRankData>>();
			}
			Dictionary<string, List<WarRankData>> dictionary = JsonHelper.ToObject<Dictionary<string, List<WarRankData>>>(SettlementInfo);
			Dictionary<int, List<WarRankData>> dictionary2 = new Dictionary<int, List<WarRankData>>();
			foreach (KeyValuePair<string, List<WarRankData>> item in dictionary)
			{
				int key = int.Parse(item.Key);
				dictionary2[key] = item.Value;
			}
			return dictionary2;
		}
	}

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Models.WarRankData")]
	public List<WarRankData> UserInTop8 { get; set; }

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Models.WarRankDataInfo")]
	public WarRankDataInfo WarRankDataInfo { get; set; }
}
