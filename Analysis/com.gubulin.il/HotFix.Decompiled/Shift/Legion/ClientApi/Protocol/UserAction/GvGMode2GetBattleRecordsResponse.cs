using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GvGMode2GetBattleRecordsResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Models.GvGMode2BattleReportBattleRecord")]
	public List<GvGMode2BattleReportBattleRecord> Records { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GVGMODE2_GET_BATTLE_RECORDS;
}
