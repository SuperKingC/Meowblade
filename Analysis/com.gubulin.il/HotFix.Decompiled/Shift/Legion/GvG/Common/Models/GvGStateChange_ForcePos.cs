using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models;

[ProtoContract]
public class GvGStateChange_ForcePos
{
	[ProtoMember(1)]
	public float X = -1f;

	[ProtoMember(2)]
	public float Y = -1f;

	[ProtoMember(3)]
	public bool hasForcePosition = false;
}
