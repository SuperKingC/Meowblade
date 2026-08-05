using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Sources.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmGetStageBattleRecordResponse : IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_GET_WAROFREALM_STAGEBATTLERECORD;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public string GroupBattleRecord { get; set; }

	public List<WarOfRealmGroupBattleRecordGroup> GetGroupBattleRecord
	{
		get
		{
			if (string.IsNullOrEmpty(GroupBattleRecord))
			{
				return new List<WarOfRealmGroupBattleRecordGroup>();
			}
			Dictionary<string, List<WarOfRealmPersonalBattleRecord>> dictionary = JsonHelper.ToObject<Dictionary<string, List<WarOfRealmPersonalBattleRecord>>>(GroupBattleRecord);
			if (dictionary == null || dictionary.Count == 0)
			{
				return new List<WarOfRealmGroupBattleRecordGroup>();
			}
			List<WarOfRealmGroupBattleRecordGroup> list = new List<WarOfRealmGroupBattleRecordGroup>(dictionary.Count);
			foreach (KeyValuePair<string, List<WarOfRealmPersonalBattleRecord>> item in dictionary)
			{
				if (float.TryParse(item.Key, out var result))
				{
					list.Add(new WarOfRealmGroupBattleRecordGroup
					{
						WinRate = result,
						Records = item.Value
					});
				}
			}
			return list;
		}
	}
}
