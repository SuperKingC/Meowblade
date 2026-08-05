using Shift.Legion.Common.Services;

public class OpenSceneCommandExecutor
{
	private readonly Contexts _contexts;

	public OpenSceneCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute(OpenSceneCommand cmd)
	{
		_contexts.Service<BaseSceneService>().OpenScene(cmd.scene, cmd.arguments);
	}
}
