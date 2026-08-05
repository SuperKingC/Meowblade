using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models;

[ProtoContract]
public class EOI_ShipInfoOnIsland
{
	[ProtoMember(1)]
	public int UserId;

	[ProtoMember(2)]
	public int CampId;

	[ProtoMember(3)]
	public int EntityId;

	[ProtoMember(4)]
	public float AvatarScale = 1f;

	public int SlotIndex = -1;
}
