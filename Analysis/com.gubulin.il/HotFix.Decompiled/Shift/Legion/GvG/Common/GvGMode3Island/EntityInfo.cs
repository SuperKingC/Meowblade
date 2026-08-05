using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using ProtoBuf;

namespace Shift.Legion.GvG.Common.GvGMode3Island;

[ProtoContract]
public class EntityInfo
{
	[ProtoMember(1)]
	public int EntityId;

	[ProtoMember(2)]
	public int UserId;

	[ProtoMember(3)]
	public int CampId;

	[ProtoMember(4)]
	public string FormationId;

	[ProtoMember(5)]
	public float GroupSpeed;

	[ProtoMember(6)]
	public int BattleStrategy;

	[ProtoMember(7)]
	public int GvGMode2State;

	[ProtoMember(8)]
	public bool IsDead;

	[ProtoMember(9)]
	public int RoleFace;

	[ProtoMember(10, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.UnitInfo_Protocol")]
	public List<UnitInfo_Protocol> UnitsInfo;

	[ProtoMember(11)]
	public float X;

	[ProtoMember(12)]
	public float Y;

	[ProtoMember(16)]
	public float GroupIconSize;

	[ProtoMember(17)]
	public float debug_MatrixWidth;

	[ProtoMember(18)]
	public string GvGMode2StateJson;

	[ProtoMember(19)]
	public int GvGMode3State;

	[ProtoMember(20)]
	public byte[] GvGMode3StateData;

	[ProtoMember(31)]
	public long BossDamage;

	[ProtoMember(32)]
	public long KillSoldiersCount;

	[ProtoMember(41)]
	public int ShipRace;

	[ProtoMember(42)]
	public int ShipSkinId;

	[ProtoMember(43)]
	public string ShipId;

	[ProtoMember(44)]
	public int CanRetreatTimestamp;

	[ProtoMember(45)]
	public string Icon;

	[ProtoMember(50)]
	public int HoldingScorePerSecond;

	[ProtoMember(51)]
	public int GvGRole;

	[ProtoMember(52)]
	public bool IsInsuranceShip;
}
