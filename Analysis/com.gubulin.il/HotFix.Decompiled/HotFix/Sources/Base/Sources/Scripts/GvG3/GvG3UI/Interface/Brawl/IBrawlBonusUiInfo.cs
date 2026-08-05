using System.Collections.Generic;
using FairyGUI;
using Shift.Legion.GvG.Common.Models;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;

public interface IBrawlBonusUiInfo
{
	bool IsFinal { get; }

	List<RItem> Bonuses { get; }

	bool HasBuff { get; }

	void DisplayBuffInfo(EventContext context);
}
