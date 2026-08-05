using Entitas;

public sealed class GameEventSystems : Feature
{
	public GameEventSystems(Contexts contexts)
	{
		((Systems)this).Add((ISystem)(object)new AlphaEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnimationEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnimationDurationEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnimationInitializedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyAssetEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AssetRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AudioClipNameEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AudioVolumeEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyBattleFieldEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyCameraEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new CastingAbilityElapsedTimeEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new CollisionRadiusEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new DeadEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new GameDestroyedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new FloatingTextEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new FloatingTextAlphaEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new FlowLightFxEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new FlowLightFxRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new HeightEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ModelEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new MoveSpeedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyPlayerEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new PositionEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new RotationEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ScaleEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnySceneLoadedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ShadowScaleEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ShowCastingBarEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ShowCastingBarRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ShowGizmosEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ShowHealthBarEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new ShowHealthBarRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new SkeletonEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new SkinEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new SpecialFxEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new SpecialFxRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new TargetPositionEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new AnyUnitEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UnitBaseImageEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UnitBaseImageRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UnitImageIndicatorEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UnitImageIndicatorRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UnitIndicatorEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UnitIndicatorRemovedEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UnitScaleEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new UnitStatsEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new VisibleEventSystem(contexts));
		((Systems)this).Add((ISystem)(object)new VisibleRemovedEventSystem(contexts));
	}
}
