using System.Collections.Generic;
using UnityEngine;

namespace Meowblade
{
    public sealed class BattleAnimationBridge
    {
        private readonly Dictionary<int, Vector2> previousPositions = new Dictionary<int, Vector2>();
        private bool finishProcessed;

        public void ProcessBatch(
            IReadOnlyList<BattleEvent> events,
            IReadOnlyDictionary<int, ICharacterAnimator> animators,
            BattleResult result,
            bool finished)
        {
            ProcessBatch(events, animators, result, finished, null);
        }

        public void ProcessBatch(
            IReadOnlyList<BattleEvent> events,
            IReadOnlyDictionary<int, ICharacterAnimator> animators,
            BattleResult result,
            bool finished,
            IReadOnlyList<BattleUnit> units)
        {
            if (events == null || animators == null)
            {
                return;
            }

            var skillSources = new HashSet<int>();
            for (int i = 0; i < events.Count; i++)
            {
                BattleEvent battleEvent = events[i];
                if (battleEvent != null && battleEvent.Type == BattleEventType.Skill)
                {
                    skillSources.Add(battleEvent.SourceUnitId);
                }
            }

            Dictionary<int, BattleUnit> unitsById = BuildUnitMap(units);
            for (int i = 0; i < events.Count; i++)
            {
                BattleEvent battleEvent = events[i];
                if (battleEvent == null)
                {
                    continue;
                }

                switch (battleEvent.Type)
                {
                    case BattleEventType.Damage:
                        Play(animators, battleEvent.SourceUnitId,
                            skillSources.Contains(battleEvent.SourceUnitId)
                                ? (CharacterAnimationState?)null
                                : CharacterAnimationState.Attack,
                            new CharacterAnimationCommand(
                                CharacterAnimationState.Attack,
                                battleEvent.SourceUnitId,
                                battleEvent.TargetUnitId,
                                CharacterEffectKind.Attack,
                                battleEvent.Value));
                        Play(animators, battleEvent.TargetUnitId, CharacterAnimationState.Hit,
                            new CharacterAnimationCommand(
                                CharacterAnimationState.Hit,
                                battleEvent.SourceUnitId,
                                battleEvent.TargetUnitId,
                                CharacterEffectKind.Hit,
                                battleEvent.Value));
                        break;

                    case BattleEventType.Skill:
                        Play(animators, battleEvent.SourceUnitId, CharacterAnimationState.Skill,
                            new CharacterAnimationCommand(
                                CharacterAnimationState.Skill,
                                battleEvent.SourceUnitId,
                                battleEvent.TargetUnitId,
                                CharacterEffectKind.Skill,
                                battleEvent.Value));
                        break;

                    case BattleEventType.UnitDown:
                        CharacterAnimationState downState = CharacterAnimationState.Down;
                        BattleUnit downUnit;
                        if (unitsById.TryGetValue(battleEvent.SourceUnitId, out downUnit) && downUnit.IsPlayer)
                        {
                            downState = CharacterAnimationState.Retreat;
                        }

                        Play(animators, battleEvent.SourceUnitId, downState,
                            new CharacterAnimationCommand(
                                downState,
                                battleEvent.SourceUnitId,
                                effectKind: downState == CharacterAnimationState.Retreat
                                    ? CharacterEffectKind.Retreat
                                    : CharacterEffectKind.None));
                        break;

                    case BattleEventType.Command:
                        for (int unitIndex = 0; unitIndex < units.Count; unitIndex++)
                        {
                            BattleUnit unit = units[unitIndex];
                            if (unit != null && unit.IsPlayer && unit.Alive)
                            {
                                Play(animators, unit.Id, CharacterAnimationState.Selected,
                                    new CharacterAnimationCommand(
                                        CharacterAnimationState.Selected,
                                        unit.Id,
                                        effectKind: CharacterEffectKind.Command));
                            }
                        }
                        break;
                }
            }

            if (finished && !finishProcessed)
            {
                finishProcessed = true;
                if (result != null && result.Victory)
                {
                    for (int unitIndex = 0; unitIndex < units.Count; unitIndex++)
                    {
                        BattleUnit unit = units[unitIndex];
                        if (unit != null && unit.IsPlayer && unit.IsHero && unit.Alive)
                        {
                            Play(animators, unit.Id, CharacterAnimationState.Victory,
                                new CharacterAnimationCommand(
                                    CharacterAnimationState.Victory,
                                    unit.Id,
                                    effectKind: CharacterEffectKind.Victory));
                        }
                    }
                }
            }
        }

        public void UpdateBaseStates(
            IReadOnlyList<BattleUnit> units,
            IReadOnlyDictionary<int, ICharacterAnimator> animators)
        {
            if (units == null || animators == null)
            {
                return;
            }

            for (int i = 0; i < units.Count; i++)
            {
                BattleUnit unit = units[i];
                if (unit == null)
                {
                    continue;
                }

                Vector2 previousPosition;
                bool moved = previousPositions.TryGetValue(unit.Id, out previousPosition) &&
                    (unit.Position - previousPosition).sqrMagnitude > 0.0001f;
                previousPositions[unit.Id] = unit.Position;

                ICharacterAnimator animator;
                if (animators.TryGetValue(unit.Id, out animator) && animator != null)
                {
                    animator.SetBaseState(moved ? CharacterAnimationState.Move : CharacterAnimationState.Idle);
                }
            }
        }

        private static Dictionary<int, BattleUnit> BuildUnitMap(IReadOnlyList<BattleUnit> units)
        {
            var result = new Dictionary<int, BattleUnit>();
            if (units == null)
            {
                return result;
            }

            for (int i = 0; i < units.Count; i++)
            {
                BattleUnit unit = units[i];
                if (unit != null)
                {
                    result[unit.Id] = unit;
                }
            }

            return result;
        }

        private static void Play(
            IReadOnlyDictionary<int, ICharacterAnimator> animators,
            int unitId,
            CharacterAnimationState? state,
            CharacterAnimationCommand command)
        {
            if (!state.HasValue)
            {
                return;
            }

            ICharacterAnimator animator;
            if (animators.TryGetValue(unitId, out animator) && animator != null)
            {
                animator.Play(command);
            }
        }
    }
}
