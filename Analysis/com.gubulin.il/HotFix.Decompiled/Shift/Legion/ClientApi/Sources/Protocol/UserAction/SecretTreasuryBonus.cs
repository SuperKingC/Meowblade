using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.GvG.Common.Models;

namespace Shift.Legion.ClientApi.Sources.Protocol.UserAction;

[ProtoContract]
public class SecretTreasuryBonus
{
	[ProtoMember(1)]
	public int Id { get; set; }

	[ProtoMember(2)]
	public int Level { get; set; }

	[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> Bonus { get; set; }

	[ProtoMember(5)]
	public bool Claimed { get; set; }
}
