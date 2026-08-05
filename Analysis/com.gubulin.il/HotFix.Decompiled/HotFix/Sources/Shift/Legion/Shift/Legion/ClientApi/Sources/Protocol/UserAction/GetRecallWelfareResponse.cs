using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;

namespace HotFix.Sources.Shift.Legion.Shift.Legion.ClientApi.Sources.Protocol.UserAction;

[ProtoContract]
public class GetRecallWelfareResponse : IPacketBody
{
	[ProtoMember(1)]
	public int BeginTime { get; set; }

	[ProtoMember(2)]
	public int ValidPeriod { get; set; }

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Models.RecallWelfarePrize")]
	public List<RecallWelfarePrize> Prizes { get; set; }

	[ProtoMember(5, TypeName = "Shift.Legion.ClientApi.Models.RecallWelfareMission")]
	public List<RecallWelfareMission> Missions { get; set; }

	[ProtoMember(6, TypeName = "Shift.Legion.ClientApi.Models.ERItem")]
	public List<ERItem> DrawRecord { get; set; } = new List<ERItem>();

	[ProtoMember(8)]
	public List<string> CompletedMission { get; set; } = new List<string>();

	[ProtoMember(9)]
	public List<string> ClaimedMission { get; set; } = new List<string>();

	[ProtoMember(10, TypeName = "Shift.Legion.ClientApi.Models.RecallWelfareMissionProgress")]
	public List<RecallWelfareMissionProgress> Progress { get; set; } = new List<RecallWelfareMissionProgress>();

	[ProtoMember(11)]
	public int TotalScore { get; set; }

	[ProtoMember(12)]
	public int Money { get; set; }

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_RECALLWELFARE_REQUEST;
}
