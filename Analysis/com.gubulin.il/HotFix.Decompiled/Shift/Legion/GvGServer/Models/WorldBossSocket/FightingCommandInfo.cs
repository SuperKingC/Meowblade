using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class FightingCommandInfo
{
	[ProtoMember(1)]
	public int ZoneId;

	[ProtoMember(2)]
	public float R_X;

	[ProtoMember(3)]
	public float R_Y;

	[ProtoMember(4)]
	public float NoR_X;

	[ProtoMember(5)]
	public float NoR_Y;

	[ProtoMember(6)]
	public long Frame;
}
