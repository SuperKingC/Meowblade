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

        [TestCase(CharacterAnimationState.Retreat, true)]
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

        [Test]
        public void SkillSuppressesAttackOnSameBatch()
        {
            Assert.That(
                SpineCharacterAnimator.CanTransition(
                    CharacterAnimationState.Skill,
                    CharacterAnimationState.Attack),
                Is.False);
        }

        [Test]
        public void HitCanInterruptAttack()
        {
            Assert.That(
                SpineCharacterAnimator.CanTransition(
                    CharacterAnimationState.Attack,
                    CharacterAnimationState.Hit),
                Is.True);
        }

        [Test]
        public void RetreatTerminatesFurtherCommands()
        {
            var model = new SpineCharacterAnimator.StateModel();

            Assert.That(model.Play(CharacterAnimationState.Retreat, 0.5f), Is.True);
            Assert.That(model.IsTerminated, Is.True);
            Assert.That(model.Play(CharacterAnimationState.Hit, 0.5f), Is.False);
            Assert.That(model.CurrentState, Is.EqualTo(CharacterAnimationState.Retreat));
        }

        [Test]
        public void OneShotReturnsToMoveWhenBaseStateIsMove()
        {
            var model = new SpineCharacterAnimator.StateModel();
            model.SetBaseState(CharacterAnimationState.Move);

            Assert.That(model.Play(CharacterAnimationState.Attack, 0.5f), Is.True);
            Assert.That(model.Tick(0.25f, 2f), Is.True);
            Assert.That(model.CurrentState, Is.EqualTo(CharacterAnimationState.Move));
        }

        [Test]
        public void ResetClearsTerminationAndRestoresIdleState()
        {
            var model = new SpineCharacterAnimator.StateModel();
            model.Play(CharacterAnimationState.Down, 0.5f);

            model.Reset();

            Assert.That(model.IsTerminated, Is.False);
            Assert.That(model.BaseState, Is.EqualTo(CharacterAnimationState.Idle));
            Assert.That(model.CurrentState, Is.EqualTo(CharacterAnimationState.Idle));
        }
    }
}
