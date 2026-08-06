using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace Meowblade.Tests
{
    public sealed class BattleAnimationBridgeTests
    {
        private sealed class RecordingAnimator : ICharacterAnimator
        {
            public readonly List<CharacterAnimationCommand> Commands = new List<CharacterAnimationCommand>();

            public bool IsTerminated { get { return false; } }

            public void Play(CharacterAnimationCommand command)
            {
                Commands.Add(command);
            }

            public void SetBaseState(CharacterAnimationState state)
            {
                Commands.Add(new CharacterAnimationCommand(state, -1));
            }

            public void Tick(float deltaTime, float playbackSpeed)
            {
            }

            public void ResetVisualState()
            {
            }

            public bool HasState(CharacterAnimationState state)
            {
                return Commands.Any(command => command.State == state);
            }

            public bool HasEffect(CharacterEffectKind effectKind)
            {
                return Commands.Any(command => command.EffectKind == effectKind);
            }
        }

        [Test]
        public void ProcessBatch_SkillSourceDamageBatchPlaysSkillHitButNotAttack()
        {
            var source = new RecordingAnimator();
            var target = new RecordingAnimator();
            var animators = new Dictionary<int, ICharacterAnimator>
            {
                { 1, source },
                { 2, target }
            };

            var events = new List<BattleEvent>
            {
                new BattleEvent(BattleEventType.Skill, "localized skill", 1, -1, 0f),
                new BattleEvent(BattleEventType.Damage, "localized damage", 1, 2, 12f)
            };

            new BattleAnimationBridge().ProcessBatch(events, animators, new BattleResult(), false);

            Assert.That(source.Commands.Count(command => command.State == CharacterAnimationState.Skill), Is.EqualTo(1));
            Assert.That(source.Commands.Any(command => command.State == CharacterAnimationState.Attack), Is.False);
            Assert.That(target.HasState(CharacterAnimationState.Hit), Is.True);
        }

        [Test]
        public void ProcessBatch_UnitDownUsesRetreatForPlayersAndDownForEnemies()
        {
            var player = new RecordingAnimator();
            var enemy = new RecordingAnimator();
            var animators = new Dictionary<int, ICharacterAnimator>
            {
                { 1, player },
                { 2, enemy }
            };
            var events = new List<BattleEvent>
            {
                new BattleEvent(BattleEventType.UnitDown, "player text", 1, -1, 0f),
                new BattleEvent(BattleEventType.UnitDown, "enemy text", 2, -1, 0f)
            };

            var units = new List<BattleUnit>
            {
                new BattleUnit { Id = 1, IsPlayer = true },
                new BattleUnit { Id = 2, IsPlayer = false }
            };

            new BattleAnimationBridge().ProcessBatch(events, animators, new BattleResult(), false, units);

            Assert.That(player.HasState(CharacterAnimationState.Retreat), Is.True);
            Assert.That(enemy.HasState(CharacterAnimationState.Down), Is.True);
        }

        [Test]
        public void ProcessBatch_CommandPlaysEffectForAlivePlayerUnitsOnly()
        {
            var alivePlayer = new RecordingAnimator();
            var downPlayer = new RecordingAnimator();
            var enemy = new RecordingAnimator();
            var animators = new Dictionary<int, ICharacterAnimator>
            {
                { 1, alivePlayer },
                { 2, downPlayer },
                { 3, enemy }
            };
            var units = new List<BattleUnit>
            {
                new BattleUnit { Id = 1, IsPlayer = true, Alive = true },
                new BattleUnit { Id = 2, IsPlayer = true, Alive = false },
                new BattleUnit { Id = 3, IsPlayer = false, Alive = true }
            };

            new BattleAnimationBridge().ProcessBatch(
                new[] { new BattleEvent(BattleEventType.Command, "ignored", -1, -1, 0f) },
                animators,
                new BattleResult(),
                false,
                units);

            Assert.That(alivePlayer.HasEffect(CharacterEffectKind.Command), Is.True);
            Assert.That(downPlayer.HasEffect(CharacterEffectKind.Command), Is.False);
            Assert.That(enemy.HasEffect(CharacterEffectKind.Command), Is.False);
        }

        [Test]
        public void ProcessBatch_FinishedVictoryPlaysVictoryForAlivePlayerHeroesOnly()
        {
            var aliveHero = new RecordingAnimator();
            var downHero = new RecordingAnimator();
            var kitten = new RecordingAnimator();
            var animators = new Dictionary<int, ICharacterAnimator>
            {
                { 1, aliveHero },
                { 2, downHero },
                { 3, kitten }
            };
            var units = new List<BattleUnit>
            {
                new BattleUnit { Id = 1, IsPlayer = true, IsHero = true, Alive = true },
                new BattleUnit { Id = 2, IsPlayer = true, IsHero = true, Alive = false },
                new BattleUnit { Id = 3, IsPlayer = true, IsHero = false, IsKitten = true, Alive = true }
            };
            var result = new BattleResult { Victory = true };
            var bridge = new BattleAnimationBridge();

            bridge.ProcessBatch(new BattleEvent[0], animators, result, true, units);
            bridge.ProcessBatch(new BattleEvent[0], animators, result, true, units);

            Assert.That(aliveHero.Commands.Count(command => command.State == CharacterAnimationState.Victory), Is.EqualTo(1));
            Assert.That(downHero.HasState(CharacterAnimationState.Victory), Is.False);
            Assert.That(kitten.HasState(CharacterAnimationState.Victory), Is.False);
        }

        [Test]
        public void UpdateBaseStates_UsesPositionDeltaToChooseIdleOrMove()
        {
            var animator = new RecordingAnimator();
            var animators = new Dictionary<int, ICharacterAnimator> { { 1, animator } };
            var unit = new BattleUnit { Id = 1, Position = Vector2.zero };
            var bridge = new BattleAnimationBridge();

            bridge.UpdateBaseStates(new[] { unit }, animators);
            unit.Position = Vector2.right;
            bridge.UpdateBaseStates(new[] { unit }, animators);

            Assert.That(animator.Commands[0].State, Is.EqualTo(CharacterAnimationState.Idle));
            Assert.That(animator.Commands[1].State, Is.EqualTo(CharacterAnimationState.Move));
        }
    }
}
