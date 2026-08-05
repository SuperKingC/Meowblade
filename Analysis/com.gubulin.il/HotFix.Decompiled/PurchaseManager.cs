using HotFix;

public class PurchaseManager
{
	private static PurchaseBehavior _instance;

	public static PurchaseBehavior Instance
	{
		get
		{
			if (_instance == null)
			{
				if (HotUpdateProcess.Instance.IsRegionOutCN)
				{
					_instance = PurchaseBehavior_Intl.Instance;
				}
				else
				{
					_instance = PurchaseBehavior.Instance;
				}
			}
			return _instance;
		}
	}
}
