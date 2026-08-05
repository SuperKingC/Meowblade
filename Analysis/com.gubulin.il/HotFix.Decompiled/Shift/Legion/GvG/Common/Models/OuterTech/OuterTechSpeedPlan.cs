using Shift.Legion.ClientApi.Protocol.UserAction;

namespace Shift.Legion.GvG.Common.Models.OuterTech;

public class OuterTechSpeedPlan
{
	public int TotalCount { get; set; }

	public int ClaimedCount { get; set; }

	public bool Claimed { get; set; }

	public int CouldClaimCount { get; set; }

	public int NextClaimCount { get; set; }

	public int GiftPurchaseLimit { get; set; }

	public int TotalGvGCount { get; set; }

	public void SyncData(GetOuterTechSpeedPlanResponse data)
	{
		TotalCount = data.TotalCount;
		ClaimedCount = data.ClaimedCount;
		CouldClaimCount = data.CouldClaimCount;
		NextClaimCount = data.NextClaimCount;
		GiftPurchaseLimit = data.GiftPurchaseLimit;
		TotalGvGCount = data.TotalGvGCount;
		Claimed = data.Claimed;
	}
}
