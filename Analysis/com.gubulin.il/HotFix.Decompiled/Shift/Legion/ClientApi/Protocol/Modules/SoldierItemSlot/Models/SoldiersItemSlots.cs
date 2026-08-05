using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Protocol.Modules.SoldierItemSlot.Models;

[ProtoContract]
public class SoldiersItemSlots
{
	[ProtoMember(1)]
	[ProtoMap]
	public Dictionary<string, int[]> Value;
}
