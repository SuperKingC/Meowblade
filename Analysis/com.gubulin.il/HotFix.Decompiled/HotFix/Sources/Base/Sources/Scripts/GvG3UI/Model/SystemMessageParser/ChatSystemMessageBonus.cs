using System.Collections.Generic;
using Shift.Legion.GvG.Common.Models;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model.SystemMessageParser;

public class ChatSystemMessageBonus
{
	public bool IsSplitBonuses = true;

	public List<RItem> Bonuses { get; set; }

	public List<int> TalentSrcList { get; set; }
}
