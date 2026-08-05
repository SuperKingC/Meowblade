using Entitas;

public class FloatingTextFeature : Feature
{
	public FloatingTextFeature(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new FloatingTextFadeOutSystem(contexts));
		((Systems)this).Add((ISystem)(object)new DestroyExpiredFloatingTextSystem(contexts));
	}
}
