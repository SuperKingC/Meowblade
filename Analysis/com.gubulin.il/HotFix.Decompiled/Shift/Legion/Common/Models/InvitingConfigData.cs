using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Models;

public class InvitingConfigData
{
	public GDEInvitingConfigData Data;

	public int UserLevel;

	public int WorkerLifeTime;

	public float WorkerProduceEfficiencyModifier;

	public Dictionary<string, int> InvitingBonus;

	public Dictionary<string, int> InvitedBonus;

	public InvitingConfigData(GDEInvitingConfigData invitingConfigData)
	{
		Data = invitingConfigData;
		UserLevel = Data.UserLevel;
		WorkerLifeTime = Data.InvitedWorkerLifeTime;
		WorkerProduceEfficiencyModifier = Data.WorkerProduceEfficiencyModifier;
		if (!string.IsNullOrEmpty(Data.InvitingBonus))
		{
			InvitingBonus = JsonHelper.ToObject<Dictionary<string, int>>(Data.InvitingBonus);
		}
		if (!string.IsNullOrEmpty(Data.InvitedBonus))
		{
			InvitedBonus = JsonHelper.ToObject<Dictionary<string, int>>(Data.InvitedBonus);
		}
	}
}
