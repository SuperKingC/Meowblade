using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class CheckBattleFailedProcessResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(2)]
	public string Message;

	[ProtoMember(3)]
	public long Tick;

	[ProtoMember(4)]
	public string _jsonReinforcementBonus;

	private Dictionary<string, int> _reinforcementBonus;

	public Dictionary<string, int> ReinforcementBonus
	{
		get
		{
			if (_reinforcementBonus == null && !string.IsNullOrEmpty(_jsonReinforcementBonus))
			{
				_reinforcementBonus = JsonHelper.ToObject<Dictionary<string, int>>(_jsonReinforcementBonus);
			}
			return _reinforcementBonus;
		}
		set
		{
			_reinforcementBonus = value;
			_jsonReinforcementBonus = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_CHECK_BATTLE_FAIL_PROCESS;
}
