using System;
using System.Linq;
using NUnit.Framework;

namespace Meowblade.Tests
{
    public sealed class CharacterAnimationTests
    {
        private static readonly CharacterAnimationState[] RequiredStates =
        {
            CharacterAnimationState.Idle,
            CharacterAnimationState.Move,
            CharacterAnimationState.Attack,
            CharacterAnimationState.Skill,
            CharacterAnimationState.Hit,
            CharacterAnimationState.Retreat,
            CharacterAnimationState.Victory,
            CharacterAnimationState.Down,
            CharacterAnimationState.Selected
        };

        private static readonly CharacterAnimationState[] OneShotStates =
        {
            CharacterAnimationState.Attack,
            CharacterAnimationState.Skill,
            CharacterAnimationState.Hit,
            CharacterAnimationState.Retreat,
            CharacterAnimationState.Victory,
            CharacterAnimationState.Down,
            CharacterAnimationState.Selected
        };

        [Test]
        public void CharacterAnimationState_ContainsEveryRequiredState()
        {
            CharacterAnimationState[] actual =
                Enum.GetValues(typeof(CharacterAnimationState)).Cast<CharacterAnimationState>().ToArray();

            CollectionAssert.AreEquivalent(RequiredStates, actual);
        }

        [Test]
        public void ForHero_ReturnsMatchingProfileForEveryConfiguredHero()
        {
            foreach (HeroId heroId in GameBalance.AllHeroes)
            {
                CharacterAnimationProfile profile = CharacterAnimationProfiles.ForHero(heroId);

                Assert.That(profile, Is.Not.Null, heroId.ToString());
                Assert.That(profile.HeroId, Is.EqualTo(heroId));
                Assert.That(profile, Is.Not.SameAs(CharacterAnimationProfiles.Fallback));
            }
        }

        [Test]
        public void ForHero_ReturnsFallbackForUnknownHero()
        {
            CharacterAnimationProfile profile = CharacterAnimationProfiles.ForHero((HeroId)999);

            Assert.That(profile, Is.SameAs(CharacterAnimationProfiles.Fallback));
        }

        [Test]
        public void EveryOneShotState_HasPositiveDurationForEveryProfile()
        {
            CharacterAnimationProfile[] profiles = GameBalance.AllHeroes
                .Select(CharacterAnimationProfiles.ForHero)
                .Append(CharacterAnimationProfiles.Fallback)
                .ToArray();

            foreach (CharacterAnimationProfile profile in profiles)
            {
                foreach (CharacterAnimationState state in OneShotStates)
                {
                    Assert.That(
                        profile.DurationFor(state),
                        Is.GreaterThan(0f),
                        $"{profile.HeroId}/{state}");
                }
            }
        }

        [TestCase(CharacterAnimationState.Down, true)]
        [TestCase(CharacterAnimationState.Victory, true)]
        [TestCase(CharacterAnimationState.Idle, false)]
        [TestCase(CharacterAnimationState.Attack, false)]
        public void IsTerminalState_OnlyLocksTerminalAnimations(
            CharacterAnimationState state,
            bool expected)
        {
            Assert.That(SpineCharacterAnimator.IsTerminalState(state), Is.EqualTo(expected));
        }

        [Test]
        public void CanTransition_RejectsLowerPriorityAndTerminalInterruptions()
        {
            Assert.That(
                SpineCharacterAnimator.CanTransition(
                    CharacterAnimationState.Attack,
                    CharacterAnimationState.Idle),
                Is.False);
            Assert.That(
                SpineCharacterAnimator.CanTransition(
                    CharacterAnimationState.Idle,
                    CharacterAnimationState.Attack),
                Is.True);
            Assert.That(
                SpineCharacterAnimator.CanTransition(
                    CharacterAnimationState.Down,
                    CharacterAnimationState.Hit),
                Is.False);
            Assert.That(
                SpineCharacterAnimator.CanTransition(
                    CharacterAnimationState.Down,
                    CharacterAnimationState.Down),
                Is.True);
        }

        [TestCase(CharacterAnimationState.Idle, "idle")]
        [TestCase(CharacterAnimationState.Move, "move")]
        [TestCase(CharacterAnimationState.Attack, "attack")]
        [TestCase(CharacterAnimationState.Selected, "selected")]
        public void AnimationNameFor_UsesLowerCaseStateNames(
            CharacterAnimationState state,
            string expected)
        {
            Assert.That(SpineCharacterAnimator.AnimationNameFor(state), Is.EqualTo(expected));
        }
    }
}
