using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class EnterGameResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(3)]
	public string Message;

	[ProtoMember(10)]
	public int OfflineSeconds;

	[ProtoMember(11, TypeName = "Shift.Legion.ClientApi.Models.ModelsBonus")]
	public List<ModelsBonus> Bonuses;

	[ProtoMember(12, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords;

	[ProtoMember(13)]
	public bool isNewDay;

	[ProtoMember(14)]
	public int DailyLoginStats;

	[ProtoMember(15)]
	public int GvGFetchGapTime;

	[ProtoMember(16)]
	public List<string> FullItemId;

	public int PacketId => PacketIds.USER_ACTION_ENTER_GAME_REQUEST;
}
