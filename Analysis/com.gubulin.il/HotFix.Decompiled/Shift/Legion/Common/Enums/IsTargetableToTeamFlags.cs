using System;

namespace Shift.Legion.Common.Enums;

[Flags]
public enum IsTargetableToTeamFlags : uint
{
	NON_TARGETABLE_ALLY = 0x800000u,
	NON_TARGETABLE_ENEMY = 0x1000000u,
	TARGETABLE_TO_ALL = 0x2000000u
}
