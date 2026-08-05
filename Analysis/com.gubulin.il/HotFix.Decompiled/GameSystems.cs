using Entitas;

public class GameSystems : Feature
{
	public GameSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new ElapsedTimeIncreaseSystem(contexts));
		((Systems)this).Add((ISystem)(object)new TickElapsedTimeSystem(contexts));
		((Systems)this).Add((ISystem)(object)new TimerFeature(contexts));
		((Systems)this).Add((ISystem)(object)new BuildingSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ActivitySystem(contexts));
		((Systems)this).Add((ISystem)(object)new LeaseholdSystem(contexts));
		((Systems)this).Add((ISystem)(object)new StoreSystem(contexts));
		((Systems)this).Add((ISystem)(object)new MailSystem(contexts));
		((Systems)this).Add((ISystem)(object)new SaveGameDataSystem(contexts));
	}
}
