using System;

namespace Shift.Legion.Common.Enums;

[Flags]
public enum AttackFlags : uint
{
	None = 0u,
	Positive = 1u,
	Negative = 2u,
	Physic = 0x20u,
	Magic = 0x40u,
	Flame = 0x80u,
	Frost = 0x100u,
	Nature = 0x200u,
	Poison = 0x400u,
	Holy = 0x800u,
	Shadow = 0x1000u,
	Psyche = 0x2000u
}
