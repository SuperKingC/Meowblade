using Entitas;

public class ReplayFixedUpdateRootSystems : Feature
{
	public ReplayFixedUpdateRootSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new InitConfigSystem(contexts));
		((Systems)this).Add((ISystem)(object)new InitGameStateSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UpdateTimeSystem(contexts));
		((Systems)this).Add((ISystem)(object)new InputFixedSystems(contexts));
		((Systems)this).Add((ISystem)(object)new ElapsedTimeIncreaseSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UpdateCastingAbilityElapsedTimeSystem(contexts));
		((Systems)this).Add((ISystem)(object)new GameStateEventSystems(contexts));
		((Systems)this).Add((ISystem)(object)new GameEventSystems(contexts));
		((Systems)this).Add((ISystem)(object)new TimerEventSystems(contexts));
		((Systems)this).Add((ISystem)(object)new ConfigEventSystems(contexts));
		((Systems)this).Add((ISystem)(object)new HealthBarToggleSystem(contexts));
		((Systems)this).Add((ISystem)(object)new GameCleanupSystems(contexts));
		((Systems)this).Add((ISystem)(object)new TimerCleanupSystems(contexts));
	}
}
