using System;

namespace Meowblade
{
    public sealed class CharacterAnimationProfile
    {
        public CharacterAnimationProfile(
            HeroId heroId,
            float attackDuration,
            float skillDuration,
            float hitDuration,
            float retreatDuration,
            float victoryDuration,
            float downDuration,
            float selectedDuration,
            float moveBobAmplitude,
            float attackLungeAmplitude,
            float hitShakeAmplitude,
            float selectedPulseAmplitude)
        {
            HeroId = heroId;
            AttackDuration = RequirePositive(attackDuration, nameof(attackDuration));
            SkillDuration = RequirePositive(skillDuration, nameof(skillDuration));
            HitDuration = RequirePositive(hitDuration, nameof(hitDuration));
            RetreatDuration = RequirePositive(retreatDuration, nameof(retreatDuration));
            VictoryDuration = RequirePositive(victoryDuration, nameof(victoryDuration));
            DownDuration = RequirePositive(downDuration, nameof(downDuration));
            SelectedDuration = RequirePositive(selectedDuration, nameof(selectedDuration));
            MoveBobAmplitude = RequireNonNegative(moveBobAmplitude, nameof(moveBobAmplitude));
            AttackLungeAmplitude = RequireNonNegative(attackLungeAmplitude, nameof(attackLungeAmplitude));
            HitShakeAmplitude = RequireNonNegative(hitShakeAmplitude, nameof(hitShakeAmplitude));
            SelectedPulseAmplitude = RequireNonNegative(selectedPulseAmplitude, nameof(selectedPulseAmplitude));
        }

        public HeroId HeroId { get; }

        public float AttackDuration { get; }

        public float SkillDuration { get; }

        public float HitDuration { get; }

        public float RetreatDuration { get; }

        public float VictoryDuration { get; }

        public float DownDuration { get; }

        public float SelectedDuration { get; }

        public float MoveBobAmplitude { get; }

        public float AttackLungeAmplitude { get; }

        public float HitShakeAmplitude { get; }

        public float SelectedPulseAmplitude { get; }

        public float DurationFor(CharacterAnimationState state)
        {
            switch (state)
            {
                case CharacterAnimationState.Attack:
                    return AttackDuration;
                case CharacterAnimationState.Skill:
                    return SkillDuration;
                case CharacterAnimationState.Hit:
                    return HitDuration;
                case CharacterAnimationState.Retreat:
                    return RetreatDuration;
                case CharacterAnimationState.Victory:
                    return VictoryDuration;
                case CharacterAnimationState.Down:
                    return DownDuration;
                case CharacterAnimationState.Selected:
                    return SelectedDuration;
                default:
                    return 0f;
            }
        }

        private static float RequirePositive(float value, string parameterName)
        {
            if (value <= 0f)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, "Duration must be positive.");
            }

            return value;
        }

        private static float RequireNonNegative(float value, string parameterName)
        {
            if (value < 0f)
            {
                throw new ArgumentOutOfRangeException(parameterName, value, "Amplitude cannot be negative.");
            }

            return value;
        }
    }
}
