using Entitas;
using Shift.Legion.CodeGeneration.Attributes;
using Shift.Legion.Common.Models;

[Command]
[CommandFlag]
public sealed class OpenSceneCommand : IComponent
{
	public string scene;

	public SceneArguments arguments;
}
