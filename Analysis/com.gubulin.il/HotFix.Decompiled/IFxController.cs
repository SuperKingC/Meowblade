public interface IFxController : IEventListener, ISpecialFxListener, ISpecialFxRemovedListener, IFlowLightFxListener, IFlowLightFxRemovedListener
{
	void Initialize(Contexts contexts, GameEntity entity);
}
