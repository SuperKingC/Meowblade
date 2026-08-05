using System;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;

public class CloudsManager
{
	private Transform CloudsTrans;

	private Transform Stage1Trans;

	private Transform Stage2Trans;

	public CloudsManager(GameObject _GvGWorldMap)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		string iZConfigId = Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.IZConfigId;
		string text = "GvG/Clouds_" + iZConfigId;
		CloudsTrans = Addressables.InstantiateAsync((object)text, (Transform)null, false, true).WaitForCompletion().transform;
		CloudsTrans.SetParent(_GvGWorldMap.transform, false);
		CloudsTrans.localPosition = Vector3.zero;
		((Object)CloudsTrans).name = "Clouds";
		Stage1Trans = CloudsTrans.Find("Stage_1");
		Stage2Trans = CloudsTrans.Find("Stage_2");
		UpdateCloudState();
		WorldStateManager instance = Singleton<WorldStateManager>.Instance;
		instance.OnCampProgressChange = (Action)Delegate.Combine(instance.OnCampProgressChange, new Action(UpdateCloudState));
	}

	private void UpdateCloudState()
	{
		CampProgressData progressData = Singleton<WorldStateManager>.Instance.Data.ProgressData;
		bool flag = progressData.CampProgress == 6;
		((Component)Stage1Trans).gameObject.SetActive(!flag);
		((Component)Stage2Trans).gameObject.SetActive(!flag || progressData.CampStep <= 1);
	}

	public void OnDestroy()
	{
		WorldStateManager instance = Singleton<WorldStateManager>.Instance;
		instance.OnCampProgressChange = (Action)Delegate.Remove(instance.OnCampProgressChange, new Action(UpdateCloudState));
	}
}
