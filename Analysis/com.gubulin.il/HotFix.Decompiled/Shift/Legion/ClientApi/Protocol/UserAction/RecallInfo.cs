using System;
using System.Collections.Generic;
using ILRuntime_LitJson;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class RecallInfo
{
	public DateTimeOffset LastActiveTime { get; set; }

	public DateTimeOffset RecallTime { get; set; }

	public bool IsRecallPlayer { get; set; } = false;

	public bool ClaimRecallPlayerBonus { get; set; } = false;

	[JsonIgnore]
	public List<RItem> Bonus { get; set; }

	[JsonIgnore]
	public string ProgressDesc { get; set; }

	[JsonIgnore]
	public int InviterClaimCount { get; set; }
}
