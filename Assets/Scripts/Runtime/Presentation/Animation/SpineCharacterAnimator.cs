using System;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

namespace Meowblade
{
    public sealed class SpineCharacterAnimator : MonoBehaviour, ICharacterAnimator
    {
        [SerializeField] private SkeletonGraphic skeletonGraphic;
        [SerializeField] private Image fallbackImage;

        private CharacterAnimationState baseState = CharacterAnimationState.Idle;
        private CharacterAnimationState currentState = CharacterAnimationState.Idle;

        public CharacterAnimationState CurrentState => currentState;
        public CharacterAnimationState BaseState => baseState;

        private void Awake()
        {
            ResetVisuals();
            Play(baseState, true);
        }

        public void SetBaseState(CharacterAnimationState state)
        {
            baseState = state;
            if (!IsTerminalState(currentState))
            {
                Play(state);
            }
        }

        public void Play(CharacterAnimationState state)
        {
            Play(state, false);
        }

        public void Play(CharacterAnimationState state, bool force)
        {
            if (!force && !CanTransition(currentState, state))
            {
                return;
            }

            currentState = state;
            string animationName = AnimationNameFor(state);
            bool playedSpineAnimation = TryPlaySpineAnimation(animationName, IsLoopingState(state));
            SetFallbackVisible(!playedSpineAnimation);
        }

        public void ReturnToBaseState()
        {
            Play(baseState, true);
        }

        public void ResetVisuals()
        {
            ResetGraphic(skeletonGraphic);
            ResetGraphic(fallbackImage);
            ResetTransform(skeletonGraphic != null ? skeletonGraphic.rectTransform : null);
            ResetTransform(fallbackImage != null ? fallbackImage.rectTransform : null);
        }

        public static bool IsTerminalState(CharacterAnimationState state)
        {
            return state == CharacterAnimationState.Down ||
                   state == CharacterAnimationState.Victory;
        }

        public static bool CanTransition(
            CharacterAnimationState current,
            CharacterAnimationState requested)
        {
            if (current == requested)
            {
                return true;
            }

            if (IsTerminalState(current))
            {
                return false;
            }

            return PriorityFor(requested) >= PriorityFor(current);
        }

        public static string AnimationNameFor(CharacterAnimationState state)
        {
            return state.ToString().ToLowerInvariant();
        }

        public static int PriorityFor(CharacterAnimationState state)
        {
            switch (state)
            {
                case CharacterAnimationState.Down:
                    return 100;
                case CharacterAnimationState.Victory:
                    return 90;
                case CharacterAnimationState.Skill:
                    return 80;
                case CharacterAnimationState.Attack:
                    return 70;
                case CharacterAnimationState.Hit:
                    return 60;
                case CharacterAnimationState.Retreat:
                    return 50;
                case CharacterAnimationState.Selected:
                    return 40;
                case CharacterAnimationState.Move:
                    return 20;
                case CharacterAnimationState.Idle:
                default:
                    return 10;
            }
        }

        private bool TryPlaySpineAnimation(string animationName, bool loop)
        {
            IAnimationStateComponent animationStateComponent = skeletonGraphic;
            if (animationStateComponent == null ||
                skeletonGraphic.SkeletonDataAsset == null ||
                skeletonGraphic.SkeletonDataAsset.GetSkeletonData(false) == null ||
                skeletonGraphic.SkeletonDataAsset.GetSkeletonData(false).FindAnimation(animationName) == null)
            {
                return false;
            }

            animationStateComponent.AnimationState.SetAnimation(0, animationName, loop);
            return true;
        }

        private void SetFallbackVisible(bool visible)
        {
            if (fallbackImage != null)
            {
                fallbackImage.enabled = visible;
            }

            if (skeletonGraphic != null)
            {
                skeletonGraphic.enabled = !visible;
            }
        }

        private static bool IsLoopingState(CharacterAnimationState state)
        {
            return state == CharacterAnimationState.Idle ||
                   state == CharacterAnimationState.Move;
        }

        private static void ResetGraphic(Graphic graphic)
        {
            if (graphic == null)
            {
                return;
            }

            graphic.color = Color.white;
            CanvasRenderer renderer = graphic.canvasRenderer;
            if (renderer != null)
            {
                renderer.SetAlpha(1f);
            }
        }

        private static void ResetTransform(RectTransform rectTransform)
        {
            if (rectTransform == null)
            {
                return;
            }

            rectTransform.localPosition = Vector3.zero;
            rectTransform.localRotation = Quaternion.identity;
            rectTransform.localScale = Vector3.one;
        }
    }
}
