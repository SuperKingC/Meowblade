using System;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol;

[ProtoContract]
public class User
{
	[ProtoMember(12)]
	public string _registerAtStr;

	[ProtoMember(120)]
	public int RegisterAtTimestamp;

	private DateTimeOffset _registerAt;

	[ProtoMember(1)]
	public int UserId { get; set; }

	[ProtoMember(2)]
	public string Nickname { get; set; }

	[ProtoMember(3)]
	public string Avatar { get; set; }

	[ProtoMember(4)]
	public int Verified { get; set; }

	[ProtoMember(5)]
	public int VerifyCnt { get; set; }

	[ProtoMember(6)]
	public string InvitingCode { get; set; }

	[ProtoMember(7)]
	public int InvitedFrom { get; set; }

	[ProtoMember(8)]
	public string LastLoginType { get; set; }

	[ProtoMember(9)]
	public string LastLoginInfo { get; set; }

	[ProtoMember(10)]
	public int Seed { get; set; }

	[ProtoMember(11)]
	public string Telephone { get; set; }

	public DateTimeOffset RegisterAt
	{
		get
		{
			if (_registerAt == default(DateTimeOffset))
			{
				_registerAt = DateTimeHelper.ParseTimeStamp(RegisterAtTimestamp);
			}
			return _registerAt;
		}
		set
		{
			_registerAt = value.ToUniversalTime();
			RegisterAtTimestamp = DateTimeHelper.GetTimeStamp(_registerAt);
			_registerAtStr = _registerAt.ToString();
		}
	}

	[ProtoMember(80)]
	public string FeedbackToken { get; set; }

	[ProtoMember(90)]
	public int ServerId { get; set; }

	[ProtoMember(91)]
	public string ServerName { get; set; }

	[ProtoMember(92)]
	public int ChannelCode { get; set; }
}
