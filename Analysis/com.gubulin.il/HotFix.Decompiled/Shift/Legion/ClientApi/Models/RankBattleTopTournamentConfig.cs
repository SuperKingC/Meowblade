using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class RankBattleTopTournamentConfig
{
	public List<List<SoldierWithLegendItemId>> _UnitsData;

	[ProtoMember(1)]
	public List<string> FormationsId { get; set; } = new List<string>();

	[ProtoMember(2)]
	public string _Units { get; set; }

	public List<List<SoldierWithLegendItemId>> Units
	{
		get
		{
			if (_UnitsData != null && _UnitsData.Count > 0)
			{
				return _UnitsData;
			}
			if (!string.IsNullOrEmpty(_Units))
			{
				_UnitsData = JsonHelper.ToObject<List<List<SoldierWithLegendItemId>>>(_Units);
				return _UnitsData;
			}
			return null;
		}
		set
		{
		}
	}
}
