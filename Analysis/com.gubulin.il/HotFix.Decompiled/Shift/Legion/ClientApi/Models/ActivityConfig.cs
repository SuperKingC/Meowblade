using System;
using System.Collections.Generic;

namespace Shift.Legion.ClientApi.Models;

public class ActivityConfig
{
	public string ActivityId;

	public int Score = 0;

	public Dictionary<string, object> Progress = new Dictionary<string, object>();

	public Dictionary<string, object> Cooldown = new Dictionary<string, object>();

	public List<float> ClaimProgress = new List<float>();

	public DateTimeOffset ModifiedAt;

	public DateTimeOffset BeginAt;

	public DateTimeOffset LastResetAt;

	public DateTimeOffset LastAutoFillAt;

	public DateTimeOffset PeriodStartAt;

	public Dictionary<string, ActivityUiInfo> PayloadUiInfo = new Dictionary<string, ActivityUiInfo>();

	public Dictionary<string, List<List<ModelsBonus>>> PayloadBonusInfo;

	public bool IsNew = true;

	public DateTimeOffset LastPeriodStarAt;

	public void UsedOnlyForAOTCodeGeneration()
	{
		new Dictionary<string, ActivityUiInfo>();
		new Dictionary<string, List<List<ModelsBonus>>>();
		throw new InvalidOperationException("This method is used for AOT code generation only.Do not call it at runtime.");
	}
}
