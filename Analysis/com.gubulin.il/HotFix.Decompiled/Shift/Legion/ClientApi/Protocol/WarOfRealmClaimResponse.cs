using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmClaimResponse : IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_WAROFREALM_CLAIMMISSIONBONUS;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	[ProtoMember(1)]
	public List<int> Claimed { get; set; }

	[ProtoMember(2, TypeName = "Shift.Legion.ClientApi.Protocol.UserAction.StockChangeRecord")]
	public List<StockChangeRecord> StockChangeRecords { get; set; }
}
