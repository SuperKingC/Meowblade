using System.Collections.Generic;
using Assets.Scripts.UI;
using Shift.Legion.Helpers;
using UnityEngine;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

public class CampProgressData
{
	public int CampProgress;

	public int CampStep;

	public bool HasSettlement;

	public int SettlementTimestamp;

	public string JsonPlayerBuffQueue;

	private List<List<string>> _playerBuffQueue;

	public List<List<string>> PlayerBuffQueue
	{
		get
		{
			if (_playerBuffQueue != null)
			{
				return _playerBuffQueue;
			}
			if (!string.IsNullOrEmpty(JsonPlayerBuffQueue))
			{
				_playerBuffQueue = new List<List<string>>();
				_playerBuffQueue.AddRange(JsonHelper.ToObject<List<List<string>>>(JsonPlayerBuffQueue));
			}
			return _playerBuffQueue;
		}
	}

	public string GetCountdown(int endTimestamp)
	{
		int num = (int)GameController.Instance.GetServerTime();
		int num2 = Mathf.Max(endTimestamp - num, 0);
		return (num2 > 86400) ? UiHelper.ParseTimeChinsesDH(num2) : UiHelper.ParseTimeChinses(num2);
	}
}
