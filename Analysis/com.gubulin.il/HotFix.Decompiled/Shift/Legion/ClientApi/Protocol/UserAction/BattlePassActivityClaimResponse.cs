using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class BattlePassActivityClaimResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	public string Message;

	[ProtoMember(3)]
	public string _jsonBonusList;

	private List<Bonus> _bonusList;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public List<Bonus> BonusList
	{
		get
		{
			if (_bonusList == null && !string.IsNullOrEmpty(_jsonBonusList))
			{
				_bonusList = JsonHelper.ToObject<List<Bonus>>(_jsonBonusList);
			}
			return _bonusList;
		}
		set
		{
			_bonusList = value;
			_jsonBonusList = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_BATTLEPASS_ACTIVITY_CLAIM_REQUEST;
}
