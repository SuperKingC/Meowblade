using System.Collections.Generic;
using ProtoBuf;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class RankBattleFormationUnitsConfig
{
	[ProtoMember(1)]
	public List<string> FormationsId { get; set; } = new List<string>();

	[ProtoMember(2)]
	public List<List<string>> UnitsId { get; set; } = new List<List<string>>();
}
