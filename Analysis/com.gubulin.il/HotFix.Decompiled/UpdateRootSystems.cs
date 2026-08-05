using Entitas;

public class UpdateRootSystems : Feature
{
	public UpdateRootSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new UpdateConfigAfterUserLoginSystem(contexts));
		((Systems)this).Add((ISystem)(object)new InputSystems(contexts));
		((Systems)this).Add((ISystem)(object)new InputFixedSystems(contexts));
		((Systems)this).Add((ISystem)(object)new GameStateSystems(contexts));
		((Systems)this).Add((ISystem)(object)new SceneFeature(contexts));
		((Systems)this).Add((ISystem)(object)new FloatingTextFeature(contexts));
		((Systems)this).Add((ISystem)(object)new InitWhenDataLoadedSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UpdateDataReadySystem(contexts));
		((Systems)this).Add((ISystem)(object)new ClearUserDataWhenDataNotReadySystem(contexts));
		((Systems)this).Add((ISystem)(object)new CommandDelaySystem(contexts));
		((Systems)this).Add((ISystem)(object)new CommandFeature(contexts));
		((Systems)this).Add((ISystem)(object)new BattleFieldFeature(contexts));
		((Systems)this).Add((ISystem)(object)new GameSystems(contexts));
		((Systems)this).Add((ISystem)(object)new ParticleFeature(contexts));
		((Systems)this).Add((ISystem)(object)new UnitDeadClearAllParticleSystem(contexts));
		((Systems)this).Add((ISystem)(object)new DestroyUnitSystem(contexts));
		((Systems)this).Add((ISystem)(object)new PlayReplaySystem(contexts));
		((Systems)this).Add((ISystem)(object)new CameraFeature(contexts));
		((Systems)this).Add((ISystem)(object)new GameStateEventSystems(contexts));
		((Systems)this).Add((ISystem)(object)new GameEventSystems(contexts));
		((Systems)this).Add((ISystem)(object)new TimerEventSystems(contexts));
		((Systems)this).Add((ISystem)(object)new ConfigEventSystems(contexts));
		((Systems)this).Add((ISystem)(object)new CommandEventSystems(contexts));
		((Systems)this).Add((ISystem)(object)new GameCleanupSystems(contexts));
		((Systems)this).Add((ISystem)(object)new TimerCleanupSystems(contexts));
		((Systems)this).Add((ISystem)(object)new CommandCleanupSystems(contexts));
		((Systems)this).Add((ISystem)(object)new InputCleanupSystems(contexts));
	}
}
