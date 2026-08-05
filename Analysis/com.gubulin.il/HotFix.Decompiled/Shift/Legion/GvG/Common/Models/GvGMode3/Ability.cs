using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol.Modules.LegendItem.Models;
using Shift.Legion.Common.Models;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

[ProtoContract]
public class Ability
{
	[ProtoIgnore]
	private ItemAbility _ability;

	[ProtoMember(1)]
	public string AbilityId { get; set; }

	[ProtoMember(2)]
	public bool IsPercent { get; set; }

	[ProtoMember(3)]
	public int N1 { get; set; }

	[ProtoMember(4)]
	public bool IsDebuff { get; set; }

	[ProtoIgnore]
	public ItemAbility ItemAbility => _ability ?? (_ability = ToItemAbility());

	public Ability Clone()
	{
		return new Ability
		{
			AbilityId = AbilityId,
			IsPercent = IsPercent,
			N1 = N1,
			IsDebuff = IsDebuff
		};
	}

	private ItemAbility ToItemAbility()
	{
		return new ItemAbility
		{
			AbilityId = AbilityId,
			Variables = new List<ItemEntryData>
			{
				new ItemEntryData("N1", N1 * 10000, IsPercent)
			}
		};
	}
}
