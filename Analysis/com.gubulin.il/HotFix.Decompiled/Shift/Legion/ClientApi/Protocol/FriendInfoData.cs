using System;

namespace Shift.Legion.ClientApi.Protocol;

public class FriendInfoData
{
	public int UserId { get; set; }

	public string Nickname { get; set; }

	public string Avatar { get; set; }

	public string Datas { get; set; }

	public string Keys { get; set; }

	public DateTimeOffset LastLoginAt { get; set; }
}
