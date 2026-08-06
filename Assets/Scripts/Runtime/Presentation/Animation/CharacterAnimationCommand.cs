namespace Meowblade
{
    public enum CharacterAnimationState
    {
        Idle = 0,
        Move = 1,
        Attack = 2,
        Skill = 3,
        Hit = 4,
        Retreat = 5,
        Victory = 6,
        Down = 7,
        Selected = 8
    }

    public enum CharacterAnimationPriority
    {
        Base = 0,
        Reaction = 100,
        Action = 200,
        Terminal = 300
    }

    public enum CharacterEffectKind
    {
        None = 0,
        Attack = 1,
        Skill = 2,
        Hit = 3,
        Retreat = 4,
        Victory = 5,
        Command = 6
    }

    public readonly struct CharacterAnimationCommand
    {
        public CharacterAnimationCommand(
            CharacterAnimationState state,
            int sourceUnitId,
            int targetUnitId = -1,
            CharacterEffectKind effectKind = CharacterEffectKind.None,
            float? value = null)
        {
            State = state;
            SourceUnitId = sourceUnitId;
            TargetUnitId = targetUnitId;
            EffectKind = effectKind;
            Value = value;
        }

        public CharacterAnimationState State { get; }

        public int SourceUnitId { get; }

        public int TargetUnitId { get; }

        public CharacterEffectKind EffectKind { get; }

        public float? Value { get; }

        public CharacterAnimationPriority Priority
        {
            get
            {
                switch (State)
                {
                    case CharacterAnimationState.Down:
                    case CharacterAnimationState.Retreat:
                    case CharacterAnimationState.Victory:
                        return CharacterAnimationPriority.Terminal;
                    case CharacterAnimationState.Attack:
                    case CharacterAnimationState.Skill:
                    case CharacterAnimationState.Selected:
                        return CharacterAnimationPriority.Action;
                    case CharacterAnimationState.Hit:
                        return CharacterAnimationPriority.Reaction;
                    default:
                        return CharacterAnimationPriority.Base;
                }
            }
        }
    }
}
