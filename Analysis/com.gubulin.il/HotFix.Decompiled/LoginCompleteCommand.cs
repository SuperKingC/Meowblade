using Entitas;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.CodeGeneration.Attributes;

[Command]
[CommandFlag]
public class LoginCompleteCommand : IComponent
{
	public User user;
}
