using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class FlagShipAttackEvent
{
	public bool WaitForJumpAnimation = false;

	[ProtoMember(1)]
	public int MissileOri { get; set; } = -1;

	[ProtoMember(2)]
	public int MissileDest { get; set; } = -1;

	[ProtoMember(3)]
	public long StartTimestamp_ms { get; set; } = -1L;

	[ProtoMember(4)]
	public long EndTimestamp_ms { get; set; } = -1L;

	[ProtoMember(5)]
	public int MissileType { get; set; }

	[ProtoMember(6)]
	public float MissileTime { get; set; }

	[ProtoMember(7)]
	public int Attack { get; set; }

	[ProtoMember(8)]
	public float AttackCD { get; set; }

	[ProtoMember(9)]
	public int CampId { get; set; }

	public void Reset()
	{
		StartTimestamp_ms = -1L;
		EndTimestamp_ms = -1L;
	}
}
