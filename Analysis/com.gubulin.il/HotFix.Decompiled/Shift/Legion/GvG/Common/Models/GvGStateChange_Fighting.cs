using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models;

[ProtoContract]
public class GvGStateChange_Fighting
{
	[ProtoMember(1)]
	public float X = -1f;

	[ProtoMember(2)]
	public float Y = -1f;

	[ProtoMember(3)]
	public int AttackTarget = -1;

	[ProtoMember(4)]
	public bool hasGvGChargeCommand = false;
}
