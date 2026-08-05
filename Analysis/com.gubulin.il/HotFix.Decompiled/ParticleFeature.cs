using Entitas;

public class ParticleFeature : Feature
{
	public ParticleFeature(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new ParticleFullscreenFollowCameraSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ParticleFullscreenMoveSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ParticleFollowTargetSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ParticleFollowTargetBoneSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ParticleFollowTargetScaleSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ParticlePlaySystem(contexts));
		((Systems)this).Add((ISystem)(object)new DestroyParticleSystem(contexts));
	}
}
