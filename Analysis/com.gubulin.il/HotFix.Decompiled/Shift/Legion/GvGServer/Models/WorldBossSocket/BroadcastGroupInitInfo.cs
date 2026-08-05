using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class BroadcastGroupInitInfo
{
	[ProtoMember(1)]
	public int EntityId;

	[ProtoMember(2)]
	public int UserId;

	[ProtoMember(3)]
	public int GvGRole;

	[ProtoMember(4)]
	public bool IsBoss;

	[ProtoMember(5)]
	public string FormationId;

	[ProtoMember(7)]
	public bool IsDead;

	[ProtoMember(8)]
	public int DefenderZoneId;

	[ProtoMember(10, TypeName = "Shift.Legion.GvGServer.Models.WorldBossSocket.UnitInfo_Protocol")]
	public List<UnitInfo_Protocol> UnitsInfo;

	[ProtoMember(11)]
	public float BornX;

	[ProtoMember(12)]
	public float BornY;

	[ProtoMember(13)]
	public float GroupSpeed;

	[ProtoMember(14)]
	public long CreatedTimestamp;

	[ProtoMember(15)]
	public string GroupIcon;

	[ProtoMember(16)]
	public float GroupIconSize;

	[ProtoMember(17)]
	public float FightingX;

	[ProtoMember(18)]
	public float FightingY;
}
