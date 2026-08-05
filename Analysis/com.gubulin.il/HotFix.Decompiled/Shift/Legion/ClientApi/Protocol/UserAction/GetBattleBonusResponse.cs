using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class GetBattleBonusResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(6, TypeName = "Shift.Legion.ClientApi.Models.BonusList")]
	[ProtoMap]
	public Dictionary<string, BonusList> Bonuses;

	[ProtoMember(7, TypeName = "Shift.Legion.ClientApi.Models.BonusList")]
	[ProtoMap]
	public Dictionary<string, BonusList> LotteryBonuses;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_GET_BATTLE_BONUS_REQUEST;

	public void UsedOnlyForAOTCodeGeneration()
	{
		new Dictionary<string, List<ModelsBonus>>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
