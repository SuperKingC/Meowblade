using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmLotteryResponse : IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_WAROFREALM_LOTTERY;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords { get; set; }
}
