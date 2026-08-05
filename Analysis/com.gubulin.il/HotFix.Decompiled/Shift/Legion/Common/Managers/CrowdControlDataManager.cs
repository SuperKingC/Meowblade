using System.Collections.Generic;
using GameDataEditor;
using Shift.Legion.Common.Helpers;

namespace Shift.Legion.Common.Managers;

public class CrowdControlDataManager : Singleton<CrowdControlDataManager>
{
	private Dictionary<string, GDECrowdControlData> _dataDict;

	public override void InitInstance()
	{
		_dataDict = new Dictionary<string, GDECrowdControlData>();
		LoadData();
	}

	private void LoadData()
	{
		IEnumerable<GDECrowdControlData> allItems = GDMgr.GetAllItems<GDECrowdControlData>();
		foreach (GDECrowdControlData item in allItems)
		{
			if (!_dataDict.ContainsKey(item.Key))
			{
				_dataDict[item.Key] = item;
			}
		}
	}

	public GDECrowdControlData GetData(string buffId)
	{
		return _dataDict.ContainsKey(buffId) ? _dataDict[buffId] : null;
	}
}
