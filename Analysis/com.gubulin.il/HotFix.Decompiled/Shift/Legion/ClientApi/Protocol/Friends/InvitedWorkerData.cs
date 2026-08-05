using System;

namespace Shift.Legion.ClientApi.Protocol.Friends;

public class InvitedWorkerData
{
	public int UserId { get; set; }

	public int InvitedUserId { get; set; }

	public string Avatar { get; set; }

	public string Nickname { get; set; }

	public string Level { get; set; }

	public DateTimeOffset InviteAt { get; set; }

	public DateTimeOffset ExpireAt { get; set; }

	public int Status { get; set; }
}
