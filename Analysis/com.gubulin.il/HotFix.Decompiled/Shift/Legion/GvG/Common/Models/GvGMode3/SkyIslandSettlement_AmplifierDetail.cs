using System.Collections.Generic;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public class SkyIslandSettlement_AmplifierDetail
{
	public Dictionary<string, int> AllCount = new Dictionary<string, int>();

	public int Score = 0;

	public Dictionary<string, int> Reward = new Dictionary<string, int>();

	public Dictionary<int, int> _allCount;

	public Dictionary<int, int> allCount
	{
		get
		{
			if (_allCount == null)
			{
				_allCount = new Dictionary<int, int>();
				foreach (KeyValuePair<string, int> item in AllCount)
				{
					_allCount.Add(int.Parse(item.Key), item.Value);
				}
			}
			return _allCount;
		}
	}
}
