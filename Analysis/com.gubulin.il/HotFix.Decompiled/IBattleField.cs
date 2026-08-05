public interface IBattleField : IEventListener, IAnyBattleStartedListener, IAnyBattleStartedRemovedListener, IAnyCurrentLevelBattleStartedListener, IAnyCurrentLevelBattleStartedRemovedListener, IAnyBattleFieldLevelListener, IAnyBattleFieldMapIdentifierListener, IPositionListener, IVisibleListener, IVisibleRemovedListener, IGameDestroyedListener
{
	void Initialize(Contexts contexts, GameEntity entity);

	void PlaySpawnUnitsAnimation();

	void PlayAnimationWhenBattleStart();
}
