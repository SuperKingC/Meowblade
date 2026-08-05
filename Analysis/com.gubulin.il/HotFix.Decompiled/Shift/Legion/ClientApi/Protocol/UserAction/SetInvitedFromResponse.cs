using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

[ProtoContract]
public class SetInvitedFromResponse : IPacketBody
{
	[ProtoMember(1)]
	public bool Result;

	[ProtoMember(3)]
	public int InvitedFrom;

	[ProtoMember(4)]
	public string _pbBonuses;

	private Dictionary<string, float> _bonuses;

	[ProtoMember(999)]
	public int ErrorCode { get; set; }

	public Dictionary<string, float> InvitedBonus
	{
		get
		{
			if (_pbBonuses == null)
			{
				return null;
			}
			return _bonuses ?? (_bonuses = JsonHelper.ToObject<Dictionary<string, float>>(_pbBonuses));
		}
		set
		{
			_bonuses = value;
			_pbBonuses = JsonHelper.ToJson(value);
		}
	}

	public int PacketId => PacketIds.USER_ACTION_SET_INVITED_FROM;
}
