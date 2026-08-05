using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class BroadcastGroupUpdateInfo
{
	[ProtoMember(1)]
	public int EntityId;

	[ProtoMember(4)]
	public bool IsFighting;

	[ProtoMember(5)]
	public bool IsDead;

	[ProtoMember(6)]
	public int RoleFace;

	[ProtoMember(8)]
	public int TargetId = -1;

	[ProtoMember(9)]
	public bool HasMarchingCommand;

	[ProtoMember(10)]
	public bool HasFightingCommand;

	[ProtoMember(11)]
	public float GroupIconSize;
}
