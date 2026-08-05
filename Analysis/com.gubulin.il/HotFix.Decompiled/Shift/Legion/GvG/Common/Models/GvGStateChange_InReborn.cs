using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models;

[ProtoContract]
public class GvGStateChange_InReborn
{
	[ProtoMember(2)]
	public float X = -1f;

	[ProtoMember(3)]
	public float Y = -1f;

	[ProtoMember(4)]
	public int CurRebornCount = 0;

	[ProtoMember(5)]
	public int MaxRebornCount = 0;

	[ProtoMember(6)]
	public long RebornFrame;

	[ProtoMember(7)]
	public long DeadFrame;
}
