using System;
using System.Collections.Generic;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Models;

public class InvitedWorker
{
	public int UserId { get; set; }

	public int InvitedUserId { get; set; }

	public string Avatar { get; set; }

	public string Nickname { get; set; }

	public int Level { get; set; }

	public KeyValuePair<string, int> AllocateInfo { get; set; }

	public DateTimeOffset InviteAt { get; set; }

	public DateTimeOffset ExpireAt { get; set; }

	public InvitedWorkerActivateStatus Status { get; set; }
}
