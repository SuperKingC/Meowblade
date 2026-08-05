using System.Collections.Generic;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Models;

public class MissionConfig
{
	public string MissionId;

	public MissionStatus Status = MissionStatus.Pending;

	public Dictionary<string, object> Progress = new Dictionary<string, object>();

	public object Clone()
	{
		MissionConfig missionConfig = new MissionConfig
		{
			MissionId = MissionId,
			Status = Status,
			Progress = new Dictionary<string, object>()
		};
		foreach (KeyValuePair<string, object> item in Progress)
		{
			missionConfig.Progress.Add(item.Key, item.Value);
		}
		return missionConfig;
	}
}
