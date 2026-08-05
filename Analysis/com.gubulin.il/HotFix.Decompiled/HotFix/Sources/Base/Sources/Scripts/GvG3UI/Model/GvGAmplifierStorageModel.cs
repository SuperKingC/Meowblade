using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvGAmplifierStorageModel
{
	public Dictionary<int, int> AmplifierStorage;

	public List<AmplifierModel> StorageAmpsConfig_List;

	public void UseMockData()
	{
		AmplifierStorage = new Dictionary<int, int>();
		for (int i = 1; i < 19; i++)
		{
			AmplifierStorage.Add(i, Random.Range(0, 30));
		}
		StorageAmpsConfig_List = new List<AmplifierModel>();
		foreach (KeyValuePair<int, int> item in AmplifierStorage)
		{
			if (item.Value != 0)
			{
				StorageAmpsConfig_List.Add(AmpConfigHelper.Configs.TryGetNormalAmplifier(item.Key));
			}
		}
	}

	public void GetData(Action onFinished)
	{
		Singleton<GvGAmplifierManager>.Instance.GetAmplifierStorage(delegate(GvGAmplifierManager.AmplifierStorageData data)
		{
			AmplifierStorage = data.AmplifierStorage;
			StorageAmpsConfig_List = new List<AmplifierModel>();
			foreach (KeyValuePair<int, int> item in AmplifierStorage)
			{
				if (item.Value != 0)
				{
					StorageAmpsConfig_List.Add(AmpConfigHelper.Configs.TryGetNormalAmplifier(item.Key));
				}
			}
			onFinished?.Invoke();
		});
	}
}
