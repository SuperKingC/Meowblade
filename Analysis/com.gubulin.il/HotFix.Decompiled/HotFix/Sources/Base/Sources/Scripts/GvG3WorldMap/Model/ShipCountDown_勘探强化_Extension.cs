using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

public static class ShipCountDown_勘探强化_Extension
{
	public static bool IsExpired(this ShipCountDown_勘探强化 cd)
	{
		return (double)cd.EndTimestamp <= GameController.Instance.GetServerRealtimeSeconds();
	}

	public static float GetRemainingCountdownPecent(this ShipCountDown_勘探强化 cd)
	{
		double num = GameController.Instance.GetServerRealtimeSeconds() - (double)cd.StartTimestamp;
		int num2 = cd.EndTimestamp - cd.StartTimestamp;
		float num3 = Mathf.Min((float)num / (float)num2, 1f);
		return 1f - num3;
	}
}
