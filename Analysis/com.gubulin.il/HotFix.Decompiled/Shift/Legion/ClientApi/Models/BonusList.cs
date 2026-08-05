using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class BonusList
{
	[ProtoMember(1, TypeName = "Shift.Legion.ClientApi.Models.ModelsBonus")]
	public List<ModelsBonus> Value;
}
