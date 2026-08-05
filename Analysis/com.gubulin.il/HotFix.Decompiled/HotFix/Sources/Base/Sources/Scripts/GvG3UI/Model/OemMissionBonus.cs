using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class OemMissionBonus
{
	public Dictionary<string, float> OEMBounusMagnification;

	public Dictionary<string, int> OEMBaseBonus { get; set; }

	public Dictionary<string, int> OEMExtraBonus { get; set; }

	public Dictionary<string, int> OEMCriticalBonus { get; set; }

	public Dictionary<string, int> OEMTitanBonus { get; set; }

	public KeyValuePair<string, int> GetBaseBonus()
	{
		KeyValuePair<string, int> keyValuePair = OEMBaseBonus.First();
		int value = (int)((float)keyValuePair.Value * GetMagnification());
		return new KeyValuePair<string, int>(keyValuePair.Key, value);
	}

	public KeyValuePair<string, int> GetExtraBonus()
	{
		KeyValuePair<string, int> keyValuePair = OEMExtraBonus.First();
		int value = (int)((float)keyValuePair.Value * GetMagnification());
		return new KeyValuePair<string, int>(keyValuePair.Key, value);
	}

	public KeyValuePair<string, int> GetCriticalBonus()
	{
		KeyValuePair<string, int> keyValuePair = OEMCriticalBonus.First();
		int value = (int)((float)keyValuePair.Value * GetMagnification());
		return new KeyValuePair<string, int>(keyValuePair.Key, value);
	}

	public KeyValuePair<string, int> GetTitanBonus()
	{
		KeyValuePair<string, int> keyValuePair = OEMTitanBonus.First();
		int value = (int)((float)keyValuePair.Value * GetMagnification());
		return new KeyValuePair<string, int>(keyValuePair.Key, value);
	}

	private float GetMagnification()
	{
		string iZConfigId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId;
		if (OEMBounusMagnification.ContainsKey(iZConfigId))
		{
			return OEMBounusMagnification[iZConfigId];
		}
		return 1f;
	}
}
