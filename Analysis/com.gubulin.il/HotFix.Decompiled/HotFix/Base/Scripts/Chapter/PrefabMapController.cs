using System.Collections.Generic;
using System.Runtime.InteropServices;
using Shift.Legion.Common.Helpers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace HotFix.Base.Scripts.Chapter;

public class PrefabMapController : MonoBehaviour, IMapBackgroundController
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct CampConstants
	{
		public const string CAMP = "camp";

		public const string ENEMY_CAMP = "enemyCamp";
	}

	public struct MapCampConfig
	{
		public string LeftCamp;

		public string RightCamp;
	}

	private GameObject _child;

	private string _identifier;

	private AsyncOperationHandle<GameObject> _mapHandle;

	private AsyncOperationHandle<GameObject> _leftCampHandle;

	private AsyncOperationHandle<GameObject> _rightCampHandle;

	private Transform _mainCameraTrans;

	private Transform _farTrans;

	private Transform _closeTrans;

	public static Dictionary<string, MapCampConfig> MapCampConfigs = new Dictionary<string, MapCampConfig>
	{
		{
			"prologue_01",
			new MapCampConfig
			{
				LeftCamp = "Camp_Prologue_01",
				RightCamp = "EnemyCamp_Prologue_01"
			}
		},
		{
			"prologue_02",
			new MapCampConfig
			{
				LeftCamp = "Camp_Prologue_02",
				RightCamp = "EnemyCamp_Prologue_02"
			}
		},
		{
			"prologue_03",
			new MapCampConfig
			{
				LeftCamp = "Camp_Prologue_03",
				RightCamp = "EnemyCamp_Prologue_03"
			}
		},
		{
			"prologue_live001",
			default(MapCampConfig)
		}
	};

	public string Identifier => _identifier;

	public Transform Map => _child.transform;

	public void SetMapIdentifier(string id)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		_identifier = id;
		_mapHandle = Addressables.LoadAssetAsync<GameObject>((object)id);
		_mapHandle.WaitForCompletion();
		_child = Object.Instantiate<GameObject>(_mapHandle.Result, ((Component)this).transform);
		Transform transform = _child.transform;
		_farTrans = transform.Find("far");
		_closeTrans = transform.Find("close");
		_mainCameraTrans = ((Component)Singleton<CameraService>.Instance.MainCamera).transform;
		LoadCamp();
	}

	public void ClearBackgrounds()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		Object.Destroy((Object)(object)_child.gameObject);
		_child = null;
		Addressables.Release<GameObject>(_mapHandle);
		if (_leftCampHandle.IsValid())
		{
			Addressables.Release<GameObject>(_leftCampHandle);
		}
		if (_rightCampHandle.IsValid())
		{
			Addressables.Release<GameObject>(_rightCampHandle);
		}
	}

	public void SetScale(Vector3 scale)
	{
	}

	public void Update()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		if (Object.op_Implicit((Object)(object)_child))
		{
			Vector3 position = _farTrans.position;
			Vector3 position2 = _mainCameraTrans.position;
			position.x = position2.x * MapBackgroundController.FarBackgroundRatio;
			_farTrans.position = position;
			Vector3 position3 = _closeTrans.position;
			position3.x = position2.x * MapBackgroundController.CloseBackgroundRatio;
			_closeTrans.position = position3;
		}
	}

	private void LoadCamp()
	{
		if (MapCampConfigs.TryGetValue(Identifier, out var value))
		{
			InstantiateCamp(value.LeftCamp, "camp", ref _leftCampHandle);
			InstantiateCamp(value.RightCamp, "enemyCamp", ref _rightCampHandle);
		}
	}

	private void InstantiateCamp(string campAsset, string campName, ref AsyncOperationHandle<GameObject> handle)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (!string.IsNullOrEmpty(campAsset))
		{
			handle = Addressables.LoadAssetAsync<GameObject>((object)campAsset);
			handle.WaitForCompletion();
			Transform val = _child.transform.Find(campName);
			Object.Instantiate<GameObject>(handle.Result, val);
		}
	}
}
