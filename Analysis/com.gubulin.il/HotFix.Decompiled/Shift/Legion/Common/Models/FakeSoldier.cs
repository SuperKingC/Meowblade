using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class FakeSoldier : Soldier
{
	public override int EvoLevel { get; set; }

	public override int Level { get; set; }

	public override int PotentialLevel { get; set; }

	public new string AiType => base.AiType;

	public new int MaxLevel => _managers.UserArchiveManager.GetSoldierMaxLevel(Id, EvoLevel);

	public FakeSoldier(string soldierId, int level, int evoLevel, int potentialLevel)
		: base(soldierId)
	{
		Level = level;
		EvoLevel = evoLevel;
		PotentialLevel = potentialLevel;
	}
}
