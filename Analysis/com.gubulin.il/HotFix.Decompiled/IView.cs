public interface IView : IEventListener, IPositionListener, IRotationListener, IScaleListener, IAssetRemovedListener, IGameDestroyedListener
{
	void Initialize(Contexts contexts, GameEntity entity);

	void AddSubView(IView view);
}
