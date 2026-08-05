using System.Collections.Generic;
using System.Linq;
using ILRuntime_LitJson;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class ProgressSettlementConfig
{
	[JsonIgnore]
	public const string BonusConfigKey = "GvGMode3ProgressSettlementBonus";

	[JsonIgnore]
	public const string GvGProgressSettlementTitleKey = "GvGProgressSettlementTitle";

	[JsonIgnore]
	public const string GvGProgressRewardPreviewTitleKey = "GvGProgressRewardPreviewTitle";

	public List<ProgressSettlementBonus> Camp = new List<ProgressSettlementBonus>();

	public List<ProgressSettlementBonus> FlagShip = new List<ProgressSettlementBonus>();

	public void Init(int progress)
	{
		Camp = Camp.Where((ProgressSettlementBonus m) => m.Visible(progress)).ToList();
		FlagShip = FlagShip.Where((ProgressSettlementBonus m) => m.Visible(progress)).ToList();
		foreach (ProgressSettlementBonus item in Camp)
		{
			item.DescText(progress);
		}
		foreach (ProgressSettlementBonus item2 in FlagShip)
		{
			item2.DescText(progress);
		}
	}
}
