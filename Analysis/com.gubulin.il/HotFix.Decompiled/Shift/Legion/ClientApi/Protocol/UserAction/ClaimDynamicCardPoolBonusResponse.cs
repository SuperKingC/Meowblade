using System;
using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class ClaimDynamicCardPoolBonusResponse : IPacketBody
{
	[ProtoMember(1)]
	public long Tick;

	[ProtoMember(2)]
	public bool Result;

	[ProtoMember(4)]
	public string ActivityId;

	[ProtoMember(5)]
	public List<float> ClaimProgress;

	[ProtoMember(6)]
	public string _jsonBonusList;

	private List<ModelsBonus> _bonusList;

	[ProtoMember(7)]
	public float Score;

	public List<ModelsBonus> BonusList
	{
		get
		{
			if (_bonusList == null && !string.IsNullOrEmpty(_jsonBonusList))
			{
				_bonusList = JsonHelper.ToObject<List<ModelsBonus>>(_jsonBonusList);
			}
			return _bonusList;
		}
		set
		{
			_bonusList = value;
			_jsonBonusList = JsonHelper.ToJson(value);
		}
	}

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public int PacketId => PacketIds.USER_ACTION_CLAIM_CARDPOOL_ACTIVITY_BONUS;

	public void UsedOnlyForAOTCodeGeneration()
	{
		new List<ModelsBonus>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
