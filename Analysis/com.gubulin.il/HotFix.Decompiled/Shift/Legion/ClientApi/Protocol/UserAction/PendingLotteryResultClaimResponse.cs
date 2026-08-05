using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class PendingLotteryResultClaimResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Models.ModelsBonus")]
	public List<ModelsBonus> BonusList;

	[ProtoMember(5)]
	public List<LotteryPendingResult> PendingLotteryResultList;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_PENDING_LOTTERY_CLAIM_REQUEST;

	public void UsedOnlyForAOTCodeGeneration()
	{
		new List<ModelsBonus>();
		new List<LotteryPendingResult>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
