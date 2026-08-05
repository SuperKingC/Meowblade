using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Interface.Brawl;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Helper;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models.GvGMode3.BrawlEvent;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.BrawlUi;

public class BrawlSettleIslandUiInfo : IBrawlIslandUiInfo
{
	public string BrawlModeIcon { get; }

	public string IslandName { get; }

	public string MConfigId { get; private set; }

	public int IslandId { get; private set; }

	public int MUID { get; private set; }

	public int IslandSubType { get; private set; }

	public bool IsFinal { get; }

	public BrawlSettleIslandUiInfo(BrawlEventSettleInfo info, bool isFinal)
	{
		string text = ((eGvGMode3CampMissionSubType)info.IslandSubType/*cast due to .constrained prefix*/).ToString();
		BrawlModeIcon = "ui://GvGBrawlFight/" + text;
		IslandName = WorldMapConfigHelper.GetCurIZIslandName(info.IslandId);
		MConfigId = info.MConfigId;
		IslandId = info.IslandId;
		MUID = info.MUId;
		IslandSubType = info.IslandSubType;
		IsFinal = isFinal;
	}
}
