using Shift.Legion.Common.Enums;

public interface IAnimator : IAnimationListener, IAnimationDurationListener, IEventListener, IModelListener, ISkinListener, IAlphaListener, IAnimationInitializedListener
{
	void Initialize(Contexts contexts, GameEntity entity);

	void PlayAnimationOnTrack(AnimationName animation, int trackIndex = 1, bool loop = false);

	void ClearTrack(int trackIndex = 1);

	void ResumeAnimation();

	void PauseAnimation();
}
