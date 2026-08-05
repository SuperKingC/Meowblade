using ProtoBuf;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class ModelsBonus
{
	[ProtoMember(1)]
	public string ItemId;

	[ProtoMember(2)]
	public int Qty;

	[ProtoMember(3)]
	public int Type;

	[ProtoMember(4)]
	public int Category;

	[ProtoMember(5)]
	public bool IsCard3;

	[ProtoMember(6)]
	public int IsShining;

	[ProtoMember(7)]
	public byte[] ExtraData;

	public StockInContext StockInReason;
}
