using Entitas;

public class ProjectileFeature : Feature
{
	public ProjectileFeature(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new InitProjectileLaunchSettingSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UpdateProjectileTargetPositionFromTargetBoneSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ProjectileMoveSystem(contexts));
		((Systems)this).Add((ISystem)(object)new DestroyProjectileSystem(contexts));
	}
}
