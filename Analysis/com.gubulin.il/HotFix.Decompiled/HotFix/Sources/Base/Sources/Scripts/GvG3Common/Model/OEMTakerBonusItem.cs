using Shift.Legion.GvG.Common.Models;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

public class OEMTakerBonusItem
{
	public RItem Item { get; set; }

	public eOEMTakeBonusType Type { get; set; }

	public bool Obtained { get; set; }
}
