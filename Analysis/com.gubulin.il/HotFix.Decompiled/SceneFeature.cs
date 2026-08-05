using Entitas;

public class SceneFeature : Feature
{
	public SceneFeature(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new ShowLoadingUiOnSceneCreatedSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UnloadPreviousSceneOnSceneCreatedSystem(contexts));
		((Systems)this).Add((ISystem)(object)new LoadSceneSystem(contexts));
		((Systems)this).Add((ISystem)(object)new CloseLoadingUiOnSceneLoadedSystem(contexts));
	}
}
