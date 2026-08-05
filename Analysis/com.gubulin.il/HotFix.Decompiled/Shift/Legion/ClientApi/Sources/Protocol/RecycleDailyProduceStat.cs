using System;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Sources.Protocol;

[ProtoContract]
public class RecycleDailyProduceStat
{
	[ProtoMember(6)]
	public string _lastLoginAtStr;

	private DateTimeOffset _lastLoginAt;

	[ProtoMember(7)]
	public int DailyProd;

	[ProtoMember(1)]
	public int UserId { get; set; }

	[ProtoMember(2)]
	public string Avatar { get; set; }

	[ProtoMember(3)]
	public string Nickname { get; set; }

	[ProtoMember(4)]
	public int UserLevel { get; set; }

	[ProtoMember(5)]
	public int LegionPower { get; set; }

	public DateTimeOffset LastLoginAt
	{
		get
		{
			if (_lastLoginAt == default(DateTimeOffset) && !string.IsNullOrEmpty(_lastLoginAtStr))
			{
				_lastLoginAt = DateTimeOffset.Parse(_lastLoginAtStr).ToUniversalTime();
			}
			return _lastLoginAt;
		}
		set
		{
			_lastLoginAt = value.ToUniversalTime();
			_lastLoginAtStr = _lastLoginAt.ToString();
		}
	}
}
