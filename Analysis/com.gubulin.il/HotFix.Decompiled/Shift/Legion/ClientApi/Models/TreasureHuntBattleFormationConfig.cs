using System.Collections.Generic;
using ProtoBuf;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.Models;

[ProtoContract]
public class TreasureHuntBattleFormationConfig
{
	private List<List<string>> _UnitsData;

	[ProtoMember(1)]
	public List<string> FormationsId { get; set; } = new List<string>();

	[ProtoMember(2)]
	public string _jsonUnits { get; set; }

	public List<List<string>> Units
	{
		get
		{
			if (_UnitsData != null && _UnitsData.Count > 0)
			{
				return _UnitsData;
			}
			if (!string.IsNullOrEmpty(_jsonUnits))
			{
				_UnitsData = JsonHelper.ToObject<List<List<string>>>(_jsonUnits);
				return _UnitsData;
			}
			return null;
		}
		set
		{
		}
	}
}
