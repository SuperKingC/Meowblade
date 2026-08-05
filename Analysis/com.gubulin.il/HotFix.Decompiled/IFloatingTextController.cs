using HotFix;

public interface IFloatingTextController : IFloatingTextListener, IFloatingTextAlphaListener, IPooled
{
	void Initialize(Contexts contexts, GameEntity entity);
}
