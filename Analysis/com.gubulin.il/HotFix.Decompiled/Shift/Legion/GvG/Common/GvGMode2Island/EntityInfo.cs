using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvGServer.Models.WorldBossSocket;

namespace Shift.Legion.GvG.Common.GvGMode2Island;

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

	[ProtoMember(10, TypeName = "Shift.Legion.GvGServer.Models.WorldBossSocket.UnitInfo_Protocol")]
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
}
