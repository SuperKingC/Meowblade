using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.Inventory.Models;

[ProtoContract]
public class InventoryItem
{
	[ProtoMember(1)]
	public long InstanceId { get; set; }

	[ProtoMember(2)]
	public int UserId { get; set; }

	[ProtoMember(3)]
	public string ItemId { get; set; }

	[ProtoMember(4)]
	public long Qty { get; set; }

	[ProtoMember(5)]
	public int Score { get; set; }

	[ProtoMember(6)]
	public float CombatPowerModifier { get; set; }

	[ProtoMember(30)]
	public string Data { get; set; }
}
