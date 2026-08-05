using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmGetWarBattleRecordResponse : IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_WAROFREALM_GETWARBATTLERECORD;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public string BattleRecords { get; set; }

	public List<RankChangeRecord> GetBattleRecordsList
	{
		get
		{
			if (string.IsNullOrEmpty(BattleRecords))
			{
				return new List<RankChangeRecord>();
			}
			return JsonHelper.ToObject<List<RankChangeRecord>>(BattleRecords) ?? new List<RankChangeRecord>();
		}
	}
}
