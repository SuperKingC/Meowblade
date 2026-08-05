using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class WarOfRealmConfig
{
	public List<List<SoldierWithLegendItemId>> _Units;

	[ProtoMember(1)]
	public List<string> FormationsId { get; set; } = new List<string>();

	[ProtoMember(2)]
	public string _jsonUnits { get; set; }

	public List<List<SoldierWithLegendItemId>> Units
	{
		get
		{
			if (_Units != null && _Units.Count > 0)
			{
				return _Units;
			}
			if (!string.IsNullOrEmpty(_jsonUnits))
			{
				_Units = JsonHelper.ToObject<List<List<SoldierWithLegendItemId>>>(_jsonUnits);
				return _Units;
			}
			return null;
		}
	}
}
