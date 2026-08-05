using System;
using System.Collections.Generic;
using ILRuntime_LitJson;

namespace Shift.Legion.ClientApi.Sources.Protocol.UserAction;

public class TreasureHouseRechargeInfo
{
	public float TotalRecharge;

	public List<float> HasClaimed;

	public DateTimeOffset EndTime;

	[JsonIgnore]
	private List<int> _hasClaimed_List_Int;

	public List<int> HasClaimed_List_Int
	{
		get
		{
			if (_hasClaimed_List_Int == null)
			{
				_hasClaimed_List_Int = new List<int>();
				foreach (float item in HasClaimed)
				{
					_hasClaimed_List_Int.Add((int)item);
				}
			}
			return _hasClaimed_List_Int;
		}
	}
}
