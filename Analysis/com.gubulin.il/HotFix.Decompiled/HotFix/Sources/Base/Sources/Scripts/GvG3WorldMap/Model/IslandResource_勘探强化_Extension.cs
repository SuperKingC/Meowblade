using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.Talent;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;

public static class IslandResource_勘探强化_Extension
{
	private static int _showTime = -1;

	public static int GetShowTime()
	{
		if (_showTime == -1)
		{
			_showTime = TalentEvent.GetConfig<勘探强化>().ResourceShowTime;
		}
		return _showTime;
	}

	public static bool IsExpired(this IslandResource_勘探强化 rc)
	{
		return (double)rc.EndTimestamp <= GameController.Instance.GetServerRealtimeSeconds();
	}

	public static float GetPassedCountdownPecent(this IslandResource_勘探强化 rc)
	{
		int showTime = GetShowTime();
		double num = GameController.Instance.GetServerRealtimeSeconds() - (double)(rc.EndTimestamp - showTime);
		return Mathf.Min((float)num / (float)showTime, 1f);
	}
}
