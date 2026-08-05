using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Friends;

[ProtoContract]
public class InvitedWorker
{
	[ProtoMember(6)]
	public string _invitedAtStr;

	private DateTimeOffset _invitedAt;

	[ProtoMember(7)]
	public string _expireAtStr;

	private DateTimeOffset _expireAt;

	[ProtoMember(1)]
	public int UserId { get; set; }

	[ProtoMember(2)]
	public string Avatar { get; set; }

	[ProtoMember(3)]
	public string Nickname { get; set; }

	[ProtoMember(4)]
	public int Level { get; set; }

	[ProtoMember(5)]
	public KeyValuePair<string, int> AllocateInfo { get; set; }

	public DateTimeOffset InvitedAt
	{
		get
		{
			if (_invitedAt == default(DateTimeOffset) && !string.IsNullOrEmpty(_invitedAtStr))
			{
				_invitedAt = DateTimeOffset.Parse(_invitedAtStr).ToUniversalTime();
			}
			return _invitedAt;
		}
		set
		{
			_invitedAt = value.ToUniversalTime();
			_invitedAtStr = _invitedAt.ToString();
		}
	}

	public DateTimeOffset ExpiredAt
	{
		get
		{
			if (_expireAt == default(DateTimeOffset) && !string.IsNullOrEmpty(_expireAtStr))
			{
				_expireAt = DateTimeOffset.Parse(_expireAtStr).ToUniversalTime();
			}
			return _expireAt;
		}
		set
		{
			_expireAt = value;
			_expireAtStr = _expireAt.ToString();
		}
	}

	[ProtoMember(8)]
	public int Status { get; set; }
}
