using Entitas;

public class ConfigSystems : Feature
{
	public ConfigSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new InitConfigSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UpdateConfigAfterUserLoginSystem(contexts));
	}
}
