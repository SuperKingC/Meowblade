using System;
using System.Globalization;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class UserInfo
{
	[ProtoMember(6)]
	public string _lastLoginAtStr;

	[ProtoMember(7)]
	public bool IsNew;

	private DateTimeOffset _lastLoginAt;

	private DateTimeOffset _lastLoginAt2;

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

	public DateTimeOffset LastLoginAt2
	{
		get
		{
			if (_lastLoginAt2 == default(DateTimeOffset) && !string.IsNullOrEmpty(_lastLoginAtStr))
			{
				try
				{
					_lastLoginAt2 = DateTimeOffset.Parse(_lastLoginAtStr, CultureInfo.InvariantCulture).ToUniversalTime();
				}
				catch (FormatException)
				{
					ILRuntimeDebug.LogError("LastLoginAt2 Format error \"" + _lastLoginAtStr + "\"");
				}
			}
			return _lastLoginAt2;
		}
	}

	[ProtoMember(8)]
	public bool Valid { get; set; }
}
