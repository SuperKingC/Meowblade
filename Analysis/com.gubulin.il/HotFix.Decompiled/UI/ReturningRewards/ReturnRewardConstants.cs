using System.Runtime.InteropServices;

namespace UI.ReturningRewards;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ReturnRewardConstants
{
	public const int MAX_USE_POINT_NUM = 350;

	public const int MONEY_EXCHANGE_MULTIPLE = 1000;

	public const string MONEY_ID = "Money";

	public const int MAX_EXCHANGE_MONEY_NUM = 350000;
}
