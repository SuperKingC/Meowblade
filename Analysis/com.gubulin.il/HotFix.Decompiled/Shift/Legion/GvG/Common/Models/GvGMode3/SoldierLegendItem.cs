using ProtoBuf;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class SoldierLegendItem
{
	[ProtoMember(1)]
	public string SoldierId { get; set; }

	[ProtoMember(2)]
	public long[] Items { get; set; }
}
