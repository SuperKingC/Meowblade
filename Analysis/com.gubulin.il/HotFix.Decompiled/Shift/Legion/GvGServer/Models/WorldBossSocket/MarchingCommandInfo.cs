using ProtoBuf;

namespace Shift.Legion.GvGServer.Models.WorldBossSocket;

[ProtoContract]
public class MarchingCommandInfo
{
	[ProtoMember(1)]
	public long Frame;

	[ProtoMember(2)]
	public float Speed;

	[ProtoMember(3)]
	public float StartPosX;

	[ProtoMember(4)]
	public float StartPosY;

	[ProtoMember(5)]
	public float EndX;

	[ProtoMember(6)]
	public float EndY;

	[ProtoMember(7)]
	public int TargetId;

	[ProtoMember(8)]
	public float NoR_EndX;

	[ProtoMember(9)]
	public float NoR_EndY;
}
