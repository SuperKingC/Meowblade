using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model;

namespace Shift.Legion.GvG.Common.Models.BattleLog;

public class ShipInfo
{
	public string ShipId { get; set; }

	public int CampId { get; set; }

	public int UserId { get; set; }

	public eGvGRole GvGRole { get; set; }

	public ShipInfo Clone()
	{
		return new ShipInfo
		{
			ShipId = ShipId,
			CampId = CampId,
			UserId = UserId,
			GvGRole = GvGRole
		};
	}
}
