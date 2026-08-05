using HotFix;

namespace Shift.Legion.Common.Managers;

public static class ArchiveExtension_Recharge
{
	private const string TotalRechargeKey = "TOTAL_RECHARGE";

	private const string TotalRechargeUSDKey = "TOTAL_RECHARGE_USD";

	private const string RechargeOrderCntKey = "RECHARGE_ORDER_CNT";

	public static float GetTotalRecharge(this UserArchiveManager manager)
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return manager.GetConfigValue<float>("TOTAL_RECHARGE_USD");
		}
		return manager.GetConfigValue<float>("TOTAL_RECHARGE");
	}

	public static void IncrTotalRecharge(this UserArchiveManager manager, float recharge)
	{
		float totalRecharge = manager.GetTotalRecharge();
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			manager.SetConfigValue("TOTAL_RECHARGE_USD", totalRecharge + recharge);
		}
		else
		{
			manager.SetConfigValue("TOTAL_RECHARGE", totalRecharge + recharge);
		}
	}

	public static bool IsRechargeFirstTime(this UserArchiveManager manager)
	{
		float totalRecharge = manager.GetTotalRecharge();
		if (totalRecharge <= float.Epsilon && totalRecharge >= -1E-45f)
		{
			return true;
		}
		return false;
	}

	public static void SetTotalRecharge(this UserArchiveManager manager, float rechargeTotal)
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			manager.SetConfigValue("TOTAL_RECHARGE_USD", rechargeTotal);
		}
		else
		{
			manager.SetConfigValue("TOTAL_RECHARGE", rechargeTotal);
		}
	}

	public static int GetRechargeOrderCnt(this UserArchiveManager manager)
	{
		return manager.GetConfigValue<int>("RECHARGE_ORDER_CNT");
	}

	public static void IncrRechargeOrderCnt(this UserArchiveManager manager, int orderCnt = 1)
	{
		int rechargeOrderCnt = manager.GetRechargeOrderCnt();
		manager.SetConfigValue("RECHARGE_ORDER_CNT", rechargeOrderCnt + orderCnt);
	}
}
