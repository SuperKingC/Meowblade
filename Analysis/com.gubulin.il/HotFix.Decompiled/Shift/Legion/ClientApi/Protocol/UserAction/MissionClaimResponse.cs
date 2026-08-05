using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class MissionClaimResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(4, TypeName = "Shift.Legion.ClientApi.Models.ModelsBonus")]
	public List<ModelsBonus> BonusList;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_MISSION_CLAIM_REQUEST;

	public void UsedOnlyForAOTCodeGeneration()
	{
		new List<ModelsBonus>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
