using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class UnitInfo_Protocol
{
	[ProtoMember(1)]
	public string SoldierId;

	[ProtoMember(4)]
	public bool IsBossUnit;

	[ProtoMember(5)]
	public float BossSize;

	[ProtoMember(6)]
	public int PotentialLevel;

	[ProtoMember(7)]
	public int PerTeamMemberCnt;

	[ProtoMember(8)]
	public int Total;

	[ProtoMember(9)]
	public int PosId;

	public string AnimMapPrefix;
}
