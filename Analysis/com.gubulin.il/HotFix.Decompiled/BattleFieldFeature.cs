using Entitas;

public class BattleFieldFeature : Feature
{
	public BattleFieldFeature(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new AddMarkToUnitFloorWhenBattleConfigChangedSystem(contexts));
		((Systems)this).Add((ISystem)(object)new HideNextLevelComingSystem(contexts));
	}
}
