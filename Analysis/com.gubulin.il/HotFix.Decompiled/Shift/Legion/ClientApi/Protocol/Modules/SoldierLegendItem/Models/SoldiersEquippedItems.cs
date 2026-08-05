using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.SoldierLegendItem.Models;

[ProtoContract]
public class SoldiersEquippedItems
{
	[ProtoMember(1)]
	[ProtoMap]
	public Dictionary<string, long[]> Value;
}
