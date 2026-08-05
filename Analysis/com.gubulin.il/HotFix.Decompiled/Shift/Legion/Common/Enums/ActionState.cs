using System;

namespace Shift.Legion.Common.Enums;

[Flags]
public enum ActionState : uint
{
	CAN_ATTACK = 1u,
	CAN_CAST = 2u,
	CAN_MOVE = 4u,
	CAN_NOT_MOVE = 8u,
	STEALTHED = 0x10u,
	REVEAL_SPECIFIC_UNIT = 0x20u,
	TAUNTED = 0x40u,
	FEARED = 0x80u,
	IS_FLEEING = 0x100u,
	CAN_NOT_ATTACK = 0x200u,
	IS_ASLEEP = 0x400u,
	IS_NEAR_SIGHTED = 0x800u,
	IS_GHOSTED = 0x1000u,
	CHARMED = 0x8000u,
	NO_RENDER = 0x10000u,
	FORCE_RENDER_PARTICLES = 0x20000u,
	UNKNOWN = 0x800000u
}
