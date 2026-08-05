using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class WarOfRealmLotteryRequest : IRequestPacket, IPacketBody
{
	public int PacketId => PacketIds.USER_ACTION_WAROFREALM_LOTTERY;

	[ProtoMember(99)]
	public int MsgIndex { get; set; }

	[ProtoMember(1)]
	public int StageStatus { get; set; }

	[ProtoMember(2)]
	public int GroupIndex { get; set; }

	[ProtoMember(3, TypeName = "Shift.Legion.ClientApi.Models.WarLottery")]
	public List<WarLottery> WarLottery { get; set; }
}
