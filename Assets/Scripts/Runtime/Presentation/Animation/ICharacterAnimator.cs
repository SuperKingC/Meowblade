namespace Meowblade
{
    public interface ICharacterAnimator
    {
        bool IsTerminated { get; }

        void Play(CharacterAnimationCommand command);

        void SetBaseState(CharacterAnimationState state);

        void Tick(float deltaTime, float playbackSpeed);

        void ResetVisualState();
    }
}
