namespace Shift.Legion.Common.Models;

public enum ActionResultCode
{
	Default = 0,
	DataNotFound = 10000000,
	StrongholdNotFound = 10000001,
	AlreadySelectedStrongholdSoldier = 10000002,
	WorkersNumError = 10000003,
	LevelUpFailed = 10000004,
	BuildingAcceptFailed = 10000005,
	FormationNotUnlocked = 10000006,
	WrongFormation = 10000007,
	UnitsIdError = 10000008,
	TeamNumExceed = 10000009,
	SoldierNotFound = 10000010,
	ItemUseError = 10000011,
	NotEnoughPieces = 10000012,
	PieceMixError = 10000013
}
