using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Network.C2S;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Controller;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3WorldMap.Manager;

public class CrisisDetectManager
{
	public C2S_GetEarlyWarningInfo.Response EarlyWarningInfo;

	public Action<C2S_GetEarlyWarningInfo.Response> OnEarlyWarningInfoChange;

	private Dictionary<int, StackPool<GameObject>> _targetLinePool;

	private Dictionary<string, PreventionInfoView> _preventionInfos;

	private const int MaxRetryCount = 5;

	private int _retryCount;

	public void Init()
	{
		_retryCount = 0;
		InitPreventionRootView();
		GetPreventionInfoAsync();
		GetEarlyWarningInfoAsync();
		((MonoBehaviour)GvGWorldMapController.Instance).StartCoroutine(GetInfos());
		SharedMessenger.AddListener<int>("GVG3_TALENT_ACTIVATED", OnTalentsChange);
		SharedMessenger.AddListener("ON__GVG3_TALENTS_RESET", OnTalentReset);
	}

	public void OnRelease()
	{
		SharedMessenger.RemoveListener<int>("GVG3_TALENT_ACTIVATED", OnTalentsChange);
		SharedMessenger.RemoveListener("ON__GVG3_TALENTS_RESET", OnTalentReset);
	}

	private void InitPreventionRootView()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		GvGWorldMapController instance = GvGWorldMapController.Instance;
		GameObject go = new GameObject("PreventionRoot");
		go.transform.SetParent(((Component)instance).transform, false);
		go.transform.localScale = new Vector3(1f, 1.414f, 1f);
		_preventionInfos = new Dictionary<string, PreventionInfoView>();
		_targetLinePool = new Dictionary<int, StackPool<GameObject>>();
		for (int i = 1; i <= 4; i++)
		{
			string address = $"ShipTargetLineCamp{i}";
			StackPool<GameObject> value = new StackPool<GameObject>(10, (Func<GameObject>)delegate
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				GameObject val = Addressables.LoadAssetAsync<GameObject>((object)address).WaitForCompletion();
				return Object.Instantiate<GameObject>(val, go.transform);
			}, (Action<GameObject>)delegate(GameObject x)
			{
				x.SetActive(true);
			}, (Action<GameObject>)delegate(GameObject x)
			{
				x.SetActive(false);
			}, (Action<GameObject>)Object.Destroy, logWarning: false);
			_targetLinePool.Add(i, value);
		}
	}

	private void GetPreventionInfoAsync()
	{
		if (!Singleton<WorldStateManager>.Instance.Data.Talents.HasTalent(eTalent.预警防范) || _retryCount > 5)
		{
			return;
		}
		List<ShipStateModel> myShips = Singleton<WorldStateManager>.Instance.Data.MyShips;
		List<int> list = new List<int>();
		foreach (ShipStateModel item in myShips)
		{
			if (item.State.IsInWorld())
			{
				list.Add(item.EntityId);
			}
		}
		if (list.Count <= 0)
		{
			return;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetPreventionInfo
		{
			Req = new C2S_GetPreventionInfo.Request
			{
				ShipIds = new List<string>(),
				ShipEntityIds = list
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetPreventionInfo.Response response = (C2S_GetPreventionInfo.Response)context_response.Resp;
			if (response.ErrorCode != 0)
			{
				_retryCount++;
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				OnPreventionInfoChange(response);
			}
		});
	}

	public void GetEarlyWarningInfoAsync()
	{
		if (!Singleton<WorldStateManager>.Instance.Data.Talents.HasTalent(eTalent.危机感知) || _retryCount > 5)
		{
			return;
		}
		List<ShipStateModel> myShips = Singleton<WorldStateManager>.Instance.Data.MyShips;
		List<string> list = (from x in myShips
			where x.State.IsInWorld()
			select x.ShipId).ToList();
		if (list.Count <= 0)
		{
			return;
		}
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_GetEarlyWarningInfo
		{
			Req = new C2S_GetEarlyWarningInfo.Request
			{
				ShipIds = list
			}
		}, delegate(SocketManager.BaseSocketPackageBodyContext context_response)
		{
			C2S_GetEarlyWarningInfo.Response response = (C2S_GetEarlyWarningInfo.Response)context_response.Resp;
			if (response.ErrorCode < 0)
			{
				_retryCount++;
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				response.Unpack();
				EarlyWarningInfo = response;
				OnEarlyWarningInfoChange?.Invoke(response);
			}
		});
	}

	private void OnTalentsChange(int id)
	{
		switch (id)
		{
		case 427:
			GetPreventionInfoAsync();
			break;
		case 428:
			GetEarlyWarningInfoAsync();
			break;
		}
	}

	private void OnTalentReset()
	{
		C2S_GetPreventionInfo.Response emptyData = C2S_GetPreventionInfo.Response.EmptyData;
		OnPreventionInfoChange(emptyData);
		C2S_GetEarlyWarningInfo.Response emptyData2 = C2S_GetEarlyWarningInfo.Response.EmptyData;
		OnEarlyWarningInfoChange?.Invoke(emptyData2);
	}

	private IEnumerator GetInfos()
	{
		WaitForSeconds wait = new WaitForSeconds(30f);
		while (true)
		{
			yield return wait;
			GetPreventionInfoAsync();
			GetEarlyWarningInfoAsync();
		}
	}

	private void OnPreventionInfoChange(C2S_GetPreventionInfo.Response res)
	{
		if (res == null)
		{
			return;
		}
		List<C2S_GetPreventionInfo.EnemyShipData> enemyShipData = res.EnemyShipData;
		if (enemyShipData == null)
		{
			return;
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, PreventionInfoView> preventionInfo in _preventionInfos)
		{
			string shipId = preventionInfo.Key;
			if (enemyShipData.FindIndex((C2S_GetPreventionInfo.EnemyShipData x) => x.ShipId == shipId) < 0)
			{
				list.Add(shipId);
			}
		}
		foreach (string item in list)
		{
			PreventionInfoView preventionInfoView = _preventionInfos[item];
			preventionInfoView.Destroy();
			_preventionInfos.Remove(item);
		}
		foreach (C2S_GetPreventionInfo.EnemyShipData item2 in enemyShipData)
		{
			if (!_preventionInfos.ContainsKey(item2.ShipId))
			{
				StackPool<GameObject> pool = _targetLinePool[item2.CampId];
				PreventionInfoView preventionInfoView2 = new PreventionInfoView();
				preventionInfoView2.InitPreventionInfo(pool, item2);
				_preventionInfos[item2.ShipId] = preventionInfoView2;
			}
			else
			{
				PreventionInfoView preventionInfoView3 = _preventionInfos[item2.ShipId];
				preventionInfoView3.Data = item2;
			}
		}
	}
}
