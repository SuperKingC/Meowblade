using System;
using System.Reflection;
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

        private readonly StateModel stateModel = new StateModel();

        public CharacterAnimationState CurrentState => stateModel.CurrentState;
        public CharacterAnimationState BaseState => stateModel.BaseState;
        public bool IsTerminated => stateModel.IsTerminated;

        private void Awake()
        {
            ResetVisualState();
        }

        public void Play(CharacterAnimationCommand command)
        {
            CharacterAnimationState state = ReadCommandValue(
                command,
                CharacterAnimationState.Idle,
                "State",
                "AnimationState");
            float duration = ReadCommandDuration(command, state);

            if (IsLoopingState(state))
            {
                SetBaseState(state);
                return;
            }

            if (stateModel.Play(state, duration))
            {
                ApplyState();
            }
        }

        public void Tick(float deltaTime, float playbackSpeed)
        {
            if (stateModel.Tick(deltaTime, playbackSpeed))
            {
                ApplyState();
            }
        }

        public void ResetVisualState()
        {
            stateModel.Reset();
            ResetGraphic(skeletonGraphic);
            ResetGraphic(fallbackImage);
            ResetTransform(skeletonGraphic != null ? skeletonGraphic.rectTransform : null);
            ResetTransform(fallbackImage != null ? fallbackImage.rectTransform : null);
            ApplyState();
        }

        public void SetBaseState(CharacterAnimationState state)
        {
            if (stateModel.SetBaseState(state))
            {
                ApplyState();
            }
        }

        public void Play(CharacterAnimationState state, float duration)
        {
            if (stateModel.Play(state, duration))
            {
                ApplyState();
            }
        }

        public static bool IsTerminalState(CharacterAnimationState state)
        {
            return state == CharacterAnimationState.Retreat ||
                   state == CharacterAnimationState.Down ||
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
                case CharacterAnimationState.Retreat:
                case CharacterAnimationState.Down:
                    return 100;
                case CharacterAnimationState.Victory:
                    return 90;
                case CharacterAnimationState.Hit:
                    return 80;
                case CharacterAnimationState.Skill:
                    return 70;
                case CharacterAnimationState.Attack:
                    return 60;
                case CharacterAnimationState.Selected:
                    return 50;
                case CharacterAnimationState.Move:
                    return 20;
                case CharacterAnimationState.Idle:
                default:
                    return 10;
            }
        }

        private void ApplyState()
        {
            string animationName = AnimationNameFor(stateModel.CurrentState);
            bool playedSpineAnimation =
                TryPlaySpineAnimation(animationName, IsLoopingState(stateModel.CurrentState));
            SetFallbackVisible(!playedSpineAnimation);
        }

        private bool TryPlaySpineAnimation(string animationName, bool loop)
        {
            IAnimationStateComponent animationStateComponent = skeletonGraphic;
            if (animationStateComponent == null ||
                skeletonGraphic.SkeletonDataAsset == null)
            {
                return false;
            }

            SkeletonData skeletonData =
                skeletonGraphic.SkeletonDataAsset.GetSkeletonData(false);
            if (skeletonData == null || skeletonData.FindAnimation(animationName) == null)
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
            graphic.canvasRenderer.SetAlpha(1f);
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

        private static T ReadCommandValue<T>(
            CharacterAnimationCommand command,
            T fallback,
            params string[] memberNames)
        {
            object boxedCommand = command;
            Type commandType = boxedCommand.GetType();

            foreach (string memberName in memberNames)
            {
                PropertyInfo property = commandType.GetProperty(
                    memberName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (property != null && property.GetValue(boxedCommand) is T propertyValue)
                {
                    return propertyValue;
                }

                FieldInfo field = commandType.GetField(
                    memberName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (field != null && field.GetValue(boxedCommand) is T fieldValue)
                {
                    return fieldValue;
                }
            }

            return fallback;
        }

        private static float ReadCommandDuration(
            CharacterAnimationCommand command,
            CharacterAnimationState state)
        {
            float directDuration = ReadCommandValue(command, -1f, "Duration");
            if (directDuration >= 0f)
            {
                return directDuration;
            }

            object boxedCommand = command;
            Type commandType = boxedCommand.GetType();
            object profile = ReadMemberValue(
                boxedCommand,
                commandType,
                "Profile",
                "AnimationProfile");
            if (profile == null)
            {
                return 0f;
            }

            MethodInfo durationFor = profile.GetType().GetMethod(
                "DurationFor",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null,
                new[] { typeof(CharacterAnimationState) },
                null);
            return durationFor != null && durationFor.Invoke(profile, new object[] { state }) is float duration
                ? duration
                : 0f;
        }

        private static object ReadMemberValue(
            object instance,
            Type instanceType,
            params string[] memberNames)
        {
            foreach (string memberName in memberNames)
            {
                PropertyInfo property = instanceType.GetProperty(
                    memberName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (property != null)
                {
                    return property.GetValue(instance);
                }

                FieldInfo field = instanceType.GetField(
                    memberName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (field != null)
                {
                    return field.GetValue(instance);
                }
            }

            return null;
        }

        public sealed class StateModel
        {
            private float remainingDuration;

            public CharacterAnimationState CurrentState { get; private set; } =
                CharacterAnimationState.Idle;
            public CharacterAnimationState BaseState { get; private set; } =
                CharacterAnimationState.Idle;
            public bool IsTerminated { get; private set; }

            public bool SetBaseState(CharacterAnimationState state)
            {
                BaseState = state;
                if (IsTerminated || !IsLoopingState(CurrentState))
                {
                    return false;
                }

                CurrentState = state;
                remainingDuration = 0f;
                return true;
            }

            public bool Play(CharacterAnimationState state, float duration)
            {
                if (!CanTransition(CurrentState, state))
                {
                    return false;
                }

                CurrentState = state;
                IsTerminated = IsTerminalState(state);
                remainingDuration = IsLoopingState(state)
                    ? 0f
                    : Mathf.Max(0f, duration);
                return true;
            }

            public bool Tick(float deltaTime, float playbackSpeed)
            {
                if (IsTerminated || IsLoopingState(CurrentState))
                {
                    return false;
                }

                remainingDuration -=
                    Mathf.Max(0f, deltaTime) * Mathf.Max(0f, playbackSpeed);
                if (remainingDuration > 0f)
                {
                    return false;
                }

                CurrentState = BaseState;
                remainingDuration = 0f;
                return true;
            }

            public void Reset()
            {
                BaseState = CharacterAnimationState.Idle;
                CurrentState = CharacterAnimationState.Idle;
                remainingDuration = 0f;
                IsTerminated = false;
            }
        }
    }
}
