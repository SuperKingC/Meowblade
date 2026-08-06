using System.Collections.Generic;

namespace Meowblade
{
    public static class CharacterAnimationProfiles
    {
        private static readonly IReadOnlyDictionary<HeroId, CharacterAnimationProfile> Profiles =
            new Dictionary<HeroId, CharacterAnimationProfile>
            {
                {
                    HeroId.CardboardKnight,
                    new CharacterAnimationProfile(
                        HeroId.CardboardKnight,
                        attackDuration: 0.55f,
                        skillDuration: 0.9f,
                        hitDuration: 0.3f,
                        retreatDuration: 0.75f,
                        victoryDuration: 1.1f,
                        downDuration: 0.8f,
                        selectedDuration: 0.4f,
                        moveBobAmplitude: 5f,
                        attackLungeAmplitude: 16f,
                        hitShakeAmplitude: 7f,
                        selectedPulseAmplitude: 0.06f)
                },
                {
                    HeroId.FishHunter,
                    new CharacterAnimationProfile(
                        HeroId.FishHunter,
                        attackDuration: 0.45f,
                        skillDuration: 0.8f,
                        hitDuration: 0.25f,
                        retreatDuration: 0.65f,
                        victoryDuration: 1f,
                        downDuration: 0.75f,
                        selectedDuration: 0.35f,
                        moveBobAmplitude: 6f,
                        attackLungeAmplitude: 20f,
                        hitShakeAmplitude: 6f,
                        selectedPulseAmplitude: 0.07f)
                },
                {
                    HeroId.YarnMage,
                    new CharacterAnimationProfile(
                        HeroId.YarnMage,
                        attackDuration: 0.6f,
                        skillDuration: 1.05f,
                        hitDuration: 0.3f,
                        retreatDuration: 0.7f,
                        victoryDuration: 1.2f,
                        downDuration: 0.85f,
                        selectedDuration: 0.45f,
                        moveBobAmplitude: 4f,
                        attackLungeAmplitude: 12f,
                        hitShakeAmplitude: 8f,
                        selectedPulseAmplitude: 0.08f)
                }
            };

        public static CharacterAnimationProfile Fallback { get; } =
            new CharacterAnimationProfile(
                (HeroId)(-1),
                attackDuration: 0.5f,
                skillDuration: 0.9f,
                hitDuration: 0.3f,
                retreatDuration: 0.7f,
                victoryDuration: 1f,
                downDuration: 0.8f,
                selectedDuration: 0.4f,
                moveBobAmplitude: 5f,
                attackLungeAmplitude: 15f,
                hitShakeAmplitude: 7f,
                selectedPulseAmplitude: 0.06f);

        public static CharacterAnimationProfile ForHero(HeroId heroId)
        {
            CharacterAnimationProfile profile;
            return Profiles.TryGetValue(heroId, out profile) ? profile : Fallback;
        }
    }
}
